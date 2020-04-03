using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaGameEditor.Menus
{
    public partial class NewMapDialog : Form
    {
        public NewMapDialog()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            OnOk();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDown_Enter(object sender, EventArgs e)
        {
            NumericUpDown numericControl = (NumericUpDown)sender;
            numericControl.Select(0, numericControl.Text.Length);
        }

        private void numericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                OnOk();
            }
        }

        private void OnOk()
        {
            Close();
        }
    }
}
