using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons
{
    public abstract class Weapon(Point pos) : Item(pos)
    {
        public abstract int Damage { get; set; }
        public override string Tag { get; set; } = "Weapon";
    }
}
