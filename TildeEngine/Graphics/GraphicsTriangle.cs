namespace TildeEngine.Graphics;

public sealed class GraphicsTriangle
{
    public Vector2 A { get; }
    public Vector2 B { get; }
    public Vector2 C { get; }
    
    public GraphicsTriangle(Vector2 a, Vector2 b, Vector2 c)
    {
        A = a;
        B = b;
        C = c;
    }

    public IEnumerable<float>CreateVertices()
    {
        yield return A.X;
        yield return A.Y;
        yield return 0;
        
        yield return B.X;
        yield return B.Y;
        yield return 0;
        
        yield return C.X;
        yield return C.Y;
        yield return 0;
    }
}