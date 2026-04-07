using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Services.Validators.ItemsValidators
{
    public static class DropItemValidator
    {
        public static bool IsValid(IBoard board, Point pos)
        {
            return board.GetAt(pos).IsEmpty;
        }
    }
}
