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
    public partial class FrmBaseReport : Form
    {
        public FrmBaseReport()
        {
            InitializeComponent();
        }

        protected GridppReport report = new GridppReport();
        private Form _mdiParent;
        public MenuTag _menuTag;
        private string _chineseName;

        private string reportFilename;
        protected DataTable dt;

        protected string querySQL;
        [Description("设置相关存储过程字符串")]
        public string QuerySQL
        {
            set { querySQL = value; }
        }

        public FrmBaseReport(MenuTag menuTag, string chineseName, Form mdiParent, string reportFilename)
        {
            InitializeComponent();
            InitForm(menuTag, chineseName, mdiParent, reportFilename);            
        }

        protected virtual void InitForm(MenuTag menuTag, string chineseName, Form mdiParent, string reportFilename)
        {
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.reportFilename = reportFilename;

            title.Text = _chineseName;

            title.TextAlign = ContentAlignment.MiddleCenter;
            //Add by HXY 20140826 设置开始时间和结束时间为当前天的前一天
            dtpBegin.Value = dtpBegin.Value.AddDays(-1);
            dtpEnd.Value = dtpEnd.Value.AddDays(-1);
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
                report.ParameterByName("beginDate").AsString = this.dtpBegin.Value.ToString("yyyy年MM月dd日");
            if (report.ParameterByName("endDate") != null)
                report.ParameterByName("endDate").AsString = this.dtpEnd.Value.ToString("yyyy年MM月dd日");
        }

        /// <summary>
        /// 检索统计报表信息
        /// </summary>
        protected virtual void Retrieve()
        {
            dt = InstanceForm.BDatabase.GetDataTable(string.Format(querySQL, SetParams()));
            this.dgvResult.DataSource = dt;
        }

        protected virtual void Preview()
        {
            if (dt != null)
            {
                ConstructFun(reportFilename);
                report.PrintPreview(true);
            }
        }

        protected virtual void Export()
        {
            if (dt != null)
            {
                ConstructFun(reportFilename);
                report.ExportDirect(GRExportType.gretXLS, this.Text, true, true);
                report.UnprepareExport();
            }
        }

        protected virtual void Print()
        {
            if (dt != null)
            {
                ConstructFun(reportFilename);
                report.Print(true);
            }
        }

        protected virtual object[] SetParams()
        {
            object[] procedureParams = new object[2];

            procedureParams[0] = this.dtpBegin.Value.Date;
            procedureParams[1] = this.dtpEnd.Value.Date;

            return procedureParams;
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
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
                Retrieve();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private void FrmBaseReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            AddColunm();
        }

        private void dgvResult_DoubleClick(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow == null) return;
            int crow = dgvResult.CurrentRow.Index;
            showDetail(crow);
        }

        protected virtual void showDetail(int crow)
        {
            switch (_menuTag.Function_Name)
            {
                case "Fun_MZ_HTDW_QFHZB":
                    {
                        int htdwid = Convert.ToInt32(dgvResult.Rows[crow].Cells["HTDWID"].Value.ToString());
                        string htdwmc = dgvResult.Rows[crow].Cells["类型"].Value.ToString();

                        FrmBaseReport_detail frmDetail = new FrmBaseReport_detail(htdwid, this.dtpBegin.Value.Date, this.dtpEnd.Value.Date, "门诊病人未结算欠费明细", "门诊病人未结算欠费明细表.grf", htdwmc);
                        frmDetail.QuerySQL = "execute dbo.SP_MZ_HTDW_QFHZB_MX '{0}','{1}',{2}";

                        frmDetail.ShowDialog();
                        break;
                    }
            }

        }

        protected virtual void AddColunm()
        {
            switch (_menuTag.Function_Name)
            {
                case "Fun_MZ_HTDW_QFHZB":
                    {
                        this.dgvResult.Columns.Add("HTDWID", "HTDWID");
                        this.dgvResult.Columns["HTDWID"].DataPropertyName = "HTDWID";
                        this.dgvResult.Columns["HTDWID"].Visible = false;

                        this.dgvResult.Columns.Add("类型", "类型");
                        this.dgvResult.Columns["类型"].DataPropertyName = "类型";
                        this.dgvResult.Columns["类型"].Width = 200;

                        this.dgvResult.Columns.Add("人数", "人数");
                        this.dgvResult.Columns["人数"].DataPropertyName = "人数";
                        this.dgvResult.Columns["人数"].Width = 100;

                        this.dgvResult.Columns.Add("总费用", "总费用");
                        this.dgvResult.Columns["总费用"].DataPropertyName = "总费用";
                        this.dgvResult.Columns["总费用"].Width = 100;

                        this.dgvResult.Columns.Add("欠费额", "欠费额");
                        this.dgvResult.Columns["欠费额"].DataPropertyName = "欠费额";
                        this.dgvResult.Columns["欠费额"].Width = 100;
                        break;
                    }
                case "Fun_MZ_HTDW_WJSHZB":
                    {

                        this.dgvResult.Columns.Add("合同单位", "合同单位");
                        this.dgvResult.Columns["合同单位"].DataPropertyName = "合同单位";
                        this.dgvResult.Columns["合同单位"].Width = 200;

                        this.dgvResult.Columns.Add("期初余额", "期初余额");
                        this.dgvResult.Columns["期初余额"].DataPropertyName = "期初余额";
                        this.dgvResult.Columns["期初余额"].Width = 120;

                        this.dgvResult.Columns.Add("本期增加额", "本期增加额");
                        this.dgvResult.Columns["本期增加额"].DataPropertyName = "本期增加额";
                        this.dgvResult.Columns["本期增加额"].Width = 120;

                        this.dgvResult.Columns.Add("本期减少额", "本期减少额");
                        this.dgvResult.Columns["本期减少额"].DataPropertyName = "本期减少额";
                        this.dgvResult.Columns["本期减少额"].Width = 120;

                        this.dgvResult.Columns.Add("本期余额", "本期余额");
                        this.dgvResult.Columns["本期余额"].DataPropertyName = "本期余额";
                        this.dgvResult.Columns["本期余额"].Width = 120;
                        break;
                    }
                case "Fun_MZSF_GH_CF_LIST":
                    {

                        this.dgvResult.Columns.Add("门诊号", "门诊号");
                        this.dgvResult.Columns["门诊号"].DataPropertyName = "门诊号";
                        this.dgvResult.Columns["门诊号"].Width = 150;

                        this.dgvResult.Columns.Add("姓名", "姓名");
                        this.dgvResult.Columns["姓名"].DataPropertyName = "姓名";
                        this.dgvResult.Columns["姓名"].Width = 100;

                        this.dgvResult.Columns.Add("实收金额", "实收金额");
                        this.dgvResult.Columns["实收金额"].DataPropertyName = "实收金额";
                        this.dgvResult.Columns["实收金额"].Width = 100;

                        this.dgvResult.Columns.Add("现金支付", "现金支付");
                        this.dgvResult.Columns["现金支付"].DataPropertyName = "现金支付";
                        this.dgvResult.Columns["现金支付"].Width = 100;

                        this.dgvResult.Columns.Add("刷卡额", "刷卡额");
                        this.dgvResult.Columns["刷卡额"].DataPropertyName = "刷卡额";
                        this.dgvResult.Columns["刷卡额"].Width = 80;

                        this.dgvResult.Columns.Add("医保补", "医保补");
                        this.dgvResult.Columns["医保补"].DataPropertyName = "医保补";
                        this.dgvResult.Columns["医保补"].Width = 80;

                        this.dgvResult.Columns.Add("记账额", "记账额");
                        this.dgvResult.Columns["记账额"].DataPropertyName = "记账额";
                        this.dgvResult.Columns["记账额"].Width = 80;

                        this.dgvResult.Columns.Add("收费日期", "收费日期");
                        this.dgvResult.Columns["收费日期"].DataPropertyName = "收费日期";
                        this.dgvResult.Columns["收费日期"].Width = 120;

                        this.dgvResult.Columns.Add("收费员", "收费员");
                        this.dgvResult.Columns["收费员"].DataPropertyName = "收费员";
                        this.dgvResult.Columns["收费员"].Width = 80;

                        this.dgvResult.Columns.Add("挂号科室", "挂号科室");
                        this.dgvResult.Columns["挂号科室"].DataPropertyName = "挂号科室";
                        this.dgvResult.Columns["挂号科室"].Width = 100;

                        this.dgvResult.Columns.Add("挂号级别", "挂号级别");
                        this.dgvResult.Columns["挂号级别"].DataPropertyName = "挂号级别";
                        this.dgvResult.Columns["挂号级别"].Width = 100;

                        this.dgvResult.Columns.Add("盘点号", "盘点号");
                        this.dgvResult.Columns["盘点号"].DataPropertyName = "盘点号";
                        this.dgvResult.Columns["盘点号"].Width = 100;
                        break;
                    }
                case "Fun_MZSF_HTDWHK_LIST":
                    this.dgvResult.Columns.Add("记账单位", "记账单位");
                    this.dgvResult.Columns["记账单位"].DataPropertyName = "记账单位";
                    this.dgvResult.Columns["记账单位"].Width = 200;

                    this.dgvResult.Columns.Add("姓名", "姓名");
                    this.dgvResult.Columns["姓名"].DataPropertyName = "姓名";
                    this.dgvResult.Columns["姓名"].Width = 100;

                    this.dgvResult.Columns.Add("收费日期", "收费日期");
                    this.dgvResult.Columns["收费日期"].DataPropertyName = "收费日期";
                    this.dgvResult.Columns["收费日期"].Width = 150;

                    this.dgvResult.Columns.Add("金额", "金额");
                    this.dgvResult.Columns["金额"].DataPropertyName = "金额";
                    this.dgvResult.Columns["金额"].Width = 100;

                    this.dgvResult.Columns.Add("收费员", "收费员");
                    this.dgvResult.Columns["收费员"].DataPropertyName = "收费员";
                    this.dgvResult.Columns["收费员"].Width = 80;

                    this.dgvResult.Columns.Add("盘点号", "盘点号");
                    this.dgvResult.Columns["盘点号"].DataPropertyName = "盘点号";
                    this.dgvResult.Columns["盘点号"].Width = 80;

                    this.dgvResult.Columns.Add("发票号", "发票号");
                    this.dgvResult.Columns["发票号"].DataPropertyName = "发票号";
                    this.dgvResult.Columns["发票号"].Width = 80;

                    this.dgvResult.Columns.Add("电脑流水号", "电脑流水号");
                    this.dgvResult.Columns["电脑流水号"].DataPropertyName = "电脑流水号";
                    this.dgvResult.Columns["电脑流水号"].Width = 150;
                    break;
                case "Fun_MZSF_HTDWMX":
                case "Fun_MZSF_HTDWMX_WJS":
                    if (dt == null) dt = InstanceForm.BDatabase.GetDataTable(string.Format(querySQL, SetParams()));
                    foreach (DataColumn Col in dt.Columns)
                    {
                        string name = Col.ColumnName;
                        this.dgvResult.Columns.Add(name,name);
                        this.dgvResult.Columns[name].DataPropertyName = name;
                        this.dgvResult.Columns[name].Width = 100;
                    }
                    break;
                case "Fun_mz_zy_zzb":
                    {
                        this.dgvResult.Columns.Add("日期", "日期");
                        this.dgvResult.Columns["日期"].DataPropertyName = "日期";
                        this.dgvResult.Columns["日期"].Width = 100;

                        this.dgvResult.Columns.Add("住院总费用", "住院总费用");
                        this.dgvResult.Columns["住院总费用"].DataPropertyName = "住院总费用";
                        this.dgvResult.Columns["住院总费用"].Width = 200;

                        this.dgvResult.Columns.Add("在院人次", "在院人次");
                        this.dgvResult.Columns["在院人次"].DataPropertyName = "在院人次";
                        this.dgvResult.Columns["在院人次"].Width = 150;

                        this.dgvResult.Columns.Add("门诊总费用", "门诊总费用");
                        this.dgvResult.Columns["门诊总费用"].DataPropertyName = "门诊总费用";
                        this.dgvResult.Columns["门诊总费用"].Width = 200;

                        this.dgvResult.Columns.Add("门诊挂号人次", "门诊挂号人次");
                        this.dgvResult.Columns["门诊挂号人次"].DataPropertyName = "门诊挂号人次";
                        this.dgvResult.Columns["门诊挂号人次"].Width = 250;
                        break;
                    }
            }
        }

    }
}