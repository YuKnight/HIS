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
using TrasenClasses.DatabaseAccess;
using System.Data.SqlClient;
using TrasenFrame;
using TrasenFrame.Forms;

namespace ts_mz_txyy
{
    public partial class yygzltj : Form
    {
        int count = 0;
        public yygzltj()
        {

            InitializeComponent();
        }

        private void yygzltj_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.AutoGenerateColumns = false;

            comqdbinddata();
            comdksbinddata();
            // btnquery_Click(null, null);

        }
        private void comqdbinddata()
        {
            DataTable dt = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "qdid";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "qdmc";
            dt.Columns.Add(column);

            //row = dt.NewRow();
            //row["qdid"] = 1;
            //row["qdmc"] = "院内预约";
            //dt.Rows.Add(row);

            row = dt.NewRow();
            row["qdid"] = 2;
            row["qdmc"] = "诊间复诊预约";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["qdid"] = 3;
            row["qdmc"] = "出院复诊预约";
            dt.Rows.Add(row);

            combqd.DataSource = dt;
            combqd.DisplayMember = "qdmc";
            combqd.ValueMember = "qdid";

        }
        private void comdksbinddata()
        {

            DataTable dt = new DataTable();
            int currentks = FrmMdiMain.CurrentDept.DeptId;
            string strsql = string.Format(@"select FLMC,KSID, * from JC_MZ_TJ_KSFL where KSID in ({0})", currentks);
            dt = FrmMdiMain.Database.GetDataTable(strsql);
            this.comboBox2.DataSource = dt;
            this.comboBox2.DisplayMember = "FLMC";
            this.comboBox2.ValueMember = "PX";


            DataTable dt2 = new DataTable();
            string strssql = string.Format(@"SELECT KSID,DEPTNAME FROM (
                                             select KSID,dbo.fun_getDeptname(ksid) as deptname from JC_MZ_TJ_KSFL
                                             where flmc='{0}'
                                             union all
                                             select 0 as KSID,'全部科室' as deptname  ) AS T  order by T.KSID", this.comboBox2.Text);
            dt2 = FrmMdiMain.Database.GetDataTable(strssql);
            this.comboBox1.DataSource = dt2;
            this.comboBox1.DisplayMember = "deptname";
            this.comboBox1.ValueMember = "ksid";
            this.comboBox1.SelectedValue = "0";

        }

        public static DataTable GetInfo_mz_yygzl(string StartDate, string EndDate, int GhyId, string strPTID, string strKSID, string strflmc, RelationalDatabase _DataBase)
        {
            DataTable tb = null;
            try
            {
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@STARTDATE";
                parameters[0].Value = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[1].Text = "@ENDDATE";
                parameters[1].Value = Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss");


                parameters[2].Text = "@PTID";
                parameters[2].Value = strPTID;

                parameters[3].Text = "@DEPTID";
                parameters[3].Value = strKSID;

                parameters[4].Text = "@DJY";
                parameters[4].Value = GhyId;

                parameters[5].Text = "@flmc";
                parameters[5].Value = strflmc;
                tb = _DataBase.GetDataTable("SP_MZ_YYGH_ZZL_DEPT", parameters);


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
            return tb;
        }

        public static DataTable GetInfo_mz_yygzl_gr(string StartDate, string EndDate, int GhyId, string strPTID, string strKSID, string strflmc, RelationalDatabase _DataBase)
        {
            DataTable tb = null;
            try
            {
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@STARTDATE";
                parameters[0].Value = Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[1].Text = "@ENDDATE";
                parameters[1].Value = Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd HH:mm:ss");


                parameters[2].Text = "@PTID";
                parameters[2].Value = strPTID;

                parameters[3].Text = "@DEPTID";
                parameters[3].Value = strKSID;

                parameters[4].Text = "@DJY";
                parameters[4].Value = GhyId;

                parameters[5].Text = "@flmc";
                parameters[5].Value = strflmc;
                tb = _DataBase.GetDataTable("SP_MZ_YYGH_ZZL_GR", parameters);


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
            return tb;
        }

        private void btnquery_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            int Ghy = 0;
            string strFromTime = dtp1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string strEndTime = dtp2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            string stringQD = this.combqd.SelectedValue.ToString();
            string strKS = this.comboBox1.SelectedValue.ToString();
            string strdks = this.comboBox2.Text;

            DataTable dt = GetInfo_mz_yygzl(strFromTime, strEndTime, Ghy, stringQD, strKS, strdks, InstanceForm.BDatabase);
            dataGridView1.DataSource = dt;
            //dataGridView1_CurrentCellChanged(null,null);
            

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    int nrow = this.dataGridView1.CurrentCell.RowIndex;
            //    DataTable tb = (DataTable)this.dataGridView1.DataSource;
            //    string strKS = tb.Rows[nrow]["deptid"].ToString();
            //    //string strKS = dataGridView1.CurrentRow.Cells["deptid"].Value.ToString();

            //    int Ghy = 0;
            //    string strFromTime = dtp1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            //    string strEndTime = dtp2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            //    string stringQD = this.combqd.SelectedValue.ToString();
            //    // string strKS = this.comboBox1.SelectedValue.ToString();
            //    string strdks = this.comboBox2.Text;
            //    DataTable dt2 = GetInfo_mz_yygzl_gr(strFromTime, strEndTime, Ghy, stringQD, strKS, strdks, InstanceForm.BDatabase);
            //    dataGridView2.DataSource = dt2;

            //}
            //catch (System.Exception err)
            //{
            //    MessageBox.Show("发生错误" + err.Message);
            //}
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int nrow = this.dataGridView1.CurrentCell.RowIndex;
                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                string strKS = tb.Rows[nrow]["deptid"].ToString();
                //string strKS = dataGridView1.CurrentRow.Cells["deptid"].Value.ToString();

                int Ghy = 0;
                string strFromTime = dtp1.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string strEndTime = dtp2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                string stringQD = this.combqd.SelectedValue.ToString();
                // string strKS = this.comboBox1.SelectedValue.ToString();
                string strdks = this.comboBox2.Text;
                DataTable dt2 = GetInfo_mz_yygzl_gr(strFromTime, strEndTime, Ghy, stringQD, strKS, strdks, InstanceForm.BDatabase);
                dataGridView2.DataSource = dt2;

            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

    } 
}