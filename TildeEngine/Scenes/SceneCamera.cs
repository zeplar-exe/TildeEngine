using TildeEngine.ObjectProperties;

namespace TildeEngine.Scenes;

public abstract class SceneCamera
{
    public Vector2Property Position { get; }
    public Vector2Property ViewSize { get; }

    protected SceneCamera()
    {
        Position = new Vector2Property(new Vector2(0, 0));
        ViewSize = new Vector2Property(new Vector2(10, 10));
    }
}