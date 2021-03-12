using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaGameEditor.Controls
{
    class Toolbox : TabControl
    {
        protected override void OnCreateControl()
        {
            if (!DesignMode)
            {
                Appearance = TabAppearance.FlatButtons;
                ItemSize = new Size(0, 1);
                SizeMode = TabSizeMode.Fixed;
            }
        }
    }
}
