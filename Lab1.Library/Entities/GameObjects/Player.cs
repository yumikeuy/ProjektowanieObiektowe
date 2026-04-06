using System;
using System.Collections.Generic;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;

namespace Lab1.Library.Entities.GameObjects
{
    public class Player(Point pos, int boardWidth, int boardHeight) : GameObject(pos), IPlayer
    {
        public override char Char { get; set; } = '@';
        public Point Pos { get; set; } = pos;

        public IPlayerState State { get; set; } = new PlayerState(boardWidth, boardHeight);
        public override IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos(Char.ToString(), new(Pos.X + 2, Pos.Y + 1)));
            return p;
        }
        public void Move(Point pos)
        {
            Pos = pos;
        }
    }
}
