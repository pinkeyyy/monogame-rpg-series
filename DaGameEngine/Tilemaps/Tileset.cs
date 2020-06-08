using DaGameEngine.JsonConverters;
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
        public string FilePath { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Texture2D Texture { get; set; }
        public List<Rectangle> Frames { get; set; }

        public static Tileset FromJsonFile(string filePath, GraphicsDevice graphicsDevice)
        {
            Tileset instance = JsonConvert.DeserializeObject<Tileset>(
                File.ReadAllText(filePath), new RectangleJsonConverter()
            );

            string imagePath = Path.ChangeExtension(filePath, ".png");
            instance.FilePath = filePath;

            using (Stream fileStream = File.OpenRead(imagePath))
            {
                instance.Texture = Texture2D.FromStream(graphicsDevice, fileStream);
            }

            return instance;
        }

        public Tileset()
        {

        }

        public Tileset(Tileset source)
        {
            Apply(source);
        }

        public void Apply(Tileset source)
        {
            Name = source.Name;
            Texture = source.Texture;
            Frames = new List<Rectangle>(source.Frames);
        }

        public void SaveToJson()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(this, Formatting.Indented, new RectangleJsonConverter()));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
