using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.Tests.Number;

using Random = System.Random;

public sealed record RandomDoubleTests
{
    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<double> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomDouble(random))
                .Cast<INumber<double>>()
                .Select(x => x.NumberValue),
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
                .Select(_ => new RandomDouble())
                .Cast<INumber<double>>()
                .Select(x => x.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 0.1, 1);
    }

    [Fact]
    public void MeanConsistencyWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<double> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomDouble(random))
                .Cast<INumber<double>>()
                .Select(x => x.NumberValue),
        ];

        double mean = values.Average();

        Assert.InRange(mean, 0.45, 0.55);
    }

    [Fact]
    public void MeanConsistency()
    {
        IEnumerable<double> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomDouble())
                .Cast<INumber<double>>()
                .Select(x => x.NumberValue),
        ];

        double mean = values.Average();

        Assert.InRange(mean, 0.45, 0.55);
    }

    [Fact]
    public void DifferentSeedsProduceDifferentSequences()
    {
        Random random1 = new Random(42);
        Random random2 = new Random(137);

        double[] seq1 =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomDouble(random1))
                .Cast<INumber<double>>()
                .Select(x => x.NumberValue),
        ];

        double[] seq2 =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomDouble(random2))
                .Cast<INumber<double>>()
                .Select(x => x.NumberValue),
        ];

        double mean1 = seq1.Average();
        double mean2 = seq2.Average();
        double numerator = seq1.Zip(seq2, (a, b) => (a - mean1) * (b - mean2)).Sum();
        double denom1 = Math.Sqrt(seq1.Sum(a => Math.Pow(a - mean1, 2)));
        double denom2 = Math.Sqrt(seq2.Sum(b => Math.Pow(b - mean2, 2)));
        double correlation = numerator / (denom1 * denom2);

        Assert.InRange(Math.Abs(correlation), 0, 0.05);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomDouble().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomDouble().ToString());
    }
}
