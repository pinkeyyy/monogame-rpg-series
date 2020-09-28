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
        public Tile BrushTile { get;set; }
        public int ActiveLayer { get; set; }
        public PaintMode Mode { get; set; }

        private Map myMap;
        private Form form;
        private Size2 viewportSize;
        private OrthographicCamera camera;

        protected override void Initialize()
        {
            base.Initialize();
            Bootstrap = new Bootstrap(GraphicsDevice, @"..\..\..\Content");
            CreateMap(10, 10, 32, 32);
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
            NewMap?.Invoke(myMap);
        }

        public void SaveMap(Stream stream)
        {
            myMap.Save(stream);
        }

        public void LoadMap(Stream stream)
        {
            myMap = new Map(stream);
            NewMap?.Invoke(myMap);
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
            else if (mouseState.IsButtonDown(MouseButton.Left))
            {
                if (Mode == PaintMode.Tiles && tile != null && BrushTile != null)
                {
                    tile.TilesetIndex = BrushTile.TilesetIndex;
                    tile.TileIndex = BrushTile.TileIndex;
                }
                else if (Mode == PaintMode.Collision && cellPositionDetail.IsValidPosition)
                {
                    if (keyboardState.IsControlDown())
                        myMap.CollisionLayer.UpdateCell(false, cellPositionDetail.Coordinates.X, cellPositionDetail.Coordinates.Y);
                    else
                        myMap.CollisionLayer.UpdateCell(true, cellPositionDetail.Coordinates.X, cellPositionDetail.Coordinates.Y);
                }
            }

            if (BrushTile != null && tilePositionDetail.IsValidPosition)
                myMap.AddImmediateTile(tilePositionDetail.Coordinates.X, tilePositionDetail.Coordinates.Y, BrushTile);
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

        public enum PaintMode
        {
            Tiles = 0,
            Collision = 1
        }
    }
}
