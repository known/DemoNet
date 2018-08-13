namespace Demo.WinForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.TreeMenu = new System.Windows.Forms.TreeView();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // MainStatus
            // 
            this.MainStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainStatus.Location = new System.Drawing.Point(0, 420);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.MainStatus.Size = new System.Drawing.Size(754, 22);
            this.MainStatus.TabIndex = 1;
            this.MainStatus.Text = "statusStrip1";
            // 
            // TreeMenu
            // 
            this.TreeMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.TreeMenu.Location = new System.Drawing.Point(0, 0);
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.Size = new System.Drawing.Size(138, 420);
            this.TreeMenu.TabIndex = 2;
            this.TreeMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeMenu_AfterSelect);
            // 
            // PanelContainer
            // 
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Location = new System.Drawing.Point(138, 0);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Padding = new System.Windows.Forms.Padding(5);
            this.PanelContainer.Size = new System.Drawing.Size(616, 420);
            this.PanelContainer.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 442);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.TreeMenu);
            this.Controls.Add(this.MainStatus);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "DemoLite";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip MainStatus;
        private System.Windows.Forms.TreeView TreeMenu;
        private System.Windows.Forms.Panel PanelContainer;
    }
}

