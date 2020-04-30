using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;

namespace DaGameEngine.Tilemaps
{
    public class Map
    {
        private int tileWidth;
        private int tileHeight;
        private Tile[,] tiles;
        private List<Tuple<int, int, Tile>> immediateTiles = new List<Tuple<int, int, Tile>>();

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

        public TilePositionDetail GetTileAtPosition(Vector2 position)
        {
            TilePositionDetail detail = new TilePositionDetail();

            int x = (int)position.X / tileWidth;
            int y = (int)position.Y / tileHeight;

            detail.Coordinates = new Point(x, y);

            if (x < 0 || y < 0 || x > tiles.GetUpperBound(0) || y > tiles.GetUpperBound(1))
            {
                detail.IsValidPosition = false;
                return detail;
            }

            detail.IsValidPosition = true;
            detail.Tile = tiles[x, y];
            return detail;
        }

        public void AddImmediateTile(int x, int y, Tile tile)
        {
            immediateTiles.Add(new Tuple<int, int, Tile>(x, y, tile));
        }

        public void Draw(SpriteBatch pSpriteBatch, Camera<Vector2> camera, List<Tileset> tilesets)
        {
            pSpriteBatch.Begin(transformMatrix: camera.GetViewMatrix());

            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    Vector2 tilePosition = new Vector2(x * tileWidth, y * tileHeight);
                    Tile tile = tiles[x, y];
                    tile.Draw(pSpriteBatch, tilePosition, tileWidth, tileHeight, tilesets); 
                }
            }

            for (int i = 0; i < immediateTiles.Count; i++)
            {
                var (x, y, tile) = immediateTiles[i];
                Vector2 tilePosition = new Vector2(x * tileWidth, y * tileHeight);
                tile.Draw(pSpriteBatch, tilePosition, tileWidth, tileHeight, tilesets);
            }

            pSpriteBatch.End();
            immediateTiles.Clear();
        }

        public class TilePositionDetail
        {
            public Tile Tile { get; set; }
            public Point Coordinates { get; set; }
            public bool IsValidPosition { get; set; }
        }
    }
}
