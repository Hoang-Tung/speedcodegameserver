//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------
using System;
using System.Collections.Generic;
using LetsCreateNetworkGame.OpenGL.Library;
using LetsCreateNetworkGame.Server.Managers;
using Lidgren.Network;
using Microsoft.Xna.Framework;

namespace LetsCreateNetworkGame.Server.Commands
{
    class LoginCommand : ICommand
    {
        public void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection, GameRoom gameRoom)
        {
            managerLogger.AddLogMessage("server", "New connection...");
            var data = inc.ReadByte();
            if (data == (byte)PacketType.Login)
            {
                inc.SenderConnection.Approve();
                managerLogger.AddLogMessage("server", "..connection accpeted.");
                playerAndConnection = CreatePlayer(inc, gameRoom.Players, gameRoom.ManagerCamera, gameRoom);
                var outmsg = server.NetServer.CreateMessage();
                outmsg.Write((byte)PacketType.Login);
                outmsg.Write(gameRoom.Players.Count);
                for (int n = 0; n < gameRoom.Players.Count; n++)
                {
                    var p = gameRoom.Players[n];
                    outmsg.Write(p.Player.Username);
                    outmsg.WriteAllProperties(p.Player.Position);
                }
                server.NetServer.SendMessage(outmsg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
                var command = new PlayerPositionCommand();
                command.Run(managerLogger, server, inc, playerAndConnection, gameRoom);
                server.SendNewPlayerEvent(playerAndConnection.Player.Username, gameRoom.GameRoomId);
            }
            else
            {
                inc.SenderConnection.Deny("Didn't send correct information.");
            }
        }

        private PlayerAndConnection CreatePlayer(NetIncomingMessage inc, List<PlayerAndConnection> players, ManagerCamera managerCamera, GameRoom gameRoom)        {
            var random = new Random();
            Position position;
            do
            {
                position = new Position { XPosition = random.Next(0, 750), YPosition = random.Next(0, 420) };
            } while (ManagerCollision.CheckCollisionObstacle(
                    new Rectangle(position.XPosition, position.YPosition, 32, 32),
                    "new_player", gameRoom.Obstacles));
            var player = new Player
            {
                Username = inc.ReadString(),
                Position = position
            };
            var playerVectorPosition = new Vector2(player.Position.XPosition, player.Position.YPosition);
            var screenPosition = managerCamera.WorldToScreenPosition(playerVectorPosition);
            player.Position.ScreenXPosition = (int) screenPosition.X;
            player.Position.ScreenYPosition = (int) screenPosition.Y;
            player.Position.Visible = managerCamera.InScreenCheck(playerVectorPosition);
            var playerAndConnection = new PlayerAndConnection(player, inc.SenderConnection);
            players.Add(playerAndConnection);
            return playerAndConnection;
        }

    }
}
