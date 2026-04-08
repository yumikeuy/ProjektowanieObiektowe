using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Services.WeaponModificators
{
    public class HappyModificator(Weapon weapon) : WeaponModificator(weapon)
    {
        private const int happinessBonus = 1;
        public override string Description => base.Description + " (Happy)";
        public override void Activate(IPlayerState playerState)
        {
            playerState.Luck += happinessBonus;
            base.Activate(playerState);
        }
        public override void Deactivate(IPlayerState playerState)
        {
            playerState.Luck -= happinessBonus;
            base.Deactivate(playerState);
        }        
    }
}
