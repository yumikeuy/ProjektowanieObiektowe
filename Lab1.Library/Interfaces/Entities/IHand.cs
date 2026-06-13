using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Printing;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IHand : ITextConvertible
    {
        public bool TryAdd(IItem item);
        public IItem? Remove();
        public void ActivateItem(IPlayerState playerState);
        public void DeactivateItem(IPlayerState playerState);
        public IItem? GetItem();
    }
}
