using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Lab1.Library.Entities.Changes;
using Lab1.Library.Entities.GameObjects.Main;
using Lab1.Library.Interfaces.Printing;
using Lab1.Library.Services;

namespace Lab1.Library.Interfaces.Entities
{
    public interface IPlayerManager : ITextConvertible
    {
        void AddPlayer(Player player, bool isLocal = false);
        void RemovePlayer(string name);
        IPlayer? GetPlayer(string name);
        IPlayer? GetPlayer(Point pos);
        IPlayer? GetLocalPlayer();
        List<IPlayer> GetAllPlayers();
        void SetLocalPlayer(string name);
        bool HasChanged { get; set; }
        PlayerChanges FlushChanges();
    }
}
