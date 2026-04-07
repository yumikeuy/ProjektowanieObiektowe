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
using Lab1.Library.Services.Visitors;

namespace Lab1.Library.Entities.GameObjects
{
    public class Player(Point printAt, Point pos, int boardWidth) : GameObject(printAt), IPlayer
    {
        public override char Char { get; set; } = '@';
        public Point Pos { get; set; } = pos;


        public IPlayerState State { get; set; } = new PlayerState(boardWidth);
        public override IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos(Char.ToString(), new(Pos.X + PrintAt.X, Pos.Y + PrintAt.Y)));
            return p;
        }
        public override bool Accept(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public void TakeDamage(int damage)
        {
            State.Health -= damage;
        }

    }
}
