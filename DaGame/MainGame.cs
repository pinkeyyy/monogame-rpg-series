using DaGameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace DaGame
{
    class MainGame : Game
    {
        private GraphicsDeviceManager manager;
        private Map myMap;
        private SpriteBatch spriteBatch;
        private OrthographicCamera camera;

        public MainGame()
        {
            manager = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myMap = new Map(32, 32, 10, 10);
            camera = new OrthographicCamera(GraphicsDevice);
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

            myMap.Draw(spriteBatch, camera);
        }
    }
}
