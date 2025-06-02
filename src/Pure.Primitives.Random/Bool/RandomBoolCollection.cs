using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;
using System.Collections;

namespace Pure.Primitives.Random.Bool;

public sealed record RandomBoolCollection : IEnumerable<IBool>
{
    private readonly INumber<ushort> _count;

    private readonly System.Random _random;

    public RandomBoolCollection(INumber<ushort> count) : this(count, new System.Random()) { }

    public RandomBoolCollection(INumber<ushort> count, System.Random random)
    {
        _count = count;
        _random = random;
    }

    public IEnumerator<IBool> GetEnumerator()
    {
        return Enumerable.Range(0, _count.NumberValue).Select(_ => new RandomBool(_random)).GetEnumerator();
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