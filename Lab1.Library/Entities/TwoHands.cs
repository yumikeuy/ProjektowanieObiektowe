using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            hands = (new Hand(Hands.Left), new Hand(Hands.Right));
            current = hands.right;
        }
        private bool isCurrentTwoHanded = false;
        public Point PrintAt { get; set; } = new Point(0, 0);
        public Printable Text()
        {
            hands.left.PrintAt = PrintAt;
            hands.right.PrintAt = new(PrintAt.X, PrintAt.Y + 1);
            return hands.left.Text() + hands.right.Text();
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
                if(TryAdd([item, item]))
                {
                    isCurrentTwoHanded = true;
                    return true;
                }
                return false;
            }
                
            
            return current.TryAdd(item);
        }
        public bool TryAdd(List<Item> items)
        {
            if(items.Count > 2 || items.Count == 0) 
                return false;

            if (items.Count == 1)
                return TryAdd(items[0]);
 
            bool l = hands.left.TryAdd(items[0]);
            bool r = hands.right.TryAdd(items[1]);
            if (!l || !r)
            {
                if (l) hands.left.Remove();
                if (r) hands.right.Remove();
                return false;
            }
            else
                return true;

        }
        public List<Item> AddOrSwap(Item item)
        {
            if (item.IsTwoHanded)
            {
                List<Item> returnItems = [];

                Item? left = hands.left.Remove();
                Item? right = hands.right.Remove();
                if(left != null) returnItems.Add(left);
                if(right != null) returnItems.Add(right);

                if (TryAdd(item)) return returnItems;
                else throw new Exception("Poorly managed Swaping the two-handed item");
            }
            else
            {
                List<Item> returnItems = [];
                Item? removedItem = Remove();
                if(removedItem != null)
                    returnItems.Add(removedItem);

                if (TryAdd(item)) return returnItems;
                else throw new Exception("Poorly managed Swaping the one-handed item");
            }
        }
        public List<Item>? AddOrSwap(List<Item> items)
        {
            if (items.Count > 2 || items.Count == 0) 
                return null;

            if (items.Count == 2 && items[0].IsTwoHanded || items[1].IsTwoHanded)
                return null;

            List<Item> returnItems = [];
            foreach(var i in items)
                returnItems.AddRange(AddOrSwap(i));

            return returnItems;
        }
        public Item? Remove()
        {
            Item? removedItem;

            if (isCurrentTwoHanded)
            {
                hands.right.Remove();
                removedItem = hands.left.Remove();
            }
            else
            {
                removedItem = current.Remove();
            }

            isCurrentTwoHanded = false;
            return removedItem;
        }
    }
}
