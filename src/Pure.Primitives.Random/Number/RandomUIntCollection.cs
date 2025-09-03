using System.Collections;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomUIntCollection : IEnumerable<INumber<uint>>
{
    private readonly INumber<uint> _minValue;

    private readonly INumber<uint> _maxValue;

    private readonly INumber<ushort> _count;

    private readonly Random _random;

    public RandomUIntCollection()
        : this(Random.Shared) { }

    public RandomUIntCollection(Random random)
        : this(new RandomUShort(random), random) { }

    public RandomUIntCollection(INumber<ushort> count)
        : this(count, Random.Shared) { }

    public RandomUIntCollection(INumber<ushort> count, Random random)
        : this(count, new MinUint(), new MaxUint(), random) { }

    public RandomUIntCollection(
        INumber<ushort> count,
        INumber<uint> min,
        INumber<uint> max
    )
        : this(count, min, max, Random.Shared) { }

    public RandomUIntCollection(
        INumber<ushort> count,
        INumber<uint> min,
        INumber<uint> max,
        Random random
    )
    {
        _minValue = min;
        _maxValue = max;
        _count = count;
        _random = random;
    }

    public IEnumerator<INumber<uint>> GetEnumerator()
    {
        return Enumerable
            .Range(0, _count.NumberValue)
            .Select(_ => new RandomUInt(_minValue, _maxValue, _random))
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
