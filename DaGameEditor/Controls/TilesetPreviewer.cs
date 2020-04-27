using DaGameEditor.Extensions;
using DaGameEngine.Tilemaps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaGameEditor.Controls
{
    class TilesetPreviewer : Panel
    {
        private PictureBox tilesetPictureBox;
        private Tileset tileset;

        public Tileset Tileset
        {
            get
            {
                return tileset;
            }
            set
            {
                tileset = value;
                tilesetPictureBox.Image = tileset != null ? tileset.GetImageFromTexture() : null;
            }
        }

        public TilesetPreviewer()
        {
            AutoScroll = true;

            tilesetPictureBox = new PictureBox();
            tilesetPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            Controls.Add(tilesetPictureBox);
        }
    }
}
