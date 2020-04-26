using DaGameEngine.Tilemaps;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGameEditor.Extensions
{
    static class TilesetExtensions
    {
        private static Dictionary<Texture2D, Image> imageCache = new Dictionary<Texture2D, Image>();

        public static Image GetImageFromTexture(this Tileset tileset)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Texture2D tilesetTexture = tileset.Texture;
                if (imageCache.ContainsKey(tilesetTexture))
                {
                    return imageCache[tilesetTexture];
                }

                tileset.Texture.SaveAsPng(stream, tileset.Texture.Width, tileset.Texture.Height);
                Image image = new Bitmap(stream);

                imageCache.Add(tilesetTexture, image);
                return image;
            }
        }
    }
}
