using Lab1.Library.Entities.Changes;
using Lab1.Library.Entities.Printing;
using Lab1.Library.Interfaces.Connections;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.Logging;

namespace Lab1.Console
{
    public class GameManager : IGameManager
    {
        private readonly IGame _game;
        private readonly double speedOfEnemies = 20;
        private readonly int refreshRate = 32;
        private readonly bool _isServer;

        public GameManager(IGame game, bool isServer)
        {
            _game = game;
            _isServer = isServer;
        }

        public void StartGame(IConnectionHandler? connectionHandler = null, IConnectionListener? connectionListener = null)
        {
            _game.Printer.PrepareConsole();
            _game.Printer.Add(_game.GameState);
            _game.Printer.PrintText(_game.GameState.Board.IntroductionText);

            if(!_isServer && connectionHandler == null)
            {
                throw new ArgumentNullException("Connection handler is not asingned on a client.");
            }

            System.Console.ReadKey();

            _game.GameState.Start();

            Logger.Instance.Log("Started the game.");

            if (_isServer)
            {
                _ = Task.Run(async () =>
                {
                    await StartGameLoopServerAsync(connectionListener);
                });
            }

            StartGameLoopClient(connectionHandler);
        }

        private async Task StartGameLoopServerAsync(IConnectionListener? connectionListener = null)
        {
            var gs = _game.GameState;
            int enemiesFrameCounter = 0;

            while (gs.IsActive)
            {
             
                gs.MediatorsDirector.Destroyer.CleanUp();


                if (enemiesFrameCounter > speedOfEnemies)
                {
                    gs.EnemyMover.Move(gs.Board);

                    enemiesFrameCounter = 0;
                }

                enemiesFrameCounter++;

                if (gs.HasChanged)
                {
                    var changes = _game.GameState.FlushChanges();

                    var broadcastTasks = new List<Task>();

                    var localPlayer = _game.GameState.PlayerManager.GetLocalPlayer();

                    foreach (var player in _game.GameState.PlayerManager.GetAllPlayers())
                    {
                        if (player == localPlayer) continue;

                        broadcastTasks.Add(connectionListener!.SendChangesToPlayerAsync(player, changes));
                    }

                    if(broadcastTasks.Count > 0)
                    {
                        await Task.WhenAll(broadcastTasks);
                    }
                }


                Thread.Sleep(refreshRate);
            }
        }


        private void StartGameLoopClient(IConnectionHandler? connectionHandler = null)
        {
            var gs = _game.GameState;

            while (gs.IsActive)
            {
                if (gs.HasChanged || _game.Printer.CheckForResize())
                {
                    _game.Printer.Print();
                }

                if (System.Console.KeyAvailable)
                {
                    var key = System.Console.ReadKey(true).Key;

                    if (_isServer)
                    {
                        _game.Instructions.ExecuteAction(_game, key, gs.PlayerManager.GetLocalPlayer()!);
                    }
                    else
                    {
                        connectionHandler!.SendCommandToServerAsync(key);
                    }
                }

                Thread.Sleep(refreshRate);
            }

            ShowEndScreen();
        }


        private void ShowEndScreen()
        {
            _game.Printer.PrepareConsole();

            _game.Printer.PrintText(EndScreen.ReasonEndText(_game.GameState.EndReason));

            System.Console.ReadKey();
        }
    }
}
