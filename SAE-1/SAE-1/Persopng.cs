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

            Console.WriteLine(position);
            this.Position = position;
        }

        public void Apparaitre()
        {
            bool poss = false;
            Vector2 pos = new Vector2(0 , 0);

            while (!poss)
            {
                poss = true;
                pos = new Vector2(new Random().Next(0, 512), new Random().Next(0, 700));
                if (Colision.IsCollision((ushort)(pos.X / ScreenPlay._tiledMap.TileWidth), (ushort)(pos.Y / ScreenPlay._tiledMap.TileWidth)))
                {
                    poss = false;
                }
            }this.Position = pos;

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

        //public static void Update()
        //{


        //    for (int i = 0; i < 10; i++)
        //    {
        //        //Persopng sprite = ScreenPlay._sprites[i];

        //        float distance = Vector2.Distance(sprite.Position, ScreenPlay._Pzombie);

        //        // distance infereiur a 15 pixel 
        //        if (distance <= 15)
        //        {
        //            sprite.visible = false;
        //            Console.WriteLine("touche");
        //        }
        //        else
        //        {
        //            sprite.visible = true;
        //        }

        //    }

        //}
        public  void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ScreenPlay._Png, position, Color.White);

        }

        public bool CheckCollisionPlayer(Vector2 posPlayer )
        {
            //Console.WriteLine("pnj " + position);
            //Console.WriteLine("joueur " + posPlayer);

            Vector2 distance = posPlayer - position;
            Console.WriteLine(Vector2.Distance(posPlayer, posPlayer));

            // distance infereiur a 15 pixel 
            if (Vector2.Distance(posPlayer,posPlayer)<2)
            {
                Console.WriteLine("CA COLISIONNE");
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
