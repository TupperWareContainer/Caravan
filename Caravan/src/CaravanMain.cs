using CaravanEngine;
using CaravanEngine.Entities;
using CaravanEngine.Animation;
using CaravanEngine.UI; 
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

    private UIHandler _uiHandler; 

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

        _uiHandler = new UIHandler();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Assets.LoadAssets(Content); 


        _player.SpriteComponent.Sprite = Assets.Default.Texture;

        Entity e = _entityHandler.Create(new Vector2(200,200),"Test Entity", Content.Load<Texture2D>("TestAnimation-Sheet"));

        e.SpriteComponent.Animator.AddAnimation(new Animation(e.SpriteComponent.Sprite,32,32,1f,true),"default"); 

        Canvas canvas = new Canvas("Test Canvas",0); 


        UIImage image = new UIImage(new Vector2(0f,0f),new Vector2(32,32),Content.Load<Texture2D>("TestAnimation-Sheet"),canvas,0);

        UIText text = new UIText(new Transform(new Vector2(0f, 0f), new Vector2(1f, 1f), 0f), canvas, 0);


        text.Text = "This is a test of the new UI Text object, I hope it works!";
        text.DrawBoundingRectangle = true; 
        canvas.AddObject(image); 

        canvas.AddObject(text);

        _uiHandler.AddCanvas(canvas); 



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
        _entityHandler.Update(gameTime);

        _uiHandler.Update(gameTime); 
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(); 

        _player.Draw(_spriteBatch); 
        _entityHandler.Draw(_spriteBatch);

        _uiHandler.DrawCanvases(_spriteBatch);

        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
