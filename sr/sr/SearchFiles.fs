module SearchFiles

open System
open System.IO

open Types

let getFiles args =
    try
        Success (Directory.EnumerateFiles(args.Dir, args.Pattern, SearchOption.AllDirectories))
    with
        | :? DirectoryNotFoundException -> Failure DirectoryNotFound
        | :? IOException -> Failure IOError
        | _ -> Failure IOError

let replace (s:string) (r:string) filename =
    let text = File.ReadAllText(filename)
    text.Replace(s, r)

let save text filename =
    try
        File.WriteAllText(filename, text)
        Success Succeeded
    with
        | :? IOException -> Failure IOError
        | _ -> Failure IOError
