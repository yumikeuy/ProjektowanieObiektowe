using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;

namespace Lab1.Library.Services.Visitors.GameObject
{
    public class PickUpItemAction(IPlayerState playerState) : GameObjectVisitor
    {
        private readonly IPlayerState _playerState = playerState;
        public override bool Visit(IItem item)
        {
            _playerState.TryAdd(item);
            return true;
        }
        public override bool Visit(Coin coin)
        {
            _playerState.Coins++;
            return true;
        }
        public override bool Visit(Gold gold)
        {
            _playerState.Gold++;
            return true;
        }
    }
}
