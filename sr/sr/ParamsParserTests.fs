module ParamsParserTests

open Xunit

[<Fact>]
let `` Parameter pattern matches search term `` () =
    match "-t term" with
    |ParamsParser.Parameter "-t" r -> Assert.Equal("term", r)
    |_ -> failwith "Invalid pattern"

[<Fact>]
let `` Parameter pattern matches replacement term `` () =
    match "-r replace" with
    |ParamsParser.Parameter "-r" r -> Assert.Equal("replace", r)
    |_ -> failwith "Invalid pattern"

[<Fact>]
let `` Parameter pattern matches path `` () =
    match "-p path" with
    |ParamsParser.Parameter "-p" r -> Assert.Equal("path", r)
    |_ -> failwith "Invalid pattern"

[<Fact>]
let `` A valid parameter set includes search term `` () =
    let expected = "foo"
    let params' = ParamsParser.Parse "-t foo -r bar -p d:\temp\*.config"
    Assert.Equal(expected, params'.Term)
