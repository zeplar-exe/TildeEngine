using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using TildeEngine.ObjectProperties;
using TildeEngine.ObjectProperties.Animation;

namespace Engine_Unit_Tests.AnimationTests;

[TestFixture, Parallelizable]
public class DoubleAnimationTests : AnimationTest
{
    [Test]
    public void TestDoubleAnimation()
    {
        var animator = new DoubleProperty(1).Animate(10, new AnimationSettings { Length = TimeSpan.FromSeconds(1) });
        var interpolationValues = CreateProgressHandler(animator);
        
        animator.Start(CancellationToken.None).Wait(TimeSpan.FromSeconds(10));
        
        Assert.True(interpolationValues.SequenceEqual(
            new[] { 1.9, 2.8, 3.7, 4.6, 5.5, 6.3999999999999995, 7.3, 8.2, 9.1,9.999999999999998, 10  } ));
    }
    
    [Test]
    public void TestEmptyDoubleAnimation()
    {
        var animator = new DoubleProperty(0.5d).Animate(0.5d, new AnimationSettings { Length = TimeSpan.FromSeconds(1) });
        var interpolationValues = CreateProgressHandler(animator);
        
        animator.Start(CancellationToken.None).Wait(TimeSpan.FromSeconds(10));

        Assert.True(!interpolationValues.Any());
    }
}