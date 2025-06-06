using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

public sealed record RandomInt : INumber<int>
{
    private readonly int _numberValue;

    public RandomInt() : this(new System.Random()) { }

    public RandomInt(System.Random random)
    {
        byte[] bytes = new byte[4];
        random.NextBytes(bytes);
        _numberValue = BitConverter.ToInt32(bytes);
    }

    int INumber<int>.NumberValue => _numberValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}