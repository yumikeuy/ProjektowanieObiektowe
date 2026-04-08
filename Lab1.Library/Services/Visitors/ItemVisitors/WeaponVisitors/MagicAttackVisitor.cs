using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Heavy;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Light;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Magic;

namespace Lab1.Library.Services.Visitors.ItemVisitors.WeaponVisitors
{
    public class MagicAttackVisitor : ItemVisitor
    {
        public int CalculatedDamage { get; set; } = 0;

        public override bool Visit(HeavyWeapon heavyWeapon)
        {
            CalculatedDamage = 1;
            return true;
        }
        public override bool Visit(LightWeapon lightWeapon)
        {
            CalculatedDamage = 1;
            return true;
        }
        public override bool Visit(MagicWeapon magicWeapon)
        {
            CalculatedDamage = magicWeapon.Damage;
            return true;
        }
    }
}
