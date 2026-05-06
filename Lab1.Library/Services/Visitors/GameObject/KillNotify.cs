using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities.GameObjects.Enemies;
using Lab1.Library.Interfaces.Events;
using Lab1.Library.Services.EventsMediators;
using Lab1.Library.Services.EventsMediators.Killing;

namespace Lab1.Library.Services.Visitors.GameObject
{
    public class KillNotify(IMediatorsDirector<INoiseData, IKillData> mediatorsDirector, Point pos) : GameObjectVisitor
    {
        public override bool Visit(IAggressive aggressive)
        {
            mediatorsDirector.AggressiveKillMediator.Notify(new KillData(pos));
            return true;
        }
        public override bool Visit(ICowardly aggressive)
        {
            mediatorsDirector.CowardlyKillMediator.Notify(new KillData(pos));
            return true;
        }
    }
}
