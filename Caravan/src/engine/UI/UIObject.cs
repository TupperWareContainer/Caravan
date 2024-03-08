using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CaravanEngine.UI{
    /// <summary>
    /// <h1>UIObject.cs</h1>
    /// <para>Abstract class for implimenting a UI element, this could be anything from a button to a slider.</para>
    /// <para>UIObjects are the bottom element of the User Interface hierarchy.</para>  
    /// </summary>
    public abstract class UIObject{
        private Transform _transform; 
        private Canvas _canvas;
        private int _layer; 

        private Texture2D _texture;

        public UIObject(Transform transform, Canvas canvas, int layer){
            _transform = transform; 
            _canvas = canvas;
            _layer = layer;
        }

        public virtual Transform Transform { get => _transform; set => _transform = value; }
        public Canvas Canvas { get => _canvas; set => _canvas = value; }
        public int Layer { get => _layer + _canvas.Layer; set => _layer = value; }
        public virtual Texture2D Texture { get => _texture; set => _texture = value; }

        public abstract void Draw(SpriteBatch sb);
        public virtual void Update(GameTime gt) {} 

    }
}