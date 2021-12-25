using System;
using System.Linq;
using NUnit.Framework;
using TildeEngine.ObjectProperties;
using TildeEngine.ObjectProperties.Animation;

namespace Engine_Unit_Tests.AnimationTests;

[TestFixture, Parallelizable]
public class StringAnimationTests : AnimationTest
{
    [Test]
    public void TestStringAnimation()
    {
        var begin = "Hello world";
        var end = "Hello, world";
        
        var animator = new StringProperty(begin).Animate(end, new AnimationSettings { Length = TimeSpan.FromSeconds(1) });
        var interpolationValues = CreateProgressHandler(animator, Console.WriteLine);
        
        animator.StartAsync().Wait(TimeSpan.FromSeconds(10));

        Assert.True(interpolationValues.First() == begin && interpolationValues.Last() == end);
    }

    [Test]
    public void TestEmptyStringAnimation()
    {
        var animator = new StringProperty("").Animate("", new AnimationSettings { Length = TimeSpan.FromSeconds(1) });
        var interpolationValues = CreateProgressHandler(animator, Console.WriteLine);
        
        animator.StartAsync().Wait(TimeSpan.FromSeconds(10));

        Assert.True(!interpolationValues.Any());
    }
}