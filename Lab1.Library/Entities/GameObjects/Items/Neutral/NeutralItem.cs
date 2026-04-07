using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Services.Visitors;

namespace Lab1.Library.Entities.GameObjects.Items.Neutral
{
    public abstract class NeutralItem : Item
    {
        public override bool Accept(GameObjectVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
