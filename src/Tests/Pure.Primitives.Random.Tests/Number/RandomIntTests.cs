using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.Tests.Number;

using Random = System.Random;

public sealed record RandomIntTests
{
    [Fact]
    public void RangeAffectGeneration()
    {
        INumber<int> max = new RandomInt(new Int(10), new MaxInt());
        INumber<int> min = new RandomInt(new Zero<int>(), max);

        IEnumerable<int> values = Enumerable
            .Range(0, 10000)
            .Select(_ => new RandomInt(min, max))
            .Cast<INumber<int>>()
            .Select(x => x.NumberValue)
            .ToArray();

        Assert.True(values.All(x => min.NumberValue <= x && x < max.NumberValue));
    }

    [Fact]
    public void ThrowsExceptionOnMinValueGreaterThanMaxValue()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            ((INumber<int>)new RandomInt(new MaxInt(), new MinInt())).NumberValue
        );
    }

    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable
            .Range(0, 10000)
            .Select(_ => new RandomInt(random))
            .Cast<INumber<int>>()
            .Select(x => x.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 1225000000, 1255000000);
    }

    [Fact]
    public void ProduceNormalStandardDeviation()
    {
        IEnumerable<int> values = Enumerable
            .Range(0, 10000)
            .Select(_ => new RandomInt())
            .Cast<INumber<int>>()
            .Select(x => x.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 1225000000, 1255000000);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new RandomInt().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new RandomInt().ToString());
    }
}