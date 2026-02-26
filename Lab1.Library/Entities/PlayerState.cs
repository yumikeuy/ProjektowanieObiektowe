using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Armor;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public class PlayerState
    {
        public Armor[] Armors { get; set; } = [];
        public Weapon[] Weapons { get; set; } = [];
        public Item[] Items { get; set; } = [];

        public int Health { get; set; }
        public int Coins { get; set; }
        public int Gold { get; set; }
    }
}
