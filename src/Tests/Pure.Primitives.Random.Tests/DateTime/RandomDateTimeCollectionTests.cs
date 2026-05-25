using System.Collections;
using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Number;
using Pure.Primitives.Random.DateTime;

namespace Pure.Primitives.Random.Tests.DateTime;

using Random = System.Random;

public sealed record RandomDateTimeCollectionTests
{
    [Fact]
    public void ProduceExactCount()
    {
        const ushort count = 1000;
        Assert.Equal(count, new RandomDateTimeCollection(new UShort(count)).Count());
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable randoms = new RandomDateTimeCollection();

        int i = 0;

        foreach (object value in randoms)
        {
            i++;
        }

        Assert.True(i > 0);
    }

    [Fact]
    public void ProduceCorrectDateTime()
    {
        Random random = new Random();

        IEnumerable<IDateTime> values = new RandomDateTimeCollection(
            new UShort(1000),
            random
        );

        Assert.All(
            values,
            x => new System.DateTime(
                x.Year.NumberValue,
                x.Month.NumberValue,
                x.Day.NumberValue,
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
    public void ProduceNormalStandardDeviationOnDay()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. new RandomDateTimeCollection(new UShort(1000), random).Select(x =>
                (int)x.Day.NumberValue
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 7.0, 10.5);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnMonth()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. new RandomDateTimeCollection(new UShort(1000), random).Select(x =>
                (int)x.Month.NumberValue
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 2.8, 3.9);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnYear()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. new RandomDateTimeCollection(new UShort(1000), random).Select(x =>
                (int)x.Year.NumberValue
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 2500, 3300);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnHour()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. new RandomDateTimeCollection(new UShort(1000), random).Select(x =>
                (int)x.Hour.NumberValue
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 6.0, 8.0);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnMinute()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. new RandomDateTimeCollection(new UShort(1000), random).Select(x =>
                (int)x.Minute.NumberValue
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 15.0, 19.5);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnSecond()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. new RandomDateTimeCollection(new UShort(1000), random).Select(x =>
                (int)x.Second.NumberValue
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 15.0, 19.5);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnMillisecond()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. new RandomDateTimeCollection(new UShort(1000), random).Select(x =>
                (int)x.Millisecond.NumberValue
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 255, 325);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnMicrosecond()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. new RandomDateTimeCollection(new UShort(1000), random).Select(x =>
                (int)x.Microsecond.NumberValue
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 255, 325);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnNanosecond()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. new RandomDateTimeCollection(new UShort(1000), random).Select(x =>
                (int)x.Nanosecond.NumberValue
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 255, 325);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RandomDateTimeCollection(new MinUshort()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RandomDateTimeCollection(new MinUshort()).ToString()
        );
    }
}
