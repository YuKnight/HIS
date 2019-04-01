using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
namespace Ts_zyys_main
{
    public partial class FrmWwcxm : Form
    {
        public DataSet ds = new DataSet();
        public FrmWwcxm()
        {
            InitializeComponent();
           
        }

         

        private void FrmWwcxm_Load(object sender, EventArgs e)
        {
            //ParameterEx[] pe = new ParameterEx[2];
            //pe[0].Text = "@DEPT_ID ";
            //pe[0].Value = InstanceForm._currentDept.DeptId;
            //pe[1].Text = "@DOC_ID";
            //pe[1].Value = InstanceForm._currentUser.EmployeeId;
            //DataSet ds = new DataSet();
            //RelationalDatabase Database = new MsSqlServer();
            //Database.Initialize(InstanceForm._database.ConnectionString);
            //Database.AdapterFillDataSet("SP_ZYYS_GET_WWCXM", pe, ds, "tb", 60);
            this.dataGridView1.DataSource = ds.Tables[0];
            this.dataGridView2.DataSource = ds.Tables[1];
            this.dataGridView3.DataSource = ds.Tables[2];
            this.dataGridView4.DataSource = ds.Tables[3];
            try
            {
                this.dataGridView5.DataSource = ds.Tables[4];
            }
            catch { }
            try
            {
                this.dataGridView6.DataSource = ds.Tables[5];
            }
            catch { }
            if (this.dataGridView5.Rows.Count == 0 )
            {
                this.tabControl2.Visible = false;
                 
            }
            if (this.dataGridView6.Rows.Count == 0)
                this.tabControl4.Visible = false;
            if (this.dataGridView6.Rows.Count == 0 && this.dataGridView5.Rows.Count == 0)
            {
                this.tableLayoutPanel1.ColumnStyles[1].Width = 0;
            }
            this.Refresh();
            //int rows = 0;
            //rows = ds.Tables[0].Rows.Count + ds.Tables[2].Rows.Count + ds.Tables[1].Rows.Count + ds.Tables[3].Rows.Count;
            //try
            //{
            //    rows = ds.Tables[0].Rows.Count + ds.Tables[2].Rows.Count + ds.Tables[1].Rows.Count + ds.Tables[3].Rows.Count + ds.Tables[4].Rows.Count + ds.Tables[5].Rows.Count;
            //}
            //catch { }
            //if (rows == 0)
            //    this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ddd");
        }
    }
}