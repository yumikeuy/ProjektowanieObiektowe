using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;
using Lab1.Library.Services.Validators.ItemsValidators;
using Lab1.Library.Services.Visitors;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        private IGameObject[,] _data;

        public Board(IGameObject[,] data)
        {
            _data = data;
            Width = data.GetLength(0);
            Height = data.GetLength(1);
        }

        // IPrtintable
        public Point PrintAt { get; set; } = new Point(1, 1);
        public IPrintable Text()
        {
            Printable lines = new();
            for (int i = -1; i <= Height; i++)
            {
                var line = new TextPos(new(PrintAt.X, PrintAt.Y + i + 1));
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

        // IBoard
        public ICollection<Point> GetEmptyCells()
        {
            var sps = new List<Point>();

            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    if (_data[j, i].Accept(new CanBeGoneThrough())) sps.Add(new(j, i));

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
        }
        public Point GetZero()
        {
            return new(PrintAt.X + 1, PrintAt.Y + 1);
        }
    }
}
