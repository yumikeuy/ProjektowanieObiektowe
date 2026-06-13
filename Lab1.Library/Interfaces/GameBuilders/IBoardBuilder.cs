using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Events;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Interfaces.GameBuilders
{
    public interface IBoardBuilder
    {
        public IBoardBuilder InitializeEmpty(int width, int height);
        public IBoardBuilder InitializeFull(int width, int height);
        public IBoardBuilder AddCorridors();
        public IBoardBuilder AddRooms();
        public IBoardBuilder AddCentralRoom();
        public IBoardBuilder AddItems(List<IItem> items, int ammount);
        public IBoardBuilder AddWeapons(List<IWeapon> items, int amount);
        public IBoardBuilder AddMoney(int amount);
        public IBoardBuilder AddEnemies(IEnemyMover enemyMover, IMediatorsDirector<INoiseData, IKillData> mediatorsDirector, List<IEnemy> items, int amount);
        public IBoardBuilder AddArtefact(IItem artefact);
        public IBoard GetResult();
    }
}
