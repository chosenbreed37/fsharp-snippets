module ParamsValidatorTests

open Xunit
open Types

[<Fact>]
let `` Detects missing search term `` () =
    let result = @"-r bar -p d:\temp\*.config" |> ParamsParser.Parse |> ParamsValidator.Validate
    match result with
    |Success _ -> failwith "Validation failure expected"
    |Failure f -> Assert.Equal(InvalidSearchTerm, f)

[<Fact>]
let `` Detects missing replacement term `` () =
    let result = @"-t foo -p d:\temp\*.config" |> ParamsParser.Parse |> ParamsValidator.Validate
    match result with
    |Success _ -> failwith "Validation failure expected"
    |Failure f -> Assert.Equal(InvalidReplacementTerm, f)

[<Fact>]
let `` Detects missing path `` () =
    let result = @"-t foo -r bar" |> ParamsParser.Parse |> ParamsValidator.Validate
    match result with
    |Success _ -> failwith "Validation failure expected"
    |Failure f -> Assert.Equal(InvalidFilePath, f)