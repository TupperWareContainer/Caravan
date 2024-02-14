using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CaravanEngine{
    public abstract class EntityComponent{

        public virtual void InvokeComponent(Entity e, GameTime gameTime) {} 

        public virtual void Draw(SpriteBatch sb) {}

    }
}