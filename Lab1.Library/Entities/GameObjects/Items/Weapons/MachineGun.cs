using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services.Visitors;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons
{
    public class MachineGun : Weapon
    {
        public const int damage = 10;
        public override char Char { get; set; } = '*';
        public override bool IsTwoHanded { get; set; } = true;
        public override string Description { get; set; } = "Enormous MachineGun";

        public MachineGun()
        {
            base.Damage = damage;
        }
        public override bool Accept(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
