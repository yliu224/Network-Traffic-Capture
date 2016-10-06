using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpPcap;
using System.Net.NetworkInformation;

namespace WindowsFormsApplication1
{
    public partial class SelecteInterfaceForm : Form
    {
        //向MainForm传递值,delegate实例！！
        public delegate void returnselecteddevice(int sdv);
        public returnselecteddevice ReturnSelectedDevice;
        //StartCapture的delegate
        public delegate void createthread();
        public createthread CreateThread;
        //setFilter的delegate
        public delegate void setfilter();
        public setfilter setFilter;

        ////得到网卡总数
        //public delegate void getnumberofinterface(int inter);
        //public getnumberofinterface getNumberofInterface;

        List<PcapDevice> devices;                       //网卡列表
        int sdv = -1;                                   //所选择的网卡

        public SelecteInterfaceForm()
        {
            InitializeComponent();

        }
        public void setDivceList(List<PcapDevice> devices)
        {
            this.devices = devices;
        }
        private void SelecteInterfaceForm_Load(object sender, EventArgs e)
        {
            Initial();

            if (devices.Count < 1)
            {
                MessageBox.Show("没有找到网卡设备！");
                this.Close();
            }
            //if (getNumberofInterface != null)
            //{
            //    getNumberofInterface(devices.Count);
            //}

            AddDevice();

        }
        //初始化tablelayout
        private void Initial()
        {
            Label device = new Label();
            device.Text = "设备";
            device.TextAlign = ContentAlignment.MiddleCenter;

            Label descreption = new Label();
            descreption.Text = "描述";
            descreption.TextAlign = ContentAlignment.MiddleCenter;

            Label ip = new Label();
            ip.Text = "IP地址";
            ip.TextAlign = ContentAlignment.MiddleCenter;

            tablay_interface.Controls.Add(device, 1, 0);
            tablay_interface.Controls.Add(descreption, 2, 0);
            tablay_interface.Controls.Add(ip, 3, 0);
        }
        private void AddDevice()
        {
            foreach (PcapDevice dev in devices)
            {
                int row = tablay_interface.RowCount++;
                //row = row - 1;
               

                CheckBox cb = new CheckBox();
                cb.Name = "cb" + IntToString(row);
                cb.Click += new EventHandler(cb_Selected);
                
                Label device = new Label();
                device.TextAlign = ContentAlignment.BottomLeft;
                if (dev.Interface.FriendlyName != null)
                {
                    device.Text = dev.Interface.FriendlyName;
                }
                else
                {
                    device.Text = dev.Name;
                }

                Label descreption = new Label();
                descreption.TextAlign = ContentAlignment.BottomLeft;
                descreption.Text = dev.Description;

                Label ip = new Label();
                ip.TextAlign = ContentAlignment.BottomLeft;
                ip.Text = dev.Addresses[1].Addr.ToString();
                
                Button but = new Button();
                but.Name = "but_details"+IntToString( row);
                but.Text = "详情";
                but.Click+=new EventHandler(but_Click);

                tablay_interface.Controls.Add(cb, 0, row);
                tablay_interface.Controls.Add(device, 1, row);
                tablay_interface.Controls.Add(descreption, 2, row);
                tablay_interface.Controls.Add(ip, 3, row);
                tablay_interface.Controls.Add(but, 4, row);
            }
        }
        //显示网卡的详细信息的按钮
        private void but_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("ddd");
            Button but = (Button)sender;
            string name = but.Name.ToString();
            int i = Convert.ToInt32(name.Substring(name.Length - 2, 2));

            InterfaceDetailsForm ifForm = new InterfaceDetailsForm(devices[i-1]);
            ifForm.Show();

        }
        //选择网卡
        private void cb_Selected(object sender, EventArgs e)
        {
            CheckBox cb=(CheckBox)sender;
            string name = cb.Name.ToString();
            int i = Convert.ToInt32(name.Substring(name.Length - 2, 2));
            sdv = i;
            if (cb.Checked)
            {
                //如果标记为1标示这个设备被选择，0为未被选择
               // MessageBox.Show(name);
                if (ReturnSelectedDevice != null)
                {
                    ReturnSelectedDevice(i);
                }
            }

        }
        //关闭按钮
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未选择网卡");
            if (ReturnSelectedDevice != null)
            {
                ReturnSelectedDevice(-1);
                sdv = -1;
            }
            this.Close();
        }
        //开始抓包
        private void but_start_Click(object sender, EventArgs e)
        {
            if (sdv == -1)
            {
                MessageBox.Show("未选择网卡！");
                return;
            }
            if (CreateThread != null)
            {
                CreateThread();
            }
            this.Close();
        }
        //考虑到设备数量可能上两位数
        private string IntToString(int n)
        {
            if (n < 10) return '0' + n.ToString();
            else return n.ToString();
        }
        //设置按钮
        private void but_setfilter_Click(object sender, EventArgs e)
        {
            if (sdv == -1)
            {
                MessageBox.Show("未选择网卡！");
                return;
            }
            if (setFilter != null)
            {
                setFilter();
            }
            this.Close();
        }
    }
}
