using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Interfaces.GameBuilders
{
    public interface IBoardBuilder
    {
        public IBoardBuilder InitializeEmpty(int width, int height);
        public IBoardBuilder InitializeFull(int width, int height);
        public IBoardBuilder AddCorridors();
        public IBoardBuilder AddRooms();
        public IBoardBuilder AddCentralRoom();
        public IBoardBuilder AddItems(int ammount);
        public IBoardBuilder AddWeapons(int amount);
        public IBoardBuilder AddMoney(int amount);
        public IBoardBuilder AddEnemies(int amount);
        public IBoard GetResult();
    }
}
