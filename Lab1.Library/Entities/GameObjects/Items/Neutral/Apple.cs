using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.Visitors.ItemVisitors;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1.Library.Entities.GameObjects.Items.Neutral
{
    public class Apple : INeutralItem
    {
        public Point PrintAt { get; set; } = (0, 0);
        public bool IsTwoHanded { get; set; } = false;
        public char Char { get; set; } = 'o';
        public string Description { get; set; } = "Juicy Red Apple";

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
        }
        public void Deactivate(IPlayerState playerState)
        {
        }
        public IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos(Char.ToString(), PrintAt));
            return p;
        }
    }
}
