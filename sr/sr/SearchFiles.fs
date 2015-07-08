module SearchFiles

open System
open System.IO

open Types

let getFiles args =
    try
        Success (args, Directory.EnumerateFiles(args.Dir, args.Pattern, SearchOption.AllDirectories))
    with
        | :? DirectoryNotFoundException -> Failure DirectoryNotFound
        | :? IOException -> Failure IOError
        | _ -> Failure IOError

let replace (s:string) (r:string) filename =
    try
        let text = File.ReadAllText(filename)
        Success (text.Replace(s, r))
    with
        | :? IOException -> Failure IOError
        | _ -> Failure IOError

let save filename text =
    try
        File.WriteAllText(filename, text)
        Success Succeeded
    with
        | :? IOException -> Failure IOError
        | _ -> Failure IOError

let apply args =
    try
        let params' = 
                match args with
                |(t1, _) -> t1
                |_ -> {Term = ""; Replacement = ""; Dir = ""; Pattern = ""}
        let files = 
            match args with
            |(_, t2) -> t2
            |_ -> Seq.empty
        Seq.map (fun file -> replace params'.Term params'.Replacement file >>= save file) files |> ignore
        Success Succeeded
    with
        | :? IOException -> Failure IOError
        | _ -> Failure IOError