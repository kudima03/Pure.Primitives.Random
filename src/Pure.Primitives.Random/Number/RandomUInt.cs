using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

public sealed record RandomUInt : INumber<uint>
{
    private readonly System.Random _random;

    public RandomUInt() : this(new System.Random()) { }

    public RandomUInt(System.Random random)
    {
        _random = random;
    }

    uint INumber<uint>.NumberValue
    {
        get
        {
            byte[] bytes = new byte[4];
            _random.NextBytes(bytes);
            return BitConverter.ToUInt32(bytes);
        }
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}