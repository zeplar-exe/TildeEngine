using OpenTK.Windowing.GraphicsLibraryFramework;
using TildeEngine.Game;

namespace TildeEngine.Input;

public class InputFramework : GameController
{
    private HashSet<KeyState> PreviousFrameBuffer { get; }
    private HashSet<KeyState> CurrentFrameBuffer { get; }

    public event EventHandler<Keys>? KeyPressed;
    public event EventHandler<Keys>? KeyHeld;
    public event EventHandler<Keys>? KeyReleased;

    internal InputFramework()
    {
        PreviousFrameBuffer = new HashSet<KeyState>();
        CurrentFrameBuffer = new HashSet<KeyState>();
    }

    public override void OnInput(KeyState key)
    {
        CurrentFrameBuffer.Add(key);
        
        base.OnInput(key);
    }

    public override void OnPreRender()
    {
        PreviousFrameBuffer.Clear();

        foreach (var key in CurrentFrameBuffer)
            PreviousFrameBuffer.Add(key);
        
        CurrentFrameBuffer.Clear();
        
        base.OnPreRender();
    }

    public bool KeyIsPressed(Keys key)
    {
        return GetKeyState(key).Pressed;
    }

    public bool KeyIsHeld(Keys key)
    {
        return GetKeyState(key).Held;
    }

    public bool KeyIsReleased(Keys key)
    {
        return GetKeyState(key).Released;
    }

    public KeyState GetKeyState(Keys key)
    {
        var currentContains = CurrentFrameBuffer.Any(k => k.Key == key); 
        var previousContains = PreviousFrameBuffer.Any(k => k.Key == key); 
        
        return new KeyState(key, 
            currentContains && !previousContains,
            currentContains && previousContains,
            !currentContains && previousContains);
    }

    public override bool IsLocked()
    {
        return false;
    }
}

public readonly struct KeyState
{
    public Keys Key { get; }
    public bool Pressed { get; }
    public bool Held { get; }
    public bool Released { get; }

    public KeyState(Keys key, bool pressed, bool held, bool released)
    {
        Key = key;
        Pressed = pressed;
        Held = held;
        Released = released;
    }
}