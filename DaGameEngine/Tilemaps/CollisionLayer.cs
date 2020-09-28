using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGameEngine.Tilemaps
{
    public class CollisionLayer
    {
        public bool Visible { get; set; }

        private int cellWidth;
        private int cellHeight;
        private bool[,] cells;

        public CollisionLayer(int cellWidth, int cellHeight, int width, int height)
        {
            this.cellWidth = cellWidth;
            this.cellHeight = cellHeight;

            cells = new bool[width, height];
        }

        internal CollisionLayer(BinaryReader reader)
        {
            Load(reader);
        }

        public void UpdateCell(bool walkable, int x, int y)
        {
            cells[x, y] = walkable;
        }

        public CellPositionDetail GetCellAtPosition(Vector2 position)
        {
            CellPositionDetail detail = new CellPositionDetail();

            int x = (int)position.X / cellWidth;
            int y = (int)position.Y / cellHeight;

            detail.Coordinates = new Point(x, y);

            if (x < 0 || y < 0 || x > cells.GetUpperBound(0) || y > cells.GetUpperBound(1))
            {
                detail.IsValidPosition = false;
                return detail;
            }

            detail.IsValidPosition = true;
            detail.IsWalkable = cells[x, y];
            return detail;
        }

        public void Draw(SpriteBatch spriteBatch, Camera<Vector2> camera)
        {
            if (!Visible)
                return;

            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    Vector2 cellPosition = new Vector2(x * cellWidth, y * cellHeight);
                    bool walkable = cells[x, y];

                    if (walkable)
                        spriteBatch.FillRectangle(cellPosition, new Size2(cellWidth, cellHeight), Color.Green * 0.5f);
                    else
                        spriteBatch.FillRectangle(cellPosition, new Size2(cellWidth, cellHeight), Color.Red * 0.5f);

                    spriteBatch.DrawRectangle(cellPosition, new Size2(cellWidth, cellHeight), Color.White);
                }
            }
        }

        internal void Save(BinaryWriter writer)
        {
            writer.Write(cellWidth);
            writer.Write(cellHeight);
            writer.Write(cells.GetLength(0));
            writer.Write(cells.GetLength(1));

            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    writer.Write(cells[x, y]);
                }
            }
        }

        private void Load(BinaryReader reader)
        {
            cellWidth = reader.ReadInt32();
            cellHeight = reader.ReadInt32();
            int width = reader.ReadInt32();
            int height = reader.ReadInt32();

            cells = new bool[width, height];
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    cells[x, y] = reader.ReadBoolean();
                }
            }
        }

        public class CellPositionDetail
        {
            public Point Coordinates { get; set; }
            public bool IsValidPosition { get; set; }
            public bool IsWalkable { get; set; }
        }
    }
}
