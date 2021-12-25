using System;
using System.Collections.Generic;
using TildeEngine.ObjectProperties.Animation;

namespace Engine_Unit_Tests.AnimationTests;

public abstract class AnimationTest
{
    protected List<T> CreateProgressHandler<T>(Animator<T> animator, Action<T>? onProgressChanged = null)
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