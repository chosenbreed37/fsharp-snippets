module ParamsParser

open Types

let Parse args =
    { Term = ""; Replacement = ""; Path = ""}

let (|Parameter|_|) (prefix:string) (text:string) =
    if text.StartsWith(prefix) then
        Some(text.Substring(prefix.Length).Trim())
    else
        None

let rec Parse' = 
    let pattern = "-{1}([a-z]){1}[ ]*[a-zA-Z0-9_ ]*"


