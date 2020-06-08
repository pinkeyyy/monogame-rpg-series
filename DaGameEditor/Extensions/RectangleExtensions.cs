using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGameEditor.Extensions
{
    static class RectangleExtensions
    {
        public static Rectangle Scale(this Rectangle rect, float factor)
        {
            return new Rectangle(
                Convert.ToInt32(rect.X * factor),
                Convert.ToInt32(rect.Y * factor),
                Convert.ToInt32(rect.Width * factor),
                Convert.ToInt32(rect.Height * factor)
            );
        }
    }
}
