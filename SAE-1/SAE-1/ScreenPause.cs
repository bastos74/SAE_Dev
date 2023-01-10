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
    public class ScreenPause : GameScreen
    {
        private Game1 _myGame;

        public ScreenPause(Game1 game) : base(game)
        {
            _myGame = game;
        }

        public override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Tab))
                _myGame.Etat = Game1.Etats.Play;

        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);
            _myGame.SpriteBatch.Begin();

            _myGame.SpriteBatch.End();
        }

    }
}
