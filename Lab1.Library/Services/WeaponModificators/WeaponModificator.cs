using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items;
using Lab1.Library.Entities.GameObjects.Items.Neutral;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.NeutralItems;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Services.WeaponModificators
{
    public class WeaponModificator(IWeapon weapon) : Item, IWeapon
    {
        protected IWeapon _weapon = weapon;

        public override char Char { get => _weapon.Char; set => _weapon.Char = value; }
        public override Point PrintAt { get => _weapon.PrintAt; set => _weapon.PrintAt = value; }
        public override string Description { get => _weapon.Description; set => _weapon.Description = value; }
        public override bool IsTwoHanded { get => _weapon.IsTwoHanded; set => _weapon.IsTwoHanded = value; }
        public int Damage { get => _weapon.Damage; set => _weapon.Damage = value; }

        public override void Activate(IPlayerState playerState)
        {
            _weapon.Activate(playerState);
        }
        public override void Deactivate(IPlayerState playerState)
        {
            _weapon.Deactivate(playerState);
        }
        public bool AcceptItemVisitor(ItemVisitor visitor) 
        {
            return _weapon.AcceptItemVisitor(visitor);
        }

        public bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public override IPrintable Text()
        {
            return _weapon.Text();
        }

        public override bool TryAdd(INeutralItem item)
        {
            return _weapon.TryAdd(item);
        }

        public override INeutralItem? TryRemoveAt(int index)
        {
            return _weapon.TryRemoveAt(index);
        }
        public override INeutralItem? TryRemove()
        {
            return _weapon.TryRemove();
        }
        public override object Clone()
        {
            return new WeaponModificator((IWeapon)_weapon.Clone())
            {
                Char = Char,
                Description = Description,
                IsTwoHanded = IsTwoHanded,
                PrintAt = PrintAt,
                Damage = Damage
            };
        }
    }
}
