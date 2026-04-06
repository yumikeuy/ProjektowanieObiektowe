using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Interfaces.GameBuilders
{
    public interface IBoardModificator
    {
        public IBoardModificator AddCorridors(IBoard board);
        public IBoardModificator AddRooms(IBoard board);
        public IBoardModificator AddCentralRoom(IBoard board);
        public IBoardModificator AddItems(IBoard board, int amount);
        public IBoardModificator AddWeapons(IBoard board, int amount);
        public IBoardModificator AddMoney(IBoard board, int amount);
        public IBoardModificator AddEnemies(IBoard board, int amount);
    }
}
