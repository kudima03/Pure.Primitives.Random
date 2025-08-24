using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Number;
using System.Collections;

namespace Pure.Primitives.Random.Tests.Number;

public sealed record RandomUShortCollectionTests
{
    [Fact]
    public void RangeAffectGeneration()
    {
        INumber<ushort> max = new RandomUShort(new UShort(10), new MaxUshort());
        INumber<ushort> min = new RandomUShort(new Zero<ushort>(), max);

        IEnumerable<ushort> values = new RandomUShortCollection(new MaxUshort(), min, max).Select(
            x => x.NumberValue
        );

        Assert.True(values.All(x => min.NumberValue <= x && x < max.NumberValue));
    }

    [Fact]
    public void ProduceExactCount()
    {
        const ushort count = 1000;
        Assert.Equal(count, new RandomUShortCollection(new UShort(count)).Count());
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        const ushort count = 1000;

        IEnumerable randoms = new RandomUShortCollection(new UShort(count));

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

        IEnumerable<int> values = new RandomUShortCollection(new UShort(10000), random)
            .Select(x => Convert.ToInt32(x.NumberValue))
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 18000, 20000);
    }

    [Fact]
    public void ProduceNormalStandardDeviation()
    {
        IEnumerable<int> values = new RandomUShortCollection(new UShort(10000))
            .Select(x => Convert.ToInt32(x.NumberValue))
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
            new RandomUShortCollection(new MinUshort()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() =>
            new RandomUShortCollection(new MinUshort()).ToString()
        );
    }
}