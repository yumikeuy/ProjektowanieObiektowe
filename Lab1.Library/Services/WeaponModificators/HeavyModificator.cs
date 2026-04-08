using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Services.WeaponModificators
{
    public class HeavyModificator : WeaponModificator
    {
        private const int damageBonus = 25;

        public HeavyModificator(Weapon weapon) : base(weapon)
        {
            Damage += damageBonus;
        }
    }
}
