using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects
{
    public class EmptyGameObject(Point pos) : GameObject(pos)
    {
        public override char Char { get; set; } = ' ';
        public override string Tag { get; set; } = string.Empty;
    }
}
