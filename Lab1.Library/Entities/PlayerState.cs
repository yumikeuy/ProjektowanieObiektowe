using Lab1.Library.Entities.GameObjects;
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
        private Inventory _inventory;
        private TwoHands _hands;
        private HandInventoryTransfer _handInvTransfer;

        public int Damage { get; set; }
        public int Health { get; set; }
        public int Happiness { get; set; }
        public int Agility { get; set; }
        public int Agressiveness { get; set; }
        public int Iq { get; set; }
        public int Coins { get; set; }
        public int Gold { get; set; }

        public Point PrintAt { get; set; } = new Point(Board.width + 5, 1);

        public void Print()
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

            _hands.Print();

            WriteLineCustom("----------------------------------");

            ClearConsoleAt();
            _inventory.Print();

            WriteLineCustom("----------------------------------");
        }

        private void ClearConsoleAt()
        {
            if (!_inventory.HasChanged) return;

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
            _inventory.HasChanged = false;
        }
        private void WriteLineCustom(string str)
        {
            var pos = System.Console.GetCursorPosition();
            Console.Write(str);
            System.Console.SetCursorPosition(pos.Left, pos.Top + 1);
        }

        public bool TryAdd(Item item)
        {
            if (_inventory.TryAdd(item))
                return true;
            else if (_hands.TryAdd(item))
                return true;

            return false;
        }
        public Item? Drop() 
        {
            return _hands.Remove();
        }
        public void SelectHand(Hands hand)
        {
            _hands.SelectHand(hand);
        }
        public bool TryTakeItemToHand(int i)
        {
            return _handInvTransfer.TransferFromInventoryToHands(i);
        }
        public bool TryHideItem()
        {
            return _handInvTransfer.TransferFromHandsToInventory();
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
            _inventory = new Inventory();
            _hands = new TwoHands();
            _handInvTransfer = new HandInventoryTransfer(_hands, _inventory);
            StateDefaultInit();
        }
    }
}
