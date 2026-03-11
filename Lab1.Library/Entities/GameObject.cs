using Lab1.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public abstract class GameObject(Point pos) : IPrintable
    {
        public abstract char Char { get; set; }
        public Point Pos { get; set; } = pos;
        public abstract string Tag { get; set; }
        public Point PrintAt { get; set; } = pos;
        public virtual void Print() => Console.Write(Char);
    }
}
