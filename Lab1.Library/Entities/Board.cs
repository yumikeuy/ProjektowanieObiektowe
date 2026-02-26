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
        public GameObject[,] Data { get; set; } = new GameObject[width, height];

        public void Print()
        {
            new NotImplementedException();
        }
    }
}
