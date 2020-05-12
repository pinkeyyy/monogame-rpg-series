using DaGameEngine.Tilemaps;
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
    public partial class EditTilesetDialog : Form
    {
        public Tileset SourceTileset { get; set; }

        public EditTilesetDialog()
        {
            InitializeComponent();
        }
    }
}
