using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.Number;
using System.Collections;

namespace Pure.Primitives.Random.Char;

public sealed record RandomCharCollection : IEnumerable<IChar>
{
    private readonly INumber<ushort> _count;

    private readonly System.Random _random;

    public RandomCharCollection(INumber<ushort> count)
        : this(count, new System.Random()) { }

    public RandomCharCollection(INumber<ushort> count, System.Random random)
    {
        _count = count;
        _random = random;
    }

    public IEnumerator<IChar> GetEnumerator()
    {
        return Enumerable
            .Range(0, _count.NumberValue)
            .Select(_ => new RandomChar(_random))
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