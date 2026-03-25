using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces
{
    public interface IBoardModificator
    {
        public IBoardModificator AddCorridors(IBoard board);
        public IBoardModificator AddRooms(IBoard board);
        public IBoardModificator AddCentralRoom(IBoard board);
        public IBoardModificator AddItems(IBoard board, int amount);
        public IBoardModificator AddWeapons(IBoard board, int amount);
        public IBoardModificator AddMoney(IBoard board, int amount);
    }
}
