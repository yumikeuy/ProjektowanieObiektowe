using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Logging;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Entities.GameObjects.Enemies
{
    public class Robot(Point pos) : IEnemy
    {
        public int Health { get; set; } = 80;
        public int Damage { get; set; } = 4;
        public int Armor { get; set; } = 5;
        public char Char { get; set; } = '%';
        public Point PrintAt { get; set; } = (0, 0);

        public bool IsPendingDeletion { get; set; } = false;

        public Point Pos { get; set; } = pos;

        public event Action<IDestroyable>? OnDestroyRequested;

        public bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
            if (Health < 0) Die();
        }
        private void Die()
        {
            IsPendingDeletion = true;
            OnDestroyRequested?.Invoke(this);
            Logger.Instance.Log("Killed an enemy.");
        }

        public IPrintable Text()
        {
            Printable p = new();
            p.AddText(new TextPos(Char.ToString(), PrintAt));
            return p;
        }
    }
}
