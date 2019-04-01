using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ts_zyhs_ypxx
{
    public partial class Frmhy : Form
    {
        public bool Bok = false;
        public Frmhy(int ggid, int cjid, int deptid)
        {
            InitializeComponent();

            string ssql = "select s_yppm 品名,s_ypgg 规格,s_sccj 厂家,lsj 单价,cast(kcl as float) 库存量,dbo.fun_yp_ypdw(zxdw) 单位,cjid,dwbl,shh 货号,cast(bdelete_kc as smallint)  禁用 from vi_yf_kcmx where ggid=" + ggid + " and deptid=" + deptid + " and cjid<>" + cjid + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            this.dataGridView1.DataSource = tb;
            if (tb.Rows.Count == 0)
                butsave.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            Bok = true;
            this.Close();
        }
    }
}