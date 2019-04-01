using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using TszyHIS;
using HospitalManage.Services;
using TrasenHIS.BLL;

namespace ts_zyhs_yzgl
{
    /// <summary>
    /// 医嘱管理 的摘要说明。
    /// </summary>
    public class frmYZGL : System.Windows.Forms.Form
    {

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        /// 


        //自定义变量==============================================		
        private BaseFunc myFunc;

        string binSql = "";
        bool isSSMZ = false;
        bool isTSZL = false;//Modify By tany 2010-03-10
        bool isCX = false;//是否查询
        int ssmzType = 0;//0=手术 1=麻醉
        string sPaint = "", sPaintPS = "", sPaintWZX = "", sName = "";
        int max_len0 = 0, max_len1 = 0, max_len2 = 0;//最长的医嘱长度,最长的医嘱长度(有数量单位的),最长的数量单位长度		
        decimal orderfee = 0;
        /// <summary>
        /// 护士站医嘱管理是否允许术前医嘱打印 0=不是,1=是
        /// </summary>
        SystemCfg cfg7111;
        SystemCfg cfg7129;
        SystemCfg cfg7160 = new SystemCfg(7160);//病人所在科室开具出院医嘱后，病人正在进行的特殊治疗科室是否可以进行冲正操作，0：否；1：是
        SystemCfg cfg7159 = new SystemCfg(7159);
        /// <summary>
        /// 医保病人的欠费控制是否按照医保实时试算结果进行欠费控制  0=否 1=是
        /// </summary>
        SystemCfg cfg7186 = new SystemCfg(7186);

        //Add By Tany 2015-05-04
        string functionName = "";

        //Add By Tany 2015-11-17
        DateTime sysDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd"));

        private TheReportDateSet rds = new TheReportDateSet();
        private DataRow dr;
        private Panel ReasenPanel;
        private System.Windows.Forms.Panel panel总;
        private System.Windows.Forms.Panel panel右;
        private System.Windows.Forms.Panel panel右上;
        private System.Windows.Forms.Panel panel右下;
        private System.Windows.Forms.Button bt详细信息;
        private System.Windows.Forms.Button bt医嘱打印;
        private System.Windows.Forms.Button bt立即执行;
        private System.Windows.Forms.Button bt退出;
        private 价格信息.PriceInfo priceInfo1;
        private 病人信息.PatientInfo patientInfo1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DataGridEx myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private DataGridEx myDataGrid3;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
        private System.Windows.Forms.Button bt未执行;
        private System.Windows.Forms.Button bt阳性;
        private System.Windows.Forms.Button bt阴性;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Button bt取消停医嘱核对;
        private System.Windows.Forms.Button bt取消停医嘱转抄;
        private System.Windows.Forms.Button bt取消开医嘱核对;
        private System.Windows.Forms.Button bt取消开医嘱转抄;
        private System.Windows.Forms.Button bt显示切换;
        private System.Windows.Forms.Button bt全选;
        private System.Windows.Forms.Button bt反选;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.ContextMenu contextMenu2;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbIn;
        private System.Windows.Forms.RadioButton rbOut;
        private System.Windows.Forms.ComboBox cmbWard;
        private System.Windows.Forms.RadioButton rbTempOut;
        private System.Windows.Forms.RadioButton rb显示病人列表;
        private System.Windows.Forms.RadioButton rb隐藏病人列表;
        private System.Windows.Forms.Button bt执行时间;
        private ContextMenu contextMenu3;
        private MenuItem menuItem7;
        private MenuItem menuItem8;
        private MenuItem menuItem9;
        private Button bt预算;
        private Button butorderprint;
        private RadioButton rbTszl;
        private RadioButton rbTrans;
        private SplitContainer splitContainer1;
        private Label label3;
        private Label label2;
        private Label label1;
        private ContextMenuStrip contextMenuSerch;
        private ToolStripMenuItem 查询ToolStripMenuItem;
        private Button btnSqyzdy;
        private ContextMenuStrip contextMenuSqm;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem 取消双签名ToolStripMenuItem;
        private ImageList imageList1;
        private Button BtnTszlZcQm;
        private ToolStripMenuItem 删除执行时间ToolStripMenuItem;
        private IContainer components;
        private Button btnCheck;
        private ToolStripMenuItem 单个签名ToolStripMenuItem;
        private ContextMenuStrip contextMenuSP;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private TabControl tabControl2;
        private TabPage tabPage5;
        private TabPage tabPage10;
        private UCWzxm ucWzxm1;
        private RadioButton rbTkxs;

        private Panel panel5;
        private Trasen.Controls.ShowCardComponent showCardComponent1;
        private Trasen.Controls.LabelTextBox txt_yz;
        private CheckBox che_yz;
        private CheckBox che_date;
        private ComboBox cmb_date;
        private TabControl tabControl1;
        private UcShowCard ucShowCard1;
        private Label label4;
        private CheckBox chkWardOrder;
        private CheckBox chkShowAllSMYz;

        //add by jchl(pivas 是否审方才能发送判断)
        string cfg7605 = new SystemCfg(7605).Config;
        string cfg7602 = new SystemCfg(7602).Config;
        private Button btSsmzwc;
        private Label lblSsMzFee;
        private Label label5;
        private Label label6;
        private CheckBox chkSsyz;
        private Panel panel6;
        private CheckBox chkGwyp;

        /// <summary>
        /// 冲正不产生发药
        /// </summary>
        private bool zczyz_notfy = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_formText">名称</param>
        /// <param name="_isTszl">是否特殊治疗0=不是1=是</param>
        public frmYZGL(string _formText, int _isTszl)
        {
            isSSMZ = false;

            isTSZL = _isTszl == 0 ? false : true;
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;

            myFunc = new BaseFunc();
            if (!isTSZL)
            {
                //binSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                //    "   FROM vi_zy_vInpatient_Bed " +
                //    "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY dbo.Fun_GetBedToOrder( (case when left( bed_no,1)='+' then '999'+ bed_no else  bed_no end) ),Baby_ID";
                binSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                  "   FROM vi_zy_vInpatient_Bed " +
                  "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
            }
            else
            {
                binSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS 住院号 " +
                    "   FROM vi_zy_vInpatient_Bed " +
                    "  WHERE inpatient_id in (select inpatient_id from ZY_TS_APPLY where status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002) and (ts_dept = " + InstanceForm.BCurrentDept.DeptId + " or ts_dept in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "'))) " +
                    "  ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
            }
            LoadWard();

            if (!isSSMZ && !isCX && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage1);
                this.tabControl1.Controls.Add(this.tabPage2);
                this.tabControl1.Controls.Add(this.tabPage3);
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (!isSSMZ && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage6);
                this.tabControl1.Controls.Add(this.tabPage8);
            }
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);

            if (isTSZL)
            {
                rbTszl.Checked = true;

                rbIn.Enabled = false;
                rbOut.Enabled = false;
                rbTempOut.Enabled = false;
                rbTrans.Enabled = false;
                //add by zouchihua 2012-4-27 特殊治疗病人转抄签名
                if (rbTszl.Checked)
                    this.BtnTszlZcQm.Visible = true;
                else
                    this.BtnTszlZcQm.Visible = false;
            }
            //核对签名
            if (isTSZL || isSSMZ)
            {
                btnCheck.Visible = true;
            }
            else
                btnCheck.Visible = false;
        }


        /// <summary>
        /// 出区病人，只能冲正药品，并且不产生费用 add by zouchihua 2013-9-11
        /// </summary>
        /// <param name="_formText">名称</param>
        /// <param name="_isTszl">是否特殊治疗0=不是1=是</param>
        public frmYZGL(string _formText, int _isTszl, bool _zczyz)
        {
            isSSMZ = false;
            zczyz_notfy = _zczyz;
            isTSZL = _isTszl == 0 ? false : true;
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;
            DataTable myTb = new DataTable();
            string sSql = "";

            cmbWard.Items.Clear();
            cmbWard.DataSource = null;

            cmbWard.SelectedIndexChanged -= new EventHandler(cmbWard_SelectedIndexChanged);
            sSql = "select WARD_ID,WARD_NAME from jc_ward where jgbm=" + FrmMdiMain.Jgbm + " order by ward_id";
            myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            cmbWard.DataSource = myTb;
            cmbWard.DisplayMember = "WARD_NAME";
            cmbWard.ValueMember = "WARD_ID";
            cmbWard.SelectedIndexChanged += new EventHandler(cmbWard_SelectedIndexChanged);

            myFunc = new BaseFunc();
            binSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                "   FROM vi_zy_vInpatient_Bed " +
                "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";



            if (!isSSMZ && !isCX && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage1);
                this.tabControl1.Controls.Add(this.tabPage2);
                this.tabControl1.Controls.Add(this.tabPage3);
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (!isSSMZ && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage6);
                this.tabControl1.Controls.Add(this.tabPage8);
            }
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);

            //if (isTSZL)
            {
                rbTempOut.Checked = true;
                rbTszl.Checked = false;

                rbIn.Enabled = false;
                rbOut.Enabled = false;
                rbTszl.Enabled = false;
                rbTrans.Enabled = false;
            }
        }
        /// <summary>
        /// 单病人
        /// </summary>
        /// <param name="_formText">名称</param>
        /// <param name="_isTszl">是否特殊治疗0=不是1=是</param>
        /// <param name="_inpatientId">病人ID</param>
        public frmYZGL(string _formText, int _isTszl, Guid _inpatientId)
        {
            isSSMZ = false;

            isTSZL = _isTszl == 0 ? false : true;
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;

            myFunc = new BaseFunc();

            binSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                "   FROM vi_zy_vInpatient_all " +
                "  WHERE inpatient_id= '" + _inpatientId + "' and flag<>10 ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";

            LoadWard();

            if (!isSSMZ && !isCX && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage1);
                this.tabControl1.Controls.Add(this.tabPage2);
                this.tabControl1.Controls.Add(this.tabPage3);
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (!isSSMZ && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage6);
                this.tabControl1.Controls.Add(this.tabPage8);
            }
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);

            if (isTSZL)
            {
                rbTszl.Checked = true;

                rbIn.Enabled = false;
                rbOut.Enabled = false;
                rbTempOut.Enabled = false;
                rbTrans.Enabled = false;
                //add by zouchihua 2012-4-27 特殊治疗病人转抄签名
                if (rbTszl.Checked)
                    this.BtnTszlZcQm.Visible = true;
                else
                    this.BtnTszlZcQm.Visible = false;
            }
            //核对签名
            if (isTSZL || isSSMZ)
            {
                btnCheck.Visible = true;
            }
            else
                btnCheck.Visible = false;
        }


        /// <summary>
        /// 单病人查询
        /// </summary>
        /// <param name="_formText">名称</param>
        /// <param name="_isTszl">是否特殊治疗0=不是1=是</param>
        /// <param name="_inpatientId">病人ID</param>
        public frmYZGL(string _formText, int _isTszl, Guid _inpatientId, bool _iscx)
        {
            isSSMZ = false;
            isCX = _iscx;
            isTSZL = _isTszl == 0 ? false : true;
            isTSZL = false;
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;

            myFunc = new BaseFunc();
            binSql = @" SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end 医保类型,BRLX_NAME 病人类型,XZLX_NAME 险种类型,DYLX_NAME 待遇类型,flag,WARD_ID " +
                "   FROM vi_zy_vInpatient_all " +
                "  WHERE inpatient_id= '" + _inpatientId + "' and flag<>10 ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";

            LoadWard();

            //add by yaokx 默认选中
            DataTable myTb = InstanceForm.BDatabase.GetDataTable(binSql);
            if (myTb.Rows.Count > 0)
            {
                if (myTb.Rows[0]["flag"].ToString() == "4")//出区
                {
                    this.rbTempOut.Checked = true;
                }
                else if (myTb.Rows[0]["flag"].ToString() == "2" || myTb.Rows[0]["flag"].ToString() == "6")//出院
                {
                    this.rbOut.Checked = true;
                }
                this.groupBox1.Enabled = false;
                cmbWard.SelectedIndexChanged -= new EventHandler(cmbWard_SelectedIndexChanged);
                this.cmbWard.SelectedValue = myTb.Rows[0]["WARD_ID"].ToString();
            }
            if (!isSSMZ && !isCX && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage1);
                this.tabControl1.Controls.Add(this.tabPage2);
                this.tabControl1.Controls.Add(this.tabPage3);
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (!isSSMZ && !isTSZL)
            {
                this.tabControl1.Controls.Add(this.tabPage6);
                this.tabControl1.Controls.Add(this.tabPage8);
            }
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);

            if (isTSZL)
            {
                rbTszl.Checked = true;
                rbIn.Enabled = false;
                rbOut.Enabled = false;
                rbTempOut.Enabled = false;
                rbTrans.Enabled = false;
                //add by zouchihua 2012-4-27 特殊治疗病人转抄签名
                if (rbTszl.Checked)
                    this.BtnTszlZcQm.Visible = true;
                else
                    this.BtnTszlZcQm.Visible = false;
            }
            //核对签名
            if (isTSZL || isSSMZ)
            {
                btnCheck.Visible = true;
            }
            else
                btnCheck.Visible = false;
        }

        /// <summary>
        /// 手术麻醉使用
        /// </summary>
        /// <param name="_formText"></param>
        /// <param name="_curDeptId"></param>
        /// <param name="_curUserId"></param>
        public frmYZGL(string _formText, string sSql, int nType, string _functionName)
        {
            isSSMZ = true;
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码            //
            this.Text = _formText;
            functionName = _functionName; //Add By Tany 2015-05-04
            myFunc = new BaseFunc();
            binSql = sSql;
            ssmzType = nType;
            LoadWard();

            if (!isSSMZ && !isCX)
            {
                this.tabControl1.Controls.Add(this.tabPage1);
                this.tabControl1.Controls.Add(this.tabPage2);
                this.tabControl1.Controls.Add(this.tabPage3);
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (!isSSMZ)
            {
                //this.tabControl1.Controls.Add(this.tabPage6);
                this.tabControl1.Controls.Add(this.tabPage8);
            }
            //pengyang 2015-7-28
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);
            bt取消开医嘱核对.EnabledChanged += new EventHandler(bt取消开医嘱核对_EnabledChanged);
        }

        /// <summary>
        /// 医嘱查询
        /// </summary>
        /// <param name="_formText"></param>
        /// <param name="_curDeptId"></param>
        /// <param name="_curUserId"></param>
        public frmYZGL(string _formText, bool _isCX)
        {
            isCX = _isCX;
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;

            myFunc = new BaseFunc();

            LoadWard();

            cmbWard.SelectedIndex = 0;

            binSql = @" SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end 医保类型,BRLX_NAME 病人类型,XZLX_NAME 险种类型,DYLX_NAME 待遇类型 " +
                "   FROM vi_zy_vInpatient_Bed " +
                "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' ORDER BY INPATIENT_NO,Baby_ID";

            if (!isSSMZ && !isCX)
            {
                this.tabControl1.Controls.Add(this.tabPage1);
                this.tabControl1.Controls.Add(this.tabPage2);
                this.tabControl1.Controls.Add(this.tabPage3);
                this.tabControl1.Controls.Add(this.tabPage4);
            }
            if (!isSSMZ)
            {
                this.tabControl1.Controls.Add(this.tabPage6);
                this.tabControl1.Controls.Add(this.tabPage8);
            }
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage9);
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Trasen.Controls.ShowCardProperty showCardProperty1 = new Trasen.Controls.ShowCardProperty();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYZGL));
            this.panel总 = new System.Windows.Forms.Panel();
            this.panel右 = new System.Windows.Forms.Panel();
            this.panel右上 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.contextMenuSerch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ucShowCard1 = new ts_zyhs_classes.UcShowCard();
            this.rbTkxs = new System.Windows.Forms.RadioButton();
            this.rbTszl = new System.Windows.Forms.RadioButton();
            this.rbTrans = new System.Windows.Forms.RadioButton();
            this.cmbWard = new System.Windows.Forms.ComboBox();
            this.rbOut = new System.Windows.Forms.RadioButton();
            this.rbTempOut = new System.Windows.Forms.RadioButton();
            this.rbIn = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btSsmzwc = new System.Windows.Forms.Button();
            this.bt反选 = new System.Windows.Forms.Button();
            this.btnSqyzdy = new System.Windows.Forms.Button();
            this.bt全选 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rb隐藏病人列表 = new System.Windows.Forms.RadioButton();
            this.rb显示病人列表 = new System.Windows.Forms.RadioButton();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel右下 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.bt立即执行 = new System.Windows.Forms.Button();
            this.bt预算 = new System.Windows.Forms.Button();
            this.bt执行时间 = new System.Windows.Forms.Button();
            this.contextMenuSqm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.取消双签名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除执行时间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单个签名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCheck = new System.Windows.Forms.Button();
            this.bt未执行 = new System.Windows.Forms.Button();
            this.bt取消开医嘱转抄 = new System.Windows.Forms.Button();
            this.bt退出 = new System.Windows.Forms.Button();
            this.bt取消停医嘱转抄 = new System.Windows.Forms.Button();
            this.butorderprint = new System.Windows.Forms.Button();
            this.bt详细信息 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.bt阳性 = new System.Windows.Forms.Button();
            this.contextMenuSP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnTszlZcQm = new System.Windows.Forms.Button();
            this.bt阴性 = new System.Windows.Forms.Button();
            this.bt医嘱打印 = new System.Windows.Forms.Button();
            this.contextMenu3 = new System.Windows.Forms.ContextMenu();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.bt取消开医嘱核对 = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.bt取消停医嘱核对 = new System.Windows.Forms.Button();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.myDataGrid3 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.ucWzxm1 = new ts_zyhs_yzgl.UCWzxm();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.patientInfo1 = new 病人信息.PatientInfo();
            this.priceInfo1 = new 价格信息.PriceInfo();
            this.bt显示切换 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkGwyp = new System.Windows.Forms.CheckBox();
            this.chkSsyz = new System.Windows.Forms.CheckBox();
            this.lblSsMzFee = new System.Windows.Forms.Label();
            this.chkWardOrder = new System.Windows.Forms.CheckBox();
            this.txt_yz = new Trasen.Controls.LabelTextBox();
            this.showCardComponent1 = new Trasen.Controls.ShowCardComponent();
            this.che_yz = new System.Windows.Forms.CheckBox();
            this.che_date = new System.Windows.Forms.CheckBox();
            this.cmb_date = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ReasenPanel = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.chkShowAllSMYz = new System.Windows.Forms.CheckBox();
            this.panel总.SuspendLayout();
            this.panel右.SuspendLayout();
            this.panel右上.SuspendLayout();
            this.panel4.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.contextMenuSerch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel右下.SuspendLayout();
            this.panel6.SuspendLayout();
            this.contextMenuSqm.SuspendLayout();
            this.contextMenuSP.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).BeginInit();
            this.tabPage10.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel总
            // 
            this.panel总.Controls.Add(this.panel右);
            this.panel总.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel总.Location = new System.Drawing.Point(0, 0);
            this.panel总.Name = "panel总";
            this.panel总.Size = new System.Drawing.Size(1160, 483);
            this.panel总.TabIndex = 0;
            // 
            // panel右
            // 
            this.panel右.Controls.Add(this.panel右上);
            this.panel右.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel右.Location = new System.Drawing.Point(0, 0);
            this.panel右.Name = "panel右";
            this.panel右.Size = new System.Drawing.Size(1160, 483);
            this.panel右.TabIndex = 2;
            // 
            // panel右上
            // 
            this.panel右上.Controls.Add(this.panel4);
            this.panel右上.Controls.Add(this.panel1);
            this.panel右上.Controls.Add(this.bt显示切换);
            this.panel右上.Controls.Add(this.panel5);
            this.panel右上.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel右上.Location = new System.Drawing.Point(0, 0);
            this.panel右上.Name = "panel右上";
            this.panel右上.Size = new System.Drawing.Size(1160, 483);
            this.panel右上.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitContainer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1160, 272);
            this.panel4.TabIndex = 81;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1160, 272);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myDataGrid2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(202, 272);
            this.panel3.TabIndex = 26;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.AllowSorting = false;
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.MediumSeaGreen;
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.ContextMenuStrip = this.contextMenuSerch;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 99);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.RowHeaderWidth = 20;
            this.myDataGrid2.Size = new System.Drawing.Size(202, 173);
            this.myDataGrid2.TabIndex = 23;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid2.Tag = "";
            this.myDataGrid2.CurrentCellChanged += new System.EventHandler(this.myDataGrid2_CurrentCellChanged);
            // 
            // contextMenuSerch
            // 
            this.contextMenuSerch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询ToolStripMenuItem});
            this.contextMenuSerch.Name = "contextMenuSerch";
            this.contextMenuSerch.Size = new System.Drawing.Size(95, 26);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ucShowCard1);
            this.groupBox1.Controls.Add(this.rbTkxs);
            this.groupBox1.Controls.Add(this.rbTszl);
            this.groupBox1.Controls.Add(this.rbTrans);
            this.groupBox1.Controls.Add(this.cmbWard);
            this.groupBox1.Controls.Add(this.rbOut);
            this.groupBox1.Controls.Add(this.rbTempOut);
            this.groupBox1.Controls.Add(this.rbIn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 99);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "检索";
            // 
            // ucShowCard1
            // 
            this.ucShowCard1.IType = 0;
            this.ucShowCard1.Key = "";
            this.ucShowCard1.Location = new System.Drawing.Point(36, 76);
            this.ucShowCard1.Name = "ucShowCard1";
            this.ucShowCard1.Row = null;
            this.ucShowCard1.Size = new System.Drawing.Size(135, 21);
            this.ucShowCard1.TabIndex = 7;
            this.ucShowCard1.Value = "";
            this.ucShowCard1.MyDelEvent += new ts_zyhs_classes.UcShowCard.MyDel(this.ucShowCard1_MyDelEvent);
            // 
            // rbTkxs
            // 
            this.rbTkxs.Location = new System.Drawing.Point(118, 28);
            this.rbTkxs.Name = "rbTkxs";
            this.rbTkxs.Size = new System.Drawing.Size(53, 24);
            this.rbTkxs.TabIndex = 6;
            this.rbTkxs.Text = "他科";
            this.rbTkxs.Click += new System.EventHandler(this.rb_Click);
            // 
            // rbTszl
            // 
            this.rbTszl.Location = new System.Drawing.Point(48, 28);
            this.rbTszl.Name = "rbTszl";
            this.rbTszl.Size = new System.Drawing.Size(74, 24);
            this.rbTszl.TabIndex = 5;
            this.rbTszl.Text = "特殊治疗";
            this.rbTszl.Click += new System.EventHandler(this.rb_Click);
            // 
            // rbTrans
            // 
            this.rbTrans.Location = new System.Drawing.Point(5, 28);
            this.rbTrans.Name = "rbTrans";
            this.rbTrans.Size = new System.Drawing.Size(57, 24);
            this.rbTrans.TabIndex = 4;
            this.rbTrans.Text = "转科";
            this.rbTrans.Click += new System.EventHandler(this.rb_Click);
            // 
            // cmbWard
            // 
            this.cmbWard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWard.Location = new System.Drawing.Point(5, 52);
            this.cmbWard.Name = "cmbWard";
            this.cmbWard.Size = new System.Drawing.Size(192, 20);
            this.cmbWard.TabIndex = 0;
            this.cmbWard.SelectedIndexChanged += new System.EventHandler(this.cmbWard_SelectedIndexChanged);
            // 
            // rbOut
            // 
            this.rbOut.Location = new System.Drawing.Point(90, 9);
            this.rbOut.Name = "rbOut";
            this.rbOut.Size = new System.Drawing.Size(48, 24);
            this.rbOut.TabIndex = 3;
            this.rbOut.Text = "出院";
            this.rbOut.Click += new System.EventHandler(this.rb_Click);
            // 
            // rbTempOut
            // 
            this.rbTempOut.Location = new System.Drawing.Point(48, 9);
            this.rbTempOut.Name = "rbTempOut";
            this.rbTempOut.Size = new System.Drawing.Size(48, 24);
            this.rbTempOut.TabIndex = 2;
            this.rbTempOut.Text = "出区";
            this.rbTempOut.Click += new System.EventHandler(this.rb_Click);
            // 
            // rbIn
            // 
            this.rbIn.Checked = true;
            this.rbIn.Location = new System.Drawing.Point(5, 9);
            this.rbIn.Name = "rbIn";
            this.rbIn.Size = new System.Drawing.Size(57, 24);
            this.rbIn.TabIndex = 1;
            this.rbIn.TabStop = true;
            this.rbIn.Text = "在院";
            this.rbIn.Click += new System.EventHandler(this.rb_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btSsmzwc);
            this.panel2.Controls.Add(this.bt反选);
            this.panel2.Controls.Add(this.btnSqyzdy);
            this.panel2.Controls.Add(this.bt全选);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rb隐藏病人列表);
            this.panel2.Controls.Add(this.rb显示病人列表);
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 272);
            this.panel2.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label6.ForeColor = System.Drawing.Color.Fuchsia;
            this.label6.Location = new System.Drawing.Point(244, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 98;
            this.label6.Text = "紫红色：皮试医嘱";
            // 
            // btSsmzwc
            // 
            this.btSsmzwc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSsmzwc.BackColor = System.Drawing.Color.PaleGreen;
            this.btSsmzwc.Location = new System.Drawing.Point(649, 2);
            this.btSsmzwc.Name = "btSsmzwc";
            this.btSsmzwc.Size = new System.Drawing.Size(94, 20);
            this.btSsmzwc.TabIndex = 96;
            this.btSsmzwc.Text = "手术麻醉完成";
            this.btSsmzwc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSsmzwc.UseVisualStyleBackColor = false;
            this.btSsmzwc.Visible = false;
            this.btSsmzwc.Click += new System.EventHandler(this.btSsmzwc_Click);
            // 
            // bt反选
            // 
            this.bt反选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt反选.BackColor = System.Drawing.Color.PaleGreen;
            this.bt反选.Location = new System.Drawing.Point(900, 2);
            this.bt反选.Name = "bt反选";
            this.bt反选.Size = new System.Drawing.Size(56, 20);
            this.bt反选.TabIndex = 79;
            this.bt反选.Text = "反选(&F)";
            this.bt反选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt反选.UseVisualStyleBackColor = false;
            this.bt反选.Click += new System.EventHandler(this.bt反选_Click);
            // 
            // btnSqyzdy
            // 
            this.btnSqyzdy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSqyzdy.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSqyzdy.Location = new System.Drawing.Point(743, 2);
            this.btnSqyzdy.Name = "btnSqyzdy";
            this.btnSqyzdy.Size = new System.Drawing.Size(97, 20);
            this.btnSqyzdy.TabIndex = 82;
            this.btnSqyzdy.Text = "术前执行单打印(&P)";
            this.btnSqyzdy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSqyzdy.UseVisualStyleBackColor = false;
            this.btnSqyzdy.Visible = false;
            this.btnSqyzdy.Click += new System.EventHandler(this.btnSqyzdy_Click);
            // 
            // bt全选
            // 
            this.bt全选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt全选.BackColor = System.Drawing.Color.PaleGreen;
            this.bt全选.Location = new System.Drawing.Point(843, 2);
            this.bt全选.Name = "bt全选";
            this.bt全选.Size = new System.Drawing.Size(56, 20);
            this.bt全选.TabIndex = 78;
            this.bt全选.Text = "全选(&A)";
            this.bt全选.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt全选.UseVisualStyleBackColor = false;
            this.bt全选.Click += new System.EventHandler(this.bt全选_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(533, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 12);
            this.label5.TabIndex = 97;
            this.label5.Text = "桔色：说明医嘱";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(145, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 95;
            this.label3.Text = "蓝色：当前未执行";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(364, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 12);
            this.label2.TabIndex = 94;
            this.label2.Text = "灰色：长嘱停止 临嘱执行完成";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(247, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 12);
            this.label1.TabIndex = 93;
            this.label1.Text = "红色：当天已经执行";
            // 
            // rb隐藏病人列表
            // 
            this.rb隐藏病人列表.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb隐藏病人列表.Location = new System.Drawing.Point(32, 3);
            this.rb隐藏病人列表.Name = "rb隐藏病人列表";
            this.rb隐藏病人列表.Size = new System.Drawing.Size(127, 18);
            this.rb隐藏病人列表.TabIndex = 92;
            this.rb隐藏病人列表.Text = "隐藏病人列表(F3)";
            this.rb隐藏病人列表.UseVisualStyleBackColor = false;
            this.rb隐藏病人列表.Visible = false;
            this.rb隐藏病人列表.Click += new System.EventHandler(this.rb显示病人列表_Click);
            // 
            // rb显示病人列表
            // 
            this.rb显示病人列表.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb显示病人列表.Checked = true;
            this.rb显示病人列表.Location = new System.Drawing.Point(11, 3);
            this.rb显示病人列表.Name = "rb显示病人列表";
            this.rb显示病人列表.Size = new System.Drawing.Size(127, 18);
            this.rb显示病人列表.TabIndex = 91;
            this.rb显示病人列表.TabStop = true;
            this.rb显示病人列表.Text = "显示病人列表(F2)";
            this.rb显示病人列表.UseVisualStyleBackColor = false;
            this.rb显示病人列表.Visible = false;
            this.rb显示病人列表.Click += new System.EventHandler(this.rb显示病人列表_Click);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(956, 272);
            this.myDataGrid1.TabIndex = 24;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.myDataGrid1_Paint);
            this.myDataGrid1.DoubleClick += new System.EventHandler(this.myDataGrid1_DoubleClick);
            this.myDataGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myDataGrid1_MouseUp);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.myKeyDown += new TrasenClasses.GeneralControls.myDelegate(this.myDataGrid1_myKeyDown);
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel右下);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 183);
            this.panel1.TabIndex = 80;
            // 
            // panel右下
            // 
            this.panel右下.Controls.Add(this.panel6);
            this.panel右下.Controls.Add(this.tabControl2);
            this.panel右下.Controls.Add(this.progressBar1);
            this.panel右下.Controls.Add(this.patientInfo1);
            this.panel右下.Controls.Add(this.priceInfo1);
            this.panel右下.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel右下.Location = new System.Drawing.Point(0, 0);
            this.panel右下.Name = "panel右下";
            this.panel右下.Size = new System.Drawing.Size(1160, 183);
            this.panel右下.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.bt立即执行);
            this.panel6.Controls.Add(this.bt预算);
            this.panel6.Controls.Add(this.bt执行时间);
            this.panel6.Controls.Add(this.btnCheck);
            this.panel6.Controls.Add(this.bt未执行);
            this.panel6.Controls.Add(this.bt取消开医嘱转抄);
            this.panel6.Controls.Add(this.bt退出);
            this.panel6.Controls.Add(this.bt取消停医嘱转抄);
            this.panel6.Controls.Add(this.butorderprint);
            this.panel6.Controls.Add(this.bt详细信息);
            this.panel6.Controls.Add(this.btnDelete);
            this.panel6.Controls.Add(this.bt阳性);
            this.panel6.Controls.Add(this.BtnTszlZcQm);
            this.panel6.Controls.Add(this.bt阴性);
            this.panel6.Controls.Add(this.bt医嘱打印);
            this.panel6.Controls.Add(this.bt取消开医嘱核对);
            this.panel6.Controls.Add(this.bt取消停医嘱核对);
            this.panel6.Location = new System.Drawing.Point(-2, -3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1276, 27);
            this.panel6.TabIndex = 76;
            // 
            // bt立即执行
            // 
            this.bt立即执行.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt立即执行.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt立即执行.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt立即执行.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt立即执行.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt立即执行.ImageIndex = 9;
            this.bt立即执行.Location = new System.Drawing.Point(2, 2);
            this.bt立即执行.Name = "bt立即执行";
            this.bt立即执行.Size = new System.Drawing.Size(61, 24);
            this.bt立即执行.TabIndex = 47;
            this.bt立即执行.Text = "发送(&S)";
            this.bt立即执行.Click += new System.EventHandler(this.bt立即执行_Click);
            // 
            // bt预算
            // 
            this.bt预算.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt预算.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt预算.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt预算.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt预算.ImageIndex = 9;
            this.bt预算.Location = new System.Drawing.Point(64, 2);
            this.bt预算.Name = "bt预算";
            this.bt预算.Size = new System.Drawing.Size(61, 24);
            this.bt预算.TabIndex = 71;
            this.bt预算.Text = "预算(&Y)";
            this.bt预算.Click += new System.EventHandler(this.bt预算_Click);
            // 
            // bt执行时间
            // 
            this.bt执行时间.ContextMenuStrip = this.contextMenuSqm;
            this.bt执行时间.Enabled = false;
            this.bt执行时间.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt执行时间.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt执行时间.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt执行时间.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt执行时间.ImageIndex = 9;
            this.bt执行时间.Location = new System.Drawing.Point(796, 2);
            this.bt执行时间.Name = "bt执行时间";
            this.bt执行时间.Size = new System.Drawing.Size(84, 24);
            this.bt执行时间.TabIndex = 70;
            this.bt执行时间.Text = "执行时间(&T)";
            this.bt执行时间.Click += new System.EventHandler(this.bt执行时间_Click);
            this.bt执行时间.EnabledChanged += new System.EventHandler(this.bt执行时间_EnabledChanged);
            // 
            // contextMenuSqm
            // 
            this.contextMenuSqm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.取消双签名ToolStripMenuItem,
            this.删除执行时间ToolStripMenuItem,
            this.单个签名ToolStripMenuItem});
            this.contextMenuSqm.Name = "contextMenuSerch";
            this.contextMenuSqm.Size = new System.Drawing.Size(143, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItem1.Text = "双签名";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 取消双签名ToolStripMenuItem
            // 
            this.取消双签名ToolStripMenuItem.Name = "取消双签名ToolStripMenuItem";
            this.取消双签名ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.取消双签名ToolStripMenuItem.Text = "取消双签名";
            this.取消双签名ToolStripMenuItem.Click += new System.EventHandler(this.取消双签名ToolStripMenuItem_Click);
            // 
            // 删除执行时间ToolStripMenuItem
            // 
            this.删除执行时间ToolStripMenuItem.Name = "删除执行时间ToolStripMenuItem";
            this.删除执行时间ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.删除执行时间ToolStripMenuItem.Text = "删除执行时间";
            this.删除执行时间ToolStripMenuItem.Click += new System.EventHandler(this.删除执行时间ToolStripMenuItem_Click);
            // 
            // 单个签名ToolStripMenuItem
            // 
            this.单个签名ToolStripMenuItem.Name = "单个签名ToolStripMenuItem";
            this.单个签名ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.单个签名ToolStripMenuItem.Text = "单个签名";
            this.单个签名ToolStripMenuItem.Click += new System.EventHandler(this.单个签名ToolStripMenuItem_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnCheck.Location = new System.Drawing.Point(440, 2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(67, 24);
            this.btnCheck.TabIndex = 74;
            this.btnCheck.Text = "核对签名";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Visible = false;
            this.btnCheck.Click += new System.EventHandler(this.BtnTszlZcQm_Click);
            // 
            // bt未执行
            // 
            this.bt未执行.Enabled = false;
            this.bt未执行.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt未执行.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt未执行.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt未执行.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt未执行.ImageIndex = 9;
            this.bt未执行.Location = new System.Drawing.Point(720, 2);
            this.bt未执行.Name = "bt未执行";
            this.bt未执行.Size = new System.Drawing.Size(76, 24);
            this.bt未执行.TabIndex = 65;
            this.bt未执行.Text = "未执行(&X)";
            this.bt未执行.Click += new System.EventHandler(this.bt未执行_Click);
            this.bt未执行.EnabledChanged += new System.EventHandler(this.bt未执行_EnabledChanged);
            // 
            // bt取消开医嘱转抄
            // 
            this.bt取消开医嘱转抄.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt取消开医嘱转抄.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt取消开医嘱转抄.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt取消开医嘱转抄.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt取消开医嘱转抄.ImageIndex = 6;
            this.bt取消开医嘱转抄.Location = new System.Drawing.Point(250, 2);
            this.bt取消开医嘱转抄.Name = "bt取消开医嘱转抄";
            this.bt取消开医嘱转抄.Size = new System.Drawing.Size(120, 24);
            this.bt取消开医嘱转抄.TabIndex = 49;
            this.bt取消开医嘱转抄.Text = "取消开医嘱转抄()";
            this.bt取消开医嘱转抄.Visible = false;
            this.bt取消开医嘱转抄.Click += new System.EventHandler(this.bt取消开医嘱转抄_Click);
            this.bt取消开医嘱转抄.EnabledChanged += new System.EventHandler(this.bt取消开医嘱转抄_EnabledChanged);
            // 
            // bt退出
            // 
            this.bt退出.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt退出.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt退出.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt退出.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt退出.ImageIndex = 4;
            this.bt退出.Location = new System.Drawing.Point(880, 2);
            this.bt退出.Name = "bt退出";
            this.bt退出.Size = new System.Drawing.Size(64, 24);
            this.bt退出.TabIndex = 48;
            this.bt退出.Text = "退出(&E)";
            this.bt退出.Click += new System.EventHandler(this.bt退出_Click);
            // 
            // bt取消停医嘱转抄
            // 
            this.bt取消停医嘱转抄.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt取消停医嘱转抄.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt取消停医嘱转抄.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt取消停医嘱转抄.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt取消停医嘱转抄.ImageIndex = 6;
            this.bt取消停医嘱转抄.Location = new System.Drawing.Point(372, 2);
            this.bt取消停医嘱转抄.Name = "bt取消停医嘱转抄";
            this.bt取消停医嘱转抄.Size = new System.Drawing.Size(120, 24);
            this.bt取消停医嘱转抄.TabIndex = 66;
            this.bt取消停医嘱转抄.Text = "取消停医嘱转抄()";
            this.bt取消停医嘱转抄.Visible = false;
            this.bt取消停医嘱转抄.Click += new System.EventHandler(this.bt取消开医嘱转抄_Click);
            this.bt取消停医嘱转抄.EnabledChanged += new System.EventHandler(this.bt取消停医嘱转抄_EnabledChanged);
            // 
            // butorderprint
            // 
            this.butorderprint.Enabled = false;
            this.butorderprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butorderprint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butorderprint.ForeColor = System.Drawing.SystemColors.Desktop;
            this.butorderprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butorderprint.ImageIndex = 9;
            this.butorderprint.Location = new System.Drawing.Point(651, 2);
            this.butorderprint.Name = "butorderprint";
            this.butorderprint.Size = new System.Drawing.Size(125, 24);
            this.butorderprint.TabIndex = 72;
            this.butorderprint.Text = "在医嘱打印中体现";
            this.butorderprint.Visible = false;
            this.butorderprint.Click += new System.EventHandler(this.butorderprint_Click);
            // 
            // bt详细信息
            // 
            this.bt详细信息.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt详细信息.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt详细信息.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt详细信息.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt详细信息.ImageIndex = 8;
            this.bt详细信息.Location = new System.Drawing.Point(126, 2);
            this.bt详细信息.Name = "bt详细信息";
            this.bt详细信息.Size = new System.Drawing.Size(61, 24);
            this.bt详细信息.TabIndex = 51;
            this.bt详细信息.Text = "冲正(F8)";
            this.bt详细信息.Click += new System.EventHandler(this.bt详细信息_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageIndex = 9;
            this.btnDelete.Location = new System.Drawing.Point(499, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 24);
            this.btnDelete.TabIndex = 69;
            this.btnDelete.Text = "删除账单(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.EnabledChanged += new System.EventHandler(this.btnDelete_EnabledChanged);
            // 
            // bt阳性
            // 
            this.bt阳性.ContextMenuStrip = this.contextMenuSP;
            this.bt阳性.Enabled = false;
            this.bt阳性.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt阳性.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt阳性.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt阳性.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt阳性.ImageIndex = 9;
            this.bt阳性.Location = new System.Drawing.Point(651, 2);
            this.bt阳性.Name = "bt阳性";
            this.bt阳性.Size = new System.Drawing.Size(64, 24);
            this.bt阳性.TabIndex = 64;
            this.bt阳性.Text = "阳性(&+)";
            this.bt阳性.Click += new System.EventHandler(this.bt阳性_Click);
            // 
            // contextMenuSP
            // 
            this.contextMenuSP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuSP.Name = "contextMenuSerch";
            this.contextMenuSP.Size = new System.Drawing.Size(137, 70);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem2.Text = "阳性(+)";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem3.Text = "加阳性(++)";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem4.Text = "强阳性(+++)";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // BtnTszlZcQm
            // 
            this.BtnTszlZcQm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTszlZcQm.ForeColor = System.Drawing.SystemColors.Desktop;
            this.BtnTszlZcQm.Location = new System.Drawing.Point(372, 2);
            this.BtnTszlZcQm.Name = "BtnTszlZcQm";
            this.BtnTszlZcQm.Size = new System.Drawing.Size(67, 24);
            this.BtnTszlZcQm.TabIndex = 73;
            this.BtnTszlZcQm.Text = "转抄签名";
            this.BtnTszlZcQm.UseVisualStyleBackColor = true;
            this.BtnTszlZcQm.Visible = false;
            this.BtnTszlZcQm.Click += new System.EventHandler(this.BtnTszlZcQm_Click);
            this.BtnTszlZcQm.EnabledChanged += new System.EventHandler(this.BtnTszlZcQm_EnabledChanged);
            // 
            // bt阴性
            // 
            this.bt阴性.Enabled = false;
            this.bt阴性.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt阴性.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt阴性.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt阴性.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt阴性.ImageIndex = 9;
            this.bt阴性.Location = new System.Drawing.Point(586, 2);
            this.bt阴性.Name = "bt阴性";
            this.bt阴性.Size = new System.Drawing.Size(64, 24);
            this.bt阴性.TabIndex = 63;
            this.bt阴性.Text = "阴性(&-)";
            this.bt阴性.Click += new System.EventHandler(this.bt阴性_Click);
            // 
            // bt医嘱打印
            // 
            this.bt医嘱打印.ContextMenu = this.contextMenu3;
            this.bt医嘱打印.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt医嘱打印.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt医嘱打印.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt医嘱打印.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt医嘱打印.ImageIndex = 7;
            this.bt医嘱打印.Location = new System.Drawing.Point(188, 2);
            this.bt医嘱打印.Name = "bt医嘱打印";
            this.bt医嘱打印.Size = new System.Drawing.Size(61, 24);
            this.bt医嘱打印.TabIndex = 50;
            this.bt医嘱打印.Text = "打印(&P)";
            this.bt医嘱打印.Click += new System.EventHandler(this.bt医嘱打印_Click);
            // 
            // contextMenu3
            // 
            this.contextMenu3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem8,
            this.menuItem9});
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "打印医嘱单";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.Text = "打印执行单";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "打印记帐凭证";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // bt取消开医嘱核对
            // 
            this.bt取消开医嘱核对.ContextMenu = this.contextMenu1;
            this.bt取消开医嘱核对.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt取消开医嘱核对.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt取消开医嘱核对.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt取消开医嘱核对.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt取消开医嘱核对.ImageIndex = 6;
            this.bt取消开医嘱核对.Location = new System.Drawing.Point(250, 2);
            this.bt取消开医嘱核对.Name = "bt取消开医嘱核对";
            this.bt取消开医嘱核对.Size = new System.Drawing.Size(120, 24);
            this.bt取消开医嘱核对.TabIndex = 62;
            this.bt取消开医嘱核对.Text = "取消开医嘱转抄(&Z)";
            this.bt取消开医嘱核对.Click += new System.EventHandler(this.bt取消开医嘱核对_Click);
            this.bt取消开医嘱核对.EnabledChanged += new System.EventHandler(this.bt取消开医嘱核对_EnabledChanged);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem3,
            this.menuItem1});
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "取消开医嘱转抄";
            this.menuItem5.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "取消开医嘱核对";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "取消开医嘱查对";
            this.menuItem1.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // bt取消停医嘱核对
            // 
            this.bt取消停医嘱核对.ContextMenu = this.contextMenu2;
            this.bt取消停医嘱核对.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt取消停医嘱核对.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt取消停医嘱核对.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt取消停医嘱核对.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt取消停医嘱核对.ImageIndex = 6;
            this.bt取消停医嘱核对.Location = new System.Drawing.Point(370, 2);
            this.bt取消停医嘱核对.Name = "bt取消停医嘱核对";
            this.bt取消停医嘱核对.Size = new System.Drawing.Size(120, 24);
            this.bt取消停医嘱核对.TabIndex = 68;
            this.bt取消停医嘱核对.Text = "取消停医嘱转抄(&C)";
            this.bt取消停医嘱核对.Click += new System.EventHandler(this.bt取消开医嘱核对_Click);
            this.bt取消停医嘱核对.EnabledChanged += new System.EventHandler(this.bt取消停医嘱核对_EnabledChanged);
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem4,
            this.menuItem2});
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "取消停医嘱转抄";
            this.menuItem6.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "取消停医嘱核对";
            this.menuItem4.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "取消停医嘱查对";
            this.menuItem2.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Location = new System.Drawing.Point(766, 37);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(390, 120);
            this.tabControl2.TabIndex = 75;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.myDataGrid3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(382, 94);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "项目明细";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // myDataGrid3
            // 
            this.myDataGrid3.AllowSorting = false;
            this.myDataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myDataGrid3.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid3.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid3.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid3.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid3.CaptionText = "项目明细";
            this.myDataGrid3.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid3.DataMember = "";
            this.myDataGrid3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid3.Location = new System.Drawing.Point(1, 5);
            this.myDataGrid3.Name = "myDataGrid3";
            this.myDataGrid3.ReadOnly = true;
            this.myDataGrid3.RowHeaderWidth = 20;
            this.myDataGrid3.Size = new System.Drawing.Size(378, 86);
            this.myDataGrid3.TabIndex = 61;
            this.myDataGrid3.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.myDataGrid3.CurrentCellChanged += new System.EventHandler(this.myDataGrid3_CurrentCellChanged);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.myDataGrid3;
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.ucWzxm1);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(382, 94);
            this.tabPage10.TabIndex = 1;
            this.tabPage10.Text = "选择物质项目";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // ucWzxm1
            // 
            this.ucWzxm1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucWzxm1.BabyID = ((long)(0));
            this.ucWzxm1.BinID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucWzxm1.Dept_id = 0;
            this.ucWzxm1.First_times = null;
            this.ucWzxm1.Fjfy_yzid = 0;
            this.ucWzxm1.IsSSMZ = false;
            this.ucWzxm1.Itemidsf = null;
            this.ucWzxm1.Location = new System.Drawing.Point(2, 1);
            this.ucWzxm1.MyTb = null;
            this.ucWzxm1.Name = "ucWzxm1";
            this.ucWzxm1.Nrow = 0;
            this.ucWzxm1.Order_id = null;
            this.ucWzxm1.RbIn = false;
            this.ucWzxm1.RbTszl = false;
            this.ucWzxm1.Size = new System.Drawing.Size(380, 97);
            this.ucWzxm1.TabIndex = 0;
            this.ucWzxm1.Yztype = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(465, 163);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(692, 14);
            this.progressBar1.TabIndex = 57;
            // 
            // patientInfo1
            // 
            this.patientInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.patientInfo1.IsShow = true;
            this.patientInfo1.Location = new System.Drawing.Point(3, 37);
            this.patientInfo1.Name = "patientInfo1";
            this.patientInfo1.Size = new System.Drawing.Size(459, 144);
            this.patientInfo1.TabIndex = 56;
            // 
            // priceInfo1
            // 
            this.priceInfo1.Dv = null;
            this.priceInfo1.Location = new System.Drawing.Point(461, 37);
            this.priceInfo1.Name = "priceInfo1";
            this.priceInfo1.Order_context = null;
            this.priceInfo1.Size = new System.Drawing.Size(307, 120);
            this.priceInfo1.TabIndex = 54;
            // 
            // bt显示切换
            // 
            this.bt显示切换.BackColor = System.Drawing.Color.PaleTurquoise;
            this.bt显示切换.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt显示切换.Location = new System.Drawing.Point(10, 54);
            this.bt显示切换.Name = "bt显示切换";
            this.bt显示切换.Size = new System.Drawing.Size(16, 20);
            this.bt显示切换.TabIndex = 68;
            this.bt显示切换.UseVisualStyleBackColor = false;
            this.bt显示切换.Click += new System.EventHandler(this.bt显示切换_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkGwyp);
            this.panel5.Controls.Add(this.chkSsyz);
            this.panel5.Controls.Add(this.lblSsMzFee);
            this.panel5.Controls.Add(this.chkWardOrder);
            this.panel5.Controls.Add(this.txt_yz);
            this.panel5.Controls.Add(this.che_yz);
            this.panel5.Controls.Add(this.che_date);
            this.panel5.Controls.Add(this.cmb_date);
            this.panel5.Controls.Add(this.tabControl1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1160, 28);
            this.panel5.TabIndex = 96;
            // 
            // chkGwyp
            // 
            this.chkGwyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGwyp.AutoSize = true;
            this.chkGwyp.Location = new System.Drawing.Point(510, 6);
            this.chkGwyp.Name = "chkGwyp";
            this.chkGwyp.Size = new System.Drawing.Size(144, 16);
            this.chkGwyp.TabIndex = 38;
            this.chkGwyp.Text = "显示麻醉所有高危药品";
            this.chkGwyp.UseVisualStyleBackColor = true;
            this.chkGwyp.Visible = false;
            this.chkGwyp.CheckedChanged += new System.EventHandler(this.chkGwyp_CheckedChanged);
            // 
            // chkSsyz
            // 
            this.chkSsyz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSsyz.AutoSize = true;
            this.chkSsyz.Location = new System.Drawing.Point(785, 6);
            this.chkSsyz.Name = "chkSsyz";
            this.chkSsyz.Size = new System.Drawing.Size(96, 16);
            this.chkSsyz.TabIndex = 98;
            this.chkSsyz.Text = "显示手术医嘱";
            this.chkSsyz.UseVisualStyleBackColor = true;
            // 
            // lblSsMzFee
            // 
            this.lblSsMzFee.AutoSize = true;
            this.lblSsMzFee.Location = new System.Drawing.Point(330, 8);
            this.lblSsMzFee.Name = "lblSsMzFee";
            this.lblSsMzFee.Size = new System.Drawing.Size(89, 12);
            this.lblSsMzFee.TabIndex = 97;
            this.lblSsMzFee.Text = "手麻费用合计：";
            this.lblSsMzFee.Visible = false;
            // 
            // chkWardOrder
            // 
            this.chkWardOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkWardOrder.AutoSize = true;
            this.chkWardOrder.Location = new System.Drawing.Point(785, 6);
            this.chkWardOrder.Name = "chkWardOrder";
            this.chkWardOrder.Size = new System.Drawing.Size(96, 16);
            this.chkWardOrder.TabIndex = 36;
            this.chkWardOrder.Text = "显示病区医嘱";
            this.chkWardOrder.UseVisualStyleBackColor = true;
            this.chkWardOrder.Visible = false;
            this.chkWardOrder.CheckedChanged += new System.EventHandler(this.chkWardOrder_CheckedChanged);
            // 
            // txt_yz
            // 
            this.txt_yz.ActiveColor = System.Drawing.Color.Empty;
            this.txt_yz.AllowDefaultValue = false;
            this.txt_yz.AllowGotoNextControlWithoutNoneSelected = false;
            this.txt_yz.AllowPressEnterKeyCheckValue = false;
            this.txt_yz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_yz.AutoTabSend = false;
            this.txt_yz.ButtonVisible = false;
            this.txt_yz.DisplayMember = "BLH";
            this.txt_yz.DisplayShowCardWhenActived = false;
            this.txt_yz.DoSelectedWhenTextEmpty = true;
            this.txt_yz.Enable = true;
            this.txt_yz.Enabled = false;
            this.txt_yz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_yz.InputValueStyle = Trasen.Controls.InputValueStyle.String;
            this.txt_yz.LabelText = "";
            this.txt_yz.Location = new System.Drawing.Point(1063, 4);
            this.txt_yz.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_yz.MaxLength = 32767;
            this.txt_yz.Multiline = false;
            this.txt_yz.Name = "txt_yz";
            this.txt_yz.ReadOnly = false;
            this.txt_yz.SelectAllTextAfterClick = false;
            this.txt_yz.SelectedValue = null;
            this.txt_yz.SelectionLength = 0;
            this.txt_yz.SelectionStart = 0;
            this.txt_yz.SetValueEqualTextWhenNoneSelected = true;
            this.txt_yz.ShowCardComponent = this.showCardComponent1;
            this.txt_yz.ShowCardEnable = false;
            showCardProperty1.AllowCustomInputWhenNoneSelectedRow = false;
            showCardProperty1.BindColumnName = null;
            showCardProperty1.ColumnHeaderVisible = false;
            showCardProperty1.DbConnection = null;
            showCardProperty1.RealTimeQuery = false;
            showCardProperty1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            showCardProperty1.RowHeaderVisible = false;
            showCardProperty1.ShowCardColumns = new Trasen.Controls.ShowCardColumn[0];
            showCardProperty1.ShowCardDataSource = null;
            showCardProperty1.ShowCardDataSourceSqlString = null;
            showCardProperty1.ShowCardSize = new System.Drawing.Size(135, 108);
            this.txt_yz.ShowCardProperty = new Trasen.Controls.ShowCardProperty[] {
        showCardProperty1};
            this.txt_yz.Size = new System.Drawing.Size(93, 24);
            this.txt_yz.TabIndex = 34;
            this.txt_yz.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_yz.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.txt_yz.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_yz.TextBoxStyle = Trasen.Controls.LabelTextBox.TextBoxStyleEnum.Standard;
            this.txt_yz.ValueMember = "BLH";
            this.txt_yz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_yz_KeyDown);
            // 
            // showCardComponent1
            // 
            this.showCardComponent1.MatchType = Trasen.Controls.MatchType.模糊查询;
            this.showCardComponent1.ShowCardSelectedMode = Trasen.Controls.ShowCardSelectedMode.Click;
            // 
            // che_yz
            // 
            this.che_yz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.che_yz.AutoSize = true;
            this.che_yz.Location = new System.Drawing.Point(1019, 8);
            this.che_yz.Name = "che_yz";
            this.che_yz.Size = new System.Drawing.Size(48, 16);
            this.che_yz.TabIndex = 31;
            this.che_yz.Text = "医嘱";
            this.che_yz.UseVisualStyleBackColor = true;
            this.che_yz.CheckedChanged += new System.EventHandler(this.che_yz_CheckedChanged);
            // 
            // che_date
            // 
            this.che_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.che_date.AutoSize = true;
            this.che_date.Location = new System.Drawing.Point(885, 6);
            this.che_date.Name = "che_date";
            this.che_date.Size = new System.Drawing.Size(60, 16);
            this.che_date.TabIndex = 28;
            this.che_date.Text = "开日期";
            this.che_date.UseVisualStyleBackColor = true;
            this.che_date.CheckedChanged += new System.EventHandler(this.che_date_CheckedChanged);
            // 
            // cmb_date
            // 
            this.cmb_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_date.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_date.Enabled = false;
            this.cmb_date.FormattingEnabled = true;
            this.cmb_date.Items.AddRange(new object[] {
            "今天",
            "昨天",
            "一周",
            "一月",
            "半年",
            "一年",
            "全部"});
            this.cmb_date.Location = new System.Drawing.Point(947, 3);
            this.cmb_date.Name = "cmb_date";
            this.cmb_date.Size = new System.Drawing.Size(66, 20);
            this.cmb_date.TabIndex = 27;
            this.cmb_date.SelectedIndexChanged += new System.EventHandler(this.cmb_date_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 22);
            this.tabControl1.Location = new System.Drawing.Point(3, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(876, 28);
            this.tabControl1.TabIndex = 35;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // ReasenPanel
            // 
            this.ReasenPanel.BackColor = System.Drawing.Color.LightGreen;
            this.ReasenPanel.Location = new System.Drawing.Point(0, 0);
            this.ReasenPanel.Name = "ReasenPanel";
            this.ReasenPanel.Size = new System.Drawing.Size(280, 40);
            this.ReasenPanel.TabIndex = 2;
            this.ReasenPanel.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "23.ICO");
            this.imageList1.Images.SetKeyName(1, "gomme.ico");
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1008, 0);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "有效长嘱";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1008, 0);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "有效临嘱";
            this.tabPage2.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1008, 0);
            this.tabPage3.TabIndex = 7;
            this.tabPage3.Text = "有效长期账单";
            this.tabPage3.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1008, 0);
            this.tabPage4.TabIndex = 8;
            this.tabPage4.Text = "有效临时账单";
            this.tabPage4.Visible = false;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 26);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1008, 0);
            this.tabPage6.TabIndex = 10;
            this.tabPage6.Text = "所有长嘱";
            this.tabPage6.Visible = false;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 26);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1008, 0);
            this.tabPage7.TabIndex = 11;
            this.tabPage7.Text = "所有临嘱";
            this.tabPage7.Visible = false;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 26);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1008, 0);
            this.tabPage8.TabIndex = 12;
            this.tabPage8.Text = "所有长期账单";
            this.tabPage8.Visible = false;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 26);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1008, 0);
            this.tabPage9.TabIndex = 13;
            this.tabPage9.Text = "所有临时账单";
            this.tabPage9.Visible = false;
            // 
            // chkShowAllSMYz
            // 
            this.chkShowAllSMYz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowAllSMYz.AutoSize = true;
            this.chkShowAllSMYz.Location = new System.Drawing.Point(661, 6);
            this.chkShowAllSMYz.Name = "chkShowAllSMYz";
            this.chkShowAllSMYz.Size = new System.Drawing.Size(120, 16);
            this.chkShowAllSMYz.TabIndex = 37;
            this.chkShowAllSMYz.Text = "显示手麻所有医嘱";
            this.chkShowAllSMYz.UseVisualStyleBackColor = true;
            this.chkShowAllSMYz.Visible = false;
            this.chkShowAllSMYz.CheckedChanged += new System.EventHandler(this.chkShowAllSMYz_CheckedChanged);
            // 
            // frmYZGL
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1160, 483);
            this.Controls.Add(this.chkShowAllSMYz);
            this.Controls.Add(this.panel总);
            this.Controls.Add(this.ReasenPanel);
            this.KeyPreview = true;
            this.Name = "frmYZGL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "医嘱查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYZGL_Load);
            this.Activated += new System.EventHandler(this.frmYZGL_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmYZGL_KeyUp);
            this.panel总.ResumeLayout(false);
            this.panel右.ResumeLayout(false);
            this.panel右上.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.contextMenuSerch.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel右下.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.contextMenuSqm.ResumeLayout(false);
            this.contextMenuSP.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).EndInit();
            this.tabPage10.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void frmYZGL_Load(object sender, System.EventArgs e)
        {
            chkGwyp.Visible = false;
            //add by zouchihua 2012-5-16 获得图片
            this.取消双签名ToolStripMenuItem.Image = ts_zyhs_yzgl.Properties.Resources.gomme;
            this.toolStripMenuItem1.Image = ts_zyhs_yzgl.Properties.Resources._23;
            this.删除执行时间ToolStripMenuItem.Image = ts_zyhs_yzgl.Properties.Resources.gomme;
            if (isSSMZ)
            {
                string[] GrdMappingName11 ={ "住院号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
                int[] GrdWidth11 ={ 9, 8, 0, 0, 0, 0 };
                int[] Alignment11 ={ 1, 0, 0, 0, 0, 0 };
                myFunc.InitGridSQL(binSql, GrdMappingName11, GrdWidth11, Alignment11, this.myDataGrid2);

                //Modify by jchl
                DataTable dtSrc = myDataGrid2.DataSource as DataTable;
                DoInitCtr(GrdMappingName11, GrdMappingName11, new string[] { "住院号", "姓名" }, new int[] { 100, 60, 0, 0, 0, 0 }, dtSrc);

                //				tabControl1.Controls.Remove(tabPage1);
                //				tabControl1.Controls.Remove(tabPage2);
                //				tabControl1.Controls.Remove(tabPage3);
                //				tabControl1.Controls.Remove(tabPage4);
                //				tabControl1.Controls.Remove(tabPage6);
                //				tabControl1.Controls.Remove(tabPage8);

                //0=手术 1=麻醉
                //手术室不能看见麻醉医嘱
                //Modify By Tany 2005-11-03 手术室可以看医嘱
                //				if(ssmzType==0)
                //				{
                //					tabControl1.Controls.Remove(tabPage7);
                //				}

                //				tabControl1.SelectedIndex=0;

                //Modify By Tany 2010-08-31 可以打印记账凭证
                //bt医嘱打印.Visible = false;

                //Modify by jchl
                if (ssmzType == 1)
                {
                    //
                    chkGwyp.Visible = true;
                }

                menuItem7.Visible = false;
                menuItem8.Visible = false;

                bt取消停医嘱核对.Visible = false;
                bt取消停医嘱转抄.Visible = false;
                //bt取消开医嘱核对.Visible=false;
                //bt取消开医嘱转抄.Visible=false;
                bt未执行.Visible = false;
                bt阳性.Visible = false;
                bt阴性.Visible = false;
                butorderprint.Visible = true;
                butorderprint.Enabled = true;
                bt执行时间.Visible = true;//Modify by zouchhua 2012-6-12 手术室也可以看到
                BtnTszlZcQm.Visible = true;//Modify by zouchhua 2012-6-12 手术室也可以看到
                btnCheck.Visible = true;//Modify by zouchhua 2013-11-28 手术室也可以看到

                chkWardOrder.Visible = true;//Modify By Tany 2015-03-25 只有手麻看得见
                chkShowAllSMYz.Visible = true;//Modify By Tany 2015-03-31 只有手麻看得见
            }
            else if (isCX || zczyz_notfy)
            {
                if (zczyz_notfy)
                {
                    binSql = @" SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end 医保类型,BRLX_NAME 病人类型,XZLX_NAME 险种类型,DYLX_NAME 待遇类型" +
                      "   FROM vi_zy_vInpatient_All " +
                      "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' and flag = 5 ORDER BY INPATIENT_NO,Baby_ID";
                }
                string[] GrdMappingName11 ={ "住院号", "床号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY", "医保类型", "病人类型", "险种类型", "待遇类型" };
                int[] GrdWidth11 ={ 9, 5, 8, 0, 0, 0, 0, 9, 9, 9, 9 };
                int[] Alignment11 ={ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                myFunc.InitGridSQL(binSql, GrdMappingName11, GrdWidth11, Alignment11, this.myDataGrid2);

                //Modify by jchl
                DataTable dtSrc = myDataGrid2.DataSource as DataTable;
                DoInitCtr(GrdMappingName11, GrdMappingName11, new string[] { "住院号", "床号", "姓名" }, new int[] { 100, 50, 60, 0, 0, 0, 0, 0, 0, 0, 0 }, dtSrc);

                //				tabControl1.Controls.Remove(tabPage1);
                //				tabControl1.Controls.Remove(tabPage2);
                //				tabControl1.Controls.Remove(tabPage3);
                //				tabControl1.Controls.Remove(tabPage4);

                tabControl1.SelectedIndex = 0;

                bt详细信息.Text = "详细信息";

                bt立即执行.Visible = false;
                bt医嘱打印.Visible = false;
                bt取消停医嘱核对.Visible = false;
                bt取消停医嘱转抄.Visible = false;
                bt取消开医嘱核对.Visible = false;
                bt取消开医嘱转抄.Visible = false;
                btnDelete.Visible = false;
                bt未执行.Visible = false;
                bt阳性.Visible = false;
                bt阴性.Visible = false;
                bt执行时间.Visible = false;
            }
            else
            {
                string[] GrdMappingName1 ={ "床号", "姓名", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY" };
                int[] GrdWidth1 ={ 5, 10, 0, 0, 0, 0 };
                int[] Alignment1 ={ 1, 0, 0, 0, 0, 0 };
                myFunc.InitGridSQL(binSql, GrdMappingName1, GrdWidth1, Alignment1, this.myDataGrid2);

                //Modify by jchl
                DataTable dtSrc = myDataGrid2.DataSource as DataTable;
                DoInitCtr(GrdMappingName1, GrdMappingName1, new string[] { "床号", "姓名" }, new int[] { 50, 60, 0, 0, 0, 0 }, dtSrc);

            }

            DataTable myTb = (DataTable)myDataGrid2.DataSource;

            int nRow = myDataGrid2.CurrentCell.RowNumber;

            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
            /*
            status_flag,Order_ID,Group_ID,Num,Unit,dwlx,Order_Usage,frequency,Dropsper,Dosage,
            ntype,exec_dept,day1,second1,day2,second2,
            AUDITING_USER,AUDITING_USER1,order_euser,order_euser1,item_code,cjid,
            开日期,开时间,
            医嘱内容,开嘱医生,开嘱转抄,开嘱核对,
            停日期,停时间,
            停嘱医生,停嘱转抄,停嘱核对,
            执行时间,发送护士,执行科室,serial_no,ps_flag,ps_orderid,ps_user,wzx_flag
            */
            string[] GrdMappingName ={ "status_flag","Order_ID","Group_ID","Num","Unit","dwlx","Order_Usage","frequency","Dropsper","Dosage",
										"ntype","exec_dept","day1","second1","day2","second2", "AUDITING_USER","AUDITING_USER1",
										"order_euser","order_euser1","item_code","xmly",     
										"选",
										"开日期","开时间","医嘱内容","费用","开嘱医生","开嘱转抄","开嘱核对",
										"停日期","停时间","停嘱医生","停嘱转抄","停嘱核对",
										"执行时间","执行人","执行科室","发送时间","发送护士",//"执行时间","执行人",
										"ps_flag","ps_orderid","ps_user","wzx_flag","P","hoitem_id","isprintypgg","数字码","单价"
                //,"zfbl"
            };//isggdy add by zouchihua 2011-11-30 //数字码,单价 add by Tany 2015-06-23
            //add by zouchihua 2011-11-30
            int isggwide = 0;
            try
            {
                //护士站医嘱管理是否显示打”印规格列“
                if (new SystemCfg(7802).Config.ToString().Trim() == "1")
                    isggwide = 10;
            }
            catch (Exception ex)
            {
                isggwide = 0;
                MessageBox.Show(ex.Message);
            }
            int[] GrdWidth ={0,0,0,0,0,0,0,0,0,0,
									 0,0,0,0,0,0,0,0,
									 0,0,0,0,
									 2,
									 6,6,50,0,8,8,0,//开嘱核对不显示
									 6,6,8,8,0,//停嘱核对不显示
									 15,8,8,15,8,
									 0,0,0,0,4,0,0,8,8};//isggwide
            int[] Alignment ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            this.InitGridYZ(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                //if (rbTszl.Checked == false)
                //{
                //    rbTszl.Checked = true;
                //    rb_Click(null, null);
                //    return;
                //}
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.patientInfo1.ClearInpatientInfo();
                ClassStatic.Current_BinID = Guid.Empty;
                ClassStatic.Current_BabyID = 0;
                ClassStatic.Current_DeptID = 0;
                ClassStatic.Current_isMYTS = 0;
                ClassStatic.Current_isMY = 0;
                //myDataGrid1.DataSource = null;
                return;
            }

            if ((new Guid(myTb.Rows[nRow]["inpatient_id"].ToString()) == ClassStatic.Current_BinID) && (Convert.ToInt64(myTb.Rows[nRow]["baby_id"]) == ClassStatic.Current_BabyID))
            {
                myDataGrid2_CurrentCellChanged(sender, e);
            }
            else
            {
                myFunc.SelectBin(true, this.myDataGrid2, "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY");
                this.ShowData();
            }

            //			PubStaticFun.ModifyDataGridStyle(myDataGrid1,0);
            PubStaticFun.ModifyDataGridStyle(myDataGrid2, 0);
            //add by zouchihu a2012-3-27
            cfg7111 = new SystemCfg(7111);
            cfg7129 = new SystemCfg(7129);
            if (zczyz_notfy)
            {
                //cmbWard.SelectedIndexChanged -= new EventHandler(cmbWard_SelectedIndexChanged);
                //cmbWard_SelectedIndexChanged(null, null);
                //cmbWard.SelectedIndexChanged += new EventHandler(cmbWard_SelectedIndexChanged);
            }

            MenuItem menu = new MenuItem();
            menu.Index = 3;
            menu.Text = "打印医嘱账单网格";
            menu.Click += new EventHandler(menu_Click);

            //Modify by jchl
            menu.Name = "yzzd";
            if (!contextMenu3.MenuItems.ContainsKey(menu.Name))
            {
                contextMenu3.MenuItems.Add(menu);
            }

            //Add By Tany 2015-02-02 增加打印中药处方
            MenuItem menu_printzycf = new MenuItem();
            menu_printzycf.Index = 4;
            menu_printzycf.Text = "打印中药处方";
            menu_printzycf.Click += new EventHandler(menu_printzycf_Click);

            //Modify by jchl
            menu_printzycf.Name = "zycf";
            if (!contextMenu3.MenuItems.ContainsKey(menu_printzycf.Name))
            {
                contextMenu3.MenuItems.Add(menu_printzycf);
            }

            //Add By jchl 
            if (isSSMZ)
            {
                MenuItem menuSm_JMY = new MenuItem();
                menuSm_JMY.Index = 5;
                menuSm_JMY.Text = "打印麻精一处方";
                menuSm_JMY.Click += new EventHandler(menuSmCf_Print);

                //Modify by jchl 打印麻精一处方
                menuSm_JMY.Name = "mjycf";
                if (!contextMenu3.MenuItems.ContainsKey(menuSm_JMY.Name))
                {
                    contextMenu3.MenuItems.Add(menuSm_JMY);
                }

                MenuItem menuSm_JE = new MenuItem();
                menuSm_JE.Index = 6;
                menuSm_JE.Text = "打印精二处方";
                menuSm_JE.Click += new EventHandler(menuSmCf_Print);

                menuSm_JE.Name = "jecf";
                if (!contextMenu3.MenuItems.ContainsKey(menuSm_JE.Name))
                {
                    contextMenu3.MenuItems.Add(menuSm_JE);
                }

                MenuItem menuSm_ptcf = new MenuItem();
                menuSm_ptcf.Index = 7;
                menuSm_ptcf.Text = "打印选择处方";
                menuSm_ptcf.Click += new EventHandler(menuSmCf_Print);

                menuSm_ptcf.Name = "xzcf";
                if (!contextMenu3.MenuItems.ContainsKey(menuSm_ptcf.Name))
                {
                    contextMenu3.MenuItems.Add(menuSm_ptcf);
                }
            }

            //if(InstanceForm)
            //Modify By Tany 2015-05-11 手术麻醉完成
            btSsmzwc.Visible = isSSMZ;
            btSsmzwc.Text = ssmzType == 0 ? "手术完成" : "麻醉完成";

            //add pengyang 2015-8-6
            if (isSSMZ)
                tabControl1.SelectedTab = tabPage7;
            //add pengyang 2015-8-6 增加皮试医嘱所显示的颜色
            label6.Location = new Point(label5.Location.X + 100, label5.Location.Y);
            //add pengyang 2015-8-6 增加手术医嘱
            //chkSsyz.Location = new Point(che_date.Location.X - 30, che_date.Location.Y);
            if (isSSMZ == true)
            {
                chkSsyz.Visible = false;
            }
            else
            {
                chkSsyz.CheckedChanged += new EventHandler(chkSsyz_CheckedChanged);
            }

            //Add By Tany 2015-11-17
            sysDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd"));
        }

        private void chkSsyz_CheckedChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-6 增加手术医嘱
            if (chkSsyz.Checked)
            {
                chkShowAllSMYz.CheckedChanged -= chkShowAllSMYz_CheckedChanged;
                chkShowAllSMYz.Checked = false;
                chkShowAllSMYz.CheckedChanged += chkShowAllSMYz_CheckedChanged;

                chkWardOrder.CheckedChanged -= chkWardOrder_CheckedChanged;
                chkWardOrder.Checked = false;
                chkWardOrder.CheckedChanged += chkWardOrder_CheckedChanged;
            }
            ShowData();
        }

        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            myDataGrid.TableStyles[0].AllowSorting = false; //不允许排序

            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "选" || GrdMappingName[i].ToString().Trim() == "P" || GrdMappingName[i].ToString().Trim() == "isprintypgg")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    if (GrdMappingName[i].ToString().Trim() == "P" || GrdMappingName[i].ToString().Trim() == "isprintypgg")
                    {
                        myBoolCol.AllowNull = false;
                        myBoolCol.TrueValue = (short)1;
                        myBoolCol.FalseValue = (short)0;
                        myBoolCol.NullValue = (short)0;
                        if (GrdMappingName[i].ToString().Trim() == "P")
                        {
                            myBoolCol.HeaderText = "不打";
                        }
                    }
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
                    //add by zouchihua 2011-11-30
                    if (GrdMappingName[i].ToString().Trim() == "isprintypgg")
                    {
                        myBoolCol.AllowNull = false;
                        myBoolCol.TrueValue = 1;
                        myBoolCol.FalseValue = 0;
                        myBoolCol.NullValue = 0;
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = "打印规格";
                    }
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            //用色彩区分医嘱的状态 
            int ColorCol = 0;		 //状态列
            e.BackColor = Color.White;
            if (Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) > 1 && Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) < 5)   //已审核
            {
                e.ForeColor = Color.Blue;
                //选择列
                if (this.myDataGrid1[e.Row, 22].ToString() == "True") e.BackColor = Color.GreenYellow;

                //Modify By Tany 2015-06-18 如果是说明医嘱，显示其他颜色
                if (this.myDataGrid1[e.Row, 10].ToString() == "7")
                {
                    e.ForeColor = Color.Orange;
                }
            }
            if (this.myDataGrid1[e.Row, ColorCol].ToString() == "5")   //已停止
            {
                e.ForeColor = Color.Gray;
                if (this.myDataGrid1[e.Row, 22].ToString() == "True") e.BackColor = Color.GreenYellow;
            }
            //已经执行的医嘱显示红色 Modify By Tany 2007-10-27
            //原本是if，改成else if，已经停止的就显示灰色，不管是不是今天执行 Modify By Tany 2014-12-22
            else if (this.myDataGrid1[e.Row, 38].ToString() != "")
            {
                if (Convert.ToDateTime(this.myDataGrid1[e.Row, 38]) >= sysDate)
                {
                    e.ForeColor = Color.Red;
                    if (this.myDataGrid1[e.Row, 22].ToString() == "True") e.BackColor = Color.GreenYellow;
                }
                object obj = myDataGrid1[e.Row, 38];
                //Modify By Tany 2015-06-18 如果是说明医嘱，显示其他颜色
                if (this.myDataGrid1[e.Row, 10].ToString() == "7")
                {
                    e.ForeColor = Color.Orange;
                }
            }
            //add pengyang 2015-8-6  增加皮试医嘱显示
            if (tabControl1.SelectedTab == tabPage7 && myDataGrid1.DataSource != null)
            {
                DataTable dt = myDataGrid1.DataSource as DataTable;
                if (dt.Rows.Count > 0 && dt.Rows.Count > e.Row)
                {
                    object ps_flag = dt.Rows[e.Row][38];
                    string[] arr = { "0", "1", "2" };
                    System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>(arr);
                    if (ps_flag != DBNull.Value && ps_flag != null && list.Contains(ps_flag.ToString().Trim()))
                    {
                        e.ForeColor = Color.Fuchsia;
                    }
                }
            }
        }

        //Tany 2014-12-2
        /// <summary>
        /// 初始化病人网格
        /// </summary>
        /// <param name="GrdMappingName"></param>
        /// <param name="GrdWidth"></param>
        /// <param name="Alignment"></param>
        /// <param name="ReadOnly"></param>
        /// <param name="myDataGrid"></param>
        private void InitGridPat(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            myDataGrid.TableStyles[0].AllowSorting = false; //不允许排序

            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "选" || GrdMappingName[i].ToString().Trim() == "P" || GrdMappingName[i].ToString().Trim() == "isprintypgg")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    if (GrdMappingName[i].ToString().Trim() == "P" || GrdMappingName[i].ToString().Trim() == "isprintypgg")
                    {
                        myBoolCol.AllowNull = false;
                        myBoolCol.TrueValue = (short)1;
                        myBoolCol.FalseValue = (short)0;
                        myBoolCol.NullValue = (short)0;
                        if (GrdMappingName[i].ToString().Trim() == "P")
                        {
                            myBoolCol.HeaderText = "不打";
                        }
                    }
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValuesPat);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
                    //add by zouchihua 2011-11-30
                    if (GrdMappingName[i].ToString().Trim() == "isprintypgg")
                    {
                        myBoolCol.AllowNull = false;
                        myBoolCol.TrueValue = 1;
                        myBoolCol.FalseValue = 0;
                        myBoolCol.NullValue = 0;
                        myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = "打印规格";
                    }
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValuesPat);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        //Tany 2014-12-22
        private void SetEnableValuesPat(object sender, DataGridEnableEventArgs e)
        {
            //用色彩区分医嘱的状态 
            int ColorCol = 0;		 //状态列
            e.BackColor = Color.White;
            e.ForeColor = Color.Red;
        }

        /// <summary>
        /// 根据时间范围、医嘱内容过滤
        /// 2014--8-26 增加
        /// </summary>
        /// <param name="myTb"></param>
        /// <returns></returns>
        private DataTable ShowDate_Filter()
        {

            DateTime curdate = TrasenClasses.GeneralClasses.DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Date;

            DataTable dt = che_date.Tag as DataTable;
            DataTable dt1 = new DataTable();
            string strYznr = "";//医嘱内容条件
            string kind = "";//时间条件分类
            string strFilter_date = ""; ;//时间过滤条件
            if (che_date.Checked && cmb_date.Text != "") kind = cmb_date.Text.Trim();
            if (che_yz.Checked && txt_yz.Text.Trim() != "") strYznr = txt_yz.Text.Trim();
            #region  处理时间过滤条件
            if (dt.Columns.Contains("ORDER_BDATE"))
            {



                switch (kind)
                {
                    case "今天":
                        strFilter_date = "ORDER_BDATE>='" + curdate + "' and ORDER_BDATE<'" + curdate.AddDays(1) + "'";
                        break;
                    case "昨天":
                        strFilter_date = "ORDER_BDATE>='" + curdate.AddDays(-1) + "' and ORDER_BDATE<'" + curdate + "'";
                        break;
                    case "一周":
                        strFilter_date = "ORDER_BDATE>='" + curdate.AddDays(-7) + "' and ORDER_BDATE<'" + curdate + "'";
                        break;
                    case "一月":
                        strFilter_date = "ORDER_BDATE>='" + curdate.AddMonths(-1) + "' and ORDER_BDATE<'" + curdate + "'";
                        break;
                    case "半年":
                        strFilter_date = "ORDER_BDATE>='" + curdate.AddMonths(-6) + "' and ORDER_BDATE<'" + curdate + "'";
                        break;
                    case "一年":
                        strFilter_date = "ORDER_BDATE>='" + curdate.AddYears(-1) + "' and ORDER_BDATE<'" + curdate + "'";
                        break;
                    case "二年":
                        strFilter_date = "ORDER_BDATE>='" + curdate.AddYears(-2) + "' and ORDER_BDATE<'" + curdate + "'";
                        break;
                }


            }
            #endregion

            #region  处理医嘱过滤条件，并组合所有过滤条件

            //Modify by jchl[麻醉显示高危药品]
            string strFil_Gwyp = "";
            if (chkGwyp.Checked)
            {
                if (dt.Columns.Contains("gwypjb"))
                {
                    strFil_Gwyp = " gwypjb=1";
                }
            }


            string strFilter_yznr = "";//医嘱过滤条件
            string strFilter_group = "";
            if (strYznr.Trim() != "") strFilter_yznr = " 医嘱内容 like '%" + strYznr + "%'";
            String strFilter = ""; //过滤条件
            if (strFilter_date.Trim() != "" && strFilter_yznr.Trim() != "")
            {
                strFilter = strFilter_date + " and " + strFilter_yznr;
            }
            else if (strFilter_date.Trim() != "" && strFilter_yznr.Trim() == "")
                strFilter = strFilter_date;
            else if (strFilter_date.Trim() == "" && strFilter_yznr.Trim() != "")
                strFilter = strFilter_yznr;

            //if (strFilter != "" && strFil_Gwyp != "")
            //{
            //    strFilter += "and" + strFil_Gwyp;
            //}
            //else if (strFilter == "" && strFil_Gwyp != "")
            //{
            //    strFilter += strFil_Gwyp;
            //}

            #endregion
            if (strFilter != "")
            {
                DataView dv = new DataView(dt.Copy(), strFilter, "", DataViewRowState.CurrentRows);
                dt1 = dv.ToTable();
            }
            #region 处理分组
            if (dt1.Rows.Count != 0)
            {
                if (dt1.Rows.Count == 1)
                {
                    strFilter_group = " group_ID =" + dt1.Rows[0]["GROUP_ID"].ToString().Trim();
                }
                else if (dt1.Rows.Count > 1)
                {
                    strFilter_group = "group_ID in (";
                    String param = "";
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (i == dt1.Rows.Count - 1)
                        {
                            param += dt1.Rows[dt1.Rows.Count - 1]["GROUP_ID"].ToString().Trim();
                        }
                        else
                        {
                            param += dt1.Rows[i]["GROUP_ID"].ToString().Trim() + ",";
                        }
                    }
                    strFilter_group += param + ")";
                }
            }

            if (strFilter_date.Trim() != "" && strFilter_group.Trim() != "")
            {
                strFilter = strFilter_date + " and 1=1  and " + strFilter_group;
            }
            else if (strFilter_date.Trim() != "" && strFilter_group.Trim() == "")
                strFilter = strFilter_date;
            else if (strFilter_date.Trim() == "" && strFilter_group.Trim() != "")
                strFilter = strFilter_group;
            #endregion
            if (strFilter != "")
            {
                DataView dv = new DataView(dt.Copy(), strFilter, "", DataViewRowState.CurrentRows);
                dt = dv.ToTable();
            }

            if (strFilter != "" && strFil_Gwyp != "")
            {
                strFilter += "and" + strFil_Gwyp;
            }
            else if (strFilter == "" && strFil_Gwyp != "")
            {
                strFilter += strFil_Gwyp;
            }

            if (strFilter != "")
            {
                DataView dv = new DataView(dt.Copy(), strFilter, "", DataViewRowState.CurrentRows);
                dt = dv.ToTable();
            }
            //if (setGridDataSource)
            //{
            //    int nType = this.GetMNGType();
            //    CheckGrdData(dt, nType);
            //    this.myDataGrid1.DataSource = dt;
            //}
            return dt;
        }
        private void ShowData()
        {
            //5=临嘱交病人
            //0-长嘱  1,5-临嘱  2-长期账单  3-临时账单  （MNGTYPE）
            int nType = this.GetMNGType();
            int nKind = this.tabControl1.SelectedTab.Text.Trim().IndexOf("有效", 0, this.tabControl1.SelectedTab.Text.Trim().Length) >= 0 ? 0 : 1;

            DataTable myTb = new DataTable();
            if (chkSsyz.Checked)
            {
                myTb = myFunc.GetBinOrdrsSSYZ("", ClassStatic.Current_BinID, ClassStatic.Current_BabyID, nType, nKind, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), "-1");
            }
            else
            {
                if (isSSMZ && !chkWardOrder.Checked)    //Modify By Tany 2015-03-25 如果勾选,则显示病区医嘱
                {
                    myTb = myFunc.GetBinOrdrsSSMZ("", ClassStatic.Current_BinID, ClassStatic.Current_BabyID, nType, nKind, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), (chkShowAllSMYz.Checked ? "-1" : InstanceForm.BCurrentDept.WardId));
                }
                else
                {
                    myTb = myFunc.GetBinOrdrs("", ClassStatic.Current_BinID, ClassStatic.Current_BabyID, nType, nKind, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), InstanceForm.BCurrentDept.WardId, (rbTszl.Checked ? InstanceForm.BCurrentDept.DeptId : 0));
                }
            }
            che_date.Tag = myTb.Copy();//add  by zouchihua 2014-8-27 增加检索条件
            myTb = ShowDate_Filter();//add  by zouchihua 2014-8-27 增加检索条件             
            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Boolean");
            col.AllowDBNull = false;
            col.ColumnName = "选";
            col.DefaultValue = false;
            if (!myTb.Columns.Contains("选")) //增加判断条件
                myTb.Columns.Add(col);

            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.TableStyles[0].RowHeaderWidth = 5;

            CheckGrdData(myTb, nType);
            this.myDataGrid1.DataSource = myTb;

            //this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();			
            //add by zouchihua 2012-5-17 是否显示核对者
            SystemCfg cfg7123 = new SystemCfg(7123);
            int Checkwide = 0;
            if (cfg7123.Config.Trim() == "1")
                Checkwide = 8;
            //开嘱核对、停嘱核对不显示
            string[] GrdMappingName ={ "费用", "开嘱医生", "开嘱转抄", "开嘱核对", "停日期", "停时间", "停嘱医生", "停嘱转抄", "停嘱核对", "执行时间", "执行人" };
            int[] GrdWidth ={   0,       8,         8,         Checkwide,       6,       6,         8,         8,         Checkwide,    0,         0,  
										6,       8,         8,         Checkwide,       0,       0,         0,         0,         0,    15,        12,
										0,       0,         8,         0,       6,       6,         0,         8,         0,    0,         0,
										6,       0,         8,         0,       0,       0,         0,         0,         0,    0,         0 };
            int i = 0, j = GrdMappingName.Length;
            for (i = 0; i <= j - 1; i++)
            {
                this.myDataGrid1.TableStyles[0].GridColumnStyles[GrdMappingName[i]].Width = GrdWidth[j * nType + i] == 0 ? 0 : (GrdWidth[j * nType + i] * 7 + 2);

                //屏蔽费用列  Modify by jchl 药品费用计算有误
                if (GrdMappingName[i].Equals("费用"))
                {
                    this.myDataGrid1.TableStyles[0].GridColumnStyles[GrdMappingName[i]].Width = 0;
                }
            }

            if (chkSsyz.Checked) //add pengyang 2015-8-7
            {
                //System.Collections.Generic.Dictionary<Button, bool> dict = new System.Collections.Generic.Dictionary<Button, bool>();
                //dict.Add(bt立即执行, false);
                //dict.Add(bt预算, false);
                //dict.Add(bt详细信息, false);
                //dict.Add(bt医嘱打印, false);
                //dict.Add(bt取消开医嘱核对, false);
                //dict.Add(BtnTszlZcQm, false);
                //dict.Add(btnCheck, false);
                //dict.Add(btnDelete, false);
                //dict.Add(butorderprint, false);
                //dict.Add(bt执行时间, false);
                //dict.Add(bt退出, true);

                //dict.Add(bt取消停医嘱转抄, false);
                //dict.Add(bt未执行, false);
                //dict.Add(bt阴性, false);
                //dict.Add(bt阳性, false);
                //foreach (System.Collections.Generic.KeyValuePair<Button, bool> pair in dict)
                //    pair.Key.Enabled = pair.Value;
                panel6.Enabled = false;
            }
            else
            {
                panel6.Enabled = true;
                //bt取消开医嘱转抄,bt取消停医嘱转抄,bt取消开医嘱核对,bt取消停医嘱核对,bt未执行,bt阴性,bt阳性,btnDelete
                //n个按钮的控制
                int[] btEnabled ={1,1,1,1,1,0,0,0,//第四个改成1，从0开始 把长期医嘱的未执行放出来
							 1,0,1,0,1,1,1,0,
							 0,0,0,0,1,0,0,1,
							 0,0,0,0,0,0,0,1};
                this.bt取消开医嘱转抄.Enabled = btEnabled[0 + nType * 8] == 1 ? true : false;
                this.bt取消停医嘱转抄.Enabled = btEnabled[1 + nType * 8] == 1 ? true : false;
                this.bt取消开医嘱核对.Enabled = btEnabled[2 + nType * 8] == 1 ? true : false;
                this.bt取消停医嘱核对.Enabled = btEnabled[3 + nType * 8] == 1 ? true : false;
                this.bt未执行.Enabled = btEnabled[4 + nType * 8] == 1 ? true : false;
                this.bt阴性.Enabled = btEnabled[5 + nType * 8] == 1 ? true : false;
                this.bt阳性.Enabled = btEnabled[6 + nType * 8] == 1 ? true : false;
                this.btnDelete.Enabled = btEnabled[7 + nType * 8] == 1 ? true : false;
                //执行时间排除在外
                this.bt执行时间.Enabled = this.tabControl1.SelectedTab.Text.Trim() == "所有临嘱" ? true : false;
                //add yaokx  2014-06-03
                if (nType == 1 || nType == 5)
                {
                    if (myTb.Rows.Count > 0)
                    {
                        if (myTb.Rows[0]["医嘱内容"].ToString().IndexOf("取消") >= 0)
                        {
                            this.bt执行时间.Enabled = false;
                        }
                        else
                        {
                            this.bt执行时间.Enabled = true;
                        }
                    }
                }
            }

            if (nType > 1)
            {
                this.myDataGrid1.TableStyles[0].GridColumnStyles["开嘱转抄"].HeaderText = "录入护士";
                this.myDataGrid1.TableStyles[0].GridColumnStyles["停嘱转抄"].HeaderText = "停止护士";
                this.bt未执行.Text = "停账单(&X)";
            }
            else
            {
                this.myDataGrid1.TableStyles[0].GridColumnStyles["开嘱转抄"].HeaderText = "开嘱转抄";
                this.myDataGrid1.TableStyles[0].GridColumnStyles["停嘱转抄"].HeaderText = "停嘱转抄";
                this.bt未执行.Text = "未执行(&X)";
            }

            this.myDataGrid1.CaptionText = tabControl1.SelectedTab.Text.Trim();
            this.myDataGrid1.Refresh();
            this.myDataGrid3_Clear();
            this.priceInfo1.ClearYpInfo();

            //add By jchl 2015-06-11 显示界面上医嘱及费用合计
            decimal sdVal = 0M;
            if (isSSMZ && !chkWardOrder.Checked)
            {
                lblSsMzFee.Visible = true;
                try
                {
                    DoCntSsMzFee(myTb, out sdVal);
                }
                catch
                { }
                lblSsMzFee.Text = "手麻费用合计：" + sdVal.ToString("0.00");
            }

            //			PubStaticFun.ModifyDataGridStyle(myDataGrid1,0);
            PubStaticFun.ModifyDataGridStyle(myDataGrid2, 0);
            //			DataGridTextboxAddDoubleClick(myDataGrid1,0);双击后要触发4次？？？Tany 2007-03-15
        }

        private int GetMNGType()
        {
            switch (this.tabControl1.SelectedTab.Text.Trim())
            {
                case "有效长嘱":
                    return 0;
                case "有效临嘱":
                    return 1;
                case "有效长期账单":
                    return 2;
                case "有效临时账单":
                    return 3;
                case "所有长嘱":
                    return 0;
                case "所有临嘱":
                    return 1;
                case "所有长期账单":
                    return 2;
                case "所有临时账单":
                    return 3;
                default:
                    return 0;
            }
        }


        private void CheckGrdData(DataTable myTb, int nType)
        {
            if (myTb.Rows.Count == 0) return;

            string sNum = "";
            int i = 0, iDay = 0, iTime = 0;                //记录上一个显示日期和时间的行号
            int l = 0, group_rows = 1;    //同组中的医嘱个数
            int ii = 0;
            this.sPaint = "";
            this.sPaintPS = "";
            this.sPaintWZX = "";

            #region 算出长度
            max_len0 = 0;
            max_len1 = 0;
            max_len2 = 0;
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                sNum = this.GetNumUnit(myTb, i);
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
                //最长医嘱
                max_len0 = max_len0 > l ? max_len0 : l;
                if (sNum.Trim() != "")
                {
                    //最长医嘱
                    max_len1 = max_len1 > l ? max_len1 : l;
                    l = System.Text.Encoding.Default.GetByteCount(sNum);
                    //最长单位
                    max_len2 = max_len2 > l ? max_len2 : l;
                }
            }
            #endregion

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                #region 显示日期时间
                if (myTb.Rows[i]["开日期"].ToString() == "" && i == 0)
                {
                    myTb.Rows[i]["开日期"] = DateTime.Parse(myTb.Rows[i]["ORDER_BDATE"].ToString()).ToString("M-dd");
                }
                else if (myTb.Rows[i]["开日期"].ToString() != "")
                {
                    //  myTb.Rows[i]["开日期"] = myFunc.getDate(myTb.Rows[i]["开日期"].ToString().Trim(), myTb.Rows[i]["day1"].ToString().Trim());
                    myTb.Rows[i]["开日期"] = DateTime.Parse(myTb.Rows[i]["ORDER_BDATE"].ToString()).ToString("M-dd");
                }

                if (myTb.Rows[i]["开时间"].ToString() != "")
                {
                    myTb.Rows[i]["开时间"] = DateTime.Parse(myTb.Rows[i]["ORDER_BDATE"].ToString()).ToString("H:mm");
                }
                else if (myTb.Rows[i]["开时间"].ToString() == "" && i == 0)
                {
                    myTb.Rows[i]["开时间"] = DateTime.Parse(myTb.Rows[i]["ORDER_BDATE"].ToString()).ToString("H:mm");
                }

                //修改屏蔽
                //myTb.Rows[i]["开日期"] = myFunc.getDate(myTb.Rows[i]["开日期"].ToString().Trim(), myTb.Rows[i]["day1"].ToString().Trim());
                //myTb.Rows[i]["开时间"] = myFunc.getTime(myTb.Rows[i]["开时间"].ToString().Trim(), myTb.Rows[i]["second1"].ToString().Trim());
                myTb.Rows[i]["停日期"] = myFunc.getDate(myTb.Rows[i]["停日期"].ToString().Trim(), myTb.Rows[i]["day2"].ToString().Trim());
                myTb.Rows[i]["停时间"] = myFunc.getTime(myTb.Rows[i]["停时间"].ToString().Trim(), myTb.Rows[i]["second2"].ToString().Trim());
                if (i != 0)
                {
                    if (myTb.Rows[i]["开日期"].ToString().Trim() == myTb.Rows[iDay]["开日期"].ToString().Trim())
                    {
                        myTb.Rows[i]["开日期"] = System.DBNull.Value;
                    }
                    else
                    {
                        iDay = i;
                    }
                    // 时间相同，日期不同要显示时间 Modify by zouchihua 2012-11-14
                    if (myTb.Rows[i]["开时间"].ToString().Trim() == myTb.Rows[iTime]["开时间"].ToString().Trim() && (myTb.Rows[i]["开日期"].ToString().Trim() == myTb.Rows[iTime]["开日期"].ToString().Trim() || myTb.Rows[i]["开日期"].ToString().Trim() == ""))
                    {
                        myTb.Rows[i]["开时间"] = System.DBNull.Value;
                    }
                    else
                    {
                        iTime = i;
                    }
                }
                #endregion
                #region 显示医嘱内容

                //“医嘱内容”+= “医嘱内容”+“空格”+“数量单位”
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["医嘱内容"].ToString().Trim());
                sNum = this.GetNumUnit(myTb, i);
                if (sNum.Trim() != "")
                    myTb.Rows[i]["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString().Trim() + myFunc.Repeat_Space(max_len1 - l) + sNum;//加一个空格 Modify by zouchiua 2012-6-29
                else
                    myTb.Rows[i]["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString().Trim() + myFunc.Repeat_Space(max_len0 - l) + sNum;

                if ((i == myTb.Rows.Count - 1) || (i != myTb.Rows.Count - 1 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i + 1]["Group_id"].ToString().Trim()))
                {
                    //如果是最后一行或本行和上一行的医嘱号不一致

                    //同组中第一条医嘱的“医嘱内容”+=“用法”+“滴速”+ “频率”
                    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1]["医嘱内容"].ToString().Trim());
                    if (sNum.Trim() != "")
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(max_len1 + max_len2 - l + 4);//Modify By Tany 2005-01-25			
                    else
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(max_len2 + 4);//Modify By Tany 2005-01-25
                    #region 新增
                    if (myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim() != "")
                    {
                        if (!myTb.Rows[i - group_rows + 1]["医嘱内容"].ToString().Trim().Contains(myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim()))
                        {
                            myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();
                        }
                    }
                    if (myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim() != "")
                    {
                        if (!myTb.Rows[i - group_rows + 1]["医嘱内容"].ToString().Trim().Contains(myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim()))
                        {
                            myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim();// +"滴/min"; Modify by zouchihua 2012-4-27先去调
                        }
                    }
                    #endregion
                    //暂时屏蔽，如果有错误，把上面的屏蔽，这里放开
                    //if (myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();
                    //if (myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim();// +"滴/min"; Modify by zouchihua 2012-4-27先去调
                    if (myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != ""
                        && myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "1"
                        //						&&(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 
                        //						    ||(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD"))
                        )
                        if (!myTb.Rows[i - group_rows + 1]["医嘱内容"].ToString().Trim().Contains(myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim()))
                        {
                            myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                        }
                    // myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                    int cd = 0;
                    //add by zouchihua 2012-6-23 增加天数
                    if ((nType == 1 || nType == 5) && myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() != ""
                        && int.Parse(myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim()) > 1
                        //						&&(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 
                        //						    ||(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD"))
                        )
                    {
                        cd = System.Text.Encoding.Default.GetByteCount(" " + myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() + "天");
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += " " + myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() + "天" + myFunc.Repeat_Space(6 - cd);
                    }
                    else
                    {
                        myTb.Rows[i - group_rows + 1]["医嘱内容"] += myFunc.Repeat_Space(6 - cd);
                    }
                    int len = 0;
                    for (int x = 0; x < group_rows; x++)
                    {

                        #region//总量显示
                        if ((nType == 1 || nType == 5) && Convert.ToInt32(myTb.Rows[i - group_rows + 1 + x]["ntype"].ToString().Trim()) < 4 && myTb.Rows[i - group_rows + 1 + x]["zsl"].ToString().Trim() != "")//如果是药品
                        {
                            string ssNum = "";

                            if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1 + x]["zsl"]) == Convert.ToInt64(myTb.Rows[i - group_rows + 1 + x]["zsl"]))
                            {
                                ssNum = String.Format("{0:F0}", myTb.Rows[i - group_rows + 1 + x]["zsl"]).Trim();
                                if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1 + x]["zsl"]) == 0)
                                    ssNum = "";
                            }
                            else
                            {
                                ssNum = String.Format("{0:F3}", myTb.Rows[i - group_rows + 1 + x]["zsl"]).Trim();
                            }
                            if (x == 0)
                            {
                                len = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1 + x]["医嘱内容"].ToString());
                                myTb.Rows[i - group_rows + 1 + x]["医嘱内容"] += " " + ssNum + myTb.Rows[i - group_rows + 1 + x]["zsldw"].ToString().Trim();
                            }
                            else
                            {
                                int blen = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1 + x]["医嘱内容"].ToString());
                                myTb.Rows[i - group_rows + 1 + x]["医嘱内容"] += myFunc.Repeat_Space(len - blen) + " " + ssNum + myTb.Rows[i - group_rows + 1 + x]["zsldw"].ToString().Trim();
                            }
                        }
                        #endregion
                    }

                    //如果一组中的医嘱个数大于1
                    if (group_rows != 1)
                    {
                        //[3i2]0 代表第三行是一组医嘱的最后一条，该组医嘱有两条医嘱，status_flag=0
                        this.sPaint += "[" + i.ToString() + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i]["status_flag"].ToString().Trim();
                    }

                    ii = i - group_rows + 1;

                    group_rows = 1;
                }
                else
                {
                    try
                    {

                        //如果不是第一行，且本行和下一行的医嘱号一致
                        myTb.Rows[i]["开嘱医生"] = System.DBNull.Value;
                        myTb.Rows[i]["开嘱转抄"] = System.DBNull.Value;
                        myTb.Rows[i]["开嘱核对"] = System.DBNull.Value;
                        myTb.Rows[i]["停日期"] = System.DBNull.Value;
                        myTb.Rows[i]["停时间"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱医生"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱转抄"] = System.DBNull.Value;
                        myTb.Rows[i]["停嘱核对"] = System.DBNull.Value;
                        if (myTb.Rows[i]["ntype"].ToString() == "1" || myTb.Rows[i]["ntype"].ToString() == "2" || myTb.Rows[i]["ntype"].ToString() == "3") group_rows += 1;

                        ii = i;
                    }
                    catch (System.Data.OleDb.OleDbException err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
                #region//总量显示
                //if ((nType == 1 || nType == 5) && Convert.ToInt32(myTb.Rows[i]["ntype"].ToString().Trim()) < 4 && myTb.Rows[i]["zsl"].ToString().Trim() != "")//如果是药品
                //{
                //    string ssNum = "";

                //    if (Convert.ToDecimal(myTb.Rows[i]["zsl"]) == Convert.ToInt64(myTb.Rows[i]["zsl"]))
                //    {
                //        ssNum = String.Format("{0:F0}", myTb.Rows[i]["zsl"]).Trim();
                //        if (Convert.ToDecimal(myTb.Rows[i]["zsl"]) == 0)
                //            ssNum = "";
                //    }
                //    else
                //    {
                //        ssNum = String.Format("{0:F3}", myTb.Rows[i]["zsl"]).Trim();
                //    }
                //    myTb.Rows[i]["医嘱内容"] += " " + ssNum + myTb.Rows[i]["zsldw"].ToString().Trim();
                //}
                #endregion
                #endregion

                #region 显示未执行
                if (Convert.ToInt16(myTb.Rows[i]["wzx_flag"]) > 0)
                {
                    this.sPaintWZX += "i" + i.ToString() + "X";
                }
                #endregion

                #region 显示皮试
                //阳性
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 2 &&
                    (myTb.Rows[ii]["医嘱内容"].ToString().Trim().IndexOf("皮试", 0) > 0
                    || myTb.Rows[ii]["医嘱内容"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "+" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["医嘱内容"].ToString().Trim()) + "]";
                }
                #region 显示强阳性皮试 yaokx 2014-05-06
                //加阳性
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 21 &&
                    (myTb.Rows[ii]["医嘱内容"].ToString().Trim().IndexOf("皮试", 0) > 0
                    || myTb.Rows[ii]["医嘱内容"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "++" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["医嘱内容"].ToString().Trim()) + "]";
                }
                //强阳性
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 22 &&
                    (myTb.Rows[ii]["医嘱内容"].ToString().Trim().IndexOf("皮试", 0) > 0
                    || myTb.Rows[ii]["医嘱内容"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "+++" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["医嘱内容"].ToString().Trim()) + "]";
                }
                #endregion
                //阴性
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 1 &&
                    (myTb.Rows[ii]["医嘱内容"].ToString().Trim().IndexOf("皮试", 0) > 0
                    || myTb.Rows[ii]["医嘱内容"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "-" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["医嘱内容"].ToString().Trim()) + "]" + myTb.Rows[ii]["status_flag"].ToString().Trim();
                }
                #endregion
            }
            this.myDataGrid1.DataSource = myTb;
        }

        //返回“数量+单位”，检查是否显示小数
        private string GetNumUnit(DataTable myTb, int i)
        {
            string sNum = "";
            if (Convert.ToDecimal(myTb.Rows[i]["Num"]) == Convert.ToInt64(myTb.Rows[i]["Num"]))
            {
                sNum = String.Format("{0:F0}", myTb.Rows[i]["Num"]).Trim();
            }
            else
            {
                sNum = String.Format("{0:F3}", myTb.Rows[i]["Num"]).Trim();
            }
            //Modify By Tany 2004-10-27
            if ((sNum == "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "1"
                && myTb.Rows[i]["ntype"].ToString().Trim() != "2"
                && myTb.Rows[i]["ntype"].ToString().Trim() != "3"
                && GetMNGType() != 2
                && GetMNGType() != 3)
                || sNum == "0" || sNum == "")
                return "";
            else
                return "" + sNum + myTb.Rows[i]["Unit"].ToString().Trim();//Modify by zouchihua 2012-6-29 加一个空格
        }


        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.ShowData();
            int mntype = this.GetMNGType();
            if (mntype == 0 || mntype == 1)
            {
                if (cfg7111.Config.Trim() == "1")
                    //add by zouchihua 2012-3-27 只有医嘱才显示术前医嘱打印
                    this.btnSqyzdy.Visible = true;

            }
            else
            {
                if (cfg7111.Config.Trim() == "1")
                    //add by zouchihua 2012-3-27 只有医嘱才显示术前医嘱打印
                    this.btnSqyzdy.Visible = false;
            }
            //add by zouchihua 2011-11-30 只有临时医嘱显示规格列
            if (mntype != 1 && mntype != 0)
            {
                for (int i = 0; i < myDataGrid1.TableStyles[0].GridColumnStyles.Count; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName == "isprintypgg")
                    {
                        myDataGrid1.TableStyles[0].GridColumnStyles[i].Width = 0;
                    }
                }
            }
            else
            {

                //add by zouchihua 2011-11-30
                int isggwide = 0;
                try
                {
                    //护士站医嘱管理是否显示打”印规格列“
                    if (new SystemCfg(7802).Config.ToString().Trim() == "1")
                    {
                        for (int i = 0; i < myDataGrid1.TableStyles[0].GridColumnStyles.Count; i++)
                        {
                            if (myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName == "isprintypgg")
                            {
                                myDataGrid1.TableStyles[0].GridColumnStyles[i].Width = 60;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            if (rbTrans.Checked && cfg7159.Config.Trim() == "1")
            {
                bt未执行.Visible = false;
                if (bt未执行.Text.Contains("停"))
                    bt未执行.Visible = true;
            }
            //得到病人基本信息
            this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);
            if (new SystemCfg(7202).Config == "1")
            {
                this.tabPage10.Hide();
                this.tabControl2.SelectedIndex = 0;
                this.ucWzxm1.Itemidsf = "";
                this.ucWzxm1.BingData();
            }

            if (isSSMZ) //add pengyang 2015-7-29
            {
                System.Collections.Generic.Dictionary<Button, bool> dict = new System.Collections.Generic.Dictionary<Button, bool>();
                if (tabControl1.SelectedTab == tabPage6)
                {
                    dict.Add(bt立即执行, false);
                    dict.Add(bt预算, false);
                    dict.Add(bt详细信息, false);
                    dict.Add(bt医嘱打印, false);
                    dict.Add(bt取消开医嘱核对, false);
                    dict.Add(BtnTszlZcQm, false);
                    dict.Add(btnCheck, false);
                    dict.Add(btnDelete, false);
                    dict.Add(butorderprint, false);
                    dict.Add(bt执行时间, false);
                    dict.Add(bt退出, true);
                }
                else if (tabControl1.SelectedTab == tabPage7)
                {
                    dict.Add(bt立即执行, true);
                    dict.Add(bt预算, true);
                    dict.Add(bt详细信息, true);
                    dict.Add(bt医嘱打印, true);
                    dict.Add(bt取消开医嘱核对, true);
                    dict.Add(BtnTszlZcQm, true);
                    dict.Add(btnCheck, true);
                    dict.Add(btnDelete, false);
                    dict.Add(butorderprint, true);
                    dict.Add(bt执行时间, true);
                    dict.Add(bt退出, true);
                }
                else
                {
                    dict.Add(bt立即执行, true);
                    dict.Add(bt预算, true);
                    dict.Add(bt详细信息, true);
                    dict.Add(bt医嘱打印, true);
                    dict.Add(bt取消开医嘱核对, false);
                    dict.Add(BtnTszlZcQm, true);
                    dict.Add(btnCheck, true);
                    dict.Add(btnDelete, false);
                    dict.Add(butorderprint, true);
                    dict.Add(bt执行时间, false);
                    dict.Add(bt退出, true);
                }
                if (dict.Count < 1)
                    return;
                foreach (System.Collections.Generic.KeyValuePair<Button, bool> pair in dict)
                    pair.Key.Enabled = pair.Value;
            }
        }

        private void bt取消开医嘱核对_EnabledChanged(object sender, EventArgs e)
        {
            if ((isSSMZ && tabControl1.SelectedTab == tabPage6))    //add pengyang 2015-7-30
            {
                bt取消开医嘱核对.EnabledChanged -= bt取消开医嘱核对_EnabledChanged;
                bt取消开医嘱核对.Enabled = false;
                bt取消开医嘱核对.EnabledChanged += bt取消开医嘱核对_EnabledChanged;
            }
        }

        private void myDataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
        {
            DataTable myTb1 = (DataTable)myDataGrid2.DataSource;
            if (myTb1 == null || myTb1.Rows.Count == 0)
            {
                return;
            }

            if ((myDataGrid2.DataSource as DataTable).DefaultView.Count <= 0)
                return;

            int nrow = this.myDataGrid2.CurrentCell.RowNumber;
            this.myDataGrid2.Select(nrow);

            DataRow dr;

            if (!ucShowCard1.Key.Trim().Equals(""))
            {
                DataRow[] drs = myTb1.Select("inpatient_id='" + ucShowCard1.Key + "'");
                if (drs.Length <= 0)
                    return;

                dr = drs[0];
            }
            else
            {
                dr = myTb1.Rows[nrow];
            }

            //Modify By Tany 2010-01-29 有床号显示床号，没有床号显示住院号
            string bz = "";
            if (myTb1.Columns.Contains("床号"))
            {
                //bz = "(" + Convert.ToString(myTb1.Rows[nrow]["床号"]).Trim() + "床)";
                bz = "(" + Convert.ToString(dr["床号"]).Trim() + "床)";
            }
            else if (myTb1.Columns.Contains("住院号"))
            {
                //bz = "(" + Convert.ToString(myTb1.Rows[nrow]["住院号"]).Trim() + ")";
                bz = "(" + Convert.ToString(dr["住院号"]).Trim() + ")";
            }
            //this.sName = Convert.ToString(myTb1.Rows[nrow]["姓名"]).Trim() + bz;
            //ClassStatic.Current_BinID = new Guid(myTb1.Rows[nrow]["inpatient_id"].ToString());
            //ClassStatic.Current_BabyID = Convert.ToInt64(myTb1.Rows[nrow]["baby_id"]);
            //ClassStatic.Current_DeptID = Convert.ToInt64(myTb1.Rows[nrow]["dept_id"]);
            //ClassStatic.Current_isMY = Convert.ToInt16(myTb1.Rows[nrow]["ismy"]);
            this.sName = Convert.ToString(dr["姓名"]).Trim() + bz;
            ClassStatic.Current_BinID = new Guid(dr["inpatient_id"].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(dr["baby_id"]);
            ClassStatic.Current_DeptID = Convert.ToInt64(dr["dept_id"]);
            ClassStatic.Current_isMY = Convert.ToInt16(dr["ismy"]);

            //得到病人基本信息
            this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb != null) myTb.Rows.Clear();
            this.myDataGrid1.DataSource = myTb;

            this.ShowData();
        }


        private void myDataGrid1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0)
            {
                this.priceInfo1.ClearYpInfo();
                return;
            }

            //如果是医嘱内容列
            if (ncol == 25)
            {
                //显示药品信息
                myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb.Rows.Count > 0)
                {
                    double myNUM = 0;
                    int myCJID = Convert.ToInt32(myTb.Rows[nrow]["hoitem_id"]);
                    //add by zouchihua 2012-6-22 如果临时医嘱，总量
                    if (this.tabControl1.SelectedTab.Text.IndexOf("临嘱") >= 0)
                    {
                        if (myTb.Rows[nrow]["zsl"].ToString() != "")
                            myNUM = Convert.ToDouble(myTb.Rows[nrow]["zsl"]);
                        else
                            myNUM = Convert.ToDouble(myTb.Rows[nrow]["Num"]);
                    }
                    else
                        myNUM = Convert.ToDouble(myTb.Rows[nrow]["Num"]);
                    int myDWLX = Convert.ToInt32(myTb.Rows[nrow]["dwlx"]);
                    long myEXECDEPT = Convert.ToInt64(myTb.Rows[nrow]["exec_dept"]);
                    int myTYPE = Convert.ToInt32(myTb.Rows[nrow]["nType"]);
                    this.priceInfo1.Order_context = myTb.Rows[nrow]["医嘱内容"].ToString();
                    //有效性判断
                    if (myTYPE < 3 && myTYPE != 0)
                    {
                        //Modify By tany 2011-04-12 获取病人医保类型
                        int yblx = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select yblx from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"));
                        this.priceInfo1.SetYpInfo(myCJID, myNUM, myDWLX, myEXECDEPT, yblx);
                    }
                    else
                    {
                        this.priceInfo1.ClearYpInfo();
                        if (myTYPE == 3)
                        {
                            string sSql = "";
                            if (this.tabControl1.SelectedTab.Text.IndexOf("临嘱") < 0)
                                sSql = " select Order_context 名称 ,Num 数量 ,Unit 单位" +
                                   "   from zy_orderrecord " +
                                   "  where group_id=" + myTb.Rows[nrow]["Group_id"].ToString().Trim() +
                                   "        and mngtype not in (1,5) and delete_bit=0" +
                                   "        and Inpatient_ID ='" + ClassStatic.Current_BinID + "'" +
                                   "        and baby_id=" + ClassStatic.Current_BabyID;
                            else
                                sSql = " select Order_context 名称 ,zsl 数量 ,zsldw 单位" +
                                "   from zy_orderrecord " +
                                "  where group_id=" + myTb.Rows[nrow]["Group_id"].ToString().Trim() +
                                "        and mngtype  in (1,5) and delete_bit=0" +
                                "        and Inpatient_ID ='" + ClassStatic.Current_BinID + "'" +
                                "        and baby_id=" + ClassStatic.Current_BabyID;
                            string[] GrdMappingName3 ={ "名称", "数量", "单位" };
                            int[] GrdWidth3 ={ 13, 8, 4 };
                            int[] Alignment3 ={ 0, 1, 1 };
                            myFunc.InitGridSQL(sSql, GrdMappingName3, GrdWidth3, Alignment3, this.myDataGrid3);
                            this.myDataGrid3.CaptionText = "中草药处方：" + myTb.Rows[nrow]["Dosage"].ToString().Trim() + "付";
                            this.myDataGrid3.Refresh();
                        }
                        else
                        {
                            long HOitem_ID = Convert.ToInt64(Convertor.IsNull(myTb.Rows[nrow]["hoitem_id"].ToString(), "0"));
                            double num = 0;//Convert.ToDouble(Convertor.IsNull(myTb.Rows[nrow]["num"].ToString(), "0"));
                            //add by zouchihua 2012-6-22 如果临时医嘱，总量
                            if (this.tabControl1.SelectedTab.Text.IndexOf("临嘱") >= 0)
                            {
                                if (myTb.Rows[nrow]["zsl"].ToString() != "")
                                    num = Convert.ToDouble(Convertor.IsNull(myTb.Rows[nrow]["zsl"].ToString(), "0"));
                                else
                                    num = Convert.ToDouble(Convertor.IsNull(myTb.Rows[nrow]["num"].ToString(), "0"));
                            }
                            else
                                num = Convert.ToDouble(Convertor.IsNull(myTb.Rows[nrow]["num"].ToString(), "0"));
                            string User_Name = myTb.Rows[nrow]["order_usage"].ToString();

                            //							this.myDataGrid3.TableStyles.Clear();
                            //add by zouchihua 如果医嘱有费用，那么就显示医嘱的费用
                            string order_id = Convert.ToString(Convertor.IsNull(myTb.Rows[nrow]["order_id"].ToString(), Guid.Empty.ToString()));
                            DataTable orderfee = FrmMdiMain.Database.GetDataTable("select  PRICE from ZY_ORDERRECORD where order_id='" + order_id + "'");
                            decimal xmfee = -1;
                            if (orderfee.Rows.Count > 0)
                            {
                                xmfee = decimal.Parse(orderfee.Rows[0]["PRICE"].ToString());
                            }
                            DataTable myTbTemp = myFunc.SetItemInfo("", HOitem_ID, num, User_Name, (new Department(myEXECDEPT, InstanceForm.BDatabase)).Jgbm); //*js);
                            if (xmfee > 0)
                            {
                                myTbTemp.Rows[0]["单价"] = xmfee;
                                myTbTemp.Rows[0]["金额"] = xmfee * Convert.ToDecimal(myTbTemp.Rows[0]["数量"].ToString());
                            }
                            this.myDataGrid3.DataSource = myTbTemp;

                            string[] GrdMappingName4 ={ "id", "名称", "数量", "单位", "单价", "金额" };
                            int[] GrdWidth4 ={ 0, 12, 4, 4, 4, 6 };
                            int[] Alignment4 ={ 0, 0, 0, 0, 0, 0 };
                            int[] Readonly4 ={ 0, 0, 0, 0, 0, 0 };
                            myFunc.InitGrid(GrdMappingName4, GrdWidth4, Alignment4, Readonly4, this.myDataGrid3);

                            this.myDataGrid3.CaptionText = "项目明细";
                            this.myDataGrid3.Refresh();
                        }
                    }

                    if (myTb.Rows.Count > 0)
                    {
                        try
                        {
                            //this.tabPage10.Show();
                            //this.tabControl2.SelectedIndex = 1;
                            string sql = @"select a.HOITEM_ID ,isnull(c.HOITEM_ID,0) glfyyzid from ZY_ORDERRECORD a left join JC_USEAGE_FEE b on  a.ORDER_USAGE=b.USE_NAME
                            left join  JC_HOI_HDI  c on c.HDITEM_ID=b.HSITEM_ID and TC_FLAG<=0 where order_id='" + myTb.Rows[nrow]["order_id"] + "'";
                            DataRow dr = InstanceForm.BDatabase.GetDataRow(sql);
                            int type = 0;
                            if (this.GetMNGType() == 0 || this.GetMNGType() == 2)
                            {
                                type = 2;
                            }
                            else
                            {
                                type = 3;
                            }
                            this.ucWzxm1.Itemidsf = myTb.Rows[nrow]["HOITEM_ID"].ToString();
                            this.ucWzxm1.Order_id = myTb.Rows[nrow]["order_id"].ToString();//add by zouchihua 2014-8-25 增加原来的医嘱id
                            this.ucWzxm1.Fjfy_yzid = int.Parse(myTb.Rows[nrow]["glfyyzid"].ToString());//add by zouchihua 2014-8-25 增加关联费用的医嘱id
                            this.ucWzxm1.BinID = ClassStatic.Current_BinID;
                            this.ucWzxm1.BabyID = ClassStatic.Current_BabyID;
                            this.ucWzxm1.RbIn = rbIn.Checked ? true : false;
                            this.ucWzxm1.Yztype = type;
                            this.ucWzxm1.IsSSMZ = isSSMZ;
                            this.ucWzxm1.RbTszl = rbTszl.Checked ? true : false;
                            this.ucWzxm1.MyTb = myTb;
                            this.ucWzxm1.Nrow = nrow;
                            this.ucWzxm1.First_times = dr["first_times"].ToString();
                            this.ucWzxm1.Dept_id = Convert.ToInt32(dr["DEPT_ID"].ToString());
                            this.ucWzxm1.BingData();
                        }
                        catch { }

                    }
                    else
                    {
                        this.tabPage10.Hide();
                        this.tabControl2.SelectedIndex = 0;
                    }

                    //add by zouchihua 2012-6-15 未执行的理由
                    if (Convert.ToInt16(myTb.Rows[nrow]["wzx_flag"]) > 0)
                    {
                        RichTextBox txtb = new RichTextBox();
                        txtb.ReadOnly = true;
                        txtb.Dock = DockStyle.Fill;
                        txtb.Multiline = true;
                        txtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        txtb.BackColor = ReasenPanel.BackColor;
                        txtb.Width = ReasenPanel.Width;
                        txtb.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        DataTable tb11 = null;
                        if (myTb.Rows[nrow]["order_id"].ToString() != Guid.Empty.ToString())
                            tb11 = FrmMdiMain.Database.GetDataTable("select memo2 from zy_orderrecord where order_id='" + myTb.Rows[nrow]["order_id"].ToString() + "'");
                        else
                            tb11 = FrmMdiMain.Database.GetDataTable("select memo2 from zy_orderrecord where group_id='" + myTb.Rows[nrow]["group_id"].ToString() + "' and inpatient_id='" + ClassStatic.Current_BinID + "'");
                        txtb.Text = "未执行原因:【 " + tb11.Rows[0]["memo2"].ToString() + " 】";
                        ReasenPanel.Controls.Clear();
                        ReasenPanel.Controls.Add(txtb);
                        Rectangle rt = this.myDataGrid1.GetCurrentCellBounds();
                        Point pt = new Point(this.myDataGrid1.Left + this.myDataGrid1.Parent.Left + this.myDataGrid1.Parent.Parent.Left + rt.Location.X, this.myDataGrid1.Top + this.myDataGrid1.Parent.Top + this.myDataGrid1.Parent.Parent.Top + rt.Location.Y + rt.Height + 30);
                        ReasenPanel.Location = pt;
                        ReasenPanel.BringToFront();
                        ReasenPanel.Visible = true;
                        ReasenPanel.Show();
                    }
                    else
                    {
                        ReasenPanel.Hide();
                        ReasenPanel.Visible = false;
                    }
                }

            }
            else
            {
                ReasenPanel.Hide();
                ReasenPanel.Visible = false;
            }


        }

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            this.myDataGrid3_Clear();
            myFunc.SelRow(this.myDataGrid3);
            //add yaokx  2014-06-03
            int nrow = 0;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int nType = this.GetMNGType();

            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            if (nType == 1 || nType == 5)
            {
                if (myTb.Rows[nrow]["医嘱内容"].ToString().IndexOf("取消") >= 0)
                {
                    this.bt执行时间.Enabled = false;
                }
                else
                {
                    this.bt执行时间.Enabled = true;
                }
            }
        }

        private void myDataGrid1_Click(object sender, System.EventArgs e)
        {
            //控制BOOL列
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //提交网格数据
            if (ncol > 0 && nrow > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            //add yaokx  2014-06-03
            int nType = this.GetMNGType();
            if (nType == 1 || nType == 5)
            {
                if (myTb.Rows[nrow]["医嘱内容"].ToString().IndexOf("取消") >= 0)
                {
                    this.bt执行时间.Enabled = false;
                }
                else
                {
                    this.bt执行时间.Enabled = true;
                }
            }
            //-是否允许护士站可以点击取消打印 0=否，1=是
            string cfg7106 = new SystemCfg(7106).Config.Trim();//add by zouchihua 2012-3-9
            if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.ToUpper().Trim() == "P")
            {
                //add by zouchihua 2012-3-9
                if (cfg7106 == "0")
                    return;
                bool del_print = Convert.ToBoolean(myTb.Rows[nrow]["P"]);
                Guid order_id = new Guid(myTb.Rows[nrow]["order_id"].ToString());
                string ssql = " ";
                int zcy = 0;
                //add by zouchihua 2012-5-22 中草药处方
                if (myTb.Rows[nrow]["医嘱内容"].ToString().IndexOf("中草药处方") >= 0)
                {
                    zcy = 1;
                    ssql = "select order_id from zy_tmporderprt(nolock) where order_id in( select order_id from zy_orderrecord where ntype=3 and  inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["group_id"].ToString() + " )"
                       + " union all select order_id from zy_logorderprt(nolock) where order_id in( select order_id from zy_orderrecord where ntype=3 and  inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["group_id"].ToString() + " )";
                }
                else
                    ssql = "select order_id from zy_tmporderprt(nolock) where order_id='" + order_id + "' union all select order_id from zy_logorderprt(nolock) where order_id='" + order_id + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count != 0)
                {
                    MessageBox.Show("该条医嘱已被生成到医嘱打印序列,不能取消打印\n 只要在医嘱打印中预览过,则被生成打印序列", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (del_print == true)
                {
                    if (MessageBox.Show(this, "您要该医嘱 [要] 打印吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                }
                else
                {
                    if (MessageBox.Show(this, "确定该医嘱 [不要] 打印吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                }

                if (del_print == true)
                {
                    if (zcy == 0)
                        ssql = "update zy_orderrecord set del_print=0 where order_id='" + order_id + "'";
                    else
                        ssql = "update zy_orderrecord set del_print=0 where order_id in( select order_id from zy_orderrecord where ntype=3 and  inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["group_id"].ToString() + " )";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    myTb.Rows[nrow]["P"] = false;
                }
                else
                {
                    if (zcy == 0)
                        ssql = "update zy_orderrecord set del_print=1 where order_id='" + order_id + "'";
                    else
                        ssql = "update zy_orderrecord set del_print=1 where order_id in( select order_id from zy_orderrecord where ntype=3 and  inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["group_id"].ToString() + " )";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    myTb.Rows[nrow]["P"] = true;
                }

            }
            else
                if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() == "isprintypgg")//add by zouchihua 2011-11-30
                {
                    //add by zouchihua 2012-3-9
                    if (cfg7106 == "0")
                        return;
                    bool del_print = Convert.ToBoolean(myTb.Rows[nrow]["isprintypgg"]);

                    Guid order_id = new Guid(myTb.Rows[nrow]["order_id"].ToString());
                    string ssql = " ";
                    ssql = "select order_id from zy_tmporderprt(nolock) where order_id='" + order_id + "' union all select order_id from zy_logorderprt(nolock) where order_id='" + order_id + "'";
                    DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb.Rows.Count != 0)
                    {
                        MessageBox.Show("该条医嘱已被生成到医嘱打印序列,不能操作！！\n 只要在医嘱打印中预览过,则被生成打印序列", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    if (del_print == true)
                    {
                        if (MessageBox.Show(this, "确定该医嘱规格[不要] 打印吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }
                    else
                    {
                        if (MessageBox.Show(this, "您要该医嘱规格 [要] 打印吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }

                    if (del_print == true)
                    {
                        ssql = "update zy_orderrecord set isprintypgg=0 where order_id='" + order_id + "'";
                        InstanceForm.BDatabase.DoCommand(ssql);
                        myTb.Rows[nrow]["isprintypgg"] = false;
                    }
                    else
                    {
                        ssql = "update zy_orderrecord set isprintypgg=1 where order_id='" + order_id + "'";
                        InstanceForm.BDatabase.DoCommand(ssql);
                        myTb.Rows[nrow]["isprintypgg"] = true;
                    }

                }
            //非"选"字段
            if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() != "选") return;
            if (nrow > myTb.Rows.Count - 1) return;

            if (myTb.Rows[nrow]["选"].ToString().Trim() == "1")
            {
                myTb.Rows[nrow]["选"] = false;
                return;
            }

            bool isResult = myTb.Rows[nrow]["选"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["选"] = isResult;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["Group_id"].ToString().Trim() == myTb.Rows[nrow]["Group_id"].ToString().Trim()
                    && myTb.Rows[i]["选"].ToString() != isResult.ToString())
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                    myTb.Rows[i]["选"] = isResult;
                    //this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
                }
            }


            this.myDataGrid1.DataSource = myTb;
            //this.myDataGrid1.CurrentCell=new DataGridCell(nrow,ncol);			
        }

        /// <summary>
        /// 计算字符串中子串出现的次数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="substring">子串</param>
        /// <returns>出现的次数</returns>
        private int SubstringCount(string str, string substring)
        {
            if (str.Contains(substring))
            {
                string strReplaced = str.Replace(substring, "");
                return (str.Length - strReplaced.Length) / substring.Length;
            }

            return -1;
        }
        private void myDataGrid1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb == null) return;
                if (myTb.Rows.Count == 0) return;

                int i = 0;
                int yDelta = this.myDataGrid1.GetCellBounds(i, 0).Height + 1;
                int y = this.myDataGrid1.GetCellBounds(i, 0).Top + 2;

                int index_start = 0, index_i = 0, index_p = 0, index_end = 0;
                int start_row = 0, start_point = 0;

                CurrencyManager cm = (CurrencyManager)this.BindingContext[this.myDataGrid1.DataSource, this.myDataGrid1.DataMember];

                while (y < this.myDataGrid1.Height - yDelta && i < cm.Count)
                {
                    y += yDelta;

                    try
                    {
                        //未执行
                        index_start = this.sPaintWZX.IndexOf("i" + i.ToString() + "X", 0, this.sPaintWZX.Trim().Length);
                        if (index_start >= 0)
                        {
                            e.Graphics.DrawString("未执行", this.myDataGrid1.Font, new SolidBrush(Color.Red), 650, y - yDelta);
                        }
                    }
                    catch { }

                    try
                    {
                        //皮试+
                        int count = SubstringCount(this.sPaintPS.ToString(), "+");
                        index_start = this.sPaintPS.IndexOf("[" + i.ToString() + "+", 0, this.sPaintPS.Trim().Length);
                        if (index_start >= 0)
                        {
                            //313/224
                            index_p = this.sPaintPS.IndexOf("+", index_start, this.sPaintPS.Trim().Length - index_start);
                            index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                            string strCtn = sPaintPS.Substring(index_start + 1, index_end - index_start - 1);
                            count = SubstringCount(strCtn.ToString(), "+");
                            if (index_start >= 0 && count == 1)//&& count==1这个要去掉
                            {
                                start_point = 119 + Convert.ToInt16(this.sPaintPS.Substring(index_p + 1, index_end - index_p - 1)) * 6;
                                e.Graphics.DrawString("(+)", this.myDataGrid1.Font, new SolidBrush(Color.Red), start_point - 100, y - yDelta);

                            }
                        }
                    }
                    catch { }

                    try
                    {
                        int count = SubstringCount(this.sPaintPS.ToString(), "+");
                        //皮试++
                        index_start = this.sPaintPS.IndexOf("[" + i.ToString() + "++", 0, this.sPaintPS.Trim().Length);
                        if (index_start >= 0)
                        {
                            index_p = this.sPaintPS.IndexOf("++", index_start, this.sPaintPS.Trim().Length - index_start);
                            index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                            string strCtn = sPaintPS.Substring(index_start + 1, index_end - index_start - 1);
                            count = SubstringCount(strCtn.ToString(), "+");
                            if (index_start >= 0 && count == 2)
                            {
                                //313/224
                                index_p = this.sPaintPS.IndexOf("++", index_start, this.sPaintPS.Trim().Length - index_start);
                                index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                                start_point = 119 + Convert.ToInt16(this.sPaintPS.Substring(index_p + 2, index_end - index_p - 2)) * 6;
                                e.Graphics.DrawString("(++)", this.myDataGrid1.Font, new SolidBrush(Color.Red), start_point - 100, y - yDelta);

                            }
                        }
                    }
                    catch { }

                    try
                    {
                        //皮试+
                        int count = SubstringCount(this.sPaintPS.ToString(), "+");
                        //皮试+++
                        index_start = this.sPaintPS.IndexOf("[" + i.ToString() + "+++", 0, this.sPaintPS.Trim().Length);
                        if (index_start >= 0)
                        {
                            index_p = this.sPaintPS.IndexOf("+++", index_start, this.sPaintPS.Trim().Length - index_start);
                            index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                            string strCtn = sPaintPS.Substring(index_start + 1, index_end - index_start - 1);
                            count = SubstringCount(strCtn.ToString(), "+");
                            if (index_start >= 0 && count == 3)
                            {
                                index_p = this.sPaintPS.IndexOf("+++", index_start, this.sPaintPS.Trim().Length - index_start);
                                index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                                start_point = 119 + Convert.ToInt16(this.sPaintPS.Substring(index_p + 3, index_end - index_p - 3)) * 6;
                                e.Graphics.DrawString("(+++)", this.myDataGrid1.Font, new SolidBrush(Color.Red), start_point - 100, y - yDelta);

                            }
                        }
                    }
                    catch { }

                    try
                    {
                        //皮试-
                        index_start = this.sPaintPS.IndexOf("[" + i.ToString() + "-", 0, this.sPaintPS.Trim().Length);
                        if (index_start >= 0)
                        {
                            index_p = this.sPaintPS.IndexOf("-", index_start, this.sPaintPS.Trim().Length - index_start);
                            index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                            start_point = 119 + Convert.ToInt16(this.sPaintPS.Substring(index_p + 1, index_end - index_p - 1)) * 6;
                            switch (this.sPaintPS.Substring(index_end + 1, 1))
                            {
                                case "1":  //未审核
                                    e.Graphics.DrawString("(-)", this.myDataGrid1.Font, new SolidBrush(Color.Black), start_point - 100, y - yDelta);
                                    break;
                                case "5":  //已停止
                                    e.Graphics.DrawString("(-)", this.myDataGrid1.Font, new SolidBrush(Color.Gray), start_point - 100, y - yDelta);
                                    break;
                                default: //已审核
                                    e.Graphics.DrawString("(-)", this.myDataGrid1.Font, new SolidBrush(Color.Blue), start_point - 100, y - yDelta);
                                    break;
                            }

                        }
                    }
                    catch { }

                    try
                    {
                        //组线
                        index_start = this.sPaint.IndexOf("[" + i.ToString() + "i", 0, this.sPaint.Trim().Length);
                        if (index_start >= 0)
                        {
                            index_i = index_start + i.ToString().Trim().Length + 1;
                            index_end = this.sPaint.IndexOf("]", index_i, this.sPaint.Trim().Length - index_i);
                            start_row = Convert.ToInt16(this.sPaint.Substring(index_i + 1, index_end - index_i - 1));
                            if (this.max_len1 == 0) start_point = 119 + (this.max_len0 + 4) * 6;
                            else start_point = 119 + (this.max_len1 + this.max_len2 + 4) * 6;
                            switch (this.sPaint.Substring(index_end + 1, 1))
                            {
                                case "1":  //未审核
                                    e.Graphics.DrawLine(System.Drawing.Pens.Black, start_point, y - start_row * yDelta, start_point, y - 5);
                                    break;
                                case "5":  //已停止
                                    e.Graphics.DrawLine(System.Drawing.Pens.Gray, start_point, y - start_row * yDelta, start_point, y - 5);
                                    break;
                                default: //已审核
                                    e.Graphics.DrawLine(System.Drawing.Pens.Blue, start_point, y - start_row * yDelta, start_point, y - 5);
                                    break;
                            }
                        }
                    }
                    catch { }

                    i++;
                }
            }
            catch { }
        }


        private void bt全选_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["status_flag"].ToString().Trim() == "1") continue;
                this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                if (tabControl1.SelectedTab == tabPage7)
                {
                    if (myTb.Rows[i]["执行时间"].ToString().Trim().Equals(""))
                    {
                        myTb.Rows[i]["选"] = true;
                    }
                    else
                    {
                        myTb.Rows[i]["选"] = false;
                    }
                }
                else
                {
                    myTb.Rows[i]["选"] = true;
                }
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private void bt反选_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["status_flag"].ToString().Trim() == "1") continue;
                this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                myTb.Rows[i]["选"] = myTb.Rows[i]["选"].ToString() == "True" ? false : true;
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private void bt显示切换_Click(object sender, System.EventArgs e)
        {
            if (this.panel右下.Height == 176)
            {
                this.panel右下.Height = 48;
                this.myDataGrid1.Height = 640;
            }
            else
            {
                this.myDataGrid1.Height = 512;
                this.panel右下.Height = 176;
            }

        }

        private void bt立即执行_Click(object sender, System.EventArgs e)
        {

            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //如果病人在老系统已经出院审核，则不允许再记费
            if (TrasenHIS.BLL.CheckPatientInfo.isCysh(patientInfo1.lbID.Text.ToString().Trim()))
            {
                MessageBox.Show("该病人在住院处已经出院审核，不能发送医嘱！请联系住院处", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            #region//Add by Zouchihua 2011-10-12 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
            string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
            int BrJgbm = Convert.ToInt32(rtnSql[1]);
            #endregion
            string sSql = "";
            string sGroupId = "-1";
            string sMsg = "";
            string sEnableGroup = "";
            int iSelectRows = 0;
            DataTable myTb = (DataTable)myDataGrid1.DataSource;

            //Modify By Tany 2015-05-11 麻醉科是否只有主任可以发送医嘱
            if (isSSMZ && ssmzType == 1)
            {
                //麻醉科发送医嘱时，是否只能主任医师级别才能发送 0=否 1=是
                if (new SystemCfg(9101).Config == "1")
                {
                    try
                    {
                        Doctor doc = new Doctor(InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);
                        if (doc.TypeID != 1)
                        {
                            throw new Exception("该用户医生级别不是主任医师！");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("麻醉医嘱只有主任才能发送，请重新确认身份！\r\n" + ex.Message);
                        return;
                    }
                }
            }

            #region 有效性判断
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True")
                {
                    iSelectRows += 1;
                }
            }
            #endregion

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "对不起，没有选择医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmBRFS f2 = new frmBRFS();
            if (isSSMZ)
            {
                f2.grpCQYZ.Enabled = false;
                f2.grpCQZD.Enabled = false;
                f2.rb全部发送.Enabled = false;
                f2.rb00.Enabled = false;
                f2.rb01.Enabled = false;
                f2.rb02.Enabled = false;
                f2.rb10.Enabled = false;
                f2.rb20.Enabled = false;
                f2.rb21.Enabled = false;
                f2.rb22.Enabled = false;
                f2.rb30.Enabled = false;
            }
            f2.nType = this.GetMNGType();
            f2.ShowDialog();

            if (f2.DialogResult == DialogResult.Cancel)
                return;

            int iSelect = f2.iSelect;
            if (iSelect == 2) return;
            int iSelect0 = f2.iSelect0;
            int iSelect1 = f2.iSelect1;
            int iSelect2 = f2.iSelect2;
            int iSelect3 = f2.iSelect3;
            bool IsChangeExecDept = f2.IsChangeExecDept;
            int newExecDept = f2.newExecDept;
            DateTime ExecDate = f2.execDateTime;
            ((Button)sender).Tag = f2.execDateTime;



            //Modify by jchl 2016-12-28-----------------------------------------
            DateTime serDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//PubStaticFun.GetDateFromGuid(PubStaticFun.NewGuid());
            int ExecYear = ExecDate.Year;
            int ServerYear = serDate.Year;
            if (ServerYear == 2016 && ExecYear == 2017)
            {
                if (MessageBox.Show("因为年底大调价，根据医院的统一部署安排，只能将医嘱发送至2016.12.31日，是否继续？\n" + sMsg,
                    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }

            DateTime dtMinFee = DateTime.Parse("2016-12-31 23:55:00");
            DateTime dtMaxFee = DateTime.Parse("2017-01-01 00:20:00");
            if (serDate >= dtMinFee && serDate <= dtMaxFee)
            {
                MessageBox.Show("因为年底大调价，根据医院的统一部署安排，12月31日 23:55以后 至 次日1月1日 00:20 为调价期间，所有病人不允许发送医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime dtMin = DateTime.Parse("2016-12-31 18:00:00");
            DateTime dtMax = DateTime.Parse("2017-01-01 00:10:00");
            if (patientInfo1.lbJSLX.Text.IndexOf("医保") >= 0)
            {
                if (serDate >= dtMin && serDate <= dtMax)
                {
                    MessageBox.Show("因为年底大调价，根据医院的统一部署安排，12月31日 18点 至 次日0:10分 医保病人不允许发送医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //------------------------------------------------------------------

            //判断药品的有效性，得到需要更改执行科室的医嘱的组号
            #region 是否更改执行科室
            if (IsChangeExecDept)
            {
                //选中的医嘱
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                    {
                        if ((myTb.Rows[i]["ntype"].ToString().Trim() == "1"
                            || myTb.Rows[i]["ntype"].ToString().Trim() == "2"
                            || myTb.Rows[i]["ntype"].ToString().Trim() == "3")
                            && myTb.Rows[i]["status_flag"].ToString().Trim() == "2")
                        {
                            sSql = "select 1 from mzyf_ypcl where s_hh='" + myTb.Rows[i]["item_code"].ToString().Trim() + "' and deptid=" + newExecDept;
                            DataTable medTb = InstanceForm.BDatabase.GetDataTable(sSql);

                            if (medTb == null || medTb.Rows.Count == 0)
                            {
                                sMsg += " ⊙ " + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "\n";
                                sEnableGroup = myTb.Rows[i]["group_id"].ToString().Trim();
                                sGroupId = sGroupId.Replace(myTb.Rows[i]["group_id"].ToString().Trim(), "-1");
                            }
                            else
                            {
                                if (myTb.Rows[i]["group_id"].ToString().Trim() != sEnableGroup)
                                    sGroupId += "," + myTb.Rows[i]["group_id"].ToString().Trim();
                            }
                        }
                    }
                }
            }
            #endregion

            if (sMsg.Trim() != "")
            {
                if (MessageBox.Show("下列医嘱因为所更改的执行科室中没有该种药品，将不能被发送，是否继续？\n不能更改执行科室的医嘱包括：\n" + sMsg,
                    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
            }
            bool isHSZ = myFunc.IsHSZ(InstanceForm.BCurrentUser.EmployeeId);

            //发送
            Cursor.Current = PubStaticFun.WaitCursor();

            //			//生成数据访问对象
            //			RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
            //			database.Initialize("");
            //			database.Open();           
            //add by zouchihua 2013-3-15 费用为0是是否提示
            try
            {
                if ((new SystemCfg(7146)).Config.Trim() == "1" && Convert.ToDecimal(this.patientInfo1.lbYE.Text) <= 0)
                {
                    if (MessageBox.Show("该病人费用余额为【" + this.patientInfo1.lbYE.Text + "】，是否继续执行医嘱？\n",
                       "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        return;
                }
            }
            catch
            {
                myDataGrid2_CurrentCellChanged(null, null);
                if ((new SystemCfg(7146)).Config.Trim() == "1" && Convert.ToDecimal(this.patientInfo1.lbYE.Text) <= 0)
                {
                    if (MessageBox.Show("该病人费用余额为【" + this.patientInfo1.lbYE.Text + "】，是否继续执行医嘱？\n",
                       "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }
            }
            try
            {
                bool _qfExeCurDeptOrder = false;//欠费是否能够发送本科室医嘱

                int _flag = 0;
                //如果允许出院病人欠费执行医嘱，才判断病人当前的状态，要不都默认为0
                if ((new SystemCfg(7042)).Config == "是")
                {
                    _flag = Convert.ToInt32(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select flag from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"), "0"));
                }
                //手术麻醉跳过，出院及死亡病人判断 Modifuy By Tany 2007-12-05
                if ((new SystemCfg(7001)).Config == "是" && !isSSMZ && _flag != 4)
                {
                    try
                    {
                        if (Convert.ToInt32(ClassStatic.Current_BabyID) == 0
                            || (Convert.ToInt32(ClassStatic.Current_BabyID) != 0 && (new SystemCfg(7002)).Config == "是"))
                        {
                            decimal _ye = 0;

                            SystemCfg sysCfg = new SystemCfg(7040);
                            //医嘱发送控制欠费是否强制包括预算费用
                            if (sysCfg.Config == "是")
                            {
                                bt预算_Click(sender, e);
                                _ye = Convert.ToDecimal(patientInfo1.lbYE.Text.Trim() == "" ? "0" : patientInfo1.lbYE.Text.Trim()) - orderfee;
                            }
                            else
                            {
                                _ye = Convert.ToDecimal(patientInfo1.lbYE.Text.Trim() == "" ? "0" : patientInfo1.lbYE.Text.Trim());
                            }
                            //Modify By Tany 2010-06-18 如果是医保病人，余额=预交金-总费用*费用比例
                            if (patientInfo1.lbJSLX.Text.IndexOf("医保") >= 0)
                            {
                                decimal fee = 0;
                                decimal yjj = 0;
                                //Modify by zouchihua 20121-5-10 
                                if (patientInfo1.lbWJSFY.Text.Trim().IndexOf("(") > 0)
                                    fee = Convert.ToDecimal(patientInfo1.lbWJSFY.Text.Trim() == "" ? "0" : patientInfo1.lbWJSFY.Text.Trim().Substring(0, patientInfo1.lbWJSFY.Text.Trim().IndexOf("(")).Trim());
                                else
                                    fee = Convert.ToDecimal(patientInfo1.lbWJSFY.Text.Trim() == "" ? "0" : patientInfo1.lbWJSFY.Text.Trim());
                                yjj = Convert.ToDecimal(patientInfo1.lbYJK.Text.Trim() == "" ? "0" : patientInfo1.myRow["YJK"].ToString().Trim());

                                if (cfg7186.Config.Trim() == "0")
                                {
                                    //首先判断费用比例是不是小于1，如果等于1，则不需要计算
                                    decimal bl = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select b.yjj_bl from zy_inpatient a left join jc_yblx b on a.yblx=b.id where a.dischargetype=1 and a.inpatient_id='" + ClassStatic.Current_BinID + "'"), "1"));
                                    //Modify By Tany 2010-08-07 比例=0的时候相当于不控制欠费
                                    if (bl >= 0 && bl < 1)
                                    {
                                        if (sysCfg.Config == "是")
                                        {
                                            _ye = yjj - (fee * bl) - (orderfee * bl);
                                        }
                                        else
                                        {
                                            _ye = yjj - (fee * bl);
                                        }
                                    }
                                }
                                else
                                {

                                    #region  add by zouchihua 2014-3-10按照医保试算进行控制
                                    string ybfy = @"select isnull(SUM(XJZF),0) fee from 
                                (
                                select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id='" + ClassStatic.Current_BinID + @"'  order by YBJS_DATE desc
                                 union all
                                select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and DISCHARGE_BIT=0 and inpatient_id='" + ClassStatic.Current_BinID + @"'
                                ) aa
                                ";
                                    DataTable tbybfy = InstanceForm.BDatabase.GetDataTable(ybfy);
                                    if (tbybfy.Rows.Count > 0)
                                    {
                                        fee = decimal.Parse(tbybfy.Rows[0]["fee"].ToString());
                                    }
                                    if (sysCfg.Config == "是")
                                    {
                                        _ye = yjj - (fee) - (orderfee);
                                    }
                                    else
                                    {
                                        _ye = yjj - (fee);
                                    }
                                    #endregion
                                }
                            }
                            //判断病人的余额
                            decimal zdje = myFunc.GetPatMinExecYE(ClassStatic.Current_BinID);
                            bool zgflag = true;
                            #region 对职工单位单独处理
                            if (new SystemCfg(7204).Config == "1")
                            {
                                string zgje = "0";
                                string iszgsql = @"select * from ZY_INPATIENT_SUPPLY where PATIENTTYPE=1 and CHARGETYPE=1 and INPATIENT_ID='" + ClassStatic.Current_BinID + "'";
                                DataTable mydtzg = FrmMdiMain.Database.GetDataTable(iszgsql);
                                if (mydtzg != null && mydtzg.Rows.Count > 0)
                                {
                                    int _hour = Convert.ToInt32(new SystemCfg(7072).Config);
                                    DateTime _rysj = Convert.ToDateTime(FrmMdiMain.Database.GetDataResult("select in_date from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"));
                                    if (_rysj.AddHours(_hour) <= ExecDate && _ye < zdje)
                                    {
                                        SystemCfg cfg7204 = new SystemCfg(7204);
                                        zgje = cfg7204.Config;
                                        if (isHSZ == false || (new SystemCfg(7034)).Config == "否")//护士长是否能够欠费发送 Modify By Tany 2007-07-19
                                        {
                                            if ((new SystemCfg(7021)).Config == "是")
                                            {
                                                _qfExeCurDeptOrder = true;
                                                MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " 床职工担保病人 " + patientInfo1.lbName.Text.Trim() + " 的余额为 " +
                                                    _ye.ToString().Trim() + " 元，" + ("最大担保金额为 " + zgje.ToString() + " 元，可以允许的欠费【") + zdje + "】请通知相关人员进行审核,目前只能发送该病人本科执行的医嘱！", "提示",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                            else
                                            {
                                                MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " 床职工担保病人 " + patientInfo1.lbName.Text.Trim() + " 的余额为 " +
                                                    _ye.ToString().Trim() + " 元，" + ("最大担保金额为 " + zgje.ToString() + " 元，可以允许的欠费【") + zdje + "】请通知相关人员进行审核！", "提示",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }
                                    }
                                    zgflag = false;
                                }

                            }
                            #endregion
                            //  MessageBox.Show("余额" + _ye.ToString() + " 最大欠费" + zdje.ToString());
                            if (_ye < zdje && zgflag)
                            {
                                //执行的这条医嘱

                                //Add By Tany 2010-11-27 增加对病人入院时间的判断
                                //7072病人入院？小时后控制欠费（0=立即控制）
                                int _hour = Convert.ToInt32(new SystemCfg(7072).Config);
                                DateTime _rysj = Convert.ToDateTime(FrmMdiMain.Database.GetDataResult("select in_date from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"));
                                if (_rysj.AddHours(_hour) <= ExecDate)
                                {
                                    SystemCfg cfg7204 = new SystemCfg(7204);
                                    if (isHSZ == false || (new SystemCfg(7034)).Config == "否")//护士长是否能够欠费发送 Modify By Tany 2007-07-19
                                    {
                                        if (cfg7204.Config == "1")
                                        {
                                            string str = "";
                                            decimal je = 0;
                                            string s = @"select * from ZY_INPATIENT_SUPPLY where CHARGETYPE in(0,2) and INPATIENT_ID='" + ClassStatic.Current_BinID + "'";
                                            DataTable mydt = FrmMdiMain.Database.GetDataTable(s);
                                            if (mydt != null && mydt.Rows.Count > 0)
                                            {
                                                if (mydt.Rows[0]["PATIENTTYPE"].ToString() == "1")
                                                {
                                                    switch (mydt.Rows[0]["CHARGETYPE"].ToString())
                                                    {
                                                        //合同单位
                                                        case "0":
                                                            str = "合同单位";
                                                            string sqlht = @"select * from JC_HTDW where ID=" + mydt.Rows[0]["HTDW"].ToString() + "";
                                                            DataTable mydt_ht = FrmMdiMain.Database.GetDataTable(sqlht);
                                                            if (mydt_ht != null && mydt_ht.Rows.Count > 0)
                                                            {
                                                                je = Convert.ToDecimal(Convertor.IsNull(mydt_ht.Rows[0]["maxmoney"], "0"));
                                                            }

                                                            break;
                                                        ////职工担保
                                                        //case "1":
                                                        //    str = "职工担保";

                                                        //    je = Convert.ToDecimal(Convertor.IsNull(new SystemCfg(5130).Config, "0"));
                                                        //    break;
                                                        //特殊担保
                                                        case "2":
                                                            str = "特殊担保";
                                                            je = Convert.ToDecimal(Convertor.IsNull(mydt.Rows[0]["NEWRANG_MONEY"], "0"));
                                                            break;
                                                        default:
                                                            str = "";
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    str = "";
                                                    je = Convert.ToDecimal(Convertor.IsNull(mydt.Rows[0]["NEWRANG_MONEY"], "0"));
                                               }
                                            }
                                            //7021病人欠费是否可以发送本科室的项目
                                            if ((new SystemCfg(7021)).Config == "是")
                                            {
                                                _qfExeCurDeptOrder = true;
                                                MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " 床" + str + "病人 " + patientInfo1.lbName.Text.Trim() + " 的余额为 " +
                                                    patientInfo1.lbYE.Text.Trim() + " 元，" + ("最大担保金额为 " + zdje.ToString() + " 元，") + "请通知相关人员进行审核！", "提示",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                            else
                                            {
                                                MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " 床" + str + "病人 " + patientInfo1.lbName.Text.Trim() + " 的余额为 " +
                                                    patientInfo1.lbYE.Text.Trim() + " 元，" + ("最大担保金额为 " + zdje.ToString() + " 元，") + "请通知相关人员进行审核！", "提示",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            //7021病人欠费是否可以发送本科室的项目
                                            if ((new SystemCfg(7021)).Config == "是")
                                            {
                                                _qfExeCurDeptOrder = true;
                                                MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " 床病人 " + patientInfo1.lbName.Text.Trim() + " 的余额为 " +
                                                    patientInfo1.lbYE.Text.Trim() + " 元，" + (orderfee == 0 ? "" : ("本次预算费用为 " + orderfee + " 元，")) + "将只能发送该病人本科执行的医嘱！", "提示",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                            else
                                            {
                                                MessageBox.Show(patientInfo1.lbBed.Text.Trim() + " 床病人 " + patientInfo1.lbName.Text.Trim() + " 的余额为 " +
                                                    patientInfo1.lbYE.Text.Trim() + " 元，" + (orderfee == 0 ? "" : ("本次预算费用为 " + orderfee + " 元，")) + "将不能发送该病人医嘱！", "提示",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message + "\n 医嘱执行出错！！");
                    }
                }

                //开始一个事物
                //				database.BeginTransaction();

                #region 改变药品执行科室
                if (IsChangeExecDept)
                {
                    //选中的医嘱
                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                        {
                            //药品医嘱
                            if ((myTb.Rows[i]["ntype"].ToString().Trim() == "1"
                                || myTb.Rows[i]["ntype"].ToString().Trim() == "2"
                                || myTb.Rows[i]["ntype"].ToString().Trim() == "3")
                                && myTb.Rows[i]["status_flag"].ToString().Trim() == "2")
                            {
                                sSql = "update zy_orderrecord set exec_dept=" + newExecDept + " where mngtype in(1,5) and group_id in (" + sGroupId + ")" +
                                    " and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                                InstanceForm.BDatabase.DoCommand(sSql);
                            }
                        }
                    }
                }
                #endregion

                #region"pivas未审方是否允许执行药品医嘱"

                //7605 pivas未审方是否允许执行药品医嘱 0否 1是
                //7602 pivas的审方内容，默认为0，0:长嘱 1:临嘱 2:长临嘱
                if (cfg7605.Trim().Equals("0"))
                {
                    string strCfgMng = cfg7602.Trim();
                    string strMng = this.GetMNGType().ToString().Trim();

                    //选中的医嘱
                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                        {
                            if (strCfgMng.Equals(strMng) || (strCfgMng.Equals("2") && (strMng.Equals("1") || strMng.Equals("2"))))
                            {
                                bool bPvsChk = isPvsChkExe(ClassStatic.Current_BinID.ToString(), ClassStatic.Current_BabyID.ToString(), myTb.Rows[i]["Group_ID"].ToString().Trim());

                                if (!bPvsChk)
                                {
                                    MessageBox.Show("该病人有pivas医嘱未审核，请联系pivas处理\n", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                }

                #endregion

                if (iSelect == 0)
                {
                    //全部发送
                    myFunc.ExecOrdersWithData(this.myDataGrid1, 9, 0, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);
                }
                else
                {
                    //发送长期医嘱
                    myFunc.ExecOrdersWithData(this.myDataGrid1, 0, iSelect0, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);

                    //发送临时医嘱
                    myFunc.ExecOrdersWithData(this.myDataGrid1, 1, iSelect1, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);

                    //发送长期账单
                    myFunc.ExecOrdersWithData(this.myDataGrid1, 2, iSelect2, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);

                    //发送临时账单
                    myFunc.ExecOrdersWithData(this.myDataGrid1, 3, iSelect3, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);
                }


                //				database.CommitTransaction();
            }
            catch (Exception err)
            {
                //				database.RollbackTransaction();
                //				database.Close();

                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "医嘱执行错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source + "\n\n数据已经回滚，请检查后重新执行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 0;
                this.tabControl1_SelectedIndexChanged(sender, e);
                return;
            }

            //			database.Close();

            //医嘱发送（冲账）是否自动生成药品统领信息
            //Modify By Tany 2005-11-05
            if ((new SystemCfg(7022)).Config == "是")
            {
                string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + InstanceForm.BCurrentDept.DeptId + ")";
                DataTable yfTb = InstanceForm.BDatabase.GetDataTable(yfSql);

                for (int i = 0; i < yfTb.Rows.Count; i++)
                {
                    //新统领药品（领药）消息 Modify By Tany 2005-09-13
                    myFunc.SendYPFY(0, 0, InstanceForm.BCurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                    //新统领药品（领药） Add by zouchihua 2012-4-22
                    myFunc.SendYPFY(2, 0, InstanceForm.BCurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                }
            }

            //Modify By Tany 2009-08-03
            //冲账和发送分开
            if ((new SystemCfg(7047)).Config == "是")
            {
                string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + InstanceForm.BCurrentDept.DeptId + ")";
                DataTable yfTb = InstanceForm.BDatabase.GetDataTable(yfSql);

                for (int i = 0; i < yfTb.Rows.Count; i++)
                {
                    //新统领药品（退药）消息 Modify By Tany 2005-09-13
                    myFunc.SendYPFY(0, 1, InstanceForm.BCurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                    //新统领药品（退药） Add by zouchihua 2012-4-22
                    myFunc.SendYPFY(2, 1, InstanceForm.BCurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                }
            }
            //add by yaokx 2014-03-12  开出院医嘱、转科医嘱时自动冲最后一天的床位费用
            #region 开出院医嘱时自动冲最后一天的床位费用
            string cfg7187 = new SystemCfg(7187).Config;
            if ((cfg7187 != "") && (GetMNGType() == 2 || GetMNGType() == 0))
            {
                string str = "";

                //if(cfg7187 != "")
                //{
                //    string[] ss = cfg7187.Split(',');
                //    for (int ii = 0; ii < ss.Length; ii++)
                //    {
                //        value += "'" + ss[ii] + "',";
                //    }
                //    str = value.Substring(0, value.Length - 1);
                //}
                DateTime dTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//取数据库时间

                myFunc.GetCZcy(ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), cfg7187, dTime);

            }
            #endregion

            Cursor.Current = Cursors.Default;

            MessageBox.Show("发送完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //刷新界面
            this.tabControl1_SelectedIndexChanged(sender, e);
        }

        private void bt详细信息_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = 0;
            int SelCount = 0;

            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        nrow = i;
                        SelCount++;
                    }
                }
            }
            if (SelCount == 0)
            {
                MessageBox.Show("没有选择医嘱，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (SelCount > 1)
            {
                MessageBox.Show("只能选择一组医嘱，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //如果医嘱ID为空
            if (myTb.Rows[nrow]["Group_ID"].ToString() == "") return;

            if (myTb.Rows.Count > 0)
            {
                frmYZXX f1 = new frmYZXX();
                f1.sTitle = "病人“" + this.sName + "”医嘱详细信息";
                f1.MNGType = this.GetMNGType();
                f1.MNGType2 = f1.MNGType == 1 ? 5 : f1.MNGType;
                f1.Group_ID = Convert.ToInt32(myTb.Rows[nrow]["Group_ID"]);
                f1.OrderID = new Guid(myTb.Rows[nrow]["Order_ID"].ToString());
                f1.nType = Convert.ToInt32(myTb.Rows[nrow]["ntype"]);
                f1.isSSMZ = isSSMZ;
                f1.isTSZL = rbTszl.Checked ? true : false;
                f1.isCX = isCX;
                if (rbIn.Checked || rbTrans.Checked || rbTszl.Checked)
                {
                    f1.isUNCZ = false;
                    //add by zouchihua 2013-8-24 特殊治疗如果开了出院医嘱，不允许冲正
                    if (rbTszl.Checked && cfg7160.Config.Trim() == "0")
                    {
                        DataTable tbbr = InstanceForm.BDatabase.GetDataTable("select flag from VI_ZY_VINPATIENT_BED where INPATIENT_ID='" + ClassStatic.Current_BinID + "' and baby_id='" + ClassStatic.Current_BabyID + "' and flag=4");
                        if (tbbr.Rows.Count > 0)
                        {
                            f1.isUNCZ = true;
                        }
                    }
                }
                else
                {
                    f1.isUNCZ = true;
                }
                //判断如果医保结算不能冲正 add by zouchihua 2013-01-07
                //string sql = "select IS_YBJS from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'";
                //DataTable temptb = FrmMdiMain.Database.GetDataTable(sql);
                //if (temptb.Rows.Count > 0)
                //{
                //    if(temptb.Rows[0]["IS_YBJS"].ToString().Trim()=="1")
                //        f1.isUNCZ = true;
                //}
                #region//Add by Zouchihua 2011-10-11 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
                string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
                if (rtnSql[0] != "0")//冻结后不能冲正
                {
                    f1.isUNCZ = true;
                }
                // if (rtnSql[2] != "0")
                //{
                //   f1.isUNCZ = true;
                //}
                #endregion
                if (zczyz_notfy)
                {
                    //出区的病人冲正，只能冲正药品。并且不产生发药信息
                    f1.isUNCZ = false;
                    f1.zczyz_notfy = zczyz_notfy;
                }

                f1.ShowDialog();
            }

        }

        private void bt医嘱打印_Click(object sender, System.EventArgs e)
        {
            Point pp = new Point(bt医嘱打印.Location.X, bt医嘱打印.Location.Y + bt医嘱打印.Height);

            contextMenu3.Show(bt医嘱打印.Parent, pp);
        }

        //注意：护理记录取消的时候要把相关的护理信息清理掉（还没有修改，修改后删除Tany）
        private void bt取消开医嘱转抄_Click(object sender, System.EventArgs e)
        {
            string tmpSql = "";

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            DataTable decoctTb = new DataTable();
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int i = 0;
            string sSql = "";
            bool isSelect = false;
            this.myDataGrid1.CurrentCell = new DataGridCell(0, 0);
            int mngType1 = GetMNGType();
            int mngType2 = -1;

            if (mngType1 == 1)
                mngType2 = 5;
            else
                mngType2 = mngType1;

            Button bt = (Button)sender;
            string btName = bt.Name.Trim().Substring(2, bt.Name.Trim().Length - 2);

            if (MessageBox.Show(this, "确认开始“" + btName + "”吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
            }
            string sSql1;
            string tmpSql1 = "";
            DataTable hltb = FrmMdiMain.Database.GetDataTable("select b.ORDER_NAME,TENDLEVEL,a.HOITEM_ID from JC_HOI_HL a left join JC_HOITEMDICTION  b on a.HOITEM_ID=b.ORDER_ID");
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                sSql1 = "";
                tmpSql1 = "";
                if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                {
                    switch (btName)
                    {
                        case "取消开医嘱转抄":
                            #region 判断该医嘱是否没有转抄、是否执行过
                            if (Convert.ToInt16(myTb.Rows[i]["Status_flag"]) == 1)
                            {
                                MessageBox.Show(this, "对不起，医嘱“" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "”还没有转抄！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            //暂时取消  Modify By Tany 2004-11-11
                            //							if (myTb.Rows[i]["AUDITING_USER"].ToString().Trim()!=InstanceForm.BCurrentUser.EmployeeId)
                            //							{
                            //								MessageBox.Show(this,"对不起，医嘱“"+myTb.Rows[i]["医嘱内容"].ToString().Trim()+"”不是您转抄的，您无权取消！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            //								return;
                            //							}
                            int nPs = Convert.ToInt16(myTb.Rows[i]["ps_flag"]);
                            if (nPs == 1 || nPs == 2)
                            {
                                MessageBox.Show(this, "对不起，该条医嘱已经设置了皮试结果！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            sSql = "select * from zy_orderrecord " +
                                "where order_id in (select order_id from zy_orderexec)" +
                                "      and group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "      and (mngtype=" + mngType1 + " or mngtype=" + mngType2 + ")" +
                                "      and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                "      and not (ntype=0)";//Modify By Tany 2005-11-05 出院医嘱等可以任意取消
                            DataTable myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                            if (myTempTb.Rows.Count != 0)
                            {
                                MessageBox.Show(this, "对不起，医嘱“" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "”已经执行，不允许取消！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            #endregion
                            #region //Add by zouchihua 取消转抄时遍历护理信息 2012-7-18
                            DataRow[] row = hltb.Select("HOITEM_ID=" + myTb.Rows[i]["HOITEM_ID"].ToString());
                            if (row != null && row.Length > 0)// && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_hl"].ToString().Trim())
                            {
                                sSql1 = "ORDER_HL=null,ORDER_HL_SPEC='',ORDER_TENDLEVEL=0";
                                //Add By Tany 2005-01-12
                                //如果是停护理级别还要看和现在护理记录表里面的级别是不是一致
                                //主要是防止先开新护理，后停老护理的时候会把新护理记录清除
                                tmpSql1 = " order_tendlevel=" + row[0]["TENDLEVEL"] + " and ";
                            }
                            if (myTb.Rows[i]["医嘱内容"].ToString().IndexOf("病重") >= 0)
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BZ=null"; ;
                            }
                            if (myTb.Rows[i]["医嘱内容"].ToString().IndexOf("病危") >= 0)//&& myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_bw"].ToString().Trim())
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BW=null";
                            }
                            if (myTb.Rows[i]["医嘱内容"].ToString().IndexOf("饮食") >= 0 || myTb.Rows[i]["医嘱内容"].ToString().IndexOf("禁食") >= 0 || myTb.Rows[i]["医嘱内容"].ToString().IndexOf("普食") >= 0)// && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_ys"].ToString().Trim())
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_YS=null,ORDER_YS_SPEC=''";
                            }
                            #endregion
                            break;
                        case "取消停医嘱转抄":
                            #region 判断该医嘱是否已经停止、是否停止转抄
                            if (Convert.ToInt16(myTb.Rows[i]["Status_flag"]) == 5)
                            {
                                MessageBox.Show(this, "对不起，医嘱“" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "”已经停止！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["Status_flag"]) != 4)
                            {
                                MessageBox.Show(this, "对不起，医嘱“" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "”还没有停止转抄！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            //暂时取消  Modify By Tany 2004-11-11
                            //							if (myTb.Rows[i]["order_euser"].ToString().Trim()!=InstanceForm.BCurrentUser.EmployeeId)
                            //							{
                            //								MessageBox.Show(this,"对不起，医嘱“"+myTb.Rows[i]["医嘱内容"].ToString().Trim()+"”不是您停止转抄的，您无权取消！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            //								return;
                            //							}

                            #endregion
                            #region //Add by zouchihua 取消停转抄时遍历护理信息 2012-7-18
                            row = hltb.Select("HOITEM_ID=" + myTb.Rows[i]["HOITEM_ID"].ToString());
                            if (row != null && row.Length > 0)
                            {
                                sSql1 = "ORDER_HL='" + myTb.Rows[i]["Order_ID"].ToString() + "',ORDER_HL_SPEC='" + row[0]["ORDER_NAME"].ToString() + "',ORDER_TENDLEVEL=" + row[0]["TENDLEVEL"].ToString();
                            }
                            if (myTb.Rows[i]["医嘱内容"].ToString().IndexOf("病重") >= 0)
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BZ='" + myTb.Rows[i]["Order_ID"].ToString() + "'";
                            }
                            if (myTb.Rows[i]["医嘱内容"].ToString().IndexOf("病危") >= 0)
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BW='" + myTb.Rows[i]["Order_ID"].ToString() + "'";
                            }
                            if (myTb.Rows[i]["医嘱内容"].ToString().IndexOf("饮食") >= 0 || myTb.Rows[i]["医嘱内容"].ToString().IndexOf("禁食") >= 0 || myTb.Rows[i]["医嘱内容"].ToString().IndexOf("普食") >= 0)// && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_ys"].ToString().Trim())
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_YS='" + myTb.Rows[i]["Order_ID"].ToString() + "',ORDER_YS_SPEC='" + myTb.Rows[i]["医嘱内容"].ToString() + "'";
                            }

                            #endregion
                            break;
                        case "取消开医嘱核对":
                            #region 判断该医嘱是否已经核对
                            //可以不做有效性判断，不影响数据 Modify By Tany 2004-11-18
                            //							if (myTb.Rows[i]["开嘱核对"].ToString().Trim()=="")
                            //							{
                            //								MessageBox.Show(this,"对不起，医嘱“"+myTb.Rows[i]["医嘱内容"].ToString().Trim()+"”还没有开始核对！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            //								return;
                            //							}
                            //暂时取消  Modify By Tany 2004-11-11
                            //							if (myTb.Rows[i]["AUDITING_USER1"].ToString().Trim()!=InstanceForm.BCurrentUser.EmployeeId)
                            //							{
                            //								MessageBox.Show(this,"对不起，医嘱“"+myTb.Rows[i]["医嘱内容"].ToString().Trim()+"”不是您核对的，您无权取消！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            //								return;
                            //							}
                            break;
                            #endregion
                        case "取消停医嘱核对":
                            #region 判断该医嘱是否已经停止审核
                            //可以不做有效性判断，不影响数据 Modify By Tany 2004-11-18
                            //							if (myTb.Rows[i]["停嘱核对"].ToString().Trim()=="")
                            //							{
                            //								MessageBox.Show(this,"对不起，医嘱“"+myTb.Rows[i]["医嘱内容"].ToString().Trim()+"”还没有停止查对！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            //								return;
                            //							}
                            //暂时取消  Modify By Tany 2004-11-11
                            //							if (myTb.Rows[i]["order_euser1"].ToString().Trim()!=InstanceForm.BCurrentUser.EmployeeId)
                            //							{
                            //								MessageBox.Show(this,"对不起，医嘱“"+myTb.Rows[i]["医嘱内容"].ToString().Trim()+"”不是你停止查对的！", "错误", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            //								return;
                            //							}					
                            break;
                            #endregion
                    }
                    isSelect = true;
                    if (sSql1 != "")
                    {
                        sSql = "update zy_inpatient_hl set " + sSql1 + " where " + tmpSql1 +
                            " inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;

                        try
                        {
                            InstanceForm.BDatabase.DoCommand(sSql);
                        }
                        catch (Exception err)
                        {
                            //写错误日志 Add By Tany 2005-01-12
                            SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "程序错误", "更新护理记录错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                            _systemErrLog.Save();
                            _systemErrLog = null;

                            MessageBox.Show("错误：更新护理记录时出错！\n系统：" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }

            if (isSelect == false)
            {
                MessageBox.Show(this, "对不起，没有选择医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #region 取消操作
            string sGroupId = "";
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (i != 0 && myTb.Rows[i]["Group_ID"].ToString().Trim() == myTb.Rows[i - 1]["Group_ID"].ToString().Trim())
                    continue;

                if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                {
                    //判断是不是有煎药费，如果有则把煎药费的临时账单取消
                    //Add By Tany 2004-10-22
                    //-------------------------------------------------------------------------------------------------------------
                    Guid n_id = Guid.Empty;
                    Guid n_order_id = Guid.Empty;
                    string strSql = "select id,order_id from zy_decoct where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                        " and group_id=" + Convert.ToDecimal(myTb.Rows[i]["group_id"].ToString().Trim()) + " and order_id is not null";
                    decoctTb = InstanceForm.BDatabase.GetDataTable(strSql);

                    if (decoctTb.Rows.Count > 0)
                    {
                        n_id = new Guid(decoctTb.Rows[0]["id"].ToString().Trim());
                        n_order_id = new Guid(decoctTb.Rows[0]["order_id"].ToString().Trim());
                        if (MessageBox.Show("该组医嘱有煎药费，是否自动删除煎药费？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //取煎药费信息
                            sSql = @"select * from zy_orderrecord where delete_bit=0 and order_id='" + n_order_id + "'";
                            DataTable myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                            //如果煎药费已经发送，则手工冲正
                            if (myTempTb.Rows.Count == 0 || myTempTb == null || myTempTb.Rows[0]["status_flag"].ToString().Trim() == "5")
                            {
                                MessageBox.Show("未找到煎药费或者煎药费已经发送，请手工冲正煎药费！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            else
                            {
                                //								//生成数据访问对象
                                //								RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
                                //								database.Initialize("");
                                //								database.Open();
                                //								//开始一个事务
                                //								database.BeginTransaction();

                                InstanceForm.BDatabase.BeginTransaction();

                                try
                                {
                                    //删除煎药费
                                    strSql = "update zy_orderrecord set delete_bit=1,order_euser=" + InstanceForm.BCurrentUser.EmployeeId +
                                        ",order_eudate=getdate() where order_id='" + n_order_id + "'";
                                    InstanceForm.BDatabase.DoCommand(strSql);

                                    //清除煎药费账单信息
                                    //Modify by jchl 不清除煎药信息
                                    //strSql = "update zy_decoct set order_id=DBO.FUN_GETEMPTYGUID() where id='" + n_id + "'";
                                    //InstanceForm.BDatabase.DoCommand(strSql);

                                    InstanceForm.BDatabase.CommitTransaction();
                                }
                                catch (Exception err)
                                {
                                    InstanceForm.BDatabase.RollbackTransaction();

                                    //写错误日志 Add By Tany 2005-01-12
                                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "取消转抄错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                                    _systemErrLog.Save();
                                    _systemErrLog = null;

                                    MessageBox.Show("错误：将煎药费从临时账单中删除时出现错误，请手工删除煎药费！\n系统：" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                //								finally
                                //								{
                                //									database.Close();
                                //								}
                            }
                        }
                    }

                    //-------------------------------------------------------------------------------------------------------------
                    //InstanceForm.BDatabase.BeginTransaction();
                    sSql = @"update zy_OrderRecord ";
                    try
                    {
                        //add by zouchihua 发送消息到住院 2013-8-14
                        string msg_wardid = "";
                        long msg_deptid = 0;// long.Parse(myTb.Rows[i]["EXEC_DEPT"].ToString().Trim());
                        long msg_empid = 0;
                        string msg_sender = FrmMdiMain.CurrentDept.DeptName + "：" + FrmMdiMain.CurrentUser.Name;
                        string msg_msg = "";
                        switch (btName)
                        {
                            case "取消开医嘱转抄":

                                //add by zouchihua 2012-2-21
                                #region 是否使用虚拟库存，转抄时。临时医嘱减虚拟库存，长期医嘱剪当天的虚拟库存
                                try
                                {
                                    string cfg6035 = new SystemCfg(6035).Config.Trim();
                                    if (cfg6035 == "1")
                                    {
                                        myFunc.OprateXnkc(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, Guid.Empty, int.Parse(myTb.Rows[i]["Group_ID"].ToString().Trim()), 1);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                                #endregion
                                //Modify by Tany 2010-04-19 如果是手术麻醉或特殊治疗，取消转抄直接取消到为0的状态
                                int _flag = 1;
                                if (isSSMZ || isTSZL)
                                {
                                    _flag = 0;
                                }
                                sSql += " set status_flag=" + _flag + ", Auditing_User=null, Auditing_Date=null ";
                                //取消转抄的时候把医嘱打印记录也删除 Add By Tany 2004-12-30 
                                if (GetMNGType() == 0)
                                {
                                    tmpSql = "delete from zy_logorderprt where group_id>=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                        "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                                }
                                else if (GetMNGType() == 1)
                                {
                                    tmpSql = "delete from zy_tmporderprt where group_id>=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                        "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                                }
                                //add by zouchihua 发送消息到住院 2013-8-14
                                msg_msg = "[" + patientInfo1.lbDQKS.Text.Trim() + "] 科室 " + patientInfo1.lbBed.Text + "床[" + patientInfo1.lbName.Text.Trim() + "] 的";
                                msg_msg += "【" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "】已经取消转抄\r\n";
                                try
                                {
                                    TrasenFrame.Classes.WorkStaticFun.SendMessage(false, SystemModule.住院护士站, InstanceForm.BCurrentDept.WardId, msg_deptid, msg_empid, msg_sender, msg_msg);
                                }
                                catch (Exception)
                                { }
                                break;
                            case "取消停医嘱转抄":
                                sSql += "  set status_flag=3,ORDER_EUSER=null, ORDER_EUDATE=null ";
                                //add by zouchihua 发送消息到住院 2013-8-14
                                //string msg_wardid = "";
                                //long msg_deptid = 0;// long.Parse(myTb.Rows[i]["EXEC_DEPT"].ToString().Trim());
                                //long msg_empid = 0;
                                //string msg_sender = FrmMdiMain.CurrentDept.DeptName + "：" + FrmMdiMain.CurrentUser.Name;
                                msg_msg = "[" + patientInfo1.lbDQKS.Text.Trim() + "] 科室 " + patientInfo1.lbBed.Text + "床[" + patientInfo1.lbName.Text.Trim() + "] 的";
                                msg_msg += "【" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "】已经取消停医嘱转抄\r\n";
                                try
                                {
                                    TrasenFrame.Classes.WorkStaticFun.SendMessage(false, SystemModule.住院护士站, InstanceForm.BCurrentDept.WardId, msg_deptid, msg_empid, msg_sender, msg_msg);
                                }
                                catch (Exception)
                                { }
                                break;
                            case "取消开医嘱核对":
                                sSql += " set Auditing_User1=null, Auditing_Date1=null ";
                                break;
                            case "取消停医嘱核对":
                                sSql += "  set ORDER_EUSER1=null, ORDER_EUDATE1=null ";
                                break;
                            case "取消开医嘱查对":
                                sSql += " set Auditing_User2=null, Auditing_Date2=null ";
                                break;
                            case "取消停医嘱查对":
                                sSql += "  set ORDER_EUSER2=null, ORDER_EUDATE2=null ";
                                break;
                        }
                        sSql += " where group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                              "       and (mngtype=" + mngType1 + " or mngtype=" + mngType2 + ")" +
                              "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                        InstanceForm.BDatabase.DoCommand(sSql);

                        //删除医嘱打印信息 Modify By Tany 2005-01-18
                        if (tmpSql.Trim() != "")
                        {
                            InstanceForm.BDatabase.DoCommand(tmpSql);
                        }
                        //InstanceForm.BDatabase.CommitTransaction();
                        sGroupId += myTb.Rows[i]["Group_ID"].ToString().Trim() + ",";
                    }
                    catch (Exception ex)
                    {
                        //InstanceForm.BDatabase.RollbackTransaction();
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            #endregion

            //写日志 Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, btName, "将inpatient_id=" + ClassStatic.Current_BinID + " and baby_id=" + ClassStatic.Current_BabyID + "的病人group_id=" + sGroupId + btName, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            this.ShowData();
        }


        private void bt阳性_Click(object sender, EventArgs e)
        {
            Point pp = new Point(bt阳性.Location.X, bt阳性.Location.Y + bt阳性.Height);

            contextMenuSP.Show(bt阳性.Parent, pp);
        }
        /// <summary>
        /// 阳性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string sMsg1 = "阳性(+)";
            string sMsg2 = "修改为阳性(+)";
            string sPSJG1 = "2";
            string sPSJG2 = "0";
            string value = " (+)";
            PSCL(sMsg1, sMsg2, sPSJG1, sPSJG2, value);
        }
        /// <summary>
        /// 加阳性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string sMsg1 = "加阳性(++)";
            string sMsg2 = "修改为加阳性(++)";
            string sPSJG1 = "21";
            string sPSJG2 = "0";
            string value = " (++)";
            PSCL(sMsg1, sMsg2, sPSJG1, sPSJG2, value);
        }
        /// <summary>
        /// 强阳性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string sMsg1 = "强阳性(+++)";
            string sMsg2 = "修改为强阳性(+++)";
            string sPSJG1 = "22";
            string sPSJG2 = "0";
            string value = " (+++)";
            PSCL(sMsg1, sMsg2, sPSJG1, sPSJG2, value);
        }
        /// <summary>
        /// 阴性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt阴性_Click(object sender, System.EventArgs e)
        {
            string sMsg1 = "阴性(-)";
            string sMsg2 = "修改为阴性(-)";
            string sPSJG1 = "1";
            string sPSJG2 = "-1";
            string value = " (-)";
            PSCL(sMsg1, sMsg2, sPSJG1, sPSJG2, value);
        }
        /// <summary>
        /// 皮试处理公用方法
        /// </summary>
        /// <param name="sMsg1"></param>
        /// <param name="sMsg2"></param>
        /// <param name="sPSJG1"></param>
        /// <param name="sPSJG2"></param>
        private void PSCL(string sMsg1, string sMsg2, string sPSJG1, string sPSJG2, string value)
        {
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            int nPs = Convert.ToInt16(myTb.Rows[nrow]["ps_flag"]);

            if (nPs == -1 || nPs == 3)
            {
                //如果是个项目，并且在vi_psyzxm里面有记录，则也允许皮试 Modify By Tany 2015-04-13
                if (Convert.ToInt16(myTb.Rows[nrow]["xmly"]) == 2
                    && Convert.ToInt16(InstanceForm.BDatabase.GetDataResult("select COUNT(1) from vi_psyzxm where order_id=" + myTb.Rows[nrow]["hoitem_id"].ToString())) > 0)
                {
                }
                else
                {
                    MessageBox.Show(this, "对不起，该条医嘱不需要皮试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if ((myTb.Rows[nrow]["Order_Usage"].ToString().Trim() != "皮试"
                && myTb.Rows[nrow]["Order_Usage"].ToString().Trim().ToUpper() != "AST"))
            {
                MessageBox.Show(this, "对不起，该条医嘱的用法不是皮试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt16(myTb.Rows[nrow]["Status_flag"]) < 2)
            {
                MessageBox.Show(this, "对不起，该条医嘱还没有审核！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Button bt = (Button)sender;
            //string sMsg1 = bt.Text.Trim().Substring(0, 2) == "阴性" ? "阴性(-)" : "阳性(+)";
            //string sMsg2 = bt.Text.Trim().Substring(0, 2) == "阴性" ? "阳性修改为阴性(-)" : "阴性修改为阳性(+))";
            //string sPSJG1 = bt.Text.Trim().Substring(0, 2) == "阴性" ? "1" : "2";
            //string sPSJG2 = bt.Text.Trim().Substring(0, 2) == "阴性" ? "-1" : "0";
            if (nPs == 1)
                sMsg2 = "阴性" + sMsg2;
            else if (nPs == 2)
                sMsg2 = "阳性" + sMsg2;
            else if (nPs == 21)
                sMsg2 = "加阳性" + sMsg2;
            else if (nPs == 22)
                sMsg2 = "强阳性" + sMsg2;
            string sSql = "";
            Guid sOrderID = Guid.Empty;
            DataTable myTempTb = new DataTable();
            //1阴性 2阳性 21 弱阳性 22强阳性
            if ((nPs == 2 && sMsg1 == "阳性(+)") || (nPs == 1 && sMsg1 == "阴性(-)") || (nPs == 21 && sMsg1 == "加阳性(++)") || (nPs == 22 && sMsg1 == "强阳性(+++)"))
            {
                MessageBox.Show(this, "对不起，该条医嘱已经设置了" + sMsg1 + "皮试结果！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nPs == 2 || nPs == 1 || nPs == 21 || nPs == 22)
            {
                //修改皮试结果

                if (InstanceForm.BCurrentUser.EmployeeId != Convert.ToInt64(myTb.Rows[nrow]["ps_user"]))
                {
                    MessageBox.Show(this, "对不起，该条医嘱已经由其他操作员设置了皮试结果，您无权修改！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool bModIvOrder = false;

                //是否有对应的医嘱
                if (new Guid(myTb.Rows[nrow]["ps_orderid"].ToString()) != Guid.Empty)
                {
                    sOrderID = new Guid(myTb.Rows[nrow]["ps_orderid"].ToString().Trim());
                    sSql = "select status_flag,order_id from zy_orderrecord where order_id='" + sOrderID + "'";
                    myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (myTempTb != null && myTempTb.Rows.Count > 0)
                    {
                        if (Convert.ToInt16(myTempTb.Rows[0]["status_flag"]) > 1
                            && new SystemCfg(7041).Config == "否")//Add By tany 2011-01-21 如果该参数为是，则可以任意更改皮试结果 7041是否允许没有皮试结果的医嘱转抄
                        {
                            MessageBox.Show(this, "对不起，该条医嘱相对应的医嘱已经转抄，不允许修改皮试结果！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (MessageBox.Show(this, "确认“" + myTb.Rows[nrow]["医嘱内容"].ToString().Trim() + "”是由 " + sMsg2 + "吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;

                    bModIvOrder = true;

                    //修改注射医嘱
                    sSql = "update zy_orderrecord set ps_flag=" + sPSJG2 + " where order_id='" + sOrderID + "'";
                    InstanceForm.BDatabase.DoCommand(sSql);
                }
                else
                {
                    if (MessageBox.Show(this, "确认“" + myTb.Rows[nrow]["医嘱内容"].ToString().Trim() + "”是由 " + sMsg2 + "吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }

                try
                {
                    InstanceForm.BDatabase.BeginTransaction();

                    if (bModIvOrder)
                    {
                        //修改注射医嘱
                        sSql = "update zy_orderrecord set ps_flag=" + sPSJG2 + " where order_id='" + sOrderID + "'";
                        InstanceForm.BDatabase.DoCommand(sSql);
                    }

                    //修改皮试医嘱
                    sSql = "update zy_orderrecord set ps_flag=" + sPSJG1 + " where order_id='" + myTb.Rows[nrow]["Order_ID"].ToString().Trim() + "'";
                    InstanceForm.BDatabase.DoCommand(sSql);
                    //add by zouchihua 2013-1-5 同时修改医嘱打印表中的数据
                    string[] updatesql = new string[] { " update ZY_TMPORDERPRT set ORDER_USAGE=rtrim(REPLACE(REPLACE(REPLACE( REPLACE(ORDER_USAGE,'(-)',''),'(+)',''),'(++)',''),'(+++)',''))+'" + value+ "' where order_id='"+ myTb.Rows[nrow]["Order_ID"].ToString().Trim()+"'" 
                ," update ZY_LOGORDERPRT set ORDER_USAGE=rtrim(REPLACE(REPLACE(REPLACE( REPLACE(ORDER_USAGE,'(-)',''),'(+)',''),'(++)',''),'(+++)',''))+'" + value+ "' where order_id='"+ myTb.Rows[nrow]["Order_ID"].ToString().Trim()+"'" };
                    InstanceForm.BDatabase.DoCommand(updatesql[0]);
                    InstanceForm.BDatabase.DoCommand(updatesql[1]);

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (Exception ex)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show("皮试出错：" + ex.Message, "错误");
                    return;
                }
            }
            else
            {
                //第一次设置皮试结果
                if (MessageBox.Show(this, "确认“" + myTb.Rows[nrow]["医嘱内容"].ToString().Trim() + "”是" + sMsg1 + "吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                //获取注射医嘱order_id
                sSql = "select a.order_id from zy_orderrecord a,zy_orderrecord b " +
                    " where a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id" +
                    "       and a.ps_flag=b.ps_flag and a.ps_flag=0 and a.ps_orderid=b.ps_orderid" +
                    "       and a.order_id<>b.order_id and b.order_id='" + myTb.Rows[nrow]["Order_ID"].ToString().Trim() + "'";
                myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (myTempTb.Rows.Count > 0)
                {
                    sOrderID = new Guid(myTempTb.Rows[0]["order_id"].ToString().Trim());
                }


                try
                {
                    InstanceForm.BDatabase.BeginTransaction();
                    //修改皮试医嘱
                    sSql = "update zy_orderrecord set ps_flag=" + sPSJG1 + ",ps_orderid='" + sOrderID + "',ps_user=" + InstanceForm.BCurrentUser.EmployeeId + " where order_id='" + myTb.Rows[nrow]["Order_ID"].ToString().Trim() + "'";
                    InstanceForm.BDatabase.DoCommand(sSql);
                    //add by zouchihua 2013-1-5 同时修改医嘱打印表中的数据
                    string[] updatesql = new string[] { " update ZY_TMPORDERPRT set ORDER_USAGE=ORDER_USAGE+'" +value+ "' where order_id='"+ myTb.Rows[nrow]["Order_ID"].ToString().Trim()+"'" 
                ," update ZY_LOGORDERPRT set ORDER_USAGE=ORDER_USAGE+'" + value+ "' where order_id='"+ myTb.Rows[nrow]["Order_ID"].ToString().Trim()+"'" };
                    InstanceForm.BDatabase.DoCommand(updatesql[0]);
                    InstanceForm.BDatabase.DoCommand(updatesql[1]);
                    if (myTempTb.Rows.Count > 0)
                    {
                        //修改注射医嘱
                        sSql = "update zy_orderrecord set ps_flag=" + sPSJG2 + ",ps_orderid='" + myTb.Rows[nrow]["Order_ID"].ToString() + "',ps_user=" + InstanceForm.BCurrentUser.EmployeeId + " where order_id='" + sOrderID + "'";
                        InstanceForm.BDatabase.DoCommand(sSql);
                    }

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (Exception ex)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show("皮试出错：" + ex.Message, "错误");
                    return;
                }
            }

            string msg_wardid = "";
            long msg_deptid = ClassStatic.Current_DeptID;
            long msg_empid = 0;
            string msg_sender = FrmMdiMain.CurrentDept.WardName + "：" + FrmMdiMain.CurrentUser.Name;
            string msg_msg = patientInfo1.lbBed.Text + " 床 " + patientInfo1.lbName.Text + " 病人\r\n医嘱：" + myTb.Rows[nrow]["医嘱内容"].ToString().Trim() + " 皮试结果为 " + sMsg1 + "\r\n" + (sPSJG1 == "2" ? "请进行处理！" : "");
            TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.住院医生站, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);

            this.ShowData();

            #region 皮试的处理流程 c1字段
            //			医生开医嘱：   
            //			           A医嘱 		P0 10:00:01     (P标志，0是长嘱/1是临嘱，时间)
            //   		           B皮试医嘱    P0 10:00:01     (P标志，0是长嘱/1是临嘱，时间，但用法是皮试或AST)
            //          皮试后：  
            //                     B皮试医嘱    P0 A.order_id-2  (P标志，0是长嘱/1是临嘱，a.order_idA医嘱的ID，-阴性/+阳性，护士工号)
            //   		                                          (如果没有对应的A医嘱，则是“P0 -2”)
            //          		   A医嘱 		P0 B.order_idI   (P标志，0是长嘱/1是临嘱，a.order_idA医嘱的ID，I阴性/A阳性，只有c1字段包含I这个医嘱才可以审核)
            //			修改皮试结果：
            //					   判断条件：工号是本人，且A医嘱没有转抄		            
            //                     再分别修改 B皮试医嘱和A医嘱的c1字段
            #endregion
        }

        private void bt未执行_Click(object sender, System.EventArgs e)
        {
            int mntype = this.GetMNGType();
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            string sSql = "";
            bool isYJ = false;  //是否是医技项目

            #region 一次性提示错误信息和提交成功的信息   yaokx2013-11-20
            ArrayList errorlist = new ArrayList();
            Hashtable sumbitht = new Hashtable();
            string reaseon = "";
            #endregion
            int count = 0;
            if (this.bt未执行.Text.Substring(0, 1) == "未")
            {
                for (int x = 0; x < myTb.Rows.Count; x++)
                {
                    if (myTb.Rows[x]["选"].ToString() == "True")
                    {
                        count++;
                        Hashtable errorht = new Hashtable();
                        nrow = x;

                        string content = myTb.Rows[x]["医嘱内容"].ToString();

                        #region 未执行
                        if (Convert.ToInt16(myTb.Rows[nrow]["Status_flag"]) < 2)
                        {
                            string s = "'" + content + "'该条医嘱还没有转抄！";
                            errorht.Add(Guid.NewGuid(), s);
                            // MessageBox.Show(this, "对不起，该条医嘱还没有转抄！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // return;
                        }
                        //临时医嘱先发送后才能标未执行
                        if (Convert.ToInt16(myTb.Rows[nrow]["Status_flag"]) < 3 && mntype==1)
                        {
                            string s = "'" + content + "'该条医嘱还未发送,请先发送后再标未执行！";
                            errorht.Add(Guid.NewGuid(), s);
                            // MessageBox.Show(this, "对不起，该条医嘱还没有转抄！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // return;
                        }

                        string groupid = myTb.Rows[nrow]["group_id"].ToString().Trim();
                        int nWzx = Convert.ToInt16(myTb.Rows[nrow]["wzx_flag"]);

                        //这组医嘱中如果有皮试则不允许通过
                        for (int i = 0; i < myTb.Rows.Count; i++)
                        {
                            if (myTb.Rows[i]["group_id"].ToString().Trim() == groupid)
                            {
                                if (Convert.ToInt16(myTb.Rows[i]["ps_flag"]) == 1 || Convert.ToInt16(myTb.Rows[i]["ps_flag"]) == 2)
                                {
                                    string s = "'" + content + "'该组医嘱已经设置了皮试结果！";
                                    errorht.Add(Guid.NewGuid(), s);
                                    //  MessageBox.Show(this, "对不起，该组医嘱已经设置了皮试结果！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //return;
                                }
                            }
                        }

                        if (nWzx > 0)
                        {
                            string s = "'" + content + "'该条医嘱已经设置“未执行”！";
                            errorht.Add(Guid.NewGuid(), s);

                            //MessageBox.Show(this, "对不起，该条医嘱已经设置“未执行”！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        if (myTb.Rows[nrow]["执行时间"].ToString() != "")
                        {
                            string s = "'" + content + "'该条医嘱已经设置“执行时间”！";
                            errorht.Add(Guid.NewGuid(), s);
                        }

                        //转科医嘱出院医嘱不允许未执行
                        //Modify by jchl 2015-08-25
                        if (content.Contains("转科") || content.Contains("出院"))
                        {
                            string s = "出院或者转科医嘱不允许未执行！";
                            errorht.Add(Guid.NewGuid(), s);
                        }


                        //判断是否执行过
                        sSql = "select 1 from zy_orderrecord a inner join zy_orderexec b on a.order_id=b.order_id " +
                            " where a.group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                            "      and a.mngtype in(0,1,5) " +//Modify by zouchihua 2013-7-10 增加5类型交病人的判断
                            "      and a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID;
                        DataTable myTb1 = InstanceForm.BDatabase.GetDataTable(sSql);
                        if (myTb1.Rows.Count > 0)
                        {
                            //检查是否是已经预约或安排（只要是医技项目）
                            sSql = "select BJSBZ from YJ_ZYSQ " +
                                "  where yzid in (select order_id from zy_orderrecord  " +
                                "				       where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                "                            and mngtype in(0,1) " +
                                "                            and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                "                     )";
                            DataTable myTb2 = InstanceForm.BDatabase.GetDataTable(sSql);
                            if (myTb2.Rows.Count > 0)
                            {
                                if (Convert.ToInt16(myTb2.Rows[0]["BJSBZ"]) == 0)
                                {
                                    //还没有安排！
                                    isYJ = true;
                                }
                                else
                                {
                                    #region  //Modiby by zouchihua 2011-11-27
                                    //string yjfee = "select sum(acvalue) fy from zy_fee_speci" +
                                    //" where charge_bit=1 and delete_bit=0 and order_id in (select order_id from zy_orderrecord " +
                                    //"                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    //"                           and mngtype in (1,5) " +
                                    //"                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                    //"                    )";
                                    string yjfee = "select sum(acvalue) fy  from (select *  from  zy_fee_speci  where charge_bit=1 and delete_bit=0 and  order_id in "
                                            + " (select order_id from zy_orderrecord where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim()
                                            + "  and mngtype in (0,1,5)  and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + "   ) "
                                             + " ) aa ";
                                    decimal _fy = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(yjfee), "0"));
                                    if (_fy != 0)//费用不为零时 不未执行
                                    {
                                        //已经安排
                                        string s = "'" + content + "'该组医嘱已做安排，请要求执行科室进行取消安排或冲正操作！";
                                        errorht.Add(Guid.NewGuid(), s);
                                        //MessageBox.Show(this, "对不起，该组医嘱已做安排，请要求执行科室进行取消安排或冲正操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //return;
                                    }
                                    else
                                    {
                                        //写停止标志和未执行标志 ,不删除费用表的信息和医技的信息 
                                        //sSql = "update zy_orderrecord set order_context='【取消】'+order_context,wzx_flag=" + InstanceForm.BCurrentUser.EmployeeId + ",status_flag=5 ,order_edate=getdate()" +//Modify By Tany 2005-01-31 ,order_edate=getdate()
                                        //    " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                        //    "       and mngtype in (1,5) " +
                                        //    "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                                        ////Modify by Tany 2005-02-21	
                                        //if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                                        //   MessageBox.Show(this, "未找到需要更新的医嘱记录，请重新确认！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //this.ShowDate();
                                        //Modify by zouchihua 可以进行未执行
                                        isYJ = true;
                                    }
                                    #endregion
                                }

                                //检查是否已经记费
                                sSql = "select sum(acvalue) fy from zy_fee_speci" +
                                    " where charge_bit=1 and delete_bit=0 and order_id in (select order_id from zy_orderrecord " +
                                    "                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    "                           and mngtype in (0,1,5) " +
                                    "                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                    "                    )";
                                decimal _fy1 = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql), "0"));
                                if (_fy1 != 0)
                                {
                                    string s = "'" + content + "'该组医嘱已经记费，请要求执行科室进行冲正操作！";
                                    errorht.Add(Guid.NewGuid(), s);

                                    //MessageBox.Show(this, "对不起，该组医嘱已经记费，请要求执行科室进行冲正操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //return;
                                }
                            }
                            else
                            {
                                //Modify By tany 2011-05-31 如果不是医技项目，则判断是否有费用，如果没有费用则允许未执行
                                sSql = "select isnull(sum(acvalue),0) fy from zy_fee_speci" +
                                    " where charge_bit=1 and delete_bit=0 and order_id in (select order_id from zy_orderrecord " +
                                    "                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    "                           and mngtype in (0,1,5) " +
                                    "                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                    "                    )";
                                decimal _fy = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql), "0"));
                                if (_fy != 0)
                                {

                                    string s = "'" + content + "'该组医嘱已经产生了费用，不允许标记未执行！可以将费用冲正后再标记未执行";
                                    errorht.Add(Guid.NewGuid(), s);
                                    //MessageBox.Show(this, "对不起，该组医嘱已经产生了费用，不允许标记未执行！\r\n\r\n可以将费用冲正后再标记未执行", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //return;
                                }
                            }
                        }
                        //同一组只需要一次
                        if (x != 0 && myTb.Rows[x]["Group_ID"].ToString().Trim() == myTb.Rows[x - 1]["Group_ID"].ToString().Trim())
                        {
                            errorlist.Add(errorht);
                            continue;
                        }
                        //add by zouchihua 2012-6-15 未执行是否需要输入原因

                        if (errorht.Count == 0)
                        {
                            if (sumbitht.Count == 0)
                            {
                                if (cfg7129.Config.Trim() == "1")
                                {
                                    FrmReason fr = new FrmReason();
                                    fr.ShowDialog();
                                    if (fr.DialogResult == DialogResult.No || fr.ss.Trim() == "")
                                    {
                                        MessageBox.Show(this, "对不起，请填写未执行的理由！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else
                                    {
                                        reaseon = fr.ss;
                                    }
                                }
                                if (MessageBox.Show(this, "确认选中的医嘱‘未执行’吗？（注意：确认后则不允许修改！）", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                                //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
                                if (new SystemCfg(7066).Config == "0")
                                {
                                    frmInPassword f1 = new frmInPassword();
                                    f1.ShowDialog();
                                    bool isHSZ = f1.isHSZ;
                                    if (f1.isLogin == false) return;
                                }
                            }


                            //				//生成数据访问对象
                            //				RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
                            //				database.Initialize("");
                            //				database.Open();
                            //				//开始一个事物
                            //				database.BeginTransaction();

                            InstanceForm.BDatabase.BeginTransaction();

                            try
                            {
                                //写停止标志和未执行标志 
                                sSql = "update zy_orderrecord set order_context='【取消】'+order_context,wzx_flag=" + InstanceForm.BCurrentUser.EmployeeId + ",status_flag=5 ,order_edate=getdate() , memo2='" + reaseon + "' " +//Modify By Tany 2005-01-31 ,order_edate=getdate() //add by zouchihua 2012-6-15增加未执行的原因
                                    " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    "    and  wzx_flag<=0   and mngtype in (0,1,5) " +
                                    "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                                //Modify by Tany 2005-02-21	
                                if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                                    throw new Exception("未找到需要更新的医嘱记录，请重新确认！");

                                #region//add by zouchihua 同时更新医嘱打印记录表 2013-4-23
                                sSql = "  update ZY_LOGORDERPRT set order_context='【取消】'+order_context  " +
                                   " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;//没有打印的情况下
                                InstanceForm.BDatabase.DoCommand(sSql);
                                sSql = "  update ZY_TMPORDERPRT set order_context='【取消】'+order_context  " +
                                  " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                   "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;//没有打印的情况下
                                InstanceForm.BDatabase.DoCommand(sSql);

                                sSql = "  update ZY_LOGORDERPRT set PRT_STATUS=4,memo='取消'  " +
                                  " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                   "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and PRT_STATUS not in(0,-1)";//打印的情况下
                                InstanceForm.BDatabase.DoCommand(sSql);
                                sSql = "  update ZY_TMPORDERPRT set    PRT_STATUS=4 ,memo='取消' " +
                                  " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                   "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and PRT_STATUS not in(0,-1)";//打印的情况下 无条件改为4
                                InstanceForm.BDatabase.DoCommand(sSql);
                                #endregion
                                //add by zouchihua 2012-5-18 如果没有执行过，往执行表插入数据
                                if (myTb1.Rows.Count == 0)
                                {
                                    string order_id = myTb.Rows[nrow]["order_id"].ToString().Trim();
                                    string inpatient_id = ClassStatic.Current_BinID.ToString();
                                    string baby_id = ClassStatic.Current_BabyID.ToString();
                                    string id = Guid.NewGuid().ToString();
                                    DateTime dt = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                                    string insert = " insert into zy_orderexec(id, ORDER_ID,BOOK_DATE,inpatient_id,baby_id,REALEXEUSER,jgbm,EXECDATE) select  DBO.FUN_GETGUID(NEWID(),GETDATE()),order_id,getdate(),'" + inpatient_id + "'," + baby_id + "," + FrmMdiMain.CurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ",'" + dt + "' from ZY_ORDERRECORD  " +
                                    "   where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                    " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["Group_id"].ToString().Trim() + "";
                                    InstanceForm.BDatabase.DoCommand(insert);
                                    string update = " update ZY_ORDERRECORD set LASTEXECDATE='" + dt + "' where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                    " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["Group_id"].ToString().Trim() + "";
                                    InstanceForm.BDatabase.DoCommand(update);
                                }
                                else
                                {
                                    string sql = " update zy_orderexec  set REALEXEUSER='" + FrmMdiMain.CurrentUser.EmployeeId + "' where  order_id in ( select order_id from ZY_ORDERRECORD where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                    " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[nrow]["Group_id"].ToString().Trim() + " )";
                                    InstanceForm.BDatabase.DoCommand(sql);
                                }
                                string _lisGroup = "-1";
                                if (isYJ)
                                {
                                    //是医技项目
                                    //看看是否有lis组合
                                    //sSql = "select lis_group from yj_applyrecord " +
                                    //    " where orderid in (select order_id from zy_orderrecord " +
                                    //    "                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    //    "                           and mngtype=1 " +
                                    //    "                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                    //    "                    )";
                                    //_lisGroup = InstanceForm.BDatabase.GetDataResult(sSql).ToString().Trim();
                                    //if (_lisGroup != "-1" && _lisGroup != "")
                                    //{
                                    //    sSql = "update yj_applyrecord set lis_group=-1 where lis_group=" + _lisGroup;
                                    //    InstanceForm.BDatabase.DoCommand(sSql);
                                    //}
                                    //取消申请表
                                    sSql = "update YJ_ZYSQ set bscbz=1,scsj=getdate() ,scr=" + InstanceForm.BCurrentUser.EmployeeId +
                                        " where YZID in (select order_id from zy_orderrecord " +
                                        "                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                        "                           and mngtype in (0,1,5) " +
                                        "                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                        "                    )";
                                    //Modify by Tany 2005-02-21
                                    if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                                        throw new Exception("未找到需要更新的医技申请记录，请重新确认！");
                                }
                                //Add by zouchihua  冲正的费用与正费用发送不在同一天时不删除

                                //Modify By Tany 2011-05-31 移出来，允许对其他的医嘱未执行
                                //费用表做删除标志
                                sSql = "update zy_fee_speci set delete_bit=1" +
                                    " where discharge_bit=0 and charge_bit=0 and order_id in (select order_id from zy_orderrecord " +
                                    "                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    "                           and mngtype in (0,1,5) " +
                                    "                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                    "                    )";
                                //Modify by Tany 2005-02-21
                                InstanceForm.BDatabase.DoCommand(sSql);
                                //if (InstanceForm.BDatabase.DoCommand(sSql) == 0)
                                //    throw new Exception("未找到需要更新的费用记录，请重新确认！");

                                //取消检查打印 Add By Tany 2004-12-02
                                sSql = "update zy_jy_print set delete_bit=1" +
                                    " where order_id in (select order_id from zy_orderrecord " +
                                    "                     where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                    "                           and mngtype in (0,1,5) " +
                                    "                           and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID +
                                    "                    )";
                                InstanceForm.BDatabase.DoCommand(sSql);

                                InstanceForm.BDatabase.CommitTransaction();

                                //更新lis条形码表
                                //					if(_lisGroup!="-1" && _lisGroup!="")
                                //					{
                                //						sSql="update ls_as_txm set delete_bit=1 where id="+_lisGroup;
                                //						InstanceForm.BDatabase.DoCommand(sSql);
                                //					}

                                //写日志 Add By Tany 2005-01-12
                                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "未执行", "将inpatient_id=" + ClassStatic.Current_BinID + " and baby_id=" + ClassStatic.Current_BabyID + "病人的group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() + "的医嘱未执行", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                                _systemLog.Save();

                                string s = "'" + content + "'，该医嘱‘未执行’提交成功";
                                sumbitht.Add(x, s);

                                _systemLog = null;
                            }
                            catch (Exception err)
                            {
                                InstanceForm.BDatabase.RollbackTransaction();
                                //					database.Close();

                                //写错误日志 Add By Tany 2005-01-12
                                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "未执行错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                                _systemErrLog.Save();
                                _systemErrLog = null;

                                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source + "\n数据已经回滚，请检查后重新执行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            errorlist.Add(errorht);
                        }

                        //if (x == myTb.Rows.Count-1)
                        //{
                        //    update(sumbitht, errorlist, sSql);
                        //}

                        //				database.Close();
                        #endregion
                    }
                }
            }
            else
            {
                #region 停账单
                bool isSelect = false;
                int i = 0;
                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                    {
                        isSelect = true;
                        break;
                    }
                }

                if (isSelect == false)
                {
                    MessageBox.Show(this, "对不起，请选择需要停止的长期账单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
                if (new SystemCfg(7066).Config == "0")
                {
                    frmInPassword fi = new frmInPassword();
                    fi.ShowDialog();
                    bool isHSZ = fi.isHSZ;
                    if (fi.isLogin == false) return;
                }

                frmInputDate f1 = new frmInputDate();
                f1.ShowDialog();
                if (f1.result == false) return;

                string StopDate = f1.DtpbeginDate.Value.ToString();
                string sTERMINAL_TIMES = f1.textBox1.Text.ToString();
                string ss = "以下医嘱开单科室不属于本科室，不允许停医嘱：";
                #region//add yaokx 2012-02-24 获取护士进入病区的门诊科室id,用开单科室作为判断
                DataRow dr = InstanceForm.BDatabase.GetDataRow("select dept_id from JC_WARDRDEPT where WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' and dept_id <>" + InstanceForm.BCurrentDept.DeptId + "");
                if (dr == null) return;
                string ORDER_ID = "";
                if (rbTrans.Checked)
                {
                    for (i = 0; i <= myTb.Rows.Count - 1; i++)
                    {
                        if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                        {
                            ORDER_ID += "'" + myTb.Rows[i]["ORDER_ID"].ToString().Trim() + "',";
                        }
                    }
                    ORDER_ID = ORDER_ID.Substring(0, ORDER_ID.Length - 1);

                    DataTable kd_deptdt = InstanceForm.BDatabase.GetDataTable("select * from ZY_ORDERRECORD where ORDER_ID in (" + ORDER_ID + ")");

                    if (kd_deptdt == null) return;

                    for (int j = 0; j < kd_deptdt.Rows.Count; j++)
                    {
                        string kd_dept = kd_deptdt.Rows[j]["dept_id"].ToString();
                        string ordid = kd_deptdt.Rows[j]["ORDER_ID"].ToString();
                        if (kd_dept != dr["dept_id"].ToString() && kd_dept != InstanceForm.BCurrentDept.DeptId.ToString())
                        {
                            for (i = 0; i <= myTb.Rows.Count - 1; i++)
                            {
                                if (myTb.Rows[i]["ORDER_ID"].ToString() == ordid)
                                {
                                    myTb.Rows[i]["选"] = "False";
                                    ss += "\r\n" + myTb.Rows[i]["医嘱内容"].ToString().Trim();
                                    break;
                                }
                            }
                        }

                    }
                }
                #endregion
                if (ss != "以下医嘱开单科室不属于本科室，不允许停医嘱：")
                {
                    MessageBox.Show(ss);
                    return;
                }
                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (i != 0 && myTb.Rows[i]["Group_ID"].ToString().Trim() == myTb.Rows[i - 1]["Group_ID"].ToString().Trim())
                        continue;

                    if (myTb.Rows[i]["医嘱内容"].ToString().Trim() != "" && myTb.Rows[i]["选"].ToString() == "True")
                    {
                        string sssql_ppcl = "";//匹配材料的也要停止
                        if (f1.isDefalut == true)
                        {
                            //末日执行次数为缺省值	已经停的是原操作员可以修改
                            sSql = "update zy_OrderRecord set status_flag=4, " +
                                " TERMINAL_TIMES=case when b.execnum is null then 1 else b.execnum end, " +
                                " ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ", " +
                                " ORDER_EDATE='" + StopDate + "', " +
                                " ORDER_EUDATE='" + StopDate + "' " +
                                "   from zy_OrderRecord a,jc_frequency b " +
                                "  where rtrim(upper(b.name))=rtrim(upper(case when a.frequency is null or ltrim(rtrim(a.frequency))='' then 'qd' else a.frequency end))" +
                                "  and a.group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "       and a.mngtype=2 " +
                                "       and a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID +
                                "		and (a.status_flag=2 or (a.status_flag=4 and (ORDER_EUSER is null or ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ")) )";
                            sssql_ppcl = "update zy_OrderRecord set status_flag=4, " +
                                " TERMINAL_TIMES=case when b.execnum is null then 1 else b.execnum end, " +
                                " ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ", " +
                                " ORDER_EDATE='" + StopDate + "', " +
                                " ORDER_EUDATE='" + StopDate + "' " +
                                "   from   zy_OrderRecord a,jc_frequency b   where  rtrim(upper(b.name))=rtrim(upper(case when a.frequency is null or ltrim(rtrim(a.frequency))='' then 'qd' else a.frequency end))  and   ppcl_yzid in (select  a.order_id   from zy_OrderRecord a  " +
                                "  where  " +
                                "    a.group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "       and a.mngtype=2 " +
                                "       and a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID +
                                "		and (a.status_flag=2 or (a.status_flag=4 and (ORDER_EUSER is null or ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ")) )  )";
                        }
                        else
                        {
                            //末日执行次数为缺省值和设定值的最小值  已经停的是原操作员可以修改
                            sSql = "update zy_OrderRecord set status_flag=4, " +
                                " TERMINAL_TIMES=case when b.execnum is not null and b.execnum<" + sTERMINAL_TIMES + " then b.execnum else " + sTERMINAL_TIMES + " end," +
                                " ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + "," +
                                " ORDER_EDATE='" + StopDate + "'," +
                                " ORDER_EUDATE='" + StopDate + "' " +
                                "       from zy_OrderRecord a,jc_frequency b " +
                                "  where rtrim(upper(b.name))=rtrim(upper(case when a.frequency is null or ltrim(rtrim(a.frequency))='' then 'qd' else a.frequency end))" +
                                " and a.group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "       and a.mngtype=2 " +//and a.status_flag=2 "+
                                "       and a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID +
                                "		and (a.status_flag=2 or (a.status_flag=4 and (ORDER_EUSER is null or ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ")) ) ";
                            sssql_ppcl = "update zy_OrderRecord set status_flag=4, " +
                                " TERMINAL_TIMES=case when b.execnum is not null and b.execnum<" + sTERMINAL_TIMES + " then b.execnum else " + sTERMINAL_TIMES + " end," +
                                " ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + "," +
                                " ORDER_EDATE='" + StopDate + "'," +
                                " ORDER_EUDATE='" + StopDate + "' " +
                                "  from   zy_OrderRecord a,jc_frequency b   where  rtrim(upper(b.name))=rtrim(upper(case when a.frequency is null or ltrim(rtrim(a.frequency))='' then 'qd' else a.frequency end))  and  ppcl_yzid in  (select order_id     from zy_OrderRecord a,jc_frequency b " +
                                "  where rtrim(upper(b.name))=rtrim(upper(case when a.frequency is null or ltrim(rtrim(a.frequency))='' then 'qd' else a.frequency end))" +
                                " and a.group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "       and a.mngtype=2 " +//and a.status_flag=2 "+
                                "       and a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID +
                                "		and (a.status_flag=2 or (a.status_flag=4 and (ORDER_EUSER is null or ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ")) ) )";
                        }
                        InstanceForm.BDatabase.DoCommand(sSql);
                        InstanceForm.BDatabase.DoCommand(sssql_ppcl);
                    }
                }
                #endregion
            }
            if (this.bt未执行.Text.Substring(0, 1) == "未")
            {
                #region 一次性提示错误信息和提交成功的信息   yaokx2013-11-20
                int SuccessCount = sumbitht.Count;
                int FailureCount = errorlist.Count;
                string str = "您选中" + count + "条医嘱，\r\n‘未执行’成功" + SuccessCount + "条(\r\n";
                foreach (DictionaryEntry de in sumbitht)
                {
                    str += "   " + de.Value.ToString().Replace(" ", "") + "\r\n";
                }
                if (FailureCount > 0)
                    str += ");\r\n‘未执行’失败" + FailureCount + "条(\r\n";
                else
                    str += "";
                for (int i = 0; i < FailureCount; i++)
                {
                    Hashtable ht = (Hashtable)errorlist[i];
                    foreach (DictionaryEntry de in ht)
                    {
                        str += "  " + de.Value.ToString().Replace(" ", "") + "\r\n";
                    }
                }
                str += ");";

                MessageBox.Show(str);
                #endregion
            }
            this.ShowData();
        }


        private void myDataGrid3_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid3);
        }

        private void myDataGrid3_Clear()
        {
            DataTable myTb = (DataTable)this.myDataGrid3.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;
            this.myDataGrid3.CaptionText = "项目明细";
            myTb.Rows.Clear();
        }

        private void bt取消开医嘱核对_Click(object sender, System.EventArgs e)
        {

            Button btnNew = (Button)sender;

            Point pp = new Point(btnNew.Location.X, btnNew.Location.Y + btnNew.Height);

            string btName = btnNew.Name.Trim().Substring(2, btnNew.Name.Trim().Length - 2);

            switch (btName)
            {
                case "取消开医嘱核对":
                    #region
                    contextMenu1.Show(btnNew.Parent, pp);
                    break;
                    #endregion
                case "取消停医嘱核对":
                    #region
                    contextMenu2.Show(btnNew.Parent, pp);
                    break;
                    #endregion
            }
        }

        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;

            Button bt = new Button();
            bt.Name = "bt" + mi.Text;

            bt取消开医嘱转抄_Click(bt, e);
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            string sSql = "";
            string sMsg = "";
            string sGroup_id = "";
            string sOrder_id = "";
            string tmpSql = "";
            DataTable tmpTb = new DataTable();
            int j = 1;

            try
            {

                DataTable myTb = (DataTable)this.myDataGrid1.DataSource;

                if (myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["发送时间"].ToString().Trim() != "")
                {
                    MessageBox.Show(this, "账单已经执行，不能删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sGroup_id = myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["group_id"].ToString().Trim();
                sOrder_id = myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["order_id"].ToString().Trim();

                //Modify By Tany 2010-10-11 这里必须再连一下数据库，确定是否发送，避免界面没有刷新
                tmpSql = "select * from zy_orderrecord where order_id='" + sOrder_id + "'";
                tmpTb = InstanceForm.BDatabase.GetDataTable(tmpSql);
                if (tmpTb != null && tmpTb.Rows.Count > 0)
                {
                    if (Convertor.IsNull(tmpTb.Rows[0]["LASTEXECDATE"], "") != "")
                    {
                        MessageBox.Show(this, "账单已经执行，不能删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["group_id"].ToString().Trim() == sGroup_id)
                    {
                        sMsg += "(" + j.ToString() + ") " + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "\n";
                        j = j + 1;
                    }
                }
                //如果只有1条记录则j==2
                if (j > 2)
                {
                    if (MessageBox.Show(this, "是否删除该组账单内容？\n该组账单包含：\n" + sMsg, "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        sSql = "update zy_orderrecord set delete_bit=1,order_euser=" + Convert.ToDecimal(InstanceForm.BCurrentUser.EmployeeId) +
                            ",order_eudate='" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "' where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + Convert.ToDecimal(ClassStatic.Current_BabyID) + " and group_id=" + Convert.ToInt32(sGroup_id) +
                            " and mngtype=" + GetMNGType();
                    }
                }
                if (sSql == "")
                {
                    if (MessageBox.Show(this, "是否删除账单 " + myTb.Rows[myDataGrid1.CurrentCell.RowNumber]["医嘱内容"].ToString().Trim() + " ？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        //判断是否是煎药费
                        tmpSql = "select 1 from zy_decoct where inpatient_id='" + ClassStatic.Current_BinID + "' and order_id='" + sOrder_id + "'";
                        tmpTb = InstanceForm.BDatabase.GetDataTable(tmpSql);
                        if (tmpTb.Rows.Count > 0)
                        {
                            if (MessageBox.Show("该账单是草药煎药费，如果删除，药房将不会代煎草药，是否真的要删除账单？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                //如果一定要删除，则清除代煎
                                //Modify by jchl 不清除煎药信息
                                //tmpSql = "update zy_decoct set order_id=DBO.FUN_GETEMPTYGUID() where inpatient_id='" + ClassStatic.Current_BinID + "' and order_id='" + sOrder_id + "'";
                                //InstanceForm.BDatabase.DoCommand(tmpSql);
                            }
                        }

                        sSql = "update zy_orderrecord set delete_bit=1,order_euser=" + Convert.ToDecimal(InstanceForm.BCurrentUser.EmployeeId) +
                            ",order_eudate='" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "' where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and order_id='" + sOrder_id + "'";
                    }
                }

                //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
                if (new SystemCfg(7066).Config == "0")
                {
                    frmInPassword f1 = new frmInPassword();
                    f1.ShowDialog();
                    if (f1.isLogin == false) return;
                }

                InstanceForm.BDatabase.DoCommand(sSql);
                MessageBox.Show(this, "执行成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //写日志 Add By Tany 2005-01-12
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "删除账单", "删除" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + "的账单Group_id=" + sGroup_id + " Order_id=" + sOrder_id, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;

                ShowData();

            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "删除账单错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt退出_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmYZGL_Activated(object sender, System.EventArgs e)
        {
            frmYZGL_Load(null, null);
        }

        private void frmYZGL_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                bt详细信息_Click(null, null);
            }
            if (e.KeyCode == Keys.F2)
            {
                rb显示病人列表.Checked = true;
                rb显示病人列表_Click(null, null);
            }
            if (e.KeyCode == Keys.F3)
            {
                rb隐藏病人列表.Checked = true;
                rb显示病人列表_Click(null, null);
            }
            if (e.KeyCode == Keys.Home)
            {
                myDataGrid1.ScollRow(0);
            }
            if (e.KeyCode == Keys.End)
            {
                DataTable tb = (DataTable)myDataGrid1.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    myDataGrid1.ScollRow(tb.Rows.Count - 1);
                }
            }
        }

        private void LoadWard()
        {
            DataTable myTb = new DataTable();
            string sSql = "";

            cmbWard.Items.Clear();
            cmbWard.DataSource = null;

            cmbWard.SelectedIndexChanged -= new EventHandler(cmbWard_SelectedIndexChanged);
            if (isCX)
            {
                sSql = "select WARD_ID,WARD_NAME from jc_ward where jgbm=" + FrmMdiMain.Jgbm + " order by ward_id";
                myTb = InstanceForm.BDatabase.GetDataTable(sSql);

                cmbWard.DataSource = myTb;
                cmbWard.DisplayMember = "WARD_NAME";
                cmbWard.ValueMember = "WARD_ID";
            }
            else
            {
                cmbWard.Items.Add(InstanceForm.BCurrentDept.WardName);
            }
            cmbWard.SelectedIndexChanged += new EventHandler(cmbWard_SelectedIndexChanged);
        }

        private void cmbWard_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (isSSMZ && !rbTkxs.Checked)
                return;

            if (rbIn.Checked)
            {
                if (isCX)
                {
                    binSql = @" SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end 医保类型,BRLX_NAME 病人类型,XZLX_NAME 险种类型,DYLX_NAME 待遇类型 " +
                        "   FROM vi_zy_vInpatient_Bed " +
                        "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' ORDER BY INPATIENT_NO,Baby_ID";
                }
                else
                {
                    binSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                        "   FROM vi_zy_vInpatient_Bed " +
                        "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
                }
            }
            else if (rbTempOut.Checked)
            {
                if (isCX)
                {
                    binSql = @" SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end 医保类型,BRLX_NAME 病人类型,XZLX_NAME 险种类型,DYLX_NAME 待遇类型 " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' and flag = 5 ORDER BY INPATIENT_NO,Baby_ID";
                }
                else
                {
                    binSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and flag = 5 ORDER BY CHARINDEX('+',bed_no) ASC,case when isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
                }
                if (zczyz_notfy)
                {
                    binSql = @" SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end 医保类型,BRLX_NAME 病人类型,XZLX_NAME 险种类型,DYLX_NAME 待遇类型 " +
                          "   FROM vi_zy_vInpatient_All " +
                          "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' and flag = 5 ORDER BY INPATIENT_NO,Baby_ID";
                }
            }
            else if (rbOut.Checked)
            {
                int _outMonth = Convert.ToInt32((new SystemCfg(7023)).Config) * -1;
                DateTime _outDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddMonths(_outMonth);

                if (isCX)
                {
                    binSql = @" SELECT INPATIENT_NO AS 住院号,BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,case dischargetype when 1 then YBLX_NAME else jsfs_name end 医保类型,BRLX_NAME 病人类型,XZLX_NAME 险种类型,DYLX_NAME 待遇类型 " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE WARD_ID= '" + cmbWard.SelectedValue + "' and flag in (2,6) " +
                        "  and out_Date>= '" + _outDate.Date + "' ORDER BY INPATIENT_NO,Baby_ID";
                }
                else
                {
                    binSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and flag in (2,6) " +
                        "  and out_Date>= '" + _outDate.Date + "' ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
                }
            }
            else if (rbTrans.Checked)
            {
                binSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS 住院号 " +
                    "   FROM vi_zy_vInpatient_All " +
                    "  WHERE  flag in(1,3,4,5) and inpatient_id in (select inpatient_id from zy_transfer_dept where cancel_bit=0 and finish_bit=1 and s_dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')) " +
                    "  ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";//2012-4-22 Modify by zouchihua 只显示在院病人
            }
            else if (rbTszl.Checked)
            {
                binSql = @" SELECT BED_NO AS 床号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS 住院号 " +
                    "   FROM vi_zy_vInpatient_Bed " +
                    "  WHERE inpatient_id in (select inpatient_id from ZY_TS_APPLY where status_flag=1 and delete_bit=0 and (DATEDIFF(DAY,apply_date,GetDate())) <= (Select cast(config as int) a from JC_CONFIG where id=6002) and (ts_dept = " + InstanceForm.BCurrentDept.DeptId + " or ts_dept in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "'))) " +
                    "   ORDER BY case when  isnumeric(bed_no)=1 and SUBSTRING (bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[吖-座]%',bed_no)>0 then 2 when SUBSTRING (bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(bed_no)=1 then cast(bed_no as int) else 999999 end,bed_no,Baby_ID";
            }
            if (rbTkxs.Checked)
            {
                //add by zouchihua 2014-8-16 他科医嘱
                binSql = @"select  BED_NO AS 床号,NAME AS 姓名,a.INPATIENT_ID,a.Baby_ID,DEPT_ID,isMY,INPATIENT_NO AS 住院号 from 
	    vi_zy_vInpatient_Bed a join  
	    (  select inpatient_id,baby_id from ZY_ORDERRECORD where  ISNULL(tkxs,0) in (select dept_id from JC_WARDRDEPT where WARD_ID   in (select WARD_ID from JC_WARDRDEPT where DEPT_ID='" + FrmMdiMain.CurrentDept.DeptId + @"' ))
	      group by  inpatient_id,baby_id
	    ) b on a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id";
            }

            frmYZGL_Load(null, null);
            myDataGrid2_CurrentCellChanged(null, null);
        }

        private void rb_Click(object sender, System.EventArgs e)
        {
            if (isSSMZ && !rbTkxs.Checked)
            {
                return;
            }

            if (rbIn.Checked)
            {
                if (isCX == false)
                {
                    bt立即执行.Visible = true;
                    bt医嘱打印.Visible = true;
                    bt取消停医嘱核对.Visible = true;
                    bt取消停医嘱转抄.Visible = true;
                    bt取消开医嘱核对.Visible = true;
                    bt取消开医嘱转抄.Visible = true;
                    btnDelete.Visible = true;
                    bt未执行.Visible = true;
                    bt阳性.Visible = true;
                    bt阴性.Visible = true;
                }
            }
            else if (rbTrans.Checked || rbTszl.Checked)
            {
                bt立即执行.Visible = true;
                bt取消停医嘱核对.Visible = false;
                bt取消停医嘱转抄.Visible = false;
                bt取消开医嘱核对.Visible = false;
                bt取消开医嘱转抄.Visible = false;
                btnDelete.Visible = false;
                bt未执行.Visible = false;
                if (cfg7159.Config.Trim() == "1")
                {
                    if (bt未执行.Text.Contains("停"))
                        bt未执行.Visible = true;
                }
                bt阳性.Visible = false;
                bt阴性.Visible = false;

            }
            else
            {
                bt立即执行.Visible = false;
                bt取消停医嘱核对.Visible = false;
                bt取消停医嘱转抄.Visible = false;
                bt取消开医嘱核对.Visible = false;
                bt取消开医嘱转抄.Visible = false;
                btnDelete.Visible = false;
                bt未执行.Visible = false;
                bt阳性.Visible = false;
                bt阴性.Visible = false;
            }
            //add by zouchihua 2012-4-27 特殊治疗病人转抄签名
            if (rbTszl.Checked)
            {
                this.BtnTszlZcQm.Visible = true;
                this.btnCheck.Visible = true;
            }

            else
            {
                this.BtnTszlZcQm.Visible = false;
                this.btnCheck.Visible = false;
            }
            //他科显示
            if (rbTkxs.Checked)
            {
                bt立即执行.Visible = true;
                bt医嘱打印.Visible = true;
                bt取消停医嘱核对.Visible = true;
                bt取消停医嘱转抄.Visible = true;
                bt取消开医嘱核对.Visible = true;
                bt取消开医嘱转抄.Visible = true;
                btnDelete.Visible = true;
                bt未执行.Visible = true;
                bt阳性.Visible = true;
                bt阴性.Visible = true;
            }
            cmbWard_SelectedIndexChanged(null, null);
        }

        private void rb显示病人列表_Click(object sender, System.EventArgs e)
        {
            if (rb显示病人列表.Checked)
            {
                panel3.Visible = true;
            }
            else
            {
                panel3.Visible = false;
            }
        }

        private void bt执行时间_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = 0;
            int SelCount = 0;

            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        if (Convert.ToInt32(myTb.Rows[i]["status_flag"]) != 5)
                        {
                            MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 还没有发送，请先发送该条（组）医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int j = 0; j < myTb.Rows.Count; j++)
                            {
                                if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                {
                                    myTb.Rows[j]["选"] = false;
                                }
                            }
                            return;
                        }
                        nrow = i;
                        SelCount++;
                    }
                    if (myTb.Rows[i]["医嘱内容"].ToString().IndexOf("取消") >= 0)
                    {
                        MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 已经标'未执行'，不能使用'执行时间'！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if (SelCount == 0)
            {
                MessageBox.Show("没有选择医嘱，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("是否确定更改医嘱的实际执行时间？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            DateTime _execTime = new DateTime();
            long _employeeId = 0;

            frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
            frmET.ShowDialog();
            if (frmET.DialogResult == DialogResult.OK)
            {
                _execTime = frmET._execTime;
                _employeeId = frmET._employeeId;
            }
            else
            {
                return;
            }

            //开始更新数据
            Cursor.Current = PubStaticFun.WaitCursor();

            string sSql = "";
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        //更新医嘱执行表
                        sSql = "update zy_orderexec set realexecdate='" + _execTime + "',realexeuser=" + _employeeId +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);
                        //更新医嘱打印表 --Modify by zouchihua 2012-6-6 屏蔽后可以支持续打执行时间
                        //sSql = "update zy_tmporderprt set execdate='" + _execTime + "',exeuser=" + _employeeId + " "+
                        //    " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                        //    " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        //InstanceForm.BDatabase.DoCommand(sSql);

                        //写日志 Add By Tany 2005-01-12
                        SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "更新执行时间", "将病人" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + " Group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + " 的医嘱执行时间更新为 " + _execTime.ToString() + " " + _employeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                        _systemLog.Save();
                        _systemLog = null;
                    }
                }
            }

            //刷新界面
            this.tabControl1_SelectedIndexChanged(sender, e);

            Cursor.Current = Cursors.Default;

            MessageBox.Show("更新执行时间成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //添加网格里面的textbox的双击事件
        public void DataGridTextboxAddDoubleClick(DataGridEx grid, int tableStyleIndex)
        {
            DataGridTextBoxColumn dgtxt = null;
            for (int i = 0; i < grid.TableStyles[tableStyleIndex].GridColumnStyles.Count; i++)
            {
                if (grid.TableStyles[tableStyleIndex].GridColumnStyles[i].GetType().ToString() == "System.Windows.Forms.DataGridTextBoxColumn")
                {
                    dgtxt = (DataGridTextBoxColumn)grid.TableStyles[tableStyleIndex].GridColumnStyles[i];
                    dgtxt.TextBox.DoubleClick += new EventHandler(myDataGrid1_DoubleClick);
                }
                else if (grid.TableStyles[tableStyleIndex].GridColumnStyles[i].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn")
                {
                    dgtxt = (DataGridEnableTextBoxColumn)grid.TableStyles[tableStyleIndex].GridColumnStyles[i];
                    dgtxt.TextBox.DoubleClick += new EventHandler(myDataGrid1_DoubleClick);
                }
            }
        }

        private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null)
                return;
            if (myTb.Rows.Count == 0)
                return;
            int nrow = 0;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            //add yaokx  2014-06-03
            int nType = this.GetMNGType();
            if (nType == 1 || nType == 5)
            {
                if (myTb.Rows[nrow]["医嘱内容"].ToString().IndexOf("取消") >= 0)
                {
                    this.bt执行时间.Enabled = false;
                }
                else
                {
                    this.bt执行时间.Enabled = true;
                }
            }
            //如果医嘱ID为空
            if (myTb.Rows[nrow]["Group_ID"].ToString() == "") return;

            //if (myTb.Rows.Count > 0 && myTb.Rows[nrow]["xmly"].ToString() == "2" && new SystemCfg(7202).Config =="1")
            //{
            //    string sql_1 = @"select * from jc_sf_wz where item_id_sf=" + myTb.Rows[nrow]["item_code"].ToString() + "";
            //    DataTable dt_1 = InstanceForm.BDatabase.GetDataTable(sql_1);
            //    if (dt_1.Rows.Count > 0)
            //    {
            //        string sql = @"select * from ZY_ORDERRECORD where order_id='" + myTb.Rows[nrow]["order_id"] + "'";
            //        DataRow dr = InstanceForm.BDatabase.GetDataRow(sql);
            //        int type = 0;
            //        if (this.GetMNGType() == 0 || this.GetMNGType() == 2)
            //        {
            //            type = 2;
            //        }
            //        else
            //        {
            //            type = 3;
            //        }

            //        FrmWzxm frm = new FrmWzxm();
            //        frm.Itemidsf = myTb.Rows[nrow]["item_code"].ToString();
            //        frm.BinID = ClassStatic.Current_BinID;
            //        frm.BabyID = ClassStatic.Current_BabyID;
            //        frm.RbIn = rbIn.Checked ? true : false;
            //        frm.Yztype = type;
            //        frm.IsSSMZ = isSSMZ;
            //        frm.RbTszl = rbTszl.Checked ? true : false;
            //        frm.MyTb = myTb;
            //        frm.Nrow = nrow;
            //        frm.First_times = dr["first_times"].ToString();
            //        frm.Dept_id = Convert.ToInt32(dr["DEPT_ID"].ToString());
            //    }
            //}
            if (myTb.Rows.Count > 0 && !chkSsyz.Checked) //update pengyang 2015-8-7 手术医嘱不显示
            {
                frmYZXX f1 = new frmYZXX();
                f1.sTitle = "病人“" + this.sName + "”医嘱详细信息";
                f1.MNGType = this.GetMNGType();
                f1.MNGType2 = f1.MNGType == 1 ? 5 : f1.MNGType;
                f1.Group_ID = Convert.ToInt32(myTb.Rows[nrow]["Group_ID"]);
                f1.OrderID = new Guid(myTb.Rows[nrow]["Order_ID"].ToString());
                f1.nType = Convert.ToInt32(myTb.Rows[nrow]["ntype"]);
                f1.isSSMZ = isSSMZ;
                f1.isTSZL = rbTszl.Checked ? true : false;
                f1.isCX = isCX;


                if (rbIn.Checked || rbTrans.Checked || rbTszl.Checked)
                {
                    f1.isUNCZ = false;
                    //add by zouchihua 2013-8-24 特殊治疗如果开了出院医嘱，不允许冲正
                    if (rbTszl.Checked && cfg7160.Config.Trim() == "0")
                    {
                        DataTable tbbr = InstanceForm.BDatabase.GetDataTable("select flag from VI_ZY_VINPATIENT_BED where INPATIENT_ID='" + ClassStatic.Current_BinID + "' and baby_id='" + ClassStatic.Current_BabyID + "' and flag=4");
                        if (tbbr.Rows.Count > 0)
                        {
                            f1.isUNCZ = true;
                        }
                    }

                }
                else
                {
                    f1.isUNCZ = true;
                }
                //判断如果医保结算不能冲正 add by zouchihua 2013-01-07
                //string sql = "select IS_YBJS from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'";
                //DataTable temptb = FrmMdiMain.Database.GetDataTable(sql);
                //if (temptb.Rows.Count > 0)
                //{
                //    if (temptb.Rows[0]["IS_YBJS"].ToString().Trim() == "1")
                //        f1.isUNCZ = true;
                //}
                #region//Add by Zouchihua 2011-10-11 判断病人的当前科室是不是属于本院区，主要是为了阻止临时跨院业务的病人操作
                string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
                if (rtnSql[0] != "0")
                {
                    f1.isUNCZ = true;
                }
                //if (rtnSql[1]!="0")//特殊治疗未完成
                //{
                //   f1.isUNCZ = true;
                //}
                #endregion
                if (zczyz_notfy)
                {
                    //出区的病人冲正，只能冲正药品。并且不产生发药信息
                    f1.isUNCZ = false;
                    f1.zczyz_notfy = zczyz_notfy;
                }
                f1.ShowDialog();
            }
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_yzdy", "Fun_ts_zyhs_yzdy", "医嘱打印", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_zxd", "Fun_ts_zyhs_zxd", "执行单", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }
        private void menuItem9_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (GetMNGType() != 1 && GetMNGType() != 3)
            {
                MessageBox.Show("只能打印临时医嘱和账单", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = 0;
            int SelCount = 0;

            try
            {
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                    {
                        if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                        {
                            if (Convert.ToInt32(myTb.Rows[i]["status_flag"]) != 5)
                            {
                                MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 还没有发送，请先发送该条（组）医嘱", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                for (int j = 0; j < myTb.Rows.Count; j++)
                                {
                                    if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                    {
                                        myTb.Rows[j]["选"] = false;
                                    }
                                }
                                return;
                            }
                            //只能打印4,5,6,8,9类型
                            if (Convert.ToInt32(myTb.Rows[i]["ntype"]) != 4
                                && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 5
                                && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 6
                                && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 8
                                && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 9)
                            {
                                MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 不能打印，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                for (int j = 0; j < myTb.Rows.Count; j++)
                                {
                                    if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                    {
                                        myTb.Rows[j]["选"] = false;
                                    }
                                }
                                return;
                            }
                            nrow = i;
                            SelCount++;
                        }
                    }
                }

                if (SelCount == 0)
                {
                    MessageBox.Show("没有选择医嘱，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                rds.Tables["tabZYJZPZ"].Clear();
                string _msg = "";

                //Add By Tany 2010-09-26 打印次数用变量
                string sSql = "";
                string[] sql = new string[myTb.Rows.Count];



                //Add By Tany 2010-08-30 增加合并项打印
                if (new SystemCfg(2).Config.Trim().Contains("长沙市第三医院") || MessageBox.Show("是否合并打印选中的医嘱？", "提问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No || SelCount == 1)
                {
                    //不合并
                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                        {
                            decimal _je = 0;
                            _je = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_GETORDERFEE_EX('" + myTb.Rows[i]["Order_ID"].ToString() + "')"), "0"));

                            #region add by 岳成成 2014-08-05
                            string sqlstring = "select cast(ISNULL(cast(c.FLID as varchar(36)),NEWID()) as varchar(36)) flid from ZY_ORDERRECORD  a" +
                                            " left join JC_ASSAY b on a.HOITEM_ID=b.YZID" +
                                            " left join JC_JYBBFLMX c on b.YZID=c.YZXMID" +
                                            " where a.XMLY=2" +
                                          " and a.ORDER_ID='" + myTb.Rows[i]["Order_ID"].ToString() + "'";
                            DataTable dt = new DataTable();
                            dt = InstanceForm.BDatabase.GetDataTable(sqlstring);
                            #endregion
                            //金额为0不显示
                            if (_je != 0)
                            {
                                dr = rds.Tables["tabZYJZPZ"].NewRow();

                                dr["病区名称"] = InstanceForm.BCurrentDept.WardDeptName;
                                dr["床号"] = patientInfo1.lbBed.Text;
                                dr["住院号"] = patientInfo1.lbID.Text;
                                dr["姓名"] = patientInfo1.lbName.Text;
                                dr["年龄"] = patientInfo1.lbAge.Text;//add by 岳成成 2014-08-05
                                dr["分组ID"] = dt.Rows[0]["flid"].ToString();//add by 岳成成 2014-08-05 
                                dr["科室"] = patientInfo1.lbDQKS.Text;
                                dr["性别"] = patientInfo1.lbSex.Text;
                                dr["医嘱ID"] = myTb.Rows[i]["Order_ID"].ToString();
                                dr["医嘱日期"] = Convert.ToDateTime(myTb.Rows[i]["发送时间"]).ToShortDateString();
                                dr["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString();
                                dr["医嘱金额"] = _je.ToString();

                                //Add By Tany 2010-08-30
                                dr["开嘱医生"] = myTb.Rows[i]["开嘱医生"].ToString();
                                dr["执行护士"] = myTb.Rows[i]["发送护士"].ToString();
                                dr["执行时间"] = myTb.Rows[i]["发送时间"].ToString();
                                dr["执行科室"] = myTb.Rows[i]["执行科室"].ToString();

                                //Add By Tany 2010-09-26
                                //查询是否打印过
                                sSql = "select id from zy_printzxd where order_id='" + myTb.Rows[i]["order_id"].ToString() + "' and kind=0";//Modify By Tany 2010-09-26 这里定义kind=0为记账凭证
                                DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                                //Modify By Tany 2010-09-26 形成sql数组
                                if (tempTab.Rows.Count > 0)
                                {
                                    dr["重打状态"] = "重打";
                                    dr["重打次数"] = tempTab.Rows.Count.ToString();
                                }
                                else
                                {
                                    dr["重打状态"] = "";
                                    dr["重打次数"] = "";
                                }
                                //不管有没有重打，都插入新纪录，记录打印次数
                                sql[i] = "insert into zy_printzxd(KIND,ORDER_ID,ZXD_DATE,PRINT_DATE,PRINT_USER,JGBM) values (" +
                                        "0,'" +
                                        myTb.Rows[i]["order_id"].ToString() + "'," +
                                        "'" + Convert.ToDateTime(myTb.Rows[i]["发送时间"]) + "'," +
                                        "getdate()," +
                                        InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";

                                rds.Tables["tabZYJZPZ"].Rows.Add(dr);
                            }
                            else
                            {
                                _msg += " ⊙ 第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] \n";
                            }
                        }
                    }
                }
                else
                {
                    TsSet tsset = new TsSet();
                    string[] GroupbyField ={ "执行科室", "开嘱医生", "重打次数" };
                    string[] ComputeField ={ "医嘱内容" };
                    string[] CField ={ "count" };

                    //Add By Tany 2010-09-26
                    if (!myTb.Columns.Contains("重打次数"))
                    {
                        myTb.Columns.Add("重打次数");
                    }

                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                        {
                            //查询是否打印过
                            sSql = "select id from zy_printzxd where order_id='" + myTb.Rows[i]["order_id"].ToString() + "' and kind=0";//Modify By Tany 2010-09-26 这里定义kind=0为记账凭证
                            DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);

                            myTb.Rows[i]["重打次数"] = tempTab.Rows.Count;
                        }
                    }

                    tsset.TsDataTable = myTb;

                    DataTable tb = tsset.GroupTable(GroupbyField, ComputeField, CField, " 选=True");

                    for (int j = 0; j < tb.Rows.Count; j++)
                    {
                        //合并
                        decimal _zje = 0;
                        string yznr = "";
                        string yzid = "";
                        int ii = 0;

                        for (int i = 0; i < myTb.Rows.Count; i++)
                        {
                            if (myTb.Rows[i]["选"].ToString().Trim() == "True"
                                && myTb.Rows[i]["执行科室"].ToString().Trim() == tb.Rows[j]["执行科室"].ToString().Trim()
                                && myTb.Rows[i]["开嘱医生"].ToString().Trim() == tb.Rows[j]["开嘱医生"].ToString().Trim()
                                && myTb.Rows[i]["重打次数"].ToString().Trim() == tb.Rows[j]["重打次数"].ToString().Trim())//Add By tany 2010-09-26 重打次数要一样
                            {
                                decimal _je = 0;
                                _je = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_GETORDERFEE_EX('" + myTb.Rows[i]["Order_ID"].ToString() + "')"), "0"));
                                //金额为0不显示
                                if (_je != 0)
                                {
                                    _zje += _je;
                                    yznr += myTb.Rows[i]["医嘱内容"].ToString().Trim() + ",";
                                    yzid += myTb.Rows[i]["Order_ID"].ToString().Trim() + ",";

                                    ii++;

                                    //不管有没有重打，都插入新纪录，记录打印次数
                                    sql[i] = "insert into zy_printzxd(KIND,ORDER_ID,ZXD_DATE,PRINT_DATE,PRINT_USER,JGBM) values (" +
                                            "0,'" +
                                            myTb.Rows[i]["order_id"].ToString() + "'," +
                                            "'" + Convert.ToDateTime(myTb.Rows[i]["发送时间"]) + "'," +
                                            "getdate()," +
                                            InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";
                                }
                                else
                                {
                                    _msg += " ⊙ 第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] \n";
                                }
                            }
                        }
                        if (_zje != 0)
                        {
                            dr = rds.Tables["tabZYJZPZ"].NewRow();

                            dr["床号"] = patientInfo1.lbBed.Text;
                            dr["住院号"] = patientInfo1.lbID.Text;
                            dr["姓名"] = patientInfo1.lbName.Text;
                            dr["科室"] = patientInfo1.lbDQKS.Text;
                            dr["性别"] = patientInfo1.lbSex.Text;
                            dr["医嘱ID"] = yzid;
                            dr["医嘱日期"] = "";
                            dr["医嘱内容"] = ii.ToString() + "项合并(" + yznr + ")";
                            dr["医嘱金额"] = _zje;

                            //Add By Tany 2010-08-30
                            dr["开嘱医生"] = tb.Rows[j]["开嘱医生"].ToString().Trim();
                            dr["执行护士"] = "";
                            dr["执行时间"] = "";
                            dr["执行科室"] = tb.Rows[j]["执行科室"].ToString().Trim();

                            if (Convert.ToInt32(tb.Rows[j]["重打次数"]) > 0)
                            {
                                dr["重打状态"] = "重打";
                                dr["重打次数"] = tb.Rows[j]["重打次数"].ToString();
                            }
                            else
                            {
                                dr["重打状态"] = "";
                                dr["重打次数"] = "";
                            }

                            rds.Tables["tabZYJZPZ"].Rows.Add(dr);
                        }
                    }
                }

                if (_msg.Trim() != "")
                {
                    MessageBox.Show("以下医嘱费用为0，不能打印！\n\n" + _msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (rds.Tables["tabZYJZPZ"].Rows.Count == 0)
                {
                    return;
                }

                FrmReportView frmRptView = null;
                string _reportName = "";
                ParameterEx[] _parameters = new ParameterEx[2];


                _reportName = "ZYHS_住院记帐凭证.rpt";

                _parameters[0].Text = "打印人";
                _parameters[0].Value = InstanceForm.BCurrentUser.Name;
                _parameters[1].Text = "医院名称";
                _parameters[1].Value = new SystemCfg(0002).Config;

                frmRptView = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);

                //Add By Tany 2010-09-26
                frmRptView._sqlStr = sql;

                frmRptView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void menu_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
                {
                    MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //如果病人控件信息没有，则激活一下
                if (patientInfo1.lbID.Text.Trim() == "")
                {
                    this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);
                }

                int iSel = GetMNGType();

                //Modify By Tany 2014-12-11 账单和医嘱共用
                //if (iSel != 2 && iSel != 3)
                //{
                //    MessageBox.Show("只能打印账单相关信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb == null) return;
                if (myTb.Rows.Count == 0) return;

                int nrow = 0;
                int SelCount = 0;

                try
                {
                    rds.Tables["dtBillInfo"].Clear();
                    string _msg = "";

                    //Add By Tany 2010-09-26 打印次数用变量
                    string sSql = "";
                    string[] sql = new string[myTb.Rows.Count];

                    FrmReportView frmRptView = null;
                    string _reportName = "";
                    ParameterEx[] _parameters = new ParameterEx[6];

                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        //打印长期账单
                        if (iSel == 2 || iSel == 0)
                        {

                            dr = rds.Tables["dtBillInfo"].NewRow();
                            //string[] GrdMappingName ={ "status_flag","Order_ID","Group_ID","Num","Unit","dwlx","Order_Usage","frequency","Dropsper","Dosage",
                            //                "ntype","exec_dept","day1","second1","day2","second2", "AUDITING_USER","AUDITING_USER1",
                            //                "order_euser","order_euser1","item_code","xmly",     
                            //                "选",
                            //                "开日期","开时间","医嘱内容","费用","开嘱医生","开嘱转抄","开嘱核对",
                            //                "停日期","停时间","停嘱医生","停嘱转抄","停嘱核对",
                            //                "执行时间","执行人","执行科室","发送时间","发送护士",//"执行时间","执行人",
                            //                "ps_flag","ps_orderid","ps_user","wzx_flag","P","hoitem_id","isprintypgg"};//isggdy add by zouchihua 2011-11-30


                            dr["order_id"] = myTb.Rows[i]["Order_ID"].ToString();
                            dr["inpatient_id"] = patientInfo1.lbID.Text.ToString();

                            dr["开始日期"] = myTb.Rows[i]["开日期"].ToString();
                            dr["开始时间"] = myTb.Rows[i]["开时间"].ToString();
                            dr["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString();
                            dr["录入人"] = iSel == 0 ? myTb.Rows[i]["开嘱医生"].ToString() : myTb.Rows[i]["开嘱转抄"].ToString();

                            dr["停止日期"] = myTb.Rows[i]["停日期"].ToString();
                            dr["停止时间"] = myTb.Rows[i]["停时间"].ToString();
                            dr["停止人"] = iSel == 0 ? myTb.Rows[i]["停嘱医生"].ToString() : myTb.Rows[i]["执行人"].ToString();

                            dr["执行科室"] = myTb.Rows[i]["执行科室"].ToString();
                            dr["发送时间"] = myTb.Rows[i]["发送时间"].ToString();
                            dr["发送人"] = myTb.Rows[i]["发送护士"].ToString();

                            rds.Tables["dtBillInfo"].Rows.Add(dr);
                            _reportName = "ZD_长期账单.rpt";

                            _parameters[0].Text = "TitleText";
                            _parameters[0].Value = iSel == 0 ? "长期医嘱" : "长期账单";
                        }
                        else
                        {
                            //打印临时账单
                            dr = rds.Tables["dtBillInfo"].NewRow();

                            dr["order_id"] = myTb.Rows[i]["Order_ID"].ToString();
                            dr["inpatient_id"] = patientInfo1.lbID;

                            dr["开始日期"] = myTb.Rows[i]["开日期"].ToString();
                            dr["开始时间"] = myTb.Rows[i]["开时间"].ToString();
                            dr["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString();
                            dr["录入人"] = iSel == 1 ? myTb.Rows[i]["开嘱医生"].ToString() : myTb.Rows[i]["开嘱转抄"].ToString();

                            dr["执行科室"] = myTb.Rows[i]["执行科室"].ToString();
                            dr["发送时间"] = myTb.Rows[i]["发送时间"].ToString();
                            dr["发送人"] = myTb.Rows[i]["发送护士"].ToString();

                            rds.Tables["dtBillInfo"].Rows.Add(dr);
                            _reportName = "ZD_临时账单.rpt";

                            _parameters[0].Text = "TitleText";
                            _parameters[0].Value = iSel == 1 ? "临时医嘱" : "临时账单";
                        }
                        int ntype = Convert.ToInt16(myTb.Rows[i]["ntype"]);
                        string stype = "";
                        switch (ntype)
                        {
                            case 0:
                                stype = "出院转科";
                                break;
                            case 1:
                                stype = "西药";
                                break;
                            case 2:
                                stype = "中成药";
                                break;
                            case 3:
                                stype = "中草药";
                                break;
                            case 4:
                                stype = "治疗";
                                break;
                            case 5:
                                stype = "医技";
                                break;
                            case 6:
                                stype = "手术";
                                break;
                            case 7:
                                stype = "说明";
                                break;
                            case 8:
                                stype = "护理";
                                break;
                            case 9:
                                stype = "其他";
                                break;
                        }
                        dr["医嘱类别"] = stype;
                    }

                    if (rds.Tables["dtBillInfo"].Rows.Count == 0)
                    {
                        return;
                    }

                    _parameters[1].Text = "床号";
                    _parameters[1].Value = patientInfo1.lbBed.Text;
                    _parameters[2].Text = "姓名";
                    _parameters[2].Value = patientInfo1.lbName.Text;
                    _parameters[3].Text = "病区";
                    _parameters[3].Value = FrmMdiMain.CurrentDept.WardName;
                    _parameters[4].Text = "科室";
                    _parameters[4].Value = patientInfo1.lbDQKS.Text;
                    _parameters[5].Text = "住院号";
                    _parameters[5].Value = patientInfo1.lbID.Text;

                    frmRptView = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);

                    frmRptView.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch { }
        }
        //private void menuItem9_Click(object sender, EventArgs e)
        //{
        //    if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
        //    {
        //        MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    if (GetMNGType() != 1 && GetMNGType() != 3)
        //    {
        //        MessageBox.Show("只能打印临时医嘱和账单", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
        //    if (myTb == null) return;
        //    if (myTb.Rows.Count == 0) return;

        //    int nrow = 0;
        //    int SelCount = 0;

        //    try
        //    {
        //        for (int i = 0; i < myTb.Rows.Count; i++)
        //        {
        //            if (myTb.Rows[i]["选"].ToString().Trim() == "True")
        //            {
        //                if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
        //                {
        //                    if (Convert.ToInt32(myTb.Rows[i]["status_flag"]) != 5)
        //                    {
        //                        MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 还没有发送，请先发送该条（组）医嘱", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        for (int j = 0; j < myTb.Rows.Count; j++)
        //                        {
        //                            if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
        //                            {
        //                                myTb.Rows[j]["选"] = false;
        //                            }
        //                        }
        //                        return;
        //                    }
        //                    //只能打印4,5,6,8,9类型
        //                    if (Convert.ToInt32(myTb.Rows[i]["ntype"]) != 4
        //                        && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 5
        //                        && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 6
        //                        && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 8
        //                        && Convert.ToInt32(myTb.Rows[i]["ntype"]) != 9)
        //                    {
        //                        MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 不能打印，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        for (int j = 0; j < myTb.Rows.Count; j++)
        //                        {
        //                            if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
        //                            {
        //                                myTb.Rows[j]["选"] = false;
        //                            }
        //                        }
        //                        return;
        //                    }
        //                    nrow = i;
        //                    SelCount++;
        //                }
        //            }
        //        }

        //        if (SelCount == 0)
        //        {
        //            MessageBox.Show("没有选择医嘱，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        rds.Tables["tabZYJZPZ"].Clear();
        //        string _msg = "";

        //        //Add By Tany 2010-09-26 打印次数用变量
        //        string sSql = "";
        //        string[] sql = new string[myTb.Rows.Count];

        //        //Add By Tany 2010-08-30 增加合并项打印
        //        if (MessageBox.Show("是否合并打印选中的医嘱？", "提问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No || SelCount == 1)
        //        {
        //            //不合并
        //            for (int i = 0; i < myTb.Rows.Count; i++)
        //            {
        //                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
        //                {
        //                    decimal _je = 0;
        //                    _je = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_GETORDERFEE_EX('" + myTb.Rows[i]["Order_ID"].ToString() + "')"), "0"));
        //                    //金额为0不显示
        //                    if (_je != 0)
        //                    {
        //                        dr = rds.Tables["tabZYJZPZ"].NewRow();

        //                        dr["床号"] = patientInfo1.lbBed.Text;
        //                        dr["住院号"] = patientInfo1.lbID.Text;
        //                        dr["姓名"] = patientInfo1.lbName.Text;
        //                        dr["科室"] = patientInfo1.lbDQKS.Text;
        //                        dr["性别"] = patientInfo1.lbSex.Text;
        //                        dr["医嘱ID"] = myTb.Rows[i]["Order_ID"].ToString();
        //                        dr["医嘱日期"] = Convert.ToDateTime(myTb.Rows[i]["发送时间"]).ToShortDateString();
        //                        dr["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString();
        //                        dr["医嘱金额"] = _je.ToString();

        //                        //Add By Tany 2010-08-30
        //                        dr["开嘱医生"] = myTb.Rows[i]["开嘱医生"].ToString();
        //                        dr["执行护士"] = myTb.Rows[i]["发送护士"].ToString();
        //                        dr["执行时间"] = myTb.Rows[i]["发送时间"].ToString();
        //                        dr["执行科室"] = myTb.Rows[i]["执行科室"].ToString();

        //                        //Add By Tany 2010-09-26
        //                        //查询是否打印过
        //                        sSql = "select id from zy_printzxd where order_id='" + myTb.Rows[i]["order_id"].ToString() + "' and kind=0";//Modify By Tany 2010-09-26 这里定义kind=0为记账凭证
        //                        DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
        //                        //Modify By Tany 2010-09-26 形成sql数组
        //                        if (tempTab.Rows.Count > 0)
        //                        {
        //                            dr["重打状态"] = "重打";
        //                            dr["重打次数"] = tempTab.Rows.Count.ToString();
        //                        }
        //                        else
        //                        {
        //                            dr["重打状态"] = "";
        //                            dr["重打次数"] = "";
        //                        }
        //                        //不管有没有重打，都插入新纪录，记录打印次数
        //                        sql[i] = "insert into zy_printzxd(KIND,ORDER_ID,ZXD_DATE,PRINT_DATE,PRINT_USER,JGBM) values (" +
        //                                "0,'" +
        //                                myTb.Rows[i]["order_id"].ToString() + "'," +
        //                                "'" + Convert.ToDateTime(myTb.Rows[i]["发送时间"]) + "'," +
        //                                "getdate()," +
        //                                InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";

        //                        rds.Tables["tabZYJZPZ"].Rows.Add(dr);
        //                    }
        //                    else
        //                    {
        //                        _msg += " ⊙ 第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] \n";
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            TsSet tsset = new TsSet();
        //            string[] GroupbyField ={ "执行科室", "开嘱医生", "重打次数" };
        //            string[] ComputeField ={ "医嘱内容" };
        //            string[] CField ={ "count" };

        //            //Add By Tany 2010-09-26
        //            if (!myTb.Columns.Contains("重打次数"))
        //            {
        //                myTb.Columns.Add("重打次数");
        //            }

        //            for (int i = 0; i < myTb.Rows.Count; i++)
        //            {
        //                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
        //                {
        //                    //查询是否打印过
        //                    sSql = "select id from zy_printzxd where order_id='" + myTb.Rows[i]["order_id"].ToString() + "' and kind=0";//Modify By Tany 2010-09-26 这里定义kind=0为记账凭证
        //                    DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);

        //                    myTb.Rows[i]["重打次数"] = tempTab.Rows.Count;
        //                }
        //            }

        //            tsset.TsDataTable = myTb;

        //            DataTable tb = tsset.GroupTable(GroupbyField, ComputeField, CField, " 选=True");

        //            for (int j = 0; j < tb.Rows.Count; j++)
        //            {
        //                //合并
        //                decimal _zje = 0;
        //                string yznr = "";
        //                string yzid = "";
        //                int ii = 0;

        //                for (int i = 0; i < myTb.Rows.Count; i++)
        //                {
        //                    if (myTb.Rows[i]["选"].ToString().Trim() == "True"
        //                        && myTb.Rows[i]["执行科室"].ToString().Trim() == tb.Rows[j]["执行科室"].ToString().Trim()
        //                        && myTb.Rows[i]["开嘱医生"].ToString().Trim() == tb.Rows[j]["开嘱医生"].ToString().Trim()
        //                        && myTb.Rows[i]["重打次数"].ToString().Trim() == tb.Rows[j]["重打次数"].ToString().Trim())//Add By tany 2010-09-26 重打次数要一样
        //                    {
        //                        decimal _je = 0;
        //                        _je = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select dbo.FUN_ZY_GETORDERFEE_EX('" + myTb.Rows[i]["Order_ID"].ToString() + "')"), "0"));
        //                        //金额为0不显示
        //                        if (_je != 0)
        //                        {
        //                            _zje += _je;
        //                            yznr += myTb.Rows[i]["医嘱内容"].ToString().Trim() + ",";
        //                            yzid += myTb.Rows[i]["Order_ID"].ToString().Trim() + ",";

        //                            ii++;

        //                            //不管有没有重打，都插入新纪录，记录打印次数
        //                            sql[i] = "insert into zy_printzxd(KIND,ORDER_ID,ZXD_DATE,PRINT_DATE,PRINT_USER,JGBM) values (" +
        //                                    "0,'" +
        //                                    myTb.Rows[i]["order_id"].ToString() + "'," +
        //                                    "'" + Convert.ToDateTime(myTb.Rows[i]["发送时间"]) + "'," +
        //                                    "getdate()," +
        //                                    InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";
        //                        }
        //                        else
        //                        {
        //                            _msg += " ⊙ 第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] \n";
        //                        }
        //                    }
        //                }
        //                if (_zje != 0)
        //                {
        //                    dr = rds.Tables["tabZYJZPZ"].NewRow();

        //                    dr["床号"] = patientInfo1.lbBed.Text;
        //                    dr["住院号"] = patientInfo1.lbID.Text;
        //                    dr["姓名"] = patientInfo1.lbName.Text;
        //                    dr["科室"] = patientInfo1.lbDQKS.Text;
        //                    dr["性别"] = patientInfo1.lbSex.Text;
        //                    dr["医嘱ID"] = yzid;
        //                    dr["医嘱日期"] = "";
        //                    dr["医嘱内容"] = ii.ToString() + "项合并(" + yznr + ")";
        //                    dr["医嘱金额"] = _zje;

        //                    //Add By Tany 2010-08-30
        //                    dr["开嘱医生"] = tb.Rows[j]["开嘱医生"].ToString().Trim();
        //                    dr["执行护士"] = "";
        //                    dr["执行时间"] = "";
        //                    dr["执行科室"] = tb.Rows[j]["执行科室"].ToString().Trim();

        //                    if (Convert.ToInt32(tb.Rows[j]["重打次数"]) > 0)
        //                    {
        //                        dr["重打状态"] = "重打";
        //                        dr["重打次数"] = tb.Rows[j]["重打次数"].ToString();
        //                    }
        //                    else
        //                    {
        //                        dr["重打状态"] = "";
        //                        dr["重打次数"] = "";
        //                    }

        //                    rds.Tables["tabZYJZPZ"].Rows.Add(dr);
        //                }
        //            }
        //        }

        //        if (_msg.Trim() != "")
        //        {
        //            MessageBox.Show("以下医嘱费用为0，不能打印！\n\n" + _msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //        if (rds.Tables["tabZYJZPZ"].Rows.Count == 0)
        //        {
        //            return;
        //        }

        //        FrmReportView frmRptView = null;
        //        string _reportName = "";
        //        ParameterEx[] _parameters = new ParameterEx[2];


        //        _reportName = "ZYHS_住院记帐凭证.rpt";

        //        _parameters[0].Text = "打印人";
        //        _parameters[0].Value = InstanceForm.BCurrentUser.Name;
        //        _parameters[1].Text = "医院名称";
        //        _parameters[1].Value = new SystemCfg(0002).Config;

        //        frmRptView = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);

        //        //Add By Tany 2010-09-26
        //        frmRptView._sqlStr = sql;

        //        frmRptView.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void bt预算_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal _orderfee = 0;
            int GroupID = -999;
            int iMNGType = 0;
            int iSelectRows = 0;
            DataTable myTb = (DataTable)myDataGrid1.DataSource;
            DateTime ExecDate = Convert.ToDateTime(Convertor.IsNull(((Button)sender).Tag, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString()));

            #region 有效性判断
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["选"].ToString() == "True")
                {
                    iSelectRows += 1;
                }
            }

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "对不起，没有选择医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            iMNGType = GetMNGType();

            progressBar1.Maximum = myTb.Rows.Count;
            progressBar1.Value = 0;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                //如果是选择发送
                if (myTb.Rows[i]["选"].ToString() == "False")
                {
                    continue;
                }

                //如果组号与上一条医嘱相同，则不执行
                if (GroupID == Convert.ToInt32(myTb.Rows[i]["Group_ID"]))
                {
                    continue;
                }

                GroupID = Convert.ToInt32(myTb.Rows[i]["Group_ID"]);
                int iMNGType2 = iMNGType == 1 ? 5 : iMNGType;

                _orderfee += myFunc.GetOrderFee(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, iMNGType, GroupID, ExecDate, ExecDate);

                progressBar1.Value += 1;
            }

            progressBar1.Value = 0;

            Button bt = (Button)sender;

            if (bt.Name == "bt预算")
            {
                MessageBox.Show("本次医嘱费用预算为：" + _orderfee.ToString() + " 元");
            }
            else
            {
                orderfee = _orderfee;
            }
        }

        private void butorderprint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确定要在医嘱打印中体现所勾选的医嘱码？\r\n\r\n注意：未勾选的医嘱将取消在医嘱打印中可见！！！", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (Convert.ToInt16(myTb.Rows[i]["选"]) == 1)
                {
                    string ssql = "update zy_orderrecord set ssmz_print=" + Convert.ToInt16(myTb.Rows[i]["选"]) + " where order_id='" + new Guid(myTb.Rows[i]["order_id"].ToString()) + "'";
                    InstanceForm.BDatabase.DoCommand(ssql);
                }
                else
                {
                    string ssql = "select * from zy_tmporderprt(nolock) where order_id='" + new Guid(myTb.Rows[i]["order_id"].ToString()) + "'";
                    DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tb.Rows.Count == 0)
                    {
                        ssql = "update zy_orderrecord set ssmz_print=" + Convert.ToInt16(myTb.Rows[i]["选"]) + " where order_id='" + new Guid(myTb.Rows[i]["order_id"].ToString()) + "'";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(myTb.Rows[i]["医嘱内容"]) + "不能取消打印，因为它已被医嘱打印程序收录");
                    }
                }
            }

            MessageBox.Show("操作成功");
        }

        private bool myDataGrid1_myKeyDown(ref Message msg, Keys keyData)
        {
            long keyInt = Convert.ToInt32(keyData);
            if (keyInt == 36)
            {
                myDataGrid1.ScollRow(0);
            }
            else if (keyInt == 35)
            {
                DataTable tb = (DataTable)myDataGrid1.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    myDataGrid1.ScollRow(tb.Rows.Count - 1);
                }
            }
            return true;
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Frmserch fserch = new Frmserch();
            // Point wz = Cursor.Position;
            //Point ScreenP = this.myDataGrid2.PointToScreen(wz);
            // fserch.Location = ScreenP;
            // fserch.ShowDialog();
            string iptid = Inpatient.GetInpatientID().ToString();// GetInpatientNO();
            if (iptid == "" || iptid == Guid.Empty.ToString())
            {
                return;
            }
            int flag = 0;
            DataTable tb = (DataTable)myDataGrid2.DataSource;
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (tb.Rows[i]["inpatient_id"].ToString().Trim() == iptid)
                    {
                        myDataGrid2.UnSelect(myDataGrid2.CurrentCell.RowNumber);
                        DataGridCell cell = new DataGridCell(i, 0);
                        myDataGrid2.CurrentCell = cell;
                        flag = 1;
                        return;
                    }
                }
            }

            if (flag == 0)
            {
                //全部查询模块
                if (isCX == true)
                {
                    string sql1 = "";
                    int _outMonth = Convert.ToInt32((new SystemCfg(7023)).Config) * -1;
                    DateTime _outDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddMonths(_outMonth);
                    sql1 = "select WARD_ID,ward_name,flag,inpatient_id" +
                            "   FROM vi_zy_vInpatient_All " +
                            "  WHERE  ( out_date is null or " +
                            "   out_Date>= '" + _outDate.Date + "')  and inpatient_id='" + iptid + "'";

                    //sql1 = "  select WARD_ID,ward_name,flag,inpatient_id from  VI_ZY_VINPATIENT_ALL  where inpatient_id='" + iptid + "'";
                    DataTable tbtb = FrmMdiMain.Database.GetDataTable(sql1);
                    if (tbtb.Rows.Count > 0)
                    {
                        if (tbtb.Rows[0]["flag"].ToString() == "3" || tbtb.Rows[0]["flag"].ToString() == "4")
                        {
                            rbIn.Checked = true;
                            rb_Click(null, null);
                        }
                        if (tbtb.Rows[0]["flag"].ToString() == "5")
                        {
                            rbTempOut.Checked = true;
                            rb_Click(null, null);
                        }
                        if (tbtb.Rows[0]["flag"].ToString() == "6" || tbtb.Rows[0]["flag"].ToString() == "2")
                        {
                            rbOut.Checked = true;
                            rb_Click(null, null);
                        }
                        cmbWard.SelectedValue = tbtb.Rows[0]["WARD_ID"].ToString();
                        DataTable tb1 = (DataTable)myDataGrid2.DataSource;
                        for (int i = 0; i < tb1.Rows.Count; i++)
                        {
                            if (tb1.Rows[i]["inpatient_id"].ToString().Trim() == iptid)
                            {
                                myDataGrid2.UnSelect(myDataGrid2.CurrentCell.RowNumber);
                                DataGridCell cell = new DataGridCell(i, 0);
                                myDataGrid2.CurrentCell = cell;
                                flag = 1;
                                return;
                            }
                        }
                        MessageBox.Show("没有找到相应的结果！！", "提示信息"); return;
                    }
                    else
                    {
                        MessageBox.Show("没有找到相应的结果！！", "提示信息"); return;
                    }

                }
            }
            else
                MessageBox.Show("没有找到相应的结果！！", "提示信息");
        }

        private void btnSqyzdy_Click(object sender, EventArgs e)
        {
            //add by zouchihua 2012-3-27 术前执行单打印
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            if (tb == null || tb.Rows.Count == 0)
                return;
            DataTable temptb = new DataTable();
            temptb.Columns.Add("医嘱内容", typeof(System.String));
            temptb.Columns.Add("规格", typeof(System.String));
            temptb.Columns.Add("组线", typeof(System.String));
            temptb.Columns.Add("执行时间", typeof(System.String));
            temptb.Columns.Add("转抄护士", typeof(System.String));
            temptb.Columns.Add("group_id", typeof(System.String));
            temptb.Columns.Add("执行人", typeof(System.String));
            int zflag = 0;
            int zjs = 0;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["选"].ToString().Trim() == "True")
                {
                    DataRow row = temptb.NewRow();
                    //row["医嘱内容"] = tb.Rows[i]["医嘱内容"].ToString().Substring(0, tb.Rows[i]["医嘱内容"].ToString().LastIndexOf(GetNumUnit(tb, i)) + GetNumUnit(tb, i).Length);
                    DataTable ordertb = FrmMdiMain.Database.GetDataTable("select * from ZY_ORDERRECORD where ORDER_ID='" + tb.Rows[i]["order_id"] + "'");
                    if (ordertb != null && ordertb.Rows.Count > 0)
                    {
                        row["医嘱内容"] = ordertb.Rows[0]["ORDER_CONTEXT"].ToString().Trim();
                        for (int x = System.Text.Encoding.Default.GetByteCount(ordertb.Rows[0]["ORDER_CONTEXT"].ToString().Trim()); x < 40; x++)
                        {
                            row["医嘱内容"] += " ";
                        }
                        row["医嘱内容"] += GetNumUnit(tb, i);
                    }
                    row["规格"] = tb.Rows[i]["ORDER_SPEC"];
                    if (i < tb.Rows.Count - 1 && tb.Rows[i]["group_id"].ToString() == tb.Rows[i + 1]["group_id"].ToString())
                    {
                        if (zflag == 0)
                        {
                            row["组线"] = "┓";
                            zflag = 1;
                        }
                        else
                            if (zflag == 1 && tb.Rows[i]["group_id"].ToString() == tb.Rows[i - 1]["group_id"].ToString())
                            {
                                row["组线"] = "┃";
                            }
                    }
                    else
                        if (zflag == 1 && tb.Rows[i]["group_id"].ToString() == tb.Rows[i - 1]["group_id"].ToString())
                        {
                            row["组线"] = "┛";
                            zflag = 0;
                            zjs = 0;
                        }
                        else
                        {
                            zflag = 0;
                            zjs = 0;
                        }
                    row["group_id"] = tb.Rows[i]["group_id"];
                    row["执行时间"] = tb.Rows[i]["执行时间"];
                    row["转抄护士"] = tb.Rows[i]["开嘱转抄"];
                    row["执行人"] = tb.Rows[i]["执行人"];
                    temptb.Rows.Add(row);
                }
            }
            string _reportName = "HS_术前执行单.rpt";
            ParameterEx[] _parameters = new ParameterEx[5];
            _parameters[0].Text = "医院名称";
            _parameters[0].Value = new SystemCfg(0002).Config;
            _parameters[1].Text = "病区";
            _parameters[1].Value = InstanceForm.BCurrentDept.WardName;
            _parameters[2].Text = "打印者";
            _parameters[2].Value = InstanceForm.BCurrentUser.Name;
            _parameters[3].Text = "姓名";
            _parameters[3].Value = this.patientInfo1.lbName.Text;
            _parameters[4].Text = "床号";
            _parameters[4].Value = this.patientInfo1.lbBed.Text;
            FrmReportView frmRptView = new FrmReportView(temptb, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);
            //frmRptView._sqlStr = sql;
            frmRptView.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = 0;
            int SelCount = 0;

            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        if (Convert.ToInt32(myTb.Rows[i]["status_flag"]) != 5)
                        {
                            MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 还没有发送，请先发送该条（组）医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int j = 0; j < myTb.Rows.Count; j++)
                            {
                                if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                {
                                    myTb.Rows[j]["选"] = false;
                                }
                            }
                            return;
                        }
                        //还没点击执行时间
                        if (myTb.Rows[i]["执行人"].ToString().Trim() == "")
                        {
                            MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 还没有执行人，请先点击【执行时间】按钮！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int j = 0; j < myTb.Rows.Count; j++)
                            {
                                if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                {
                                    myTb.Rows[j]["选"] = false;
                                }
                            }
                            return;
                        }

                        nrow = i;
                        SelCount++;
                    }
                }
            }
            if (SelCount == 0)
            {
                MessageBox.Show("没有选择医嘱，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("是否确定进行双签名？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            DateTime _execTime = new DateTime();
            long _employeeId = 0;

            frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
            frmET.ShowDialog();
            if (frmET.DialogResult == DialogResult.OK)
            {
                _execTime = frmET._execTime;
                _employeeId = frmET._employeeId;
            }
            else
            {
                return;
            }

            //开始更新数据
            Cursor.Current = PubStaticFun.WaitCursor();

            string sSql = "";
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        if (myTb.Rows[i]["REALEXEUSER"].ToString().Trim() == _employeeId.ToString().Trim())
                        {
                            MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 的两个签名不能相同！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            for (int j = 0; j < myTb.Rows.Count; j++)
                            {
                                if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                {
                                    myTb.Rows[j]["选"] = false;
                                }
                            }
                            continue;
                        }
                        //更新医嘱执行表
                        sSql = "update zy_orderexec set  realexeuserdb=" + _employeeId +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);
                        //更新医嘱打印表
                        sSql = "update zy_tmporderprt set  exec_Duser=" + _employeeId +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);

                        //写日志 Add By Tany 2005-01-12
                        SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "更新执行时间", "将病人" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + " Group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + " 的医嘱执行时间更新为 " + " " + _employeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                        _systemLog.Save();
                        _systemLog = null;
                    }
                }
            }

            //刷新界面
            this.tabControl1_SelectedIndexChanged(sender, e);

            Cursor.Current = Cursors.Default;

            MessageBox.Show("双签名成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 取消双签名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int nrow = 0;
            int SelCount = 0;
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
            frmET.ShowDialog();
            if (frmET.DialogResult == DialogResult.OK)
            {
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["选"].ToString().Trim() == "True" && myTb.Rows[i]["REALEXEUSERDb"].ToString().Trim() != frmET._employeeId.ToString().Trim())
                    {
                        MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 双签名不是你签的，您无权取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int j = 0; j < myTb.Rows.Count; j++)
                        {
                            if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                            {
                                myTb.Rows[j]["选"] = false;
                            }
                        }
                        return;
                    }
                }
            }
            else
            {
                return;
            }

            //开始更新数据
            Cursor.Current = PubStaticFun.WaitCursor();
            if (MessageBox.Show("是否确定取消双签名？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            string sSql = "";
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {

                        //更新医嘱执行表
                        sSql = "update zy_orderexec set  realexeuserdb=-1" +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);
                        //更新医嘱打印表
                        sSql = "update zy_tmporderprt set  exec_Duser=-1" +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);

                        //写日志 Add By Tany 2005-01-12
                        SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "更新执行时间", "将病人" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + " Group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + " 的医嘱双签名更新为 " + " -1", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                        _systemLog.Save();
                        _systemLog = null;
                    }
                }
            }

            //刷新界面
            this.tabControl1_SelectedIndexChanged(sender, e);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("取消双签名成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnTszlZcQm_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = 0;
            int SelCount = 0;

            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        SelCount++;
                    }
                }
            }
            if (SelCount == 0)
            {
                MessageBox.Show("没有选择医嘱，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((sender as Button).Text.Contains("转抄签名"))
            {
                if (MessageBox.Show("是否确定进行转抄签名？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("是否确定进行核对签名？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }

            DateTime _execTime = new DateTime();
            long _employeeId = 0;

            frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
            frmET.ShowDialog();
            if (frmET.DialogResult == DialogResult.OK)
            {
                _execTime = frmET._execTime;
                _employeeId = frmET._employeeId;
            }
            else
            {
                return;
            }

            //开始更新数据
            Cursor.Current = PubStaticFun.WaitCursor();

            string sSql = "";
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {
                        if ((sender as Button).Text.Contains("转抄签名"))
                        {
                            //if (myTb.Rows[i]["AUDITING_USER"].ToString().Trim() != "" && myTb.Rows[i]["AUDITING_USER"].ToString().Trim() != "-1")
                            //{
                            //    MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 转抄签名已经存在，您不能再签！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    for (int j = 0; j < myTb.Rows.Count; j++)
                            //    {
                            //        if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                            //        {
                            //            myTb.Rows[j]["选"] = false;
                            //        }
                            //    }
                            //    return;
                            //}
                            //存在核对人
                            if (myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() != "" && myTb.Rows[i]["AUDITING_USER"].ToString().Trim() != "-1")
                            {
                                if (myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() == _employeeId.ToString().Trim())
                                {
                                    MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 转抄和核对不能为同一个人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            //更新医嘱执行表
                            sSql = "update ZY_ORDERRECORD set  AUDITING_USER=" + _employeeId + ", AUDITING_DATE='" + _execTime + "' " +
                                " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                            InstanceForm.BDatabase.DoCommand(sSql);
                            //更新医嘱打印表
                            sSql = "update zy_tmporderprt set  AUDITING_USER=" + _employeeId + " " +
                                " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                            InstanceForm.BDatabase.DoCommand(sSql);

                            //写日志 Add By Tany 2005-01-12
                            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "转抄签名", "将病人" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + " Group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + " 的转抄人更新为 " + " " + _employeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                            _systemLog.Save();
                            _systemLog = null;
                        }
                        else
                        {
                            #region  核对签名
                            //if(
                            //    (myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() != "" && myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() != "-1")         
                            //)
                            //{
                            //    MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 核对签名已经存在，您不能再签！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    for (int j = 0; j < myTb.Rows.Count; j++)
                            //    {
                            //        if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                            //        {
                            //            myTb.Rows[j]["选"] = false;
                            //        }
                            //    }
                            //    return;
                            //}
                            if (myTb.Rows[i]["AUDITING_USER"].ToString().Trim() == "" || myTb.Rows[i]["AUDITING_USER"].ToString().Trim() == "-1")
                            {
                                MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 没有转抄签名，请您先转抄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //by add yaokx 2014-06-10 平台号5014转抄和核对签名可以由同一人执行，请增加判断，不允许同一人签名，否则科室不能打印医嘱单，会报错。
                            if (myTb.Rows[i]["AUDITING_USER"].ToString().Trim() == myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() || myTb.Rows[i]["AUDITING_USER"].ToString().Trim() == _employeeId.ToString())
                            {
                                MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 转抄和核对不能为同一个人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //更新医嘱执行表
                            sSql = "update ZY_ORDERRECORD set  AUDITING_USER1=" + _employeeId + ", AUDITING_DATE1='" + _execTime + "' " +
                                " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                            InstanceForm.BDatabase.DoCommand(sSql);
                            //更新医嘱打印表
                            sSql = "update zy_tmporderprt set  AUDITING_USER1=" + _employeeId + " " +
                                " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                                " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                            InstanceForm.BDatabase.DoCommand(sSql);

                            //写日志 Add By Tany 2005-01-12
                            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "核对签名", "将病人" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + " Group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + " 的转抄人更新为 " + " " + _employeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                            _systemLog.Save();
                            _systemLog = null;
                            #endregion
                        }
                    }
                }
            }

            //刷新界面
            this.tabControl1_SelectedIndexChanged(sender, e);

            Cursor.Current = Cursors.Default;

            MessageBox.Show((sender as Button).Text.Contains("转抄签名") ? "转抄签名成功！" : "核对签名成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 删除执行时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int nrow = 0;
            int SelCount = 0;
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
            frmET.ShowDialog();
            if (frmET.DialogResult == DialogResult.OK)
            {
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["选"].ToString().Trim() == "True" && myTb.Rows[i]["REALEXEUSERDb"].ToString().Trim() != "" && myTb.Rows[i]["REALEXEUSERDb"].ToString().Trim() != "-1")
                    {
                        MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 已经双签名，您无权取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int j = 0; j < myTb.Rows.Count; j++)
                        {
                            if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                            {
                                myTb.Rows[j]["选"] = false;
                            }
                        }
                        return;
                    }
                    if (myTb.Rows[i]["选"].ToString().Trim() == "True" && myTb.Rows[i]["REALEXEUSER"].ToString().Trim() != frmET._employeeId.ToString().Trim())
                    {
                        MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 执行时间不是你签的，您无权取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int j = 0; j < myTb.Rows.Count; j++)
                        {
                            if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                            {
                                myTb.Rows[j]["选"] = false;
                            }
                        }
                        return;
                    }

                }
            }
            else
            {
                return;
            }

            //开始更新数据
            Cursor.Current = PubStaticFun.WaitCursor();
            if (MessageBox.Show("是否确定取消执行时间？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            string sSql = "";
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                {
                    if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                    {

                        //更新医嘱执行表
                        sSql = "update zy_orderexec set  realexecdate=null,REALEXEUSER=-1" +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);
                        //更新医嘱打印表
                        sSql = "update zy_tmporderprt set  execdate=null,EXEUSER=null" +
                            " where order_id in (select order_id from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                            " and baby_id=" + ClassStatic.Current_BabyID + " and group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + ")";
                        InstanceForm.BDatabase.DoCommand(sSql);

                        //写日志 Add By Tany 2005-01-12
                        SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "更新执行时间", "将病人" + ClassStatic.Current_BinID + " " + ClassStatic.Current_BabyID + " Group_id=" + myTb.Rows[i]["Group_id"].ToString().Trim() + " 的医嘱签名更新为 " + " null", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                        _systemLog.Save();
                        _systemLog = null;
                    }
                }
            }

            //刷新界面
            this.tabControl1_SelectedIndexChanged(sender, e);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("取消执行时间成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 单个签名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            string str_orderid = "(";
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                {
                    str_orderid += "'" + myTb.Rows[i]["order_id"].ToString().Trim() + "',";
                }
            }
            if (str_orderid != "(")
                str_orderid = str_orderid.Substring(0, str_orderid.Length - 1) + ")";
            else
                return;
            FrmDgqm fqm = new FrmDgqm();
            fqm.str_orderid = str_orderid;
            fqm.ShowDialog();
            if (fqm.DialogResult == DialogResult.OK)
            {
                //刷新界面
                this.tabControl1_SelectedIndexChanged(sender, e);

            }
        }
        private void che_yz_CheckedChanged(object sender, EventArgs e)
        {
            txt_yz.Enabled = txt_yz.Enable = che_yz.Checked;
            this.ShowData();
        }

        private void che_date_CheckedChanged(object sender, EventArgs e)
        {
            cmb_date.Enabled = che_date.Checked;
            this.ShowData();
        }

        private void cmb_date_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowData();
        }

        private void txt_yz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ShowData();
            }
        }

        //Add By Tany 2015-02-02 打印中药处方
        private void menu_printzycf_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (GetMNGType() != 0 && GetMNGType() != 1)
            {
                MessageBox.Show("只能打印中草药医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int nrow = 0;
            int SelCount = 0;

            try
            {
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                    {
                        if (i == 0 || (i != 0 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i - 1]["Group_id"].ToString().Trim()))
                        {
                            //只能打印4,5,6,8,9类型
                            if (Convert.ToInt32(myTb.Rows[i]["ntype"]) != 3)
                            {
                                MessageBox.Show("第 " + (i + 1) + " 行医嘱 [" + myTb.Rows[i]["医嘱内容"].ToString().Trim() + "] 不能打印，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                for (int j = 0; j < myTb.Rows.Count; j++)
                                {
                                    if (myTb.Rows[j]["Group_id"].ToString().Trim() == myTb.Rows[i]["Group_id"].ToString().Trim())
                                    {
                                        myTb.Rows[j]["选"] = false;
                                    }
                                }
                                return;
                            }
                            nrow = i;
                            SelCount++;
                        }
                    }
                }

                if (SelCount == 0)
                {
                    MessageBox.Show("没有选择医嘱，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //////////////
                string groupid = "";
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["选"].ToString().Trim() == "True")
                    {
                        if (groupid == myTb.Rows[i]["group_id"].ToString().Trim())
                        {
                            continue;
                        }
                        else
                        {
                            groupid = myTb.Rows[i]["group_id"].ToString().Trim();
                        }
                        string mngtype = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select mngtype from zy_orderrecord where inpatient_id='" + ClassStatic.Current_BinID + "' and group_id=" + groupid), GetMNGType().ToString());
                        ts_yf_zyfy.PubClass.PrintCf(ClassStatic.Current_BinID.ToString(), mngtype, groupid, InstanceForm.BDatabase);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示信息");
            }
        }

        private void DoInitCtr(string[] headtext, string[] mappingname, string[] serchFileds, int[] cols, DataTable dtSrc)
        {
            ucShowCard1.Init(headtext, mappingname, serchFileds, cols, dtSrc);
        }

        private void ucShowCard1_MyDelEvent()
        {
            ucShowCard1.Value = ucShowCard1.Row["姓名"].ToString();
            ucShowCard1.Key = ucShowCard1.Row["INPATIENT_ID"].ToString();

            DataTable dt = myDataGrid2.DataSource as DataTable;
            if (dt == null || dt.Rows.Count <= 0)
                return;

            dt.DefaultView.RowFilter = "INPATIENT_ID='" + ucShowCard1.Key + "'";

            myDataGrid2_CurrentCellChanged(null, null);
        }

        private void chkWardOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAllSMYz.Checked)
            {
                chkShowAllSMYz.CheckedChanged -= chkShowAllSMYz_CheckedChanged;
                chkShowAllSMYz.Checked = !chkWardOrder.Checked;
                chkShowAllSMYz.CheckedChanged += chkShowAllSMYz_CheckedChanged;
            }
            chkShowAllSMYz.Enabled = !chkWardOrder.Checked;
            ShowData();
        }

        private void chkShowAllSMYz_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAllSMYz.Checked)
            {
                chkWardOrder.CheckedChanged -= chkWardOrder_CheckedChanged;
                chkWardOrder.Checked = false;
                chkWardOrder.CheckedChanged += chkWardOrder_CheckedChanged;
            }
            chkWardOrder.Enabled = !chkShowAllSMYz.Checked;
            ShowData();
        }

        /// <summary>
        /// pivas 是否审方
        /// </summary>
        private bool isPvsChkExe(string inpatid, string babyid, string groupid)
        {
            try
            {
                string sSql = string.Format(@"select count(1) as Num from ZY_ORDERRECORD t 
                                        where t.INPATIENT_ID='{0}' and BABY_ID='{1}' and t.GROUP_ID='{2}'  and t.DELETE_BIT=0 and t.STATUS_FLAG=2 and t.is_PvsChk=0
	                                        and exists(select 1 from VI_pivas_Orderusage f where t.ORDER_USAGE=f.name)  ",
                                                                                                                         inpatid, babyid, groupid);


                string str = InstanceForm.BDatabase.GetDataResult(sSql).ToString().Trim();
                int iNum = int.Parse(str);

                //没有 需要却未审方 的医嘱
                if (iNum == 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void btSsmzwc_Click(object sender, EventArgs e)
        {
            string ssmz = ssmzType == 0 ? "手术" : "麻醉";

            if (MessageBox.Show(this, "点击完成后程序将不会更新" + ssmz + "相关信息，仅将该" + ssmz + "标记为完成状态！！！\r\n\r\n您确认吗?", "" + ssmz + "完成", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    string ssql = "";
                    string ssfj = "";
                    string sNo = "";
                    //Modify By Tany 2015-05-11 查找病人有几个手术
                    ssql = "select SNO,APDJRQ 登记时间,YSSS 手术,b.NAME 麻醉,SSTC from SS_ARRRECORD a left join SS_ANESTHESIACODE b on a.YSMZ=b.ID where BDELETE=0 and INPATIENT_ID='" + ClassStatic.Current_BinID + "'";
                    if (ssmzType == 0)
                    {
                        ssql += " and wcbj=0";
                    }
                    else
                    {
                        ssql += " and mzwcbj=0";
                    }
                    //Modify By tany 2015-05-14 再加上安排信息
                    ssql += " union all ";
                    ssql += "select SNO,YSSSRQ 拟施时间,YSSS 手术,b.NAME 麻醉,null SSTC from SS_APPRECORD a left join SS_ANESTHESIACODE b on a.YSMZ=b.ID where BDELETE=0 and (shbj = 1 or jzss=1) and apbj = 1 and INPATIENT_ID='" + ClassStatic.Current_BinID + "'";
                    DataTable ssmzTb = FrmMdiMain.Database.GetDataTable(ssql);
                    if (ssmzTb == null || ssmzTb.Rows.Count == 0)
                    {
                        MessageBox.Show("没有找到未完成的" + ssmz + "，无需点完成！", "提示");
                        return;
                    }
                    //else if (ssmzTb.Rows.Count == 1)
                    //{
                    //    ssfj = ssmzTb.Rows[0]["sstc"].ToString().Trim();
                    //    sNo = ssmzTb.Rows[0]["sno"].ToString().Trim();
                    //}
                    else
                    {
                        Ts_zygl_ybgl.FrmDataGridView frmDv = new Ts_zygl_ybgl.FrmDataGridView();
                        frmDv.dgv.DataSource = ssmzTb;
                        frmDv.dgv.MultiSelect = false;
                        frmDv.ShowDialog();
                        if (frmDv.DialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (frmDv.dgv.SelectedRows.Count == 0)
                            {
                                MessageBox.Show("未选择数据！");
                                return;
                            }
                            else
                            {
                                ssfj = Convertor.IsNull(ssmzTb.Rows[frmDv.dgv.SelectedRows[0].Index]["sstc"], "");
                                sNo = Convertor.IsNull(ssmzTb.Rows[frmDv.dgv.SelectedRows[0].Index]["sno"], "");
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    //Modify By Tany 2015-04-08 手术和麻醉完成的内容不一样
                    FrmMdiMain.Database.BeginTransaction();
                    if (ssmzType == 0)
                    {
                        //更新房间占用标志
                        if (IsGuid(ssfj))
                        {
                            ssql = "update ss_roomtc set flag=0 where id='" + ssfj + "'";
                            FrmMdiMain.Database.DoCommand(ssql);
                        }
                        //增加更新安排标志 Modify By Tany 2015-04-20
                        ssql = "update ss_apprecord set apbj=1 where sno='" + sNo + "'";
                        FrmMdiMain.Database.DoCommand(ssql);
                        //更新安排表
                        ssql = "update ss_arrrecord set " +
                            " wcbj = 1,wcsj = getdate()" +
                            " where sno='" + sNo + "'";
                        FrmMdiMain.Database.DoCommand(ssql);
                        //插入日志
                        ssql = "insert into ss_log(id,sno,inpatient_name,sbz,djrq,czy)values('" + TrasenClasses.GeneralClasses.PubStaticFun.NewGuid() + "','" + sNo + "','','手术完成',getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ")";
                        FrmMdiMain.Database.DoCommand(ssql);
                    }
                    else if (ssmzType == 1)
                    {
                        //更新安排表
                        ssql = "update ss_arrrecord set " +
                            " mzwcbj = 1,mzwcsj = getdate()," +
                            " mzwcczy=" + FrmMdiMain.CurrentUser.EmployeeId +
                            " where sno='" + sNo + "'";
                        FrmMdiMain.Database.DoCommand(ssql);
                    }
                    FrmMdiMain.Database.CommitTransaction();
                    MessageBox.Show(ssmz + "完成！");
                }
                catch (System.Exception err)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    MessageBox.Show(err.Message + err.Source);
                }
            }
        }

        //Add By Tany 2015-04-20
        /// <summary>
        /// 是否GUID型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsGuid(string str)
        {
            bool isGuid = false;
            try
            {
                Guid gstr = new Guid(str);
                return true;
            }
            catch
            {
                isGuid = false;
            }
            return isGuid;
        }

        /// <summary>
        /// 调用：医嘱发送、护士执行
        /// </summary>
        /// <param name="inpatient_id"></param>
        /// <param name="inpNo"></param>
        /// <returns></returns> 
        private bool DoVaildYbOrder(string inpatient_id, string inpNo)
        {
            //try
            //{
            //    decimal sum = 0M;

            //    //明细Info
            //    DataTable dtDetail = GetDetailBill(dtOrder, out sum);

            //    //主单info
            //    DataTable dtMain = ClsAuditCheck.RetAfSetMainInfo(inpatient_id, inpNo, sum, FrmMdiMain.Database);

            //    BmiAuditClass clsAudit = new BmiAuditClass();
            //    string strRet = clsAudit.ClaimAudit4Hospital_Y(dtMain, dtDetail);

            //    if (!strRet.Equals("1"))
            //    {
            //        //throw new Exception(clsAudit.l_error_message);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("智审出错：医嘱明细 \r\t " + ex.Message);
            //    return false;
            //}
            return true;
        }

        //add by jchl
        private void DoCntSsMzFee(DataTable dtDetials, out decimal sdVal)
        {
            //计算明细金额
            sdVal = 0M;

            DataRow[] drGrps = dtDetials.Select("HOITEM_ID<>-1");
            if (drGrps.Length <= 0)
                return;

            for (int i = 0; i < drGrps.Length; i++)
            {
                DataRow drDet = drGrps[i];

                string xmly = drDet["xmly"].ToString().Trim();
                string xmid = drDet["HOITEM_ID"].ToString().Trim();

                DataTable dtItem = GetItemDetails(xmid, xmly);
                for (int j = 0; j < dtItem.Rows.Count; j++)
                {
                    DataRow row = dtItem.Rows[j];

                    if (row["XMLY"].ToString().Trim().Equals("1"))
                    {
                        //if (drDet["MNGTYPE"].ToString().Trim().Equals("1"))
                        //{
                        //    //临嘱需要上传 总单位、总量
                        //    DataTable dtPrc = HisFunctions.SP_FUN_DW_NUM(drDet["dwlx"].ToString(), decimal.Parse(drDet["总量"].ToString()), row["xmid"].ToString(), drDet["执行科室"].ToString(), FrmMdiMain.Database);
                        //    sdVal = decimal.Parse(dtPrc.Rows[0]["sdvalue"].ToString().Trim());//单次用量的费用
                        //}
                        //else
                        //{
                        //    //其他传单位类型和剂量
                        //    DataTable dtPrc = HisFunctions.SP_FUN_DW_NUM(drDet["dwlx"].ToString(), decimal.Parse(drDet["剂量"].ToString()), row["xmid"].ToString(), drDet["执行科室"].ToString(), FrmMdiMain.Database);
                        //    sdVal = decimal.Parse(dtPrc.Rows[0]["sdvalue"].ToString().Trim());//单次用量的费用
                        //}

                        //手麻只有临时医嘱、和临时账单
                        //临嘱需要上传 总单位、总量
                        DataTable dtPrc = HisFunctions.SP_FUN_DW_NUM(drDet["dwlx"].ToString(), decimal.Parse(drDet["zsl"].ToString()), row["xmid"].ToString(), drDet["EXEC_DEPT"].ToString(), FrmMdiMain.Database);
                        sdVal += decimal.Parse(dtPrc.Rows[0]["sdvalue"].ToString().Trim());//单次用量的费用
                    }
                    else
                    {
                        //项目金额
                        string sql = string.Format(@"select * from JC_HSITEM where ITEM_ID='{0}' ", row["xmid"].ToString());
                        DataTable dtPrc = FrmMdiMain.Database.GetDataTable(sql);
                        decimal iNum = Convert.ToDecimal(drDet["num"].ToString());

                        sdVal += decimal.Parse(dtPrc.Rows[0]["RETAIL_PRICE"].ToString()) * iNum;//单次用量的费用
                    }
                }
            }
        }

        private DataTable GetItemDetails(string xmid, string xmly)
        {
            string sql = string.Format(@"select xmid, xmly
                                        from
                                        (
                                        select 2 as xmly,SUBITEM_ID as xmid from JC_HOI_HDI t 
                                        inner join JC_TC a on t.TCID=a.ITEM_ID and TC_FLAG=1 and a.DELETE_BIT=0 
                                        inner join JC_TC_MX b on a.ITEM_ID=b.MAINITEM_ID 
                                        where t.HOITEM_ID='{0}' and '{1}'='2'
                                        union all
                                        select 2 as xmly,ITEM_ID as xmid from JC_HOI_HDI t 
                                        inner join JC_HSITEM a on t.HDITEM_ID=a.ITEM_ID and TC_FLAG=0 and a.DELETE_BIT=0
                                        where t.HOITEM_ID='{0}' and '{1}'='2' 
                                        )a
                                        union all
                                        select '{0}' as xmid,'1' as xmly where '{1}'='1'", xmid, xmly);

            DataTable itemDetails = InstanceForm.BDatabase.GetDataTable(sql);
            return itemDetails;
        }


        private void bt执行时间_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    bt执行时间.EnabledChanged -= bt执行时间_EnabledChanged;
            //    bt执行时间.Enabled = false;
            //    bt执行时间.EnabledChanged += bt执行时间_EnabledChanged;
            //}
        }

        private void bt取消停医嘱转抄_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    bt取消停医嘱转抄.EnabledChanged -= bt取消停医嘱转抄_EnabledChanged;
            //    bt取消停医嘱转抄.Enabled = false;
            //    bt取消停医嘱转抄.EnabledChanged += bt取消停医嘱转抄_EnabledChanged;
            //}
        }

        private void bt取消开医嘱转抄_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    bt取消开医嘱转抄.EnabledChanged -= bt取消开医嘱转抄_EnabledChanged;
            //    bt取消开医嘱转抄.Enabled = false;
            //    bt取消开医嘱转抄.EnabledChanged += bt取消开医嘱转抄_EnabledChanged;
            //}
        }

        private void bt取消停医嘱核对_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    bt取消停医嘱核对.EnabledChanged -= bt取消停医嘱核对_EnabledChanged;
            //    bt取消停医嘱核对.Enabled = false;
            //    bt取消停医嘱核对.EnabledChanged += bt取消停医嘱核对_EnabledChanged;
            //}
        }

        private void BtnTszlZcQm_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    BtnTszlZcQm.EnabledChanged -= BtnTszlZcQm_EnabledChanged;
            //    BtnTszlZcQm.Enabled = false;
            //    BtnTszlZcQm.EnabledChanged += BtnTszlZcQm_EnabledChanged;
            //}
        }

        private void btnDelete_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    btnDelete.EnabledChanged -= btnDelete_EnabledChanged;
            //    btnDelete.Enabled = false;
            //    btnDelete.EnabledChanged += btnDelete_EnabledChanged;
            //}
        }

        private void bt未执行_EnabledChanged(object sender, EventArgs e)
        {
            //add pengyang 2015-8-7
            //if (chkSsyz.Checked)
            //{
            //    bt未执行.EnabledChanged -= bt未执行_EnabledChanged;
            //    bt未执行.Enabled = false;
            //    bt未执行.EnabledChanged += bt未执行_EnabledChanged;
            //}
        }

        private void chkGwyp_CheckedChanged(object sender, EventArgs e)
        {
            chkShowAllSMYz.Visible = chkSsyz.Visible = !chkGwyp.Checked;

            if (chkGwyp.Checked)
            {
                chkWardOrder.Checked = chkShowAllSMYz.Checked = chkSsyz.Checked = !chkGwyp.Checked;
            }

            if (ssmzType == 1)
            {
                chkWardOrder.Visible = false;
            }

            ShowData();
        }

        void menuSmCf_Print(object sender, EventArgs e)
        {

            try
            {
                if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
                {
                    MessageBox.Show("没有找到病人信息，请重新确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //如果病人控件信息没有，则激活一下
                if (patientInfo1.lbID.Text.Trim() == "")
                {
                    this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);
                }

                int iSel = GetMNGType();

                DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb == null) return;
                if (myTb.Rows.Count == 0) return;

                int nrow = 0;
                int SelCount = 0;

                try
                {
                    rds.Tables["dtSsMzCf"].Clear();
                    string _msg = "";

                    //Add By Tany 2010-09-26 打印次数用变量
                    string sSql = "";
                    string[] sql = new string[myTb.Rows.Count];

                    FrmReportView frmRptView = null;
                    string _reportName = "";
                    ParameterEx[] _parameters = new ParameterEx[9];

                    string cfType = (sender as MenuItem).Name;
                    int iCfType = 0;
                    if (cfType.Equals("mjycf"))
                    {
                        _reportName = "MZ_麻精一处方清单(处方格式).rpt";
                        iCfType = 1;
                    }
                    else if (cfType.Equals("jecf"))
                    {
                        _reportName = "MZ_精二处方清单(处方格式).rpt";
                        iCfType = 2;
                    }
                    else if (cfType.Equals("xzcf"))
                    {
                        _reportName = "MZ_手麻普通处方.rpt";
                        iCfType = 3;
                    }

                    if (iCfType == 1 || iCfType == 2)
                    {
                        for (int i = 0; i < myTb.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(myTb.Rows[i]["选"].ToString()) && myTb.Rows[i]["xmly"].ToString().Trim().Equals("1"))
                            {
                                string cjid = myTb.Rows[i]["item_code"].ToString().Trim();
                                string ypgg = "";

                                if (!IsPrtSsMzPresc(iCfType, cjid, out ypgg))
                                    continue;

                                rds.Tables["dtSsMzCf"].Clear();

                                dr = rds.Tables["dtSsMzCf"].NewRow();

                                string order = myTb.Rows[i]["Order_ID"].ToString();
                                string strSql = string.Format(@"select ORDER_BDATE,ORDER_DOC,ORDER_USAGE,FREQUENCY,ORDER_CONTEXT,zsl NUM,zsldw UNIT from ZY_ORDERRECORD where ORDER_ID='{0}'", order);

                                DataTable dtOrd = InstanceForm.BDatabase.GetDataTable(strSql);

                                if (dtOrd == null || dtOrd.Rows.Count <= 0)
                                    continue;


                                dr["开始日期"] = dtOrd.Rows[0]["ORDER_BDATE"].ToString();
                                dr["医嘱内容"] = dtOrd.Rows[0]["ORDER_CONTEXT"].ToString();
                                dr["录入人"] = dtOrd.Rows[0]["ORDER_DOC"].ToString();//iSel == 1 ? dtOrd.Rows[i]["开嘱医生"].ToString() : myTb.Rows[i]["开嘱转抄"].ToString();
                                dr["用法"] = dtOrd.Rows[0]["Order_Usage"].ToString();
                                dr["频率"] = dtOrd.Rows[0]["FREQUENCY"].ToString();
                                dr["数量"] = dtOrd.Rows[0]["NUM"].ToString();
                                dr["单位"] = dtOrd.Rows[0]["UNIT"].ToString();
                                dr["规格"] = ypgg;
                                dr["医生签名"] = GetImageByte((Convertor.IsNull(dtOrd.Rows[0]["ORDER_DOC"], "0")));

                                rds.Tables["dtSsMzCf"].Rows.Add(dr);

                                if (rds.Tables["dtSsMzCf"].Rows.Count == 0)
                                {
                                    return;
                                }

                                _parameters[0].Text = "hzsfzh";
                                _parameters[0].Value = "";
                                _parameters[1].Text = "xm";
                                _parameters[1].Value = patientInfo1.lbName.Text;
                                _parameters[2].Text = "xb";
                                _parameters[2].Value = patientInfo1.lbSex.Text;

                                _parameters[3].Text = "bq";
                                _parameters[3].Value = "";//FrmMdiMain.CurrentDept.WardName;
                                _parameters[4].Text = "ks";
                                _parameters[4].Value = patientInfo1.lbDQKS.Text;
                                _parameters[5].Text = "zyh";
                                _parameters[5].Value = patientInfo1.lbID.Text;

                                _parameters[6].Text = "ch";
                                _parameters[6].Value = patientInfo1.lbBed.Text;
                                _parameters[7].Text = "zd";
                                _parameters[7].Value = patientInfo1.lbRYZD.Text;
                                _parameters[8].Text = "nl";
                                _parameters[8].Value = patientInfo1.lbAge.Text;

                                frmRptView = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);

                                frmRptView.Show();
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < myTb.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(myTb.Rows[i]["选"].ToString()))
                            {
                                dr = rds.Tables["dtSsMzCf"].NewRow();

                                string order = myTb.Rows[i]["Order_ID"].ToString();
                                string strSql = string.Format(@"select ORDER_BDATE,ORDER_DOC,ORDER_USAGE,FREQUENCY,ORDER_CONTEXT,zsl NUM,zsldw UNIT from ZY_ORDERRECORD where ORDER_ID='{0}'", order);

                                DataTable dtOrd = InstanceForm.BDatabase.GetDataTable(strSql);

                                if (dtOrd == null || dtOrd.Rows.Count <= 0)
                                    continue;

                                //dr["开始日期"] = myTb.Rows[i]["开日期"].ToString();
                                //dr["医嘱内容"] = myTb.Rows[i]["医嘱内容"].ToString();
                                //dr["录入人"] = iSel == 1 ? myTb.Rows[i]["开嘱医生"].ToString() : myTb.Rows[i]["开嘱转抄"].ToString();


                                dr["开始日期"] = dtOrd.Rows[0]["ORDER_BDATE"].ToString();
                                dr["医嘱内容"] = dtOrd.Rows[0]["ORDER_CONTEXT"].ToString();
                                dr["录入人"] = dtOrd.Rows[0]["ORDER_DOC"].ToString();//iSel == 1 ? dtOrd.Rows[i]["开嘱医生"].ToString() : myTb.Rows[i]["开嘱转抄"].ToString();
                                dr["用法"] = dtOrd.Rows[0]["Order_Usage"].ToString();
                                dr["频率"] = dtOrd.Rows[0]["FREQUENCY"].ToString();
                                dr["数量"] = dtOrd.Rows[0]["NUM"].ToString();
                                dr["单位"] = dtOrd.Rows[0]["UNIT"].ToString();
                                dr["医生签名"] = GetImageByte((Convertor.IsNull(dtOrd.Rows[0]["ORDER_DOC"], "0")));

                                rds.Tables["dtSsMzCf"].Rows.Add(dr);
                            }
                        }

                        if (rds.Tables["dtSsMzCf"].Rows.Count == 0)
                        {
                            return;
                        }

                        _parameters[0].Text = "hzsfzh";
                        _parameters[0].Value = "";
                        _parameters[1].Text = "xm";
                        _parameters[1].Value = patientInfo1.lbName.Text;
                        _parameters[2].Text = "xb";
                        _parameters[2].Value = patientInfo1.lbSex.Text;

                        _parameters[3].Text = "bq";
                        _parameters[3].Value = "";//FrmMdiMain.CurrentDept.WardName;
                        _parameters[4].Text = "ks";
                        _parameters[4].Value = patientInfo1.lbDQKS.Text;
                        _parameters[5].Text = "zyh";
                        _parameters[5].Value = patientInfo1.lbID.Text;

                        _parameters[6].Text = "ch";
                        _parameters[6].Value = patientInfo1.lbBed.Text;
                        _parameters[7].Text = "zd";
                        _parameters[7].Value = patientInfo1.lbRYZD.Text;
                        _parameters[8].Text = "nl";
                        _parameters[8].Value = patientInfo1.lbAge.Text;

                        frmRptView = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);

                        frmRptView.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch { }
        }

        /// <summary>
        /// 该药品是否打印
        /// </summary>
        /// <param name="iType">1：麻、精一  2：精二 </param>
        /// <param name="cjid"></param>
        /// <returns></returns>
        private bool IsPrtSsMzPresc(int iType, string cjid, out string ypgg)
        {
            ypgg = "";
            try
            {
                string strSql = string.Format(@"select cast(MZYP as int) MZYP,cast(jsyp as int) jsyp,jsypfl,s_ypgg from VI_YP_YPCD where cjid='{0}'", cjid);

                DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql);

                if (dt == null || dt.Rows.Count <= 0)
                    return false;

                int iMz = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["MZYP"], "-1"));
                int iJs = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["jsyp"], "-1"));
                int iJsdj = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["jsypfl"], "-1"));
                ypgg = Convertor.IsNull(dt.Rows[0]["s_ypgg"], "");

                if (iType == 1)
                {
                    if (iMz > 0)
                    {
                        //麻醉
                        return true;
                    }
                    if (iJs > 0 && iJsdj == 1)
                    {
                        //精一
                        return true;
                    }
                }
                else if (iType == 2)
                {
                    if (iJs > 0 && iJsdj == 2)
                    {
                        //精二
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
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
    }
}