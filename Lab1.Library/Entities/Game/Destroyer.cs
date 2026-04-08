using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Interfaces.Entities;
using Lab1.Library.Interfaces.Game;

namespace Lab1.Library.Entities.Game
{
    public class Destroyer(IBoard board) : IDestroyer
    {
        private IBoard _board = board;
        private List<IDestroyable> _toRemove = new List<IDestroyable>();

        public void Add(IDestroyable entity)
        {
            entity.OnDestroyRequested += HandleDestroyRequest;
        }

        private void HandleDestroyRequest(IDestroyable entity)
        {
            _toRemove.Add(entity);
        }

        public void CleanUp()
        {
            if (_toRemove.Count > 0)
            {
                foreach (var entity in _toRemove)
                {
                    entity.OnDestroyRequested -= HandleDestroyRequest;
                    DisposeEntity(entity);
                }
                _toRemove.Clear();
            }
        }

        private void DisposeEntity(IDestroyable entity)
        {
            
        }
    }
}
