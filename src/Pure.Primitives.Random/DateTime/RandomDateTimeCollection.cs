using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Abstractions.Number;
using System.Collections;

namespace Pure.Primitives.Random.DateTime;

public sealed record RandomDateTimeCollection : IEnumerable<IDateTime>
{
    private readonly INumber<ushort> _count;

    private readonly System.Random _random;

    public RandomDateTimeCollection(INumber<ushort> count) : this(count, new System.Random()) { }

    public RandomDateTimeCollection(INumber<ushort> count, System.Random random)
    {
        _count = count;
        _random = random;
    }

    public IEnumerator<IDateTime> GetEnumerator()
    {
        return Enumerable.Range(0, _count.NumberValue).Select(_ => new RandomDateTime(_random)).GetEnumerator();
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