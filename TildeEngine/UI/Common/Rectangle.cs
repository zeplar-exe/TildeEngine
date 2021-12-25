using System.Drawing;
using TildeEngine.Graphics;
using TildeEngine.Graphics.Common;
using TildeEngine.ObjectProperties;

namespace TildeEngine.UI.Common;

public class Rectangle : UIElement
{
    public Vector2Property Size { get; }
    public ColorProperty Color { get; }
    
    public override Rect Bounds => new(Position, Size);
    
    public Rectangle(Vector2 position, Vector2 size) : base(position)
    {
        Size = new Vector2Property(size);
        Color = new ColorProperty(default);
    }

    public override void Draw(FrameCanvas canvas)
    {
        canvas.DrawShape(new Square(Position, Size));
    }
}