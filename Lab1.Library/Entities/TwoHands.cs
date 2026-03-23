using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities
{
    public class TwoHands : IPrintable
    {
        private (Hand left, Hand right) hands;
        private Hand current;

        public TwoHands()
        {
            hands = (new Hand(), new Hand());
            current = hands.right;
        }

        public Point PrintAt { get; set; } = new Point(0, 0);

        public void Print()
        {
            hands.left.Print();
            hands.right.Print();
        }

        public void SelectHand(Hands hand)
        {
            switch (hand)
            {
                case Hands.Left:
                    current = hands.left;
                    break;
                case Hands.Right:
                    current = hands.right; 
                    break;
            }
        }

        public bool TryAdd(Item item)
        {
            if (item.IsTwoHanded)
            {
                bool l = hands.left.TryAdd(item);
                bool r = hands.right.TryAdd(item);
                if (!l || !r)
                {
                    if (l) hands.left.Remove();
                    if (r) hands.right.Remove();
                    return false;
                }
                else 
                    return true;
            }
            else 
                return current.TryAdd(item);
        }
        public bool TryAdd(List<Item> items)
        {
            throw new NotImplementedException();
        }
        public List<Item> AddOrSwap(Item item)
        {
            throw new NotImplementedException();
        }
        public List<Item> AddOrSwap(List<Item> items)
        {
            throw new NotImplementedException();
        }
        public Item? Remove()
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem()
        {
            throw new NotImplementedException();
        }
        public bool RemoveItems(Inventory inventory)
        {
            throw new NotImplementedException();
        }
    }
}
