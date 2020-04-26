using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace DaGameEngine.Tilemaps
{
    public class Map
    {
        private int tileWidth;
        private int tileHeight;
        private Tile[,] tiles;

        public Map(int tileWidth, int tileHeight, int width, int height)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;

            tiles = new Tile[width, height];
            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    tiles[x, y] = new Tile()
                    {
                        BackgroundColor = (x + y) % 2 == 0 ? Color.Red : Color.Green
                    };
                }
            }
        }

        public Tile GetTileAtPosition(Vector2 position)
        {
            int x = (int)position.X / tileWidth;
            int y = (int)position.Y / tileHeight;

            if (x < 0 || y < 0 || x > tiles.GetUpperBound(0) || y > tiles.GetUpperBound(1))
                return null;

            return tiles[x, y];
        }

        public void Draw(SpriteBatch pSpriteBatch, Camera<Vector2> camera)
        {
            pSpriteBatch.Begin(transformMatrix: camera.GetViewMatrix());

            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    Vector2 tilePosition = new Vector2(x * tileWidth, y * tileHeight);
                    Tile tile = tiles[x, y];

                    pSpriteBatch.FillRectangle(tilePosition, new Size2(tileWidth, tileHeight), Color.White);
                    pSpriteBatch.FillRectangle(tilePosition + new Vector2(1, 1), new Size2(tileWidth - 2, tileHeight - 2), tile.BackgroundColor);
                }
            }

            pSpriteBatch.End();
        }
    }
}
