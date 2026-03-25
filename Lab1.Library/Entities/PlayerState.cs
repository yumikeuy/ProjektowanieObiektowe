using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces;
using Lab1.Library.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public class PlayerState : IPlayerState
    {
        private IInventory _inventory;
        private IHands _hands;
        private IHandInventoryTransfer _handInvTransfer;

        public int Damage { get; set; }
        public int Health { get; set; }
        public int Happiness { get; set; }
        public int Agility { get; set; }
        public int Agressiveness { get; set; }
        public int Iq { get; set; }
        public int Coins { get; set; }
        public int Gold { get; set; }

        public Point PrintAt { get; set; }
        private Point currentPrintPos;
        private Point pressELinePrintAt;

        public bool IsOnItem { get; set; } = false;

        public IPrintable Text()
        {
            currentPrintPos = PrintAt;
            Printable p = new();
            
            AddLine(p, "Player State:");
            AddLine(p, "==========================");

            AddLine(p, "");
            AddLine(p, $"Damage\t\t{Damage}");
            AddLine(p, $"Health\t\t{Health}");
            AddLine(p, $"Happiness\t\t{Happiness}");
            AddLine(p, $"Agility\t\t{Agility}");
            AddLine(p, $"Agressiveness\t{Agressiveness}");
            AddLine(p, $"Iq\t\t\t{Iq}");
            AddLine(p, "");
            AddLine(p, "--------------------------");
            AddLine(p, "");
            AddLine(p, $"Coins\t\t{Coins}");
            AddLine(p, $"Gold\t\t{Gold}");
            AddLine(p, "");
            AddLine(p, "--------------------------");

            _hands.PrintAt = currentPrintPos;
            p.Add(_hands.Text());
            currentPrintPos = p.LastPosition;
            currentPrintPos.Y++;

            AddLine(p, "--------------------------");

            _inventory.PrintAt = currentPrintPos;
            p.Add(_inventory.Text());
            currentPrintPos = p.LastPosition;
            currentPrintPos.Y++;

            if (IsOnItem)
                p.Add(new PressELine(pressELinePrintAt).Text());
            else
                p.Add(new EmptyLine(pressELinePrintAt, 25).Text());

            return p;
        }
        private void AddLine(IPrintable p, string str)
        {
            p.AddText(new TextPos(str, new(currentPrintPos.X, currentPrintPos.Y++)));
        } 

        public bool TryAdd(IItem item)
        {
            if (_inventory.TryAdd(item))
                return true;
            else if (_hands.TryAdd(item))
                return true;

            return false;
        }
        public IItem? Drop() 
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
        public PlayerState(int boardWidth, int boardHeight)
        {
            PrintAt = new(boardWidth + 5, 1);
            pressELinePrintAt = new(1, boardHeight + 2);
            _inventory = new Inventory();
            _hands = new TwoHands();
            _handInvTransfer = new HandInventoryTransfer(_hands, _inventory);
            StateDefaultInit();
        }
    }
}
