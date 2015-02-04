namespace Checkers.Core

module GameRules =

    let size = 4
    let initialRows = 3
    let allowKingRun = false

    type Player = Black | White
    type Direction = NE | SE | SW | NW
    type Tile = Empty | BlackKing | WhiteKing | BlackMan | WhiteMan | Invalid
    type Board = Tile list

    let startGame =
        let piecesPerPlayer = size * initialRows
        let emptyTiles = (size - initialRows) * 2 * size
        Invalid :: [for i in 1 .. piecesPerPlayer -> BlackMan] @ [for i in 1 .. emptyTiles -> Empty] @ [for i in 1 .. piecesPerPlayer -> WhiteMan]

    let board = startGame

    let isGameOver board =
        (board |> List.filter (fun x -> x = BlackKing || x = BlackMan) |> List.isEmpty)
        || (board |> List.filter (fun x -> x = WhiteKing || x = WhiteMan) |> List.isEmpty)

    (*  The game board:
        Black player
     0  -   1   -   2   -   3   -   4
        5   -   6   -   7   -   8   -
        -   9   -   10  -   11  -   12
        13  -   14  -   15  -   16  -
        -   17  -   18  -   19  -   20
        21  -   22  -   23  -   24  -
        -   25  -   26  -   27  -   28
        29  -   30  -   31  -   32  -
        White player
    *)

    let canPieceMove piece direction distance =
        match piece with
        | BlackKing -> distance = 1 || allowKingRun
        | BlackMan -> distance = 1 && (direction = SE || direction = SW)
        | WhiteKing -> distance = 1 || allowKingRun
        | WhiteMan -> distance = 1 && (direction = NE || direction = NW)
        | _ -> false

    let canPieceJump piece direction distance =
        match piece with
        | BlackKing -> distance = 2 || (distance > 2 && allowKingRun)
        | BlackMan -> distance = 2 && (direction = SE || direction = SW)
        | WhiteKing -> distance = 2 || allowKingRun
        | WhiteMan -> distance = 2 && (direction = NE || direction = NW)
        | _ -> false

    let inEvenRow index =
            (index - 1) % (size * 2) >= size
    let rowDifference (index1: int) (index2: int) =
            abs(index1 / size - index2 / size)

    let getIndex direction initialPosition =
        match direction with
        | NE ->
            match inEvenRow initialPosition with
            | true  -> initialPosition - 4
            | false -> initialPosition - 3
        | SE ->
            match inEvenRow initialPosition with
            | true  -> initialPosition + 4
            | false -> initialPosition + 5
        | SW ->
            match inEvenRow initialPosition with
            | true  -> initialPosition + 3
            | false -> initialPosition + 4
        | NW ->
            match inEvenRow initialPosition with
            | true  -> initialPosition - 5
            | false -> initialPosition - 4

    let getTiles board initialPosition direction distance =
        [ for index in 1 .. distance do
            let testPosition = getIndex direction initialPosition
            // Probably there are unnecessary checks here
            let tileType = board |> List.item testPosition
            let initialPosition = testPosition
            yield tileType
        ]

    let getTrajectory initialPosition finalPosition =
        let convertToXY position =
            let X = 
                match inEvenRow position with
                | true  -> ((position - 1) % size) * 2 + 1
                | false -> ((position - 1) % size) * 2 + 2
            let Y = (position - 1) / size + 1
            X, Y
        // Get XY coordinates
        let initialPoint = convertToXY initialPosition
        let finalPoint = convertToXY finalPosition
        let distanceX = fst finalPoint - fst initialPoint
        let distanceY = snd finalPoint - snd initialPoint

        // Find the direction
        let direction =
            if distanceX > 0 && distanceY < 0 then NE
            elif distanceX > 0 && distanceY > 0 then SE
            elif distanceX < 0 && distanceY > 0 then SW
            else NW
    
        direction, abs(distanceX), abs(distanceY)

    let isMoveAllowed (board: Board) initialPosition finalPosition =
        let direction, distanceX, distanceY = getTrajectory initialPosition finalPosition
        if distanceX = distanceY && distanceX <> 0 then
            let piece = board |> List.item initialPosition
            let coveredTiles = getTiles board initialPosition direction distanceX
            let numberOfEmpty = coveredTiles |> List.filter (fun x -> x = Empty) |> List.length
            let numberOfInvalid = coveredTiles |> List.filter (fun x -> x = Invalid) |> List.length
            let isLastTileEmpty = coveredTiles |> List.last = Empty

            if numberOfInvalid = 0 && isLastTileEmpty then
                if canPieceJump piece direction distanceX then
                    // Check if enemy is second last
                    let enemySpot = coveredTiles |> List.item (distanceX - 2)
                    let foundEnemy =
                        match piece with
                        | BlackKing | BlackMan ->
                            enemySpot = WhiteKing || enemySpot = WhiteMan
                        | WhiteKing | WhiteMan ->
                            enemySpot = BlackKing || enemySpot = BlackMan
                        | _ -> false
        
                    // There must be only one piece in between and it must be the expected enemy
                    foundEnemy && numberOfEmpty = distanceX - 1
                elif canPieceMove piece direction distanceX then
                    numberOfEmpty = distanceX
                else
                    false
            else
                false
        else
            false
    

    let inKingRow player finalPosition =
        match player with
        | Black -> finalPosition > size * (size * 2 - 1)
        | White -> finalPosition <= size