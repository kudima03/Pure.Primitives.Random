using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Abstractions.Number;
using System.Collections;

namespace Pure.Primitives.Random.Date;

public sealed record RandomDateCollection : IEnumerable<IDate>
{
    private readonly INumber<ushort> _count;

    private readonly System.Random _random;

    public RandomDateCollection(INumber<ushort> count)
        : this(count, new System.Random()) { }

    public RandomDateCollection(INumber<ushort> count, System.Random random)
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