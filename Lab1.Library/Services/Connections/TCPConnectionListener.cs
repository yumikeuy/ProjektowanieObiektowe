using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Lab1.Library.Entities.Changes;
using Lab1.Library.Entities.DTOs;
using Lab1.Library.Interfaces.Connections;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Services.Logging;

namespace Lab1.Library.Services.Connections
{
    public class TCPConnectionListener : IConnectionListener
    {
        private readonly ConcurrentDictionary<string, IConnectedClient> _clients = [];

        public void Start(IPEndPoint ipep, IGame game)
        {
            Task.Run(async () =>
            {
                var listener = new TcpListener(ipep);

                try
                {
                    listener.Start();

                    while (true)
                    {
                        var client = await listener.AcceptTcpClientAsync();

                        _ = HandleNewPlayerAsync(client, game);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.Log($"[Server Error] Listener encountered an error: {ex.Message}");
                }
                finally
                {
                    listener.Stop();
                }
            });
        }


        private async Task HandleNewPlayerAsync(TcpClient client, IGame game)
        {
            try
            {
                using var connectedClient = new ConnectedClient(client);
                string playerName = (await connectedClient.ReceiveAsync())!;

                if (string.IsNullOrWhiteSpace(playerName)) return;

                if (client.Client.LocalEndPoint is IPEndPoint ipep)
                {
                    game.GameState.AddPlayer(playerName, ipep);
                    _clients.TryAdd(playerName, connectedClient);
                }
                else
                {
                    throw new Exception("Unsupported connection.");
                }

                var jsonString = PrepareData(game);
                await connectedClient.SendAsync(jsonString);

                await HandleInputLoop(game, playerName, connectedClient);
                game.GameState.PlayerManager.RemovePlayer(playerName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Log($"[Server Connection Error] {ex.Message}");
            }
        }

        private async Task HandleInputLoop(IGame game, string playerName, IConnectedClient connectedClient)
        {
            while (true)
            {
                string? incomingInput = await connectedClient.ReceiveAsync();

                if (incomingInput == null)
                    break;

                try
                {
                    var key = JsonSerializer.Deserialize<ConsoleKey>(incomingInput);
                    ProcessPlayerInput(key, game, playerName);
                }
                catch (JsonException jsonEx)
                {
                    Logger.Instance.Log($"[Server Warning] Received invalid JSON from {playerName}: {jsonEx.Message}");
                }
            }
        }

        private void ProcessPlayerInput(ConsoleKey key, IGame game, string name)
        {
            game.Instructions.ExecuteAction(game, key, game.GameState.PlayerManager.GetPlayer(name)!);
        }

        public async Task SendChangesToPlayerAsync(IPlayer player)
        {
            var res = _clients.TryGetValue(player.Name, out var connectedClient);

            if (res == false || connectedClient == null)
            {
                return;
            }

            try
            {
                var stateDto = ConvertStateToDto(player.State);
                string jsonPayload = JsonSerializer.Serialize(stateDto);
                await connectedClient.SendAsync(jsonPayload);
            } 
            catch (SocketException ex)
            {
                Logger.Instance.Log($"[Network Warning] Failed to reach player {player.Name}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Logger.Instance.Log($"[Network Error] Unexpected error sending delta data to {player.Name}: {ex.Message}");
            }
        }

        private static PlayerStateDto ConvertStateToDto(IPlayerState playerState)
        {
            var stateDto = new PlayerStateDto
            {
                Damage = playerState.Damage,
                Health = playerState.Health,
                Luck = playerState.Luck,
                Agility = playerState.Agility,
                Agressiveness = playerState.Agressiveness,
                Iq = playerState.Iq,
                Coins = playerState.Coins,
                Gold = playerState.Gold,
                Armor = playerState.Armor
            };

            foreach(var item in playerState.GetInventory())
            {
                stateDto.Inventory.Items.Add(new ItemDto { Description = item.Description });
            }

            (var leftItem, var rightItem) = playerState.GetItemsFromHands();
            stateDto.HandsDto.LeftItem = new ItemDto { Description = leftItem?.Description ?? string.Empty };
            stateDto.HandsDto.RightItem = new ItemDto { Description = rightItem?.Description ?? string.Empty};

            return stateDto;

        }

        public async Task BroadcastChangesAsync(GameChanges changes)
        {
            string jsonPayload = JsonSerializer.Serialize(changes);

            var tasks = new List<Task>();

            foreach (var connectedClient in _clients.Values)
            {
                if (connectedClient.TcpClient != null && connectedClient.TcpClient.Connected)
                {
                    try
                    {
                        tasks.Add(connectedClient.SendAsync(jsonPayload));
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.Log($"[Broadcast Error] Не удалось отправить обновление игроку: {ex.Message}");
                    }
                }
            }

            await Task.WhenAll(tasks);
        }


        private static string PrepareData(IGame game)
        {
            List<PlayerDto> playerDtos = [];

            var board = game.GameState.Board;

            string[] gameObjectDtos = new string[board.Height];

            for (int y = 0; y < board.Height; y++)
            {
                StringBuilder sb = new(board.Width);

                for (int x = 0; x < board.Width; x++)
                {
                    sb.Append(board.GetAt(new(x, y)).Char);
                }

                gameObjectDtos[y] = sb.ToString();
            }

            var boardDto = new BoardDto(board.Width, board.Height, gameObjectDtos);

            foreach (var player in game.GameState.PlayerManager.GetAllPlayers())
            {
                playerDtos.Add(new(player.Name, player.Pos));
            }

            var gameDto = new GameStateDto(boardDto, playerDtos);


            return JsonSerializer.Serialize(gameDto);
        }
    }
}
