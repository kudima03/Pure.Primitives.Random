using Pure.Primitives.Abstractions.DayOfWeek;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;

namespace Pure.Primitives.Random.DayOfWeek;

public sealed record RandomDayOfWeek : IDayOfWeek
{
    private readonly INumber<ushort> _dayNumberValue;

    public RandomDayOfWeek()
        : this(new System.Random()) { }

    public RandomDayOfWeek(System.Random random)
        : this(new UShort((ushort)random.Next(0, 8))) { }

    private RandomDayOfWeek(INumber<ushort> dayNumberValue)
    {
        _dayNumberValue = dayNumberValue;
    }

    INumber<ushort> IDayOfWeek.DayNumberValue => _dayNumberValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}