using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DaGame
{
    class MainGame : Game
    {
        private GraphicsDeviceManager manager;

        public MainGame()
        {
            manager = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
