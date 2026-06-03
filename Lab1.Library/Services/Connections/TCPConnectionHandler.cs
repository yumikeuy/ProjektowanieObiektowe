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

namespace Lab1.Library.Services.Connections
{
    public class TCPConnectionHandler : IConnectionHandler
    {
     
        private TcpClient _client = null!;
        private StreamReader _reader = null!;
        private StreamWriter _writer = null!;
        private bool _isConnected = false;

        public async Task<IGame> ConnectAsync(IPEndPoint serverEndPoint, string playerName)
        {
            _client = new TcpClient();

            try
            {
                await _client.ConnectAsync(serverEndPoint.Address, serverEndPoint.Port);

                NetworkStream stream = _client.GetStream();
                _reader = new StreamReader(stream, Encoding.UTF8);
                _writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };


                await _writer.WriteLineAsync(playerName);

                string initialGameJson = (await _reader.ReadLineAsync())!;

                if (string.IsNullOrEmpty(initialGameJson))
                {
                    throw new Exception("Server closed connection without sending game data.");
                }

                var initialGameState = (JsonSerializer.Deserialize<GameStateDto>(initialGameJson))!;

                var gameState = new GameState();
                gameState.PlayerManager = new PlayerManager();

                foreach(var player in initialGameState.Players)
                {
                    gameState.PlayerManager.AddPlayer(new Player(new(0, 0), 
                        player.NewPos, initialGameState.Board.Width, string.Empty, null!));
                }

                var boardData = new IGameObject[initialGameState.Board.Width, initialGameState.Board.Height];

                for(int y = 0; y < initialGameState.Board.Height; y++)
                {
                    for(int x = 0; x < initialGameState.Board.Width; x++)
                    {
                        boardData[x, y] = new CharGameObject(initialGameState.Board.board[y][x]);
                    }
                }

                gameState.Board = new Board(boardData);


                var game = new Game(gameState, new Printer(), new Instructions(new(0, 0)));

                _isConnected = true;

                _ = StartListeningForUpdatesAsync(gameState);

                return game;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Client Connection Error] Could not connect: {ex.Message}");
                Disconnect();
                return null!;
            }
        }

        private async Task StartListeningForUpdatesAsync(IGameState gameState)
        {
            try
            {
                while (_isConnected && _client.Connected)
                {
                    string liveUpdateJson = (await _reader.ReadLineAsync())!;

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
            finally
            {
                Disconnect();
            }
        }

        private void ProcessIncomingServerData(string json, IGameState gameState)
        {
            try
            {
                GameChanges? serverChanges = JsonSerializer.Deserialize<GameChanges>(json);
                if (serverChanges == null) return;

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
                    foreach (PlayerChange playerChange in serverChanges.PlayersChanges.Changes)
                    {

                        if (playerChange.Player == null || !playerChange.Player.IsAlive)
                        {
                            gameState.PlayerManager.RemovePlayer(playerChange.Name);
                        }
                        else
                        {
                            var localPlayer = new Player((0, 0), playerChange.Player.NewPos, gameState.Board.Width, playerChange.Name, null!);

                            gameState.PlayerManager.AddPlayer(localPlayer);
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

        private readonly object _writeLock = new object();

        public void SendCommandToServerAsync(ConsoleKey key)
        {
            Task.Run(() =>
            {
                if (_isConnected && _writer != null)
                {
                    try
                    {
                        var json = JsonSerializer.Serialize<ConsoleKey>(key);

                        lock (_writeLock)
                        {
                            _writer.WriteLine(json);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Client Network Error] Failed to send key input: {ex.Message}");
                    }
                }
            });
            
        }

        public void Disconnect()
        {
            _isConnected = false;
            _writer?.Dispose();
            _reader?.Dispose();
            _client?.Dispose();
        }
    }
}
