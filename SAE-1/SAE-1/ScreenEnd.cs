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

namespace SAE_1
{
    public class ScreenEnd : GameScreen
    {

        private Game1 _myGame;
        private SpriteFont _font;

        public ScreenEnd(Game1 game) : base(game)
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
            { _myGame.Etat = Game1.Etats.End; }

            if (Keyboard.GetState().IsKeyDown(Keys.M))
            { _myGame.Etat = Game1.Etats.Menu; }

        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aqua);
            _myGame.SpriteBatch.Begin();
            _myGame.SpriteBatch.DrawString(_font, $" Game finish ", new Vector2(300, 40), Color.Black);
            _myGame.SpriteBatch.DrawString(_font, $" Votre score : {ScreenPlay._score}", new Vector2(290, 100), Color.Black);
            _myGame.SpriteBatch.DrawString(_font, $" Pressed M to back to the menu  ", new Vector2(250, 150), Color.Black);
            _myGame.SpriteBatch.End();
        }

    }
}
