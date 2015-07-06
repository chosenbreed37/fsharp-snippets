module ParamsValidator

open Types

let validateSearchTerm input =
    if input.Term = "" then
        Failure InvalidSearchTerm
    else
        Success input

let validateReplacementTerm input =
    if input.Replacement = "" then
        Failure InvalidReplacementTerm
    else
        Success input

let validateFilePath input =
    if input.Path = "" then
        Failure InvalidFilePath
    else
        Success input

let bind switchFunction twoTrackInput =
    match twoTrackInput with
    |Success s -> switchFunction s
    |Failure f -> Failure f

let (>>=) twoTrackInput switchFunction =
    bind switchFunction twoTrackInput

let Validate input =
    input 
    |> validateSearchTerm 
    >>= validateReplacementTerm
    >>= validateFilePath
    
