using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Heavy;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Light;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Magic;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Services.Visitors.ItemVisitors.WeaponVisitors
{
    public class MagicAttackVisitor(IPlayerState playerState) : AttackVisitor
    {
        public override int CalculatedDamage { get; set; } = 0;
        public override int CalculatedArmor { get; set; } = playerState.Luck;

        public override bool Visit(HeavyWeapon heavyWeapon)
        {
            CalculatedDamage = 1;
            CalculatedArmor = playerState.Luck;
            return true;
        }
        public override bool Visit(LightWeapon lightWeapon)
        {
            CalculatedDamage = 1;
            CalculatedArmor = playerState.Luck;
            return true;
        }
        public override bool Visit(MagicWeapon magicWeapon)
        {
            CalculatedDamage = magicWeapon.Damage;
            CalculatedArmor = playerState.Iq * 2;
            return true;
        }
    }
}
