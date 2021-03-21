using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System.Collections.Generic;

namespace DaGameEngine.Tilemaps
{
    public class Tile
    {
        public int TilesetIndex { get; set; } = -1;
        public int TileIndex { get; set; } = -1;

        public void Draw(SpriteBatch spriteBatch, Vector2 tilePosition, int tileWidth, int tileHeight, List<Tileset> tilesets, bool scaleTiles)
        {
            spriteBatch.DrawRectangle(tilePosition, new Size2(tileWidth, tileHeight), Color.White);

            if (TilesetIndex != -1 && TileIndex != -1)
            {
                Tileset tileset = tilesets[TilesetIndex];
                if (scaleTiles)
                    spriteBatch.Draw(tileset.Texture, new Rectangle(tilePosition.ToPoint(), new Point(tileWidth, tileHeight)) , tileset.Frames[TileIndex], Color.White);
                else
                    spriteBatch.Draw(tileset.Texture, tilePosition, tileset.Frames[TileIndex], Color.White);
            }
        }
    }
}
