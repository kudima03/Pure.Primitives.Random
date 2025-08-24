using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.Time;
using System.Collections;

namespace Pure.Primitives.Random.Time;

public sealed record RandomTimeCollection : IEnumerable<ITime>
{
    private readonly INumber<ushort> _count;

    private readonly System.Random _random;

    public RandomTimeCollection(INumber<ushort> count)
        : this(count, new System.Random()) { }

    public RandomTimeCollection(INumber<ushort> count, System.Random random)
    {
        _count = count;
        _random = random;
    }

    public IEnumerator<ITime> GetEnumerator()
    {
        return Enumerable
            .Range(0, _count.NumberValue)
            .Select(_ => new RandomTime(_random))
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