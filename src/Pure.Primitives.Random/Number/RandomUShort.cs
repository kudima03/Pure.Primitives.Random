using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomUShort : INumber<ushort>
{
    private readonly Lazy<ushort> _lazyValue;

    public RandomUShort()
        : this(Random.Shared) { }

    public RandomUShort(Random random)
        : this(new MinUshort(), new MaxUshort(), random) { }

    public RandomUShort(INumber<ushort> min, INumber<ushort> max)
        : this(min, max, Random.Shared) { }

    public RandomUShort(INumber<ushort> min, INumber<ushort> max, Random random)
        : this(
            new Lazy<ushort>(() => (ushort)random.Next(min.NumberValue, max.NumberValue))
        )
    { }

    private RandomUShort(Lazy<ushort> lazyValue)
    {
        _lazyValue = lazyValue;
    }

    ushort INumber<ushort>.NumberValue => _lazyValue.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
