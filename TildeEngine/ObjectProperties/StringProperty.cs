using TildeEngine.ObjectProperties.Animation;

namespace TildeEngine.ObjectProperties;

public class StringProperty : ObjectProperty<string>
{
    public StringProperty(string value) : base(value)
    {
        
    }

    public override Animator<string> Animate(string result, AnimationSettings settings) 
        // TODO: Maybe use ObjectPropertyMetadata instead 
    {
        var fixedValue = Value ?? string.Empty;
        var values = new List<string>();

        if (result == null) 
            throw new ArgumentNullException(nameof(result));

        if (string.IsNullOrEmpty(fixedValue) && string.IsNullOrEmpty(result))
            return new Animator<string>(this, Enumerable.Empty<string>(), settings.Length.TotalSeconds);

        var valueIndex = 0;

        for (; valueIndex < fixedValue.Length; valueIndex++)
        {
            if (fixedValue[valueIndex] == result[valueIndex])
                continue; // Skip until we find a difference

            var removalIndex = fixedValue.Length;

            for (; removalIndex >= valueIndex; removalIndex--)
            { // Remove values in reverse until we reached the point of divergence
                values.Add(fixedValue[..removalIndex]);
            }

            break;
        }

        for (; valueIndex < result.Length; valueIndex++)
        { // Append missing values if any
            values.Add(values.Last() + result[valueIndex]);
        }

        return new Animator<string>(this, values, settings.Length.TotalSeconds / values.Count);
    }
}