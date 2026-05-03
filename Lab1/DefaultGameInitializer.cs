using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.GameBuilders.BuildingStrategies;
using Lab1.Library.Interfaces.GameBuilders.BuildingThemes;
using Lab1.Library.Services.GameBuilders;
using Lab1.Library.Services.GameBuilders.BuildingStrategies;
using Lab1.Library.Services.Logging;

namespace Lab1.Console
{
    public class DefaultGameInitializer : IGameInitializer
    {
        public void Initialize(string jsonConfigurationPath, IBuildingThemeFactory buildingThemeFactory)
        {
            var config = JsonSerializer.Deserialize<GameConfiguration>(File.ReadAllText(jsonConfigurationPath)) 
                ?? throw new NullReferenceException("Game configuration is invalid.");


            var gameBuilder = new DefaultGameBuilder(config, 
                new DefaultBoardBuilder(new DefaultBoardInitializer(), new DefaulBoardModificator()), new DefaultInstructionsBuilder());



            var theme = buildingThemeFactory.SelectBuildingTheme(gameBuilder, config.Theme);
            theme.BuildingStrategy.GenerateLayout(config, gameBuilder);
            gameBuilder.AddItems(theme.Items, config.ItemsAmount)
                .AddEnemies(theme.Enemies, config.EnemiesCount)
                .AddArtefact(theme.Artefact);



            Logger.Instance.Initialize(config.LogPath, config.PlayerName, new FileMessageWriter(), new FileLogReader());



            var gameState = gameBuilder.GetResult();
            var gameManager = new GameManager(gameState);

            gameManager.StartGame();
        }
    }
}
