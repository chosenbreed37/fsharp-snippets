module ParamsParser

open System.Text.RegularExpressions
open Types

let (|Parameter|_|) (prefix:string) (text:string) =
    if text.StartsWith(prefix) then
        Some(text.Substring(prefix.Length).Trim())
    else
        None

//let rec Parse' args = 
 //   let pattern = "-{1}([a-z]){1}[ ]*[a-zA-Z0-9_ ]*"

let Split args =
    Regex.Matches(args, "-{1}([a-z]){1}[ ]*[a-zA-Z0-9_ ]*")
    |> Seq.cast
    |> Seq.map (fun (x: Match) -> x.Value)
    |> Seq.toList

let Parse args =
    let args' = Split args
    let rec Parse' p args' =
        match args' with
        |[] -> p
        |h::t ->
            match h with
            |Parameter "-t" v -> Parse' { p with Term = v } t
            |Parameter "-r" v -> Parse' { p with Replacement = v } t
            |Parameter "-p" v -> Parse' { p with Path = v } t
            |_ -> Parse' p t
    Parse' { Term = ""; Replacement = ""; Path = ""; } args'
