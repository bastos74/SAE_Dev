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
    public class Png
    {
        private Texture2D _png;
        private Vector2 position;
        
       private static Vector2 pointA = new Vector2(1, 2);
       private static Vector2 pointB = new Vector2(3, 4);
       private static Vector2 positionVector = Vector2.Subtract(pointB, pointA);

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

        public static void Update(float deltaTime)
        {
            int vitesse = 80;
            
            Vector2 sens;


            for (int i = 0; i < ScreenPlay._sprites.Count; i++)
            {
                
                Png png = ScreenPlay._sprites[i];
                float distance = Vector2.Distance(png.Position, ScreenPlay._Pzombie); 
                sens = Vector2.Normalize(ScreenPlay._sprites[i].Position - ScreenPlay._Pzombie);

                if (distance < 8*6 )
                {

                    
                    ushort xX;
                    ushort yX = (ushort)(png.position.Y / ScreenPlay._tiledMap.TileHeight);

                    if (sens.X <= 0)
                        xX = (ushort)(png.position.X / ScreenPlay._tiledMap.TileWidth - 0.5);
                    else
                        xX = (ushort)(png.position.X / ScreenPlay._tiledMap.TileWidth + 1.25);
                    if(Colision.IsCollision(xX , yX))
                    {
                        sens.X = 0;
                    }
                    ushort xY = (ushort)(png.position.X / ScreenPlay._tiledMap.TileWidth);
                    ushort yY;
                    if (sens.Y <= 0)
                        yY = (ushort)(png.position.Y / ScreenPlay._tiledMap.TileHeight - 0.50);
                    else
                        yY = (ushort)(png.position.Y / ScreenPlay._tiledMap.TileHeight + 1.50);
                    if (Colision.IsCollision(xY, yY))
                    {
                        sens.Y = 0;
                    }
                    png.position += sens * vitesse * deltaTime;

                    // si la distance est inferieur a 15 pixel il y a une colision 
                    if (distance < 8)
                    {
                        Console.WriteLine("sa touche");
                        Png pngASupprime = ScreenPlay._sprites[i];
                        ScreenPlay._sprites.Remove(pngASupprime);
                        ScreenPlay._score++;

                    }

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
