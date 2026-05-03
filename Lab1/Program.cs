using Lab1.Console;
using Lab1.Library.Interfaces.GameBuilders.BuildingStrategies;
using Lab1.Library.Services.GameBuilders.BuildingStrategies;
using Lab1.Library.Services.GameBuilders.BuildingThemes;

new DefaultGameInitializer().Initialize("Configuration.json", new BuildingThemeFactory());