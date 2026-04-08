using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Enemies;
using Lab1.Library.Entities.GameObjects.Items.Neutral;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Heavy;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Light;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Magic;
using Lab1.Library.Entities.GameObjects.Money;

namespace Lab1.Library.Services.Visitors.GameObject
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
        public virtual bool Visit(Weapon weapon) { return false; }
        public virtual bool Visit(HeavyWeapon heavyWeapon) { return false; }
        public virtual bool Visit(LightWeapon lightWeapon) { return false; }
        public virtual bool Visit(MagicWeapon magicWeapon) { return false; }
        public virtual bool Visit(NeutralItem neutralItem) { return false; }
    }
}
