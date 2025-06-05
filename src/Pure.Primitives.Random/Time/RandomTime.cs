using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Number;

namespace Pure.Primitives.Random.Time;

public sealed record RandomTime : ITime
{
    public RandomTime() : this(new System.Random()) { }

    public RandomTime(System.Random random)
    {
        Hour = new UShort((ushort)random.Next(24));
        Minute = new UShort((ushort)random.Next(60));
        Second = new UShort((ushort)random.Next(60));
        Millisecond = new UShort((ushort)random.Next(1000));
        Microsecond = new UShort((ushort)random.Next(1000));
        Nanosecond = new UShort((ushort)random.Next(1000));
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