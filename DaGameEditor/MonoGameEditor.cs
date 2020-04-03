using DaGameEngine;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Input;
using MonoGame.Forms.Controls;
using System.Windows.Forms;

namespace DaGameEditor
{
    class MonoGameEditor : MonoGameControl
    {
        private Map myMap;
        private Form form;

        protected override void Initialize()
        {
            base.Initialize();
            myMap = new Map(GraphicsDevice, 32, 32, 10, 10);
            form = FindForm();
        }

        public void CreateMap(int mapWidth, int mapHeight, int tileWidth, int tileHeight)
        {
            myMap = new Map(GraphicsDevice, tileWidth, tileHeight, mapWidth, mapHeight);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!form.ContainsFocus)
                return;

            MouseStateExtended mouseState = MouseExtended.GetState();

            if (mouseState.IsButtonDown(MouseButton.Right))
            {
                myMap.Camera.Move(mouseState.DeltaPosition.ToVector2());
            } 
            else if (mouseState.WasButtonJustUp(MouseButton.Left))
            {
                Point mousePosition = mouseState.Position;
                Vector2 worldPosition = myMap.Camera.ScreenToWorld(mousePosition.ToVector2());

                Tile tile = myMap.GetTileAtPosition(worldPosition);
                if (tile != null)
                {
                    if (tile.BackgroundColor == Color.Red)
                    {
                        tile.BackgroundColor = Color.Green;
                    }
                    else
                    {
                        tile.BackgroundColor = Color.Red;
                    }
                }
            }
        }

        protected override void Draw()
        {
            base.Draw();
            myMap.Draw(Editor.spriteBatch);
        }
    }
}
