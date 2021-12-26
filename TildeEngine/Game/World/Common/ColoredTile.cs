using TildeEngine.Graphics;
using TildeEngine.Graphics.Color;
using TildeEngine.Graphics.Common;
using TildeEngine.ObjectProperties;

namespace TildeEngine.Game.World.Common;

public class ColoredTile : Tile
{
    public ColorArgbProperty Color { get; }
    
    public ColoredTile(Vector2 position, ColorArgb color) : base(position)
    {
        Color = new ColorArgbProperty(color);
    }
    
    public override void Draw(FrameCanvas canvas)
    {
        canvas.DrawShape(new Square(Position, new Vector2(30, 30)));
    }
}