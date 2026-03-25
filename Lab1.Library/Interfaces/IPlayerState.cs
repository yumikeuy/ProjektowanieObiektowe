using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities;

namespace Lab1.Library.Interfaces
{
    public interface IPlayerState : ITextConvertible
    {
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Happiness { get; set; }
        public int Agility { get; set; }
        public int Agressiveness { get; set; }
        public int Iq { get; set; }
        public int Coins { get; set; }
        public int Gold { get; set; }

        public bool IsOnItem { get; set; }

        public bool TryAdd(IItem item);
        public IItem? Drop();
        public void SelectHand(Hands hand);
        public bool TryTakeItemToHand(int i);
        public bool TryHideItem();
    }
}
