using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.Tests.Number;

using Random = System.Random;

public sealed record RandomUShortTests
{
    [Fact]
    public void ProduceMaxValue()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 1000000)
            .Select(_ => new RandomUShort(random))
            .Cast<INumber<ushort>>()
            .Select(x => (int)x.NumberValue)
            .ToHashSet();

        Assert.Contains(ushort.MaxValue, values);
    }

    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomUShort(random))
            .Cast<INumber<ushort>>()
            .Select(x => (int)x.NumberValue)
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
            .Select(_ => new RandomUShort())
            .Cast<INumber<ushort>>()
            .Select(x => (int)x.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 18000, 20000);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new RandomUShort().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new RandomUShort().ToString());
    }
}