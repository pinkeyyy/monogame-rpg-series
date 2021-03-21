using DaGameEditor.Tools;
using DaGameEngine;
using DaGameEngine.Tilemaps;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Input;
using MonoGame.Forms.Controls;
using System.IO;
using System.Windows.Forms;

namespace DaGameEditor
{
    class MonoGameEditor : MonoGameControl
    {
        public delegate void OnNewMapHandler(Map newMap);
        public event OnNewMapHandler NewMap;

        public Bootstrap Bootstrap { get; set; }
        public int ActiveLayer { get; set; }
        public PaintingTool ActivePaintingTool { get; set; }

        private Map myMap;
        private Form form;
        private Size2 viewportSize;
        private OrthographicCamera camera;

        protected override void Initialize()
        {
            base.Initialize();

            EditorConfig config = EditorConfig.Get();

            Bootstrap = new Bootstrap(GraphicsDevice, @"..\..\..\Content");
            CreateMap(config.DefaultMapWidth, config.DefaultMapHeight, config.DefaultTileWidth, config.DefaultTileHeight);
            form = FindForm();

            camera = new OrthographicCamera(GraphicsDevice)
            {
                MinimumZoom = 0.25f,
                MaximumZoom = 1.25f
            };
        }

        public Map CreateMap(int mapWidth, int mapHeight, int tileWidth, int tileHeight)
        {
            myMap = new Map(tileWidth, tileHeight, mapWidth, mapHeight);
            NewMap?.Invoke(myMap);
            return myMap;
        }

        public void SaveMap(Stream stream)
        {
            myMap.Save(stream);
        }

        public Map LoadMap(Stream stream)
        {
            myMap = new Map(stream);
            NewMap?.Invoke(myMap);
            return myMap;
        }

        public void SetCollisionLayerVisible(bool visible)
        {
            myMap.CollisionLayer.Visible = visible;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!form.ContainsFocus)
                return;

            HandleViewportSizeChange();

            MouseStateExtended mouseState = MouseExtended.GetState();
            KeyboardStateExtended keyboardState = KeyboardExtended.GetState();
            Point mousePosition = mouseState.Position;
            Vector2 worldPosition = camera.ScreenToWorld(mousePosition.ToVector2());

            TileLayer.TilePositionDetail tilePositionDetail = myMap.GetTileAtPosition(worldPosition, ActiveLayer);
            CollisionLayer.CellPositionDetail cellPositionDetail = myMap.GetCellAtPosition(worldPosition);
            Tile tile = tilePositionDetail.Tile;

            if (mouseState.IsButtonDown(MouseButton.Right))
            {
                camera.Move(mouseState.DeltaPosition.ToVector2() / camera.Zoom);
            }
            else if (mouseState.DeltaScrollWheelValue != 0)
            {
                camera.Zoom = MathHelper.Clamp(camera.Zoom - mouseState.DeltaScrollWheelValue * 0.001f, camera.MinimumZoom, camera.MaximumZoom);
            }
            
            if (ActivePaintingTool != null)
            {
                if (ActivePaintingTool.IsValidPosition(myMap, keyboardState, tilePositionDetail, cellPositionDetail))
                {
                    if (mouseState.IsButtonDown(MouseButton.Left))
                    {
                        ActivePaintingTool.Paint(myMap, keyboardState, tilePositionDetail, cellPositionDetail);
                    }
                    else
                    {
                        ActivePaintingTool.Hover(myMap, keyboardState, tilePositionDetail, cellPositionDetail);
                    }
                }
            }
        }

        protected override void Draw()
        {
            base.Draw();
            myMap.Draw(Editor.spriteBatch, camera, Bootstrap.Tilesets);
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
