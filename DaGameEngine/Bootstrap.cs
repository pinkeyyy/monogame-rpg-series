using DaGameEngine.Tilemaps;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGameEngine
{
    public class Bootstrap
    {
        private GraphicsDevice graphicsDevice;
        private string contentPath;

        public List<Tileset> Tilesets { get; private set; }

        public Bootstrap(GraphicsDevice graphicsDevice, string contentPath)
        {
            this.graphicsDevice = graphicsDevice;
            this.contentPath = contentPath;
            SanitizeContentPath();
            LoadTilesets();
        }

        private void SanitizeContentPath()
        {
            if (contentPath.LastIndexOf(@"\") != contentPath.Length - 1)
                contentPath += @"\";
        }

        private void LoadTilesets()
        {
            Tilesets = new List<Tileset>();

            string tilesetPath = contentPath + @"Tilesets\";
            List<string> texturePaths = Directory.GetFiles(tilesetPath, "*.png").ToList();
            for (int i = 0; i < texturePaths.Count; i++)
            {
                string texturePath = texturePaths[i];
                using (Stream fileStream = File.OpenRead(texturePath))
                {
                    Tileset tilesetInstance = new Tileset()
                    {
                        Name = Path.GetFileNameWithoutExtension(texturePath),
                        Texture = Texture2D.FromStream(graphicsDevice, fileStream)
                    };

                    Tilesets.Add(tilesetInstance);
                }
            }
        }
    }
}
