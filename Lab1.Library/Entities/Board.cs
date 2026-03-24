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
        public int Width { get; }
        public int Height { get; } 

        private GameObject[,] data;

        public Point PrintAt { get; set; } = new Point(1, 1);
        public Player Player { get; set; }

        public Board(int width, int height, Player player)
        {
            Width = width;
            Height = height;
            data = new GameObject[Width, Height];
            Player = player;
            BoardDefaultInit(player.Pos);
        }
        public void BoardDefaultInit(Point playerStartPos)
        {
            var randomizer = new Random();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (i == playerStartPos.X && j == playerStartPos.Y) continue;
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
        public Printable Text()
        {
            Printable lines = new();
            for (int i = -1; i <= Height; i++)
            {
                var line = new TextPos(new(PrintAt.X, PrintAt.Y + i));
                for(int j = -1; j <= Width; j++)
                {
                    if (i == Player.Pos.Y && j == Player.Pos.X)
                    {
                        lines.AddText(line);
                        line = new(new(j + 3, i + 1));
                        continue;
                    }
                    if (i == -1 || i == Height)
                        line.Text += '-';
                    else if (j == -1 || j == Width)
                        line.Text += "|";
                    else
                        line.Text += data[j, i].Text().ToString();
                }
                lines.AddText(line);
            }

            if (data[Player.Pos.X, Player.Pos.Y].Pickable())
                lines.AddText(new("Press \"E\" to pick up.", new(PrintAt.X, PrintAt.Y + Height + 1)));
            else
                lines.AddText(new("                       ", new(PrintAt.X, PrintAt.Y + Height + 1)));

            return lines;
        }

        public bool TryMovePlayer(Player player, Point pos)
        {
            var currentPos = player.Pos;

            if(!IsNextTo(currentPos, pos) || !IsInside(pos)) return false;
            if (!GetAt(pos).CanBeGoneThrough) return false;
                
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
            return pos.X >= 0 && pos.Y >= 0 && pos.X < Width && pos.Y < Height;
        }
        private bool IsNextTo(Point playerPos, Point pos)
        {
            return ((Math.Abs(playerPos.X - pos.X) <= 1 && playerPos.Y == pos.Y) ||
                    (Math.Abs(playerPos.Y - pos.Y) <= 1 && playerPos.X == pos.X));
        }
    }
}
