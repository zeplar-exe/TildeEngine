namespace TildeEngine.Graphics.Common;

public class Square : Shape
{
    public Vector2 Size { get; }
    
    public Square(Vector2 position, Vector2 size) : base(position)
    {
        Size = size;
    }

    public override IEnumerable<GraphicsTriangle> CreateTriangles()
    {
        yield return new GraphicsTriangle(
            new Vector2(Position.X, Position.Y), // Bottom left
            new Vector2(Position.X + Size.X, Position.Y), // Bottom right
            new Vector2(Position.X, Position.Y + Size.Y)); // Top Left

        yield return new GraphicsTriangle(
            new Vector2(Position.X, Position.Y + Size.Y), // Top Left
            new Vector2(Position.X + Size.X, Position.Y + Size.Y), // Top Right
            new Vector2(Position.X + Size.X, Position.Y)); // Bottom Right
    }
}