using System;
using System.Collections.Generic;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Entities.GameObjects
{
    public class Player(Point printAt, Point pos, int boardWidth) : GameObject(printAt), IPlayer
    {
        public override char Char { get; set; } = '@';
        public Point Pos { get; set; } = pos;

        public event Action<IDestroyable>? OnDestroyRequested;
        public bool IsPendingDeletion { get; private set; }

        public IPlayerState State { get; set; } = new PlayerState(boardWidth);
        public override IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos(Char.ToString(), new(Pos.X + PrintAt.X, Pos.Y + PrintAt.Y)));
            return p;
        }
        public override bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public void TakeDamage(int damage)
        {
            State.Health -= damage;
            if (State.Health < 0) Die();
        }

        private void Die()
        {
            IsPendingDeletion = true;
            OnDestroyRequested?.Invoke(this);
        }
    }
}
