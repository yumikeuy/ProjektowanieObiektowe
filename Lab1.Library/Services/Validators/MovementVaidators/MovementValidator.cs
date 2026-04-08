using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Validators.BoardValidators;
using Lab1.Library.Services.Visitors;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Services.Validators.MovementVaidators
{
    public static class MovementValidator
    {
        public static bool IsValid(IBoard board, Point nextPos)
        {
            if (!IsInsideBoardValidator.IsValid(board, nextPos)) return false;
            if (board.GetAt(nextPos).AcceptGameObjectVisitor(new CantBeGoneThrough())) return false;
            return true;
        }
    }
}
