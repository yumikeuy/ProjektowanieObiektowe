using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.GameBuilders.BuildingStrategies;
using Lab1.Library.Interfaces.GameBuilders.BuildingThemes;
using Lab1.Library.Services.Connections;
using Lab1.Library.Services.GameBuilders;
using Lab1.Library.Services.GameBuilders.BuildingStrategies;
using Lab1.Library.Services.Logging;

namespace Lab1.Console
{
    public class DefaultGameInitializer(IGameConfiguration config, IBuildingThemeFactory buildingThemeFactory) : IGameInitializer
    {
        public void Initialize(bool isServer, IPEndPoint ipEndPoint)
        {
            if (isServer)
            {
                InitializeServer(ipEndPoint);
            }
            else
            {
                InitializeClient(ipEndPoint);
            }
        }
        private void InitializeServer(IPEndPoint ipEndPoint)
        {
            var gameBuilder = new DefaultGameBuilder(config, 
                new DefaultBoardBuilder(new DefaultBoardInitializer(), new DefaulBoardModificator()), new DefaultInstructionsBuilder());


            var theme = buildingThemeFactory.SelectBuildingTheme(gameBuilder, config.Theme);
            theme.BuildingStrategy.GenerateLayout(config, gameBuilder);
            gameBuilder.AddItems(theme.Items, config.ItemsAmount)
                .AddEnemies(theme.Enemies, config.EnemiesCount)
                .AddArtefact(theme.Artefact);



            Logger.Instance.Initialize(config.LogPath, config.PlayerName, new FileMessageWriter(), new FileLogReader());


            var game = gameBuilder.GetResult();
            var gameManager = new GameManager(game, true);

            var connectionListener = new TCPConnectionListener();
            connectionListener.Start(ipEndPoint, game);

            gameManager.StartGame(null, connectionListener);
        }

        private async void InitializeClient(IPEndPoint ipEndPoint)
        {
            Logger.Instance.Initialize(config.LogPath, config.PlayerName, new FileMessageWriter(), new FileLogReader());

            var connectionHandler = new TCPConnectionHandler();
            var game = await connectionHandler.ConnectAsync(ipEndPoint, config.PlayerName);

            var gameManager = new GameManager(game, false);

            gameManager.StartGame(connectionHandler, null);
        }
    }
}
