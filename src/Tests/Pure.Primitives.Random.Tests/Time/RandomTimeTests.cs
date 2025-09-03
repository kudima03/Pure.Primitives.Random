using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Random.Time;

namespace Pure.Primitives.Random.Tests.Time;

using Random = System.Random;

public sealed record RandomTimeTests
{
    [Fact]
    public void ProduceCorrectTime()
    {
        Random random = new Random();

        IEnumerable<ITime> values = Enumerable
            .Range(0, 10000)
            .Select(_ => new RandomTime(random));

        Assert.All(
            values,
            x => new TimeOnly(
                x.Hour.NumberValue,
                x.Minute.NumberValue,
                x.Second.NumberValue,
                x.Millisecond.NumberValue,
                x.Microsecond.NumberValue
            )
        );

        Assert.True(
            values.All(x =>
            {
                ushort nanosecond = x.Nanosecond.NumberValue;
                return nanosecond is >= 0 and < 1000;
            })
        );
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnHour()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomTime(random))
                .Cast<ITime>()
                .Select(x => (int)x.Hour.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 6.8, 7);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnMinute()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomTime(random))
                .Cast<ITime>()
                .Select(x => (int)x.Minute.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 17, 17.5);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnSecond()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomTime(random))
                .Cast<ITime>()
                .Select(x => (int)x.Second.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 17, 17.5);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnMillisecond()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomTime(random))
                .Cast<ITime>()
                .Select(x => (int)x.Millisecond.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 280, 300);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnMicrosecond()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomTime(random))
                .Cast<ITime>()
                .Select(x => (int)x.Microsecond.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 280, 300);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnNanosecond()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. Enumerable
                .Range(0, 10000)
                .Select(_ => new RandomTime(random))
                .Cast<ITime>()
                .Select(x => (int)x.Nanosecond.NumberValue),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 280, 300);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomTime().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() => new RandomTime().ToString());
    }
}
