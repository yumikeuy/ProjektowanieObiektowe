using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Services.WeaponModificators
{
    public class HeavyModificator(Weapon weapon) : WeaponModificator(weapon)
    {
        private const int damageBonus = 25;
        public override void Activate(IPlayerState playerState)
        {
            base.Activate(playerState);
            playerState.Damage += damageBonus;
        }
        public override void Deactivate(IPlayerState playerState)
        {
            base.Deactivate(playerState);
            playerState.Damage -= damageBonus;
        }
    }
}
