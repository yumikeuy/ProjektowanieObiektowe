using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.NeutralItems;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.HeavyWeapons;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.LightWeapons;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.MagicWeapons;

namespace Lab1.Library.Services.Visitors.ItemVisitors.WeaponVisitors
{
    public class NoiseWeaponVisitor : ItemVisitor
    {
        public int Radius { get; set; } = 0;
        public override bool Visit(IHeavyWeapon heavyWeapon)
        {
            Radius = 7;
            return true;
        }
        public override bool Visit(ILightWeapon lightWeapon)
        {
            Radius = 2;
            return true;
        }
        public override bool Visit(IMagicWeapon magicWeapon)
        {
            Radius = 4;
            return true;
        }
    }
}
