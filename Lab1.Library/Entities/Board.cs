using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Armor;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public class Board : IPrintable
    {
        public const int width = 40;
        public const int height = 20;
        public Point PlayerStartPos { get; set; }
        public Point PrintAt { get; set; } = new Point(1, 1);
        public GameObject[,] Data { get; set; } = new GameObject[width, height];

        public Board(out Player player)
        {
            BoardDefaultInit(out player);
        }

        public void Print()
        {
            System.Console.SetCursorPosition(PrintAt.X, PrintAt.Y - 1);
            for (int i = -1; i <= height; i++)
            {
                for(int j = -1; j <= width; j++)
                {
                    if (i == -1 || i == height)
                        System.Console.Write('-');
                    else if(j == -1 || j == width)
                        System.Console.Write('|');
                    else
                        Data[j, i].Print();
                }
                System.Console.SetCursorPosition(PrintAt.X, PrintAt.Y + i + 1);
            }
        }

        public void BoardDefaultInit(out Player player)
        {
            var randomizer = new Random();
            PlayerStartPos = new(randomizer.Next(0, width), randomizer.Next(0, height));
            player = new Player(PlayerStartPos);
            SetCell(PlayerStartPos, player);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int r = randomizer.Next(1, 100);
                    if (PlayerStartPos.X == j && PlayerStartPos.Y == i)
                    {
                        continue;
                    }
                    if(r <= 10)
                    {
                        Data[j, i] = new Wall(new(j, i));
                    }
                    else if(r <= 11)
                    {
                        Data[j, i] = new Coin(new(j, i));
                    }
                    else if(r <= 12)
                    {
                        Data[j, i] = new Gold(new(j, i));
                    }
                    else if (r <= 13)
                    {
                        Data[j, i] = new MachineGun(new(j, i));
                    }
                    else if (r <= 14)
                    {
                        Data[j, i] = new ClassicBow(new(j, i));
                    }
                    else
                    {
                        Data[j, i] = new EmptyGameObject(new(j, i));
                    }
                }
            }
        }

        public bool TryMovePlayer(Player player, Point pos)
        {
            var currentPos = player.Pos;

            if(!IsNextTo(currentPos, pos) || !IsInside(pos)) return false;
            if (Cell(pos) is Wall) return false;
                
            var nextObj = Cell(pos);

            if (player.State.CurrentItem is null)
                SetCell(currentPos, new EmptyGameObject(currentPos));
            else
               SetCell(currentPos, player.State.CurrentItem);

            player.State.CurrentItem = null;

            MovePlayer(player, pos);

            if(nextObj is Coin)
                player.State.Coins++;
            else if (nextObj is Gold)
                player.State.Gold++;
            else if(nextObj is Item newItem) 
                player.State.CurrentItem = newItem;
            
            return true; 
        }

        private void MovePlayer(Player player, Point pos)
        {
            SetCell(pos, player);
            player.Pos = pos;
        }

        public GameObject Cell(Point pos)
        {
            return Data[pos.X, pos.Y];
        }

        public void SetCell(Point pos, GameObject gameObject)
        {
            Data[pos.X, pos.Y] = gameObject;
        }

        private bool IsInside(Point pos)
        {
            return pos.X >= 0 && pos.Y >= 0 && pos.X < width && pos.Y < height;
        }

        private bool IsNextTo(Point playerPos, Point pos)
        {
            return ((Math.Abs(playerPos.X - pos.X) <= 1 && playerPos.Y == pos.Y) ||
                    (Math.Abs(playerPos.Y - pos.Y) <= 1 && playerPos.X == pos.X));
        }
    }
}
