using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.GameBuilders;
using Lab1.Library.Services.Logging;

namespace Lab1.Console
{
    public static class DefaultGameInitializer
    {
        public static void Initialize(string jsonConfigurationPath)
        {
            var config = JsonSerializer.Deserialize<GameConfiguration>(File.ReadAllText(jsonConfigurationPath)) 
                ?? throw new NullReferenceException("Game configuration is invalid.");

            var gameBuilder = new DefaultGameBuilder(config.BoardWidth, config.BoardHeight, config.PlayerStateWidth,
                       new DefaultBoardBuilder(new DefaultBoardInitializer(), new DefaulBoardModificator()), new DefaultInstructionsBuilder());

            InitializeBoard(gameBuilder, config.InitializeOption);
            if (config.AddCentralRoom) gameBuilder.AddCentralRoom();
            if (config.AddCorridors) gameBuilder.AddCorridors();
            if (config.AddRooms) gameBuilder.AddRooms();
            if (config.AddItems) gameBuilder.AddItems(config.ItemsAmount);
            if (config.AddWeapons) gameBuilder.AddWeapons(config.WeaponsAmount);
            if (config.AddMoney) gameBuilder.AddMoney(config.MoneyCount);
            if (config.AddEnemies) gameBuilder.AddEnemies(config.EnemiesCount);

            Logger.Instance.Initialize(new FileMessageWriter(config.LogPath, config.PlayerName));

            var gameState = gameBuilder.GetResult();

            var gameManager = new GameManager(gameState);

            gameManager.StartGame();
        }

        private static void InitializeBoard(DefaultGameBuilder builder, string initOpt)
        {
            switch(initOpt)
            {
                case "Empty":
                    builder.InitializeEmpty();
                    break;
                case "Full":
                    builder.InitializeFull();
                    break;
                default:
                    builder.InitializeFull();
                    break;
            }
        }
    }
}
