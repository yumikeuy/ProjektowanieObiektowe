using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.GameBuilders.BuildingStrategies;

namespace Lab1.Library.Interfaces.GameBuilders.BuildingThemes
{
    public interface IBuildingTheme
    {
        public IBuildingStrategy BuildingStrategy { get; set; }
        public IItem Artefact { get; set; }
        public List<IItem> Items { get; set; }
        public List<IEnemy> Enemies { get; set; }
        public string Message { get; set; }
    }
}
