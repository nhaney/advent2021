open System.IO

type Instruction =
    | Up of amount: int
    | Down of amount : int
    | Forward of amount : int

let parseInstruction (line: string) =
    let words = line.Split()

    if words.Length <> 2 then
        None 
    else 
        match words[0] with
        | "up" -> Some(Instruction.Up(int(words[1])))
        | "down" -> Some(Instruction.Down(int(words[1])))
        | "forward" -> Some(Instruction.Forward(int(words[1])))
        | _ -> None

let finalPositionWithoutAim (filename: string) =
    let instructions = 
        File.ReadAllLines(filename) 
        |> Array.toList
        |> List.map parseInstruction
        |> List.choose id
    let mutable x = 0
    let mutable y = 0

    for instruction in instructions do
        printfn "%A" instruction

        match instruction with
        | Up amount -> y <- y - amount
        | Down amount -> y <- y + amount
        | Forward amount -> x <- x + amount

        printfn "%d, %d" x y

    x * y

let finalPositionWithAim (filename: string) =
    let instructions = 
        File.ReadAllLines(filename) 
        |> Array.toList
        |> List.map parseInstruction
        |> List.choose id
    let mutable x = 0
    let mutable y = 0
    let mutable aim = 0

    for instruction in instructions do
        printfn "%A" instruction

        match instruction with
        | Up amount -> aim <- aim - amount
        | Down amount -> aim <- aim + amount
        | Forward amount -> x <- x + amount; y <- y + (aim * amount)

        printfn "%d, %d" x y

    x * y