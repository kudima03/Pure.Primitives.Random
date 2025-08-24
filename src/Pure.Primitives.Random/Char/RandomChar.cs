using Pure.Primitives.Abstractions.Char;

namespace Pure.Primitives.Random.Char;

using Random = System.Random;

public sealed record RandomChar : IChar
{
    private readonly char _charValue;

    public RandomChar()
        : this(Random.Shared) { }

    public RandomChar(Random random)
        : this(Convert.ToChar(random.Next(char.MinValue, char.MaxValue))) { }

    private RandomChar(char charValue)
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