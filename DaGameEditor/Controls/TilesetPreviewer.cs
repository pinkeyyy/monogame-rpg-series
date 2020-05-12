using DaGameEditor.Extensions;
using DaGameEngine.Tilemaps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MonoGamePoint = Microsoft.Xna.Framework.Point;
using MonoGameRectangle = Microsoft.Xna.Framework.Rectangle;
using SystemRectangle = System.Drawing.Rectangle;

namespace DaGameEditor.Controls
{
    class TilesetPreviewer : Panel
    {
        private PictureBox tilesetPictureBox;
        private Tileset tileset;
        private int selectedFrameIndex = -1;

        public delegate void OnTileSelectHandler(Tileset tileset, int frameIndex);
        public event OnTileSelectHandler TileSelect;

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

        protected override void OnCreateControl()
        {
            if (!DesignMode)
            {
                tilesetPictureBox.Click += TilesetPictureBox_Click;
                tilesetPictureBox.Paint += TilesetPictureBox_Paint;
            }
        }

        public void RefreshFrames()
        {
            tilesetPictureBox.Invalidate();
        }

        private void TilesetPictureBox_Click(object sender, EventArgs e)
        {
            if (tileset == null)
                return;

            MouseEventArgs mouseArgs = (MouseEventArgs)e;
            MonoGamePoint mousePoint = new MonoGamePoint(mouseArgs.X, mouseArgs.Y);

            List<MonoGameRectangle> frameRects = tileset.Frames;
            for (int i = 0; i < frameRects.Count; i++)
            {
                if (frameRects[i].Contains(mousePoint))
                {
                    selectedFrameIndex = i;

                    TileSelect?.Invoke(tileset, selectedFrameIndex);

                    RefreshFrames();
                }
            }
        }

        private void TilesetPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (tileset == null)
                return;

            List<MonoGameRectangle> frameRects = tileset.Frames;
            for (int i = 0; i < frameRects.Count; i++)
            {
                MonoGameRectangle frameRect = frameRects[i];
                SystemRectangle drawingRect = new SystemRectangle(frameRect.X, frameRect.Y, frameRect.Width - 1, frameRect.Height - 1);

                if (selectedFrameIndex == i)
                    e.Graphics.DrawRectangle(Pens.Red, drawingRect);
                else
                    e.Graphics.DrawRectangle(Pens.Blue, drawingRect);
            }
        }
    }
}
