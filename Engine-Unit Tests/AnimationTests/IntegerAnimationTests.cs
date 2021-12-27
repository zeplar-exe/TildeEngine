using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using TildeEngine.ObjectProperties;
using TildeEngine.ObjectProperties.Animation;

namespace Engine_Unit_Tests.AnimationTests;

[TestFixture, Parallelizable]
public class IntegerAnimationTests : AnimationTest
{
    [Test]
    public void TestIntAnimation()
    {
        var animator = new IntegerProperty(0).Animate(10, new AnimationSettings { Length = TimeSpan.FromSeconds(1) });
        var interpolationValues = CreateProgressHandler(animator);
        
        animator.Start(CancellationToken.None).Wait(TimeSpan.FromSeconds(10));
        
        Assert.True(interpolationValues.SequenceEqual(
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } ));
    }
}