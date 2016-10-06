using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpPcap;
using WindowsFormsApplication1.Capture;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using SharpPcap.Packets;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        #region 样式设置
        //Imports the UXTheme DLL设置listview样式所需要的外部dll
        [DllImport("uxtheme", CharSet = CharSet.Unicode)]
        public extern static Int32 SetWindowTheme
                (IntPtr hWnd, String textSubAppName, String textSubIdList);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage
                    (IntPtr hWnd, int msg, int wParam, int lParam);
        //获取滚动条位置的函数
        [DllImport("user32.dll", EntryPoint = "GetScrollPos")]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);

        #endregion

        #region 变量
        string Filepath;                        //临时存储文件目录
        int sdv=-1;                             //被选择的设备  
        Thread tr;                              //网卡的线程
        public delegate void lv_showinfo(Packet packet);     //ShowPacket.cs 调用Listview控件

        //int NumberofInterface;
        List<PcapDevice> devices;

        CaptureMine cm; 
        ShowPacket sp;
        ShowPacket_Details sp_d;

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cm = new CaptureMine(this);
            sp = new ShowPacket(this);
            sp_d = new ShowPacket_Details(this);
            //设置listview的样式
            SetWindowTheme(listView_PacketInfo.Handle, "explorer", null);
            SendMessage(listView_PacketInfo.Handle, 0x1100 + 44, 0x0040, 0x0040);

            but_start.Enabled = false;
            but_stop.Enabled = false;
            //but_pause.Enabled=false;

            devices = SharpPcap.Pcap.GetAllDevices();

        }

        #region 选择网卡窗口
        private void 选择网卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectInterfaceForm_Initial();
        }  
        private void but_netinterface_Click(object sender, EventArgs e)
        {
            SelectInterfaceForm_Initial();
        }
        
        public void SelectInterfaceForm_Initial()
        {
            SelecteInterfaceForm siForm = new SelecteInterfaceForm();

            siForm.ReturnSelectedDevice = new SelecteInterfaceForm.returnselecteddevice(getSelectedDevice);
            siForm.CreateThread = new SelecteInterfaceForm.createthread(CreateThread);
            siForm.setFilter = new SelecteInterfaceForm.setfilter(SetFilterForm_Initial);
            //siForm.getNumberofInterface = new SelecteInterfaceForm.getnumberofinterface(getNumberofInterface);

            siForm.setDivceList(devices);
            siForm.Show();
        }

        //通过delegate从SelectedInterfaceForm中的到已选择的网卡的编号 
        private void getSelectedDevice(int sdv)
        {
            but_start.Enabled = true;
            this.sdv = sdv - 1;
        }   
        #endregion

        #region 过滤规则窗口
        private void 设置过滤规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFilterForm_Initial();
        }
        private void but_filter_Click(object sender, EventArgs e)
        {
            SetFilterForm_Initial();
        }
        //初始化设置过滤规则的窗口
        public void SetFilterForm_Initial()
        {
            SetFilterForm sfFrom = new SetFilterForm();

            sfFrom.CheckFilter = new SetFilterForm.checkfilter(cm.CheckFilter);
            sfFrom.SetFilter = new SetFilterForm.setfilter(cm.setFilter);
            sfFrom.StartCapture = new SetFilterForm.startcapture(CreateThread);

            sfFrom.Show();
        }
        #endregion

        #region 线程
        //开始、重启
        private void but_start_Click(object sender, EventArgs e)
        {
            if (!Check_sdv())
            {
                MessageBox.Show("网卡未选择！");

            }
            if (listView_PacketInfo.Items.Count != 0)
            {
                KillThread();
                if(ShowMessageBox()) return;
            }
            
            CreateThread();
        }

        //创建线程
        private void CreateThread()
        {
            Initial();

            but_start.Enabled = false;
            but_stop.Enabled = true;

            tr = new Thread(new ParameterizedThreadStart(StartCapture));
            tr.IsBackground = true;
            tr.Priority = ThreadPriority.Lowest;
            tr.Start(sdv);

        }

        //抓包线程
        public void StartCapture(object no)
        {

            //把文件默认存储在C根目录
            Filepath = "C:\\" + devices[sdv].Description + DateTime.Now.ToFileTime();
            //cm = new CaptureMine(this);
            //sp = new ShowPacket(this);

            int n = (int)no;
            PcapDevice device=devices[n];

            cm.setShowPacket(sp);
            cm.OpenCapture(device);

            cm.DumpOpen(device,Filepath);
            

            while (true)
            {
                cm.Capture(device);
                //cm.DumpFlush(device);
                Thread.Sleep(1000);

            }
            //MessageBox.Show("haha ");
            //cm.DumpClose(device);
            
        }

        //停止抓包
        private void but_stop_Click(object sender, EventArgs e)
        {
            KillThread();
            but_start.Enabled = true;
            but_stop.Enabled = false; ;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Check_sdv()) return;

            KillThread();
            ShowMessageBox(e);
        }
        public void KillThread()
        {
            PcapDevice device;

            device = devices[sdv];
            cm.CloseCapture(device);
            cm.DumpClose(device);
            //线程结束
            if (tr != null)
            {
                tr.Abort();
            }
            
        }
       
        #endregion

        #region 杂项
        //初始化面板
        private void Initial()
        {
            tr = null;
            listView_PacketInfo.Items.Clear();
            textBox_Byte.Clear();
            treeView_PacketInfo.Nodes.Clear();
            cm.CaptureInitial();
        }
        //让treeview得到选择的包的编号
        private void listView_PacketInfo_SelectedIndexChanged(object sender, EventArgs e)
        {       

            int length = listView_PacketInfo.SelectedItems.Count;
            int SelectedPacket_No=0;
            for (int i = 0; i < length; i++)
            {
                SelectedPacket_No = listView_PacketInfo.SelectedItems[i].Index;
            }
            sp_d.setPacket(cm.packets[SelectedPacket_No]);
            sp_d.ShowPacketInfo_text();
            sp_d.ShowPacketInfo_tv();

            
        }

        private bool Check_sdv()
        {
            if (sdv == -1) return false;
            return true;
        }
        #endregion

        #region 文件
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            try
            {
                PcapDevice device = SharpPcap.Pcap.GetPcapOfflineDevice(ofd.FileName.ToString());
                StartCapture_File(device);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
        public void StartCapture_File(PcapDevice device)
        {
            Initial();

            //cm.CaptureInitial();
            //sdv = -1;

            //cm.setShowPacket(sp);
            //cm.OpenCapture_File(device);
            //cm.Capture_File(device);

            sdv = -1;
            cm.setShowPacket(sp);
            cm.OpenCapture_File(device);
            cm.Capture_File(device);


        }
        private void ShowMessageBox(FormClosingEventArgs e)
        {
            DialogResult dr;
            SaveFileDialog sfd;
            dr = MessageBox.Show("您是否要保存抓包文件", "提示", MessageBoxButtons.YesNoCancel,
                     MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                sfd = new SaveFileDialog();
                sfd.ShowDialog();

                if (File.Exists(Filepath) && sfd.FileName.ToString() != null)
                {
                    File.Move(Filepath, sfd.FileName.ToString());
                }
                else
                {
                    MessageBox.Show("文件不存在！");
                }

                //MessageBox.Show(sfd.FileName.ToString());
            }
            else if (dr == DialogResult.No)
            {

                //判断文件是不是存在
                if (File.Exists(Filepath))
                {
                    //如果存在则删除
                    File.Delete(Filepath);
                }
                else
                {
                    MessageBox.Show("文件不存在");
                }
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        private bool ShowMessageBox()
        {
            DialogResult dr;
            SaveFileDialog sfd;
            dr = MessageBox.Show("您是否要保存抓包文件", "提示", MessageBoxButtons.YesNoCancel,
                     MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                sfd = new SaveFileDialog();
                sfd.ShowDialog();

                if (File.Exists(Filepath) && sfd.FileName.ToString() != null)
                {
                    File.Move(Filepath, sfd.FileName.ToString());

                }
                else
                {
                    MessageBox.Show("文件不存在！");
                }
                return false;
                //MessageBox.Show(sfd.FileName.ToString());
            }
            else if (dr == DialogResult.No)
            {

                //判断文件是不是存在
                if (File.Exists(Filepath))
                {
                    //如果存在则删除
                    File.Delete(Filepath);

                }
                else
                {
                    MessageBox.Show("文件不存在");
                }
                return false;
            }
            else if (dr == DialogResult.Cancel)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Error!");
                return true;
            }
        }
        #endregion

        #region 暂时无用
        /*
        //得到网卡的数量
        private void getNumberofInterface(int inter)
        {
            NumberofInterface = inter;
        }
        */
        #endregion
    }
}
