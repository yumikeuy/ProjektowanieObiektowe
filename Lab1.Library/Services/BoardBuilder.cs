using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Services
{
    public class BoardBuilder : IBoardBuilder
    {
        private IBoard _board;

        private IBoardInitializer _initializer;
        private IBoardModificator _modificator;

        private bool isInitialized = false;
        private bool isBuilded = false;

        public BoardBuilder(IBoardInitializer initializer, IBoardModificator modificator)
        {
            _initializer = initializer;
            _modificator = modificator;
        }

        public IBoardBuilder InitializeEmpty(int width, int height)
        {
            _board = _initializer.InitializeEmpty(width, height);
            isInitialized = true;
            return this;
        }
        public IBoardBuilder InitializeFull(int width, int height)
        {
            _board = _initializer.InitializeFull(width, height);
            isInitialized = true;
            return this;
        }
        public IBoardBuilder AddCorridors()
        {
            if (!isInitialized) throw new Exception("Board hasn't been initialized yet.");

            _modificator.AddCorridors(_board);
            return this;
        }
        public IBoardBuilder AddRooms()
        {
            if (!isInitialized) throw new Exception("Board hasn't been initialized yet.");

            _modificator.AddRooms(_board);
            return this;
        }
        public IBoardBuilder AddCentralRoom()
        {
            if (!isInitialized) throw new Exception("Board hasn't been initialized yet.");

            _modificator.AddCentralRoom(_board);
            return this;
        }
        public IBoardBuilder AddItems()
        {
            if (!isInitialized) throw new Exception("Board hasn't been initialized yet.");

            _modificator.AddItems(_board);
            return this;
        }
        public IBoardBuilder AddWeapons()
        {
            if (!isInitialized) throw new Exception("Board hasn't been initialized yet.");

            _modificator.AddWeapons(_board);
            return this;
        }
        public void Build()
        {
            if (!isInitialized) throw new Exception("Board hasn't been initialized yet.");

            isBuilded = true;
        }
        public IBoard GetResult()
        {
            if (!isBuilded) throw new Exception("Board hasn't been built yet.");
            return _board;
        }
    }
}
