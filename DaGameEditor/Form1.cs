using DaGameEditor.Menus;
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
    }
}
