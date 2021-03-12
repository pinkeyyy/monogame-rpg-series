using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DaGameEditor.Controls
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class ToolStripRadioButton : ToolStripButton
    {
        public ToolStripRadioButton()
        {
            CheckOnClick = true;
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            if (Parent == null)
                return;

            if (Checked == true)
            {
                List<ToolStripRadioButton> otherRadioButtons = Parent.Items.OfType<ToolStripRadioButton>().Where(r => r != this).ToList();
                otherRadioButtons.ForEach(r =>
                {
                    r.Checked = false;
                });
            }
        }
    }
}
