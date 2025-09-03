using System.Collections;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Bool;

namespace Pure.Primitives.Random.Tests.Bool;

using Random = System.Random;

public sealed record RandomBoolCollectionTests
{
    [Fact]
    public void ProduceExactCount()
    {
        const ushort count = 1000;
        Assert.Equal(count, new RandomBoolCollection(new UShort(count)).Count());
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable randoms = new RandomBoolCollection();

        int i = 0;

        foreach (object value in randoms)
        {
            i++;
        }

        Assert.True(i > 0);
    }

    [Fact]
    public void ProduceNormalDistributionWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. new RandomBoolCollection(new UShort(1000), random).Select(x =>
                Convert.ToInt32(x.BoolValue)
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 0.48, 0.5);
    }

    [Fact]
    public void ProduceNormalDistribution()
    {
        IEnumerable<int> values =
        [
            .. new RandomBoolCollection(new UShort(1000)).Select(x =>
                Convert.ToInt32(x.BoolValue)
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 0.48, 0.5);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RandomBoolCollection(new MinUshort()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RandomBoolCollection(new MinUshort()).ToString()
        );
    }
}
