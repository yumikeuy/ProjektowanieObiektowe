using Lab1.Library.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects
{
    public abstract class Item : GameObject, IItem
    {
        public virtual string Description { get; set; } = string.Empty;
        public virtual bool IsTwoHanded { get; set; } = false;

        public override bool Pick(IPlayerState playerState)
        {
            return playerState.TryAdd(this);
        }
        public override bool Pickable()
        {
            return true;
        }

        public virtual void Activate(IPlayerState playerState) { }
        public virtual void Deactivate(IPlayerState playerState) { }
    }
}
