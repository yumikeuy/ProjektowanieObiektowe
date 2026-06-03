using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services;

namespace Lab1.Library.Entities.Changes
{
    public class LocalPlayerChange
    {
        public bool IsAlive { get; set; } = true;
        public Point Pos { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Luck { get; set; }
        public int Agility { get; set; }
        public int Agressiveness { get; set; }
        public int Iq { get; set; }
        public int Coins { get; set; }
        public int Gold { get; set; }
        public int Armor { get; set; }

    }
}
