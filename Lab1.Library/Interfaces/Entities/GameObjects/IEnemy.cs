using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Interfaces.Entities.GameObjects
{
    public interface IEnemy : IGameObject, IDestroyable, IDamagable
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
    }
}
