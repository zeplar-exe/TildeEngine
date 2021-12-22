using TildeEngine.Graphics;

namespace TildeEngine.Scenes;

public class Scene
{
    public SceneCamera Camera { get; }
    public List<IDrawable> Drawables { get; }

    public Scene(SceneCamera camera)
    {
        Camera = camera;
        Drawables = new List<IDrawable>();
    }
}