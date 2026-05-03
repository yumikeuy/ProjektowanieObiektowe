using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.GameBuilders;
using Lab1.Library.Interfaces.GameBuilders.BuildingStrategies;

namespace Lab1.Library.Services.GameBuilders.BuildingStrategies
{
    public class BuildingStrategyFactory : IBuildingStrategyFactory
    {
        public IBuildingStrategy SelectBuildingStrategy(IGameBuilder gameBuilder, string strategy)
        {
            return strategy.ToLower() switch
            {
                "dungeon" => new DungeonStategy(),
                "forest" => new ForestStrategy(),
                "valley" => new ValleyStrategy(),
                _ => new DungeonStategy()
            };
        }
    }
}
