using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpPcap.Packets;

namespace WindowsFormsApplication1.Capture
{
    public class Exchange
    {
        public Exchange()
        {
        }
        public string toArpOpCode(int code)
        {
            switch (code)
            {
                case 1: return "request";
                case 2: return "reply";
            }
            return "null";
        }
        public string toFormatEthernetAddress(string address)
        {
            return address.Insert(2, ":").Insert(5, ":").Insert(8, ":").Insert(11, ":").Insert(14, ":");
        }
        public string toReadableTCPFlags(TCPPacket tcp)
        {
            string result = null;
            if (tcp.CWR && result != null) result += ", CWR";
            if (tcp.CWR && result == null) result += "CWR";

            if (tcp.ECN && result != null) result += ", ECN";
            if (tcp.ECN && result == null) result += "ECN";

            if (tcp.Urg && result != null) result += ", URG";
            if (tcp.Urg && result == null) result += "URG";

            if (tcp.Ack && result != null) result += ", ACK";
            if (tcp.Ack && result == null) result += "ACK";

            if (tcp.Psh && result != null) result += ", PSH";
            if (tcp.Psh && result == null) result += "PSH";

            if (tcp.Rst && result != null) result += ", RST";
            if (tcp.Rst && result == null) result += "RST";

            if (tcp.Syn && result != null) result += ", SYN";
            if (tcp.Syn && result == null) result += "SYN";

            if (tcp.Fin && result != null) result += ", FIN";
            if (tcp.Fin && result == null) result += "FIN";

            return result;

        }
        public string toInt(bool b)
        {
            if (b) return "1";
            else return "0";
        }
        public string toReadableLong(long no)
        {
            string No = no.ToString();
            for (int i = No.Length - 1; i >= 0; )
            {
                i = i - 3;
                if (i <= 0) break;
                No.Insert(i, ",");
            }
            return No;
        }



    }
}
