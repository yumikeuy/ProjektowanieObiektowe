using Lab1.Library.Entities.Printing;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Logging;

namespace Lab1.Console
{
    public class GameManager : IGameManager
    {
        private readonly IGameState _gameState;

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
            Logger.Instance.Log("Started the game.");
            StartGameLoop();
        }

        private void StartGameLoop()
        {
            var hasChanged = true;
            while (_gameState.IsActive)
            {
                _gameState.Destroyer.CleanUp();

                if (hasChanged || _gameState.Printer.CheckForResize()) _gameState.Printer.Print();
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
