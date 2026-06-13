using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities.DTOs
{
    public class HandsDto
    {
        public ItemDto? LeftItem { get; set; }
        public ItemDto? RightItem { get; set; }
    }
}
