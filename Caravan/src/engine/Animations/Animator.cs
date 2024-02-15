using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace CaravanEngine{
    public class Animator{
       
        private Dictionary<string,Animation> _animations;

        private Animation _default; 

        private Animation _current; 

        public Animator(){
            _animations = new Dictionary<string, Animation>(); 
        }

        public void AddAnimation(Animation animation, string tag){
            bool success = _animations.TryAdd<string,Animation>(tag,animation); 
            if(!success) CaravanDebug.LogMessage("WARNING::ANIMATOR::COULD NOT ADD ANIMATION");
            if(_default == null) _default = animation; 
            if(_current == null) _current = animation;
        }

        public void SetDefaultAnimation(string tag){
            _default = GetAnimationByTag(tag); 
        }

        public Animation GetAnimationByTag(string tag){
            if(!_animations.ContainsKey(tag)) return null; 
            
            return _animations[tag]; 
        }

        public bool SetCurrentAnimation(string tag){

            if(!_animations.ContainsKey(tag)) return false;

            _current.ResetAnimation(); 

            _current = _animations[tag]; 

            if(_current != null)return true; 
            else{
                _current = _default; 
                CaravanDebug.LogMessage("ERROR::ANIMATOR::FAILED TO FIND ANIMATION WITH TAG \"" + tag + "\""); 
                return false; 
            }

        }

        public void Update(GameTime gt){
            if(_current.IsFinished()){
                _current.ResetAnimation();
                _current = _default;
            }
            _current.Update(gt);
        }

        public Animation GetCurrentAnimation(){
            return _current;
        }

        public bool IsEmpty(){
            return _animations.Count <= 0; 
        }
    }
}