using Pure.Primitives.Abstractions.Char;

namespace Pure.Primitives.Random.Char;

public sealed record RandomChar : IChar
{
    private readonly char _charValue;

    public RandomChar() : this(new System.Random()) { }

    public RandomChar(System.Random random) : 
        this(Convert.ToChar(random.Next(char.MinValue, char.MaxValue))) { }

    internal RandomChar(char charValue)
    {
        _charValue = charValue;
    }

    char IChar.CharValue => _charValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}