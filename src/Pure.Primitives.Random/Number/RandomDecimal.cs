using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomDecimal : INumber<decimal>
{
    private readonly decimal _numberValue;

    public RandomDecimal()
        : this(Random.Shared) { }

    public RandomDecimal(Random random)
        : this(Convert.ToDecimal(random.NextDouble())) { }

    private RandomDecimal(decimal numberValue)
    {
        _numberValue = numberValue;
    }

    decimal INumber<decimal>.NumberValue => _numberValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}