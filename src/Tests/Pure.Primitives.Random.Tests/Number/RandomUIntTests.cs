using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.Tests.Number;

using Random = System.Random;

public sealed record RandomUIntTests
{
    [Fact]
    public void RangeAffectGeneration()
    {
        INumber<uint> max = new RandomUInt(new UInt(10), new MaxUint());
        INumber<uint> min = new RandomUInt(new Zero<uint>(), max);

        IEnumerable<uint> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomUInt(min, max))
                .Cast<INumber<uint>>()
                .Select(x => x.NumberValue),
        ];

        Assert.True(values.All(x => min.NumberValue <= x && x < max.NumberValue));
    }

    [Fact]
    public void ThrowsExceptionOnMinValueGreaterThanMaxValue()
    {
        _ = Assert.Throws<ArgumentOutOfRangeException>(() =>
            new RandomUInt(new MaxUint(), new MinUint()).NumberValue
        );
    }

    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<double> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomUInt(random))
                .Cast<INumber<uint>>()
                .Select(x => Convert.ToDouble(x.NumberValue)),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 1225000000, 1255000000);
    }

    [Fact]
    public void ProduceNormalStandardDeviation()
    {
        IEnumerable<int> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomUInt())
                .Cast<INumber<uint>>()
                .Select(x => (int)x.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 1225000000, 1255000000);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomUInt().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomUInt().ToString());
    }
}
