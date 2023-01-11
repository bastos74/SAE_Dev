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
    public class ScreenControls : GameScreen
    {
        private Game1 _myGame;
        private SpriteFont _font;
        private Texture2D _textureUpArrow;
        private Texture2D _textureLeftArrow;
        private Texture2D _textureDownArrow;
        private Texture2D _textureRightArrow;
        private Texture2D _textureZsqd;
        private Vector2 _positionUpArrow;
        private Vector2 _positionLeftArrow;
        private Vector2 _positionDownArrow;
        private Vector2 _positionRightArrow;
        private Vector2 _positionZqsd;
        private Texture2D _textureSpacebar;
        // pour récupérer une référence à l’objet game pour avoir accès à tout ce qui est 
        // défini dans Game1
        public ScreenControls(Game1 game) : base(game)
        {
            _myGame = game;
        }
        public override void LoadContent()
        {

            base.LoadContent();
            _textureUpArrow = Content.Load<Texture2D>("uparrow");
            _textureLeftArrow = Content.Load<Texture2D>("leftarrow");
            _textureDownArrow = Content.Load<Texture2D>("downarrow");
            _textureRightArrow = Content.Load<Texture2D>("rightarrow");
            _textureSpacebar = Content.Load<Texture2D>("Spacebar2");
            _textureZsqd = Content.Load<Texture2D>("index");



            _font = Content.Load<SpriteFont>("font");
        }
        public override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Back))
                _myGame.Etat = Game1.Etats.Menu;

        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _myGame.SpriteBatch.Begin();
            //_myGame.SpriteBatch.DrawString(_font, $"Mouvement", new Vector2(0, 10), Color.Crimson);
            _myGame.SpriteBatch.Draw(_textureUpArrow, new Vector2(400, 50), Color.White);
            _myGame.SpriteBatch.Draw(_textureDownArrow, new Vector2(400, 100), Color.White);
            _myGame.SpriteBatch.Draw(_textureLeftArrow, new Vector2(350, 100), Color.White);    
            _myGame.SpriteBatch.Draw(_textureRightArrow, new Vector2(450, 100), Color.White);
            _myGame.SpriteBatch.DrawString(_font, $"ATTACK!!!", new Vector2(0, 150), Color.White);
            _myGame.SpriteBatch.Draw(_textureSpacebar, new Vector2(0, 175), Color.White);
            _myGame.SpriteBatch.DrawString(_font, $"OBJECTIVES :" +
                "\nProvoke the Apocalypse and the catastrophe around the city as a Zombie " +
                "\nBite them All! DON'T SPARE ANYONE!" + "\nEAT THEIR BRAAAAAAAAIIIIIINNNNNN!!!",
                new Vector2(0, 250), Color.White);
            _myGame.SpriteBatch.Draw(_textureZsqd, new Vector2(20, 10), Color.White);
            _myGame.SpriteBatch.DrawString(_font, $"HERE'S YOUR ZOMBIE !!!", new Vector2(0, 400), Color.Crimson);
            _myGame.SpriteBatch.End();


        }
    }
}




