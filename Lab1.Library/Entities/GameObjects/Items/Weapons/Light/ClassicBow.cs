using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons.Light
{
    public class ClassicBow : LightWeapon
    {
        private const int damage = 3;
        public override char Char { get; set; } = 'D';
        public override bool IsTwoHanded { get; set; } = false;
        public override string Description { get; set; } = "Classic Ancient Bow";

        public ClassicBow()
        {
            Damage = damage;
        }
        public override bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
