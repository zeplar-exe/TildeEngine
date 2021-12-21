namespace TildeEngine.ObjectProperties.Animation;

public class Animator<TProperty>
{
    private bool IsAnimating { get; set; }
    
    private int Index { get; set; }
    private ObjectProperty<TProperty> Property { get; }
    private TProperty[] Values { get; }
    private double Interval { get; }

    private IProgress<AnimationStatus<TProperty>> InterfaceProgress => Progress;
    public Progress<AnimationStatus<TProperty>> Progress { get; }

    internal Animator(ObjectProperty<TProperty> property, IEnumerable<TProperty> values, double interval)
    {
        Property = property ?? throw new ArgumentNullException(nameof(property));
        Values = values?.ToArray() ?? throw new ArgumentNullException(nameof(values));
        Interval = interval;

        Progress = new Progress<AnimationStatus<TProperty>>();
    }
    
    public IEnumerable<TProperty> GetPropertySequence() => Values;

    public void Start()
    {
        Restart();
    }
    
    public async Task StartAsync()
    {
        await RestartAsync();
    }

    public void Pause()
    {
        IsAnimating = false;
    }

    public async void Restart()
    {
        IsAnimating = true;

        Animate();
    }
    
    public async Task RestartAsync()
    {
        IsAnimating = true;
        
        await AnimateAsync();
    }

    private void Animate()
    {
        for (; Index < Values.LongLength; Index++)
        {
            if (!IsAnimating)
                return;
            
            var value = Values[Index];
                        
            Property.Value = value;
            InterfaceProgress.Report(CreateStatus());

            Thread.Sleep(TimeSpan.FromSeconds(Interval));
        }
    }

    private async Task AnimateAsync()
    {
        for (; Index < Values.LongLength; Index++)
        {
            if (!IsAnimating)
                return;
            
            var value = Values[Index];
                        
            Property.Value = value;
            InterfaceProgress.Report(CreateStatus());

            await Task.Delay(TimeSpan.FromSeconds(Interval));
        }
    }

    private AnimationStatus<TProperty> CreateStatus()
    {
        return new AnimationStatus<TProperty>(
            Index == Values.LongLength - 1,
            new ProgressInfo(Index, Values.LongLength),
            Values[Index]);
    }
}