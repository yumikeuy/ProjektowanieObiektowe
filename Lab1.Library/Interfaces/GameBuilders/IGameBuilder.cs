using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons;
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
        public IGameBuilder AddItems(List<IItem> items, int ammount);
        public IGameBuilder AddWeapons(List<IWeapon> weapons, int amount);
        public IGameBuilder AddMoney(int amount);
        public IGameBuilder AddEnemies(List<IEnemy> enemies, int amount);
        public IGameBuilder AddArtefact(IItem artefact);
        public IGameState GetResult();
    }
}
