using System;
using System.Collections.Generic;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameObjects
{
    public class Player(Point pos, int boardWidth) : GameObject(pos), IPlayer
    {
        public override char Char { get; set; } = '@';

        public override string Tag { get; set; } = "Player";
        public IPlayerState State { get; set; } = new PlayerState(new(boardWidth + 5, 1));
        public override Printable Text()
        {
            Printable p = new();
            p.AddText(new(Char.ToString(), new(Pos.X + 2, Pos.Y + 1)));
            return p;
        }
        public void Move(Point pos)
        {
            Pos = pos;
        }
    }
}
