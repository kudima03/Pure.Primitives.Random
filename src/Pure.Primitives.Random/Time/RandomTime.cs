using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Number;

namespace Pure.Primitives.Random.Time;

public sealed record RandomTime : ITime
{
    public RandomTime()
        : this(new System.Random()) { }

    public RandomTime(System.Random random)
        : this(
            new UShort((ushort)random.Next(24)),
            new UShort((ushort)random.Next(60)),
            new UShort((ushort)random.Next(60)),
            new UShort((ushort)random.Next(1000)),
            new UShort((ushort)random.Next(1000)),
            new UShort((ushort)random.Next(1000))
        )
    { }

    private RandomTime(
        INumber<ushort> hour,
        INumber<ushort> minute,
        INumber<ushort> second,
        INumber<ushort> millisecond,
        INumber<ushort> microsecond,
        INumber<ushort> nanosecond
    )
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
        Microsecond = microsecond;
        Nanosecond = nanosecond;
    }

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