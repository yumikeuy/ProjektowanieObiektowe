using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameInstructions;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Services
{
    public abstract class InputHandler
    {
        protected InputHandler? _nextHandler;
        protected ICollection<ActionInstruction> _instructions = [];
        public void SetNext(InputHandler nextHandler)
        {
            if(_nextHandler == null)
                _nextHandler = nextHandler;
            else
                _nextHandler.SetNext(nextHandler);
        }
        public InputHandler? GetNext()
        {
            return _nextHandler;      
        }

        public void Handle(IInputEvent inputEvent)
        {
            _instructions.FirstOrDefault(i => i.Keys.Contains(inputEvent.Key))?.Execute(inputEvent);
            if (!inputEvent.IsHandled && _nextHandler != null)
                _nextHandler.Handle(inputEvent);
        }

        public ICollection<ActionInstruction> GetInstructions()
        {
            return _instructions;
        }
    }
}
