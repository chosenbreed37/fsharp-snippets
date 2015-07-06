//module SearchFiles
//
//open System.IO
//
//let getFiles path pattern =
//    try
//        Some Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories)
//    with
//        |DirectoryNotFoundException -> None
//
