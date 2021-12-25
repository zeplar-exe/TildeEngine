namespace TildeEngine.Graphics.Common;

public class Square : Shape
{
    public Vector2 Size { get; }
    
    public Square(Vector2 position, Vector2 size) : base(position)
    {
        Size = size;
    }

    public override IEnumerable<Vector2> CreateVertices()
    {
        yield return new Vector2(Position.X, Position.Y); // Bottom left

        yield return new Vector2(Position.X, Position.Y + Size.Y); // Bottom right
        
        yield return new Vector2(Position.X + Size.X, Position.Y + Size.Y); // Top right
        
        yield return new Vector2(Position.X + Size.X, Position.Y); // Top left
    }
}