using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.Number;
using System.Collections;

namespace Pure.Primitives.Random.String;

using Random = System.Random;

public sealed record RandomStringCollection : IEnumerable<IString>
{
    private readonly INumber<ushort> _count;

    private readonly IEnumerable<INumber<ushort>> _lengths;

    private readonly Random _random;

    public RandomStringCollection()
        : this(Random.Shared) { }

    public RandomStringCollection(Random random)
        : this(new RandomUShort(random), random) { }

    public RandomStringCollection(INumber<ushort> count)
        : this(count, Random.Shared) { }

    public RandomStringCollection(INumber<ushort> count, Random random)
        : this(count, new RandomUShortCollection(count, random)) { }

    public RandomStringCollection(INumber<ushort> count, INumber<ushort> length)
        : this(count, length, Random.Shared) { }

    public RandomStringCollection(INumber<ushort> count, INumber<ushort> length, Random random)
        : this(count, Enumerable.Range(0, count.NumberValue).Select(_ => length), random) { }

    public RandomStringCollection(INumber<ushort> count, IEnumerable<INumber<ushort>> lengths)
        : this(count, lengths, Random.Shared) { }

    public RandomStringCollection(
        INumber<ushort> count,
        IEnumerable<INumber<ushort>> lengths,
        Random random
    )
    {
        _count = count;
        _lengths = lengths;
        _random = random;
    }

    public IEnumerator<IString> GetEnumerator()
    {
        using IEnumerator<INumber<ushort>> lengthEnumerator = _lengths.GetEnumerator();

        for (int i = 0; i < _count.NumberValue; i++)
        {
            yield return !lengthEnumerator.MoveNext()
                ? throw new ArgumentException()
                : new RandomString(lengthEnumerator.Current, _random);
        }
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