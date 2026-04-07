using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects.Enemies
{
    public class Zombie : Enemy
    {
        public override int Health { get; set; } = 15;
        public override int Damage { get; set; } = 3;
        public override int Armor { get; set; } = 3;
    }
}
