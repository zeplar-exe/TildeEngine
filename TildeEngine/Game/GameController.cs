using OpenTK.Windowing.GraphicsLibraryFramework;
using TildeEngine.Input;
using TildeEngine.Scenes;

namespace TildeEngine.Game;

public abstract class GameController : IDisposable
{
    internal bool Enabled { get; set; }
    
    /// <summary>
    /// Called when the game application is initialized and before loading.
    /// </summary>
    public virtual void OnStart() { }
    /// <summary>
    /// Called after scene/frame rendering is completed.
    /// </summary>
    public virtual void OnRender() { }
    /// <summary>
    /// Called just before the scene/frame is rendered.
    /// </summary>
    public virtual void OnPreRender() { }
    /// <summary>
    /// Called when input is caught and rerouted
    /// </summary>
    /// <param name="key">Key state.</param>
    public virtual void OnInput(KeyState key) { }
    /// <summary>
    /// Called when an exception in the main thread is thrown.
    /// </summary>
    /// <param name="exception">The thrown exception.</param>
    public virtual void OnException(Exception exception) { }
    /// <summary>
    /// Called when the scene has successfully changed.
    /// </summary>
    /// <param name="old">The previous scene.</param>
    /// <param name="new">The new scene.</param>
    public virtual void OnSceneChange(Scene old, Scene @new) { }
    /// <summary>
    /// Called just before all assets are unloaded and the application closes.
    /// </summary>
    public virtual void OnGameClosing() { }

    /// <summary>
    /// Boolean value representing the object's state.
    /// </summary>
    /// <returns>A bool; True meaning that the object should not be operated on. False meaning the object can be used freely.</returns>
    public abstract bool IsLocked();

    public void Enable() => Enabled = true;
    public void Disable() => Enabled = false;
    
    public virtual void Dispose() { GC.SuppressFinalize(this); }
}