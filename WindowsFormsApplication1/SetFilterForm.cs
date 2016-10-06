using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class SetFilterForm : Form
    {                                                      
        public delegate void setfilter(string filter);                 //设置过滤规则的函数
        public setfilter SetFilter;
        public delegate bool checkfilter(string filter);               //检查过滤规则是否合法
        public checkfilter CheckFilter;
        public delegate void startcapture();
        public startcapture StartCapture;

        public SetFilterForm()
        {
            InitializeComponent();
        }

        private void SetFilterForm_FormClosing(object sender, FormClosingEventArgs e)
        { 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SetFilter != null)
            {
                SetFilter(textBox_Filter.Text.ToString());
            }
            if (StartCapture != null)
            {
                StartCapture();
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("过滤器设置未保存！");
            if (SetFilter != null )
            {
                SetFilter("");
            }
            this.Close();
        }

        private void textBox_Filter_TextChanged(object sender, EventArgs e)
        {
            if (CheckFilter != null)
            {
                if (CheckFilter(textBox_Filter.Text.ToString()))
                {
                    textBox_Filter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));//翠绿色
                }
                else
                {
                    textBox_Filter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));//粉红色
                    textBox_Filter.Focus();
                }
            }
        }
    }
}
