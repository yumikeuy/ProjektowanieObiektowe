using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Entities.GameObjects.Enemies
{
    public abstract class Enemy : GameObject, IDestroyable
    {
        public override char Char { get; set; } = '#';
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }
        public abstract int Armor { get; set; }

        public event Action<IDestroyable>? OnDestroyRequested;
        public bool IsPendingDeletion { get; private set; }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage - Armor;
            if (Health < 0) Die();
        }
        public override bool AcceptGameObjectVisitor(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
        private void Die()
        {
            IsPendingDeletion = true;
            OnDestroyRequested?.Invoke(this);
        }
    }
}
