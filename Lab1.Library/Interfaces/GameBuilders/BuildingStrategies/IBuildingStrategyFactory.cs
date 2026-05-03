using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.GameBuilders.BuildingStrategies
{
    public interface IBuildingStrategyFactory
    {
        IBuildingStrategy SelectBuildingStrategy(IGameBuilder gameBuilder, string buildingStrategy);
    }
}
