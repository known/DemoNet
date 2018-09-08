using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.WinForm.UITest
{
    [ToolboxItem(false)]
    public partial class OneFormControl : UserControl
    {
        public OneFormControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(string.Format("{0}|{1}", textBox1.Text, textBox2.Text));
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Items.Add(string.Format("{0}|{1}", textBox1.Text, textBox2.Text));
            }
        }
    }
}
