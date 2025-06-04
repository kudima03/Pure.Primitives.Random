using Pure.Primitives.Abstractions.DayOfWeek;
using Pure.Primitives.Random.DayOfWeek;

namespace Pure.Primitives.Random.Tests.DayOfWeek;

using Random = System.Random;

public sealed record RandomDayOfWeekTests
{
    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<double> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomDayOfWeek(random))
            .Cast<IDayOfWeek>()
            .Select(x => Convert.ToDouble(x.DayNumberValue.NumberValue))
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 2.1, 2.4);
    }

    [Fact]
    public void ProduceNormalStandardDeviation()
    {
        IEnumerable<double> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomDayOfWeek())
            .Cast<IDayOfWeek>()
            .Select(x => Convert.ToDouble(x.DayNumberValue.NumberValue))
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 2.1, 2.4);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new RandomDayOfWeek().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new RandomDayOfWeek().ToString());
    }
}