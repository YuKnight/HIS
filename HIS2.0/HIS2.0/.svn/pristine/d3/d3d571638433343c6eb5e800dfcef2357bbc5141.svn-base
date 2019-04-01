using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_kgl;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenClasses.DatabaseAccess;
using Ts_Visit_Class;

namespace Ts_OrderRegist
{
    public partial class Frm_OrderRegist : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        /// <summary>
        /// 是否启用平台方法实现 0:HIS方法实现,1:平台方法实现 由系统参数1081实现
        /// </summary>
        private SystemCfg _cfg1081 = new SystemCfg(1081);
        /// <summary>
        /// 预约平台医院编码 参数
        /// </summary>
        private SystemCfg _cfg3059 = new SystemCfg(3059);
        /// <summary>
        /// 预约平台操作员号 
        /// </summary>
        private SystemCfg _cfg3060 = new SystemCfg(3060);
        /// <summary>
        /// 预约类型1院内预约 2网上预约 3电话预约 4 医生站预约
        /// </summary>
        private Mz_YYgh.YYgh_Sort _CurrentYylx;
        /// <summary>
        /// 当前用户
        /// </summary>
        private User _currentuser;
        /// <summary>
        /// 基础数据集(科室、人员)
        /// </summary>
        private DataSet _ds = new DataSet();

        /// <summary>
        /// 系统定义的病历本种类
        /// </summary>
        private SystemCfg cfgBlb = new SystemCfg(1018);
        /// <summary>
        /// 预约平台操作类
        /// </summary>
        private Order_Web _orderMeans;

        private Order_Parmanalyze Analy_Order = new Order_Parmanalyze();
        /// <summary>
        /// 是否开始查询
        /// </summary>
        private bool IsSelect = false;
        /// <summary>
        /// 当前科室id（当前 医生站预约用）
        /// </summary>
        private int _currentdeptid = -1;
        /// <summary>
        /// 当前医生级别（医生站预约）
        /// </summary>
        //private int _currentysjb = -1;
        /// <summary>
        /// 排班主键 预约平台用
        /// </summary>
        private string rowid = string.Empty;

        /// <summary>
        ///构造函数
        /// </summary>
        /// <param name="menuTag"></param>
        /// <param name="chineseName"></param>
        /// <param name="mdiParent"></param>
        /// <param name="_user"></param>
        /// <param name="yylx">预约类型</param>
        public Frm_OrderRegist(MenuTag menuTag, string chineseName, Form mdiParent, User _user, Mz_YYgh.YYgh_Sort yylx)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
            _currentuser = _user;
            _CurrentYylx = yylx;
            cmb_sxw.SelectedIndex = 0;
            _orderMeans = new Order_Web(_cfg3059);
            //添加卡类型
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
        }
        /// <summary>
        /// 医生站传输  构造函数
        /// </summary>
        /// <param name="menuTag"></param>
        /// <param name="chineseName">窗体text值</param>
        /// <param name="mdiParent"></param>
        /// <param name="_user">当前用户</param>
        /// <param name="yylx">预约类型</param>
        /// <param name="deptid">科室id</param>
        /// <param name="ysid">医生id</param>
        public Frm_OrderRegist(MenuTag menuTag, string chineseName, Form mdiParent, User _user, Mz_YYgh.YYgh_Sort yylx, int deptid, string cardno, string klx, RelationalDatabase db)
        {
            InitializeComponent();
            if (db != null)
                InstanceForm.BDatabase = db;
            _menuTag = menuTag;
            _chineseName = chineseName;
            this.Text = _chineseName;
            _currentuser = _user;
            _CurrentYylx = yylx;
            _currentdeptid = deptid;
            cmb_sxw.SelectedIndex = 0;
            this.cmbghjb.Enabled = false;
            this.Lab_Doctor.Enable = false;
            this.Lab_Dept.Enable = false;
            this.cmb_sxw.Enabled = false;
            _orderMeans = new Order_Web(_cfg3059);
            _CurrentYylx = yylx;
            //添加卡类型
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            if (!string.IsNullOrEmpty(cardno))
            {
                this.cmbklx.SelectedValue = klx;
                this.txtkh.Text = cardno;
                this.txtkh.Enabled = false;
                this.cmbklx.Enabled = false;
                SetControls(cardno);
            }

        }

        private void SetControls(string cardno)
        {
            if (string.IsNullOrEmpty(cardno))
            {
                return;
            }
            char keycharr = '\r';
            KeyPressEventArgs key = new KeyPressEventArgs(keycharr);
            txtkh_KeyPress(null, key);
        }
        //his自身数据源绑定时段下拉  Add by zp 2013-11-07
        private void BindCmbTime()
        {
            try
            {
                int ghys = int.Parse(Convertor.IsNull(Lab_Doctor.SelectedValue, "0"));
                int ghjb = int.Parse(Convertor.IsNull(cmbghjb.SelectedValue, "0"));
                int ghks = int.Parse(Convertor.IsNull(Lab_Dept.SelectedValue, "0"));
                DateTime date = dateTimePicker1.Value;
                Ts_Visit_Class.VisitResource _VisRes = new VisitResource(ghks, ghjb, ghys, date.ToString("yyyy-MM-dd"), InstanceForm.BDatabase);
                FsdClass _fsd = new FsdClass();
                int sxwid = cmb_sxw.Text.Trim() == "上午" ? 1 : 2;
                DataTable dt = _fsd.GetSdInfo(_VisRes.Resid, sxwid, InstanceForm.BDatabase);
                if (dt == null || dt.Rows.Count == 0)
                    Cmb_Times.Enabled = false;
                else
                {
                    Cmb_Times.Enabled = true;
                    Cmb_Times.DisplayMember = "SJNC";
                    Cmb_Times.ValueMember = "ZYMXID";
                    Cmb_Times.DataSource = dt;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }


        private void Frm_OrderRegist_Load(object sender, EventArgs e)
        {
            //dateTimePicker1_ValueChanged
            this.dateTimePicker1.ValueChanged -= dateTimePicker1_ValueChanged;
            this.dateTimePicker1.Value = this.dateTimePicker1.Value.AddDays(1);//预约日期默认为第二天     
            this.dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            IsSelect = true;

            SetDataSet(0);
            if (int.Parse(_cfg1081.Config) == 0) //如果是院内则屏蔽相关控件
            {
                this.label5.Enabled = false;
                BindCmbTime();
            }
            if (_CurrentYylx == Mz_YYgh.YYgh_Sort.院内预约)
            {
                FunAddComboBox.AddGhjb(false, 0, cmbghjb, InstanceForm.BDatabase);
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                //Modify by zp 2014.11.03
                int zcjb = Fun.GetDocZcjb(_currentuser.EmployeeId, InstanceForm.BDatabase);
                if (zcjb != 0)
                {
                    if (this.cmbghjb.DataSource == null) //绑定挂号级别 Add by zp 2014-11-11
                        FunAddComboBox.AddGhjb(false, 0, cmbghjb, InstanceForm.BDatabase);
                    if (this.cmbghjb.SelectedValue == null)
                        this.cmbghjb.SelectedValue = zcjb;
                }
                this.WindowState = FormWindowState.Normal;
            }
        }
        /// <summary>
        /// 填充数据到内存集合(科室、医生列表) 0:获取科室、性别列表 1: //获取医生
        /// </summary>
        /// <param name="value">0获取科室1获取医生</param>
        private void SetDataSet(short value)
        {
            if (!IsSelect) { return; }
            string sql = string.Empty;
            DataTable dt = null;
            switch (value)
            {
                case 0:  //获取科室、性别列表
                    sql = @"select distinct dept_id as 科室id,name as 科室名称,py_code as 拼音码,wb_code as 五笔码 
                    from JC_DEPT_PROPERTY as a inner join JC_MZ_YSPB as b on a.DEPT_ID=b.PBKSID and a.DELETED=0 
                    and b.BSCBZ=0 where a.MZ_FLAG=1 and a.JZ_FLAG=0 
                    and CONVERT(varchar(10),PBSJ,120)='" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ";
                    if (!string.IsNullOrEmpty(this.cmb_sxw.Text.Trim()))
                    {
                        int pblx = this.cmb_sxw.Text.Trim() == "上午" ? 1 : 2;
                        sql += "and b.PBLX= " + pblx;
                    }
                    //chencan
                    //if (_currentdeptid > 0 && _CurrentYylx==Mz_YYgh.YYgh_Sort.医生站预约)  //当前科室id 大于0 则直接选择改科室id
                    //{
                    //    sql += " and dept_id=" + _currentdeptid + "";
                    //}
                    dt = InstanceForm.BDatabase.GetDataTable(sql);
                    dt.TableName = "dt_dept";
                    if (_ds.Tables.Contains("dt_dept"))
                    {
                        _ds.Tables.Remove("dt_dept");
                    }
                    _ds.Tables.Add(dt);
                    string str_deptId = this.Lab_Dept.SelectedValue != null ? this.Lab_Dept.SelectedValue.ToString() : "";
                    this.Lab_Dept.ShowCardProperty[0].ShowCardDataSource = _ds.Tables["dt_dept"];
                    if (_ds.Tables["dt_dept"].Rows.Count > 0)
                    {
                        this.Lab_Dept.SelectedValue = str_deptId == "" ? _currentdeptid.ToString() : str_deptId;
                    }
                    /*性别集合是固定的 只需要新增一次*/
                    if (_ds.Tables.Contains("dt_sex"))
                    {
                        return;
                    }
                    sql = @"select CODE,NAME from jc_sexcode";
                    dt = InstanceForm.BDatabase.GetDataTable(sql);
                    dt.TableName = "dt_sex";
                    _ds.Tables.Add(dt);
                    this.cmb_sex.DataSource = _ds.Tables["dt_sex"];
                    this.cmb_sex.ValueMember = "CODE";
                    this.cmb_sex.DisplayMember = "NAME";
                    break;
                case 1: //获取医生
                    sql = @"select a.NAME as 医生名称,c.DEPT_ID as 科室ID,c.NAME as 科室名称,
                    f.zzjb as 坐诊级别,a.PY_CODE as 拼音码,a.WB_CODE as 五笔码,a.EMPLOYEE_ID as 医生id from JC_EMPLOYEE_PROPERTY as a 
                    inner join JC_EMP_DEPT_ROLE as b on a.EMPLOYEE_ID=b.EMPLOYEE_ID and a.RYLX=1
                    inner join JC_DEPT_PROPERTY as c on b.DEPT_ID=c.DEPT_ID 
                    inner join JC_ROLE_DOCTOR as d on a.EMPLOYEE_ID=d.EMPLOYEE_ID
                    inner join JC_DOCTOR_TYPE as e on d.YS_TYPEID=e.TYPE_ID
                    inner join JC_MZ_YSPB as f on a.EMPLOYEE_ID=f.YSID and f.BSCBZ=0
                    where c.MZ_FLAG=1 and JZ_FLAG=0  
                    and CONVERT(varchar(10),f.PBSJ,120)='" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'";
                    if (this.Lab_Dept.SelectedValue != null)
                    {
                        sql += "  and f.pbksid =" + this.Lab_Dept.SelectedValue + " and c.DEPT_ID=" + this.Lab_Dept.SelectedValue + " ";
                    }
                    if (this.cmbghjb.SelectedIndex > -1)
                    {
                        sql += "  and f.ZZJBID=" + this.cmbghjb.SelectedValue + "";
                    }
                    if (!string.IsNullOrEmpty(this.cmb_sxw.Text.Trim()))
                    {
                        int pblx = this.cmb_sxw.Text.Trim() == "上午" ? 1 : 2;
                        sql += " and f.pblx=" + pblx;
                    }
                    //chencan
                    //if (this._CurrentYylx == Mz_YYgh.YYgh_Sort.医生站预约 && this._currentuser!=null)
                    //{
                    //    sql += " and a.EMPLOYEE_ID=" + this._currentuser.EmployeeId + "";
                    //}
                    dt = InstanceForm.BDatabase.GetDataTable(sql);
                    dt.TableName = "dt_doc";
                    if (_ds.Tables.Contains("dt_doc"))
                    {
                        _ds.Tables.Remove("dt_doc");
                    }
                    _ds.Tables.Add(dt);
                    string str_empId = this.Lab_Doctor.SelectedValue != null ? this.Lab_Doctor.SelectedValue.ToString() : "";
                    this.Lab_Doctor.ShowCardProperty[0].ShowCardDataSource = _ds.Tables["dt_doc"];
                    if (_ds.Tables["dt_doc"].Rows.Count > 0 && this._CurrentYylx == Mz_YYgh.YYgh_Sort.医生站预约)
                    {
                        this.Lab_Doctor.SelectedValue = str_empId == "" ? _currentuser.EmployeeId.ToString() : str_empId;
                    }
                    break;
            }
        }
        /// <summary>
        /// 通过日期排班绑定医生级别  zp 2013-05-17
        /// </summary>
        private void FullDocLevel()
        {
            try
            {
                int pblx = this.cmb_sxw.Text == "上午" ? 1 : 2;
                DataTable dt_level = Mz_YYgh.BindDocLevelByPb(this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(_currentuser.EmployeeId),
                    pblx, _currentdeptid, InstanceForm.BDatabase);

                cmbghjb.ValueMember = "ZZJBID";
                cmbghjb.DisplayMember = "ZZJB";
                cmbghjb.DataSource = dt_level;
                //Add by zp 2014-11-14 如果有排班就赋值 否则SelectedValue为null
                if (cmbghjb.DataSource != null && dt_level.Rows.Count > 0)
                {
                    cmbghjb.SelectedValue = dt_level.Rows[0]["ZZJBID"];
                }

            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
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
                if (card.kdjid != Guid.Empty)
                {
                    cmbklx.SelectedValue = card.klx;
                    txtkh.Text = card.kh;
                    txtkh.Focus();
                    txtkh_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
                }
                else
                {
                    if (f.bok == true)
                    {
                        MessageBox.Show("只能检索有卡的病人", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                    txtkh.Text = Fun.returnKh(klx, txtkh.Text.Trim(), InstanceForm.BDatabase); //卡号获取
                    txtkh.Text = ts_mz_class.Fun.ToDBC(txtkh.Text);
                    //this.Tag = Guid.Empty.ToString();
                    //使用左连接。因为有些卡登记了但没有病人信息，只有持卡人信息
                    string ssq = @"select *,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,brlx from YY_KDJB a inner join YY_BRXX b 
                            on a.brxxid=b.brxxid where a.klx=" + klx + " and a.kh='" + txtkh.Text + "'  and a.ZFBZ=0 ";
                    DataTable tbk = InstanceForm.BDatabase.GetDataTable(ssq); //获取病人信息
                    if (tbk.Rows.Count < 1)
                    {
                        MessageBox.Show("未发现该卡号的病人信息!请确定卡号是否输入正确!", "提示");
                        return;
                    }
                    if (tbk.Rows.Count != 1)
                    {
                        MessageBox.Show("找到多张同时有效的卡,请和系统管理员联系");
                        return;
                    }
                    if (Convert.ToInt16(tbk.Rows[0]["sdbz"]) == 1)
                    {
                        MessageBox.Show("这张卡已被锁定,不能消费.请先激活", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    this.txtxm.Text = tbk.Rows[0]["CKRXM"].ToString();
                    this.cmb_sex.SelectedValue = tbk.Rows[0]["xb"].ToString();
                    this.txtgrlxfs.Text = Convertor.IsNull(tbk.Rows[0]["BRLXFS"], "");
                    this.txtjtdz.Text = Convertor.IsNull(tbk.Rows[0]["JTDZ"], "");
                    this.txt_Sfzh.Text = Convertor.IsNull(tbk.Rows[0]["SFZH"], "");
                    this.txt_csrq.Text = Convertor.IsNull(DateTime.Parse(tbk.Rows[0]["CSRQ"].ToString()).ToShortDateString(), "");
                    BindDgv();
                }
                catch (Exception ea)
                {
                    MessageBox.Show("出现错误!原因:" + ea.ToString());
                }
            }

        }



        /// <summary>
        /// 保存预约事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_Save_Click(object sender, EventArgs e)
        {
            SaveOrder();
            if (this._CurrentYylx == Mz_YYgh.YYgh_Sort.医生站预约 && this.txtkh.Text.Trim().Length < 1)
                return;
            BindDgv();
            Clear();
        }

        private void Clear()
        {
            this.Txt_Bz.Clear();
        }

        /// <summary>
        /// 保存预约挂号
        /// </summary>
        private void SaveOrder()
        {
            try
            {
                #region 常规验证
                if (string.IsNullOrEmpty(this.txtkh.Text.Trim()))
                {
                    MessageBox.Show("请输入卡号!", "提示");
                    return;
                }

                if (string.IsNullOrEmpty(this.txtxm.Text.Trim()))
                {
                    MessageBox.Show("输入的卡号获取不到病人信息!请确定输入的卡号是否正确!");
                    return;
                }

                if (Lab_Dept.SelectedValue == null)
                {
                    MessageBox.Show("预约科室不能为空!", "提示");
                    return;
                }
                if (Lab_Doctor.SelectedValue == null)
                {
                    MessageBox.Show("预约医生不能为空!", "提示");
                    return;
                }
                string sex = this.cmb_sex.SelectedValue.ToString();
                if (sex == "")
                {
                    MessageBox.Show("当前病人信息异常,找不到性别代码!请联系管理员", "提示");
                    return;
                }
                int ghjb = Convert.ToInt32(Convertor.IsNull(cmbghjb.SelectedValue, "0"));
                if (ghjb == 0)
                {
                    MessageBox.Show("未选择挂号级别!", "提示");
                    return;
                }
                int ghys = Convert.ToInt32(Convertor.IsNull(this.Lab_Doctor.SelectedValue, "0"));
                if (ghys == 0)
                {
                    MessageBox.Show("未选择挂号医生!", "提示");
                    return;
                }
                if (string.IsNullOrEmpty(this.cmb_sxw.Text.Trim()))
                {
                    MessageBox.Show("未选择上下午就诊时间", "提示");
                    return;
                }
                #endregion
                #region 数据保存
                Guid order_guid = Guid.Empty;//.NewGuid();

                int yyqjd = this.cmb_sxw.Text.Trim() == "上午" ? 1 : 2;
                string qhyzm = "";
                if (this._cfg1081.Config.Trim() == "0")
                {
                    qhyzm = Mz_YYgh.GetCheckNo(this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), this.dateTimePicker1.Value.Date.AddDays(1).ToString("yyyy-MM-dd"), InstanceForm.BDatabase);
                }
                string new_dlxh = string.Empty;
                string new_yzm = string.Empty;
                Guid new_yyid = new Guid();
                int err_code = 0;
                string err_text = string.Empty;
                decimal gh_fee = 0;
                int ghks = Convert.ToInt32(this.Lab_Dept.SelectedValue);
                string blb = cfgBlb.Config.Trim();
                Guid yhlx = Guid.Empty;
                string Memo = this.Txt_Bz.Text.Trim(); //备注信息 Add by zp 2014-09-25
                DataSet dset = mz_ghxx.mzgh_get_sfmx(1, 0, 0, ghks, ghjb,
                        ghys, "", 0, 0, yhlx, TrasenFrame.Forms.FrmMdiMain.Jgbm, out err_code, out err_text, _menuTag.Function_Name, InstanceForm.BDatabase);
                if (err_code != 0)
                {
                    MessageBox.Show(err_text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                //填写流水号,一张发票对应一个流水号
                for (int iFp = 0; iFp < dset.Tables[0].Rows.Count; iFp++)
                {
                    gh_fee = Convert.ToDecimal(dset.Tables[0].Compute("sum(zje)", ""));//计算结果集1表的总金额
                }
                if (this._cfg1081.Config == "0")//HIS方式
                {
                    int klx = Convert.ToInt32(this.cmbklx.SelectedValue);
                    //InstanceForm.BDatabase.BeginTransaction();
                    try
                    {
                        string yysd = this.Cmb_Times.Text.Trim();
                        Mz_YYgh.YYGH_save(order_guid, _CurrentYylx, this.txtkh.Text.Trim(), this.txtxm.Text.Trim(), sex,
                          this.txt_csrq.Text.Trim(), this.txtjtdz.Text.Trim(), this.txtgrlxfs.Text.Trim(), this.txt_Sfzh.Text.Trim(),
                          qhyzm, ghks, ghjb, ghys, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(),
                           _currentuser.EmployeeId, this.dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00"), yysd,
                           null, 0, yyqjd, 1, 0, gh_fee, klx, out new_yzm, "", out new_dlxh, out new_yyid, out err_code, out err_text,
                           InstanceForm.BDatabase, Memo);
                        if (err_code == 0)
                        {
                            // InstanceForm.BDatabase.CommitTransaction();
                            MessageBox.Show("预约登记成功!" + new_yzm, "提示");
                        }
                        else
                        {
                            //InstanceForm.BDatabase.RollbackTransaction();
                            MessageBox.Show("预约失败!原因:" + err_text, "提示");
                        }
                    }
                    catch (Exception ea)
                    {
                        //InstanceForm.BDatabase.RollbackTransaction();
                        MessageBox.Show("预约失败!原因:" + ea.Message, "提示");
                    }
                }
                else
                {
                    string msg = string.Empty;
                    string orderid = string.Empty;
                    if (this.Cmb_Times.SelectedValue == null)
                    {
                        MessageBox.Show("必须选择时段!", "提示");
                        return;
                    }
                    string numid = this.Cmb_Times.SelectedValue.ToString();
                    int klxid = Convert.ToInt32(this.cmbklx.SelectedValue);

                    try
                    {
                        //性别从代码改成汉子 B/S组曾高贤这边要求 Modify by zp 2014-07-10
                        sex = sex.Trim() == "1" ? "男" : "女"; //只有男女 
                        if (!this._orderMeans.SaveOrder(this.txtkh.Text.Trim(), this.txtxm.Text.Trim(), this.txt_Sfzh.Text.Trim(), sex,
                        this.txt_csrq.Text.Trim(), this.txtgrlxfs.Text.Trim(), this.txtjtdz.Text.Trim(), rowid, _cfg3060.Config.Trim(),
                        klxid, ref msg, ref new_yzm, ref orderid, ref numid, Memo)) //新增备注参数 Add by zp 2014-09-25
                        {
                            MessageBox.Show(msg, "提示", MessageBoxButtons.OK);
                            return;
                        }
                        else //Modify By zp 2014-03-28 更新成医生站预约
                        {
                            //Modify By zp 2014-07-15 更新预约平台id 统一由B/S的预约平台更新
                            MessageBox.Show("预约成功!取号时请出示诊疗卡或取号密码:" + "" + new_yzm + "" + "就诊", "提示", MessageBoxButtons.OK);
                        }
                    }
                    catch (Exception ea)
                    {
                        MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
                    }
                }
                #endregion
            }
            catch (Exception ea)
            {
                MessageBox.Show("预约登记出现错误!原因:" + ea.ToString(), "错误");
            }
        }
        /// <summary>
        /// 删除预约记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_Delete_Click(object sender, EventArgs e)
        {
            DeleteOrder();
            BindDgv();
        }
        /// <summary>
        /// 绑定dgv
        /// </summary>
        private void BindDgv()
        {
            try
            {
                string cardno = this.txtkh.Text.Trim();
                string sfzh = this.txt_Sfzh.Text.Trim();
                int klx = -1;
                if (!string.IsNullOrEmpty(cardno))
                {
                    klx = Convert.ToInt32(this.cmbklx.SelectedValue);
                }
                int err_code;
                string err_text;
                DataTable dt = Mz_YYgh.GetYYghInfo("", sfzh, cardno, "", Mz_YYgh.YYgh_Status.未作废未取号记录, "", "", klx, 0, 0, Mz_YYgh.YYgh_Sort.所有预约方式, out err_code,
                    out err_text, InstanceForm.BDatabase);
                this.Dgv_OrderInfo.DataSource = dt;
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
            }
        }
        /// <summary>
        /// 作废预约
        /// </summary>
        private void DeleteOrder()
        {
            try
            {
                if (this.Dgv_OrderInfo.SelectedRows.Count < 1)
                {
                    MessageBox.Show("请先选择需要删除的预约挂号记录", "提示");
                    return;
                }
                if (Convert.ToInt16(this.Dgv_OrderInfo.SelectedRows[0].Cells["Cl_bqhbz"].Value) == 1)
                {
                    MessageBox.Show("当前预约记录已取号!无法进行删除操作!", "提示");
                    return;
                }
                if (Convert.ToInt32(this.Dgv_OrderInfo.SelectedRows[0].Cells["Cl_yylxid"].Value) != (int)_CurrentYylx)
                {
                    MessageBox.Show("不能删除当前预约类型的预约记录!", "提示");
                    return;
                }

                Guid yyid = new Guid(this.Dgv_OrderInfo.SelectedRows[0].Cells["Cl_yyid"].Value.ToString());
                string name = Convertor.IsNull(this.Dgv_OrderInfo.SelectedRows[0].Cells["Cl_Name"].Value, "");
                if (_cfg1081.Config == "1") //平台注销
                {
                    string msg = string.Empty;
                    string ptbh = Convertor.IsNull(this.Dgv_OrderInfo.SelectedRows[0].Cells["cl_ptid"].Value, "");
                    string qhpwd = Convertor.IsNull(this.Dgv_OrderInfo.SelectedRows[0].Cells["cl_yzm"].Value, "");
                    if (!_orderMeans.CancelOrder(ptbh, qhpwd, _cfg3060.Config.Trim(), ref msg))
                    {
                        MessageBox.Show("撤销预约失败!原因:" + msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                        MessageBox.Show("删除成功!", "提示");
                }
                else
                {
                    if (!Mz_YYgh.CanCelYYGH(yyid, name, InstanceForm.BDatabase))
                        MessageBox.Show("删除失败!", "提示");
                    else
                        MessageBox.Show("删除成功!", "提示");
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString());
            }
        }
        /// <summary>
        /// 通过身份证检索(当前并非从YY_BRXX表中以身份证获取信息)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void txt_Sfzh_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == '\r' && (!string.IsNullOrEmpty(this.txt_Sfzh.Text.Trim())))
        //    {
        //        int err_code;
        //        string err_text;
        //        DataTable dt = Mz_YYgh.GetYYghInfo("",this.txt_Sfzh.Text.Trim(), "", "", Mz_YYgh.YYgh_Status.未作废记录,"","",-1,
        //            out err_code, out err_text, InstanceForm.BDatabase);
        //        if (dt.Rows.Count > 0)
        //        {
        //            this.txtkh.Text = Convertor.IsNull(dt.Rows[dt.Rows.Count - 1]["卡号"], "");
        //            this.txtxm.Text = Convertor.IsNull(dt.Rows[dt.Rows.Count - 1]["姓名"], "");
        //            this.cmb_sex.SelectedValue = dt.Rows[dt.Rows.Count - 1]["xb"].ToString();
        //            this.txt_csrq.Text = Convertor.IsNull(dt.Rows[dt.Rows.Count - 1]["出生日期"], "");
        //            this.txtgrlxfs.Text = Convertor.IsNull(dt.Rows[dt.Rows.Count - 1]["联系方式"], "");
        //            this.txtjtdz.Text = Convertor.IsNull(dt.Rows[dt.Rows.Count - 1]["家庭地址"], "");
        //            BindDgv();
        //        }
        //        else
        //        {
        //            MessageBox.Show("输入的身份证未获取到预约数据!", "提示");
        //            return;
        //        }
        //    }
        //}
        /// <summary>
        /// 调出医生排班信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_SelectPb_Click(object sender, EventArgs e)
        {
            int dept_id = Convert.ToInt32(Convertor.IsNull(this.Lab_Dept.SelectedValue, "-1"));
            int emp_id = Convert.ToInt32(Convertor.IsNull(this.Lab_Doctor.SelectedValue, "-1"));
            DateTime bdate = this.dateTimePicker1.Value;
            Frm_PbInfo frm = new Frm_PbInfo(dept_id, emp_id, bdate, bdate);
            frm.GetPbEvent += SetPbControlsValue;//注册方法
            frm.ShowDialog();

        }

        private void cmb_Sd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb_sxw.SelectedIndex >= 0)
            {
                if (this._cfg1081.Config.Trim() == "0")
                {
                    SetDataSet(0);
                    SetDataSet(1);
                    FullLabXh();
                    BindCmbTime();
                }
                else
                {
                    //分院内和医生站 不再检索医生、科室数据 
                    //SetDataSet(1);
                    this.IsSelect = true;
                    FullCmbSd();
                }

            }
        }
        /// <summary>
        /// 填充预约时段下拉
        /// </summary>
        private void FullCmbSd()
        {
            try
            {
                if (!this.IsSelect) { return; }
                if (_cfg1081.Config.Trim() == "0") { return; }
                string deptid = ""; ; //XcConvert.IsNull(txtRegDept.SelectedValue, "");
                string doctorid = ""; // XcConvert.IsNull(txtRegDoctor.SelectedValue, "");
                DataTable dt_time = null;
                string date = this.dateTimePicker1.Value.ToString("yyyyMMdd");
                string ampm = this.cmb_sxw.Text == "上午" ? "1" : "2";
                deptid = Convertor.IsNull(this.Lab_Dept.SelectedValue, ""); //XcConvert.IsNull(txtRegDept.SelectedValue, "");
                doctorid = Convertor.IsNull(this.Lab_Doctor.SelectedValue, ""); // XcConvert.IsNull(txtRegDoctor.SelectedValue, "");
                if (deptid.Length > 0 && ampm.Length > 0 && doctorid.Length > 0 && date.Length > 0)
                {
                    string HosptId = this._cfg3059.Config;
                    rowid = string.Format("{0}_{1}_{2}_{3}_{4}",
                      HosptId, deptid, doctorid, ampm, date);
                    string post = _orderMeans.GetNumberId(rowid, this._cfg3060.Config.Trim());
                    dt_time = Analy_Order.GetOrderTimes(post);
                    DataRow dr = dt_time.NewRow();
                    dr["NumberID"] = -1;
                    dr["tsTimeSlot"] = "";
                    dt_time.Rows.InsertAt(dr, 0);
                    this.Cmb_Times.DataSource = dt_time;
                    this.Cmb_Times.DisplayMember = "tsTimeSlot";
                    this.Cmb_Times.ValueMember = "NumberID";
                    this.IsSelect = false;
                }
                else
                {
                    this.Cmb_Times.DataSource = null;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbghjb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_cfg1081.Config.Trim() == "0")
            {
                SetDataSet(0);
                SetDataSet(1);
                FullLabXh();
            }
            else
            {
                if (this.Lab_Dept.SelectedValue != null && this.Lab_Doctor.SelectedValue != null && this.cmbghjb.SelectedValue != null)
                {
                    int sxw = this.cmb_sxw.Text.Trim() == "下午" ? 2 : 1;
                    string sql = @" select * from jc_mz_yspb where CONVERT(varchar(10),PBSJ,120)='" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + @"'  
                    and PBKSID=" + this.Lab_Dept.SelectedValue + " and pblx=" + sxw + " and YSID=" + this.Lab_Doctor.SelectedValue + " AND ZZJBID=" + this.cmbghjb.SelectedValue + "";
                    DataTable dt = FrmMdiMain.Database.GetDataTable(sql);
                    if (dt.Rows.Count <= 0)
                    {
                        this.Lab_Doctor.SelectedValue = null;
                    }
                }
                this.IsSelect = true;
                FullCmbSd();
            }
        }


        /// <summary>
        /// 通过委托从排班查询界面获取数据集填充当前
        /// </summary>
        /// <param name="dt"></param>
        public void SetPbControlsValue(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                this.IsSelect = true;
                this.dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0]["pbrq"]);
                this.cmbghjb.SelectedValue = dt.Rows[0]["zzjb"];
                this.Lab_Dept.SelectedValue = dt.Rows[0]["dept_id"];
                this.Lab_Doctor.SelectedValue = dt.Rows[0]["doc_id"];
                this.cmb_sxw.Text = dt.Rows[0]["pbsd"].ToString();
                BindCmbTime();
            }
        }
        /// <summary>
        /// 获取限号信息
        /// </summary>
        private void FullLabXh()
        {
            if (!IsSelect) { return; }
            if (_cfg1081.Config == "1") { return; }
            string memo = "";
            int err_code = 0;
            string err_text = "";
            try
            {
                if (this.Lab_Dept.SelectedValue == null)
                {
                    return;
                }
                if (this.Lab_Doctor.SelectedValue == null)
                {
                    return;
                }
                if (this.cmbghjb.SelectedValue == null)
                {
                    return;
                }
                int ksdm = Convert.ToInt32(this.Lab_Dept.SelectedValue);
                int ysdm = Convert.ToInt32(this.Lab_Doctor.SelectedValue);
                int level = Convert.ToInt32(this.cmbghjb.SelectedValue);
                int sxw = cmb_sxw.Text.Trim() == "上午" ? 1 : 2;

                Mz_YYgh.GetOrderXhInfo(ksdm, ysdm, level, 1, sxw, this.dateTimePicker1.Value.ToString(), out memo, out err_code, out err_text, InstanceForm.BDatabase);
                this.lblxh.Text = memo.Trim();
                if (err_code != 0)
                {
                    this.lblxh.ForeColor = Color.Red;
                }
                else
                {
                    this.lblxh.ForeColor = Color.Black;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.Cmb_Times.DataSource = null;
            this.IsSelect = true;
            SetDataSet(0);
            if (this._cfg1081.Config.Trim() == "0")
            {
                SetDataSet(1);
                FullLabXh();
                FullCmbSd();
            }
            else
            {
                if (this._CurrentYylx == Mz_YYgh.YYgh_Sort.医生站预约) //ADD BY ZP 2014-10-07医生站预约才从排班获取数据源
                    FullDocLevel();
                this.IsSelect = true;
                SetDataSet(1);
                FullCmbSd();
            }
        }

        private void Lab_Doctor_LabelTextBoxSelectedValueChanged(object sender, object oldValue, object newValue)
        {
            if (this.Lab_Dept.SelectedValue == null && this.Lab_Doctor.SelectedValue != null)
            {
                DataRow[] drs = _ds.Tables["dt_doc"].Select("医生id=" + this.Lab_Doctor.SelectedValue + "");
                if (drs.Length > 0)
                {
                    this.Lab_Dept.SelectedValue = drs[0]["科室ID"].ToString();
                }
            }
            this.IsSelect = true;
            FullLabXh();
            FullCmbSd();
        }

        private void Lab_Dept_LabelTextBoxSelectedValueChanged(object sender, object oldValue, object newValue)
        {

            if (this._cfg1081.Config.Trim() == "0")
            {
                FullLabXh();
                SetDataSet(1);
            }
            else
            {
                if (this._CurrentYylx != Mz_YYgh.YYgh_Sort.医生站预约)
                    this.Lab_Doctor.SelectedValue = null;
            }

        }
        /// <summary>
        /// 下拉值改变时 显示限号值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Times_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.lblxh.Text = "";
                if (Cmb_Times.SelectedValue == null)
                {
                    return;
                }
                if (int.Parse(_cfg1081.Config) != 0)
                {
                    DataTable dt = (DataTable)this.Cmb_Times.DataSource;
                    string numid = Cmb_Times.SelectedValue.ToString();
                    DataRow[] drs = dt.Select("NumberID='" + numid + "'");
                    if (drs.Length < 1 || drs[0]["tsTimeRange"].ToString().Trim().Length < 1) { return; }

                    int xhs = Convert.ToInt32(drs[0]["tsSumCount"]);
                    int yghs = Convert.ToInt32(drs[0]["tsRegisterCount"]);
                    this.lblxh.Text = "" + yghs + "/" + "" + xhs + "" + " 已挂号数:" + yghs + " 限号数:" + xhs.ToString();
                }
                else
                {
                    /*获取所选时段的限号情况*/
                    FsdClass _fsd = new FsdClass();
                    DateTime date = this.dateTimePicker1.Value;
                    int sxwid = 1;
                    if (this.cmb_sxw.SelectedIndex == 1)
                        sxwid = 2;
                    DataTable dt = _fsd.GetSdXhInfo(date.ToString(), 0, Convert.ToInt64(Cmb_Times.SelectedValue), "", sxwid, InstanceForm.BDatabase);
                    if (dt == null || dt.Rows.Count <= 0) return;
                    string yghs = dt.Rows[0]["已挂号人数"].ToString();
                    string xhs = dt.Rows[0]["总资源数"].ToString();
                    this.lblxh.Text = yghs + "/" + xhs + "已挂号数:" + yghs + " 限号数:" + xhs;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
            }

        }

        private void Lab_Doctor_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this._CurrentYylx != Mz_YYgh.YYgh_Sort.院内预约) return;
                //选择医生LAB时候 获取医生数据
                IsSelect = true;
                SetDataSet(1);
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message);
            }
        }

    }
}
