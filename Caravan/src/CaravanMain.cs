using CaravanEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using nkast.Aether.Physics2D.Dynamics;

namespace Caravan;

public class CaravanMain : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private EntityHandler _entityHandler;

    private Player _player; 

    private MouseState _prevMouseState;
    private KeyboardState _prevKeyboardState;
    public CaravanMain()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Physics.WorldInstance = new World();      
        _player = new Player(new Vector2(200,400));   
        _entityHandler = new EntityHandler();  

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _player.SpriteComponent.Sprite = Content.Load<Texture2D>("MissingTexture"); 

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {        
        CaravanDebug.Timestamp = (float)gameTime.TotalGameTime.TotalSeconds; 
        if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if(Mouse.GetState().LeftButton == ButtonState.Pressed && _prevMouseState.LeftButton == ButtonState.Released){
            _entityHandler.Create(Mouse.GetState().Position.ToVector2(),$"Entity{_entityHandler.Size}",_player.SpriteComponent.Sprite); 
        }
        if(Keyboard.GetState().IsKeyDown(Keys.Q) && _prevKeyboardState.IsKeyUp(Keys.Q)){
            _entityHandler.RemoveLast(); 
        }

        // TODO: Add your update logic here
        bool up = Keyboard.GetState().IsKeyDown(Keys.W); 
        bool down = Keyboard.GetState().IsKeyDown(Keys.S); 
        bool left = Keyboard.GetState().IsKeyDown(Keys.A); 
        bool right = Keyboard.GetState().IsKeyDown(Keys.D); 

        _player.MovePlayer(up,down,left,right);

        Physics.WorldInstance.Step((float)gameTime.ElapsedGameTime.TotalSeconds);

        _player.Update(gameTime);
        base.Update(gameTime);
        _prevMouseState = Mouse.GetState(); 
        _prevKeyboardState = Keyboard.GetState(); 
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(); 

        _player.Draw(_spriteBatch); 
        _entityHandler.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
