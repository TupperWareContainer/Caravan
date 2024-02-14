using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace CaravanEngine{
    /// <summary>
    /// Animation.cs
    /// Animations are created from spritesheets, with each frame being generated horizontally
    /// </summary>
    public class Animation{
        private Texture2D _spriteSheet;
        private Rectangle[] _frames; 

        private float _duration;

        private float _timer; 

        private float _fps;

        private int _cFrameIndex;

        private Rectangle _cFrame;  

        private bool _repeating;

        private bool _finished; 


        public Animation(Texture2D spriteSheet, int frameWidth, int frameHeight, float duration, bool repeating){
            _repeating = repeating; 
            _finished = false;
            int numRectangles = spriteSheet.Width / frameWidth; 

            _spriteSheet = spriteSheet;

            _duration = duration; 
            _timer = 0; 

            _fps = _duration / numRectangles;

            _frames = new Rectangle[numRectangles]; 

            for(int i = 1; i <= numRectangles; i++){
                _frames[i-1] = new Rectangle((frameWidth * i) - spriteSheet.Width,frameHeight,frameWidth,frameHeight);
            }
            _cFrameIndex = 0; 
            _cFrame = _frames[0]; 
        }

        public void Update(GameTime gameTime){
            if(_finished) return;
            if(_timer >= _duration && !_repeating) _finished = true; 
            else if(_timer >= _duration) _timer = 0;

            if(_timer % _fps == 0 && _cFrameIndex + 1 <_frames.Length){
                _cFrameIndex++;
                _cFrame = _frames[_cFrameIndex]; 
            }
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds; 

        }
        public Rectangle GetCurrentFrame(){
            return _cFrame; 
        }

        public void ResetAnimation(){
            _timer = 0; 
            _cFrame = _frames[0]; 
            _finished = false;
        }

        public bool IsFinished(){
            return _finished;
        }
    }
}