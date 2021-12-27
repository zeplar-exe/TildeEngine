using System.Collections;
using System.Runtime.CompilerServices;
using TildeEngine.ObjectProperties.Animation;

namespace TildeEngine.Audio;

public class AudioSequence : IEnumerable<AudioClip>
{
    private List<AudioClip> Clips { get; }
    private List<AudioClip>? OrderedClips { get; set; }
    
    private bool IsRunning { get; set; }
    private int CurrentIndex { get; set; }

    public AudioClip? Current => Clips.ElementAtOrDefault(CurrentIndex);
    
    public AudioSequence(IEnumerable<AudioClip>? clips)
    {
        Clips = clips?.ToList() ?? new List<AudioClip>();
    }

    public void Shuffle()
    {
        var random = new Random();
        
        OrderedClips = Clips.OrderBy(_ => random.Next(0, Clips.Count * random.Next(2, 10))).ToList();
    }

    public async IAsyncEnumerable<AudioSequenceStatus> StartFrom(int index, [EnumeratorCancellation] CancellationToken token)
    {
        CurrentIndex = index;

        await foreach (var status in Start(token))
        {
            yield return status;
        }
    }

    public async IAsyncEnumerable<AudioSequenceStatus> Start([EnumeratorCancellation] CancellationToken token)
    {
        OrderedClips ??= Clips;
        
        for (; CurrentIndex < OrderedClips.Count; CurrentIndex++)
        {
            if (token.IsCancellationRequested || !IsRunning)
                yield break;
            
            var clip = OrderedClips[CurrentIndex];

            yield return new AudioSequenceStatus(
                new ProgressInfo(CurrentIndex, OrderedClips.Count), 
                Current!);
            
            clip.Start(token);

            while (IsRunning && !token.IsCancellationRequested && clip.IsPlaying)
            {
                await Task.Delay(100, token);
            }
        }
    }
    
    public void Stop()
    {
        IsRunning = false;
    }

    public async IAsyncEnumerable<AudioSequenceStatus> Restart([EnumeratorCancellation] CancellationToken token)
    {
        await foreach (var status in StartFrom(0, token))
        {
            yield return status;
        }
    }

    public IEnumerator<AudioClip> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}