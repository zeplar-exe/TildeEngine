using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using TildeEngine.Graphics;
using TildeEngine.OpenTK;
using TildeEngine.Scenes;

namespace TildeEngine.Game;

public class AppWindow : GameWindow
{
    private Shader Shader { get; set; }

    private int VertexBufferObject { get; set; }
    private int VertexArrayObject { get; set; }

    private Scene? b_scene;

    public Scene? Scene
    {
        get => b_scene;
        set
        {
            if (b_scene == value)
                return;

            SceneChanged?.Invoke(this, b_scene, value);
            
            b_scene = value;
        }
    }

    public delegate void SceneChangedHandler(AppWindow window, Scene? old, Scene? @new);
    public event SceneChangedHandler? SceneChanged;

    public event EventHandler? OnPreRender;

    internal AppWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) :
        base(gameWindowSettings, nativeWindowSettings)
    {
        
    }
    
    protected override void OnLoad()
    {
        Shader = new Shader("OpenTK/shader.vert", "OpenTK/shader.frag");
        VertexBufferObject = GL.GenBuffer();
        VertexArrayObject = GL.GenVertexArray();
        
        GL.BindVertexArray(VertexArrayObject);
        GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
        GL.ClearColor(1f, 1f, 1f, 1f);

        base.OnLoad();
    }
    
    protected override void OnUnload()
    {
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.DeleteBuffer(VertexBufferObject);

        Shader.Dispose();
        
        base.OnUnload();
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        if (Scene == null)
            return;

        GL.Clear(ClearBufferMask.ColorBufferBit);

        var canvas = new FrameCanvas(100f); // TODO: Make this customizable

        foreach (var drawable in Scene.Drawables)
        {
            drawable.Draw(canvas);
        }

        var vertices = canvas.PullVertices().ToArray();
        
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StreamDraw);
        
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
        GL.EnableVertexAttribArray(0);
        
        Shader.Use();
        
        GL.DrawArrays(PrimitiveType.TriangleFan, 0, 12);
        
        GL.DisableVertexAttribArray(0);

        OnPreRender?.Invoke(this, EventArgs.Empty);
        Context.SwapBuffers();
        base.OnRenderFrame(args);
    }
    
    protected override void OnResize(ResizeEventArgs e)
    {
        GL.Viewport(0, 0, e.Width, e.Height);
        
        base.OnResize(e);
    }
}