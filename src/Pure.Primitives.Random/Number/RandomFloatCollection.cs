using Pure.Primitives.Abstractions.Number;
using System.Collections;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomFloatCollection : IEnumerable<INumber<float>>
{
    private readonly INumber<ushort> _count;

    private readonly Random _random;

    public RandomFloatCollection()
        : this(Random.Shared) { }

    public RandomFloatCollection(Random random)
        : this(new RandomUShort(random), random) { }

    public RandomFloatCollection(INumber<ushort> count)
        : this(count, Random.Shared) { }

    public RandomFloatCollection(INumber<ushort> count, Random random)
    {
        _count = count;
        _random = random;
    }

    public IEnumerator<INumber<float>> GetEnumerator()
    {
        return Enumerable
            .Range(0, _count.NumberValue)
            .Select(_ => new RandomFloat(_random))
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