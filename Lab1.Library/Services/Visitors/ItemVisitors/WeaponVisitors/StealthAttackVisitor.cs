using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Neutral;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Heavy;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Light;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Magic;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Services.Visitors.ItemVisitors.WeaponVisitors
{
    public class StealthAttackVisitor(IPlayerState playerState) : AttackVisitor
    {
        public override int CalculatedDamage { get; set; } = 0;
        public override int CalculatedArmor { get; set; } = 0;


        public override bool Visit(HeavyWeapon heavyWeapon)
        {
            CalculatedDamage = heavyWeapon.Damage / 2;
            CalculatedArmor = playerState.Agressiveness;
            return true;
        }
        public override bool Visit(LightWeapon lightWeapon)
        {
            CalculatedDamage = lightWeapon.Damage * 2;
            CalculatedArmor = playerState.Agility;
            return true;
        }
        public override bool Visit(MagicWeapon magicWeapon)
        {
            CalculatedDamage = 1;
            return true;
        }
    }
}
