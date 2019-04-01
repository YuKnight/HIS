using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Data;
using YpClass;
using System.Windows.Forms;

namespace ts_zyhs_ypxx
{
    public partial class FrmSjjlcx : Form
    {
        public FrmSjjlcx()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable rtnTb = new DataTable();
            string sSql = "";
            ParameterEx[] parameters = new ParameterEx[3];
            DateTime date1 = this.dateTimePicker1.Value;
            DateTime date2 = this.dateTimePicker2.Value;
            int deptly = InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId;
            try
            {
                sSql = "sp_zyhs_selectzcysjjl";
                parameters[0].Value = date1;
                parameters[0].Text = "@kssj";
                parameters[1].Value = date2;
                parameters[1].Text = "@jssj";
                parameters[2].Value = deptly;
                parameters[2].Text = "@deptly";
                rtnTb = InstanceForm.BDatabase.GetDataTable(sSql, parameters, 120);
                this.dataGridView1.DataSource = rtnTb;
                this.dataGridView1.ReadOnly = true;
                for (int i = 0; i < this.dataGridView1.RowCount;i++ )
                {
                    if (this.dataGridView1.Rows[i].Cells["药品名称"].Value.ToString().Trim() == "小计")
                    {
                        this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
                        this.dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                    }
                    if (this.dataGridView1.Rows[i].Cells["药品名称"].Value.ToString().Trim() == "合计")
                    {
                        this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                        this.dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Brown;
                    }
                    if (this.dataGridView1.Rows[i].Cells["结余金额"].Value.ToString().Trim()!=""&& decimal.Parse(this.dataGridView1.Rows[i].Cells["结余金额"].Value.ToString().Trim()) < 0)
                    {
                     //   this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                        this.dataGridView1.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, InstanceForm.BCurrentDept.WardDeptName + " 药品上缴记录",
                "日期:" + this.dateTimePicker1.Value.ToShortDateString() + " 到 " + this.dateTimePicker2.Value.ToShortDateString(), true, false,false, false);
        }
    }
}