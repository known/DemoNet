using Demo.UIAuto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Demo.WinForm.UITest
{
    public partial class Runner : Form
    {
        public Runner()
        {
            InitializeComponent();
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Exe文件(*.exe)|*.exe";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = dialog.FileName;
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            var process = Process.Start(txtFile.Text);
            var processId = process.Id;

            var steps = new List<string>();
            steps.Add("SetValue=>textBox1=>d[text1]");
            steps.Add("SetValueAndEnter=>textBox2=>d[text2]");

            for (int i = 0; i < 10; i++)
            {
                var data = new Dictionary<string, string>();
                data.Add("text1", "key-text1-" + i);
                data.Add("text2", "key-text2-" + i);
                foreach (var step in steps)
                {
                    new Step(processId, step, data).Perform();
                }
            }
        }
    }
}
