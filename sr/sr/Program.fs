﻿// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
module sr

open Types
open ParamsParser
open ParamsValidator
open SearchFiles

[<EntryPoint>]
let main argv = 
    let result = 
        argv |> String.concat " " |> ParamsParser.Parse |> SearchFiles.execute
    printfn "%A" result
    0 // return an integer exit code
        