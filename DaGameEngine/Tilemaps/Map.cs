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
        private List<TileLayer> layers;
        private List<Tuple<int, int, Tile>> immediateTiles = new List<Tuple<int, int, Tile>>();

        public Map(int tileWidth, int tileHeight, int width, int height)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            layers = new List<TileLayer>();
            layers.Add(new TileLayer(tileWidth, tileHeight, width, height));
        }

        public TileLayer.TilePositionDetail GetTileAtPosition(Vector2 position, int layerIndex)
        {
            if (layerIndex < 0 || layerIndex >= layers.Count)
                return null;

            return layers[layerIndex].GetTileAtPosition(position);
        }

        public void AddImmediateTile(int x, int y, Tile tile)
        {
            immediateTiles.Add(new Tuple<int, int, Tile>(x, y, tile));
        }

        public void Draw(SpriteBatch pSpriteBatch, Camera<Vector2> camera, List<Tileset> tilesets)
        {
            pSpriteBatch.Begin(transformMatrix: camera.GetViewMatrix());

            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].Draw(pSpriteBatch, camera, tilesets);
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
    }
}
