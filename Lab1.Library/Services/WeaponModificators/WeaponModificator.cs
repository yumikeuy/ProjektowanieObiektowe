using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Services.WeaponModificators
{
    public abstract class WeaponModificator(IWeapon weapon) : IWeapon
    {
        protected IWeapon _weapon = weapon;

        public char Char { get => _weapon.Char; set => _weapon.Char = value; }
        public Point PrintAt { get => _weapon.PrintAt; set => _weapon.PrintAt = value; }
        public virtual string Description { get => _weapon.Description; set => _weapon.Description = value; }
        public bool IsTwoHanded { get => _weapon.IsTwoHanded; set => _weapon.IsTwoHanded = value; }
        public int Damage { get => _weapon.Damage; set => _weapon.Damage = value; }

        public virtual void Activate(IPlayerState playerState)
        {
            _weapon.Activate(playerState);
        }
        public virtual void Deactivate(IPlayerState playerState)
        {
            _weapon.Deactivate(playerState);
        }
        public bool AcceptItemVisitor(ItemVisitor visitor) 
        {
            return visitor.Visit(this);
        }

        public bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public IPrintable Text()
        {
            return _weapon.Text();
        }
    }
}
