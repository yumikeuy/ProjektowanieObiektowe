using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services.Visitors;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons
{
    public class ClassicBow : Weapon
    {
        private const int damage = 3; 
        public override char Char { get; set; } = 'D';
        public override bool IsTwoHanded { get; set; } = false;
        public override string Description { get; set; } = "Classic Ancient Bow";

        public ClassicBow()
        {
            base.Damage = damage;
        }
        public override bool Accept(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
