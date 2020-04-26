using DaGameEngine;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Input;
using MonoGame.Forms.Controls;
using System.Windows.Forms;

namespace DaGameEditor
{
    class MonoGameEditor : MonoGameControl
    {
        private Map myMap;
        private Form form;
        private Size2 viewportSize;
        private OrthographicCamera camera;

        protected override void Initialize()
        {
            base.Initialize();
            myMap = new Map(32, 32, 10, 10);
            form = FindForm();

            camera = new OrthographicCamera(GraphicsDevice)
            {
                MinimumZoom = 0.25f,
                MaximumZoom = 1.25f
            };
        }

        public void CreateMap(int mapWidth, int mapHeight, int tileWidth, int tileHeight)
        {
            myMap = new Map(tileWidth, tileHeight, mapWidth, mapHeight);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!form.ContainsFocus)
                return;

            HandleViewportSizeChange();

            MouseStateExtended mouseState = MouseExtended.GetState();

            if (mouseState.IsButtonDown(MouseButton.Right))
            {
                camera.Move(mouseState.DeltaPosition.ToVector2() / camera.Zoom);
            }
            else if (mouseState.DeltaScrollWheelValue != 0)
            {
                camera.Zoom = MathHelper.Clamp(camera.Zoom + mouseState.DeltaScrollWheelValue * 0.001f, camera.MinimumZoom, camera.MaximumZoom);
            }
            else if (mouseState.WasButtonJustUp(MouseButton.Left))
            {
                Point mousePosition = mouseState.Position;
                Vector2 worldPosition = camera.ScreenToWorld(mousePosition.ToVector2());

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
            myMap.Draw(Editor.spriteBatch, camera);
        }

        private void HandleViewportSizeChange()
        {
            Size2 graphicsDeviceSize = new Size2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            if (viewportSize != graphicsDeviceSize)
            {
                Vector2 cameraCenter = camera.Center;
                camera.Origin = new Vector2(graphicsDeviceSize.Width / 2, graphicsDeviceSize.Height / 2);
                camera.LookAt(cameraCenter);

                viewportSize = graphicsDeviceSize;
            }
        }
    }
}
