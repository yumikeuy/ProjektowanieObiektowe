using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.DTOs;

namespace Lab1.Library.Entities.Changes
{
    public record PlayerChange(string Name, PlayerDto Player);
}
