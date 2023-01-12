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
        private SpriteFont _font;
        private Texture2D _textBoutons;
        // contient les rectangles : position et taille des 2 boutons présents dans la texture 
        private Rectangle[] lesBoutons;

        public ScreenPause(Game1 game) : base(game)
        {
            _myGame = game;
            lesBoutons = new Rectangle[2];
            lesBoutons[0] = new Rectangle(196, 330, 308, 93);
            lesBoutons[1] = new Rectangle(196, 418, 308, 93);
        }

        public override void LoadContent()
        {

            base.LoadContent();
            _textBoutons = Content.Load<Texture2D>("pause");

            _font = Content.Load<SpriteFont>("font");
        }

        public override void Update(GameTime gameTime)
        {

            //if (Keyboard.GetState().IsKeyDown(Keys.Back))
            //{ _myGame.Etat = Game1.Etats.Menu; } 
           
            //if (Keyboard.GetState().IsKeyDown(Keys.R))
            //{ _myGame.Etat = Game1.Etats.Play; }
            
            MouseState _mouseState = Mouse.GetState();
            if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < lesBoutons.Length; i++)
                {
                    // si le clic correspond à un des 2 boutons
                    if (lesBoutons[i].Contains(Mouse.GetState().X, Mouse.GetState().Y))
                    {
                        // on change l'état défini dans Game1 en fonction du bouton cliqué
                        if (i == 0)
                            _myGame.Etat = Game1.Etats.Play;
                        else if (i == 1)
                            _myGame.Etat = Game1.Etats.Menu;
                        break;
                    }
                }
            }



        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);
            _myGame.SpriteBatch.Begin();
            //_myGame.SpriteBatch.DrawString(_font, $" Pause " , new Vector2(320, 40), Color.Black);
            
            _myGame.SpriteBatch.Draw(_textBoutons, new Vector2(0, 0), Color.White);
            _myGame.SpriteBatch.DrawString(_font, $" Votre score : {ScreenPlay._score}", new Vector2(300, 100), Color.Red);
            //_myGame.SpriteBatch.DrawString(_font, $" Presser r pour jouer  : ", new Vector2(290, 160), Color.Black);
            _myGame.SpriteBatch.End();
        }

    }
}
