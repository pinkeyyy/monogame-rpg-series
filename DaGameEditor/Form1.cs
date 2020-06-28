﻿using DaGameEditor.Extensions;
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
            buttonEditTileset.Enabled = tileset != null;
            if (tileset == null)
                return;

            tilesetPreviewer.Tileset = tileset;
        }

        private void tilesetPreviewer_TileSelect(Tileset tileset, int frameIndex)
        {
            Tile brushTile = new Tile()
            {
                TilesetIndex = monoGameEditor1.Bootstrap.Tilesets.IndexOf(tileset),
                TileIndex = frameIndex
            };

            monoGameEditor1.BrushTile = brushTile;
        }

        private void buttonEditTileset_Click(object sender, System.EventArgs e)
        {
            EditTilesetDialog dialog = new EditTilesetDialog()
            {
                SourceTileset = (Tileset)comboBoxTilesets.SelectedItem
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dialog.SourceTileset.Apply(dialog.ModifiedTileset);
                tilesetPreviewer.RefreshFrames();
                monoGameEditor1.Bootstrap.SaveTilesets();
            }
        }

        private void monoGameEditor1_NewMap(Map newMap)
        {
            for (int i = 0; i < newMap.Layers.Count; i++)
            {
                listBoxLayers.Items.Add(newMap.Layers[i]);
            }

            listBoxLayers.SelectedIndex = 0;
        }

        private void listBoxLayers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            monoGameEditor1.ActiveLayer = listBoxLayers.SelectedIndex;
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }
    }
}
