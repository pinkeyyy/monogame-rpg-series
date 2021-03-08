using DaGameEngine.Tilemaps;
using MonoGame.Extended.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGameEditor.Tools
{
    class CollisionPaintingTool : PaintingTool
    {
        public override void Hover(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition)
        {

        }

        public override bool IsValidPosition(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition)
        {
            return cellPosition.IsValidPosition;
        }

        public override void Paint(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition)
        {
            if (keyboardState.IsControlDown())
                map.CollisionLayer.UpdateCell(false, cellPosition.Coordinates.X, cellPosition.Coordinates.Y);
            else
                map.CollisionLayer.UpdateCell(true, cellPosition.Coordinates.X, cellPosition.Coordinates.Y);
        }
    }
}
