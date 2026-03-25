using Lab1.Library.Interfaces;
using Lab1.Library.Services;
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
        public abstract char Char { get; set; }
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
