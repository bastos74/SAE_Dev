using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;

namespace SAE_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly ScreenManager _screenManager;

        // on définit les différents états possibles du jeu ( à compléter) 
        public enum Etats { Menu, Controls, Play, Quit };

        // on définit un champ pour stocker l'état en cours du jeu
        private Etats etat;

        // on définit  3 écrans ( à compléter )
        private ScreenMenu _screenMenu;
        private ScreenPlay _screenPlay;
        private ScreenControls _screenControls;


        public SpriteBatch SpriteBatch
        {
            get
            {
                return this._spriteBatch;
            }

            set
            {
                this._spriteBatch = value;
            }
        }

        public Etats Etat
        {
            get
            {
                return this.etat;
            }

            set
            {
                this.etat = value;
            }
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 700;
            _graphics.PreferredBackBufferHeight = 512;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager();
            Components.Add(_screenManager);

            // Par défaut, le 1er état flèche l'écran de menu
            Etat = Etats.Menu;

            // on charge les 2 écrans 
            _screenMenu = new ScreenMenu(this);
            _screenPlay = new ScreenPlay(this);
            _screenControls = new ScreenControls(this);

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // on charge l'écran de menu par défaut 
            _screenManager.LoadScreen(_screenMenu, new FadeTransition(GraphicsDevice, Color.Black));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // On teste le clic de souris et l'état pour savoir quelle action faire 
            MouseState _mouseState = Mouse.GetState();
            if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                // Attention, l'état a été mis à jour directement par l'écran en question
                if (this.Etat == Etats.Quit)
                    Exit();

                else if (this.Etat == Etats.Play)
                    _screenManager.LoadScreen(_screenPlay, new FadeTransition(GraphicsDevice, Color.Black));

                else if (this.Etat == Etats.Controls)
                    _screenManager.LoadScreen(_screenControls, new FadeTransition(GraphicsDevice, Color.Black));

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                if (this.Etat == Etats.Menu)
                    _screenManager.LoadScreen(_screenMenu, new FadeTransition(GraphicsDevice, Color.Black));
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}