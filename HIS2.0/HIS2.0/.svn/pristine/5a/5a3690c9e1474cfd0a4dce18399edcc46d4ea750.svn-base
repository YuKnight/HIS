using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using Ts_zyys_public;
using TrasenFrame.Forms;


namespace ts_mz_tjbb
{
    public partial class 门诊预交金收支情况统计 : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        string[] title = new string[]{"序号,收预交金,收预交金,收预交金,退预交金,退预交金,退预交金,收支净额,财务记账",
                                      "序号,现金收款,POS收款,转帐收款,现金退款,POS退款,转帐退款,收支净额,财务记账"
                                    };
       
        public 门诊预交金收支情况统计()
        {
            InitializeComponent();
        }
        public 门诊预交金收支情况统计(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            //this.dataGridViewX1.PaintEnhancedSelection = true;
        }

        private void buttj_Click(object sender, EventArgs e)
        {
           
            ParameterEx[] parameters1 = new ParameterEx[4];

            parameters1[0].Text = "@SKY";
            parameters1[0].Value = Convert.ToInt32(Convertor.IsNull(comboBox1.SelectedValue, "0"));
            parameters1[1].Text = "@ksrq";
            parameters1[1].Value = dtpjsrq1.Value.ToString();

            parameters1[2].Text = "@JSRQ";
            parameters1[2].Value = dtpjsrq2.Value.ToString();

            parameters1[3].Text = "@err_text";
            parameters1[3].Value = "";
            parameters1[3].ParaDirection = ParameterDirection.Output;

            DataSet dset = new DataSet();
            TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_MZSF_TJ_YJJSZQK", parameters1, dset, "tj", 60);
            Fun.AddRowtNo(dset.Tables[0]);
            this.dataGridViewX1.DataSource = dset.Tables[0];
        }

        private void 门诊预交金收支情况统计_Load(object sender, EventArgs e)
        {
            dataGridViewX1.ColumnDeep = 2;
            this.dataGridViewX1.AutoGenerateColumns = false;
            dtpjsrq1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
            dtpjsrq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
            FunAddComboBox.AddOperator(true, comboBox1, InstanceForm.BDatabase);
           
        }

        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
            
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                string swhere = "";

                swhere = "日期从:" + dtpjsrq1.Value.ToString() + " 到:" + dtpjsrq2.Value.ToString();

                ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridViewX1, Constant.HospitalName + "门诊预交金收支情况统计", swhere, true, true, false, false);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 门诊预交金收支情况统计_Resize(object sender, EventArgs e)
        {
            this.dataGridViewX1.Refresh();
        }

        private void butprint_pos_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridViewX1.DataSource;
            DataSetjk.yjjszqkDataTable tbyjj = new DataSetjk.yjjszqkDataTable();
            DataRow dr;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                dr = tbyjj.NewRow();
                for (int j = 1; j < tb.Columns.Count; j++)
                {
                    if (tb.Columns[j].ColumnName == "财务记帐")
                        tb.Columns[j].ColumnName = "财务记账";
                    dr[tb.Columns[j].ColumnName] = tb.Rows[i][tb.Columns[j].ColumnName];
                }

                tbyjj.Rows.Add(dr);
            }
            ParameterEx[] parameters = new ParameterEx[2];

            parameters[0].Text = "医院名称";
            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;
            parameters[1].Text = "统计日期";
            parameters[1].Value = "日期从:" + dtpjsrq1.Value.ToString() + " 到:" + dtpjsrq2.Value.ToString();


            TrasenFrame.Forms.FrmReportView f;
            f = new FrmReportView(tbyjj, Constant.ApplicationDirectory + "\\Report\\门诊预交金收支情况表.rpt", parameters);

            if (f.LoadReportSuccess)
            {
                f.Show();
            }
            else
            {
                f.Dispose();
            }
        }
    }
}