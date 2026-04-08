using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Interfaces.Printing;

namespace Lab1.Library.Services.Printing
{
    public class Printer : IPrinter
    {
        private ICollection<ITextConvertible> _objectsToPrint = [];

        private int currentBufferWidth = System.Console.BufferWidth;
        private int currentBufferHeight = System.Console.BufferHeight;

        public void Add(ITextConvertible printable)
        {
            _objectsToPrint.Add(printable);
        }

        public void Print()
        {
            System.Console.SetCursorPosition(0, 0);
            System.Console.Write(CreateString(_objectsToPrint));
        }

        private string CreateString(ICollection<ITextConvertible> objectsToPrint)
        {
            var consoleHeight = System.Console.BufferHeight;
            var consoleWidth = System.Console.BufferWidth;
            char[] result = new char[consoleWidth * consoleHeight];
            Array.Fill(result, ' ');

            foreach (var printable in objectsToPrint)
            {
                foreach(var txtPos in printable.Text().GetData())
                {
                    char[] txt = txtPos.Text.ToCharArray();
                    int ind = txtPos.PrintAt.X + txtPos.PrintAt.Y * consoleWidth;
                    txt.AsSpan().CopyTo(result.AsSpan(ind));
                }
            }

            return new string(result);
        }

        public void PrintText(string text)
        {
            Console.WriteLine(text);
        }

        public void PrepareConsole()
        {
            Console.CursorVisible = false;
            Console.Clear();
        }

        public bool CheckForResize()
        {
            int newBufferHeight = System.Console.BufferHeight;
            int newBufferWidth = System.Console.BufferWidth;

            if (newBufferHeight != currentBufferHeight || newBufferWidth != currentBufferWidth)
            {
                currentBufferHeight = newBufferHeight;
                currentBufferWidth = newBufferWidth;

                return true;
            }

            return false;
        }
    }
}
