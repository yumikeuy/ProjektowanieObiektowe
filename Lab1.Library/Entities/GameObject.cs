using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public abstract class GameObject : IGameObject
    {
        public virtual char Char { get; set; } = ' ';
        public virtual bool IsEmpty { get; set; } = false;
        public virtual bool CanBeGoneThrough { get; set; } = true;
        public virtual Point PrintAt { get; set; } = new(0, 0);
        public virtual IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos(Char.ToString(), new(PrintAt.X, PrintAt.Y)));
            return p;
        }
        public virtual bool Pick(IPlayerState playerState)
        {
            return false;
        }
        public virtual bool Pickable()
        {
            return false;
        }
        public GameObject() { }
        public GameObject(Point printAt)
        {
            PrintAt = printAt;
        }

    }
}
