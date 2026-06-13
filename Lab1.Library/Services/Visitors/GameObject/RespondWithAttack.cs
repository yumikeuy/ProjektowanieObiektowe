using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Enemies;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Enemies;
using Lab1.Library.Services.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1.Library.Services.Visitors.GameObject
{ 
    public class RespondWithAttack(IPlayer player) : GameObjectVisitor
    {
        public override bool Visit(IAggressive enemy)
        {
            player.AcceptGameObjectVisitor(new TakeDamage(enemy.Damage));
            Logger.Instance.Log($"Got attacked by an enemy with {enemy.Damage} damage.");
            return true;
        }
        public override bool Visit(ICowardly enemy)
        {
            player.AcceptGameObjectVisitor(new TakeDamage(enemy.Damage));
            Logger.Instance.Log($"Got attacked by an enemy with {enemy.Damage} damage.");
            return true;
        }
        public override bool Visit(IOrdinary enemy)
        {
            player.AcceptGameObjectVisitor(new TakeDamage(enemy.Damage));
            Logger.Instance.Log($"Got attacked by an enemy with {enemy.Damage} damage.");
            return true;
        }
        public override bool Visit(IEnemy enemy)
        {
            player.AcceptGameObjectVisitor(new TakeDamage(enemy.Damage));
            Logger.Instance.Log($"Got attacked by an enemy with {enemy.Damage} damage.");
            return true;
        }
    }
}
