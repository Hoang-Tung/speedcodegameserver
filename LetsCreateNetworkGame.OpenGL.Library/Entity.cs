//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

namespace LetsCreateNetworkGame.OpenGL.Library
{
    public class Entity
    {
        public Position Position { get; set; }

        public bool isHidden { get; set; }

        public Entity(Position position)
        {
            Position = position;
            isHidden = false;
        }

        public Entity() 
        { 
            isHidden = false;
        }

        public virtual void Update(double gameTime)
        {
            
        }
    }
}
