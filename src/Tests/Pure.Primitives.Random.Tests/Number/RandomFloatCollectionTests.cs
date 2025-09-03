using System.Collections;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.Tests.Number;

using Random = System.Random;

public sealed record RandomFloatCollectionTests
{
    [Fact]
    public void ProduceExactCount()
    {
        const ushort count = 1000;
        Assert.Equal(count, new RandomFloatCollection(new UShort(count)).Count());
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable randoms = new RandomFloatCollection();

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

        IEnumerable<double> values =
        [
            .. new RandomFloatCollection(new UShort(10000), random).Select(x =>
                Convert.ToDouble(x.NumberValue)
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, -1, 1);
    }

    [Fact]
    public void ProduceNormalStandardDeviation()
    {
        IEnumerable<double> values =
        [
            .. new RandomFloatCollection(new UShort(10000)).Select(x =>
                Convert.ToDouble(x.NumberValue)
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, -1, 1);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RandomFloatCollection(new MinUshort()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RandomFloatCollection(new MinUshort()).ToString()
        );
    }
}
