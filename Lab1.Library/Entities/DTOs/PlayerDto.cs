using System;
using System.Collections.Generic;
using Lab1.Library.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.DTOs
{
    public record PlayerDto(bool IsAlive, Point NewPos);
}
