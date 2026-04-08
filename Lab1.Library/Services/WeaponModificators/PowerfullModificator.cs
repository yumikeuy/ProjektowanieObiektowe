using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Services.WeaponModificators
{
    public class PowerfullModificator : WeaponModificator
    {
        private const int damageBonus = 5;

        public PowerfullModificator(Weapon weapon) : base(weapon)
        {
            Damage += damageBonus;
        }
    }
}
