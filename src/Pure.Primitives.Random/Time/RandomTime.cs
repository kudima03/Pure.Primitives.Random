using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.Time;

using Random = System.Random;

public sealed record RandomTime : ITime
{
    public RandomTime()
        : this(Random.Shared) { }

    public RandomTime(Random random)
        : this(
            new RandomUShort(new MinUshort(), new UShort(24), random),
            new RandomUShort(new MinUshort(), new UShort(60), random),
            new RandomUShort(new MinUshort(), new UShort(60), random),
            new RandomUShort(new MinUshort(), new UShort(1000), random),
            new RandomUShort(new MinUshort(), new UShort(1000), random),
            new RandomUShort(new MinUshort(), new UShort(1000), random)
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
