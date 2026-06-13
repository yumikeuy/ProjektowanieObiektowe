using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Neutral;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Heavy;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Light;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Magic;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.HeavyWeapons;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.LightWeapons;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.MagicWeapons;

namespace Lab1.Library.Interfaces.Visitors
{
    public interface IItemVisitor
    {
        public bool Visit(IWeapon weapon);
        public bool Visit(IHeavyWeapon heavyWeapon);
        public bool Visit(ILightWeapon lightWeapon);
        public bool Visit(IMagicWeapon magicWeapon);
        public bool Visit(IItem item);
    }
}
