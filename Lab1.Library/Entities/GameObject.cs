using Lab1.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public abstract class GameObject(Point pos) : IPrintable, IPickable
    {
        public abstract char Char { get; set; }
        public Point Pos { get; set; } = pos;
        public abstract string Tag { get; set; }
        public virtual Point PrintAt { get; set; } = pos;
        public virtual bool IsEmpty { get; set; } = false;
        public virtual void Print() => Console.Write(Char);
        public virtual bool Pick(PlayerState playerState)
        {
            return false;
        }
    }
}
