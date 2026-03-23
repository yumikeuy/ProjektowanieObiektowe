using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces;

namespace Lab1.Console
{
    public class GameManager
    {
        private Printer _printer;
        private Board _board;
        private Player _player;

        private bool stopLoop = false;

        public GameManager(Printer printer, Board board, Player player)
        {
            _printer = printer;
            _board = board;
            _player = player;
        }

        public void StartGame()
        {
            _printer.PrepareConsole();
            _printer.Print(_board);
            _printer.Print(_player.State);

            StartGameLoop();
        }

        private void StartGameLoop()
        {
            while (!stopLoop)
            {
                _printer.Print(_board);
                _printer.Print(_player.State);
                _printer.Print(_player);

                if (System.Console.KeyAvailable)
                {
                    var key = System.Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.W:
                            TryMoveUp();
                            continue;
                        case ConsoleKey.A:
                            TryMoveLeft();
                            continue;
                        case ConsoleKey.S:
                            TryMoveDown();
                            continue;
                        case ConsoleKey.D:
                            TryMoveRight();
                            continue;
                        case ConsoleKey.E:
                            TryPickUpItem();
                            continue;
                        case ConsoleKey.L:
                            SelectLeftHand();
                            continue;
                        case ConsoleKey.R:
                            SelectRightHand();
                            continue;
                        case ConsoleKey.Escape:
                            StopGame();
                            continue;
                        case >= ConsoleKey.D1 and <= ConsoleKey.D9:
                            TryTakeItemToHand(key - ConsoleKey.D1);
                            continue;
                        case ConsoleKey.D0:
                            TryHideItem();
                            continue;
                        case ConsoleKey.Q:
                            TryDropItem();
                            continue;
                        default:
                            continue;
                    }
                }

                Thread.Sleep(16);
            }
        }

        public void StopGame()
        {
            stopLoop = true;
        }

        public void TryMoveUp()
        {
            _board.TryMovePlayer(_player, new(_player.Pos.X, _player.Pos.Y - 1));
        }
        public void TryMoveLeft()
        {
            _board.TryMovePlayer(_player, new(_player.Pos.X - 1, _player.Pos.Y));
        }
        public void TryMoveDown()
        {
            _board.TryMovePlayer(_player, new(_player.Pos.X, _player.Pos.Y + 1));
        }
        public void TryMoveRight()
        {
            _board.TryMovePlayer(_player, new(_player.Pos.X + 1, _player.Pos.Y));
        }

        public bool TryPickUpItem()
        {
            return _board.TryPickUp(_player);                
        }
        public bool TryDropItem()
        {
            return _board.TryDrop(_player);
        }
        public bool TryTakeItemToHand(int i)
        {
            return _player.State.TryTakeItemToHand(i);
        }
        public bool TryHideItem()
        {
            return _player.State.TryHideItem();
        }
        public void SelectLeftHand()
        {
            _player.State.SelectHand(Hands.Left);
        }
        public void SelectRightHand()
        {
            _player.State.SelectHand(Hands.Right);
        }
    }
}
