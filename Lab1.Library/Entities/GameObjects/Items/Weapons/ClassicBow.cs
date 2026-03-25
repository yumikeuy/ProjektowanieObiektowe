using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons
{
    public class ClassicBow : Weapon
    {
        public override char Char { get; set; } = 'D';
        public override bool IsTwoHanded { get; set; } = false;
        public override int Damage { get; set; } = 3;
        public override string Description { get; set; } = "Classic Ancient Bow";
    }
}
