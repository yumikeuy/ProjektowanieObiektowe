using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Interfaces.Entities.GameObjects.Items
{
    public interface IItem : IGameObject
    {
        public string Description { get; set; }
        public bool IsTwoHanded { get; set; }

        public void Activate(IPlayerState playerState);
        public void Deactivate(IPlayerState playerState);
        public bool AcceptItemVisitor(ItemVisitor visitor);
    }
}
