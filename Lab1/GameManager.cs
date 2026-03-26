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
        private IGameState _gameState;

        public GameManager(IGameState gameState)
        {
            _gameState = gameState;
        }

        public void StartGame()
        {
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
                }

                Thread.Sleep(16);
            }
        }
    }
}
