namespace TildeEngine.Graphics.Common;

public abstract class Shape
{
    protected Vector2 Position { get; }

    public Shape(Vector2 position)
    {
        Position = position;
    }

    public abstract IEnumerable<GraphicsTriangle> CreateTriangles();
}