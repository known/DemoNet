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
    public partial class MoreFormControl : UserControl
    {
        public MoreFormControl()
        {
            InitializeComponent();
        }

        private void MoreFormControl_Load(object sender, EventArgs e)
        {
            var list = new List<object>();
            list.Add(new { Code = "TV", Name = "电视" });
            list.Add(new { Code = "Mobile", Name = "手机" });
            list.Add(new { Code = "PC", Name = "台式电脑" });
            list.Add(new { Code = "Laptop", Name = "笔记本" });
            list.Add(new { Code = "Memory", Name = "内存" });
            list.Add(new { Code = "Mouse", Name = "鼠标" });
            list.Add(new { Code = "Keyboard", Name = "键盘" });
            list.Add(new { Code = "Power", Name = "电源" });
            list.Add(new { Code = "Usb", Name = "USB" });
            list.Add(new { Code = "HD", Name = "硬盘" });
            list.Add(new { Code = "CD", Name = "CD" });
            list.Add(new { Code = "DVD", Name = "DVD" });
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                textBox4.Text = rows[0].Cells[0].Value.ToString();
                textBox3.Text = rows[0].Cells[1].Value.ToString();
            }
        }
    }
}
