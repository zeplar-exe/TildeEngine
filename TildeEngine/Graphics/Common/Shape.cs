namespace TildeEngine.Graphics.Common;

public abstract class Shape
{
    protected Vector2 Position { get; }
    protected Vector2 Size { get; }

    public Shape(Vector2 position, Vector2 size)
    {
        Position = position;
        Size = size;
    }

    public abstract IEnumerable<Vector2> CreateVertices();
}