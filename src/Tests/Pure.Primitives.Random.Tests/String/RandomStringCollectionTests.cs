using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Number;
using Pure.Primitives.Random.String;
using System.Collections;

namespace Pure.Primitives.Random.Tests.String;

public sealed record RandomStringCollectionTests
{
    [Fact]
    public void ProduceDifferentLengths()
    {
        IReadOnlyCollection<int> lengths = new RandomStringCollection(new UShort(50))
            .Select(x => x.TextValue.Length)
            .ToArray();

        Assert.Equal(lengths.Count, lengths.Distinct().Count());
    }

    [Fact]
    public void ThrowsExceptionWhenLengthsShorterThanCount()
    {
        IEnumerable<IString> randoms = new RandomStringCollection(
            new UShort(100),
            new RandomUShortCollection(new UShort(50))
        );

        Assert.Throws<ArgumentException>(() => randoms.Count());
    }

    [Fact]
    public void ProduceExactCount()
    {
        const ushort count = 1000;
        Assert.Equal(count, new RandomStringCollection(new UShort(count), new MinUshort()).Count());
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable randoms = new RandomStringCollection();

        int i = 0;

        foreach (object value in randoms)
        {
            i++;
        }

        Assert.True(i > 0);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() =>
            new RandomStringCollection(new MinUshort(), new MinUshort()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() =>
            new RandomStringCollection(new MinUshort(), new MinUshort()).ToString()
        );
    }
}