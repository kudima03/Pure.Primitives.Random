using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.Char;

using Random = System.Random;

public sealed record RandomCharCollection : IEnumerable<IChar>
{
    private readonly INumber<ushort> _count;

    private readonly Random _random;

    public RandomCharCollection()
        : this(Random.Shared) { }

    public RandomCharCollection(Random random)
        : this(new RandomUShort(random), random) { }

    public RandomCharCollection(INumber<ushort> count)
        : this(count, Random.Shared) { }

    public RandomCharCollection(INumber<ushort> count, Random random)
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
