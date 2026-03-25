using System.Drawing;
using Lab1.Console;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces;
using Lab1.Library.Services;

int boardWidth = 40;
int boardHeight = 20;

//Random rand = new();
//Point pos = new(rand.Next(0, boardWidth), rand.Next(0, boardHeight));

//IPlayer player = new Player(pos, boardWidth);
//IBoard board = new Board(boardWidth, boardHeight, player);
//IPrinter printer = new Printer();
//IGameManager gameManager = new GameManager(printer, board, player);

//gameManager.StartGame();

////

Random rand = new();

Point pos = new(rand.Next(0, boardWidth), rand.Next(0, boardHeight));

IPlayer player = new Player(pos, boardWidth);

var boardBuilder = new DefaultBoardBuilder(new DefaultBoardInitializer(), new DefaulBoardModificator());

boardBuilder.DefaultInitialize(boardWidth, boardHeight, player);
    //.AddCorridors()
    //.AddRooms()
    //.AddItems()

IBoard board_ = boardBuilder.GetResult();

IPrinter printer = new Printer();

IGameManager gameManager_ = new GameManager(printer, board_, player);
gameManager_.StartGame();
