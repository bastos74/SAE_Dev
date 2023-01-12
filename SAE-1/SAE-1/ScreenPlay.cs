using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Sprites;

namespace SAE_1
{
    public class ScreenPlay : GameScreen
    {

        // bases 
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static TiledMap _tiledMap;
        public static TiledMapRenderer _tiledMapRenderer;
        public static int fentereHeight = 400;
        public TiledMapTileLayer mapLayer;
        private KeyboardState _keyboardState;
        // chrono 
        public static float _chrono;
        public Vector2 _positionChrono;

        // zombie 
        public static Texture2D _Zombie;
        public static Vector2 _Pzombie;
        private static int _vitesseZ;
        private static int _sens;

        // png 
        public static Texture2D _Png;
        public static List<Png> _sprites = new List<Png>();

        Random rnb = new Random();

        public static int _score;
        public Vector2 _positionscore;
        public SpriteFont _police;

        // les vecteur 
        private Vector2 _direction;
        private Vector2 _positionPerso;

        private Game1 _myGame;
        private SpriteFont _font;

        // pour récupérer une référence à l’objet game pour avoir accès à tout ce qui est défini dans Game1
        public ScreenPlay(Game1 game) : base(game)
        {
            _myGame = game;
        }
        public override void Initialize()
        {
     
            GraphicsDevice.BlendState = BlendState.AlphaBlend;

            _Pzombie = new Vector2(20, 20);
            _vitesseZ = 150;

            for (int i = 0; i < 25; i++)
            {
               _sprites.Add(new(_Png, new Vector2(new Random().Next(0 , 700),new Random().Next(0 , 512)), Content));   
            }

            //vecteur  
            _direction = Vector2.Normalize(new Vector2(1, -3));

            // score 
            _score = 0;
            _positionscore = new Vector2(630, 0);
            
            // chrono 
            _chrono = 60;
            _positionChrono = new Vector2(612, 15);

            base.Initialize();
        }

        public override void LoadContent()
        {

            base.LoadContent();

            //_font = Content.Load<SpriteFont>("font");

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tiledMap = Content.Load<TiledMap>("mapdebgp");
            Colision.LoadContent(Content);
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            _Zombie = Content.Load<Texture2D>("ZSAE1removebg");
            

            // pour le score 
            _police = Content.Load<SpriteFont>("font");

            // pour les png 
            for (int i = 0; i < _sprites.Count; i++)
            {
                _sprites[i].Apparaitre();
            }
            
            //for (int i = 0; i < _Png.Length; i++)
            //{
            //    _Png[i] = Content.Load<Texture2D>("Png");
            //}
        }

        public override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Back))
                { _myGame.Etat = Game1.Etats.Menu; }
           

            if (Keyboard.GetState().IsKeyDown(Keys.Tab))
                { _myGame.Etat = Game1.Etats.Pause; }
            
            int vitesse = 1;

           
            
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float walkSpeed = deltaTime * vitesse; // Vitesse de déplacement du sprite 
            _keyboardState = Keyboard.GetState();

            // deplacement du zombie + les collistion            
            _sens = 0;
            //fleche droite
            if (_keyboardState.IsKeyDown(Keys.Right) || (_keyboardState.IsKeyDown(Keys.D)))
            {
                _sens = 1;
                ushort tx = (ushort)(_Pzombie.X / _tiledMap.TileWidth + 1);
                ushort ty = (ushort)(_Pzombie.Y / _tiledMap.TileHeight);
                _Pzombie.X += _sens * _vitesseZ * deltaTime;

                if (Colision.IsCollision(tx, ty))
                { _Pzombie.X -= _sens * _vitesseZ * deltaTime; }
            }

            // fleche gauche 
            if (_keyboardState.IsKeyDown(Keys.Left) || (_keyboardState.IsKeyDown(Keys.Q)))
            {
                _sens = -1;

                ushort tx = (ushort)(_Pzombie.X / _tiledMap.TileWidth - 0.5);
                ushort ty = (ushort)(_Pzombie.Y / _tiledMap.TileHeight);
                _Pzombie.X += _sens * _vitesseZ * deltaTime;

                if (Colision.IsCollision(tx, ty))
                { _Pzombie.X -= _sens * _vitesseZ * deltaTime; }

            }

            //fleche haut
            if (_keyboardState.IsKeyDown(Keys.Up) || (_keyboardState.IsKeyDown(Keys.Z)))
            {
                _sens = -1;
                ushort tx = (ushort)(_Pzombie.X / _tiledMap.TileWidth);
                ushort ty = (ushort)(_Pzombie.Y / _tiledMap.TileHeight - 0.25);
                _Pzombie.Y += _sens * _vitesseZ * deltaTime;
                if (Colision.IsCollision(tx, ty))
                { _Pzombie.Y -= _sens * _vitesseZ * deltaTime; }
            }

            // fleche bas 
            if (_keyboardState.IsKeyDown(Keys.Down) || (_keyboardState.IsKeyDown(Keys.S)))
            {
                _sens = 1;
                ushort tx = (ushort)(_Pzombie.X / _tiledMap.TileWidth);
                ushort ty = (ushort)(_Pzombie.Y / _tiledMap.TileHeight + 1.50);
                _Pzombie.Y += _sens * _vitesseZ * deltaTime;
                if (Colision.IsCollision(tx, ty))
                { _Pzombie.Y -= _sens * _vitesseZ * deltaTime; }
            }

            Png.Update(deltaTime);

            // chrono 
            _chrono -= (deltaTime);

            if (_chrono <= 0)
            {
                _chrono = 0;
                _vitesseZ = 0;
                _myGame.Etat = Game1.Etats.End;

            }

            // vecteur 
            _positionPerso += _direction * (float)gameTime.ElapsedGameTime.TotalMilliseconds * vitesse;

            _tiledMapRenderer.Update(gameTime);
            
        }
        public override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);
           
            _myGame.SpriteBatch.Begin();
            _spriteBatch.Begin();
            _tiledMapRenderer.Draw();
         
            _spriteBatch.Draw(_Zombie, _Pzombie, Color.White);

            Png.Draw(_spriteBatch);
            
            _spriteBatch.DrawString(_police, $"score : {_score}", _positionscore, Color.Black);
            _spriteBatch.DrawString(_police, $"Temps : {Math.Round(_chrono)}", _positionChrono, Color.Black);
            _spriteBatch.End();
            _myGame.SpriteBatch.End();

        }
    }
}
