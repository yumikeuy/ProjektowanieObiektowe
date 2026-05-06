using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Interfaces.Events
{
    public interface IResponsive<TEventData>
    {
        void OnNotify(TEventData data);
    }
}
