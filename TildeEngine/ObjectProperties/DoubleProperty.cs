using TildeEngine.ObjectProperties.Animation;

namespace TildeEngine.ObjectProperties;

public class DoubleProperty : ObjectProperty<double>
{
    public DoubleProperty(double value) : base(value)
    {
        
    }
    public override Animator<double> Animate(double result, AnimationSettings settings)
    {
        var difference = Math.Max(Value, result) - Math.Min(Value, result);

        if (result < Value)
            difference = -difference;
        
        var minAlpha = 0.1 * (1 / settings.Length.TotalSeconds);
        var values = new List<double>();
        
        var alpha = 0d;

        while ((alpha += minAlpha) < 1)
        {
            values.Add(Value + alpha * (result - Value));
        }
        
        if (Math.Abs(values.Last() - result) > 0.0000000000000001)
            values.Add(result);

        return new Animator<double>(this, values, settings.Length.TotalSeconds / values.Count);
    }
}