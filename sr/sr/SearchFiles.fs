module SearchFiles

open System
open System.IO

open Types

let getFiles path pattern =
    try
        Success (Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories))
    with
        | :? DirectoryNotFoundException -> Failure DirectoryNotFound
        | :? IOException -> Failure IOError
        | _ -> Failure IOError

