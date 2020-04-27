using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGameEngine.Tilemaps
{
    public class Tileset
    {
        public string Name { get; set; }
        public Texture2D Texture { get; set; }
        public List<Rectangle> Frames { get; set; }

        public static Tileset FromJsonFile(string filePath, GraphicsDevice graphicsDevice)
        {
            Tileset instance = JsonConvert.DeserializeObject<Tileset>(
                File.ReadAllText(filePath)
            );

            string imagePath = Path.ChangeExtension(filePath, ".png");

            using (Stream fileStream = File.OpenRead(imagePath))
            {
                instance.Texture = Texture2D.FromStream(graphicsDevice, fileStream);
            }

            return instance;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
