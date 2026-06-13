using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.NeutralItems;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services.Printing;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1.Library.Entities.GameObjects.Items
{
    public class ItemWithTwoHandles : Item
    {
        protected INeutralItem[] _innerItems = new INeutralItem[2];
        protected virtual string _description { get; set; } = string.Empty;
        public override string Description { get => GetSummaryDescription(); set { _description = value; } }

        public override void Activate(IPlayerState playerState)
        {
            base.Activate(playerState);

            foreach (var item in _innerItems)
            {
                item?.Activate(playerState);
            }
        }

        public override void Deactivate(IPlayerState playerState)
        {
            base.Deactivate(playerState);

            foreach (var item in _innerItems)
            {
                item?.Deactivate(playerState);
            }
        }

        public override bool TryAdd(INeutralItem item)
        {
            if (_innerItems[0] == null)
            {
                _innerItems[0] = item;

                if (_isActivated && _playerState != null)
                {
                    item.Activate(_playerState);
                }

                return true;
            }
            if (_innerItems[1] == null)
            {
                _innerItems[1] = item;

                if (_isActivated && _playerState != null)
                {
                    item.Activate(_playerState);
                }

                return true;
            }

            return false;
        }

        public override INeutralItem? TryRemoveAt(int index)
        {
            if (index < 0 || index >= _innerItems.Length)
            {
                return null;
            }

            var item = _innerItems[index];

            if (_isActivated && _playerState != null)
            {
                item?.Deactivate(_playerState);
            }

            return item;
        }
        public override INeutralItem? TryRemove()
        {
            if (_innerItems[0] != null)
            {
                var tmp = TryRemoveAt(0);
                _innerItems[0] = null!;
                return tmp;
            }
            if (_innerItems[1] != null)
            {
                var tmp = TryRemoveAt(1);
                _innerItems[1] = null!;
                return tmp;
            }

            return null;
        }
        public override object Clone()
        {
            var type = this.GetType();

            var cloneObj = Activator.CreateInstance(type) ?? throw new Exception();
            var clone = (ItemWithTwoHandles)cloneObj;

            clone.Char = Char;
            clone.Description = _description;
            clone.IsTwoHanded = IsTwoHanded;
            clone.PrintAt = PrintAt;

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
        protected string GetSummaryDescription()
        {
            var sb = new StringBuilder();

            sb.Append(_description);

            foreach (var item in _innerItems)
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
    }
}
