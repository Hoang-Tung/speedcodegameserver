//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System;

namespace LetsCreateNetworkGame.OpenGL.Library.AI.Movement
{
    public class BlockMovement : BaseMovement
    {

        private double _frequency;
        private double _count;
        private Direction _direction;
        private Random _rnd;

        public BlockMovement(Position position) : base(position)   // ramdom huong di chuyen cua enemy
        {
            _frequency = 200;
            _count = 0;
            _rnd = new Random();
            _direction = (Direction)_rnd.Next(0, 3);
            Speed = 0;
        }

        public override void Update(double gameTime) // hien thi
        {
            _count += gameTime;
            if (_count > _frequency)
            {
                _direction = (Direction)_rnd.Next(0, 3);
                _count = 0;
            }

            switch (_direction)
            {
                case Direction.Left:
                    Position.XPosition -= Speed;
                    if (Position.XPosition < 0)
                        Position.XPosition = 0;
                    break;
                case Direction.Right:
                    Position.XPosition += Speed;
                    if (Position.XPosition > 800)
                        Position.XPosition = 800;
                    break;
                case Direction.Up:
                    Position.YPosition -= Speed;
                    if (Position.YPosition < 0)
                        Position.YPosition = 0;
                    break;
                case Direction.Down:
                    Position.YPosition += Speed;
                    if (Position.YPosition > 480)
                        Position.YPosition = 480;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
