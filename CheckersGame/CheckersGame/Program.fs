open System
open Checkers.Core.GameRules
// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

let printGame (board: Board) =
    let inEvenRow index =
        (index - 1) % (4 * 2) >= 4

    Console.SetCursorPosition(0, 0);
    Console.WriteLine("Black Player");

    for index in 1 .. (board |> List.length) - 1 do

        if not (inEvenRow index) then
            Console.Write("▓");

        let myColor =
            try
                if isMoveAllowed board 22 index then
                    ConsoleColor.Green
                else
                    ConsoleColor.Red
            with
                | ex -> ConsoleColor.DarkRed

        if 22 = index then
            Console.ForegroundColor <- ConsoleColor.White
        else
            Console.ForegroundColor <- myColor

        match board.Item index with
        | Empty -> Console.Write("-");
        | BlackKing -> Console.Write("B")
        | BlackMan -> Console.Write("b")
        | WhiteKing -> Console.Write("W")
        | WhiteMan -> Console.Write("w");

        Console.ForegroundColor <- ConsoleColor.Gray
        
        if (inEvenRow index) then
            Console.Write("▓");

        if index % 4 = 0 then
            Console.WriteLine("");

    Console.WriteLine("White Player");
    0

[<EntryPoint>]
let main argv = 
    let board = startGame
    let nothing = printGame board
    printfn "%A" argv
    0 // return an integer exit code

