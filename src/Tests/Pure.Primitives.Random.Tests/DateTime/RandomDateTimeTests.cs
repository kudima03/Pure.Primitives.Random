﻿using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Random.DateTime;

namespace Pure.Primitives.Random.Tests.DateTime;

using Random = System.Random;

public sealed record RandomDateTimeTests
{
    [Fact]
    public void ProduceCorrectDateTime()
    {
        Random random = new Random();

        IEnumerable<IDateTime> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomDateTime(random));

        Assert.All(values,
            x => new System.DateTime(x.Year.NumberValue,
                x.Month.NumberValue,
                x.Day.NumberValue,
                x.Hour.NumberValue,
                x.Minute.NumberValue,
                x.Second.NumberValue,
                x.Millisecond.NumberValue,
                x.Microsecond.NumberValue));

        Assert.True(values.All(x =>
        {
            ushort nanosecond = x.Nanosecond.NumberValue;
            return nanosecond is >= 0 and < 1000;
        }));
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnDay()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomDateTime(random))
            .Cast<IDateTime>()
            .Select(x => (int)x.Day.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 8.7, 9);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnMonth()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomDateTime(random))
            .Cast<IDateTime>()
            .Select(x => (int)x.Month.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 3.4, 3.6);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnYear()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomDateTime(random))
            .Cast<IDateTime>()
            .Select(x => (int)x.Year.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 2750, 2950);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnHour()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomDateTime(random))
            .Cast<IDateTime>()
            .Select(x => (int)x.Hour.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 6.8, 7);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnMinute()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomDateTime(random))
            .Cast<IDateTime>()
            .Select(x => (int)x.Minute.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 17, 17.5);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnSecond()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomDateTime(random))
            .Cast<IDateTime>()
            .Select(x => (int)x.Second.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 17, 17.5);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnMillisecond()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomDateTime(random))
            .Cast<IDateTime>()
            .Select(x => (int)x.Millisecond.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 280, 300);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnMicrosecond()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomDateTime(random))
            .Cast<IDateTime>()
            .Select(x => (int)x.Microsecond.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 280, 300);
    }

    [Fact]
    public void ProduceNormalStandardDeviationOnNanosecond()
    {
        Random random = new Random();

        IEnumerable<int> values = Enumerable.Range(0, 10000)
            .Select(_ => new RandomDateTime(random))
            .Cast<IDateTime>()
            .Select(x => (int)x.Nanosecond.NumberValue)
            .ToArray();

        double mean = values.Average();
        double variance = values.Select(v => Math.Pow(v - mean, 2)).Average();
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 280, 300);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new RandomDateTime().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new RandomDateTime().ToString());
    }
}