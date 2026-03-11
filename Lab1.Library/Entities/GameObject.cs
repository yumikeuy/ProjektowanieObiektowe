using Lab1.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public abstract class GameObject(char c = ' ') : IPrintable
    {
        public char Char { get; set; } = c;
        public int[] Pos { get; set; } = [0, 0];
        public string Tag { get; set; } = string.Empty;

        public int[] PrintAt { get; set; } = [0, 0];

        public virtual void Print() => Console.Write(c);
    }
}
