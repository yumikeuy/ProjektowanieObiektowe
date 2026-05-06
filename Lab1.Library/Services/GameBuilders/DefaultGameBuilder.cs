using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;

using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Interfaces.GameBuilders;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Entities.Game;
using Lab1.Library.Services.Printing;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Entities.Main;
using Lab1.Library.Services.Logging;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Services.EventsMediators;
using Lab1.Library.Services.EventsMediators.Noise;
using Lab1.Library.Services.EventsMediators.Killing;
using Lab1.Library.Interfaces.Events;


namespace Lab1.Library.Services.GameBuilders
{
    public class DefaultGameBuilder : IGameBuilder
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Point printAt;

        private readonly IBoardBuilder _boardBuilder;
        private readonly IInstructionsBuilder _instructionsBuilder;

        private IGameState _gameState = new GameState();
        private IGameConfiguration _gameConfiguration;
        public DefaultGameBuilder(IGameConfiguration gameConfiguration,
        IBoardBuilder boardBuilder, IInstructionsBuilder instructionsBuilder)
        {
            _gameConfiguration = gameConfiguration;
            _width = _gameConfiguration.BoardWidth;
            _height = _gameConfiguration.BoardHeight;
            printAt = new(_width + 10 + _gameConfiguration.PlayerStateWidth + 5, 1);
            _boardBuilder = boardBuilder;
            _instructionsBuilder = instructionsBuilder;
            _gameState.LogScreen = new LogScreen(_height);
            _gameState.MediatorsDirector = new MediatorsDirector(new Destroyer(), new Mediator<INoiseData>(), new Mediator<IKillData>());
            _gameState.EnemyMover = new EnemyMover();
        }

        // IGameBuilder
        public IGameBuilder InitializeEmpty()
        {
            _boardBuilder.InitializeEmpty(_width, _height);
            _instructionsBuilder.Initialize(printAt);

            return this;
        }
        public IGameBuilder InitializeFull()
        {
            _boardBuilder.InitializeFull(_width, _height);
            _instructionsBuilder.Initialize(printAt);

            return this;
        }
        public IGameBuilder AddCorridors()
        {
            _boardBuilder.AddCorridors();

            return this;
        }
        public IGameBuilder AddRooms()
        {
            _boardBuilder.AddRooms();

            return this;
        }
        public IGameBuilder AddCentralRoom()
        {
            _boardBuilder.AddCentralRoom();

            return this;
        }
        public IGameBuilder AddItems(List<IItem> items, int amount)
        {
            _boardBuilder.AddItems(items, amount);
            _instructionsBuilder.AddItems();

            return this;
        }
        public IGameBuilder AddWeapons(List<IWeapon> weapons, int amount)
        {
            _boardBuilder.AddWeapons(weapons, amount);
            _instructionsBuilder.AddItems();

            return this;
        }
        public IGameBuilder AddMoney(int amount)
        {
            _boardBuilder.AddMoney(amount);
            _instructionsBuilder.AddItems();

            return this;
        }

        public IGameBuilder AddEnemies(List<IEnemy> enemies, int amount)
        {
            _boardBuilder.AddEnemies(_gameState.EnemyMover, _gameState.MediatorsDirector, enemies, amount);
            _instructionsBuilder.AddEnemies();

            return this;
        }

        public IGameBuilder AddArtefact(IItem artefact)
        {
            _boardBuilder.AddArtefact(artefact);
            _instructionsBuilder.AddItems();

            return this;
        }

        public IGameState GetResult()
        {
            _gameState.Printer = new Printer();
            _gameState.Board = _boardBuilder.GetResult();
            _gameState.Instructions = _instructionsBuilder.GetResult();
            _gameState.MediatorsDirector.Destroyer.AddBoard(_gameState.Board);
            _gameState.Player = new Player(_gameState.Board.GetZero(), _gameState.Board.GetSpawnPoint(), _width);
            _gameState.MediatorsDirector.Destroyer.Add(_gameState.Player);
            return _gameState;
        }
    }
}
