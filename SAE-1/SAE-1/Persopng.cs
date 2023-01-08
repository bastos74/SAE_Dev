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
using System.Xml.Linq;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Serialization;

namespace SAE_1
{
    public class Persopng
    {
        private Texture2D _png;
        private Vector2 position;
        private bool visible = false;
        //private AnimatedSprite pnng;

        public Persopng(Texture2D _png, Vector2 position, ContentManager content)
        {
            
            this._png = content.Load<Texture2D>("png");

            int x = new Random().Next(0, 700 );
            int y = new  Random().Next(0, 500 );
            this.Position = new Vector2(x, y);
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        public static void draw(SpriteBatch spriteBatch)
        {


            foreach (Persopng sprite in ScreenPlay._sprites)
            {
                // calcul la distance entre les png et le zombie 
                float distance = Vector2.Distance(sprite.Position, ScreenPlay._Pzombie);
                
                // distance infereiur a 15 pixel 
                if (distance < 15)
                {
                    sprite.visible = false;
                    Console.WriteLine("touche");
                }
                else
                {
                    sprite.visible = true;
                }

                // Ne dessinez le sprite que s'il est visible
                if (sprite.visible)
                {
                    spriteBatch.Draw(ScreenPlay._Png, sprite.Position, Color.White);

                }
            }

        }

    }
}
