using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects
{
    public class EmptyGameObject : GameObject
    {
        public override char Char { get; set; } = ' ';
        public override bool IsEmpty { get; set; } = true;
    }
}
