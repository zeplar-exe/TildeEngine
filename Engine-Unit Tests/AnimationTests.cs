using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TildeEngine.ObjectProperties;
using TildeEngine.ObjectProperties.Animation;
using TildeEngine.Time;

namespace Engine_Unit_Tests;

public class AnimationTests
{
    [Test]
    public void TestIntAnimation()
    {
        var animator = new IntegerProperty(0).Animate(10, new AnimationSettings { Length = TimeSpan.FromSeconds(1) });
        var interpolationValues = CreateProgressHandler(animator);
        
        animator.StartAsync().Wait(TimeSpan.FromSeconds(10));
        
        Assert.True(interpolationValues.SequenceEqual(
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } ));
    }
    
    [Test]
    public void TestDoubleAnimation()
    {
        var animator = new DoubleProperty(1).Animate(10, new AnimationSettings { Length = TimeSpan.FromSeconds(1) });
        var interpolationValues = CreateProgressHandler(animator);
        
        animator.StartAsync().Wait(TimeSpan.FromSeconds(10));
        
        Assert.True(interpolationValues.SequenceEqual(
            new[] { 1.9, 2.8, 3.7, 4.6, 5.5, 6.3999999999999995, 7.3, 8.2, 9.1,9.999999999999998, 10  } ));
    }

    [Test]
    public void TestStringAnimation()
    {
        var begin = "Hello world";
        var end = "Hello, world";
        
        var animator = new StringProperty(begin).Animate(end,
            new AnimationSettings { Length = TimeSpan.FromSeconds(1) });
        var interpolationValues = CreateProgressHandler(animator, Console.WriteLine);
        
        animator.StartAsync().Wait(TimeSpan.FromSeconds(10));

        Assert.True(interpolationValues.First() == begin && interpolationValues.Last() == end);
    }

    private List<T> CreateProgressHandler<T>(Animator<T> animator, Action<T>? onProgressChanged = null)
    {
        var interpolationValues = new List<T>();

        animator.Progress.ProgressChanged += delegate(object? sender, AnimationStatus<T> status)
        {
            onProgressChanged?.Invoke(status.NewValue);
            interpolationValues.Add(status.NewValue);
        };

        return interpolationValues;
    }
}