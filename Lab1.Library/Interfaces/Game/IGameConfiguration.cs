using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.Game
{
    public interface IGameConfiguration
    {
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        public int PlayerStateWidth { get; set; }
        public int ItemsAmount { get; set; }
        public int WeaponsAmount { get; set; }
        public int MoneyCount { get; set; }
        public int EnemiesCount { get; set; }
        public bool AddRooms { get; set; }
        public bool AddCorridors { get; set; }
        public bool AddCentralRoom { get; set; }
        public bool AddItems { get; set; }
        public bool AddWeapons { get; set; }
        public bool AddMoney { get; set; }
        public bool AddEnemies { get; set; }
        public string InitializeOption { get; set; }
        public string LogPath { get; set; }
        public string PlayerName { get; set; }
    }
}
