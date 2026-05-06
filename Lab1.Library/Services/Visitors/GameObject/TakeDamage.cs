using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Enemies;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Enemies;

namespace Lab1.Library.Services.Visitors.GameObject
{
    public class TakeDamage(int damage) : GameObjectVisitor
    {
        public bool HasDied { get; set; } = false;
        public override bool Visit(IEnemy enemy)
        {
            HasDied = enemy.TakeDamage(damage);
            return true;
        }
        public override bool Visit(ICowardly cowardly)
        {
            HasDied = cowardly.TakeDamage(damage);
            return true;
        }
        public override bool Visit(IAggressive aggressive)
        {
            HasDied = aggressive.TakeDamage(damage);
            return true;
        }

        public override bool Visit(Player player)
        {
            HasDied = player.TakeDamage(damage);
            return true;
        }
    }
}
