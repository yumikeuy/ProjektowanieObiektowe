using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities.GameObjects;
using Lab1.Library.Interfaces.Entities.GameObjects.Enemies;
using Lab1.Library.Interfaces.Events;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Services.EventsMediators
{
    public class MediatorsDirector(IDestroyer destroyer, IMediator<INoiseData> noiseMediator, IMediator<IKillData> killMediator) 
        : IMediatorsDirector<INoiseData, IKillData>
    {
        public IDestroyer Destroyer { get; set; } = destroyer;
        public IMediator<INoiseData> NoiseMediator { get; set; } = noiseMediator;
        public IMediator<IKillData> CowardlyKillMediator { get; set; } = killMediator;
        public IMediator<IKillData> AggressiveKillMediator { get; set; } = killMediator;
        public IMediator<IKillData> OrdinaryKillMediator { get; set; } = killMediator;
        public void SubscribeKill(IAggressive aggressive)
        {
            AggressiveKillMediator.Subscribe(aggressive);
        }
        public void SubscribeKill(ICowardly cowardly)
        {
            CowardlyKillMediator.Subscribe(cowardly);
        }
        public void SubscribeKill(IOrdinary ordinary)
        {
            OrdinaryKillMediator.Subscribe(ordinary);
        }
    }
}
