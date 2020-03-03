using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace DaGame
{
    class Map
    {
        private int tileWidth;
        private int tileHeight;
        private int width;
        private int height;

        public Camera2D Camera;

        public Map(GraphicsDevice pDevice, int pTileWidth, int pTileHeight, int pWidth, int pHeight)
        {
            tileWidth = pTileWidth;
            tileHeight = pTileHeight;
            width = pWidth;
            height = pHeight;

            Camera = new Camera2D(pDevice);
        }

        public void draw(SpriteBatch pSpriteBatch)
        {
            Vector2 tilePosition = Vector2.Zero;

            pSpriteBatch.Begin(transformMatrix: Camera.GetViewMatrix());

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pSpriteBatch.FillRectangle(tilePosition, new Size2(tileWidth, tileHeight), Color.White);
                    pSpriteBatch.FillRectangle(tilePosition + new Vector2(1, 1), new Size2(tileWidth - 2, tileHeight - 2), Color.Black);
                    tilePosition.Y += tileHeight;
                }

                tilePosition.Y = 0;
                tilePosition.X += tileWidth;
            }

            pSpriteBatch.End();
        }
    }
}
