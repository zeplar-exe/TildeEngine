using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TildeEngine;
using TildeEngine.Graphics;
using TildeEngine.Graphics.Common;

namespace Engine_Unit_Tests.GraphicsTests;

[TestFixture]
public class FrameCanvasTests
{
    [Test]
    public void TestShapeDraw()
    {
        var canvas = new FrameCanvas(1);
        
        canvas.DrawShape(new TestLineShape(new Vector2(0, 0)));
        
        Assert.True(canvas.PullVertices().SequenceEqual(
            new[] { 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f })); // (0, 0, 0), (1, 0, 0), (0, 0, 0)
    }
}

internal class TestLineShape : Shape
{
    public TestLineShape(Vector2 position) : base(position)
    {
        
    }

    public override IEnumerable<GraphicsTriangle> CreateTriangles()
    {
        yield return new GraphicsTriangle(
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 0));
    }
}