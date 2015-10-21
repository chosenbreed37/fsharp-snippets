let factWithForLoop n =
    let mutable result = 1
    for i in 1..n do
        result <- result * i
    result
factWithForLoop 5;;

let rec factWithNormalRecursion n =
    match n with
    |0 -> 1
    |x -> x * factWithNormalRecursion (x - 1)
factWithNormalRecursion 5;;

let factWithTailRecursion n =
    let rec fact' n acc =
        match n with
        |0 -> 1
        |x -> fact' (x - 1) x * acc
    fact' n 1

factWithTailRecursion 5;;

let factWithFold n = [1..n] |> Seq.reduce (*)

factWithFold 5;;