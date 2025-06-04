using Pure.Primitives.Abstractions.DayOfWeek;
using Pure.Primitives.Abstractions.Number;
using System.Collections;

namespace Pure.Primitives.Random.DayOfWeek;

public sealed record RandomDayOfWeekCollection : IEnumerable<IDayOfWeek>
{
    private readonly INumber<ushort> _count;

    private readonly System.Random _random;

    public RandomDayOfWeekCollection(INumber<ushort> count) : this(count, new System.Random()) { }

    public RandomDayOfWeekCollection(INumber<ushort> count, System.Random random)
    {
        _count = count;
        _random = random;
    }

    public IEnumerator<IDayOfWeek> GetEnumerator()
    {
        return Enumerable.Range(0, _count.NumberValue).Select(_ => new RandomDayOfWeek(_random)).GetEnumerator();
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