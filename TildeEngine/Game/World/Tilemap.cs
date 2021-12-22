using TildeEngine.Graphics;

namespace TildeEngine.Game.World;

public class Tilemap : IDrawable
{
    public Tile[,] Tiles { get; }
    public Vector2Int Size { get; }
    
    public Tilemap(Vector2Int size)
    {
        Size = size;
        Tiles = new Tile[size.X, size.Y];
    }

    public void Draw(FrameCanvas canvas)
    {
        foreach (var tile in Tiles)
        {
            tile.Draw(canvas);
        }
    }
}