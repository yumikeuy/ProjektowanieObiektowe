using System.Net;
using System.Text.Json;
using Lab1.Console;
using Lab1.Library.Interfaces.GameBuilders.BuildingStrategies;
using Lab1.Library.Services.GameBuilders.BuildingStrategies;
using Lab1.Library.Services.GameBuilders.BuildingThemes;


var config = JsonSerializer.Deserialize<GameConfiguration>(File.ReadAllText("Configuration.json"))
                ?? throw new NullReferenceException("Game configuration is invalid.");

var argsManager = new ArgsManager(new(IPAddress.Parse(config.DefaultIp), config.DefaultPort));
(var isServer, var ipep, var nick) = argsManager.HandleArgs(args);

config.PlayerName = nick;
config.DefaultPort = ipep.Port;
config.DefaultIp = ipep.Address.ToString();

var buildingThemeFactory = new BuildingThemeFactory();

var gameInit = new DefaultGameInitializer(config, buildingThemeFactory);


await gameInit.Initialize(isServer, ipep);

