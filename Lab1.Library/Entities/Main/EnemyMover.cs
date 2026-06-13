using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Entities.Main
{
    public class EnemyMover : IEnemyMover
    {
        private readonly List<IEnemy> enemies = [];
        public void Add(IEnemy enemy)
        {
            enemies.Add(enemy);
        }
        public void Move(IGameState gs)
        {
            foreach(var enemy in enemies)
                enemy.Move(gs);
        }
    }
}
