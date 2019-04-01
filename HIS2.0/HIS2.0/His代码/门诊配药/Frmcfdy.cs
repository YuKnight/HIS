using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using YpClass;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using ts_mz_class;
//using ts_yf_mzfy; 

namespace ts_yf_mzpy
{
    public partial class Frmcfdy : Form
    {
        public Frmcfdy()
        {
            InitializeComponent();         
        }
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        DataTable cfmxTable = null;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cryRepViw;
        private ToolBar tbMain;
        /// <summary>
        /// 该字符串用于点击打印后执行
        /// </summary>
        /// <remarks>Add By Tany 2010-09-25 增加一个SQLSTR用于点击打印后执行该语句</remarks>
        private string[] printReportInfo;
        /// <summary>
        /// 是否在点击打印后成功执行该字符串
        /// </summary>
        private bool isExecSuccess = false;
        public Frmcfdy(MenuTag menuTag, string chineseName, Form mdiParent)
            : this()
        {
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
        }

        private DataTable DoQuery(string kh, string fph)
        {
            string sql = string.Format(@"     select
             a.FPH 发票号,b.BRXM 姓名,b.CSRQ as 出生日期,b.XB,a.brxxid,   
             case when b.XB =1 then '男' else case when  b.xb = 2 then '女' else '' end end 性别,
             a.PYCK 配药窗口,a.FYCK 发药窗口,a.CFID 处方ID,a.BLH 门诊号,a.XMLY 项目来源,a.BSCBZ 删除标志,c.KH 病人卡号,a.PYR 配药人, 
             case when a.dybz =1 then '已打印' else '未打印' end 打印标志  
             from mz_cfb a
             left join yy_brxx b on a.BRXXID = b.BRXXID
             left join yy_kdjb c on a.BRXXID = c.BRXXID and c.klx = {1} 
             where 1=1 and a.ZXKS = {0} and (a.BSCBZ = 0 or a.BSCBZ is null) ", InstanceForm.BCurrentDept.DeptId, cmbklx.SelectedValue != null ? cmbklx.SelectedValue.ToString() : "");
            if (!cbyfyjs.Checked)
                sql += " and (a.BFYBZ = 0 or a.BFYBZ is null)";
            else
                sql += " and a.BFYBZ = 1 ";
            if (cbglydy.Checked)
                sql += " and (a.dybz = 0 or a.dybz is null)";
            //else
            //    sql += " and a.dybz = 1 ";

            sql += string.Format(" and a.sfrq>='{0} 00:00:00' and a.sfrq<='{0} 23:59:59'", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            if (!string.IsNullOrEmpty(kh))
            {
                sql += string.Format(" and c.KH = '{0}'", kh);
            }
            if (!string.IsNullOrEmpty(fph))
            {
                sql += string.Format(" and  a.FPH = '{0}'", fph);
            }
            return InstanceForm.BDatabase.GetDataTable(sql);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataTable tb = DoQuery(null, null);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = tb;
        }

        bool selectParam = true;
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells["checkbox"].Value = selectParam ? 1 : 0;
            }
            selectParam = !selectParam;
        }

        private void btnCancelSelect_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                }
            }
        }

        private void btnBatchPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.EndEdit();
                List<DataRow> list = new List<DataRow>();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    object obj = dataGridView1.Rows[i].Cells["checkbox"].Value;
                    if (obj != null && obj.ToString().Trim() == "1" )
                    {
                        DataRow dataRow = (dataGridView1.Rows[i].DataBoundItem as DataRowView).Row;
                        list.Add(dataRow);
                    }
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("请勾选需要打印的单据!","提示");
                    return;
                }
                isPreview = false;
                this.tabControl1.TabPages.Clear();
                foreach (DataRow row in list)
                {
                    DataPrint(row);
                }               
            }
        }

        bool isPreview = false;
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.EndEdit();
                List<DataRow> list = new List<DataRow>();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    object obj = dataGridView1.Rows[i].Cells["checkbox"].Value;
                    if (obj != null && obj.ToString().Trim() == "1")
                    {
                        DataRow dataRow = (dataGridView1.Rows[i].DataBoundItem as DataRowView).Row;
                        list.Add(dataRow);
                    }
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("请勾选需要预览的单据!", "提示");
                    return;
                }
                isPreview = true;
                this.tabControl1.TabPages.Clear();
                foreach (DataRow row in list)
                {
                    DataPrint(row);
                }
            }
        }

        private void btnfycksz_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxfph_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && tbxfph.Text.Trim() != string.Empty)
            {                
                DataTable tb = DoQuery(null, tbxfph.Text.Trim());
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = tb;
                if (dataGridView1.RowCount > 0)
                {
                    dataGridView1.EndEdit();
                    List<DataRow> list = new List<DataRow>();
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Cells["checkbox"].Value = selectParam ? 1 : 0;
                        DataRow dataRow = (dataGridView1.Rows[i].DataBoundItem as DataRowView).Row;
                        list.Add(dataRow);
                        //object obj = dataGridView1.Rows[i].Cells["checkbox"].Value;
                        //if (obj != null && obj.ToString().Trim() == "1")
                        //{
                        //    DataRow dataRow = (dataGridView1.Rows[i].DataBoundItem as DataRowView).Row;
                        //    list.Add(dataRow);
                        //}
                    }
                    if (list.Count == 0)
                    {
                        //MessageBox.Show("请勾选需要打印的单据!", "提示");
                        return;
                    }
                    isPreview = false;
                    this.tabControl1.TabPages.Clear();
                    foreach (DataRow row in list)
                    {
                        DataPrint(row);
                    }
                }
            }
        }

        private void tbxbr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && tbxbr.Text.Trim() != string.Empty)
            {              
                DataTable tb = DoQuery(tbxbr.Text.Trim(), null);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = tb;

                if (dataGridView1.RowCount > 0)
                {
                    dataGridView1.EndEdit();
                    List<DataRow> list = new List<DataRow>();
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Cells["checkbox"].Value = selectParam ? 1 : 0;
                        DataRow dataRow = (dataGridView1.Rows[i].DataBoundItem as DataRowView).Row;
                        list.Add(dataRow);
                        //object obj = dataGridView1.Rows[i].Cells["checkbox"].Value;
                        //if (obj != null && obj.ToString().Trim() == "1")
                        //{
                        //    DataRow dataRow = (dataGridView1.Rows[i].DataBoundItem as DataRowView).Row;
                        //    list.Add(dataRow);
                        //}
                    }
                    if (list.Count == 0)
                    {
                        //MessageBox.Show("请勾选需要打印的单据!", "提示");
                        return;
                    }
                    isPreview = false;
                    this.tabControl1.TabPages.Clear();
                    foreach (DataRow row in list)
                    {
                        DataPrint(row);
                    }
                }
            }
        }

        private void Frmcfdy_Load(object sender, EventArgs e)
        {
            try
            {
                this.tbxbr.Focus();
                cfmxTable = this.CreateDataSouce();
                FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
                cbglydy.Checked = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString(), "提示");
            }
        }
      
        private void initReportTemp(TrasenFrame.Forms.UcReportView reportView)
        {
            cryRepViw = reportView.CryRepViw_Uc;
            tbMain = reportView.tbMain_Uc;
            if (printReportInfo != null && printReportInfo.Length > 0)
                reportView.sqlStr_Uc = printReportInfo;
            reportView.IsExecSuccessChanged += new EventHandler(ucReportView1_IsExecSuccessChanged);
            User CurrentUser = null;
            if (FrmMdiMain.CurrentUser == null)
            {
                CurrentUser = new User();
            }
            else
            {
                CurrentUser = FrmMdiMain.CurrentUser;
            }
            if (CurrentUser.IsAdministrator || new SystemCfg(21).Config == "0")
            {
                cryRepViw.ShowCloseButton = true;
                cryRepViw.ShowExportButton = true;
                cryRepViw.ShowRefreshButton = true;
                cryRepViw.ShowGroupTreeButton = true;
            }
        }

        private bool initReportData(TrasenFrame.Forms.UcReportView reportView, object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter)
        {
            return reportView.Init(reportDataSource, reportFilePath, parameters, toPrinter);
        }

        private void ucReportView1_IsExecSuccessChanged(object sender, EventArgs e)
        {
            if (sender is TrasenFrame.Forms.UcReportView)
                this.isExecSuccess = (sender as TrasenFrame.Forms.UcReportView).isExecSuccess_Uc;
        }

        private bool IsVisable(string columnName, bool defaultVisable)
        {
            string strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("门诊处方发药网格列", columnName, Application.StartupPath + "\\ClientWindow.ini");
            if (string.IsNullOrEmpty(strVal))
                TrasenClasses.GeneralClasses.ApiFunction.WriteIniString("门诊处方发药网格列", columnName, defaultVisable ? "1" : "0", Application.StartupPath + "\\ClientWindow.ini");
            strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("门诊处方发药网格列", columnName, Application.StartupPath + "\\ClientWindow.ini");
            return strVal == "1" ? true : false;
        }

        private DataTable CreateDataSouce()
        {
            List<ColumnDefine> columns = new List<ColumnDefine>();
            #region 列定义
            columns.Add(ColumnDefine.NewColumnDefine("序号", "序号", 40, true, 1));
            columns.Add(ColumnDefine.NewColumnDefine("警示灯", "警示灯", 30, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("发药", "发药", 30, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("皮试", "皮试", 30, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("项目", "项目", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("总金额", "总金额", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("姓名", "姓名", 60, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("商品名", "商品名", (IsVisable("商品名", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("品名", "品名", (IsVisable("品名", true) ? 150 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("规格", "规格", (IsVisable("规格", true) ? 110 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("单位", "单位", (IsVisable("单位", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("用量", "用量", (IsVisable("用量", true) ? 40 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("剂数", "剂数", (IsVisable("剂数", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("用法", "用法", (IsVisable("用法", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("频次", "频次", (IsVisable("频次", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("单价", "单价", (IsVisable("单价", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("金额", "金额", (IsVisable("金额", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("库存", "库存", (IsVisable("库存", true) ? 65 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("医生", "医生", (IsVisable("医生", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("科室", "科室", (IsVisable("科室", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("发票号", "发票号", (IsVisable("发票号", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("门诊号", "门诊号", (IsVisable("门诊号", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("性别", "性别", (IsVisable("性别", true) ? 40 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("年龄", "年龄", (IsVisable("年龄", true) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("剂型", "剂型", (IsVisable("剂型", false) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("厂家", "厂家", (IsVisable("厂家", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("诊断", "诊断", (IsVisable("诊断", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("煎药", "煎药", (IsVisable("煎药", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("剂量", "剂量", (IsVisable("剂量", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("剂量单位", "剂量单位", (IsVisable("剂量单位", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("天数", "天数", (IsVisable("天数", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("组标志", "组标志", (IsVisable("组标志", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("排序序号", "排序序号", (IsVisable("排序序号", false) ? 30 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("录入员", "录入员", (IsVisable("录入员", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("录入日期", "录入日期", (IsVisable("录入日期", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("收费日期", "收费日期", (IsVisable("收费日期", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("记费员", "记费员", (IsVisable("记费员", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("发药日期", "发药日期", (IsVisable("发药日期", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("发药员", "发药员", (IsVisable("发药员", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("配药员", "配药员", (IsVisable("配药员", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("处方号", "处方号", (IsVisable("处方号", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("CFLX", "CFLX", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("JSSJH", "JSSJH", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("CFXH", "CFXH", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("PATID", "PATID", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("YSDM", "YSDM", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("KSDM", "KSDM", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("sfczy", "sfczy", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("qrczyh", "qrczyh", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("pyczyh", "pyczyh", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("配药窗口", "配药窗口", (IsVisable("配药窗口", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("发药窗口", "发药窗口", (IsVisable("发药窗口", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("记帐金额", "记帐金额", (IsVisable("记帐金额", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("优惠金额", "优惠金额", (IsVisable("优惠金额", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("自付金额", "自付金额", (IsVisable("自付金额", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("YPID", "YPID", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("YDWBL", "YDWBL", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("cfmxid", "cfmxid", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("嘱托", "嘱托", (IsVisable("嘱托", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("批发价", "批发价", (IsVisable("批发价", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("批发金额", "批发金额", (IsVisable("批发金额", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("使用频次", "使用频次", (IsVisable("使用频次", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("货号", "货号", (IsVisable("货号", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("单位规格", "单位规格", (IsVisable("单位规格", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("zsyp", "zsyp", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("fpid", "fpid", (IsVisable("fpid", true) ? 80 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("发票流水号", "发票流水号", (IsVisable("发票流水号", false) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("中药备注", "中药备注", (IsVisable("中药备注", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("备注2", "备注2", (IsVisable("备注2", true) ? 150 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("备注3", "备注3", (IsVisable("备注3", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("tyid", "tyid", (IsVisable("tyid", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("批号", "批号", (IsVisable("批号", false) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("效期", "效期", (IsVisable("效期", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("批次号", "批次号", (IsVisable("批次号", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("ypsl", "ypsl", (IsVisable("ypsl", true) ? 95 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("hwmc", "hwmc", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("byscf", "byscf", 0, true, 0));
            #endregion
            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbmx";
            SystemCfg cfg8032 = new SystemCfg(8032);
           
            int j = 0;
            foreach (ColumnDefine define in columns)
            {
                if (define.ColBoolButton == 0)
                {
                    DataColumn datacol;
                    if (define.MappingName.Trim() == "ypsl" || define.MappingName == "金额")
                        datacol = new DataColumn(define.MappingName, Type.GetType("System.Decimal"));
                    else
                        datacol = new DataColumn(define.MappingName);
                    dtTmp.Columns.Add(datacol);
                }
                else
                {
                    DataColumn datacol;
                    datacol = new DataColumn(define.MappingName);
                    dtTmp.Columns.Add(datacol);
                }
                j++;
            }
            return dtTmp;
        }      

        private void DataPrint(DataRow row)
        {
            if (row == null)
                return;
            //int bk = this.rdodq.Checked == true ? 0 : 1;
            int fybz = cbyfyjs.Checked == false ? 0 : 1;
            string sfrq1 = "";
            string sfrq2 = "";
            string fyrq1 = "";
            string fyrq2 = "";
            string brxxid = row["brxxid"].ToString();
            string fph = row["发票号"].ToString();

            sfrq1 = dateTimePicker1.Value.ToShortDateString();
            sfrq2 = dateTimePicker1.Value.ToShortDateString();
            fyrq1 = "";
            fyrq2 = "";

            //this.cfmxTable = MZYF.SelectMzcfk("Fun_ts_yf_mzfy", InstanceForm.BCurrentDept.DeptId, Guid.Empty, row["姓名"].ToString(),
            //fph, 0, fyrq1, fyrq2, 0, fybz, "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, new Guid(brxxid), 0, InstanceForm.BDatabase);
            //if (cfmxTable == null || cfmxTable.Rows.Count == 0)
            //    return;
            //DataTable datalist = this.cfmxTable.Copy();
            DataTable retTable = MZYF.SelectMzcfk("Fun_ts_yf_mzfy", InstanceForm.BCurrentDept.DeptId, Guid.Empty, row["姓名"].ToString(),
            fph, 0, fyrq1, fyrq2, 0, fybz, "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, new Guid(brxxid), 0, InstanceForm.BDatabase);
            this.cfmxTable = retTable.Clone();
            DataRow[] retRows = retTable.Select(string.Format(" cfxh = '{0}'", row["处方ID"]));
            if (retRows != null && retRows.Length > 0)
            {
                foreach (DataRow tmp in retRows)
                {
                    this.cfmxTable.Rows.Add(tmp.ItemArray);
                }
            }
            if (this.cfmxTable.Rows.Count == 0)
            {
                MessageBox.Show("未找到处方明细","提示");
                return;
            }
            DataTable datalist = this.cfmxTable.Copy();

            #region
            //this.AddPresc(dataSouce);       
            //YpConfig ypconfig = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
            ////分组处方
            //DataRow[] selrow;
            //if (ypconfig.门诊发药后才能打印处方 == true)
            //    selrow = tb.Select("( 发药='√') and ypid<>''");
            //else
            //    selrow = tb.Select("(发药='◆' or  发药='√') and ypid<>''");
            //DataTable tbsel = tb.Clone();
            //for (int w = 0; w <= selrow.Length - 1; w++)
            //    tbsel.ImportRow(selrow[w]);
            #endregion
            DataTable tbcf;
            if (cbyfyjs.Checked == false) //如果为未发药就取总金额，已发药则取求和值
            {
                string[] GroupbyField ={ "cfxh", "发票号", "总金额", "诊断", "门诊号" };
                string[] ComputeField ={ };
                string[] CField ={ };
                tbcf = FunBase.GroupbyDataTable(datalist, GroupbyField, ComputeField, CField, null);
            }
            else
            {
                string[] GroupbyField ={ "cfxh", "发票号", "诊断", "门诊号" };
                string[] ComputeField ={ "金额" };
                string[] CField ={ "sum" };
                tbcf = FunBase.GroupbyDataTable(datalist, GroupbyField, ComputeField, CField, null);
            }

            //SystemCfg cfg8035 = new SystemCfg(8035);
            //if (cfg8035.Config == "1")
            //{
            //处方           
            for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            {
                TrasenFrame.Forms.UcReportView urv = new UcReportView();
                this.PrintCf(tbcf.Rows[i], 1, urv);
            }
            //}
            //else
            //{
            //    //处方
            //    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            //    {
            //        this.PrintCf(tbcf.Rows[i], 1);
            //    }
            //}            
        }

        private void PrintCf(DataRow row, int cfgs, TrasenFrame.Forms.UcReportView reportView)
        {
            DataRow[] rows;
            if (cfgs == 1)
                rows = cfmxTable.Select(" cfxh='" + row["cfxh"] + "' ");
            else
                rows = cfmxTable.Select(" cfxh='" + row["cfxh"] + "' and zsyp=1 ");
            if (rows.Length == 0)
                return;

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;
            string jtdz = "";
            string grlxdh = "";
            string sfzh = "";
            string brxm = "";
            string ssql = "select * from yy_brxx a inner join mz_cfb b on a.brxxid=b.brxxid where b.cfid='" + row["cfxh"].ToString() + "'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                jtdz = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
                grlxdh = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
                sfzh = Convertor.IsNull(tb.Rows[0]["sfzh"], "");
                brxm = Convertor.IsNull(tb.Rows[0]["brxm"], "");
            }
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                #region  非中药处方格式
                myrow = Dset.病人处方清单.NewRow();
                myrow["xh"] = Convert.ToInt32(rows[i]["序号"]);
                myrow["ypmc"] = Convert.ToString(rows[i]["品名"]);
                myrow["ypgg"] = Convert.ToString(rows[i]["规格"]);
                myrow["sccj"] = Convert.ToString(rows[i]["厂家"]);
                myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["单价"], "0"));
                myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["用量"], "0")).ToString();
                myrow["ypdw"] = Convert.ToString(rows[i]["单位"]);
                myrow["cfts"] = rows[i]["剂数"].ToString();
                myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["金额"], "0"));
                myrow["yf"] = Convertor.IsNull(rows[i]["用法"], "");
                myrow["pc"] = Convertor.IsNull(rows[i]["使用频次"], "");
                myrow["syjl"] = "";
                myrow["zt"] = Convertor.IsNull(rows[i]["嘱托"], "");
                myrow["shh"] = Convert.ToString(rows[i]["货号"]);
                myrow["ksname"] = Convert.ToString(rows[i]["科室"]).Trim();
                myrow["ysname"] = Convert.ToString(rows[i]["医生"]).Trim();
                myrow["PSZT"] = rows[i]["皮试"].ToString();
                myrow["fph"] = Convert.ToString(rows[i]["发票号"]);
                myrow["hzxm"] = Convert.ToString(rows[i]["姓名"]);
                myrow["sex"] = Convert.ToString(rows[i]["性别"]);
                myrow["age"] = Convert.ToString(rows[i]["年龄"]);
                myrow["blh"] = Convert.ToString(rows[i]["门诊号"]);
                myrow["sfrq"] = Convert.ToString(rows[i]["收费日期"]);
                //myrow["pyr"] = rows[i]["配药人"];            
                myrow["fyr"] = Convert.ToString(rows[i]["发药员"]) == "" ? InstanceForm.BCurrentUser.Name : Convert.ToString(rows[i]["发药员"]);
                myrow["pyckdm"] = Convertor.IsNull(rows[i]["配药窗口"], "") == "" ? "" : Convertor.IsNull(rows[i]["配药窗口"], "");
                myrow["fyckdm"] = Convertor.IsNull(rows[i]["发药窗口"], ""); //Convertor.IsNull(rows[i]["发药窗口"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["发药窗口"], "");
                myrow["zdmc"] = Convertor.IsNull(rows[i]["诊断"], "");
                myrow["syff"] = Convert.ToString(rows[i]["用法"]);
                myrow["sypc"] = Convert.ToString(rows[i]["使用频次"]);
                myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["剂量"]));
                myrow["jldw"] = Convert.ToString(rows[i]["剂量单位"]);
                myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["天数"], "0")).ToString();
                myrow["jx"] = Convertor.IsNull(rows[i]["剂型"], "");

                if (rows[i]["组标志"].ToString() == "1")
                {
                    yzzh = yzzh + 1;
                }
                myrow["yzzh"] = yzzh;
                myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["排序序号"], "0"));
                myrow["syjl"] = Convertor.IsNull(rows[i]["单位规格"], "");
                myrow["sfrq"] = Convert.ToDateTime(rows[i]["收费日期"]).ToLongDateString();
                myrow["cfrq"] = Convert.ToDateTime(rows[i]["录入日期"]).ToLongDateString();
                //myrow["sfrq"] = PrintRq.ToLongDateString();
                //myrow["cfrq"] = PrintRq.ToLongDateString();
                //myrow["blh"] =PrintRq.Year.ToString()+"0"+PrintRq.Month.ToString()+PrintRq.Day.ToString()+ Convert.ToString(rows[i]["门诊号"]).Substring(8,Convert.ToString(rows[i]["门诊号"]).Length-8);
                myrow["fzbz"] = rows[i]["组标志"].ToString();

                myrow["JTDZ"] = jtdz;
                myrow["LXDH"] = grlxdh;
                myrow["SFZH"] = sfzh;
                myrow["bz1"] = Convertor.IsNull(rows[i]["中药备注"], "");
                myrow["bz2"] = Convertor.IsNull(rows[i]["备注2"], "");
                myrow["bz3"] = Convertor.IsNull(rows[i]["备注3"], "");
                myrow["dyr"] = InstanceForm.BCurrentUser.Name;
                myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                Dset.病人处方清单.Rows.Add(myrow);
                #endregion
            }
            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Text = "cfts";
            parameters[0].Value = rows[0]["剂数"].ToString();
            parameters[1].Text = "zje";
            parameters[1].Value = Convert.ToDecimal(Convertor.IsNull(rows[0]["总金额"], "0"));
            parameters[2].Text = "TITLETEXT";
            parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "";
            parameters[3].Text = "text1";
            parameters[3].Value = "发药单位:" + InstanceForm.BCurrentDept.DeptName + "    诊断:" + rows[0]["诊断"].ToString();

            parameters[4].Text = "xyf";
            if (Convert.ToString(rows[0]["cflx"]) != "03")
                parameters[4].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[4].Value = 0;
            parameters[5].Text = "zyf";
            if (Convert.ToString(rows[0]["cflx"]) == "03")
                parameters[5].Value = Convert.ToDecimal(rows[0]["总金额"]);
            else
                parameters[5].Value = 0;
            parameters[6].Text = "yfmc";
            parameters[6].Value = InstanceForm.BCurrentDept.DeptName;

            reportView.Dock = DockStyle.Fill;
            TabPage pageCtl = new TabPage();
            pageCtl.Text = string.Format("{0}{1}", brxm, row["发票号"]);
            pageCtl.Controls.Add(reportView);
            this.tabControl1.TabPages.Add(pageCtl);
            initReportTemp(reportView);
            if (Convert.ToString(rows[0]["cflx"]) == "03")
                this.initReportData(reportView, Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单_中药处方.rpt", parameters, false);
            else
                this.initReportData(reportView, Dset.病人处方清单, Constant.ApplicationDirectory + "\\Report\\YF_病人处方清单(处方格式).rpt", parameters, false);

            if (isPreview == false)
            {
                reportView.tbMain_ButtonClick(null, new ToolBarButtonClickEventArgs(new ToolBarButton()));
                string sql = string.Format("update mz_cfb set dybz = 1 where cfid = '{0}'", row["cfxh"]);
                InstanceForm.BDatabase.DoCommand(sql);
            }            
        }

        private byte[] GetImageByte(string strEmployeeId)
        {
            string ss = "select sign from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID=" + strEmployeeId + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ss);
            if (tb == null || tb.Rows.Count == 0 || tb.Rows[0]["sign"].GetType().ToString() == "System.DBNull")
                return null;
            else
                return ((byte[])tb.Rows[0]["sign"]);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //if (dataGridView1.RowCount > 0)
            //{
            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            object printflag = dataGridView1.Rows[e.RowIndex].Cells["打印标志"].Value;
            if (printflag != null && printflag.ToString().Trim() == "已打印")
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            else
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            //}
            //}
        }

        private void tbxfph_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frmcfdy_Shown(object sender, EventArgs e)
        {
            this.tbxbr.Focus();
        }
    }

    public struct ColumnDefine
    {
        public string HeaderText;
        public string MappingName;
        public int ColWidth;
        public bool ColReadOnly;
        public int ColBoolButton;

        public static ColumnDefine NewColumnDefine(string headerText, string mappinName, int colWidth, bool colReadonly, int colBoolButton)
        {
            ColumnDefine define = new ColumnDefine();
            define.HeaderText = headerText;
            define.MappingName = mappinName;
            define.ColWidth = colWidth;
            define.ColReadOnly = colReadonly;
            define.ColBoolButton = colBoolButton;
            return define;
        }
    }
}