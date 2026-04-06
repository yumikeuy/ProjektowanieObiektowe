using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.GameBuilders;

namespace Lab1.Library.Services.GameBuilders
{
    public class DefaultBoardBuilder : IBoardBuilder
    {
        private IBoard _board = null!;

        private IBoardInitializer _initializer;
        private IBoardModificator _modificator;

        private bool isInitialized = false;

        public DefaultBoardBuilder(IBoardInitializer initializer, IBoardModificator modificator)
        {
            _initializer = initializer;
            _modificator = modificator;
        }

        public IBoardBuilder InitializeEmpty(int width, int height)
        {
            _board = _initializer.InitializeEmpty(width, height);
            _board.IntroductionText = IntroductionTexts.InitializeText;
            isInitialized = true;
            return this;
        }
        public IBoardBuilder InitializeFull(int width, int height)
        {
            _board = _initializer.InitializeFull(width, height);
            _board.IntroductionText = IntroductionTexts.InitializeText;
            isInitialized = true;
            return this;
        }
        public IBoardBuilder DefaultInitialize(int width, int height)
        {
            _board = _initializer.DefaultInitialize(width, height);
            _board.IntroductionText = IntroductionTexts.InitializeText;
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
        public IBoardBuilder AddItems(int amount)
        {
            if (!isInitialized) throw new Exception("Board hasn't been initialized yet.");

            _modificator.AddItems(_board, amount);
            _board.IntroductionText += IntroductionTexts.InitializeText;
            return this;
        }
        public IBoardBuilder AddWeapons(int amount)
        {
            if (!isInitialized) throw new Exception("Board hasn't been initialized yet.");

            _modificator.AddWeapons(_board, amount);
            _board.IntroductionText += IntroductionTexts.WeaponsText;
            return this;
        }
        public IBoardBuilder AddMoney(int amount)
        {
            if (!isInitialized) throw new Exception("Board hasn't been initialized yet.");

            _modificator.AddMoney(_board, amount);
            _board.IntroductionText += IntroductionTexts.MoneyText;
            return this;
        }
        public IBoard GetResult()
        {
            if (!isInitialized) throw new Exception("Board hasn't been built yet.");
            return _board;
        }
    }
}
