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
    public partial class GenerateFramesDialog : Form
    {
        public GenerationDetails Details { get; private set; }

        public GenerateFramesDialog()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Details = new GenerationDetails()
            {
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

        public class GenerationDetails
        {
            public int TileWidth { get; set; }
            public int TileHeight { get; set; }
        }
    }
}
