using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Enemies;
using Lab1.Library.Entities.GameObjects.Money;

namespace Lab1.Library.Services.Visitors.GameObject
{
    public class CantBeGoneThrough : GameObjectVisitor
    {
        public override bool Visit(Wall wall) { return true; }
        public override bool Visit(Player player) { return true; }
        public override bool Visit(Enemy enemy) { return true; }
    }
}
