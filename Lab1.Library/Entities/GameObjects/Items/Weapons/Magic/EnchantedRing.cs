using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons.Magic
{
    public class EnchantedRing : MagicWeapon
    {
        public const int damage = 6;
        public override char Char { get; set; } = 'q';
        public override bool IsTwoHanded { get; set; } = false;
        public override string Description { get; set; } = "Legendary enchanted ring";

        public EnchantedRing()
        {
            Damage = damage;
        }
        public override bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
