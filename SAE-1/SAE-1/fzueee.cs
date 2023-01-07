﻿//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework;
//using MonoGame.Extended.Serialization;
//using MonoGame.Extended.Sprites;
//using MonoGame.Extended.ViewportAdapters;
//using MonoGame.Extended;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Metadata;
//using System.Text;
//using System.Threading.Tasks;

//namespace SAE_1
//{
//    internal class fzueee
//    {
//        //BASIC
//        public static GraphicsDeviceManager _graphics;
//        public static SpriteBatch _spriteBatch { get; set; }

//        //MAIN MENU
//        public static Texture2D _textureFondEcran;
//        public static Texture2D _texturePlayButton;
//        public static Texture2D _textureControls;
//        public static Vector2 _positionPlayButton;


//        //JEU

//        public static Texture2D _textureombrePerso;
//        public Texture2D _textureObscurite;
//        public static Vector2 _positionObscurite;


//        public static int _screenWidth;
//        public static int _screenHeight;

//        public static bool _debugMode;

//        public static List<Monstre> _listeMonstre = new List<Monstre>();


//        public static double _viePerso;





//        public static bool _gameStarted;
//        public static bool _gameBegin;
//        public static float _wait;


//        public Game1()
//        {
//            _graphics = new GraphicsDeviceManager(this);
//            Content.RootDirectory = "Content";
//            IsMouseVisible = true;
//        }





//        protected override void Initialize()
//        {
//            _spriteBatch = new SpriteBatch(GraphicsDevice);
//            GraphicsDevice.BlendState = BlendState.AlphaBlend;


//            _gameStarted = false;
//            _gameBegin = false;
//            _debugMode = false;
//            _wait = 0;
//            KeyboardManager.frappe = false;
//            KeyboardManager.wait = 0;

//            _screenWidth = 1280;
//            _screenHeight = 720;
//            _graphics.PreferredBackBufferWidth = _screenWidth;
//            _graphics.PreferredBackBufferHeight = _screenHeight;
//            _graphics.ApplyChanges();

//            MapUI.Initialise();
//            _positionPlayButton = new Vector2(490, 300);


//            _viePerso = 6;
//            Perso.Initialise();
//            Fee.Initialise();
//            Zone.Initialise();
//            base.Initialize();
//            for (int i = 0; i < 50; i++)
//            {
//                _listeMonstre.Add(new Monstre("monstreAnimation.sf", new Vector2(new Random().Next(0, 1600), new Random().Next(0, 1600)), Content));
//            }
//            // Gestion de la caméra
//            var viewportadapter = new BoxingViewportAdapter(Window, GraphicsDevice, _screenWidth, _screenHeight);
//            Camera.Initialise(viewportadapter);
//            Map.Initialise();
//        }




//        protected override void LoadContent()
//        {
//            //MENU

//            _texturePlayButton = Content.Load<Texture2D>("Menu/play");
//            _textureControls = Content.Load<Texture2D>("Menu/controls");
//            _textureFondEcran = Content.Load<Texture2D>("Menu/background");


//            //JEU
//            HUD.LoadContent(Content);
//            Map.LoadContent(Content, GraphicsDevice);
//            Fee.LoadContent(Content);
//            _textureombrePerso = Content.Load<Texture2D>("ombre");
//            _textureObscurite = Content.Load<Texture2D>("obscurite");


//            MapUI.LoadContent(Content);
//            HUD.LoadContent(Content);
//            ViePerso.LoadContent(Content);
//            SpriteSheet spriteSheet = Content.Load<SpriteSheet>("persoAnimation.sf", new JsonContentLoader());
//            Perso.LoadContent(spriteSheet, Content);
//            Message.LoadContent(Content);
//        }





//        protected override void Update(GameTime gameTime)
//        {
//            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

//            //JEU



//            if (_gameStarted)
//            {
//                if (_gameBegin)
//                {
//                    if (_wait < 4)
//                        _wait += deltaTime;
//                    else
//                        _gameBegin = false;
//                }

//                if (KeyboardManager.frappe)
//                {
//                    KeyboardManager.wait += 1 * deltaTime;
//                    if (KeyboardManager.wait >= 1)
//                    {
//                        KeyboardManager.frappe = false;
//                        KeyboardManager.wait = 0;
//                    }
//                }
//                if (Perso._touche)
//                {
//                    Perso._wait += 1 * deltaTime;
//                    if (Math.Round(Perso._wait, 0) == 3)
//                    {
//                        Perso._touche = false;
//                        Perso._wait = 0;
//                    }

//                }

//                float walkSpeed = deltaTime * Perso._vitessePerso;
//                Perso.Update();
//                Fee.Update();
//                ViePerso.Update();
//                KeyboardManager.Manage(Perso._positionPerso, Map._tiledMap, Perso._animation, walkSpeed, Map._mapWidth, Map._mapHeight, _graphics, deltaTime);
//                Camera.Update();
//                MapUI.Update();
//                Zone.Update();
//                _positionObscurite = new Vector2(Perso._positionPerso.X - 1080 / 2, Perso._positionPerso.Y - 720 / 2);
//                Monstre.Update(deltaTime);
//                Perso._perso.Play(Perso._animation);
//                Perso._perso.Update(deltaTime);
//                Map.Update(gameTime);
//            }

//            //MENU

//            else
//            {
//                var mouseState = Mouse.GetState();
//                var mousePosition = new Point(mouseState.X, mouseState.Y);
//                if (mousePosition.X >= _positionPlayButton.X &&
//                    mousePosition.X <= _positionPlayButton.X + 300 &&
//                mousePosition.Y >= _positionPlayButton.Y &&
//                    mousePosition.Y <= _positionPlayButton.Y + 100)
//                {
//                    _texturePlayButton = Content.Load<Texture2D>("Menu/playHover");
//                }
//                else
//                {
//                    _texturePlayButton = Content.Load<Texture2D>("Menu/play");
//                }


//                if (mouseState.LeftButton == ButtonState.Pressed)
//                {
//                    if (mousePosition.X >= _positionPlayButton.X &&
//                            mousePosition.X <= _positionPlayButton.X + 300 &&
//                            mousePosition.Y >= _positionPlayButton.Y &&
//                            mousePosition.Y <= _positionPlayButton.Y + 100)
//                    {
//                        _gameStarted = true;
//                        _gameBegin = true;
//                        for (int i = 0; i < _listeMonstre.Count; i++)
//                        {
//                            _listeMonstre[i].Spawn();
//                        }
//                    }
//                }
//                KeyboardState keyboardState = Keyboard.GetState();

//                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
//                {
//                    _gameStarted = true;
//                    _gameBegin = true;

//                    for (int i = 0; i < _listeMonstre.Count; i++)
//                    {
//                        _listeMonstre[i].Spawn();
//                    }
//                }
//            }
//            base.Update(gameTime);
//        }





//        protected override void Draw(GameTime gameTime)
//        {

//            if (!_gameStarted)
//            {
//                _spriteBatch.Begin();
//                _spriteBatch.Draw(_textureFondEcran, new Vector2(0, 0), Color.White);
//                _spriteBatch.Draw(_texturePlayButton, _positionPlayButton, Color.White);
//                _spriteBatch.Draw(_textureControls, new Vector2(340, 570), Color.White);
//                _spriteBatch.End();
//            }
//            else
//            {
//                var transformMatrix = Camera._camera.GetViewMatrix();

//                //affichage de la map et des sprites en fonction de la matrice créée depuis la caméra actuelle.
//                _spriteBatch.Begin(transformMatrix: transformMatrix);

//                Map.Draw(transformMatrix);

//                Monstre.Draw(_spriteBatch);
//                Perso.Draw(_spriteBatch);

//                ViePerso.Draw(_spriteBatch);
//                Fee.Draw(_spriteBatch);

//                if (!_debugMode)
//                    _spriteBatch.Draw(_textureObscurite, _positionObscurite, Color.White);
//                _spriteBatch.End();




//                _spriteBatch.Begin();
//                MapUI.Draw(_spriteBatch);
//                HUD.Draw(_spriteBatch);

//                if (_gameBegin)
//                {
//                    Message.Draw(_spriteBatch, "Libere la ville des mechants !", "Fais vite... Je crois en toi !");
//                }
//                _spriteBatch.End();
//            }

//            base.Draw(gameTime);




//        }
//}
