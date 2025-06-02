using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Bool;

namespace Pure.Primitives.Random.Tests.Bool;

using Random = System.Random;

public sealed record RandomBoolCollectionTests
{
    [Fact]
    public void ProduceExactCount()
    {
        const ushort count = 1000;
        Assert.Equal(count, new RandomBoolCollection(new UShort(count)).Count());
    }

    [Fact]
    public void ProduceNormalDistributionWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<IBool> values = new RandomBoolCollection(new UShort(1000), random);

        int trueCount = values.Count(x => x.BoolValue);
        int falseCount = values.Count(x => !x.BoolValue);

        double ratio = (double)Math.Min(trueCount, falseCount) / Math.Max(trueCount, falseCount);

        Assert.True(ratio > 0.9, $"Ratio: {ratio}");
    }

    [Fact]
    public void ProduceNormalDistribution()
    {
        IEnumerable<IBool> values = new RandomBoolCollection(new UShort(1000));

        int trueCount = values.Count(x => x.BoolValue);
        int falseCount = values.Count(x => !x.BoolValue);

        double ratio = (double)Math.Min(trueCount, falseCount) / Math.Max(trueCount, falseCount);

        Assert.True(ratio > 0.95);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new RandomBoolCollection(new MinUshort()).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new RandomBoolCollection(new MinUshort()).ToString());
    }
}