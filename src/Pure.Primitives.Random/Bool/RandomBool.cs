using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Random.Bool;

using Random = System.Random;

public sealed record RandomBool : IBool
{
    private readonly Lazy<bool> _lazyBool;

    public RandomBool()
        : this(Random.Shared) { }

    public RandomBool(Random random)
        : this(new Lazy<bool>(() => Convert.ToBoolean(random.Next(0, 2)))) { }

    private RandomBool(Lazy<bool> boolValue)
    {
        _lazyBool = boolValue;
    }

    public bool BoolValue => _lazyBool.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
