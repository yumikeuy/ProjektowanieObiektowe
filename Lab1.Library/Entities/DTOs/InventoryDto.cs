using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.DTOs
{
    public class InventoryDto
    {
        public List<ItemDto> Items { get; set; } = [];
    }
}
