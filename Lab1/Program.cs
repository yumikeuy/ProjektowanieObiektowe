using Lab1.Console;
using Lab1.Library.Entities;




Board board = new Board();
PlayerState playerState = new PlayerState();
Printer printer = new Printer();
GameManager gameManager = new(printer, board, playerState);

gameManager.StartGame();
