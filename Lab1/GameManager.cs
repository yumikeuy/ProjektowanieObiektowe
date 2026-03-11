using System;
using System.Collections.Generic;
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

        public GameManager(Printer printer)
        {
            _printer = printer;
        }
        public GameManager(Printer printer, Board board)
        {
            _printer = printer;
            Board = board;
        }
        public GameManager(Printer printer, Board board, Player player)
        {
            _printer = printer;
            Board = board;
            Player = player;
            PlayerState = player.State;
        }

        public void PrepareConsole()
        {
            _printer.PrepareConsole();
        }

        public void AddBoard(Board board)
        {
            Board = board;
        }

        public void AddPlayer(Player player)
        {
            Player = player;
            PlayerState = player.State;
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
                            TryGrabItem();
                            continue;
                        case ConsoleKey.L:
                            TryUseLeftItem();
                            continue;
                        case ConsoleKey.R:
                            TryUseRightItem();
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
            throw new NotImplementedException();
        }

        public void TryMoveUp()
        {
            var currentPos = Player.Pos;
            int[] newPos = [currentPos[0], currentPos[1] - 1 ];

            if (IsInside(newPos) && Board.Cell(newPos) is not Wall)
            {
                Player.Pos = newPos;
                if (Board.Cell(newPos) is Item)
                {
                    PlayerState.IsOnItem = true;
                }
            }
        }

        public void TryMoveLeft()
        {
            var currentPos = Player.Pos;
            int[] newPos = [currentPos[0] - 1, currentPos[1]];

            if (IsInside(newPos) && Board.Cell(newPos) is not Wall)
            {
                Player.Pos = newPos;
                if (Board.Cell(newPos) is Item)
                {
                    PlayerState.IsOnItem = true;
                }
            }
        }
        public void TryMoveDown()
        {
            var currentPos = Player.Pos;
            int[] newPos = [currentPos[0], currentPos[1] + 1];

            if (IsInside(newPos) && Board.Cell(newPos) is not Wall)
            {
                Player.Pos = newPos;
                if (Board.Cell(newPos) is Item)
                {
                    PlayerState.IsOnItem = true;
                }
            }
        }
        public void TryMoveRight()
        {
            var currentPos = Player.Pos;
            int[] newPos = [currentPos[0] + 1, currentPos[1]];

            if (IsInside(newPos) && Board.Cell(newPos) is not Wall)
            {
                Player.Pos = newPos;
                if(Board.Cell(newPos) is Item)
                {
                    PlayerState.IsOnItem = true;
                }
            }
        }
        public void TryGrabItem()
        {
            var currentPos = Player.Pos;
            if (PlayerState.IsOnItem)
            {
                if (PlayerState.TryAddToInventory((Item)Board.Cell(currentPos)))
                {
                    Board.SetCell(currentPos, new EmptyGameObject());
                }
                else
                {
                    // Full Inventory
                }
            }
            else
            {
                // No Item
            }
        }
        public void TryUseLeftItem()
        {
            throw new NotImplementedException();
        }
        public void TryUseRightItem()
        {
            throw new NotImplementedException();
        }

        private bool IsInside(int[] pos)
        {
            return pos[0] > 0 && pos[1] > 0 && pos[0] < Board.width + 1 && pos[1] < Board.height + 1;
        }
    }
}
