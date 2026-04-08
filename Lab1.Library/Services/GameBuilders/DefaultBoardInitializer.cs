using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Heavy;
using Lab1.Library.Entities.GameObjects.Items.Weapons.Light;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.GameBuilders;

namespace Lab1.Library.Services.GameBuilders
{
    public class DefaultBoardInitializer : IBoardInitializer
    {
        public IBoard InitializeEmpty(int width, int height)
        {
            var data = new IGameObject[width, height];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    data[j, i] = new EmptyGameObject();

            return new Board(data);
        }
        public IBoard InitializeFull(int width, int height)
        {
            var data = new IGameObject[width, height];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    data[j, i] = new Wall();

            return new Board(data);
        }
        public IBoard InitializeWith<T>(int width, int height) where T : IGameObject, new()
        {
            var data = new IGameObject[width, height];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    data[j, i] = new T();

            return new Board(data);
        }
        public IBoard DefaultInitialize(int width, int height)
        {
            var data = new IGameObject[width, height];
            var randomizer = new Random();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int r = randomizer.Next(1, 100);
                    switch (r)
                    {
                        case <= 10:
                            data[j, i] = new Wall();
                            break;
                        case <= 11:
                            data[j, i] = new Coin();
                            break;
                        case <= 12:
                            data[j, i] = new Gold();
                            break;
                        case <= 13:
                            data[j, i] = new MachineGun();
                            break;
                        case <= 14:
                            data[j, i] = new ClassicBow();
                            break;
                        default:
                            data[j, i] = new EmptyGameObject();
                            break;
                    }
                }
            }

            return new Board(data);
        }
    }
}