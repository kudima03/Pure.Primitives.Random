using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

public sealed record RandomDecimal : INumber<decimal>
{
    private readonly System.Random _random;

    public RandomDecimal() : this(new System.Random()) { }

    public RandomDecimal(System.Random random)
    {
        _random = random;
    }

    decimal INumber<decimal>.NumberValue => Convert.ToDecimal(_random.NextDouble());

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}