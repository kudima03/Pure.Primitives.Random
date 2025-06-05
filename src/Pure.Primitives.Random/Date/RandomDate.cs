using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;

namespace Pure.Primitives.Random.Date;

public sealed record RandomDate : IDate
{
    public RandomDate() : this(new System.Random()) { }

    public RandomDate(System.Random random) :
        this(DateOnly.MinValue.AddDays(random.Next((System.DateTime.MaxValue - System.DateTime.MinValue).Days))) { }

    private RandomDate(DateOnly date) :
        this(new UShort((ushort)date.Day),
            new UShort((ushort)date.Month),
            new UShort((ushort)date.Year)) { }

    private RandomDate(INumber<ushort> day, INumber<ushort> month, INumber<ushort> year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public INumber<ushort> Day { get; }

    public INumber<ushort> Month { get; }

    public INumber<ushort> Year { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}