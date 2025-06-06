using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

public sealed record RandomUShort : INumber<ushort>
{
    private readonly ushort _numberValue;

    public RandomUShort() : this(new System.Random()) { }

    public RandomUShort(System.Random random) :
        this(Convert.ToUInt16(random.Next(ushort.MinValue, ushort.MaxValue + 1)))
    { }

    public RandomUShort(ushort numberValue)
    {
        _numberValue = numberValue;
    }

    ushort INumber<ushort>.NumberValue => _numberValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}