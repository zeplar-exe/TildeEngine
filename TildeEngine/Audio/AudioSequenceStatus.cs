using TildeEngine.ObjectProperties.Animation;

namespace TildeEngine.Audio;

public class AudioSequenceStatus
{
    public ProgressInfo Progress { get; }
    public AudioClip CurrentClip { get; }
    
    public AudioSequenceStatus(ProgressInfo progress, AudioClip currentClip)
    {
        Progress = progress;
        CurrentClip = currentClip;
    }
}