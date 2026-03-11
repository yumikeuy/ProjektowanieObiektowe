using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons
{
    public class MachineGun(Point pos) : Weapon(pos)
    {
        public override char Char { get; set; } = '*';
        public override bool IsTwoHanded { get; set; } = true;
        public override int Damage { get; set; } = 10;
        public override string Description { get; set; } = "Enormous MachineGun";
    }
}
