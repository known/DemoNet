using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Demo.WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTreeMenu();
        }

        private void TreeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes != null && e.Node.Nodes.Count > 0)
                return;

            PanelContainer.Controls.Clear();
            Control control = null;

            var typeName = e.Node.Parent != null
                         ? $"Demo.WinForm.{e.Node.Parent.Name}.{e.Node.Name}Control"
                         : $"Demo.WinForm.Common.{e.Node.Name}Control";
            var controlType = Type.GetType(typeName);
            if (controlType == null)
                control = CreateErrorControl($"暂无类型控件{typeName}");
            else
                control = Activator.CreateInstance(controlType) as Control;

            if (control != null)
            {
                control.Dock = DockStyle.Fill;
                PanelContainer.Controls.Add(control);
            }
        }

        private void LoadTreeMenu()
        {
            var path = $@"{Application.StartupPath}\Configs\Menu.xml";
            var doc = new XmlDocument();
            doc.Load(path);
            var root = doc.SelectSingleNode("menus");

            foreach (XmlNode node in root.ChildNodes)
            {
                var key = node.Attributes["id"].Value;
                var text = node.Attributes["name"].Value;
                var treeNode = TreeMenu.Nodes.Add(key, text);
                LoadTreeMenu(treeNode, node);
            }
        }

        private void LoadTreeMenu(TreeNode treeNode, XmlNode xmlNode)
        {
            if (!xmlNode.HasChildNodes)
                return;

            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                var key = node.Attributes["id"].Value;
                var text = node.Attributes["name"].Value;
                var tn = treeNode.Nodes.Add(key, text);
                LoadTreeMenu(tn, node);
            }
        }

        private Control CreateErrorControl(string message)
        {
            var label = new Label();
            label.Font = new Font(FontFamily.GenericSansSerif, 14);
            label.ForeColor = Color.Red;
            label.AutoSize = false;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Text = message;
            return label;
        }
    }
}
