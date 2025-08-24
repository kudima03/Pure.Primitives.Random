using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;

namespace Pure.Primitives.Random.Number;

using Random = System.Random;

public sealed record RandomUInt : INumber<uint>
{
    private readonly Lazy<uint> _lazyValue;

    public RandomUInt()
        : this(Random.Shared) { }

    public RandomUInt(Random random)
        : this(new MinUint(), new MaxUint(), random) { }

    public RandomUInt(INumber<uint> min, INumber<uint> max)
        : this(min, max, Random.Shared) { }

    public RandomUInt(INumber<uint> min, INumber<uint> max, Random random)
        : this(new Lazy<uint>(() => (uint)random.NextInt64(min.NumberValue, max.NumberValue))) { }

    private RandomUInt(Lazy<uint> lazyValue)
    {
        _lazyValue = lazyValue;
    }

    uint INumber<uint>.NumberValue => _lazyValue.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}