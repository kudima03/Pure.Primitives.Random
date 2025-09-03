using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number;

namespace Pure.Primitives.Random.Date;

using Random = System.Random;

public sealed record RandomDate : IDate
{
    private readonly Lazy<DateOnly> _lazyDateOnly;

    public RandomDate()
        : this(Random.Shared) { }

    public RandomDate(Random random)
        : this(
            new Lazy<DateOnly>(() =>
                DateOnly.MinValue.AddDays(
                    random.Next((System.DateTime.MaxValue - System.DateTime.MinValue).Days)
                )
            )
        )
    { }

    private RandomDate(Lazy<DateOnly> lazyDateOnly)
    {
        _lazyDateOnly = lazyDateOnly;
    }

    public INumber<ushort> Day => new UShort((ushort)_lazyDateOnly.Value.Day);

    public INumber<ushort> Month => new UShort((ushort)_lazyDateOnly.Value.Month);

    public INumber<ushort> Year => new UShort((ushort)_lazyDateOnly.Value.Year);

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}