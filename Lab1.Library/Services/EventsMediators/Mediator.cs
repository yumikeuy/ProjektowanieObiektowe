using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Events;

namespace Lab1.Library.Services.EventsMediators
{
    public class Mediator<TEventData> : IMediator<TEventData> where TEventData : IEventData
    {
        public List<IResponsive<TEventData>> _observers = [];
        public void Notify(TEventData eventData)
        {
            var snapshot = new List<IResponsive<TEventData>>(_observers);

            foreach (var observer in snapshot)
            {
                observer.OnNotify(eventData);
            }
        }
        public void Subscribe(IResponsive<TEventData> responsive)
        {
            _observers.Add(responsive);
        }
        public void Unsubscribe(IResponsive<TEventData> responsive)
        {
            _observers.Remove(responsive);
        }
    }
}
