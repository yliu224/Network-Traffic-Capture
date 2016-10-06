using WindowsFormsApplication1.Tools;
namespace WindowsFormsApplication1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择网卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置过滤规则ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView_PacketInfo = new WindowsFormsApplication1.Tools.ListViewNF();
            this.编号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.时间 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.源IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.目的IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.协议 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.长度 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBox_Byte = new System.Windows.Forms.TextBox();
            this.treeView_PacketInfo = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.but_netinterface = new System.Windows.Forms.ToolStripButton();
            this.but_filter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.but_start = new System.Windows.Forms.ToolStripButton();
            this.but_stop = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.menuStrip1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(741, 25);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(140, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.另存为ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择网卡ToolStripMenuItem,
            this.设置过滤规则ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 选择网卡ToolStripMenuItem
            // 
            this.选择网卡ToolStripMenuItem.Name = "选择网卡ToolStripMenuItem";
            this.选择网卡ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.选择网卡ToolStripMenuItem.Text = "选择网卡";
            this.选择网卡ToolStripMenuItem.Click += new System.EventHandler(this.选择网卡ToolStripMenuItem_Click);
            // 
            // 设置过滤规则ToolStripMenuItem
            // 
            this.设置过滤规则ToolStripMenuItem.Name = "设置过滤规则ToolStripMenuItem";
            this.设置过滤规则ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.设置过滤规则ToolStripMenuItem.Text = "设置过滤规则";
            this.设置过滤规则ToolStripMenuItem.Click += new System.EventHandler(this.设置过滤规则ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView_PacketInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(741, 358);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.TabIndex = 1;
            // 
            // listView_PacketInfo
            // 
            this.listView_PacketInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.编号,
            this.时间,
            this.源IP,
            this.目的IP,
            this.协议,
            this.长度});
            this.listView_PacketInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_PacketInfo.FullRowSelect = true;
            this.listView_PacketInfo.Location = new System.Drawing.Point(0, 0);
            this.listView_PacketInfo.Name = "listView_PacketInfo";
            this.listView_PacketInfo.Size = new System.Drawing.Size(741, 237);
            this.listView_PacketInfo.TabIndex = 0;
            this.listView_PacketInfo.UseCompatibleStateImageBehavior = false;
            this.listView_PacketInfo.View = System.Windows.Forms.View.Details;
            this.listView_PacketInfo.SelectedIndexChanged += new System.EventHandler(this.listView_PacketInfo_SelectedIndexChanged);
            // 
            // 编号
            // 
            this.编号.Text = "编号";
            // 
            // 时间
            // 
            this.时间.Text = "时间";
            this.时间.Width = 105;
            // 
            // 源IP
            // 
            this.源IP.Text = "源IP";
            this.源IP.Width = 200;
            // 
            // 目的IP
            // 
            this.目的IP.Text = "目的IP";
            this.目的IP.Width = 200;
            // 
            // 协议
            // 
            this.协议.Text = "协议";
            this.协议.Width = 75;
            // 
            // 长度
            // 
            this.长度.Text = "长度";
            this.长度.Width = 90;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.textBox_Byte);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.treeView_PacketInfo);
            this.splitContainer2.Size = new System.Drawing.Size(741, 117);
            this.splitContainer2.SplitterDistance = 379;
            this.splitContainer2.TabIndex = 0;
            // 
            // textBox_Byte
            // 
            this.textBox_Byte.AcceptsReturn = true;
            this.textBox_Byte.AcceptsTab = true;
            this.textBox_Byte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_Byte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Byte.Location = new System.Drawing.Point(0, 0);
            this.textBox_Byte.Multiline = true;
            this.textBox_Byte.Name = "textBox_Byte";
            this.textBox_Byte.ReadOnly = true;
            this.textBox_Byte.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Byte.Size = new System.Drawing.Size(379, 117);
            this.textBox_Byte.TabIndex = 0;
            // 
            // treeView_PacketInfo
            // 
            this.treeView_PacketInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_PacketInfo.Location = new System.Drawing.Point(0, 0);
            this.treeView_PacketInfo.Name = "treeView_PacketInfo";
            this.treeView_PacketInfo.Size = new System.Drawing.Size(358, 117);
            this.treeView_PacketInfo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 26);
            this.panel1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.but_netinterface,
            this.but_filter,
            this.toolStripSeparator1,
            this.but_start,
            this.but_stop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(739, 24);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // but_netinterface
            // 
            this.but_netinterface.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.but_netinterface.Image = ((System.Drawing.Image)(resources.GetObject("but_netinterface.Image")));
            this.but_netinterface.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.but_netinterface.Name = "but_netinterface";
            this.but_netinterface.Size = new System.Drawing.Size(23, 21);
            this.but_netinterface.Text = "网卡选择";
            this.but_netinterface.Click += new System.EventHandler(this.but_netinterface_Click);
            // 
            // but_filter
            // 
            this.but_filter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.but_filter.Image = ((System.Drawing.Image)(resources.GetObject("but_filter.Image")));
            this.but_filter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.but_filter.Name = "but_filter";
            this.but_filter.Size = new System.Drawing.Size(23, 21);
            this.but_filter.Text = "过滤设置";
            this.but_filter.Click += new System.EventHandler(this.but_filter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
            // 
            // but_start
            // 
            this.but_start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.but_start.Image = ((System.Drawing.Image)(resources.GetObject("but_start.Image")));
            this.but_start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.but_start.Name = "but_start";
            this.but_start.Size = new System.Drawing.Size(23, 21);
            this.but_start.Text = "开始";
            this.but_start.Click += new System.EventHandler(this.but_start_Click);
            // 
            // but_stop
            // 
            this.but_stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.but_stop.Image = ((System.Drawing.Image)(resources.GetObject("but_stop.Image")));
            this.but_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.but_stop.Name = "but_stop";
            this.but_stop.Size = new System.Drawing.Size(23, 21);
            this.but_stop.Text = "停止";
            this.but_stop.Click += new System.EventHandler(this.but_stop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 407);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dean丁";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择网卡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置过滤规则ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton but_netinterface;
        private System.Windows.Forms.ToolStripButton but_filter;
        private System.Windows.Forms.ToolStripButton but_stop;
        private System.Windows.Forms.ToolStripButton but_start;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.TreeView treeView_PacketInfo;
        public ListViewNF listView_PacketInfo;
        public System.Windows.Forms.ColumnHeader 编号;
        public System.Windows.Forms.ColumnHeader 时间;
        public System.Windows.Forms.ColumnHeader 源IP;
        public System.Windows.Forms.ColumnHeader 目的IP;
        public System.Windows.Forms.ColumnHeader 协议;
        public System.Windows.Forms.ColumnHeader 长度;
        public System.Windows.Forms.TextBox textBox_Byte;
    }
}

