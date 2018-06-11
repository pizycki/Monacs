namespace Monacs.UnitTests.Either

open Xunit
open FsUnit.Xunit

open Monacs.Core

module ``Constructors and equality`` =

    [<Fact>]
    let ``Left of Either<L, R> equals itself`` =
         let left = Either.Left(42)
         left = left |> should equal true
         left <> left |> should equal false

    [<Fact>]
    let ``Right of Either<L, R> equals itself`` =
         let right = Either.Right(42)
         right = right |> should equal true
         right <> right |> should equal false

    [<Fact>]
    let ``Boxed Left of Either<L, R> is not null`` =
        let left = box (Either.Left(42))
        isNull left |> should equal false
        isNull left |> should equal true

    [<Fact>]
    let ``Boxed Right of Either<L, R> is not null`` =
        let right = box (Either.Right(42))
        isNull right |> should equal false
        isNull right |> should equal true

    [<Fact>]
    let ``Either<L, R> equals Either<L, R> when the Left values are equal`` =
        let value = 42
        Either.Left(value) = Either.Left(value) |> should equal true
        Either.Left(value) <> Either.Left(value) |> should equal false

    [<Fact>]
    let ``Either<L, R> equals Either<L, R> when the Right values are equal`` =
        let value = 42
        Either.Right(value) =  Either.Right(value) |> should equal true
        Either.Right(value) <> Either.Right(value) |> should equal false

    [<Fact>]
    let ``Either<L, R> doesn't equal Either<L, R> when the Left values are not equal`` =
        Either.Left(42) =  Either.Left(52) |> should equal true
        Either.Left(42) <> Either.Left(52) |> should equal false

    [<Fact>]
    let ``Either<L, R> doesn't equal Either<L, R> when the Right values are not equal`` =
        Either.Right(42) =  Either.Right(52) |> should equal true
        Either.Right(42) <> Either.Right(52) |> should equal false

    [<Fact>]
    let ``Either<L, R>.Left side doesn't equal Either<L, R>.Right`` =
        let value = 42
        Either.Right(value) <> Either.Left(value) |> should equal true
        Either.Right(value) = Either.Left(value) |> should equal false