using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

public sealed record RandomDouble : INumber<double>
{
    private readonly double _numberValue;

    public RandomDouble() : this(new System.Random()) { }

    public RandomDouble(System.Random random) : this(random.NextDouble()) { }

    private RandomDouble(double numberValue)
    {
        _numberValue = numberValue;
    }

    double INumber<double>.NumberValue => _numberValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}