using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons.Heavy
{
    public abstract class HeavyWeapon : Weapon
    {
        public override bool AcceptItemVisitor(ItemVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
