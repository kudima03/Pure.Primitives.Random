using Pure.Primitives.Abstractions.DayOfWeek;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.DayOfWeek;

using Random = System.Random;

public sealed record RandomDayOfWeek : IDayOfWeek
{
    public RandomDayOfWeek()
        : this(Random.Shared) { }

    public RandomDayOfWeek(Random random)
        : this(new RandomUShort(new MinUshort(), new UShort(8), random)) { }

    private RandomDayOfWeek(INumber<ushort> dayNumberValue)
    {
        DayNumberValue = dayNumberValue;
    }

    public INumber<ushort> DayNumberValue { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
