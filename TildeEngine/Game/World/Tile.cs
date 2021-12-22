using TildeEngine.Graphics;

namespace TildeEngine.Game.World;

public abstract class Tile : IDrawable
{
    public Vector2 Position { get; }

    protected Tile(Vector2 position)
    {
        Position = position;
    }

    public abstract void Draw(FrameCanvas canvas);
}