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
        // Something something integer interpolation

        throw new NotImplementedException();
    }
}