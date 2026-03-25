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
    public class GameManager : IGameManager
    {
        //private IPrinter _printer;
        //private IBoard _board;
        //private IPlayer _player;

        private IGameState _gameState;

        //private bool stopLoop = false;

        //public GameManager(IPrinter printer, IBoard board, IPlayer player)
        //{
        //    _printer = printer;
        //    _board = board;
        //    _player = player;
        //}
        //public GameManager(IGameState gameState)
        //{
        //    _printer = gameState.Printer;
        //    _board = gameState.Board;   
        //    _player = gameState.Player;
        //}
        public GameManager(IGameState gameState)
        {
            _gameState = gameState;
        }

        public void StartGame()
        {
            //_printer.PrepareConsole();
            //_printer.Add(_board);
            //_printer.Add(_player.State);
            //_printer.Add(_player);
            //StartGameLoop();

            _gameState.Printer.PrepareConsole();
            _gameState.Printer.Add(_gameState);
            _gameState.IsActive = true;
            StartGameLoop();

        }

        private void StartGameLoop()
        {
            var hasChanged = true;
            while (_gameState.IsActive)
            {
                if(hasChanged) _gameState.Printer.Print();
                hasChanged = false;

                if (System.Console.KeyAvailable)
                {
                    var key = System.Console.ReadKey(true).Key;
                    hasChanged = true;
                    _gameState.Instructions.ExecuteAction(_gameState, key);
                    //switch (key)
                    //{
                    //    case ConsoleKey.W:
                    //        TryMoveUp();
                    //        continue;
                    //    case ConsoleKey.A:
                    //        TryMoveLeft();
                    //        continue;
                    //    case ConsoleKey.S:
                    //        TryMoveDown();
                    //        continue;
                    //    case ConsoleKey.D:
                    //        TryMoveRight();
                    //        continue;
                    //    case ConsoleKey.E:
                    //        TryPickUpItem();
                    //        continue;
                    //    case ConsoleKey.L:
                    //        SelectLeftHand();
                    //        continue;
                    //    case ConsoleKey.R:
                    //        SelectRightHand();
                    //        continue;
                    //    case ConsoleKey.Escape:
                    //        StopGame();
                    //        continue;
                    //    case >= ConsoleKey.D1 and <= ConsoleKey.D9:
                    //        TryTakeItemToHand(key - ConsoleKey.D1);
                    //        continue;
                    //    case ConsoleKey.D0:
                    //        TryHideItem();
                    //        continue;
                    //    case ConsoleKey.Q:
                    //        TryDropItem();
                    //        continue;
                    //    default:
                    //        hasChanged = false;
                    //        continue;
                    //}
                }

                Thread.Sleep(16);
            }
        }

        //public void StopGame()
        //{
        //    stopLoop = true;
        //}

        //private void TryMoveUp()
        //{
        //    _board.TryMovePlayer(_player, new(_player.Pos.X, _player.Pos.Y - 1));
        //}
        //private void TryMoveLeft()
        //{
        //    _board.TryMovePlayer(_player, new(_player.Pos.X - 1, _player.Pos.Y));
        //}
        //private void TryMoveDown()
        //{
        //    _board.TryMovePlayer(_player, new(_player.Pos.X, _player.Pos.Y + 1));
        //}
        //private void TryMoveRight()
        //{
        //    _board.TryMovePlayer(_player, new(_player.Pos.X + 1, _player.Pos.Y));
        //}

        //private bool TryPickUpItem()
        //{
        //    return _board.TryPickUp(_player);                
        //}
        //private bool TryDropItem()
        //{
        //    return _board.TryDrop(_player);
        //}
        //private bool TryTakeItemToHand(int i)
        //{
        //    return _player.State.TryTakeItemToHand(i);
        //}
        //private bool TryHideItem()
        //{
        //    return _player.State.TryHideItem();
        //}
        //private void SelectLeftHand()
        //{
        //    _player.State.SelectHand(Hands.Left);
        //}
        //private void SelectRightHand()
        //{
        //    _player.State.SelectHand(Hands.Right);
        //}
    }
}
