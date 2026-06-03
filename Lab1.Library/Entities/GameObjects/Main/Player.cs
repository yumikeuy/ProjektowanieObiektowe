using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Logging;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Entities.GameObjects.Main
{
    public class Player(Point printAt, Point pos, int boardWidth, string name, IPEndPoint iPEndPoint) : IPlayer
    {
        public string Name { get; set; } = name;
        public IPEndPoint IP { get; set; } = iPEndPoint;
        public char Char { get; set; } = '@';
        public Point Pos { get; set; } = pos;
        public Point PrintAt { get; set; } = printAt;

        public event Action<IDestroyable>? OnDestroyRequested;
        public bool IsPendingDeletion { get; private set; } = false;

        public IPlayerState State { get; set; } = new PlayerState(boardWidth);
        public IPrintable Text()
        {
            Printable p = new();
            if (!IsPendingDeletion)
                p.AddText(new TextPos(Char.ToString(), Pos + PrintAt));
            return p;
        }
        public bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public bool TakeDamage(int damage)
        {
            var actualDamage = damage - State.Armor;
            if (actualDamage < 0) return false;

            State.Health -= actualDamage;
            State.Armor = 0;

            if (State.Health <= 0)
            {
                Die();
                return true;
            }

            return false;
        }

        public void Die()
        {
            IsPendingDeletion = true;
            OnDestroyRequested?.Invoke(this);
            Logger.Instance.Log("Got killed an enemy.");
        }
    }
}
