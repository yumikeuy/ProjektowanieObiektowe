using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces.Printing;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IHand : ITextConvertible
    {
        public bool TryAdd(Item item);
        public Item? Remove();
        public void ActivateItem(IPlayerState playerState);
        public void DeactivateItem(IPlayerState playerState);
        public Item? GetItem();
    }
}
