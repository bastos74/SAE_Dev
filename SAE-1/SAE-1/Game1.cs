using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace SAE_1
{
    public class Game1 : Game
    {
        // bases 
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        public static int fentereHeight = 400;
        private TiledMapTileLayer mapLayer;
        private KeyboardState _keyboardState;
        
        // zobmie 
        private Texture2D _Zombie;
        private Vector2 _Pzombie;
        public const int LARGEUR_Z = 50;
        public const int HAUTEUR_Z = 24;      
        private int _vitesseZ;
        private int _sens;
        
        // les vecteur 
        private Vector2 _direction;
        private int vitesse;
        private Vector2 _positionPerso;
        
        
        // camera 
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = "call of the dead";
            _graphics.PreferredBackBufferWidth = 700;  
            _graphics.PreferredBackBufferHeight = 512;
            _graphics.ApplyChanges();
            GraphicsDevice.BlendState = BlendState.AlphaBlend;

            _Pzombie = new Vector2(200, 150);
            _vitesseZ = 150;
            
            //vecteur  
            _direction = Vector2.Normalize(new Vector2(1, -3));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tiledMap = Content.Load<TiledMap>("mapP");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);

            _Zombie = Content.Load<Texture2D>("zombie_idle");
            mapLayer = _tiledMap.GetLayer<TiledMapTileLayer>("maison et autres ");
            
           

            // TODO: use this.Content to load your game content here
        }

        // methode pour les collision -------------------------------------------------------------------------------------------------------
        private bool IsCollision(ushort x, ushort y)
        {
            // définition de tile qui peut être null (?)
            TiledMapTile? tile;
            if (mapLayer.TryGetTile(x, y, out tile) == false)
                return false;
            if (!tile.Value.IsBlank)
                return true;
            return false;
        }
        

        protected override void Update(GameTime gameTime)
        {
            int vitesse = 2;

           
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float walkSpeed = deltaTime * vitesse; // Vitesse de déplacement du sprite 
            _keyboardState = Keyboard.GetState();
          
            // deplacement du zombie + les collistion  
            //fleche droite
            _sens = 0;
            if (_keyboardState.IsKeyDown(Keys.Right))
            {
                _sens = 1;
                ushort tx = (ushort)(_Pzombie.X / _tiledMap.TileWidth + 1);
                ushort ty = (ushort)(_Pzombie.Y / _tiledMap.TileHeight);
                _Pzombie.X += _sens * _vitesseZ * deltaTime;

                if (IsCollision(tx, ty))
                { _Pzombie.X -= _sens * _vitesseZ * deltaTime ;}

                
            }
            
           
            
            // fleche gauche 
            if (_keyboardState.IsKeyDown(Keys.Left))
            {
                _sens = -1;
                
                ushort tx = (ushort)(_Pzombie.X / _tiledMap.TileWidth - 1);
                ushort ty = (ushort)(_Pzombie.Y / _tiledMap.TileHeight);
                _Pzombie.X += _sens * _vitesseZ * deltaTime;

                if (IsCollision(tx, ty))
                { _Pzombie.X -= _sens * _vitesseZ * deltaTime ; }
            
            }
          

            //fleche haut
            if (_keyboardState.IsKeyDown(Keys.Up))
            {
                _sens = -1;
                ushort tx = (ushort)(_Pzombie.X / _tiledMap.TileWidth);
                ushort ty = (ushort)(_Pzombie.Y / _tiledMap.TileHeight - 1);
                _Pzombie.Y += _sens * _vitesseZ * deltaTime;
                if (IsCollision(tx, ty))
                { _Pzombie.Y -= _sens * _vitesseZ * deltaTime; }
            }

            // fleche bas 
            if (_keyboardState.IsKeyDown(Keys.Down))
            {
                _sens = 1;
                ushort tx = (ushort)(_Pzombie.X / _tiledMap.TileWidth);
                ushort ty = (ushort)(_Pzombie.Y / _tiledMap.TileHeight + 1);
                _Pzombie.Y += _sens * _vitesseZ * deltaTime;
                if (IsCollision(tx, ty))
                { _Pzombie.Y -= _sens * _vitesseZ * deltaTime; }
            }

            // vecteur 
            _positionPerso += _direction * (float)gameTime.ElapsedGameTime.TotalMilliseconds * vitesse;



            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _tiledMapRenderer.Update(gameTime);

            
            // TODO: Add your update logic here

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _tiledMapRenderer.Draw(); _tiledMapRenderer.Draw();
            _spriteBatch.Draw(_Zombie, _Pzombie, Color.White);
            _spriteBatch.End();

           

            base.Draw(gameTime);
            
            
        }
    }
}