﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SAE_1
{
    public class ScreenPause : GameScreen
    {
        private Game1 _myGame;
        private SpriteFont _font;

        public ScreenPause(Game1 game) : base(game)
        {
            _myGame = game;
        }

        public override void LoadContent()
        {

            base.LoadContent();
          
            _font = Content.Load<SpriteFont>("font");
        }

        public override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            { _myGame.Etat = Game1.Etats.Menu; } 
           
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            { _myGame.Etat = Game1.Etats.Play; }

        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);
            _myGame.SpriteBatch.Begin();
            _myGame.SpriteBatch.DrawString(_font, $" Pause " , new Vector2(320, 40), Color.Black);
            _myGame.SpriteBatch.DrawString(_font,  $" Votre score : {ScreenPlay._score}", new Vector2(300, 100), Color.Black);
            _myGame.SpriteBatch.DrawString(_font, $" Presser r pour jouer  : ", new Vector2(290, 160), Color.Black);
            _myGame.SpriteBatch.End();
        }

    }
}
