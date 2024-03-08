using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CaravanEngine.UI{
    public class UIImage : UIObject{
        
        private Rectangle _rectangleTransform;
        public override Transform Transform 
        { 
            get => base.Transform; 

            set{
                base.Transform = value; 
                _rectangleTransform.X = (int)value.Position.X; 
                _rectangleTransform.Y = (int)value.Position.Y;
            }
        }
        /// <summary>
        /// Create a UI Image by manually passing in a bounding rectangle
        /// </summary>
        /// <param name="rectangle"></param> the bounding rectangle 
        /// <param name="texture"></param>   the image to be rendered
        /// <param name="canvas"></param>    the host canvas
        /// <param name="layer"></param>     the render layer
        public UIImage(Rectangle rectangle, Texture2D texture, Canvas canvas, int layer = 0) : base (new Transform(new Vector2(rectangle.X,rectangle.Y),Vector2.One,0f),canvas,layer){
            _rectangleTransform = rectangle;
            Texture = texture; 
        }

        public UIImage(Vector2 centerPosition, Vector2 extents, Texture2D texture, Canvas canvas, int layer) : base(new Transform(centerPosition,Vector2.One,0f), canvas,layer){
            _rectangleTransform.X = (int)centerPosition.X; 
            _rectangleTransform.Y = (int)centerPosition.Y; 
            _rectangleTransform.Width = (int)extents.X; 
            _rectangleTransform.Height = (int)extents.Y;
            Texture = texture;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture,_rectangleTransform,null,Color.White,this.Transform.Rotation,Transform.Position,SpriteEffects.None,Layer);
        }
    }
}