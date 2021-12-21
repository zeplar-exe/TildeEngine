using TildeEngine.ObjectProperties.Animation;

namespace TildeEngine.ObjectProperties;

public abstract class ObjectProperty<TValue>
{
    private TValue? b_value;
    public TValue? Value
    {
        get => b_value;
        set
        {
            if (b_value?.Equals(value) == true)
                return;

            b_value = value;
            ValueChanged?.Invoke(this, value);
        }
    }

    public event EventHandler<TValue>? ValueChanged;

    protected ObjectProperty(TValue value)
    {
        Value = value;
    }

    public abstract Animator<TValue> Animate(TValue result, AnimationSettings settings);
}