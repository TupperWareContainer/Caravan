using Microsoft.Xna.Framework;
using nkast.Aether.Physics2D.Dynamics;
using CaravanEngine;
using CaravanEngine.Entities;

namespace Caravan{
    public class Player : Entity{
        public static Player PlayerInstance; 
        private const float baseMoveSpeed = 100f;

        private float _moveSpeed;  
        private float _moveSpeedMod = 1f; 

        private Vector2 _cVelocity; 
        /// <summary>
        /// Creates a player singleton that is globally accessable through the static PlayerInstance field
        /// </summary>
        /// <param name="position"></param> the position of the player
        /// <returns><para>The player instance (if singleton is null)</para><para>null (if singleton is not null)</para></returns>
        public static Player CreatePlayerInstance(Vector2 position){
            if(PlayerInstance == null){
                Player p = new Player(position); 
                PlayerInstance = p; 
                return p; 
            }
            else return null; 

        }
         /// <summary>
        /// Creates a player singleton that is globally accessable through the static PlayerInstance field
        /// </summary>
        /// <param name="pX"></param> the X position of the player
        /// <param name="pY"></param> the Y position of the player
        /// <returns><para>The player instance (if singleton is null)</para><para>null (if singleton is not null)</para></returns>
        public static Player CreatePlayerInstance(float pX, float pY){
            if(PlayerInstance == null){
                Player p = new Player(new Vector2(pX,pY)); 
                PlayerInstance = p; 
                return p; 
            }
            else return null; 
        }

        private Player(Vector2 position) : base(position, "Player"){
            Rigidbody = Physics.WorldInstance.CreateBody(position,0f,BodyType.Kinematic); 
            _moveSpeed = baseMoveSpeed; 
            _cVelocity = new Vector2(0f,0f);

        }

        public void MovePlayer(bool up, bool down, bool left, bool right){
            if(up){
                _cVelocity.Y =  -1f; 
            }
            else if(down){
                _cVelocity.Y = 1f;
            }
            else{
                _cVelocity.Y = 0f; 
            }

            if(left){
                _cVelocity.X = -1f; 
            }
            else if (right){
                _cVelocity.X = 1f;
            }
            else{
                _cVelocity.X = 0f;
            }

            if(_cVelocity.X !=0f && _cVelocity.Y != 0f) _cVelocity.Normalize();
            _cVelocity *= _moveSpeed * _moveSpeedMod; 

            Rigidbody.LinearVelocity = _cVelocity;

        }

        public void SetPosition(Vector2 position){
            Rigidbody.Position = position;
        }


    }
}