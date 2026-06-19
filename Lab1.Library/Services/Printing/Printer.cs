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

        private int currentBufferWidth = !System.Console.IsOutputRedirected
            ? System.Console.BufferWidth
            : 80; // Fallback default for tests

        private int currentBufferHeight = !System.Console.IsOutputRedirected
            ? System.Console.BufferHeight
            : 25;

        public void Add(ITextConvertible printable)
        {
            _objectsToPrint.Add(printable);
        }

        public void Print()
        {
            System.Console.SetCursorPosition(0, 0);

            var stringData = CreateString(_objectsToPrint);

            if(stringData == null)
            {
                return;
            }

            System.Console.Write(stringData);
        }

        private string? CreateString(ICollection<ITextConvertible> objectsToPrint)
        {
            var consoleHeight = System.Console.BufferHeight;
            var consoleWidth = System.Console.BufferWidth;
            char[] result = new char[consoleWidth * consoleHeight];
            Array.Fill(result, ' ');

            try
            {
                foreach (var printable in objectsToPrint)
                {
                    foreach (var txtPos in printable.Text().GetData())
                    {
                        char[] txt = txtPos.Text.ToCharArray();
                        int ind = txtPos.PrintAt.X + txtPos.PrintAt.Y * consoleWidth;
                        txt.AsSpan().CopyTo(result.AsSpan(ind));
                    }
                }
                return new string(result);
            }
            catch
            {
                return null;
            }



        }

        public void PrintText(string text)
        {
            Console.WriteLine(text);
        }

        public void PrepareConsole()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
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
