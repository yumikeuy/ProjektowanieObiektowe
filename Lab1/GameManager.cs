using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Interfaces;

namespace Lab1.Console
{
    public class GameManager
    {
        //IPrinter
        Printer _printer;
        Board Board { get; set; }
        PlayerState PlayerState { get; set; }
        IPlayer Player { get; set; }

        private bool stopLoop = false;

        public GameManager(Printer printer)
        {
            _printer = printer;
        }
        public GameManager(Printer printer, Board board)
        {
            _printer = printer;
            Board = board;
        }
        public GameManager(Printer printer, Board board, PlayerState playerState)
        {
            _printer = printer;
            Board = board;
            PlayerState = playerState;
        }

        public void PrepareConsole()
        {
            _printer.PrepareConsole();
        }

        public void AddBoard(Board board)
        {
            Board = board;
        }

        public void AddPlayerState(PlayerState playerState)
        {
            PlayerState = playerState;
        }

        public void StartGame()
        {
            _printer.Print(Board);
            _printer.Print(PlayerState);

            StartGameLoop();
        }

        private void StartGameLoop()
        {
            while (!stopLoop)
            {
                if (System.Console.KeyAvailable)
                {
                    var key = System.Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.W:
                            Player.TryMoveUp();
                            continue;
                        case ConsoleKey.A:
                            Player.TryMoveLeft();
                            continue;
                        case ConsoleKey.S:
                            Player.TryMoveDown();
                            continue;
                        case ConsoleKey.D:
                            Player.TryMoveRight();
                            continue;
                        case ConsoleKey.E:
                            Player.TryGrabItem();
                            continue;
                        case ConsoleKey.L:
                            Player.TryUseLeftItem();
                            continue;
                        case ConsoleKey.R:
                            Player.TryUseRightItem();
                            continue;
                        default:
                            continue;
                    }
                }

                Thread.Sleep(16);
            }
        }

        public void OnPressedKey()
        {

        }

        

        public void StopGame()
        {

        }
    }
}
