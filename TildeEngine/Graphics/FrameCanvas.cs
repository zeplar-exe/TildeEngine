using TildeEngine.Graphics.Common;

namespace TildeEngine.Graphics;

public class FrameCanvas
{
    private const float NormalizedDeviceCoordinateDivisor = 1f;
    private List<float> Vertices { get; }

    public FrameCanvas()
    {
        Vertices = new List<float>();
    }

    public IEnumerable<float> PullVertices() => Vertices;

    public void DrawShape(Shape shape)
    {
        foreach (var coordinate in shape.CreateVertices())
        {
            AddVertex(coordinate.X);
            AddVertex(coordinate.Y);
            AddVertex(0); // 2D only, Z axis is unnecessary
        }
    }

    private void AddVertex(float vertex)
    {
        if (vertex == 0)
            Vertices.Add(vertex);
        else
            Vertices.Add(NormalizedDeviceCoordinateDivisor / vertex);
    }

    public void Clear()
    {
        Vertices.Clear();
    }
}