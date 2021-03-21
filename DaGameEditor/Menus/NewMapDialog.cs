using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaGameEditor.Menus
{
    public partial class NewMapDialog : Form
    {
        public CreationDetails Details { get; private set; }

        public NewMapDialog()
        {
            InitializeComponent();
        }

        private void NewMapDialog_Load(object sender, EventArgs e)
        {
            EditorConfig config = EditorConfig.Get();

            numericMapWidth.Value = config.DefaultMapWidth;
            numericMapHeight.Value = config.DefaultMapHeight;
            numericTileWidth.Value = config.DefaultTileWidth;
            numericTileHeight.Value = config.DefaultTileHeight;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Details = new CreationDetails()
            {
                MapWidth = (int)numericMapWidth.Value,
                MapHeight = (int)numericMapHeight.Value,
                TileWidth = (int)numericTileWidth.Value,
                TileHeight = (int)numericTileHeight.Value
            };

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDown_Enter(object sender, EventArgs e)
        {
            NumericUpDown numericControl = (NumericUpDown)sender;
            numericControl.Select(0, numericControl.Text.Length);
        }

        public class CreationDetails
        {
            public int MapWidth { get; set; }
            public int MapHeight { get; set; }
            public int TileWidth { get; set; }
            public int TileHeight { get; set; }
        }
    }
}
