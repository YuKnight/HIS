using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Ts_zyys_main
{
    public delegate void GdtGt();
    public class myListview : ListView
    {
        public event GdtGt GD;
        public myListview()
        {
            
        }
         
        protected override void WndProc(ref Message m)
         {

            if (m.Msg == 0x0115 || m.Msg == 0x0114|| m.Msg == 0x020A)//滚动条滚动
            {
                GD();
            }
             base.WndProc(ref m);

        }

    }
}
