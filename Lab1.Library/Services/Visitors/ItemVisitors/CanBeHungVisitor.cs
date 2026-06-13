using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities.GameObjects.Items;
using Lab1.Library.Interfaces.Entities.GameObjects.Items.NeutralItems;

namespace Lab1.Library.Services.Visitors.ItemVisitors
{
    public class CanBeHungVisitor(IItem itemToHandOn) : ItemVisitor
    {
        public override bool Visit(INeutralItem item)
        {
            return itemToHandOn.TryAdd(item);
        }

        public override bool Visit(IHandle item)
        {
            return itemToHandOn.TryAdd(item);
        }
    }
}
