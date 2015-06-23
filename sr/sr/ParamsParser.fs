module ParamsParser

open Types

//let Parse args =
//    { Term = ""; Replacement = ""; Path = ""}

let (|Parameter|_|) (prefix:string) (text:string) =
    if text.StartsWith(prefix) then
        Some(text.Substring(prefix.Length).Trim())
    else
        None

//let rec Parse' args = 
 //   let pattern = "-{1}([a-z]){1}[ ]*[a-zA-Z0-9_ ]*"

let Parse args =
    let rec Parse' p args =
        match args with
        |[] -> p
        |h::t ->
            match h with
            |Parameter "-t" v -> Parse' { p with Term = v } t
            |Parameter "-r" v -> Parse' { p with Replacement = v } t
            |Parameter "-p" v -> Parse' { p with Path = v } t
            |_ -> Parse' p t
    Parse' { Term = ""; Replacement = ""; Path = ""; } args