using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons
{
    public abstract class Weapon : Item
    {
        public abstract int Damage { get; set; }
    }
}
