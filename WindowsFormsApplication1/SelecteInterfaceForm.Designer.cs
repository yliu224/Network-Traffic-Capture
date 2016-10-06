namespace WindowsFormsApplication1
{
    partial class SelecteInterfaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelecteInterfaceForm));
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.but_setfilter = new System.Windows.Forms.Button();
            this.but_start = new System.Windows.Forms.Button();
            this.tablay_interface = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(514, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "退 出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.but_setfilter);
            this.panel2.Controls.Add(this.but_start);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(13, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 38);
            this.panel2.TabIndex = 3;
            // 
            // but_setfilter
            // 
            this.but_setfilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_setfilter.Location = new System.Drawing.Point(433, 4);
            this.but_setfilter.Name = "but_setfilter";
            this.but_setfilter.Size = new System.Drawing.Size(75, 23);
            this.but_setfilter.TabIndex = 4;
            this.but_setfilter.Text = "设  置";
            this.but_setfilter.UseVisualStyleBackColor = true;
            this.but_setfilter.Click += new System.EventHandler(this.but_setfilter_Click);
            // 
            // but_start
            // 
            this.but_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_start.Location = new System.Drawing.Point(352, 4);
            this.but_start.Name = "but_start";
            this.but_start.Size = new System.Drawing.Size(75, 23);
            this.but_start.TabIndex = 3;
            this.but_start.Text = "开 始";
            this.but_start.UseVisualStyleBackColor = true;
            this.but_start.Click += new System.EventHandler(this.but_start_Click);
            // 
            // tablay_interface
            // 
            this.tablay_interface.AutoScroll = true;
            this.tablay_interface.ColumnCount = 5;
            this.tablay_interface.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablay_interface.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablay_interface.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablay_interface.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablay_interface.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablay_interface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablay_interface.Location = new System.Drawing.Point(0, 0);
            this.tablay_interface.Name = "tablay_interface";
            this.tablay_interface.RowCount = 1;
            this.tablay_interface.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablay_interface.Size = new System.Drawing.Size(587, 147);
            this.tablay_interface.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tablay_interface);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 151);
            this.panel1.TabIndex = 0;
            // 
            // SelecteInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(616, 210);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelecteInterfaceForm";
            this.Text = "选择网卡";
            this.Load += new System.EventHandler(this.SelecteInterfaceForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tablay_interface;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button but_start;
        private System.Windows.Forms.Button but_setfilter;
    }
}