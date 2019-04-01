using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ts_Bl_interface
{
    public partial class FrmWeb : Form
    {
        string url;
        public FrmWeb(string text, string _url)
        {
            InitializeComponent();
            this.Text = text;
            this.url = _url;
        }
        public void ShowInfo(string _url)
        {
            webBrowser.Navigate(_url);
        }

        private void FrmWebBrowse_Load(object sender, EventArgs e)
        {
            ShowInfo(url);
        }

        private void FrmWeb_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch { }
        }

        private void FrmWeb_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch { }
        }
    }
}