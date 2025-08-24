using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;
using System.Collections;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomIntCollection : IEnumerable<INumber<int>>
{
    private readonly INumber<int> _minValue;

    private readonly INumber<int> _maxValue;

    private readonly INumber<ushort> _count;

    private readonly Random _random;

    public RandomIntCollection(INumber<ushort> count) : this(count, Random.Shared) { }

    public RandomIntCollection(INumber<ushort> count, Random random) : this(count, new MinInt(), new MaxInt(), random) { }

    public RandomIntCollection(INumber<ushort> count, INumber<int> min, INumber<int> max) : this(count, min, max, Random.Shared) { }

    public RandomIntCollection(INumber<ushort> count, INumber<int> min, INumber<int> max, Random random)
    {
        _minValue = min;
        _maxValue = max;
        _count = count;
        _random = random;
    }

    public IEnumerator<INumber<int>> GetEnumerator()
    {
        return Enumerable.Range(0, _count.NumberValue).Select(_ => new RandomInt(_minValue, _maxValue, _random)).GetEnumerator();
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