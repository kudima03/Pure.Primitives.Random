﻿using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Random.Char;

namespace Pure.Primitives.Random.Tests.Char;

using Random = System.Random;

public sealed record RandomCharTests
{
    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomChar(random))
            .Cast<IChar>()
            .Select(x => Convert.ToInt32(x.CharValue))
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 18000, 20000);
    }

    [Fact]
    public void ProduceNormalStandardDeviation()
    {
        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomChar())
            .Cast<IChar>()
            .Select(x => Convert.ToInt32(x.CharValue))
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 18000, 20000);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new RandomChar().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new RandomChar().ToString());
    }
}