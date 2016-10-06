using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpPcap;
using SharpPcap.Packets;
using WindowsFormsApplication1;
using System.Windows.Forms;
using SharpPcap.Packets.Util;

namespace WindowsFormsApplication1.Capture
{
    public class ShowPacket
    {
        //private Packet packet;                                          //抓到的包
        //private int EtherType;                                          //得到的Ethernet包的类型
        private StringBuilder packetBuffer_0x = new StringBuilder();    //packet16进制的缓存，显示在TextBox中
        //private int RowNo;                                              //TextBox中的行号
        MainForm mf;                                                    //主界面的实例
        Exchange Ex = new Exchange();                                   //把数字代码转换成文字


        public ShowPacket()
        {
        }
        public ShowPacket(MainForm mf)
        {
            this.mf = mf;
        }

        //public void setPacket(Packet packet)
        //{
        //    this.packet = packet;
        //}
        public string getProtocol(Packet packet)
        {
            if (packet is HTTPPacket)
            {
                HTTPPacket http = (HTTPPacket)packet;
                if (!http.HTTPData.Equals(""))
                {
                    return "HTTP";
                }
            }

            if (packet is TCPPacket) return "TCP";
            if (packet is UDPFields) return "UDP";
            if (packet is ICMPPacket) return "ICMP";

            if (packet is IPPacket) return "IP";
            if (packet is ARPPacket) return "ARP";

            if (packet is EthernetPacket) return "Ethernet";
            return "null";
        }

        #region 在控件中显示信息
        //在datagridview中显示packet信息
        public void ShowPacketInfo_lv(Packet packet)
        {

            ListView listv_show = mf.listView_PacketInfo;
            int index = listv_show.Items.Count;
            DateTime time = packet.PcapHeader.Date;
            uint len = packet.PcapHeader.PacketLength;

            ListViewItem lvi = new ListViewItem(index.ToString(), index);


            lvi.SubItems.Add(time.Hour.ToString() + ":" + time.Minute.ToString() + ":" + time.Second.ToString());
            if (packet is IPPacket)
            {
                IPPacket ip = (IPPacket)packet;
                lvi.SubItems.Add(ip.SourceAddress.ToString());
                lvi.SubItems.Add(ip.DestinationAddress.ToString());
            }
            else if (packet is EthernetPacket)
            {
                EthernetPacket eth = (EthernetPacket)packet;
                lvi.SubItems.Add(Ex.toFormatEthernetAddress(eth.SourceHwAddress.ToString()));
                lvi.SubItems.Add(Ex.toFormatEthernetAddress(eth.DestinationHwAddress.ToString()));
            }
            else
            {
                lvi.SubItems.Add("未识别");
                lvi.SubItems.Add("未识别");
            }

            lvi.SubItems.Add(getProtocol(packet));
            lvi.SubItems.Add(len.ToString());

            listv_show.Items.Add(lvi);
            //确保最后一排可见
            //listv_show.Items[index].EnsureVisible();

        }
        
        
        #endregion

        #region 异常
        #endregion
    }
}
 