using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.Tests.Number;

using Random = System.Random;

public sealed record RandomUIntTests
{
    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomUInt(random))
            .Cast<INumber<uint>>()
            .Select(x => (int)x.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 1230000000, 1250000000);
    }

    [Fact]
    public void ProduceNormalStandardDeviation()
    {
        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomUInt())
            .Cast<INumber<uint>>()
            .Select(x => (int)x.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 1230000000, 1250000000);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new RandomUInt().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new RandomUInt().ToString());
    }
}