using DaGameEngine.Tilemaps;
using MonoGame.Extended.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGameEditor.Tools
{
    class TilePaintingTool : PaintingTool
    {
        public Tile BrushTile { get; set; }

        public override void Hover(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition)
        {
            map.AddImmediateTile(tilePosition.Coordinates.X, tilePosition.Coordinates.Y, BrushTile);
        }

        public override bool IsValidPosition(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition)
        {
            return tilePosition.IsValidPosition && BrushTile != null;
        }

        public override void Paint(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition)
        {
            tilePosition.Tile.TilesetIndex = BrushTile.TilesetIndex;
            tilePosition.Tile.TileIndex = BrushTile.TileIndex;
        }
    }
}
