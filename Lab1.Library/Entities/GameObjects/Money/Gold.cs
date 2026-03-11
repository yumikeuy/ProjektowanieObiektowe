using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects.Money
{
    public class Gold(Point pos) : Money(pos)
    {
        public override char Char { get; set; } = '$';
        public override string Tag { get; set; } = "Coin";
    }
}
