using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Printing;

namespace Lab1.Library.Interfaces.Game
{
    public interface IGameObject : ITextConvertible, IPickable
    {
        public char Char { get; set; }
        public bool IsEmpty { get; set; }
        public bool CanBeGoneThrough { get; set; }
    }
}
