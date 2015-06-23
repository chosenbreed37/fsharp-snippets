module CalculatorTests

open Xunit

[<Fact>]
let ``10000 compounded at 10% over 10 years yields `` () =
    let expected = 25937.424601
    let actual = Calculator.compound 10000.0 0.10 10
    Assert.Equal(expected, actual)

