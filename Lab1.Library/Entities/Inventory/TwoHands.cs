using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;

namespace Lab1.Library.Entities.Inventory
{
    public class TwoHands : IHands
    {
        private IPlayerState _playerState;
        private (IHand left, IHand right) hands;
        private IHand current;

        public Point PrintAt { get; set; } = new Point(0, 0);
        private bool isCurrentTwoHanded = false;

        public TwoHands(IPlayerState playerState)
        {
            _playerState = playerState;
            hands = (new Hand(Hands.Left), new Hand(Hands.Right));
            current = hands.right;
        }

        public IPrintable Text()
        {
            hands.left.PrintAt = PrintAt;
            hands.right.PrintAt = new(PrintAt.X, PrintAt.Y + 1);
            return hands.left.Text().Add(hands.right.Text());
        }

        public void SelectHand(Hands hand)
        {
            switch (hand)
            {
                case Hands.Left:
                    Select(hands.left);
                    break;
                case Hands.Right:
                    Select(hands.right);
                    break;
            }
        }
        public bool TryAdd(IItem item)
        {
            if (item.IsTwoHanded)
            {
                if (TryAdd([item, item]))
                {
                    isCurrentTwoHanded = true;
                    return true;
                }
                return false;
            }


            return Add(current, item);
        }
        public bool TryAdd(ICollection<IItem> items)
        {
            if (items.Count > 2 || items.Count == 0)
                return false;

            if (items.Count == 1)
                return TryAdd(items.First());

            bool l = Add(hands.left, items.First());
            bool r = Add(hands.right, items.Last());
            if (!l || !r)
            {
                if (l) Remove(hands.left);
                if (r) Remove(hands.right);
                return false;
            }
            else
                return true;

        }
        public ICollection<IItem> AddOrSwap(IItem item)
        {
            if (item.IsTwoHanded)
            {
                ICollection<IItem> returnItems = [];

                IItem? left = Remove(hands.left);
                IItem? right = Remove(hands.right);
                if (left != null) returnItems.Add(left);
                if (right != null) returnItems.Add(right);

                if (TryAdd(item)) return returnItems;
                else throw new Exception("Poorly managed Swaping the two-handed item");
            }
            else
            {
                ICollection<IItem> returnItems = [];
                IItem? removedItem = Remove();
                if (removedItem != null)
                    returnItems.Add(removedItem);

                if (TryAdd(item)) return returnItems;
                else throw new Exception("Poorly managed Swaping the one-handed item");
            }
        }
        public ICollection<IItem>? AddOrSwap(ICollection<IItem> items)
        {
            if (items.Count > 2 || items.Count == 0)
                return null;

            if (items.Count == 2 && items.First().IsTwoHanded || items.Last().IsTwoHanded)
                return null;

            ICollection<IItem> returnItems = [];
            foreach (var i in items)
                foreach (var item in AddOrSwap(i))
                    returnItems.Add(item);

            return returnItems;
        }
        public IItem? Remove()
        {
            IItem? removedItem;

            if (isCurrentTwoHanded)
            {
                Remove(hands.right);
                removedItem = Remove(hands.left);
            }
            else
            {
                removedItem = Remove(current);
            }

            isCurrentTwoHanded = false;
            return removedItem;
        }

        private IItem? Remove(IHand hand)
        {
            var item = hand.Remove();
            item?.Deactivate(_playerState);

            return item;
        }
        private bool Add(IHand hand, IItem item)
        {
            if (hand.TryAdd(item))
            {
                hand.ActivateItem(_playerState);
                return true;
            }

            return false;
        }
        private void Select(IHand hand)
        {
            if (current == hand) return;

            current.DeactivateItem(_playerState);
            current = hand;
            current.ActivateItem(_playerState);
        }
    }
}
