using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Number;
using Pure.Primitives.Random.String;
using System.Collections;

namespace Pure.Primitives.Random.Tests.String;

using Random = System.Random;

public sealed record RandomStringTests
{
    [Fact]
    public void ProduceExactLength()
    {
        const ushort count = 1000;
        IString str = new RandomString(new UShort(count));
        Assert.Equal(count, str.TextValue.Length);
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        const ushort count = 1000;

        IEnumerable randoms = new RandomString(new UShort(count));

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
        Random random = new Random();

        IEnumerable<int> values = new RandomString(new UShort(10000), random)
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
        IEnumerable<int> values = new RandomString(new UShort(10000))
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
        Assert.Throws<NotSupportedException>(() => new RandomString(new MinUshort()).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new RandomString(new MinUshort()).ToString());
    }
}