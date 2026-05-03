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
            _gameState.Destroyer = new Destroyer();
            _gameState.LogScreen = new LogScreen(_height);
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
        public IGameBuilder AddItems(int amount)
        {
            _boardBuilder.AddItems(amount);
            _instructionsBuilder.AddItems();

            return this;
        }
        public IGameBuilder AddWeapons(int amount)
        {
            _boardBuilder.AddWeapons(amount);
            _instructionsBuilder.AddItems();

            return this;
        }
        public IGameBuilder AddMoney(int amount)
        {
            _boardBuilder.AddMoney(amount);
            _instructionsBuilder.AddItems();

            return this;
        }

        public IGameBuilder AddEnemies(int amount)
        {
            _boardBuilder.AddEnemies(_gameState.Destroyer, amount);
            _instructionsBuilder.AddEnemies();

            return this;
        }

        public IGameState GetResult()
        {
            _gameState.Printer = new Printer();
            _gameState.Board = _boardBuilder.GetResult();
            _gameState.Instructions = _instructionsBuilder.GetResult();
            _gameState.Destroyer.AddBoard(_gameState.Board);
            _gameState.Player = new Player(_gameState.Board.GetZero(), _gameState.Board.GetSpawnPoint(), _width);
            _gameState.Destroyer.Add(_gameState.Player);
            return _gameState;
        }
    }
}
