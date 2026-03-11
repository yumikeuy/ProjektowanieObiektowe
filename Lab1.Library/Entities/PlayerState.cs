using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Armor;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public class PlayerState : IPrintable
    {
        public List<Item> Inventory { get; set; } = [];
        public Armor? Armor { get; set; }
        public Item? Hand1 { get; set; }
        public Item? Hand2 { get; set; }

        public int Damage { get; set; }
        public int Health { get; set; }
        public int Happiness { get; set; }
        public int Agility { get; set; }
        public int Agressiveness { get; set; }
        public int Iq { get; set; }
        public int Coins { get; set; }
        public int Gold { get; set; }

        public bool IsOnItem { get; set; } = false;

        public bool IsInventoryFull() => Inventory.Count >= inventorySize;

        private int inventorySize = 10; //todo
        public int[] PrintAt { get; set; } = [45, 1]; // todo

        public void Print() // todo
        {
            System.Console.SetCursorPosition(PrintAt[0], PrintAt[1]);

            WriteLineCustom("Player State:");
            WriteLineCustom("==============================================");

            WriteLineCustom("");
            WriteLineCustom($"Damage\t\t{Damage}");
            WriteLineCustom($"Health\t\t{Health}");
            WriteLineCustom($"Happiness\t\t{Happiness}");
            WriteLineCustom($"Agility\t\t{Agility}");
            WriteLineCustom($"Agressiveness\t\t{Agressiveness}");
            WriteLineCustom($"Iq\t\t{Iq}");
            WriteLineCustom("");
            WriteLineCustom($"Coins\t\t{Coins}");
            WriteLineCustom($"Gold\t\t{Gold}");
            WriteLineCustom("");
            WriteLineCustom("Inventory:");
            WriteLineCustom("");

            if (Inventory.Count == 0) WriteLineCustom("Empty.");
            else foreach(var i in Inventory) WriteLineCustom(i.Description);

            WriteLineCustom("");
            WriteLineCustom( $"Left Hand:\t{Hand1?.Description}");
            WriteLineCustom($"Right Hand:\t{Hand2?.Description}");

            WriteLineCustom("");
            WriteLineCustom($"Armor:\t{Armor?.Description}");
            WriteLineCustom("");

            if (IsOnItem) WriteLineCustom("Press \"E\" to pick up the item");
        }

        public void WriteLineCustom(int x, int y, string str)
        {
            System.Console.SetCursorPosition(x, y);
            Console.Write(str);
        }

        public void WriteLineCustom(string str)
        {
            var pos = System.Console.GetCursorPosition();
            Console.Write(str);
            System.Console.SetCursorPosition(pos.Left + 1, pos.Top);
        }

        public bool TryAddToInventory(Item item)
        {
            if(!IsInventoryFull())
            {
                Inventory.Add(item);
                return true;
            }

            return false;
        }
    }
}
