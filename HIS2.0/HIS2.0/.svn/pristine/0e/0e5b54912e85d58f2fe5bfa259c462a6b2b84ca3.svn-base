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
using grproLib;
namespace ts_mz_tjbb
{
    public partial class Frmyjjyeqkb : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        protected GridppReport report = new GridppReport();

        public Frmyjjyeqkb(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.Text = _chineseName;


        }

        private DataTable dt;

        protected void ConstructFun()
        {
            report = new GridppReport();

            report.Initialize += new _IGridppReportEvents_InitializeEventHandler(Report_Initialize);
            report.LoadFromFile(Constant.ApplicationDirectory + "\\预交款余额情况表.grf");

            report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);

        }
        void report_FetchRecord()
        {
            FillFieldRecordToReport(report, dt);
        }
        public static void FillFieldRecordToReport(IGridppReport Report, DataTable dt)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];

            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dt.Columns.Count; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.Name, dt.Columns[i].ColumnName, true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }


            // 将 DataTable 中的每一条记录转储到 Grid++Report 的数据集中去
            foreach (DataRow dr in dt.Rows)
            {
                Report.DetailGrid.Recordset.Append();

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr[MatchFieldPairs[i].MatchColumnIndex];
                }

                Report.DetailGrid.Recordset.Post();
            }
        }
        private struct MatchFieldPairType
        {
            public IGRField grField;
            public int MatchColumnIndex;
        }

        private void Report_Initialize()
        {
            ReportInit();
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        protected virtual void ReportInit()
        {
            //开始日期
            if (report.ParameterByName("date") != null)
                report.ParameterByName("date").AsString = this.dtpdqsj.Value.ToString("yyyy年MM月dd日");
        }

        private string querySQL = "EXEC DBO.SP_MZSF_CX_BRXX_YEQK '{0}','{1}','{2}',{3},{4},{5},{6},{7}";

        protected virtual object[] SetParams()
        {
            object[] procedureParams = new object[8];

            procedureParams[0] = this.dtpdqsj.Value.Date.ToShortDateString()+" 23:59:59";//查询时间
            procedureParams[1] = this.txtjtdz.Text.ToString(); //家庭住址
            procedureParams[2] = this.txtgzdw.Text.ToString(); //工作单位
            procedureParams[3] = this.chkye.Checked ? 1: 0; //现卡余额
            procedureParams[4] = this.chkdj.Checked ? 1 : 0; //卡冻结
            procedureParams[5] = this.chkgs.Checked ? 1 : 0; //卡挂失
            procedureParams[6] = this.chkdqkye.Checked ? 1 : 0; //当前卡余额
            procedureParams[7] = this.chkbh.Checked ? 1 : 0;  //有消费或存入


            return procedureParams;
        }

        private void buttj_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = TrasenClasses.GeneralClasses.PubStaticFun.WaitCursor();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                dt = InstanceForm.BDatabase.GetDataTable(string.Format(querySQL, SetParams()));
                for (int n = 0; n < dt.Rows.Count;n++ )
                {
                    if (dt.Rows[n]["序号"].ToString() == "")
                    {
                        dt.Rows[n]["序号"] = n + 1;
                    }
                }
                this.dataGridView1.DataSource = dt;
                this.Cursor = Cursors.Default;
            }
        }

        private void Frmyjjjk_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dtpdqsj.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");

        }


        private void butprint_pos_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                ConstructFun();
                if (chkprint.Checked)
                    report.PrintPreview(true);
                else report.Print(true);
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                ConstructFun();
                report.ExportDirect(GRExportType.gretXLS, this.Text, true, true);
                report.UnprepareExport();
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                if (dgv.Cells["序号"].Value.ToString() == "合计")
                {
                    dgv.DefaultCellStyle.BackColor = Color.LightSeaGreen;
                }
            }
        }
    }
}