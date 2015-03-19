using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Core.CS
{
    public enum Piece
    {
        None,
        BlackMan,
        WhiteMan,
        BlackKing,
        WhiteKing
    }

    public class Board
    {
        Piece[,] _board;
        const int SIZE = 8;
        const int INITIAL_ROWS = 3;

        public Board()
        {
            _board = new Piece[SIZE, SIZE];
            for (int row = 0; row < INITIAL_ROWS; row++)
            {
                for (int spot = 0; spot < SIZE; spot++)
                {
                    if (spot % 2 == row % 2)
                    {
                        _board[row, spot] = Piece.BlackMan;
                    }
                }
            }
            for (int row = SIZE-INITIAL_ROWS; row < SIZE; row++)
            {
                for (int spot = 0; spot < SIZE; spot++)
                {
                    if (spot % 2 == row % 2)
                    {
                        _board[row, spot] = Piece.WhiteMan;
                    }
                }
            }
        }

        public void ToConsole()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Black Player");

            for (int row = 0; row < SIZE; row++)
            {
                for (int spot = 0; spot < SIZE; spot++)
                {
                    switch (_board[row, spot])
                    {
                        case Piece.None:
                            if (spot % 2 == row % 2)
                            {
                                Console.Write("-");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                            break;
                        case Piece.BlackMan:
                            Console.Write("b");
                            break;
                        case Piece.WhiteMan:
                            Console.Write("w");
                            break;
                        case Piece.BlackKing:
                            Console.Write("B");
                            break;
                        case Piece.WhiteKing:
                            Console.Write("W");
                            break;
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("White Player");
        }
    }
}
