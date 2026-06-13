using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Heavy;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Light;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Magic;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Events;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.GameBuilders;
using Lab1.Library.Services.Validators.BoardValidators;
using Lab1.Library.Services.Visitors.GameObject;
using Lab1.Library.Services.WeaponModificators;

namespace Lab1.Library.Services.GameBuilders
{
    public class DefaulBoardModificator: IBoardModificator
    {
        private const int gridWidth = 8;
        private const int gridHeight = 10;

        private const int minCorridors = 20;
        private const int maxCorridors = 25;

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
                    if (board.GetAt((j, y0)).AcceptGameObjectVisitor(new CantBeGoneThrough()))
                        board.SetAt((j, y0), new EmptyGameObject());

            foreach (var x0 in x)
                for (int j = 0; j < board.Height; j++)
                    if (board.GetAt((x0, j)).AcceptGameObjectVisitor(new CantBeGoneThrough()))
                        board.SetAt((x0, j), new EmptyGameObject());

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
            AddRoom(board, new Point(board.Width, board.Height) / 2, centralRoomWidth, centralRoomHeight);

            return this;
        }
        public IBoardModificator AddItems(IBoard board, List<IItem> items, int amount)
        {
            var empty = board.GetEmptyCells();

            if (empty.Count != 0)
                for (int i = 0; i < amount; i++)
                {
                    int ind = Random.Shared.Next(0, items.Count);
                    var item = (IItem)items[ind].Clone();
                    board.SetAt(empty.ElementAt(Random.Shared.Next(empty.Count)), item);
                }
                 
            return this;
        }
        public IBoardModificator AddWeapons(IBoard board, List<IWeapon> weapons, int amount)
        {
            var empty = board.GetEmptyCells();

            if (empty.Count != 0)
                for (int i = 0; i < amount; i++)
                {
                    int j = Random.Shared.Next(1, 100);
                    IWeapon weapon = j switch
                    {
                        < 10 => new HappyModificator(new ClassicBow()),
                        < 20 => new HappyModificator(new MachineGun()),
                        < 30 => new ClassicBow(),
                        < 40 => new MachineGun(),
                        < 50 => new PowerfullModificator(new HappyModificator(new ClassicBow())),
                        < 60 => new PowerfullModificator(new HappyModificator(new MachineGun())),
                        < 70 => new HappyModificator(new PowerfullModificator(new MachineGun())),
                        < 80 => new HappyModificator(new PowerfullModificator(new MachineGun())),
                        < 90 => new HappyModificator(new EnchantedRing()),
                        _ => new MachineGun(),
                    };
                    board.SetAt(empty.ElementAt(Random.Shared.Next(empty.Count)), weapon);
                }
                    
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
        public IBoardModificator AddEnemies(IBoard board, IEnemyMover enemyMover, IMediatorsDirector<INoiseData, IKillData> mediatorsDirector, List<IEnemy> enemies, int amount)
        {
            var empty = board.GetEmptyCells();

            if (empty.Count != 0)
                for (int i = 0; i < amount; i++)
                {
                    var pos = empty.ElementAt(Random.Shared.Next(empty.Count));
                    int ind = Random.Shared.Next(0, enemies.Count);
                    var newEnemy = (IEnemy)enemies[ind].Clone();
                    newEnemy.Pos = newEnemy.PrintAt = pos;

                    enemyMover.Add(newEnemy);

                    mediatorsDirector.NoiseMediator.Subscribe(newEnemy);
                    newEnemy.RegisterInKillMediator(mediatorsDirector);
                    mediatorsDirector.Destroyer.Add(newEnemy);

                    board.SetAt(pos, newEnemy);
                }
                    
            return this;
        }
        public IBoardModificator AddArtefact(IBoard board, IItem artefact)
        {
            var empty = board.GetEmptyCells();

            if (empty.Count != 0)
                board.SetAt(empty.ElementAt(Random.Shared.Next(empty.Count)), artefact);

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
            for (int i = 0; i < amount / 2; i++)
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
        private void AddRoom(IBoard board, Point pos, int roomWidth, int roomHeight)
        {
            roomHeight /= 2;
            roomWidth /= 2;

            for (int i = -roomWidth; i <= roomWidth; i++)
                for (int j = -roomHeight; j <= roomHeight; j++)
                    if (IsInsideBoardValidator.IsValid(board, pos + (i, j)))
                        if (board.GetAt(pos + (i, j)).AcceptGameObjectVisitor(new CantBeGoneThrough()))
                            board.SetAt(pos + (i, j), new EmptyGameObject());
        }
    }
}
