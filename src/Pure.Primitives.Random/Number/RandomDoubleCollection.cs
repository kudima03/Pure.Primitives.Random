using System.Collections;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomDoubleCollection : IEnumerable<INumber<double>>
{
    private readonly INumber<ushort> _count;

    private readonly Random _random;

    public RandomDoubleCollection()
        : this(Random.Shared) { }

    public RandomDoubleCollection(Random random)
        : this(new RandomUShort(random), random) { }

    public RandomDoubleCollection(INumber<ushort> count)
        : this(count, Random.Shared) { }

    public RandomDoubleCollection(INumber<ushort> count, Random random)
    {
        _count = count;
        _random = random;
    }

    public IEnumerator<INumber<double>> GetEnumerator()
    {
        return Enumerable
            .Range(0, _count.NumberValue)
            .Select(_ => new RandomDouble(_random))
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
