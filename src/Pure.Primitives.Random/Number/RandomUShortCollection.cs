using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;
using System.Collections;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomUShortCollection : IEnumerable<INumber<ushort>>
{
    private readonly INumber<ushort> _minValue;

    private readonly INumber<ushort> _maxValue;

    private readonly INumber<ushort> _count;

    private readonly Random _random;

    public RandomUShortCollection()
        : this(Random.Shared) { }

    public RandomUShortCollection(Random random)
        : this(new RandomUShort(random), random) { }

    public RandomUShortCollection(INumber<ushort> count)
        : this(count, Random.Shared) { }

    public RandomUShortCollection(INumber<ushort> count, Random random)
        : this(count, new MinUshort(), new MaxUshort(), random) { }

    public RandomUShortCollection(INumber<ushort> count, INumber<ushort> min, INumber<ushort> max)
        : this(count, min, max, Random.Shared) { }

    public RandomUShortCollection(
        INumber<ushort> count,
        INumber<ushort> min,
        INumber<ushort> max,
        Random random
    )
    {
        _minValue = min;
        _maxValue = max;
        _count = count;
        _random = random;
    }

    public IEnumerator<INumber<ushort>> GetEnumerator()
    {
        return Enumerable
            .Range(0, _count.NumberValue)
            .Select(_ => new RandomUShort(_minValue, _maxValue, _random))
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