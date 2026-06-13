using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Services.Logging
{
    public class FileLogReader : ILogReader
    {
        private string _path = null!;

        public void SetPath(string path)
        {
            _path = path;
        }

        public string[] GetLogs()
        {
            if (_path == null) throw new NullReferenceException("Logging path for reading is not specified.");
            if (!File.Exists(_path)) throw new FileNotFoundException("Logging path for reading not found.");

            return File.ReadAllLines(_path);
        }
    }
}
