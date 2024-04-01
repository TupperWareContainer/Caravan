using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CaravanEngine;

namespace CaravanEngine{
    public struct Tilemap{
        public Texture2D TextureAtlas; 
        public float TileWidth; 
        public float TileHeight;

        public Tile[][] Tiles; //a 2d jagged array of tiles where each row represents a new tilemap

        public void LoadTilesFromFile(string fileName){
            //TODO: figure out how to parse tiles from file
        }


        public void Draw(SpriteBatch sb){
            for(int i = 0; i < Tiles.Length; i++){
                for(int j = 0; j < Tiles[i].Length; j++){
                    sb.Draw(TextureAtlas,new Vector2(Tiles[i][j].XOffset * TileWidth, Tiles[i][j].YOffset * TileHeight),Tiles[i][j].SpriteSheetRectangle,Color.White);
                }
            }
        }
    }
}