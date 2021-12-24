using TildeEngine.Graphics;
using TildeEngine.ObjectProperties;

namespace TildeEngine.UI;

public abstract class UIElement : IDrawable
{
    public Vector2 Position { get; }
    public abstract Rect Bounds { get; }
    
    public ObjectPropertyMetadata Metadata { get; }
    
    protected UIElement(Vector2 position)
    {
        Position = position;
        Metadata = new ObjectPropertyMetadata();
    }

    public abstract void Draw(FrameCanvas canvas);
}