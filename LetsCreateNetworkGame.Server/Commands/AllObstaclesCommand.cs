//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System.Linq;
using LetsCreateNetworkGame.OpenGL.Library;
using LetsCreateNetworkGame.Server.Managers;
using Lidgren.Network;

namespace LetsCreateNetworkGame.Server.Commands
{
    class AllObstaclesCommand : ICommand
    {
        public bool CameraUpdate { get; set; }

        public void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection, GameRoom gameRoom)
        {
            managerLogger.AddLogMessage("server", "Sending enemy list");
            var outmessage = server.NetServer.CreateMessage();
            outmessage.Write((byte)PacketType.AllObstacles);
            outmessage.Write(CameraUpdate);
            outmessage.Write(gameRoom.Obstacles.Count);
            foreach (var e in gameRoom.Obstacles)
            {
                outmessage.Write(e.UniqueId);
                outmessage.Write(e.ObstacleId);
                outmessage.WriteAllProperties(e.Position);
            }
            server.NetServer.SendMessage(outmessage, gameRoom.Players.Select(p => p.Connection).ToList(), NetDeliveryMethod.ReliableOrdered, 0);
        }
    }
}
