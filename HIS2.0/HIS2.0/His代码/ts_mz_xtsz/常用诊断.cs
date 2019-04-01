using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using ts_mz_class;

namespace ts_mz_xtsz
{
    public partial class FrmDiagnose : Form
    {

        #region
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;


        private long jgbm;

        DataTable tbOld;
        DataTable tbNow;
        #endregion

        #region
        public FrmDiagnose(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = chineseName;

        }
        #endregion

        #region Diagnose
        public void DiagnoseLoad()
        {
            string sql1, sql2;
            sql1 = "select coding as item_code,name as item_name,py_code,wb_code from jc_disease where coding not in (select zdbm from mzys_cyzd where ysdm='" + InstanceForm.BCurrentUser.EmployeeId + "' )";
            sql2 = "select zdbm as item_code,zdmc as item_name,pym as py_code,wbm as wb_code from mzys_cyzd where ysdm='" + InstanceForm.BCurrentUser.EmployeeId + "' ";

            tbOld = InstanceForm.BDatabase.GetDataTable(sql1);
            tbNow = InstanceForm.BDatabase.GetDataTable(sql2);

            dataGridView1.DataSource = tbOld;
            dataGridView2.DataSource = tbNow;
        }
        #endregion

        #region
        private void FrmDiagnose_Load(object sender, EventArgs e)
        {
            DiagnoseLoad();
        }
        #endregion

        #region
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentCell == null) return;
            DataTable tb = (DataTable)dataGridView1.DataSource;
            DataTable tbExist = new DataTable();
            int nrow = dataGridView1.CurrentCell.RowIndex;
            long jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
            DataRow mrow;
            mrow = tb.Rows[nrow];
            string sql1 = "select zdbm from mzys_cyzd where jgbm='" + jgbm + "' and zdbm='" + mrow["item_code"] + "' and ysdm='" + InstanceForm.BCurrentUser.EmployeeId + "'";
            tbExist = InstanceForm.BDatabase.GetDataTable(sql1);

            string sql2 = "insert mzys_cyzd values('" + jgbm + "','" + mrow["item_code"] + "','" + mrow["item_name"] + "','" + mrow["py_code"] + "','" + mrow["wb_code"] + "','0','" + InstanceForm.BCurrentUser.EmployeeId + "',getdate(),'0')";

            if (tbExist.Rows.Count == 0)
            {
                InstanceForm.BDatabase.DoCommand(sql2);
            }
            DiagnoseLoad();
        }
        #endregion

        #region
        private void txt_Oldquery_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    string sql = "";
                    sql = "select coding as item_code,name as item_name,py_code,wb_code from jc_disease where coding not in (select zdbm from mzys_cyzd where  ysdm=" + InstanceForm.BCurrentUser.EmployeeId + ") and ";

                    sql = sql + " ( py_code like '%" + this.txt_Oldquery.Text.Trim() + "%'";

                    sql = sql + " or coding like '%" + this.txt_Oldquery.Text.Trim() + "%'";

                    sql = sql + " or name like '" + this.txt_Oldquery.Text.Trim() + "')";

                    tbOld = InstanceForm.BDatabase.GetDataTable(sql);
                    dataGridView1.DataSource = tbOld;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_NowQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    string sql = "";
                    sql = "select zdbm as item_code,zdmc as item_name,pym as py_code,wbm as wb_code from mzys_cyzd where ysdm='" + InstanceForm.BCurrentUser.EmployeeId + "'  and ";

                    sql = sql + "( pym like '%" + this.txt_NowQuery.Text.Trim() + "%'";
                    sql = sql + " or zdbm like '%" + this.txt_NowQuery.Text.Trim() + "%'";
                    sql = sql + " or zdmc like '" + this.txt_NowQuery.Text.Trim() + "')";
                    tbNow = InstanceForm.BDatabase.GetDataTable(sql);
                    dataGridView2.DataSource = tbNow;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void txt_Oldquery_Click(object sender, EventArgs e)
        {
            txt_Oldquery.Text = "";
        }

        private void txt_NowQuery_Click(object sender, EventArgs e)
        {
            txt_NowQuery.Text = "";
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell == null) return;
            DataTable tb = (DataTable)dataGridView2.DataSource;
            int nrow = dataGridView2.CurrentCell.RowIndex;
            long jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
            DataRow mrow;
            mrow = tb.Rows[nrow];//Modify By Zj 2012-12-17 增加诊断名称的条件
            string sql1 = "delete from mzys_cyzd where jgbm='" + jgbm + "' and zdbm='" + mrow["item_code"] + "' and zdmc='" + mrow["item_name"] + "' and ysdm='" + InstanceForm.BCurrentUser.EmployeeId + "'";
            InstanceForm.BDatabase.DoCommand(sql1);
            DiagnoseLoad();
        }




    }
}