using TildeEngine.ObjectProperties;

namespace TildeEngine.Time;

public static class Timescale
{
    public static DoubleProperty Scale { get; } = new(1);
}