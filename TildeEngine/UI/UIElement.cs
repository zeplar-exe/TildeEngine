using TildeEngine.Graphics;
using TildeEngine.ObjectProperties;

namespace TildeEngine.UI;

public abstract class UIElement : IDrawable
{
    public Vector2Property Position { get; }
    public abstract Rect Bounds { get; }
    
    public ObjectPropertyMetadata Metadata { get; }
    
    protected UIElement(Vector2 position)
    {
        Position = new Vector2Property(position);
        Metadata = new ObjectPropertyMetadata();
    }

    public abstract void Draw(FrameCanvas canvas);
}