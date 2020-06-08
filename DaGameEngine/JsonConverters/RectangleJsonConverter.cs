using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGameEngine.JsonConverters
{
    class RectangleJsonConverter : JsonConverter<Rectangle>
    {
        public override Rectangle ReadJson(JsonReader reader, Type objectType, Rectangle existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                return ReadOldFormat(reader);
            }
            else if (reader.TokenType == JsonToken.String)
            {
                return ReadNewFormat(reader);
            }

            throw new Exception($"RectangleJsonConverter: Invalid token: {reader.TokenType}");
        }

        public override void WriteJson(JsonWriter writer, Rectangle value, JsonSerializer serializer)
        {
            writer.WriteValue($"{value.X} {value.Y} {value.Width} {value.Height}");
        }

        private Rectangle ReadOldFormat(JsonReader reader)
        {
            JObject jsonObject = JObject.Load(reader);

            if (!jsonObject.TryGetValue("X", out JToken xToken) ||
                !jsonObject.TryGetValue("Y", out JToken yToken) ||
                !jsonObject.TryGetValue("Width", out JToken widthToken) ||
                !jsonObject.TryGetValue("Height", out JToken heightToken))
            {
                throw new Exception($"RectangleJsonConverter: Not all rectangle components were found ({reader.Path})");
            }

            if (!int.TryParse(xToken.ToString(), out int x) ||
                !int.TryParse(yToken.ToString(), out int y) ||
                !int.TryParse(widthToken.ToString(), out int width) ||
                !int.TryParse(heightToken.ToString(), out int height))
            {
                throw new Exception($"RectangleJsonConverter: Not all rectangle components were numeric ({reader.Path})");
            }

            return new Rectangle(x, y, width, height);
        }

        private Rectangle ReadNewFormat(JsonReader reader)
        {
            string[] components = reader.Value.ToString().Split(' ');
            if (components.Length != 4)
            {
                throw new Exception($"RectangleJsonConverter: Not all rectangle components were found ({reader.Path})");
            }

            if (!int.TryParse(components[0], out int x) ||
                !int.TryParse(components[1], out int y) ||
                !int.TryParse(components[2], out int width) ||
                !int.TryParse(components[3], out int height))
            {
                throw new Exception($"RectangleJsonConverter: Not all rectangle components were numeric ({reader.Path})");
            }

            return new Rectangle(x, y, width, height);
        }
    }
}
