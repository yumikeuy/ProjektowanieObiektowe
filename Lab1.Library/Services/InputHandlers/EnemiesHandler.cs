using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameInstructions;

namespace Lab1.Library.Services.InputHandlers
{
    public class EnemiesHandler : InputHandler
    {
        public EnemiesHandler()
        {
            _instructions.Add(new AttackingInstruction());
        }
    }
}
