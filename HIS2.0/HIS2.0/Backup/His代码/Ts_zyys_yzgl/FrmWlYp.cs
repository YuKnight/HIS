using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ts_zyys_public;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;

namespace Ts_zyys_yzgl
{
     
    public partial class FrmWlYp : Form
    {
        public  bool _cr;
        public string _yplx;
        private string _ypmc;
        private string _ypgg;
        /// <summary>
        /// 药品名称
        /// </summary>
        public string Ypmc
        {
            get { return _ypmc; }
        }
        /// <summary>
        /// 药品规格
        /// </summary>
        public string Ypgg
        {
            get { return _ypgg; }
        }
        Ts_zyys_public.DbQuery dbQuery = new DbQuery(InstanceForm._database);
        public FrmWlYp()
        {
            InitializeComponent();
        }

        private void FrmWlYp_Load(object sender, EventArgs e)
        {
            this.combYPlx.DisplayMember = "mc";
            this.combYPlx.ValueMember = "id";
            this.combYPlx.DataSource=dbQuery.GetYplx();
            textBoxExYpmc.Focus();
            this.combYPlx.SelectedValue = -1;
        }

        private void btnQiutPath_Click(object sender, EventArgs e)
        {
            _ypmc = this.textBoxExYpmc.Text.Trim();
            _ypgg = this.textBoxExYpgg.Text.Trim();
            
            if (this.radioButton1.Checked)
                _cr = true;
            else
                _cr = false;
            string ts = "";
            if (_ypmc.Trim() == ""||this.combYPlx.Text.Trim()=="")
            {
                ts = "药品名称 |  药品类型不能为空";
            }
            if (ts.Trim() != "")
            {
                MessageBox.Show(ts);
                this.textBoxExYpmc.Focus();
            }
            else
            {
                _yplx = this.combYPlx.SelectedValue.ToString();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ypmc = "";
            this.Close();
        }

        private void textBoxExYpmc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.SelectNextControl((Control)sender, true, false, true, true);
                return;
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0xa3)
            {
                return;
            }
            base.WndProc(ref m);
        }
    }
}