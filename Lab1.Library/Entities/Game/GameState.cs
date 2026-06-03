using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Lab1.Library.Entities.Changes;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Events;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;
using Lab1.Library.Services.Printing;

namespace Lab1.Library.Entities.Game
{
    public class GameState : IGameState
    {
        public bool IsActive { get; private set; } = false;
        public bool HasChanged
        {
            get => Board.HasChanged || PlayerManager.HasChanged;
            set
            {
            }
        } 

        public GameState()
        {
            HasChanged = true;
        }

        public IPlayerManager PlayerManager { get; set; } = null!;
        public IBoard Board { get; set; } = null!;
        public IDestroyer Destroyer { get; set; } = null!;
        public ILogScreen LogScreen { get; set; } = null!;
        public string EndReason { get; private set; } = string.Empty;
        public IMediatorsDirector<INoiseData, IKillData> MediatorsDirector { get; set; } = null!;
        public IEnemyMover EnemyMover { get; set; } = null!;

        public void Stop(string reason)
        {
            IsActive = false;
            EndReason = reason;
        }

        public void Start()
        {
            IsActive = true;
        }

        public void AddPlayer(string name, IPEndPoint ipep, bool isLocal = false)
        {
            var player = new Player(Board.GetZero(), Board.GetSpawnPoint(), Board.Width, name, ipep);
            MediatorsDirector.Destroyer.Add(player);
            PlayerManager.AddPlayer(player, isLocal);

            HasChanged = true;
        }

        public void RemovePlayer(string name)
        {
            var player = PlayerManager.GetPlayer(name);
            if(player == null) return;

            player.Die();
            MediatorsDirector.Destroyer.Add(player);
            PlayerManager.RemovePlayer(name);

            HasChanged = true;
        }

        public Point PrintAt { get; set; } = new(0, 0);

        public IPrintable Text()
        {
            Printable p = new();

            p.Add(Board.Text());

            p.Add(PlayerManager.Text());
            
            p.Add(LogScreen.Text());

            return p;
        }

        public GameChanges FlushChanges()
        {
            var changes = new GameChanges();

            if (Board.HasChanged)
            {
                changes.BoardChanges = Board.FlushChanges();
            }

            if (PlayerManager.HasChanged)
            {
                changes.PlayersChanges = PlayerManager.FlushChanges();
            }

            HasChanged = false;

            return changes;
        }
    }
}
