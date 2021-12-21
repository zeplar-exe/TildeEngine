using TildeEngine.ObjectProperties;

namespace TildeEngine.Time;

public static class Tick
{
    private static bool Enabled { get; set; }
    private static ulong Count { get; set; }
    
    public static TimeSpanProperty Interval { get; } = new(TimeSpan.FromMilliseconds(100));

    public static event EventHandler<ulong>? OnTick;

    static Tick()
    {
        EnableTickUpdate();
    }

    public static async void EnableTickUpdate()
    {
        Enabled = true;

        while (Enabled)
        {
            OnTick?.Invoke(null, ++Count);
            
            await Task.Delay(Interval);
        }
    }

    public static void DisableTickUpdate()
    {
        Enabled = false;
    }
}