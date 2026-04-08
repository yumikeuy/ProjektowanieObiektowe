using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Services.WeaponModificators
{
    public abstract class WeaponModificator(Weapon weapon) : Weapon
    {
        protected Weapon _weapon = weapon;

        public override char Char => _weapon.Char;
        public override Point PrintAt => _weapon.PrintAt;
        public override string Description => _weapon.Description;
        public override bool IsTwoHanded => _weapon.IsTwoHanded;

        public override void Activate(IPlayerState playerState)
        {
            _weapon.Activate(playerState);
            base.Activate(playerState);
        }
        public override void Deactivate(IPlayerState playerState)
        {
            _weapon.Deactivate(playerState);
            base.Deactivate(playerState);
        }
        public override bool AcceptItemVisitor(ItemVisitor visitor) 
        {
            return _weapon.AcceptItemVisitor(visitor);
        }
    }
}
