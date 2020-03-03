using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace DaGameEngine
{
    public class Map
    {
        private int tileWidth;
        private int tileHeight;
        private int width;
        private int height;

        public OrthographicCamera Camera;

        public Map(GraphicsDevice device, int tileWidth, int tileHeight, int width, int height)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.width = width;
            this.height = height;

            Camera = new OrthographicCamera(device);
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Begin(transformMatrix: Camera.GetViewMatrix());

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2 tilePosition = new Vector2(x * tileWidth, y * tileHeight);

                    pSpriteBatch.FillRectangle(tilePosition, new Size2(tileWidth, tileHeight), Color.White);
                    pSpriteBatch.FillRectangle(tilePosition + new Vector2(1, 1), new Size2(tileWidth - 2, tileHeight - 2), Color.Black);
                }
            }

            pSpriteBatch.End();
        }
    }
}
