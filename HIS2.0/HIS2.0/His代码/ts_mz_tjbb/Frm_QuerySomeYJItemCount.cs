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
    public partial class Frm_QuerySomeYJItemCount : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frm_QuerySomeYJItemCount(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
  

            this.Text = _chineseName;
        }
        private void Frm_QuerySomeYJItemCount_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dtpBjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpEjksj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

        }

        private void Frm_QuerySomeYJItemCount_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Width = this.Width - 40;
            this.dataGridView1.Height = this.Height - this.dataGridView1.Top - 40;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {

            ParameterEx[] parameters = new ParameterEx[2];


            parameters[0].Text = "@rq1";
            parameters[0].Value = dtpBjksj.Value.ToString();

            parameters[1].Text = "@rq2";
            parameters[1].Value = dtpEjksj.Value.ToString();



            DataSet dset = new DataSet();
            TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("sp_QuerySomeYJItemCount", parameters, dset, "sfmx", 60);

            DataTable dt = dset.Tables[0];
          
            Fun.AddRowtNo(dt);
            this.dataGridView1.DataSource = dt;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        private void Print()
        {
            try
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;

                ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

                DataRow myrow = Dset.收费项目.NewRow();
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    int x = i + 1;
                    string nm = "T" + x.ToString();
                    myrow[nm] = dt.Columns[i].ColumnName.Trim();
                }
                Dset.收费项目.Rows.Add(myrow);

                for (int nrow = 0; nrow <= dt.Rows.Count - 1; nrow++)
                {
                    DataRow myrow1 = Dset.收费项目金额.NewRow();
                    for (int i = 0; i <= dt.Columns.Count - 1; i++)
                    {
                        int x = i + 1;
                        string nm = "JE" + x.ToString();
                        myrow1[nm] = dt.Rows[nrow][dt.Columns[i].ColumnName].ToString();
                    }
                    Dset.收费项目金额.Rows.Add(myrow1);
                }


                ParameterEx[] parameters = new ParameterEx[13];

                parameters[0].Text = "黑白B超";
                parameters[0].Value = GetNumColOfItem(dt, "黑白B超");
                parameters[1].Text = "彩超";
                parameters[1].Value = GetNumColOfItem(dt, "黑白B超");
                parameters[2].Text = "心电图";
                parameters[2].Value = GetNumColOfItem(dt, "心电图");
                parameters[3].Text = "脑血流图";
                parameters[3].Value = GetNumColOfItem(dt, "脑血流图");
                parameters[4].Text = "胃镜";
                parameters[4].Value = GetNumColOfItem(dt, "胃镜");
                parameters[5].Text = "肠镜";
                parameters[5].Value = GetNumColOfItem(dt, "肠镜");
                parameters[6].Text = "肝肾功能";
                parameters[6].Value = GetNumColOfItem(dt, "肝肾功能");
                parameters[7].Text = "三大常规";
                parameters[7].Value = GetNumColOfItem(dt, "三大常规");
                parameters[8].Text = "用血量";
                parameters[8].Value = GetNumColOfItem(dt, "用血量");
                parameters[9].Text = "血气分析";
                parameters[9].Value = GetNumColOfItem(dt, "血气分析");
                parameters[10].Text = "切片";
                parameters[10].Value = GetNumColOfItem(dt, "切片");
                parameters[11].Text = "涂片";
                parameters[11].Value = GetNumColOfItem(dt, "涂片");
                parameters[12].Text = "动态心电图";
                parameters[12].Value = GetNumColOfItem(dt, "动态心电图");



                TrasenFrame.Forms.FrmReportView f = null;

                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\医技项目人次统计.rpt", parameters);

                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string GetNumColOfItem(DataTable dt, string itemName)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["项目名称"].ToString() == itemName)
                {
                    return dt.Rows[i]["人次/数量"].ToString();
                }
            }
            return "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Print();
        }

    }
}