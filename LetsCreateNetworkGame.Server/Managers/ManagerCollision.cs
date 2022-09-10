//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------
using System.Collections.Generic;
using LetsCreateNetworkGame.OpenGL.Library;
using Microsoft.Xna.Framework;

namespace LetsCreateNetworkGame.Server.Managers
{
    class ManagerCollision
    {
        public static bool CheckCollision(Rectangle rec, string username, List<Player> players)
        {
            foreach (var player in players)
            {
                if (player.Username != username)
                {
                    var playerRec = new Rectangle(player.Position.XPosition, player.Position.YPosition, 32, 32);
                    if (playerRec.Intersects(rec))
                    {
                        return true; 
                    }
                }
            }
            return false; 
        }

        public static bool CheckCollisionWithEnemies(Rectangle rec, List<Enemy> enemies)
        {
            foreach(var enemy in enemies)
            {
                var EnemyRec = new Rectangle(enemy.Position.XPosition, enemy.Position.YPosition, 32, 32);
                if(EnemyRec.Intersects(rec))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
