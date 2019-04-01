using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using ts_mz_class;

namespace ts_mz_tjbb
{
    public partial class FrmBaseDateGrid : Form
    {
        protected GridppReport report = new GridppReport();

        private DataTable Tbys;//医生数据

        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        private string reportFilename;
        private DataTable dt;

        /// <summary>
        /// 设置相关存储过程字符串
        /// </summary>
        protected string querySQL;
        [Description("设置相关存储过程字符串")]
        public string QuerySQL
        {
            set { querySQL = value; }
        }

        public FrmBaseDateGrid()
        {
            InitializeComponent();
        }

        public FrmBaseDateGrid(MenuTag menuTag, string chineseName, Form mdiParent, string reportFilename)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.reportFilename = reportFilename;
        }

        private void txtYs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar == 8)
            {
                txtYs.Tag = "0";
                txtYs.Text = "";
                return;
            }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new TrasenFrame.Forms.FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
                f.WorkForm = this;
                f.srcControl = txtYs;
                f.Font = txtYs.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtYs.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtYs.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    txtYs.Text = f.SelectDataRow["name"].ToString().Trim();
                    txtYs.Focus();
                    e.Handled = true;
                }

            }
            else
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        protected virtual void ConstructFun(string reportFilename)
        {
            report = new GridppReport();
            //InitBtnImage();
            //初始化时参数赋值
            report.Initialize += new _IGridppReportEvents_InitializeEventHandler(Report_Initialize);
            report.LoadFromFile(Constant.ApplicationDirectory + "\\" + reportFilename);

            report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);

            //this.axReport.Report = report;

        }

        void report_FetchRecord()
        {
            FillFieldRecordToReport(report, dt);
        }

        protected virtual object[] SetParams()
        {
            object[] procedureParams = new object[3];

            procedureParams[0] = this.dtpBegin.Value.Date;
            procedureParams[1] = this.dtpEnd.Value.Date;
            if (txtYs.Tag != null && txtYs.Tag.ToString() != "0")
                procedureParams[2] = txtYs.Tag.ToString();
            else
                procedureParams[2] = "";

            return procedureParams;
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

        private void btnRetrieve_Click(object sender, EventArgs e)
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

        protected virtual void Export()
        {
            if (dt != null)
            {
                ConstructFun(reportFilename);
                report.ExportDirect(GRExportType.gretXLS, this.Text, true, true);
                report.UnprepareExport();
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        protected virtual void Print()
        {
            if (dt != null)
            {
                ConstructFun(reportFilename);
                report.Print(true);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private void FrmBaseDateGrid_Load(object sender, EventArgs e)
        {
            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
        }

        private void txtYs_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Text.Trim() == "") control.Tag = "";
        }
    }
}