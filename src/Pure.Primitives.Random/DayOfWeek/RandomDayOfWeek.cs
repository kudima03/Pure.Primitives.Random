using Pure.Primitives.Abstractions.DayOfWeek;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;

namespace Pure.Primitives.Random.DayOfWeek;

public sealed record RandomDayOfWeek : IDayOfWeek
{
    private readonly System.Random _random;

    public RandomDayOfWeek() : this(new System.Random()) { }

    public RandomDayOfWeek(System.Random random)
    {
        _random = random;
    }

    public INumber<ushort> DayNumberValue => new UShort((ushort)_random.Next(0, 8));

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}