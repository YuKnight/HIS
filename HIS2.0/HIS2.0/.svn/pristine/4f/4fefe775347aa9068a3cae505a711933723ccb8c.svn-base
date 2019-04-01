using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;

namespace Ts_OrderRegist
{
    /// <summary>
    /// add by zp 2014-10-21
    /// 预约平台设置
    /// </summary>
    public partial class Frm_YYPTSZ : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private User _CurrentUser;

        public Frm_YYPTSZ()
        {
            InitializeComponent();
        }
        public Frm_YYPTSZ(MenuTag menuTag, string chineseName, Form mdiParent, User _user)
        {
            InitializeComponent();
            _CurrentUser = _user;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
        }
        private void Frm_YYPTSZ_Load(object sender, EventArgs e)
        {
            SystemCfg _cfg1150 = new SystemCfg(1150);
            if (string.IsNullOrEmpty(_cfg1150.Config))
            {
                MessageBox.Show("未设置预约平台地址[1150]参数值,请设置1150参数值!", "提示");
                return;
            }
            this.webBrowser1.Url = new Uri(_cfg1150.Config);
            Screen[] _screen = Screen.AllScreens;
            int width = _screen[0].WorkingArea.Width;
            int height = _screen[0].WorkingArea.Height;
            this.Width = width;
            this.Height = height;
            this.WindowState = FormWindowState.Maximized;
        }


    }
}
