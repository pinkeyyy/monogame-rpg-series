using DaGameEditor.Extensions;
using DaGameEditor.Menus;
using DaGameEditor.Tools;
using DaGameEngine.Tilemaps;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DaGameEditor
{
    public partial class Form1 : Form
    {
        private const string TITLE_TEXT = "Da Game Editor";
        private const string TITLE_TEXT_SAVED = "Da Game Editor [{0}]";
        private string currentMapPath;

        private TilePaintingTool tilePaintingTool;
        private CollisionPaintingTool collisionPaintingTool;

        public Form1()
        {
            ValidateConfig();
            InitializeComponent();

            tilePaintingTool = new TilePaintingTool();
            collisionPaintingTool = new CollisionPaintingTool();
            monoGameEditor1.ActivePaintingTool = tilePaintingTool;
        }

        private void ValidateConfig()
        {
            EditorConfig config = EditorConfig.Get();

            if (!File.Exists(config.ClientExecutablePath))
                throw new FileNotFoundException($"Client executable not found: {config.ClientExecutablePath}");
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

            tilePaintingTool.BrushTile = brushTile;
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
            listBoxLayers.Items.Clear();

            for (int i = 0; i < newMap.Layers.Count; i++)
            {
                listBoxLayers.Items.Add(newMap.Layers[i]);
            }

            listBoxLayers.SelectedIndex = 0;
            monoGameEditor1.SetCollisionLayerVisible(checkCollisionLayerVisible.Checked);
            OnMapNew();
        }

        private void listBoxLayers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            monoGameEditor1.ActiveLayer = listBoxLayers.SelectedIndex;
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Da Game Map (*.map)|*.map"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = File.OpenWrite(dialog.FileName))
                {
                    monoGameEditor1.SaveMap(fileStream);
                    OnMapSave(dialog.FileName);
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Da Game Map (*.map)|*.map",
                Multiselect = false,
                CheckFileExists = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = File.OpenRead(dialog.FileName))
                {
                    monoGameEditor1.LoadMap(fileStream);
                    OnMapLoad(dialog.FileName);
                }
            }
        }

        private void checkCollisionLayerVisible_CheckedChanged(object sender, System.EventArgs e)
        {
            monoGameEditor1.SetCollisionLayerVisible(checkCollisionLayerVisible.Checked);
        }

        private void OnMapNew()
        {
            Text = TITLE_TEXT;
            previewToolStripMenuItem.Enabled = false;
            currentMapPath = null;
        }

        private void OnMapSave(string mapPath)
        {
            Text = string.Format(TITLE_TEXT_SAVED, mapPath);
            previewToolStripMenuItem.Enabled = true;
            currentMapPath = mapPath;
        }

        private void OnMapLoad(string mapPath)
        {
            Text = string.Format(TITLE_TEXT_SAVED, mapPath);
            previewToolStripMenuItem.Enabled = true;
            currentMapPath = mapPath;
        }

        private void previewToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            EditorConfig config = EditorConfig.Get();

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Path.GetFullPath(config.ClientExecutablePath),
                    Arguments = $"--map \"{Path.GetFullPath(currentMapPath)}\""
                }
            };

            process.Start();
            process.WaitForExit();
        }

        private void toolStripPaintTiles_Click(object sender, System.EventArgs e)
        {
            monoGameEditor1.ActivePaintingTool = tilePaintingTool;
            toolbox.SelectedIndex = 0;
        }

        private void toolStripPaintCollision_Click(object sender, System.EventArgs e)
        {
            monoGameEditor1.ActivePaintingTool = collisionPaintingTool;
            toolbox.SelectedIndex = 1;
        }
    }
}
