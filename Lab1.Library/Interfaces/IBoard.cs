using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;

namespace Lab1.Library.Interfaces
{
    public interface IBoard : ITextConvertible
    {
        public bool TryMovePlayer(IPlayer player, Point pos);
        public bool TryPickUp(IPlayer player);
        public bool TryDrop(IPlayer player);
    }
}
