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
    public class DungeonStategy : IBuildingStrategy
    {
        public void GenerateLayout(IGameConfiguration config, IGameBuilder gameBuilder)
        {
            gameBuilder.InitializeFull()
                .AddCorridors()
                .AddRooms();
        }
    }
}
