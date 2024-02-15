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

            CaravanDebug.LogMessage($"Creating animation from sprite sheet {spriteSheet.Name}\nFrame count = {numRectangles}\nFPS: {_fps}");


            _frames = new Rectangle[numRectangles]; 
            //_frames[0] = new Rectangle(0,0,frameWidth,frameHeight);
            for(int i = 0; i < numRectangles; i++){
                _frames[i] = new Rectangle(frameWidth * i,0,frameWidth,frameHeight);
            }
            _cFrameIndex = 0; 
            _cFrame = _frames[0]; 
        }

        public void Update(GameTime gameTime){
            if(_finished) return;
            if(_timer >= _duration && !_repeating) _finished = true; 
            else if(_timer >= _duration){
                ResetAnimation();
                CaravanDebug.LogMessage("Resetting animation frame");
            } 

            if(_timer % _fps == 0 && _cFrameIndex + 1 <_frames.Length){
                _cFrameIndex++;
                _cFrame = _frames[_cFrameIndex]; 
                CaravanDebug.LogMessage("Changing animation frame");
            }
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds; 


        }
        public Rectangle GetCurrentFrame(){
            return _cFrame; 
        }

        public void ResetAnimation(){
            _timer = 0; 
            _cFrame = _frames[0];
            _cFrameIndex = 0; 
            _finished = false;
        }

        public bool IsFinished(){
            return _finished;
        }
    }
}