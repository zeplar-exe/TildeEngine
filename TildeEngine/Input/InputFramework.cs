using OpenTK.Windowing.GraphicsLibraryFramework;

namespace TildeEngine.Input;

public static class InputFramework
{
    private static HashSet<Keys> PreviousFrameBuffer { get; }
    private static HashSet<Keys> CurrentFrameBuffer { get; }

    public static event EventHandler<Keys>? KeyPressed;
    public static event EventHandler<Keys>? KeyHeld;
    public static event EventHandler<Keys>? KeyReleased;

    static InputFramework()
    {
        PreviousFrameBuffer = new HashSet<Keys>();
        CurrentFrameBuffer = new HashSet<Keys>();
    }

    public static bool KeyIsPressed(Keys key)
    {
        return GetKeyState(key).Pressed;
    }

    public static bool KeyIsHeld(Keys key)
    {
        return GetKeyState(key).Held;
    }

    public static bool KeyIsReleased(Keys key)
    {
        return GetKeyState(key).Released;
    }

    public static KeyState GetKeyState(Keys key)
    {
        return new KeyState(key,
            CurrentFrameBuffer.Contains(key) && !PreviousFrameBuffer.Contains(key),
            CurrentFrameBuffer.Contains(key) && PreviousFrameBuffer.Contains(key),
            !CurrentFrameBuffer.Contains(key) && PreviousFrameBuffer.Contains(key));
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