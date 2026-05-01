using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Enemies;
using Lab1.Library.Entities.GameObjects.Items;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Money;

namespace Lab1.Library.Services.Visitors.GameObject
{
    public abstract class GameObjectVisitor
    {
        public virtual bool Visit(Player player) { return false; }
        public virtual bool Visit(IEnemy enemy) { return false; }
        public virtual bool Visit(EmptyGameObject emptyGameObject) { return false; }
        public virtual bool Visit(Wall wall) { return false; }
        public virtual bool Visit(IMoney money) { return false; }
        public virtual bool Visit(Coin coin) { return false; }
        public virtual bool Visit(Gold gold) { return false; }
        public virtual bool Visit(IItem item) { return false; }
    }
}
