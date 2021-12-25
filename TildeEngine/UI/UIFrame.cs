using System.Collections;
using TildeEngine.Graphics;

namespace TildeEngine.UI;

public class UIFrame : UIElement, IDrawableContainer<UIElement>
{
    private readonly List<UIElement> b_elements;
    
    public IEnumerable<UIElement> Drawables => b_elements;

    public override Rect Bounds
    {
        get
        {
            var bottomLeft = new Vector2(
                Drawables.Min(e => e.Position.Value.X), Drawables.Min(e => e.Position.Value.Y));
            var topRight = new Vector2(
                Drawables.Max(e => e.Position.Value.X), Drawables.Max(e => e.Position.Value.Y));
            var points = new[] { bottomLeft, topRight };
            
            return new Rect(bottomLeft, 
                points.MaxBy(e => e.Magnitude) - points.MinBy(e => e.Magnitude));
        }
    }

    public UIFrame(Vector2 position) : base(position)
    {
        b_elements = new List<UIElement>();
    }
    
    // Collection initializer method
    public void Add(UIElement element)
    {
        b_elements.Add(element);
    }
    
    public override void Draw(FrameCanvas canvas)
    {
        foreach (var element in Drawables)
            element.Draw(canvas);
    }

    public IEnumerator<UIElement> GetEnumerator()
    {
        return Drawables.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}