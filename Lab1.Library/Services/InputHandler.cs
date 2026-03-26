using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Services
{
    public class InputHandler
    {
        protected InputHandler? _nextHandler;
        protected ICollection<IActionInstruction> _instructions = [];
        public void SetNext(InputHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public virtual void Handle(IInputEvent inputEvent)
        {
            if(!inputEvent.IsHandled && _nextHandler != null)
                _nextHandler.Handle(inputEvent);
        }
    }
}
