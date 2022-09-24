//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System;
using System.Linq;
using LetsCreateNetworkGame.OpenGL.Library;
using LetsCreateNetworkGame.Server.Managers;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LetsCreateNetworkGame.Server.Commands
{
    class InputCommand : ICommand
    {
        public void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection, GameRoom gameRoom)
        {
            managerLogger.AddLogMessage("server", "Received new input");
            var key = (Keys)inc.ReadByte();
            var name = inc.ReadString();
            playerAndConnection = gameRoom.Players.FirstOrDefault(p => p.Player.Username == name);
            if (playerAndConnection == null)
            {
                managerLogger.AddLogMessage("server", string.Format("Could not find player with name {0}", name));
                return;
            }

            int x = 0;
            int y = 0; 

            switch (key)
            {
                case Keys.Down:
                    y++;
                    playerAndConnection.Player.direction = OpenGL.Library.Direction.Down;
                    break;

                case Keys.Up:
                    y--;
                    playerAndConnection.Player.direction = OpenGL.Library.Direction.Up;
                    break;

                case Keys.Left:
                    x--;
                    playerAndConnection.Player.direction = OpenGL.Library.Direction.Left;
                    break;

                case Keys.Right:
                    x++;
                    playerAndConnection.Player.direction = OpenGL.Library.Direction.Right;
                    break;

                case Keys.A:
                    Position post = new Position(playerAndConnection.Player.Position.XPosition ,
                        playerAndConnection.Player.Position.YPosition,
                        playerAndConnection.Player.Position.ScreenXPosition,
                        playerAndConnection.Player.Position.ScreenYPosition,
                        playerAndConnection.Player.Position.Visible);
                    gameRoom.AddMissle(post,
                        playerAndConnection.Player.direction,
                        playerAndConnection.Player.Username);
                    break;
                default:
                    break;
            }
           
            var player = playerAndConnection.Player;
            var position = playerAndConnection.Player.Position;

            if (ManagerCollision.CheckCollisionWithEnemies(new Rectangle(position.XPosition + x, position.YPosition + y, 32, 32),
                gameRoom.Enemies))
            {
                managerLogger.AddLogMessage("server", string.Format("collied with enemy", name));
                server.KickPlayer(playerAndConnection.Player.Username, gameRoom.GameRoomId);

            }
          
             for(int i = 0; i < gameRoom.Enemies.Count; i++) {
               
                if (ManagerCollision.CkeckCollisionMissleAndEnemy(new Rectangle(gameRoom.Enemies[i].Position.XPosition, gameRoom.Enemies[i].Position.YPosition , 32, 32),
                     gameRoom.Missles))
                {
                    managerLogger.AddLogMessage("server", string.Format("collied with Missle", name));
                    playerAndConnection.Player.point += 10;
                    server.KickEnemy(gameRoom.Enemies[i].UniqueId, gameRoom.GameRoomId);
                    gameRoom.Enemies.RemoveAt(i);
                }
             }
             

            if (!ManagerCollision.CheckCollision(
                new Rectangle(position.XPosition + x, position.YPosition + y, 32, 32),
                player.Username, gameRoom.Players.Select(p => p.Player).ToList())
                &&
                !ManagerCollision.CheckCollisionObstacle(
                    new Rectangle(position.XPosition + x, position.YPosition + y, 32, 32),
                    player.Username, gameRoom.Obstacles)
                )
            {
                position.XPosition += x;
                position.YPosition += y;

                position.Visible = gameRoom.ManagerCamera.InScreenCheck(new Vector2(position.XPosition, position.YPosition));
                if (position.Visible)
                {
                    var screenPosition =
                        gameRoom.ManagerCamera.WorldToScreenPosition(new Vector2(position.XPosition, position.YPosition));
                    position.ScreenXPosition = (int)screenPosition.X;
                    position.ScreenYPosition = (int)screenPosition.Y;
                }
                else
                {
                    position.XPosition -= x;
                    position.YPosition -= y;
                    return;
                }
                    
                var command = new PlayerPositionCommand();
                command.Run(managerLogger, server, inc, playerAndConnection, gameRoom);
                
                
            }
        }
    }
}
