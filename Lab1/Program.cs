using System.Drawing;
using Lab1.Console;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces;
using Lab1.Library.Services;

int boardWidth = 40;
int boardHeight = 20;
int playerStateWidth = 30;
int itemsAmount = 20;
int weaponsAmount = 10;
int moneyCount = 5;

var gameBuilder = new DefaultGameBuilder(boardWidth, boardHeight, playerStateWidth,
    new DefaultBoardBuilder(new DefaultBoardInitializer(), new DefaulBoardModificator()), new DefaultInstructionsBuilder());

gameBuilder.InitializeFull()
    .AddRooms()
    .AddCorridors()
    .AddCentralRoom()
    .AddItems(itemsAmount)
    .AddWeapons(weaponsAmount)
    .AddMoney(moneyCount);

IGameState gameState = gameBuilder.GetResult();

IGameManager gameManager = new GameManager(gameState);

gameManager.StartGame();

//var boardBuilder = new DefaultBoardBuilder(new DefaultBoardInitializer(), new DefaulBoardModificator());

//boardBuilder.InitializeFull(boardWidth, boardHeight)
//    .AddRooms()
//    .AddCorridors()
//    .AddCentralRoom()
//    .AddItems(itemsAmount)
//    .AddWeapons(weaponsAmount)
//    .AddMoney(moneyCount);

//IBoard board = boardBuilder.GetResult();


//IPlayer player = new Player(board.GetSpawnPoint(), boardWidth, boardHeight);

//IGameManager gameManager = new GameManager(new Printer(), board, player);
//gameManager.StartGame();





