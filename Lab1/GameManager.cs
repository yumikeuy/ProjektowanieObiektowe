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
        //IPrinter
        Printer _printer;
        Board Board { get; set; }
        PlayerState PlayerState { get; set; }
        Player Player { get; set; }

        private bool stopLoop = false;
        private int currentHand = 0;

        //public GameManager(Printer printer)
        //{
        //    _printer = printer;
        //}
        //public GameManager(Printer printer, Board board)
        //{
        //    _printer = printer;
        //    Board = board;
        //}

        public GameManager(Printer printer, Board board, Player player)
        {
            _printer = printer;
            Board = board;
            Player = player;
            PlayerState = player.State;
        }

        //public void PrepareConsole()
        //{
        //    _printer.PrepareConsole();
        //}

        //public void AddBoard(Board board)
        //{
        //    Board = board;
        //}

        //public void AddPlayer(Player player)
        //{
        //    Player = player;
        //    PlayerState = player.State;
        //}

        public void StartGame()
        {
            _printer.PrepareConsole();
            _printer.Print(Board);
            _printer.Print(PlayerState);

            StartGameLoop();
        }

        private void StartGameLoop()
        {
            while (!stopLoop)
            {
                _printer.Print(Board);
                _printer.Print(PlayerState);

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
                        case ConsoleKey.D1:
                            TryTakeItemToHand(0);
                            continue;
                        case ConsoleKey.D2:
                            TryTakeItemToHand(1);
                            continue;
                        case ConsoleKey.D3:
                            TryTakeItemToHand(2);
                            continue;
                        case ConsoleKey.D4:
                            TryTakeItemToHand(3);
                            continue;
                        case ConsoleKey.D5:
                            TryTakeItemToHand(4);
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

        public bool TryMoveUp()
        {
            return Board.TryMovePlayer(Player, new(Player.Pos.X, Player.Pos.Y - 1));
        }
        public bool TryMoveLeft()
        {
            return Board.TryMovePlayer(Player, new(Player.Pos.X - 1, Player.Pos.Y));
        }
        public bool TryMoveDown()
        {
            return Board.TryMovePlayer(Player, new(Player.Pos.X, Player.Pos.Y + 1));
        }
        public bool TryMoveRight()
        {
            return Board.TryMovePlayer(Player, new(Player.Pos.X + 1, Player.Pos.Y));
        }

        public bool TryPickUpItem()
        {
            return PlayerState.TryAddToInventory();
        }
        public void SelectLeftHand()
        {
            currentHand = 0;
        }
        public void SelectRightHand()
        {
            currentHand = 1;
        }

        public bool TryTakeItemToHand(int d)
        {
            return PlayerState.TryTakeItemToHand(currentHand, d);
        }
    }
}
