using Pure.Primitives.Number;
using Pure.Primitives.Random.Char;
using System.Collections;

namespace Pure.Primitives.Random.Tests.Char;

using Random = System.Random;

public sealed record RandomCharCollectionTests
{
    [Fact]
    public void ProduceExactCount()
    {
        const ushort count = 1000;
        Assert.Equal(count, new RandomCharCollection(new UShort(count)).Count());
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable randoms = new RandomCharCollection();

        int i = 0;

        foreach (object value in randoms)
        {
            i++;
        }

        Assert.True(i > 0);
    }

    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<int> values = new RandomCharCollection(new UShort(10000), random)
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
        IEnumerable<int> values = new RandomCharCollection(new UShort(10000))
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
        Assert.Throws<NotSupportedException>(() =>
            new RandomCharCollection(new MinUshort()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() =>
            new RandomCharCollection(new MinUshort()).ToString()
        );
    }
}