using System.Drawing;
using TildeEngine.Graphics;
using TildeEngine.Graphics.Common;
using TildeEngine.ObjectProperties;

namespace TildeEngine.Game.World.Common;

public class ColoredTile : Tile
{
    public ColorProperty Color { get; }
    
    public ColoredTile(Vector2 position, Color color) : base(position)
    {
        Color = new ColorProperty(color);
    }
    
    public override void Draw(FrameCanvas canvas)
    {
        canvas.DrawShape(new Square(Position, new Vector2(30, 30)));
    }
}