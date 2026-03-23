using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.GameObjects.Money
{
    public class Coin(Point pos) : Money(pos)
    {
        public override char Char { get; set; } = 'c';
        public override string Tag { get; set; } = "Coin";

        public override bool Pick(PlayerState playerState)
        {
            playerState.Coins++;
            return false;
        }
    }
}
