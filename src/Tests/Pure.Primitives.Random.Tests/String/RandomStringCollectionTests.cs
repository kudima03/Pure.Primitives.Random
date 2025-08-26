using Pure.Primitives.Number;
using Pure.Primitives.Random.String;
using System.Collections;

namespace Pure.Primitives.Random.Tests.String;

public sealed record RandomStringCollectionTests
{
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