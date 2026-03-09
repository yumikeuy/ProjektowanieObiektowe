using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameObjects
{
    public class Player() : GameObject('¶'), IPlayer
    {
        public new string Tag = "Player";
        public void TryMoveUp()
        {

        }
        public void TryMoveLeft() { }
        public void TryMoveDown() { }
        public void TryMoveRight() { }
        public void TryGrabItem() { }
        public void TryUseLeftItem() { }
        public void TryUseRightItem() { }
    }
}
