using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace TildeEngine.OpenTK;

public class Shader : IDisposable
{
    public int Handle { get; }

    public Shader(string vertexPath, string fragmentPath)
    {
        var vertexShader = 0;
        var fragmentShader = 0;
        
        var vertexShaderSource = string.Empty;

        using (var reader = new StreamReader(vertexPath, Encoding.UTF8))
        {
            vertexShaderSource = reader.ReadToEnd();
        }

        var fragmentShaderSource = string.Empty;

        using (var reader = new StreamReader(fragmentPath, Encoding.UTF8))
        {
            fragmentShaderSource = reader.ReadToEnd();
        }
        
        vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, vertexShaderSource);

        fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShader, fragmentShaderSource);
        
        GL.CompileShader(vertexShader);

        var infoLogVert = GL.GetShaderInfoLog(vertexShader);
        
        if (!string.IsNullOrEmpty(infoLogVert))
            Console.WriteLine(infoLogVert); // TODO: Use a logger

        GL.CompileShader(fragmentShader);

        var infoLogFrag = GL.GetShaderInfoLog(fragmentShader);

        if (infoLogFrag != string.Empty)
            Console.WriteLine(infoLogFrag);
        
        Handle = GL.CreateProgram();

        GL.AttachShader(Handle, vertexShader);
        GL.AttachShader(Handle, fragmentShader);

        GL.LinkProgram(Handle);
        
        GL.DetachShader(Handle, vertexShader);
        GL.DetachShader(Handle, fragmentShader);
        GL.DeleteShader(fragmentShader);
        GL.DeleteShader(vertexShader);
    } // Courtesy of https://opentk.net/learn/chapter1/2-hello-triangle.html
    
    ~Shader()
    {
        GL.DeleteProgram(Handle);
    }
    
    public void Use()
    {
        GL.UseProgram(Handle);
    }
    
    private bool disposedValue;

    public virtual void Dispose()
    {
        if (disposedValue) 
            return;
        
        GL.DeleteProgram(Handle);

        disposedValue = true;
    }
}