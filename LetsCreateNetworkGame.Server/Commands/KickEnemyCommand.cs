//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using LetsCreateNetworkGame.OpenGL.Library;
using LetsCreateNetworkGame.Server.Managers;
using Lidgren.Network;

namespace LetsCreateNetworkGame.Server.Commands
{
    class KickEnemyCommand : ICommand
    {
        public int KickUniqueId { get; set; }
        public void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection, GameRoom gameRoom)
        {
            managerLogger.AddLogMessage("server", string.Format("Kicking EnemyId {0}", KickUniqueId));
            
            var outmessage = server.NetServer.CreateMessage();
            outmessage.Write((byte)PacketType.KickEnemy);
            outmessage.Write(KickUniqueId);
            server.NetServer.SendToAll(outmessage, NetDeliveryMethod.ReliableOrdered);
            
        }
    }
}
