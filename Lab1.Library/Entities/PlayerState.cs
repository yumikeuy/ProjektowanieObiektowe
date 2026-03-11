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

        private int inventorySize = 5; 
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
            if (Hand1 is null) WriteLineCustom($"Left Hand: \t                                                     ");
            else WriteLineCustom($"Left Hand: \t{Hand1?.Description}");
            if (Hand2 is null) WriteLineCustom($"Right Hand: \t                                                     ");
            else WriteLineCustom($"Right Hand:\t{Hand2?.Description}");
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
            for (int i = 0; i < 10; i++) 
            {
                for(int j = 0; j < 100; j++)
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

        public bool TryAddToInventory(int hand)
        {
            if (Hand(hand) is not null && !IsInventoryFull())
            {
                Inventory.Add(Hand(hand)!);
                if (Hand(hand) is Weapon weapon && weapon.IsTwoHanded)
                    SetHand(1 - hand, null);
                SetHand(hand, null);
                inventoryChanged = true;
                return true;
            }

            return false;
        }

        public bool TryDropItem(Item item)
        {
            throw new NotImplementedException();
        }

        public bool TryDropItem(int hand)
        {
            if(CurrentItem is null)
            {
                CurrentItem = Hand(hand);
                if (Hand(hand) is Weapon weapon && weapon.IsTwoHanded)
                    SetHand(1 - hand, null);
                SetHand(hand, null);
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

        public bool TryTakeItemToHand(int hand, int slot)
        {
            if (Inventory.Count <= slot) return false;

            var item = Inventory[slot];

            inventoryChanged = true;

            if (item is Weapon weapon && weapon.IsTwoHanded)
            {
                if (TryEmptyHands(slot))
                {
                    Hand1 = item;
                    Hand2 = item;

                    return true;
                }

                return false;
            }
            else
            {
                if (Hand(hand) is null)
                    Inventory.RemoveAt(slot);
                else
                    Inventory[slot] = Hand(hand)!;

                if (Hand(hand) is Weapon w && w.IsTwoHanded)
                    SetHand(1 - hand, null);
                SetHand(hand, item);

                return true;
            }

        }

        private bool TryEmptyHands(int slot)
        {
            if (Hand1 is null && Hand2 is null)
                Inventory.RemoveAt(slot);
            else if (Hand1 is not null && Hand2 is null)
                Inventory[slot] = Hand1;
            else if (Hand2 is not null && Hand1 is null)
                Inventory[slot] = Hand2;
            else if (TryAddToInventory(0))
                Inventory[slot] = Hand2!;
            else if (TryDropItem(0))
                Inventory[slot] = Hand2!;
            else return false;

            return true;
        }

        private Item? Hand(int hand)
        {
            if (hand == 0)
                return Hand1;
            if (hand == 1)
                return Hand2;
            return null;
        }

        private void SetHand(int hand, Item? item)
        {
            if (hand == 0)
                Hand1 = item;
            if (hand == 1)
                Hand2 = item;
        }

        public bool TryHideItem(int hand)
        {
            return TryAddToInventory(hand);
        }
    }
}
