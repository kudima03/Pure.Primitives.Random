using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Random.Number;
using System.Collections;

namespace Pure.Primitives.Random.Time;

using Random = System.Random;

public sealed record RandomTimeCollection : IEnumerable<ITime>
{
    private readonly INumber<ushort> _count;

    private readonly Random _random;

    public RandomTimeCollection()
        : this(Random.Shared) { }

    public RandomTimeCollection(Random random)
        : this(new RandomUShort(random), random) { }

    public RandomTimeCollection(INumber<ushort> count)
        : this(count, Random.Shared) { }

    public RandomTimeCollection(INumber<ushort> count, Random random)
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