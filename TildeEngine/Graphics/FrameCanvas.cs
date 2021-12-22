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
        foreach (var vertex in shape.CreateVertices())
        {
            if (vertex == 0)
                Vertices.Add(vertex);
            else
                Vertices.Add(NormalizedDeviceCoordinateDivisor / vertex);
        }
    }

    public void Clear()
    {
        Vertices.Clear();
    }
}