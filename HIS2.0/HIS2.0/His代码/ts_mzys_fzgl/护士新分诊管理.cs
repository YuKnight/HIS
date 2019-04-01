using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;
using System.Diagnostics;
using ts_mzys_class;
using ts_mz_class;
using System.Net.Sockets;
using System.Threading;
using System.Media;
using System.Text;
using System.Net;
using DotNetSpeech;
using Ts_Fz_Help;
using ts_mz_rizhi;
using TrasenClasses.DatabaseAccess;

namespace ts_mzys_fzgl
{
    public partial class Frmfzgl_New : Form
    {

        private bool isFzzj;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private int czType;
        private Form current_tvfrm = null;//Ts_Fz_Help.FrmScreen

        private TimeSpan tmsp = new TimeSpan(100);

        private Thread listenThread;
        SystemCfg cfg3103 = new SystemCfg(3103);
        static private TcpListener tcplistener;
        /// <summary>
        /// 语音对象 add by zp 2013-06-19
        /// </summary>
        private VoiceHelp _voice = new VoiceHelp();

        private ServerListen _serverlisten = new ServerListen();
        /// </summary>
        /// 护士站服务端监听对象socket add by zp 2013-06-18
        /// </summary>
        private Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        /// <summary>
        /// 护士站监听得到的网络传输对象 add by zp 2013-06-18
        /// </summary>
        private Socket socket;
        //string bqybjq = ApiFunction.GetIniString("报价器文件路径", "启用报价器", Constant.ApplicationDirectory + "//ClientWindow.ini");
        //string bjqxh = ApiFunction.GetIniString("报价器文件路径", "报价器型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
        private Fz_Zq current_zq = new Fz_Zq(); //add by zp 2013-06


        public TrasenClasses.DatabaseAccess.RelationalDatabase current_db = InstanceForm.BDatabase;
        /// <summary>
        /// 电视机显示界面是否已打开 false 未打开 true 已打开 add by zp 2013-06-14
        /// </summary>
        //public bool ScreenFrmOff;
        /// <summary>
        /// 是否启用新分诊叫号系统0是1否 add by zp 2013-06-18
        /// </summary>
        public SystemCfg _cfg3070 = new SystemCfg(3070);
        public SystemCfg _cfg3075 = new SystemCfg(3075); //Add By zp 2013-09-24 护士分诊台是否新增按钮控制报道方式 0不允许 1允许 默认0
        public SystemCfg _cfg3078 = new SystemCfg(3078);//Add By zp 2013-10-22  分诊护士站是否开启病人转诊功能 0否 1是 默认0
        /// <summary>
        /// 呼叫对应的挂号级别 Add By zp 2013-08-05
        /// </summary>
        private DataTable dt_ghjb;

        public Frmfzgl_New(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;

        }
        /// <summary>
        /// 监听方法
        /// </summary>
        private void startListen()
        {
            if (this.toolStripLabel1.Tag == null)
            {
                return;
            }

            string sql = @"SELECT TOP 1 ISNULL(TXDK,8889) AS TXDK FROM JC_ZJSZ WHERE ZQID=" + current_zq.Zqid + "";
            int port = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(sql));
            _serverlisten.SocketListen(port, InstanceForm.BDatabase, current_zq, listener, _voice, ref socket); // modify by zp 2013-06-18

        }
        /// <summary>
        /// 绑定已分诊的科室下拉 add by zp 2013-06-04
        /// </summary>
        private void BindYfzDept()
        {
            try
            {
                string sql = @"SELECT DEPT_ID AS 科室id,dbo.fun_getDeptname(DEPT_ID) AS 科室名称 FROM JC_FZ_ZQ_DEPT
                WHERE ZQ_ID=" + this.current_zq.Zqid + "";
                DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
                DataRow dr = dt.NewRow();
                dr["科室id"] = "-1";
                dr["科室名称"] = "所有科室";
                dt.Rows.InsertAt(dr, 0);
                this.Cmb_Dept.ValueMember = "科室id";
                this.Cmb_Dept.DisplayMember = "科室名称";
                this.Cmb_Dept.DataSource = dt;
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
            }
        }

        private void Frmfzgl_Load(object sender, EventArgs e)
        {
            try
            {
                if (_cfg3075.Config.Trim() == "0") //控制报道方式按钮影藏 Add by zp 2013-09-24
                    this.toolStripButton1.Visible = false;
                if (_cfg3078.Config.Trim() == "1") //是否允许护士转诊 Add by zp 2013-10-22
                {
                    this.病人转诊ToolStripMenuItem.Visible = true;
                    this.病人转诊ToolStripMenuItem1.Visible = true;
                    this.病人转诊ToolStripMenuItem2.Visible = true;
                }
              
                SetGhjbRdbTag();
                this.WindowState = FormWindowState.Maximized;
                FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

                /*实例化诊区*/
                string ip = current_zq.GetLoacalHostIP();
                //DataTable dt_zq = current_zq.GetZq(ip, InstanceForm.BDatabase);
                current_zq = new Fz_Zq(InstanceForm.BDatabase, ip);

                ServerListen.Hjcs = int.Parse(current_zq.Zqhjcs);
                toolStripLabel1.Text = current_zq.Zqname.Trim();
                toolStripLabel1.Tag = current_zq.Zqid;
                BindYfzDept();
                this.Rdb_Allys.Checked = true;
                butref1_Click(sender, e);
                //butref2_Click(sender, e);

                //自动读射频卡
                string sbxh = ApiFunction.GetIniString("医院健康卡", "设备型号", Constant.ApplicationDirectory + "//ClientWindow.ini");
                ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
                if (ReadCard != null)
                    ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txtkh);
                this.Cmb_Dept.SelectedIndex = 0;
                Control.CheckForIllegalCrossThreadCalls = false;
                listenThread = new Thread(startListen);//start);
                listenThread.IsBackground = true;
                listenThread.Start();

                if (cfg3103.Config == "1")
                {
                    butfz.Visible = false;
                    排队优先ToolStripMenuItem.Visible = false;
                    病人转诊ToolStripMenuItem.Visible = false;
                    病人转诊ToolStripMenuItem1.Visible = false;
                }
                if (new SystemCfg(3115).Config == "1")
                {
                    录入体征信息ToolStripMenuItem1.Visible = false;
                    门急诊录入ToolStripMenuItem1.Visible = true;
                }
                else
                {
                    录入体征信息ToolStripMenuItem1.Visible = true;
                    门急诊录入ToolStripMenuItem1.Visible = false;
                }
                if (new SystemCfg(3112).Config == "0")
                {
                    门急诊录入ToolStripMenuItem.Visible = false; 
                    门急诊录入ToolStripMenuItem1.Visible = false;
                }
                string iszdsx = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("护士分诊", "是否开启刷新", Constant.ApplicationDirectory + "\\TrasenFzjh3.0.ini");
                string jgsj = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("护士分诊", "刷新间隔时间", Constant.ApplicationDirectory + "\\TrasenFzjh3.0.ini");
                if (iszdsx.ToUpper() == "TRUE")
                {
                    timer1.Enabled = true;
                    timer1.Interval = Convert.ToInt32(jgsj);
                    timer1.Start();
                }

            }
            catch (Exception ea)
            {
                MessageBox.Show("Frmfzgl_Load出现异常!原因:" + ea.Message, "错误");
            }
        }

        private void SetGhjbRdbTag()
        {
            dt_ghjb = this.current_zq.LoadGhjbItem(InstanceForm.BDatabase);
            this.current_zq.SetControlByGhjb(pan_DocLevel, dt_ghjb);
        }

        /// <summary>
        /// 刷新未分诊病人列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butref1_Click(object sender, EventArgs e)
        {
            try
            {
                string rq1 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00";
                string rq2 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59";
                int klx = 0;
                string kh = "";
                string blh = "";
                int sort = 0;
                if (new SystemCfg(3069).Config == "0")
                {
                    int hour = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select DATEPART(hh, GETDATE())"));
                    if (hour >= 8 && hour <= 12)
                        sort = 1;
                    else if (hour > 12 && hour < 18)
                        sort = 2;
                }
                //if (new SystemCfg(3103).Config == "1") sort = 0;
                DataSet ds = MZHS_FZJL.Select_WfzPat(current_zq.Zqid, rq1, rq2, klx, kh, blh, sort, InstanceForm.BDatabase);
                DataTable dt = ds.Tables[0];
                //Modify by zp 2013-11-05 将预约与现场病人队列合并
                //DataTable dt_yyinfo = ds.Tables[2];
                //AddWfzList(dt_xcinfo, this.listView1);
                AddWfzList(dt, this.ListView_Wfz_Yy);
                this.TabPgWfz_YyInfo.Text = "候诊病人列表 " + dt.Rows.Count + "人";
                //this.TabPgWfz_XcInfo.Text = "现场挂号病人列表 " + dt_xcinfo.Rows.Count + "人";
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 填充未分诊网格
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="control"></param>
        private void AddWfzList(DataTable tb, ListView control)
        {
            //listView1.Items.Clear();
            control.Items.Clear();
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Name = "候诊号";
                item.Text = Convertor.IsNull(tb.Rows[i]["候诊号"], "");
                if (new SystemCfg(3103).Config == "1")
                {
                    ListView_Wfz_Yy.Columns[0].Text = "排序号";
                    if (tb.Rows[i]["排序号"].ToString() == "9999") tb.Rows[i]["排序号"] = "";
                    item.Text = Convertor.IsNull(tb.Rows[i]["排序号"], "");
                }

                ListViewItem.ListViewSubItem subitem_xm = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["姓名"], ""));
                subitem_xm.Name = "姓名";
                item.SubItems.Add(subitem_xm);

                ListViewItem.ListViewSubItem subitem_ghsj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号时间"], ""));
                subitem_ghsj.Name = "挂号时间";
                item.SubItems.Add(subitem_ghsj);
                //
                ListViewItem.ListViewSubItem subitem_ghks = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号科室"], ""));
                subitem_ghks.Name = "挂号科室";
                item.SubItems.Add(subitem_ghks);

                ListViewItem.ListViewSubItem subitem_ghjb = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号级别"], ""));
                subitem_ghjb.Name = "挂号级别";
                item.SubItems.Add(subitem_ghjb);

                ListViewItem.ListViewSubItem subitem_ghys = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号医生"], ""));
                subitem_ghys.Name = "挂号医生";
                item.SubItems.Add(subitem_ghys);


                ListViewItem.ListViewSubItem subitem_ghxxid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["ghxxid"], ""));
                subitem_ghxxid.Name = "ghxxid";
                item.SubItems.Add(subitem_ghxxid);

                ListViewItem.ListViewSubItem subitem_mzh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["门诊号"], ""));
                subitem_mzh.Name = "门诊号";
                item.SubItems.Add(subitem_mzh);

                ListViewItem.ListViewSubItem subitem_kh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["卡号"], ""));
                subitem_kh.Name = "卡号";
                item.SubItems.Add(subitem_kh);

                control.Items.Add(item);
            }
        }

        /// <summary>
        /// 返回当前选择的医生级别
        /// </summary>
        /// <returns></returns>
        private int GetSelectDocLevel()
        {
            try
            {
                foreach (Control ctr in pan_DocLevel.Controls)
                {
                    if (ctr is RadioButton)
                    {
                        RadioButton rdbtn = (RadioButton)ctr;
                        if (!rdbtn.Checked) { continue; }
                        return Convert.ToInt32(rdbtn.Tag);
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
            }
            return -1;
        }

        /// <summary>
        /// 填充已分诊网格 modify by zp 2013-05-29
        /// </summary>
        /// <param name="tb"></param>
        private void AddYfzList(DataTable tb, ListView control)
        {
            //listView2.Items.Clear();
            control.Items.Clear();
            int dept_id = Convert.ToInt32(this.Cmb_Dept.SelectedValue); //科室id
            int doclevel = GetSelectDocLevel(); //得到选择的挂号级别
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                //验证科室是否一致
                if (Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["fzks"], "0")) != dept_id && dept_id != -1)
                    continue;
                //验证级别是否一致
                if (Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["GHJB"],"0")) != doclevel && doclevel != -1)
                    continue;
                //Modify by zp 2013-11-05 新增时段
                ListViewItem item = new ListViewItem();
                item.Name = "时段";
                item.Text = Convertor.IsNull(tb.Rows[i]["时段昵称"], "");
                ListViewItem.ListViewSubItem subitem_hzh;
                if (new SystemCfg(3103).Config == "1")
                { 
                    ListView_Yfz.Columns[0].Text = "排序号";
                   subitem_hzh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["排队序号"], ""));
                    subitem_hzh.Name = "候诊号";
                }
                else
                {
                    subitem_hzh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["候诊号"], ""));
                    subitem_hzh.Name = "候诊号";
                }
                item.SubItems.Add(subitem_hzh);

                ListViewItem.ListViewSubItem subitem_mzh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["门诊号"], ""));
                subitem_mzh.Name = "门诊号";
                item.SubItems.Add(subitem_mzh);

                ListViewItem.ListViewSubItem subitem_kh = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["卡号"], ""));
                subitem_kh.Name = "卡号";
                item.SubItems.Add(subitem_kh);

                ListViewItem.ListViewSubItem subitem_xm = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["姓名"], ""));
                subitem_xm.Name = "姓名";
                item.SubItems.Add(subitem_xm);

                ListViewItem.ListViewSubItem subitem_hzks = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["候诊科室"], ""));
                subitem_hzks.Name = "候诊科室";
                item.SubItems.Add(subitem_hzks);

                ListViewItem.ListViewSubItem subitem_hzzs = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["候诊诊室"], ""));
                subitem_hzzs.Name = "候诊诊室";
                item.SubItems.Add(subitem_hzzs);

                ListViewItem.ListViewSubItem subitem_fzys = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["分诊医生"], ""));
                subitem_fzys.Name = "分诊医生";
                item.SubItems.Add(subitem_fzys);

                ListViewItem.ListViewSubItem subitem_yysd = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["预约时段"], ""));
                subitem_yysd.Name = "预约时段";
                item.SubItems.Add(subitem_yysd);

                ListViewItem.ListViewSubItem subitem_pdsj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["排队时间"], ""));
                subitem_pdsj.Name = "排队时间";
                item.SubItems.Add(subitem_pdsj);

                ListViewItem.ListViewSubItem subitem_ghsj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号时间"], ""));
                subitem_ghsj.Name = "挂号时间";
                item.SubItems.Add(subitem_ghsj);

                ListViewItem.ListViewSubItem subitem_ghks = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号科室"], ""));
                subitem_ghks.Name = "挂号科室";
                item.SubItems.Add(subitem_ghks);

                ListViewItem.ListViewSubItem subitem_ghjb = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号级别"], ""));
                subitem_ghjb.Name = "挂号级别";
                item.SubItems.Add(subitem_ghjb);

                ListViewItem.ListViewSubItem subitem_ghys = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["挂号医生"], ""));
                subitem_ghys.Name = "挂号医生";
                item.SubItems.Add(subitem_ghys);

                ListViewItem.ListViewSubItem subitem_bz = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["备注"], ""));
                subitem_bz.Name = "备注";
                item.SubItems.Add(subitem_bz);

                ListViewItem.ListViewSubItem subitem_ghxxid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["ghxxid"], ""));
                subitem_ghxxid.Name = "ghxxid";
                item.SubItems.Add(subitem_ghxxid);

                ListViewItem.ListViewSubItem subitem_zsid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["zsid"], ""));
                subitem_zsid.Name = "zsid";
                item.SubItems.Add(subitem_zsid);

                ListViewItem.ListViewSubItem subitem_fzid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["FZID"], ""));
                subitem_fzid.Name = "fzid";
                item.SubItems.Add(subitem_fzid);

                ListViewItem.ListViewSubItem subitem_kssj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["开始时间"], ""));
                subitem_kssj.Name = "开始时间";
                item.SubItems.Add(subitem_kssj);

                ListViewItem.ListViewSubItem subitem_jssj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["结束时间"], ""));
                subitem_jssj.Name = "结束时间";
                item.SubItems.Add(subitem_jssj);


                int hzlx = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["hzlx"], "0"));
                if (hzlx == 1)
                    item.ForeColor = Color.Blue;
                if (hzlx == 2)
                    item.ForeColor = Color.Green;

                //listView2.Items.Add(item);
                control.Items.Add(item);

            }

        }

        private void AddListView4(DataTable tb)
        {
            listView4.Items.Clear();
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Name = "科室";
                item.Text = Convertor.IsNull(tb.Rows[i]["科室"], "");

                ListViewItem.ListViewSubItem subitem_zs = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["诊室"], ""));
                subitem_zs.Name = "诊室";
                item.SubItems.Add(subitem_zs);

                ListViewItem.ListViewSubItem subitem_zzys = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["坐诊医生"], ""));
                subitem_zzys.Name = "坐诊医生";
                item.SubItems.Add(subitem_zzys);

                ListViewItem.ListViewSubItem subitem_dlsj = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["登陆时间"], ""));
                subitem_dlsj.Name = "登陆时间";
                item.SubItems.Add(subitem_dlsj);

                ListViewItem.ListViewSubItem subitem_zjid = new ListViewItem.ListViewSubItem(item, Convertor.IsNull(tb.Rows[i]["zjid"], ""));
                subitem_zjid.Name = "zjid";
                item.SubItems.Add(subitem_zjid);

                listView4.Items.Add(item);
            }
        }


        private void UpdatePxxh()
        {
            try
            {
                if (ListView_Yfz.Items.Count == 0)
                {
                    return;
                }
                InstanceForm.BDatabase.BeginTransaction();
                for (int i = 0; i <= ListView_Yfz.Items.Count - 1; i++)
                {
                    ListViewItem item = (ListViewItem)ListView_Yfz.Items[i];
                    string fzid = item.SubItems["fzid"].Text;
                    int pxxh = i + 1;
                    string ssql = "update mzhs_fzjl set pxxh=" + pxxh + " where fzid='" + fzid + "'";
                    int iii = InstanceForm.BDatabase.DoCommand(ssql);
                }
                InstanceForm.BDatabase.CommitTransaction();

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                throw new Exception(err.Message);
            }
        }
        /// <summary>
        /// 分诊病人再刷新未分诊记录
        /// </summary>
        private void BindWfzPatInfo()
        {
            try
            {
                //int zqdm = Convert.ToInt32(Convertor.IsNull(cmb.ComboBox.SelectedValue, "0"));//诊区代码
                string rq1 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00";
                string rq2 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59";
                int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));//卡类型
                string kh = "";
                string blh = "";
                if (!string.IsNullOrEmpty(txtkh.Text.Trim()))
                {
                    txtkh.Text = Fun.returnKh(klx, txtkh.Text.Trim(), InstanceForm.BDatabase);
                    kh = txtkh.Text.Trim();
                }

                if (!string.IsNullOrEmpty(txtmzh.Text.Trim()))
                {
                    txtmzh.Text = Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                    txtmzh.SelectAll();
                    blh = txtmzh.Text.Trim();
                } 

                Guid NewFzid = Guid.Empty;
                int err_code = -1;
                string err_text = "";

                int sort = 0;
                int hour = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select DATEPART(hh, GETDATE())"));
                if (hour >= 8 && hour <= 12)
                    sort = 1;
                else if (hour > 12 && hour < 18)
                    sort = 2;
                if (new SystemCfg(3103).Config == "1") sort = 0;
                DataSet dset = MZHS_FZJL.Select_WfzPat(this.current_zq.Zqid, rq1, rq2, klx, kh, blh, sort, InstanceForm.BDatabase);
                DataTable tb = dset.Tables[0];
                //DataTable tb_yywfz = dset.Tables[2];

                //如果多行，则由用户选择 Modify by zp 2013-11-05
                if (tb.Rows.Count > 1)
                {
                    AddWfzList(tb, this.ListView_Wfz_Yy);//AddWfzList(tb, this.listView1);
                }

                //如果找到一行。则直接候诊
                if (tb.Rows.Count == 1)//|| tb_yywfz.Rows.Count == 1
                {
                    try
                    {
                        InstanceForm.BDatabase.BeginTransaction();
                        Guid _guid = Guid.Empty;
                        int fzks = 0;
                        if (tb.Rows.Count == 1)
                        {
                            _guid = new Guid(tb.Rows[0]["ghxxid"].ToString());
                            fzks = Convert.ToInt32(tb.Rows[0]["hzks"]);
                        }
                        if (new SystemCfg(3103).Config == "1" && this.current_zq.Xsfs == 1)
                        {
                            MZHS_FZJL.AddHz(TrasenFrame.Forms.FrmMdiMain.Jgbm, _guid, fzks, GetPxxh(fzks), MZHS_FZJL.FzStatus.已分诊,
                                out NewFzid, out err_code, out err_text, Convertor.IsNull(tb.Rows[0]["kssj"], ""), Convertor.IsNull(tb.Rows[0]["jssj"], ""), Convertor.IsNull(tb.Rows[0]["sjnc"], ""), 0, InstanceForm.BDatabase);
                        }
                        else
                        {
                            MZHS_FZJL.AddHz(TrasenFrame.Forms.FrmMdiMain.Jgbm, _guid, fzks, MZHS_FZJL.FzStatus.已分诊,
                                out NewFzid, out err_code, out err_text, Convertor.IsNull(tb.Rows[0]["kssj"], ""), Convertor.IsNull(tb.Rows[0]["jssj"], ""), Convertor.IsNull(tb.Rows[0]["sjnc"], ""), 0, InstanceForm.BDatabase);
                        }
                        if (err_code != 0)//NewFzid == Guid.Empty ||
                            throw new Exception(err_text);
                        InstanceForm.BDatabase.CommitTransaction();
                        if ((new SystemCfg(3103).Config == "1" && this.current_zq.Xsfs == 2 )||(new SystemCfg(3103).Config == "1" && this.current_zq.Xsfs == 3))
                        { 
                            butfz_Click(null, null); 
                        }
                        butref1_Click(null, null);
                        butref2_Click(null, null);
                        /*刷新显示屏*/
                        if (Fz_ShowSx.Frm_Open) //如果当前窗体已经打开则将最新的已分诊数据传输给电视机
                        {
                            ServerListen.UpdateDisplay(null, this.current_zq.Zqid, InstanceForm.BDatabase);
                        }
                    }
                    catch (System.Exception err)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();
                        throw new Exception(err.Message);
                    }
                }

                //如果没有找到行
                if (tb.Rows.Count == 0)
                {
                    if (dset.Tables.Count > 1)
                    {
                        DataTable tbxx = dset.Tables[1];
                        if (tbxx.Rows.Count == 0)
                        {
                            MessageBox.Show("没有找到这个病人的挂号信息!", "提示");
                            return;
                        }
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("BindWfzPatInfo出现错误!原因:" + ea.ToString(), "错误");
            }
        }
        /// <summary>
        /// 病人分诊 在分诊的时候更新分诊表的诊室字段 为挂号医生所在诊室 Modify zp 2013-05-29 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 13) return;
            if (new SystemCfg(3134).Config == "1")
            {
                if (MessageBox.Show("是否将该病人强制转诊到本诊区?", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes) return; 
                if (!string.IsNullOrEmpty(txtkh.Text.Trim()))
                {
                    txtkh.Text = Fun.returnKh(Convert.ToInt32( cmbklx.SelectedValue), txtkh.Text.Trim(), InstanceForm.BDatabase);
                    string strMZH = InstanceForm.BDatabase.GetDataResult(@"SELECT TOP 1 BLH FROM dbo.MZ_GHXX a INNER JOIN  YY_KDJB b ON a.KDJID= b.KDJID WHERE KH='" + txtkh.Text + "' ORDER  BY a.GHSJ DESC ").ToString();
                    if (!string.IsNullOrEmpty(strMZH))
                        txtmzh.Text = strMZH;
                } 
                if (!string.IsNullOrEmpty(txtmzh.Text.Trim()))
                {
                    txtmzh.Text = Fun.returnMzh(txtmzh.Text.Trim(), InstanceForm.BDatabase);
                    txtmzh.SelectAll(); 
                }
                if (string.IsNullOrEmpty(txtmzh.Text.Trim())) return;
                
                FrmKzqzz frm = new FrmKzqzz(this.txtmzh.Text.Trim(), this.current_zq);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    butref1_Click(null, null);
                }
            }
            else BindWfzPatInfo();
        }
        /// <summary>
        /// 绑定已分诊病人信息
        /// </summary>
        private void BindYfzPat()
        {
            try
            {
                string rq1 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00";
                string rq2 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59";
                int klx = 0;
                string kh = "";
                string blh = "";
                int sort = 0;
                if (new SystemCfg(3069).Config == "0")
                {
                    int hour = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select DATEPART(hh, GETDATE())"));
                    if (hour >= 7 && hour < 12)
                        sort = 1;
                    else if (hour >= 12 && hour < 18)
                        sort = 2;
                }
                //if (new SystemCfg(3103).Config == "1") sort = 0;
                DataSet ds = MZHS_FZJL.Select_yfzpat(this.current_zq.Zqid, rq1, rq2, klx, kh, blh, sort, InstanceForm.BDatabase);
                DataTable dt = ds.Tables[0];
                //DataTable dt_yyinfo = ds.Tables[1];
                //AddYfzList(dt_xcinfo, this.listView2);//绑定现场挂号已分诊
                AddYfzList(dt, this.ListView_Yfz); //绑定预约挂号已分诊

                this.TabPgYfz_YyPat.Text = "已分诊病人列表 " + dt.Rows.Count + "人";
                /*刷新显示屏 Add by zp 2014-07-22*/
                ServerListen.UpdateDisplay(null, this.current_zq.Zqid, InstanceForm.BDatabase);
                //controlForm_RefreshScreenDisplay
                  
            }
            catch (Exception ea)
            {
                MessageBox.Show("BindYfzPat出现异常!原因:" + ea.Message, "错误");
            }
        }
        /// <summary>
        /// 刷新已分诊 同时刷新电视机显示屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butref2_Click(object sender, EventArgs e)
        {
            BindYfzPat();
        }

        private void butup_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListView_Yfz.SelectedIndices.Count == 0) return;
                ListViewItem item = (ListViewItem)ListView_Yfz.SelectedItems[0];
                int nrow = item.Index - 1;
                if (nrow < 0) return;
                item.Remove();
                ListView_Yfz.Items.Insert(nrow, item);
                UpdatePxxh();

            }
            catch (System.Exception ERR)
            {
                MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butdown_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListView_Yfz.SelectedIndices.Count == 0) return;
                ListViewItem item = (ListViewItem)ListView_Yfz.SelectedItems[0];
                int nrow = item.Index + 1;
                if (nrow > ListView_Yfz.Items.Count - 1) return;
                item.Remove();
                ListView_Yfz.Items.Insert(nrow, item);
                UpdatePxxh();
            }
            catch (System.Exception ERR)
            {
                MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 踢出队列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butqxhz_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = null;
                if (this.TabConrol_Yfz.SelectedTab.Name == "TabPgYfz_YyPat") ///预约页面
                {
                    if (this.ListView_Yfz.SelectedIndices.Count == 0) { return; }
                    item = (ListViewItem)this.ListView_Yfz.SelectedItems[0];
                }
         
                if (MessageBox.Show(this, "您确认要取消[" + item.SubItems["姓名"].Text + "]的候诊吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                MZHS_FZJL.Delete_Hz(new Guid(item.SubItems["fzid"].Text), _cfg3070, InstanceForm.BDatabase);
                item.Remove();
                /*刷新显示屏*/
                if (Fz_ShowSx.Frm_Open) //如果当前窗体已经打开则将最新的已分诊数据传输给电视机
                    ServerListen.UpdateDisplay(null, this.current_zq.Zqid, InstanceForm.BDatabase);
                //刷新未分诊列表
                butref1_Click(sender,e); 
            }
            catch (System.Exception ERR)
            {
                MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        ///  绑定诊间信息 还需更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_PageGotFocus(object sender, EventArgs e)
        {
            try
            {
                // int ksdm = Convert.ToInt32(Convertor.IsNull(cmb.ComboBox.SelectedValue, "0"));
                string ssql = "select dbo.fun_getdeptname(ksdm) 科室,zjmc 诊室,dbo.fun_getempname(zzys) 坐诊医生,dlsj 登陆时间,zjid from jc_zjsz where bdlbz=1 ";
                // if (ksdm > 0) ssql = ssql + " and  ksdm=" + ksdm + " ";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                AddListView4(tb);
            }
            catch (System.Exception ERR)
            {
                MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //分诊
        private void butfz_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListView_Wfz_Yy.Items.Count == 0) return;
                ListViewItem item = new ListViewItem();
                if (ListView_Wfz_Yy.SelectedIndices.Count == 0) item = ListView_Wfz_Yy.Items[0];
                else  item = (ListViewItem)ListView_Wfz_Yy.SelectedItems[0];
                string strFzid = InstanceForm.BDatabase.GetDataResult("SELECT FZID FROM dbo.MZHS_FZJL WHERE GHXXID='" + item.SubItems["ghxxid"].Text + "'").ToString();
                FrmFzNew frmAction = new FrmFzNew(strFzid, item.SubItems["ghxxid"].Text, item.SubItems["门诊号"].Text, current_zq.Zqid);
                frmAction.ShowDialog();
                if (frmAction.DialogResult == DialogResult.OK)
                {
                    isFzzj = true; 
                }
                else
                {
                    isFzzj = false;
                }
                if (isFzzj && new SystemCfg(3112).Config == "1")
                {
                    ts_mz_rizhi.InstanceForm InstanceFormTemp = new ts_mz_rizhi.InstanceForm(); 
                    InstanceFormTemp.Database = TrasenFrame.Forms.FrmMdiMain.Database; 
                    InstanceFormTemp.CurrentDept = TrasenFrame.Forms.FrmMdiMain.CurrentDept;
                    InstanceFormTemp.CurrentUser = TrasenFrame.Forms.FrmMdiMain.CurrentUser;
                    MZ_RZ frm = new MZ_RZ("门诊急诊录入", _menuTag, txtmzh.Text);
                    frm.ShowDialog();
                }
                butref2_Click(sender, e);
            }
            catch (System.Exception ERR)
            {
                MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmfzgl_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                /* modify by zp 2013-06-18*/

                if (current_tvfrm != null)
                {
                    current_tvfrm.Close();
                }
                if (socket != null)
                    socket.Close();

                if (_voice != null)
                {
                    _voice.DisposeVoice();
                }

                if (tcplistener != null)
                {
                    tcplistener.Stop();
                    tcplistener = null;
                }

                if (listenThread != null)
                {

                    if (listenThread.IsAlive)
                    {
                        listenThread.Suspend();
                    }
                    listenThread.Abort();
                    listenThread = null;
                }

                if (listener != null)
                {
                    listener.Close();
                    listener = null;
                }

            }
            catch
            {
                //MessageBox.Show(ERR.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void listView1_DoubleClick(object sender, EventArgs e)
        //{
        //    WfzBdEvent(this.listView1, e);
        //}

        private void cmbks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                butref1_Click(sender, e);
            }
            catch (System.Exception err)
            {
            }
        }


        /// <summary>
        /// 对未分诊病人进行分诊操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WfzBdEvent(object sender, EventArgs e)
        {
            try
            {
                ListView control = (ListView)sender;
                if (control.SelectedIndices.Count == 0) { return; }
                ListViewItem item = (ListViewItem)control.SelectedItems[0];
                string blh = item.SubItems["门诊号"].Text;
                txtmzh.Text = blh;
                //txtkh_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
                BindWfzPatInfo();
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 执行分诊操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_Wfz_Yy_DoubleClick(object sender, EventArgs e)
        {
            this.txtkh.Text = "";
            this.txtmzh.Text = "";
            WfzBdEvent(ListView_Wfz_Yy, e);
            //butref2_Click(sender, e);
        }

        private int GetPxxh(int deptid)
        {
            int sort = 1;
            int hour = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select DATEPART(hh, GETDATE())"));
            if (hour >= 8 && hour <= 12)
                sort = 1;
            else if (hour > 12 && hour < 18)
                sort = 2;
            //产生候诊号  
            string strSql = string.Empty;
            int pdxh = -1;
            if (sort == 1)
            {

                strSql = string.Format(@"SELECT ISNULL( MAX(pxxhnew),0)+1 pxxhnew  FROM 
                                                            (
                                                            SELECT (CASE WHEN PXXH=9999 THEN 0 ELSE PXXH END) pxxhnew,*
                                                            FROM dbo.MZHS_FZJL WHERE FZKS={0} and DJSJ>='{1}' and DJSJ<'{2}' 
                                                            )  a", deptid, System.DateTime.Now.ToShortDateString() + " 07:00:00", DateTime.Now.AddDays(1).ToShortDateString() + " 12:00:00");

                pdxh = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(strSql));
            }
            else
            {

                strSql = string.Format(@"SELECT ISNULL( MAX(pxxhnew),0)+1 pxxhnew  FROM 
                                                            (
                                                            SELECT (CASE WHEN PXXH=9999 THEN 0 ELSE PXXH END) pxxhnew,*
                                                            FROM dbo.MZHS_FZJL WHERE FZKS={0} and DJSJ>='{1}' and DJSJ<'{2}' 
                                                            )  a", deptid, System.DateTime.Now.ToShortDateString() + " 12:00:00", DateTime.Now.AddDays(1).ToShortDateString() + " 23:59:59");

                pdxh = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(strSql));
                if (pdxh == 1)
                {

                    strSql = string.Format(@"SELECT *  FROM dbo.MZHS_FZJL WHERE FZKS={0} and DJSJ>='{1}' and DJSJ<'{2}'  and BJZBZ = 1  order by pxxh",
                                         deptid, System.DateTime.Now.ToShortDateString() + " 07:00:00",
                                         DateTime.Now.AddDays(1).ToShortDateString() + " 12:00:00");

                    DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql);
                    if (dt.Rows.Count > 0)
                    {
                        int ii = 1;
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            string strUpdate = string.Format(@"UPDATE MZHS_FZJL SET PXXH ={0} WHERE FZKS='{1}' ", ii, dt.Rows[i]["FZID"].ToString());
                            InstanceForm.BDatabase.DoCommand(strSql);
                            ii++;
                        }
                        pdxh = ii;
                    }
                } 
            }
            return pdxh;
        }
        /// <summary>
        /// 预约病人排队优先
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 排队优先ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateHzyx(this.ListView_Yfz);
        }
        /// <summary>
        /// 现场病人排队优先 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 排队优先ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateHzyx(this.ListView_Yfz);
        }
        /// <summary>
        /// 优先已分诊病人 add by zp
        /// </summary>
        /// <param name="view"></param>
        private void UpdateHzyx(ListView view)
        {
            try
            {
                if (view.SelectedIndices.Count == 0) { return; }
                //先得到所选择的记录
                ListViewItem item = (ListViewItem)view.SelectedItems[0];
                butref2_Click(null, null);//再刷新下已分诊病人
                if (view.Name == this.ListView_Yfz.Name)
                { 
                        ListViewItem item_one = (ListViewItem)view.Items[0];
                        /*先得到需要优先的排队时间 然后再更新比第一条时间还要小*/
                        decimal currentpdsj = Convert.ToDecimal(Convertor.IsNull(item.SubItems["排队时间"].Text.Trim(), "-1"));
                        decimal pdsj_one = Convert.ToDecimal(item_one.SubItems["排队时间"].Text.Trim());
                        decimal updatepdsj = pdsj_one - 1;
                        string fzid = item.SubItems["fzid"].Text.Trim();
                        string sql = @"update mzhs_fzjl set pdsj=" + updatepdsj + @" where fzid='" + fzid + "' ";
                        InstanceForm.BDatabase.DoCommand(sql); 
                }
//                else
//                {
//                    decimal currentpdsj = Convert.ToDecimal(Convertor.IsNull(item.SubItems["排队时间"].Text.Trim(), "-1"));

//                    string currentsd = item.SubItems["预约时段"].Text.Trim();
//                    string fzid = item.SubItems["fzid"].Text.Trim();
//                    string sql = @"SELECT TOP 1 A.PDSJ FROM MZHS_FZJL AS A 
//                    INNER JOIN MZ_YYGHLB AS B ON A.GHXXID=B.GHXXID
//                    WHERE CONVERT(VARCHAR(10),A.FZSJ,120)=CONVERT(VARCHAR(10),GETDATE(),120) 
//                    AND A.BSCBZ=0 AND B.YYSD='" + currentsd + "' ORDER BY A.PDSJ";
//                    decimal updatepdsj = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sql), "0"));
//                    updatepdsj = updatepdsj - 1;
//                    sql = @"update mzhs_fzjl set pdsj=" + updatepdsj + @" where fzid='" + fzid + "' ";
//                    InstanceForm.BDatabase.DoCommand(sql);
//                }
                BindYfzPat();
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现错误!原因:" + ea.ToString(), "错误");
            }
        }
        /// <summary>
        /// 切换科室刷新已分诊的病人列表 add by zp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindYfzPat();
        }

        /// <summary>
        /// 切换医生级别刷新已分诊病人列表 add by zp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbYfz_CheckedChanged(object sender, EventArgs e)
        {
            BindYfzPat();
        }
        /// <summary>
        /// 开启电视机 add by zp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_OpenTv_Click(object sender, EventArgs e)
        {
            try
            { 
                if (Fz_ShowSx.Frm_Open)
                {
                    MessageBox.Show("电视机显示界面已开启!不能重复开启!", "提示");
                    return;
                }
                //MessageBox.Show(this.current_zq.Xsfs.ToString());
                if (System.Windows.Forms.Screen.AllScreens.Length > 1)
                {
                    //获取副显示器
                    Screen[] screens = System.Windows.Forms.Screen.AllScreens;
                    System.Windows.Forms.Screen displayScreen = null;
                    int count = screens.Length;
                    for (int i = 0; i < count; i++)
                    {
                        if (screens[i].Primary)
                            continue;
                        else
                            displayScreen = screens[i]; break;
                    }
                    if (displayScreen == null)
                    {
                        MessageBox.Show("没有获取到用于显示的副显示屏!"); return;
                    }
                    Fz_ShowSx.Frm_Open = true; 
                    if (new SystemCfg(3103).Config == "0")
                    {
                        switch (this.current_zq.Xsfs)
                        {
                            case 0:
                                current_tvfrm = new FrmScreen(InstanceForm.BDatabase, this.current_zq, dt_ghjb);
                                break;
                            case 1:
                                current_tvfrm = new FrmScreen_Dept(InstanceForm.BDatabase, this.current_zq, dt_ghjb);
                                break;
                            default:
                                current_tvfrm = new FrmScreen_Zs(InstanceForm.BDatabase, this.current_zq, dt_ghjb);
                                break;
                        }
                    }
                    else
                    {
                        current_tvfrm = new FrmScreenSy(InstanceForm.BDatabase, this.current_zq);//this
                    }  
                  
                    current_tvfrm.Text = "";
                    current_tvfrm.StartPosition = FormStartPosition.Manual;
                    current_tvfrm.Height = displayScreen.Bounds.Height;
                    current_tvfrm.Width = displayScreen.Bounds.Width;
                    current_tvfrm.Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;//将该窗体显示在主屏幕之外
                    current_tvfrm.Top = 0;
                    current_tvfrm.FormBorderStyle = FormBorderStyle.None;
                    current_tvfrm.TopMost = true;
                    current_tvfrm.Show();

                }
                else
                {
                    if (this.current_zq.Dt_zqdept.Rows.Count < 1)
                    {
                        MessageBox.Show("诊区下的科室数目小于1!请联系管理员!", "提示");
                        return;
                    }
                    Fz_ShowSx.Frm_Open = true;
                  
                    if (new SystemCfg(3103).Config == "0")
                    {
                        switch (this.current_zq.Xsfs)
                        {
                            case 0:
                                current_tvfrm = new FrmScreen(InstanceForm.BDatabase, this.current_zq, dt_ghjb);
                                break;
                            case 1:
                                current_tvfrm = new FrmScreen_Dept(InstanceForm.BDatabase, this.current_zq, dt_ghjb);
                                break;
                            default:
                                current_tvfrm = new FrmScreen_Zs(InstanceForm.BDatabase, this.current_zq, dt_ghjb);
                                break;
                        }
                    }
                    else
                    {
                        current_tvfrm = new FrmScreenSy(InstanceForm.BDatabase, this.current_zq);//this
                    } 
                    current_tvfrm.Show();
                }

                /*刷新显示屏*/
                ServerListen.UpdateDisplay(null, this.current_zq.Zqid, InstanceForm.BDatabase);
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

        /// <summary>
        /// 更新诊区报道方式 Add By zp 2013-09-24
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_SelectBdfs frm = new Frm_SelectBdfs();
                frm.ShowDialog();

                if (!frm.flag) return;

                if (frm.fz_type)
                    this.current_zq.Zqbdfs = 1;
                else
                    this.current_zq.Zqbdfs = 0;

                if (!this.current_zq.UpdateZqInfo(this.current_zq, InstanceForm.BDatabase))
                    MessageBox.Show("更新失败!", "提示");
                else
                    MessageBox.Show("更新成功!", "提示");
            }
            catch (Exception ea)
            {
                MessageBox.Show("更新诊区报道方式出现异常!原因:" + ea.Message, "提示");
            }
        }
   

        private void 录入体征信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTzFrm(ListView_Yfz);
        }

        private void ShowTzFrm(ListView view)
        {
            try
            {
                if (view.SelectedIndices.Count == 0) { return; }
                //先得到所选择的记录
                ListViewItem item = (ListViewItem)view.SelectedItems[0];
                /*通过挂号信息id获取病人信息*/
                Guid ghxxid = new Guid(item.SubItems["ghxxid"].Text.Trim());
                Guid brxxid = Fun.GetBrxxId(ghxxid, InstanceForm.BDatabase);
                YY_BRXX _brxx = new YY_BRXX(brxxid, InstanceForm.BDatabase);
                string kh = item.SubItems["卡号"].Text.Trim();
                string nl = Age.GetAgeString(Convert.ToDateTime(_brxx.Csrq), DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0);
                string ghks = item.SubItems["挂号科室"].Text.Trim();
                string xb = "男";
                if (_brxx.Xb.Trim() == "2")
                    xb = "女";
                if (_brxx.Xb.Trim() != "1" && _brxx.Xb.Trim() != "2")
                    xb = "未知";
                FrmFz_Tzlr frm = new FrmFz_Tzlr(_brxx.Brxm, kh, ghks, xb, nl, ghxxid, _brxx.Brxxid);
                frm.ShowDialog();
            }
            catch (Exception ea)
            {
                MessageBox.Show("出现异常!原因:" + ea.Message, "提示");
            }
        }

        private void 录入体征信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowTzFrm(this.ListView_Yfz);
        }

        private void 病人转诊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowZzFrm(ListView_Yfz);
        }

        private void ShowZzFrm(ListView view)
        {
               if (view.SelectedIndices.Count == 0) { return; }
                //先得到所选择的记录
                ListViewItem item = (ListViewItem)view.SelectedItems[0];
                /*通过挂号信息id获取病人信息*/
                Guid ghxxid = new Guid(item.SubItems["ghxxid"].Text.Trim());

                frmzz frm = new frmzz(ghxxid, this.current_zq);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    butref1_Click(null, null);
                }
        }

        private void 病人转诊ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowZzFrm(ListView_Yfz);
        }

        private void 病人转诊ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.TabContrl_Wfz.SelectedTab.Name.Trim() == "TabPgWfz_YyInfo")
                ShowZzFrm(ListView_Wfz_Yy);
            //else
            //    ShowZzFrm(listView1);
        } 
       
        private void 门急诊录入ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListView view = ListView_Yfz;
            if (view.SelectedIndices.Count == 0) { return; }
            //先得到所选择的记录
            ListViewItem item = (ListViewItem)view.SelectedItems[0];
            /*通过挂号信息id获取病人信息*/
            string blh = item.SubItems["门诊号"].Text.Trim();

            ts_mz_rizhi.InstanceForm InstanceForm = new ts_mz_rizhi.InstanceForm();

            InstanceForm.Database = TrasenFrame.Forms.FrmMdiMain.Database;

            InstanceForm.CurrentDept = TrasenFrame.Forms.FrmMdiMain.CurrentDept;
            InstanceForm.CurrentUser = TrasenFrame.Forms.FrmMdiMain.CurrentUser;
            MZ_RZ frm = new MZ_RZ("门诊急诊录入", _menuTag, blh);
            frm.ShowDialog();
            //if (frm.DialogResult == DialogResult.OK)
            //{
            //    butref2_Click(null, null);
            //} 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Enabled = false;
            RelationalDatabase Database = new MsSqlServer();
            Database.Initialize(InstanceForm.BDatabase.ConnectionString);
            try
            {
              
                string rq1 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00";
                string rq2 = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59";
                int klx = 0;
                string kh = "";
                string blh = "";
                int sort = 0;
                if (new SystemCfg(3069).Config == "0")
                {
                    int hour = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select DATEPART(hh, GETDATE())"));
                    if (hour >= 8 && hour <= 12)
                        sort = 1;
                    else if (hour > 12 && hour < 18)
                        sort = 2;
                }
                //if (new SystemCfg(3103).Config == "1") sort = 0;
                DataSet ds = MZHS_FZJL.Select_WfzPat(current_zq.Zqid, rq1, rq2, klx, kh, blh, sort, Database);
                DataTable dt = ds.Tables[0];
                //Modify by zp 2013-11-05 将预约与现场病人队列合并
                //DataTable dt_yyinfo = ds.Tables[2];
                //AddWfzList(dt_xcinfo, this.listView1);
                AddWfzList(dt, this.ListView_Wfz_Yy);
                this.TabPgWfz_YyInfo.Text = "候诊病人列表 " + dt.Rows.Count + "人";
                Database.Close();
                Database.Dispose();
                this.Enabled = true; ;
            }
            catch
            {
                Database.Close();
                Database.Dispose();
                this.Enabled = true; ;
            }
        } 
    }
}