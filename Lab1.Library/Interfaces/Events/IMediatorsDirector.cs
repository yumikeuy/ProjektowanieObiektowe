using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Game;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Enemies;
using Lab1.Library.Interfaces.Game;
using Lab1.Library.Services.EventsMediators.Killing;
using Lab1.Library.Services.EventsMediators.Noise;

namespace Lab1.Library.Interfaces.Events
{
    public interface IMediatorsDirector<TNoiseData, TKillData> where TNoiseData : INoiseData where TKillData : IKillData
    {
        public IDestroyer Destroyer { get; set; }
        public IMediator<TNoiseData> NoiseMediator { get; set; }
        public IMediator<TKillData> CowardlyKillMediator { get; set; }
        public IMediator<TKillData> AggressiveKillMediator { get; set; }
        public void SubscribeKill(IAggressive aggressive);
        public void SubscribeKill(ICowardly cowardly);
    }
}
