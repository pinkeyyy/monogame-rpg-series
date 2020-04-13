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

        public Image Image
        {
            get
            {
                return tilesetPictureBox.Image;
            }
            set
            {
                tilesetPictureBox.Image = value;
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
