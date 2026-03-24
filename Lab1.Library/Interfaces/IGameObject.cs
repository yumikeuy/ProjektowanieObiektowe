using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;

namespace Lab1.Library.Interfaces
{
    public interface IGameObject : ITextConvertible, IPickable
    {
        public char Char { get; set; }
        public Point Pos { get; set; }
        public string Tag { get; set; }
        public bool IsEmpty { get; set; }
        public bool CanBeGoneThrough { get; set; }
    }
}
