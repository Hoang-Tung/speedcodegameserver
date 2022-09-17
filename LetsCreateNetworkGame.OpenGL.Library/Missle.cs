using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreateNetworkGame.OpenGL.Library.AI.Movement;

namespace LetsCreateNetworkGame.OpenGL.Library


{
    public class Missle : Entity
    {
        public int MissleId { get; set; }

        public int UniqueId { get; set; }

        public Direction direction { get; set; }

        public BaseMovement BaseMovement { get; set; }

        public Missle(int missleId, Position position, Direction direction)  :base(position)
        {
            MissleId = missleId;
            base.Position = position;
            UniqueId = new Random().Next(0, 90000);
            this.direction = direction;
            BaseMovement = new MissleMovement(position, direction);
        }

        public Missle()
        {
            base.Position = new Position();
        }

        public override void Update(double gameTime)
        {
            BaseMovement.Update(gameTime);
        }
    }
}
