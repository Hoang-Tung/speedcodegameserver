//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System;
using LetsCreateNetworkGame.OpenGL.Library.AI.Movement;

namespace LetsCreateNetworkGame.OpenGL.Library
{
    public class Obstacle : Entity
    {
        public int ObstacleId { get; set; }

        public int UniqueId { get; set; }

        public BaseMovement BaseMovement { get; set; }

        public Obstacle(int blockId, Position position)             //ramdom
            : base(position)
        {
            ObstacleId = blockId;
            UniqueId = new Random().Next(0, 90000);
            BaseMovement = new BlockMovement(position);
        }

        public Obstacle()
        {
            Position = new Position(); // khoi tao enymy
        }

        public override void Update(double gameTime)
        {
            BaseMovement.Update(gameTime);         // update
        }
    }
}
