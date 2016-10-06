using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1.Tools
{
    public class ListViewNF : System.Windows.Forms.ListView
    {

        //次构造函数可以取消闪烁情况
        public ListViewNF()
        {
            // 开启双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            // Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }

        }

        //public delegate void ScrollEventHandler(object sender, EventArgs e);
        //水平滚动条的事件
        public event EventHandler HScroll;
        //垂直滚动条的滚动事件
        public event EventHandler VScroll;

        const int WM_HSCROLL = 0x0114;
        const int WM_VSCROLL = 0x0115;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HSCROLL)
            {
                OnHScroll(this, new EventArgs());
            }
            else if (m.Msg == WM_VSCROLL)
            {
                OnVScroll(this, new EventArgs());
            }
            base.WndProc(ref m);
        }
        virtual protected void OnHScroll(object sender, EventArgs e)
        {
            if (HScroll != null)
                HScroll(this, e);
        }
        virtual protected void OnVScroll(object sender, EventArgs e)
        {
            if (VScroll != null)
                VScroll(this, e);
        }


    }
}
