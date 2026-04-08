using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Enemies;
using Lab1.Library.Interfaces.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1.Library.Services.Visitors.GameObject
{ 
    public class RespondWithAttack(IPlayer player) : GameObjectVisitor
    {
        public override bool Visit(Enemy enemy)
        {
            player.AcceptGameObjectVisitor(new TakeDamage(enemy.Damage));
            return true;
        }
    }
}
