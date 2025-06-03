using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.String;
using System.Collections;

namespace Pure.Primitives.Random.String;

using Char = Primitives.Char.Char;

public sealed record RandomString : IString
{
    private readonly INumber<ushort> _length;

    private readonly System.Random _random;

    public RandomString(INumber<ushort> length) : this(length, new System.Random()) { }

    public RandomString(INumber<ushort> length, System.Random random)
    {
        _random = random;
        _length = length;
    }

    private string ValueInternal => string.Join(string.Empty,
        Enumerable.Range(0, _length.NumberValue)
            .Select(_ => _random.Next(char.MinValue, char.MaxValue))
            .Select(Convert.ToChar));

    string IString.TextValue => ValueInternal;

    public IEnumerator<IChar> GetEnumerator()
    {
        return ValueInternal.Select(x => new Char(x)).GetEnumerator();
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