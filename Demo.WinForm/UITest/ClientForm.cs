using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.WinForm.UITest
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void tslOneForm_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var control = new OneFormControl();
            control.Dock = DockStyle.Fill;
            panel1.Controls.Add(control);
        }

        private void tslMoreForm_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var control = new MoreFormControl();
            control.Dock = DockStyle.Fill;
            panel1.Controls.Add(control);
        }
    }
}
