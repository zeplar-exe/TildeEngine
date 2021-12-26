using TildeEngine.Graphics;
using TildeEngine.ObjectProperties.Animation;

namespace TildeEngine.ObjectProperties;

public class ColorArgbProperty : ObjectProperty<ColorArgb>
{
    public ColorArgbProperty(ColorArgb value) : base(value)
    {
        
    }

    public override Animator<ColorArgb> Animate(ColorArgb result, AnimationSettings settings)
    {
        var a = new IntegerProperty(Value.Alpha).Animate(result.Alpha, settings).GetPropertySequence().ToArray();
        var r = new IntegerProperty(Value.R).Animate(result.R, settings).GetPropertySequence().ToArray();
        var g = new IntegerProperty(Value.G).Animate(result.G, settings).GetPropertySequence().ToArray();
        var b = new IntegerProperty(Value.B).Animate(result.B, settings).GetPropertySequence().ToArray();

        var values = r.Select((_, i) => new ColorArgb(a[i], r[i], g[i], b[i])).ToArray();

        return new Animator<ColorArgb>(this, values, settings.Length.TotalSeconds / values.Length);
    }
}