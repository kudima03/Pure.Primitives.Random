using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomFloat : INumber<float>
{
    private readonly float _numberValue;

    public RandomFloat()
        : this(Random.Shared) { }

    public RandomFloat(Random random)
        : this(random.NextSingle()) { }

    private RandomFloat(float numberValue)
    {
        _numberValue = numberValue;
    }

    float INumber<float>.NumberValue => _numberValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}