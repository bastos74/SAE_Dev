using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
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
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        public static int fentereHeight = 400;
        private TiledMapTileLayer mapLayer;
        private KeyboardState _keyboardState;

        // zombie 
        private static Texture2D _Zombie;
        public static Vector2 _Pzombie;
        public const int LARGEUR_Z = 50;
        public const int HAUTEUR_Z = 24;
        private static int _vitesseZ;
        private static int _sens;

        public static List<Persopng> _sprites = new List<Persopng>();

        // png 
        public static Texture2D _Png;
        //private Texture2D[] _Png = new Texture2D[5];
        //private Vector2[] _Pngp = new Vector2[5];
        //Random rnb = new Random();
        //int choix;

        // les vecteur 
        private Vector2 _direction;
        private int vitesse;
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

            _Pzombie = new Vector2(200, 150);
            _vitesseZ = 150;
            
            //choix = rnb.Next(1, 3);
            //if (choix == 1)
            //{
            //    for (int i = 0; i < _Pngp.Length; i++)
            //    {
            //        _Pngp[i] = new Vector2(rnb.Next(-100, -50), rnb.Next(-100, 450));
            //    }
            //}
            //if (choix == 2)
            //{
            //    for (int i = 0; i < _Pngp.Length; i++)
            //    {
            //        _Pngp[i] = new Vector2(rnb.Next(-220, 450), rnb.Next(-40, 10));
            //    }
            //}
            //else { }

            for (int i = 0; i < 10; i++)
            {
               _sprites.Add(new(_Png, new Vector2(100,100), Content));   
            }

            //vecteur  
            _direction = Vector2.Normalize(new Vector2(1, -3));

            //png = new Png(new Vector2(20, 25));

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
            _Zombie = Content.Load<Texture2D>("zombie_idle");

            _Png = Content.Load<Texture2D>("Png");
            //for (int i = 0; i < _Png.Length; i++)
            //{
            //    _Png[i] = Content.Load<Texture2D>("Png");
            //}
        }

        public override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Back))
                _myGame.Etat = Game1.Etats.Menu;


            int vitesse = 2;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float walkSpeed = deltaTime * vitesse; // Vitesse de déplacement du sprite 
            _keyboardState = Keyboard.GetState();

            // deplacement du zombie + les collistion            
            _sens = 0;
            //fleche droite
            if (_keyboardState.IsKeyDown(Keys.Right))
            {
                _sens = 1;
                ushort tx = (ushort)(_Pzombie.X / _tiledMap.TileWidth + 1);
                ushort ty = (ushort)(_Pzombie.Y / _tiledMap.TileHeight);
                _Pzombie.X += _sens * _vitesseZ * deltaTime;

                if (Colision.IsCollision(tx, ty))
                { _Pzombie.X -= _sens * _vitesseZ * deltaTime; }
            }

            // fleche gauche 
            if (_keyboardState.IsKeyDown(Keys.Left))
            {
                _sens = -1;

                ushort tx = (ushort)(_Pzombie.X / _tiledMap.TileWidth - 1);
                ushort ty = (ushort)(_Pzombie.Y / _tiledMap.TileHeight);
                _Pzombie.X += _sens * _vitesseZ * deltaTime;

                if (Colision.IsCollision(tx, ty))
                { _Pzombie.X -= _sens * _vitesseZ * deltaTime; }

            }

            //fleche haut
            if (_keyboardState.IsKeyDown(Keys.Up))
            {
                _sens = -1;
                ushort tx = (ushort)(_Pzombie.X / _tiledMap.TileWidth);
                ushort ty = (ushort)(_Pzombie.Y / _tiledMap.TileHeight - 1);
                _Pzombie.Y += _sens * _vitesseZ * deltaTime;
                if (Colision.IsCollision(tx, ty))
                { _Pzombie.Y -= _sens * _vitesseZ * deltaTime; }
            }

            // fleche bas 
            if (_keyboardState.IsKeyDown(Keys.Down))
            {
                _sens = 1;
                ushort tx = (ushort)(_Pzombie.X / _tiledMap.TileWidth);
                ushort ty = (ushort)(_Pzombie.Y / _tiledMap.TileHeight + 1);
                _Pzombie.Y += _sens * _vitesseZ * deltaTime;
                if (Colision.IsCollision(tx, ty))
                { _Pzombie.Y -= _sens * _vitesseZ * deltaTime; }
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
            _tiledMapRenderer.Draw(); _tiledMapRenderer.Draw();
            _spriteBatch.Draw(_Zombie, _Pzombie, Color.White);
           
            Persopng.draw(_spriteBatch);
            //for (int i = 0; i < _Png.Length; i++)
            //{
            //    _spriteBatch.Draw(_Png[i], _Pngp[i], Color.White);
            //}
            _spriteBatch.End();
            _myGame.SpriteBatch.End();

        }
    }
}
