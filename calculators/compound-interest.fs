module Calculator

let rec compound (principal:float) (interest:float) (term:int) =
    match term with
    |0 -> principal
    |_ -> compound (principal * interest + principal) interest (term - 1)