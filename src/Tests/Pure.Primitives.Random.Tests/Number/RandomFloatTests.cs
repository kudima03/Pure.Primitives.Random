using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.Tests.Number;

using Random = System.Random;

public sealed record RandomFloatTests
{
    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<float> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomFloat(random))
            .Cast<INumber<float>>()
            .Select(x => x.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 0.1, 1);
    }

    [Fact]
    public void ProduceNormalStandardDeviation()
    {
        IEnumerable<float> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomFloat())
            .Cast<INumber<float>>()
            .Select(x => x.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 0.1, 1);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new RandomFloat().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new RandomFloat().ToString());
    }
}