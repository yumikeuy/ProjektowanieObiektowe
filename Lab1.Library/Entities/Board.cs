using Lab1.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public class Board : IPrintable
    {
        public const int width = 40;
        public const int height = 20;
        public int[] PrintAt { get; set; } = [1, 1];
        public GameObject[,] Data { get; set; } = new GameObject[width, height];

        public void Print()
        {
            System.Console.SetCursorPosition(PrintAt[0], PrintAt[1]);
            for (int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    Data[j, i].Print();
                }
                System.Console.SetCursorPosition(PrintAt[0], PrintAt[1] + i + 1);
            }
        }

        public GameObject Cell(int[] pos)
        {
            return Data[pos[0], pos[1]];
        }

        public void SetCell(int[] pos, GameObject gameObject)
        {
            Data[pos[0], pos[1]] = gameObject;
        }
    }
}
