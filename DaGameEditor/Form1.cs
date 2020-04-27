using DaGameEditor.Extensions;
using DaGameEditor.Menus;
using DaGameEngine.Tilemaps;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DaGameEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            NewMapDialog dialog = new NewMapDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                monoGameEditor1.CreateMap(
                    dialog.Details.MapWidth,
                    dialog.Details.MapHeight,
                    dialog.Details.TileWidth,
                    dialog.Details.TileHeight
                );
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            List<Tileset> tilesets = monoGameEditor1.Bootstrap.Tilesets;
            comboBoxTilesets.Items.AddRange(tilesets.ToArray());
        }

        private void comboBoxTilesets_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Tileset tileset = comboBoxTilesets.SelectedItem as Tileset;
            if (tileset == null)
                return;

            tilesetPreviewer.Tileset = tileset;
        }
    }
}
