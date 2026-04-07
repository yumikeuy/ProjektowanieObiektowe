using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services.Visitors;

namespace Lab1.Library.Entities.GameObjects.Items.Neutral
{
    public class Apple : NeutralItem
    {
        public override char Char { get; set; } = 'o';
        public override string Description { get; set; } = "Juicy Red Apple";
        public override bool Accept(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
