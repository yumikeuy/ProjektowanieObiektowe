using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.GameBuilders.BuildingStrategies;

namespace Lab1.Library.Interfaces.GameBuilders.BuildingThemes
{
    public interface IBuildingThemeFactory
    {
        IBuildingTheme SelectBuildingTheme(IGameBuilder gameBuilder, string buildingTheme);
    }
}
