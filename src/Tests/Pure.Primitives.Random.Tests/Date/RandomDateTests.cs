using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Random.Date;

namespace Pure.Primitives.Random.Tests.Date;

using Random = System.Random;

public sealed record RandomDateTests
{
    [Fact]
    public void ProduceCorrectDate()
    {
        Random random = new Random();

        IEnumerable<IDate> values = Enumerable
            .Range(0, 10000)
            .Select(_ => new RandomDate(random));

        Assert.All(
            values,
            x => new DateOnly(x.Year.NumberValue, x.Month.NumberValue, x.Day.NumberValue)
        );
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnDay()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomDate(random))
                .Cast<IDate>()
                .Select(x => (int)x.Day.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 8.7, 9);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnMonth()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomDate(random))
                .Cast<IDate>()
                .Select(x => (int)x.Month.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 3.4, 3.6);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnYear()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomDate(random))
                .Cast<IDate>()
                .Select(x => (int)x.Year.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 2750, 2950);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomDate().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomDate().ToString());
    }
}
