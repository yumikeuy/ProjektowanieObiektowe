using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces
{
    public interface IPlayer
    {
        public void TryMoveUp();
        public void TryMoveLeft();
        public void TryMoveDown();
        public void TryMoveRight();
        public void TryGrabItem();
        public void TryUseLeftItem();
        public void TryUseRightItem();
    }
}
