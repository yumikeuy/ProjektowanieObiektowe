using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Changes;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;

namespace Lab1.Library.Entities.Main
{
    public class PlayerManager() : IPlayerManager
    {
        private readonly ConcurrentDictionary<string, IPlayer> _players = [];
        private string localPlayer = string.Empty;

        public bool HasChanged { get; set; } = false;
        private LocalPlayerChanges localPlayerChanges = new();

        public void AddPlayer(Player player, bool isLocal = false)
        {
            _players[player.Name] = player;

            if (isLocal)
            {
                localPlayer = player.Name;
            }


            HasChanged = true;
        }

        public IPlayer? GetPlayer(string name)
        {
            if(!_players.TryGetValue(name, out var player))
            {
                return null;
            }


            HasChanged = true;

            return player;
        }
        public IPlayer? GetPlayer(Point pos)
        {
            var player = _players.Values.FirstOrDefault(p => p.Pos == pos);

            if(player != null)
            {
                HasChanged = true;
            }
            
            return player;
        }

        public IPlayer? GetLocalPlayer()
        {
            var player = _players.Values.FirstOrDefault(p => p.Name == localPlayer);

            if (player != null)
            {
                HasChanged = true;
            }

            return player;
        }

        public List<IPlayer> GetAllPlayers()
        {
            HasChanged = true;
            return _players.Values.ToList();
        }

        public void RemovePlayer(string name)
        {
            _players.Remove(name, out var player);

            if(name == localPlayer)
            {
                localPlayer = string.Empty;
            
            }
            if(player != null)
            {
                HasChanged = true;
            }
        }

        public void RemoveAllPlayers()
        {
            _players.Clear();

        }

        public Point PrintAt { get; set; } = (0, 0);

        public IPrintable Text()
        {
            var p = new Printable();
            foreach (var player in _players.Values)
            {
                p.Add(player.Text());

                if(player.Name == localPlayer)
                {
                    p.Add(player.State.Text());
                }
            }

            return p;
        }

        public void SetLocalPlayer(string name)
        {
            localPlayer = name;
        }

        public PlayerChanges FlushChanges()
        {
            var changes = new PlayerChanges();
            
            foreach(var player in _players.Values)
            {
                changes.Changes.Add(new(player.Name, new(true, player.Pos)));
            }

            return changes;
        }
    }
}
