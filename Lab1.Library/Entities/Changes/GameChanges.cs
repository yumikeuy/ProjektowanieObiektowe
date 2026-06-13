using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.DTOs;
using Lab1.Library.Entities.Main;

namespace Lab1.Library.Entities.Changes
{
    public class GameChanges 
    {
        public BoardChanges? BoardChanges { get; set; }
        public PlayerChanges? PlayersChanges { get; set; } 
    }
}
