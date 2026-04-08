using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Console
{
    public class GameManager : IGameManager
    {
        private IGameState _gameState;

        public GameManager(IGameState gameState)
        {
            _gameState = gameState;
        }

        public void StartGame()
        {
            _gameState.Printer.PrepareConsole();
            _gameState.Printer.Add(_gameState);
            _gameState.Printer.PrintText(_gameState.Board.IntroductionText);
            System.Console.ReadKey();
            _gameState.Start();
            StartGameLoop();
        }

        private void StartGameLoop()
        {
            var hasChanged = true;
            while (_gameState.IsActive)
            {
                _gameState.Destroyer.CleanUp();

                if(hasChanged || _gameState.Printer.CheckForResize()) _gameState.Printer.Print();
                hasChanged = false;

                if (System.Console.KeyAvailable)
                {
                    var key = System.Console.ReadKey(true).Key;
                    hasChanged = true;
                    _gameState.Instructions.ExecuteAction(_gameState, key);
                }

                if (_gameState.Player.IsPendingDeletion)
                    _gameState.Stop("You died in a battle.");

                Thread.Sleep(16);
            }

            ShowEndScreen();
        }

        private void ShowEndScreen()
        {
            _gameState.Printer.PrepareConsole();
            _gameState.Printer.PrintText(EndScreen.ReasonEndText(_gameState.EndReason));
            System.Console.ReadKey();
        }
    }
}
