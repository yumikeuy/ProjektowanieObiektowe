using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Interfaces.GameBuilders
{
    public interface IGameBuilder
    {
        public IGameBuilder InitializeEmpty();
        public IGameBuilder InitializeFull();
        public IGameBuilder AddCorridors();
        public IGameBuilder AddRooms();
        public IGameBuilder AddCentralRoom();
        public IGameBuilder AddItems(int ammount);
        public IGameBuilder AddWeapons(int amount);
        public IGameBuilder AddMoney(int amount);
        public IGameBuilder AddEnemies(int amount);
        public IGameState GetResult();
    }
}
