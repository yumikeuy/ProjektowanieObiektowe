using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Armor;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Item? CurrentItem { get; set; }

        public bool IsInventoryFull() => Inventory.Count >= inventorySize;

        private int inventorySize = 10; //todo
        public Point PrintAt { get; set; } = new Point(Board.width + 5, 1); // todo

        private bool inventoryChanged = false;

        public void Print() // todo
        {
            System.Console.SetCursorPosition(PrintAt.X, PrintAt.Y);

            WriteLineCustom("Player State:");
            WriteLineCustom("==============================================");

            WriteLineCustom("");
            WriteLineCustom($"Damage\t\t{Damage}");
            WriteLineCustom($"Health\t\t{Health}");
            WriteLineCustom($"Happiness\t\t{Happiness}");
            WriteLineCustom($"Agility\t\t{Agility}");
            WriteLineCustom($"Agressiveness\t{Agressiveness}");
            WriteLineCustom($"Iq\t\t\t{Iq}");
            WriteLineCustom("");

            WriteLineCustom("----------------------------------");

            WriteLineCustom("");
            WriteLineCustom($"Coins\t\t{Coins}");
            WriteLineCustom($"Gold\t\t{Gold}");
            WriteLineCustom("");

            WriteLineCustom("----------------------------------");

            WriteLineCustom("");
            WriteLineCustom($"Left Hand:\t{Hand1?.Description}");
            WriteLineCustom($"Right Hand:\t{Hand2?.Description}");
            WriteLineCustom("");

            WriteLineCustom("----------------------------------");

            WriteLineCustom("");
            WriteLineCustom("Inventory:");
            WriteLineCustom("");

            ClearConsoleAt();
            if (Inventory.Count == 0) WriteLineCustom("Empty.");
            else
            {
                int i = 0;
                foreach (var item in Inventory)
                    WriteLineCustom($"{++i}. {item.Description}");
            }

            WriteLineCustom("");
            WriteLineCustom("----------------------------------");

            if (CurrentItem is not null) WriteLineCustom("Press \"E\" to pick up the item");
            else WriteLineCustom("                                          ");
        }

        public void ClearConsoleAt()
        {
            if (!inventoryChanged) return;

            (int, int) p = System.Console.GetCursorPosition();
            for (int i = 0; i < 15; i++) //todo
            {
                for(int j = 0; j < 100; j++) //todo
                {
                    System.Console.Write(' ');
                }
                System.Console.SetCursorPosition(p.Item1, p.Item2 + i);
            }
            System.Console.SetCursorPosition(p.Item1, p.Item2);
            inventoryChanged = false;
        }

        public void WriteLineCustom(Point pos, string str)
        {
            System.Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(str);
        }

        public void WriteLineCustom(string str)
        {
            var pos = System.Console.GetCursorPosition();
            Console.Write(str);
            System.Console.SetCursorPosition(pos.Left, pos.Top + 1);
        }

        public bool TryAddToInventory()
        {
            if(CurrentItem is not null && !IsInventoryFull())
            {
                Inventory.Add(CurrentItem);
                CurrentItem = null;
                inventoryChanged = true;
                return true;
            }

            return false;
        }

        public void StateDefaultInit()
        {
            Damage = 1;
            Health = 100;
            Happiness = 50;
            Agility = 50;
            Agressiveness = 50;
            Iq = 50;
            Coins = 0;
            Gold = 0;
        }

        public PlayerState()
        {
            StateDefaultInit();
        }
    }
}
