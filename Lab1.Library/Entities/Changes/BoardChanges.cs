using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.DTOs;
using Lab1.Library.Interfaces.Entities.GameObjects;

namespace Lab1.Library.Entities.Changes
{
    public class BoardChanges
    {
        public List<BoardChange> Changes { get; set; } = [];
    }
}
