using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_mzys_blcflr
{
    public partial class FrmJkdallq : Form
    {
        string _PID = "";
        string _Name = "";
        public FrmJkdallq(string PID, string Name)
        {
            _PID = PID;
            _Name = Name;
            InitializeComponent();
        }

        private void FrmJkdallq_Load(object sender, EventArgs e)
        {
            string conname = UnicodeConverter(_Name);
            this.webBrowser1.Navigate("http://172.32.0.133:8765/ehr/ehr_view/bespeak/pages/login.jsp?userType=D&username=44517902343020311A2101&management=S&card_type=98&card_num=" + _PID + "&p_name=" + conname + "&singlewindow=false");
        }


        public static string UnicodeConverter(string str)
        {
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    outStr += "\\u" + ((int)str[i]).ToString("x");
                }
            }
            return outStr;
        }

    }
}