using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Console
{
    public class GameConfiguration : IGameConfiguration
    {
        public int BoardWidth { get; set; } = 40;
        public int BoardHeight { get; set; } = 20;
        public int PlayerStateWidth { get; set; } = 45;
        public int ItemsAmount { get; set; } = 20;
        public int WeaponsAmount { get; set; } = 10;
        public int MoneyCount { get; set; } = 5;
        public int EnemiesCount { get; set; } = 5;
        public bool AddRooms { get; set; } = true;
        public bool AddCorridors { get; set; } = true;
        public bool AddCentralRoom { get; set; } = false;
        public bool AddItems { get; set; } = true;
        public bool AddWeapons { get; set; } = true;
        public bool AddMoney { get; set; } = true;
        public bool AddEnemies { get; set; } = true;
        public string InitializeOption { get; set; } = string.Empty;
        public string LogPath { get; set; } = string.Empty;
        public string PlayerName { get; set; } = string.Empty;
        public string BuildingStrategy { get; set; } = string.Empty;
        public string Theme { get; set; } = string.Empty;
    }
}
