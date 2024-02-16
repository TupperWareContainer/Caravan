using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CaravanEngine.UI{
    public abstract class UIObject{
        private Transform _localTransform; 
        private Canvas _canvas;
        private int _layer; 

        public UIObject(Transform transform, Canvas canvas, int layer){
            _localTransform = transform; 
            _canvas = canvas;
            _layer = layer;
        }

        public Transform LocalTransform { get => _localTransform; set => _localTransform = value; }
        public Canvas Canvas { get => _canvas; set => _canvas = value; }
        public int Layer { get => _layer; set => _layer = value; }

        public abstract void Draw(SpriteBatch sb);
        public abstract void Update(GameTime gt); 

    }
}