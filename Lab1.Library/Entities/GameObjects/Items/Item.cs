using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items.Neutral;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.NeutralItems;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Entities.GameObjects.Items
{
    public class Item
    {
        protected bool _isActivated = false;
        protected IPlayerState? _playerState = null;

        public virtual Point PrintAt { get; set; } = (0, 0);
        public virtual bool IsTwoHanded { get; set; } = false;
        public virtual char Char { get; set; } = ' ';
        public virtual string Description { get; set; } = string.Empty;

        public virtual void Activate(IPlayerState playerState)
        {
            if(_isActivated) return;
            _playerState = playerState;
            _isActivated = true;
        }
        public virtual void Deactivate(IPlayerState playerState)
        {
            if(!_isActivated) return;
            _playerState = playerState;
            _isActivated = false;
        }
        public virtual IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos(Char.ToString(), PrintAt));
            return p;
        }
        public virtual bool TryAdd(INeutralItem item)
        {
            return false;
        }

        public virtual INeutralItem? TryRemoveAt(int index)
        {
            return null;
        }
        public virtual INeutralItem? TryRemove()
        {
            return null;
        }

        public virtual object Clone()
        {
            var type = this.GetType();
            var cloneObj = Activator.CreateInstance(type) ?? throw new Exception();
            var clone = (Item)cloneObj;

            clone.Char = Char;
            clone.Description = Description;
            clone.IsTwoHanded = IsTwoHanded;
            clone.PrintAt = PrintAt;

            return clone;
        }
    }
}

