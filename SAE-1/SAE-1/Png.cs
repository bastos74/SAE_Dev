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
    internal class Png
    {
        private Texture2D _png;
        private Vector2 position;
        private bool visible = false;
        //private AnimatedSprite pnng;

        public Png(Texture2D _png, Vector2 position, ContentManager content)
        {
            this._png = content.Load<Texture2D>("png");

            Console.WriteLine(position);
            this.Position = position;
        }

        public void Apparaitre()
        {
            bool poss = false;
            Vector2 pos = new Vector2(0, 0);

            while (!poss)
            {
                poss = true;
                pos = new Vector2(new Random().Next(0, 512), new Random().Next(0, 700));
                if (Colision.IsCollision((ushort)(pos.X / ScreenPlay._tiledMap.TileWidth), (ushort)(pos.Y / ScreenPlay._tiledMap.TileWidth)))
                {
                    poss = false;
                }
            }
            this.Position = pos;

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

        public void draw()
        {
            foreach (RandomSprite sprite in sprites)
            {
                // Calculate the distance between the sprite and the monster
                float distance = Vector2.Distance(sprite.Position, ScreenPlay._Pzombie);

                // If the distance is less than 15 pixels, hide the sprite
                if (distance < 15)
                {
                    sprite.IsVisible = false;
                }
                else
                {
                    sprite.IsVisible = true;
                }

                // Only draw the sprite if it is visible
                if (sprite.IsVisible)
                {
                    spriteBatch.Draw(sprite.Texture, sprite.Position, Color.White);
                }
            }


        }
    
    
    }
}
