using System.Linq;
using LetsCreateNetworkGame.OpenGL.Library;
using LetsCreateNetworkGame.Server.Managers;
using Lidgren.Network;

namespace LetsCreateNetworkGame.Server.Commands
{
    class AllMisslesCommand : ICommand
    {

        public bool CameraUpdate { get; set; }
        public void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection, GameRoom gameRoom)
        {
            managerLogger.AddLogMessage("server", "Sending Missle list");
            var outmessage = server.NetServer.CreateMessage();
            outmessage.Write((byte)PacketType.AllMissles);
            outmessage.Write(CameraUpdate);
            outmessage.Write(gameRoom.Missles.Count);
            foreach (var m in gameRoom.Missles)
            {
                outmessage.Write(m.UniqueId);
                outmessage.Write(m.MissleId);
                outmessage.WriteAllProperties(m.Position);
                outmessage.WriteAllProperties(m.direction);
            }
            server.NetServer.SendMessage(outmessage, gameRoom.Players.Select(p => p.Connection).ToList(), NetDeliveryMethod.ReliableOrdered, 0);
        }
    }
}
