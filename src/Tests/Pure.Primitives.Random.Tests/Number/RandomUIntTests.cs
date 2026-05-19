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

        Assert.InRange(stdDev, 1190000000, 1290000000);
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

        Assert.InRange(stdDev, 1190000000, 1290000000);
    }

    [Fact]
    public void MeanConsistencyWithSharedProvider()
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

        Assert.InRange(mean, 2047483647.0, 2247483647.0);
    }

    [Fact]
    public void MeanConsistency()
    {
        IEnumerable<double> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomUInt())
                .Cast<INumber<uint>>()
                .Select(x => Convert.ToDouble(x.NumberValue)),
        ];

        double mean = values.Average();

        Assert.InRange(mean, 2047483647.0, 2247483647.0);
    }

    [Fact]
    public void DifferentSeedsProduceDifferentSequences()
    {
        Random random1 = new Random(42);
        Random random2 = new Random(137);

        IEnumerable<double> seq1 =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomUInt(random1))
                .Cast<INumber<uint>>()
                .Select(x => Convert.ToDouble(x.NumberValue)),
        ];

        IEnumerable<double> seq2 =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomUInt(random2))
                .Cast<INumber<uint>>()
                .Select(x => Convert.ToDouble(x.NumberValue)),
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
        _ = Assert.Throws<NotSupportedException>(() => new RandomUInt().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomUInt().ToString());
    }
}
