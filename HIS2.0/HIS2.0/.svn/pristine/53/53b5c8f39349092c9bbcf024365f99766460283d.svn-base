using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using System.IO;
using Alias = ts_mz_class;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Xml;

namespace ts_yj_mzyj
{
    public partial class Frmyjqr : Form
    {
        /// <summary>
        /// 门诊医技模板 Add by Eric 2014-04-15
        /// </summary>
        private static string tempFile = "BarcodebyMZYJ.Trasen";
        /// <summary>
        /// 加载XML文档，展示文本按钮 Add by Eric 2014-04-15
        /// </summary>
        private static string xmlFile = "TrasenBarCodeOtherInfo1.xml";
        /// <summary>
        /// 模板文件 Add by Eric 2014-04-17
        /// </summary>
        private static string xmlFile1 = "TrasenBarCode1.XML";
        /// <summary>
        /// 呼叫次数
        /// </summary>
        private int CallCount = 0;
        /// <summary>
        /// 呼叫号码
        /// </summary>
        private int Num = 0;

        private Guid kdjid = Guid.Empty;
        private readonly Form _mdiParent;
        private readonly MenuTag _menuTag;
        private readonly string _chineseName;
        private readonly Guid ghxxid = Guid.Empty;
        private Guid brxxid = Guid.Empty;
        private SystemCfg cfg10013 = new SystemCfg(10013);
        private readonly SystemCfg cfg10014 = new SystemCfg(10014);
        private readonly SystemCfg syscfg7188 = new SystemCfg(7188);
        private readonly SystemCfg syscfg7217 = new SystemCfg(7217);
        public Frmyjqr(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            dataGridView1.AutoGenerateColumns = false;
        }
        #region 门诊医技代码
        private void btref_Click(object sender, EventArgs e)
        {

            try
            {
                cfg10013 = new SystemCfg(10013, InstanceForm.BDatabase);
                if (cfg10013.Config == "1")
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (txtkh.Text.Trim() != "")
                {
                    ReadCard card = new ReadCard(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
                    brxxid = card.brxxid;
                }
                else
                {
                    brxxid = Guid.Empty;
                }

                ParameterEx[] parameters = new ParameterEx[11];
                parameters[0].Text = "@execdept";
                parameters[0].Value = InstanceForm.BCurrentDept.DeptId;

                parameters[1].Text = "@blh";
                parameters[1].Value = txtmzh.Text.Trim();

                parameters[2].Text = "@brxxid";
                parameters[2].Value = brxxid;

                int lx = 0;
                if (rdo2.Checked == true) lx = 1;
                if (rdo3.Checked == true) lx = 2;

                parameters[3].Text = "@RQLX";
                parameters[3].Value = lx;

                parameters[4].Text = "@RQ1";
                parameters[4].Value = dtp1.Value.ToShortDateString() + " 00:00:00";

                parameters[5].Text = "@RQ2";
                parameters[5].Value = dtp2.Value.ToShortDateString() + " 23:59:59";

                parameters[6].Text = "@BRXM";
                parameters[6].Value = txtxm.Text.Trim();

                parameters[7].Text = "@FPH";
                parameters[7].Value = txtfph.Text.Trim();

                parameters[8].Text = "@jgbm";
                parameters[8].Value = Convert.ToInt64(cmbjgbm.SelectedValue);

                parameters[9].Text = "@tmdybz";
                parameters[9].Value = rdowdy.Checked == true ? 0 : 1;

                parameters[10].Text = "@btf";
                parameters[10].Value = chktfsq.Checked == true ? 1 : 0;

                using (DataSet dset = new DataSet())
                {
                    if (!chkLs.Checked)
                        InstanceForm.BDatabase.AdapterFillDataSet("SP_YJ_SELECT_MZ", parameters, dset, "sfmx", 30);
                    else
                        InstanceForm.BDatabase.AdapterFillDataSet("SP_YJ_SELECT_MZHIS", parameters, dset, "sfmx", 30);
                    Alias.Fun.AddRowtNo(dset.Tables[0]);
                    dataGridView1.DataSource = dset.Tables[0].DefaultView;
                    if (dset.Tables.Count > 1)
                    {
                        Alias.Fun.AddRowtNo(dset.Tables[1]);
                        dataGridView2.DataSource = dset.Tables[1];
                        panelxxx.Visible = true;
                    }
                    if (rdo2.Checked == true)
                    {
                        decimal je = Convert.ToDecimal(Convertor.IsNull(dset.Tables[0].Compute("sum(金额)", ""), "0"));
                        toolStripStatusLabel1.Text = "确认金额: " + je;
                    }
                    else
                        toolStripStatusLabel1.Text = "";
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butok_Click(object sender, EventArgs e)
        {

            DataTable tb = ((DataView)dataGridView1.DataSource).Table;
            if (tb == null)
                return;

            tb.AcceptChanges(); //add by wangzhi 2010-10-15 需要调用此方法，否则DataView不会与DataTable同步

            DataRow[] rows = tb.Select("选择=1");

            if (rows.Length == 0) return;

            int bqrbz;
            if (butok.Text == "取消确认(F2)")
                bqrbz = 0;
            else
                bqrbz = 1;

            if (bqrbz == 0 && MessageBox.Show("您确认要取消吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            int err_code = -1;
            string err_text = "";
            decimal sumje = 0;
            string mzh = txtmzh.Text.Trim();
            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    ParameterEx[] parameters = new ParameterEx[10];
                    parameters[0].Text = "@CFID";
                    parameters[0].Value = new Guid(rows[i]["CFID"].ToString());
                    parameters[1].Text = "@CFMXID";
                    parameters[1].Value = new Guid(rows[i]["CFMXID"].ToString());
                    parameters[2].Text = "@TCID";
                    parameters[2].Value = Convert.ToInt32(rows[i]["TCID"]);

                    parameters[3].Text = "@BQRBZ";
                    parameters[3].Value = bqrbz;
                    parameters[4].Text = "@QRKS";
                    parameters[4].Value = InstanceForm.BCurrentDept.DeptId;
                    parameters[5].Text = "@QRRQ";
                    parameters[5].Value = djsj;

                    parameters[6].Text = "@QRDJY";
                    parameters[6].Value = InstanceForm.BCurrentUser.EmployeeId;

                    parameters[7].Text = "@err_code";
                    parameters[7].ParaDirection = ParameterDirection.Output;
                    parameters[7].DataType = DbType.Int32;
                    parameters[7].ParaSize = 100;

                    parameters[8].Text = "@err_text";
                    parameters[8].ParaDirection = ParameterDirection.Output;
                    parameters[8].ParaSize = 100;
                    parameters[9].Text = "@YQRKS";
                    parameters[9].Value = Convert.ToInt32(rows[i]["QRKSID"]);
                    InstanceForm.BDatabase.GetDataTable("SP_YJ_SAVE_QRJL_MZ", parameters, 60);
                    err_code = Convert.ToInt32(parameters[7].Value);
                    err_text = Convert.ToString(parameters[8].Value);
                    if (err_code != 0) throw new Exception(err_text);
                    sumje = sumje + Convert.ToDecimal(rows[i]["金额"]);
                    if (mzh == "")
                        mzh = rows[i]["门诊号"].ToString();
                }

                InstanceForm.BDatabase.CommitTransaction();

                if (panelxxx.Visible == false)
                {
                    MessageBox.Show(String.Format("{0}   金额:{1}", err_text, sumje), "确认", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (txtkh.Enabled == true) txtkh.Focus(); else txtmzh.Focus();
                }

                int n = rows.Length;
                for (int i = 0; i <= n - 1; i++)
                    tb.Rows.Remove(rows[i]);

                Alias.Fun.AddRowtNo(tb);
            }
            catch (Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (panelxxx.Visible == false) return;
            //Modify by caicheng
            SystemCfg sys10017 = new SystemCfg(10017, InstanceForm.BDatabase);

            try
            {
                if (sys10017.Config.Trim() == "1")
                {
                    if (MessageBox.Show(String.Format("{0}   金额:{1},您进入打印处方审核模块吗?", err_text, sumje), "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        if (txtkh.Enabled == true) txtkh.Focus(); else txtmzh.Focus();
                        return;
                    }

                    object[] comValue = new object[3];
                    comValue[0] = cmbklx.SelectedValue.ToString();
                    comValue[1] = txtkh.Text.Trim();
                    comValue[2] = mzh;
                    Form f = ShowDllForm("ts_mzhs_cfcl", "Fun_ts_mzhs_cfcl", "处方管理", ref comValue, false);
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show(String.Format("{0}   金额:{1}", err_text, sumje), "确认", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (txtkh.Enabled == true) txtkh.Focus(); else txtmzh.Focus();
                    return;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //end Modify
        }

        private Form ShowDllForm(string dllName, string functionName, string chineseName, ref object[] communicateValue, bool showModule)
        {
            try
            {
                long menuId;
                menuId = _menuTag.ModuleId;
                //获得DLL中窗体
                Form dllForm = null;
                if (showModule)
                    dllForm = (Form)WorkStaticFun.InstanceForm(dllName, functionName, chineseName, InstanceForm.BCurrentUser, InstanceForm.BCurrentDept,
                        _menuTag, menuId, MdiParent, InstanceForm.BDatabase, ref communicateValue);
                else
                    dllForm = (Form)WorkStaticFun.InstanceForm(dllName, functionName, chineseName, InstanceForm.BCurrentUser, InstanceForm.BCurrentDept,
                        _menuTag, menuId, null, InstanceForm.BDatabase, ref communicateValue);
                return dllForm;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //begin add by wangzhi 2010-10-11 修改了原来排序后显示和后台数据不一致的BUG
            if (e.RowIndex == -1)
                return;
            if (dataGridView1.DataSource == null)
                return;
            DataView dv = (DataView)dataGridView1.DataSource;

            if (dv.Count == 0)
                return;

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int colIndex = dataGridView1.CurrentCell.ColumnIndex;
            short iSel = (short)0;

            if (dataGridView1.Columns[colIndex].Name == 选择.Name)
            {
                //单行选择
                iSel = Convert.IsDBNull(dv[rowIndex][选择.Name]) ? (short)0 : Convert.ToInt16(dv[rowIndex][选择.Name]);
                if (iSel == 1)
                    iSel = 0;
                else
                    iSel = 1;
                dv[rowIndex][选择.Name] = iSel;
            }
            else
            {
                //按处方选择
                string cfid = dv[rowIndex][CFID.Name].ToString();
                DataRow[] drs = dv.Table.Select(String.Format("cfid='{0}'", cfid));
                if (drs.Length != 0)
                {
                    iSel = Convert.IsDBNull(drs[0]["选择"]) ? (short)0 : Convert.ToInt16(drs[0]["选择"]);
                    if (iSel == 1)
                        iSel = 0;
                    else
                        iSel = 1;
                    foreach (DataRow dr in drs)
                        dr["选择"] = iSel;
                }
            }
        }

        private void Frmyjqr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Cursor.Current = PubStaticFun.WaitCursor();
                btref_Click(sender, e);
                Cursor.Current = Cursors.Default;
            }
            if (e.KeyCode == Keys.F2 && butok.Enabled == true)
            {
                butok_Click(sender, e);
            }

            if (e.KeyCode == Keys.F8)
            {
                buttxm_Click(sender, e);
            }
        }

        private void buthelp_Click(object sender, EventArgs e)
        {
            try
            {
                MenuTag tag = new MenuTag();
                tag = _menuTag;
                using (ts_mz_kgl.Frmbrxxcx f = new ts_mz_kgl.Frmbrxxcx(tag, "病人查询", null))
                {
                    f.txtbrxm.Text = txtxm.Text;
                    if (txtxm.Text.Trim() == "")
                        f.chkdjsj.Checked = true;
                    f.txtbrxm.Focus();
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                    ReadCard card = new ReadCard(f.return_kdjid, InstanceForm.BDatabase);
                    txtkh.Text = card.kh.Trim();
                    cmbklx.SelectedValue = card.klx.ToString();
                }
                txtkh_KeyPress(sender, new KeyPressEventArgs((Char)Keys.Enter));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            //brxxid = Guid.Empty;
            if ((int)e.KeyChar != 13) return;
            Control control = (Control)sender;
            if (control.Name == "txtkh")
            {
                txtkh.Text = Alias.Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
                txtkh.SelectAll();
                txtmzh.Text = "";
            }
            if (control.Name == "txtmzh")
            {
                txtmzh.Text = Alias.Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                txtmzh.SelectAll();
                txtkh.Text = "";
            }
            btref_Click(sender, e);
            /*if (new SystemCfg(10021).Config == "1")
            {
                if (txtkh.Text.Trim() != "")
                {
                    ReadCard card = new ReadCard(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
                    kdjid = card.kdjid;
                    brxxid = card.brxxid;
                }
                if (IsHaveWsfcf())
                {
                    //MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                    //DialogResult dr = MessageBox.Show("该患者存在未扣费项目是否进行扣费?", "提示", messButton);
                    //if (dr == DialogResult.OK)
                    //{
                    Frmyssyk frmAction = new Frmyssyk(InstanceForm.BCurrentDept.DeptId, brxxid.ToString(), strGhxxid.ToString(), txtmzh.Text.Trim(), txtkh.Text.Trim(), InstanceForm.BDatabase, _menuTag, "科室扣费", _mdiParent);
                    frmAction.Show();
                    //}
                }
                btref_Click(sender, e);
            }*/
        }

        private string strGhxxid;
        /// <summary>
        /// 判断是否存在未收费处方
        /// </summary>
        /// <returns></returns>
        private bool IsHaveWsfcf()
        {
            string sql = @"select    a.BLH 门诊号,b.BRXM 姓名,dbo.fun_getDeptname(a.GHKS)挂号科室,a.GHSJ 挂号时间, d.KLXMC 卡类型,c.KLX,
                            (select name from JC_BRLX where CODE=b.BRLX) 病人类型,
                             c.KH 卡号,c.KYE 卡余额, a.ghxxi05015019d,b.brxxid ,b.BRLX
                            from MZ_GHXX a  
                            left join YY_BRXX b on a.BRXXID=b.BRXXID 
                            left join YY_KDJB c on a.KDJID=c.KDJID 
                            inner join JC_KLX d on c.KLX=d.KLX where 1=1 ";
            if (!string.IsNullOrEmpty(brxxid.ToString()))
                sql += " and a.brxxid='" + brxxid + "'";
            DataTable tbcx = InstanceForm.BDatabase.GetDataTable(sql);

            //DataTable tbcx = mz_ghxx.GetGhxxByCard(kdjid, "", false, true, 0, InstanceForm.BDatabase);
            if (tbcx.Rows.Count == 0)
            {
                return false;
            }
            DataRow row = null;
            if (tbcx.Rows.Count == 1)
            {
                strGhxxid = tbcx.Rows[0]["ghxxid"].ToString();
            }
            else
            {
                Frmghjl f = new Frmghjl(_menuTag, _chineseName, _mdiParent);
                tbcx.TableName = "tb";
                f.dataGridView1.DataSource = tbcx;
                f.ShowDialog();
                if (f.Bok == false) return false;
                row = f.ReturnRow;
                strGhxxid = row["ghxxid"].ToString();
            }
            // strGhxxid = Fun.GetLastGhxxid(brxxid, InstanceForm.BDatabase);
            DataTable tb = mz_sf.Select_Wsfcf(InstanceForm.BCurrentDept.DeptId, brxxid, new Guid(strGhxxid), 0, 0, Guid.Empty, InstanceForm.BDatabase);
            if (tb.Rows.Count > 0) return true;
            else return false;
        }

        private void Frmyjqr_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Alias.FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            //解决多院刷新报错问题 add by cc 
            Alias.FunAddComboBox.AddJgbm(false, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = InstanceForm._menuTag.Jgbm;
            cmbjgbm.SelectedIndexChanged += new EventHandler(cmbjgbm_SelectedIndexChanged);
            //end add 

            SystemCfg sys10010 = new SystemCfg(10010, InstanceForm.BDatabase);
            if (sys10010.Config.Trim() != "")
            {
                string[] sArray = sys10010.Config.Split(new char[1] { ',' });
                for (int j = 0; j <= sArray.Length - 1; j++)
                {
                    if (InstanceForm.BCurrentDept.DeptId.ToString() == Convertor.IsNull(sArray[j], ""))
                        butok.Enabled = false;
                }
            }
            buttf.Enabled = false;
            SystemCfg sysrq = new SystemCfg(10007, InstanceForm.BDatabase);
            dtp1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(Convert.ToInt32(sysrq.Config) * (-1));

            dataGridView1.Paint += dataGridView1_Paint;

            string Bkh = ApiFunction.GetIniString("划价收费", "卡号优先获得焦点", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (Bkh == "true")
                txtkh.Focus();
            else
                txtmzh.Focus();

            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
            ForbidSortColumn(dataGridView2);

            try
            {
                btnOpen.Visible = new SystemCfg(7188).Config == "1" ? true : false;
            }
            catch { btnOpen.Visible = false; }
            btref_Click(null, null);
            this.Refresh();
        }

        void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (!Convert.IsDBNull(dataGridView1[选择.Name, i].Value))
                {
                    if (Convert.ToInt32(dataGridView1[选择.Name, i].Value) == 1)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                        continue;
                    }

                }
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable tb = ((DataView)dataGridView1.DataSource).Table;
            Control control = (Control)sender;
            if (control.Name == "rdo1" && rdo1.Checked == true)
            {
                lblrq.Text = "收费日期";
                butok.Enabled = true;
                buttf.Enabled = false;
                butok.Text = "确认(F2)";
                if (txtkh.Text.Trim() != "" || txtmzh.Text.Trim() != "" || txtfph.Text.Trim() != "" || txtxm.Text.Trim() != "")
                    btref_Click(sender, e);
                else
                {
                    if (tb != null) tb.Rows.Clear();
                }
            }
            if (control.Name == "rdo2" && rdo2.Checked == true)
            {
                //dtp1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                lblrq.Text = "确认日期";
                butok.Enabled = true;
                if (_menuTag.Function_Name == "Fun_ts_yj_mzyj_all")
                    buttf.Enabled = true;
                else
                    buttf.Enabled = false;
                butok.Text = "取消确认(F2)";
                if (txtkh.Text.Trim() != "" || txtmzh.Text.Trim() != "" || txtfph.Text.Trim() != "" || txtxm.Text.Trim() != "")
                    btref_Click(sender, e);
                else
                {
                    if (tb != null) tb.Rows.Clear();
                }

                if (new SystemCfg(10008, InstanceForm.BDatabase).Config == "1" && _menuTag.Function_Name != "Fun_ts_yj_mzyj_all")
                    butok.Enabled = false;
            }
            if (control.Name == "rdo3" && rdo3.Checked == true)
            {
                lblrq.Text = "确认日期";
                butok.Enabled = false;
                buttf.Enabled = false;
                if (txtkh.Text.Trim() != "" || txtmzh.Text.Trim() != "" || txtfph.Text.Trim() != "" || txtxm.Text.Trim() != "")
                    btref_Click(sender, e);
                else
                {
                    if (tb != null) tb.Rows.Clear();
                }
            }

            SystemCfg sys10010 = new SystemCfg(10010, InstanceForm.BDatabase);
            if (sys10010.Config.Trim() != "")
            {
                string[] sArray = sys10010.Config.Split(new char[1] { ',' });
                for (int j = 0; j <= sArray.Length - 1; j++)
                {
                    if (InstanceForm.BCurrentDept.DeptId.ToString() == Convertor.IsNull(sArray[j], ""))
                        butok.Enabled = false;
                }
            }
        }

        private void buttf_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("请先按条件查询出结果并指定要退费的记录！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable tb = ((DataView)dataGridView1.DataSource).Table;
            if (tb == null)
                return;
            tb.AcceptChanges(); //add by wangzhi 2010-10-15 需要调用此方法，否则DataView不会与DataTable同步 
            DataRow[] rows = tb.Select("选择=1");
            if (rows.Length == 0) return;
            const int bqrbz = 2;
            if (MessageBox.Show("您确认同意退费吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            int err_code = -1;
            string err_text = "";
            decimal sumje = 0;
            try
            {
                InstanceForm.BDatabase.BeginTransaction();
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    ParameterEx[] parameters = new ParameterEx[10];
                    parameters[0].Text = "@CFID";
                    parameters[0].Value = new Guid(rows[i]["CFID"].ToString());
                    parameters[1].Text = "@CFMXID";
                    parameters[1].Value = new Guid(rows[i]["CFMXID"].ToString());
                    parameters[2].Text = "@TCID";
                    parameters[2].Value = Convert.ToInt32(rows[i]["TCID"]);
                    parameters[3].Text = "@BQRBZ";
                    parameters[3].Value = bqrbz;
                    parameters[4].Text = "@QRKS";
                    parameters[4].Value = InstanceForm.BCurrentDept.DeptId;
                    parameters[5].Text = "@QRRQ";
                    parameters[5].Value = djsj;

                    parameters[6].Text = "@QRDJY";
                    parameters[6].Value = InstanceForm.BCurrentUser.EmployeeId;

                    parameters[7].Text = "@err_code";
                    parameters[7].ParaDirection = ParameterDirection.Output;
                    parameters[7].DataType = DbType.Int32;
                    parameters[7].ParaSize = 100;

                    parameters[8].Text = "@err_text";
                    parameters[8].ParaDirection = ParameterDirection.Output;
                    parameters[8].ParaSize = 100;

                    parameters[9].Text = "@YQRKS";
                    parameters[9].Value = Convert.ToInt32(rows[i]["QRKSID"]);

                    InstanceForm.BDatabase.GetDataTable("SP_YJ_SAVE_QRJL_MZ", parameters, 60);
                    err_code = Convert.ToInt32(parameters[7].Value);
                    err_text = Convert.ToString(parameters[8].Value);
                    if (err_code != 0) throw new Exception(err_text);

                    sumje = sumje + Convert.ToDecimal(rows[i]["金额"]);
                }

                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show(String.Format("{0}   金额:{1}", err_text, sumje), "确认", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbjgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                InstanceForm.BDatabase = WorkStaticFun.GetJgbmDb(Convert.ToInt32(cmbjgbm.SelectedValue));

                btref_Click(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable dv = (DataTable)dataGridView2.DataSource;
                int rowIndex = dataGridView2.CurrentCell.RowIndex;
                int colIndex = dataGridView2.CurrentCell.ColumnIndex;
                short iSel = (short)0;

                if (dataGridView2.Columns[colIndex].HeaderText == 选择.Name)
                {
                    //单行选择
                    iSel = Convert.IsDBNull(dv.Rows[rowIndex]["选择"]) ? (short)0 : Convert.ToInt16(dv.Rows[rowIndex]["选择"]);
                    string txm = dv.Rows[rowIndex]["条码"].ToString();
                    if (iSel == 1)
                        iSel = 0;
                    else
                        iSel = 1;

                    if (txm == "")
                        dv.Rows[rowIndex]["选择"] = iSel;

                    else
                    {
                        for (int i = 0; i <= dv.Rows.Count - 1; i++)
                        {
                            if (dv.Rows[i]["条码"].ToString() == txm)
                                dv.Rows[i]["选择"] = iSel;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //打印条码
        private void buttxm_Click(object sender, EventArgs e)
        {
            //Add by Eric 2014-04-17 兼容旧的设计模板文件
            TrasenCommon.OperateXML.CompatibilityXMLFile(xmlFile1, xmlFile, tempFile);

            List<DataRow> list = new List<DataRow>();
            try
            {
                DataTable tb = (DataTable)dataGridView2.DataSource;

                //条形码
                DataRow[] sel = tb.Select("  选择=true ");
                if (sel.Length == 0) return;

                string sqsj = "";
                string strColor = "";
                //汇总当前的分类
                string[] GroupbyField1 ={ "BRXXID" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                DataTable tab = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, " 选择=true");
                if (tab.Rows.Count > 1)
                {
                    MessageBox.Show("您选择了不同的病人,请重新选择", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow[] sel_x = tb.Select(" 选择=true and 条码<>''");
                if (sel_x.Length > 0)
                {
                    if (cfg10014.Config == "1")
                    {
                        MessageBox.Show("您选择的项目可能已打印,请重新选择", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("您选择的项目可能已打印,您确定要重新生成新的条码吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;
                    }
                }

                #region
                ////汇总当前的分类
                //string[] GroupbyField2 ={ "标本" };
                //string[] ComputeField2 ={ };
                //string[] CField2 ={ };
                //TrasenFrame.Classes.TsSet xcset2 = new TrasenFrame.Classes.TsSet();
                //xcset2.TsDataTable = tb;
                //DataTable tab2 = xcset1.GroupTable(GroupbyField2, ComputeField2, CField2, " 选择=true and 标本<>''");
                //if (tab2.Rows.Count > 1)
                //{
                //    if (MessageBox.Show("您选择的项目可能使用不同的标本,您确定吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                //}
                #endregion

                //汇总当前的分类
                string[] GroupbyField3 ={ "组号" };
                string[] ComputeField3 ={ };
                string[] CField3 ={ };
                TsSet xcset3 = new TsSet();
                xcset3.TsDataTable = tb;
                DataTable tab3 = xcset3.GroupTable(GroupbyField3, ComputeField3, CField3, " 选择=true");
                for (int X = 0; X <= tab3.Rows.Count - 1; X++)
                {
                    sel = tb.Select(String.Format(" 选择=true and isnull(组号,'')='{0}'", Convertor.IsNull(tab3.Rows[X]["组号"], "")));
                    string Sorderid = " ('";
                    for (int i = 0; i <= sel.Length - 1; i++)
                        Sorderid = String.Format("{0}{1}','", Sorderid, sel[i]["yjsqid"]);
                    Sorderid = String.Format("{0}{1}')", Sorderid, Guid.Empty);

                    Random a = new Random(DateTime.Now.Millisecond);
                    long Norderid = a.Next(111111111, 990000000) + a.Next(1, 9999999);

                    // Modify by caicheng 
                    string ssql = "update JC_IDENTITY WITH (ROWLOCK) set no=no+1 where rowtype=10";
                    //end Modify
                    InstanceForm.BDatabase.DoCommand(ssql);

                    if (syscfg7217.Config != "1")
                    {
                        ssql = "select '9'+left('00000000',8-len([NO]))+cast([no] as varchar(30)) from JC_IDENTITY where rowtype=10";
                        Norderid = Convert.ToInt64(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(ssql), Norderid.ToString()));
                    }
                    else
                    {

                        ssql = "select '" + TrasenFrame.Forms.FrmMdiMain.JgYybm.ToString() + "9'+left('00000000',7-len([NO]))+cast([no] as varchar(30)) from JC_IDENTITY where rowtype=10";
                        Norderid = Convert.ToInt64(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(ssql), Norderid.ToString()));
                    }
                    //Modify by caicheng
                    ssql = string.Format("INSERT INTO dbo.jc_lock ( no, type, crsj )  VALUES  ( " + Norderid.ToString() + ",   10,   GETDATE())");
                    InstanceForm.BDatabase.DoCommand(ssql);
                    //end Modify

                    //将条形码更新到申请表
                    string hostname = System.Net.Dns.GetHostName();
                    string sql = String.Format("update yj_mzsq set txm='{0:000000000}',TXMDYJQ='{1}',TXMDYSJ=getdate(),DYSJ=getdate() where yjsqid in {2}  ", Norderid, hostname, Sorderid);
                    int iii = InstanceForm.BDatabase.DoCommand(sql, 30);

                    if (iii != sel.Length)
                        throw new Exception("数据可能在别处已被更新，请重新刷新数据");
                    //同一组的条码一样
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        if (Convert.ToInt16(tb.Rows[i]["选择"]) == 1 && tb.Rows[i]["组号"].ToString() == tab3.Rows[X]["组号"].ToString())
                            tb.Rows[i]["条码"] = Norderid.ToString("000000000");
                    }


                    ts_yj_tjbb.DataSet1 Dset = new ts_yj_tjbb.DataSet1();
                    DataRow myrow;

                    string xm = "";
                    string xmcx = "";//重新的长度为7的字符串
                    DataRow[] selrow = tb.Select(String.Format(" 条码='{0:000000000}'", Norderid));
                    for (int i = 0; i <= selrow.Length - 1; i++)
                    {
                        myrow = Dset.txmdy.NewRow();
                        myrow["条形码"] = Norderid.ToString("000000000");
                        myrow["条形码图片"] = ReturnImagesByte(Norderid);
                        myrow["住院号"] = selrow[i]["门诊号"].ToString();
                        myrow["姓名"] = selrow[i]["姓名"].ToString();
                        myrow["性别"] = selrow[i]["性别"].ToString();
                        myrow["年龄"] = selrow[i]["年龄"].ToString();
                        myrow["科室"] = selrow[i]["科室"].ToString();
                        myrow["病区"] = InstanceForm.BCurrentDept.WardName;
                        myrow["床号"] = selrow[i]["COLOR"].ToString();
                        myrow["标本"] = Convertor.IsNull(selrow[i]["标本"], "").Trim();
                        myrow["项目分类"] = selrow[i]["检验类型"].ToString();
                        xmcx = selrow[i]["项目名称"].ToString();
                        xm += xmcx.Trim() + "  ";
                        //modify by caicheng 
                        sqsj = selrow[i]["申请时间"].ToString();
                        myrow["项目内容"] = selrow[i]["项目名称"];
                        myrow["申请医生"] = "";
                        myrow["申请日期"] = sqsj.Split(' ')[0];
                        myrow["数量"] = selrow[i]["数量"].ToString();
                        myrow["单位"] = selrow[i]["单位"].ToString();
                        myrow["金额"] = selrow[i]["金额"].ToString();
                        myrow["xmmc"] = xm;
                        strColor = selrow[i]["COLOR"].ToString();
                        Dset.txmdy.Rows.Add(myrow);
                        list.Add(myrow);
                    }

                    ParameterEx[] parameters = new ParameterEx[4];
                    parameters[0].Text = "医院名称";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;
                    parameters[1].Text = "打印者";
                    parameters[1].Value = InstanceForm.BCurrentUser.Name;
                    parameters[2].Text = "xmmc";
                    parameters[2].Value = xm;
                    parameters[3].Text = "备注";
                    parameters[3].Value = "";

                    bool bview = chkview.Checked == true ? false : true;
                    string _printerName = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select printername from jc_reportpaper where reportname='MZ_检验单申请条码'"), "");// "在 WIND 上自动 Microsoft XPS Document Writer";// 

                    //add by yaokx 2014-03-14 条码打印
                    if (syscfg7188.Config == "2")
                    {

                        DataTable dtTemp = Dset.txmdy.Copy();
                        dtTemp.Clear();
                        dtTemp.Rows.Add(Dset.txmdy.Rows[Dset.txmdy.Rows.Count - 1].ItemArray);
                        Creating_Barcode.Barcode b = new Creating_Barcode.Barcode();

                        DataTable dt = GetTMTable(1, dtTemp, 0);
                        if (dt.Rows.Count > 0)
                        {
                             b.PrintBarcodeMore(dt, bview, 1); 
                           
                            //b.PrintBarcodeMore(dt, bview, tempFile);
                        }
                    }
                    else
                        if (syscfg7188.Config == "1")
                        {
                            DataTable dataTable4 = Dset.txmdy.Copy();
                            dataTable4.Clear();
                            dataTable4.Rows.Add(Dset.txmdy.Rows[Dset.txmdy.Rows.Count - 1].ItemArray);
                            Creating_Barcode.Barcode barcode = new Creating_Barcode.Barcode();
                            DataTable tMTable = this.GetTMTable(1, dataTable4, 0);
                            if (tMTable.Rows.Count > 0)
                            {
                                 barcode.PrintBarcodeMore(tMTable, bview, 1); 
                            }



                        }
                        else
                        {
                            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.txmdy, Constant.ApplicationDirectory + "\\report\\MZ_检验单申请条码.rpt", parameters, bview, _printerName);
                            if (f.LoadReportSuccess)
                                f.Show();
                            else
                                f.Dispose();
                        }
                    DataRow[] selrowx = tb.Select(String.Format(" 条码='{0:000000000}'", Norderid));
                    for (int i = 0; i <= selrowx.Length - 1; i++)
                        selrowx[i]["选择"] = (short)0;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                Control control = (Control)sender;
                if (control.Name == "txtkh")
                {
                    txtkh.Text = Alias.Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
                    txtkh.SelectAll();
                    txtmzh.Text = "";
                }
                if (control.Name == "txtmzh")
                {
                    txtmzh.Text = Alias.Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                    txtmzh.SelectAll();
                    txtkh.Text = "";
                }
                btref_Click(sender, e);
                txtkh.Focus();
            }
        }

        private DataTable GetTMTable(int printnum, DataTable tabJYSQD, int type)
        {

            if (tabJYSQD.Rows.Count < 1) return new DataTable();
            #region 处理条码相同的情况
            DataTable dtSqd_xmzh = tabJYSQD.Copy();
            if (dtSqd_xmzh.Columns.Contains("条形码图片"))
            {
                dtSqd_xmzh.Columns.Remove("条形码图片");
            }
            for (int i = dtSqd_xmzh.Rows.Count - 1; i >= 0; i--)
            {
                if (i > dtSqd_xmzh.Rows.Count - 1)
                {
                    i = dtSqd_xmzh.Rows.Count - 1;
                }
                DataRow dr = dtSqd_xmzh.Rows[i];
                string txm = dr["条形码"].ToString();
                DataView dv = new DataView(dtSqd_xmzh, "条形码='" + txm + "'", "", DataViewRowState.CurrentRows);
                if (dv.Count > 1)
                {
                    for (int j = dv.Count - 1; j > 0; j--)
                    {
                        dtSqd_xmzh.Rows.Remove(dv[j].Row);
                    }
                }
            }
            #endregion
            DataTable dt = GetTMTableStruct(dtSqd_xmzh.Rows[0], type);
            for (int i = 0; i < dtSqd_xmzh.Rows.Count; i++)
            {
                DataRow drnew = GetTMTableOneRow(dt, printnum, dtSqd_xmzh.Rows[i], type);
                dt.Rows.Add(drnew);
            }
            return dt;
        }

        private DataRow GetTMTableOneRow(DataTable dt, int printnum, DataRow dr, int type)
        {

            DataRow drr = dt.NewRow();
            drr["barcode"] = dr["条形码"].ToString();
            drr["printnum"] = printnum;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string s = dt.Columns[i].ColumnName;
                if (s != "barcode" && s != "printnum")
                {
                    for (int a = 0; a < dr.Table.Columns.Count; a++)
                    {
                        if (dt.Columns[i].ColumnName == dr.Table.Columns[a].ColumnName)
                        {
                            drr[dt.Columns[i].ColumnName] = dr[a].ToString();
                            break;
                        }
                    }
                }

            }
            if (type == 1)
            {
                drr["bd"] = "补打";
            }
            return drr;
        }

        private DataTable GetTMTableStruct(DataRow dr, int type)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("barcode");
            dt.Columns.Add("printnum");
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                dt.Columns.Add(dr.Table.Columns[i].ColumnName);
            }
            if (type == 1)
            {
                dt.Columns.Add("bd");
            }
            return dt;
        }

        private byte[] ReturnImagesByte(long Txm)
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode(Txm.ToString("000000000"), BarcodeLib.TYPE.CODE128);
            Image im = b.Encode();
            b.SaveImage("c:\\条码.JPG", BarcodeLib.SaveTypes.JPG);
            MemoryStream ms = new MemoryStream();
            im.Save(ms, ImageFormat.Jpeg);
            byte[] bytes = ms.ToArray();
            //new byte[ms.Length];
            //ms.Write(bytes, 0, (int)ms.Length);
            //return bytes;
            return bytes;
        }

        private static void toText(string FILE_NAME, string text)
        {
            if (File.Exists(FILE_NAME))
            {
                using (StreamWriter sw = File.AppendText(FILE_NAME))
                {
                    sw.WriteLine(text + "\n");
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                StreamWriter sr = File.CreateText(FILE_NAME);
                sr.Close();
            }
        }

        private void butbd_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataRow> list = new List<DataRow>();
                DataTable tb = (DataTable)dataGridView2.DataSource;

                //条形码条形码条形码条形码条形码条形码条形码条形码
                DataRow[] sel = tb.Select("  选择=true and 条码<>'' ");
                if (sel.Length == 0) return;

                //汇总当前的分类
                string[] GroupbyField1 ={ "条码" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                DataTable tab = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, " 选择=true and 条码<>''");
                if (tab.Rows.Count > 1)
                {
                    MessageBox.Show("您选择了不同的条形码,请重新选择", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ts_yj_tjbb.DataSet1 Dset = new ts_yj_tjbb.DataSet1();
                DataRow myrow;

                string xm = "";
                string xmcx = "";//重新的长度为7的字符串 
                DataRow[] selrow = tb.Select(" 选择=true and 条码<>'' ");
                for (int i = 0; i <= selrow.Length - 1; i++)
                {
                    myrow = Dset.txmdy.NewRow();
                    myrow["条形码"] = selrow[i]["条码"].ToString();
                    myrow["条形码图片"] = ReturnImagesByte(Convert.ToInt64(selrow[i]["条码"].ToString()));
                    myrow["住院号"] = selrow[i]["门诊号"].ToString();
                    myrow["姓名"] = selrow[i]["姓名"].ToString();
                    myrow["性别"] = selrow[i]["性别"].ToString();
                    myrow["年龄"] = selrow[i]["年龄"].ToString();
                    myrow["科室"] = selrow[i]["科室"].ToString();
                    myrow["病区"] = InstanceForm.BCurrentDept.WardName;
                    myrow["床号"] = selrow[i]["COLOR"].ToString();
                    myrow["标本"] = Convertor.IsNull(selrow[i]["标本"], "").Trim();
                    myrow["项目分类"] = selrow[i]["检验类型"].ToString();
                    xmcx = selrow[i]["项目名称"].ToString();
                    xm += xmcx.Trim() + "  ";
                    myrow["项目内容"] = selrow[i]["项目名称"];
                    myrow["申请医生"] = "";
                    myrow["申请日期"] = selrow[i]["申请时间"].ToString().Split(' ')[0];
                    myrow["数量"] = selrow[i]["数量"].ToString();
                    myrow["单位"] = selrow[i]["单位"].ToString();
                    myrow["金额"] = selrow[i]["金额"].ToString();
                    myrow["xmmc"] = xm;
                    Dset.txmdy.Rows.Add(myrow);
                    list.Add(myrow);
                    string hostname = System.Net.Dns.GetHostName();
                    string sql = String.Format("update yj_mzsq set TXMDYJQ='{0}',TXMDYSJ=getdate() where yjsqid = '{1}'", hostname, selrow[i]["yjsqid"]);
                    int iii = InstanceForm.BDatabase.DoCommand(sql, 30);

                }

                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "医院名称";
                parameters[0].Value = Constant.HospitalName;
                parameters[1].Text = "打印者";
                parameters[1].Value = InstanceForm.BCurrentUser.Name;
                parameters[2].Text = "xmmc";
                parameters[2].Value = xm;
                parameters[3].Text = "备注";
                parameters[3].Value = "补打";
                bool bview = chkview.Checked == true ? false : true;
                string _printerName = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select printername from jc_reportpaper where reportname='MZ_检验单申请条码'"), "");// "在 WIND 上自动 Microsoft XPS Document Writer";// 
                //add by yaokx 2014-03-14 条码打印
                if (syscfg7188.Config == "1")
                {

                    DataTable dtTemp = Dset.txmdy.Copy();
                    dtTemp.Clear();
                    dtTemp.Rows.Add(Dset.txmdy.Rows[Dset.txmdy.Rows.Count - 1].ItemArray);
                    Creating_Barcode.Barcode b = new Creating_Barcode.Barcode();

                    DataTable dt = GetTMTable(1, dtTemp, 1);
                    if (dt.Rows.Count > 0)
                    {
                         b.PrintBarcodeMore(dt, bview, 1); 
                    }
                }
                else
                {
                    FrmReportView f = new FrmReportView(Dset.txmdy, Constant.ApplicationDirectory + "\\report\\MZ_检验单申请条码.rpt", parameters, bview, _printerName);
                    if (f.LoadReportSuccess) f.Show(); else f.Dispose();
                }
                //测试
                DataRow[] selrowx = tb.Select(" 选择=true and 条码<>'' ");
                for (int i = 0; i <= selrowx.Length - 1; i++)
                    selrowx[i]["选择"] = (short)0;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                //modify by caicheng
                Control control = (Control)sender;
                if (control.Name == "txtkh")
                {
                    txtkh.Text = Alias.Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
                    txtkh.SelectAll();
                    txtmzh.Text = "";
                }
                if (control.Name == "txtmzh")
                {
                    txtmzh.Text = Alias.Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                    txtmzh.SelectAll();
                    txtkh.Text = "";
                }
                btref_Click(sender, e);
                txtkh.Focus();
            }
        }

        private void rdowdy_CheckedChanged(object sender, EventArgs e)
        {
            btref_Click(sender, e);
            //modify by caicheng 20140330
            //SystemCfg sys10016 = new SystemCfg(10016, InstanceForm.BDatabase); 
            if (cfg10014.Config.Trim() == "0")
            {
                btnAgain.Enabled = rdowdy.Checked == true ? false : true;
            }
            //end Modify
            butbd.Enabled = rdowdy.Checked == true ? false : true;
            buttxm.Enabled = rdowdy.Checked == true ? true : false;
            if (rdowdy.Checked == true)
                groupBox2.Enabled = false;
            else
                groupBox2.Enabled = true;
        }

        /// <summary>
        /// 重编 modify by cc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgain_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dataGridView2.DataSource;
                tb.AcceptChanges();
                DataRow[] sel = tb.Select("选择=1");
                if (sel.Length == 0) return;
                for (int i = 0; i <= sel.Length - 1; i++)
                {
                    string yjsqid = string.Empty;
                    string bqsbz = string.Empty;
                    bqsbz = sel[i]["BQSBZ"].ToString();
                    if (bqsbz == "1")
                    {
                        MessageBox.Show("该记录已经签收！");
                        //this.dataGridView2.Rows[i].Cells["选择"].Value = "0";
                        dataGridView2.Rows[i].Cells["选择"].Selected = true;
                        break;
                    }
                    yjsqid = sel[i]["yjsqid"].ToString();

                    string strSql = string.Format(@" update yj_mzsq set TXM=null,TXMDYJQ=null,TXMDYSJ=null ,BTXMDYBZ=0 where yjsqid='{0}'", yjsqid);
                    int iii = InstanceForm.BDatabase.DoCommand(strSql, 30);
                    ts_jc_log.His_Log.SaveLog("医技管理—重编门诊检验单条形码", "重编门诊检验单条形码成功", FrmMdiMain.CurrentDept.Default, FrmMdiMain.CurrentUser.EmployeeId, InstanceForm.BDatabase);
                }
                Control control = (Control)sender;
                if (control.Name == "txtkh")
                {
                    txtkh.Text = Alias.Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
                    txtkh.SelectAll();
                    txtmzh.Text = "";
                }
                if (control.Name == "txtmzh")
                {
                    txtmzh.Text = Alias.Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                    txtmzh.SelectAll();
                    txtkh.Text = "";
                }
                btref_Click(sender, e);
            }
            catch (Exception ex)
            {
                ts_jc_log.His_Log.SaveLog("医技管理—重编门诊检验单条形码", ex.Message, FrmMdiMain.CurrentDept.Default, FrmMdiMain.CurrentUser.EmployeeId, InstanceForm.BDatabase);
            }
        }

        /// <summary>
        /// 禁止列头排序
        /// </summary>
        /// <param name="dgv"></param>
        private static void ForbidSortColumn(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void mitemShowCzrz_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            string cfid = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["CFID"].Value.ToString();
            string cfmxid = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["CFMXID"].Value.ToString();
            string tcid = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["TCID"].Value.ToString();
            if (string.IsNullOrEmpty(cfid) || string.IsNullOrEmpty(cfmxid) || string.IsNullOrEmpty(tcid)) return;
            new FrmShowLog(cfid, cfmxid, Convert.ToInt16(tcid)).Show();
        }

        /// <summary>
        /// 打开条码设计器 Add by Eric 2014-04-15
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            TrasenCommon.OperateXML.CompatibilityXMLFile(xmlFile1, xmlFile, tempFile);

            ts_BarCodeDesigner.FrmMain main = new ts_BarCodeDesigner.FrmMain(tempFile, xmlFile);
            main.Show();
        }

        /// <summary>
        /// 单元格值改变事件 --Add by Eric 2014-04-16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.DataSource != null)
            {
                int rowIndex = e.RowIndex;
                int colIndex = e.ColumnIndex;
                try
                {
                    if (dataGridView2.Columns[colIndex].HeaderText == 标本采集时间.Name)
                    {
                        if (FrmMdiMain.Database.GetDataResult(string.Format("select BQSBZ from yj_mzsq where yjsqid ='{0}'"
                              , dataGridView2["yjsqid", rowIndex].Value.ToString())).ToString() == "0")//判断标本签收状态
                        {
                            if (!string.IsNullOrEmpty(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                            {
                                //DateTime.Parse(dataGridView2.EditingControl.Text);
                                string strSql = string.Format(@" update yj_mzsq set BBCJSJ='{0}' where yjsqid='{1}'",
                                    dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),
                                     dataGridView2["yjsqid", rowIndex].Value.ToString());
                                int iii = InstanceForm.BDatabase.DoCommand(strSql, 30);
                            }
                        }
                        else
                        {
                            dataGridView2.EditingControl.Text = "";
                        }
                    }
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// 单元格鼠标双击时间 --Add by Eric 2014-04-16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dataGridView1.DataSource != null)
            {
                int rowIndex = e.RowIndex;
                int colIndex = e.ColumnIndex;
                if (dataGridView2.Columns[colIndex].HeaderText == 标本采集时间.Name)
                {
                    if (FrmMdiMain.Database.GetDataResult(string.Format("select BQSBZ from yj_mzsq where yjsqid ='{0}'"
                          , dataGridView2["yjsqid", rowIndex].Value.ToString())).ToString() == "0")//判断标本签收状态
                    {
                        if (dataGridView2[colIndex, rowIndex].Value != null)
                        {
                            if (string.IsNullOrEmpty(dataGridView2[colIndex, rowIndex].Value.ToString()))
                            {
                                dataGridView2[colIndex, rowIndex].Value = DateTime.Now.ToString();
                                string strSql = string.Format(@" update yj_mzsq set BBCJSJ='{0}' where yjsqid='{1}'",
                                    DateTime.Now.ToString(),
                                     dataGridView2["yjsqid", rowIndex].Value.ToString());
                                int iii = InstanceForm.BDatabase.DoCommand(strSql, 30);
                            }
                        }
                    }
                }
                if (dataGridView2.Columns[colIndex].HeaderText == 标本采集时间.Name)
                {
                    FrmDt dt = new FrmDt();
                    dt.ShowDialog();
                    if (dt.DialogResult == DialogResult.OK)
                    {
                        this.dataGridView2.Rows[e.RowIndex].Cells["标本采集时间"].Value = dt.dt;
                    }
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, this.Text);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convertor.IsNull(row.Cells["CLZT"].Value, "").IndexOf("加急") >= 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        /// <summary>
        /// 修改标本采集、交接时间 --Add By Daniel 2015-02-03
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butxgsj_Click(object sender, EventArgs e)
        {
            int num = 0;
            try
            {
                DataTable table = (DataTable)dataGridView2.DataSource;
                if (table == null) return;
                DataRow[] rows = table.Select("选择=true");
                if (rows.Length == 0)
                    return;
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    string yjsqid = string.Empty;
                    string sqlStr = "";
                    yjsqid = rows[i]["yjsqid"].ToString();
                    sqlStr = string.Format(@"select TXM from YJ_MZSQ where YJSQID='{0}'", yjsqid);
                    DataTable tb = InstanceForm.BDatabase.GetDataTable(sqlStr);
                    string _txm = tb.Rows[0]["TXM"].ToString();
                    if (rdoydy.Checked == false)
                        groupBox2.Enabled = false;
                    if (rdoydy.Checked == true)
                    {
                        if (!string.IsNullOrEmpty(_txm))
                        {
                            if (rdoCj.Checked == true)
                            {
                                if (string.IsNullOrEmpty(rows[i]["标本采集时间"].ToString()))
                                {
                                    sqlStr = string.Format(@"update YJ_MZSQ set BBCJSJ='{0}' where YJSQID='{1}'", dtpic.Value.ToString(), yjsqid);
                                }
                                else
                                {
                                    MessageBox.Show("标本采集时间已经确认！无需再次确认");
                                    return;
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(rows[i]["标本交接时间"].ToString()))
                                {
                                    sqlStr = string.Format(@"update YJ_MZSQ set BBJJSJ='{0}' where YJSQID='{1}'", dtpic.Value.ToString(), yjsqid);
                                }
                                else
                                {
                                    MessageBox.Show("标本交接时间已经确认！无需再次确认");
                                    return;
                                }
                            }
                            int result = InstanceForm.BDatabase.DoCommand(sqlStr);
                            if (result > 0)
                                num++;
                        }
                        else
                        {
                            MessageBox.Show("必须先打印条码，才能进行时间确认!");
                            return;
                        }
                    }
                }
                if (num == rows.Length)
                {
                    MessageBox.Show("时间确认成功!");
                    btref_Click(sender, e);
                    return;
                }
                else
                {
                    MessageBox.Show("时间确认失败!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region 号码呼叫
        //呼叫号码
        private void btn_CallNum_Click(object sender, EventArgs e)
        {
            CallCount++;
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Text = "Num";
            parameters[0].Value = Num;
            parameters[1].Text = "CallCount";
            parameters[1].Value = CallCount;
            parameters[2].Text = "flag";
            parameters[2].Value = 0;
            DataTable dt = InstanceForm.BDatabase.GetDataTable("sp_interface_CallNum", parameters);
            this.txtkh.Text = dt.Rows[1]["CARDCODE"].ToString();
            Num = int.Parse(dt.Rows[1]["Num"].ToString());
            this.btn_CallNum.Text = "呼叫号码(" + Num + ")";
            CallNum(Num);
        }

        //下一个号码
        private void btn_CallNextNum_Click(object sender, EventArgs e)
        {
            CallCount = 1;
            ParameterEx[] parameters = new ParameterEx[2];
            parameters[0].Text = "Num";
            parameters[0].Value = Num;
            parameters[1].Text = "CallCount";
            parameters[1].Value = CallCount;
            parameters[2].Text = "flag";
            parameters[2].Value = 1;
            DataTable dt = InstanceForm.BDatabase.GetDataTable("sp_interface_CallNum", parameters);
            this.txtkh.Text = dt.Rows[1]["CARDCODE"].ToString();
            Num = int.Parse(dt.Rows[1]["Num"].ToString());
            this.btn_CallNextNum.Text = "下一个(" + Num + ")";
            CallNum(Num);
        }
        #endregion

        #region 语音呼叫
        /// <summary>r
        /// 语音呼叫
        /// </summary>
        /// <param name="Num">呼叫号码</param>
        public void CallNum(int Num)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
            string CallString = GetCallString("ZZJJH_Config.xml", Num);
            synth.Speak(CallString);
            timer.Start();
        }

        #region 获取配置文件中的配置的提示语句
        /// <summary>
        /// 获取配置文件中的配置的提示语句
        /// </summary>
        /// <param name="xmlPath">配置文件名</param>
        /// <param name="Num">当前号码</param>
        /// <returns></returns>
        public static string GetCallString(string xmlPath, int Num)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlNode root = xmlDoc.SelectSingleNode("//Connection");
            string Title = (root.SelectSingleNode("Title")).InnerText;
            string HaoMa = (root.SelectSingleNode("HaoMa")).InnerText;
            string ChuangKou = (root.SelectSingleNode("ChuangKou")).InnerText;
            string CaiJi = (root.SelectSingleNode("CaiJi")).InnerText;

            return Title + Num + HaoMa + ChuangKou + CaiJi;
        }
        #endregion

        private void Frmyjqr_Activated(object sender, EventArgs e)
        {
            this.Refresh();
        }

        #endregion

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataTable tb = (DataTable)dataGridView2.DataSource;
           
                try
                {
                    Color q = Color.FromName(Convertor.IsNull(tb.Rows[e.RowIndex]["color"].ToString(), "white"));
                    this.dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = q;
                }
                catch
                {
                    //row.DefaultCellStyle.BackColor = Color.White;
                }
            
        }
    } 
}