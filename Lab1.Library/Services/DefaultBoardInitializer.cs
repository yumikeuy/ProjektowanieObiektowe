using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Services
{
    public class DefaultBoardInitializer : IBoardInitializer
    {
        public IBoard InitializeEmpty(int width, int height, IPlayer player)
        {
            var data = new IGameObject[width, height];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    data[i, j] = new EmptyGameObject(new(i, j));

            return new Board(data, player);
        }
        public IBoard InitializeFull(int width, int height, IPlayer player)
        {
            var data = new IGameObject[width, height];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    data[i, j] = new Wall(new(i, j));

            return new Board(data, player);
        }
        public IBoard InitializeWith<T>(int width, int height, IPlayer player) where T : IGameObject, new()
        {
            var data = new IGameObject[width, height];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    data[i, j] = new T();

            return new Board(data, player);
        }
        public IBoard DefaultInitialize(int width, int height, IPlayer player)
        {
            var data = new IGameObject[width, height];
            var randomizer = new Random();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == player.Pos.X && j == player.Pos.Y)
                    {
                        data[j, i] = new EmptyGameObject(new(j, i));
                        continue;
                    }

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

            return new Board(data, player);
        }
    }
}
// TODO
// Board without player
// Printing restrictions
// Board Modificator
// Controllers (how to play)