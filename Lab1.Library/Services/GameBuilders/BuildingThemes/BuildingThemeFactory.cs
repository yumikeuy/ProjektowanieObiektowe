using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.GameBuilders;
using Lab1.Library.Interfaces.GameBuilders.BuildingThemes;
using Lab1.Library.Services.GameBuilders.BuildingStrategies;

namespace Lab1.Library.Services.GameBuilders.BuildingThemes
{
    public class BuildingThemeFactory : IBuildingThemeFactory
    {
        public IBuildingTheme SelectBuildingTheme(IGameBuilder gameBuilder, string buildingTheme)
        {
            return buildingTheme.ToLower() switch
            {
                "nuclear" => new NuclearTheme(),
                //"winter" => new WinterTheme(),
                _ => new NuclearTheme()
            };
        }
    }
}
