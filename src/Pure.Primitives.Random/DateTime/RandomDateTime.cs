using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Random.Date;
using Pure.Primitives.Random.Time;

namespace Pure.Primitives.Random.DateTime;

public sealed record RandomDateTime : IDateTime
{
    public RandomDateTime() : this(new System.Random()) { }

    public RandomDateTime(System.Random random) :
        this(new RandomDate(random), new RandomTime(random))
    { }

    private RandomDateTime(IDate date, ITime time) :
        this(date.Year,
            date.Month,
            date.Day,
            time.Hour,
            time.Minute,
            time.Second,
            time.Millisecond,
            time.Microsecond,
            time.Nanosecond)
    { }

    private RandomDateTime(
        INumber<ushort> year,
        INumber<ushort> month,
        INumber<ushort> day,
        INumber<ushort> hour,
        INumber<ushort> minute,
        INumber<ushort> second,
        INumber<ushort> millisecond,
        INumber<ushort> microsecond,
        INumber<ushort> nanosecond)
    {
        Year = year;
        Month = month;
        Day = day;
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
        Microsecond = microsecond;
        Nanosecond = nanosecond;
    }

    public INumber<ushort> Year { get; }

    public INumber<ushort> Month { get; }

    public INumber<ushort> Day { get; }

    public INumber<ushort> Hour { get; }

    public INumber<ushort> Minute { get; }

    public INumber<ushort> Second { get; }

    public INumber<ushort> Millisecond { get; }

    public INumber<ushort> Microsecond { get; }

    public INumber<ushort> Nanosecond { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}