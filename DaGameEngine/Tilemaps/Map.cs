using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.IO;

namespace DaGameEngine.Tilemaps
{
    public class Map
    {
        public List<TileLayer> Layers { get; private set; }
        public CollisionLayer CollisionLayer { get; private set; }
        public bool ScaleTiles { get; set; }

        private int tileWidth;
        private int tileHeight;
        private int width;
        private int height;
        private List<Tuple<int, int, Tile>> immediateTiles = new List<Tuple<int, int, Tile>>();

        public Map(int tileWidth, int tileHeight, int width, int height)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.width = width;
            this.height = height;
            Layers = new List<TileLayer>();
            Layers.Add(new TileLayer(tileWidth, tileHeight, width, height, "Base Layer"));
            Layers.Add(new TileLayer(tileWidth, tileHeight, width, height, "Second Layer"));

            CollisionLayer = new CollisionLayer(tileWidth, tileHeight, width, height);
        }

        public Map(Stream stream)
        {
            Layers = new List<TileLayer>();
            Load(stream);
        }

        public TileLayer.TilePositionDetail GetTileAtPosition(Vector2 position, int layerIndex)
        {
            if (layerIndex < 0 || layerIndex >= Layers.Count)
                return null;

            return Layers[layerIndex].GetTileAtPosition(position);
        }

        public CollisionLayer.CellPositionDetail GetCellAtPosition(Vector2 position)
        {
            return CollisionLayer.GetCellAtPosition(position);
        }

        public void AddImmediateTile(int x, int y, Tile tile)
        {
            immediateTiles.Add(new Tuple<int, int, Tile>(x, y, tile));
        }

        public void Draw(SpriteBatch pSpriteBatch, Camera<Vector2> camera, List<Tileset> tilesets)
        {
            pSpriteBatch.Begin(transformMatrix: camera.GetViewMatrix());

            pSpriteBatch.FillRectangle(Vector2.Zero, new Size2(tileWidth * width, tileHeight * height), Color.Gray);

            for (int i = 0; i < Layers.Count; i++)
            {
                Layers[i].Draw(pSpriteBatch, camera, tilesets, ScaleTiles);
            }

            CollisionLayer.Draw(pSpriteBatch, camera);

            for (int i = 0; i < immediateTiles.Count; i++)
            {
                var (x, y, tile) = immediateTiles[i];
                Vector2 tilePosition = new Vector2(x * tileWidth, y * tileHeight);
                tile.Draw(pSpriteBatch, tilePosition, tileWidth, tileHeight, tilesets, ScaleTiles);
            }

            pSpriteBatch.End();
            immediateTiles.Clear();
        }

        public void Save(Stream stream)
        {
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(width);
                writer.Write(height);
                writer.Write(tileWidth);
                writer.Write(tileHeight);
                writer.Write(Layers.Count);
                for (int i = 0; i < Layers.Count; i++)
                {
                    Layers[i].Save(writer);
                }
                writer.Write(ScaleTiles);
                CollisionLayer.Save(writer);
            }
        }

        private void Load(Stream stream)
        {
            using (BinaryReader reader = new BinaryReader(stream))
            {
                width = reader.ReadInt32();
                height = reader.ReadInt32();
                tileWidth = reader.ReadInt32();
                tileHeight = reader.ReadInt32();
                int layerCount = reader.ReadInt32();
                for (int i = 0; i < layerCount; i++)
                {
                    Layers.Add(new TileLayer(reader));
                }
                ScaleTiles = reader.ReadBoolean();
                CollisionLayer = new CollisionLayer(reader);
            }
        }
    }
}
