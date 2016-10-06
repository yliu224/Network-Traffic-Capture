using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpPcap;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SharpPcap.Packets;
using System.Threading;
//此处在线程中抓包必须要使用without callback！！
namespace WindowsFormsApplication1.Capture
{
    public class CaptureMine
    {
        public string filter = "";                      //用于设置过滤规则
        public MainForm mf;                             //主窗口界面
        public ShowPacket sp;                           //显示Packet的类
        public Packet []packets;                        //Packet缓存
        public int PIndex ;                             //Packet缓存的索引  
        MainForm.lv_showinfo lv_ShowInfo;               //负责显示ListView信息                         
 
        public CaptureMine()
        {
        }
        public CaptureMine(MainForm mf)
        {
            this.mf = mf;
        }
        public void CaptureInitial()
        {
            packets = new Packet[10000];
            PIndex = 0;
        }

        #region 抓包的基本函数
        public void Capture(PcapDevice device)
        {
            Packet packet;
            try
            {
                //Keep capture packets using PcapGetNextPacket()
                while ((packet = device.GetNextPacket()) != null)
                {
                    //把packet放入缓存
                    packets[PIndex] = packet;
                    PIndex++;

                    device.Dump(packet);

                    //调用此方法

                    /*************************************************/

                    //使用Invoke（），当大量packet过来的时候，UI会出现假死的现象！！！
                    //mf.listView_PacketInfo.Invoke(lv_ShowInfo);

                    //使用BegionInvoke会出现包显示不正确的现象,原因是没有同步，这样就解决了同步问题
                    mf.listView_PacketInfo.BeginInvoke(lv_ShowInfo,packet);
                    /*************************************************/
                }
                return;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message.ToString());
            }
        }
        public void CloseCapture(PcapDevice device)
        {
            device.Close();
            if (device.Started)
            {
                device.Close();
            }
        }
        public void OpenCapture(PcapDevice device)
        {
            //Open the device for capturing
            //true -- means promiscuous mode
            //1000 -- means a read wait of 1000ms
            device.Open(true, 1000);
        }
        #endregion  

        #region 操作文件的函数
        public void DumpOpen(PcapDevice device,string capfile)
        {
            device.DumpOpen(capfile);
            device.SetFilter(filter);
        }
        public void DumpFlush(PcapDevice device)
        {
            device.DumpFlush();
        }
        public void DumpClose(PcapDevice device)
        {
            device.DumpClose();
        }
        public void OpenCapture_File(PcapDevice device)
        {
            device.Open();
        }
        public void Capture_File(PcapDevice device)
        {
            #region 无用
            /*
            Packet packet;
            try
            {
                //Keep capture packets using PcapGetNextPacket()
                while ((packet = device.GetNextPacket()) != null)
                {
                    //把packet放入缓存
                    packets[PIndex] = packet;
                    PIndex++;

                          
                    //把抓到的包放到sp这个类中
                    //sp.setPacket(packet);
                    //通过委托来调用类中的方法，让包的信息显示到windowsform中去
                    MainForm.lv_showinfo lv_ShowInfo = new MainForm.lv_showinfo(sp.ShowPacketInfo_lv);
                    //调用此方法
                    mf.listView_PacketInfo.Invoke(lv_ShowInfo);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message.ToString());
            }
            */
            #endregion
            Packet packet;
            try
            {
                //Keep capture packets using PcapGetNextPacket()
                while ((packet = device.GetNextPacket()) != null)
                {
                    //把packet放入缓存
                    packets[PIndex] = packet;
                    PIndex++;

                    device.Dump(packet);

                    //调用此方法

                    /*************************************************/

                    //使用Invoke（），当大量packet过来的时候，UI会出现假死的现象！！！
                    //mf.listView_PacketInfo.Invoke(lv_ShowInfo);

                    //使用BegionInvoke会出现包显示不正确的现象,原因是没有同步，这样就解决了同步问题
                    mf.listView_PacketInfo.BeginInvoke(lv_ShowInfo, packet);
                    /*************************************************/
                }
                return;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message.ToString());
            }
            device.Close();
        }
        //private static void device_PcapOnPacketArrival(object sender, PcapCaptureEventArgs e)
        //{
        //    try
        //    {
        //        //Keep capture packets using PcapGetNextPacket()
        //        while ((packet = device.GetNextPacket()) != null)
        //        {
        //            //把packet放入缓存
        //            packets[PIndex] = packet;
        //            PIndex++;

        //            device.Dump(packet);
        //            // Prints the time and length of each received packet
        //            //把抓到的包放到sp这个类中
        //            sp.setPacket(packet);
        //            //通过委托来调用类中的方法，让包的信息显示到windowsform中去
        //            MainForm.lv_showinfo lv_ShowInfo = new MainForm.lv_showinfo(sp.ShowPacketInfo_lv);
        //            //调用此方法
        //            mf.listView_PacketInfo.Invoke(lv_ShowInfo);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message.ToString());
        //    }
        //}
        #endregion

        #region 设置过滤规则
        public void setFilter(string filter)
        {
            this.filter = filter;
        }
        public bool CheckFilter(string filter)
        {
            /*
             * 关键字out的使用http://www.cnblogs.com/yanwei067/archive/2007/10/31/944295.html
             *1.out 关键字会导致参数通过引用来传递。这与 ref 关键字类似，不同之处在于ref 要求变量必须在传递之前进行初始化。
             *2.方法定义和调用方法都必须显式使用 out 关键字。
             *3.属性不是变量，因此不能作为 out 参数传递。
             */
            string erro=null;
            if (PcapDevice.CheckFilter(filter, out erro))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        public void setShowPacket(ShowPacket sp)
        {
            this.sp = sp;
            //通过委托来调用类中的方法，让包的信息显示到windowsform中去
            lv_ShowInfo = new MainForm.lv_showinfo(sp.ShowPacketInfo_lv); 
        }
         
    }
}
