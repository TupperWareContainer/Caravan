using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using nkast.Aether.Physics2D.Dynamics;

namespace CaravanEngine.Entities{
    public class Entity{
        private Transform _transform; 

        public Transform Transform {get => _transform; set => _transform = value;}
        public SpriteComponent SpriteComponent { get => _spriteComponent; set => _spriteComponent = value; }

        public Body Rigidbody {get=> _rb; set=> _rb = value;}
        public string Name { get => _name; set => _name = value; }

        private List<EntityComponent> _components; 

        private SpriteComponent _spriteComponent;

        private Body _rb = null; 

        private string _name; 

        public Entity(Vector2 position){
            _transform = new Transform(); 

            _transform.Position = position; 

            _components = new List<EntityComponent>();

            _name = "Empty"; 

            _spriteComponent = new SpriteComponent(); 
        }
        public Entity(Vector2 position, string name){
            _transform = new Transform(); 

            _transform.Position = position; 

            _components = new List<EntityComponent>();

            _name = name;

            _spriteComponent = new SpriteComponent(); 
        }


        public void Update(GameTime gameTime){
            if(_rb != null){
                _transform.Position = _rb.Position; 
                _transform.Rotation = _rb.Rotation; 
                //Console.WriteLine($"rb velocity: L:{_rb.LinearVelocity.Length()}, X: {_rb.LinearVelocity.X}, Y: {_rb.LinearVelocity.Y}\nrb position: {_rb.Position.X}, {_rb.Position.Y}\n");
            }
            for(int i = 0; i < _components.Count; i++){
                _components[i].InvokeComponent(this,gameTime);
            }
            _spriteComponent.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch){
            if(_spriteComponent.Sprite != null) _spriteComponent.Draw(spriteBatch,_transform);
        }


        public void AddComponent(EntityComponent component){
            
            if(component.GetType() == typeof(SpriteComponent)){
                //Console.WriteLine($"Attempted to add sprite component to entity {_name} ({GetHashCode()}), please modify SpriteComponent field directly via Entity.SpriteComponent!"); 
                SpriteComponent = (SpriteComponent)component; 
                return;
            }
            _components.Add(component);
        }
        public void AddComponent(Body rigidbody){
            if(_rb != null) return; 
            _rb = rigidbody;
            // _rb.Position = Transform.Position; 
            // _rb.Rotation = Transform.Rotation;
            Console.WriteLine("Rigidbody Added"); 

            //Physics.WorldInstance.Add(_rb); 
        }
        
        public EntityComponent GetComponent(Type t){
            for(int i = 0; i < _components.Count; i++){
                if(_components[i].GetType() == t){
                    return _components[i]; 
                }
            }
            return null;
        }
    }
}