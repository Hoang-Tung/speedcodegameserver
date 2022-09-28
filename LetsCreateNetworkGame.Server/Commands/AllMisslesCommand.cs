using System.Collections.Generic;
using System.Linq;
using LetsCreateNetworkGame.OpenGL.Library;
using LetsCreateNetworkGame.Server.Managers;
using Lidgren.Network;

namespace LetsCreateNetworkGame.Server.Commands
{
    class AllMisslesCommand : ICommand
    {

        public bool CameraUpdate { get; set; }
        public List<Missle> Missles ;
        public void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection, GameRoom gameRoom)
        {
            Missles = new List<Missle>();
            //managerLogger.AddLogMessage("server", "Sending Missle list");
            var outmessage = server.NetServer.CreateMessage();
            outmessage.Write((byte)PacketType.AllMissles);
            outmessage.Write(CameraUpdate);
            outmessage.Write(gameRoom.Missles.Count);
            outmessage.Write(gameRoom.GameRoomId);
            Missles = gameRoom.Missles;
            foreach (var m in Missles)
            {
                outmessage.Write(m.UniqueId);
                outmessage.Write(m.MissleId);
                outmessage.Write(m.isHidden);
                outmessage.WriteAllProperties(m.Position);
                outmessage.WriteAllProperties(m.direction);
            }
            if (gameRoom.Players.Select(p => p.Connection).ToList().Count > 0)
                server.NetServer.SendMessage(outmessage, gameRoom.Players.Select(p => p.Connection).ToList(), NetDeliveryMethod.ReliableOrdered, 0);
        }
    }
}
