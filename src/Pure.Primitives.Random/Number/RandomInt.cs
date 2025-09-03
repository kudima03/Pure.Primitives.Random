using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomInt : INumber<int>
{
    private readonly Lazy<int> _lazyValue;

    public RandomInt()
        : this(Random.Shared) { }

    public RandomInt(Random random)
        : this(new MinInt(), new MaxInt(), random) { }

    public RandomInt(INumber<int> min, INumber<int> max)
        : this(min, max, Random.Shared) { }

    public RandomInt(INumber<int> min, INumber<int> max, Random random)
        : this(new Lazy<int>(() => random.Next(min.NumberValue, max.NumberValue))) { }

    private RandomInt(Lazy<int> lazyValue)
    {
        _lazyValue = lazyValue;
    }

    int INumber<int>.NumberValue => _lazyValue.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
