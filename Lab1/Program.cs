using System.Drawing;
using Lab1.Console;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects;

int boardWidth = 40;
int boardHeight = 20;
Random rand = new();
Point pos = new(rand.Next(0, boardWidth), rand.Next(0, boardHeight));
Player player = new(pos);

Board board = new(boardWidth, boardHeight, player);
Printer printer = new();
GameManager gameManager = new(printer, board, player);

gameManager.StartGame();
