//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

namespace LetsCreateNetworkGame.OpenGL.Library
{
    public class Player : Entity
    {
        public string Username { get; set; }
        public Direction direction { get; set; }

        public int point { get; set; }
        public Player(string username, Position position)
            :base(position)
        {
            Username = username;
            point = 0;
        }

        public Player()
        {
            Position = new Position();
            point = 0;
        }

    }
}
