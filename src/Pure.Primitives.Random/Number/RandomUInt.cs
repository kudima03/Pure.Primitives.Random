using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

public sealed record RandomUInt : INumber<uint>
{
    private readonly uint _numberValue;

    public RandomUInt() : this(new System.Random()) { }

    public RandomUInt(System.Random random)
    {
        byte[] bytes = new byte[4];
        random.NextBytes(bytes);
        _numberValue = BitConverter.ToUInt32(bytes);
    }

    uint INumber<uint>.NumberValue => _numberValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}