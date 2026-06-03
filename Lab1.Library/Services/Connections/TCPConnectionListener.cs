using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lab1.Library.Entities.Changes;
using Lab1.Library.Entities.DTOs;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Entities.Main;
using Lab1.Library.Interfaces.Connections;
using Lab1.Library.Interfaces.Entities;

namespace Lab1.Library.Services.Connections
{
    public class TCPConnectionListener : IConnectionListener
    {
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
                    Console.WriteLine($"[Server Error] Listener encountered an error: {ex.Message}");
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
                using (client)
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                using (var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                {
                    string playerName = (await reader.ReadLineAsync())!;

                    if (string.IsNullOrWhiteSpace(playerName))
                    {
                        return;
                    }

                    if (client.Client.LocalEndPoint is IPEndPoint ipep)
                    {
                        game.GameState.AddPlayer(playerName, ipep);
                    }
                    else
                    {
                        throw new Exception("Unsupported connection.");
                    }

                    List<PlayerDto> playerDtos = [];

                    var board = game.GameState.Board;
                    
                    string[] gameObjectDtos = new string[board.Height];

                    for(int y = 0; y < board.Height; y++)
                    {
                        StringBuilder sb = new StringBuilder(board.Width);

                        for (int x = 0; x < board.Width; x++)
                        {
                            sb.Append(board.GetAt(new(x, y)).Char);
                        }

                        gameObjectDtos[y] = sb.ToString();
                    }

                    var boardDto = new BoardDto(board.Width, board.Height, gameObjectDtos);

                    foreach(var player in game.GameState.PlayerManager.GetAllPlayers())
                    {
                        playerDtos.Add(new(true, player.Pos));
                    }

                    var gameDto = new GameStateDto(boardDto, playerDtos);


                    string jsonString = JsonSerializer.Serialize(gameDto);

                    await writer.WriteLineAsync(jsonString);

                    while (client.Connected)
                    {
                        string incomingInput = (await reader.ReadLineAsync())!;
                        if (incomingInput == null) break;

                        var key = JsonSerializer.Deserialize<ConsoleKey>(incomingInput);

                        ProcessPlayerInput(key, game, playerName);
                    }

                    game.GameState.PlayerManager.RemovePlayer(playerName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Server Connection Error] {ex.Message}");
            }
        }

        private void ProcessPlayerInput(ConsoleKey key, IGame game, string name)
        {
            game.Instructions.ExecuteAction(game, key, game.GameState.PlayerManager.GetPlayer(name)!);
        }

        public async Task SendChangesToPlayerAsync(IPlayer player, GameChanges changes)
        {
            if (player?.IP == null)
            {
                Console.WriteLine($"[Network Error] Cannot send changes; player or IPEndPoint is null.");
                return;
            }

            using var client = new TcpClient();
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

            try
            {                
                await client.ConnectAsync(player.IP.Address, player.IP.Port, cts.Token);

                using var stream = client.GetStream();
                using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

                string jsonPayload = JsonSerializer.Serialize(changes);

                await writer.WriteLineAsync(jsonPayload);
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"[Network Warning] Failed to reach player {player.Name} at {player.IP}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Network Error] Unexpected error sending delta data to {player.Name}: {ex.Message}");
            }
        }
    }
}
