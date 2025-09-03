using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.Tests.Number;

using Random = System.Random;

public sealed record RandomDecimalTests
{
    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<double> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomDecimal(random))
                .Cast<INumber<decimal>>()
                .Select(x => Convert.ToDouble(x.NumberValue)),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 0.1, 1);
    }

    [Fact]
    public void ProduceNormalStandardDeviation()
    {
        IEnumerable<double> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomDecimal())
                .Cast<INumber<decimal>>()
                .Select(x => Convert.ToDouble(x.NumberValue)),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 0.1, 1);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomDecimal().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomDecimal().ToString());
    }
}
