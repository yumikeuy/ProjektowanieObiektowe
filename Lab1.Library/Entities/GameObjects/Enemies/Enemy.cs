using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects.Enemies
{
    public abstract class Enemy : GameObject
    {
        public override char Char { get; set; } = '#';
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }
        public abstract int Armor { get; set; }
    }
}
