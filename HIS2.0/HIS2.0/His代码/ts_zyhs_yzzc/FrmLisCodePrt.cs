using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_zyhs_yzzc
{
    public partial class FrmLisCodePrt : Form
    {
        public FrmLisCodePrt()
        {
            InitializeComponent();

        }

        private void FrmLisCodePrt_Load(object sender, EventArgs e)
        {
            string postId = TrasenFrame.Forms.FrmMdiMain.PortalsId;

            string strUrl = @"http://192.168.0.81:101/login_index.aspx?portalsid=" + postId;
            //webBrowser1.Url = new Uri(strUrl);
            webBrowser1.Navigate(new Uri(strUrl));

            if (string.IsNullOrEmpty(postId))
            {
                MessageBox.Show("无效的ID，请使用Lis账户登录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}