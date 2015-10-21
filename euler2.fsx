let Euler2 = 
    let (|Stop|CarryOn|) (l:int list) = 
        match l with
        |h::t -> 
            if h > 4000000 then Stop else CarryOn
        |_ -> CarryOn

    let rec fib l =
        match l with
        |Stop -> List.tail l     
        |CarryOn -> 
            match l with
            |[] -> fib [2;1]
            |a::b::t -> fib (a+b::a::b::t)
            |[_] -> [2;1]
    fib [] |> List.filter (fun x -> x % 2 = 0) |> List.sum