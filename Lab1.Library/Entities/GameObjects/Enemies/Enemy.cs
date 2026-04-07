using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services.Visitors;

namespace Lab1.Library.Entities.GameObjects.Enemies
{
    public abstract class Enemy : GameObject
    {
        public override char Char { get; set; } = '#';
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }
        public abstract int Armor { get; set; }
        public virtual void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }
        public override bool Accept(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
