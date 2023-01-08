using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SAE_1
{
    internal class Colision
    {
        private static TiledMap _tiledMap;
        public static TiledMapTileLayer mapLayer;

        public static void LoadContent(ContentManager Content)
        {
            _tiledMap = Content.Load<TiledMap>("mapdebgp");
            mapLayer = _tiledMap.GetLayer<TiledMapTileLayer>("maison");
        }

        public static bool IsCollision(ushort x, ushort y)
        {
            // définition de tile qui peut être null (?)
            TiledMapTile? tile;
            if (mapLayer.TryGetTile(x, y, out tile) == false)
                return false;
            if (!tile.Value.IsBlank)
                return true;
            return false;
        }
    }
}
