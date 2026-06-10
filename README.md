# Pure.Primitives.Random

Random value generators for **Pure** primitive types.

[![.NET build & test](https://github.com/kudima03/Pure.Primitives.Random/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Random/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Primitives.Random/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Random/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Primitives.Random)](https://www.nuget.org/packages/Pure.Primitives.Random)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Primitives.Random` provides types that generate random values conforming to the `Pure.Primitives.Abstractions` interfaces. These generators are intended for use in tests, property-based testing, and fuzz testing scenarios where you need arbitrarily-valued but interface-conforming primitives.

## Types

### Single values

| Type | Implements | Generates |
|------|-----------|-----------|
| `RandomChar` | `IChar` | A random Unicode character |
| `RandomDate` | `IDate` | A random date |
| `RandomTime` | `ITime` | A random time |
| `RandomDateTime` | `IDateTime` | A random date-time |
| `RandomInt` / `RandomLong` / `RandomDouble` / etc. | `INumber<T>` | Random numeric values |

### Collections

| Type | Generates |
|------|-----------|
| `RandomCharCollection` | Random sequence of `IChar` values |
| `RandomDateCollection` | Random sequence of `IDate` values |
| `RandomTimeCollection` | Random sequence of `ITime` values |
| `RandomDateTimeCollection` | Random sequence of `IDateTime` values |

## Design Principles

- **Interface-conforming** — all types implement `Pure.Primitives.Abstractions` interfaces.
- **AOT-compatible** — no reflection; fully compatible with Native AOT.

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions) — Pure primitive interfaces
- [`Pure.Primitives`](https://github.com/kudima03/Pure.Primitives) — concrete implementations used internally
