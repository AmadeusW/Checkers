namespace Checkers.Core.Tests

open NUnit.Framework

[<TestFixture>]
module BoardTests =

    open Checkers.Core.GameRules

    [<Test>]
    let ``Board is properly set up`` ()=
        Assert.AreEqual(startGame |> List.filter (fun x -> x = BlackMan) |> List.length, 12)
        Assert.AreEqual(startGame |> List.filter (fun x -> x = WhiteMan) |> List.length, 12)
        Assert.AreEqual(startGame |> List.filter (fun x -> x = BlackKing) |> List.length, 0)
        Assert.AreEqual(startGame |> List.filter (fun x -> x = WhiteKing) |> List.length, 0)
