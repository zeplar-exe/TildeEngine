using TildeEngine.ObjectProperties.Animation;

namespace TildeEngine.ObjectProperties;

public class Vector2Property : ObjectProperty<Vector2>
{

    public Vector2Property(Vector2 value) : base(value)
    {
    }

    public override Animator<Vector2> Animate(Vector2 result, AnimationSettings settings)
    {
        // Something something integer interpolation
        
        throw new NotImplementedException();
    }
}