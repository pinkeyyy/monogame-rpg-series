using DaGameEngine.Tilemaps;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaGameEditor.Menus
{
    public partial class EditTilesetDialog : Form
    {
        private Tileset sourceTileset;

        public Tileset SourceTileset
        {
            get
            {
                return sourceTileset;
            }
            set
            {
                sourceTileset = value;
                ModifiedTileset = new Tileset(sourceTileset);
            }
        }

        public Tileset ModifiedTileset { get; set; }

        public bool HasChanges
        {
            get
            {
                return ModifiedTileset.Frames.Except(SourceTileset.Frames).Any();
            }
        }

        public EditTilesetDialog()
        {
            InitializeComponent();
        }

        private void EditTilesetDialog_Load(object sender, EventArgs e)
        {
            tilesetPreviewer.Tileset = ModifiedTileset;
        }

        private void buttonGenerateFrames_Click(object sender, EventArgs e)
        {
            GenerateFramesDialog dialog = new GenerateFramesDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ModifiedTileset.Frames.Clear();
                int tileWidth = dialog.Details.TileWidth;
                int tileHeight = dialog.Details.TileHeight;
                int horizontalFrames = ModifiedTileset.Texture.Width / tileWidth;
                int verticalFrames = ModifiedTileset.Texture.Height / tileHeight;

                for (int y = 0; y < verticalFrames; y++)
                {
                    for (int x = 0; x < horizontalFrames; x++)
                    {
                        Rectangle frame = new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight);
                        ModifiedTileset.Frames.Add(frame);
                    }
                }

                tilesetPreviewer.RefreshFrames();
                UpdateButtonState();
            }
        }

        private void UpdateButtonState()
        {
            buttonOk.Enabled = HasChanges;
        }
    }
}
