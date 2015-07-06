module Types

type Params = {
    Term:string;
    Replacement:string;
    Path:string;
}

type ErrorMessage =
    |InvalidSearchTerm
    |InvalidReplacementTerm
    |InvalidFilePath

    |DirectoryNotFound
    |IOError

type Result<'T> =
    |Success of 'T
    |Failure of ErrorMessage

