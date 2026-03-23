using Lab1.Library.Entities.GameObjects;
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

        private GameObject[,] data = new GameObject[width, height];

        public Point PlayerStartPos { get; set; }
        public Point PrintAt { get; set; } = new Point(1, 1);

        public Board()
        {
            BoardDefaultInit();
        }
        public void BoardDefaultInit()
        {
            var randomizer = new Random();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int r = randomizer.Next(1, 100);
                    switch (r)
                    {
                        case <= 10:
                            data[j, i] = new Wall(new(j, i));
                            break;
                        case <= 11:
                            data[j, i] = new Coin(new(j, i));
                            break;
                        case <= 12:
                            data[j, i] = new Gold(new(j, i));
                            break;
                        case <= 13:
                            data[j, i] = new MachineGun(new(j, i));
                            break;
                        case <= 14:
                            data[j, i] = new ClassicBow(new(j, i));
                            break;
                        default:
                            data[j, i] = new EmptyGameObject(new(j, i));
                            break;
                    }
                }
            }
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
                        data[j, i].Print();
                }
                System.Console.SetCursorPosition(PrintAt.X, PrintAt.Y + i + 1);
            }
        }

        public bool TryMovePlayer(Player player, Point pos)
        {
            var currentPos = player.Pos;

            if(!IsNextTo(currentPos, pos) || !IsInside(pos)) return false;
            if (GetAt(pos) is Wall) return false;
                
            player.Move(pos);
            
            return true; 
        }

        public bool TryPickUp(Player player)
        {
            if (GetAt(player.Pos).Pick(player.State))
            {
                SetAt(player.Pos, new EmptyGameObject(player.Pos));
                return true;
            }

            return false;
        }
        public bool TryDrop(Player player)
        {
            if (GetAt(player.Pos).IsEmpty)
            {
                var item = player.State.Drop();
                if (item != null)
                {
                    SetAt(player.Pos, item);
                    return true;
                }
            }

            return false;
        }

        public GameObject GetAt(Point pos)
        {
            return data[pos.X, pos.Y];
        }
        private void SetAt(Point pos, GameObject gameObject)
        {
            data[pos.X, pos.Y] = gameObject;
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
