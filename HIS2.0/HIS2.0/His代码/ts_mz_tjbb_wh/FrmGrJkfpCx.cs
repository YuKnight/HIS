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
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using Microsoft.Win32;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
namespace ts_mz_tjbb
{
    public partial class FrmGrJkfpCx : Form
    {
        public FrmGrJkfpCx()
        {
            InitializeComponent();
        } 

        private void FrmGrJkfpCx_Load(object sender, EventArgs e)
        {
            this.comboBox1.ValueMember = "EMPLOYEE_ID";
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.DataSource = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("select * from JC_EMPLOYEE_PROPERTY where RYLX=3 and DELETE_BIT=0");
          
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.crystalReportViewer1.ReportSource = null;
            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Text = "@sfy";
            parameters[0].Value = this.comboBox1.SelectedValue;

            parameters[1].Text = "@qsh";
            parameters[1].Value =Int64.Parse(this.txtqsh.Text);

            parameters[2].Text = "@jsh";
            parameters[2].Value = Int64.Parse(this.txtjsh.Text);

            parameters[3].Text = "@type";
            parameters[3].Value = radioButton1.Checked ?1:2;
            
            DataTable tbinfo = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("sp_getsfyjkqk", parameters);
            if (tbinfo.Rows.Count <= 0)
            {
                MessageBox.Show("没有找到相关记录,请修改条件后查询");
                return;
            }
            DataSet1.收费员个人交款发票统计DataTable dataTable = new DataSet1.收费员个人交款发票统计DataTable();
            
            for (int i = 0; i < tbinfo.Columns.Count; i++)
            {
                if (tbinfo.Columns[i].ColumnName.Contains(":"))
                {
                    DataRow _row = dataTable.NewRow();
                    _row["sfyxm"] = this.comboBox1.Text;
                    _row["xmmc"] = tbinfo.Columns[i].ColumnName;
                    _row["xmbm"] = "";
                    _row["je"] = tbinfo.Rows[0][i];
                    _row["zje"] = tbinfo.Rows[0]["总金额"];
                    _row["xjzf"] = tbinfo.Rows[0]["现金支付"];
                    _row["ybzf"] = tbinfo.Rows[0]["医保支付"];
                    _row["ylzf"] = tbinfo.Rows[0]["银联卡支付"];
                    _row["zpzf"] = tbinfo.Rows[0]["支票支付"];
                    _row["feipiaoxx"] = tbinfo.Rows[0]["废票信息"];
                    _row["fpd"] = tbinfo.Rows[0]["发票段"];
                    dataTable.Rows.Add(_row);
                }
            }
            ReportDocument rptdoc = new ReportDocument();
            string ss1 = Constant.CustomDirectory;
            try
            {
                if(this.radioButton1.Checked)
                   rptdoc.Load(Constant.CustomDirectory + "\\Report\\门诊收费员个人交款发票统计.rpt");
                else
                  rptdoc.Load(Constant.CustomDirectory + "\\Report\\住院收费员个人交款发票统计.rpt");
            }
            catch
            {
                if (this.radioButton1.Checked)
                    rptdoc.Load(Application.StartupPath + "\\Report\\门诊收费员个人交款发票统计.rpt");
                else
                    rptdoc.Load(Application.StartupPath + "\\Report\\住院收费员个人交款发票统计.rpt");
            }
            //for (int i = 0; i < pa.Length; i++)
            //{
            //    rptdoc.SetParameterValue(pa[i].Text, pa[i].Value.ToString());
            //}
            rptdoc.SetDataSource( (DataTable)dataTable);//.SetDataSource();
            // rptdoc.PrintOptions.PrinterName = prtdoc.PrinterSettings.PrinterName;

            // DataTable tb=ts_zyhs_fyxx.tabZfxm
            this.crystalReportViewer1.ReportSource = rptdoc;
        }

        private void txtqsh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((sender as TextBox).Text == "")
                    return;
                Int64 i=-1;
                Int64.TryParse((sender as TextBox).Text, out i);
                if (i <= 0)
                {
                    MessageBox.Show("请输入整数");
                }
            }
            catch { }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {

                    if (txtqsh.Text == "")
                        txtqsh.Text = "0";
                    txtjsh.Text = Convert.ToString(Int64.Parse(txtqsh.Text) + Int64.Parse(textBox3.Text) - 1);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                if ((sender as TextBox).Text == "")
                    return;
                if (txtqsh.Text == "")
                    txtqsh.Text = "0";
                txtjsh.Text = Convert.ToString(Int64.Parse(txtqsh.Text) + Int64.Parse(textBox3.Text)-1) ;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // this.crystalReportViewer1.PrintReport();
            ((ReportDocument)this.crystalReportViewer1.ReportSource).PrintToPrinter(1, false, 0, 0);
        }
    }
}