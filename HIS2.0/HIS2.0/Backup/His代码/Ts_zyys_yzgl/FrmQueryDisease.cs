using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;

namespace Ts_zyys_yzgl
{
    public partial class FrmQueryDisease : Form
    {
        public DataTable _dtAll = new DataTable();

        public FrmQueryDisease()
        {
            InitializeComponent();

            DoInit();
        }

        public void DoInit()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AutoGenerateColumns = false;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.AutoGenerateColumns = false;

            txtQuery.TextChanged += new EventHandler(delegate(object s, EventArgs args)
            {
                if (_dtAll != null)
                {
                    DataTable dtAllInfo = _dtAll.Copy();

                    string strFil = " 1=1 ";
                    DoFilData(ref strFil);

                    DoBindData(dtAllInfo,  strFil);
                }
            });
        }

        public void DoQueryYyYbZd()
        {
            string strSql = string.Format(@"select a.ID,YYJBBM,YYJBMC,YBJBBM,YBJBMC,b.PY_CODE as pym,b.WB_CODE wbm,a.yb_wbm,a.yb_pym
                                            from JC_DISEASE_YYYBDZ a
                                            inner join JC_DISEASE b on a.YYJBBM=b.CODING and b.YBJKLX=40
                                            where a.YBJKLX=40");

            _dtAll = FrmMdiMain.Database.GetDataTable(strSql);

            DataTable dtAll = _dtAll.Copy();

            string strFil=" 1=1 ";
            DoFilData(ref strFil);
            DoBindData(dtAll,  strFil);
        }

        public void DoQueryInpDisease()
        {

            string strSql = string.Format(@"select a.INPATIENT_NO,a.NAME,b.DISEASE_CODE as ICD,b.DISEASE_MARK,b.DISEASE_NAME as out_zd,b.YBJBBM as ybbm,b.YBJBMC as ybzd
                                            from VI_ZY_VINPATIENT a 
                                            inner join ZY_DISEASE_MANY b on a.INPATIENT_ID=b.INPATIENT_ID --and b.DISEASE_MARK='第1诊断'
                                            where a.INPATIENT_NO='{0}'  ", TszyHIS.InpatientNo.FormatZyh(txtZyh.Text.Trim()));

            DataTable dt = FrmMdiMain.Database.GetDataTable(strSql);

            dataGridView2.DataSource = dt;
            
        }

        private void DoFilData(ref string strFil)
        {
            //strFil += "and " + (rbtAll.Checked ? "'1'" : "del_bit") + "=" + (rbtAll.Checked ? "'1'" : rbtOpen.Checked ? "0" : "1");
            
            if (!string.IsNullOrEmpty(txtQuery.Text.Trim()))
            {
                strFil += " and (pym  like '%" + txtQuery.Text.Trim() + "%' or wbm like '%" + txtQuery.Text.Trim() + "%' or yb_pym like '%" + txtQuery.Text.Trim() + "%' or yb_wbm like '%" + txtQuery.Text.Trim() + "%')";
                //strFil += " and (pym  like '%" + txtQuery.Text.Trim() + "%' or wbm like '%" + txtQuery.Text.Trim() + "%' or YYJBBM like '%" + txtQuery.Text.Trim() + "%' or YYJBMC like '%" + txtQuery.Text.Trim() + "%' or YBJBBM like '%" + txtQuery.Text.Trim() + "%' or YBJBMC like '%" + txtQuery.Text.Trim() + "%')";
                //strFil += " and ( YYJBBM like '%" + txtQuery.Text.Trim() + "%' or YYJBMC like '%" + txtQuery.Text.Trim() + "%' or YBJBBM like '%" + txtQuery.Text.Trim() + "%' or YBJBMC like '%" + txtQuery.Text.Trim() + "%')";
            }
        }

        private void DoBindData(DataTable dtAllInfo, string strFil)
        {
            try
            {
                if (dataGridView1.DataSource != null)
                {
                    (dataGridView1.DataSource as DataTable).Clear();
                }

                DataTable dtBind = new DataTable();
                dtAllInfo.DefaultView.RowFilter = strFil;
                dtBind = dtAllInfo;

                if (dtBind != null && dtBind.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dtBind;
                    (this.dataGridView1.DataSource as DataTable).AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void FrmQueryDisease_Load(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                DoQueryYyYbZd();
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                DoQueryInpDisease();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedTab == tabPage1)
            //{
            //    DoQueryYyYbZd();
            //}
            //else if (tabControl1.SelectedTab == tabPage2)
            //{
            //    DoQueryInpDisease();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoQueryInpDisease();
        }
    }
}