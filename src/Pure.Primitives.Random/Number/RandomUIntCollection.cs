using Pure.Primitives.Abstractions.Number;
using System.Collections;

namespace Pure.Primitives.Random.Number;

public sealed record RandomUIntCollection : IEnumerable<INumber<uint>>
{
    private readonly INumber<ushort> _count;

    private readonly System.Random _random;

    public RandomUIntCollection(INumber<ushort> count) : this(count, new System.Random()) { }

    public RandomUIntCollection(INumber<ushort> count, System.Random random)
    {
        _count = count;
        _random = random;
    }

    public IEnumerator<INumber<uint>> GetEnumerator()
    {
        return Enumerable.Range(0, _count.NumberValue).Select(_ => new RandomUInt(_random)).GetEnumerator();
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