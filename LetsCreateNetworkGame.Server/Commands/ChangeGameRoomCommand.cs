using LetsCreateNetworkGame.Server.Managers;
using Lidgren.Network;
using System.Linq;
using LetsCreateNetworkGame.OpenGL.Library;

namespace LetsCreateNetworkGame.Server.Commands
{
    class ChangeGameRoomCommand : ICommand
    {
        public void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection, GameRoom gameRoom)
        {
            if (playerAndConnection != null)
            {
                //managerLogger.AddLogMessage("server", "Sending out new player position to all in group " + gameRoom.GameRoomId);
                var outmessage = server.NetServer.CreateMessage();
                outmessage.Write((byte)PacketType.ChangeGRoom);
                outmessage.Write(playerAndConnection.Player.Username);
                outmessage.Write(playerAndConnection.Player.point);
                outmessage.Write(gameRoom.GameRoomId);
                outmessage.WriteAllProperties(playerAndConnection.Player.Position);
                if (gameRoom.Players.Select(p => p.Connection).ToList().Count > 0)
                    server.NetServer.SendMessage(outmessage, gameRoom.Players.Select(p => p.Connection).ToList(),
                    NetDeliveryMethod.ReliableOrdered, 0);
            }
        }
    }
}
