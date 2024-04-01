using Microsoft.Xna.Framework.Graphics;
using CaravanEngine;
using Microsoft.Xna.Framework;
namespace CaravanEngine{
    public struct Tile{
        public int XOffset; 
        public int YOffset;

        public Rectangle SpriteSheetRectangle;

        public Tile(int xOffset, int yOffset, Rectangle spriteSheetRectangle)
        {
            XOffset = xOffset;
            YOffset = yOffset;
            SpriteSheetRectangle = spriteSheetRectangle;
        }

        public static Rectangle GenerateRectangle(int xOffset, int yOffset, float spriteWidth, float spriteHeight){
            return new Rectangle((int)spriteWidth * xOffset, (int)spriteHeight * yOffset, (int)spriteWidth, (int)spriteHeight); 
        }
    }
}