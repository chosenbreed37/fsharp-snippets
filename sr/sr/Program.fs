// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
module sr

open Types
open ParamsParser
open ParamsValidator
open SearchFiles

[<EntryPoint>]
let main argv = 
    let args = String.concat " " argv |> ParamsParser.Parse |> SearchFiles.getFiles
    printfn "%A" args
    0 // return an integer exit code
        