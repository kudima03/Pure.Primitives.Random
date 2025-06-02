using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Random.Bool;

namespace Pure.Primitives.Random.Tests.Bool;

using Random = System.Random;

public sealed record  RandomBoolTests
{
    [Fact]
    public void ProduceCorrectlyWithSharedProvider()
    {
        Random random = new Random();

        IEnumerable<IBool> values = Enumerable.Range(0, 10000).Select(_ => new RandomBool(random)).ToArray();

        int trueCount = values.Count(x => x.BoolValue);
        int falseCount = values.Count(x => !x.BoolValue);

        double ratio = (double)Math.Min(trueCount, falseCount) / Math.Max(trueCount, falseCount);

        Assert.True(ratio > 0.95);
    }

    [Fact]
    public void ProduceCorrectlyOnSequentialCall()
    {
        IEnumerable<IBool> values = Enumerable.Range(0, 10000).Select(_ => new RandomBool()).ToArray();

        int trueCount = values.Count(x => x.BoolValue);
        int falseCount = values.Count(x => !x.BoolValue);

        double ratio = (double)Math.Min(trueCount, falseCount) / Math.Max(trueCount, falseCount);

        Assert.True(ratio > 0.95);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new RandomBool().GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new RandomBool().ToString());
    }
}