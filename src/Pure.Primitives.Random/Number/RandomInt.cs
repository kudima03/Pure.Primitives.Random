using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

public sealed record RandomInt : INumber<int>
{
    private readonly System.Random _random;

    public RandomInt() : this(new System.Random()) { }

    public RandomInt(System.Random random)
    {
        _random = random;
    }

    int INumber<int>.NumberValue
    {
        get
        {
            byte[] bytes = new byte[4];
            _random.NextBytes(bytes);
            return BitConverter.ToInt32(bytes);
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