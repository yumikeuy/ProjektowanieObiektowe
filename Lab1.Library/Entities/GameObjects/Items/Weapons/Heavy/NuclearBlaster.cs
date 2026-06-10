using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Neutral;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.NeutralItems;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons.HeavyWeapons;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Entities.GameObjects.Items.Weapons.Heavy
{
    public class NuclearBlaster : IHeavyWeapon
    {
        private INeutralItem[] _innerItems = new INeutralItem[2];
        public int Damage { get; set; } = 20;
        public char Char { get; set; } = '=';
        public bool IsTwoHanded { get; set; } = false;
        public string Description { get; set; } = "Nuclear Blaster";
        public Point PrintAt { get; set; } = (0, 0);

        public bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public bool AcceptItemVisitor(ItemVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public void Activate(IPlayerState playerState)
        {
            playerState.Damage += Damage;
        }
        public void Deactivate(IPlayerState playerState)
        {
            playerState.Damage -= Damage;
        }
        public IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos(Char.ToString(), PrintAt));
            return p;
        }

        public bool TryAdd(INeutralItem item)
        {
            if (_innerItems[0] == null)
            {
                _innerItems[0] = item;
                return true;
            }
            if (_innerItems[1] == null)
            {
                _innerItems[1] = item;
                return true;
            }

            return false;
        }

        public INeutralItem? TryRemoveAt(int index)
        {
            if (index < 0 || index >= _innerItems.Length)
            {
                return null;
            }

            return _innerItems[index];
        }
        public INeutralItem? TryRemove()
        {
            if (_innerItems[0] != null)
            {
                var tmp = _innerItems[0];
                _innerItems[0] = null!;
                return tmp;
            }
            if (_innerItems[1] != null)
            {
                var tmp = _innerItems[1];
                _innerItems[1] = null!;
                return tmp;
            }

            return null;
        }

        public object Clone()
        {
            return new NuclearBlaster
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
