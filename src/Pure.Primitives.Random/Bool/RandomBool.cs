using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Random.Bool;

public sealed record RandomBool : IBool
{
    private readonly bool _boolValue;

    public RandomBool()
        : this(new System.Random()) { }

    public RandomBool(System.Random random)
        : this(Convert.ToBoolean(random.Next(0, 2))) { }

    private RandomBool(bool boolValue)
    {
        _boolValue = boolValue;
    }

    bool IBool.BoolValue => _boolValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}