module Tests

open Xunit

[<Fact>]
let ``Add test`` () =
    let expected = 2
    let actual = Calculator.Add 1 1
    Assert.Equal(expected, actual)