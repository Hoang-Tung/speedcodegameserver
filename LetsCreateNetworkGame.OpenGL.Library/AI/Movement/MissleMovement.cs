using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCreateNetworkGame.OpenGL.Library.AI.Movement
{
    public class MissleMovement : BaseMovement
    {
        private Direction direction { get; set; }                    

        public MissleMovement(Position position, Direction direction) : base(position) // tốc độ bay
        {
            this.direction = direction;
            Speed = 5;
        }

        public override void Update(double gameTime)  // xử lý đường bay tốc độ bay của đạn
        {
            switch (direction)
            {
                case Direction.Left:
                    Position.XPosition -= Speed;
                    //if (Position.XPosition < 0)
                    //    Position.XPosition = 0;
                    break;
                case Direction.Right:
                    Position.XPosition += Speed;
                    //if (Position.XPosition > 800)
                    //    Position.XPosition = 800;
                    break;
                case Direction.Up:                                        
                    Position.YPosition -= Speed;
                    //if (Position.YPosition < 0)
                    //    Position.YPosition = 0;
                    break;
                case Direction.Down:
                    Position.YPosition += Speed;
                    //if (Position.YPosition > 480)
                    //    Position.YPosition = 480;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
