using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.Events
{
    public interface IMediator<TEventData>
    {
        void Notify(TEventData data);
        void Subscribe(IResponsive<TEventData> responsive);
        void Unsubscribe(IResponsive<TEventData> responsive);
    }
}
