using CaravanEngine;
using CaravanEngine.Entities;
using CaravanEngine.Animation;
using CaravanEngine.UI; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using nkast.Aether.Physics2D.Dynamics;
using Caravan;
/// @TODO: Impliment game pipeline 
namespace CaravanEngine{
    public static class CaravanPipeline{
        private static Game _gameInstance; 
        private static SpriteBatch _spriteBatch;
        private static EntityHandler _entityHandler;
    
        private static UIHandler _uiHandler; 
    
        public static void Init(Game game){
            _gameInstance = game; 
            Physics.WorldInstance = new World();      

            _entityHandler = new EntityHandler(); 
            _uiHandler = new UIHandler();
            Player.CreatePlayerInstance(300,300);
 
        }

        public static void LoadContent(){
            _spriteBatch = new SpriteBatch(_gameInstance.GraphicsDevice); 

            Assets.LoadAssets(_gameInstance.Content); // load default assets
            /// TODO: level asset loading
            Player.PlayerInstance.SpriteComponent.Sprite = Assets.Default.Texture; 
            
        }

    }
}   