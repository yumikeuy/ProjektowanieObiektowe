using System.Drawing;
using Lab1.Console;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces;
using Lab1.Library.Services;

int boardWidth = 40;
int boardHeight = 20;
int itemsAmount = 20;
int weaponsAmount = 10;
int moneyCount = 5;

var boardBuilder = new DefaultBoardBuilder(new DefaultBoardInitializer(), new DefaulBoardModificator());

boardBuilder.InitializeFull(boardWidth, boardHeight)
    .AddRooms()
    .AddCorridors()
    .AddCentralRoom()
    .AddItems(itemsAmount)
    .AddWeapons(weaponsAmount)
    .AddMoney(moneyCount);

IBoard board = boardBuilder.GetResult();

IPlayer player = new Player(board.GetSpawnPoint(), boardWidth, boardHeight);

IGameManager gameManager = new GameManager(new Printer(), board, player);
gameManager.StartGame();
