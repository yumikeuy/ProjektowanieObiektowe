using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services.Visitors.GameObject;

namespace Lab1.Library.Interfaces.Entities.GameObjects
{
    public interface IGameObject : ITextConvertible
    {
        char Char { get; set; }

        bool AcceptGameObjectVisitor(GameObjectVisitor visitor);
    }
}
