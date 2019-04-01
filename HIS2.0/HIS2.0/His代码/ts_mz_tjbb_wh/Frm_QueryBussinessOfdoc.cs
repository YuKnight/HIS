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
using ts_mz_class;

namespace ts_mz_tjbb
{
    public partial class Frm_QueryBussinessOfdoc : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private ClsParams _param;
        public Frm_QueryBussinessOfdoc(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void Frm_QueryBussinessOfdoc_Load(object sender, EventArgs e)
        {
            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            this.WindowState = FormWindowState.Maximized;
            this.cmbSource.SelectedIndex = 0;
        }

        private void GetData_Total()
        {
            int count = 10;
            if (!Int32.TryParse(comboBox1.Text, out count))
            {
                count = 10;
                comboBox1.Text = "10";
            }

            ParameterEx[] parameters = new ParameterEx[5];


            parameters[0].Text = "@rq1";
            parameters[0].Value = dtpBjksj.Value.ToString();

            parameters[1].Text = "@rq2";
            parameters[1].Value = dtpEjksj.Value.ToString();

            parameters[2].Text = "@sourceType";
            parameters[2].Value = this.cmbSource.SelectedIndex;

            parameters[3].Text = "@Num";
            parameters[3].Value = count;

            parameters[4].Text = "@docName";
            parameters[4].Value = textBox1.Text.Replace("'", "''");

            this._param = new ClsParams();
            this._param.rq1 = DateTime.Parse(dtpBjksj.Value.ToString());
            this._param.rq2 =DateTime.Parse( dtpEjksj.Value.ToString());
            this._param.sourceType = this.cmbSource.SelectedIndex;
            

            DataSet dset = new DataSet();
            TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("sp_MZ_QueryBussinessOfdoc", parameters, dset, "sfmx", 60);

            Fun.AddRowtNo(dset.Tables[0]);
            this.dataGridView1.DataSource = dset.Tables[0];
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (this.dataGridView1.Columns[i].Name.ToLower() == "ksdm" || dset.Tables[0].Columns[i].ColumnName.ToLower() == "docid")
                {
                    this.dataGridView1.Columns[i].Visible = false;
                }
            }
        }


        private void GetData_doc()
        {


            ParameterEx[] parameters = new ParameterEx[5];


            parameters[0].Text = "@rq1";
            parameters[0].Value = this._param.rq1;

            parameters[1].Text = "@rq2";
            parameters[1].Value = this._param.rq2;

            parameters[2].Text = "@sourceType";
            parameters[2].Value = this._param.sourceType;

            parameters[3].Text = "@docId";
            parameters[3].Value = this._param.docId;

            parameters[4].Text = "@department";
            parameters[4].Value = int.Parse(this._param.departmentID);



            DataSet dset = new DataSet();
            TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("sp_MZ_QueryBussinessOfdoc_single", parameters, dset, "sfmx", 60);

            Fun.AddRowtNo(dset.Tables[0]);
            this.dataGridView2.DataSource = dset.Tables[0];
            for (int i = 0; i < this.dataGridView2.Columns.Count; i++)
            {
                this.dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (this.dataGridView2.Columns[i].Name.ToLower() == "ksdm" || dset.Tables[0].Columns[i].ColumnName.ToLower() == "docid")
                {
                    this.dataGridView2.Columns[i].Visible = false;
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            GetData_Total();
            this.label2.Text = "当前医生收入构成：";
            this.dataGridView2.DataSource = null;
        }

        private void Frm_QueryBussinessOfdoc_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Top = 70;
            this.dataGridView1.Width = this.Width - 40;
            this.dataGridView2.Width = this.Width - 40;
            this.dataGridView1.Height = (this.Height - 100) / 2;
            this.label2.Top = this.dataGridView1.Height + this.dataGridView1.Top + 20;
            this.dataGridView2.Top = this.label2.Top + this.label2.Height + 10;
            this.dataGridView2.Height = this.Height - this.dataGridView2.Top - 50;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (this._param == null) return;
            DataTable dt = (DataTable)this.dataGridView1.DataSource;
            this._param.departmentID = dt.Rows[e.RowIndex]["ksdm"].ToString();
            this._param.docId = int.Parse(dt.Rows[e.RowIndex]["医生ID"].ToString());
            this.label2.Text = "当前医生收入构成< " + dt.Rows[e.RowIndex]["医生姓名"].ToString().Trim() + " >：";
            GetData_doc();
        }


    }
}