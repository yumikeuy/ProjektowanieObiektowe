using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.Inventory;
using Lab1.Library.Entities.Printing;
using Lab1.Library.Interfaces;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.Main
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
        private readonly int separatorLength = 40;

        public char Orientation { get; set; } = 'S';

        public IPrintable Text()
        {
            currentPrintPos = PrintAt;
            Printable p = new();

            AddLine(p, "Player State:");
            AddLine(p, new string('=', separatorLength));

            AddLine(p, "");
            AddLine(p, $"Damage           {Damage}");
            AddLine(p, $"Health           {Health}");
            AddLine(p, $"Happiness        {Happiness}");
            AddLine(p, $"Agility          {Agility}");
            AddLine(p, $"Agressiveness    {Agressiveness}");
            AddLine(p, $"Iq               {Iq}");
            AddLine(p, "");
            AddLine(p, new string('-', separatorLength));
            AddLine(p, "");
            AddLine(p, $"Coins            {Coins}");
            AddLine(p, $"Gold             {Gold}");
            AddLine(p, "");
            AddLine(p, new string('-', separatorLength));

            _hands.PrintAt = currentPrintPos;
            p.Add(_hands.Text());
            currentPrintPos = p.LastPosition;
            currentPrintPos.Y++;

            AddLine(p, new string('-', separatorLength));

            _inventory.PrintAt = currentPrintPos;
            p.Add(_inventory.Text());
            currentPrintPos = p.LastPosition;
            currentPrintPos.Y++;

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
            Damage = 0;
            Health = 100;
            Happiness = 50;
            Agility = 50;
            Agressiveness = 50;
            Iq = 50;
            Coins = 0;
            Gold = 0;
        }
        public PlayerState(int boardWidth)
        {
            PrintAt = new(boardWidth + 5, 1);
            _inventory = new Inventory.Inventory();
            _hands = new TwoHands(this);
            _handInvTransfer = new HandInventoryTransfer(_hands, _inventory);
            StateDefaultInit();
        }
    }
}
