using Pure.Primitives.Number;
using Pure.Primitives.Random.Number;
using System.Collections;

namespace Pure.Primitives.Random.Tests.Number;

public sealed record RandomDecimalCollectionTests
{
    [Fact]
    public void ProduceExactCount()
    {
        const ushort count = 1000;
        Assert.Equal(count, new RandomDecimalCollection(new UShort(count)).Count());
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        const ushort count = 1000;

        IEnumerable randoms = new RandomDecimalCollection(new UShort(count));

        int i = 0;

        foreach (object value in randoms)
        {
            i++;
        }

        Assert.Equal(count, i);
    }

    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        System.Random random = new System.Random();

        IEnumerable<double> values = new RandomDecimalCollection(new UShort(10000), random)
            .Select(x => Convert.ToDouble(x.NumberValue))
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 0, 1);
    }

    [Fact]
    public void ProduceNormalStandardDeviation()
    {
        IEnumerable<double> values = new RandomDecimalCollection(new UShort(10000))
            .Select(x => Convert.ToDouble(x.NumberValue))
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 0, 1);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new RandomDecimalCollection(new MinUshort()).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new RandomDecimalCollection(new MinUshort()).ToString());
    }
}