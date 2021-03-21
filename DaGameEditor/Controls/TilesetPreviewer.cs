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
        private readonly List<float> zoomLevels = new List<float>()
        {
            0.25f,
            0.5f,
            0.75f,
            1f,
            1.25f,
            1.5f,
            1.75f,
            2f
        };

        private PictureBox tilesetPictureBox;
        private Tileset tileset;
        private int selectedFrameIndex = -1;
        private Size originalSize;
        private int currentZoomLevel;
        private int currentEventNumber = 0;

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
                OnTilesetChange();
            }
        }

        public TilesetPreviewer()
        {
            AutoScroll = true;

            tilesetPictureBox = new PictureBox();
            tilesetPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(tilesetPictureBox);
        }

        protected override void OnCreateControl()
        {
            if (!DesignMode)
            {
                tilesetPictureBox.Click += TilesetPictureBox_Click;
                tilesetPictureBox.Paint += TilesetPictureBox_Paint;
                tilesetPictureBox.MouseWheel += TilesetPictureBox_MouseWheel;
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
                MonoGameRectangle scaledRect = frameRects[i].Scale(zoomLevels[currentZoomLevel]);
                if (scaledRect.Contains(mousePoint))
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
                MonoGameRectangle frameRect = frameRects[i].Scale(zoomLevels[currentZoomLevel]);
                SystemRectangle drawingRect = new SystemRectangle(frameRect.X, frameRect.Y, frameRect.Width - 1, frameRect.Height - 1);

                if (selectedFrameIndex == i)
                    e.Graphics.DrawRectangle(Pens.Red, drawingRect);
                else
                    e.Graphics.DrawRectangle(Pens.Blue, drawingRect);
            }
        }

        private void TilesetPictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys != Keys.Shift)
                return;

            HandledMouseEventArgs handledArgs = (HandledMouseEventArgs)e;
            handledArgs.Handled = true;

            if (SystemInformation.MouseWheelScrollLines != -1 && currentEventNumber < SystemInformation.MouseWheelScrollLines)
            {
                currentEventNumber++;
                return;
            }

            currentEventNumber = 0;


            if (e.Delta > 0)
            {
                // Zoom in
                currentZoomLevel = Math.Min(currentZoomLevel + 1, zoomLevels.Count - 1);
            }
            else
            {
                // Zoom out
                currentZoomLevel = Math.Max(currentZoomLevel - 1, 0);
            }

            tilesetPictureBox.Size = new Size((int)(originalSize.Width * zoomLevels[currentZoomLevel]), (int)(originalSize.Height * zoomLevels[currentZoomLevel]));
        }

        private void OnTilesetChange()
        {
            if (Tileset == null)
            {
                tilesetPictureBox.Image = null;
                return;
            }

            Image tilesetImage = tileset.GetImageFromTexture();
            tilesetPictureBox.Image = tilesetImage;
            tilesetPictureBox.Size = new Size(tilesetImage.Width, tilesetImage.Height);
            originalSize = tilesetPictureBox.Size;
            currentZoomLevel = 3;
        }
    }
}
