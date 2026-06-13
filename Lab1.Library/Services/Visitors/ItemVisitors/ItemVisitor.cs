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
using Lab1.Library.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Visitors;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.HeavyWeapons;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.LightWeapons;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.MagicWeapons;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.NeutralItems;

namespace Lab1.Library.Services.Visitors.ItemVisitors
{
    public abstract class ItemVisitor : IItemVisitor
    {
        public virtual bool Visit(IWeapon weapon) { return false; }
        public virtual bool Visit(IHeavyWeapon heavyWeapon) { return false; }
        public virtual bool Visit(ILightWeapon lightWeapon) { return false; }
        public virtual bool Visit(IMagicWeapon magicWeapon) { return false; }
        public virtual bool Visit(IItem item) { return false; }
        public virtual bool Visit(INeutralItem item) { return false; }
        public virtual bool Visit(IHandle item) { return false; }
    }
}
