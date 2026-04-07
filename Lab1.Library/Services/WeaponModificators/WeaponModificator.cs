using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Services.WeaponModificators
{
    public abstract class WeaponModificator : Weapon
    {
        protected Weapon _weapon;

        public override char Char => _weapon.Char;
        public override Point PrintAt => _weapon.PrintAt;
        public override string Description => _weapon.Description;
        public override bool IsTwoHanded => _weapon.IsTwoHanded;

        public override void Activate(IPlayerState playerState)
        {
            base.Activate(playerState);
            _weapon.Activate(playerState);
        }
        public override void Deactivate(IPlayerState playerState)
        {
            base.Deactivate(playerState);
            _weapon.Deactivate(playerState);
        }
        public WeaponModificator(Weapon weapon)
        {
            _weapon = weapon;
        }
    }
}
