using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomDouble : INumber<double>
{
    private readonly Lazy<double> _lazyValue;

    public RandomDouble()
        : this(Random.Shared) { }

    public RandomDouble(Random random)
        : this(new Lazy<double>(random.NextDouble)) { }

    private RandomDouble(Lazy<double> lazyValue)
    {
        _lazyValue = lazyValue;
    }

    double INumber<double>.NumberValue => _lazyValue.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}