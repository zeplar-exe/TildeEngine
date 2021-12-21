using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using TildeEngine;
using TildeEngine.ObjectProperties.Animation;
using TildeEngine.Time;

namespace Engine_Unit_Tests;

public class AnimationTests
{
    [Test]
    public void TestDoubleAnimation()
    {
        var animator = Timescale.Scale.Animate(10, new AnimationSettings { Length = TimeSpan.FromSeconds(1) });
        var interpolationValues = new List<double>();
        
        animator.Progress.ProgressChanged += delegate(object? sender, AnimationStatus<double> status)
        {
            interpolationValues.Add(status.NewValue);
        };
        
        animator.StartAsync().Wait(TimeSpan.FromSeconds(10));
        
        Assert.True(interpolationValues.SequenceEqual(
            new[] { 1.9, 2.8, 3.7, 4.6, 5.5, 6.3999999999999995, 7.3, 8.2, 9.1,9.999999999999998, 10  } ));
    }
}