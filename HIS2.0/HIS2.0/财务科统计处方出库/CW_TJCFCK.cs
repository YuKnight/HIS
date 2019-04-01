using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using cw_tjcfck;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace cw_tjcfck
{
    public partial class CW_TJCFCK : Form
    {
        public CW_TJCFCK()
        {
            InitializeComponent();
        }
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
       
        public CW_TJCFCK(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.WindowState = FormWindowState.Maximized;
        }
        private void butcx_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                string ywlx = this.YWLX.Text;
                if (ywlx == "门诊处方出库")
                {
                    ywlx = "017";
                }
                if (ywlx == "住院处方出库")
                {
                    ywlx = "020";
                }
              
                if (ywlx == "其他领药单")
                {
                    ywlx = "014";
                }

                string yplx = this.YPLX.Text;
                if (yplx == "西药")
                {
                    yplx = "1";
                }
                else if (yplx == "中成药")
                {
                    yplx = "2";
                }
                else if (yplx == "草药")
                {
                    yplx = "3";
                }
                string yqid = this.combyq.Text;

                if (yqid == "南院")
                {
                    yqid = "1001";
                }
                if (yqid == "后湖")
                {
                    yqid = "1002";
                }
                string typeid = this.typeid.Text;
              
              
                    ParameterEx[] parameters = new ParameterEx[5];
                    parameters[0].Value = ywlx;
                    parameters[1].Value = yplx;
                    parameters[2].Value = dtp1.Value.ToString();
                    parameters[3].Value = dtp2.Value.ToString();
                   // parameters[4].Value = typeid;
                    parameters[4].Value = yqid;
                    
                    parameters[0].Text = "@ywlx";
                    parameters[1].Text = "@yplx";
                    parameters[2].Text = "@dtp1";
                    parameters[3].Text = "@dtp2";
                   // parameters[4].Text = "@deptname";
                    parameters[4].Text = "@yqid";

                    DataSet dset = new DataSet();
                    InstanceForm.BDatabase.AdapterFillDataSet("SP_YF_tj_djqktj_CW_DeptSum", parameters, dset, "kss", 30);
                    this.dataGridView1.DataSource = dset.Tables[0];
                    this.dataGridView2.DataSource = dset.Tables[1];

                }
               
               

         
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }
       

        private void CW_TJCFCK_Load(object sender, EventArgs e)
        {
            this.YWLX.Text = "门诊处方出库";
            this.YPLX.Text = "西药";
            combks(typeid);
            this.typeid.Text = "门诊";
            this.combyq.Text = "南院";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ReadOnly = true;

        }

        private void combks(ComboBox combobox)
        {
            DataTable dt = new DataTable();
            string sql = string.Format(@"select distinct  DeptName  from  jc_Dept_SubDept_compared");
            dt = InstanceForm.BDatabase.GetDataTable(sql);
            combobox.DataSource = dt;
            combobox.DisplayMember = "DeptName";
            combobox.ValueMember = "DeptName";
            combobox.SelectedValue = "0";
        }

    }
}