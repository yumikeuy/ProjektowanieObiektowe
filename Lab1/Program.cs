using System.Drawing;
using Lab1.Console;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces;
using Lab1.Library.Services;

int boardWidth = 40;
int boardHeight = 20;

var boardBuilder = new DefaultBoardBuilder(new DefaultBoardInitializer(), new DefaulBoardModificator());

boardBuilder.InitializeFull(boardWidth, boardHeight)
    .AddRooms()
    .AddCorridors();
    //.AddItems()

IBoard board = boardBuilder.GetResult();

IPlayer player = new Player(board.GetSpawnPoint(), boardWidth, boardHeight);

IGameManager gameManager = new GameManager(new Printer(), board, player);
gameManager.StartGame();
