using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Printing;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Interfaces.Events;
using Lab1.Library.Interfaces.Game;
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
        public IBoardBuilder AddItems(List<IItem> items, int amount)
        {
            if (!isInitialized) throw new Exception("Board hasn't been initialized yet.");

            _modificator.AddItems(_board, items, amount);
            _board.IntroductionText += IntroductionTexts.InitializeText;
            return this;
        }
        public IBoardBuilder AddWeapons(List<IWeapon> weapons, int amount)
        {
            if (!isInitialized) throw new Exception("Board hasn't been initialized yet.");

            _modificator.AddWeapons(_board, weapons, amount);
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
        public IBoardBuilder AddEnemies(IEnemyMover enemyMover, IMediatorsDirector<INoiseData, IKillData> mediatorsDirector,  List<IEnemy> enemies, int amount)
        {
            if (!isInitialized) throw new Exception("Board hasn't been initialized yet.");

            _modificator.AddEnemies(_board, enemyMover, mediatorsDirector, enemies, amount);
            _board.IntroductionText += IntroductionTexts.EnemiesText;
            return this;
        }
        public IBoardBuilder AddArtefact(IItem artefact)
        {
            _modificator.AddArtefact(_board, artefact);

            return this;
        }
        public IBoard GetResult()
        {
            if (!isInitialized) throw new Exception("Board hasn't been built yet.");
            return _board;
        }
    }
}
