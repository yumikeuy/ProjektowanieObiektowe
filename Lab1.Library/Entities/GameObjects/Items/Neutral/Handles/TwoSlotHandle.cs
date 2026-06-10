using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.NeutralItems;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Entities.GameObjects.Items.Neutral.Handles
{
    public class TwoSlotHandle : IHandle
    {
        private INeutralItem[] _innerItems = new INeutralItem[2];
        private IPlayerState? _playerState = null;

        private string _description = "H2";
        public string Description { get => GetSummaryDescription(); set { _description = value; } }
        public bool IsTwoHanded { get; set; } = false;
        public char Char { get; set; } = 'H';
        public Point PrintAt { get; set; } = new(0, 0);

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
            foreach(var item in _innerItems)
            {
                item?.Activate(playerState);
            }
        }

        public void Deactivate(IPlayerState playerState)
        {
            foreach (var item in _innerItems)
            {
                item?.Deactivate(playerState);
            }
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

            var item = _innerItems[index];


            if (_playerState != null)
            {
                item?.Deactivate(_playerState);
            }

            _innerItems[index] = null!;

            return item;
        }
        public INeutralItem? TryRemove()
        {
            if (_innerItems[0] != null)
            {
                var tmp = _innerItems[0];
                _innerItems[0] = null!;
                return tmp;
            }
            if ( _innerItems[1] != null)
            {
                var tmp = _innerItems[1];
                _innerItems[1] = null!;
                return tmp;
            }

            return null;
        }

        private string GetSummaryDescription()
        {
            var sb = new StringBuilder();

            sb.Append(_description);

            foreach(var item in _innerItems)
            {
                sb.Append(" (");
                if (item != null)
                {
                    sb.Append(item.Description);
                }
                else
                {
                    sb.Append("Empty");
                }
                sb.Append(')');
            }

            return sb.ToString();
        }

        public object Clone()
        {
            var clone = new TwoSlotHandle
            {
                Char = Char,
                Description = _description,
                IsTwoHanded = IsTwoHanded,
                PrintAt = PrintAt
            };

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
