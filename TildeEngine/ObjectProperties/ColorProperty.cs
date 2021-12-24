using System.Drawing;
using TildeEngine.ObjectProperties.Animation;

namespace TildeEngine.ObjectProperties;

public class ColorProperty : ObjectProperty<Color>
{
    public ColorProperty(Color value) : base(value)
    {
        
    }

    public override Animator<Color> Animate(Color result, AnimationSettings settings)
    {
        var r = new IntegerProperty(Value.R).Animate(result.R, settings).GetPropertySequence().ToArray();
        var g = new IntegerProperty(Value.G).Animate(result.G, settings).GetPropertySequence().ToArray();
        var b = new IntegerProperty(Value.B).Animate(result.B, settings).GetPropertySequence().ToArray();
        var a = new IntegerProperty(Value.A).Animate(result.A, settings).GetPropertySequence().ToArray();

        var values = r.Select((_, i) => Color.FromArgb(a[i], r[i], g[i], b[i])).ToArray();

        return new Animator<Color>(this, values, settings.Length.TotalSeconds / values.Length);
    }
}