using DaGameEngine.Tilemaps;
using MonoGame.Extended.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGameEditor.Tools
{
    abstract class PaintingTool
    {
        public abstract bool IsValidPosition(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition);
        public abstract void Hover(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition);
        public abstract void Paint(Map map, KeyboardStateExtended keyboardState, TileLayer.TilePositionDetail tilePosition, CollisionLayer.CellPositionDetail cellPosition);
    }
}
