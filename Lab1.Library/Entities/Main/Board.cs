using Lab1.Library.Entities.Changes;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Validators.BoardValidators;
using Lab1.Library.Services.Validators.ItemsValidators;
using Lab1.Library.Services.Visitors;
using Lab1.Library.Services.Visitors.GameObject;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.Main
{
    public class Board : IBoard
    {
        public int Width { get; }
        public int Height { get; }
        public string IntroductionText { get; set; } = string.Empty;
        public bool HasChanged { get; set; } = false;
        private BoardChanges boardChanges = new BoardChanges();

        private IGameObject[,] _data;

        public Board(IGameObject[,] data)
        {
            _data = data;
            Width = data.GetLength(0);
            Height = data.GetLength(1);
        }

        public Point PrintAt { get; set; } = new Point(1, 1);
        public IPrintable Text()
        {
            Printable lines = new();
            for (int i = -1; i <= Height; i++)
            {
                var line = new TextPos(PrintAt.DownN(i + 1));
                for (int j = -1; j <= Width; j++)
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

        public ICollection<Point> GetEmptyCells()
        {
            var sps = new List<Point>();

            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    if (!_data[j, i].AcceptGameObjectVisitor(new CantBeGoneThrough())) sps.Add((j, i));

            return sps;
        }
        public Point GetSpawnPoint()
        {
            var sps = GetEmptyCells();
            var randomIndex = Random.Shared.Next(GetEmptyCells().Count);

            return sps.ElementAt(randomIndex);
        }
        public IGameObject GetAt(Point pos)
        {
            return _data[pos.X, pos.Y];
        }
        public void SetAt(Point pos, IGameObject gameObject)
        {
            _data[pos.X, pos.Y] = gameObject;

            boardChanges.Changes.Add(new(pos.X, pos.Y, new(gameObject.Char)));
            HasChanged = true;
        }
        public Point GetZero()
        {
            return PrintAt + (1, 1);
        }

        public bool IsReachable(Point src, Point dst, int radius, out int dist)
        {
            dist = -1; 

            if (src.X == dst.X && src.Y == dst.Y)
            {
                dist = 0;
                return true;
            }

            Queue<(Point Point, int Distance)> queue = new();
            HashSet<Point> visited = new();

            queue.Enqueue((src, 0));
            visited.Add(src);

            while (queue.Count > 0)
            {
                var (current, currentDist) = queue.Dequeue();

                if (currentDist >= radius) continue;

                foreach (var neighbor in current.Neighbors)
                {
                    if (!IsInsideBoardValidator.IsValid(this, neighbor)) continue;

                    if (visited.Contains(neighbor)) continue;

                    if (GetAt(neighbor).AcceptGameObjectVisitor(new CantBeGoneThrough())) continue;

                    int nextDist = currentDist + 1;

                    if (neighbor == dst)
                    {
                        dist = nextDist;
                        return true;
                    }

                    if (Point.LinearDistance(neighbor, dst) <= 1 && nextDist < radius)
                    {
                        dist = nextDist + 1;
                        return true;
                    }

                    visited.Add(neighbor);
                    queue.Enqueue((neighbor, nextDist));
                }
            }

            return false;
        }

        public BoardChanges FlushChanges()
        {
            var changes = boardChanges;

            boardChanges = new BoardChanges();

            HasChanged = false;

            return changes;
        }
    }
}
