using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.String;
using System.Collections;

namespace Pure.Primitives.Random.String;

using Char = Primitives.Char.Char;
using Random = System.Random;

public sealed record RandomString : IString
{
    private readonly string _textValue;

    public RandomString(INumber<ushort> length)
        : this(length, Random.Shared) { }

    public RandomString(INumber<ushort> length, Random random)
        : this(
            string.Join(
                string.Empty,
                Enumerable
                    .Range(0, length.NumberValue)
                    .Select(_ => random.Next(char.MinValue, char.MaxValue))
                    .Select(Convert.ToChar)
            )
        )
    { }

    private RandomString(string textValue)
    {
        _textValue = textValue;
    }

    string IString.TextValue => _textValue;

    public IEnumerator<IChar> GetEnumerator()
    {
        return _textValue.Select(x => new Char(x)).GetEnumerator();
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}