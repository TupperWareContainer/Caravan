using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace CaravanEngine.UI{
    public class UIHandler{
        private List<Canvas> _canvases; 

        public UIHandler(){
            _canvases = new List<Canvas>(); 
        }

        public void AddCanvas(Canvas canvas){
            _canvases.Add(canvas);
        }

        public void DrawCanvases(SpriteBatch spriteBatch){
            for(int i = 0; i < _canvases.Count; i++){
                _canvases[i].Draw(spriteBatch); 
            }
        }
    }
}