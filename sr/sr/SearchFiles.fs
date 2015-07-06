module SearchFiles

open System
open System.IO

let getFiles path pattern =
    try
        Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories)
    with
        | :? DirectoryNotFoundException -> Seq.empty
        | :? IOException -> Seq.empty
        | _ -> Seq.empty

