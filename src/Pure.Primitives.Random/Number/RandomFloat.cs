using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomFloat : INumber<float>
{
    private readonly Lazy<float> _lazyValue;

    public RandomFloat()
        : this(Random.Shared) { }

    public RandomFloat(Random random)
        : this(new Lazy<float>(random.NextSingle)) { }

    private RandomFloat(Lazy<float> lazyValue)
    {
        _lazyValue = lazyValue;
    }

    float INumber<float>.NumberValue => _lazyValue.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
