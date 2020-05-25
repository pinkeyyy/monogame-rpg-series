using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;

namespace DaGameEngine.Tilemaps
{
    public class Map
    {
        public List<TileLayer> Layers { get; private set; }

        private int tileWidth;
        private int tileHeight;
        private List<Tuple<int, int, Tile>> immediateTiles = new List<Tuple<int, int, Tile>>();

        public Map(int tileWidth, int tileHeight, int width, int height)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            Layers = new List<TileLayer>();
            Layers.Add(new TileLayer(tileWidth, tileHeight, width, height, "Base Layer"));
            Layers.Add(new TileLayer(tileWidth, tileHeight, width, height, "Second Layer"));
        }

        public TileLayer.TilePositionDetail GetTileAtPosition(Vector2 position, int layerIndex)
        {
            if (layerIndex < 0 || layerIndex >= Layers.Count)
                return null;

            return Layers[layerIndex].GetTileAtPosition(position);
        }

        public void AddImmediateTile(int x, int y, Tile tile)
        {
            immediateTiles.Add(new Tuple<int, int, Tile>(x, y, tile));
        }

        public void Draw(SpriteBatch pSpriteBatch, Camera<Vector2> camera, List<Tileset> tilesets)
        {
            pSpriteBatch.Begin(transformMatrix: camera.GetViewMatrix());

            for (int i = 0; i < Layers.Count; i++)
            {
                Layers[i].Draw(pSpriteBatch, camera, tilesets);
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
