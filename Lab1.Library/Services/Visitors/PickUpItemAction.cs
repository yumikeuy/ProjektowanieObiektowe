using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Services.Visitors
{
    public class PickUpItemAction(IPlayerState playerState) : GameObjectVisitor
    {
        private readonly IPlayerState _playerState = playerState;
        public override bool Visit(Item item)
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
