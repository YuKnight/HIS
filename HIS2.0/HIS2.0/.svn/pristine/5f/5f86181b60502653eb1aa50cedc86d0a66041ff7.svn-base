using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using YpClass;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;

namespace ts_yf_cx
{
    public partial class FrmZyMzJyCx : Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private YpConfig ss;

        public FrmZyMzJyCx()
        {
            InitializeComponent();
        }

        public FrmZyMzJyCx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            ss = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
        }

        private void FrmZyMzJyCx_Load(object sender, EventArgs e)
        {
            CshMxGrid(this.myDataGrid1);
            CshHzGrid(this.myDataGrid2);
            SystemCfg sysrq = new SystemCfg(8019);
            this.dtprq1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(Convert.ToInt32(sysrq.Config) * (-1));
            this.dtprq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.chkrq.Checked = true;
            this.tabControl1.SelectedTab = this.tabPage1;

            //Modify by jchl
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "-1", "全部" });
                dt.Rows.Add(new object[] { "1", "住院" });
                dt.Rows.Add(new object[] { "2", "门诊" });

                Addcmb(cmbFylb, dt, "id", "name");
                cmbFylb.SelectedIndex = 0;
            }
            catch { }
        }

        private bool IsVisable(string columnName, bool defaultVisable)
        {
            string strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("住院处方发药网格列", columnName, Application.StartupPath + "\\ClientWindow.ini");
            if (string.IsNullOrEmpty(strVal))
                TrasenClasses.GeneralClasses.ApiFunction.WriteIniString("住院处方发药网格列", columnName, defaultVisable ? "1" : "0", Application.StartupPath + "\\ClientWindow.ini");
            strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("住院处方发药网格列", columnName, Application.StartupPath + "\\ClientWindow.ini");
            return strVal == "1" ? true : false;
        }

        private void CshMxGrid(TrasenClasses.GeneralControls.ButtonDataGridEx xcjwDataGrid)
        {
            #region 添加明细的列------------------
            List<ColumnDefine> columns = new List<ColumnDefine>();
            columns.Add(PubClass.NewColumnDefine("序号", "序号", 30, true, 1));
            columns.Add(PubClass.NewColumnDefine("发药", "发药", 30, true, 0));
            columns.Add(PubClass.NewColumnDefine("床号", "床号", (IsVisable("床号", true) ? 30 : 0), true, 0));//住院+床号  或者  门诊
            columns.Add(PubClass.NewColumnDefine("姓名", "姓名", (IsVisable("姓名", true) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("住院号", "住院号", (IsVisable("住院号", true) ? 60 : 0), true, 0));//住院号或者门诊号
            columns.Add(PubClass.NewColumnDefine("性别", "性别", (IsVisable("性别", true) ? 30 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("年龄", "年龄", (IsVisable("年龄", false) ? 40 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("剂型", "剂型", (IsVisable("剂型", false) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("商品名", "商品名", (IsVisable("商品名", true) ? 60 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("品名", "品名", (IsVisable("品名", true) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("规格", "规格", (IsVisable("规格", true) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("厂家", "厂家", (IsVisable("厂家", false) ? 100 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("单价", "单价", (IsVisable("单价", true) ? 80 : 0), true, 0));
            //columns.Add(PubClass.NewColumnDefine("库存数", "库存数", (IsVisable("库存数", false) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("数量", "数量", (IsVisable("数量", true) ? 60 : 0), true, 0));
            //update code by py 7-1 18:40
            columns.Add(PubClass.NewColumnDefine("单位", "单位", (IsVisable("单位", true) ? 35 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("剂数", "剂数", (IsVisable("剂数", true) ? 55 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("金额", "金额", (IsVisable("金额", true) ? 70 : 0), true, 0));

            columns.Add(PubClass.NewColumnDefine("煎药", "煎药", (IsVisable("煎药", true) ? 60 : 0), true, 0));

            columns.Add(PubClass.NewColumnDefine("用法", "用法", (IsVisable("用法", true) ? 50 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("频次", "频次", (IsVisable("频次", true) ? 45 : 0), true, 0));

            columns.Add(PubClass.NewColumnDefine("剂量", "剂量", (IsVisable("剂量", true) ? 45 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("剂量单位", "剂量单位", (IsVisable("剂量单位", false) ? 45 : 0), true, 0));

            columns.Add(PubClass.NewColumnDefine("货号", "货号", (IsVisable("货号", false) ? 50 : 0), true, 0));

            columns.Add(PubClass.NewColumnDefine("处方日期", "处方日期", (IsVisable("处方日期", true) ? 110 : 0), true, 0));//住院：处方日期  门诊：录入日期
            columns.Add(PubClass.NewColumnDefine("记费日期", "记费日期", (IsVisable("记费日期", true) ? 77 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("记费员", "记费员", (IsVisable("记费员", true) ? 70 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("发药日期", "发药日期", (IsVisable("发药日期", true) ? 60 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("发药员", "发药员", (IsVisable("发药员", true) ? 70 : 0), true, 0));

            //columns.Add(PubClass.NewColumnDefine("配药员", "配药员", (IsVisable("配药员", false) ? 45 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("处方号", "处方号", (IsVisable("处方号", true) ? 100 : 0), true, 0));

            columns.Add(PubClass.NewColumnDefine("zy_id", "zy_id", 0, true, 0));//cfmxid
            columns.Add(PubClass.NewColumnDefine("cjid", "cjid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dept_id", "dept_id", 0, true, 0));//KSDM
            columns.Add(PubClass.NewColumnDefine("doc_id", "doc_id", 0, true, 0));//YSDM
            //columns.Add(PubClass.NewColumnDefine("unitrate", "unitrate", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("ypsl", "ypsl", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("zxdw", "zxdw", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("inpatient_id", "inpatient_id", 0, true, 0));//PATID
            columns.Add(PubClass.NewColumnDefine("批发价", "批发价", (IsVisable("批发价", false) ? 75 : 0), true, 0));
            columns.Add(PubClass.NewColumnDefine("批发金额", "批发金额", (IsVisable("批发金额", false) ? 75 : 0), true, 0));
            //columns.Add(PubClass.NewColumnDefine("charge_bit", "charge_bit", 0, true, 0));
            //columns.Add(PubClass.NewColumnDefine("discharge_bit", "discharge_bit", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("医生", "医生", (IsVisable("批发金额", true) ? 75 : 0), true, 0));//医生名字
            columns.Add(PubClass.NewColumnDefine("dept_ly", "dept_ly", 0, true, 0));//科室名字
            //columns.Add(PubClass.NewColumnDefine("诊断", "诊断", 0, true, 0));
            //columns.Add(PubClass.NewColumnDefine("中医诊断", "中医诊断", (IsVisable("中医诊断", false) ? 100 : 0), true, 0));
            //columns.Add(PubClass.NewColumnDefine("中医症型", "中医症型", (IsVisable("中医症型", false) ? 100 : 0), true, 0));
            //columns.Add(PubClass.NewColumnDefine("STATITEM_CODE", "STATITEM_CODE", 0, true, 0));
            //columns.Add(PubClass.NewColumnDefine("家庭地址", "家庭地址", (IsVisable("家庭地址", false) ? 100 : 0), true, 0));
            //columns.Add(PubClass.NewColumnDefine("联系方式", "联系方式", (IsVisable("联系方式", false) ? 75 : 0), true, 0));
            //columns.Add(PubClass.NewColumnDefine("身份证", "身份证", (IsVisable("身份证", false) ? 100 : 0), true, 0));
            //columns.Add(PubClass.NewColumnDefine("cz_id", "cz_id", 0, true, 0));
            //columns.Add(PubClass.NewColumnDefine("kcid", "kcid", 0, true, 0));
            //columns.Add(PubClass.NewColumnDefine("execdept_id", "execdept_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("hwh", "hwh", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("特殊用法", "tsyf", 150, true, 0));
            columns.Add(PubClass.NewColumnDefine("剂量单位数量", "剂量单位数量", 0, true, 0));

            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbmx";
            int index = 0;
            foreach (ColumnDefine cd in columns)
            {
                //DataGridEnableBoolColumn
                if (cd.ColBoolButton == 0)
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(index);
                    colText.HeaderText = cd.HeaderText;
                    colText.MappingName = cd.MappingName;
                    colText.Width = cd.ColWidth;
                    colText.NullText = "";
                    colText.ReadOnly = cd.ColReadOnly;
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);

                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    DataColumn datacol;
                    if (cd.MappingName.Trim() == "ypsl" || cd.MappingName == "金额")
                        datacol = new DataColumn(cd.MappingName, Type.GetType("System.Decimal"));
                    else
                        datacol = new DataColumn(cd.MappingName);

                    dtTmp.Columns.Add(datacol);
                }
                else
                {
                    DataGridButtonColumn btnCol = new DataGridButtonColumn(index);
                    btnCol.HeaderText = cd.HeaderText;
                    btnCol.MappingName = cd.MappingName;
                    btnCol.Width = cd.ColWidth;

                    btnCol.CellButtonClicked += new DataGridCellButtonClickEventHandler(btnCol_CellButtonClicked);
                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);

                    this.myDataGrid1.MouseDown += new MouseEventHandler(btnCol.HandleMouseDown);
                    this.myDataGrid1.MouseUp += new MouseEventHandler(btnCol.HandleMouseUp);

                    DataColumn datacol;
                    datacol = new DataColumn(cd.MappingName);
                    dtTmp.Columns.Add(datacol);
                }
                index++;
            }

            xcjwDataGrid.DataSource = dtTmp;
            xcjwDataGrid.TableStyles[0].MappingName = "tbmx";

            if (ss.网络内容显示商品名 == true)
                xcjwDataGrid.TableStyles[0].GridColumnStyles["商品名"].Width = 100;
            else
                xcjwDataGrid.TableStyles[0].GridColumnStyles["商品名"].Width = 0;

            if ((new SystemCfg(8007)).Config == "0")
                this.myDataGrid1.TableStyles[0].GridColumnStyles["医生"].Width = 0;
            #endregion

        }

        private void CshHzGrid(TrasenClasses.GeneralControls.DataGridEx xcjwDataGrid)
        {
            #region 添加汇总的列
            List<ColumnDefine> columns = new List<ColumnDefine>();
            columns.Add(PubClass.NewColumnDefine("序号", "序号", 35, true, 0));
            columns.Add(PubClass.NewColumnDefine("剂型", "剂型", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("品名", "品名", 150, true, 0));
            columns.Add(PubClass.NewColumnDefine("商品名", "商品名", 150, true, 0));
            columns.Add(PubClass.NewColumnDefine("规格", "规格", 100, true, 0));
            columns.Add(PubClass.NewColumnDefine("厂家", "厂家", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("单价", "单价", 65, true, 0));
            //columns.Add(PubClass.NewColumnDefine("库存数", "库存数", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("领药数", "领药数", 65, true, 0));
            columns.Add(PubClass.NewColumnDefine("缺药数", "缺药数", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("单位", "单位", 40, true, 0));
            columns.Add(PubClass.NewColumnDefine("药库单位", "药库单位", 75, true, 0));
            columns.Add(PubClass.NewColumnDefine("金额", "金额", 75, true, 0));
            columns.Add(PubClass.NewColumnDefine("货号", "货号", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("cjid", "cjid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
            //columns.Add(PubClass.NewColumnDefine("领药科室", "领药科室", 0, true, 0));

            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbhz";
            int index = 0;
            foreach (ColumnDefine cd in columns)
            {
                DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(index);
                colText.HeaderText = cd.HeaderText;
                colText.MappingName = cd.MappingName;
                colText.Width = cd.ColWidth;
                colText.NullText = "";
                colText.ReadOnly = cd.ColReadOnly;
                colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid2_CheckCellEnabled);
                xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                DataColumn datacol;
                if (cd.MappingName.Trim() == "ypsl" || cd.MappingName == "金额")
                    datacol = new DataColumn(cd.MappingName, Type.GetType("System.Decimal"));
                else
                    datacol = new DataColumn(cd.MappingName);

                dtTmp.Columns.Add(datacol);

                index++;
            }
            xcjwDataGrid.DataSource = dtTmp;
            xcjwDataGrid.TableStyles[0].MappingName = "tbhz";
            #endregion

        }

        //列颜色改变事件
        private void myDataGrid1_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            try
            {

                e.BackColor = Color.White;
                DataTable tb;
                if (sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn")
                {
                    DataGridEnableBoolColumn column = (DataGridEnableBoolColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                else
                {
                    DataGridEnableTextBoxColumn tbxColumn = (DataGridEnableTextBoxColumn)sender;
                    tb = (DataTable)tbxColumn.DataGridTableStyle.DataGrid.DataSource;
                }
                if (e.Row > tb.Rows.Count - 1)
                    return;
                //				if (tb.Rows[e.Row]["cjid"].ToString().Trim()=="")
                //					e.BackColor=Color.Azure;

                if (tb.Rows[e.Row]["发药"].ToString().Trim() == "◆")
                    e.ForeColor = Color.Blue;
                if (tb.Rows[e.Row]["发药"].ToString().Trim() == "")
                {
                    //if (tabControl1.SelectedTab == tabPage1)
                    //{
                    //    if (tb.Rows[e.Row]["床号"] != null && tb.Rows[e.Row]["床号"].ToString().Trim() != string.Empty)
                    //    {
                    //        tb.Rows[e.Row]["发药"] = "◆";
                    //        e.ForeColor = Color.Blue;//Color.Black;
                    //    }
                    //    else
                    //    {
                    //        //tb.Rows[e.Row]["发药"] = string.Empty;
                    //        e.ForeColor = Color.Black;
                    //    }
                    //}
                    //else
                    //{
                    e.ForeColor = Color.Black;
                    //}
                }
                if (tb.Rows[e.Row]["发药"].ToString().Trim() == "√")
                    e.ForeColor = Color.Gray;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            //			
        }

        private void myDataGrid2_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;
            DataTable tb = (DataTable)this.myDataGrid2.DataSource;
            if (e.Row > tb.Rows.Count - 1)
                return;
            //if (Convert.ToDecimal(tb.Rows[e.Row]["领药数"]) > Convert.ToDecimal(tb.Rows[e.Row]["库存数"]))
            //    e.ForeColor = Color.Red;
            //else
            //    e.ForeColor = Color.Black;
        }

        //查询处方按钮事件
        private void butcfcx_Click(object sender, System.EventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();

            try
            {

                DataTable tb = new DataTable();

                string rq1 = dtprq1.Value.ToShortDateString();
                string rq2 = dtprq2.Value.ToShortDateString();
                string wardid = InstanceForm.BCurrentDept.DeptId.ToString();

                //未发药
                //if (this.tabControl1.SelectedTab == this.tabPage1)
                //{

                //    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_jy")
                //        tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                //    else
                //        tb = ZY_FY.SelectCF(wardid, inpatient_id, rq1, rq2, "", "", "", "", "0", bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                //}
                ////已发药
                //if (this.tabControl1.SelectedTab == this.tabPage2)
                //{
                //    string fybz = "1";
                //    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_jy")
                //        fybz = "9";

                //    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_cf_cx")
                //        tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, fybz, bk, (rdCydy.Checked ? 1 : 0), 0, cfh, InstanceForm.BDatabase, bdybz);
                //    else
                //        tb = ZY_FY.SelectCF(wardid, inpatient_id, "", "", "", "", rq1, rq2, fybz, bk, (rdCydy.Checked ? 1 : 0), InstanceForm.BCurrentDept.DeptId, cfh, InstanceForm.BDatabase, bdybz);
                //}
                string fybz = "1";
                int bdybz = 0;

                string fyType = cmbFylb.SelectedValue.ToString();

                tb = ZY_FY.SelectCF(fyType, wardid, rq1, rq2, fybz, bdybz, InstanceForm.BDatabase);


                //添加处方
                this.AddPresc(tb);

                chkall.Checked = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        //明细列的按钮事件
        private void btnCol_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
        {
            return;
            try
            {
                //如果为已发药
                if (this.tabControl1.SelectedTab != this.tabPage1)
                {
                    DataTable tab = (DataTable)this.myDataGrid1.DataSource;
                    int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                    if (tab.Rows[nrow]["序号"].ToString() == "" || tab.Rows[nrow]["序号"].ToString() == "小计" || Convert.ToDecimal(Convertor.IsNull(tab.Rows[nrow]["数量"], "0")) < 0)
                        this.myDataGrid1.ContextMenuStrip = null;
                    else
                    {
                        //if (Convert.ToDecimal(Convertor.IsNull(tab.Rows[nrow]["剂数"], "0")) == 1)
                        //    mnutjs.Visible = false;
                        //else
                        //    mnutjs.Visible = true;
                        //this.myDataGrid1.ContextMenuStrip = contextMenu1;

                    }
                    return;
                }
                this.myDataGrid1.ContextMenuStrip = null;
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {

                    if (tb.Rows[i]["处方号"].ToString().Trim() == tb.Rows[e.RowIndex]["处方号"].ToString().Trim() && tb.Rows[i]["住院号"].ToString().Trim() == tb.Rows[e.RowIndex]["住院号"].ToString().Trim() && tb.Rows[i]["处方号"].ToString().Trim() != "" && tb.Rows[i]["发药"].ToString().Trim() != "√" && tb.Rows[i]["发药"].ToString().Trim() != "×")
                    {
                        if (tb.Rows[i]["发药"].ToString().Trim() == "")
                            tb.Rows[i]["发药"] = "◆";
                        else
                            tb.Rows[i]["发药"] = "";
                    }
                }
                ComputeCf();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //添加处方记录
        private void AddPresc(DataTable tbcf)
        {

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();

            if (tbcf.Rows.Count == 0)
                return;

            //Modify by jchl
            tbcf = DoFilFylb(tbcf);

            if (tbcf.Rows.Count == 0)
                return;

            string _prescNo = tbcf.Rows[0]["处方号"].ToString().Trim();
            int _PrescRowNo = 0;
            decimal _PrescJe = 0;
            string _cfrq = "";
            string _zyh = "";
            int iCntNum = 0;
            for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            {
                if (tbcf.Rows[i]["处方号"].ToString().Trim() != _prescNo)
                {
                    DataRow row = tb.NewRow();
                    row["序号"] = "小计";
                    row["金额"] = _PrescJe.ToString("0.00");
                    row["处方号"] = _prescNo;
                    row["住院号"] = _zyh;
                    _prescNo = tbcf.Rows[i]["处方号"].ToString().Trim();
                    _cfrq = tbcf.Rows[i]["处方日期"].ToString().Trim();
                    _PrescRowNo = 0;
                    _PrescJe = 0;
                    iCntNum++;
                    tb.Rows.Add(row);

                    DataRow row1 = tb.NewRow();
                    tb.Rows.Add(row1);
                }

                if (tbcf.Rows[i]["处方号"].ToString().Trim() == _prescNo)
                {
                    _PrescRowNo = _PrescRowNo + 1;
                    tbcf.Rows[i]["序号"] = _PrescRowNo.ToString();
                    //					if (this.tabControl1.SelectedTab==this.tabPage2) tbcf.Rows[i]["发药"]="√";
                    tb.ImportRow(tbcf.Rows[i]);

                    if (this.tabControl1.SelectedTab == this.tabPage2)
                        tb.Rows[tb.Rows.Count - 1]["发药"] = "√";
                    else
                        tb.Rows[tb.Rows.Count - 1]["发药"] = "◆";

                    _PrescJe = _PrescJe + Convert.ToDecimal(tbcf.Rows[i]["金额"]);
                }

                _prescNo = tbcf.Rows[i]["处方号"].ToString().Trim();
                _cfrq = tbcf.Rows[i]["处方日期"].ToString().Trim();
            }

            //添加最后一张处方的合计
            DataRow endrow = tb.NewRow();
            iCntNum++;
            endrow["序号"] = "小计";
            endrow["金额"] = _PrescJe.ToString("0.00");
            endrow["住院号"] = Convert.ToDateTime(_cfrq).ToShortDateString();
            tb.Rows.Add(endrow);
            tb.TableName = "tbmx";

            txtCfNum.Text = iCntNum + "";

            this.myDataGrid1.DataSource = tb;
        }

        //汇总药品数量
        private void computeTld(string fyrq)
        {
            bool bGrpByDeptLy = false;
            bGrpByDeptLy = _menuTag.Function_Name.Trim().Equals("Fun_ts_yf_zyfy_cf_ZCY");//中草药上传不按照领药科室分组
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            string[] GroupbyField ={ "剂型", "品名", "商品名", "规格", "厂家", "单价", "货号", "cjid", "zxdw", "dwbl", "dept_ly" };
            bGrpByDeptLy = true;
            if (bGrpByDeptLy)
            {
                GroupbyField = new string[] { "剂型", "品名", "商品名", "规格", "厂家", "单价", "货号", "cjid", "zxdw", "dwbl" };
            }

            string[] ComputeField ={ "ypsl", "金额" };
            string[] CField ={ "sum", "sum" };

            //			TrasenFrame.Classes.TsSet xcset=new TrasenFrame.Classes.TsSet();
            //			xcset.TsDataTable=tb;
            //汇总每个统领分类
            //			DataTable tab=xcset.GroupTable(GroupbyField,ComputeField,CField,"发药='◆' and ypsl<>0");

            DataTable tab;
            DataRow[] selrow;

            if (this.tabControl1.SelectedTab == this.tabPage2)
            {
                selrow = tb.Select("ypsl<>0");
                //selrow = tb.Select("发药='√' and ypsl<>0");
            }
            else
            {
                //if (fyrq != "")
                //    selrow = tb.Select("发药='√' and ypsl<>0 and 发药日期='" + Convertor.IsNull(butfy.Tag, "") + "'");
                //else
                selrow = tb.Select("发药='◆' and ypsl<>0");
            }

            DataTable tbsel = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel.ImportRow(selrow[w]);
            tab = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);

            DataTable mytb = (DataTable)this.myDataGrid2.DataSource;
            mytb.Rows.Clear();

            DataRow[] Rows = tab.Select("", "剂型");
            decimal dSum = 0M;
            //添加数据
            for (int x = 0; x <= Rows.Length - 1; x++)
            {
                DataRow row = mytb.NewRow();
                row["序号"] = mytb.Rows.Count + 1;
                row["剂型"] = Rows[x]["剂型"];
                row["品名"] = Rows[x]["品名"];
                row["商品名"] = Rows[x]["商品名"];
                row["规格"] = Rows[x]["规格"];
                row["厂家"] = Rows[x]["厂家"];
                row["单价"] = Rows[x]["单价"];
                //row["库存数"] = Rows[x]["库存数"];
                row["领药数"] = Rows[x]["ypsl"];
                //decimal kcl = Convert.ToDecimal(Rows[x]["库存数"]);
                decimal ypsl = Convert.ToDecimal(Rows[x]["ypsl"]);
                decimal dwbl = Convert.ToDecimal(Rows[x]["dwbl"]);
                //row["缺药数"] = (kcl - ypsl) < 0 ? System.Math.Abs(kcl - ypsl) : 0;
                row["单位"] = Yp.SeekYpdw(Convert.ToInt32(Rows[x]["zxdw"]), InstanceForm.BDatabase);
                Ypcj cj = new Ypcj(Convert.ToInt32(Rows[x]["cjid"]), InstanceForm.BDatabase);
                row["药库单位"] = Convert.ToDouble(Math.Round(ypsl / dwbl, 3)).ToString() + cj.S_YPDW;
                row["金额"] = Rows[x]["金额"];
                row["货号"] = Rows[x]["货号"];
                row["cjid"] = Rows[x]["cjid"];
                row["dwbl"] = Rows[x]["dwbl"];
                if (!bGrpByDeptLy)
                {
                    row["领药科室"] = Yp.SeekDeptName(Convert.ToInt32(Rows[x]["dept_ly"]), InstanceForm.BDatabase);
                }
                mytb.Rows.Add(row);
                dSum += decimal.Parse(Rows[x]["金额"].ToString().Trim());
            }

            DataRow rAll = mytb.NewRow();
            rAll["品名"] = "总金额";
            rAll["金额"] = dSum;
            mytb.Rows.Add(rAll);
        }

        private void ComputeCf()
        {
            string[] GroupbyField ={ "处方号" };
            string[] ComputeField ={ };
            string[] CField ={ };

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            DataTable tab;
            DataRow[] selrow = tb.Select("发药='◆' and cjid<>''");
            //DataRow[] selrow=tb.Select("发药='◆' and cjid<>'' and charge_bit='1'");
            DataTable tbsel = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel.ImportRow(selrow[w]);
            tab = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
            //this.lblbz.Text = "处方数:" + tab.Rows.Count.ToString() + " 张";

            string[] GroupbyField1 ={ "dept_ly" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };
            DataTable tbsel1 = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel1.ImportRow(selrow[w]);
            tab = FunBase.GroupbyDataTable(tbsel1, GroupbyField1, ComputeField1, CField1, null);
            string ss = "";
            for (int i = 0; i <= tab.Rows.Count - 1; i++)
                ss = ss + " " + Yp.SeekDeptName(Convert.ToInt32(tab.Rows[i]["dept_ly"]), InstanceForm.BDatabase);
            //this.lblbz.Text = lblbz.Text + " 科室:" + ss.ToString();
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        //Add by jchl【天剂外包发药：根据发药类别过滤处方】
        private DataTable DoFilFylb(DataTable tb)
        {
            try
            {
                //Modify by jchl【处方发药：根据发药类型判断-1：全部  1：本药房发药  2：用法(水煎服)煎药(待煎)过滤】
                DataTable dtCffy = tb.Clone();

                DataRow[] drs = tb.Select();

                for (int i = 0; i < drs.Length; i++)
                {
                    dtCffy.Rows.Add(drs[i].ItemArray);
                }

                return dtCffy;
            }
            catch
            {
                return null;
            }
        }

        private void chkrq_CheckedChanged(object sender, EventArgs e)
        {
            dtprq1.Enabled = chkrq.Checked;
            dtprq2.Enabled = chkrq.Checked;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

            try
            {
                this.Cursor = PubStaticFun.WaitCursor();

                computeTld("");

                if (this.tabControl1.SelectedTab == this.tabPage2)
                    this.butprinthz.Enabled = true;
                else
                    this.butprinthz.Enabled = false;


            }
            catch (System.Exception err)
            {
                DataTable tb = (DataTable)this.myDataGrid2.DataSource;
                tb.Rows.Clear();
                MessageBox.Show(this, "发生错误" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void butprinthz_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid2.DataSource;
                ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                if (tb.Rows.Count == 0)
                    return;

                DataTable tbmx = (DataTable)this.myDataGrid1.DataSource;
                DataRow[] rows;
                rows = tbmx.Select("ypsl<>0");

                if (rows.Length == 0 && new SystemCfg(8041).Config == "1")
                {
                    MessageBox.Show("没有要打印的已发药处方", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                butprinthz.Enabled = false;


                //string lydw=Yp.SeekWardName(tb.Rows[0]["wardid"].ToString().Trim());
                //string fyr=Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["fyr"]));
                //string pyr=Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["pyr"]));
                DataRow myrow;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (tb.Rows[i]["品名"].ToString().Trim().Equals("总金额"))
                    {
                        continue;
                    }

                    myrow = Dset.发药明细单.NewRow();
                    myrow["yppm"] = Convertor.IsNull(Convert.ToString(tb.Rows[i]["品名"]), "");
                    myrow["ypspm"] = Convertor.IsNull(Convert.ToString(tb.Rows[i]["商品名"]), "");
                    myrow["ypgg"] = Convertor.IsNull(Convert.ToString(tb.Rows[i]["规格"]), "");
                    myrow["sccj"] = Convertor.IsNull(Convert.ToString(tb.Rows[i]["厂家"]), "");
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["单价"], "0"));
                    myrow["ypsl"] = Convertor.IsNull(tb.Rows[i]["领药数"], "");
                    myrow["ypdw"] = Convertor.IsNull(Convert.ToString(tb.Rows[i]["单位"]), "");
                    myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["金额"], "0"));
                    myrow["shh"] = Convertor.IsNull(Convert.ToString(tb.Rows[i]["货号"]), "");
                    myrow["tlfl"] = "";
                    myrow["fyrq"] = "";
                    myrow["fyr"] = "";
                    myrow["pyr"] = "";
                    myrow["lydw"] = "";
                    myrow["bz"] = Convertor.IsNull(Convert.ToString(tb.Rows[i]["药库单位"]), "");
                    Dset.发药明细单.Rows.Add(myrow);
                }

                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "title";
                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")代煎处方汇总单";
                parameters[1].Text = "lydwHeadText";
                parameters[1].Value = "";
                bool bview = this.chkprintview.Checked == true ? false : true;

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_住院处方汇总单.rpt", parameters, bview);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
                butprinthz.Enabled = true;

            }
            catch (System.Exception err)
            {
                butprinthz.Enabled = true;
                MessageBox.Show(err.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = (tabControl1.SelectedTab.Name.Equals("tabPage1") ? myDataGrid1.DataSource : myDataGrid2.DataSource) as DataTable;
                if (dt == null || dt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有数据需要导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //saveFileDialog1.OverwritePrompt
                string table = @"";

                //设置文件类型
                //书写规则例如：txt files(*.txt)|*.txt  dBase(*.dbf)
                saveFileDialog1.Filter = "Excel files(*.xls)|*.xls|All files(*.*)|*.*";
                //设置默认文件名（可以不设置）
                saveFileDialog1.FileName = "1";
                //主设置默认文件extension（可以不设置）
                saveFileDialog1.DefaultExt = "xls";
                //获取或设置一个值，该值指示如果用户省略扩展名，文件对话框是否自动在文件名中添加扩展名。（可以不设置）
                saveFileDialog1.AddExtension = true;

                //设置默认文件类型显示顺序（可以不设置）
                saveFileDialog1.FilterIndex = 1;

                //保存对话框是否记忆上次打开的目录
                saveFileDialog1.RestoreDirectory = true;

                // Show save file dialog box
                DialogResult result = saveFileDialog1.ShowDialog();
                //点了保存按钮进入
                if (result == DialogResult.OK)
                {
                    //获得文件路径
                    table = saveFileDialog1.FileName.ToString();
                }
                else
                {
                    return;
                }

                ExportExcel(dt, table);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作出错! \n\t " + ex.Message + " \n\t " + ex.StackTrace);
                return;
            }
        }

        protected void ExportExcel(DataTable dt, string table)
        {
            if (dt == null || dt.Rows.Count == 0) return;
            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                return;
            }
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Excel.Workbooks workbooks = xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
            //Excel.Workbook workbook = xlApp.Workbooks.Open(table, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //Excel.Worksheet worksheet = workbook.Sheets[1] as Excel.Worksheet; //第一个sheet页
            worksheet.Name = "煎药信息汇总"; //这里修改sheet名称

            try
            {
                Excel.Range range;
                long totalCount = dt.Rows.Count;
                long rowRead = 0;
                float percent = 0;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                    range = (Excel.Range)worksheet.Cells[1, i + 1];
                    range.Interior.ColorIndex = 15;
                    range.Font.Bold = true;
                    //range.NumberFormat = "0.00";
                }

                DataTable dtDec = DecCol();

                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string strValue = dt.Rows[r][i].ToString();
                        decimal dm = 0M;
                        if (dtDec.Columns.Contains(dt.Columns[i].ColumnName))
                        {
                            ((Excel.Range)worksheet.Cells[r + 2, i + 1]).NumberFormat = "0.00";
                            worksheet.Cells[r + 2, i + 1] = strValue;
                        }
                        else
                        {
                            worksheet.Cells[r + 2, i + 1] = "'" + strValue;
                            //worksheet.Cells[r + 2, i + 1] = strValue;
                        }
                    }
                    rowRead++;
                    percent = ((float)(100 * rowRead)) / totalCount;
                }
                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                workbook.Saved = true;

                if (System.IO.File.Exists(table))
                {
                    System.IO.File.Delete(table);
                }
                workbook.SaveCopyAs(table);
                workbook.Close(true, Type.Missing, Type.Missing);
                workbook = null;
                xlApp.Quit();
                xlApp = null;
            }
        }

        private DataTable DecCol()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("金额", typeof(decimal));
            dt.Columns.Add("单价", typeof(decimal));

            return dt;
        }
    }
}