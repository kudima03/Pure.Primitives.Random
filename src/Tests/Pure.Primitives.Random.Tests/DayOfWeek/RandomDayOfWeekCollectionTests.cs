using System.Collections;
using Pure.Primitives.Number;
using Pure.Primitives.Random.DayOfWeek;

namespace Pure.Primitives.Random.Tests.DayOfWeek;

using Random = System.Random;

public sealed record RandomDayOfWeekCollectionTests
{
    [Fact]
    public void ProduceExactCount()
    {
        const ushort count = 1000;
        Assert.Equal(count, new RandomDayOfWeekCollection(new UShort(count)).Count());
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable randoms = new RandomDayOfWeekCollection();

        int i = 0;

        foreach (object value in randoms)
        {
            i++;
        }

        Assert.True(i > 0);
    }

    [Fact]
    public void ProduceNormalStandardDeviationWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<int> values =
        [
            .. new RandomDayOfWeekCollection(new UShort(10000), random).Select(x =>
                (int)x.DayNumberValue.NumberValue
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 2.1, 2.4);
    }

    [Fact]
    public void ProduceNormalStandardDeviation()
    {
        IEnumerable<int> values =
        [
            .. new RandomDayOfWeekCollection(new UShort(10000)).Select(x =>
                (int)x.DayNumberValue.NumberValue
            ),
        ];

        double mean = values.Average();
        double variance = values.Average(v => Math.Pow(v - mean, 2));
        double stdDev = Math.Sqrt(variance);

        Assert.InRange(stdDev, 2.1, 2.4);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RandomDayOfWeekCollection(new MinUshort()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RandomDayOfWeekCollection(new MinUshort()).ToString()
        );
    }
}
