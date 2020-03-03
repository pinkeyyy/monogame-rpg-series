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
        private MouseStateExtended mouseState;
        private Form form;

        protected override void Initialize()
        {
            base.Initialize();
            myMap = new Map(GraphicsDevice, 32, 32, 10, 10);
            form = FindForm();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!form.ContainsFocus)
                return;

            mouseState = MouseExtended.GetState();

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
