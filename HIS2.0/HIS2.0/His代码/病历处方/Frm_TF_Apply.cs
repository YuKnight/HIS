using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using System.Data.OleDb;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using System.IO;
using YpClass; 

namespace ts_mzys_blcflr
{
    public partial class Frm_TF_Apply : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private Guid ghxxid = Guid.Empty;
        private Guid brxxid = Guid.Empty;
        private string strType = "2";
        
        public Frm_TF_Apply(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            ts_mz_class.FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            ts_mz_class.FunAddComboBox.AddJgbm(false, cmbjgbm, InstanceForm.BDatabase);
            cmbjgbm.SelectedValue = InstanceForm._menuTag.Jgbm;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            if (InstanceForm._functionName == "Fun_ts_mztfsh")
            {
                tabControl1.TabPages.RemoveAt(0);
                tabControl1.TabPages[0].Text = "待复审记录";
                //Add by CC 2014-03-25
                linkLabel2.Visible = false;
                Dgv_Dtf.Columns["取消退费"].Visible = false;
            }

        }

        public Frm_TF_Apply(int klx,string kh,string mzh,string brxm)
        {
            try
            {
                InitializeComponent();
                ts_mz_class.FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase); 
                ts_mz_class.FunAddComboBox.AddJgbm(false, cmbjgbm, InstanceForm.BDatabase); 
                cmbjgbm.SelectedValue = InstanceForm._menuTag.Jgbm;
                this.cmbklx.SelectedValue = klx;
                this.txtkh.Text = kh;
                this.txtmzh.Text = mzh;
                this.txtxm.Text = brxm;
                linkLabel3.Visible = false; //医生站申请时候屏蔽复审按钮 
                strType = "1";
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.Message, "错误");
            }
        }

        private void btref_Click(object sender, EventArgs e)
        {
            try
            { 
                int _klx=Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                if (txtkh.Text.Trim() != "")
                {
                    ReadCard card = new ReadCard(_klx, txtkh.Text.Trim(), InstanceForm.BDatabase);
                    brxxid = card.brxxid;
                }
                else
                    brxxid = Guid.Empty;
                if(!string.IsNullOrEmpty(txtmzh.Text))
                {
                    txtmzh.Text = ts_mz_class.Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                    txtmzh.SelectAll();
                }
                txtkh.Text = "";
                
                string _brxm=txtxm.Text.Trim();
                GetBrxx(txtmzh.Text, _klx, txtkh.Text.Trim(), "", _brxm);
                RefDgv(ghxxid);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        _menuTag, menuId, this.MdiParent, InstanceForm.BDatabase, ref communicateValue);
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

        private void Frmyjqr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Cursor.Current = PubStaticFun.WaitCursor();
                btref_Click(sender, e);
                Cursor.Current = Cursors.Default;
            }
        }

        private void buthelp_Click(object sender, EventArgs e)
        {
            try
            {

                MenuTag tag = new MenuTag();
                tag = _menuTag;
                ts_mz_kgl.Frmbrxxcx f = new ts_mz_kgl.Frmbrxxcx(tag, "病人查询", null);
                f.txtbrxm.Text = txtxm.Text;
                if (txtxm.Text.Trim() == "")
                    f.chkdjsj.Checked = true;
                f.txtbrxm.Focus();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();



                ReadCard card = new ReadCard(f.return_kdjid, InstanceForm.BDatabase);
                txtkh.Text = card.kh.Trim();
                cmbklx.SelectedValue = card.klx.ToString();
                txtkh_KeyPress(sender,new KeyPressEventArgs((Char)Keys.Enter));

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="mzh"></param>
        /// <param name="klx"></param>
        /// <param name="kh"></param>
        /// <param name="fph"></param>
        /// <param name="brxm"></param>
        private void GetBrxx(string mzh, int klx, string kh, string fph, string brxm)
        {
            if (klx == 0 && kh.Trim() != "") MessageBox.Show("请选择卡类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (klx != 0 && kh.Trim() == "" && mzh.Trim() == "" && (fph.Trim() == "" || fph == "0") && brxm == "") return;//Add By Zj 2012-08-01 如果不加病人姓名为空的判断 就会造成 在这个判断直接Return的情况

            if (mzh.Trim() == "" && kh.Trim() == "" && fph.Trim() == "" && brxm.Trim() == "") return;
            string _mzh = Fun.returnMzh(mzh, InstanceForm.BDatabase);

            string _kh = kh.Trim() == "" ? "" : Fun.returnKh(klx, kh, InstanceForm.BDatabase);

            if (kh.Trim() != "")
            {
                string ssq = "select * from YY_KDJB where klx=" + klx + " and kh='" + _kh.Trim() + "'  and ZFBZ=0 ";
                DataTable tbk = InstanceForm.BDatabase.GetDataTable(ssq);
                if (tbk.Rows.Count == 0)
                {
                    MessageBox.Show("没有找到卡信息，请确认卡号是否正确或卡没有作废");
                    return;
                }
                if (tbk.Rows.Count > 1)
                {
                    MessageBox.Show("找到多张同时有效的卡,请和系统管理员联系");
                    return;
                }             
            }
            string tabghxx = " mz_ghxx";
            string ssql = "select * from ( select (case when bqxghbz=1 then '已销号' else '' end) 状态,(select name from jc_brlx where code=brlx) 病人类型,blh 门诊号,brxm 姓名,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,dbo.fun_zy_age(csrq,3,getdate()) 年龄,dbo.fun_getdeptname(ghks) 挂号科室,ghks,dbo.fun_getempname(ghys) 挂号医生 ,ghys,(select top 1 type_name from jc_doctor_type where type_id=ghjb) 挂号级别,ghsj 挂号时间,zdmc 诊断,dbo.fun_getempname(jzys) 接诊医生,jzys ,dbo.fun_getdeptname(jzks) 接诊科室,jzks,jzsj 接诊时间,ghxxid,a.brxxid,gzdw 工作单位,gzdwdh 联系电话,jtdz 家庭地址,jtdh 家庭电话,brlxfs 本人联系方式,(select klxmc from JC_KLX where klx=c.klx) 卡类型,c.KLX,c.KH 卡号,c.kdjid,a.pym,a.wbm from YY_BRXX a inner join " + tabghxx + "  b on a.brxxid=b.brxxid left join YY_KDJB c on b.kdjid=c.kdjid and zfbz=0    ";
            ssql = ssql + ") a where a.brxxid is not null  ";

            if (kh.Trim() != "")
            {
                ssql = ssql + " and kdjid in(select kdjid from YY_KDJB where klx=" + klx + " and kh='" + _kh.Trim() + "'  and ZFBZ=0 ) ";
            }
            if (brxm.Trim() != "")
            {
                ssql = ssql + " and (姓名 like '%" + brxm + "%' or a.pym='" + brxm + "' or a.wbm='" + brxm + "')  ";
            }

            if (mzh.Trim() != "" && kh.Trim() == "")
            {
                ssql = ssql + " and 门诊号='" + _mzh + "' ";
            }
            if (fph != "" && fph != "0")
            {
                string table_fp = "mz_fpb";
                ssql = ssql + " and ghxxid in(select ghxxid from " + table_fp + " where fph= '" + fph + "' ) ";
            }


            ssql = ssql + " order by 挂号时间 desc";
            DataTable tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(ssql);
            if (tb.Rows.Count == 0 )
            {
                MessageBox.Show("没有找到病人看病记录,请确认就诊时间是否设置正确", "确认", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (tb.Rows.Count == 0)
            {
                string sssql = ssql.Replace("mz_fpb", "mz_fpb_h");//Add By Zj 2012-08-13
                tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(sssql);
                if (tb.Rows.Count == 0)
                {
                    MessageBox.Show("没有找到病人信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmzh.Focus();
                    return;
                }
            }
            if (tb.Rows.Count == 0)
                return;

            DataRow row = null;
            if (tb.Rows.Count > 0)
                row = tb.Rows[0];

            string _brxm = brxm == "" ? "" : brxm;
            string _fph = fph == "" ? "" : fph;
           
 
            ts_mz_class.MZ_TF_Record _TfApply=new MZ_TF_Record ();
            if (tb.Rows.Count > 1)
            {

                //如果有多次就诊记录并且要弹出选择框
                Frmghjl f = new Frmghjl(_menuTag, _chineseName, _mdiParent);
                tb.TableName = "tb";
                f.dataGridView1.DataSource = tb;
                f.ShowDialog();
                if (f.Bok == false)
                    return;
                row = f.ReturnRow;
                txtmzh.Enabled = true;
                ShowPatientInfo(row);
                brxxid = new Guid(row["brxxid"].ToString());
                ghxxid = new Guid(row["ghxxid"].ToString());
            }
            else
            {
                row = tb.Rows[0];
                ShowPatientInfo(row);
                txtmzh.Enabled = true;
                ShowPatientInfo(row);
                brxxid = new Guid(row["brxxid"].ToString());
                ghxxid = new Guid(row["ghxxid"].ToString());
            }
          
        }

        /// <summary>
        /// 刷新界面
        /// </summary>
        /// <param name="_ghxxid"></param>
        private void RefDgv(Guid _ghxxid)
        {
            try
            {
                ts_mz_class.MZ_TF_Record _TfApply = new MZ_TF_Record();
                _TfApply.GHXXID = _ghxxid; 
                DataTable dt_dtcf = ts_mz_class.MZ_TF_Record.GetDtfCfInfo(_TfApply, InstanceForm.BDatabase, strType,this.dtp1.Value.ToShortDateString()+" 00:00:00",this.dtp2.Value.ToShortDateString()+" 00:00:00");
                Fun.AddRowtNo(dt_dtcf);
                this.Dgv_Dtf.DataSource = dt_dtcf;
                /*获取已申请退费处方*/
                if (strType != "2")
                {
                    DataTable dt_cfxx = ts_mz_class.MZ_TF_Record.GetYsfCfInfo(_TfApply, InstanceForm.BDatabase, this.dtp1.Value.ToShortDateString() + " 00:00:00", this.dtp2.Value.ToShortDateString() + " 00:00:00");
                    Fun.AddRowtNo(dt_cfxx);
                    this.Dgv_Ysf.DataSource = dt_cfxx;
                }
                //如果是复审菜 则显示复审按钮 
                if (InstanceForm._functionName == "Fun_ts_mztfsh" && this.Dgv_Dtf.Columns["CLM_FSQR"] != null)
                    this.Dgv_Dtf.Columns["CLM_FSQR"].Visible = true;
                beautifyGridView();
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:"+ea.Message,"提示");
            }
        } 
 
        private void ShowPatientInfo(DataRow row)
        {
            txtmzh.Text = row["门诊号"].ToString();
            txtxm.Text = row["姓名"].ToString();
            txtkh.Text = row["卡号"].ToString();
            if (row["klx"]  is DBNull) return;
            cmbklx.SelectedValue = row["klx"].ToString();
            if (Convertor.IsNull(row["klx"], "0") != "0")
                cmbklx.SelectedValue = row["klx"].ToString(); 
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 13) return;
            Control control = (Control)sender;
            int _klx=Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue,"0"));
          
            string _brxm=txtxm.Text.Trim();

            if (control.Name == "txtkh")
            {
                txtkh.Text = ts_mz_class.Fun.returnKh(_klx, txtkh.Text.Trim(), InstanceForm.BDatabase);
                txtkh.SelectAll();
                txtmzh.Text = "";
                GetBrxx("", _klx, txtkh.Text.Trim(), "", _brxm);
            }
            if (control.Name  == "txtmzh")
            {
                txtmzh.Text = ts_mz_class.Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                txtmzh.SelectAll();
                txtkh.Text = "";
                GetBrxx(txtmzh.Text, _klx, txtkh.Text.Trim(), "", _brxm);
            }
            RefDgv(ghxxid);
        }

        private void Frmyjqr_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; 
            
            //SystemCfg sysrq = new SystemCfg(10007, InstanceForm.BDatabase);
            this.dtp2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(Convert.ToInt32(1)); 

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
        }

        private void toText(string FILE_NAME, string text)
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

        private void Dgv_Dtf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv_Dtf.CurrentCell == null) return;
                if (e.RowIndex <= -1) return;
                //取消退费
                if (Dgv_Dtf.Columns[Dgv_Dtf.CurrentCell.ColumnIndex].Name.Trim() == "取消退费")
                {
                    DataTable dt = (DataTable)this.Dgv_Dtf.DataSource;
                    int rowindex = Dgv_Dtf.CurrentCell.RowIndex;
                    MZ_TF_Record tf_apply = new MZ_TF_Record(new Guid(dt.Rows[rowindex]["退费申请id"].ToString()), InstanceForm.BDatabase);//new MZ_TF_Record(new Guid(dt.Rows[rowindex]["退费申请id"].ToString()), InstanceForm.BDatabase);
                    
                    if (tf_apply.TFBZ == 1)
                    {
                        MessageBox.Show("已经退费不能再取消退费！", "提示");
                        return;
                    } 
                    if (InstanceForm._functionName != "Fun_ts_mztfsh")
                    {
                        if (tf_apply.FSBZ == 1)
                        {
                            MessageBox.Show("已经复审不能取消退费！", "提示");
                            return;
                        }
                    } 

                    if (ts_mz_class.MZ_TF_Record.checkIsty(new Guid(Dgv_Dtf.Rows[Dgv_Dtf.CurrentCell.RowIndex].Cells["CFMXID"].Value.ToString()), InstanceForm.BDatabase))
                    {
                        MessageBox.Show("已经退药不能再取消退费！", "提示");
                        return;
                    }

                    tf_apply.TFSQID = new Guid(dt.Rows[rowindex]["退费申请id"].ToString());
                    MZ_TF_Record.Update(MZ_TF_Record.TfApplyUpdateSort.取消申请,tf_apply,true, InstanceForm.BDatabase);
                    RefDgv(ghxxid);
                }
                //Add By zp 2014-02-07 
                if (Dgv_Dtf.Rows.Count == 0) return;
                if (InstanceForm._functionName == "Fun_ts_mztfsh" && Dgv_Dtf.Columns[Dgv_Dtf.CurrentCell.ColumnIndex].Name.Trim() == "复审确认")
                {
                    DataTable dt = (DataTable)this.Dgv_Dtf.DataSource;
                    int rowindex = Dgv_Dtf.CurrentCell.RowIndex;
                    MZ_TF_Record tf_apply = new MZ_TF_Record();
                    tf_apply.TFSQID = new Guid(dt.Rows[rowindex]["退费申请id"].ToString());

                    tf_apply.FSY = InstanceForm.BCurrentUser.EmployeeId;
                    tf_apply.FSSJ = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");
                    MZ_TF_Record.Update(MZ_TF_Record.TfApplyUpdateSort.退费复审, tf_apply, InstanceForm.BDatabase);
                    RefDgv(ghxxid);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }

        }

        private void Dgv_Ysf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Dgv_Ysf.CurrentCell == null) return;
                if (e.RowIndex <= -1) return;
                if (Dgv_Ysf.Columns[Dgv_Ysf.CurrentCell.ColumnIndex].Name == "申请退费")
                {
                    /*如果项目的数量大于1 则show出窗体选择需退数量,否则直接向退费申请表插入记录*/
                    DataTable dt = (DataTable)Dgv_Ysf.DataSource;
                    int rowindex = Dgv_Ysf.CurrentCell.RowIndex;
                    int xmly = Convert.ToInt32(dt.Rows[rowindex]["项目来源"]);
                    MZ_TF_Record tf_apply = new MZ_TF_Record();
                    tf_apply.TFSQID = Guid.Empty;
                    tf_apply.CFID = new Guid(dt.Rows[rowindex]["CFID"].ToString());
                    tf_apply.CFMXID = new Guid(Convertor.IsNull(dt.Rows[rowindex]["cfmxid"].ToString(), Guid.Empty.ToString()));
                    tf_apply.XMMC = Convertor.IsNull(dt.Rows[rowindex]["项目名称"], "");
                    tf_apply.XMID = Convert.ToInt32(dt.Rows[rowindex]["项目编号"]);
                    tf_apply.TCID = Convert.ToInt32(Convertor.IsNull(dt.Rows[rowindex]["套餐编号"], "0"));
                    tf_apply.XMGG = Convertor.IsNull(dt.Rows[rowindex]["规格"], "");
                    tf_apply.XMDW = Convertor.IsNull(dt.Rows[rowindex]["单位"], "");
                    tf_apply.YDJ = Convert.ToDecimal(dt.Rows[rowindex]["单价"]);
                    tf_apply.YSL = Convert.ToDecimal(dt.Rows[rowindex]["数量"]);
                    tf_apply.YJE = Convert.ToDecimal(dt.Rows[rowindex]["金额"]);
                    tf_apply.KDKS = Convert.ToInt32(Convertor.IsNull(dt.Rows[rowindex]["科室编号"], "0"));
                    tf_apply.TFSQKS = InstanceForm.BCurrentDept.DeptId;
                    tf_apply.DJY = InstanceForm.BCurrentUser.EmployeeId;
                    tf_apply.KH = txtkh.Text.Trim();
                    tf_apply.GHXXID = ghxxid;
                    tf_apply.FPID = new Guid(dt.Rows[rowindex]["FPID"].ToString());
                    tf_apply.YZID = Convert.ToInt32(Convertor.IsNull(dt.Rows[rowindex]["yzid"], "0"));
                    string sffy = Convert.ToString(dt.Rows[rowindex]["是否发药"]);
                    if (Convert.ToString(dt.Rows[rowindex]["是否发药"]) == "1" || Convert.ToString(dt.Rows[rowindex]["是否确认"]) == "1")
                    {
                        tf_apply.SHBZ = 0;
                        tf_apply.SHY =0;
                        tf_apply.SHSJ = System.DateTime.Now.ToString();
                    }
                    else
                    {
                        tf_apply.SHBZ = 1;
                        tf_apply.SHY = InstanceForm.BCurrentUser.EmployeeId;
                        tf_apply.SHSJ = System.DateTime.Now.ToString();
                    }
                    tf_apply.TSL = Convert.ToDecimal(dt.Rows[rowindex]["可退数量"]);

                    #region  MODIFY BY CC 可以部分退费
                    /*在进行退费申请前 需要验证当前费用是否已在退费申请表有了记录*/
                    if (!MZ_TF_Record.CheckIsYFy(tf_apply, dt.Rows[rowindex], InstanceForm.BDatabase))
                    {
                        MessageBox.Show("当前记录已经进行了申请退费,可在待退费记录中查询!", "提示");
                        return;
                    }

                    if (Convert.ToInt32(dt.Rows[rowindex]["可退数量"]) == 1)
                    {
                        tf_apply.TSL = Convert.ToDecimal(dt.Rows[rowindex]["可退数量"]);
                        /*在进行退费申请前 需要验证当前费用是否已在退费申请表有了记录*/
                        if (!MZ_TF_Record.CheckIsYFy(tf_apply, dt.Rows[rowindex], InstanceForm.BDatabase))
                        {
                            MessageBox.Show("当前记录已经进行了申请退费,可在待退费记录中查询!", "提示");
                            return;
                        }
                    }
                    else
                    {
                        /*弹出选择框 进行输入数量*/
                        decimal _ysl = Convert.ToDecimal(dt.Rows[rowindex]["可退数量"]);
                        DlgInputBox Dlg_Add = new DlgInputBox("0", "退费数量", "退费数量");
                        Dlg_Add.ShowDialog();
                        // if(Dlg_Add.DialogResult!= DialogResult.OK)return; 
                        decimal tfs = 0;

                        if (!decimal.TryParse(DlgInputBox.DlgValue, out tfs))
                        {
                            MessageBox.Show("退费数必须为数值类型!", "提示");
                            return;
                        }
                        if (tfs != _ysl && xmly != 1)//如果退费数不等于原数量同时不为药品 则必须退费数为整数
                        {
                            int _value = 0;
                            if (!int.TryParse(DlgInputBox.DlgValue, out _value))
                            {
                                MessageBox.Show("退费数必须为整数类型!", "提示");
                                return;
                            }
                        }
                        if (tfs < 0)// Add by zp 2013-12-27
                        {
                            MessageBox.Show("退费数必须大于0!", "提示");
                            return;
                        }
                        if (tfs == 0)
                        {
                            //MessageBox.Show("退费数不能为0!", "提示");
                            return;
                        }
                        if (tfs > _ysl)
                        {
                            MessageBox.Show("退费数不能大于收费原数量!", "提示");
                            return;
                        }
                        tf_apply.TSL = tfs; 
                    }  
                    #endregion 
                   
                    try
                    {
                       bool isQr = false;

                        //if (dt.Rows[rowindex]["执行科室编号"].ToString() == InstanceForm.BCurrentDept.DeptId.ToString())
                        //{
                        //    isQr = true;
                        //}
                       // bool isQr = Fun.IsQr(new Guid(Convertor.IsNull(dt.Rows[rowindex]["cfmxid"].ToString(), Guid.Empty.ToString())),Convert.ToInt32(Convertor.IsNull(dt.Rows[rowindex]["套餐编号"], "0")), InstanceForm.BDatabase);
                        MZ_TF_Record.Save(ref tf_apply, isQr, InstanceForm.BDatabase);

                        #region 注释代码 MODIFY BY CC
                        if (xmly == 1 && sffy == "1") //如果是退药 则需要向yf_fymx插入记录
                        {
                            long fph = Convert.ToInt64(Convertor.IsNull(dt.Rows[rowindex]["发票号"], "0"));
                            string bm = Convertor.IsNull(dt.Rows[rowindex]["编码"], "");
                            string pm = Convertor.IsNull(dt.Rows[rowindex]["项目名称"], "");
                            string spm = Convertor.IsNull(dt.Rows[rowindex]["商品名"], "");
                            string cj = Convertor.IsNull(dt.Rows[rowindex]["厂家"], "");
                            decimal ydwbl = Convert.ToDecimal(Convertor.IsNull(dt.Rows[rowindex]["YDWBL"], "1"));
                            decimal tyl = tf_apply.YSL * -1;
                            int ts = Convert.ToInt32(dt.Rows[rowindex]["天数"]);
                            decimal pfj = Convert.ToDecimal(Convertor.IsNull(dt.Rows[rowindex]["批发价"], "0"));
                            decimal pfje = Convert.ToDecimal(Convertor.IsNull(dt.Rows[rowindex]["批发金额"], "0"));
                            decimal lsj = Convert.ToDecimal(Convertor.IsNull(dt.Rows[rowindex]["单价"], "0"));
                            long yfid = Convert.ToInt32(dt.Rows[rowindex]["执行科室编号"]);
                            string ps = Convertor.IsNull(dt.Rows[rowindex]["皮试"], "");
                            string yf = Convertor.IsNull(dt.Rows[rowindex]["用法"], "");
                            DataTable dt_fyxx = MZ_TF_Record.GetFymxInfo(tf_apply.CFID, tf_apply.CFMXID, InstanceForm.BDatabase);
                            Guid _fymxid = Guid.Empty;
                            string pc = "";
                            Guid NewFyid = Guid.Empty;
                            int err_code = 0;
                            string err_text = "";
                            if (dt_fyxx.Rows.Count > 0)
                            {
                                pc = MZYF.SeekFymxPh(_fymxid, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                                YpClass.MZYF.SaveFymx(Guid.Empty, fph, tf_apply.CFID, tf_apply.XMID, bm, pm, spm,
                                tf_apply.XMGG, cj, tf_apply.XMDW, ydwbl, tyl,
                                 ts,
                                 pfj,
                                 pfj * tyl * ts,
                                 lsj,
                                 Math.Round(lsj * tyl * ts, 2), 0, 0, yfid, Guid.Empty, "", Guid.Empty, tf_apply.CFMXID, ps, yf, "",
                                     "",
                                 "",
                                 "",
                                 "",
                                  0,
                                 0,
                                 0, "sp_yf_fymx", out NewFyid, out err_code, out err_text, InstanceForm.BDatabase);
                            }
                        }
                        #endregion

                        KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Enter);
                        object o = this.txtmzh;
                        txtkh_KeyPress(o, ee);
                    }
                    catch (Exception ea)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();
                        throw ea;
                    }
                } 
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            } 
        }

        //全部取消退费
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)this.Dgv_Dtf.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                { 
                    if (ts_mz_class.MZ_TF_Record.checkIsty(new Guid(Dgv_Dtf.Rows[i].Cells["CFMXID"].Value.ToString()), InstanceForm.BDatabase))
                    {
                        MessageBox.Show("已经退药不能再取消退费！", "提示");
                        return;
                    }
                    if (InstanceForm._functionName != "Fun_ts_mztfsh")
                    {
                        if (Dgv_Dtf.Rows[i].Cells["CFMXID"].Value.ToString()=="1")
                        {
                            MessageBox.Show("已经复审不能取消退费！", "提示");
                            return;
                        }
                    } 
                    MZ_TF_Record tf_apply = new MZ_TF_Record();
                    tf_apply.TFSQID = new Guid(dt.Rows[i]["退费申请id"].ToString());
                    MZ_TF_Record.Update(MZ_TF_Record.TfApplyUpdateSort.取消申请, tf_apply,true, InstanceForm.BDatabase);
                }
                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Enter);
                object o = this.txtmzh;
                txtkh_KeyPress(o, ee);
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:"+ea.Message,"提示");
            }
        }

        //全选复审确认
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)this.Dgv_Dtf.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MZ_TF_Record tf_apply = new MZ_TF_Record();
                    tf_apply.TFSQID = new Guid(dt.Rows[i]["退费申请id"].ToString());
                    tf_apply.FSY = InstanceForm.BCurrentUser.EmployeeId;
                    tf_apply.FSSJ = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");
                    MZ_TF_Record.Update(MZ_TF_Record.TfApplyUpdateSort.退费复审,tf_apply, InstanceForm.BDatabase);
                }
                KeyPressEventArgs ee = new KeyPressEventArgs((char)Keys.Enter);
                object o = this.txtmzh;
                txtkh_KeyPress(o, ee);
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

        //全选申请退费
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                 
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

        /// <summary>
        /// 美化界面
        /// </summary>
        private void beautifyGridView()
        {
            if (strType != "2")
            {
                DataTable dt = (DataTable)this.Dgv_Ysf.DataSource;
                if (dt == null) return;
                this.Dgv_Ysf.Columns["hjid"].Visible = false;
                this.Dgv_Ysf.Columns["yzid"].Visible = false;
                this.Dgv_Ysf.Columns["GHXXID"].Visible = false;
                this.Dgv_Ysf.Columns["CFID"].Visible = false;
                this.Dgv_Ysf.Columns["CFMXID"].Visible = false;
                this.Dgv_Ysf.Columns["FPID"].Visible = false;
                this.Dgv_Ysf.Columns["KH"].Visible = false;
                this.Dgv_Ysf.Columns["YDWBL"].Visible = false; 
            }
            DataTable dt2 = (DataTable)this.Dgv_Dtf.DataSource;
            if (dt2 == null) return;
            this.Dgv_Dtf.Columns["hjid"].Visible = false;
            this.Dgv_Dtf.Columns["yzid"].Visible = false;
            this.Dgv_Dtf.Columns["GHXXID"].Visible = false;
            this.Dgv_Dtf.Columns["CFID"].Visible = false;
            this.Dgv_Dtf.Columns["CFMXID"].Visible = false;
            this.Dgv_Dtf.Columns["FPID"].Visible = false;
            this.Dgv_Dtf.Columns["KH"].Visible = false;
            this.Dgv_Dtf.Columns["YDWBL"].Visible = false;
            this.Dgv_Dtf.Columns["dwlx"].Visible = false;
            this.Dgv_Dtf.Columns["HJMXID"].Visible = false;
            this.Dgv_Dtf.Columns["HJY"].Visible = false;
            if (strType != "2")
            {
                this.Dgv_Dtf.Columns["复审确认"].Visible = false; 
            }

        }

        private void Dgv_Ysf_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //显示行数
            DataGridView dgv = sender as DataGridView;
            if (dgv != null)
            {
                //Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth - 4, e.RowBounds.Height);
                //TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvListMInfo.RowHeadersDefaultCellStyle.Font, rect, Dgv_Ysf.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                //隔行换色
                Dgv_Ysf.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
            } 
        }

        private void Dgv_Dtf_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //显示行数
            DataGridView dgv = sender as DataGridView;
            if (dgv != null)
            {
                //Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth - 4, e.RowBounds.Height);
                //TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvListMInfo.RowHeadersDefaultCellStyle.Font, rect, Dgv_Ysf.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                //隔行换色
                Dgv_Dtf.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
            } 
        }

      
    }
}