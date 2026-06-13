using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Entities.Changes;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Events;
using Lab1.Library.Interfaces.Printing;

namespace Lab1.Library.Interfaces.Game
{
    public interface IGameState : ITextConvertible
    {
        public bool IsActive { get; }
        public bool HasChanged { get; set; }
        public GameChanges FlushChanges();
        public IPlayerManager PlayerManager { get; set; }
        public IBoard Board { get; set; }
        public IDestroyer Destroyer { get; set; }
        public ILogScreen LogScreen { get; set; }
        public IMediatorsDirector<INoiseData, IKillData> MediatorsDirector { get; set; }
        public IEnemyMover EnemyMover { get; set; }
        public string EndReason { get; }
        public void AddPlayer(string name, IPEndPoint ipep, bool isLocal = false);
        public void Stop(string reason);
        public void Start();
    }
}
