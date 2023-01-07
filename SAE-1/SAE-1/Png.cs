//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using MonoGame.Extended.Tiled;
//using MonoGame.Extended.Tiled.Renderers;
//using System;
//using System.Collections.Generic;
//using MonoGame.Extended.Sprites;
//using Microsoft.Xna.Framework.Content;
//using MonoGame.Extended.Serialization;
//using System.Reflection.Metadata;
//using MonoGame.Extended;
//using MonoGame.Extended.TextureAtlases;


//namespace SAE_1
//{
//    internal class Png
//    {
//        public static Texture2D[] _Png = new Texture2D[5];
//        public static Vector2[] _Pngp = new Vector2[5];

        

//        public static void Initialize()
//        {
//            int choix;
//            Random rnb = new Random();

//            choix = rnb.Next(1, 3);
//            if (choix == 1)
//            {
//                for (int i = 0; i < _Pngp.Length; i++)
//                {
//                    _Pngp[i] = new Vector2(rnb.Next(-100, -50), rnb.Next(-100, 450));
//                }
//            }
//            if (choix == 2)
//            {
//                for (int i = 0; i < _Pngp.Length; i++)
//                {
//                    _Pngp[i] = new Vector2(rnb.Next(-220, 450), rnb.Next(-40, 10));
//                }
//            }
//            else { }

          
//        }
//        public static void LoadContent(ContentManager Content)
//        {
            

//            for (int i = 0; i < _Png.Length; i++)
//            {
//                _Png[i] = Content.Load<Texture2D>("Png");
//            }

            
//        }

//        public static  void Draw(SpriteBatch _spriteBatch)
//        {
    
//            for (int i = 0; i < _Png.Length; i++)
//            {
//                _spriteBatch.Draw(_Png[i], _Pngp[i], Color.White);

//            }
            
//        }
//    }
//}
