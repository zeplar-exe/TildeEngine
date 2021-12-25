using System;
using System.Linq;
using NUnit.Framework;
using TildeEngine.ObjectProperties;
using TildeEngine.ObjectProperties.Animation;

namespace Engine_Unit_Tests.AnimationTests;

[TestFixture, Parallelizable]
public class FloatAnimationTests : AnimationTest
{
    [Test]
    public void TestFloatAnimation()
    {
        var animator = new FloatProperty(1f).Animate(10f, new AnimationSettings { Length = TimeSpan.FromSeconds(1) });
        var interpolationValues = CreateProgressHandler(animator, Console.WriteLine);
        
        animator.StartAsync().Wait(TimeSpan.FromSeconds(10));
        
        Assert.True(interpolationValues.SequenceEqual(
            new[] { 1.9f, 2.8f, 3.7f, 4.6f, 5.5f, 6.4f, 7.3f, 8.2f, 9.1f, 10f  } ));
    }
    
    [Test]
    public void TestEmptyFloatAnimation()
    {
        var animator = new FloatProperty(0.5f).Animate(0.5f, new AnimationSettings { Length = TimeSpan.FromSeconds(1) });
        var interpolationValues = CreateProgressHandler(animator);
        
        animator.StartAsync().Wait(TimeSpan.FromSeconds(10));

        Assert.True(!interpolationValues.Any());
    }
}