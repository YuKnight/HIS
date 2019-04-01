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
using TrasenFrame.Forms;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using System.Text;
using ts_Pos;

namespace ts_mz_kgl
{
    public partial class Frmbrkdj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Guid brxxid = Guid.Empty;
        public Guid kdjid = Guid.Empty;
        public RelationalDatabase _DataBase;

        private bool _Modify = false;

        private string strCsrq = string.Empty;

        public SystemCfg cfg3033 = new SystemCfg(3033);//Add By Zj 2012-03-28 必填项控制
        public SystemCfg cfg3034 = new SystemCfg(3034);//Add By Zj 2012-03-28 身份证唯一
        public SystemCfg cfg1060 = new SystemCfg(1060);//Add By Zj 2012-05-10 是否验证卡号数字正确性
        public SystemCfg cfg3084 = new SystemCfg(3084); //Add By zp 2014-01-09 如果患者年龄小于指定岁数需要指定家长名称,如果参数值为-1则不需要验证 默认-1
        public SystemCfg cfg1107 = new SystemCfg(1107); //Add By zp 2014-02-08 办理诊疗卡是否限制只允许输入数字 0不限制 1限制 如果1060为1则该参数则在程序里不起判断
        public SystemCfg cfg1110 = new SystemCfg(1110);
        public SystemCfg cfg1158 = new SystemCfg(1158);//Add By chencan 150107 设置病人卡管理权限的用户组编码
        /// <summary>
        /// 诊疗卡登记时启用系统自动产生诊疗编码（0不启用，1启用）默认0，影响重大，请慎重设置！
        /// </summary>
        public SystemCfg cfg1161 = new SystemCfg(1161);//Add By chencan 150108 启用卡单据使用。
        public SystemCfg cfg1183 = new SystemCfg(1183);//add by chencan 150716 设置能否修改住院病人的基本信息

        bool isFirstEnter = true;
        private string tempKdjid = string.Empty;
        public YY_BRXX_BC_MOL yy_brxx_bc = new YY_BRXX_BC_MOL();
        /// <summary>
        /// 延迟保存
        /// </summary>
        private bool delaySave = false;
        /// <summary>
        /// 延迟保存，如果设置为TRUE，点击保存按钮后只返回登记信息，不进行数据操作
        /// </summary>
        public bool DelaySave
        {
            get
            {
                return delaySave;
            }
            set
            {
                delaySave = value;
            }
        }
        private MZ_BRXX_KXX brdjxx;
        /// <summary>
        /// 新卡的病人登记信息
        /// </summary>
        public MZ_BRXX_KXX Brdjxx
        {
            get
            {
                return brdjxx;
            }
        }
        private bool _bk = false;
        public bool p_bk
        {
            set { _bk = value; }
        }
        /// <summary>
        /// 当前启用的pos接口 
        /// </summary>
        private PosInfo _Posjk = new PosInfo();

        public Frmbrkdj(MenuTag menuTag, string chineseName, Form mdiParent, Guid _brxxid, Guid _kdjid)
        {
            InitializeComponent();

            _Modify = true;

            if (InstanceForm.BDatabase == null)
                InstanceForm.BDatabase = TrasenFrame.Forms.FrmMdiMain.Database;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            //add by zouchihua 2013-5-29  行政区划（家庭所在地区、出生地、户口所在地）
            tbdz = FrmMdiMain.Database.GetDataTable("SELECT CODE AS ITEMCODE,NAME AS ITEMNAME,PY_CODE, WB_CODE,' ' AS D_CODE FROM JC_DISTRICT ORDER BY ORDERS");
            txtcsdz.DisplayMember = "ITEMNAME";
            txtcsdz.ValueMember = "ITEMCODE";
            txtcsdz.DataSource = tbdz;
            txtcsdz.SelectedIndex = -1;

            txtjtdz.DisplayMember = "ITEMNAME";
            txtjtdz.ValueMember = "ITEMCODE";
            txtjtdz.DataSource = tbdz;
            txtjtdz.SelectedIndex = -1;

            FunAddComboBox.AddBrlx(false, 0, cmbbrlx, InstanceForm.BDatabase);
            FunAddComboBox.AddKlx(false, 0, 0, cmbklx, InstanceForm.BDatabase);
            FunAddComboBox.AddYblx(false, 0, cmbyblx, InstanceForm.BDatabase);
            FunAddComboBox.Addxb(false, cmbxb, InstanceForm.BDatabase);
            FunAddComboBox.AddGj(false, cmbgj, InstanceForm.BDatabase);
            FunAddComboBox.AddMz(false, cmbmz, InstanceForm.BDatabase);
            FunAddComboBox.AddHk(false, cmbhk, InstanceForm.BDatabase);
            FunAddComboBox.AddDic("DD_病人登记来源", false, true, true, "", cmb_brly, InstanceForm.BDatabase);

            //关系字典
            tbbrgx = FrmMdiMain.Database.GetDataTable("SELECT CODE AS ID,NAME,PY_CODE FROM JC_RELATIVE");
            if (tbbrgx == null)
            {
                MessageBox.Show("错误，未能取关系信息！", "提示");
            }
            txtlxrybrgx.DisplayMember = "NAME";
            txtlxrybrgx.ValueMember = "ID";
            txtlxrybrgx.DataSource = tbbrgx;

            //年龄单位
            DataTable tb = new DataTable();
            tb.Columns.Add("ID", Type.GetType("System.Int32"));
            tb.Columns.Add("NAME", Type.GetType("System.String"));
            DataRow row = tb.NewRow();
            row["ID"] = 0;
            row["NAME"] = "岁";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 1;
            row["NAME"] = "月";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 2;
            row["NAME"] = "天";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 3;
            row["NAME"] = "小时";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 4;
            row["NAME"] = "分钟";
            tb.Rows.Add(row);
            cmbDW.DisplayMember = "NAME";
            cmbDW.ValueMember = "ID";
            cmbDW.DataSource = tb;
            cmbDW.SelectedIndex = 0;

            cmbyblx.SelectedIndex = -1;
            cmbhk.SelectedIndex = -1;//默认为-1
            cmbgj.SelectedIndex = 0;
            cmbmz.SelectedIndex = 0;

            ReadCard readcard = new ReadCard(_kdjid, InstanceForm.BDatabase);
            if (readcard.kdjid != Guid.Empty)
            {
                kdjid = readcard.kdjid;
                brxxid = readcard.brxxid;
                txtkh.Text = readcard.kh;
                cmbklx.SelectedValue = readcard.klx;
            }
            else
            {
                kdjid = Guid.Empty;
                brxxid = _brxxid;
            }

            FillBrxx(brxxid);
        }
        public Frmbrkdj(MenuTag menuTag, string chineseName, Form mdiParent, Guid _brxxid, Guid _kdjid, RelationalDatabase DataBase)
        {
            try
            {
                InitializeComponent();
            }
            catch { }

            InstanceForm.BDatabase = DataBase;
            _DataBase = DataBase;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            //add by zouchihua 2013-5-29  行政区划（家庭所在地区、出生地、户口所在地）
            tbdz = FrmMdiMain.Database.GetDataTable("SELECT CODE AS ITEMCODE,NAME AS ITEMNAME,PY_CODE, WB_CODE,' ' AS D_CODE FROM JC_DISTRICT ORDER BY ORDERS");
            txtcsdz.DisplayMember = "ITEMNAME";
            txtcsdz.ValueMember = "ITEMCODE";
            txtcsdz.DataSource = tbdz;
            txtcsdz.SelectedIndex = -1;

            txtjtdz.DisplayMember = "ITEMNAME";
            txtjtdz.ValueMember = "ITEMCODE";
            txtjtdz.DataSource = tbdz;
            txtjtdz.SelectedIndex = -1;
            this.Text = _chineseName;


            //关系字典
            tbbrgx = FrmMdiMain.Database.GetDataTable("SELECT CODE AS ID,NAME,PY_CODE FROM JC_RELATIVE");
            if (tbbrgx == null)
            {
                MessageBox.Show("错误，未能取关系信息！", "提示");
            }
            txtlxrybrgx.DisplayMember = "NAME";
            txtlxrybrgx.ValueMember = "ID";
            txtlxrybrgx.DataSource = tbbrgx;

            FunAddComboBox.AddBrlx(false, 0, cmbbrlx, InstanceForm.BDatabase);
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase); ;
            FunAddComboBox.AddYblx(false, 0, cmbyblx, InstanceForm.BDatabase);
            FunAddComboBox.Addxb(false, cmbxb, InstanceForm.BDatabase);
            FunAddComboBox.AddGj(false, cmbgj, InstanceForm.BDatabase);
            FunAddComboBox.AddMz(false, cmbmz, InstanceForm.BDatabase);
            FunAddComboBox.AddHk(false, cmbhk, InstanceForm.BDatabase);
            FunAddComboBox.AddDic("DD_病人登记来源", false, true, true, "", cmb_brly, InstanceForm.BDatabase);

            //年龄单位
            DataTable tb = new DataTable();
            tb.Columns.Add("ID", Type.GetType("System.Int32"));
            tb.Columns.Add("NAME", Type.GetType("System.String"));
            DataRow row = tb.NewRow();
            row["ID"] = 0;
            row["NAME"] = "岁";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 1;
            row["NAME"] = "月";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 2;
            row["NAME"] = "天";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 3;
            row["NAME"] = "小时";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 4;
            row["NAME"] = "分钟";
            tb.Rows.Add(row);
            cmbDW.DisplayMember = "NAME";
            cmbDW.ValueMember = "ID";
            cmbDW.DataSource = tb;
            cmbDW.SelectedIndex = 0;


            cmbyblx.SelectedIndex = -1;
            cmbhk.SelectedIndex = -1;
            cmbgj.SelectedIndex = 0;
            cmbmz.SelectedIndex = 0;

            ReadCard readcard = new ReadCard(_kdjid, InstanceForm.BDatabase);
            if (readcard.kdjid != Guid.Empty)
            {
                kdjid = readcard.kdjid;
                brxxid = readcard.brxxid;
                txtkh.Text = readcard.kh;
                cmbklx.SelectedValue = readcard.klx;
            }
            else
            {
                kdjid = Guid.Empty;
                brxxid = _brxxid;
            }

            FillBrxx(brxxid);
        }
        public Frmbrkdj(object 姓名, object 性别, object 家庭地址, object 联系方式, object 出生日期, object 年龄)
        {
            InitializeComponent();

            if (InstanceForm.BDatabase == null)
                InstanceForm.BDatabase = TrasenFrame.Forms.FrmMdiMain.Database;
            //_menuTag = menuTag;
            //_chineseName = chineseName;
            //_mdiParent = mdiParent;

            this.Text = _chineseName;
            //add by zouchihua 2013-5-29  行政区划（家庭所在地区、出生地、户口所在地）
            tbdz = FrmMdiMain.Database.GetDataTable("SELECT CODE AS ITEMCODE,NAME AS ITEMNAME,PY_CODE, WB_CODE,' ' AS D_CODE FROM JC_DISTRICT ORDER BY ORDERS");
            txtcsdz.DisplayMember = "ITEMNAME";
            txtcsdz.ValueMember = "ITEMCODE";
            txtcsdz.DataSource = tbdz;
            txtcsdz.SelectedIndex = -1;

            txtjtdz.DisplayMember = "ITEMNAME";
            txtjtdz.ValueMember = "ITEMCODE";
            txtjtdz.DataSource = tbdz;
            txtjtdz.SelectedIndex = -1;

            FunAddComboBox.AddBrlx(false, 0, cmbbrlx, InstanceForm.BDatabase);
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase); ;
            FunAddComboBox.AddYblx(false, 0, cmbyblx, InstanceForm.BDatabase);
            FunAddComboBox.Addxb(false, cmbxb, InstanceForm.BDatabase);
            FunAddComboBox.AddGj(false, cmbgj, InstanceForm.BDatabase);
            FunAddComboBox.AddMz(false, cmbmz, InstanceForm.BDatabase);
            FunAddComboBox.AddHk(false, cmbhk, InstanceForm.BDatabase);
            FunAddComboBox.AddDic("DD_病人登记来源", false, true, true, "", cmb_brly, InstanceForm.BDatabase);

            //关系字典
            tbbrgx = FrmMdiMain.Database.GetDataTable("SELECT CODE AS ID,NAME,PY_CODE FROM JC_RELATIVE");
            if (tbbrgx == null)
            {
                MessageBox.Show("错误，未能取关系信息！", "提示");
            }
            txtlxrybrgx.DisplayMember = "NAME";
            txtlxrybrgx.ValueMember = "ID";
            txtlxrybrgx.DataSource = tbbrgx;

            //年龄单位
            DataTable tb = new DataTable();
            tb.Columns.Add("ID", Type.GetType("System.Int32"));
            tb.Columns.Add("NAME", Type.GetType("System.String"));
            DataRow row = tb.NewRow();
            row["ID"] = 0;
            row["NAME"] = "岁";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 1;
            row["NAME"] = "月";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 2;
            row["NAME"] = "天";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 3;
            row["NAME"] = "小时";
            tb.Rows.Add(row);
            row = tb.NewRow();
            row["ID"] = 4;
            row["NAME"] = "分钟";
            tb.Rows.Add(row);
            cmbDW.DisplayMember = "NAME";
            cmbDW.ValueMember = "ID";
            cmbDW.DataSource = tb;
            cmbDW.SelectedIndex = 0;

            cmbyblx.SelectedIndex = -1;
            cmbhk.SelectedIndex = -1;//默认为-1
            cmbgj.SelectedIndex = 0;
            cmbmz.SelectedIndex = 0;

            ReadCard readcard = new ReadCard(Guid.Empty, InstanceForm.BDatabase);
            if (readcard.kdjid != Guid.Empty)
            {
                kdjid = readcard.kdjid;
                brxxid = readcard.brxxid;
                txtkh.Text = readcard.kh;
                cmbklx.SelectedValue = readcard.klx;
            }
            else
            {
                kdjid = Guid.Empty;
                brxxid = Guid.Empty;
            }
            FillBrxx(brxxid);
            txtbrxm.Text = 姓名.ToString();
            cmbxb.Text = 性别.ToString();
            if (出生日期.ToString() != "")
                dtpcsrq.Value = Convert.ToDateTime(出生日期.ToString());
            txtjtdh.Text = 联系方式.ToString();
            if (年龄.ToString() != "")
                this.txtnl.Text = 年龄.ToString().Substring(0, 年龄.ToString().Length - 1);
            //txtjtdz.Text = 家庭地址.ToString(); 
            txtkh.KeyPress -= new KeyPressEventHandler(txtkh_KeyPress);
            txtkh.KeyPress += new KeyPressEventHandler(txtkh_KeyPress1);
        }
        DataTable tbdz = null;
        DataTable tbbrgx = null;
        private void Frmbrkdj_Load(object sender, EventArgs e)
        {

            if (_menuTag.Function_Name != "hs" && _menuTag.Function_Name != "ys")
            {
                string brlx = ApiFunction.GetIniString("卡信息登记屏蔽项", "病人类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
                cmbbrlx.Enabled = brlx == "true" ? true : false;

                string klx = ApiFunction.GetIniString("卡信息登记屏蔽项", "卡类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string kh = ApiFunction.GetIniString("卡信息登记屏蔽项", "卡号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                cmbklx.Enabled = klx == "true" ? true : false;
                txtkh.Enabled = kh == "true" ? true : false;

                string brxm = ApiFunction.GetIniString("卡信息登记屏蔽项", "姓名", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string xb = ApiFunction.GetIniString("卡信息登记屏蔽项", "性别", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string nl = ApiFunction.GetIniString("卡信息登记屏蔽项", "年龄", Constant.ApplicationDirectory + "//ClientWindow.ini");

                txtbrxm.Enabled = brxm == "true" ? true : false;
                cmbxb.Enabled = xb == "true" ? true : false;

                //武汉可以修改年龄和出生日期
                txtnl.Enabled = nl == "true" ? true : false;
                rdonl.Enabled = nl == "true" ? true : false;//Add By Zj 2013-03-11
                rdocsrq.Enabled = nl == "true" ? true : false;//Add By Zj 2013-03-11
                cmbDW.Enabled = nl == "true" ? true : false;//Add By Zj 2013-03-11

                string hk = ApiFunction.GetIniString("卡信息登记屏蔽项", "婚况", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string gj = ApiFunction.GetIniString("卡信息登记屏蔽项", "国籍", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string mz = ApiFunction.GetIniString("卡信息登记屏蔽项", "民族", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string zy = ApiFunction.GetIniString("卡信息登记屏蔽项", "职业", Constant.ApplicationDirectory + "//ClientWindow.ini");
                cmbhk.Enabled = hk == "true" ? true : false;
                cmbgj.Enabled = gj == "true" ? true : false;
                cmbmz.Enabled = mz == "true" ? true : false;
                txtzy.Enabled = zy == "true" ? true : false;
                txtzydm.Enabled = zy == "true" ? true : false;

                string brlxfs = ApiFunction.GetIniString("卡信息登记屏蔽项", "本人联系方式", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string dzyj = ApiFunction.GetIniString("卡信息登记屏蔽项", "电子邮件", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string yblx = ApiFunction.GetIniString("卡信息登记屏蔽项", "医保类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string cbkh = ApiFunction.GetIniString("卡信息登记屏蔽项", "参保卡号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string sfzh = ApiFunction.GetIniString("卡信息登记屏蔽项", "身份证号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                txtjtdh.Enabled = brlxfs == "true" ? true : false;
                txtdzyj.Enabled = dzyj == "true" ? true : false;
                cmbyblx.Enabled = yblx == "true" ? true : false;
                txtcbkh.Enabled = cbkh == "true" ? true : false;
                txtsfzh.Enabled = sfzh == "true" ? true : false;

                string csdz = ApiFunction.GetIniString("卡信息登记屏蔽项", "出生地址", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string jtdz = ApiFunction.GetIniString("卡信息登记屏蔽项", "家庭住址", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string jtdh = ApiFunction.GetIniString("卡信息登记屏蔽项", "家庭电话", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string jtyb = ApiFunction.GetIniString("卡信息登记屏蔽项", "家庭邮编", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string jtlxr = ApiFunction.GetIniString("卡信息登记屏蔽项", "家庭联系人", Constant.ApplicationDirectory + "//ClientWindow.ini");
                txtcsdz.Enabled = csdz == "true" ? true : false;
                txtjtdz.Enabled = jtdz == "true" ? true : false;
                txtbrlxfs.Enabled = jtdh == "true" ? true : false;
                txtjtyb.Enabled = jtyb == "true" ? true : false;
                txtjtlxr.Enabled = jtlxr == "true" ? true : false;


                string gzdw = ApiFunction.GetIniString("卡信息登记屏蔽项", "工作单位", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string dwdh = ApiFunction.GetIniString("卡信息登记屏蔽项", "单位电话", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string dwyb = ApiFunction.GetIniString("卡信息登记屏蔽项", "单位邮编", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string dwlxr = ApiFunction.GetIniString("卡信息登记屏蔽项", "单位联系人", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string dwdz = ApiFunction.GetIniString("卡信息登记屏蔽项", "单位地址", Constant.ApplicationDirectory + "//ClientWindow.ini");
                txtgzdw.Enabled = gzdw == "true" ? true : false;
                txtdwdh.Enabled = dwdh == "true" ? true : false;
                txtdwyb.Enabled = dwyb == "true" ? true : false;
                txtdwlxr.Enabled = dwlxr == "true" ? true : false;
                txtdwdz.Enabled = dwdz == "true" ? true : false;

                string qtzj = ApiFunction.GetIniString("卡信息登记屏蔽项", "其他证件", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string zjhm = ApiFunction.GetIniString("卡信息登记屏蔽项", "证件号码", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string jkdabh = ApiFunction.GetIniString("卡信息登记屏蔽项", "健康档案编号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string whcd = ApiFunction.GetIniString("卡信息登记屏蔽项", "文化程度", Constant.ApplicationDirectory + "//ClientWindow.ini");

                txtqtzjlx.Enabled = qtzj == "true" ? true : false;
                txtqtzjhm.Enabled = zjhm == "true" ? true : false;
                txtjkdabh.Enabled = jkdabh == "true" ? true : false;
                txtwhcd.Enabled = whcd == "true" ? true : false;

                string lxrxm = ApiFunction.GetIniString("卡信息登记屏蔽项", "联系人姓名", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string ybrdgx = ApiFunction.GetIniString("卡信息登记屏蔽项", "与病人的关系", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string lxrdh = ApiFunction.GetIniString("卡信息登记屏蔽项", "联系人电话", Constant.ApplicationDirectory + "//ClientWindow.ini");

                txtlxrxm.Enabled = (string.IsNullOrEmpty(lxrxm) ? true : (lxrxm == "true" ? true : false));
                txtlxrybrgx.Enabled = (string.IsNullOrEmpty(ybrdgx) ? true : (ybrdgx == "true" ? true : false));
                txtlxrdh.Enabled = (string.IsNullOrEmpty(lxrdh) ? true : (lxrdh == "true" ? true : false));
            }
            if (_menuTag.Function_Name == "hs")
            {
                string brlx = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "病人类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
                cmbbrlx.Enabled = brlx == "true" ? true : false;

                string klx = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "卡类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string kh = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "卡号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                cmbklx.Enabled = klx == "true" ? true : false;
                txtkh.Enabled = kh == "true" ? true : false;

                string brxm = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "姓名", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string xb = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "性别", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string nl = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "年龄", Constant.ApplicationDirectory + "//ClientWindow.ini");
                txtbrxm.Enabled = brxm == "true" ? true : false;
                cmbxb.Enabled = xb == "true" ? true : false;
                txtnl.Enabled = nl == "true" ? true : false;

                string hk = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "婚况", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string gj = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "国籍", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string mz = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "民族", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string zy = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "职业", Constant.ApplicationDirectory + "//ClientWindow.ini");
                cmbhk.Enabled = hk == "true" ? true : false;
                cmbgj.Enabled = gj == "true" ? true : false;
                cmbxb.Enabled = mz == "true" ? true : false;
                txtzy.Enabled = zy == "true" ? true : false;

                txtzydm.Enabled = zy == "true" ? true : false;//Add By Zj 2013-03-11

                string brlxfs = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "本人联系方式", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string dzyj = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "电子邮件", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string yblx = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "医保类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string cbkh = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "参保卡号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string sfzh = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "身份证号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                txtjtdh.Enabled = brlxfs == "true" ? true : false;
                txtdzyj.Enabled = dzyj == "true" ? true : false;
                cmbyblx.Enabled = yblx == "true" ? true : false;
                txtcbkh.Enabled = cbkh == "true" ? true : false;
                txtsfzh.Enabled = sfzh == "true" ? true : false;

                string csdz = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "出生地址", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string jtdz = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "家庭住址", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string jtdh = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "家庭电话", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string jtyb = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "家庭邮编", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string jtlxr = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "家庭联系人", Constant.ApplicationDirectory + "//ClientWindow.ini");
                txtcsdz.Enabled = csdz == "true" ? true : false;
                txtjtdz.Enabled = jtdz == "true" ? true : false;
                txtbrlxfs.Enabled = jtdh == "true" ? true : false;
                txtjtyb.Enabled = jtyb == "true" ? true : false;
                txtjtlxr.Enabled = jtlxr == "true" ? true : false;


                string gzdw = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "工作单位", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string dwdh = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "单位电话", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string dwyb = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "单位邮编", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string dwlxr = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "单位联系人", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string dwdz = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "单位地址", Constant.ApplicationDirectory + "//ClientWindow.ini");//Add By Zj 2013-03-11

                txtgzdw.Enabled = gzdw == "true" ? true : false;
                txtdwdh.Enabled = dwdh == "true" ? true : false;
                txtdwyb.Enabled = dwyb == "true" ? true : false;
                txtdwlxr.Enabled = dwlxr == "true" ? true : false;
                txtdwdz.Enabled = dwdz == "true" ? true : false;//Add By Zj 2013-03-11

                string lxrxm = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "联系人姓名", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string ybrdgx = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "与病人的关系", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string lxrdh = ApiFunction.GetIniString("卡信息登记屏蔽项_护士站", "联系人电话", Constant.ApplicationDirectory + "//ClientWindow.ini");

                txtlxrxm.Enabled = (string.IsNullOrEmpty(lxrxm) ? true : (lxrxm == "true" ? true : false));
                txtlxrybrgx.Enabled = (string.IsNullOrEmpty(ybrdgx) ? true : (ybrdgx == "true" ? true : false));
                txtlxrdh.Enabled = (string.IsNullOrEmpty(lxrdh) ? true : (lxrdh == "true" ? true : false));
            }

            if (_menuTag.Function_Name == "ys")
            {
                txtbrxm.Focus();
                cmbklx.Enabled = txtkh.Enabled = cmbbrlx.Enabled = false;
                //string brlx = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "病人类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
                //cmbbrlx.Enabled = brlx == "true" ? true : false;

                //string klx = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "卡类型", Constant.ApplicationDirectory + "//ClientWindow.ini");
                //string kh = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "卡号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                //cmbklx.Enabled = klx == "true" ? true : false;
                //txtkh.Enabled = kh == "true" ? true : false;

                string brxm = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "姓名", Constant.ApplicationDirectory + "//txyy.ini");
                string xb = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "性别", Constant.ApplicationDirectory + "//txyy.ini");
                string nl = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "年龄", Constant.ApplicationDirectory + "//txyy.ini");
                txtbrxm.Enabled = brxm == "true" ? true : false;
                cmbxb.Enabled = xb == "true" ? true : false;

                //txtnl.Enabled = nl == "true" ? true : false;
                //rdocsrq.Enabled = nl == "true" ? true : false;//Add By Zj 2013-03-11
                //cmbDW.Enabled = nl == "true" ? true : false;//Add By Zj 2013-03-11
                txtnl.Enabled = nl == "false" ? true : false;
                rdonl.Enabled = nl == "false" ? true : false;//Add By Zj 2013-03-11
                rdocsrq.Enabled = nl == "false" ? true : false;//Add By Zj 2013-03-11
                cmbDW.Enabled = nl == "false" ? true : false;//Add By Zj 2013-03-11

                string hk = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "婚况", Constant.ApplicationDirectory + "//txyy.ini");
                string gj = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "国籍", Constant.ApplicationDirectory + "//txyy.ini");
                string mz = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "民族", Constant.ApplicationDirectory + "//txyy.ini");
                string zy = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "职业", Constant.ApplicationDirectory + "//txyy.ini");
                cmbhk.Enabled = hk == "true" ? true : false;
                cmbgj.Enabled = gj == "true" ? true : false;
                cmbmz.Enabled = mz == "true" ? true : false;

                txtzy.Enabled = zy == "true" ? true : false;
                txtzydm.Enabled = zy == "true" ? true : false;//Add By Zj 2013-03-11

                string brlxfs = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "本人联系方式", Constant.ApplicationDirectory + "//txyy.ini");
                string dzyj = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "电子邮件", Constant.ApplicationDirectory + "//txyy.ini");
                string yblx = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "医保类型", Constant.ApplicationDirectory + "//txyy.ini");
                string cbkh = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "参保卡号", Constant.ApplicationDirectory + "//txyy.ini");
                string sfzh = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "身份证号", Constant.ApplicationDirectory + "//txyy.ini");
                txtjtdh.Enabled = brlxfs == "true" ? true : false;
                txtdzyj.Enabled = dzyj == "true" ? true : false;
                cmbyblx.Enabled = yblx == "true" ? true : false;
                txtcbkh.Enabled = cbkh == "true" ? true : false;
                txtsfzh.Enabled = sfzh == "true" ? true : false;

                string csdz = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "出生地址", Constant.ApplicationDirectory + "//txyy.ini");
                string jtdz = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "家庭住址", Constant.ApplicationDirectory + "//txyy.ini");
                string jtdh = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "家庭电话", Constant.ApplicationDirectory + "//txyy.ini");
                string jtyb = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "家庭邮编", Constant.ApplicationDirectory + "//txyy.ini");
                string jtlxr = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "家庭联系人", Constant.ApplicationDirectory + "//txyy.ini");
                txtcsdz.Enabled = csdz == "true" ? true : false;
                txtjtdz.Enabled = jtdz == "true" ? true : false;
                txtbrlxfs.Enabled = jtdh == "true" ? true : false;
                txtjtyb.Enabled = jtyb == "true" ? true : false;
                txtjtlxr.Enabled = jtlxr == "true" ? true : false;


                string gzdw = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "工作单位", Constant.ApplicationDirectory + "//txyy.ini");
                string dwdh = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "单位电话", Constant.ApplicationDirectory + "//txyy.ini");
                string dwyb = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "单位邮编", Constant.ApplicationDirectory + "//txyy.ini");
                string dwlxr = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "单位联系人", Constant.ApplicationDirectory + "//txyy.ini");
                string dwdz = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "单位地址", Constant.ApplicationDirectory + "//txyy.ini");//Add By Zj 2013-03-11

                txtgzdw.Enabled = gzdw == "true" ? true : false;
                txtdwdh.Enabled = dwdh == "true" ? true : false;
                txtdwyb.Enabled = dwyb == "true" ? true : false;
                txtdwlxr.Enabled = dwlxr == "true" ? true : false;
                txtdwdz.Enabled = dwdz == "true" ? true : false;//Add By Zj 2013-03-11

                string lxrxm = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "联系人姓名", Constant.ApplicationDirectory + "//txyy.ini");
                string ybrdgx = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "与病人的关系", Constant.ApplicationDirectory + "//txyy.ini");
                string lxrdh = ApiFunction.GetIniString("卡信息登记屏蔽项_医生站", "联系人电话", Constant.ApplicationDirectory + "//txyy.ini");

                txtlxrxm.Enabled = (string.IsNullOrEmpty(lxrxm) ? true : (lxrxm == "true" ? true : false));
                txtlxrybrgx.Enabled = (string.IsNullOrEmpty(ybrdgx) ? true : (ybrdgx == "true" ? true : false));
                txtlxrdh.Enabled = (string.IsNullOrEmpty(lxrdh) ? true : (lxrdh == "true" ? true : false));
            }
            //Add by zp 2013-11-14 对应反馈平台单据号4536
            string xznl = ApiFunction.GetIniString("卡信息登记年龄控件默认选择", "出生日期", Constant.ApplicationDirectory + "//txyy.ini").ToLower();//Add By Zj 2013-03-11
            if (xznl == "true")
                rdocsrq.Checked = true;
            else
                rdonl.Checked = true;

            if (brxxid == Guid.Empty)
                txtkh.Focus();
            else
            {
                cmbklx.Enabled = false;
                txtkh.Enabled = false;
            }

            //Add By CC 判断是否为空
            bool kqjtdzzw = false;
            if (string.IsNullOrEmpty(cfg1110.Config))
            {
                kqjtdzzw = false;
            }
            else
            {
                if (cfg1110.Config == "1") kqjtdzzw = true;
                else kqjtdzzw = false;
            }
            //End Add
            if (kqjtdzzw)
                this.txtjtdz.Enter += new System.EventHandler(this.ChangeSrf); //Add by zp 2014-02-08
            if (_menuTag.Function_Name == "Fun_ts_mz_kgl_cx")
            {
                for (int i = 0; i <= this.Controls.Count - 1; i++)
                    this.Controls[i].Enabled = false;
                this.butquit.Enabled = true;
            }

            if (new SystemCfg(1049).Config == "1")
                rdocsrq.Checked = true;
            //自动读射频卡
            string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (sbxh != "")
            {
                ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
                if (ReadCard != null)
                    ReadCard.AutoReadCard(InstanceForm._menuTag.Function_Name, cmbklx, txtkh);
            }

            string zyzdy = ApiFunction.GetIniString("职业是否可以自定义", "职业职业是否可以自定义", Constant.ApplicationDirectory + "//ClientWindow.ini").ToLower();//Add By Zj 2013-03-11
            if (zyzdy != "true")
                txtzy.ReadOnly = true;
            //End Modify

            //***********************20150106 chencan/ ***********************************
            //添加参数1158： 设置病人卡管理授权的用户组编码。 为空表示没有控制。
            if (!String.IsNullOrEmpty(cfg1158.Config))
            {
                try
                {
                    if (TrasenFrame.Forms.FrmMdiMain.CurrentUser == null) return;
                    string str_userid = TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID.ToString();
                    string str_groupid = cfg1158.Config.Replace('，', ',');
                    string str_sql = "select 1 from Pub_Group_User where Delete_Bit=0 and Group_Id in (" + str_groupid + ") and User_Id=" + str_userid;
                    object obj = InstanceForm.BDatabase.GetDataResult(str_sql, 30);
                    if (obj == null)
                    {
                        butnext.Enabled = false;
                        butsave.Enabled = false;
                    }
                }
                catch
                {
                    MessageBox.Show("病人卡管理授权的用户组编码内容设置不规范，请检查！");
                }
            }
            //150108 chencan/ 启用卡单据使用，保存卡信息时，系统自动产生卡编号
            if (cfg1161.Config == "1")
            {
                txtkh.Enabled = false;
                txtbrxm.Focus();
            }
            //无卡病人办卡
            ckb_wkbr.CheckedChanged += new EventHandler(ckb_wkbr_CheckedChanged);
            ckb_wkbr.Checked = _bk;

            dtpcsrq.MaxDate = DateTime.Now.Date;
            //dtpcsrq.Value = DateTime.Now;

            if (_Modify)
            {
                cmbbrlx.Enabled = false;
            }
        }
        private void txtkh_KeyPress1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    if (cfg1060.Config == "0")//当参数1060 等于0  不允许卡中包含英文字母的时候验证卡的数字型
                    {
                        if (!Convertor.IsNumeric(txtkh.Text.Trim()))
                        {
                            MessageBox.Show("请输入正确的卡号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtkh.SelectAll();
                            return;
                        }
                        if (cfg1107.Config.Trim() == "1") //限制只能输入数字 Add By zp 2014-02-08
                        {
                            long value = 0;
                            if (!long.TryParse(txtkh.Text.Trim(), out value))
                            {
                                MessageBox.Show("输入了非数字字符!系统不允许卡号带有非数字字符!", "提示");
                                return;
                            }
                        }
                    }
                    txtkh.Text = Fun.returnKh(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text, InstanceForm.BDatabase);
                    txtkh.Text = ToDBC(txtkh.Text);
                    ReadCard readcard = new ReadCard(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text, InstanceForm.BDatabase);
                    if (readcard.kdjid != Guid.Empty)
                    {
                        kdjid = readcard.kdjid;
                        brxxid = readcard.brxxid;
                    }
                    else
                    {
                        kdjid = Guid.Empty;
                        brxxid = Guid.Empty;
                    }
                    // FillBrxx(brxxid);
                    SendKeys.Send("{TAB}");
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowZy(object sender, KeyPressEventArgs e, int type)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "名称", "编码", "拼音码", "五笔码" };
                string[] mappingname = new string[] { "name", "code", "py_code", "wb_code" };
                string[] searchfields = new string[] { "name", "code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 70, 70, 70 };
                DataTable Tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("select code,name,py_code,wb_code from JC_OCCUPATI");
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tb;
                f.WorkForm = this;
                f.srcControl = control;
                //f.Font = control.Font;
                f.Width = 400;
                f.Left = txtzydm.Left;
                f.Top = txtzydm.Bottom;
                //+ txtzydm.Height;
                if (type == 1)
                    f.ReciveString = "";
                else
                    f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    txtzy.Text = f.SelectDataRow["name"].ToString().Trim();
                    txtzy.Tag = f.SelectDataRow["code"].ToString().Trim();// add by zouchihua 保存职业代码
                    txtzy.Focus();
                    control.Text = "";
                    SendKeys.Send("{TAB}");
                }
            }
            else
            {
                SendKeys.Send("{TAB}");
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
                this.SelectNextControl(control, true, false, false, false);
                //SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        /// <summary>
        /// 清除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butnext_Click(object sender, EventArgs e)
        {
            brxxid = Guid.Empty;
            kdjid = Guid.Empty;
            cmbbrlx.SelectedIndex = 0;
            txtkh.Text = "";
            txtbrxm.Text = "";
            cmbxb.SelectedIndex = 0;
            txtnl.Text = "";
            cmbDW.SelectedIndex = 0;

            //if (cmbhk.SelectedIndex != -1) cmbhk.SelectedIndex = 0;
            cmbhk.SelectedIndex = -1;
            if (cmbgj.SelectedIndex != -1) cmbgj.SelectedIndex = 0;
            if (cmbmz.SelectedIndex != -1) cmbmz.SelectedIndex = 0;
            txtzy.Text = "";
            //add by zouchihua 国际和名族都改为默认 2013-3-27
            //if (cmbgj.Enabled)
            //    cmbgj.SelectedIndex = 0;
            //if (cmbmz.Enabled)
            //    cmbmz.SelectedIndex = 0;

            txtjtdh.Text = "";
            txtdzyj.Text = "";
            if (cmbhk.SelectedIndex != -1) cmbhk.SelectedIndex = 0;
            txtcbkh.Text = "";
            txtsfzh.Text = "";

            txtcsdz.Text = "";
            txtjtdz.Text = "";
            txtbrlxfs.Text = "";
            txtjtyb.Text = "";
            txtjtlxr.Text = "";

            txtgzdw.Text = "";
            txtdwdh.Text = "";
            txtdwyb.Text = "";
            txtdwlxr.Text = "";

            lbldjsj.Text = "";

            txtkh.Focus();


        }

        private void txtnl_Leave(object sender, EventArgs e)
        {
            //string ss = txtnl.Text;
            //ss=ss.Replace("岁", "");
            //ss = ss.Replace("月", "");
            //ss = ss.Replace("天", "");
            //if (txtnl.Text.Trim() != "" && Convertor.IsNumeric(ss) == false)
            //{
            //    MessageBox.Show("年龄请输入数字");
            //    return;
            //}
            //if (txtnl.Text.Trim() != "" && txtnl.Text.Contains("岁") == false && txtnl.Text.Contains("月") == false && txtnl.Text.Contains("天") == false)
            //{
            //    DateTime date = DateManager.AgeToDate(new Age(Convert.ToInt32(ss), AgeUnit.岁), TrasenFrame.Forms.FrmMdiMain.Database);
            //    dtpcsrq.Value = date;
            //}
            //if (txtnl.Text.Trim() != "" && Convertor.IsNumeric(ss) == true && txtnl.Text.Contains("岁") == true)
            //{
            //    DateTime date = DateManager.AgeToDate(new Age(Convert.ToInt32(ss), AgeUnit.岁), TrasenFrame.Forms.FrmMdiMain.Database);
            //    dtpcsrq.Value = date;
            //}

            try
            {
                if (txtnl.Text.Trim() != "" && Convertor.IsNumeric(txtnl.Text) == false)
                {
                    MessageBox.Show("年龄请输入数字");
                    return;
                }
                if (txtnl.Text.Trim() != "")
                {
                    dtpcsrq.Value = DateManager.AgeToDate(new Age(Convert.ToInt16(txtnl.Text), (AgeUnit)cmbDW.SelectedIndex), InstanceForm.BDatabase);
                    if (cmbhk.SelectedIndex == -1)
                        SetHyzk(new Age(Convert.ToInt16(txtnl.Text), (AgeUnit)cmbDW.SelectedIndex));
                }
                else
                    dtpcsrq.Value = DateManager.ServerDateTimeByDBType(TrasenFrame.Forms.FrmMdiMain.Database);
            }
            catch (Exception ex)
            {
                MessageBox.Show("年龄与出生日期、婚况联动出错：" + ex.Message);
            }
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            int err_code = 0;
            string err_text = "";
            string djsj = DateManager.ServerDateTimeByDBType(TrasenFrame.Forms.FrmMdiMain.Database).ToString();
            decimal Crje = 0;//存入金额
            #region //Add By Zj 2012-03-28 病人信息登记必填项控制
            if (cfg3033.Config.Trim() != "")
            {
                string[] strarr = cfg3033.Config.Split(',');
                for (int i = 0; i < strarr.Length; i++)
                {
                    if (strarr[i].ToString() == "1" && txtjtdh.Text.Trim() == "")
                    {
                        MessageBox.Show("请输入病人电话号码!", "提示:必填项", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtjtdh.Focus();
                        return;
                    }
                    if (strarr[i].ToString() == "2" && txtsfzh.Text.Trim() == "")
                    {
                        MessageBox.Show("请输入身份证号!", "提示:必填项", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtsfzh.Focus();
                        return;
                    }
                    if (strarr[i].ToString() == "3" && txtjtdz.Text.Trim() == "")
                    {
                        MessageBox.Show("请输入家庭地址!", "提示:必填项", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtjtdz1.Focus();
                        return;
                    }
                }
            }
            #endregion

            #region//验证姓名、年龄、全角
            if (txtbrxm.Text.Trim() == "")
            {
                MessageBox.Show("请输入病人姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!YY_BRXX.ValidingNameString(txtbrxm.Text))
            {
                MessageBox.Show("姓名中不能包含特殊字符", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rdonl.Checked == true && txtnl.Text.Trim() == "")
            {
                MessageBox.Show("请输入年龄", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnl.Focus();
                return;
            }
            if (dtpcsrq.Value.CompareTo(DateTime.Parse(djsj)) > 0)
            {
                MessageBox.Show("出生日期不能大于当前时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rdonl.Checked == true && txtnl.Text.Trim() != "")
                txtnl_Leave(sender, e);

            if (txtkh.Text.Trim().Length > 0)
            {
                char[] ss = txtkh.Text.ToCharArray();
                if (ss[ss.Length - 1] > 255) { MessageBox.Show("卡号不能是全角,请修改", "", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            #endregion

            #region //验证是否填写联系人姓名 Add by zp 2014-01-09
            int brnl = 0;
            if (cmbDW.Text.Trim() == "岁" && !string.IsNullOrEmpty(txtnl.Text))
                brnl = int.Parse(txtnl.Text.Trim());
            if (int.Parse(cfg3084.Config.Trim()) >= 0 && brnl <= int.Parse(cfg3084.Config.Trim()))
            {
                if (string.IsNullOrEmpty(this.txtlxrxm.Text))
                {
                    MessageBox.Show("当前患者年龄在" + cfg3084.Config + "岁内,需要填写联系人姓名,以及联系人关系!", "提示");
                    return;
                }
                if (string.IsNullOrEmpty(this.txtlxrybrgx.Text))
                {
                    MessageBox.Show("当前患者年龄在" + cfg3084.Config + "岁内,需要填写联系人姓名,以及联系人关系!", "提示");
                    return;
                }
            }
            #endregion

            //验证卡长度
            mz_card card = new mz_card(Convert.ToInt32(cmbklx.SelectedValue), InstanceForm.BDatabase);
            //if (txtkh.Text.Length != card.kcd && card.klx > 0 && txtkh.Text.Trim() != "")
            //{
            //    MessageBox.Show("卡位数必须符合系统设定的(" + card.kcd.ToString() + ")位长度", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //Add By Zj 2012-03-28 身份证唯一验证
            if (txtsfzh.Text != "" && cfg3034.Config == "0")
            {
                if (!mz_kdj.SFZHCount(this.txtsfzh.Text, InstanceForm.BDatabase))
                {
                    MessageBox.Show("身份证号:" + this.txtsfzh.Text + "已经拥有一张诊疗卡.不能继续办理!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.txtsfzh.SelectAll();
                    this.txtsfzh.Focus();
                    return;
                }
            }

            if (cfg1161.Config == "1")
            {
                string sql = "select count(*) from yy_brxx where brxm='" + txtbrxm.Text.Trim() + "' and bscbz=0";
                int result = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(sql));
                if (result > 0)
                {
                    string msg = "姓名已存在，是否继续？\r\n(提示：如果确认是同一病人，可以在病人信息查询页面重打条码单)";
                    if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
            }
            if (delaySave)
            {
                brdjxx = new MZ_BRXX_KXX();
                //构造病人信息
                YY_BRXX brxx = new YY_BRXX();
                brxx.Brxxid = Guid.Empty;
                brxx.Brxm = txtbrxm.Text.Trim();
                brxx.Xb = Convertor.IsNull(cmbxb.SelectedValue, "1");
                brxx.Csrq = dtpcsrq.Value.ToString("yyyy-MM-dd HH:mm:ss");
                brxx.Hyzk = Convertor.IsNull(cmbhk.SelectedValue, "0");
                brxx.Gj = Convertor.IsNull(cmbgj.SelectedValue, "-1");//Modify by zouchihua 2013-5-7 用编码保存cmbgj.Text.Trim();
                brxx.Mz = Convertor.IsNull(cmbmz.SelectedValue, "-1");//Modify by zouchihua 2013-5-7 用编码保存 cmbmz.Text.Trim();
                brxx.Zy = txtzy.Tag == null ? "" : txtzy.Tag.ToString().Trim();//Modify by zouchihua 2013-5-7 用编码保存 cmbmz.Text.Trim();
                brxx.Csdz = Convertor.IsNull(txtcsdz.SelectedValue, "-1"); //txtcsdz1.Text.Trim();
                brxx.Jtdz = txtjtdz.Text.Trim();
                brxx.Jtyb = txtjtyb.Text.Trim();
                //brxx.Jtdh = txtbrlxfs.Text.Trim();
                brxx.Jtdh = txtjtdh.Text.Trim();
                brxx.Jtlxr = txtjtlxr.Text.Trim();
                //brxx.Brlxfs = txtjtdh.Text.Trim();
                brxx.Brlxfs = txtbrlxfs.Text.Trim();
                brxx.Dzyj = txtdzyj.Text.Trim();
                brxx.Gzdw = txtgzdw.Text.Trim();
                brxx.Gzdwdz = txtdwdz.Text.Trim();
                brxx.Gzdwyb = txtdwyb.Text.Trim();
                brxx.Gzdwdh = txtdwdh.Text.Trim();
                brxx.Gzdwlxr = txtdwlxr.Text.Trim();
                brxx.Sfzh = txtsfzh.Text.Trim();
                brxx.Brlx = Convert.ToInt32(Convertor.IsNull(cmbbrlx.SelectedValue, "0"));
                brxx.Yblx = Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0"));
                brxx.Cbkh = txtcbkh.Text.Trim();
                brxx.Djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                if (cmb_brly.SelectedValue == null)
                {
                    brxx.Djly = 0;
                }
                else
                {
                    brxx.Djly = Int32.Parse(cmb_brly.SelectedValue.ToString());
                }
                //Add By Zj 2012-07-16
                brxx.Qtzjlx = txtqtzjlx.Text.Trim();
                brxx.Qtzjhm = txtqtzjhm.Text.Trim();
                brxx.Jkdah = txtjkdabh.Text.Trim();
                brxx.Whcddm = Convertor.IsNull(txtwhcd.Tag, "0").ToString().Trim();
                brxx.Lxrxm = txtlxrxm.Text.Trim();
                brxx.Lxrgx = Convertor.IsNull(txtlxrybrgx.SelectedValue, "-1"); //txtcsdz1.Text.Trim();txtlxrybrgx1.Text.Trim();

                brxx.Lxrdh = txtlxrdh.Text.Trim();
                //构造卡登记信息
                MZ_KDJXX kdjxx = new MZ_KDJXX();
                kdjxx.Kdjid = Guid.Empty;
                kdjxx.Brxxid = Guid.Empty;
                kdjxx.Klx = Convert.ToInt32(cmbklx.SelectedValue);
                kdjxx.Kh = txtkh.Text.Trim();
                kdjxx.Brxm = txtbrxm.Text.Trim();
                kdjxx.Zbbz = 0;
                kdjxx.Zbks = 0;
                kdjxx.Zbjb = 0;
                kdjxx.Zbys = 0;
                kdjxx.Djsj = djsj;
                kdjxx.Djy = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                kdjxx.Kmm = card.mrmm;
                brdjxx.Brxx = brxx;
                brdjxx.Kdjxx = kdjxx;

                yy_brxx_bc.BRXXID = brxxid;
                yy_brxx_bc.QTZJLX = txtqtzjlx.Text.Trim();
                yy_brxx_bc.QTZJHM = txtqtzjhm.Text.Trim();
                yy_brxx_bc.JKDAH = txtjkdabh.Text.Trim();
                yy_brxx_bc.WHCDDM = Convertor.IsNull(txtwhcd.Tag, "0").ToString().Trim();
                yy_brxx_bc.LXRXM = txtlxrxm.Text.Trim();
                yy_brxx_bc.LXRGX = Convertor.IsNull(txtlxrybrgx.SelectedValue, "-1");
                yy_brxx_bc.LXRDH = txtlxrdh.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            Guid _y_brxxid = brxxid;
            Guid _y_kdjid = kdjid;

            #region 自动读射频卡
            string kxym = "";
            ReadCard _readCard = new ReadCard(kdjid, InstanceForm.BDatabase);
            kxym = Convertor.IsNull(_readCard.kxym, "");
            try
            {
                if (kdjid == Guid.Empty || (_readCard.kdjid != Guid.Empty && Convertor.IsNull(_readCard.kxym, "") == ""))
                {
                    string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
                    if (ReadCard != null)
                    {
                        kxym = ReadCard.CreateKxym();
                        //kxym = "4299902600";
                        bool bok = ReadCard.WriterCard(txtkh.Text, kxym, "", kxym);
                        if (bok == false)
                            throw new Exception("写卡没有成功");
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("读射频卡出错：" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region 住院信息
            try
            {
                //增加判断，如果有在住院有住院信息，给与提示 add by zouchihua 2013-4-22 
                if (brxxid != null && brxxid != Guid.Empty)
                {
                    string sql = @" select NAME,SEXCODE,BIRTHDAY,sex from VI_ZY_VINPATIENT(nolock)  where patient_id='" + brxxid + "'";
                    DataTable tbmx = FrmMdiMain.Database.GetDataTable(sql);
                    if (tbmx.Rows.Count > 0)
                    {
                        if (cfg1183.Config == "1")
                        {
                            //if (tbmx.Rows[0]["NAME"].ToString().Trim() != this.txtbrxm.Text.Trim() || tbmx.Rows[0]["SEXCODE"].ToString().Trim() != this.cmbxb.SelectedValue.ToString().Trim()
                            //    || Convert.ToDateTime(tbmx.Rows[0]["BIRTHDAY"].ToString().Trim()).ToShortDateString() != dtpcsrq.Value.ToShortDateString())
                            //{
                            if (
                                (MessageBox.Show("该病人存在住院信息，您确定要更改吗？\r\n  在住院的信息如下：\n  姓名【" + tbmx.Rows[0]["NAME"].ToString().Trim() + "】\n"
                                + "  性别【" + tbmx.Rows[0]["sex"].ToString().Trim() + "】\n" + "  出生日期:【" + Convert.ToDateTime(tbmx.Rows[0]["BIRTHDAY"].ToString().Trim()).ToShortDateString() + "】"

                                , "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                )
                                return;
                            //}
                        }
                        else if (cfg1183.Config == "2")
                        {
                            MessageBox.Show("该病人存在住院信息，不能修改病人基本信息！");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("检查病人的住院信息时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                #region 保存病人卡信息
                //保存病人信息 Modify By Zj 2012-12-11 将出生日期的值 短日期格式格式化为 标准格式 为了正确的获取出生的小时
                YY_BRXX.BrxxDj(brxxid,
                    txtbrxm.Text.Trim(),
                    Convertor.IsNull(cmbxb.SelectedValue, "1"),
                   dtpcsrq.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    //Convert.ToDateTime(strCsrq).ToString("yyyy-MM-dd HH:mm:ss"),
                   Convertor.IsNull(cmbhk.SelectedValue, "0"),
                   Convertor.IsNull(cmbgj.SelectedValue, "-1"),
                   Convertor.IsNull(cmbmz.SelectedValue, "-1"),
                  txtzy.Tag == null ? "" : txtzy.Tag.ToString().Trim(),
                    Convertor.IsNull(txtcsdz.SelectedValue, "-1"),//txtcsdz1.Text.Trim()
                      txtjtdz.Text,
                   txtjtyb.Text.Trim(),
                   txtjtdh.Text.Trim(),
                   txtjtlxr.Text.Trim(),
                   txtbrlxfs.Text.Trim(),
                   txtdzyj.Text.Trim(),
                   txtgzdw.Text.Trim(),
                   txtdwdz.Text.Trim(),
                   txtdwyb.Text.Trim(),
                   txtdwdh.Text.Trim(),
                   txtdwlxr.Text.Trim(),
                   txtsfzh.Text.Trim(),
                   Convert.ToInt32(Convertor.IsNull(cmbbrlx.SelectedValue, "0")),
                   Convert.ToInt32(Convertor.IsNull(cmbyblx.SelectedValue, "0")),
                   txtcbkh.Text.Trim(),
                   TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId, cmb_brly.SelectedValue == null ? 0 : Int32.Parse(cmb_brly.SelectedValue.ToString()),
                   out brxxid, out err_code, out err_text, InstanceForm.BDatabase);
                if (brxxid == Guid.Empty || err_code != 0) throw new Exception("保存病人信息出错：" + err_text);
                //Add By Zj 2012-07-16
                if (txtqtzjlx.Text.Trim() != "" || txtqtzjhm.Text.Trim() != "" || txtjkdabh.Text.Trim() != "" || txtwhcd.Text.Trim() != "" || txtlxrxm.Text.Trim() != "" || txtlxrybrgx.Text.Trim() != "" || txtlxrdh.Text.Trim() != "")
                {
                    YY_BRXX.BrxxBcDj(brxxid, txtqtzjlx.Text.Trim(), txtqtzjhm.Text.Trim(), txtjkdabh.Text.Trim(), Convertor.IsNull(txtwhcd.Tag, "0").ToString().Trim(), txtlxrxm.Text.Trim(),
                        Convertor.IsNull(txtlxrybrgx.SelectedValue, "-1"),
                        txtlxrdh.Text.Trim(), out err_code, out err_text, InstanceForm.BDatabase);
                    if (err_code != 0) throw new Exception("补充病人信息出错：" + err_text);
                }

                //生成卡单据编码
                if (cfg1161.Config == "1")
                {
                    if (String.IsNullOrEmpty(txtkh.Text))
                    {
                        txtkh.Text = C_CardManager.M_GenerateCard(cmbklx.SelectedValue, InstanceForm.BDatabase);
                        if (String.IsNullOrEmpty(txtkh.Text))
                        {
                            throw new Exception("生成条码卡号失败");
                        }
                    }
                }
                if (string.IsNullOrEmpty(_menuTag.Function_Name)) _menuTag.Function_Name = "temp";
                //保存卡信息
                if (txtkh.Text.Trim() != "" && card.klx > 0)
                {
                    mz_kdj.Kdj(kdjid,
                          brxxid,
                          Convert.ToInt32(cmbklx.SelectedValue),
                          txtkh.Text.Trim(),
                          txtbrxm.Text.Trim(),
                          0,
                          0,
                          0,
                          0,
                          djsj,
                          TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId,
                          card.mrmm, kxym, "",
                          out kdjid, out err_code, out err_text, Fun.GetNewGrzhbh(InstanceForm.BDatabase), _menuTag.Function_Name, InstanceForm.BDatabase);
                    if (kdjid == Guid.Empty || err_code != 0) throw new Exception("保存卡信息出错：" + err_text);
                    this.Text = this.txtkh.Text.ToString();
                }

                //保存金额
                if (Crje > 0)
                {
                    Guid kjeid = Guid.Empty;
                    mz_kdj.Kdj_je(Guid.Empty, kdjid, brxxid, 1, "", Crje, TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId, djsj, "", "", "", "", out kjeid, out err_code, out err_text, InstanceForm.BDatabase);
                    if (kjeid == Guid.Empty || err_code != 0) throw new Exception("保存卡金额出错：" + err_text);
                }
                if (cfg1161.Config == "1")
                    C_CardManager.M_PrintCard(txtkh.Text);//打印条码卡单
                #endregion

                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("保存成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception err)
            {
                brxxid = _y_brxxid;
                kdjid = _y_kdjid;
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    if (cfg1060.Config == "0")//当参数1060 等于0  不允许卡中包含英文字母的时候验证卡的数字型
                    {
                        if (!Convertor.IsNumeric(txtkh.Text.Trim()))
                        {
                            MessageBox.Show("请输入正确的卡号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtkh.SelectAll();
                            return;
                        }
                        if (cfg1107.Config.Trim() == "1") //限制只能输入数字 Add By zp 2014-02-08
                        {
                            long value = 0;
                            if (!long.TryParse(txtkh.Text.Trim(), out value))
                            {
                                MessageBox.Show("输入了非数字字符!系统不允许卡号带有非数字字符!", "提示");
                                return;
                            }
                        }
                    }

                    //txtkh.Text = Fun.returnKh(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text, InstanceForm.BDatabase);
                    string num = Fun.returnKh(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text, InstanceForm.BDatabase);
                    num = num.Replace(@";", "");
                    num = num.Replace(@"；", "");
                    num = num.Replace(@"；", "");
                    num = num.Replace(@"?", "");
                    num = num.Replace(@"？", "");
                    num = num.Replace(@"？", "");
                    txtkh.Text = ToDBC(num);
                    //txtkh.Text = ToDBC(txtkh.Text);
                    ReadCard readcard = new ReadCard(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text, InstanceForm.BDatabase);
                    if (readcard.kdjid != Guid.Empty)
                    {
                        kdjid = readcard.kdjid;
                        brxxid = readcard.brxxid;
                        //清掉无卡病人的信息
                        ckb_wkbr.Checked = false;
                    }
                    //如果是无卡病人办卡,且卡是新卡
                    else if (ckb_wkbr.Checked)
                    {
                        return;
                    }
                    else
                    {
                        kdjid = Guid.Empty;
                        brxxid = Guid.Empty;
                    }
                    FillBrxx(brxxid);
                    SendKeys.Send("{TAB}");
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillBrxx(Guid brxxid)
        {
            YY_BRXX brxx = new YY_BRXX(brxxid, InstanceForm.BDatabase);

            if (brxx.Brlx > 0)
                cmbbrlx.SelectedValue = brxx.Brlx.ToString();
            else
            {
                if (cmbbrlx.SelectedIndex == -1) cmbbrlx.SelectedIndex = 0;
            }
            txtbrxm.Text = brxx.Brxm;
            cmbxb.SelectedValue = brxx.Xb;
            if (brxx.Csrq.Trim() != "")
            {
                dtpcsrq.Value = Convert.ToDateTime(brxx.Csrq);
                SetNlControl(dtpcsrq.Value);
            }
            else
            {
                txtnl.Text = "";
            }
            if (brxx.Hyzk != "0")
                cmbhk.SelectedValue = brxx.Hyzk;
            else
                cmbhk.SelectedValue = "9";

            //Modify by zouchihua 2013-5-7 通过编码获得
            cmbgj.SelectedValue = brxx.Gj;
            cmbmz.SelectedValue = brxx.Mz;
            try
            {
                DataTable tbzy = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("select code,name,py_code,wb_code from JC_OCCUPATI where code='" + brxx.Zy + "'");
                if (tbzy.Rows.Count > 0)
                {
                    txtzy.Text = tbzy.Rows[0]["name"].ToString().Trim();//需要改为名称显示
                }
                txtzy.Tag = brxx.Zy;

            }
            catch { }

            //txtjtdh.Text = brxx.Brlxfs;
            txtjtdh.Text = brxx.Jtdh;
            txtdzyj.Text = brxx.Dzyj;
            cmbyblx.SelectedValue = brxx.Yblx.ToString();
            txtcbkh.Text = brxx.Cbkh;
            txtsfzh.Text = brxx.Sfzh;

            try
            {
                txtcsdz.SetSelectItem(brxx.Csdz == "-1" ? "-1" : brxx.Csdz);
                //txtcsdz.SelectedValue = brxx.Csdz == "-1" ? "-1" : brxx.Csdz;
                //txtcsdz.SelectedIndex = 2;

            }
            catch
            {
                txtcsdz.SelectedValue = -1;
            }
            try
            {
                txtjtdz.Text = brxx.Jtdz;
                txtjtdz.DataSource = null;
                txtjtdz.DropDownHeight = 0;
                //txtjtdz.SetSelectItem(brxx.Jtdz == "-1" ? "-1" : brxx.Jtdz);
            }
            catch
            {
                txtjtdz.SelectedValue = -1;
            }
            //txtbrlxfs.Text = brxx.Jtdh;
            txtbrlxfs.Text = brxx.Brlxfs;
            txtjtyb.Text = brxx.Jtyb;
            txtjtlxr.Text = brxx.Jtlxr;

            txtgzdw.Text = brxx.Gzdw;
            txtdwdz.Text = brxx.Gzdwdz;
            txtdwdh.Text = brxx.Gzdwdh;
            txtdwyb.Text = brxx.Gzdwyb;
            txtdwlxr.Text = brxx.Gzdwlxr;
            //Add By Zj 2012-07-16 
            txtqtzjlx.Text = brxx.Qtzjlx;
            txtqtzjhm.Text = brxx.Qtzjhm;
            txtjkdabh.Text = brxx.Jkdah;
            txtwhcd.Text = brxx.Whcddm;
            txtlxrxm.Text = brxx.Lxrxm;
            try
            {
                // txtlxrybrgx.Text = brxx.Lxrgx;
                txtlxrybrgx.SetSelectItem(brxx.Lxrgx == "-1" ? "-1" : brxx.Lxrgx);

            }
            catch
            {
                //txtlxrybrgx.SelectedValue = -1;
            }
            txtlxrdh.Text = brxx.Lxrdh;

            //lbldjly.Text = Fun.SeekDjly(brxx.Djly);
            cmb_brly.SelectedValue = brxx.Djly;
            lbldjsj.Text = brxx.Djsj.ToString();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtnl.Enabled = rdonl.Checked == true ? true : false;
            cmbDW.Enabled = rdonl.Checked == true ? true : false;
            dtpcsrq.Enabled = rdocsrq.Checked == true ? true : false;
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtzydm_KeyPress(object sender, KeyPressEventArgs e)
        {
            ShowZy(sender, e, 2);
            //Control control = (Control)sender;
            //if ((int)e.KeyChar != 13)
            //{
            //    string[] headtext = new string[] { "名称", "编码", "拼音码", "五笔码" };
            //    string[] mappingname = new string[] { "name", "code", "py_code", "wb_code" };
            //    string[] searchfields = new string[] { "name", "code", "py_code", "wb_code" };
            //    int[] colwidth = new int[] { 150, 70, 70, 70 };
            //    DataTable Tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("select code,name,py_code,wb_code from JC_OCCUPATI");
            //    TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
            //    f.sourceDataTable = Tb;
            //    f.WorkForm = this;
            //    f.srcControl = control;
            //    //f.Font = control.Font;
            //    f.Width = 400;
            //    f.Left = txtzydm.Left;
            //    f.Top = txtzydm.Top + txtzydm.Height;
            //    f.ReciveString = e.KeyChar.ToString();
            //    e.Handled = true;
            //    if (f.ShowDialog() == DialogResult.Cancel)
            //    {
            //        control.Focus();
            //    }
            //    else
            //    {
            //        txtzy.Text = f.SelectDataRow["name"].ToString().Trim();
            //        txtzy.Tag = f.SelectDataRow["code"].ToString().Trim();// add by zouchihua 保存职业代码
            //        txtzy.Focus();
            //        control.Text = "";
            //        SendKeys.Send("{TAB}");
            //    }
            //}
            //else
            //{
            //    SendKeys.Send("{TAB}");
            //}
        }

        private void Frmbrkdj_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2 && butsave.Enabled == true)
            {
                if (txtnl.ContainsFocus == true)
                    txtnl_Leave(sender, new EventArgs());
                butsave_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                butquit_Click(sender, e);
            }

            if (e.KeyCode == Keys.F4)
            {
                butnext_Click(sender, e);
            }

            if (e.KeyCode == Keys.F3)
            {
                butsfz_Click(this.txtkh, e);
            }

            if (e.KeyCode == Keys.F5)
            {
                butsave_Click(butsave, e);
            }
        }

        private void dtpcsrq_ValueChanged(object sender, EventArgs e)
        {
            SetNlControl(dtpcsrq.Value);
        }

        private void SetNlControl(DateTime csrq)
        {
            Age age = DateManager.DateToAge(csrq, InstanceForm.BDatabase);
            txtnl.Text = age.AgeNum.ToString();
            cmbDW.SelectedIndex = (int)age.Unit;
            SetHyzk(age);

            //SetAge(csrq, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase));
        }

        SystemCfg cfgAge = new SystemCfg(5101);

        private void SetHyzk(Age age)
        {
            //if (age.Unit.ToString() == "岁" && (int)age.AgeNum >= Convert.ToInt32(cfgAge.Config))
            //    cmbhk.SelectedIndex = 1;
            //else
            //    cmbhk.SelectedIndex = 0;

            //------ 数据库值定义------
            //1	未婚
            //2	已婚
            //3	丧偶
            //4	离婚
            //9	其他
            //--------参数定义----------
            //0 = 其他, 
            //1 = 18岁以下其他,18岁以上已婚, 
            //2 = 25岁以下未婚,25岁以上已婚) 当值>=18 时，直接以值判断(年龄大于等于该值是已婚，否则为未婚 )
            try
            {
                if (age.Unit != AgeUnit.岁)
                    return;
                if (cfgAge == null || String.IsNullOrEmpty(cfgAge.Config))
                    return;
                string[] arr_sz = cfgAge.Config.Split('|');
                if (arr_sz.Length < 3)
                    return;
                if (!String.IsNullOrEmpty(arr_sz[0]))
                {
                    if (age.AgeNum >= Convert.ToInt32(arr_sz[0]))
                    {
                        cmbhk.SelectedValue = !String.IsNullOrEmpty(arr_sz[2]) ? arr_sz[2] : null;
                    }
                    else
                    {
                        cmbhk.SelectedValue = !String.IsNullOrEmpty(arr_sz[1]) ? arr_sz[1] : null;
                    }
                }
            }
            catch
            {
                //DialogResult dr =MessageBox.Show("婚姻状况默认值设置有误，详见参数1176。","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //if (dr == DialogResult.OK)
                //{
                //    return;
                //}
            }
        }


        private void butclearyb_Click(object sender, EventArgs e)
        {
            cmbyblx.SelectedIndex = -1;
        }

        private void txtnl_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 39 || (int)e.KeyCode == 40)
            {
                rdocsrq.Checked = true;
                dtpcsrq.Focus();
            }
        }

        private void dtpcsrq_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Language_Off(object sender, System.EventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                control.ImeMode = ImeMode.Close;
                Fun.SetInputLanguageOff();
            }
            catch (Exception ex)
            {
                MessageBox.Show("关闭输入法有误," + ex.Message);
            }
        }

        private void Language_On(object sender, System.EventArgs e)
        {
            //Control control = (Control)sender; 
            //control.ImeMode = ImeMode.On;  
            //Fun.SetInputLanguageOn();
            //ChangeSrf(sender,e);--modify by jiangzf
            try
            {
                Control control = (Control)sender;
                control.ImeMode = ImeMode.OnHalf;
                Fun.SetInputLanguageOn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("开启输入法有误," + ex.Message);
            }
        }

        private void ChangeSrf(object sender, System.EventArgs e)
        {
            string[] languagename = new string[] { "拼音", "五笔", "中文" };
            bool bResult = false;
            for (int i = 0; i < languagename.Length; i++)
            {
                foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
                {
                    if (lang.LayoutName.IndexOf(languagename[i]) >= 0)
                    {
                        InputLanguage.CurrentInputLanguage = lang;
                        bResult = true;
                        break;
                    }
                }

                if (bResult)
                    break;
            }
        }

        private void butsfz_Click(object sender, EventArgs e)
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
                    if (bok == false) return;

                    if (bshow == "true")
                    {
                        ts_ReadCard.Frmsfxx f = new ts_ReadCard.Frmsfxx(ref _IDCardData);
                        f.ShowDialog();
                        if (f.Ok == false) return;
                    }

                    txtbrxm.Text = _IDCardData.Name;
                    cmbxb.Text = _IDCardData.Sex;
                    cmbmz.Text = _IDCardData.Nation;
                    if (!string.IsNullOrEmpty(_IDCardData.Nation))
                    {
                        string lastWords = _IDCardData.Nation.Substring(_IDCardData.Nation.Length - 1, 1);
                        if (lastWords == "族")
                            _IDCardData.Nation = _IDCardData.Nation.Substring(0, _IDCardData.Nation.Length - 1);
                        DataRow[] rows = ((DataTable)cmbmz.DataSource).Select("name like '" + _IDCardData.Nation + "%'");
                        if (rows.Length > 0)
                        {
                            string code = rows[0]["code"].ToString().Trim();
                            cmbmz.SelectedValue = code;
                        }
                    }

                    //Modify By cc 2014-02-20
                    //string xznl = ApiFunction.GetIniString("卡信息登记年龄控件默认选择", "出生日期", Constant.ApplicationDirectory + "//ClientWindow.ini").ToLower();//Add By Zj 2013-03-11
                    //if (Convert.ToBoolean(xznl))
                    //{
                    //    rdocsrq.Checked = true;
                    //    dtpcsrq.Value = Convert.ToDateTime(_IDCardData.Born);
                    //    SetNlControl(dtpcsrq.Value);
                    //}
                    //else
                    //{
                    //    rdonl.Checked = true;
                    //    object o = getYear(_IDCardData.Born);
                    //    cmbDW.Text = o.ToString().Substring(o.ToString().Length - 1);
                    //    txtnl.Text = o.ToString().Substring(0, o.ToString().Length - 1);
                    //    dtpcsrq.Value = Convert.ToDateTime(_IDCardData.Born); 
                    //}
                    //End Modify
                    dtpcsrq.Value = Convert.ToDateTime(_IDCardData.Born);
                    SetNlControl(dtpcsrq.Value);

                    bool bFocus = txtkh.Focused;
                    txtjtdz.Text = _IDCardData.Address;
                    txtsfzh.Text = _IDCardData.IDCardNo;
                    if (bFocus)
                        txtkh.Focus();
                    //cmbmz.SelectedValue = _IDCardData.Nation;
                    //if (cmbmz.SelectedIndex < 0)
                    //    cmbmz.SelectedText = _IDCardData.Nation;

                    //chencan 计算性别,出生日期,年龄
                    string str_sfz = txtsfzh.Text.Trim();
                    if (!String.IsNullOrEmpty(str_sfz) && !mz_kdj.IsIDCardNumber(str_sfz))
                    {
                        string[] sVal = mz_kdj.ReturnAgeAndSex(str_sfz);
                        cmbxb.Text = sVal[1];

                        DateTime bornDay = Convert.ToDateTime(sVal[0]);
                        rdocsrq.Checked = true;
                        dtpcsrq.Value = bornDay;

                        Age age = DateManager.DateToAge(bornDay, InstanceForm.BDatabase);
                        txtnl.Text = age.AgeNum.ToString();
                        cmbDW.SelectedIndex = (int)age.Unit;
                    }

                    if (((Control)sender).Name == txtkh.Name && txtkh.Focused && e.GetType() == typeof(KeyEventArgs) && ((KeyEventArgs)e).KeyCode == Keys.F8)
                    {
                        SystemCfg cfg1186 = new SystemCfg(1186, InstanceForm.BDatabase);
                        if (cfg1186.Config == "1")
                        {
                            SystemCfg cfg1187 = new SystemCfg(1187, InstanceForm.BDatabase);
                            if (!string.IsNullOrEmpty(cfg1187.Config) && Convertor.IsInteger(cfg1187.Config))
                            {
                                cmbklx.SelectedValue = Convert.ToInt32(cfg1187.Config);
                                txtkh.Text = _IDCardData.IDCardNo;
                            }
                            else
                            {
                                MessageBox.Show("身份证登记功能不能用，请正确设置参数1187或关闭参数1186", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Add By CC 2014-02-20
        private object getYear(string strCsrq)
        {
            string strSql = string.Format(@"select  dbo.fun_GetAge('{0}',1,GETDATE()) ", Convert.ToDateTime(strCsrq));
            object o = InstanceForm.BDatabase.GetDataResult(strSql);
            return o;
        }

        private object getYearTwo(string strCsrq)
        {
            string strSql = string.Format(@"select  dbo.fun_GetAgeYear('{0}',GETDATE()) ", Convert.ToDateTime(strCsrq));
            object o = InstanceForm.BDatabase.GetDataResult(strSql);
            return o;
        }
        //End Add
        private void Frmbrkdj_Activated(object sender, EventArgs e)
        {
            if (DelaySave == true && txtbrxm.Enabled == true)
                txtbrxm.Focus();
            //Modify by CC 
            //string mrjd = ApiFunction.GetIniString("卡登记默认焦点控件名称", "控件名称", Constant.ApplicationDirectory + "//ClientWindow.ini").ToLower();//Add By Zj 2013-03-11
            //if (!string.IsNullOrEmpty(mrjd))
            //{
            //    if (mrjd == "姓名") txtbrxm.Focus();
            //}           
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
        //Add By Zj 2012-04-18 姓名重复个数提示
        private void txtbrxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                txtbrxm_Leave(sender, e);
                SendKeys.Send("{TAB}");
            }
        }

        private void txtbrxm_Leave(object sender, EventArgs e)
        {
            if (txtbrxm.Text.Trim() != "")
            {
                string sql = "select count(*) from yy_brxx where brxm='" + txtbrxm.Text.Trim() + "' and bscbz=0";
                int result = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(sql));
                if (result > 0)
                    lblts.Text = "已有(" + result.ToString() + ")人";
                else
                    lblts.Text = "";
            }
        }

        private void txtwhcd_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "名称", "编码", "拼音码", "五笔码" };
                string[] mappingname = new string[] { "name", "code", "py_code", "wb_code" };
                string[] searchfields = new string[] { "name", "code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 70, 70, 70 };
                DataTable Tb = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable("select cast(code as varchar(20)) code ,name,py_code,wb_code from jc_whcd");
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Tb;
                f.WorkForm = this;
                f.srcControl = control;
                //f.Font = control.Font;
                f.Width = 400;
                f.Left = 0;
                f.Top = 0;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    txtwhcd.Text = f.SelectDataRow["name"].ToString().Trim();
                    txtwhcd.Tag = f.SelectDataRow["code"].ToString().Trim();
                    txtwhcd.Focus();
                    SendKeys.Send("{TAB}");
                }
            }
            else
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtcsdz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.SelectNextControl((sender as Control), true, false, false, false);
            }
        }

        private void txtlxrybrgx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.SelectNextControl((sender as Control), true, false, false, false);
            }
        }

        private void txtcsdz_TextChanged(object sender, EventArgs e)
        {
            if (txtjtdz.DropDownHeight == 0)
                txtjtdz.DropDownHeight = 160;
            //Modify by cc 2014-02-24 增加ITEMNAME 搜索
            tbdz.DefaultView.RowFilter = "PY_CODE like '" + (sender as TrasenClasses.GeneralControls.ComboBoxEx).Text.Trim() + "%' or ITEMNAME LIKE '" + (sender as TrasenClasses.GeneralControls.ComboBoxEx).Text.Trim() + "%'";
            (sender as TrasenClasses.GeneralControls.ComboBoxEx).DataSource = tbdz.DefaultView.ToTable();
        }

        private void txtlxrybrgx_TextChanged(object sender, EventArgs e)
        {
            //Modify by cc 2014-02-24 增加ITEMNAME 搜索
            //tbbrgx.DefaultView.RowFilter = "PY_CODE like '" + (sender as TrasenClasses.GeneralControls.ComboBoxEx).Text.Trim() + "%'or NAME LIKE '" + (sender as TrasenClasses.GeneralControls.ComboBoxEx).Text.Trim() + "%'";
            //(sender as TrasenClasses.GeneralControls.ComboBoxEx).DataSource = tbbrgx.DefaultView.ToTable();
        }

        private void Frmbrkdj_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (new SystemCfg(1188).Config == "1")
            {
                //关闭同时获取用户选择年龄的控件,存储到ini 便于下次打开窗体是默认选择年龄控件 Add by zp 2013-11-14 对应平台单据号4536
                bool xznl = rdocsrq.Checked == true ? true : false;
                ApiFunction.WriteIniString("卡信息登记年龄控件默认选择", "出生日期", xznl.ToString(), Constant.ApplicationDirectory + "//ClientWindow.ini");//Add By Zj 2013-03-11
            }
        }

        private void txtlxrybrgx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Down && e.KeyCode != Keys.Up && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
            {
                tbbrgx.DefaultView.RowFilter = "PY_CODE like '" + (sender as TrasenClasses.GeneralControls.ComboBoxEx).Text.Trim() + "%'or NAME LIKE '" + (sender as TrasenClasses.GeneralControls.ComboBoxEx).Text.Trim() + "%'";
                (sender as TrasenClasses.GeneralControls.ComboBoxEx).DataSource = tbbrgx.DefaultView.ToTable();
            }
        }

        private void txtzydm_Enter(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.ImeMode = ImeMode.OnHalf;
            Fun.SetInputLanguageOn();
            //object o = this. txtzydm;
            if (isFirstEnter)
            {
                isFirstEnter = false;
                KeyPressEventArgs ee = new KeyPressEventArgs((char)12);
                ShowZy(sender, ee, 1);

            }
        }

        /// <summary>
        /// 手工输入身份证号时自动生成出身日期和性别，年龄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>add by wangzhi 2014-09-10 马王堆医院需求</remarks>
        private void txtsfzh_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r' && !string.IsNullOrEmpty(txtsfzh.Text.Trim()))
                {
                    string inputString = txtsfzh.Text;
                    if (!mz_kdj.IsIDCardNumber(inputString))
                    {
                        MessageBox.Show("输入的身份证号格式不正确，请输入15或18位的身份证号", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string[] sVal = mz_kdj.ReturnAgeAndSex(inputString);
                    cmbxb.Text = sVal[1];

                    DateTime bornDay = Convert.ToDateTime(sVal[0]);
                    dtpcsrq.Value = bornDay;
                    Age age = DateManager.DateToAge(bornDay, InstanceForm.BDatabase);
                    txtnl.Text = age.AgeNum.ToString();
                    cmbDW.SelectedIndex = (int)age.Unit;

                    if (rdonl.Checked)
                    {
                        //txtnl.Focus();
                        SendKeys.SendWait("{Tab}");
                        SendKeys.Flush();
                    }
                    else
                    {
                        SendKeys.SendWait("{Tab}");
                        SendKeys.Flush();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 150826 add by chencan 无卡病人办卡
        /// 在病人卡登记页面，实现为已经建立了病人基本信息而没有关联卡的病人进行诊疗卡登记.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckb_wkbr_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ckb_wkbr.Checked)
                {
                    return;
                }
                if (String.IsNullOrEmpty(txtbrxm.Text.Trim()) && String.IsNullOrEmpty(txtsfzh.Text.Trim()))
                {
                    MessageBox.Show("查询无卡病人的范围太大，请输入病人姓名或者身份证号码。");
                    ckb_wkbr.Checked = false;
                    txtbrxm.Focus();
                    return;
                }
                //查找系统中无卡病人信息
                StringBuilder sbr_sql = new StringBuilder();
                sbr_sql.Append("select brxxid,brxm,case XB when 1 then '男' when 2 then '女' else '' end as xb,convert(varchar(10),CSRQ,120) as csrq,SFZH,Brlxfs,JTDZ from YY_BRXX a where not exists (select 1 from YY_KDJB b where b.BRXXID=a.BRXXID and b.ZFBZ=0) ");
                if (brxxid != null && brxxid != Guid.Empty)
                {
                    sbr_sql.Append(" and brxxid='");
                    sbr_sql.Append(brxxid);
                    sbr_sql.Append("' ");
                }
                else
                {
                    if (!String.IsNullOrEmpty(txtbrxm.Text.Trim()))
                    {
                        sbr_sql.Append(" and brxm like '%");
                        sbr_sql.Append(txtbrxm.Text.Trim());
                        sbr_sql.Append("%' ");
                    }
                    if (cmbxb.SelectedValue != null && !String.IsNullOrEmpty(cmbxb.SelectedValue.ToString().Trim()))
                    {
                        sbr_sql.Append(" and xb=");
                        sbr_sql.Append(cmbxb.SelectedValue.ToString().Trim());
                    }
                    if (!String.IsNullOrEmpty(txtsfzh.Text.Trim()))
                    {
                        sbr_sql.Append(" and sfzh='");
                        sbr_sql.Append(txtsfzh.Text.Trim());
                        sbr_sql.Append("' ");
                    }
                    //if (dtpcsrq.Value != null)
                    //{
                    //    sbr_sql.Append(" and (CSRQ is null or convert(varchar(10),CSRQ,120)='");
                    //    sbr_sql.Append(dtpcsrq.Value.ToShortDateString());
                    //    sbr_sql.Append("') ");
                    //}
                }
                DataTable dt = InstanceForm.BDatabase.GetDataTable(sbr_sql.ToString());
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("系统中没有符合条件的无卡病人。");
                    ckb_wkbr.Checked = false;
                    return;
                }
                if (dt.Rows.Count == 1)
                {
                    brxxid = new Guid(dt.Rows[0]["brxxid"].ToString());
                    FillBrxx(brxxid);
                    txtkh.Enabled = true;
                    cmbklx.Enabled = true;
                    kdjid = Guid.Empty;
                }
                else
                {
                    Frm_SelectBr fs = new Frm_SelectBr(dt);
                    fs.StartPosition = FormStartPosition.CenterScreen;
                    fs.ShowDialog();
                    if (fs.brxxid != Guid.Empty)
                    {
                        brxxid = fs.brxxid;
                        FillBrxx(brxxid);
                        txtkh.Enabled = true;
                        cmbklx.Enabled = true;
                        kdjid = Guid.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbklx_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < cmbklx.Items.Count; i++)
            {
                string kValue = "D" + (i + 1).ToString();
                if (e.KeyCode == (Keys)Enum.Parse(typeof(Keys), kValue))
                {
                    cmbklx.SelectedIndex = i;
                }
            }
        }

        private bool jump = true;

        private void dtpcsrq_ValueChanged_1(object sender, EventArgs e)
        {
            if (jump && dtpcsrq.Focused)
            {
                SendKeys.Send("{right}");
            }
        }

        private void dtpcsrq_CloseUp(object sender, EventArgs e)
        {
            jump = true;
        }

        private void dtpcsrq_DropDown(object sender, EventArgs e)
        {
            jump = false;
        }
    }
}