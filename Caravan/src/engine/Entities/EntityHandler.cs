using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CaravanEngine{
    public class EntityHandler{
        class EntityNode{
            public Entity E;
            public EntityNode Next;
            public EntityNode Prev;
            public EntityNode(Entity e){
                E = e; 
                Next = null; 
                Prev = null;
            }

        }

        private EntityNode _head;
        private EntityNode _tail; 
        private int _size;

        public int Size { get => _size; set => _size = value; }

        public EntityHandler(){
            _head = null; 
            _tail = null;
            _size = 0; 
        } 

        public void Draw(SpriteBatch sb){
            EntityNode current = _head;
            for(int i = 0; i < _size; i++){
                current.E.Draw(sb); 
                current = current.Next; 
            }
        }

        public void Add(Entity entity){
            EntityNode node = new EntityNode(entity);
            if(_head == null){
                _head = node; 
                _size++;
                return; 
            }
            else if(_tail == null){
                _tail = node; 
                _head.Next = _tail; 
                _tail.Prev = _head; 
                _size++;
                return;
            }
            else{
                _tail.Next = node; 
                node.Prev = _tail; 
                _tail = node; 
                _size++; 
                return; 
            }
        }
        public Entity Create(Vector2 position, string name, Texture2D sprite){
            Entity e = new Entity(position,name); 
            Add(e); 
            e.SpriteComponent.Sprite = sprite;
            return e; 
        }

        public Entity RemoveLast(){
            Entity outEntity = null; 
            if(_tail == null && _head == null) return null;
            else if(_tail == null){
                CaravanDebug.LogMessage("Removing head node: " + _head.GetHashCode());

                outEntity = _head.E; 
                _head = null; 
                _size--; 
                
                return outEntity;
            }
            else{
                outEntity = _tail.E; 
                CaravanDebug.LogMessage("Removing tail node: " + _tail.GetHashCode());

                _tail.Prev.Next = null; 
                if(_tail.Prev == _head) _tail = null; 
                else _tail = _tail.Prev; 
                _size--; 
                return outEntity;

            }
        }
        public Entity Remove(string name){
            EntityNode current = _head; 
            if(_head.E.Name.Equals(name)){
                Entity e = _head.E; 
                CaravanDebug.LogMessage("Removing head node: " + _head.GetHashCode());

                if(_head.Next == null) _head = null; 
                else if(_head.Next == _tail){
                    _tail.Prev = null; 
                    _head = _tail; 
                    _tail = null; 
                }
                else{
                    _head.Next.Prev = null; 
                    _head = _head.Next; 
                }
                _size --;
                return e; 

            }
            else if(_tail.E.Name.Equals(name)) return RemoveLast();  

            for(int i = 0; i < _size; i++){
                current = current.Next; 
                if(current.E.Name.Equals(name)){
                    Entity e = current.E; 
                    CaravanDebug.LogMessage("Removing node: " + current.GetHashCode());

                    current.Prev.Next = current.Next; 
                    current.Next.Prev = current.Prev;
                    _size --;
                    return e;
                }
            }
            return null;
        }
    }
}