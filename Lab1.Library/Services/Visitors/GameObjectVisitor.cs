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
    public abstract class GameObjectVisitor
    {
        public virtual bool Visit(Player player) { return false; }
        public virtual bool Visit(Enemy enemy) { return false; }
        public virtual bool Visit(EmptyGameObject emptyGameObject) { return false; }
        public virtual bool Visit(Wall wall) { return false; }
        public virtual bool Visit(Money money) { return false; }
        public virtual bool Visit(Item item) { return false; }
        public virtual bool Visit(Coin coin) { return false; }
        public virtual bool Visit(Gold gold) { return false; }
    }
}
