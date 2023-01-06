using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Content;


namespace SAE_1
{
    internal class Png
    {
        private Texture2D _Png;
        private Vector2 _Pngp;


        public Png( Vector2 pngp , Game game)
        {
            _Pngp = pngp;
        }

       
    }
}
