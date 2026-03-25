using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Neutral;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Services
{
    public class DefaulBoardModificator : IBoardModificator
    {
        private const int gridWidth = 8;
        private const int gridHeight = 10;

        private const int minCorridors = 20;
        private const int maxCorridors = 25;
        private const int minCorridorLenght = 10;
        private const int maxCorridorLendth = 18;
        private const int straightCorridorBooster = 20;

        private const int minRooms = 1;
        private const int maxRooms = 2;
        private const int minRoomHeigth = 2;
        private const int maxRoomHeigth = 4;
        private const int minRoomWidth = 2;
        private const int maxRoomWidth = 6;

        private const int centralRoomWidth = 6;
        private const int centralRoomHeight = 3;
        public IBoardModificator AddCorridors(IBoard board)
        {
            var corridorsNumber = Random.Shared.Next(minCorridors, maxCorridors);
            (int[] x, int[] y) = GetRandomPoints(board, corridorsNumber);

            foreach (var y0 in y)
                for (int j = 0; j < board.Width; j++)
                    if (!board.GetAt(new(j, y0)).CanBeGoneThrough)
                        board.SetAt(new(j, y0), new EmptyGameObject());

            foreach (var x0 in x)
                for (int j = 0; j < board.Height; j++)
                    if (!board.GetAt(new(x0, j)).CanBeGoneThrough)
                        board.SetAt(new(x0, j), new EmptyGameObject());

            return this;
        }
        public IBoardModificator AddRooms(IBoard board)
        {
            int gridRectNum = board.Width / gridWidth * board.Height / gridHeight;
            var roomsNumber = Random.Shared.Next(gridRectNum * minRooms, gridRectNum * maxRooms);
            for (int i = 0; i < roomsNumber; i++)
            {
                var pos = GetRandomPoint(board, i);
                var roomHeight = Random.Shared.Next(minRoomHeigth, maxRoomHeigth);
                var roomWidth = Random.Shared.Next(minRoomWidth, maxRoomWidth);
                AddRoom(board, pos, roomWidth, roomHeight);
            }

            return this;
        }
        public IBoardModificator AddCentralRoom(IBoard board)
        {
            AddRoom(board, new(board.Width / 2, board.Height / 2), centralRoomWidth, centralRoomHeight);

            return this;    
        }
        public IBoardModificator AddItems(IBoard board, int amount)
        {
            var empty = board.GetEmptyCells();

            if (empty.Count != 0)
                for (int i = 0; i < amount; i++)
                    board.SetAt(empty.ElementAt(Random.Shared.Next(empty.Count)), new Apple());

            return this;
        }
        public IBoardModificator AddWeapons(IBoard board, int amount)
        {
            var empty = board.GetEmptyCells();

            if (empty.Count != 0)
                for (int i = 0; i < amount; i++)
                    board.SetAt(empty.ElementAt(Random.Shared.Next(empty.Count)), new ClassicBow());

            return this;
        }
        public IBoardModificator AddMoney(IBoard board, int amount)
        {
            var empty = board.GetEmptyCells();

            if (empty.Count != 0)
                for (int i = 0; i < amount; i++)
                    board.SetAt(empty.ElementAt(Random.Shared.Next(empty.Count)), new Gold());

            return this;
        }

        private Point GetRandomPoint(IBoard board, int grid)
        {
            var x = (Random.Shared.Next(gridWidth) + gridWidth * grid % board.Width) % board.Width;
            var y = (Random.Shared.Next(gridHeight) + gridHeight * gridWidth * grid / board.Width) % board.Height;
            return new(x, y);
        }
        private (int[], int[]) GetRandomPoints(IBoard board, int amount)
        {
            (HashSet<int> x, HashSet<int> y) = (new HashSet<int>(), new HashSet<int>());
            for(int i = 0; i < amount / 2; i++)
            {
                var x0 = Random.Shared.Next(board.Width);
                if (!x.Contains(x0 - 1) && !x.Contains(x0 + 1))
                    x.Add(x0);

                var y0 = Random.Shared.Next(board.Height);
                if (!y.Contains(y0 - 1) && !y.Contains(y0 + 1))
                    y.Add(y0);

            }
            return (x.ToArray(), y.ToArray());
        }
        private Point GetNextPoint(IBoard board, Point pos, ref Point prevPos)
        {
            List<Point> nearPoints = [];
            List<Point> nonEmptyPoints = [];
            List<Point> notNearEmptyPoints = [];

            CheckAndAddPoint(board, new(pos.X, pos.Y + 1), prevPos, nearPoints, nonEmptyPoints, notNearEmptyPoints);
            CheckAndAddPoint(board, new(pos.X, pos.Y - 1), prevPos, nearPoints, nonEmptyPoints, notNearEmptyPoints);
            CheckAndAddPoint(board, new(pos.X + 1, pos.Y), prevPos, nearPoints, nonEmptyPoints, notNearEmptyPoints);
            CheckAndAddPoint(board, new(pos.X - 1, pos.Y), prevPos, nearPoints, nonEmptyPoints, notNearEmptyPoints);

            prevPos = pos;

            if (notNearEmptyPoints.Count != 0)
                return notNearEmptyPoints[Random.Shared.Next(notNearEmptyPoints.Count)];

            if (nonEmptyPoints.Count != 0)
                return nonEmptyPoints[Random.Shared.Next(nonEmptyPoints.Count)];
            
            return nearPoints[Random.Shared.Next(nearPoints.Count)];
        }

        private bool IsInside(IBoard board, Point pos)
        {
            return pos.X >= 0 && pos.Y >= 0 && pos.X < board.Width && pos.Y < board.Height;
        }

        private void CheckAndAddPoint(IBoard board, Point pos, Point prevPos, 
            ICollection<Point> nearPoints, ICollection<Point> nonEmptyPoints, ICollection<Point> notNearEmptyPoints)
        {
            
            if (IsInside(board, pos) && pos != prevPos)
            {
                AddWithStraightBooster(pos, prevPos, nearPoints);

                if (!board.GetAt(pos).CanBeGoneThrough)
                {
                    AddWithStraightBooster(pos, prevPos, nonEmptyPoints);

                    if (!NearEmpty(board, pos))
                    {
                        AddWithStraightBooster(pos, prevPos, notNearEmptyPoints);
                    }
                }
            }
        }

        private void AddWithStraightBooster(Point pos, Point prevPos, ICollection<Point> points)
        {
            if (Math.Abs(prevPos.X - pos.X) == 2 || Math.Abs(prevPos.Y - pos.Y) == 2)
                for (int i = 0; i < straightCorridorBooster; i++)
                    points.Add(pos);
            points.Add(pos);
        }

        private bool NearEmpty(IBoard board, Point pos)
        {
            int countEmpty = 0;

            if (IsInside(board, new(pos.X, pos.Y + 1)) && board.GetAt(new(pos.X, pos.Y + 1)).CanBeGoneThrough) countEmpty++;
            if (IsInside(board, new(pos.X, pos.Y - 1)) && board.GetAt(new(pos.X, pos.Y - 1)).CanBeGoneThrough) countEmpty++;
            if (IsInside(board, new(pos.X + 1, pos.Y)) && board.GetAt(new(pos.X + 1, pos.Y)).CanBeGoneThrough) countEmpty++;
            if (IsInside(board, new(pos.X - 1, pos.Y)) && board.GetAt(new(pos.X - 1, pos.Y)).CanBeGoneThrough) countEmpty++;

            return countEmpty > 1;
        }

        private void AddRoom(IBoard board, Point pos, int roomWidth, int roomHeight)
        {
            roomHeight /= 2;
            roomWidth /= 2;

            for(int i = -roomWidth; i <= roomWidth; i++)
                for(int j = -roomHeight; j <= roomHeight; j++)
                    if(IsInside(board, new(pos.X + i, pos.Y + j)))
                        if(!board.GetAt(new(pos.X + i, pos.Y + j)).CanBeGoneThrough)
                            board.SetAt(new(pos.X + i, pos.Y + j), new EmptyGameObject());
        }
    }
}
