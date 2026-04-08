using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects
{
    public abstract class Item : GameObject
    {
        public virtual string Description { get; set; } = string.Empty;
        public virtual bool IsTwoHanded { get; set; } = false;

        public virtual void Activate(IPlayerState playerState) { }
        public virtual void Deactivate(IPlayerState playerState) { }
        public override bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public virtual bool AcceptItemVisitor(ItemVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
