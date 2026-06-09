using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;

namespace Lab1.Library.Entities.GameObjects.Items.Neutral
{
    public class EmptyItem(string description) : IItem
    {
        public Point PrintAt { get; set; } = (0, 0);
        public bool IsTwoHanded { get; set; } = false;
        public char Char { get; set; } = ' ';
        public string Description { get; set; } = description;

        public bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public bool AcceptItemVisitor(ItemVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public void Activate(IPlayerState playerState)
        {
        }
        public void Deactivate(IPlayerState playerState)
        {
        }
        public IPrintable Text()
        {
           throw new NotImplementedException();
        }
    }
}
