using Microsoft.Xna.Framework;
using nkast.Aether.Physics2D.Dynamics;
using CaravanEngine;

namespace Caravan{
    public class Player : Entity{

        private const float baseMoveSpeed = 100f;

        private float _moveSpeed;  
        private float _moveSpeedMod = 1f; 

        private Vector2 _cVelocity; 
        public Player(Vector2 position) : base(position, "Player"){
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


    }
}