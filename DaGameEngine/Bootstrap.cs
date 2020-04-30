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
            List<string> jsonPaths = Directory.GetFiles(tilesetPath, "*.json").ToList();
            for (int i = 0; i < jsonPaths.Count; i++)
            {
                string jsonPath = jsonPaths[i];
                Tileset tileset = Tileset.FromJsonFile(jsonPath, graphicsDevice);
                Tilesets.Add(tileset);
            }
        }
    }
}
