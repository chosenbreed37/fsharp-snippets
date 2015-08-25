let Euler2 = 
    let (|Stop|CarryOn|) (l:int list) = 
        match l with
        |h::t -> 
            if h > 4000000 then Stop else CarryOn
        |_ -> CarryOn

    let rec fib1' l =
        match l with
        |Stop -> List.tail l     
        |CarryOn -> 
            match l with
            |[] -> fib1' [2;1]
            |a::b::t -> fib1' (a+b::a::b::t)
            |[_] -> [2;1]
    fib1' [] |> List.filter (fun x -> x % 2 = 0) |> List.sum