using Lab1.Console;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects;




Board board = new(out var player);
Printer printer = new();
GameManager gameManager = new(printer, board, player);

gameManager.StartGame();
