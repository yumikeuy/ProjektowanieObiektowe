using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Interfaces;
using Lab1.Library.Services;
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
    public class Board : IBoard
    {
        public int Width { get; }
        public int Height { get; }

        private IGameObject[,] _data;

        public Point PrintAt { get; set; } = new Point(1, 1);
        
        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            _data = new IGameObject[Width, Height];
        }
        public Board(IGameObject[,] data)
        {
            _data = data;
            Width = data.GetLength(0);
            Height = data.GetLength(1);
        }
        
        public IPrintable Text()
        {
            Printable lines = new();
            for (int i = -1; i <= Height; i++)
            {
                var line = new TextPos(new(PrintAt.X, PrintAt.Y + i));
                for(int j = -1; j <= Width; j++)
                {
                    if (i == -1 || i == Height)
                        line.Text += '-';
                    else if (j == -1 || j == Width)
                        line.Text += "|";
                    else
                        line.Text += _data[j, i].Text().GetText();
                }
                lines.AddText(line);
            }

            return lines;
        }

        public bool TryMovePlayer(IPlayer player, Point pos)
        {
            var currentPos = player.Pos;

            if(!IsNextTo(currentPos, pos) || !IsInside(pos)) return false;
            if (!GetAt(pos).CanBeGoneThrough) return false;
                
            player.Move(pos);

            CheckForPickable(player);

            return true; 
        }

        public bool TryPickUp(IPlayer player)
        {
            if (GetAt(player.Pos).Pick(player.State))
            {
                SetAt(player.Pos, new EmptyGameObject());
                CheckForPickable(player);
                return true;
            }

            return false;
        }
        public bool TryDrop(IPlayer player)
        {
            if (GetAt(player.Pos).IsEmpty)
            {
                var item = player.State.Drop();
                if (item != null)
                {
                    SetAt(player.Pos, item);
                    CheckForPickable(player);
                    return true;
                }
            }

            return false;
        }

        public ICollection<Point> GetSpawnPoints()
        {
            var sps = new List<Point>();

            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    if (_data[j, i].CanBeGoneThrough) sps.Add(new(j, i));

            return sps;
        }
        public Point GetSpawnPoint()
        {
            var sps = GetSpawnPoints();
            var randomIndex = Random.Shared.Next(GetSpawnPoints().Count);

            return sps.ElementAt(randomIndex);
        }

        public IGameObject GetAt(Point pos)
        {
            return _data[pos.X, pos.Y];
        }
        public void SetAt(Point pos, IGameObject gameObject)
        {
            _data[pos.X, pos.Y] = gameObject;
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
        private void CheckForPickable(IPlayer player)
        {
            if (_data[player.Pos.X, player.Pos.Y].Pickable())
                player.State.IsOnItem = true;
            else
                player.State.IsOnItem = false;
        }
    }
}
