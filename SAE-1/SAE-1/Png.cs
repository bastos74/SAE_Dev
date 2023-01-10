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
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Sprites;
using System.Xml.Linq;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Serialization;

namespace SAE_1
{
    public class Png
    {
        private Texture2D _png;
        private Vector2 position;
        private bool visible = false;
        //private AnimatedSprite pnng;

        public Png(Texture2D _png, Vector2 position, ContentManager content)
        {
            this._png = content.Load<Texture2D>("Character");

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
                Console.WriteLine((pos.X / ScreenPlay._tiledMap.TileWidth));
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

        public static void Update()
        {
            for (int i = 0; i < ScreenPlay._sprites.Count; i++)
            {

                Png png = ScreenPlay._sprites[i];
                float distance = Vector2.Distance(png.Position, ScreenPlay._Pzombie);
                
  
                // si la distance est inferieur a 15 pixel il y a une colision 
                if (distance < 15 )
                {
                    Console.WriteLine("sa touche");
                    Png pngASupprime = ScreenPlay._sprites[i];
                    ScreenPlay._sprites.Remove(pngASupprime);
                       
                }
            }
        }
        
        public static void Draw(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < ScreenPlay._sprites.Count; i++)
            {
                //ScreenPlay._sprites[i].draw(spriteBatch);
                
                   
                Png png = ScreenPlay._sprites[i];
               
                _spriteBatch.Draw(png._png, png.position, Color.White);
                
            }
            

        }


    }
}
