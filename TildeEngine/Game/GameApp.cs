using System.Drawing;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using TildeEngine.Game.World.Common;
using TildeEngine.Input;
using TildeEngine.Scenes;

namespace TildeEngine.Game;

public class GameApp : IDisposable
{
    private AppWindow Window { get; }
    private List<GameController> Controllers { get; }
    
    public event EventHandler? WindowClosed;
    public InputFramework InputFramework { get; }
    
    public GameApp()
    {
        Window = new AppWindow(GameWindowSettings.Default, new NativeWindowSettings
        {
            API = ContextAPI.OpenGL,
            Size = new Vector2i(800, 500)
        });
        
        Window.Scene = new Scene(new StaticCamera());
        Window.Scene.AddDrawable(new ColoredTile(new Vector2(0, 0), Color.Aqua));

        Controllers = new List<GameController>();
        InputFramework = new InputFramework();
        
        HookController(InputFramework);
    }

    /// <summary>
    /// Hook a game controller to the update loop.
    /// </summary>
    /// <param name="controller">The game controller to be hooked.</param>
    public void HookController(GameController controller)
    {
        Controllers.Add(controller);
        
        InitializeControllerEventHandlers(controller);
    }
    
    private void InitializeControllerEventHandlers(GameController controller)
    {
        Window.RenderFrame += e => controller.OnRender(e.Time);
        Window.KeyDown += e => controller.OnInput(new KeyState(e.Key, true, false, false));
        Window.KeyUp += e => controller.OnInput(new KeyState(e.Key, false, false, true));
        Window.SceneChanged += (_, old, @new) => controller.OnSceneChange(old, @new);
        Window.Closing += _ => controller.OnGameClosing();
        
        // TODO: Handle exceptions
        // TODO: Handle control keys in input
    }
    
    /// <summary>
    /// Initializes the application and opens the game window.
    /// </summary>
    /// <param name="closeType">Defines how the application should act once the window closes.</param>
    public void Start(CloseHandler closeType)
    {
        Window.Run();
        
        foreach (var controller in Controllers)
            controller.OnStart();

        switch (closeType)
        {
            case CloseHandler.InvokeEvent:
                Window.Closed += () => WindowClosed?.Invoke(this, EventArgs.Empty);
                break;
            case CloseHandler.Kill:
                Window.Closed += Kill;
                break;
        }
    }

    /// <summary>
    /// Kills the application and disposes of any hooked controllers.
    /// </summary>
    public void Kill()
    {
        foreach (var controller in Controllers)
        {
            controller.Dispose();
        }
        
        Window.Close();
    }

    public void Dispose()
    {
        Kill();
        Window.Dispose();
        GC.SuppressFinalize(this);
    }
}

public enum CloseHandler
{
    None = 0,
    
    InvokeEvent,
    Kill
}