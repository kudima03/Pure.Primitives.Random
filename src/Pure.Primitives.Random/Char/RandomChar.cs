using Pure.Primitives.Abstractions.Char;

namespace Pure.Primitives.Random.Char;

using Random = System.Random;

public sealed record RandomChar : IChar
{
    private readonly Lazy<char> _lazyChar;

    public RandomChar()
        : this(Random.Shared) { }

    public RandomChar(Random random)
        : this(
            new Lazy<char>(() =>
                Convert.ToChar(random.Next(char.MinValue, char.MaxValue))
            )
        )
    { }

    private RandomChar(Lazy<char> lazyChar)
    {
        _lazyChar = lazyChar;
    }

    public char CharValue => _lazyChar.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
