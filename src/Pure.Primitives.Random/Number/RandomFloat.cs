using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Random.Number;

public sealed record RandomFloat : INumber<float>
{
    private readonly System.Random _random;

    public RandomFloat() : this(new System.Random()) { }

    public RandomFloat(System.Random random)
    {
        _random = random;
    }

    float INumber<float>.NumberValue => _random.NextSingle();

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}