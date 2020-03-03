using DaGameEngine;
using MonoGame.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGameEditor
{
    class MonoGameEditor : MonoGameControl
    {
        private Map myMap;

        protected override void Initialize()
        {
            base.Initialize();
            myMap = new Map(GraphicsDevice, 32, 32, 10, 10);
        }

        protected override void Draw()
        {
            base.Draw();
            myMap.Draw(Editor.spriteBatch);
        }
    }
}
