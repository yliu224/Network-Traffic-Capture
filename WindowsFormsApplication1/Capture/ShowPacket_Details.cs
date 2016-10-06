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
    class ShowPacket_Details
    {
        private Packet packet;                                          //抓到的包
        private int EtherType;                                          //得到的Ethernet包的类型
        MainForm mf;                                                    //主界面的实例
        Exchange Ex = new Exchange();                                   //把数字代码转换成文字
        StringBuilder packetBuffer_0x = new StringBuilder();    //packet16进制的缓存，显示在TextBox中
        int RowNo = 0;                                              //TextBox中的行号

        #region 构造函数
        public ShowPacket_Details()
        {
        }
        public ShowPacket_Details(MainForm mf)
        {
            this.mf = mf;
        }
        #endregion

        public void setPacket(Packet packet)
        {
            this.packet = packet;
        }

        #region 分析包
        public void getEthernetPacket()
        {
            if (packet is EthernetPacket)
            {
                EthernetPacket ethernet = (EthernetPacket)packet;

                EtherType = ethernet.EthernetProtocol;

                TreeNode Ethernet_Root = new TreeNode(); Ethernet_Root.Text = "Ethernet;Src: " + Ex.toFormatEthernetAddress(ethernet.SourceHwAddress.ToString()) + " ;Dst: " + Ex.toFormatEthernetAddress(ethernet.SourceHwAddress.ToString());
                this.mf.treeView_PacketInfo.Nodes.Add(Ethernet_Root);

                TreeNode Ethernet_Src = new TreeNode(); Ethernet_Src.Text = "Source: " + Ex.toFormatEthernetAddress(ethernet.SourceHwAddress.ToString());
                Ethernet_Root.Nodes.Add(Ethernet_Src);
                TreeNode Ethernet_Dst = new TreeNode(); Ethernet_Dst.Text = "Destination: " + Ex.toFormatEthernetAddress(ethernet.DestinationHwAddress.ToString());
                Ethernet_Root.Nodes.Add(Ethernet_Dst);
                TreeNode Ethernet_Type = new TreeNode(); Ethernet_Type.Text = "Type: 0x" + ethernet.EthernetProtocol.ToString("X");
                Ethernet_Root.Nodes.Add(Ethernet_Type);
            }
            else
            {
                TreeView_Error();
            }
        }
        public void getIPPacket()
        {
            if (packet is IPPacket)
            {
                IPPacket ip = (IPPacket)packet;
                if (IPPacket.IPVersions.IPv4 == ip.IPVersion)
                {
                    TreeNode IPv4_Root = new TreeNode(); IPv4_Root.Text = "Internet Protocol v4;Src: " + ip.ipv4.SourceAddress.ToString() + " ;Dst: " + ip.ipv4.DestinationAddress.ToString();
                    this.mf.treeView_PacketInfo.Nodes.Add(IPv4_Root);

                    TreeNode IPv4_Version = new TreeNode(); IPv4_Version.Text = "Version: " + ip.ipv4.IPVersion;
                    IPv4_Root.Nodes.Add(IPv4_Version);
                    TreeNode IPv4_HeaderLength = new TreeNode(); IPv4_HeaderLength.Text = "Header Length: " + ip.ipv4.HeaderLength.ToString() + " bytes";
                    IPv4_Root.Nodes.Add(IPv4_HeaderLength);
                    TreeNode IPv4_TOS = new TreeNode(); IPv4_TOS.Text = "Type Of Service: " + ip.ipv4.TypeOfService.ToString();
                    IPv4_Root.Nodes.Add(IPv4_TOS);
                    TreeNode IPv4_TotalLength = new TreeNode(); IPv4_TotalLength.Text = "Total Length: " + ip.ipv4.IPTotalLength.ToString() + " bytes";
                    IPv4_Root.Nodes.Add(IPv4_TotalLength);
                    TreeNode IPv4_Identification = new TreeNode(); IPv4_Identification.Text = "Identification: 0x" + ip.ipv4.Id.ToString("X").PadLeft(4, '0') + "(" + ip.ipv4.Id.ToString() + ")";
                    IPv4_Root.Nodes.Add(IPv4_Identification);
                    TreeNode IPv4_Flag = new TreeNode(); IPv4_Flag.Text = "Flag: 0x" + ip.ipv4.FragmentFlags.ToString("X").PadLeft(2, '0');
                    IPv4_Root.Nodes.Add(IPv4_Flag);
                    TreeNode IPv4_FragmentOffset = new TreeNode(); IPv4_FragmentOffset.Text = "Fragment Offset: " + ip.ipv4.FragmentOffset.ToString();
                    IPv4_Root.Nodes.Add(IPv4_FragmentOffset);
                    TreeNode IPv4_TimetoLive = new TreeNode(); IPv4_TimetoLive.Text = "Time to Live: " + ip.ipv4.TimeToLive.ToString();
                    IPv4_Root.Nodes.Add(IPv4_TimetoLive);
                    TreeNode IPv4_Protocol = new TreeNode(); IPv4_Protocol.Text = "Protocol: " + ip.ipv4.IPProtocol.ToString() + "(" + ip.ipv4.IPProtocol.ToString("D") + ")";
                    IPv4_Root.Nodes.Add(IPv4_Protocol);
                    TreeNode IPv4_Checksum = new TreeNode(); IPv4_Checksum.Text = "Checksum: 0x" + ip.ipv4.Checksum.ToString("X").PadLeft(4, '0');
                    IPv4_Root.Nodes.Add(IPv4_Checksum);
                    TreeNode IPv4_SourceIP = new TreeNode(); IPv4_SourceIP.Text = "Source: " + ip.ipv4.SourceAddress.ToString();
                    IPv4_Root.Nodes.Add(IPv4_SourceIP);
                    TreeNode IPv4_DestinationIP = new TreeNode(); IPv4_DestinationIP.Text = "Destination: " + ip.ipv4.DestinationAddress.ToString();
                    IPv4_Root.Nodes.Add(IPv4_DestinationIP);

                    return;
                }
                if (IPPacket.IPVersions.IPv6 == ip.IPVersion)
                {
                    TreeNode IPv6_Root = new TreeNode(); IPv6_Root.Text = "Internet Protocol v6;Src: " + ip.ipv6.SourceAddress.ToString() + " ;Dst: " + ip.ipv6.DestinationAddress.ToString();
                    this.mf.treeView_PacketInfo.Nodes.Add(IPv6_Root);

                    TreeNode IPv6_Version = new TreeNode(); IPv6_Version.Text = "Version: " + ip.ipv6.IPv6Version;
                    TreeNode IPv6_TrafficClass = new TreeNode(); IPv6_TrafficClass.Text = "Traffic Class: 0x" + ip.ipv6.TrafficClass.ToString("X").PadLeft(8, '0');
                    TreeNode IPv6_FlowLabel = new TreeNode(); IPv6_FlowLabel.Text = "Flow Label: 0x" + ip.ipv6.FlowLabel.ToString("X").PadLeft(8, '0');
                    TreeNode IPv6_PayloadLength = new TreeNode(); IPv6_PayloadLength.Text = "Payload Length: " + ip.ipv6.IPPayloadLength;
                    TreeNode IPv6_NextHeader = new TreeNode(); IPv6_NextHeader.Text = "Next Header: " + ip.ipv6.NextHeader.ToString() + "(" + ip.ipv6.NextHeader.ToString("D") + ")";
                    TreeNode IPv6_HopLimit = new TreeNode(); IPv6_HopLimit.Text = "Hop Limit: " + ip.ipv6.HopLimit.ToString();
                    TreeNode IPv6_SourceIP = new TreeNode(); IPv6_SourceIP.Text = "Source: " + ip.ipv6.SourceAddress.ToString();
                    TreeNode IPv6_DestinationIP = new TreeNode(); IPv6_DestinationIP.Text = "Destination: " + ip.ipv6.DestinationAddress.ToString();

                    IPv6_Root.Nodes.Add(IPv6_Version);
                    IPv6_Root.Nodes.Add(IPv6_TrafficClass);
                    IPv6_Root.Nodes.Add(IPv6_FlowLabel);
                    IPv6_Root.Nodes.Add(IPv6_PayloadLength);
                    IPv6_Root.Nodes.Add(IPv6_NextHeader);
                    IPv6_Root.Nodes.Add(IPv6_HopLimit);
                    IPv6_Root.Nodes.Add(IPv6_SourceIP);
                    IPv6_Root.Nodes.Add(IPv6_DestinationIP);

                    return;
                }

                TreeView_Error();

            }
            else
            {
                TreeView_Error();
            }
        }
        public void getICMPPacket()
        {
            if (packet is ICMPPacket)
            {
                ICMPPacket icmp = (ICMPPacket)packet;
                TreeNode ICMP_Root = new TreeNode(); ICMP_Root.Text = "Internet Control Message Protocol" + " (" + ICMPMessage.getDescription(ArrayHelper.extractInteger(icmp.Header, 0, 2)) + ")";
                this.mf.treeView_PacketInfo.Nodes.Add(ICMP_Root);

                TreeNode ICMP_Type = new TreeNode(); ICMP_Type.Text = "Type: " + icmp.MessageMajorCode.ToString();
                TreeNode ICMP_Code = new TreeNode(); ICMP_Code.Text = "Code: " + icmp.MessageMinorCode.ToString();
                TreeNode ICMP_Checksum = new TreeNode(); ICMP_Checksum.Text = "Checksum: 0x" + icmp.Checksum.ToString("X").PadLeft(4, '0');
                //TreeNode ICMP_Data = new TreeNode(); ICMP_Data.Text = "Data: " + ArrayHelper.extractInteger(icmp.ICMPData, 0, icmp.ICMPData.Count() ).ToString("X");

                ICMP_Root.Nodes.Add(ICMP_Type);
                ICMP_Root.Nodes.Add(ICMP_Code);
                ICMP_Root.Nodes.Add(ICMP_Checksum);
                //ICMP_Root.Nodes.Add(ICMP_Data);
            }
            else
            {
                TreeView_Error();
            }
        }
        public void getTCPPacket()
        {
            if (packet is TCPPacket)
            {
                TCPPacket tcp = (TCPPacket)packet;
                int Flags = ArrayHelper.extractInteger(tcp.Header, TCPFields_Fields.TCP_FLAG_POS, TCPFields_Fields.TCP_FLAG_LEN);

                TreeNode TCP_Root = new TreeNode(); TCP_Root.Text = "Transmission Control Protocol; Src Port: " + tcp.SourcePort.ToString() + " ;Dst Port: " + tcp.DestinationPort.ToString() + " (" + Ex.toReadableTCPFlags(tcp) + ")";
                this.mf.treeView_PacketInfo.Nodes.Add(TCP_Root);

                TreeNode TCP_SourcePort = new TreeNode(); TCP_SourcePort.Text = "Source Port: " + tcp.SourcePort.ToString();
                TreeNode TCP_DestinationPort = new TreeNode(); TCP_DestinationPort.Text = "Destination Port: " + tcp.DestinationPort.ToString();
                TreeNode TCP_SequenceNo = new TreeNode(); TCP_SequenceNo.Text = "Sequence Number: 0x" + tcp.SequenceNumber.ToString("X");
                TreeNode TCP_AcknowledgmentNo = new TreeNode(); TCP_AcknowledgmentNo.Text = "Acknowledgment Number: 0x" + tcp.AcknowledgmentNumber.ToString("X");
                TreeNode TCP_HeaderLength = new TreeNode(); TCP_HeaderLength.Text = "Header Length: " + tcp.HeaderLength.ToString() + " bytes";
                TreeNode TCP_Flags = new TreeNode(); TCP_Flags.Text = Convert.ToString(Flags, 2).Remove(0, 4).Insert(4, " ").Insert(9, " ") + " = Flags: 0x" + Convert.ToString(Flags, 16).Remove(0, 1).PadLeft(3, '0') + " (" + Ex.toReadableTCPFlags(tcp) + ")";
                TreeNode TCP_Windows = new TreeNode(); TCP_Windows.Text = "Windows Size Value: " + tcp.WindowSize.ToString();
                TreeNode TCP_Checksum = new TreeNode(); TCP_Checksum.Text = "Checksum: 0x" + tcp.Checksum.ToString("X").PadLeft(4, '0');
                TreeNode TCP_UrgentPointer = new TreeNode(); TCP_UrgentPointer.Text = "Urgent Pointer: " + tcp.getUrgentPointer().ToString();
                //TreeNode TCP_Options = new TreeNode();TCP_Options.Text="Options: "+ tcp. tcp.Options

                TCP_Root.Nodes.Add(TCP_SourcePort);
                TCP_Root.Nodes.Add(TCP_DestinationPort);
                TCP_Root.Nodes.Add(TCP_SequenceNo);
                TCP_Root.Nodes.Add(TCP_AcknowledgmentNo);
                TCP_Root.Nodes.Add(TCP_HeaderLength);
                TCP_Root.Nodes.Add(TCP_Flags);
                TCP_Root.Nodes.Add(TCP_Windows);
                TCP_Root.Nodes.Add(TCP_Checksum);
                TCP_Root.Nodes.Add(TCP_UrgentPointer);

                TreeNode TCP_Flags_Reserved = new TreeNode(); TCP_Flags_Reserved.Text = "0000 .... .... = Rserved";
                TreeNode TCP_Flags_CWR = new TreeNode(); TCP_Flags_CWR.Text = ".... " + Ex.toInt(tcp.CWR) + "... .... = Congestion Window Reduced: " + tcp.CWR.ToString();
                TreeNode TCP_Flags_ECN = new TreeNode(); TCP_Flags_ECN.Text = ".... ." + Ex.toInt(tcp.ECN) + ".. .... = ECN_Echo: " + tcp.ECN.ToString();
                TreeNode TCP_Flags_URG = new TreeNode(); TCP_Flags_URG.Text = ".... .." + Ex.toInt(tcp.Urg) + ". .... = Urgent: " + tcp.Urg.ToString();
                TreeNode TCP_Flags_ACK = new TreeNode(); TCP_Flags_ACK.Text = ".... ..." + Ex.toInt(tcp.Ack) + " .... = Acknowledgment: " + tcp.Ack.ToString();
                TreeNode TCP_Flags_PSH = new TreeNode(); TCP_Flags_PSH.Text = ".... .... " + Ex.toInt(tcp.Psh) + "... = Push: " + tcp.Psh.ToString();
                TreeNode TCP_Flags_RST = new TreeNode(); TCP_Flags_RST.Text = ".... .... ." + Ex.toInt(tcp.Rst) + ".. = Reset: " + tcp.Rst.ToString();
                TreeNode TCP_Flags_SYN = new TreeNode(); TCP_Flags_SYN.Text = ".... .... .." + Ex.toInt(tcp.Syn) + ". = Syn: " + tcp.Syn.ToString();
                TreeNode TCP_Flags_FIN = new TreeNode(); TCP_Flags_FIN.Text = ".... .... ..." + Ex.toInt(tcp.Fin) + " = Fin: " + tcp.Fin.ToString();

                TCP_Flags.Nodes.Add(TCP_Flags_Reserved);
                TCP_Flags.Nodes.Add(TCP_Flags_CWR);
                TCP_Flags.Nodes.Add(TCP_Flags_ECN);
                TCP_Flags.Nodes.Add(TCP_Flags_URG);
                TCP_Flags.Nodes.Add(TCP_Flags_ACK);
                TCP_Flags.Nodes.Add(TCP_Flags_PSH);
                TCP_Flags.Nodes.Add(TCP_Flags_RST);
                TCP_Flags.Nodes.Add(TCP_Flags_SYN);
                TCP_Flags.Nodes.Add(TCP_Flags_FIN);

            }
            else
            {
                TreeView_Error();
            }
        }
        public void getUDPPacket()
        {
            if (packet is UDPPacket)
            {
                UDPPacket udp = (UDPPacket)packet;
                TreeNode UDP_Root = new TreeNode(); UDP_Root.Text = "User Datagram Protocol; Src Port: " + udp.SourcePort.ToString() + "; Dst Port: " + udp.DestinationPort.ToString();
                this.mf.treeView_PacketInfo.Nodes.Add(UDP_Root);

                TreeNode UDP_SrcPort = new TreeNode(); UDP_SrcPort.Text = "Source Port: " + udp.SourcePort.ToString();
                TreeNode UDP_DstPort = new TreeNode(); UDP_DstPort.Text = "Destination Port: " + udp.DestinationPort.ToString();
                TreeNode UDP_Length = new TreeNode(); UDP_Length.Text = "Length: " + udp.Length.ToString() + " bytes";
                TreeNode UDP_Checksum = new TreeNode(); UDP_Checksum.Text = "Checksum: 0x" + udp.Checksum.ToString("X").PadLeft(4, '0');

                UDP_Root.Nodes.Add(UDP_SrcPort);
                UDP_Root.Nodes.Add(UDP_DstPort);
                UDP_Root.Nodes.Add(UDP_Length);
                UDP_Root.Nodes.Add(UDP_Checksum);
            }
            else
            {
                TreeView_Error();
            }
        }
        public void getARPPacket()
        {
            if (packet is ARPPacket)
            {
                ARPPacket arp = (ARPPacket)packet;
                TreeNode ARP_Root = new TreeNode(); ARP_Root.Text = "Address Resolution Protocol (" + Ex.toArpOpCode(arp.ARPOperation) + ")";
                this.mf.treeView_PacketInfo.Nodes.Add(ARP_Root);

                TreeNode ARP_HardwareType = new TreeNode(); ARP_HardwareType.Text = "Hardware Type: " + arp.ARPHwType.ToString();// +" (" + arp.ARPHwType.ToString("D") + ")";
                TreeNode ARP_ProtocolType = new TreeNode(); ARP_ProtocolType.Text = "Protocol Type: 0x" + arp.ARPProtocolType.ToString("X").PadLeft(4, '0');
                TreeNode ARP_HardwareLength = new TreeNode(); ARP_HardwareLength.Text = "Hardware Length: " + arp.ARPHwLength.ToString();
                TreeNode ARP_ProtocolLength = new TreeNode(); ARP_ProtocolLength.Text = "Protocol Length: " + arp.ARPProtocolLength.ToString();
                TreeNode ARP_OpCode = new TreeNode(); ARP_OpCode.Text = "Operate Code: " + Ex.toArpOpCode(arp.ARPOperation) + "(" + arp.ARPOperation.ToString() + ")";
                TreeNode ARP_SenderMacAddress = new TreeNode(); ARP_SenderMacAddress.Text = "Sender Mac Address: " + Ex.toFormatEthernetAddress(arp.ARPSenderHwAddress.ToString());
                TreeNode ARP_SenderIPAddress = new TreeNode(); ARP_SenderIPAddress.Text = "Sender IP Address: " + arp.ARPSenderProtoAddress.ToString();
                TreeNode ARP_TargetMacAddress = new TreeNode(); ARP_TargetMacAddress.Text = "Target Mac Address: " + Ex.toFormatEthernetAddress(arp.ARPTargetHwAddress.ToString());
                TreeNode ARP_TargetIPAdress = new TreeNode(); ARP_TargetIPAdress.Text = "Target IP Address: " + arp.ARPTargetProtoAddress.ToString();

                ARP_Root.Nodes.Add(ARP_HardwareType);
                ARP_Root.Nodes.Add(ARP_ProtocolType);
                ARP_Root.Nodes.Add(ARP_HardwareLength);
                ARP_Root.Nodes.Add(ARP_ProtocolLength);
                ARP_Root.Nodes.Add(ARP_OpCode);
                ARP_Root.Nodes.Add(ARP_SenderMacAddress);
                ARP_Root.Nodes.Add(ARP_SenderIPAddress);
                ARP_Root.Nodes.Add(ARP_TargetMacAddress);
                ARP_Root.Nodes.Add(ARP_TargetIPAdress);

            }
            else
            {
                TreeView_Error();
            }
        }
        public void getHTTPPacket()
        {
            if (packet is HTTPPacket)
            {
                //TCP segment unresovled!!!!
                HTTPPacket http = (HTTPPacket)packet;
                if (http.HTTPData.Equals("")) return;

                TreeNode HTTP_Root = new TreeNode(); HTTP_Root.Text = "Hypertext Transfer Protocol";
                this.mf.treeView_PacketInfo.Nodes.Add(HTTP_Root);

                foreach (string str in http.HTTPInfo)
                {
                    HTTP_Root.Nodes.Add(new TreeNode(str));
                }
                //if (http.HTTP1stLine.Count()==1) return;
                //if (http.HTTPInfo[0].StartsWith("HTTP"))
                //{
                //    HTTP_Root.Nodes[0].Nodes.Add("Requst Version: " + http.HTTP1stLine[0]);
                //    HTTP_Root.Nodes[0].Nodes.Add("Status Code: " + http.HTTP1stLine[1]);
                //    HTTP_Root.Nodes[0].Nodes.Add("Response Phrase: " + http.HTTP1stLine[2]);
                //}
                //else
                //{
                //    HTTP_Root.Nodes[0].Nodes.Add("Requst Method: " + http.HTTP1stLine[0]);
                //    HTTP_Root.Nodes[0].Nodes.Add("Requst URL: " + http.HTTP1stLine[1]);
                //    HTTP_Root.Nodes[0].Nodes.Add("Requst Version: " + http.HTTP1stLine[2]);
                //}
            }
        }
        #endregion

        #region 在控件中显示包
        //在treeview中显示具体的packet细节
        public void ShowPacketInfo_tv()
        {
            this.mf.treeView_PacketInfo.Nodes.Clear();

            getEthernetPacket();
            if (EtherType == EthernetPacket.EtherType.IP || EtherType == EthernetPacket.EtherType.IPV6)
            {
                //ip
                getIPPacket();
                //icmp
                if (packet is ICMPPacket)
                {
                    getICMPPacket();
                }
                //tcp
                if (packet is TCPPacket)
                {
                    getTCPPacket();
                    //http
                    if (packet is HTTPPacket)
                    {
                        getHTTPPacket();
                    }
                }
                //udp
                if (packet is UDPPacket)
                {
                    getUDPPacket();
                }
            }

            if (EtherType == EthernetPacket.EtherType.ARP)
            {
                getARPPacket();
            }

            if (EtherType == EthernetPacket.EtherType.RARP)
            {
            }

        }
        //在texttable中显示packet的16进制信息
        public void ShowPacketInfo_text()
        {
            //初始化
            packetBuffer_0x.Clear();
            RowNo = 0;
            this.mf.textBox_Byte.Text="";
            //packetBuffer_0x.Clear();

            for (int i = 0; i < packet.Bytes.Length; )
            {
                if (i % 16 == 0)
                {
                    packetBuffer_0x.Append(RowNo.ToString().PadLeft(3, '0'));
                    RowNo++;
                    packetBuffer_0x.Append("  ");
                }
                packetBuffer_0x.Append(packet.Bytes[i].ToString("X").ToUpper().PadLeft(2, '0') + " ");
                i++;
                if (i % 8 == 0 && i / 8 % 2 != 0) packetBuffer_0x.Append(" ");
                //TextBox中的换行！！
                if (i % 16 == 0) packetBuffer_0x.Append("\r\n");

                //System.Convert.ToString(
            }
            this.mf.textBox_Byte.AppendText(packetBuffer_0x.ToString());
            //TCPPacket tcp = (TCPPacket)packet;
            //this.mf.textBox_Byte.AppendText(Encoding.ASCII.GetString(tcp.Data));
        }
        #endregion

        #region 异常
        public void TreeView_Error()
        {
            TreeNode Ex_Root = new TreeNode(); Ex_Root.Text = "null";
            this.mf.treeView_PacketInfo.Nodes.Add(Ex_Root);
        }
        #endregion
    }
}
