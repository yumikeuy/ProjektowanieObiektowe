using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lab1.Library.Entities.DTOs;
using Lab1.Library.Entities.Game;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Connections;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.GameInstructions;
using Lab1.Library.Services.Printing;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Entities.Changes;
using Lab1.Library.Entities.GameObjects.Items.Neutral;

namespace Lab1.Library.Services.Connections
{
    public class TCPConnectionHandler : IConnectionHandler
    {
        private ConnectedClient _client = null!;
        private bool _isConnected = false;
        private string localPlayerName = string.Empty;

        public async Task<IGame> ConnectAsync(IPEndPoint serverEndPoint, string playerName)
        {
            localPlayerName = playerName;
            bool isConnected = false;
            while(!isConnected)
            {
                try
                {
                    _client = new ConnectedClient(serverEndPoint);
                    _isConnected = true;

                    await _client.SendAsync(playerName);

                    string initialGameJson = (await _client.ReceiveAsync())!;

                    var game = PrepareGameFromJson(initialGameJson);

                    _ = StartListeningForUpdatesAsync(game.GameState);

                    return game;
                } 
                catch (Exception ex)
                {
                    Console.WriteLine($"[Client Connection Error] Could not connect: {ex.Message}");
                    Disconnect();
                    await Task.Delay(2000);
                }
            }

            return null!;
        }

        private Game PrepareGameFromJson(string initialGameJson)
        {
            if (string.IsNullOrEmpty(initialGameJson))
            {
                throw new Exception("Server closed connection without sending game data.");
            }

            var initialGameState = (JsonSerializer.Deserialize<GameStateDto>(initialGameJson))!;

            var gameState = new GameState()
            {
                PlayerManager = new PlayerManager()
            };


            foreach (var player in initialGameState.Players)
            {
                if(player.Name == localPlayerName)
                {
                    gameState.PlayerManager.AddPlayer(new Player(new(1, 1),
                        player.NewPos, initialGameState.Board.Width, player.Name, null!), true);
                }
                else
                {
                    gameState.PlayerManager.AddPlayer(new Player(new(1, 1),
                        player.NewPos, initialGameState.Board.Width, player.Name, null!));
                }
            }

            var boardData = new IGameObject[initialGameState.Board.Width, initialGameState.Board.Height];

            for (int y = 0; y < initialGameState.Board.Height; y++)
            {
                for (int x = 0; x < initialGameState.Board.Width; x++)
                {
                    boardData[x, y] = new CharGameObject(initialGameState.Board.board[y][x]);
                }
            }

            gameState.Board = new Board(boardData);

            var game = new Game(gameState, new Printer(), new Instructions(new(0, 0)));

            gameState.LogScreen = new LogScreen(gameState.Board.Height);

            return game;
        }

        private async Task StartListeningForUpdatesAsync(IGameState gameState)
        {
            try
            {
                while (_isConnected && _client.TcpClient.Connected)
                {
                    string liveUpdateJson = (await _client.ReceiveAsync())!;

                    if (liveUpdateJson == null)
                    {
                        break;
                    }

                    ProcessIncomingServerData(liveUpdateJson, gameState);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Client Error] Error reading server updates: {ex.Message}");
            }
        }

        private void ProcessIncomingServerData(string json, IGameState gameState)
        {
            try
            {
                GameChanges? serverChanges = JsonSerializer.Deserialize<GameChanges>(json);
                if (serverChanges == null || (serverChanges.PlayersChanges == null && serverChanges.BoardChanges == null))
                {
                    var playerStateDto = JsonSerializer.Deserialize<PlayerStateDto>(json);
                    if (playerStateDto == null) return;


                    var playerState = ConvertFromDtoToState(playerStateDto, gameState.Board.Width);

                    var player = gameState.PlayerManager.GetPlayer(localPlayerName);

                    if (player == null) return;

                    player.State = playerState;
                }
                else
                {
                    if (serverChanges.BoardChanges?.Changes != null)
                    {
                        foreach (BoardChange boardChange in serverChanges.BoardChanges.Changes)
                        {

                            char representationChar = boardChange.GameObject.Char;
                            IGameObject concreteGo = new CharGameObject(representationChar);

                            gameState.Board.SetAt(new(boardChange.X, boardChange.Y), concreteGo);
                        }
                    }

                    if (serverChanges.PlayersChanges?.Changes != null)
                    {
                        foreach(var player in gameState.PlayerManager.GetAllPlayers())
                        {
                            var existingPLayer = serverChanges.PlayersChanges.Changes.FirstOrDefault(p => p.Name == player.Name);
                            if (existingPLayer == null)
                            {
                                gameState.PlayerManager.RemovePlayer(player.Name);
                            }
                            else
                            {
                                player.Pos = existingPLayer.NewPos;
                            }
                        }

                        foreach (var playerChange in serverChanges.PlayersChanges.Changes)
                        {
                            var newPlayer = gameState.PlayerManager.GetPlayer(playerChange.Name);
                            if(newPlayer == null)
                            {
                                gameState.PlayerManager.AddPlayer(new(new(0, 0), playerChange.NewPos, gameState.Board.Width, playerChange.Name, null!), localPlayerName == playerChange.Name);
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                     
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"[Client Parse Error] Received invalid packet structure: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Client State Error] Error applying updates to local world: {ex.Message}");
            }
        }

        private static PlayerState ConvertFromDtoToState(PlayerStateDto playerStateDto, int boardWidth)
        {
            var playerState = new PlayerState(boardWidth)
            {
                Damage = playerStateDto.Damage,
                Health = playerStateDto.Health,
                Luck = playerStateDto.Luck,
                Agility = playerStateDto.Agility,
                Agressiveness = playerStateDto.Agressiveness,
                Iq = playerStateDto.Iq,
                Coins = playerStateDto.Coins,
                Gold = playerStateDto.Gold,
                Armor = playerStateDto.Armor
            };

            foreach(var item in playerStateDto.Inventory.Items)
            {
                playerState.TryAdd(new EmptyItem(item.Description));
            }

            if(playerStateDto.HandsDto.LeftItem != null)
            {
                playerState.TryAddToLeft(new EmptyItem(playerStateDto.HandsDto.LeftItem.Description));
            }

            if (playerStateDto.HandsDto.RightItem != null)
            {
                playerState.TryAddToRight(new EmptyItem(playerStateDto.HandsDto.RightItem.Description));
            }

            return playerState;
        }

        private DateTime _lastCommandTime = DateTime.MinValue;
        private readonly TimeSpan _commandCooldown = TimeSpan.FromMilliseconds(60);

        public async Task SendCommandToServerAsync(ConsoleKey key)
        {
            var now = DateTime.UtcNow;
            if (now - _lastCommandTime < _commandCooldown)
            {
                return;
            }

            _lastCommandTime = now;

            if (_isConnected)
            {
                try
                {
                    var json = JsonSerializer.Serialize<ConsoleKey>(key);

                    await _client.SendAsync(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Client Network Error] Failed to send key input: {ex.Message}");
                }
            }
            
        }

        public void Disconnect()
        {
            _isConnected = false;
            _client?.Dispose();
        }
    }
}
