using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using YpClass;

namespace ts_yf_mzpy
{
    public partial class Frmcksz : Form
    {
        public Frmcksz()
        {
            InitializeComponent();
        }

        static string _pfckh;
        internal static string pfckh 
        {
            get
            {
                return _pfckh;
            }
            set
            {
                _pfckh = value;
            }
        }

        private void Frmcksz_Load(object sender, EventArgs e)
        {
            DataTable tb = MZPY.Get_pyck("", "", InstanceForm.BDatabase);
            tb.TableName = "tab";
            cmbpyck.DataSource = tb;
            cmbpyck.ValueMember = "CODE";
            cmbpyck.DisplayMember = "NAME";
            if (cmbpyck.Items.Count > 0)
                cmbpyck.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbpyck.Items.Count > 0 && cmbpyck.SelectedIndex > -1)
            {
                _pfckh = cmbpyck.SelectedValue.ToString();
            }
        }
    }
}