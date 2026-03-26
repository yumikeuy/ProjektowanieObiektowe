using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Interfaces;

using Lab1.Library.Entities.GameObjects;

namespace Lab1.Library.Services
{
    public class DefaultGameBuilder(int width, int height, int playerStateWidth, 
        IBoardBuilder boardBuilder, IInstructionsBuilder instructionsBuilder) : IGameBuilder
    {
        private readonly int _width = width;
        private readonly int _height = height;
        private readonly int _playerStateWidth = playerStateWidth;
        private readonly IBoardBuilder _boardBuilder = boardBuilder;
        private readonly IInstructionsBuilder _instructionsBuilder = instructionsBuilder;

        private IGameState _gameState = new GameState();

        // IGameBuilder
        public IGameBuilder InitializeEmpty()
        {
            _boardBuilder.InitializeEmpty(_width, _height);
            _instructionsBuilder.Initialize(new(_width + _playerStateWidth + 3, 1));

            return this;
        }
        public IGameBuilder InitializeFull()
        {
            _boardBuilder.InitializeFull(_width, _height);
            _instructionsBuilder.Initialize(new(_width + _playerStateWidth + 3, 1));

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
        public IGameBuilder AddItems(int ammount)
        {
            _boardBuilder.AddItems(ammount);
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
        public IGameState GetResult()
        {
            _gameState.Printer = new Printer();
            _gameState.Board = _boardBuilder.GetResult();
            _gameState.Instructions = _instructionsBuilder.GetResult();
            _gameState.Player = new Player(_gameState.Board.GetSpawnPoint(), _width, _height);

            return _gameState;
        }
    }
}
