using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Enemies;
using Lab1.Library.Entities.GameObjects.Items.Neutral;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Heavy;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Light;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Magic;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Entities.GameObjects;

namespace Lab1.Library.Services.Visitors.ItemVisitors
{
    public abstract class ItemVisitor
    {
        public virtual bool Visit(Weapon weapon) { return false; }
        public virtual bool Visit(HeavyWeapon heavyWeapon) { return false; }
        public virtual bool Visit(LightWeapon lightWeapon) { return false; }
        public virtual bool Visit(MagicWeapon magicWeapon) { return false; }
        public virtual bool Visit(Item item) { return false; }
        public virtual bool Visit(NeutralItem neutralItem) { return false; }

    }
}
