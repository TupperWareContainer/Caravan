using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace CaravanEngine.UI{
    public class Canvas{
        public Transform Transform {get; set;}
        public int Layer { get => _layer; set => _layer = value; }

        private List<UIObject> _uiObjects; 
        private int _layer; 
        private string _name; 

        public Canvas(string name, int layer, Transform transform){
            _layer = layer;
            _name = name; 
            Transform = transform; 

        }

        public void Draw(SpriteBatch sb){
            for(int i = 0; i < _uiObjects.Count; i++){
                _uiObjects[i].Draw(sb);
            }
        }


        
    }
}