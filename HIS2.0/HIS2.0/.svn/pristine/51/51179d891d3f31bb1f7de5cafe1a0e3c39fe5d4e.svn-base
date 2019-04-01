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
using ts_yb_interface;
using TrasenFrame.Forms;
using System.Text;
using TrasenClasses.DatabaseAccess;
using Ts_Visit_Class;
using ts_mzys_class;
using System.Net;

namespace ts_mz_gh
{
    public partial class Frmghdj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private DataTable Tbks;//挂号科室数据
        private DataTable Tbys;//挂号医生数据
        private int Fplx;//发票类型 0 挂号票 1 收费票
        private DataTable tbk;//病人卡信息
        //用于控制窗口控件可用性变量
        private string ghlb_ini = "";
        private string klx_ini = "";
        private string kh_ini = "";
        private string xm_ini = "";
        private string xb_ini = "";
        private string nl_ini = "";
        private string lxfs_ini = "";
        private string jtdz_ini = "";
        private string brlx_ini = "";
        private string ghks_ini = "";
        private string ghjb_ini = "";
        private string ghys_ini = "";
        private string yblx_ini = "";
        private string readcard_ini = "";
        private string blb_ini = "";
        private string sfplx_ini = "";
        private string Bview = "";//发票预览
        /// <summary>
        /// 系统参数 - 挂号时允许新卡
        /// </summary>
        private string New_Card = ""; //挂号时允许新卡
        /// <summary>
        /// 系统参数 - 刷卡时不允许改病人信息
        /// </summary>
        private string Modif_ini = "";//刷卡时不允许改病人信息
        /// <summary>
        /// 系统参数 - 挂号时必须使用卡
        /// </summary>
        private string syk_ini = "";//挂号时必须使用卡
        private long Jgbm = 0;//机构编码
        /// <summary>
        /// 医保病人信息对象
        /// </summary>
        private ts_yb_mzgl.BRXX brxx = new ts_yb_mzgl.BRXX();
        private ts_yb_mzgl.CFMX[] cfmx;
        private ts_yb_mzgl.JSXX jsxx;

        private DataTable Ybcard;//医保卡信息
        private DataTable Ybbrxx;//医保病人信息
        private IntPtr Pint;

        private string yb_dylx = "";
        private string yb_dylxmc = "";
        private string yb_bzxx = "";
        private SystemCfg cfgsfy = new SystemCfg(3016);
        /// <summary>
        /// 系统定义的病历本种类,add by wangzhi 2010-10-26
        /// </summary>
        private SystemCfg cfgBlb = new SystemCfg(1018);
        /// <summary>
        /// 本次操作是否创建了一张新卡
        /// </summary>
        //Add By Tany 2010-09-18 这里用于收费是否收卡费
        private bool _isCreateNewCard = false;
        private SystemCfg cfgnl = new SystemCfg(1050);
        private SystemCfg cfgpb = new SystemCfg(1051);
        private SystemCfg cfgpbys = new SystemCfg(1052);
        private SystemCfg cfg1046 = new SystemCfg(1046);
        //门诊挂号输入医生时只检索对应科室的医生
        private SystemCfg cfg1058 = new SystemCfg(1058);
        private SystemCfg cfg1060 = new SystemCfg(1060);//Add By Zj 2012-05-10 是否验证卡的英文字母
        private SystemCfg cfg3035 = new SystemCfg(3035);//Add By Zj 2012-06-07 打印发票使用诊间名称还是科室名称
        private SystemCfg cfg1065 = new SystemCfg(1065);//门诊本机收费数据下载间隔提醒时间 Add By Zj 2012-10-08
        private SystemCfg cfg1078 = new SystemCfg(1078);//*add by zch 2013-03-26 门诊小票打印是否打在一张上（只切纸一次）0=否 ，1=是 */
        private SystemCfg cfg1079 = new SystemCfg(1079);//*add by zch 2013-03-28 门诊小票打印是否打在一张上（只切纸一次）0=否 ，1=是 */
        private SystemCfg cfg_1093 = new SystemCfg(1093);//Add By zp 2013-09-22 挂号是否只允许刷卡消费 0否 1是 默认0
        /// <summary>
        /// 是否启用新分诊叫号系统 add by zp 2013-07-11
        /// </summary>
        private SystemCfg cfg3070 = new SystemCfg(3070);
        /// <summary>
        /// 门诊挂号科室对应的年龄 格式:科室id|年龄 通过符号","区分科室
        /// </summary>
        private SystemCfg cfg1088 = new SystemCfg(1088);
        public SystemCfg cfg1099 = new SystemCfg(1099); //Add by zp 2013-11-08 是否启用分时段挂号0不启用1启用 默认0
        private SystemCfg cfg1114 = new SystemCfg(1114);//add by jiangzf 2014-4-22 合同单位病人是否打印发票 1不打印 0打印 默认0
        /// <summary>
        /// 0:挂/限/余,1:挂/限,2:限/余,3:挂/余
        /// </summary>
        private SystemCfg cfg1155 = new SystemCfg(1155);
        /// <summary>
        /// 是否启用由系统自动产生的条码卡（0:否 1:是)
        /// </summary>
        private SystemCfg cfg1161 = new SystemCfg(1161);
        /// <summary>
        /// 零金额是否不打印发票 0-否 1-是
        /// </summary>
        private SystemCfg cfg1163 = new SystemCfg(1163);
        /// <summary>
        /// 新办卡时返回的未保存的病人信息及卡信息 add by wangzhi 2010-10-27
        /// </summary>
        private MZ_BRXX_KXX _new_brxx_kxx;
        private DataTable dt_AgeToDocLevel = null;//存储年龄自动选择挂号级别的记录 病人年龄、挂号级别 为空挂号则不验证 Add By zp 2013-09-03 
        private DataTable dt_ghksxz = null; //挂号科室限制内存表 挂号下拉不能包含的科室 add by zp 2013-12-14
        private bool Isyy = false; //是否在预约 Add By zp 2014-03-26 
        /// <summary>
        /// 用于标示是否收取卡费，一般在允许新建卡并充值的情况下使用
        /// </summary>
        private bool _needChargeCardFee = false;
        public YY_BRXX_BC_MOL yy_brxx_bc = new YY_BRXX_BC_MOL();//add by cc

        public Frmghdj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

            ControlEnable();

            //add by zouchihua 2013-4-17 开始加载报表打印
            this.backgroundWorker1.RunWorkerAsync();


        }

        private void Frmghdj_Load(object sender, EventArgs e)
        {
            try
            {
                panel_yanzheng.Height = 0;
                //添加合同单位类型
                FunAddComboBox.AddHtdwLx(false, cmbdwlx, InstanceForm.BDatabase);
                cmbdwlx.SelectedIndex = -1;
                //添加病人类型
                FunAddComboBox.AddBrlx(false, 0, cmbbrlx, InstanceForm.BDatabase);
                //添加挂号类型
                FunAddComboBox.AddGhlx(false, 0, cmbghlx, InstanceForm.BDatabase);
                //添加卡类型
                FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
                //添加挂号级别
                FunAddComboBox.AddGhjb(false, 0, cmbghjb, InstanceForm.BDatabase);
                //添加医保类型
                FunAddComboBox.AddYblx(false, 0, cmbyblx, InstanceForm.BDatabase);
                //添加性别
                FunAddComboBox.Addxb(false, cmbxb, InstanceForm.BDatabase);
                //年龄单位
                #region 年龄
                DataTable tbnl = new DataTable();
                tbnl.Columns.Add("ID", Type.GetType("System.Int32"));
                tbnl.Columns.Add("NAME", Type.GetType("System.String"));
                DataRow row = tbnl.NewRow();
                row["ID"] = 0;
                row["NAME"] = "岁";
                tbnl.Rows.Add(row);
                row = tbnl.NewRow();
                row["ID"] = 1;
                row["NAME"] = "月";
                tbnl.Rows.Add(row);
                row = tbnl.NewRow();
                row["ID"] = 2;
                row["NAME"] = "天";
                tbnl.Rows.Add(row);
                row = tbnl.NewRow();
                row["ID"] = 3;
                row["NAME"] = "小时";
                tbnl.Rows.Add(row);
                cmbDW.DisplayMember = "NAME";
                cmbDW.ValueMember = "ID";
                cmbDW.DataSource = tbnl;
                cmbDW.SelectedIndex = 0;
                #endregion
                //添加优惠方案
                AddYhlx();
                this.dt_AgeToDocLevel = ts_mz_class.Fun.FillDocLevelByPatAge();
                IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
                string ip = addressList[0].ToString().Trim();
                this.dt_ghksxz = Fun.GetGhKsXz(ip, InstanceForm.BDatabase); //得到挂号科室下拉需屏蔽的科室信息
            }
            catch (System.Exception err)
            {
                //Add by Zj 2012-2-11 添加错误提示
                MessageBox.Show("初始化错误!错误代码:1,原因:" + err.Message);
            }
            this.WindowState = FormWindowState.Maximized;
            Jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
            //ADD BY CC Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
            SystemCfg cfg1116 = new SystemCfg(1116);
            if (cfg1116.Config.ToString() == "0")
            {
                Tbks = Fun.GetGhks(false, InstanceForm.BDatabase);
            }
            else
            {
                Tbks = GetGhks_lyfy(false, InstanceForm.BDatabase, cfg1116.Config.Trim());
            }
            RefGhKsInfo(); //Add by zp 2013-12-14
            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);
            //ReadGhxx();
            //报价器 欢迎
            #region 报价器代码
            try
            {
                string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqybjq == "true")
                {
                    string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                    call.SetPicture(InstanceForm.BCurrentUser.EmployeeId.ToString());  //(txtxm.Text.Trim());
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("报价器出现异常!原因:" + ea.Message, "提示");
            }
            #endregion
            //窗口控制 如果没有交账  禁用全部控件
            try
            {
                mz_sf.CKJZKZ(InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);
            }
            catch (System.Exception err)
            {
                for (int i = 0; i <= panel1.Controls.Count - 1; i++)
                    panel1.Controls[i].Enabled = false;
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //添加排班科室树形
            if (cfgpb.Config == "0")
                tabControl1.TabPages.Remove(tabPage2);
            else
                AddDeptTree();
            //初始化新病人
            butnew_Click(sender, e);

            //Add By Zj 2012-10-15 本机收费数据下载
            if (cfg1065.Config != "0")
            {
                string applicationName = "";
                string link = "";
                string LinkDBName = "";
                //RelationalDatabase Database = null;
                ParameterEx[] parameters = new ParameterEx[1];
                try
                {
                    applicationName = ApiFunction.GetIniString("SERVER_NAME", "NAME", Constant.ApplicationDirectory + "\\LocalClientConfig.ini");
                    link = TrasenClasses.GeneralClasses.Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "Link", Constant.ApplicationDirectory + "\\LocalClientConfig.ini"));//Add By Zj 2012-10-07
                    LinkDBName = TrasenClasses.GeneralClasses.Crypto.Instance().Decrypto(ApiFunction.GetIniString(applicationName, "LinkDBName", Constant.ApplicationDirectory + "\\LocalClientConfig.ini"));//Add By Zj 2012-10-07
                    parameters[0].Text = "@servername";
                    parameters[0].Value = "[" + link + "].[" + LinkDBName + "]";

                }
                catch (Exception Ex)
                {
                    MessageBox.Show("连接本地数据失败!请打开本地数据库或者尝试联系管理员!" + Ex.Message, "提示");
                }
                if (link != "")
                {
                    MessageBox.Show("请仔细核对您的电脑发票号是否和实际发票号一致!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (new SystemCfg(1137).Config == "1")
                panel10.Visible = true;

            #region//自动读射频卡,全部初始化完后再来开启外接设备
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (sbxh != "")
            {
                ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);

                if (ReadCard != null)
                    ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
            }
            #endregion

        }




        public static DataTable GetGhks_lyfy(bool jzks, RelationalDatabase _DataBase, string strNoteTemp)
        {
            string strNote = strNoteTemp;
            string strDept = InstanceForm.BCurrentDept.DeptId.ToString();
            string[] strDeptList = strNote.Split('|');
            int iCount = 0;
            for (int i = 0; i < strDeptList.Length; i++)
            {
                if (strDeptList[i].ToString().IndexOf(InstanceForm.BCurrentDept.DeptId.ToString()) >= 0)
                {
                    iCount = i;
                    break;
                }
            }
            string strDeptAll = strDeptList[iCount].ToString().Split('-')[1];

            //原代码

            string ssql = "";
            SystemCfg cfg = new SystemCfg(1057, _DataBase);
            if (jzks == false)
                ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where layer=3 and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and deleted=0 " +
                          " and dept_id in (select dept_id from jc_dept_type_relation where type_code in(" + cfg.Config + "))";
            else
                ssql = "select DEPT_ID, NAME ,D_CODE,PY_CODE,wb_code from jc_dept_property where layer=3 and  jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " and deleted=0 " +
                          " and dept_id in (select dept_id from jc_dept_type_relation where type_code in('003'))";
            return _DataBase.GetDataTable(ssql + " and dept_id  in" + strDeptAll);
        }
        //刷选出当前机器可以挂号的科室记录 Add by zp 2013-12-14
        private void RefGhKsInfo()
        {
            try
            {
                if (dt_ghksxz == null || dt_ghksxz.Rows.Count == 0) return;
                for (int i = 0; i < dt_ghksxz.Rows.Count; i++)
                {
                    DataRow[] drs = Tbks.Select("DEPT_ID=" + dt_ghksxz.Rows[i]["GHKSID"] + "");
                    if (drs.Length == 0) continue;
                    DataRow dr = drs[0];
                    Tbks.Rows.Remove(dr);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("RefGhKsInfo出现异常!原因:" + ea.Message, "提示");
            }
        }

        private void ControlEnable()
        {
            #region 窗口输入项的控制
            ghlb_ini = ApiFunction.GetIniString("挂号屏蔽项", "诊别", Constant.ApplicationDirectory + "//ClientWindow.ini");
            klx_ini = ApiFunction.GetIniString("挂号屏蔽项", "卡类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
            kh_ini = ApiFunction.GetIniString("挂号屏蔽项", "卡号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            xm_ini = ApiFunction.GetIniString("挂号屏蔽项", "姓名", Constant.ApplicationDirectory + "//ClientWindow.ini");
            xb_ini = ApiFunction.GetIniString("挂号屏蔽项", "性别", Constant.ApplicationDirectory + "//ClientWindow.ini");
            nl_ini = ApiFunction.GetIniString("挂号屏蔽项", "年龄", Constant.ApplicationDirectory + "//ClientWindow.ini");
            lxfs_ini = ApiFunction.GetIniString("挂号屏蔽项", "联系方式", Constant.ApplicationDirectory + "//ClientWindow.ini");
            jtdz_ini = ApiFunction.GetIniString("挂号屏蔽项", "家庭地址", Constant.ApplicationDirectory + "//ClientWindow.ini");
            brlx_ini = ApiFunction.GetIniString("挂号屏蔽项", "病人类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ghks_ini = ApiFunction.GetIniString("挂号屏蔽项", "挂号科室", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ghjb_ini = ApiFunction.GetIniString("挂号屏蔽项", "挂号级别", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ghys_ini = ApiFunction.GetIniString("挂号屏蔽项", "挂号医生", Constant.ApplicationDirectory + "//ClientWindow.ini");
            yblx_ini = ApiFunction.GetIniString("挂号屏蔽项", "医保类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
            readcard_ini = ApiFunction.GetIniString("挂号屏蔽项", "读卡", Constant.ApplicationDirectory + "//ClientWindow.ini");
            blb_ini = ApiFunction.GetIniString("挂号屏蔽项", "病历本", Constant.ApplicationDirectory + "//ClientWindow.ini");

            sfplx_ini = new SystemCfg(1005).Config == "0" ? "true" : "false";//
            syk_ini = new SystemCfg(1009).Config == "1" ? "true" : "false";
            Bview = ApiFunction.GetIniString("划价收费", "挂号发票预览", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (Bview == null || Bview == "")
                Bview = ApiFunction.GetIniString("划价收费", "发票预览", Constant.ApplicationDirectory + "//ClientWindow.ini");

            New_Card = new SystemCfg(1010).Config == "1" ? "true" : "false";
            Modif_ini = new SystemCfg(1011).Config == "1" ? "true" : "false";


            Fplx = sfplx_ini == "true" ? 1 : 0;
            cmbghlx.Enabled = ghlb_ini == "true" ? false : true;
            cmbklx.Enabled = klx_ini == "true" ? false : true;
            txtkh.Enabled = kh_ini == "true" ? false : true;
            txtxm.Enabled = xm_ini == "true" ? false : true;
            cmbxb.Enabled = xb_ini == "true" ? false : true;
            txtnl.Enabled = nl_ini == "true" ? false : true;
            cmbDW.Enabled = nl_ini == "true" ? false : true;
            txtgrlxfs.Enabled = lxfs_ini == "true" ? false : true;
            txtjtdz.Enabled = jtdz_ini == "true" ? false : true;
            cmbbrlx.Enabled = brlx_ini == "true" ? false : true;
            txtks.Enabled = ghks_ini == "true" ? false : true;
            cmbghjb.Enabled = ghjb_ini == "true" ? false : true;
            txtys.Enabled = ghys_ini == "true" ? false : true;
            cmbyblx.Enabled = yblx_ini == "true" ? false : true;
            butreadcard.Enabled = readcard_ini == "true" ? false : true;
            chkblb.Enabled = blb_ini == "true" ? false : true;
            #endregion
        }
        /// <summary>
        /// 新号按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butnew_Click(object sender, EventArgs e)
        {
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");

            //Add By tany2010-09-18
            _isCreateNewCard = false;

            this.Tag = Guid.Empty.ToString(); //存储了病人信息ＩＤ
            lbljyh.Text = "";
            cmbyblx.SelectedIndex = -1;
            lblfph.Text = "";
            //Add By Zj 因为设备的特殊原因不能清空卡号 而是去掉了控件中的默认值
            //if (sbxh == "") 
            txtkh.Text = ""; //Modify By zp 2013-09-23 不管是否启用读卡设备 都清空卡号
            txtxm.Text = "";
            txtnl.Text = "";
            cmbDW.SelectedIndex = 0;
            txtgrlxfs.Text = "";
            txtjtdz.Text = "";
            lblkye.Text = "";
            lblmzh.Text = "";
            txtks.Text = "";
            txtks.Tag = "0";
            txtys.Text = "";
            txtys.Tag = "0";
            tbk = null;
            Ybbrxx = null;
            Ybcard = null;
            lblgzdw.Text = "";
            lblybrylx.Text = "";
            lblYbye.Text = "";
            lbljyh.Text = "";
            lblybxm.Text = "";

            lblghzs.Text = "0";
            //lblghzs.Visible = false;
            //label11.Visible = false;

            cmbdwlx.SelectedIndex = -1;
            txthtdw.Text = "";
            txthtdw.Tag = "0";
            lblxh.Text = "";

            label22.Text = "";

            yb_bzxx = "";
            yb_dylx = "";
            yb_dylxmc = "";

            jsxx.GRZF = 0;
            jsxx.ZHZF = 0;
            jsxx.TCZF = 0;
            jsxx.JSDH = "";
            jsxx.HisJsdid = 0;
            jsxx.HisJsid_Old = 0;
            jsxx.YBZF = 0;
            jsxx.ZJE = 0;

            brxx.BRXXID = Guid.Empty;
            brxx.GHXXID = Guid.Empty;
            brxx.GRBH = "";
            brxx.GSYWSQH = "";
            brxx.GZDW = "";
            brxx.ICD = "";
            brxx.ICDMC = "";
            brxx.JSSJH = "";
            brxx.KH = "";
            brxx.KLX = 0;
            brxx.KYE = "";
            brxx.LXDH = "";
            brxx.RYLB = "";
            brxx.RYLBMC = "";
            brxx.SFZH = "";
            brxx.XB = "";
            brxx.YLBZKKH = "";
            brxx.YLZH = "";
            brxx.YWLX = "";
            brxx.YWLXMC = "";
            brxx.YWSQH = "";
            brxx.YWZLX = "";
            brxx.YWZLXMC = "";

            Tbys = Fun.GetGhys(0, InstanceForm.BDatabase);


            lblmzh.Text = Fun.GetNewMzh(InstanceForm.BDatabase);

            butnew.Enabled = false;

            //获得可用发票号
            if (cfg1046.Config == "1")
            {
                int err_code; string err_text;
                DataTable tb = Fun.GetFph(InstanceForm.BCurrentUser.EmployeeId, 1, Fplx, out err_code, out err_text, InstanceForm.BDatabase);
                if (tb.Rows.Count == 0 || err_code != 0)
                {
                    MessageBox.Show(err_text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lblfph.Text = Convertor.IsNull(tb.Rows[0]["QZ"], "") + tb.Rows[0]["fph"].ToString().Trim();
            }

            if (cmbbrlx.Items.Count > 0) cmbbrlx.SelectedIndex = 0;

            if (cmbbrlx.Items.Count > 0) cmbbrlx.SelectedIndex = 0;
            //添加优惠方案
            AddYhlx();

            //报价器 姓名
            //string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
            //if (bqybjq == "true")
            //{
            //    string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            //    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
            //    call.Call(ts_call.DmType.清除, "");
            //}

            //if (cmbghlx.Enabled == true) { cmbghlx.Focus(); return; }
            //if (cmbbrlx.Enabled == true) { cmbbrlx.Focus(); return; }
            //if (cmbklx.Enabled == true) { cmbklx.Focus(); return; }

            _new_brxx_kxx = null;  // add by wangzhi 2010-10-27 
            // 新号或者清除时将新病人信息和卡登记信息置Null
            rdonl.Checked = true;
            if (txtkh.Enabled == true) { txtkh.Focus(); return; }
            if (txtxm.Enabled == true) { txtxm.Focus(); return; }
            if (txtks.Enabled == true) { txtks.Focus(); return; }
            if (txtys.Enabled == true) { txtys.Focus(); return; }
            if (Isyy)
            {
                Isyy = false;
                butqh.Tag = "";
                butqh.BackColor = Color.WhiteSmoke;
                txtks.Enabled = true;
                cmbghjb.Enabled = true;
                txtys.Enabled = true;
                treeView1.Enabled = true;
            }
        }


        /// <summary>
        /// 回车跳至下一个文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                if (control.Name == "txtnl" && cfgnl.Config == "1" && control.Text.Trim() == "")
                {
                    return;
                }
                if (control.Name == "cmbDW")
                {
                    if (txtgrlxfs.Enabled == true) { txtgrlxfs.Focus(); return; }
                    if (txtjtdz.Enabled == true) { txtjtdz.Focus(); return; }
                    if (txtks.Enabled == true)
                    {
                        if (cfgpb.Config == "1" && cfgpbys.Config == "1" && txtys.Enabled == true)
                            txtys.Focus();
                        else
                            txtks.Focus();
                        return;
                    }
                }
                if (control.Name == "txtjtdz")
                {
                    if (txtks.Enabled == true) txtks.Focus(); return;
                }
                if (control.Name == "txtxm" && control.Text.Trim() == "")
                    return;

                SendKeys.Send("{TAB}");
                return;


            }
        }

        /// <summary>
        /// 输入法设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLanguage_Click(object sender, EventArgs e)
        {
            FrmSelectLanguage f = new FrmSelectLanguage();
            if (f.ShowDialog() == DialogResult.OK)
            {
                ApiFunction.WriteIniString("INPUTLANGUAGE", "N" + InstanceForm.BCurrentUser.LoginCode, f.SelectedInputLanguageName, Constant.ApplicationDirectory + "//CustomInputLanguage.ini");

            }
        }

        private void Language_Off(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            control.ImeMode = ImeMode.Close;
            Fun.SetInputLanguageOff();
        }

        private void Language_On(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            control.ImeMode = ImeMode.On;
            Fun.SetInputLanguageOn();
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            SystemCfg cfg1121 = new SystemCfg(1121);
            if (cfg1121.Config == "1")
            {
                int out_code = 0;
                string out_text = "";
                Fun.Isjz(InstanceForm.BCurrentUser.EmployeeId, out out_code, out out_text, InstanceForm.BDatabase);
                if (out_code == -1)
                {
                    MessageBox.Show(out_text);
                    return;
                }
            }
            if (cmbdwlx.SelectedIndex != -1 && (txthtdw.Text.Trim().Length == 0 || txthtdw.Tag == null))
            {
                MessageBox.Show("指定了单位类型，但没有选择合同单位,请选择合同单位", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                #region 变量付值
                string Msg = "";
                //long kdjid = 0;
                Guid brxxid = new Guid(Convertor.IsNull(this.Tag, Guid.Empty.ToString()));
                int ghlx = Convert.ToInt32(Convertor.IsNull(cmbghlx.SelectedValue, "0"));
                string _ghlx = Convertor.IsNull(cmbghlx.Text, "");
                int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                int _pdxh = 0;//排队序号
                string kh = txtkh.Text.Trim();
                string xm = txtxm.Text.Trim();

                decimal zje = 0;
                decimal yhje = 0;
                decimal srje = 0;
                decimal zfje = 0;
                decimal ybzf = 0;
                int fpzs = 0;//发票张数 Add By Zj 2012-12-13
                //Add By Tany 2010-06-30
                decimal ybzhzf = 0;//医保帐户支付
                decimal ybjjzf = 0;//医保基金支付
                decimal ybbzzf = 0;//医保补助支付

                decimal ybkye = Convert.ToDecimal(Convertor.IsNull(lblYbye.Text, "0"));

                if (Convertor.IsNumeric(txtnl.Text) == false && txtnl.Text.Trim() != "")
                {
                    MessageBox.Show("年龄请输入数字");
                    return;
                }

                Guid NewFpid = Guid.Empty;

                string csrq = "1900-01-01 00:00:00";
                if (rdocsrq.Checked == true) csrq = dtpcsrq.Value.ToShortDateString();
                if (rdonl.Checked == true && txtnl.Text.Trim() != "") csrq = dtpcsrq.Value.ToShortDateString();
                if (cfgnl.Config == "1" && txtnl.Text.Trim() == "" && rdonl.Checked == true)
                {
                    MessageBox.Show("年龄必须输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtnl.Focus();
                    return;
                }

                #region 新病人信息结构体
                if (brxxid == Guid.Empty)
                {
                    if (_new_brxx_kxx == null)
                        _new_brxx_kxx = new MZ_BRXX_KXX();
                    _new_brxx_kxx.Brxx.Brxm = txtxm.Text.Trim();
                    _new_brxx_kxx.Brxx.Xb = Convertor.IsNull(cmbxb.SelectedValue, "1");
                    _new_brxx_kxx.Brxx.Csrq = csrq;
                    _new_brxx_kxx.Brxx.Brlxfs = txtgrlxfs.Text.Trim();
                    _new_brxx_kxx.Brxx.Jtdz = txtjtdz.Text.Trim();
                    _new_brxx_kxx.Brxx.Brlx = Convert.ToInt32(Convertor.IsNull(cmbbrlx.SelectedValue, "0"));
                    if (Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0")) > 0)
                        _new_brxx_kxx.Brxx.Yblx = Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0"));
                    if (Convertor.IsNull(cmbyblx.Tag, "") != "")
                        _new_brxx_kxx.Brxx.Cbkh = Convertor.IsNull(cmbyblx.Tag, "");
                }
                #endregion

                int brlx = Convert.ToInt32(Convertor.IsNull(cmbbrlx.SelectedValue, "0"));
                string mzh = lblmzh.Text.Trim();
                string fph = "0";
                decimal ye = Convert.ToDecimal(Convertor.IsNull(lblkye.Text, "0"));
                int ghks = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));
                int ghjb = Convert.ToInt32(Convertor.IsNull(cmbghjb.SelectedValue, "0"));
                int ghys = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));
                int yblx = Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0"));
                string jydjh = lbljyh.Text.Trim();
                string cbkh = Convertor.IsNull(cmbyblx.Tag, "");

                string _message = "";

                #region add by wangzhi 2014-11-04 增加持卡人和当前病人是否一致的判断，防止先检索出信息后，再修改卡号后不回车直接点挂号而产生错误数据
                if (!mz_ghxx.ValidingPatInfoAndCardInfo(klx, kh, brxxid, InstanceForm.BDatabase, out  _message))
                {
                    MessageBox.Show(_message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                #endregion

                #region add by wangzhi 2014-09-10 增加性别、年龄 不允许挂号哪些科室 的限制判断，马王堆需求,原来还有个参数1088控制年龄

                DateTime? _boryDay = null;
                if (!string.IsNullOrEmpty(csrq))
                    _boryDay = Convert.ToDateTime(csrq);
                int? xb = null;
                xb = Convert.ToInt32(Convertor.IsNull(cmbxb.SelectedValue, "1"));
                if (!mz_ghxx.ValidingRestrictiveConditions(xb, _boryDay, ghks, InstanceForm.BDatabase, out _message))
                {
                    MessageBox.Show(_message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //2014-09-10
                //wangzhi:原来的参数1088也是用于控制某个年龄不能挂特定科室，与后来加的参数1143功能上一样，由于已经有医院再用，故保留MatchAge函数           
                /*限制挂号所需年龄 如儿科 指定16周岁内才允许挂号 add by zp 2013-07-17*/
                if (!MatchAge())
                    return;
                #endregion

                #region 住院欠费检查
                // add by wangzhi 2010-10-28
                if (CheckZyFee(brxxid, xm) == false)
                {
                    return;
                }
                // end add
                #endregion

                //获取参数设置的病历本类型，参数格式 1000,1001
                string blb = cfgBlb.Config.Trim();
                if (!String.IsNullOrEmpty(blb))
                {
                    FrmNoteBookSelect fNote = new FrmNoteBookSelect(blb);
                    if (fNote.ShowDialog() == DialogResult.OK)
                    {
                        blb = fNote.SelectedBLB;
                    }
                    else
                    {
                        blb = "";
                    }
                }
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                //卡属性
                mz_card card = new mz_card(klx, InstanceForm.BDatabase);
                //读取病人卡余额
                ReadCard readcard = new ReadCard(klx, kh, InstanceForm.BDatabase);
                ye = readcard.kye;

                if (readcard.sdbz == 1)
                {
                    MessageBox.Show("病人卡已冻结，暂不能消费。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (readcard.sdbz == 2)
                {
                    MessageBox.Show("病人卡已挂失，暂不能消费。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (kh.Trim() != "" && readcard.kdjid == Guid.Empty && New_Card != "true")
                {
                    MessageBox.Show("没有找到卡信息，请确认卡是否输入正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //150213  chencan/   验证卡号有效性
                if (txtkh.Text.Length != card.kcd && card.klx > 0 && txtkh.Text.Trim() != "")
                {
                    MessageBox.Show("卡位数必须符合系统设定的(" + card.kcd.ToString() + ")位长度", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cfg1060.Config == "0" && !Convertor.IsNumeric(txtkh.Text.Trim()))
                {
                    MessageBox.Show("卡号录入有误，不能出现字符!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InstanceForm.BDatabase.RollbackTransaction();
                    return;
                }

                //医保类型
                Yblx yb = new Yblx(yblx, InstanceForm.BDatabase);

                if (lblmzh.Text.Trim() == "")
                {
                    MessageBox.Show("门诊号为空，请检查");
                    return;
                }

                if (syk_ini == "true" && readcard.kdjid == Guid.Empty && kh == "")
                {
                    MessageBox.Show("必须输入卡号");
                    txtkh.Focus();
                    return;
                }

                if (xm_ini != "true" && xm == "")
                {
                    MessageBox.Show("请输入姓名");
                    txtxm.Focus();
                    return;
                }
                if (ghks_ini != "true" && ghks == 0)
                {
                    MessageBox.Show("请输入挂号科室");
                    txtks.Focus();
                    return;
                }
                //if (ghys_ini != "true" && ghys == 0)
                //{
                //    MessageBox.Show("请输入挂号医生");
                //    txtys.Focus();
                //    return;
                //}

                if (yb.ybjklx > 0)
                {
                    SystemCfg s = new SystemCfg(1031);
                    if (s.Config == "1" && lblybxm.Text.Trim() != "" && lblybxm.Text.Trim() != txtxm.Text.Trim() && lblybxm.Text.Trim() != "")
                    {
                        MessageBox.Show("不能收费！系统要求医保病人姓名与HIS系统中使用的姓名相同!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //预约相关信息
                int yylx = 0;
                string yysd = "";
                string yyqtxx = "";
                string ghsj = djsj;
                if (Convertor.IsNull(butqh.Tag, "0") != "0")
                {
                    string ssql = "select * from mz_yyghlb where yyid='" + Convertor.IsNull(butqh.Tag, "") + "'";
                    DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb.Rows.Count > 0)
                    {
                        yylx = Convert.ToInt32(tb.Rows[0]["yylx"]);
                        yysd = Convertor.IsNull(tb.Rows[0]["yysd"], "");
                        yyqtxx = "";
                        //chencan 预约取号的挂号时间处理
                        //如果预约记录有时段，则挂号时间是预约日期+时段；如果取号日期不是预约日期，则挂号日期=预约日期；如果取号日期是预约日期，则挂号日期=当前时间。
                        if (tb.Rows[0]["yyrq"] != null)
                        {
                            DateTime dt = Convert.ToDateTime(tb.Rows[0]["yyrq"]);
                            //Fun.DebugView(dt);
                            //预约日期+时段
                            if (!string.IsNullOrEmpty(yysd))
                            {
                                ghsj = dt.ToString("yyyy-MM-dd")+" " + yysd.Split('-')[0];
                            }
                            //挂号日期=预约日期
                            else if (DateTime.Parse(ghsj).ToString("yyyy-mm-dd") != dt.ToString("yyyy-mm-dd"))
                            {
                                ghsj = Convert.ToDateTime(tb.Rows[0]["yyrq"]).ToString();
                            }
                        }
                        _pdxh = Convert.ToInt32(tb.Rows[0]["pdxh"]);
                    }
                }
                #endregion
                int err_code = -1;
                string err_text = "";
                //Guid NewCfmxid = Guid.NewGuid(); //Add by zp 2013-12-13 因创智医保需要传输处方明细id所以 先生成处方明细id
                #region 医保预算
                string HDGS_MZH = "";
                try
                {

                    if (yb.isgh == true)
                    {
                        DataSet mxds = mz_ghxx.mzgh_get_sfmx(ghlx, brlx, yblx, ghks, ghjb, ghys, blb, ybzf, klx, new Guid(Convertor.IsNull(cmbyhlx.SelectedValue, Guid.Empty.ToString())), Jgbm, out err_code, out err_text, Convertor.IsNull(butqh.Tag, Guid.Empty.ToString()), InstanceForm.BDatabase);//改成yyid

                        DataRow[] Tab_yb = mxds.Tables[4].Select("groupid='挂号费'");//Modify By Zj 2012-12-19 医保传输 只传输挂号费

                        cfmx = new ts_yb_mzgl.CFMX[Tab_yb.Length];
                        for (int i = 0; i <= cfmx.Length - 1; i++)
                        {
                            cfmx[i].HJID = PubStaticFun.NewGuid().ToString();//Modify By tany 2010-08-06 挂号没有HJID Tab_yb.Rows[i]["hjid"].ToString();//Add By Tany 2010-08-06
                            cfmx[i].TJDXM = Tab_yb[i]["statitem_code"].ToString().Trim();
                            if (Tab_yb[i]["项目来源"].ToString() == "1")
                                cfmx[i].BM = Convertor.IsNull(yb.ypbm, "") + Tab_yb[i]["HISCODE"].ToString().Trim();
                            else
                                cfmx[i].BM = Convertor.IsNull(yb.xmbm, "") + Tab_yb[i]["HISCODE"].ToString().Trim();
                            cfmx[i].MC = Tab_yb[i]["item_name"].ToString().Trim().Trim();
                            cfmx[i].GG = "";
                            cfmx[i].JX = "";
                            cfmx[i].DJ = Tab_yb[i]["cost_price"].ToString();
                            decimal sl = Convert.ToDecimal(Tab_yb[i]["num"]);
                            cfmx[i].SL = sl.ToString();
                            cfmx[i].JE = Tab_yb[i]["je"].ToString();
                            cfmx[i].DW = Tab_yb[i]["item_unit"].ToString().Trim();
                            cfmx[i].SCCJ = "";
                            cfmx[i].YSDM = Convertor.IsNull(txtys.Tag, "");
                            cfmx[i].YSXM = Fun.SeekEmpName(Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0")), InstanceForm.BDatabase);
                            cfmx[i].KSDM = Convertor.IsNull(txtks.Tag, "");
                            cfmx[i].KSMC = Fun.SeekDeptName(Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0")), InstanceForm.BDatabase);
                            cfmx[i].FSSJ = djsj;
                            //cfmx[i].HJMXID = NewCfmxid.ToString(); //以前这里是注释的 创智需要划价明细id所以 现在启用 Add by zp 2013-12-13

                        }


                        if (cfmx.Length > 0)
                        {
                            ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yb.ybjklx);
                            bool bok = ybjk.Compute(false, yb.yblx.ToString(), yb.insureCentral, yb.hospid, InstanceForm.BCurrentUser.EmployeeId.ToString(), cfmx, brxx, ref jsxx);
                            if (bok == false) throw new Exception("医保试算没有成功");
                            ybzf = jsxx.YBZF;
                            zfje = jsxx.GRZF;

                            //Add By Tany 2010-06-30
                            ybzhzf = jsxx.ZHZF;
                            ybjjzf = jsxx.TCZF;
                            ybbzzf = jsxx.QTZF;
                            //Add by zp 2013-12-30 华东工伤需求
                            HDGS_MZH = jsxx.HDGS_MZH;
                        }
                        else
                            yb.isgh = false;  //如果挂号费为0 则更改为自费 Modify By zp 2013-10-14  
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("医保预算出现异常! 原因:" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                #endregion

                //bool b_ok = false;

                #region 限号判断
                //验证是否超过了限号
                try
                {
                    GetXh(false);
                }
                catch (System.Exception err)
                {
                    if (err.Message != "") MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                #endregion

                #region  通过挂号信息获得本次的收费联动明细项目

                //卡费的收取 如果传了卡类型就收卡费
                int _klx = 0;

                //if (New_Card == "true" && readcard.kdjid == Guid.Empty && txtkh.Text.Trim() != "")
                //Modify By Tany 2010-09-18 应该是卡登记ID不为空才能收卡费并且为本次创建的新卡
                //if (_isCreateNewCard && New_Card == "true" && readcard.kdjid != Guid.Empty && txtkh.Text.Trim() != "")
                //Modify By zp 2013-09-30 新卡办理后的卡登记id永远是空的  所以判断需要改变 以前是必须完全保存了病人信息和卡信息
                if (_isCreateNewCard && New_Card == "true" && readcard.kdjid == Guid.Empty && txtkh.Text.Trim() != "")
                {
                    _klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                }
                if (_isCreateNewCard && _needChargeCardFee)
                    _klx = 1;

                // add by wangzhi 2010-10-27 
                //当新病人信息卡信息不为Null时，说明是新办卡,设置_klx变量以便后台能够处理收取卡费
                if (_klx > 0)
                {

                    if (_new_brxx_kxx != null)
                    {
                        _klx = _new_brxx_kxx.Kdjxx.Klx;
                        //add by zouchihua 2013-4-17 如果是新卡，再判断一次看是否有挂号记录
                        string ssstr = "select * from YY_KDJB where KH='" + txtkh.Text.Trim() + "'and ZFBZ=0  and KLX=" + _klx;
                        DataTable tbtempxx = InstanceForm.BDatabase.GetDataTable(ssstr);
                        if (tbtempxx.Rows.Count > 0)
                        {
                            MessageBox.Show("系统检查到该卡号已经存在有效的卡信息！\r\n 请重新刷卡再进行挂号操作！！");
                            return;
                        }
                    }
                }
                //end add
                Guid yhlx = new Guid(Convertor.IsNull(cmbyhlx.SelectedValue, Guid.Empty.ToString()));
                DataSet dset = mz_ghxx.mzgh_get_sfmx(ghlx, brlx, yblx, ghks, ghjb, ghys, blb, ybzf, _klx, yhlx, Jgbm, out err_code, out err_text, Convertor.IsNull(butqh.Tag, Guid.Empty.ToString()), InstanceForm.BDatabase);

                if (err_code != 0)
                {
                    MessageBox.Show(err_text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }

                //填写流水号,一张发票对应一个流水号
                for (int iFp = 0; iFp < dset.Tables[0].Rows.Count; iFp++)
                    dset.Tables[0].Rows[iFp]["dnlsh"] = Fun.GetNewDnlsh(InstanceForm.BDatabase);


                zje = Convert.ToDecimal(dset.Tables[0].Compute("sum(zje)", ""));//计算结果集1表的总金额
                yhje = Convert.ToDecimal(dset.Tables[0].Compute("sum(yhje)", ""));//计算结果集1表的优惠金额
                srje = Convert.ToDecimal(dset.Tables[0].Compute("sum(srje)", ""));//计算结果集1表的舍入金额
                zfje = Convert.ToDecimal(dset.Tables[0].Compute("sum(zfje)", ""));//计算结果集1表的自付金额
                fpzs = dset.Tables[0].Rows.Count;//Add By Zj 2012-12-13 将发票张数赋值

                //if (new SystemCfg(1068).Config == "0")//Add By Zj 2012-12-20 诊疗卡费用不打印  发票为1张
                //    fpzs = 1;
                //如果分票 注释这些
                //zje = Convert.ToDecimal(dset.Tables[0].Rows[0]["zje"]);
                //yhje = Convert.ToDecimal(dset.Tables[0].Rows[0]["yhje"]);
                //srje = Convert.ToDecimal(dset.Tables[0].Rows[0]["srje"]);
                //zfje = Convert.ToDecimal(dset.Tables[0].Rows[0]["zfje"]);



                #endregion

                #region 收银对象框

                Frmsf f = new Frmsf(_menuTag, _chineseName, _mdiParent, InstanceForm.BDatabase);
                f.lblks.Text = txtks.Text.Trim();
                f.lblxm.Text = txtxm.Text.Trim();
                f.lblfph.Text = lblfph.Text.Trim();
                f.lblzje.Text = zje.ToString();
                f.lblklx.Text = cmbklx.Text.Trim();
                f.lblkye.Text = lblkye.Text.Trim();
                f.lblbrlx.Text = cmbbrlx.Text.Trim();
                f.lblyhje.Text = yhje == 0 ? "" : yhje.ToString();
                f.lblsrje.Text = srje == 0 ? "" : srje.ToString();
                f.txtybzf.Text = ybzf == 0 ? "" : ybzf.ToString();
                f.lblfps.Text = fpzs + " 张";
                f.txtybzf.Enabled = ybzf > 0 && Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0")) > 0 ? false : true;
                f.klx = readcard.klx;
                f.kdjid = readcard.kdjid;
                f.fpzs = fpzs;
                f.dataGridView1.DataSource = dset.Tables[1];
                f.lblhtdwlx.Text = cmbdwlx.Text;
                f.lblhtdw.Text = txthtdw.Text;


                //当选择了医保类型，但没有启用接口的情况下 医保输入框可用
                f.txtybzf.Enabled = false;
                if (yblx > 0 && jydjh.Trim() == "" && yb.isgh == false)
                    f.txtybzf.Enabled = true;

                if (yb.issf == true)
                    f.lblbz.Text = "帐户支付:" + ybzhzf.ToString() + " 统筹支付:" + ybjjzf.ToString() + " 其他支付:" + ybbzzf.ToString();

                //判断当前卡是否支持欠费挂帐 如果可以则欠费挂帐输入框可用

                //f.txtqfgz.Enabled = card.bqfgz;
                //f.txtcwjz.Enabled = card.bjebz == true && ye > 0 ? true : false;

                //判断当前卡是否支持欠费挂帐 如果可以则欠费挂帐输入框可用
                string ssqfgz = new SystemCfg(1025).Config == "0" ? "true" : "false";
                if (ssqfgz == "true") f.txtqfgz.Enabled = true; else f.txtqfgz.Enabled = false;
                if (card.klx > 0 && card.bqfgz == true)
                    f.txtqfgz.Enabled = card.bqfgz;
                if (new SystemCfg(1037).Config == "1") f.txtzpzf.Enabled = false;
                if (new SystemCfg(1038).Config == "1" && cmbdwlx.Text.Trim() == "") f.txtqfgz.Enabled = false;

                //卡中有余额
                if (ye > 0)
                {
                    if (ye >= zfje)
                    {
                        f.txtcwjz.Text = zfje.ToString();
                        f.lblysxj.Text = "0";
                    }
                    else
                    {
                        f.txtcwjz.Text = ye.ToString();
                        f.lblysxj.Text = Convert.ToDecimal(zfje - ye).ToString();
                    }
                }
                else
                {
                    f.txtcwjz.Enabled = false;
                    f.txtcwjz.Text = "";
                    f.lblysxj.Text = zfje.ToString();
                }


                //合同单位病人收银时,金额输入到挂帐一栏
                if (new SystemCfg(1036).Config == "1" && cmbdwlx.Text.Trim() != "")
                {
                    f.txtqfgz.Text = zfje.ToString();
                    f.lblysxj.Text = "0";
                }

                //报价器 应收 Modify by tck 2013-11-21
                string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqybjq == "true")
                {
                    string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);

                    /* 因为公司报价器已经还给邵阳人医,无法测试 所以此处先注释 继续用老的模式
                    ts_call.CallFactory.cwjz = Convert.ToDecimal(Convertor.IsNull(f.txtcwjz.Text, "0"));
                    ts_call.CallFactory.ysje = Convert.ToDecimal(Convertor.IsNull(f.lblysxj.Text, "0"));
                    ts_call.CallFactory.zje = Convert.ToDecimal(Convertor.IsNull(f.lblzje.Text, "0"));
                    string par = txtxm.Text.Trim() + ",(" + txtks.Text.Trim() + ")" + "," + ye + "元" + "," + ts_call.CallFactory.ysje.ToString("0.00") + "元";
                    ts_call.CallFactory.Bjq_YsCall(bjqxh, call, par);*/
                    decimal _cwjz = Convert.ToDecimal(Convertor.IsNull(f.txtcwjz.Text, "0"));//财务记账
                    decimal ysje = Convert.ToDecimal(Convertor.IsNull(f.lblysxj.Text, "0"));//应付现金
                    decimal _zje = Convert.ToDecimal(Convertor.IsNull(f.lblzje.Text, "0"));
                    decimal ysze = Convert.ToDecimal(Convertor.IsNull(f.lblzje.Text, "0"));

                    decimal _ybzf = Convert.ToDecimal(Convertor.IsNull(f.txtybzf.Text, "0"));//医保支付



                    if (ye > ysje && bjqxh == "上海通导语音报价器型号Ⅳ")
                    {
                        string par = txtxm.Text.Trim() + ",(" + txtks.Text.Trim() + ")" + "," + ye + "元" + "," + ysje.ToString("0.00") + "元";
                        call.Call(ts_call.DmType.应收, par);
                    }
                    else if (ye > _zje && bjqxh == "上海通导语音报价器邵阳第一人民医院")
                    {
                        call.Call(ts_call.DmType.姓名, txtxm.Text.Trim() + "(" + txtks.Text.Trim() + ")");
                        call.Call(ts_call.DmType.总费用, _zje.ToString("0.00") + "元");//_zje
                    }
                    else
                    {
                        call.Call(ts_call.DmType.姓名, txtxm.Text.Trim() + "(" + txtks.Text.Trim() + ")");
                        call.Call(ts_call.DmType.应收, Convert.ToDecimal(Convertor.IsNull(f.lblysxj.Text, "0")).ToString("0.00"));

                        //call.Call(ts_call.DmType.实收,)
                    }
                }
                f.txtssxj.Focus();
                f.ShowDialog();

                if (f.Bok == false)
                {
                    //Add By Tany 2010-0630
                    try
                    {
                        if (yb.ybjklx > 0 && yb.issf)
                        {
                            ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yb.ybjklx);
                            bool bok = ybjk.DeleteYbInfo(yb.insureCentral, yb.hospid, brxx, ref jsxx);//Modify By zp 2013-08-30 新增jsxx
                            if (bok)
                            {
                                MessageBox.Show("取消医保成功，请重新读卡确认医保病人信息！");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    return;
                }


                #endregion

                #region 医保正式结算

                try
                {
                    if (yb.isgh == true)
                    {
                        ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yb.ybjklx);
                        jsxx.HDGS_MZH = HDGS_MZH;//Add by zp 2013-12-30
                        bool bok = ybjk.Compute(true, yb.yblx.ToString(), yb.insureCentral, yb.hospid, InstanceForm.BCurrentUser.EmployeeId.ToString(), cfmx, brxx, ref jsxx);
                        if (bok == false) throw new Exception("医保正式算没有成功");
                    }

                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message);
                    return;
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
                #endregion

                #region 限号判断
                //验证是否超过了限号
                try
                {
                    GetXh(false);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #endregion

                #region  //报价器 找零 Modify By tck 2013-11-21
                bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqybjq == "true")
                {
                    string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                    decimal ssje = Convert.ToDecimal(Convertor.IsNull(f.txtssxj.Text, "0"));//实收现金
                    //decimal je = Convert.ToDecimal(Convertor.IsNull(f.txtssxj.Text, "0"));
                    decimal _cwjz = Convert.ToDecimal(Convertor.IsNull(f.txtcwjz.Text, "0"));
                    decimal _zlje = Convert.ToDecimal(Convertor.IsNull(f.lblzl.Text, "0"));

                    if (bjqxh.Trim() == "上海通导语音报价器型号Ⅳ" && _cwjz > 0)
                    {
                        string par = ",,,," + ssje.ToString("0.00") + "元";
                        call.Call(ts_call.DmType.实收, par);//ssje.ToString("0.00")
                    }
                    else if (bjqxh.Trim() == "上海通导语音报价器邵阳第一人民医院" && _cwjz > 0 && ssje == 0)
                    {
                        //Add by tck 2013-11
                        string par = _cwjz.ToString("0.00") + "元" + "," + (ye - _cwjz) + "元";
                        call.Call(ts_call.DmType.实收, par);
                    }
                    else
                        call.Call(ssje.ToString("0.00"), _zlje.ToString("0.00"));
                    /*报价器的特殊处理全部由ts_call的CallFactory类里去处理 在下个版本测试 先用老的模式 Modify By zp 2013-12-04
                    ts_call.CallFactory.cwjz = Convert.ToDecimal(Convertor.IsNull(f.txtcwjz.Text, "0"));
                    ts_call.CallFactory.ssje = Convert.ToDecimal(Convertor.IsNull(f.txtssxj.Text, "0"));//实收现金
                    ts_call.CallFactory.zlje = Convert.ToDecimal(Convertor.IsNull(f.lblzl.Text, "0"));
                    ts_call.CallFactory.zlkye = ye;
                    ts_call.CallFactory.Bjq_ZlCall(bjqxh, call, "");
                    */
                }
                #endregion

                #region //自动读射频卡
                string kxym = "";
                //try
                //{
                //    if ( New_Card == "true" && readcard.kdjid == Guid.Empty && txtkh.Text.Trim() != "" )
                //    {
                //        string sbxh = ApiFunction.GetIniString( "医院健康卡" , "设备型号" , Constant.ApplicationDirectory + "//ClientWindow.ini" );
                //        if ( sbxh != "" )
                //        {
                //            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall( sbxh );
                //            if ( ReadCard != null )
                //            {
                //                kxym = ReadCard.CreateKxym();
                //                bool bok = ReadCard.WriterCard( txtkh.Text , kxym , "" , kxym );
                //                if ( bok == false )
                //                    throw new Exception( "写卡没有成功" );
                //            }
                //        }
                //    }
                //}
                //catch ( System.Exception err )
                //{
                //    MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                //    return;
                //}
                #endregion

                decimal ylkzf = 0;//银联卡支付
                decimal cwjz = 0;//财务记账
                decimal qfgz = 0;//欠费挂账
                decimal ssxj = 0;//实收金额
                decimal zlje = 0;//找零金额
                decimal xjzf = 0;//现金支付
                decimal zpzf = 0;//支票支付
                string _ghck = "";//挂号窗口
                FsdClass _fsd = null;
                Guid NewJsid = Guid.Empty;

                ylkzf = Convert.ToDecimal(Convertor.IsNull(f.txtpos.Text, "0"));//银联
                cwjz = Convert.ToDecimal(Convertor.IsNull(f.txtcwjz.Text, "0"));//财务记帐
                qfgz = Convert.ToDecimal(Convertor.IsNull(f.txtqfgz.Text, "0"));//欠费挂帐
                ssxj = Convert.ToDecimal(Convertor.IsNull(f.txtssxj.Text, "0"));//实收现金
                zlje = Convert.ToDecimal(Convertor.IsNull(f.lblzl.Text, "0"));//找零金额
                xjzf = Convert.ToDecimal(Convertor.IsNull(f.lblysxj.Text, "0"));//现金自付
                zpzf = Convert.ToDecimal(Convertor.IsNull(f.txtzpzf.Text, "0"));//支票支付
                ybzf = Convert.ToDecimal(Convertor.IsNull(f.txtybzf.Text, "0"));//医保支付
                _ghck = "";
                if (cwjz > 0)
                {
                    #region 敲入卡号

                    if (cfg_1093.Config.Trim() == "1") //Add By zp 如果是诊疗卡扣款则需要读卡验证 2013-09-22
                    {
                        string strMsg = "读卡失败，医院诊疗卡支付需要进行读卡确认!请将卡放置读卡器上!\r\n可能配置不正确，可能读卡设备有问题...";


                        string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                        if (sbxh != "")
                        {
                            //load 事件 中 将panel_yanzheng 的高度 设为0
                            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
                            if (ReadCard != null)
                            {
                                ts_Read_hospitalCard.CardFactory.ReadCard_for_yanzheng(ReadCard, _menuTag.Function_Name, cmbklx, txt_kh_yanzheng);
                                if (string.IsNullOrEmpty(txt_kh_yanzheng.Text) || txt_kh_yanzheng.Text.Trim() != kh.Trim())
                                {
                                    string strRetry = "医院诊疗卡支付需要进行读卡确认！\r\n按<重试>将再读一次卡，按<重试>前请放好卡\r\n否则退出，本次挂号无效！";
                                    string strRetryMsg = "";
                                    if (string.IsNullOrEmpty(txt_kh_yanzheng.Text)) strRetryMsg = "读取卡失败！" + strRetry;
                                    else
                                    {
                                        // (txt_kh_yanzheng.Text.Trim() != kh.Trim())
                                        strRetryMsg = "读卡器读取卡信息与挂号窗口填写的卡信息不符！挂号失败！\r\n" + strRetry;
                                    }
                                    DialogResult dlg = MessageBox.Show(strRetryMsg, "提示", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                                    ts_Read_hospitalCard.CardFactory.ReadCard_for_yanzheng(ReadCard, _menuTag.Function_Name, cmbklx, txt_kh_yanzheng);
                                    if (string.IsNullOrEmpty(txt_kh_yanzheng.Text))
                                    {
                                        if (dlg == DialogResult.Retry) MessageBox.Show(string.Format("按<重试>后仍然读卡失败，挂号无效！"), "提示");
                                        return;
                                    }
                                    else if (txt_kh_yanzheng.Text.Trim() != kh.Trim())
                                    {
                                        string str = txt_kh_yanzheng.Text;
                                        if (dlg == DialogResult.Retry) MessageBox.Show(string.Format("按<重试>后仍然读卡卡信息与挂号窗口填写的卡信息不符，挂号无效！", "提示"));
                                        return;
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show(strMsg, "提示");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(strMsg, "提示");
                            return;
                        }
                    }
                    #endregion
                }

                #region  获得可用发票号集合
                DataTable tbfp = null;
                tbfp = Fun.GetFph(InstanceForm.BCurrentUser.EmployeeId, new SystemCfg(1067).Config != "2" ? 1 : fpzs, Fplx, out err_code, out err_text, InstanceForm.BDatabase);
                if (err_code != 0 || tbfp.Rows.Count == 0 || tbfp.Rows.Count != (new SystemCfg(1067).Config != "2" ? 1 : fpzs))
                {
                    if (cfg1046.Config == "1")//只有打发票时才判断 Modify by zouchihua 2013-4-23)
                    {
                        //if (Convertor.IsNull(txthtdw.Tag, "0") != "0" && txthtdw.Tag.ToString() != "" && cfg1114.Config == "0") { }//add by jiangzf 如果是合同单位病人，并且参数1114=1，则不需要获取发票号
                        if (cmbdwlx.SelectedIndex != -1 && cfg1114.Config != "1") { }//add by jiangzf
                        else
                        {
                            MessageBox.Show(err_text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                #endregion

                #region//分时段挂号处理 Add by zp 2013-10-30 存储数据到后台前先获取当前分时段信息
                string _msg = ""; //cfg1099


                if (cfg1099.Config.Trim() == "1")
                {
                    try
                    {
                        _fsd = FsdClass.GetNowFsd(ghks, ghys, ghjb, ghsj, yysd, ref _msg, InstanceForm.BDatabase);
                        if (_fsd == null)//为空表示当前时段未找到分时段资源,但该医生又设置了资源限号
                        {
                            MessageBox.Show(_msg, "提示");
                            return;
                        }
                        //没分时段的资源给予固定的时段昵称 Modify by zp 2013-11-05
                        if (_fsd.FsdId <= 0)
                        {
                            DateTime _date = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                            if (_date.Hour < 12 && _date.Hour > 6)
                            {
                                _fsd.Btime = "08:00";
                                _fsd.Etime = "12:00";
                                _fsd.Sdbm = "08:00-12:00";
                            }
                            else
                            {
                                _fsd.Btime = "14:00";
                                _fsd.Etime = "17:00";
                                _fsd.Sdbm = "14:00-17:00";
                            }
                        }
                    }
                    catch (Exception ea)
                    {

                        MessageBox.Show("获取分时段异常!原因:" + ea.Message);
                    }

                }

                #endregion
                Cursor = PubStaticFun.WaitCursor();
                InstanceForm.BDatabase.BeginTransaction();
                try
                {
                    #region//病人信息保存
                    if (brxxid == Guid.Empty)
                    {
                        //add by zouchihua 2013-4-9如果没有选择，默认为男
                        if (_new_brxx_kxx.Brxx.Xb.Trim() == "0")
                            _new_brxx_kxx.Brxx.Xb = "1";
                        //YY_BRXX.BrxxDj(Guid.Empty, xm, xb, csrq, "", "", "", "", "", jtdz, "", "", "", lxdh, "", "", "", "", "", "", "", brlx, yblx, cbkh, InstanceForm.BCurrentUser.EmployeeId, 0, out brxxid, out err_code, out err_text, InstanceForm.BDatabase);
                        string str_brxm = txtxm.Text.Trim();
                        string str_brxb = cmbxb.SelectedValue.ToString();
                        string str_csrq = dtpcsrq.Value.ToShortDateString();
                        string str_jtdz = txtjtdz.Text.Trim();
                        string str_brlxfs = txtgrlxfs.Text.Trim();
                        YY_BRXX.BrxxDj(Guid.Empty, str_brxm, str_brxb, str_csrq, _new_brxx_kxx.Brxx.Hyzk,
                            _new_brxx_kxx.Brxx.Gj, _new_brxx_kxx.Brxx.Mz, _new_brxx_kxx.Brxx.Zy, _new_brxx_kxx.Brxx.Csdz, str_jtdz,
                            _new_brxx_kxx.Brxx.Jtyb, _new_brxx_kxx.Brxx.Jtdh, _new_brxx_kxx.Brxx.Jtlxr, str_brlxfs, _new_brxx_kxx.Brxx.Dzyj,
                            _new_brxx_kxx.Brxx.Gzdw, _new_brxx_kxx.Brxx.Gzdwdz, _new_brxx_kxx.Brxx.Gzdwyb, _new_brxx_kxx.Brxx.Gzdwdh, _new_brxx_kxx.Brxx.Gzdwlxr,
                            _new_brxx_kxx.Brxx.Sfzh, _new_brxx_kxx.Brxx.Brlx, _new_brxx_kxx.Brxx.Yblx, _new_brxx_kxx.Brxx.Cbkh, InstanceForm.BCurrentUser.EmployeeId, 0, out brxxid, out err_code, out err_text, InstanceForm.BDatabase);
                        if (brxxid == Guid.Empty || err_code != 0)
                        {
                            brxxid = Guid.Empty;
                            throw new Exception(err_text);
                        }
                        //add by cc 
                        YY_BRXX.BrxxBcDj(brxxid, yy_brxx_bc.QTZJLX, yy_brxx_bc.QTZJHM, yy_brxx_bc.JKDAH, yy_brxx_bc.WHCDDM, yy_brxx_bc.LXRXM,
                        yy_brxx_bc.LXRGX, yy_brxx_bc.LXRDH, out err_code, out err_text, InstanceForm.BDatabase);
                        if (err_code != 0)
                            throw new Exception(err_text);
                        //end add 
                    }
                    #endregion

                    Guid NewGhxxid = Guid.Empty;
                    Guid _Kdjid = Guid.Empty;
                    #region //保存卡信息

                    if (New_Card == "true" && readcard.kdjid == Guid.Empty && txtkh.Text.Trim() != "")
                    {
                        mz_kdj.Kdj(Guid.Empty,
                            brxxid,
                            Convert.ToInt32(cmbklx.SelectedValue),
                            txtkh.Text.Trim(),
                            txtxm.Text.Trim() == "" ? "未写名" : txtxm.Text.Trim(),
                            0,
                            0,
                            0,
                            0,
                            djsj,
                            InstanceForm.BCurrentUser.EmployeeId,
                            card.mrmm, kxym, "",
                            out _Kdjid, out err_code, out err_text, Fun.GetNewGrzhbh(InstanceForm.BDatabase), _menuTag.Function_Name, InstanceForm.BDatabase);
                        if (_Kdjid == Guid.Empty || err_code != 0)
                            throw new Exception(err_text);
                        readcard.kdjid = _Kdjid;
                        //Add By Zj 2012-12-24
                        mz_kdj.UpdateBKJE(_Kdjid, brxxid, klx, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);

                    }
                    #endregion

                    #region //保存挂号信息、处方信息
                    string sCfid = "";
                    for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                    {
                        int ksdm = ghks;//科室代码
                        string ksmc = txtks.Text.Trim();//科室名称
                        int ysdm = ghys;//医生代码
                        string ysmc = txtys.Text.Trim();//医生名称
                        int zxks = ghks;//执行科室代码
                        string zxksmc = txtks.Text.Trim();//执行科室名称
                        int bghpbz = 0;//挂号票标志
                        decimal cfzje = Convert.ToDecimal(dset.Tables[0].Rows[i]["zje"]);//计算出挂号总金额 与 卡费分开
                        if (dset.Tables[0].Rows[i]["groupid"].ToString() == "挂号费" || dset.Tables[0].Rows[i]["groupid"].ToString() == "")
                        {
                            bghpbz = 1;//挂号票
                            if (cfg1046.Config == "1")//如果需要打发票。就获取发票号
                            {
                                //add by jiangzf 如果是合同单位病人，并且参数1114=0，则不需要获取发票号
                                //add by wangzhi 如果是0金额，由参数1163控制0金额是否打印发票
                                if ((cmbdwlx.SelectedIndex != -1 && cfg1114.Config != "1") || (cfg1163.Config == "1" && zje == 0))
                                {
                                }
                                else
                                    fph = Convertor.IsNull(tbfp.Rows[i]["QZ"], "") + tbfp.Rows[i]["fph"].ToString().Trim();
                            }
                            long _dnlsh = Convert.ToInt64(dset.Tables[0].Rows[i]["dnlsh"]);
                            //挂号信息保存
                            mz_ghxx.GhxxDj(Guid.Empty, brxxid, ghlx, readcard.kdjid, mzh, ghks, ghys, ghjb, cfzje, InstanceForm.BCurrentUser.EmployeeId, 1, _ghck, ref _pdxh, _dnlsh, fph, Jgbm, out NewGhxxid, out err_code, out err_text, Convert.ToInt32(Convertor.IsNull(cmbdwlx.SelectedValue, "0")), Convert.ToInt32(Convertor.IsNull(txthtdw.Tag, "0")), Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0")), yb_dylx, yb_dylxmc, yb_bzxx, yylx, yysd, yyqtxx, ghsj, InstanceForm.BDatabase);
                            if (NewGhxxid == Guid.Empty || err_code != 0)
                                throw new Exception(err_text);
                        }
                        else
                        {

                            ksdm = 0;
                            ksmc = "";
                            ysdm = 0;
                            ysmc = "";
                            zxks = 0;
                            zxksmc = "";//卡费不属于任何医生和科室 只记录操作员
                            //add by zouchihua 2013-3-28 设置卡号费的执行科室（0按照之前方式 大于0表示卡费执行科室） 
                            if (cfg1079.Config.Trim() != "0")
                            {
                                zxks = Convert.ToInt32(cfg1079.Config);
                                ksdm = Convert.ToInt32(cfg1079.Config);
                            }
                        }

                        if (!(cfg1163.Config == "1" && zje == 0))
                        {
                            string groupid = dset.Tables[0].Rows[i]["groupid"].ToString();//用于分解数据行
                            #region 保存处方
                            Guid NewCfid = Guid.Empty;
                            if (cfg1163.Config == "1" && zje == 0)
                            {
                                //总金额为0并且又不打发票，不需要生成处方
                            }
                            else
                            {
                                mz_cf.SaveCf(Guid.Empty, brxxid, NewGhxxid, lblmzh.Text.Trim(), _ghck, cfzje, djsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, _ghck, Guid.Empty, ksdm,
                                            ksmc, ysdm, ysmc, 0, zxks, zxksmc, bghpbz, 0, 2, 0, 1, Jgbm, out NewCfid, out err_code, out err_text, InstanceForm.BDatabase);
                                if (NewCfid == Guid.Empty || err_code != 0)
                                    throw new Exception(err_text);

                                sCfid += NewCfid.ToString() + ",";//组成需要更新的CFID

                                DataRow[] rows = dset.Tables[4].Select("groupid='" + groupid + "'");//找到对应的分组处方

                                for (int j = 0; j <= rows.Length - 1; j++)
                                {
                                    //保存处方明细
                                    Guid NewCfmxid = Guid.Empty;
                                    mz_cf.SaveCfmx(Guid.Empty, NewCfid, rows[j]["PY_CODE"].ToString().Trim(), "", rows[j]["item_name"].ToString().Trim(),
                                        rows[j]["item_name"].ToString().Trim(), "", "", Convert.ToDecimal(rows[j]["cost_price"]), Convert.ToDecimal(rows[j]["num"]),
                                        rows[j]["item_unit"].ToString().Trim(), 1, 1, Convert.ToDecimal(rows[j]["je"]), rows[j]["statitem_code"].ToString().Trim(),
                                        Convert.ToInt64(rows[j]["item_id"]), Guid.Empty, rows[j]["STD_CODE"].ToString().Trim(), 0, 0, Guid.Empty, 0, "", "", 0, 0, "",
                                        0, 0, Guid.Empty, 0, 0, 0, out NewCfmxid, out err_code, out err_text, InstanceForm.BDatabase);
                                    if (NewCfmxid == Guid.Empty || err_code != 0)
                                        throw new Exception(err_text);
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion
                    int UpdateCfs = 0;//更新处方头张数
                    #region //保存收银信息
                    if (!(cfg1163.Config == "1" && zje == 0))
                    {
                        mz_sf.SaveJs(Guid.Empty, brxxid, NewGhxxid, djsj, InstanceForm.BCurrentUser.EmployeeId, zje, ybzf, 0, 0, ylkzf, yhje, cwjz, qfgz, xjzf, zpzf, srje, ssxj, zlje, fpzs, 0, Jgbm, out NewJsid, out err_code, out err_text, InstanceForm.BDatabase);
                        if (NewJsid == Guid.Empty || err_code != 0)
                            throw new Exception(err_text);


                        sCfid = sCfid.Substring(0, sCfid.Length - 1);//将结尾的,去掉
                        string[] ssCfid = sCfid.Split(',');//有几张发票就有几个CFID 分隔 用来 作为更新收费标志的条件

                        for (int X = 0; X < dset.Tables[0].Rows.Count; X++)
                        {
                            Guid yhlxid = new Guid(dset.Tables[0].Rows[X]["yhlxid"].ToString());//优惠
                            string yhlxmc = Fun.SeekYhlxMc(yhlxid, InstanceForm.BDatabase);
                            decimal cfzje = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);//计算出挂号总金额 与 卡费分开
                            string groupid = dset.Tables[0].Rows[X]["groupid"].ToString();//分组ID
                            int bghpbz = 0;//挂号票标志
                            long _dnlsh = Convert.ToInt64(dset.Tables[0].Rows[X]["dnlsh"]);//获取每张发票的电脑流水号


                            if (new SystemCfg(1067).Config == "1" && dset.Tables[0].Rows[X]["groupid"].ToString() != "挂号费" && dset.Tables[0].Rows[X]["groupid"].ToString() != "")//Add By Zj 2012-12-20 诊疗卡费用不打印  发票为1张
                                fph = "0";
                            // add by jiangzf 2014-07-26 诊疗卡费用与挂号费分开,但诊疗卡费只打小票
                            if (new SystemCfg(1067).Config == "3" && dset.Tables[0].Rows[X]["groupid"].ToString() != "挂号费" && dset.Tables[0].Rows[X]["groupid"].ToString() != "")
                                fph = "0";
                            if (cfg1046.Config == "1" && fph != "0")//如果需要打发票。就获取发票号
                                fph = Convertor.IsNull(tbfp.Rows[X]["QZ"], "") + tbfp.Rows[X]["fph"].ToString().Trim();
                            if (dset.Tables[0].Rows[X]["groupid"].ToString() == "挂号费" || dset.Tables[0].Rows[X]["groupid"].ToString() == "") //Modify By Zj 2012-12-28 免费挂号
                            {
                                bghpbz = 1;
                                //只有挂号费 才给医保就医登记号赋值
                                jydjh = string.IsNullOrEmpty(jsxx.JSDH) ? "" : jsxx.JSDH;//add by wangzhi 2010-12-28
                            }
                            else//Add By Zj 2013-03-11 ghpbz=2 是诊疗卡 发票。用来统计诊疗卡发票.
                                bghpbz = 2;
                            if (dset.Tables[0].Rows.Count == 1)//Modify By Zj 2012-12-20 总记录数为1时 才保存一张发票.诊疗卡虽然不打发票 但是仍然要有记录
                            {
                                //add by zouchihua 2013-3-28 设置卡号费的执行科室（0按照之前方式 大于0表示卡费执行科室） 
                                if (bghpbz == 2)
                                {
                                    //保存发票信息  //add by zouchihua 2013-5-9诊疗卡不属于任何科室和医生
                                    mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, xm, djsj, InstanceForm.BCurrentUser.EmployeeId, _ghck, _dnlsh, fph, cfzje, ybzf, 0, 0, ylkzf, yhje, cwjz, qfgz, xjzf, zpzf, srje, Guid.Empty, "", NewJsid, bghpbz, Convert.ToInt32(cfg1079.Config), 0, 0, Convert.ToInt32(cfg1079.Config), yblx, jydjh, 0, readcard.kdjid, Jgbm, yhlx, yhlxmc, out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                                }
                                else
                                    //保存发票信息
                                    mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, xm, djsj, InstanceForm.BCurrentUser.EmployeeId, _ghck, _dnlsh, fph, cfzje, ybzf, 0, 0, ylkzf, yhje, cwjz, qfgz, xjzf, zpzf, srje, Guid.Empty, "", NewJsid, bghpbz, ghks, ghys, 0, ghks, yblx, jydjh, 0, readcard.kdjid, Jgbm, yhlx, yhlxmc, out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                            }
                            else
                            {
                                decimal fp_zfje = Convert.ToDecimal(dset.Tables[0].Rows[X]["zfje"]);
                                //计算每张发票的支付金额
                                if (Convert.ToDecimal(dset.Tables[0].Rows[X]["ybzf"]) == 0)
                                    fp_zfje = fp_zfje - (dset.Tables[0].Rows[X]["groupid"].ToString() == "挂号费" ? ybzf : 0);//Modify By Zj 2012-12-26 手工输入的医保支付 在存储过程里无法计算 所以这里的自付金额要减去医保支付

                                decimal fp_zje = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);
                                decimal fp_yhje = Convert.ToDecimal(dset.Tables[0].Rows[X]["yhje"]);
                                decimal fp_srje = Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"]);
                                //decimal fp_ybzhzf = ybzhzf > 0 && ybjjzf == 0 && ybbzzf == 0 ? fp_zfje : 0;
                                //decimal fp_ybjjzf = ybjjzf > 0 && ybzhzf == 0 && ybbzzf == 0 ? fp_zfje : 0;
                                //decimal fp_ybbzzf = ybbzzf > 0 && ybzhzf == 0 && ybjjzf == 0 ? fp_zfje : 0;
                                decimal fp_ylkzf = ylkzf > 0 ? fp_zfje : 0;
                                decimal fp_cwjz = cwjz > 0 ? fp_zfje : 0;
                                decimal fp_qfgz = qfgz > 0 ? fp_zfje : 0;
                                decimal fp_ybzf = dset.Tables[0].Rows[X]["groupid"].ToString() == "挂号费" ? ybzf : 0;
                                decimal fp_xjzf = xjzf > 0 ? fp_zfje : 0;
                                decimal fp_zpzf = zpzf > 0 ? fp_zfje : 0;
                                //add by zouchihua 2013-3-28 设置卡号费的执行科室（0按照之前方式 大于0表示卡费执行科室） 
                                if (bghpbz == 2)
                                {
                                    //add by zouchihua 2013-5-9诊疗卡不属于任何科室和医生
                                    //保存发票信息
                                    mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, xm, djsj, InstanceForm.BCurrentUser.EmployeeId, _ghck, _dnlsh, fph, fp_zje, fp_ybzf, 0, 0, fp_ylkzf, fp_yhje, fp_cwjz, fp_qfgz, fp_xjzf, fp_zpzf, fp_srje, Guid.Empty, "", NewJsid, bghpbz, Convert.ToInt32(cfg1079.Config), 0, 0, Convert.ToInt32(cfg1079.Config), yblx, jydjh, 0, readcard.kdjid, Jgbm, yhlxid, yhlxmc, out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                                }
                                else
                                    mz_sf.SaveFp(Guid.Empty, brxxid, NewGhxxid, mzh, xm, djsj, InstanceForm.BCurrentUser.EmployeeId, _ghck, _dnlsh, fph, fp_zje, fp_ybzf, 0, 0, fp_ylkzf, fp_yhje, fp_cwjz, fp_qfgz, fp_xjzf, fp_zpzf, fp_srje, Guid.Empty, "", NewJsid, bghpbz, ghks, ghys, 0, ghks, yblx, jydjh, 0, readcard.kdjid, Jgbm, yhlxid, yhlxmc, out NewFpid, out err_code, out err_text, InstanceForm.BDatabase);
                                if (err_code != 0)
                                    throw new Exception(err_text);

                            }

                            //发票明细
                            decimal fpje = 0;
                            DataRow[] rows = dset.Tables[1].Select("groupid = '" + groupid + "'");
                            //保存发票明细项目 Begin
                            for (int i = 0; i <= rows.Length - 1; i++)
                            {
                                mz_sf.SaveFpmx(NewFpid, Convertor.IsNull(rows[i]["code"], "0"), Convertor.IsNull(rows[i]["item_name"], "0"), Convert.ToDecimal(rows[i]["je"]), 0, out err_code, out err_text, InstanceForm.BDatabase);
                                if (err_code != 0)
                                    throw new Exception(err_text);
                                fpje = fpje + Convert.ToDecimal(rows[i]["je"]);
                            }
                            if (fpje != Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]) - (Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"])))
                                throw new Exception("插入发票明细时出错,金额不等于发票总额");
                            //保存发票明细项目 End

                            //保存发票统计大项目 Begin
                            decimal tjxmje = 0;
                            DataRow[] tjdxmrows = dset.Tables[3].Select("groupid = '" + groupid + "' ");
                            for (int i = 0; i <= tjdxmrows.Length - 1; i++)
                            {
                                mz_sf.SaveFpdxmmx(NewFpid, Convertor.IsNull(tjdxmrows[i]["code"], "0"), Convertor.IsNull(tjdxmrows[i]["item_name"], "0"), Convert.ToDecimal(tjdxmrows[i]["je"]), 0, out err_code, out err_text, InstanceForm.BDatabase);
                                if (err_code != 0)
                                    throw new Exception(err_text);
                                tjxmje = tjxmje + Convert.ToDecimal(tjdxmrows[i]["je"]);
                            }
                            if (tjxmje != Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]) - (Convert.ToDecimal(dset.Tables[0].Rows[X]["srje"])))
                                throw new Exception("插入发票明细时出错,金额不等于发票总额");
                            //保存发票统计大项目 End

                            //更新医保结算表的收费信息
                            if (yb.isgh == true && groupid == "挂号费")
                            {
                                ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yb.ybjklx);
                                bool bok = ybjk.UpdateJsmx(brxxid, NewGhxxid, 0, jsxx.HisJsdid, NewFpid, fph, djsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);
                                if (bok == false)
                                    throw new Exception("更新本地医保结算明细表时没有成功");
                            }
                            dset.Tables[0].Rows[X]["fph"] = fph.ToString();
                            dset.Tables[0].Rows[X]["fpid"] = NewFpid;

                            //更新处方状态
                            int Nrows = 0;
                            mz_cf.UpdateCfsfzt("('" + ssCfid[X] + "')", InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, djsj, _ghck, _dnlsh, fph, NewFpid, out Nrows, out err_code, out err_text, InstanceForm.BDatabase);
                            if (Nrows != 1)
                                throw new Exception(err_text);
                            UpdateCfs = UpdateCfs + Nrows;
                        }
                    }
                    #endregion

                    #region pos支付存入mz_pos_czjl
                    if (ylkzf > 0)
                    {
                        Guid opid = Guid.NewGuid();
                        InstanceForm.BDatabase.DoCommand(string.Format("insert into mz_pos_czjl(czid,fpid,fph,je,jsid,tsbz,czy,czsj) select '{0}',fpid,fph,ylkzf,jsid,0,{2},'{3}' from mz_fpb where jsid='{1}'", opid, NewJsid, InstanceForm.BCurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss")));
                    }
                    #endregion

                    //判断处方更新张数和实际分组张数是否一样
                    if (!(cfg1163.Config == "1" && zje == 0))
                    {
                        if (UpdateCfs != dset.Tables[0].Rows.Count)
                            throw new Exception("更新处方表张数" + UpdateCfs + "张,分组处方张数" + dset.Tables[0].Rows.Count + "张.请检查处方状态或刷新处方再试");

                        //更新发票领用表的当前发票号码
                        if (cfg1046.Config == "1")
                        {
                            //if (Convertor.IsNull(txthtdw.Tag, "0") != "0" && txthtdw.Tag.ToString() != "" && cfg1114.Config == "0") { }//add by jiangzf 如果是合同单位病人，并且参数1114=0，则不需要获取发票号
                            if (cmbdwlx.SelectedIndex != -1 && cfg1114.Config != "1")
                            {
                            }
                            else
                                mz_sf.UpdateDqfph(new Guid(tbfp.Rows[0]["fpid"].ToString()), tbfp.Rows[0]["fph"].ToString().Trim(), tbfp.Rows[tbfp.Rows.Count - 1]["fph"].ToString().Trim(), out Msg, InstanceForm.BDatabase);
                        }

                        //更新卡余额和累计消息金额
                        if (cwjz > 0)
                            readcard.UpdateKye(cwjz, InstanceForm.BDatabase);
                    }

                    string dd = Convertor.IsNull(butqh.Tag, "");
                    //更新预约取号状态
                    if (new Guid(Convertor.IsNull(butqh.Tag, Guid.Empty.ToString())) != Guid.Empty)
                        mz_ghxx.UpateYyghxx(new Guid(Convertor.IsNull(butqh.Tag, Guid.Empty.ToString())), NewGhxxid, djsj, InstanceForm.BDatabase);


                    #region  //modify by zp 2013-06  是否自动报道  启用了新分诊系统、有诊区并且当前诊区为自动报道
                    //if (cfg3070.Config.Trim() == "0") //Modify by zp 不管是否启用分诊都插入记录到护士分诊表 2013-10-31
                    //{
                    Fz_Zq _fzzq = new Fz_Zq(InstanceForm.BDatabase, ghks, ghjb);
                    Guid NewFzid = Guid.Empty;
                    string fsd_btime = "";
                    string fsd_etime = "";
                    string fsd_sdbm = "";
                    if (_fsd != null)
                    {
                        fsd_btime = Convertor.IsNull(_fsd.Btime, "");
                        fsd_etime = Convertor.IsNull(_fsd.Etime, "");
                        fsd_sdbm = Convertor.IsNull(_fsd.Sdbm, "");
                    }
                    if (_fzzq.Zqid > 0)//Zqid默认为0 大于0表示有诊区记录
                    {
                        if (_fzzq.Zqbdfs <= 0) //手动报道 _fsd
                        {
                            ts_mzys_class.MZHS_FZJL.AddHz(TrasenFrame.Forms.FrmMdiMain.Jgbm, NewGhxxid, ghks, ts_mzys_class.MZHS_FZJL.FzStatus.未分诊, out NewFzid, out err_code, out err_text, fsd_btime, fsd_etime, fsd_sdbm, _fzzq.Zqid, InstanceForm.BDatabase);
                            if (err_code != 0)
                                MessageBox.Show("分诊手动报道出现异常!原因:" + err_text);
                        }
                        else
                        {
                            ts_mzys_class.MZHS_FZJL.AddHz(TrasenFrame.Forms.FrmMdiMain.Jgbm, NewGhxxid, ghks, ts_mzys_class.MZHS_FZJL.FzStatus.已分诊, out NewFzid, out err_code, out err_text, fsd_btime, fsd_etime, fsd_sdbm, _fzzq.Zqid, InstanceForm.BDatabase);
                            if (err_code != 0)
                                MessageBox.Show("分诊自动报道出现异常!原因:" + err_text);
                            if (new SystemCfg(3103).Config == "1")
                            {
                                int isjz = 0;
                                if (ghlx == 2)
                                    isjz = 1; 
                                int pxxh = Fun.MZQH_GET_HZH(ghks, ghys, ghjb, Convert.ToInt16(Isyy), isjz, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss"), InstanceForm.BDatabase);
                                InstanceForm.BDatabase.DoCommand("UPDATE MZHS_FZJL SET PXXH = " + pxxh.ToString() + "WHERE FZID = '" + NewFzid + "'");
                                int zsid=Convert.ToInt16(   InstanceForm.BDatabase.GetDataResult("SELECT ISNULL(ZJID,0) FROM JC_ZJSZ WHERE ZZYS='" + ghys + "' ORDER BY DLSJ DESC") ); 
                                InstanceForm.BDatabase.DoCommand("UPDATE MZHS_FZJL SET zsid = " + zsid.ToString() + "WHERE FZID = '" + NewFzid + "'");
                            }
                        }
                    }
                    else //未设置诊区的也插入记录到分诊表
                    {
                        ts_mzys_class.MZHS_FZJL.AddHz(TrasenFrame.Forms.FrmMdiMain.Jgbm, NewGhxxid, ghks, ts_mzys_class.MZHS_FZJL.FzStatus.已分诊, out NewFzid, out err_code, out err_text, fsd_btime, fsd_etime, fsd_sdbm, 0, InstanceForm.BDatabase);
                        if (err_code != 0)
                            MessageBox.Show("分诊自动报道出现异常!原因:" + err_text);
                    }
                    if (_fsd != null && _fsd.FsdId > 0 && (string.IsNullOrEmpty(yysd)))
                        _fsd.UpdateFsdGhrc(ref _fsd, InstanceForm.BDatabase); //更新挂号人数

                    #endregion
                    InstanceForm.BDatabase.CommitTransaction();

                    _new_brxx_kxx = null;//挂号成功后将病人信息和新卡信息置为Null
                    this.Tag = Guid.Empty;
                    Isyy = false;
                    butqh.Tag = "";
                    butqh.BackColor = Color.WhiteSmoke;
                    txtks.Enabled = true;
                    cmbghjb.Enabled = true;
                    txtys.Enabled = true;
                    treeView1.Enabled = true;
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message);
                    return;
                }
                finally
                {
                    Cursor = Cursors.Default;

                }


                /*给小票或发票打印候诊时段 Modify by zp 2013-11-21*/
                string Print_Sdnc = yysd;
                if (string.IsNullOrEmpty(Print_Sdnc) && _fsd != null && _fsd.FsdId > 0)
                    Print_Sdnc = _fsd.Sdbm;

                if (cfg1163.Config == "1" && zje == 0)
                {
                    //1163开启并且总金额未，不打印任何东西
                }
                else
                {

                    if (cmbdwlx.SelectedIndex != -1 && cfg1114.Config != "1")
                    {
                        if (cfg1114.Config == "0")
                            PrintGuideBill();//打印导引单
                    }
                    //Modify By zp 2013-09-30 重构 打印票据
                    else
                        PrintReport(_ghlx, _pdxh, card, djsj, fpzs, dset, fph, jydjh, kh, klx, zje, ssxj, zlje, ybkye, ybzf, ybzhzf, ye, Print_Sdnc, cwjz);
                }

                #region 产生当前可用发票号 刷新网格
                try
                {
                    //控件的可用性
                    ControlEnable();
                    this.butnew_Click(sender, e);
                    //提示发票段已经用完
                    if (Msg.Trim() != "")
                        MessageBox.Show(Msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //刷新网格
                    if (chksx.Checked == true)
                        ReadGhxx();
                    if (cfgpb.Config.ToString() == "1")//Add By Zj 2013-02-16 如果启用排版挂号，挂号成功后刷新排班。为了刷新医生挂号人次
                        treeView1_AfterSelect(sender, null);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("收费已成功,但发生下列错误" + err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion
                #region 评价器
                string bqypjq = ApiFunction.GetIniString("评价器", "启用评价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string pjqxh = ApiFunction.GetIniString("评价器", "评价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                try
                {
                    if (bqypjq == "true")
                    {
                        ts_pjq.ipjq ipjq = ts_pjq.PjqFactory.Newpjq(pjqxh);
                        string perr_text = "";
                        int perr_code = 0;
                        ipjq.Pj(InstanceForm.BCurrentUser.LoginCode.ToString(), InstanceForm.BCurrentUser.Name, InstanceForm.BCurrentDept.DeptId.ToString(), InstanceForm.BCurrentDept.DeptName, out perr_code, out perr_text);
                        if (perr_code != 0) throw new Exception("评价器调用出错!" + perr_text);
                    }
                }
                catch (Exception ea)
                {
                    MessageBox.Show(ea.Message);
                }
                #endregion
            }
            catch (Exception ea)
            {
                MessageBox.Show("挂号登记出现异常!" + ea.Message);
            }
        }
        private void PrintGuideBill()
        {
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

            int ksdm = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));//挂号科室
            string ssql = "select NAME,DEPTADDR from  JC_DEPT_PROPERTY where dept_id=" + ksdm;
            DataRow deptdr = InstanceForm.BDatabase.GetDataRow(ssql);//科室所在位置

            ParameterEx[] paramters = new ParameterEx[7];
            paramters[0].Text = "医院名称";
            paramters[0].Value = Constant.HospitalName;

            paramters[1].Text = "姓名";
            paramters[1].Value = txtxm.Text.Trim();

            paramters[2].Text = "卡号";
            paramters[2].Value = txtkh.Text.Trim();

            paramters[3].Text = "门诊号";
            paramters[3].Value = lblmzh.Text.Trim();

            paramters[4].Text = "科室";
            paramters[4].Value = txtks.Text.Trim();

            paramters[5].Text = "就诊日期";
            paramters[5].Value = sDate;

            paramters[6].Text = "科室信息";
            paramters[6].Value = deptdr["NAME"] + " 位置:" + Convertor.IsNull(deptdr["DEPTADDR"], "") + "\r\n";


            TrasenFrame.Forms.FrmReportView ff;
            ff = new TrasenFrame.Forms.FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\MZ_导引单.rpt", paramters, true);
        }
        //打印挂号票 Add By zp 2013-09-30
        private void PrintReport(string _ghlx, int _pdxh, mz_card card, string djsj, int fpzs, DataSet dset,
            string fph, string jydjh, string kh, int klx, decimal zje, decimal ssxj, decimal zlje, decimal ybkye,
            decimal ybzf, decimal ybzhzf, decimal ye, string yysd, decimal cwjz)
        {
            #region 打印发票
            try
            {
                //获得卡费
                string sql = " select isnull(b.RETAIL_PRICE,0) RETAIL_PRICE,d.CODE,d.ITEM_NAME from JC_KLX a left join JC_HSITEM b on a.SFXMID=b.ITEM_ID  "
                           + "  left join JC_STAT_ITEM c on c.CODE=b.STATITEM_CODE  "
                           + " left join JC_MZFP_XM d on c.mzfp_code=d.code  where a.klx=" + klx + " ";
                DataTable kftb = FrmMdiMain.Database.GetDataTable(sql);
                decimal kf = 0;
                if (kftb.Rows.Count > 0)
                    kf = decimal.Parse(kftb.Rows[0]["RETAIL_PRICE"].ToString());

                SystemCfg cfg1067 = new SystemCfg(1067);//诊疗卡打印方式 0 诊疗卡费用与挂号费打印在同一张票 1 诊疗卡费用与挂号费分开(仅打印挂号费一张票) 2 诊疗卡费用与挂号费分开(打印挂号费与诊疗卡费在不同的票） 默认0
                int num = 1;
                if (cfg1067.Config != "2")
                    num = 1;
                else
                    num = fpzs;

                for (int X = 0; X <= num - 1; X++)//Modify By Zj 2012-12-20 记录数修改为发票数
                {

                    int ksdm = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));
                    int ysdm = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));
                    int zxks = 0;

                    string ssql = "select *,deptaddr from mz_fpb a (nolock) left join jc_dept_property b on a.ksdm=b.dept_id where fpid='" + new Guid(dset.Tables[0].Rows[X]["fpid"].ToString()) + "'";
                    DataTable tbFp = InstanceForm.BDatabase.GetDataTable(ssql);

                    lbl_xm.Text = tbFp.Rows[0]["brxm"].ToString();
                    lbl_mzh.Text = tbFp.Rows[0]["blh"].ToString();
                    lbl_zje.Text = zje.ToString();
                    lbl_ssxj.Text = ssxj.ToString();
                    lbl_zlje.Text = zlje.ToString();
                    if (cfg1046.Config == "1") //打印发票
                    {
                        //参数1006：挂号票是否使用水晶报表0=不是1=是
                        if ((new TrasenFrame.Classes.SystemCfg(1006)).Config == "1")
                        {
                            try
                            {
                                #region 水晶表
                                ParameterEx[] parameters = new ParameterEx[25];
                                parameters[0].Text = "医院名称";
                                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                                parameters[1].Text = "发票号";
                                parameters[1].Value = fph.Trim();

                                DateTime time = Convert.ToDateTime(djsj);

                                parameters[2].Text = "年";
                                parameters[2].Value = time.Year;

                                parameters[3].Text = "月";
                                parameters[3].Value = time.Month;

                                parameters[4].Text = "日";
                                parameters[4].Value = time.Day;

                                parameters[5].Text = "挂号类型";
                                parameters[5].Value = _ghlx;

                                parameters[6].Text = "科室";
                                parameters[6].Value = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);

                                parameters[7].Text = "医生";
                                parameters[7].Value = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);

                                parameters[8].Text = "医生级别";
                                parameters[8].Value = cmbghjb.Text.Substring(cmbghjb.Text.IndexOf("-") + 1, cmbghjb.Text.Length - cmbghjb.Text.IndexOf("-") - 1);

                                parameters[9].Text = "挂号序号";
                                parameters[9].Value = _pdxh;

                                PrintClass.InvoiceItem[] item = null;
                                //150316 chencan 分票明细
                                //DataRow[] rows = dset.Tables[1].Select();
                                DataRow[] rows = dset.Tables[1].Select("groupid = '" + dset.Tables[0].Rows[X]["groupid"].ToString() + "'");
                                string _ghf = "";
                                string _zcf = "";
                                string _jcf = "";
                                string _clf = "";
                                item = new PrintClass.InvoiceItem[rows.Length];
                                for (int m = 0; m <= rows.Length - 1; m++)
                                {

                                    item[m].ItemCode = rows[m]["CODE"].ToString().Trim();
                                    item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                                    item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//发票项目金额

                                    //挂号专有项目 Modify By Tany 2008-12-22
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1001)).Config.ToString().Trim())
                                    {
                                        _ghf = item[m].ItemMoney.ToString("0.00");
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1002)).Config.ToString().Trim())
                                    {
                                        _zcf = item[m].ItemMoney.ToString("0.00");
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1003)).Config.ToString().Trim())
                                    {
                                        _jcf = item[m].ItemMoney.ToString("0.00");
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1004)).Config.ToString().Trim())
                                    {
                                        _clf = item[m].ItemMoney.ToString("0.00");
                                    }
                                }

                                parameters[10].Text = "挂号费";
                                parameters[10].Value = _ghf;

                                parameters[11].Text = "诊查费";
                                parameters[11].Value = _zcf;

                                parameters[12].Text = "检查费";
                                parameters[12].Value = _jcf;

                                parameters[13].Text = "材料费";
                                parameters[13].Value = _clf;

                                parameters[14].Text = "小写金额";
                                parameters[14].Value = Convert.ToDecimal(Convertor.IsNull(dset.Tables[0].Rows[X]["zje"], "0")).ToString("0.00");

                                parameters[15].Text = "大写金额";
                                parameters[15].Value = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());

                                parameters[16].Text = "收款员";
                                if (cfgsfy.Config == "1")
                                    parameters[16].Value = InstanceForm.BCurrentUser.Name;
                                else
                                    parameters[16].Value = InstanceForm.BCurrentUser.LoginCode;

                                parameters[17].Text = "病人姓名";
                                parameters[17].Value = txtxm.Text.Trim();

                                parameters[18].Text = "门诊号";
                                parameters[18].Value = lblmzh.Text.Trim();

                                parameters[19].Text = "类型";
                                parameters[19].Value = "";

                                parameters[20].Text = "医保卡号";
                                parameters[20].Value = lbljyh.Text.Trim();

                                parameters[21].Text = "医保支付";
                                parameters[21].Value = Convert.ToString(jsxx.TCZF);

                                parameters[22].Text = "医保卡支付";
                                parameters[22].Value = Convert.ToString(jsxx.ZHZF);

                                parameters[23].Text = "现金支付";
                                parameters[23].Value = tbFp.Rows[0]["xjzf"].ToString();

                                parameters[24].Text = "医保余额";
                                parameters[24].Value = Convert.ToString(ybkye - jsxx.ZHZF);

                                //parameters[25].Text = "位置";
                                //parameters[25].Value = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");

                                //parameters[25].Text = "门诊卡号";
                                //parameters[25].Value = txtkh.Text;

                                //parameters[26].Text = "位置";
                                //parameters[26].Value = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");

                                //parameters[27].Text = "医院卡余额";
                                //parameters[27].Value = ye - (Convert.ToDecimal(tbFp.Rows[0]["cwjz"]));

                                //parameters[28].Text = "卡支付金额";//财务记帐
                                //parameters[28].Value = cwjz;


                                TrasenFrame.Forms.FrmReportView fv;

                                if (Bview == "true")
                                {
                                    fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号发票.rpt", parameters);
                                    if (!fv.LoadReportSuccess)
                                    {
                                        fv.Dispose();
                                    }
                                    else
                                    {
                                        fv.Show();
                                    }
                                }
                                else
                                {
                                    //TrasenFrame.Forms.FrmReportView.DirectPrint(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号发票.rpt", parameters, false, "", false);
                                    fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号发票.rpt", parameters, true);
                                }

                                #endregion
                            }
                            catch
                            {
                                //modify by zouchihua 2013-7-1 增加了卡号
                                #region 水晶表
                                ParameterEx[] parameters = new ParameterEx[29];
                                parameters[0].Text = "医院名称";
                                parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                                parameters[1].Text = "发票号";
                                parameters[1].Value = fph.Trim();

                                DateTime time = Convert.ToDateTime(djsj);

                                parameters[2].Text = "年";
                                parameters[2].Value = time.Year;

                                parameters[3].Text = "月";
                                parameters[3].Value = time.Month;

                                parameters[4].Text = "日";
                                parameters[4].Value = time.Day;

                                parameters[5].Text = "挂号类型";
                                parameters[5].Value = _ghlx;

                                parameters[6].Text = "科室";
                                parameters[6].Value = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);

                                parameters[7].Text = "医生";
                                parameters[7].Value = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);

                                parameters[8].Text = "医生级别";
                                parameters[8].Value = cmbghjb.Text.Substring(cmbghjb.Text.IndexOf("-") + 1, cmbghjb.Text.Length - cmbghjb.Text.IndexOf("-") - 1);

                                parameters[9].Text = "挂号序号";
                                parameters[9].Value = _pdxh;

                                PrintClass.InvoiceItem[] item = null;
                                DataRow[] rows = dset.Tables[1].Select();
                                string _ghf = "";
                                string _zcf = "";
                                string _jcf = "";
                                string _clf = "";
                                item = new PrintClass.InvoiceItem[rows.Length];
                                for (int m = 0; m <= rows.Length - 1; m++)
                                {
                                    item[m].ItemCode = rows[m]["CODE"].ToString().Trim();
                                    item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                                    item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//发票项目金额

                                    //挂号专有项目 Modify By Tany 2008-12-22
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1001)).Config.ToString().Trim())
                                    {
                                        _ghf = item[m].ItemMoney.ToString();
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1002)).Config.ToString().Trim())
                                    {
                                        _zcf = item[m].ItemMoney.ToString();
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1003)).Config.ToString().Trim())
                                    {
                                        _jcf = item[m].ItemMoney.ToString();
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1004)).Config.ToString().Trim())
                                    {
                                        _clf = item[m].ItemMoney.ToString();
                                    }
                                }

                                parameters[10].Text = "挂号费";
                                parameters[10].Value = _ghf;

                                parameters[11].Text = "诊查费";
                                parameters[11].Value = _zcf;

                                parameters[12].Text = "检查费";
                                parameters[12].Value = _jcf;

                                parameters[13].Text = "材料费";
                                parameters[13].Value = _clf;

                                parameters[14].Text = "小写金额";
                                parameters[14].Value = dset.Tables[0].Rows[X]["zje"].ToString();

                                parameters[15].Text = "大写金额";
                                parameters[15].Value = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());

                                parameters[16].Text = "收款员";
                                if (cfgsfy.Config == "1")
                                    parameters[16].Value = InstanceForm.BCurrentUser.Name;
                                else
                                    parameters[16].Value = InstanceForm.BCurrentUser.LoginCode;

                                parameters[17].Text = "病人姓名";
                                parameters[17].Value = txtxm.Text.Trim();

                                parameters[18].Text = "门诊号";
                                parameters[18].Value = lblmzh.Text.Trim();

                                parameters[19].Text = "类型";
                                parameters[19].Value = "";

                                parameters[20].Text = "医保卡号";
                                parameters[20].Value = lbljyh.Text.Trim();

                                parameters[21].Text = "医保支付";
                                parameters[21].Value = Convert.ToString(jsxx.TCZF);

                                parameters[22].Text = "医保卡支付";
                                parameters[22].Value = Convert.ToString(jsxx.ZHZF);

                                parameters[23].Text = "现金支付";
                                parameters[23].Value = Convert.ToDecimal(Convertor.IsNull(tbFp.Rows[0]["xjzf"], "0")).ToString("0.00");

                                parameters[24].Text = "医保余额";
                                parameters[24].Value = Convert.ToString(ybkye - jsxx.ZHZF);
                                //add by zouchihua 2013-7-1

                                parameters[25].Text = "门诊卡号";
                                parameters[25].Value = txtkh.Text;

                                parameters[26].Text = "位置";
                                parameters[26].Value = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");

                                parameters[27].Text = "医院卡余额";
                                parameters[27].Value = ye - (Convert.ToDecimal(tbFp.Rows[0]["cwjz"]));

                                parameters[28].Text = "卡支付金额";//财务记帐
                                parameters[28].Value = cwjz;

                                TrasenFrame.Forms.FrmReportView fv;

                                if (Bview == "true")
                                {
                                    fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号发票.rpt", parameters);
                                    if (!fv.LoadReportSuccess)
                                    {
                                        fv.Dispose();
                                    }
                                    else
                                    {
                                        fv.Show();
                                    }
                                }
                                else
                                {
                                    //TrasenFrame.Forms.FrmReportView.DirectPrint(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号发票.rpt", parameters, false, "", false);
                                    fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号发票.rpt", parameters, true);
                                }

                                #endregion
                            }
                        }
                        else
                        {
                            //参数1005：挂号时发票段使用哪个票据类型的领用段:0-门诊收费票据,1-挂号专用票据
                            SystemCfg cfg1005 = new SystemCfg(1005);
                            if (cfg1005.Config == "0")
                            {
                                //参数1123：门诊发票是否启用新发票格式 0不启用 1启用 默认0
                                SystemCfg cfg1123 = new SystemCfg(1123);
                                PrintClass.OPDInvoice invoice = PrintClass.PrintClass.GetOPDInvoiceInstance(cfg1123.Config);
                                #region 收费发票内容赋值
                                invoice.yysd = yysd;
                                invoice.OtherInfo = "";
                                invoice.HisName = Constant.HospitalName;
                                invoice.PatientName = txtxm.Text.Trim();
                                invoice.OutPatientNo = lblmzh.Text.Trim();
                                //Add By Zj 2012-06-07 如果启用3035参数以后  挂号票上面科室名称 显示诊间名称 特地为株洲中医院修改
                                //参数3035：医生排班按诊室(诊间)排,且诊室(诊间)设置可以多个科室共用  0=否，1=是 默认为0,不要随意改为1，0改为1时需要手工处理数据 
                                if (cfg3035.Config == "1")
                                {
                                    //Modify By Zj 2012-09-10 添加了ZJID 解决了一个科室多个诊间显示不正确的问题
                                    string zjsql = "select PBKS,pbksid,ZJID_QC from jc_mz_yspb where ysid=" + ysdm + " and BSCBZ=0 and PBSJ='" + Convert.ToDateTime(djsj).ToString("yyyy-MM-dd") + " 00:00:00'";

                                    if (Convert.ToDateTime(Convert.ToDateTime(djsj).ToShortTimeString()) <= Convert.ToDateTime("12:00"))//Add By Zj 2013-02-26 为了防止显示不正确，在医生上午在妇科下午在产科的这种排班 增加了类型判断 防止出错
                                        zjsql += " and pblx=1";
                                    else
                                        zjsql += " and pblx=2";

                                    DataTable zjtb = InstanceForm.BDatabase.GetDataTable(zjsql);
                                    if (zjtb.Rows.Count > 0)
                                    {
                                        if (zjtb.Rows[0]["ZJID_QC"].ToString() != "0")
                                        {
                                            //Add By Zj 2012-08-22 再次验证诊间的正确性
                                            string zjmcsql = "select ZJMC from JC_ZJSZ a,JC_ZJSZ_QC b where a.ZJID_QC=b.ZJID_QC and b.deleted=0 and b.ZJID_QC=" + zjtb.Rows[0]["ZJID_QC"].ToString() + " and a.ksdm=" + zjtb.Rows[0]["pbksid"].ToString();
                                            invoice.DepartmentName = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(zjmcsql), "");
                                        }
                                        else
                                            invoice.DepartmentName = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);
                                    }
                                    else
                                        invoice.DepartmentName = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);
                                }
                                else
                                    invoice.DepartmentName = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);
                                invoice.DoctorName = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);
                                invoice.InvoiceNo = "电脑票号：" + Convert.ToString(dset.Tables[0].Rows[X]["fph"]);//Modify By Zj 2012-12-19 多张发票使用循环的发票号

                                invoice.TotalMoneyCN = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());
                                invoice.TotalMoneyNum = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);
                                if (cfgsfy.Config == "1")
                                    invoice.Payee = InstanceForm.BCurrentUser.Name;
                                else
                                    invoice.Payee = InstanceForm.BCurrentUser.LoginCode;

                                DateTime time = Convert.ToDateTime(djsj);
                                invoice.Year = time.Year;
                                invoice.Month = time.Month;
                                invoice.Day = time.Day;

                                bool bqedy = mz_sf.Bqedy(new Guid(Convertor.IsNull(tbFp.Rows[0]["yhlxid"], Guid.Empty.ToString())), InstanceForm.BDatabase);
                                if (bqedy == true && Convert.ToDecimal(tbFp.Rows[0]["yhje"]) != 0)
                                {
                                    invoice.Yhje = 0;
                                    invoice.Qfgz = 0;
                                    invoice.Ybzhzf = 0;
                                    invoice.Ybjjzf = 0;
                                    invoice.Ybbzzf = 0;
                                    invoice.Cwjz = 0;
                                    invoice.Ylkje = 0;
                                    invoice.Srje = 0;
                                    invoice.Xjzf = 0;
                                    invoice.Zpzf = 0;
                                }
                                else
                                {
                                    invoice.Yhje = Convert.ToDecimal(tbFp.Rows[0]["yhje"]);
                                    invoice.Qfgz = Convert.ToDecimal(tbFp.Rows[0]["qfgz"]);
                                    invoice.Ybzhzf = dset.Tables[0].Rows[X]["groupid"].ToString() == "挂号费" ? ybzf : 0; //挂号费才显示医保支付 
                                    invoice.Cwjz = Convert.ToDecimal(tbFp.Rows[0]["cwjz"]);
                                    invoice.Ylkje = Convert.ToDecimal(tbFp.Rows[0]["ylkzf"]);
                                    invoice.Srje = Convert.ToDecimal(tbFp.Rows[0]["srje"]);
                                    invoice.Xjzf = Convert.ToDecimal(tbFp.Rows[0]["xjzf"]);
                                    invoice.Zpzf = Convert.ToDecimal(tbFp.Rows[0]["zpzf"]);
                                }


                                invoice.Zxks = Fun.SeekDeptName(zxks, InstanceForm.BDatabase);
                                invoice.Kye = ye - invoice.Cwjz;
                                invoice.Ybkye = 0;

                                invoice.Ybkye = ybkye - ybzhzf;
                                if (invoice.Ybkye < 0)
                                    invoice.Ybkye = 0;

                                invoice.Yblx = cmbyblx.Text.Trim();
                                invoice.Ybjydjh = jydjh.Trim();
                                invoice.Klx = txtkh.Text.Trim() == "" ? "" : cmbklx.Text.Trim();
                                invoice.Klx_Bje = card.bjebz;

                                invoice.sfck = "";
                                invoice.fyck = "";
                                invoice.htdwlx = cmbdwlx.Text.Trim();
                                invoice.htdwmc = txthtdw.Text.Trim();
                                invoice.kswz = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");

                                invoice.Klx = kh.Trim() == "" ? "" : cmbklx.Text.Trim();
                                invoice.kh = kh;
                                invoice.sfsj = Convert.ToDateTime(djsj).ToShortTimeString();
                                invoice.yysj = yysd;
                                invoice.ghjb = cmbghjb.Text.Substring(cmbghjb.Text.IndexOf("-", 0) + 1);//挂号级别名称 Add By Zj 截取挂号级别 2012-03-06
                                if (Convert.ToDateTime(djsj).DayOfWeek == DayOfWeek.Saturday || Convert.ToDateTime(djsj).DayOfWeek == DayOfWeek.Sunday)//Add By Zj 2012-03-19 添加双休日标记
                                    invoice.sxrbz = "双休日";
                                else
                                    invoice.sxrbz = "";
                                if (_pdxh > 0)
                                    invoice.hzh = _pdxh.ToString();
                                invoice.sex = cmbxb.Text.Trim();

                                PrintClass.InvoiceItem[] item = null;

                                string groupid = dset.Tables[0].Rows[X]["groupid"].ToString();//Add By Zj 2012-12-19 用于分组

                                DataRow[] rows = dset.Tables[1].Select("groupid = '" + groupid + "' ");//Modify By Zj 2012-12-19 用于分组
                                item = new PrintClass.InvoiceItem[rows.Length];
                                for (int m = 0; m <= rows.Length - 1; m++)
                                {
                                    item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                                    item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//发票项目金额
                                }
                                if (rows.Length == 0 && invoice.TotalMoneyNum == 0M)
                                {
                                    item = new PrintClass.InvoiceItem[1];
                                    item[0].ItemName = "挂号费";
                                    item[0].ItemMoney = 0;//发票项目金额
                                }
                                invoice.Items = item;

                                PrintClass.InvoiceItemDetail[] itemdetail = null; //Modify By Tany 2008-12-20 增加发票明细项目

                                //Modify By Tany 2008-12-20 增加发票明细项目
                                DataRow[] rowsdetail = dset.Tables[4].Select("groupid = '" + groupid + "' ");//Modify By Zj 2012-12-19 用于分组
                                itemdetail = new PrintClass.InvoiceItemDetail[rowsdetail.Length];
                                for (int m = 0; m <= rowsdetail.Length - 1; m++)
                                {
                                    itemdetail[m].ItemDetailName = rowsdetail[m]["item_name"].ToString().Trim();
                                    itemdetail[m].ItemDW = rowsdetail[m]["item_unit"].ToString().Trim();
                                    itemdetail[m].ItemGG = "";
                                    itemdetail[m].ItemJS = 1;
                                    itemdetail[m].ItemNum = Convert.ToDecimal(rowsdetail[m]["num"]);
                                    itemdetail[m].ItemPrice = Convert.ToDecimal(rowsdetail[m]["cost_price"]);
                                    itemdetail[m].ItemJE = Convert.ToDecimal(rowsdetail[m]["JE"]);
                                }
                                if (rowsdetail.Length == 0 && invoice.TotalMoneyNum == 0)
                                {
                                    itemdetail = new PrintClass.InvoiceItemDetail[1];
                                    itemdetail[0].ItemDetailName = "挂号费";
                                    itemdetail[0].ItemDW = "";
                                    itemdetail[0].ItemGG = "";
                                    itemdetail[0].ItemJS = 0;
                                    itemdetail[0].ItemNum = 0;
                                    itemdetail[0].ItemPrice = 0;
                                    itemdetail[0].ItemJE = 0;
                                }
                                invoice.ItemDetail = itemdetail;


                                if (Bview != "true")
                                    invoice.Print();
                                else
                                    invoice.Preview();
                                #endregion

                            }
                            else
                            {
                                #region 挂号发票
                                PrintClass.RegisterInvoice Rinvoice = PrintClass.PrintClass.GetRegisterInvoice(cfg1005.Config);

                                Rinvoice.OtherInfo = "";
                                Rinvoice.yysd = yysd;
                                Rinvoice.kh = kh;
                                Rinvoice.HisName = Constant.HospitalName;
                                Rinvoice.PatientName = txtxm.Text.Trim();
                                Rinvoice.OutPatientNo = lblmzh.Text.Trim();
                                Rinvoice.DepartmentName = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);
                                Rinvoice.Pdxh = _pdxh;//排队序号 Modify by Tany 2008-12-26
                                Rinvoice.DoctorName = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);
                                Rinvoice.InvoiceNo = "电脑票号：" + fph.Trim();

                                Rinvoice.TotalMoneyCN = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());
                                Rinvoice.TotalMoneyNum = Convert.ToDecimal(dset.Tables[0].Rows[X]["zje"]);
                                if (cfgsfy.Config == "1")
                                    Rinvoice.Payee = InstanceForm.BCurrentUser.Name;
                                else
                                    Rinvoice.Payee = InstanceForm.BCurrentUser.LoginCode;

                                DateTime time = Convert.ToDateTime(djsj);
                                Rinvoice.Year = time.Year;
                                Rinvoice.Month = time.Month;
                                Rinvoice.Day = time.Day;
                                Rinvoice.yysj = yysd; //Add by zp 2013-10-31
                                Rinvoice.Yhje = Convert.ToDecimal(tbFp.Rows[0]["yhje"]);
                                Rinvoice.Qfgz = Convert.ToDecimal(tbFp.Rows[0]["qfgz"]);
                                Rinvoice.Ybzhzf = ybzf;
                                Rinvoice.Cwjz = Convert.ToDecimal(tbFp.Rows[0]["cwjz"]);
                                Rinvoice.Ylkje = Convert.ToDecimal(tbFp.Rows[0]["ylkzf"]);
                                Rinvoice.Srje = Convert.ToDecimal(tbFp.Rows[0]["srje"]);
                                Rinvoice.Xjzf = Convert.ToDecimal(tbFp.Rows[0]["xjzf"]);
                                Rinvoice.Zxks = Fun.SeekDeptName(zxks, InstanceForm.BDatabase);
                                Rinvoice.Kye = ye - zje;

                                //add by jiangzf 科室位置
                                Rinvoice.kswz = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");

                                //Rinvoice.Ybkye = 0;
                                Rinvoice.Ybkye = ybkye - ybzhzf;
                                if (Rinvoice.Ybkye < 0)
                                    Rinvoice.Ybkye = 0;

                                Rinvoice.Yblx = cmbyblx.Text.Trim();
                                Rinvoice.Ybjydjh = jydjh.ToString().Trim();
                                Rinvoice.Klx = txtkh.Text.Trim() == "" ? "" : cmbklx.Text.Trim();
                                Rinvoice.Klx_Bje = card.bjebz;

                                //Modify By Tany 2008-12-26
                                Rinvoice.RegisterType = cmbghjb.Text.Substring(cmbghjb.Text.IndexOf("-") + 1, cmbghjb.Text.Length - cmbghjb.Text.IndexOf("-") - 1);

                                PrintClass.InvoiceItem[] item = null;

                                DataRow[] rows = dset.Tables[1].Select();
                                item = new PrintClass.InvoiceItem[rows.Length];
                                for (int m = 0; m <= rows.Length - 1; m++)
                                {
                                    item[m].ItemCode = rows[m]["CODE"].ToString().Trim();
                                    item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                                    item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//发票项目金额

                                    //挂号专有项目 Modify By Tany 2008-12-22
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1001)).Config.ToString().Trim())
                                    {
                                        Rinvoice.RegisterFee = item[m].ItemMoney.ToString();
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1002)).Config.ToString().Trim())
                                    {
                                        Rinvoice.ExamineFee = item[m].ItemMoney.ToString();
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1003)).Config.ToString().Trim())
                                    {
                                        Rinvoice.JerqueFee = item[m].ItemMoney.ToString();
                                    }
                                    if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1004)).Config.ToString().Trim())
                                    {
                                        Rinvoice.MaterialFee = item[m].ItemMoney.ToString();
                                    }
                                }
                                Rinvoice.Items = item;
                                //Modify by Tany 2008-12-26 增加挂号类型
                                Rinvoice.Ghlx = _ghlx;

                                if (Bview != "true")
                                    Rinvoice.Print();
                                else
                                    Rinvoice.Preview();
                                #endregion
                            }
                        }
                    }
                    else if (cfg1046.Config == "2")
                    {
                        #region 小票
                        ParameterEx[] parameters = new ParameterEx[30];
                        parameters[0].Text = "医院名称";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                        parameters[1].Text = "发票号";
                        parameters[1].Value = fph.Trim();

                        DateTime time = Convert.ToDateTime(djsj);

                        parameters[2].Text = "年";
                        parameters[2].Value = time.Year;

                        parameters[3].Text = "月";
                        parameters[3].Value = time.Month;

                        parameters[4].Text = "日";
                        parameters[4].Value = time.Day;

                        parameters[5].Text = "挂号类型";
                        parameters[5].Value = _ghlx;

                        parameters[6].Text = "科室";
                        parameters[6].Value = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);

                        parameters[7].Text = "医生";
                        parameters[7].Value = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);

                        parameters[8].Text = "医生级别";
                        parameters[8].Value = cmbghjb.Text.Substring(cmbghjb.Text.IndexOf("-") + 1, cmbghjb.Text.Length - cmbghjb.Text.IndexOf("-") - 1);

                        parameters[9].Text = "挂号序号";
                        parameters[9].Value = _pdxh;

                        PrintClass.InvoiceItem[] item = null;
                        DataRow[] rows = dset.Tables[1].Select();
                        string _ghf = "0";
                        string _zcf = "0";
                        string _jcf = "0";
                        string _clf = "0";
                        item = new PrintClass.InvoiceItem[rows.Length];
                        for (int m = 0; m <= rows.Length - 1; m++)
                        {
                            item[m].ItemCode = rows[m]["CODE"].ToString().Trim();
                            item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                            item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//发票项目金额

                            //add  by zouchihua 2013-3-31 获得卡费的发票项目,如果发票张数2，并且打卡费用小票

                            if (fpzs == 2 && X == 0 && item[m].ItemCode.Trim() == kftb.Rows[0]["code"].ToString().Trim())
                            {
                                if (rows[m]["groupid"].ToString().Trim() == "诊疗卡费")
                                    continue;
                            }
                            if (fpzs == 2 && X == 1) //X=1说明第二次循环,只有卡费
                            {
                                if (item[m].ItemCode.Trim() == kftb.Rows[0]["code"].ToString().Trim())
                                {
                                    item[m].ItemMoney = kf;
                                    //item[m].ItemName=kf.ToString()+"(卡费)";
                                }
                                else
                                    item[m].ItemMoney = 0;
                            }
                            //挂号专有项目 Modify By Tany 2008-12-22
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1001)).Config.ToString().Trim())
                            {
                                _ghf = item[m].ItemMoney.ToString();
                            }
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1002)).Config.ToString().Trim())
                            {
                                _zcf = item[m].ItemMoney.ToString();
                            }
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1003)).Config.ToString().Trim())
                            {
                                _jcf = item[m].ItemMoney.ToString();
                            }
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1004)).Config.ToString().Trim())
                            {
                                _clf = item[m].ItemMoney.ToString();
                            }

                        }
                        try
                        {
                            //增加挂号费备注
                            if (fpzs == 2 && X == 1)
                            {
                                if (Convert.ToDecimal(_ghf == "" ? "0" : _ghf) > 0)
                                    _ghf += "(卡费)";
                                if (Convert.ToDecimal(_zcf == "" ? "0" : _zcf) > 0)
                                    _zcf += "(卡费)";
                                if (Convert.ToDecimal(_jcf == "" ? "0" : _jcf) > 0)
                                    _jcf += "(卡费)";
                                if (Convert.ToDecimal(_clf == "" ? "0" : _clf) > 0)
                                    _clf += "(卡费)";
                            }
                        }
                        catch
                        {

                        }

                        parameters[10].Text = "挂号费";
                        parameters[10].Value = _ghf;

                        parameters[11].Text = "诊查费";
                        parameters[11].Value = _zcf;

                        parameters[12].Text = "检查费";
                        parameters[12].Value = _jcf;

                        parameters[13].Text = "材料费";
                        parameters[13].Value = _clf;

                        parameters[14].Text = "小写金额";
                        parameters[14].Value = dset.Tables[0].Rows[X]["zje"].ToString();

                        parameters[15].Text = "大写金额";
                        parameters[15].Value = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());

                        parameters[16].Text = "收款员";
                        if (cfgsfy.Config == "1")
                            parameters[16].Value = InstanceForm.BCurrentUser.Name;
                        else
                            parameters[16].Value = InstanceForm.BCurrentUser.LoginCode;

                        parameters[17].Text = "病人姓名";
                        parameters[17].Value = txtxm.Text.Trim();

                        parameters[18].Text = "门诊号";
                        parameters[18].Value = lblmzh.Text.Trim();

                        parameters[19].Text = "类型";
                        parameters[19].Value = "";

                        parameters[20].Text = "医保卡号";
                        parameters[20].Value = lbljyh.Text.Trim();

                        parameters[21].Text = "医保支付";
                        parameters[21].Value = Convert.ToString(jsxx.TCZF);

                        parameters[22].Text = "医保卡支付";
                        parameters[22].Value = Convert.ToString(jsxx.ZHZF);

                        parameters[23].Text = "现金支付";
                        parameters[23].Value = Convert.ToDecimal(Convertor.IsNull(tbFp.Rows[0]["xjzf"], "0")).ToString("0.00");

                        parameters[24].Text = "医保余额";
                        parameters[24].Value = Convert.ToString(ybkye - jsxx.ZHZF);


                        parameters[25].Text = "卡号";
                        parameters[25].Value = txtkh.Text;

                        parameters[26].Text = "就诊时段";
                        parameters[26].Value = yysd;

                        parameters[27].Text = "医院卡余额"; //add by zp 2013-12-20
                        parameters[27].Value = ye - (Convert.ToDecimal(tbFp.Rows[0]["cwjz"]));

                        parameters[28].Text = "卡支付金额";//财务记帐
                        parameters[28].Value = cwjz;

                        parameters[29].Text = "位置";
                        parameters[29].Value = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");

                        TrasenFrame.Forms.FrmReportView fv;

                        if (Bview == "true")
                        {
                            fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号小票.rpt", parameters);
                            if (!fv.LoadReportSuccess)
                            {
                                fv.Dispose();
                            }
                            else
                            {
                                fv.Show();
                            }
                        }
                        else
                        {
                            //TrasenFrame.Forms.FrmReportView.DirectPrint(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号发票.rpt", parameters, false, "", false);
                            fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号小票.rpt", parameters, true);
                        }
                        /*add by zch 2013-03-26 门诊小票打印是否打在一张上（只切纸一次）0=否 ，1=是 */
                        // if (cfg1078.Config.Trim() == "1")//打两份
                        // fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号小票.rpt", parameters, true);
                        #endregion
                    }
                }
                //打小票 add by zouchihua 2013-3-29
                for (int X = 0; X <= (new SystemCfg(1067).Config != "2" ? 1 : fpzs) - 1; X++)//Modify By Zj 2012-12-20 记录数修改为发票数
                {
                    int ksdm = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));
                    int ysdm = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));
                    string ssql = "select *,deptaddr from mz_fpb a (nolock) left join jc_dept_property b on a.ksdm=b.dept_id where fpid='" + new Guid(dset.Tables[0].Rows[X]["fpid"].ToString()) + "'";
                    DataTable tbFp = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (cfg1046.Config == "2")
                    {
                        #region 小票
                        ParameterEx[] parameters = new ParameterEx[30];
                        parameters[0].Text = "医院名称";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                        parameters[1].Text = "发票号";
                        parameters[1].Value = fph.Trim();

                        DateTime time = Convert.ToDateTime(djsj);

                        parameters[2].Text = "年";
                        parameters[2].Value = time.Year;

                        parameters[3].Text = "月";
                        parameters[3].Value = time.Month;

                        parameters[4].Text = "日";
                        parameters[4].Value = time.Day;

                        parameters[5].Text = "挂号类型";
                        parameters[5].Value = _ghlx;

                        parameters[6].Text = "科室";
                        parameters[6].Value = Fun.SeekDeptName(ksdm, InstanceForm.BDatabase);

                        parameters[7].Text = "医生";
                        parameters[7].Value = Fun.SeekEmpName(ysdm, InstanceForm.BDatabase);

                        parameters[8].Text = "医生级别";
                        parameters[8].Value = cmbghjb.Text.Substring(cmbghjb.Text.IndexOf("-") + 1, cmbghjb.Text.Length - cmbghjb.Text.IndexOf("-") - 1);

                        parameters[9].Text = "挂号序号";
                        parameters[9].Value = _pdxh;

                        PrintClass.InvoiceItem[] item = null;
                        DataRow[] rows = dset.Tables[1].Select();
                        string _ghf = "";
                        string _zcf = "";
                        string _jcf = "";
                        string _clf = "";
                        item = new PrintClass.InvoiceItem[rows.Length];
                        for (int m = 0; m <= rows.Length - 1; m++)//Modify By zp 2013-09-30
                        {
                            item[m].ItemCode = rows[m]["CODE"].ToString().Trim();
                            item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                            item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//发票项目金额
                            //add  by zouchihua 2013-3-31 获得卡费的发票项目,如果发票张数2，并且打卡费用小票

                            if (fpzs == 2 && X == 0 && item[m].ItemCode.Trim() == kftb.Rows[0]["code"].ToString().Trim())
                            {
                                if (rows[m]["groupid"].ToString().Trim() == "诊疗卡费")
                                    continue;

                            }
                            else
                                if (fpzs == 2 && X == 1) //X=1说明第二次循环,只有卡费
                                {
                                    if (item[m].ItemCode.Trim() == kftb.Rows[0]["code"].ToString().Trim())
                                        item[m].ItemMoney = kf;
                                    else
                                        item[m].ItemMoney = 0;
                                }
                            //挂号专有项目 Modify By Tany 2008-12-22
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1001)).Config.ToString().Trim())
                            {
                                _ghf = item[m].ItemMoney.ToString();
                            }
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1002)).Config.ToString().Trim())
                            {
                                _zcf = item[m].ItemMoney.ToString();
                            }
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1003)).Config.ToString().Trim())
                            {
                                _jcf = item[m].ItemMoney.ToString();
                            }
                            if (item[m].ItemCode == (new TrasenFrame.Classes.SystemCfg(1004)).Config.ToString().Trim())
                            {
                                _clf = item[m].ItemMoney.ToString();
                            }


                        }
                        try
                        {
                            //增加挂号费备注
                            if (fpzs == 2 && X == 1)
                            {
                                if (Convert.ToDecimal(_ghf == "" ? "0" : _ghf) > 0)
                                    _ghf += "(卡费)";
                                if (Convert.ToDecimal(_zcf == "" ? "0" : _zcf) > 0)
                                    _zcf += "(卡费)";
                                if (Convert.ToDecimal(_jcf == "" ? "0" : _jcf) > 0)
                                    _jcf += "(卡费)";
                                if (Convert.ToDecimal(_clf == "" ? "0" : _clf) > 0)
                                    _clf += "(卡费)";
                            }
                        }
                        catch
                        {

                        }
                        parameters[10].Text = "挂号费";
                        parameters[10].Value = _ghf;

                        parameters[11].Text = "诊查费";
                        parameters[11].Value = _zcf;

                        parameters[12].Text = "检查费";
                        parameters[12].Value = _jcf;

                        parameters[13].Text = "材料费";
                        parameters[13].Value = _clf;

                        parameters[14].Text = "小写金额";
                        parameters[14].Value = dset.Tables[0].Rows[X]["zje"].ToString();

                        parameters[15].Text = "大写金额";
                        parameters[15].Value = Money.NumToChn(dset.Tables[0].Rows[X]["zje"].ToString());

                        parameters[16].Text = "收款员";
                        if (cfgsfy.Config == "1")
                            parameters[16].Value = InstanceForm.BCurrentUser.Name;
                        else
                            parameters[16].Value = InstanceForm.BCurrentUser.LoginCode;

                        parameters[17].Text = "病人姓名";
                        parameters[17].Value = txtxm.Text.Trim();

                        parameters[18].Text = "门诊号";
                        parameters[18].Value = lblmzh.Text.Trim();

                        parameters[19].Text = "类型";
                        parameters[19].Value = "";

                        parameters[20].Text = "医保卡号";
                        parameters[20].Value = lbljyh.Text.Trim();

                        parameters[21].Text = "医保支付";
                        parameters[21].Value = Convert.ToString(jsxx.TCZF);

                        parameters[22].Text = "医保卡支付";
                        parameters[22].Value = Convert.ToString(jsxx.ZHZF);

                        parameters[23].Text = "现金支付";
                        parameters[23].Value = Convert.ToDecimal(Convertor.IsNull(tbFp.Rows[0]["xjzf"], "0")).ToString("0.00");

                        parameters[24].Text = "医保余额";
                        parameters[24].Value = Convert.ToString(ybkye - jsxx.ZHZF);

                        parameters[25].Text = "卡号";
                        parameters[25].Value = txtkh.Text;
                        TrasenFrame.Forms.FrmReportView fv;

                        parameters[26].Text = "就诊时段";
                        parameters[26].Value = yysd;

                        parameters[27].Text = "医院卡余额"; //add by zp 2013-12-20
                        parameters[27].Value = ye - (Convert.ToDecimal(tbFp.Rows[0]["cwjz"]));

                        parameters[28].Text = "卡支付金额";//add by jiangzf财务记帐
                        parameters[28].Value = cwjz;

                        parameters[29].Text = "位置";//add by jiangzf 
                        parameters[29].Value = Convertor.IsNull(tbFp.Rows[0]["deptaddr"], "");


                        /*add by zch 2013-03-26 门诊小票打印是否打在一张上（只切纸一次）0=否 ，1=是 */
                        if (cfg1078.Config.Trim() == "1")//打两份
                            fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号小票.rpt", parameters, true);
                        #endregion
                    }
                }

                if (fpzs == 2 && new SystemCfg(1067).Config == "3")
                {

                    #region 小票
                    ParameterEx[] parameters = new ParameterEx[10];
                    parameters[0].Text = "医院名称";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

                    DateTime time = Convert.ToDateTime(djsj);

                    parameters[1].Text = "年";
                    parameters[1].Value = time.Year;

                    parameters[2].Text = "月";
                    parameters[2].Value = time.Month;

                    parameters[3].Text = "日";
                    parameters[3].Value = time.Day;


                    parameters[4].Text = "小写金额";
                    parameters[4].Value = kf.ToString();

                    parameters[5].Text = "大写金额";
                    parameters[5].Value = Money.NumToChn(kf.ToString());

                    parameters[6].Text = "收款员";
                    if (cfgsfy.Config == "1")
                        parameters[6].Value = InstanceForm.BCurrentUser.Name;
                    else
                        parameters[6].Value = InstanceForm.BCurrentUser.LoginCode;

                    parameters[7].Text = "病人姓名";
                    parameters[7].Value = txtxm.Text.Trim();


                    parameters[8].Text = "现金支付";
                    parameters[8].Value = kf.ToString("0.00");


                    parameters[9].Text = "卡号";
                    parameters[9].Value = txtkh.Text;

                    TrasenFrame.Forms.FrmReportView fv;

                    if (Bview == "true")
                    {
                        fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\诊疗卡费.rpt", parameters);
                        if (!fv.LoadReportSuccess)
                        {
                            fv.Dispose();
                        }
                        else
                        {
                            fv.Show();
                        }
                    }
                    else
                    {
                        fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\诊疗卡费.rpt", parameters, true);
                    }
                    #endregion
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
        }

        private bool MatchAge()
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtks.Text.Trim()))
                    return false;
                int dept_id = Convert.ToInt32(this.txtks.Tag);
                DateTime birth = this.dtpcsrq.Value;

                if (string.IsNullOrEmpty(cfg1088.Config))
                    return true;

                string[] par_match = cfg1088.Config.Split(',');
                foreach (string par in par_match)
                {
                    string[] par_m = par.Split(':');
                    if (par_m.Length < 1) return true;

                    if (int.Parse(par_m[0]) == dept_id) /*与当前科室匹配 则判断患者年龄是否小于参数设置的年龄*/
                    {
                        // DateTime now_time = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                        // string age = TrasenClasses.GeneralClasses.Age.GetAgeString(birth, now_time, 1);
                        string age = this.txtnl.Text;
                        switch (this.cmbDW.Text.Trim())
                        {
                            case "岁":
                                if (int.Parse(age) > int.Parse(par_m[1]))
                                {
                                    MessageBox.Show("当前科室限制了患者的挂号年龄!必须是" + par_m[1] + "岁以内才允许挂当前科室号");
                                    return false;
                                }
                                break;
                            default:
                                return true;
                        }
                        break;
                    }

                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("MatchAge函数出现异常!原因:" + ea.Message, "错误");
            }
            return true;
        }


        /// <summary>
        /// 生成处方分组表格
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="klx"></param>
        /// <returns></returns>
        private DataTable GetGroupCf(DataSet dset, int klx)
        {
            if (klx > 0)
            {
                string ssql = "select sfxmid from jc_klx where klx=" + klx.ToString();//找到卡收费ID
                int ksfxmid = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(ssql));
                DataTable grouptb = dset.Tables[4].Clone();//克隆收费明细表
                grouptb.Columns.Add("分组ID", Type.GetType("System.String"));//添加分组ID列
                grouptb.Columns.Add("发票分类CODE", Type.GetType("System.String"));//添加发票分类代码列
                grouptb.Columns.Add("发票分类NAME", Type.GetType("System.String"));//添加发票分类名称列
                grouptb.Columns.Add("统计大项目名称", Type.GetType("System.String"));//添加统计大项目名称列
                for (int i = 0; i < dset.Tables[4].Rows.Count; i++)//循环添加至克隆表
                {
                    DataRow dr = grouptb.NewRow();
                    dr["ITEM_ID"] = dset.Tables[4].Rows[i]["ITEM_ID"];
                    dr["ITEM_NAME"] = dset.Tables[4].Rows[i]["ITEM_NAME"];
                    dr["ITEM_UNIT"] = dset.Tables[4].Rows[i]["ITEM_UNIT"];
                    dr["cost_price"] = dset.Tables[4].Rows[i]["cost_price"];
                    dr["num"] = dset.Tables[4].Rows[i]["num"];
                    dr["je"] = dset.Tables[4].Rows[i]["je"];
                    dr["yhje"] = dset.Tables[4].Rows[i]["yhje"];
                    dr["py_code"] = dset.Tables[4].Rows[i]["py_code"];
                    dr["wb_code"] = dset.Tables[4].Rows[i]["wb_code"];
                    dr["std_code"] = dset.Tables[4].Rows[i]["std_code"];
                    string fpsql = "SELECT A.CODE,A.ITEM_NAME,B.ITEM_NAME AS STATNAME FROM JC_MZFP_XM A INNER JOIN  JC_STAT_ITEM B ON B.MZFP_CODE=A.CODE WHERE B.CODE='" + dset.Tables[4].Rows[i]["statitem_code"].ToString() + "' ";
                    DataTable fptb = InstanceForm.BDatabase.GetDataTable(fpsql);
                    if (fptb.Rows.Count != 1)
                    {
                        MessageBox.Show("统计大项目关联的发票项目分类大于一个或者不存在对应关系。不能进行收费操作，请联系管理员检查数据！", "提示");
                        return null;
                    }
                    dr["发票分类CODE"] = fptb.Rows[0]["CODE"].ToString();
                    dr["发票分类NAME"] = fptb.Rows[0]["ITEM_NAME"].ToString();
                    dr["statitem_code"] = dset.Tables[4].Rows[i]["statitem_code"];
                    dr["统计大项目名称"] = fptb.Rows[0]["STATNAME"].ToString();
                    dr["hiscode"] = dset.Tables[4].Rows[i]["hiscode"];
                    dr["项目来源"] = dset.Tables[4].Rows[i]["项目来源"];
                    if (ksfxmid == Convert.ToInt32(dset.Tables[4].Rows[i]["ITEM_ID"]))//如果等于卡费ID 分组ID设置为卡费 否则就设置为挂号费
                        dr["分组ID"] = "卡费";
                    else
                        dr["分组ID"] = "挂号费";
                    grouptb.Rows.Add(dr);
                }
                return grouptb;
            }
            else
                return null;
        }
        /// <summary>
        /// 住院欠费检查
        /// </summary>
        /// <param name="brxxid"></param>
        /// <param name="xm"></param>
        private bool CheckZyFee(Guid brxxid, string xm)
        {
            //add by wangzhi 2010-10-05
            //增加判断病人是否曾经住院并且欠费出院，如果有，给出提示
            string ssq = "";
            SystemCfg cfg = new SystemCfg(1044);
            if (cfg.Config.Trim() == "1")
            {
                SystemCfg cfg1045 = new SystemCfg(1045);
                if (cfg1045.Config.Trim() == "1")
                {

                    ssq = @"select top 1 b.patient_id,lack_fee,discharge_bdate,discharge_edate
                    from zy_discharge a ,zy_inpatient b 
                    where a.inpatient_id=b.inpatient_id
                        and a.ntype=2 and a.cancel_bit=0 and lack_fee>0
                        and patient_id = '" + brxxid.ToString() + "' order by a.discharge_date desc";
                }
                else if (cfg1045.Config.Trim() == "2")
                {
                    ssq = @"select top 1 b.patient_id,lack_fee,discharge_bdate,discharge_edate
                    from zy_discharge a ,zy_inpatient b ,yy_brxx c
                    where a.inpatient_id=b.inpatient_id and b.patient_id=c.brxxid
                        and a.ntype=2 and a.cancel_bit=0 and lack_fee>0
                        and c.brxm = '" + xm + "' order by a.discharge_date desc";
                }
                DataRow drZyqf = InstanceForm.BDatabase.GetDataRow(ssq);
                if (drZyqf != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("该病人曾于");
                    sb.Append(Convert.ToDateTime(drZyqf["discharge_bdate"]).ToString("yyyy-MM-dd HH:mm;ss"));
                    sb.Append("～");
                    sb.Append(Convert.ToDateTime(drZyqf["discharge_edate"]).ToString("yyyy-MM-dd HH:mm;ss"));
                    sb.Append("在本院住院");
                    sb.Append(",并且以欠费出院方式出院（欠费：" + Convert.ToDecimal(drZyqf["lack_fee"]).ToString() + "元）");
                    sb.Append("\r\n");
                    sb.Append("是否继续挂号？");

                    if (MessageBox.Show(sb.ToString(), "欠费病人", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return false;
                    else
                        return true;
                }
            }
            return true;
            //end add
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 22)
            {
                txtkh.Text = "";
                e.Handled = true;
                return;

            }

            if ((int)e.KeyChar != 13)
            {
                _isCreateNewCard = false; //Add By tany2010-09-18
                return;
            }

            if (txtkh.Text.Trim() == "")
            {
                //Add By tany2010-09-18
                _isCreateNewCard = false;
                if (sender != null)
                {
                    SendKeys.Send("{TAB}");
                }
                return;
            }
            if (cfg1060.Config == "0")//当参数1060 等于0  不允许卡中包含英文字母的时候验证卡的数字型 Add By Zj 2012-05-10
            {
                if (!Convertor.IsNumeric(txtkh.Text.Trim()))
                {
                    MessageBox.Show("请输入正确的卡号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtkh.SelectAll();
                    return;
                }
            }


            int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
            txtkh.Text = Fun.returnKh(klx, txtkh.Text.Trim(), InstanceForm.BDatabase);
            if (!Isyy) //add by zp 2014-03-26 如果是非预约的就清空病人信息数据 show出创建病人信息框
            {
                txtkh.Text = ToDBC(txtkh.Text);
                txtxm.Text = "";
                cmbxb.Text = "";
                txtnl.Text = "";
                cmbDW.SelectedIndex = 0;
                txtgrlxfs.Text = "";
                txtjtdz.Text = "";
            }
            this.Tag = Guid.Empty.ToString();
            //使用左连接。因为有些卡登记了但没有病人信息，只有持卡人信息
            string ssq = @"select *,dbo.FUN_ZY_SEEKSEXNAME(xb) 性别,brlx from YY_KDJB a inner join YY_BRXX b 
                            on a.brxxid=b.brxxid where a.klx=" + klx + " and a.kh='" + txtkh.Text + "'  and a.ZFBZ=0 ";
            tbk = InstanceForm.BDatabase.GetDataTable(ssq);
            if (tbk.Rows.Count == 0) //没有找到病人信息和卡信息
            {
                if (New_Card != "true")
                {
                    this.Tag = Guid.Empty.ToString();
                    MessageBox.Show("没有找到卡信息，请确认卡号是否正确或卡没有作废");
                    return;
                }
                else
                {
                    if (cfg1161.Config == "1")
                    {
                        MessageBox.Show("参数1161开启时, 不允许在此处办理新卡业务", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    this.Tag = Guid.Empty.ToString();
                    if (!Isyy) //Add by zp  2014-03-26 如果是无卡预约的 则不需要再填写一次病人信息了
                    {
                        ts_mz_kgl.Frmbrkdj f = new ts_mz_kgl.Frmbrkdj(_menuTag, "病人信息登记", _mdiParent, Guid.Empty, Guid.Empty, InstanceForm.BDatabase);
                        f.txtkh.Text = txtkh.Text;
                        f.txtbrxm.Text = "未写名";
                        f.cmbklx.SelectedValue = cmbklx.SelectedValue;
                        //if (f.txtbrxm.Enabled == true) f.txtbrxm.Focus();

                        //add by wangzhi 2010-10-27
                        //设置病人登记对话框为延时保存病人信息，在点击挂号后一并保存
                        f.DelaySave = true;
                        if (f.ShowDialog() == DialogResult.Cancel)
                        {
                            ControlEnable();
                            butnew_Click(sender, e);
                            return;
                        }
                        _new_brxx_kxx = f.Brdjxx;
                        //add by cc 2014-04-24
                        yy_brxx_bc = f.yy_brxx_bc;
                        //end add
                        ShowBrxx();
                    }
                    //end add

                    //comment by wangzhi 2010-10-27
                    //if (f.brxxid != Guid.Empty)
                    //    txtkh_KeyPress(sender, e);
                    //end comment

                    this.RechargeWithNewCard(klx, ref _new_brxx_kxx);

                    //Add By tany2010-09-18
                    _isCreateNewCard = true;
                    txtks.Focus();
                    return;
                }
            }
            else
            {
                //正在处理预约病人挂号，且刷卡病人不是预约病人,取消预约状态,进入正常挂号状态
                if (Isyy && tbk.Rows[0]["brxm"].ToString() != txtxm.Text.Trim())
                {
                    Isyy = false;
                    butqh.Tag = "";
                    butqh.BackColor = Color.WhiteSmoke;
                    txtks.Text = "";
                    txtys.Text = "";
                    txtks.Enabled = true;
                    cmbghjb.Enabled = true;
                    txtys.Enabled = true;
                    treeView1.Enabled = true;
                }
                _new_brxx_kxx = null;  // add by wangzhi 2010-10-27
                // 如果通过卡找到病人信息，则将新病人的办卡信息（包括病人基本信息，卡信息）之为Null

                if (new SystemCfg(1137).Config == "1")
                {
                    DataTable dt = mz_ghxx.GetLastestGhxx(txtkh.Text.Trim(), klx, InstanceForm.BDatabase);
                    if (dt.Rows.Count == 0)
                    {
                        label22.Text = "";
                        //return;
                    }
                    else
                    {
                        label22.Text = "上次挂号科室：" + dt.Rows[0]["ghks"].ToString() + ",就诊医生：" + dt.Rows[0]["jzys"].ToString();
                    }
                }
            }
            //else
            //{
            //    throw new Exception("错误,没有找到病人信息");
            //}

            if (Modif_ini == "true")
            {
                txtxm.Enabled = false;
                cmbxb.Enabled = false;
                txtnl.Enabled = false;
                cmbDW.Enabled = false;
                txtgrlxfs.Enabled = false;
                txtjtdz.Enabled = false;
            }
            else
            {
                txtxm.Enabled = true;
                cmbxb.Enabled = true;
                txtnl.Enabled = true;
                cmbDW.Enabled = true;
                txtgrlxfs.Enabled = true;
                txtjtdz.Enabled = true;
            }

            if (tbk.Rows.Count > 1)
            {
                MessageBox.Show("找到多张同时有效的卡,请和系统管理员联系");
                return;
            }
            if (Convert.ToInt16(tbk.Rows[0]["sdbz"]) == 1)
            {
                MessageBox.Show("这张卡已被锁定,不能消费.请先激活", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Getghzs(new Guid(tbk.Rows[0]["kdjid"].ToString()));

            if (xm_ini == "true") txtxm.Enabled = false;
            if (xb_ini == "true") cmbxb.Enabled = false;
            if (nl_ini == "true") { txtnl.Enabled = false; cmbDW.Enabled = false; }
            if (lxfs_ini == "true") txtgrlxfs.Enabled = false;
            if (jtdz_ini == "true") txtjtdz.Enabled = false;

            lblkye.Text = tbk.Rows[0]["kye"].ToString();
            txtxm.Text = Convertor.IsNull(tbk.Rows[0]["brxm"], "");
            if (txtxm.Text.Trim() == "")
                txtxm.Text = Convertor.IsNull(tbk.Rows[0]["CKRXM"], "");
            txtgrlxfs.Text = Convertor.IsNull(tbk.Rows[0]["BRLXFS"], "");
            txtjtdz.Text = Convertor.IsNull(tbk.Rows[0]["JTDZ"], "");
            cmbxb.Text = Convertor.IsNull(tbk.Rows[0]["性别"], "");
            lblgzdw.Text = Convertor.IsNull(tbk.Rows[0]["gzdw"], "");
            cmbbrlx.SelectedValue = Convertor.IsNull(tbk.Rows[0]["brlx"], "");


            //添加优惠方案
            AddYhlx();

            if (Convertor.IsNull(tbk.Rows[0]["csrq"], "") != "")
            {
                txtnl.Text = DateManager.DateToAge(Convert.ToDateTime(tbk.Rows[0]["csrq"]), InstanceForm.BDatabase).AgeNum.ToString();
                dtpcsrq.Value = Convert.ToDateTime(tbk.Rows[0]["csrq"]);
                AutoSelectGhjb();
            }
            this.Tag = Convertor.IsNull(tbk.Rows[0]["brxxid"], Guid.Empty.ToString());

            if (Convert.ToInt16(tbk.Rows[0]["zbbz"]) == 1)
            {
                txtks.Text = Fun.SeekDeptName(Convert.ToInt32(tbk.Rows[0]["zbks"]), InstanceForm.BDatabase);
                txtks.Tag = tbk.Rows[0]["zbks"].ToString();
                cmbghjb.SelectedValue = tbk.Rows[0]["ZBJB"].ToString() == "0" ? "1" : tbk.Rows[0]["ZBJB"].ToString();
                txtys.Text = Fun.SeekEmpName(Convert.ToInt32(tbk.Rows[0]["ZBYS"]), InstanceForm.BDatabase);
                txtys.Tag = tbk.Rows[0]["ZBYS"].ToString();
            }

            //报价器 姓名
            string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (bqybjq == "true")
            {
                string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.Call(ts_call.DmType.清除, "");//add by zouchihua 2013-6-24 姓名之前先清除
                call.Call(ts_call.DmType.姓名, txtxm.Text.Trim());
            }

            txtks.Focus();

            //if (sender != null)
            //{
            //    SendKeys.Send("{TAB}");

            //}
        }
        /// <summary>
        /// 通过病人年龄自动选择挂号级别 Add By zp 2013-09-04
        /// </summary>
        private void AutoSelectGhjb()
        {
            try
            {
                string age = this.txtnl.Text;
                int i_age = 0;
                int _ghjb = -1;
                if (this.cmbDW.Text.Trim() == "岁" && (!string.IsNullOrEmpty(age)))
                    i_age = int.Parse(age);
                _ghjb = ts_mz_class.Fun.SelectDocLevelByPatAge(i_age, this.dt_AgeToDocLevel);
                if (_ghjb > -1)
                    this.cmbghjb.SelectedValue = _ghjb;
            }
            catch (Exception ea)
            {
                MessageBox.Show("函数AutoSelectGhjb出现异常!原因:" + ea.Message);
            }
        }

        private void txtks_KeyPress(object sender, KeyPressEventArgs e)
        {

            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "科室名称", "数字码", "拼音码", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbks;
                f.WorkForm = this;
                f.srcControl = txtks;
                f.Font = txtks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtks.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtks.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    txtks.Text = f.SelectDataRow["name"].ToString().Trim();
                    GetXh(true);
                    if (cfg1058.Config == "0")
                    {
                        Tbys = Fun.GetGhys(Convert.ToInt32(txtks.Tag), 0, InstanceForm.BDatabase);
                    }
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
            else
            {
                if (txtks.Text.Trim() == "")
                {
                    txtks.Focus();
                    return;
                }
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtys_KeyPress(object sender, KeyPressEventArgs e)
        {

            Control control = (Control)sender;

            if ((int)e.KeyChar == 8)
            {
                txtys.Tag = "0";
                txtys.Text = "";
                return;
            }

            if ((int)e.KeyChar == 13 && Convertor.IsNumeric(txtys.Text.Trim()) == true)
            {
                DataRow[] rows = Tbys.Select("code='" + txtys.Text.Trim() + "'", "");
                if (rows.Length == 1)
                {
                    txtys.Tag = rows[0]["employee_id"].ToString();
                    txtys.Text = rows[0]["name"].ToString().Trim();
                    GetDoctorPbxx(rows[0]["employee_id"].ToString());
                    //Add By Zj 2012-02-16 输入医生编码显示预约限制信息
                    GetXh(true);
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                    return;
                }
                else
                {
                    txtys.Tag = "0";
                    txtys.Text = "";
                    return;
                }
            }

            if ((int)e.KeyChar != 13 && Convertor.IsNumeric(e.KeyChar.ToString()) == false)
            {
                string[] headtext = new string[] { "医生姓名", "代码", "工号", "拼音码", "五笔码", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tbys;
                f.WorkForm = this;
                f.srcControl = txtys;
                f.Font = txtks.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txtys.Focus();
                    e.Handled = true;
                }
                else
                {
                    txtys.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    txtys.Text = f.SelectDataRow["name"].ToString().Trim();
                    GetDoctorPbxx(txtys.Tag.ToString());
                    #region  屏蔽代码
                    ////////int yghs = 0; int xhs = 0; int swxhs = 0; int xwxhs = 0; int lsjh = 0;
                    ////////mz_ghxx.GetXhs(Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0")), out yghs, out xhs, out swxhs, out xwxhs, out lsjh, InstanceForm.BDatabase);
                    ////////if (xhs > 0) lblxh.Text = yghs.ToString().ToString() + "/" + Convert.ToString(xhs+lsjh); else lblxh.Text = "";
                    ////////if (swxhs > 0) lblxh.Text = lblxh.Text + " 上午:" + swxhs.ToString();//上午
                    ////////if (xwxhs > 0) lblxh.Text = lblxh.Text + " 下午:" + xwxhs.ToString();//下午
                    ////////if (lsjh > 0) lblxh.Text = lblxh.Text + " 加号:" + lsjh.ToString();
                    #endregion
                    GetXh(true);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }

            }
            if ((int)e.KeyChar == 13)
            {
                //Add By Zj 2012-04-09 输入医生编码显示预约限制信息
                GetDoctorPbxx(txtys.Tag.ToString());
                //Add By Zj 2012-02-16 输入医生编码显示预约限制信息
                GetXh(true);
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }

        }

        private void ReadGhxx()
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[14];

                parameters[0].Text = "@djy";
                parameters[0].Value = InstanceForm.BCurrentUser.EmployeeId;

                parameters[1].Text = "@rq1";
                parameters[1].Value = DateTime.Now.ToShortDateString() + " 00:00:00";

                parameters[2].Text = "@rq2";
                parameters[2].Value = DateTime.Now.ToShortDateString() + " 23:59:59";

                parameters[3].Text = "@GHLB";
                parameters[3].Value = 0;

                parameters[4].Text = "@BRLX";
                parameters[4].Value = 0;

                parameters[5].Text = "@GHKS";
                parameters[5].Value = 0;

                parameters[6].Text = "@GHJB";
                parameters[6].Value = 0;

                parameters[7].Text = "@GHYS";
                parameters[7].Value = 0;

                parameters[8].Text = "@KLX";
                parameters[8].Value = 0;

                parameters[9].Text = "@kh";
                parameters[9].Value = "";

                parameters[10].Text = "@brxm";
                parameters[10].Value = "";

                parameters[11].Text = "@blh";
                parameters[11].Value = "";

                parameters[12].Text = "@px";
                parameters[12].Value = " DESC ";

                parameters[13].Text = "@fph";
                parameters[13].Value = "";
                //modify by cc 界面查询不需要使用视图SP_MZSF_CX_GHXXFORGHJM
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_MZSF_CX_GHXXFORGHJM", parameters, 30);
                Fun.AddRowtNo(tb);
                this.dataGridView1.DataSource = tb;

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtnl.Visible = rdonl.Checked == true ? true : false;
            dtpcsrq.Visible = rdocsrq.Checked == true ? true : false;
        }

        private void butclear_Click(object sender, EventArgs e)
        {
            ControlEnable();
            butnew_Click(sender, e);


        }

        private void txtnl_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtnl.Text.Trim() != "" && Convertor.IsNumeric(txtnl.Text.Trim()) == false)
                {
                    MessageBox.Show("年龄请输入数字");
                    return;
                }
                if (txtnl.Text.Trim() != "")
                {
                    //DateTime date = DateManager.AgeToDate(new Age(Convert.ToInt32(txtnl.Text), AgeUnit.岁), InstanceForm.BDatabase);
                    //dtpcsrq.Value = date;
                    dtpcsrq.Value = DateManager.AgeToDate(new Age(Convert.ToInt16(txtnl.Text), (AgeUnit)cmbDW.SelectedIndex), InstanceForm.BDatabase);
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmghdj_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && butsave.Enabled == true)
                butsave_Click(sender, e);

            if (e.KeyData == Keys.F1 && buthelp.Enabled == true)
                buthelp_Click(sender, e);

            if (e.KeyData == Keys.F3)
                butnew_Click(sender, e);

            if (e.KeyData == Keys.F7)
                butreadcard_Click(sender, e);

            if (e.KeyData == Keys.F10)
            {
                cmbdwlx.DroppedDown = true;
                cmbdwlx.Focus();
            }
            if (e.KeyData == Keys.F6)
            {
                cmbyblx.DroppedDown = true;
                cmbyblx.Focus();
            }
            if (e.KeyData == Keys.F9)
            {
                butclear_Click(sender, e);
            }

            if (e.KeyCode == Keys.F12)
            {
                for (int i = 0; i <= _mdiParent.MdiChildren.Length - 1; i++)
                {
                    if (_mdiParent.MdiChildren[i].Name == "Frmhjsf")
                    {
                        _mdiParent.MdiChildren[i].Activate();
                        _mdiParent.MdiChildren[i].Show();
                    }
                }
            }
        }

        private void txtxm_Leave(object sender, EventArgs e)
        {
            #region  如果使用卡 且持卡人病人信息不等于当前姓名时，就新增病人信息，或找相应的病人信息
            if (tbk != null)
            {
                if (tbk.Rows.Count != 0)
                {
                    if (Convertor.IsNull(tbk.Rows[0]["brxm"], "").Trim() != txtxm.Text.Trim())
                    {
                        //DialogResult dr = MessageBox.Show("");
                        string ss = "select * from YY_BRXX where brxxid in(select b.brxxid from YY_KDJB  a inner join vi_mz_ghxx b on a.kdjid=b.kdjid and a.brxxid='" + tbk.Rows[0]["brxxid"].ToString() + "')";
                        DataTable tbghxx = InstanceForm.BDatabase.GetDataTable(ss);
                        this.Tag = Guid.Empty.ToString();
                        for (int i = 0; i <= tbghxx.Rows.Count - 1; i++)
                        {
                            if (tbghxx.Rows[i]["brxm"].ToString().Trim() == txtxm.Text.Trim())
                            {
                                this.Tag = tbghxx.Rows[i]["brxxid"].ToString();
                                lblkye.Text = tbk.Rows[0]["kye"].ToString();
                                txtgrlxfs.Text = Convertor.IsNull(tbk.Rows[0]["BRLXFS"], "");
                                txtjtdz.Text = Convertor.IsNull(tbk.Rows[0]["JTDZ"], "");
                                cmbxb.Text = Convertor.IsNull(tbk.Rows[0]["xb"], "");
                            }
                        }
                    }
                }
            }
            #endregion

            //报价器 姓名
            string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (bqybjq == "true")
            {
                string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.Call(ts_call.DmType.清除, "");
                call.Call(ts_call.DmType.姓名, txtxm.Text.Trim());
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //读医保卡
        private void butreadcard_Click(object sender, EventArgs e)
        {


            //读卡的话默认第一个医保类型 
            if (Convert.ToInt32(cmbyblx.SelectedValue) <= 0)
            {
                if (cmbyblx.Items.Count > 0) cmbyblx.SelectedIndex = 0;
            }

            if (cmbyblx.SelectedIndex == -1)
            {
                MessageBox.Show("没有选择医保类型！");
                return;
            }

            try
            {
                Cursor = PubStaticFun.WaitCursor();
                int _yblx = Convert.ToInt32(cmbyblx.SelectedValue);
                Yblx yblx = new Yblx(_yblx, InstanceForm.BDatabase);

                brxx = new ts_yb_mzgl.BRXX();
                jsxx = new ts_yb_mzgl.JSXX();

                brxx.BRXM = txtxm.Text;

                // if (yblx.isgh == false) return;

                ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yblx.ybjklx);
                ComboBox cmbtb = new ComboBox();
                bool bok = ybjk.GetPatientInfo("", yblx.yblx.ToString(), yblx.insureCentral, yblx.hospid, InstanceForm.BCurrentUser.EmployeeId.ToString(), "", "", ref brxx, cmbtb);

                if (brxx.KLX != 0 && brxx.KH != null && brxx.KH != "")
                {
                    cmbklx.SelectedValue = brxx.KLX;
                    txtkh.Text = brxx.KH;
                    txtkh_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
                    if (cmbxb.Text.Trim() != "" && brxx.XB.Trim() != cmbxb.Text.Trim())
                        MessageBox.Show("医保中的病人性别和HIS登记的病人性别不一致,请及时修改", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                brxx.BLH = lblmzh.Text.Trim();
                brxx.SFZH = "";

                lblybxm.Text = brxx.BRXM;
                txtxm.Text = brxx.BRXM;
                lblYbye.Text = brxx.KYE;//获取医保卡余额
                lblybrylx.Text = brxx.RYLB;
                lbljyh.Text = brxx.JSSJH;
                lblgzdw.Text = brxx.GZDW;


                yb_dylx = brxx.YWLX;
                yb_dylxmc = brxx.YWLXMC;
                yb_bzxx = "审批疾病:" + brxx.ICDMC;
                yb_bzxx = "    人员类别:" + brxx.RYLBMC;

                txtkh.Focus();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                butreadcard.Enabled = false;
                Cursor = Cursors.Default;
            }
            finally
            {
                butreadcard.Enabled = true;
                Cursor = Cursors.Default;
            }

        }

        private void butxtk_Click(object sender, EventArgs e)
        {
            try
            {
                //默认第一个医保类型
                if (Convert.ToInt32(cmbyblx.SelectedValue) <= 0)
                {
                    DataTable yblxTb = (DataTable)cmbyblx.DataSource;
                    DataRow[] yblxDr = yblxTb.Select("ID>0");

                    if (yblxDr.Length > 0)
                    {
                        cmbyblx.SelectedValue = Convert.ToInt32(Convertor.IsNull(yblxDr[0]["id"], "-1"));
                    }
                }

                Cursor = PubStaticFun.WaitCursor();
                int _yblx = Convert.ToInt32(cmbyblx.SelectedValue);
                Yblx yblx = new Yblx(_yblx, InstanceForm.BDatabase);

                ts_yb_mzgl.IMZYB ybjk = ts_yb_mzgl.ClassFactory.InewInterface(yblx.ybjklx);
                bool bok = ybjk.Xtk(yblx.yblx.ToString(), yblx.insureCentral, yblx.hospid);

                butreadcard.Focus();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void Frmghdj_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Modify by Tany 2009-01-04 关闭的时候释放医保资源
            DataTable yblxTb = (DataTable)cmbyblx.DataSource;
            DataRow[] yblxDr = yblxTb.Select("ID>0");

            for (int i = 0; i < yblxDr.Length; i++)
            {
                Yblx yblx = new Yblx(Convert.ToInt64(Convertor.IsNull(yblxDr[i]["id"], "-1")), InstanceForm.BDatabase);

                switch (yblx.ybjklx)
                {
                    case 1://长信
                        break;
                    case 2://桑达
                        string msg = "";
                        ushort iAuth = ts_yb_interface.SED_Interface.Sed_UnAuthHis(ref msg);
                        if (iAuth == 0)
                            MessageBox.Show("取消认证失败！" + msg);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Frmghdj_Activated(object sender, EventArgs e)
        {
            try
            {
                //ReadGhxx();
                //dataGridView1_DataBindingComplete( null , null );

                //获得可用发票号
                if (cfg1046.Config == "1")
                {
                    int err_code; string err_text;
                    DataTable tb = Fun.GetFph(InstanceForm.BCurrentUser.EmployeeId, 1, Fplx, out err_code, out err_text, InstanceForm.BDatabase);
                    if (tb.Rows.Count == 0 || err_code != 0)
                    {
                        MessageBox.Show(err_text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lblfph.Text = Convertor.IsNull(tb.Rows[0]["QZ"], "") + tb.Rows[0]["fph"].ToString().Trim();
                }

                if (txtkh.Enabled == true) { txtkh.Focus(); return; }
                if (txtxm.Enabled == true) { txtxm.Focus(); return; }
                if (txtks.Enabled == true) { txtks.Focus(); return; }
                if (txtys.Enabled == true) { txtys.Focus(); return; }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                if (Convertor.IsNull(dgv.Cells["取消日期"].Value, "") != "")
                    dgv.DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void Getghzs(Guid kdjid)
        {
            string bdate = DateTime.Now.ToShortDateString() + " 00:00:00";
            string edate = DateTime.Now.ToShortDateString() + " 23:59:59";
            DataTable tb = FrmMdiMain.Database.GetDataTable("select count(1) num from mz_ghxx where ghsj between '" + bdate + "' and '" + edate + "' and bqxghbz=0 and kdjid='" + kdjid + "'");

            if (tb.Rows.Count > 0)
            {
                lblghzs.Text = Convert.ToString(tb.Rows[0][0]);
            }
            else
            {
                lblghzs.Text = "0";
            }

            lblghzs.Visible = true;
            label11.Visible = true;
        }

        //添加优惠方案
        private void AddYhlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AddYhlx();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //添加优惠方案
        private void AddYhlx()
        {
            ReadCard readcard = new ReadCard(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtkh.Text.Trim(), InstanceForm.BDatabase);
            //添加优惠方案 增加科室参数，取优惠方案下拉列表　add by jiangzf
            FunAddComboBox.AddYhfa(readcard.klx, readcard.kdjid, Convert.ToInt32(Convertor.IsNull(cmbbrlx.SelectedValue, "0")), Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0")), Convert.ToInt32(Convertor.IsNull(cmbdwlx.SelectedValue, "0")), _menuTag.Function_Name, cmbyhlx, InstanceForm.BDatabase);
        }

        private void txthtdw_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "单位名称", "数字码", "拼音码", "五笔码" };
                string[] mappingname = new string[] { "dwmc", "szm", "pym", "wbm" };
                string[] searchfields = new string[] { "dwmc", "szm", "pym", "wbm" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = InstanceForm.BDatabase.GetDataTable(@"select * from jc_htdw WHERE ISNULL(BQYBZ,1)=1  ");
                f.WorkForm = this;
                f.srcControl = txthtdw;
                f.Font = txthtdw.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    txthtdw.Focus();
                }
                else
                {
                    txthtdw.Tag = Convert.ToInt32(f.SelectDataRow["id"]);
                    txthtdw.Text = f.SelectDataRow["dwmc"].ToString().Trim();
                    //this.SelectNextControl(control, true, false, true, true);
                    butsave.Focus();
                }
            }
            else
            {
                if (txthtdw.Text.Trim() == "") { txthtdw.Focus(); return; }
                butsave.Focus();
            }
            e.Handled = true;
        }

        private void txtjtdz_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblYbye_Click(object sender, EventArgs e)
        {

        }

        private void butreadcard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtkh.Enabled == true)
            {
                txtkh.Focus();
                return;
            }
            if (txtxm.Enabled == true)
            {
                txtxm.Focus();
                return;
            }

        }

        private void Frmghdj_KeyPress(object sender, KeyPressEventArgs e)
        {

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

        private void buthygl_Click(object sender, EventArgs e)
        {
            //报价器 姓名
            string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (bqybjq == "true")
            {
                string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.SetPicture(InstanceForm.BCurrentUser.EmployeeId.ToString());
            }
        }
        private void butzbsy_Click(object sender, EventArgs e)
        {
            //报价器 姓名
            string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (bqybjq == "true")
            {
                string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.Call(ts_call.DmType.欢迎, "抱歉,暂停工作");
            }
        }
        /// <summary>
        /// 显示新办未登记的卡信息
        /// </summary>
        /// <remarks>add by wangzhi 2010-10-27</remarks>
        private void ShowBrxx()
        {
            if (Modif_ini == "true")
            {
                txtxm.Enabled = false;
                cmbxb.Enabled = false;
                txtnl.Enabled = false;
                txtgrlxfs.Enabled = false;
                txtjtdz.Enabled = false;
            }
            else
            {
                txtxm.Enabled = true;
                cmbxb.Enabled = true;
                txtnl.Enabled = true;
                txtgrlxfs.Enabled = true;
                txtjtdz.Enabled = true;
            }


            Getghzs(_new_brxx_kxx.Kdjxx.Kdjid);




            if (xm_ini == "true")
                txtxm.Enabled = false;
            if (xb_ini == "true")
                cmbxb.Enabled = false;
            if (nl_ini == "true")
                txtnl.Enabled = false;
            if (lxfs_ini == "true")
                txtgrlxfs.Enabled = false;
            if (jtdz_ini == "true")
                txtjtdz.Enabled = false;

            lblkye.Text = "0.00";                                    // tbk.Rows[0]["kye"].ToString();
            txtkh.Text = _new_brxx_kxx.Kdjxx.Kh;
            txtxm.Text = _new_brxx_kxx.Brxx.Brxm;               //Convertor.IsNull( tbk.Rows[0]["brxm"] , "" );
            if (txtxm.Text.Trim() == "")
                txtxm.Text = _new_brxx_kxx.Kdjxx.Brxm;          //Convertor.IsNull( tbk.Rows[0]["CKRXM"] , "" );
            txtgrlxfs.Text = _new_brxx_kxx.Brxx.Brlxfs;         //Convertor.IsNull( tbk.Rows[0]["BRLXFS"] , "" );
            txtjtdz.Text = _new_brxx_kxx.Brxx.Jtdz;             //Convertor.IsNull( tbk.Rows[0]["JTDZ"] , "" );
            cmbxb.SelectedValue = _new_brxx_kxx.Brxx.Xb;                 //Convertor.IsNull( tbk.Rows[0]["性别"] , "" );
            lblgzdw.Text = _new_brxx_kxx.Brxx.Gzdw;             //Convertor.IsNull( tbk.Rows[0]["gzdw"] , "" );
            cmbbrlx.SelectedValue = _new_brxx_kxx.Brxx.Brlx;

            //添加优惠方案
            AddYhlx();

            if (_new_brxx_kxx.Brxx.Csrq != "")
            {
                txtnl.Text = DateManager.DateToAge(Convert.ToDateTime(_new_brxx_kxx.Brxx.Csrq), InstanceForm.BDatabase).AgeNum.ToString();
                dtpcsrq.Value = Convert.ToDateTime(_new_brxx_kxx.Brxx.Csrq);
                AutoSelectGhjb();
            }

            this.Tag = _new_brxx_kxx.Brxx.Brxxid.ToString();


            if (Convert.ToInt16(_new_brxx_kxx.Kdjxx.Zbbz) == 1)
            {
                txtks.Text = Fun.SeekDeptName(Convert.ToInt32(_new_brxx_kxx.Kdjxx.Zbks), InstanceForm.BDatabase);
                txtks.Tag = _new_brxx_kxx.Kdjxx.Zbks;
                cmbghjb.SelectedValue = _new_brxx_kxx.Kdjxx.Zbjb.ToString() == "0" ? "1" : _new_brxx_kxx.Kdjxx.Zbjb.ToString();
                txtys.Text = Fun.SeekEmpName(Convert.ToInt32(_new_brxx_kxx.Kdjxx.Zbys), InstanceForm.BDatabase);
                txtys.Tag = _new_brxx_kxx.Kdjxx.Zbys.ToString();

            }



            //报价器 姓名
            string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (bqybjq == "true")
            {
                string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.Call(ts_call.DmType.姓名, txtxm.Text.Trim());
            }
        }

        //预约取号
        private void butqh_Click(object sender, EventArgs e)
        {
            //如果有预约平台 
            if (new SystemCfg(3061).Config.Trim() == "1")
            {
                try
                {
                    DataRow row = null;
                    Frmyyjl f = new Frmyyjl("取预约号", "", txtkh.Text.Trim(), txtxm.Text.Trim());//全部传入空
                    f.ShowDialog();
                    if (f.Bok == false) { return; }
                    //Isyy = true; //记录是预约 Add by zp 2014-03-26
                    row = f.ReturnRow;
                    if (row == null) return;
                    string ssql = "select * from MZ_YYGHLB where yyid='" + Convertor.IsNull(row["yyid"], Guid.Empty.ToString()) + "'";
                    DataTable tbyy2 = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tbyy2.Rows.Count == 0) return;
                    ReadCard card = new ReadCard(Convert.ToInt32(cmbklx.SelectedValue), f.ReturnNewKH, InstanceForm.BDatabase);

                    if (card.kdjid == Guid.Empty)
                    {
                        #region 构造病人信息
                        _new_brxx_kxx = new MZ_BRXX_KXX();
                        YY_BRXX brxx = new YY_BRXX();
                        brxx.Brxxid = Guid.Empty;
                        brxx.Brxm = Convertor.IsNull(tbyy2.Rows[0]["brxm"], "");
                        brxx.Xb = Convertor.IsNull(tbyy2.Rows[0]["xb"], "");
                        brxx.Csrq = Convertor.IsNull(tbyy2.Rows[0]["csrq"], "");
                        brxx.Hyzk = "";
                        brxx.Gj = "";
                        brxx.Mz = "";
                        brxx.Zy = "";
                        brxx.Csdz = Convertor.IsNull(tbyy2.Rows[0]["jtdz"], ""); ;
                        brxx.Jtdz = Convertor.IsNull(tbyy2.Rows[0]["jtdz"], "");
                        brxx.Jtyb = "";
                        brxx.Jtdh = Convertor.IsNull(tbyy2.Rows[0]["lxdh"], ""); ;
                        brxx.Jtlxr = "";
                        brxx.Brlxfs = Convertor.IsNull(tbyy2.Rows[0]["lxdh"], ""); ;
                        brxx.Dzyj = "";
                        brxx.Gzdw = "";
                        brxx.Gzdwdz = "";
                        brxx.Gzdwyb = "";
                        brxx.Gzdwdh = "";
                        brxx.Gzdwlxr = "";
                        brxx.Sfzh = Convertor.IsNull(tbyy2.Rows[0]["sfzh"], "");
                        brxx.Brlx = 0;
                        brxx.Yblx = 0;
                        brxx.Cbkh = "";
                        brxx.Djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                        brxx.Djly = 0;
                        //构造卡登记信息
                        MZ_KDJXX kdjxx = new MZ_KDJXX();
                        kdjxx.Kdjid = Guid.Empty;
                        kdjxx.Brxxid = Guid.Empty;
                        kdjxx.Klx = Convert.ToInt32(cmbklx.SelectedValue);
                        kdjxx.Kh = f.ReturnNewKH;
                        kdjxx.Brxm = Convertor.IsNull(tbyy2.Rows[0]["brxm"], "");
                        kdjxx.Zbbz = 0;
                        kdjxx.Zbks = 0;
                        kdjxx.Zbjb = 0;
                        kdjxx.Zbys = 0;
                        kdjxx.Djsj = "";
                        kdjxx.Djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                        kdjxx.Kmm = "";

                        _new_brxx_kxx.Brxx = brxx;
                        _new_brxx_kxx.Kdjxx = kdjxx;
                        if (card.brxxid == Guid.Empty)
                            _isCreateNewCard = true;

                        ShowBrxx();
                        #endregion
                    }
                    if (f.ReturnNewKH != "")//modify by jiangzf 非无号预约，取预约信息中的卡号
                        txtkh.Text = f.ReturnNewKH;
                    KeyPressEventArgs key = new KeyPressEventArgs('\r');
                    txtkh_KeyPress(null, key);
                    txtks.Text = Fun.SeekDeptName(Convert.ToInt32(tbyy2.Rows[0]["ghks"]), InstanceForm.BDatabase);
                    txtks.Tag = Convertor.IsNull(row["ghks"], "");
                    txtys.Text = Fun.SeekEmpName(Convert.ToInt32(tbyy2.Rows[0]["ghys"]), InstanceForm.BDatabase);
                    txtys.Tag = Convertor.IsNull(row["ghys"], "");
                    cmbghjb.Text = Fun.SeekGhjbName(Convert.ToInt32(tbyy2.Rows[0]["ghjb"]), InstanceForm.BDatabase);
                    cmbghjb.SelectedValue = Convertor.IsNull(tbyy2.Rows[0]["ghjb"], "");
                    Isyy = true;
                    butqh.Tag = Convertor.IsNull(row["yyid"], "");
                    butqh.BackColor = Color.Red;
                    if (Convertor.IsNull(tbyy2.Rows[0]["brxm"], "") == "") txtxm.Focus(); else butsave.Focus();
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                //Add by Zj 2012-2-11 如果病人有卡,点击预约取号的时候 直接绑定病人信息 Begin
                int err_code = -1;
                string err_text = "";
                DataTable tbyy = mz_ghxx.YYQH("", txtkh.Text, "", "", "", out err_code, out err_text, TrasenFrame.Forms.FrmMdiMain.Database);
                if (tbyy.Rows.Count == 1) //拥有诊疗卡 同时只有一条记录 直接赋值
                {
                    Isyy = true; //记录是预约
                    txtks.Text = Fun.SeekDeptName(Convert.ToInt32(tbyy.Rows[0]["ghks"]), InstanceForm.BDatabase);
                    txtks.Tag = Convertor.IsNull(tbyy.Rows[0]["ghks"], "");
                    txtys.Text = Fun.SeekEmpName(Convert.ToInt32(tbyy.Rows[0]["ghys"]), InstanceForm.BDatabase);
                    txtys.Tag = Convertor.IsNull(tbyy.Rows[0]["ghys"], "");
                    cmbghjb.Text = Fun.SeekGhjbName(Convert.ToInt32(tbyy.Rows[0]["ghjb"]), InstanceForm.BDatabase);
                    cmbghjb.SelectedValue = Convertor.IsNull(tbyy.Rows[0]["ghjb"], "");
                    butqh.Tag = Convertor.IsNull(tbyy.Rows[0]["yyid"], Guid.Empty.ToString());//Add By Zj 2012-05-15 添加取号Tag值 防止未更新到MZ_YYGHLB
                    butqh.BackColor = Color.Red;
                }
                else
                {
                    try
                    {
                        DataRow row = null;
                        Frmyyjl f = new Frmyyjl("取预约号", Convertor.IsNull(cmbklx.SelectedValue, ""), txtkh.Text, txtxm.Text);
                        f.ShowDialog();
                        if (f.Bok == false) { return; }
                        row = f.ReturnRow;
                        if (row == null) return;
                        Isyy = true; //记录是预约 Add by zp 2014-03-26
                        string ssql = "select * from mz_yyghlb where yyid='" + Convertor.IsNull(row["yyid"], Guid.Empty.ToString()) + "'";
                        DataTable tbyy2 = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (tbyy2.Rows.Count == 0) return;

                        ReadCard card = new ReadCard(Convert.ToInt32(cmbklx.SelectedValue), f.ReturnNewKH, InstanceForm.BDatabase);


                        if (card.kdjid == Guid.Empty)
                        {
                            #region 构造病人信息
                            _new_brxx_kxx = new MZ_BRXX_KXX();
                            YY_BRXX brxx = new YY_BRXX();
                            brxx.Brxxid = Guid.Empty;
                            brxx.Brxm = Convertor.IsNull(tbyy2.Rows[0]["brxm"], "");
                            brxx.Xb = Convertor.IsNull(tbyy2.Rows[0]["xb"], "");
                            brxx.Csrq = Convertor.IsNull(tbyy2.Rows[0]["csrq"], "");
                            brxx.Hyzk = "";
                            brxx.Gj = "";
                            brxx.Mz = "";
                            brxx.Zy = "";
                            brxx.Csdz = Convertor.IsNull(tbyy2.Rows[0]["jtdz"], ""); ;
                            brxx.Jtdz = Convertor.IsNull(tbyy2.Rows[0]["jtdz"], "");
                            brxx.Jtyb = "";
                            brxx.Jtdh = Convertor.IsNull(tbyy2.Rows[0]["lxdh"], ""); ;
                            brxx.Jtlxr = "";
                            brxx.Brlxfs = Convertor.IsNull(tbyy2.Rows[0]["lxdh"], ""); ;
                            brxx.Dzyj = "";
                            brxx.Gzdw = "";
                            brxx.Gzdwdz = "";
                            brxx.Gzdwyb = "";
                            brxx.Gzdwdh = "";
                            brxx.Gzdwlxr = "";
                            brxx.Sfzh = Convertor.IsNull(tbyy2.Rows[0]["sfzh"], "");
                            brxx.Brlx = 0;
                            brxx.Yblx = 0;
                            brxx.Cbkh = "";
                            brxx.Djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                            brxx.Djly = 0;
                            //构造卡登记信息
                            MZ_KDJXX kdjxx = new MZ_KDJXX();
                            kdjxx.Kdjid = Guid.Empty;
                            kdjxx.Brxxid = Guid.Empty;
                            kdjxx.Klx = Convert.ToInt32(cmbklx.SelectedValue);
                            kdjxx.Kh = f.ReturnNewKH;
                            kdjxx.Brxm = Convertor.IsNull(tbyy2.Rows[0]["brxm"], "");
                            kdjxx.Zbbz = 0;
                            kdjxx.Zbks = 0;
                            kdjxx.Zbjb = 0;
                            kdjxx.Zbys = 0;
                            kdjxx.Djsj = "";
                            kdjxx.Djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                            kdjxx.Kmm = "";

                            _new_brxx_kxx.Brxx = brxx;
                            _new_brxx_kxx.Kdjxx = kdjxx;
                            if (card.brxxid == Guid.Empty)
                                _isCreateNewCard = true;
                            txtkh.Text = f.ReturnNewKH;
                            ShowBrxx();
                            #endregion
                        }
                        txtks.Text = Fun.SeekDeptName(Convert.ToInt32(tbyy2.Rows[0]["ghks"]), InstanceForm.BDatabase);
                        txtks.Tag = Convertor.IsNull(row["ghks"], "");
                        txtys.Text = Fun.SeekEmpName(Convert.ToInt32(tbyy2.Rows[0]["ghys"]), InstanceForm.BDatabase);
                        txtys.Tag = Convertor.IsNull(row["ghys"], "");
                        cmbghjb.Text = Fun.SeekGhjbName(Convert.ToInt32(tbyy2.Rows[0]["ghjb"]), InstanceForm.BDatabase);
                        cmbghjb.SelectedValue = Convertor.IsNull(tbyy2.Rows[0]["ghjb"], "");

                        butqh.Tag = Convertor.IsNull(row["yyid"], "");
                        butqh.BackColor = Color.Red;

                        if (Convertor.IsNull(tbyy2.Rows[0]["brxm"], "") == "") txtxm.Focus(); else butsave.Focus();

                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            //150310 chencan 预约取号不允许修改挂号科室及医生信息.
            txtks.Enabled = false;
            cmbghjb.Enabled = false;
            txtys.Enabled = false;
            treeView1.Enabled = false;
            panel8.Controls.Clear();
            //end 
        }

        //获取限号情况 Modify by zp 2013-12-04
        private void GetXh(bool bxs)
        {
            try
            {
                Guid _Yyid = new Guid(Convertor.IsNull(butqh.Tag, Guid.Empty.ToString()));
                int ghks = Convert.ToInt32(Convertor.IsNull(txtks.Tag, "0"));
                int ghjb = Convert.ToInt32(Convertor.IsNull(cmbghjb.SelectedValue, "0"));
                int ghys = Convert.ToInt32(Convertor.IsNull(txtys.Tag, "0"));
                if (ghks == 0) return;
                if (ghjb == 0) return;
                //如果启用分时段 同时该医生有分时段信息 则显示资源时段限号信息 Modify By zp 2013-12-04
                if (cfg1099.Config.Trim() == "1")
                {
                    DateTime date = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                    string ghrq = date.ToString("yyyy-MM-dd");
                    int sxwid = 1;

                    if (_Yyid != Guid.Empty)
                    {
                        int _err_code = 0;
                        string _err_text = "";
                        //DataTable dt = Mz_YYgh.GetYYghInfo( _Yyid.ToString() , "" , "" , "" , Mz_YYgh.YYgh_Status.未作废未取号记录 , "" , "" , 0 , out _err_code , out _err_text , InstanceForm.BDatabase );
                        DataTable dt = Mz_YYgh.GetYYghInfo(_Yyid.ToString(), "", "", "", Mz_YYgh.YYgh_Status.未作废未取号记录, "", "", 0, 0, 0, Mz_YYgh.YYgh_Sort.所有预约方式, out _err_code, out _err_text, InstanceForm.BDatabase);

                        ghrq = Convert.ToDateTime(dt.Rows[0]["预约日期"]).ToString("yyyy-MM-dd");
                        sxwid = Convert.ToInt32(dt.Rows[0]["预约区间段id"]);
                    }
                    else
                    {
                        if (date.Hour >= 12)
                            sxwid = 2;
                    }
                    VisitResource _vistRes = new VisitResource(ghks, ghjb, ghys, ghrq, InstanceForm.BDatabase);
                    if (_vistRes.Resid > 0)
                    {
                        string strTime = "";
                        if (sxwid == 1)
                            strTime = string.Format("(ghsj>='{0} 00:00:00' and ghsj<='{0} 12:00:00')", ghrq);
                        else
                            strTime = string.Format("(ghsj>='{0} 12:00:01' and ghsj<='{0} 23:59:59')", ghrq);
                        object objRS = InstanceForm.BDatabase.GetDataResult(string.Format("select count(1) from mz_ghxx where bqxghbz=0 and ghks={0} and ghys={1} and {2}",
                            ghks, ghys, strTime));
                        objRS = Convertor.IsNull(objRS, "0");

                        FsdClass _fsd = new FsdClass();
                        DataTable dt_fsd = _fsd.GetSdXhInfo(ghrq, _vistRes.Resid, 0, date.ToString("HH:mm"), sxwid, InstanceForm.BDatabase);
                        //lblxh.Text = "[挂:" + objRS.ToString() + "][限:" + dt_fsd.Rows[0]["总资源数"].ToString() + "][余:" + dt_fsd.Rows[0]["剩余数"].ToString() + "]";
                        if (dt_fsd.Rows.Count > 0)
                        {
                            switch (cfg1155.Config)
                            {
                                case "1":
                                    lblxh.Text = string.Format("[挂:{0}][限:{1}]", objRS, dt_fsd.Rows[0]["总资源数"]);
                                    break;
                                case "2":
                                    lblxh.Text = string.Format("[限:{0}][余:{1}]", dt_fsd.Rows[0]["总资源数"], dt_fsd.Rows[0]["剩余数"]);
                                    break;
                                case "3":
                                    lblxh.Text = string.Format("[挂:{0}][余:{1}]", objRS, dt_fsd.Rows[0]["剩余数"]);
                                    break;
                                case "0":
                                default:
                                    //lblxh.Text = string.Format( "[挂:{2}][限:{0}][余:{1}]" , objRS , dt_fsd.Rows[0]["总资源数"] , dt_fsd.Rows[0]["剩余数"] );
                                    lblxh.Text = string.Format("[挂:{0}][限:{1}][余:{2}]", objRS, dt_fsd.Rows[0]["总资源数"], dt_fsd.Rows[0]["剩余数"]);
                                    break;
                            }
                        }
                        return;
                    }
                }


                ParameterEx[] parameters = new ParameterEx[9];

                parameters[0].Text = "@YYID";
                parameters[0].Value = _Yyid;

                parameters[1].Text = "@GHKS";
                parameters[1].Value = ghks;

                parameters[2].Text = "@ghjb";
                parameters[2].Value = ghjb;

                parameters[3].Text = "@ghys";
                parameters[3].Value = ghys;

                parameters[4].Text = "@bxs";
                parameters[4].Value = bxs == true ? 1 : 0;

                parameters[5].Text = "@outbok";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].DataType = System.Data.DbType.Int16;


                parameters[6].Text = "@OUTBZ";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].DataType = System.Data.DbType.String;
                parameters[6].ParaSize = 100;

                parameters[7].Text = "@err_code";
                parameters[7].ParaDirection = ParameterDirection.Output;
                parameters[7].DataType = System.Data.DbType.Int32;
                parameters[7].ParaSize = 100;

                parameters[8].Text = "@err_text";
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].ParaSize = 100;


                InstanceForm.BDatabase.DoCommand("SP_MZSF_MZXH", parameters, 30);

                int outbok = Convert.ToInt16(parameters[5].Value);
                string outbz = Convert.ToString(parameters[6].Value);
                int err_code = Convert.ToInt32(parameters[7].Value);
                string err_text = Convert.ToString(parameters[8].Value);

                if (outbok == 1 && MessageBox.Show(outbz, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) throw new Exception("");
                if (bxs == true)
                {
                    lblxh.Text = outbz;
                    return;
                }
                if (err_code != 0 && outbok != 1) throw new Exception(outbz);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }



        private void cmbghjb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetXh(true);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void cmbklx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                mz_card card = new mz_card(klx, InstanceForm.BDatabase);
                //txtmzh.Enabled = true;
                buthelp.Enabled = true;
                if (card.binput == false)
                {

                    //txtmzh.Enabled = false;
                    buthelp.Enabled = false;

                }
                if (txtkh.Enabled == true) txtkh.Focus();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }

        //添加排班科室树形
        private void AddDeptTree()
        {
            //            string ssql = @"select id as id,0 as flid ,mc,bzk from jc_mz_yspb_ksfl
            //                        union all 
            //                        select ksid as id,flid,rtrim(name) as mc,0 bzk from jc_mz_yspb_ksflmx a,jc_dept_property b where a.ksid=b.dept_id and deleted=0";
            //            string sssql = @"select id,flid,mc,bzk from 
            //(select id as id,0 as flid ,mc,bzk from jc_mz_yspb_ksfl
            //union all 
            //select a.zjid_qc as id,flid,rtrim(ZJMC_QC) as mc,0 bzk 
            //from jc_mz_yspb_ksflmx  a, JC_ZJSZ_QC b 
            //where a.zjid_qc=b.zjid_qc and a.zjid_qc<>0 and b.deleted =0 ) a
            //order by  id,flid ";
            string ssql = @"select id as id,0 as flid ,mc,bzk,PXXH
from jc_mz_yspb_ksfl
union all 
select ksid as id,flid,rtrim(name) as mc,0 bzk,PXXH
from jc_mz_yspb_ksflmx a,jc_dept_property b 
where a.ksid=b.dept_id and deleted=0";
            string sssql = @"select id,flid,mc,bzk,PXXH from 
(select id as id,0 as flid ,mc,bzk,PXXH from jc_mz_yspb_ksfl
union all 
select a.zjid_qc as id,flid,rtrim(ZJMC_QC) as mc,0 bzk ,PXXH
from jc_mz_yspb_ksflmx  a, JC_ZJSZ_QC b 
where a.zjid_qc=b.zjid_qc and a.zjid_qc<>0 and b.deleted =0 ) a
order by  flid,PXXH ";

            DataTable tb = null;
            if (cfg3035.Config == "0")
                tb = InstanceForm.BDatabase.GetDataTable(ssql);
            else
                tb = InstanceForm.BDatabase.GetDataTable(sssql);

            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList2;

            DataRow[] rows_x = tb.Select(" flid=0", "PXXH asc");
            for (int x = 0; x <= rows_x.Length - 1; x++)
            {
                TreeNode node = treeView1.Nodes.Add(rows_x[x]["mc"].ToString().Trim());
                node.Tag = rows_x[x]["id"].ToString().Trim();
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                DataRow[] rows = tb.Select(" flid=" + rows_x[x]["id"].ToString().Trim() + "", "PXXH asc");
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    TreeNode Cnode = node.Nodes.Add(rows[i]["mc"].ToString());
                    Cnode.Tag = rows[i]["id"].ToString().Trim();
                    Cnode.ImageIndex = 2;
                    Cnode.SelectedImageIndex = 2;
                }
                if (rows_x[x]["bzk"].ToString() == "1")
                    node.Expand();
            }

        }
        //获取排班信息
        private void GetPbxx(string ksid, string ysid)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[2];

                parameters[0].Text = "@ksid";
                parameters[0].Value = ksid;

                parameters[1].Text = "@ysid";
                parameters[1].Value = ysid;

                DataSet dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_MZGH_GETPBXX", parameters, dset, "sfmx", 30);

                CreateTabPage(dset);


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }
        //创建tabpage
        private void CreateTabPage(DataSet dset)
        {
            string ghsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd");//Add By Zj 2013-03-19
            //this.tableLayoutPanel2.Controls.Add(this.label22, 0, 0);
            //tabControl2.TabPages.Clear();
            //for (int i = 0; i <= dset.Tables[1].Rows.Count - 1; i++)
            //{
            //    System.Windows.Forms.TabPage tabPage = new System.Windows.Forms.TabPage();
            //    System.Windows.Forms.ListView listView = new System.Windows.Forms.ListView();

            //    tabPage.Controls.Add(listView);
            //    tabPage.Location = new System.Drawing.Point(4, 21);
            //    tabPage.Name = "tabPage3";
            //    tabPage.Padding = new System.Windows.Forms.Padding(3);
            //    tabPage.Size = new System.Drawing.Size(813, 276);
            //    tabPage.TabIndex = 0;
            //    tabPage.Text = dset.Tables[1].Rows[i]["ghjbmc"].ToString();
            //    tabPage.UseVisualStyleBackColor = true;

            //    listView.Dock = System.Windows.Forms.DockStyle.Fill;
            //    listView.Location = new System.Drawing.Point(3, 3);
            //    listView.Name = "listView1";
            //    listView.Size = new System.Drawing.Size(807, 270);
            //    listView.TabIndex = 0;
            //    listView.UseCompatibleStateImageBehavior = false;
            //    this.tabControl2.Controls.Add(tabPage);
            //    listView.DoubleClick += new EventHandler(listView_DoubleClick);
            //}

            panel8.Controls.Clear();
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();

            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.506699F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.4933F));
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 0;
            //tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new System.Drawing.Size(821, 150);
            tableLayoutPanel2.TabIndex = 2;
            tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            tableLayoutPanel2.AutoScroll = true;
            tableLayoutPanel2.AutoSize = false;

            //tableLayoutPanel2.RowCount = dset.Tables[1].Rows.Count;
            for (int i = 0; i <= dset.Tables[1].Rows.Count - 1; i++)
            {
                DataRow[] rowsJB = dset.Tables[0].Select("ghjb='" + dset.Tables[1].Rows[i]["ghjb"].ToString() + "'");
                if (rowsJB.Length <= 7)
                    tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));//70
                else
                    tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));

                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label.AutoEllipsis = true;
                label.BorderStyle = System.Windows.Forms.BorderStyle.None;
                label.Dock = System.Windows.Forms.DockStyle.Fill;
                label.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                label.Location = new System.Drawing.Point(3, 0);
                label.Name = "label22";
                label.Size = new System.Drawing.Size(30, 150);
                label.TabIndex = 0;

                label.Text = dset.Tables[1].Rows[i]["ghjbmc"].ToString();
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                tableLayoutPanel2.Controls.Add(label, 0, i);

                System.Windows.Forms.ListView listView = new System.Windows.Forms.ListView();
                listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
                listView.Dock = System.Windows.Forms.DockStyle.Fill;
                listView.Location = new System.Drawing.Point(3, 3);
                listView.Name = "listView1";
                listView.Size = new System.Drawing.Size(807, 30);
                listView.TabIndex = 0;
                listView.UseCompatibleStateImageBehavior = false;
                tableLayoutPanel2.Controls.Add(listView, 1, i);
                listView.DoubleClick += new EventHandler(listView_DoubleClick);
                listView.Click += new EventHandler(listView_Click);
                listView.LargeImageList = this.imgBED;
                listView.View = System.Windows.Forms.View.LargeIcon;
                listView.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                //tableLayoutPanel2.RowStyles[0].Height = 300;

                DataRow[] rows = dset.Tables[0].Select("ghjb=" + dset.Tables[1].Rows[i]["ghjb"].ToString() + "", "px");
                for (int j = 0; j <= rows.Length - 1; j++)
                {
                    //Add by zp 2013-12-04 新增资源限号情况
                    string xhqk = "";
                    if (cfg1099.Config.Trim() == "1")
                    {
                        try
                        {
                            FsdClass _Fsd = new FsdClass();
                            int ksdm = Convert.ToInt32(rows[j]["ksdm"]);
                            int ysdm = Convert.ToInt32(rows[j]["ysdm"]);
                            int ghjb = Convert.ToInt32(rows[j]["ghjb"]);
                            DateTime date = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                            int sxwid = 1;
                            string ghrq = date.ToString("yyyy-MM-dd");
                            if (date.Hour >= 12)
                                sxwid = 2;
                            string time = date.ToString("HH:mm");
                            VisitResource _visres = new VisitResource(ksdm, ghjb, ysdm, ghrq, InstanceForm.BDatabase);
                            DataTable dtb = _Fsd.GetSdXhInfo(ghrq, _visres.Resid, 0, time, sxwid, InstanceForm.BDatabase);
                            //取当日挂号人数
                            string strTime = "";
                            if (sxwid == 1)
                                strTime = string.Format("(ghsj>='{0} 00:00:00' and ghsj<='{0} 12:00:00')", ghrq);
                            else
                                strTime = string.Format("(ghsj>='{0} 12:00:01' and ghsj<='{0} 23:59:59')", ghrq);
                            object objRS = InstanceForm.BDatabase.GetDataResult(string.Format("select count(1) from mz_ghxx where bqxghbz=0 and ghks={0} and ghys={1} and {2}",
                                ksdm, ysdm, strTime));
                            objRS = Convertor.IsNull(objRS, "0");

                            if (dtb != null && dtb.Rows.Count > 0)
                            {
                                switch (cfg1155.Config)
                                {
                                    case "1":
                                        xhqk = string.Format("\r\n[挂:{0}][限:{1}]", objRS, dtb.Rows[0]["总资源数"]);
                                        break;
                                    case "2":
                                        xhqk = string.Format("\r\n[限:{0}][余:{1}]", dtb.Rows[0]["总资源数"], dtb.Rows[0]["剩余数"]);
                                        break;
                                    case "3":
                                        xhqk = string.Format("\r\n[挂:{0}][余:{1}]", objRS, dtb.Rows[0]["剩余数"]);
                                        break;
                                    case "0":
                                    default:
                                        xhqk = string.Format("\r\n[挂:{0}][限:{1}][余:{2}]", objRS, dtb.Rows[0]["总资源数"], dtb.Rows[0]["剩余数"]);
                                        break;
                                }
                            }
                        }
                        catch
                        { }
                    }
                    string mc = rows[j]["ysmc"].ToString() + xhqk;
                    ListViewItem item = new ListViewItem(mc);//+ "\r" + rows[j]["ghjbmc"].ToString().Trim());
                    item.Tag = rows[j]["xh"].ToString();
                    if (rows[j]["sex"].ToString() == "男")
                        item.ImageIndex = 8;
                    if (rows[j]["sex"].ToString() == "女")
                        item.ImageIndex = 3;
                    if (rows[j]["sex"].ToString() == "")
                        item.ImageIndex = 71;

                    ////Add By Zj 2013-02-16    Modify by zj 2013-03-19 速度很慢 如果需要统计医生的挂号人次 最好在存储过程中一起统计出来。
                    //string ssql = "select COUNT(*) from MZ_GHXX where GHKS=" + dset.Tables[0].Rows[i]["ksdm"].ToString() + " and GHJB=" + dset.Tables[1].Rows[i]["ghjb"].ToString() + " and CONVERT(varchar(120),ghsj,23)='" + ghsj + "' ";
                    //if (rows[j]["ysdm"].ToString() != "0")
                    //    ssql += " and GHYS=" + rows[j]["ysdm"].ToString();
                    //if (rows[j]["ysdm"].ToString() == "0")
                    //    ssql += " and GHYS=0";
                    //item.Text = item.Text + "(" + InstanceForm.BDatabase.GetDataResult(ssql).ToString() + ")";
                    listView.Items.Add(item);
                }

            }
            panel8.Controls.Add(tableLayoutPanel2);
        }
        //医生点击事件
        void listView_Click(object sender, EventArgs e)
        {
            try
            {
                ListView tree = (ListView)sender;
                if (tree.SelectedItems[0] == null) return;
                string tag = tree.SelectedItems[0].Tag.ToString();
                string[] s = tag.Split(new char[1] { '|' });
                if (s.Length <= 1) return;
                string ksdm = s[0];
                string ysdm = s[1];
                string ghjb = s[2];
                string pplx = s[3];
                txtks.Tag = ksdm;
                txtks.Text = Fun.SeekDeptName(Convert.ToInt32(ksdm), InstanceForm.BDatabase);
                txtys.Tag = ysdm;
                txtys.Text = Fun.SeekEmpName(Convert.ToInt32(ysdm), InstanceForm.BDatabase);
                cmbghjb.SelectedValue = ghjb;

                GetXh(true);

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //医生双击事件
        void listView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListView tree = (ListView)sender;
                if (tree.SelectedItems[0] == null) return;
                string tag = tree.SelectedItems[0].Tag.ToString();
                string[] s = tag.Split(new char[1] { '|' });
                if (s.Length <= 1) return;
                string ksdm = s[0];
                string ysdm = s[1];
                string ghjb = s[2];
                string pplx = s[3];
                txtks.Tag = ksdm;
                txtks.Text = Fun.SeekDeptName(Convert.ToInt32(ksdm), InstanceForm.BDatabase);
                txtys.Tag = ysdm;
                txtys.Text = Fun.SeekEmpName(Convert.ToInt32(ysdm), InstanceForm.BDatabase);
                cmbghjb.SelectedValue = ghjb;
                butsave_Click(sender, e);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //科室选择事件
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                if (this.treeView1.SelectedNode == null)
                    return;
                if (this.treeView1.SelectedNode.ImageIndex == 2)
                    GetPbxx(this.treeView1.SelectedNode.Tag.ToString(), "0");
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        //通过医生个人排班确定科室和级别
        private void GetDoctorPbxx(string ysid)
        {
            try
            {
                if (cfgpb.Config == "0") return;
                ParameterEx[] parameters = new ParameterEx[2];

                parameters[0].Text = "@ksid";
                parameters[0].Value = "0";

                parameters[1].Text = "@ysid";
                parameters[1].Value = ysid;

                DataSet dset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_MZGH_GETPBXX", parameters, dset, "sfmx", 30);

                if (dset.Tables[0].Rows.Count > 0)
                {
                    string tag = Convertor.IsNull(dset.Tables[0].Rows[0]["xh"], "");
                    string[] s = tag.Split(new char[1] { '|' });
                    if (s.Length <= 1) return;
                    string ksdm = s[0];
                    string ysdm = s[1];
                    string ghjb = s[2];
                    string pplx = s[3];
                    if (txtks.Text.Trim() == "")//Add By Zj 2012-05-06 如果已经输入了科室 将不改变科室 修改原因是因为怀化三医院 输入科室再输入医生制空的话 会清空科室
                    {
                        txtks.Tag = ksdm;
                        txtks.Text = Fun.SeekDeptName(Convert.ToInt32(ksdm), InstanceForm.BDatabase);
                        cmbghjb.SelectedValue = ghjb;
                    }
                    txtys.Tag = ysdm;
                    txtys.Text = Fun.SeekEmpName(Convert.ToInt32(ysdm), InstanceForm.BDatabase);
                }
                else
                {
                    string ssql = @"select a.employee_id,d.type_id,a.dept_id,dbo.fun_getdeptname(a.dept_id) dept_name from JC_EMP_DEPT_ROLE a inner join jc_role_doctor b
                                        on a.employee_id=b.employee_id  inner join 
                                        JC_DEPT_TYPE_RELATION c on a.dept_id=c.dept_id and c.type_code='001'
                                        inner join jc_doctor_type d on  b.ys_typeid=d.zcjb where a.employee_id=" + ysid + "";

                    DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb.Rows.Count > 0)
                    {
                        if (txtks.Text.Trim() == "")
                        {
                            txtks.Text = tb.Rows[0]["dept_name"].ToString();
                            txtks.Tag = tb.Rows[0]["dept_id"].ToString();
                            cmbghjb.SelectedValue = tb.Rows[0]["type_id"].ToString();
                        }
                        else //如果科室不为空 只改变医生默认的级别 2012-04-09
                        {
                            cmbghjb.SelectedValue = tb.Rows[0]["type_id"].ToString();
                        }
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void dtpcsrq_ValueChanged(object sender, EventArgs e)
        {
            DateTime Nowtime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            TimeSpan timespan = Nowtime.Subtract(dtpcsrq.Value);
            Age age = DateManager.DateToAge(dtpcsrq.Value, InstanceForm.BDatabase);

            txtnl.Text = age.AgeNum.ToString();
            switch (age.Unit.ToString())
            {
                case "岁":
                    cmbDW.SelectedValue = 0;
                    break;
                case "月":
                    cmbDW.SelectedValue = 1;
                    break;
                case "天":
                    cmbDW.SelectedValue = 2;
                    break;
                case "小时":
                    cmbDW.SelectedValue = 3;
                    break;
                default:
                    cmbDW.SelectedValue = 4;
                    break;
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            #region 第一次使用报表处理
            try
            {
                #region 小票
                ParameterEx[] parameters = new ParameterEx[26];
                parameters[0].Text = "医院名称";
                parameters[0].Value = "";

                parameters[1].Text = "发票号";
                parameters[1].Value = "";

                DateTime time = System.DateTime.Now;

                parameters[2].Text = "年";
                parameters[2].Value = time.Year;

                parameters[3].Text = "月";
                parameters[3].Value = time.Month;

                parameters[4].Text = "日";
                parameters[4].Value = time.Day;

                parameters[5].Text = "挂号类型";
                parameters[5].Value = "";

                parameters[6].Text = "科室";
                parameters[6].Value = "";

                parameters[7].Text = "医生";
                parameters[7].Value = "";

                parameters[8].Text = "医生级别";
                parameters[8].Value = "";

                parameters[9].Text = "挂号序号";
                parameters[9].Value = "";

                PrintClass.InvoiceItem[] item = null;


                parameters[10].Text = "挂号费";
                parameters[10].Value = "";

                parameters[11].Text = "诊查费";
                parameters[11].Value = "";

                parameters[12].Text = "检查费";
                parameters[12].Value = "";

                parameters[13].Text = "材料费";
                parameters[13].Value = "";

                parameters[14].Text = "小写金额";
                parameters[14].Value = "";

                parameters[15].Text = "大写金额";
                parameters[15].Value = "";
                parameters[16].Text = "收款员";
                if (cfgsfy.Config == "1")
                    parameters[16].Value = "";
                else
                    parameters[16].Value = "";

                parameters[17].Text = "病人姓名";
                parameters[17].Value = txtxm.Text.Trim();

                parameters[18].Text = "门诊号";
                parameters[18].Value = lblmzh.Text.Trim();

                parameters[19].Text = "类型";
                parameters[19].Value = "";

                parameters[20].Text = "医保卡号";
                parameters[20].Value = "";

                parameters[21].Text = "医保支付";
                parameters[21].Value = "";

                parameters[22].Text = "医保卡支付";
                parameters[22].Value = "";

                parameters[23].Text = "现金支付";
                parameters[23].Value = "";

                parameters[24].Text = "医保余额";
                parameters[24].Value = "";
                parameters[25].Text = "卡号";
                parameters[25].Value = txtkh.Text;
                // TrasenFrame.Forms.FrmReportView fv;


                //fv = new FrmReportView(null, Constant.ApplicationDirectory + "\\Report\\GH_挂号小票.rpt", parameters, false);
                #endregion
                //fv.Show();
                // fv.Close();

                CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rd.Load(Constant.CustomDirectory + "\\Report\\GH_挂号小票.rpt");
                // rd.Load(Constant.ApplicationDirectory + "\\Report\\MZSF_小票(只打一张).rpt");
                // rd.SetDataSource(_dset);
                for (int i = 0; i < parameters.Length; i++)
                {
                    rd.SetParameterValue(parameters[i].Text, parameters[i].Value);
                }
                crystalReportViewer1.ReportSource = rd;
                crystalReportViewer1.Show();
                //Form f = new Form();
                //f.Controls.Add(crystalReportViewer1);
                //f.ShowDialog();
                crystalReportViewer1.Dispose();
            }
            catch (Exception ex) { }
            #endregion
        }
        //add by jiangzf 优惠方案跟科室关联
        private void txtks_Leave(object sender, EventArgs e)
        {
            AddYhlx();
        }

        private void btnReadIDCard_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "                                                                                                      ";
                string bqy = ApiFunction.GetIniString("身份证扫描器", "启用身份证扫描器", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqy == "true")
                {
                    string bsbxh = ApiFunction.GetIniString("身份证扫描器", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    string bshow = ApiFunction.GetIniString("身份证扫描器", "显示窗口信息", Constant.ApplicationDirectory + "//ClientWindow.ini");

                    ts_ReadCard.Icard card = ts_ReadCard.CardFactory.NewCard(bsbxh);
                    ts_ReadCard.IDCardData _IDCardData = new ts_ReadCard.IDCardData();

                    bool bok = card.ReadCard(ref _IDCardData, ref msg);
                    if (bok == false)
                        return;

                    txtxm.Text = _IDCardData.Name;
                    cmbxb.Text = _IDCardData.Sex;

                    dtpcsrq.Value = Convert.ToDateTime(_IDCardData.Born);
                    rdonl.Checked = true;

                    Age age = DateManager.DateToAge(dtpcsrq.Value, InstanceForm.BDatabase);
                    txtnl.Text = age.AgeNum.ToString();
                    cmbDW.SelectedIndex = (int)age.Unit;

                    txtjtdz.Text = _IDCardData.Address;

                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 刷新挂号记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadGhxx();
            dataGridView1_DataBindingComplete(null, null);
        }
        /// <summary>
        /// 新卡充值
        /// </summary>
        private void RechargeWithNewCard(int _klx, ref MZ_BRXX_KXX new_brxx_kxx)
        {
            SystemCfg cfg1154 = new SystemCfg(1154, InstanceForm.BDatabase);
            if (cfg1154.Config == "1")
            {
                ts_mz_class.Klx cardType = new Klx(_klx, InstanceForm.BDatabase);
                if (cardType.BJEBZ == (short)1)
                {
                    //新建卡时，如果卡允许存金
                    if (MessageBox.Show("是否现在预存金额？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string strDjsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");
                        int err_code = -1;
                        string err_text = "";
                        try
                        {
                            InstanceForm.BDatabase.BeginTransaction();
                            Guid _outNewBrxxId = Guid.Empty;
                            //首先保存病人信息
                            ts_mz_class.YY_BRXX.BrxxDj(Guid.Empty, new_brxx_kxx.Brxx.Brxm, new_brxx_kxx.Brxx.Xb, new_brxx_kxx.Brxx.Csrq, new_brxx_kxx.Brxx.Hyzk,
                                new_brxx_kxx.Brxx.Gj, new_brxx_kxx.Brxx.Mz, new_brxx_kxx.Brxx.Zy, new_brxx_kxx.Brxx.Csdz, new_brxx_kxx.Brxx.Jtdh, new_brxx_kxx.Brxx.Jtyb,
                                new_brxx_kxx.Brxx.Jtdh, new_brxx_kxx.Brxx.Jtlxr, new_brxx_kxx.Brxx.Brlxfs, new_brxx_kxx.Brxx.Dzyj, new_brxx_kxx.Brxx.Gzdw, new_brxx_kxx.Brxx.Gzdwdz,
                                new_brxx_kxx.Brxx.Gzdwyb, new_brxx_kxx.Brxx.Gzdwdh, new_brxx_kxx.Brxx.Gzdwlxr, new_brxx_kxx.Brxx.Sfzh, new_brxx_kxx.Brxx.Brlx, new_brxx_kxx.Brxx.Yblx,
                                new_brxx_kxx.Brxx.Cbkh, new_brxx_kxx.Brxx.Djy, new_brxx_kxx.Brxx.Djly, out _outNewBrxxId, out err_code, out err_text, InstanceForm.BDatabase);
                            if (_outNewBrxxId == Guid.Empty || err_code != 0)
                                throw new Exception(err_text);

                            //保存卡信息
                            Guid _outNewKdjid = Guid.Empty;
                            ts_mz_class.mz_kdj.Kdj(Guid.Empty, _outNewBrxxId, _klx, txtkh.Text, new_brxx_kxx.Brxx.Brxm, 0, 0, 0, 0, strDjsj, new_brxx_kxx.Brxx.Djy, "", "",
                                "", out _outNewKdjid, out err_code, out err_text, "", "", InstanceForm.BDatabase);
                            if (_outNewKdjid == Guid.Empty || err_code != 0)
                                throw new Exception(err_text);
                            InstanceForm.BDatabase.CommitTransaction();
                            new_brxx_kxx.Brxx.Brxxid = _outNewBrxxId;
                        }
                        catch (Exception error)
                        {
                            InstanceForm.BDatabase.RollbackTransaction();
                            throw error;
                        }
                        //弹出预交金界面
                        ts_mz_kgl.Frmbrkcz frmkcz = new ts_mz_kgl.Frmbrkcz(InstanceForm.BDatabase, InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, _klx, txtkh.Text);
                        frmkcz.AfterRechargeSuccess += delegate()
                        {
                            frmkcz.Close();
                        };
                        //将充值界面的卡号设置为只读
                        ((System.Windows.Forms.TextBox)frmkcz.GetType().GetField("txtkh", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(frmkcz)).ReadOnly = true;
                        frmkcz.Size = new Size(852, 385);
                        frmkcz.StartPosition = FormStartPosition.CenterScreen;
                        frmkcz.ShowDialog();
                        txtkh.Focus();
                        txtkh_KeyPress(txtkh, new KeyPressEventArgs('\r'));
                        _isCreateNewCard = true;
                        _needChargeCardFee = true;
                    }
                }
            }
        }
    }
}
