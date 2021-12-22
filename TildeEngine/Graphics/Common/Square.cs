namespace TildeEngine.Graphics.Common;

public class Square : Shape
{
    public Square(Vector2 position, Vector2 size) : base(position, size)
    {
        
    }

    public override IEnumerable<float> CreateVertices()
    {
        yield return Position.X;
        yield return Position.Y;
        yield return 0f;

        yield return Position.X + Size.X;
        yield return Position.Y;
        yield return 0f;
        
        yield return Position.X;
        yield return Position.Y + Size.Y;
        yield return 0f;
        
        yield return Position.X + Size.X;
        yield return Position.Y + Size.Y;
        yield return 0f;
    }
}