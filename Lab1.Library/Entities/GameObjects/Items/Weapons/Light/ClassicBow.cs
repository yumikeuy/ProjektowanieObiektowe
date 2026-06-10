using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Neutral;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.NeutralItems;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.LightWeapons;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons.Light
{
    public class ClassicBow : Item, ILightWeapon
    {
        public int Damage { get; set; } = 3;
        public override char Char { get; set; } = 'D';
        public override bool IsTwoHanded { get; set; } = false;
        public override string Description { get; set; } = "Classic Ancient Bow";

        public bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public bool AcceptItemVisitor(ItemVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
