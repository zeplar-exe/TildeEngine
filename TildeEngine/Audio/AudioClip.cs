using CSCore;
using CSCore.Codecs;
using CSCore.CoreAudioAPI;
using CSCore.SoundOut;

namespace TildeEngine.Audio;

public class AudioClip : IDisposable
{
    private ISoundOut Output { get; }
    private IWaveSource Source { get; }

    public bool IsPlaying => Output.PlaybackState == PlaybackState.Playing;
    public bool IsPaused => Output.PlaybackState == PlaybackState.Paused;

    public TimeSpan PlaybackPosition => Source.GetPosition();
    public TimeSpan PlaybackLength => Source.GetLength();

    public event EventHandler<TimeSpan>? Started;
    public event EventHandler<TimeSpan>? Paused;
    public event EventHandler<TimeSpan>? Resumed;
    public event EventHandler<TimeSpan>? Stopped;

    public static AudioClip FromFile(string filePath, MMDevice device)
    {
        var source = CodecFactory.Instance.GetCodec(filePath)
                .ToSampleSource()
                .ToMono()
                .ToWaveSource();
        
        var output = new WasapiOut {Latency = 100, Device = device};

        return new AudioClip(output, source);
    }
    
    public AudioClip(ISoundOut output, IWaveSource source)
    {
        output.Initialize(source);
        
        Output = output;
        Source = source;
    }
    
    public void Start(CancellationToken token)
    {
        if (!IsPlaying)
            throw new InvalidOperationException("The audio clip is already playing.");
        
        Started?.Invoke(this, TimeSpan.Zero);
        Output.Play();
    }

    public void Resume()
    {
        if (!IsPaused)
            throw new InvalidOperationException("The audio clip is not paused.");
        
        Output.Resume();
        Resumed?.Invoke(this, PlaybackPosition);
    }

    public void Pause()
    {
        if (IsPaused)
            throw new InvalidOperationException("The audio clip is already paused.");
        
        Output.Pause();
        Paused?.Invoke(this, PlaybackPosition);
    }

    public void Stop()
    {
        if (!IsPlaying)
            throw new InvalidOperationException("The audio clip is not playing.");
        
        Output.Stop();
        Stopped?.Invoke(this, PlaybackPosition);
    }

    public void Restart(CancellationToken token)
    {
        Start(token);
    }

    public void Dispose()
    {
        Output.Dispose();
        Source.Dispose();
        GC.SuppressFinalize(this);
    }
}