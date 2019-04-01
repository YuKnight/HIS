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
using System.IO;
using System.Net;

namespace ts_mz_tjbb
{
    public partial class FrmICBCRec : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        public FrmICBCRec()
        {
            InitializeComponent();
        }

        public FrmICBCRec(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;

           // ProcessTXT();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 统计
        /// </summary>
        private void StatData()
        {
            try
            {
                //统计
                ParameterEx[] parameter = new ParameterEx[2];
                parameter[0].Text = "@StratTime";
                parameter[0].Value = StartTime.Value.ToString();
                parameter[1].Text = "@EndTime";
                parameter[1].Value = EndTime.Value.ToString();

                DataSet ds = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_ZZ_ICBC_TJ", parameter, ds, "dztj", 30);
                Fun.AddRowtNo(ds.Tables[0]);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void PrintData()
        {
            try
            {

                DataTable tb = (DataTable)dataGridView1.DataSource;
                ts_mz_report.DataSet1 dset = new ts_mz_report.DataSet1();
                DataRow dr;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    dr = dset.工商银行自助机对账统计.NewRow();
                    int x = i + 1;
                    dr["序号"] = Convert.ToString(tb.Rows[i]["序号"]);
                    dr["类型"] = Convert.ToString(tb.Rows[i]["类型"]);
                    dr["交易总金额"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["交易总金额"], "0"));
                    dr["交易笔数"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["交易笔数"], "0"));
                    dset.工商银行自助机对账统计.Rows.Add(dr);
                }

                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "医院名称";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                parameters[1].Text = "填报日期";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

                parameters[2].Text = "备注";
                parameters[2].Value = "统计日期:" + StartTime.Value.ToString() + " 到 " + EndTime.Value.ToString();

                parameters[3].Text = "统计人";
                parameters[3].Value = InstanceForm.BCurrentUser.Name;

                
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(dset, Constant.ApplicationDirectory + "\\Report\\MZ_工商银行自助机对账统计.rpt", parameters);

                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 导出execl
        /// </summary>
        private void ExcelData()
        {
          string swhere = "";

          swhere = "对账日期从:" + StartTime.Value.ToString() + " 到:" + EndTime.Value.ToString();

          ts_jc_log.ExcelOper.ExportData_ForDataTable(dataGridView1, Constant.HospitalName + label3.Text, swhere, true, true, false, false);

        }

        private void butprint_pos_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            PrintData();
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            StatData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if(dataGridView1.Rows.Count == 0)
                    return;

                string st = StartTime.Value.ToString();
                string et = EndTime.Value.ToString();

                //Guid tjid = new Guid(dataGridView1.Rows[1].Cells[4].Value.ToString());
                Guid tjid = Guid.Empty;

                FrmICBCRecMx frm = new FrmICBCRecMx(this._menuTag, this._chineseName, this._mdiParent);
                frm.MdiParent = this._mdiParent;
                frm.Show();

                frm.ICBCMXTJ(st, et, tjid);

            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dataGridView1.DataSource == null )
                return;
            ExcelData();
        }

        private void FrmICBCRec_Load(object sender, EventArgs e)
        {
            SystemCfg cfg1054 = new SystemCfg(1054);
            string[] s = cfg1054.Config.ToString().Split(',');
            if (s.Length == 2)
            {
                StartTime.Value = Convert.ToDateTime(StartTime.Value.AddDays(-1).ToShortDateString() + " " + s[0]);
                EndTime.Value = Convert.ToDateTime(EndTime.Value.ToShortDateString() + " " + s[1]);
            }
        }
    }
}