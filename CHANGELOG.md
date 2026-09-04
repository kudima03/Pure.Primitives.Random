# Changelog

All notable changes to Pure.Primitives.Random are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.8.3] — 2026-06-25

- Maintenance release: dependency and build updates.

## [0.8.2] — 2026-05-20

- Maintenance release: dependency and build updates.

## [0.8.1] — 2026-05-07

- Maintenance release: dependency and build updates.

## [0.8.0] — 2025-12-01

### Changed

- Target frameworks expanded from `net9.0` to `net7.0`, `net8.0`, `net9.0`,
  and `net10.0`.

## [0.7.0] — 2025-11-02

### Added

- Members that were previously accessible only through their interface are
  now public properties on the concrete type: `RandomBool.BoolValue`,
  `RandomChar.CharValue`, `RandomDayOfWeek.DayNumberValue`,
  `RandomDecimal.NumberValue`, `RandomDouble.NumberValue`,
  `RandomFloat.NumberValue`, `RandomInt.NumberValue`,
  `RandomUInt.NumberValue`, `RandomUShort.NumberValue`, and
  `RandomString.TextValue`.

## [0.6.0] — 2025-11-01

### Changed

- Declared the package as AOT/trim-compatible (`IsAotCompatible`).
- `Pure.Primitives` is no longer a transitive dependency of consumers
  (referenced with `PrivateAssets="All"`); `Pure.Primitives.Abstractions`
  is now referenced directly.

## [0.5.0] — 2025-09-08

### Added

- `RandomString` gained constructors accepting an `IChar` minimum and
  maximum character bound (`RandomString(IChar minValue, IChar maxValue)`,
  `RandomString(INumber<ushort> length, IChar minValue, IChar maxValue)`,
  and `Random`-accepting overloads), restricting generated characters to
  the given range.

## [0.4.0] — 2025-08-29

### Added

- `RandomStringCollection` gained constructors accepting a per-item
  `IEnumerable<INumber<ushort>>` of lengths, so each generated string in
  the collection can have a different length. A count-only constructor
  (`RandomStringCollection(INumber<ushort> count)`) was also added.

### Changed

- `RandomStringCollection` now throws `ArgumentException` if the supplied
  lengths sequence is shorter than `count`.

## [0.3.0] — 2025-08-26

### Added

- Collection types (`RandomBoolCollection`, `RandomCharCollection`,
  `RandomDateCollection`, `RandomDateTimeCollection`,
  `RandomDayOfWeekCollection`, `RandomDecimalCollection`,
  `RandomDoubleCollection`, `RandomFloatCollection`,
  `RandomIntCollection`, `RandomStringCollection`, `RandomTimeCollection`,
  `RandomUIntCollection`, `RandomUShortCollection`) gained parameterless
  and `Random`-only constructors, in addition to their existing
  count-based constructors.

## [0.2.0] — 2025-08-24

### Added

- `RandomInt`, `RandomIntCollection`, `RandomUInt`, `RandomUIntCollection`,
  `RandomUShort`, and `RandomUShortCollection` gained constructors
  accepting explicit `min`/`max` bounds, constraining generated values to
  the given range.

## [0.1.1] — 2025-06-06

- Maintenance release: NuGet package metadata and license file added.

## [0.1.0] — 2025-06-06

### Added

- Initial release. Provides random-value generators for the `Pure.Primitives`
  abstractions: `RandomBool`, `RandomChar`, `RandomDate`, `RandomDateTime`,
  `RandomDayOfWeek`, `RandomDecimal`, `RandomDouble`, `RandomFloat`,
  `RandomInt`, `RandomString`, `RandomTime`, `RandomUInt`, and
  `RandomUShort`, each with a matching `*Collection` type for generating
  sequences of random values.
