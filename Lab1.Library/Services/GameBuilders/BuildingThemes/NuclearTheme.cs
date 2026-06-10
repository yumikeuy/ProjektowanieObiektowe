using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.GameBuilders.BuildingStrategies;
using Lab1.Library.Interfaces.GameBuilders.BuildingThemes;
using Lab1.Library.Services.GameBuilders.BuildingStrategies;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Heavy;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Light;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Magic;
using Lab1.Library.Entities.GameObjects.Enemies;
using Lab1.Library.Entities.GameObjects.Enemies.Cowardly;
using Lab1.Library.Entities.GameObjects.Enemies.Aggressive;
using Lab1.Library.Entities.GameObjects.Enemies.Ordinary;
using Lab1.Library.Entities.GameObjects.Items.Neutral.Handles;
using Lab1.Library.Entities.GameObjects.Items.Neutral;

namespace Lab1.Library.Services.GameBuilders.BuildingThemes
{
    public class NuclearTheme : IBuildingTheme
    {
        public IBuildingStrategy BuildingStrategy { get; set; } = new DungeonStategy();
        public IItem Artefact { get; set; } = new NuclearBlaster();

        public List<IItem> Items { get; set; } = 
        [
            new Electroshocker(), 
            new MachineGun(), 
            new LaserSword(), 
            new UraniumOre(), 
            new TwoSlotHandle(), 
            new Apple()
        ];

        public List<IEnemy> Enemies { get; set; } = 
        [   
            new Robot(new(0, 0)), 
            new UraniumGolem(new(0, 0)), 
            new RickSanchez(new(0, 0))
        ];

        public string Message { get; set; } = null!;
    }
}
