using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

public sealed record RandomDouble : INumber<double>
{
    private readonly System.Random _random;

    public RandomDouble() : this(new System.Random()) { }

    public RandomDouble(System.Random random)
    {
        _random = random;
    }

    double INumber<double>.NumberValue => _random.NextDouble();

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}