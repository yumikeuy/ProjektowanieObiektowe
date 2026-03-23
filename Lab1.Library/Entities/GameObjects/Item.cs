using Lab1.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects
{
    public abstract class Item(Point pos) : GameObject(pos), IItem
    {
        public abstract string Description { get; set; }

        public virtual bool IsTwoHanded { get; set; } = false;

        public override bool Pick(PlayerState playerState)
        {
            return playerState.TryAdd(this);
        }
    }
}
