using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpPcap;
using SharpPcap.Containers;

namespace WindowsFormsApplication1
{
    public partial class InterfaceDetailsForm : Form
    {
        public InterfaceDetailsForm()
        {
            InitializeComponent();
        }
        public InterfaceDetailsForm(PcapDevice dev)
        {
            InitializeComponent();
            list_InterfaceDetails.Items.Add("名称:\t\t" + dev.Name);
            list_InterfaceDetails.Items.Add("友好名称:\t" + dev.Interface.FriendlyName);
            list_InterfaceDetails.Items.Add("描述:\t\t" + dev.Description);
            list_InterfaceDetails.Items.Add("--------------------------------------");
            foreach(PcapAddress addr in dev.Addresses)
            {
                
                list_InterfaceDetails.Items.Add(" ");
                if (addr.Addr != null)
                    list_InterfaceDetails.Items.Add("地址:\t\t" + addr.Addr.ToString());
                if(addr.Broadaddr!=null)
                    list_InterfaceDetails.Items.Add("子网掩码:\t" + addr.Broadaddr.ToString());
                if(addr.Netmask!=null)
                    list_InterfaceDetails.Items.Add("广播地址:\t" + addr.Netmask.ToString());
                if(addr.Dstaddr!=null)
                    list_InterfaceDetails.Items.Add("MAC地址:\t\t" + addr.Dstaddr.ToString());
            }
            list_InterfaceDetails.Items.Add("--------------------------------------");
            list_InterfaceDetails.Items.Add("标识:\t\t" + dev.Flags);
        }

        private void InterfaceDetails_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
