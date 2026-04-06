using System.Drawing;
using Lab1.Console;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces;
using Lab1.Library.Services;
using Lab1.Library.Services.GameBuilders;

const int boardWidth = 40;
const int boardHeight = 20;
const int playerStateWidth = 45;
const int itemsAmount = 20;
const int weaponsAmount = 10;
const int moneyCount = 5;

var gameBuilder = new DefaultGameBuilder(boardWidth, boardHeight, playerStateWidth,
    new DefaultBoardBuilder(new DefaultBoardInitializer(), new DefaulBoardModificator()), new DefaultInstructionsBuilder());

gameBuilder.InitializeFull()
    .AddRooms()
    .AddCorridors()
    .AddCentralRoom()
    .AddItems(itemsAmount)
    .AddWeapons(weaponsAmount)
    .AddMoney(moneyCount);

var gameState = gameBuilder.GetResult();

var gameManager = new GameManager(gameState);

gameManager.StartGame();






