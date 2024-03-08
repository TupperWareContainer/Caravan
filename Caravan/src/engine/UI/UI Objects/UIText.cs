using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CaravanEngine.UI{

    public class UIText : UIObject{
        private SpriteFont _spriteFont; 
        private string _text; 
        private Color _color; 
        
        private Rectangle _bounds; 

        private bool _overflowText; 
        private bool _drawBoundingRectangle;
        
        public UIText(SpriteFont spriteFont, Transform transform, Canvas canvas, int layer) : base(transform,canvas,layer){
            _overflowText = false; 
            _spriteFont = spriteFont; 
            _text = ""; 
            _color = Color.White; 
            Vector2 spriteFontBounds = _spriteFont.MeasureString("a"); /// get dimensions of arbitrary character
            ///default bounding box has 255 character width and 32 character height
            _bounds = new Rectangle((int)transform.Position.X,(int)transform.Position.Y,(int)spriteFontBounds.X * 255, (int)spriteFontBounds.Y * 32);
            _drawBoundingRectangle = false;
        }
        public UIText(Transform transform, Canvas canvas, int layer) : base(transform,canvas,layer){
            _overflowText = false;
            _spriteFont = Assets.Default.Font; 
            _text = ""; 
            _color = Color.White; 
            Vector2 spriteFontBounds = _spriteFont.MeasureString("a"); /// get dimensions of arbitrary character
            ///default bounding box has 255 character width and 32 character height
            _bounds = new Rectangle((int)transform.Position.X,(int)transform.Position.Y,(int)spriteFontBounds.X * 255, (int)spriteFontBounds.Y * 32);
            _drawBoundingRectangle = false;
        }
        /// <summary>
        /// Returns a string that is properly truncated to fit within a given rectangle
        /// </summary>
        /// <param name="sf"></param> the spritefont to be used
        /// <param name="text"></param> the text to be wrapped
        /// <param name="rect"></param> the bounding rectangle
        /// <param name="wrap"></param> whether or not the text should be wrapped or truncated once it exceeds its vertical bounds

        /// <returns></returns>
        private string WrapString(SpriteFont sf, string text, Rectangle rect, bool wrap){
            string[] words = text.Split(" ");
            foreach(string str in words){
                Console.WriteLine(str);
            }
            string outString = "";
            float cLineWidth = 0; 
            float totalHeight = 0; 
            Vector2 spaceDimensions = sf.MeasureString(" "); 
            Console.WriteLine($"Space Dimensions:\nX: {spaceDimensions.X}\nY: {spaceDimensions.Y}\nRect Dimensions:\nWidth {rect.Width}\nHeight: {rect.Height}");
            Vector2 cWordDimensions; 
            string word;
            for (int i = 0; i < words.Length; i++){
                word = words[i];
                Console.WriteLine(word + "\nLine Width = " + cLineWidth + "\nText Height = " + totalHeight);
                cWordDimensions = sf.MeasureString(word);
                cWordDimensions.Floor(); 
                
                if(cLineWidth + cWordDimensions.X <= rect.Width){
                    outString += word + " ";
                    cLineWidth += cWordDimensions.X + spaceDimensions.X; 
                }
                else{
                    outString += "\n";
                    if (!wrap){
                        totalHeight += cWordDimensions.Y; 
                        if(totalHeight > rect.Height) break; 
                    }
                    if(totalHeight < rect.Height){
                        outString += word + " "; 
                        cLineWidth = cWordDimensions.X + spaceDimensions.X; 
                    } 
                    
                }

            }
            CaravanDebug.LogMessage($"Successfuly wrapped string \"{text}\"");
            CaravanDebug.LogMessage($"New String = \"{outString}\""); 
            return outString;

        }

        public override void Draw(SpriteBatch sb)
        {
            //CaravanDebug.LogMessage($"Drawing text object with text: {_text}");
            if(_drawBoundingRectangle) sb.Draw(Assets.Default.Texture,_bounds,_color);
            sb.DrawString(_spriteFont,_text,Transform.Position,_color,Transform.Rotation,Vector2.Zero,Transform.Scale,SpriteEffects.None,Layer);
        }

        public string Text { 
            get => _text; 
            set{
                _text = value;
                ResizeTextBoxBasedOnText(_text);
                _text = WrapString(_spriteFont,_text,_bounds,_overflowText);
            } 
        }
        private void ResizeTextBoxBasedOnText(string text){
            Vector2 bounds = _spriteFont.MeasureString(text); 
            _bounds.Width = (int)MathF.Ceiling(bounds.X); 
            _bounds.Height = (int)MathF.Ceiling(bounds.Y);
        }

        public void SetTextBoxBounds(int nCharX, int nCharY){
            Vector2 spriteFontBounds = _spriteFont.MeasureString("a"); /// get dimensions of arbitrary character
            _bounds.Width = (int)spriteFontBounds.X * nCharX; 
            _bounds.Height = (int)spriteFontBounds.Y * nCharY; 
        }
        public Color Color { get => _color; set => _color = value; }
        /// <summary>
        /// Determines whether the text should overflow past the text box, if false, lines outside of the textbox will not render 
        /// </summary>
        public bool OverflowText { get => _overflowText; set => _overflowText = value; }
        public Rectangle Bounds { get => _bounds; set => _bounds = value; }
        public bool DrawBoundingRectangle { get => _drawBoundingRectangle; set => _drawBoundingRectangle = value; }
    }

}