using TildeEngine.ObjectProperties.Animation;

namespace TildeEngine.ObjectProperties;

public class DoubleProperty : ObjectProperty<double>
{
    public DoubleProperty(double value) : base(value)
    {
        
    }
    public override Animator<double> Animate(double result, AnimationSettings settings)
    {
        var values = new List<double>();

        switch (settings.Type)
        {
            case AnimationType.Linear:
            {
                var minAlpha = 0.1 * (1 / settings.Length.TotalSeconds);

                var alpha = 0d;

                while ((alpha += minAlpha) < 1)
                {
                    values.Add(Value + alpha * (result - Value));
                }
        
                if (Math.Abs(values.Last() - result) > 0.0000000000000001)
                    values.Add(result);
                
                break;
            }
        }

        return new Animator<double>(this, values, settings.Length.TotalSeconds / values.Count);
    }
}