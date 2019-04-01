using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;
using TrasenFrame.Classes;

namespace ts_mz_tjbb
{
    public partial class FrmBaseReport_detail : Form
    {
        public FrmBaseReport_detail()
        {
            InitializeComponent();
        }

        public FrmBaseReport_detail(int htdwid,DateTime begin_date,DateTime end_date, string title,string reportFilename,string htdwmc)
        {
            InitializeComponent();
            this.htdwid = htdwid;
            this.begin_date = begin_date;
            this.end_date = end_date;

            this.Text = title;
            this.reportFilename = reportFilename;
            this.label1.Text = htdwmc;

            AddColunm();

            ConstructFun(reportFilename);

            
        }
        private int htdwid;
        private DateTime begin_date;
        private DateTime end_date;

        protected GridppReport report = new GridppReport();
        public FrmBaseReport_detail(int htdwid)
        {
            InitializeComponent();
            this.htdwid = htdwid;
        }

        private string reportFilename;
        private DataTable dt;

        protected string querySQL;
        [Description("设置相关存储过程字符串")]
        public string QuerySQL
        {
            set { querySQL = value; }
        }

        protected virtual void ConstructFun(string reportFilename)
        {
            report = new GridppReport();

            report.Initialize += new _IGridppReportEvents_InitializeEventHandler(Report_Initialize);
            report.LoadFromFile(Constant.ApplicationDirectory + "\\" + reportFilename);

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
            if (report.ParameterByName("beginDate") != null)
                report.ParameterByName("beginDate").AsString = begin_date.ToString("yyyy年MM月dd日");
            if (report.ParameterByName("endDate") != null)
                report.ParameterByName("endDate").AsString = end_date.ToString("yyyy年MM月dd日");
            if(report.ParameterByName("htdwmc") != null)
                report.ParameterByName("htdwmc").AsString = this.label1.Text.ToString();
        }

        /// <summary>
        /// 检索统计报表信息
        /// </summary>
        protected virtual void Retrieve()
        {
            dt = InstanceForm.BDatabase.GetDataTable(string.Format(querySQL, SetParams()));
            this.dgvResult.DataSource = dt;
        }

        protected virtual object[] SetParams()
        {
            object[] procedureParams = new object[3];

            
            procedureParams[0] = begin_date;
            procedureParams[1] = end_date;
            procedureParams[2] = this.htdwid;

            return procedureParams;
        }

        private void FrmBaseReport_detail_Load(object sender, EventArgs e)
        {
            Retrieve();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                report.PrintPreview(true);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dt != null)
                report.Print(true);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                report.ExportDirect(GRExportType.gretXLS, this.Text, true, true);
                report.UnprepareExport();
            }
        }

        protected virtual void AddColunm()
        {

            this.dgvResult.Columns.Add("日期", "日期");
            this.dgvResult.Columns["日期"].DataPropertyName = "日期";
            this.dgvResult.Columns["日期"].Width = 200;

            this.dgvResult.Columns.Add("姓名", "姓名");
            this.dgvResult.Columns["姓名"].DataPropertyName = "姓名";
            this.dgvResult.Columns["姓名"].Width = 100;

            this.dgvResult.Columns.Add("总费用", "总费用");
            this.dgvResult.Columns["总费用"].DataPropertyName = "总费用";
            this.dgvResult.Columns["总费用"].Width = 100;

            this.dgvResult.Columns.Add("欠费金额", "欠费金额");
            this.dgvResult.Columns["欠费金额"].DataPropertyName = "欠费金额";
            this.dgvResult.Columns["欠费金额"].Width = 100;

            this.dgvResult.Columns.Add("安全员", "安全员");
            this.dgvResult.Columns["安全员"].DataPropertyName = "安全员";
            this.dgvResult.Columns["安全员"].Width = 100;
        }
    }
}