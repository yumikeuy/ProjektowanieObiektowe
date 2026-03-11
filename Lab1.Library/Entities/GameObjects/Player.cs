using System;
using System.Collections.Generic;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Entities.GameObjects
{
    public class Player(Point pos) : GameObject(pos), IPlayer
    {
        public override char Char { get; set; } = 'O';

        public override string Tag { get; set; } = "Player";
        public PlayerState State { get; set; } = new();
    }
}
