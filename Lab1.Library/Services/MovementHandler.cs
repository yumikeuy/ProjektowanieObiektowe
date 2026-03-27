using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameInstructions;
using Lab1.Library.Interfaces;

namespace Lab1.Library.Services
{
    public class MovementHandler : InputHandler
    {
        public MovementHandler()
        {
            _instructions.Add(new MovementInstruction());
        }
    }
}
