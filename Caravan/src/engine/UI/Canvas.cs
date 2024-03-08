using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CaravanEngine.UI{

    /// <summary>
    /// <h1>Canvas.cs</h1>
    /// <para>Canvases can be thought of as the containers for individual interfaces such as a menu or HUD</para>
    /// </summary>
    public class Canvas{
        public int Layer { get => _layer; set => _layer = value; }

        private List<UIObject> _uiObjects; 
        private int _layer; 
        private string _name; 

        public Canvas(string name, int layer){
            _layer = layer;
            _name = name; 
            _uiObjects = new List<UIObject>(); 

        }

        public void Draw(SpriteBatch sb){
            for(int i = 0; i < _uiObjects.Count; i++){
                _uiObjects[i].Draw(sb);
            }
        }

        public void Update(GameTime gt){
            for(int i = 0; i < _uiObjects.Count; i++){
                _uiObjects[i].Update(gt);
            }
        }

        public void AddObject(UIObject obj){
            _uiObjects.Add(obj); 
        }


        
    }
}