using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CaravanEngine{
    public class SpriteComponent : EntityComponent{
        private Texture2D _sprite; 
        private Color _color;
        private SpriteEffects _spriteEffects;

        private Animator _animator;
        private float _layer; 

        public SpriteComponent(){
            _sprite = null;
            _color = Color.White; 
            _spriteEffects = SpriteEffects.None; 
            _layer = 0; 
            _animator = new Animator();
        }

        public SpriteComponent(Texture2D sprite){
            _sprite = sprite; 
            _color = Color.White; 
            _spriteEffects = SpriteEffects.None; 
            _layer = 0; 
            _animator = new Animator();

        }
        public SpriteComponent(Texture2D sprite, Color color, SpriteEffects spriteEffects, float layer){
            _sprite = sprite; 
            _color = color; 
            _spriteEffects = spriteEffects;
            _layer = layer; 
            _animator = new Animator();

        }

        public void Draw(SpriteBatch sb,Transform transform)
        {
            if(_animator.IsEmpty()) sb.Draw(_sprite,transform.Position,Color.White); 
            else{
                Rectangle rect = _animator.GetCurrentAnimation().GetCurrentFrame(); 
                //sb.Draw(_sprite,transform.Position,Color.White);

                sb.Draw(_sprite,transform.Position,rect,Color.White); 
            }
        }

        public void Update(GameTime gt){
            if(_animator.IsEmpty()) return; 
            _animator.Update(gt);
        }

        public Texture2D Sprite { get => _sprite; set => _sprite = value; }
        public Color Color { get => _color; set => _color = value; }
        public SpriteEffects SpriteEffects { get => _spriteEffects; set => _spriteEffects = value; }
        public float Layer { get => _layer; set => _layer = value; }
        public Animator Animator { get => _animator; set => _animator = value; }
    }
}