using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.String;
using System.Collections;

namespace Pure.Primitives.Random.String;

using Random = System.Random;

public sealed record RandomStringCollection : IEnumerable<IString>
{
    private readonly INumber<ushort> _count;

    private readonly INumber<ushort> _length;

    private readonly Random _random;

    public RandomStringCollection(INumber<ushort> count, INumber<ushort> length)
        : this(count, length, Random.Shared) { }

    public RandomStringCollection(INumber<ushort> count, INumber<ushort> length, Random random)
    {
        _count = count;
        _random = random;
        _length = length;
    }

    public IEnumerator<IString> GetEnumerator()
    {
        return Enumerable
            .Range(0, _count.NumberValue)
            .Select(_ => new RandomString(_length, _random))
            .GetEnumerator();
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}