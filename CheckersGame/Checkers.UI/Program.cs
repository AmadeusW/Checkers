using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Core.CS;

namespace Checkers.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameBoard = new Board();
            gameBoard.ToConsole();
        }
    }
}
