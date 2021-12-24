using System.Collections;
using TildeEngine.Graphics;

namespace TildeEngine.Scenes;

public class Scene : IDrawableContainer<IDrawable>
{
    private List<IDrawable> b_drawables;

    public SceneCamera Camera { get; }
    public IEnumerable<IDrawable> Drawables => b_drawables;

    public Scene(SceneCamera camera)
    {
        Camera = camera;
        b_drawables = new List<IDrawable>();
    }

    public void AddDrawable(IDrawable drawable) => b_drawables.Add(drawable);
    public bool RemoveDrawable(IDrawable drawable) => b_drawables.Remove(drawable);
    
    public IEnumerator<IDrawable> GetEnumerator()
    {
        return Drawables.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}