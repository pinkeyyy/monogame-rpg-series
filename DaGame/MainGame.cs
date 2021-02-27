using DaGameEngine;
using DaGameEngine.Tilemaps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System.Collections.Generic;
using System.IO;

namespace DaGame
{
    class MainGame : Game
    {
        private LaunchOptions options;
        private GraphicsDeviceManager manager;
        private Map myMap;
        private SpriteBatch spriteBatch;
        private OrthographicCamera camera;
        private Bootstrap bootstrap;

        public MainGame(LaunchOptions options)
        {
            this.options = options;
            manager = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            bootstrap = new Bootstrap(GraphicsDevice, @"..\..\..\Content");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new OrthographicCamera(GraphicsDevice);

            if (string.IsNullOrWhiteSpace(options.Map))
            {
                myMap = new Map(32, 32, 10, 10);
            }
            else
            {
                using (FileStream fileStream = File.OpenRead(options.Map))
                {
                    myMap = new Map(fileStream);
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Vector2 moveVelocity = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                moveVelocity += new Vector2(1, 0);
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                moveVelocity += new Vector2(-1, 0);
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                moveVelocity += new Vector2(0, -1);
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                moveVelocity += new Vector2(0, 1);
            }

            camera.Move(moveVelocity);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            myMap.Draw(spriteBatch, camera, bootstrap.Tilesets);
        }
    }
}
