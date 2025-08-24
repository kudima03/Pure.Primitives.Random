using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Random.Bool;

namespace Pure.Primitives.Random.Tests.Bool;

using Random = System.Random;

public sealed record RandomBoolTests
{
    [Fact]
    public void ProduceCorrectlyWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable
            .Range(0, 10000)
            .Select(_ => new RandomBool(random))
            .Cast<IBool>()
            .Select(x => Convert.ToInt32(x.BoolValue))
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 0.48, 0.5);
    }

    [Fact]
    public void ProduceCorrectlyOnSequentialCall()
    {
        IEnumerable<int> values = Enumerable
            .Range(0, 10000)
            .Select(_ => new RandomBool())
            .Cast<IBool>()
            .Select(x => Convert.ToInt32(x.BoolValue))
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 0.48, 0.5);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new RandomBool().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new RandomBool().ToString());
    }
}