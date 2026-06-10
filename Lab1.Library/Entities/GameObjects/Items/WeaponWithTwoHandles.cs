using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Light;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.NeutralItems;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons;

namespace Lab1.Library.Entities.GameObjects.Items
{
    public class WeaponWithTwoHandles : ItemWithTwoHandles
    {
        public virtual int Damage { get; set; } = 0;

        public override void Activate(IPlayerState playerState)
        {
            base.Activate(playerState);

            playerState.Damage += Damage;
        }

        public override void Deactivate(IPlayerState playerState)
        {
            base.Deactivate(playerState);

            playerState.Damage -= Damage;
        }

        public override object Clone()
        {
            var type = this.GetType();

            var cloneObj = Activator.CreateInstance(type) ?? throw new Exception();
            var clone = (WeaponWithTwoHandles)cloneObj;

            clone.Char = Char;
            clone.Description = Description;
            clone.IsTwoHanded = IsTwoHanded;
            clone.PrintAt = PrintAt;
            clone.Damage = Damage;

            if (_innerItems[0] != null)
            {
                clone.TryAdd((INeutralItem)_innerItems[0].Clone());
            }
            if (_innerItems[1] != null)
            {
                clone.TryAdd((INeutralItem)_innerItems[1].Clone());
            }
            
            return clone;
        }
    }
}
