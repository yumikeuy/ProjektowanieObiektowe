using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Entities.GameInstructions;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Services
{
    public class UIHandler : InputHandler
    {
        public UIHandler()
        {
            _instructions.Add(new StopGameInstruction());
        }

        public override void Handle(IInputEvent inputEvent)
        {
            _instructions.FirstOrDefault(i => i.Keys.Contains(inputEvent.Key)).Action();
            base.Handle(actionInstruction);
        }
    }
}
