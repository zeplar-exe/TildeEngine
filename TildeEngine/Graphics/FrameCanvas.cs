using TildeEngine.Graphics.Common;

namespace TildeEngine.Graphics;

public class FrameCanvas
{
    private const float NormalizedDeviceCoordinateDivisor = 1f;
    private List<float> Vertices { get; }
    
    public float Scale { get; }

    public FrameCanvas(float scale)
    {
        Vertices = new List<float>();
        Scale = scale;
    }

    public IEnumerable<float> PullVertices() => Vertices;

    public void DrawShape(Shape shape)
    {
        foreach (var triangle in shape.CreateTriangles())
        {
            foreach (var vertex in triangle.CreateVertices())
            {
                AddVertex(vertex / Scale);
            }
        }
    }

    private void AddVertex(float vertex)
    {
        Vertices.Add(vertex);
    }

    public void Clear()
    {
        Vertices.Clear();
    }
}