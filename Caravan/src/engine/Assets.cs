using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CaravanEngine{
    public static class Assets{
        public struct Default{
            public static SpriteFont Font; 
            public static Texture2D Texture; 
        }

        public static void LoadAssets(ContentManager contentManager){
            Default.Font = contentManager.Load<SpriteFont>("DebugFont");
            Default.Texture = contentManager.Load<Texture2D>("MissingTexture"); 
        }




    }
}