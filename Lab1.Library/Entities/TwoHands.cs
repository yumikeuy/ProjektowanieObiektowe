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
    public class TwoHands : IHands
    {
        private (IHand left, IHand right) hands;
        private IHand current;
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

        public bool TryAdd(IItem item)
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
        public bool TryAdd(ICollection<IItem> items)
        {
            if(items.Count > 2 || items.Count == 0) 
                return false;

            if (items.Count == 1)
                return TryAdd(items.First());
 
            bool l = hands.left.TryAdd(items.First());
            bool r = hands.right.TryAdd(items.Last());
            if (!l || !r)
            {
                if (l) hands.left.Remove();
                if (r) hands.right.Remove();
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

                IItem? left = hands.left.Remove();
                IItem? right = hands.right.Remove();
                if(left != null) returnItems.Add(left);
                if(right != null) returnItems.Add(right);

                if (TryAdd(item)) return returnItems;
                else throw new Exception("Poorly managed Swaping the two-handed item");
            }
            else
            {
                ICollection<IItem> returnItems = [];
                IItem? removedItem = Remove();
                if(removedItem != null)
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
            foreach(var i in items)
                foreach(var item in AddOrSwap(i))
                    returnItems.Add(item);

            return returnItems;
        }
        public IItem? Remove()
        {
            IItem? removedItem;

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
