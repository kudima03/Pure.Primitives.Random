using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

public sealed record RandomUShort : INumber<ushort>
{
    private readonly System.Random _random;

    public RandomUShort() : this(new System.Random()) { }

    public RandomUShort(System.Random random)
    {
        _random = random;
    }

    ushort INumber<ushort>.NumberValue => Convert.ToUInt16(_random.Next(ushort.MinValue, ushort.MaxValue + 1));

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}