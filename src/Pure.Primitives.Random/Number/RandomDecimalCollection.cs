using Pure.Primitives.Abstractions.Number;
using System.Collections;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomDecimalCollection : IEnumerable<INumber<decimal>>
{
    private readonly INumber<ushort> _count;

    private readonly Random _random;

    public RandomDecimalCollection(INumber<ushort> count)
        : this(count, Random.Shared) { }

    public RandomDecimalCollection(INumber<ushort> count, Random random)
    {
        _count = count;
        _random = random;
    }

    public IEnumerator<INumber<decimal>> GetEnumerator()
    {
        return Enumerable
            .Range(0, _count.NumberValue)
            .Select(_ => new RandomDecimal(_random))
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