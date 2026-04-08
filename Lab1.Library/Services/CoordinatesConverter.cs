using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Services
{
    public static class CoordinatesConverter
    {
        public static Point ConsoleToBoard(IBoard board, Point point)
        {
            return point - board.GetZero();
        }

        public static Point BoardToConsole(IBoard board, Point point)
        {
            return point + board.GetZero();
        }
    }
}
