using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Enemies;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Interfaces.Entities.GameObjects;

namespace Lab1.Library.Services.Visitors.GameObject
{
    public class IsEnemy : GameObjectVisitor
    {
        public override bool Visit(IEnemy enemy)
        {
            return true;
        }
        public override bool Visit(Player player)
        {
            return true;
        }
    }
}
