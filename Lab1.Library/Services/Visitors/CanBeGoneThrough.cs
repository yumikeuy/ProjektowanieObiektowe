using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Enemies;
using Lab1.Library.Entities.GameObjects.Money;

namespace Lab1.Library.Services.Visitors
{
    public class CanBeGoneThrough : GameObjectVisitor
    {
        public override bool Visit(EmptyGameObject emptyGameObject) { return true; }
        public override bool Visit(Money money) { return true; }
        public override bool Visit(Item item) { return true; }
        public override bool Visit(Coin coin) { return true; }
        public override bool Visit(Gold gold) { return true; }
    }
}
