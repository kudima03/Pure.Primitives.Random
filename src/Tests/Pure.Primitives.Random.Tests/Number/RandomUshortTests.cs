using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.Tests.Number;

using Random = System.Random;

public sealed record RandomUShortTests
{
    [Fact]
    public void RangeAffectGeneration()
    {
        INumber<ushort> max = new RandomUShort(new UShort(10), new MaxUshort());
        INumber<ushort> min = new RandomUShort(new Zero<ushort>(), max);

        IEnumerable<ushort> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomUShort(min, max))
                .Cast<INumber<ushort>>()
                .Select(x => x.NumberValue),
        ];

        Assert.True(values.All(x => min.NumberValue <= x && x < max.NumberValue));
    }

    [Fact]
    public void ThrowsExceptionOnMinValueGreaterThanMaxValue()
    {
        _ = Assert.Throws<ArgumentOutOfRangeException>(() =>
            (
                (INumber<ushort>)new RandomUShort(new MaxUshort(), new MinUshort())
            ).NumberValue
        );
    }

    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomUShort(random))
                .Cast<INumber<ushort>>()
                .Select(x => (int)x.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 18000, 20000);
    }

    [Fact]
    public void ProduceNormalStandardDeviation()
    {
        IEnumerable<int> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomUShort())
                .Cast<INumber<ushort>>()
                .Select(x => (int)x.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 18000, 20000);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomUShort().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomUShort().ToString());
    }
}
