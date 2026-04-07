using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.GameObjects;

namespace Lab1.Library.Services.Visitors
{
    public class IsEmpty : GameObjectVisitor
    {
        public override bool Visit(EmptyGameObject emptyGameObject)
        {
            return true;
        }
    }
}
