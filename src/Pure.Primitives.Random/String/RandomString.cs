using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Random.String;

using Char = Primitives.Char.Char;
using Random = System.Random;

public sealed record RandomString : IString
{
    private readonly Lazy<string> _lazyValue;

    public RandomString()
        : this(Random.Shared) { }

    public RandomString(Random random)
        : this(new RandomUShort(random)) { }

    public RandomString(INumber<ushort> length)
        : this(length, Random.Shared) { }

    public RandomString(INumber<ushort> length, Random random)
        : this(
            new Lazy<string>(() =>
                string.Join(
                    string.Empty,
                    Enumerable
                        .Range(0, length.NumberValue)
                        .Select(_ => random.Next(char.MinValue, char.MaxValue))
                        .Select(Convert.ToChar)
                )
            )
        )
    { }

    private RandomString(Lazy<string> lazyValue)
    {
        _lazyValue = lazyValue;
    }

    string IString.TextValue => _lazyValue.Value;

    public IEnumerator<IChar> GetEnumerator()
    {
        return _lazyValue.Value.Select(x => new Char(x)).GetEnumerator();
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
