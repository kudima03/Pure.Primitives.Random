using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Random.Number;
using System.Collections;

namespace Pure.Primitives.Random.Date;

using Random = System.Random;

public sealed record RandomDateCollection : IEnumerable<IDate>
{
    private readonly INumber<ushort> _count;

    private readonly Random _random;

    public RandomDateCollection()
        : this(Random.Shared) { }

    public RandomDateCollection(Random random)
        : this(new RandomUShort(random), random) { }

    public RandomDateCollection(INumber<ushort> count)
        : this(count, Random.Shared) { }

    public RandomDateCollection(INumber<ushort> count, Random random)
    {
        _count = count;
        _random = random;
    }

    public IEnumerator<IDate> GetEnumerator()
    {
        return Enumerable
            .Range(0, _count.NumberValue)
            .Select(_ => new RandomDate(_random))
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