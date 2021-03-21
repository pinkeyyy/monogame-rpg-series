using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGameEditor
{
    class EditorConfig
    {
        private static EditorConfig instance;

        public static EditorConfig Get()
        {
            const string EDITOR_CONFIG_PATH = "editor.json";

            if (!File.Exists(EDITOR_CONFIG_PATH))
                throw new FileNotFoundException($"Editor config file not found: {EDITOR_CONFIG_PATH}");

            if (instance == null)
            {
                instance = JsonConvert.DeserializeObject<EditorConfig>(
                    File.ReadAllText(EDITOR_CONFIG_PATH)
                );
            }

            return instance;
        }

        public string ClientExecutablePath { get; set; }
        public int DefaultMapWidth { get; set; } = 10;
        public int DefaultMapHeight { get; set; } = 10;
        public int DefaultTileWidth { get; set; } = 32;
        public int DefaultTileHeight { get; set; } = 32;
    }
}
