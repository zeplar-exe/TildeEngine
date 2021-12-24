using TildeEngine.Graphics;

namespace TildeEngine.UI;

public abstract class UIElement : IDrawable
{
    public Vector2 Position { get; }
    public abstract Rect Bounds { get; }
    
    protected UIElement(Vector2 position)
    {
        Position = position;
    }

    public abstract void Draw(FrameCanvas canvas);
}