using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using ts_mz_class;
using Trasen.Print;

namespace ts_mzsf_fpbd
{
    public partial class FrmFPCX : Form
    {
        private BllHandler handler;
        private SystemCfg cfg1046 = new SystemCfg(1046);

        public FrmFPCX(string FormText)
        {
            InitializeComponent();

            this.Text = FormText;
            this.WindowState = FormWindowState.Maximized;
            this.Activated += new EventHandler(FrmFPCX_Activated);
        }
        //private SystemCfg cfg1171 = new SystemCfg(1171);
        //private SystemCfg cfg1172 = new SystemCfg(1172);
        void FrmFPCX_Activated(object sender, EventArgs e)
        {
            ShowDqfp();
        }

        private void FrmFPCX_Load(object sender, EventArgs e)
        {
            txtMzh.KeyPress += new KeyPressEventHandler(txtMzh_KeyPress);
            txtDNLSH.KeyPress += new KeyPressEventHandler(txtDNLSH_KeyPress);
            txtBrxm.KeyPress += new KeyPressEventHandler(txtBrxm_KeyPress);

            handler = new BllHandler();

            string date = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd");
            dtpSFRQ1.Value = Convert.ToDateTime(date + " 00:00:00");
            dtpSFRQ2.Value = Convert.ToDateTime(date + " 23:59:59");
            dtpBdsj1.Value = Convert.ToDateTime(date + " 00:00:00");
            dtpBdsj2.Value = Convert.ToDateTime(date + " 23:59:59");

            ComboBox cbo = new ComboBox();
            FunAddComboBox.AddOperator(true, cbo, InstanceForm.BDatabase);
            cboBDY.DisplayMember = "name";
            cboBDY.ValueMember = "employee_id";
            cboBDY.DataSource = cbo.DataSource;

            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            if ((cmbklx.DataSource as DataTable).Rows.Count > 1)
            {
                //写死   默认选中磁卡号
                cmbklx.SelectedIndex = 1;
            }


            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(InstanceForm._menuTag.Function_Name, cmbklx, txtKh);

            #region 增加F6读身份证
            this.KeyDown += delegate(object o, KeyEventArgs args)
            {
                if (args.KeyCode == Keys.F6)
                {
                    string bqy = ApiFunction.GetIniString("身份证扫描器", "启用身份证扫描器", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    if (bqy == "true")
                    {
                        string bsbxh = ApiFunction.GetIniString("身份证扫描器", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                        ts_ReadCard.Icard card = ts_ReadCard.CardFactory.NewCard(bsbxh);
                        ts_ReadCard.IDCardData _IDCardData = new ts_ReadCard.IDCardData();
                        string msg = "";
                        bool bok = card.ReadCard(ref _IDCardData, ref msg);
                        if (bok == false)
                            return;

                        SystemCfg cfg1186 = new SystemCfg(1186, InstanceForm.BDatabase);
                        if (cfg1186.Config == "1")
                        {
                            SystemCfg cfg1187 = new SystemCfg(1187, InstanceForm.BDatabase);
                            if (!string.IsNullOrEmpty(cfg1187.Config) && Convertor.IsInteger(cfg1187.Config))
                            {
                                cmbklx.SelectedValue = Convert.ToInt32(cfg1187.Config);
                                txtKh.Text = _IDCardData.IDCardNo;
                                txtKh_KeyPress(txtKh, new KeyPressEventArgs('\r'));
                            }
                            else
                            {
                                MessageBox.Show("身份证登记功能不能用，请正确设置参数1187或关闭参数1186", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            };
            #endregion
        }

        private void ShowDqfp()
        {
            try
            {
                EmptyFP dqfp = handler.GetFPH(InstanceForm.BCurrentUser.EmployeeId);
                lblFPH.Text = dqfp.Qz + dqfp.Fph;
            }
            catch (Exception err)
            {
                lblFPH.Text = "<无可用票据>";
                btnPrint.Visible = false;
            }
        }

        private void btnCX_Click(object sender, EventArgs e)
        {
            string dateFormat = "yyyy-MM-dd HH:mm:ss";
            DataTable tbFpjl = null;
            int sjly = 0;
            if (rdLS.Checked)
                sjly = 1;
            if (rdbWDY.Checked)
            {
                tbFpjl = handler.SelectFPJL(sjly, txtMzh.Text, Convert.ToInt32(cmbklx.SelectedValue), txtKh.Text, txtDNLSH.Text, txtBrxm.Text,
                                                    dtpSFRQ1.Value.ToString(dateFormat), dtpSFRQ2.Value.ToString(dateFormat));
            }
            else
            {
                tbFpjl = handler.SelectFPJL(sjly, txtMzh.Text, Convert.ToInt32(cmbklx.SelectedValue), txtKh.Text, txtDNLSH.Text, txtBrxm.Text, "", "",
                                                        (Convert.IsDBNull(cboBDY.SelectedValue) ? 0 : Convert.ToInt32(cboBDY.SelectedValue)),
                                                        dtpBdsj1.Value.ToString(dateFormat), dtpBdsj2.Value.ToString(dateFormat));
            }
            dgvFpjl.DataSource = tbFpjl;

        }

        private void btnGhPrt_Click(object sender, EventArgs e)
        {
            if (dgvFpjl.DataSource == null)
            {
                MessageBox.Show("请先查询要打印的 挂号小票 记录", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow dgr = dgvFpjl.CurrentRow;

            if (dgr == null)
            {
                MessageBox.Show("没有选择要打印的 挂号小票 记录", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //
            if (!dgr.Cells["COL_LZMC"].Value.ToString().Trim().Equals("挂号"))
            {
                MessageBox.Show("只有 挂号 记录才能打印小票记录", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int prtTimes = int.Parse(dgr.Cells["xpcs"].Value.ToString().Trim());

            if (prtTimes >= 1)
            {
                if (MessageBox.Show("挂号小票已打印过，是否确认要继续补打", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                {
                    return;
                }
            }


            string blh = dgr.Cells["COL_BLH"].Value.ToString().Trim();
            string fpid = dgr.Cells["COL_FPID"].Value.ToString().Trim();

            string strSql = string.Format(@" select convert( varchar(10),GHSJ,  120) GHSJ,YYSD,
                                                 PDXH,b.BRXM,
                                                 case b.XB when '1' then '男' when '2' then '女' else '未知' end as XB,
                                                 a.GHJB as ghjb_code,
                                                 d.TYPE_NAME as ghjb,
                                                 dbo.fun_getDeptname( a.GHKS) GHKS,
                                                 dbo.fun_getEmpName( a.GHYS) GHYS,
                                                 --a.GHJE, 
                                                 f.ZJE-f.yhje as GHJE, 
                                                 a.DJY DJY,
                                                 a.GHDJSJ,
                                                 a.DNLXH,
                                                 c.NAME,
                                                 c.DEPTADDR,
                                                case DATEPART(weekday,GHSJ)
                                                when 1  then isnull(g.Sunday,'')
                                                when 2  then isnull(g.Moday,'')
                                                when 3  then isnull(g.Tuesday,'')
                                                when 4  then isnull(g.Wednesday,'')
                                                when 5  then isnull(g.Thursday,'')
                                                when 6  then isnull(g.Friday,'')
                                                when 7  then isnull(g.Sataurday,'')
                                                end AS addr,
                                                 e.kh
                                                 from MZ_GHXX a
                                                 inner join YY_BRXX b on a.BRXXID=b.BRXXID 
                                                 left join JC_DEPT_PROPERTY c on a.GHKS=c.DEPT_ID
                                                 inner join JC_DOCTOR_TYPE d on a.GHJB=d.TYPE_ID
                                                 inner join YY_KDJB e on a.KDJID=e.KDJID
                                                 inner join MZ_FPB f on a.GHXXID=f.GHXXID and f.BGHPBZ=1 and JLZT in (0,1)
                                                 left join jc_mz_ksdzwh g on a.ghys=g.emp_id and a.ghks=g.dept_id
                                               where a.blh='{0}'", blh);

            DataTable dt=InstanceForm.BDatabase.GetDataTable(strSql);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("未找到该病历号的挂号记录", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow dr = dt.Rows[0];

            #region 获取挂号费、诊查费
            string strGhf = "0.00";
            string strZcf = "0.00";
            string strSqlGH = string.Format(@"select XMDM,JE from MZ_FPB_MX where FPID=(select FPID from MZ_FPB where BGHPBZ=1 and ZJE>-0.1 and GHXXID=(select GHXXID from MZ_GHXX where BLH='{0}'))", blh);

            DataTable dtGH = InstanceForm.BDatabase.GetDataTable(strSqlGH);
            if (dtGH.Rows.Count > 0)
            {
                foreach (DataRow item in dtGH.Rows)
                {
                    if (item["XMDM"].ToString().Trim().Equals("36"))
                    {
                        strGhf = item["JE"].ToString();
                    }
                    else if (item["XMDM"].ToString().Trim().Equals("37"))
                    {
                        strZcf = item["JE"].ToString();
                    }
                }
            }
            else
            {
                strGhf = "0.00";
                strZcf = "0.00";
            }
            #endregion

            try
            {
                string prtName = TrasenFrame.Classes.Constant.CReportPrinterName;
                if (string.IsNullOrEmpty(prtName))
                {
                    try
                    {
                        prtName = ApiFunction.GetIniString("打印机", "name", Constant.ApplicationDirectory + "ClientWindow.ini");
                    }
                    catch { }
                }
                string isprt = ApiFunction.GetIniString("打印机", "isprint", Constant.ApplicationDirectory + "ClientWindow.ini");

                string visitTime = dr["GHSJ"].ToString().Trim();
                visitTime += "  ";
                visitTime += dr["YYSD"].ToString().Trim();

                List<ReportParameter> para = new List<ReportParameter>();
                para.Add(new ReportParameter("排队号", dr["PDXH"].ToString().Trim()));
                para.Add(new ReportParameter("姓名", dr["BRXM"].ToString().Trim()));
                para.Add(new ReportParameter("性别", dr["XB"].ToString().Trim()));
                para.Add(new ReportParameter("看诊时间", visitTime));//待取数据源
                para.Add(new ReportParameter("科室", dr["GHKS"].ToString().Trim()));
                para.Add(new ReportParameter("医生", dr["GHYS"] == DBNull.Value ? "" : dr["GHYS"].ToString().Trim()));     //待取数据源
                para.Add(new ReportParameter("号别", dr["GHJB"].ToString().Trim()));
                //para.Add(new ReportParameter("挂号费", dr["GHJE"].ToString().Trim()));
                //para.Add(new ReportParameter("操作员", dr["DJY"].ToString().Trim()));
                para.Add(new ReportParameter("操作员", InstanceForm.BCurrentUser.LoginCode));
                if (dr["addr"].ToString().Trim().Equals(""))
                {
                    para.Add(new ReportParameter("看诊地点", dr["DEPTADDR"].ToString().Trim()));    
                }
                else
                {
                    para.Add(new ReportParameter("看诊地点", dr["addr"].ToString().Trim()));
                }
                para.Add(new ReportParameter("日期", dr["GHDJSJ"].ToString().Trim()));                                              //待取数据源
                para.Add(new ReportParameter("流水号", dr["DNLXH"].ToString().Trim()));
                para.Add(new ReportParameter("卡号", dr["kh"].ToString().Trim()));

                if (prtTimes >= 1)
                {
                    para.Add(new ReportParameter("补打", "补"));
                }
                else
                {
                    para.Add(new ReportParameter("补打", ""));
                }


                double num = Convert.ToDouble(strGhf) + Convert.ToDouble(strZcf);//挂号费加诊查费

                if (dr["GHJE"].ToString() == strZcf.ToString())//实际金额等于诊查费表示免挂号费
                {
                    para.Add(new ReportParameter("挂号费", "0.00"));//免挂号费
                    para.Add(new ReportParameter("诊查费", strZcf));//诊查费
                }
                else if (dr["GHJE"].ToString() == strGhf.ToString())//实际金额等于挂号费表示免诊查费
                {
                    para.Add(new ReportParameter("挂号费", strGhf)); ;//挂号费
                    para.Add(new ReportParameter("诊查费", "0.00")); ;//免诊查费
                }
                else if (dr["GHJE"].ToString() == "0.00")//实际金额等于0表示全免
                {
                    para.Add(new ReportParameter("挂号费", "0.00"));//免挂号费
                    para.Add(new ReportParameter("诊查费", "0.00")); ;//免诊查费
                }
                else if (dr["GHJE"].ToString() == num.ToString("#0.00"))//实际金额等于挂号费加诊查费表示不免
                {
                    para.Add(new ReportParameter("挂号费", strGhf)); ;//挂号费
                    para.Add(new ReportParameter("诊查费", strZcf));//诊查费
                }
                para.Add(new ReportParameter("总金额", dr["GHJE"].ToString()));//实际金额
                //TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView( new DataSet(),Constant.ApplicationDirectory + "\\Report\\YF_药品领药按单据汇总统计.rpt", parameters);

                //if (f.LoadReportSuccess)
                //{
                //    f.Show();
                //}
                //else
                //{
                //    f.Dispose(); 
                //}
                //List<ReportParameter> para = new List<ReportParameter>();

                Trasen.Print.BaseReportPrinter printer1 = Trasen.Print.BaseReportPrinter.GetReportPrinter(Trasen.Print.Mode.Grid十十);
                printer1.ReportTemplateFile = "MZGH_预约挂号卷.grf";
                printer1.Preview = isprt.Trim().Equals("true");
                printer1.PrinterName = prtName;
                printer1.Print(para.ToArray());

                string isPrt = cfg1046.Config.Trim();
                 strSql = string.Format("update a set xpcs=isnull(xpcs,0)+{1} from MZ_FPB a where a.FPID='{0}' ", fpid, isPrt.Equals("2") ? 1 : 0);

                int iret = InstanceForm.BDatabase.DoCommand(strSql);

                if (iret <= 0)
                {
                    throw new Exception("更新打印次数时未找到该发票记录");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("打印预约票报错\r" + ex.Message + "\r" + ex.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnCX_Click(null, null);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvFpjl.DataSource == null)
            {
                MessageBox.Show("请先查询要补打的记录", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string _dnlsh = this.dgvFpjl.CurrentRow.Cells["COL_DNLSH"].Value.ToString();
            if (!string.IsNullOrEmpty(_dnlsh))
            {
                string sqlString = string.Format(@"select bqxghbz from mz_ghxx where dnlxh = '{0}'", _dnlsh);
                DataTable _dataTable = InstanceForm.BDatabase.GetDataTable(sqlString);
                if (_dataTable.Rows.Count > 0)
                {
                    string _bqxghbz = _dataTable.Rows[0]["bqxghbz"].ToString();
                    int _out = 0;
                    if (Int32.TryParse(_bqxghbz, out _out))
                    {
                        if (_out == 1)
                        {
                            MessageBox.Show(string.Format("当前选中的电脑流水号为:[{0}]的挂号记录已退费", _dnlsh), "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }

            DataTable tb = (DataTable)dgvFpjl.DataSource;
            DataRow[] drsFpjl = tb.Select("SELECTED=1 and JLZT=0");

            if (drsFpjl.Length == 0)
            {
                MessageBox.Show("没有选择需要补打的记录", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string dysj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");
            groupBox1.Enabled = false;
            this.Cursor = TrasenClasses.GeneralClasses.PubStaticFun.WaitCursor();
            int sjly = 0;
            if (rdLS.Checked)
                sjly = 1;
            try
            {
                for (int i = 0; i < drsFpjl.Length; i++)
                {
                    Guid fpid = new Guid(drsFpjl[i]["FPID"].ToString().Trim());
                    int lx = Convert.ToInt32(drsFpjl[i]["LX"]);
                    //后台查询发票记录，以防止同时操作
                    DataRow drFpxx = handler.SelectFpxx(lx, "", fpid, sjly);
                    //Fun.DebugView(drFpxx.Table);
                    if (Convertor.IsNull(drFpxx["发票号"], "0") != "0" && Convertor.IsNull(drFpxx["发票号"], "") != "")
                        throw new Exception("该记录已经打印过发票，不能补打");
                    //if (InstanceForm.BCurrentUser.Name.ToString() != drFpxx["收费员"].ToString())
                    //    throw new Exception("非本人票，不能补打"); 
                    TimeSpan ts = Convert.ToDateTime(dysj) - Convert.ToDateTime(drFpxx["收费日期"]);
                    double dHours = Math.Round(ts.TotalHours);
                    //if (dHours <= Convert.ToDouble(cfg1172.Config))
                    //    throw new Exception("发票打印时间太久，不能补打");

                    try
                    {
                        //获得可用发票
                        EmptyFP emptyfp = handler.GetFPH(InstanceForm.BCurrentUser.EmployeeId);
                        try
                        {
                            //打印
                            handler.Print(drFpxx, emptyfp, dysj);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("打印过程中发生错误:" + Environment.NewLine + error.Message + Environment.NewLine + error.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception err)
                    {
                        if (MessageBox.Show("获取可用发票发生错误：" + err.Message + Environment.NewLine + err.StackTrace + Environment.NewLine + "是否继续打印？", "",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;
                    }
                }
                btnCX_Click(null, null);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + Environment.NewLine + error.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                groupBox1.Enabled = true;
                ShowDqfp();
                this.Cursor = Cursors.Default;
            }
        }

        private void rdbWDY_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbWDY.Checked)
            {
                groupBox5.Enabled = true;
                groupBox3.Enabled = false;
                btnPrint.Enabled = true;
            }
            else
            {
                groupBox5.Enabled = false;
                groupBox3.Enabled = true;
                btnPrint.Enabled = false;
            }
            btnCX_Click(null, null);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKh_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*---------------Add By Zj 2012-04-18 增加卡号格式化-----------*/
            if ((int)e.KeyChar == 13)
            {
                int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                txtKh.Text = Fun.returnKh(klx, txtKh.Text.Trim(), InstanceForm.BDatabase);//格式化卡号 根据卡长度
                txtKh.SelectionStart = txtKh.Text.Length;//将光标定位到最后一个字符
                btnCX_Click(sender, e);
            }
        }

        private void btndc_Click(object sender, EventArgs e)
        {
            if (this.dgvFpjl.Rows.Count == 0) return;
            DataTable tb = (DataTable)this.dgvFpjl.DataSource;
            // 创建Excel对象                    --LeeWenjie    2006-11-29
            Excel.Application xlApp = new Excel.ApplicationClass();
            if (xlApp == null)
            {
                MessageBox.Show("Excel无法启动");
                return;
            }
            // 创建Excel工作薄
            Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
            Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

            // 列索引，行索引，总列数，总行数
            int colIndex = 0;
            int RowIndex = 0;
            int colCount = 0;
            int RowCount = tb.Rows.Count;
            for (int i = 0; i <= dgvFpjl.ColumnCount - 1; i++)
            {
                if (dgvFpjl.Columns[i].Visible == true && (dgvFpjl.Columns[i].Name != "COL_SELECTED" && dgvFpjl.Columns[i].Name != "COL_LZMC"))
                    colCount = colCount + 1;
            }

            // 设置标题
            Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
            range.MergeCells = true;
            xlApp.ActiveCell.FormulaR1C1 = this.Text;
            xlApp.ActiveCell.Font.Size = 20;
            xlApp.ActiveCell.Font.Bold = true;
            xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


            // 创建缓存数据
            object[,] objData = new object[RowCount + 1, colCount + 1];
            // 获取列标题
            for (int i = 0; i <= dgvFpjl.ColumnCount - 1; i++)
            {
                if (dgvFpjl.Columns[i].Visible == true && (dgvFpjl.Columns[i].Name != "COL_SELECTED" && dgvFpjl.Columns[i].Name != "COL_LZMC"))
                    objData[0, colIndex++] = dgvFpjl.Columns[i].HeaderText;
            }
            // 获取数据

            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                colIndex = 0;
                for (int j = 0; j <= dgvFpjl.ColumnCount - 1; j++)
                {
                    if (dgvFpjl.Columns[j].Visible == true && (dgvFpjl.Columns[j].Name != "COL_SELECTED" && dgvFpjl.Columns[j].Name != "COL_LZMC"))
                    {
                        objData[i + 1, colIndex++] = "'" + tb.Rows[i][j].ToString();
                    }
                }
                Application.DoEvents();
            }
            // 写入Excel
            range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
            range.Value2 = objData;

            // 
            xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

            //设置报表表格为最适应宽度
            xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Select();
            xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Columns.AutoFit();
            xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Font.Size = 9;

            xlApp.Visible = true;
        }

        private void 发票异常处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvFpjl.DataSource == null)
            {
                MessageBox.Show("请先查询要补打的记录", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.BindingContext[this.dgvFpjl.DataSource].EndCurrentEdit();

            try
            {
                this.dgvFpjl.CurrentCell = this.dgvFpjl.Rows[this.dgvFpjl.CurrentCell.RowIndex].Cells[1];
            }
            catch
            {

            }

            this.BindingContext[(DataTable)dgvFpjl.DataSource].EndCurrentEdit();
            DataTable tb = (DataTable)dgvFpjl.DataSource;
            DataRow[] drsFpjl = tb.Select("SELECTED=1");
            if (drsFpjl.Length == 0)
            {
                MessageBox.Show("没有选择需要处理的记录", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.dgvFpjl.CurrentCell != null)
                this.dgvFpjl.CurrentCell = this.dgvFpjl.Rows[this.dgvFpjl.CurrentCell.RowIndex].Cells[2];

            string dysj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                if (MessageBox.Show(this, "您是由于补打发票没有打印出发票要进行处理吗？\r\n（请点击确定以后，再补打发票）\r\n 注意：补打时核对电脑发票与当前打印机发票是否一致 ?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < drsFpjl.Length; i++)
                    {
                        try
                        {
                            Guid fpid = new Guid(drsFpjl[i]["FPID"].ToString().Trim());
                            int lx = Convert.ToInt32(drsFpjl[i]["LX"]);
                            string fph = drsFpjl[i]["FPH"].ToString().Trim();
                            try
                            {
                                TrasenFrame.Forms.FrmMdiMain.Database.BeginTransaction();

                                string sql = "update MZ_FPB set FPH = 0 where FPID = '" + fpid + "'";
                                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql);
                                sql = "update MZ_FPB_H set FPH = 0 where FPID = '" + fpid + "'";
                                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql);

                                sql = "update MZ_CFB set FPH = 0 where FPID = '" + fpid + "'";
                                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql);
                                sql = "update MZ_CFB_H set FPH = 0 where FPID = '" + fpid + "'";
                                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql);

                                sql = "update MZ_CFB set FPH = 0 where FPH = '" + fph + "'";
                                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql);
                                sql = "update MZ_CFB_H set FPH = 0 where FPH = '" + fph + "'";
                                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql);

                                sql = "update MZ_GHXX set FPH = '0' where FPH = '" + fph + "'";
                                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql);
                                sql = "update MZ_GHXX_H set FPH = '0' where FPH = '" + fph + "'";
                                TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql);

                                TrasenFrame.Forms.FrmMdiMain.Database.CommitTransaction();
                            }
                            catch (Exception err)
                            {
                                TrasenFrame.Forms.FrmMdiMain.Database.RollbackTransaction();
                                MessageBox.Show("操作发生错误：" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception err)
                        {
                            if (MessageBox.Show("补打发生错误：" + err.Message + Environment.NewLine + "是否继续打印？", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                        }
                    }
                    btnCX_Click(null, null);
                }
            }
            catch (Exception)
            {
            }
        }

        private void dgvFpjl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.BindingContext[this.dgvFpjl.DataSource].EndCurrentEdit();
        }

        private void dgvFpjl_Click(object sender, EventArgs e)
        {
            //this.dgvmx.DataSource = null;

            //if (this.dgvFpjl.CurrentCell == null)
            //    return;
            //DataTable temp = (DataTable)this.dgvFpjl.DataSource;
            //string ss = "declare  @sql varchar(500) " +
            //      " set @sql='select '   " +
            //       "    select @sql=@sql+CAST(JE as varchar)+'   ' +XMMC +',' from VI_MZ_FPB_MX where FPID='" + temp.Rows[this.dgvFpjl.CurrentCell.RowIndex]["FPID"] + "' "
            //       + "    set @sql=LEFT( @sql,LEN(@sql)-1)     exec  (@sql)  ";
            //DataTable tb = InstanceForm.BDatabase.GetDataTable(ss);
            //this.dgvmx.DataSource = tb;
            this.dgvmx.DataSource = null;
            this.dgvmx.Columns.Clear();
            if (this.dgvFpjl.CurrentCell == null)
                return;
            object obj = ((DataRowView)dgvFpjl.CurrentRow.DataBoundItem).Row["FPID"];
            Guid fpid = new Guid(Convertor.IsNull(obj, Guid.Empty.ToString()));
            if (fpid == Guid.Empty)
                return;

            DataTable tbMX = InstanceForm.BDatabase.GetDataTable("select * from VI_MZ_FPB_MX where fpid='" + fpid + "'");
            object[] itemArray = new object[tbMX.Rows.Count];
            DataTable tbRow = new DataTable();
            for (int i = 0; i < tbMX.Rows.Count; i++)
            {
                DataRow r = tbMX.Rows[i];
                DataColumn col = new DataColumn(r["XMMC"].ToString());
                tbRow.Columns.Add(col);
                itemArray[i] = r["JE"];
            }
            tbRow.Rows.Add(itemArray);

            this.dgvmx.DataSource = tbRow;
        }

        private void txtMzh_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnCX.PerformClick();
        }

        private void txtDNLSH_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnCX.PerformClick();
        }

        private void txtBrxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnCX.PerformClick();
        }
    }
}