using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Interfaces.GameBuilders.BuildingStrategies
{
    public interface IBuildingStrategy
    {
        void GenerateLayout(IGameConfiguration configuration, IGameBuilder gameBuilder);
    }
}
