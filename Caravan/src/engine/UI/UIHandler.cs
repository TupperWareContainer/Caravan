using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CaravanEngine.UI{
/// <summary>
/// <h1>UIHandler.cs</h1>
/// <para>Responsible for managing the games different UI canvases.</para>
/// <para>Essentially a wrapper class for a list object.</para>
/// </summary>
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

        public void Update(GameTime gt){
            for(int i = 0; i < _canvases.Count; i++){
                _canvases[i].Update(gt);
            }
        }
    }
}