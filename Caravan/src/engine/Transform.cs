using Microsoft.Xna.Framework;

namespace CaravanEngine{
    public struct Transform{
        public Vector2 Position; 
        public Vector2 Scale;
        public float   Rotation;

        public Transform(){
            Position = new Vector2(0f,0f); 
            Scale = new Vector2(1f,1f); 
            Rotation = 0f;
        }
        public Transform(Vector2 position, Vector2 scale, float rotation){
            Position = position; 
            Scale = scale; 
            Rotation = rotation;
        }
    }




}