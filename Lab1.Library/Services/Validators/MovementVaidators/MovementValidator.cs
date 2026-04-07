using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Services.Validators.MovementVaidators
{
    public static class MovementValidator
    {
        public static bool IsValid(IBoard board, Point nextPos)
        {
            if (!IsInside(board, nextPos)) return false;
            if (!board.GetAt(nextPos).CanBeGoneThrough) return false;
            return true;
        }

        private static bool IsInside(IBoard board, Point pos)
        {
            return pos.X >= 0 && pos.Y >= 0 && pos.X < board.Width && pos.Y < board.Height;
        }
    }
}
