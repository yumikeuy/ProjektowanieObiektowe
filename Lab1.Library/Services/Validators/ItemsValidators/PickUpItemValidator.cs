using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services.Visitors;

namespace Lab1.Library.Services.Validators.ItemsValidators
{
    public static class PickUpItemValidator
    {
        public static bool IsValid(IBoard board, Point pos, IPlayerState playerState)
        {
            if (board.GetAt(pos).Accept(new PickUpItemAction(playerState)))
                return true;

            return false;
        }
    }
}
