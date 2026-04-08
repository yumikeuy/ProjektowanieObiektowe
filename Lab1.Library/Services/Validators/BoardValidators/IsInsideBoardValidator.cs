using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Services.Validators.BoardValidators
{
    public static class IsInsideBoardValidator
    {
        public static bool IsValid(IBoard board, Point pos)
        {
            return pos.X >= 0 && pos.Y >= 0 && pos.X < board.Width && pos.Y < board.Height;
        }
    }
}
