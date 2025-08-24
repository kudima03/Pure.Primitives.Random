using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomDecimal : INumber<decimal>
{
    private readonly Lazy<decimal> _lazyValue;

    public RandomDecimal()
        : this(Random.Shared) { }

    public RandomDecimal(Random random)
        : this(new Lazy<decimal>(() => Convert.ToDecimal(random.NextDouble()))) { }

    private RandomDecimal(Lazy<decimal> lazyValue)
    {
        _lazyValue = lazyValue;
    }

    decimal INumber<decimal>.NumberValue => _lazyValue.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}