using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Interfaces.Game
{
    public interface IEnemyMover
    {
        public void Add(IEnemy enemy);
        public void Move(IGameState gs);
    }
}
