using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TszyHIS;
using Ts_ss_class;
using Ts_zyys_public;

namespace Ts_zyys_ssgl
{
    /// <summary>
    /// 手术申请 的摘要说明。
    /// </summary>
    public class FrmSSApply : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components;
        public string CaptionText;
        public string sNo = "";
        public string sInpatient_no = "";
        public long _Order_Num;
        public Guid BinID = Guid.Empty;
        public long DeptID = 0;
        public string WardID = "";
        public long YS_ID = 0;
        public User YS = null;
        public long lg = 0;
        //		public DataView SelectView;
        private DbQuery myQuery = new DbQuery();
        public System.Data.OleDb.OleDbConnection cCon = new System.Data.OleDb.OleDbConnection();
        private DataSet ds = new DataSet();
        private Control _curActiveTextBox;
        private bool isHs = false;//是不是护士站申请，如果是，那么手术直接审核

        protected System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label lblnl;
        protected System.Windows.Forms.Label label36;
        protected System.Windows.Forms.Label lblxb;
        protected System.Windows.Forms.Label label34;
        protected System.Windows.Forms.Label lblsqdh;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label lblks;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.Label lblbq;
        protected System.Windows.Forms.Label lblcwh;
        protected System.Windows.Forms.Label lblbrxm;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Label label27;
        protected System.Windows.Forms.Label label26;
        protected System.Windows.Forms.TextBox txtsg;
        protected System.Windows.Forms.TextBox txttz;
        protected System.Windows.Forms.Label label17;
        protected System.Windows.Forms.Label label16;
        protected System.Windows.Forms.TextBox txtzyh;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox txtysss;
        protected System.Windows.Forms.Label label18;
        protected System.Windows.Forms.Label label22;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.Label label15;
        protected System.Windows.Forms.Label label33;
        protected System.Windows.Forms.Label label35;
        protected System.Windows.Forms.Label label37;
        protected System.Windows.Forms.Label label38;
        protected System.Windows.Forms.Label label39;
        protected System.Windows.Forms.Label label40;
        protected System.Windows.Forms.Label label41;
        protected System.Windows.Forms.TextBox txtbz;
        protected System.Windows.Forms.Label label31;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.CheckBox checkjzss;
        protected System.Windows.Forms.CheckBox checkmztys;
        protected System.Windows.Forms.CheckBox checksstys;
        protected System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button Bsave;
        protected System.Windows.Forms.Label lblsqzd;
        protected System.Windows.Forms.TextBox txtfz1;
        protected System.Windows.Forms.TextBox txtfz2;
        protected System.Windows.Forms.TextBox txtfz3;
        protected System.Windows.Forms.TextBox txtywgms;
        protected System.Windows.Forms.TextBox txtysmz;
        protected System.Windows.Forms.TextBox txtsstw;
        protected System.Windows.Forms.TextBox txtssez;
        protected System.Windows.Forms.TextBox txtsssz;
        protected System.Windows.Forms.TextBox txtssyz;
        protected System.Windows.Forms.TextBox txtzdys;
        protected System.Windows.Forms.DateTimePicker dtpyssj;
        protected System.Windows.Forms.TextBox txttsqj1;
        protected System.Windows.Forms.TextBox txttsqj2;
        protected System.Windows.Forms.TextBox txttsqj3;
        protected System.Windows.Forms.TextBox txttsqj4;
        protected System.Windows.Forms.TextBox txtysqyy4;
        protected System.Windows.Forms.TextBox txtysqyy3;
        protected System.Windows.Forms.TextBox txtysqyy2;
        protected System.Windows.Forms.TextBox txtysqyy1;
        protected System.Windows.Forms.TextBox txtjsss4;
        protected System.Windows.Forms.TextBox txtjsss3;
        protected System.Windows.Forms.TextBox txtjsss2;
        protected System.Windows.Forms.TextBox txtjsss1;
        protected System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton chkhbsagx;
        private System.Windows.Forms.RadioButton chkhbsagy;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton chkkhcvx;
        private System.Windows.Forms.RadioButton chkkhcvy;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton chkkhzvx;
        private System.Windows.Forms.RadioButton chkkhzvy;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton chkktpx;
        private System.Windows.Forms.RadioButton chkktpy;
        public System.Windows.Forms.Button btSH;
        private System.Windows.Forms.DataGrid dGrid_sel;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        protected System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_dept;
        protected System.Windows.Forms.TextBox txtcgz4;
        protected System.Windows.Forms.TextBox txtcgz3;
        protected System.Windows.Forms.TextBox txtcgz2;
        protected System.Windows.Forms.TextBox txtcgz1;
        protected System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DateTimePicker dtpysrq;
        private CheckBox chcekbl;
        private DateTimePicker DtpbeginDate;
        public int ExecType = 0;//操作类型
        /// <summary>
        /// 是否启用手术等级控制 add by zouchihua 
        /// </summary>
        private SystemCfg cfg6071 = new SystemCfg(6071);

        private SystemCfg cfg6092 = new SystemCfg(6092);//by add yaokx 2014-05-12 拟施日期，把精准的时间改成”上午“或”下午“由医生进行选择
        /// <summary>
        /// 1表示临床路径用
        /// </summary>
        public int Iscp=0;
        private string pathway_id = "";
        private string PATH_STEP_ID = "";
        private string PATHWAY_EXE_ID = "";
        private string EXE_STEP_ID = "";
        private string PATH_STEP_ITEM_ID = "";
        private string ysss = "";
        protected TextBox txtjsmz;
        protected Label label19;
        private Label labssdj;
        private ComboBox comboBox1;
        private Label label20;
        private string ysssid = "";
        private Panel panelnsrqfw;
        private RadioButton rbnsrqfw_x;
        private RadioButton rbnsrqfw_s;
        /// <summary>
        /// 是否查看
        /// </summary>
        public bool _ck = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="currentDept"></param>
        /// <param name="formText"></param>
        /// <param name="_value"></param>
        public FrmSSApply(long currentUser, long currentDept, string formText, object[] _value)
        {
            InitializeComponent();

            BinID = new Guid(Convertor.IsNull(_value[0], Guid.Empty.ToString()));

            YS = new User(Convert.ToInt64(currentUser), FrmMdiMain.Database);

            YS_ID = YS.EmployeeId;
            DeptID = currentDept;
            WardID = _value[1].ToString();
            lg = Convert.ToInt64(Convertor.IsNull(_value[5], "0"));
            sInpatient_no = Convertor.IsNull(_value[6], "0");
        }
        
        public FrmSSApply(long currentUser, long currentDept, string formText, bool _ishs, object[] _value)
        {
            InitializeComponent();

            isHs = _ishs;

            BinID = new Guid(Convertor.IsNull(_value[0], Guid.Empty.ToString()));

            YS = new User(Convert.ToInt64(currentUser), FrmMdiMain.Database);

            YS_ID = YS.EmployeeId;
            DeptID = currentDept;
            WardID = _value[1].ToString();
            lg = Convert.ToInt64(Convertor.IsNull(_value[5], "0"));
            sInpatient_no = Convertor.IsNull(_value[6], "0");
             
        }
        /// <summary>
        /// 临床路径调用
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="currentDept"></param>
        /// <param name="formText"></param>
        /// <param name="_ishs"></param>
        /// <param name="_value"></param>
          public FrmSSApply(long currentUser, long currentDept, string formText, int  _Iscp, object[] _value)
        {
            InitializeComponent();

            Iscp = _Iscp;
            
            BinID = new Guid(Convertor.IsNull(_value[0], Guid.Empty.ToString()));

            YS = new User(Convert.ToInt64(currentUser), FrmMdiMain.Database);

            YS_ID = YS.EmployeeId;
            DeptID = currentDept;
            WardID = _value[1].ToString();
            lg = Convert.ToInt64(Convertor.IsNull(_value[5], "0"));
            sInpatient_no = Convertor.IsNull(_value[6], "0");
            txtysss.Text = _value[7].ToString();
            txtysss.Tag = _value[8];
            pathway_id = Convert.ToString(_value[9]);
            PATH_STEP_ID = Convert.ToString(_value[10]);
            PATHWAY_EXE_ID = Convert.ToString(_value[11]);
            EXE_STEP_ID = Convert.ToString(_value[12]);
            PATH_STEP_ITEM_ID = Convert.ToString(_value[13]);
            ysss = _value[7].ToString();
            ysssid = _value[8].ToString();  
        }
        public FrmSSApply(long currentUser, long currentDept, string formText)
        {
            InitializeComponent();
        }
        public FrmSSApply(bool _ishs)
        {
            InitializeComponent();

            isHs = _ishs;
        }
        public FrmSSApply()
        {
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSSApply));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblsqzd = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblnl = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblxb = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lblsqdh = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblks = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblbq = new System.Windows.Forms.Label();
            this.lblcwh = new System.Windows.Forms.Label();
            this.lblbrxm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelnsrqfw = new System.Windows.Forms.Panel();
            this.rbnsrqfw_x = new System.Windows.Forms.RadioButton();
            this.rbnsrqfw_s = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.labssdj = new System.Windows.Forms.Label();
            this.txtjsmz = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtcgz4 = new System.Windows.Forms.TextBox();
            this.txtcgz3 = new System.Windows.Forms.TextBox();
            this.txtcgz2 = new System.Windows.Forms.TextBox();
            this.txtcgz1 = new System.Windows.Forms.TextBox();
            this.cmb_dept = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dGrid_sel = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkktpx = new System.Windows.Forms.RadioButton();
            this.chkktpy = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkkhzvx = new System.Windows.Forms.RadioButton();
            this.chkkhzvy = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkkhcvx = new System.Windows.Forms.RadioButton();
            this.chkkhcvy = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkhbsagx = new System.Windows.Forms.RadioButton();
            this.chkhbsagy = new System.Windows.Forms.RadioButton();
            this.txtjsss4 = new System.Windows.Forms.TextBox();
            this.txtjsss3 = new System.Windows.Forms.TextBox();
            this.txtjsss2 = new System.Windows.Forms.TextBox();
            this.txtjsss1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtysqyy4 = new System.Windows.Forms.TextBox();
            this.txtysqyy3 = new System.Windows.Forms.TextBox();
            this.txtysqyy2 = new System.Windows.Forms.TextBox();
            this.txtysqyy1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txttsqj4 = new System.Windows.Forms.TextBox();
            this.txttsqj3 = new System.Windows.Forms.TextBox();
            this.txttsqj2 = new System.Windows.Forms.TextBox();
            this.txttsqj1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.dtpyssj = new System.Windows.Forms.DateTimePicker();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txtywgms = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtfz3 = new System.Windows.Forms.TextBox();
            this.txtfz2 = new System.Windows.Forms.TextBox();
            this.txtfz1 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtssez = new System.Windows.Forms.TextBox();
            this.txtsssz = new System.Windows.Forms.TextBox();
            this.txtssyz = new System.Windows.Forms.TextBox();
            this.txtzdys = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtsstw = new System.Windows.Forms.TextBox();
            this.txtysmz = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtysss = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtsg = new System.Windows.Forms.TextBox();
            this.txttz = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtzyh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpysrq = new System.Windows.Forms.DateTimePicker();
            this.checkjzss = new System.Windows.Forms.CheckBox();
            this.checkmztys = new System.Windows.Forms.CheckBox();
            this.checksstys = new System.Windows.Forms.CheckBox();
            this.btSH = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Bsave = new System.Windows.Forms.Button();
            this.chcekbl = new System.Windows.Forms.CheckBox();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelnsrqfw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_sel)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblsqzd);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblnl);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.lblxb);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.lblsqdh);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblks);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblbq);
            this.groupBox2.Controls.Add(this.lblcwh);
            this.groupBox2.Controls.Add(this.lblbrxm);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Location = new System.Drawing.Point(8, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(734, 80);
            this.groupBox2.TabIndex = 162;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "病人信息";
            // 
            // lblsqzd
            // 
            this.lblsqzd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblsqzd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsqzd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblsqzd.Location = new System.Drawing.Point(424, 50);
            this.lblsqzd.Name = "lblsqzd";
            this.lblsqzd.Size = new System.Drawing.Size(272, 21);
            this.lblsqzd.TabIndex = 143;
            this.lblsqzd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(360, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 142;
            this.label4.Text = "术前诊断";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(203, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 18);
            this.label7.TabIndex = 141;
            this.label7.Text = "病区";
            // 
            // lblnl
            // 
            this.lblnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblnl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblnl.Location = new System.Drawing.Point(392, 21);
            this.lblnl.Name = "lblnl";
            this.lblnl.Size = new System.Drawing.Size(41, 21);
            this.lblnl.TabIndex = 140;
            this.lblnl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(360, 24);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(50, 18);
            this.label36.TabIndex = 139;
            this.label36.Text = "年龄";
            // 
            // lblxb
            // 
            this.lblxb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblxb.Location = new System.Drawing.Point(304, 21);
            this.lblxb.Name = "lblxb";
            this.lblxb.Size = new System.Drawing.Size(41, 21);
            this.lblxb.TabIndex = 138;
            this.lblxb.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(272, 24);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(50, 18);
            this.label34.TabIndex = 137;
            this.label34.Text = "性别";
            // 
            // lblsqdh
            // 
            this.lblsqdh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblsqdh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsqdh.ForeColor = System.Drawing.Color.Red;
            this.lblsqdh.Location = new System.Drawing.Point(504, 20);
            this.lblsqdh.Name = "lblsqdh";
            this.lblsqdh.Size = new System.Drawing.Size(192, 21);
            this.lblsqdh.TabIndex = 134;
            this.lblsqdh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(448, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 133;
            this.label5.Text = "单据号";
            // 
            // lblks
            // 
            this.lblks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblks.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblks.Location = new System.Drawing.Point(79, 50);
            this.lblks.Name = "lblks";
            this.lblks.Size = new System.Drawing.Size(121, 21);
            this.lblks.TabIndex = 130;
            this.lblks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(16, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 18);
            this.label11.TabIndex = 129;
            this.label11.Text = "科  室";
            // 
            // lblbq
            // 
            this.lblbq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblbq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblbq.Location = new System.Drawing.Point(242, 50);
            this.lblbq.Name = "lblbq";
            this.lblbq.Size = new System.Drawing.Size(102, 21);
            this.lblbq.TabIndex = 128;
            this.lblbq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblcwh
            // 
            this.lblcwh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcwh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcwh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblcwh.Location = new System.Drawing.Point(224, 21);
            this.lblcwh.Name = "lblcwh";
            this.lblcwh.Size = new System.Drawing.Size(41, 21);
            this.lblcwh.TabIndex = 127;
            this.lblcwh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblbrxm
            // 
            this.lblbrxm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblbrxm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbrxm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblbrxm.Location = new System.Drawing.Point(79, 21);
            this.lblbrxm.Name = "lblbrxm";
            this.lblbrxm.Size = new System.Drawing.Size(100, 21);
            this.lblbrxm.TabIndex = 126;
            this.lblbrxm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 125;
            this.label3.Text = "病人姓名";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(189, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 124;
            this.label2.Text = "床号";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelnsrqfw);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.labssdj);
            this.groupBox1.Controls.Add(this.txtjsmz);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtcgz4);
            this.groupBox1.Controls.Add(this.txtcgz3);
            this.groupBox1.Controls.Add(this.txtcgz2);
            this.groupBox1.Controls.Add(this.txtcgz1);
            this.groupBox1.Controls.Add(this.cmb_dept);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dGrid_sel);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.txtjsss4);
            this.groupBox1.Controls.Add(this.txtjsss3);
            this.groupBox1.Controls.Add(this.txtjsss2);
            this.groupBox1.Controls.Add(this.txtjsss1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtysqyy4);
            this.groupBox1.Controls.Add(this.txtysqyy3);
            this.groupBox1.Controls.Add(this.txtysqyy2);
            this.groupBox1.Controls.Add(this.txtysqyy1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txttsqj4);
            this.groupBox1.Controls.Add(this.txttsqj3);
            this.groupBox1.Controls.Add(this.txttsqj2);
            this.groupBox1.Controls.Add(this.txttsqj1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtbz);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.dtpyssj);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.txtywgms);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.txtfz3);
            this.groupBox1.Controls.Add(this.txtfz2);
            this.groupBox1.Controls.Add(this.txtfz1);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtssez);
            this.groupBox1.Controls.Add(this.txtsssz);
            this.groupBox1.Controls.Add(this.txtssyz);
            this.groupBox1.Controls.Add(this.txtzdys);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtsstw);
            this.groupBox1.Controls.Add(this.txtysmz);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txtysss);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.txtsg);
            this.groupBox1.Controls.Add(this.txttz);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtzyh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpysrq);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(8, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 321);
            this.groupBox1.TabIndex = 163;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "申请信息";
            // 
            // panelnsrqfw
            // 
            this.panelnsrqfw.Controls.Add(this.rbnsrqfw_x);
            this.panelnsrqfw.Controls.Add(this.rbnsrqfw_s);
            this.panelnsrqfw.Location = new System.Drawing.Point(626, 166);
            this.panelnsrqfw.Name = "panelnsrqfw";
            this.panelnsrqfw.Size = new System.Drawing.Size(101, 23);
            this.panelnsrqfw.TabIndex = 213;
            this.panelnsrqfw.Visible = false;
            // 
            // rbnsrqfw_x
            // 
            this.rbnsrqfw_x.AutoSize = true;
            this.rbnsrqfw_x.Location = new System.Drawing.Point(50, 4);
            this.rbnsrqfw_x.Name = "rbnsrqfw_x";
            this.rbnsrqfw_x.Size = new System.Drawing.Size(47, 16);
            this.rbnsrqfw_x.TabIndex = 0;
            this.rbnsrqfw_x.TabStop = true;
            this.rbnsrqfw_x.Text = "下午";
            this.rbnsrqfw_x.UseVisualStyleBackColor = true;
            // 
            // rbnsrqfw_s
            // 
            this.rbnsrqfw_s.AutoSize = true;
            this.rbnsrqfw_s.Location = new System.Drawing.Point(6, 4);
            this.rbnsrqfw_s.Name = "rbnsrqfw_s";
            this.rbnsrqfw_s.Size = new System.Drawing.Size(47, 16);
            this.rbnsrqfw_s.TabIndex = 0;
            this.rbnsrqfw_s.TabStop = true;
            this.rbnsrqfw_s.Text = "上午";
            this.rbnsrqfw_s.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "    ",
            "正常",
            "不正常"});
            this.comboBox1.Location = new System.Drawing.Point(645, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(83, 20);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(595, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 212;
            this.label20.Text = "凝血常规";
            // 
            // labssdj
            // 
            this.labssdj.AutoSize = true;
            this.labssdj.ForeColor = System.Drawing.Color.Red;
            this.labssdj.Location = new System.Drawing.Point(218, 112);
            this.labssdj.Name = "labssdj";
            this.labssdj.Size = new System.Drawing.Size(0, 12);
            this.labssdj.TabIndex = 211;
            // 
            // txtjsmz
            // 
            this.txtjsmz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjsmz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjsmz.Location = new System.Drawing.Point(504, 108);
            this.txtjsmz.Name = "txtjsmz";
            this.txtjsmz.Size = new System.Drawing.Size(80, 23);
            this.txtjsmz.TabIndex = 17;
            this.txtjsmz.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(435, 112);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 18);
            this.label19.TabIndex = 210;
            this.label19.Text = "兼施麻醉";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(251, 296);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 14);
            this.label14.TabIndex = 209;
            this.label14.Text = "参观者";
            // 
            // txtcgz4
            // 
            this.txtcgz4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcgz4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtcgz4.Location = new System.Drawing.Point(592, 288);
            this.txtcgz4.Name = "txtcgz4";
            this.txtcgz4.Size = new System.Drawing.Size(136, 23);
            this.txtcgz4.TabIndex = 40;
            this.txtcgz4.Visible = false;
            this.txtcgz4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtcgz4.Enter += new System.EventHandler(this.txt_Enter);
            this.txtcgz4.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtcgz3
            // 
            this.txtcgz3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcgz3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtcgz3.Location = new System.Drawing.Point(496, 288);
            this.txtcgz3.Name = "txtcgz3";
            this.txtcgz3.Size = new System.Drawing.Size(96, 23);
            this.txtcgz3.TabIndex = 39;
            this.txtcgz3.Visible = false;
            this.txtcgz3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtcgz3.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtcgz2
            // 
            this.txtcgz2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcgz2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtcgz2.Location = new System.Drawing.Point(400, 288);
            this.txtcgz2.Name = "txtcgz2";
            this.txtcgz2.Size = new System.Drawing.Size(96, 23);
            this.txtcgz2.TabIndex = 38;
            this.txtcgz2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtcgz2.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtcgz1
            // 
            this.txtcgz1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcgz1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtcgz1.Location = new System.Drawing.Point(304, 288);
            this.txtcgz1.Name = "txtcgz1";
            this.txtcgz1.Size = new System.Drawing.Size(96, 23);
            this.txtcgz1.TabIndex = 37;
            this.txtcgz1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtcgz1.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // cmb_dept
            // 
            this.cmb_dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_dept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_dept.Location = new System.Drawing.Point(80, 288);
            this.cmb_dept.Name = "cmb_dept";
            this.cmb_dept.Size = new System.Drawing.Size(152, 22);
            this.cmb_dept.TabIndex = 204;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(16, 292);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 18);
            this.label12.TabIndex = 203;
            this.label12.Text = "手术地点";
            // 
            // dGrid_sel
            // 
            this.dGrid_sel.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dGrid_sel.CaptionVisible = false;
            this.dGrid_sel.DataMember = "";
            this.dGrid_sel.HeaderBackColor = System.Drawing.Color.DarkGray;
            this.dGrid_sel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGrid_sel.Location = new System.Drawing.Point(656, -146);
            this.dGrid_sel.Name = "dGrid_sel";
            this.dGrid_sel.RowHeaderWidth = 25;
            this.dGrid_sel.Size = new System.Drawing.Size(336, 160);
            this.dGrid_sel.TabIndex = 202;
            this.dGrid_sel.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dGrid_sel.Visible = false;
            this.dGrid_sel.DoubleClick += new System.EventHandler(this.dGrid_sel_DoubleClick);
            this.dGrid_sel.CurrentCellChanged += new System.EventHandler(this.dGrid_CurrentCellChanged);
            this.dGrid_sel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dGrid_sel_KeyUp);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dGrid_sel;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "seltb";
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeaderWidth = 25;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "序号";
            this.dataGridTextBoxColumn5.MappingName = "ROWNO";
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "数字码";
            this.dataGridTextBoxColumn1.MappingName = "D_CODE";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "名称";
            this.dataGridTextBoxColumn2.MappingName = "NAME";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "拼音码";
            this.dataGridTextBoxColumn3.MappingName = "PY_CODE";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "五笔码";
            this.dataGridTextBoxColumn4.MappingName = "WB_CODE";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkktpx);
            this.panel4.Controls.Add(this.chkktpy);
            this.panel4.Location = new System.Drawing.Point(584, 72);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(112, 32);
            this.panel4.TabIndex = 200;
            // 
            // chkktpx
            // 
            this.chkktpx.BackColor = System.Drawing.SystemColors.Control;
            this.chkktpx.ForeColor = System.Drawing.SystemColors.GrayText;
            this.chkktpx.Location = new System.Drawing.Point(57, 6);
            this.chkktpx.Name = "chkktpx";
            this.chkktpx.Size = new System.Drawing.Size(48, 24);
            this.chkktpx.TabIndex = 198;
            this.chkktpx.Text = "阴性";
            this.chkktpx.UseVisualStyleBackColor = false;
            // 
            // chkktpy
            // 
            this.chkktpy.BackColor = System.Drawing.SystemColors.Control;
            this.chkktpy.ForeColor = System.Drawing.SystemColors.GrayText;
            this.chkktpy.Location = new System.Drawing.Point(8, 6);
            this.chkktpy.Name = "chkktpy";
            this.chkktpy.Size = new System.Drawing.Size(48, 24);
            this.chkktpy.TabIndex = 197;
            this.chkktpy.Text = "阳性";
            this.chkktpy.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkkhzvx);
            this.panel3.Controls.Add(this.chkkhzvy);
            this.panel3.Location = new System.Drawing.Point(424, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(112, 32);
            this.panel3.TabIndex = 199;
            // 
            // chkkhzvx
            // 
            this.chkkhzvx.BackColor = System.Drawing.SystemColors.Control;
            this.chkkhzvx.ForeColor = System.Drawing.SystemColors.GrayText;
            this.chkkhzvx.Location = new System.Drawing.Point(57, 6);
            this.chkkhzvx.Name = "chkkhzvx";
            this.chkkhzvx.Size = new System.Drawing.Size(48, 24);
            this.chkkhzvx.TabIndex = 198;
            this.chkkhzvx.Text = "阴性";
            this.chkkhzvx.UseVisualStyleBackColor = false;
            // 
            // chkkhzvy
            // 
            this.chkkhzvy.BackColor = System.Drawing.SystemColors.Control;
            this.chkkhzvy.ForeColor = System.Drawing.SystemColors.GrayText;
            this.chkkhzvy.Location = new System.Drawing.Point(8, 6);
            this.chkkhzvy.Name = "chkkhzvy";
            this.chkkhzvy.Size = new System.Drawing.Size(48, 24);
            this.chkkhzvy.TabIndex = 197;
            this.chkkhzvy.Text = "阳性";
            this.chkkhzvy.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkkhcvx);
            this.panel2.Controls.Add(this.chkkhcvy);
            this.panel2.Location = new System.Drawing.Point(256, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(112, 32);
            this.panel2.TabIndex = 198;
            // 
            // chkkhcvx
            // 
            this.chkkhcvx.BackColor = System.Drawing.SystemColors.Control;
            this.chkkhcvx.ForeColor = System.Drawing.SystemColors.GrayText;
            this.chkkhcvx.Location = new System.Drawing.Point(57, 6);
            this.chkkhcvx.Name = "chkkhcvx";
            this.chkkhcvx.Size = new System.Drawing.Size(48, 24);
            this.chkkhcvx.TabIndex = 198;
            this.chkkhcvx.Text = "阴性";
            this.chkkhcvx.UseVisualStyleBackColor = false;
            // 
            // chkkhcvy
            // 
            this.chkkhcvy.BackColor = System.Drawing.SystemColors.Control;
            this.chkkhcvy.ForeColor = System.Drawing.SystemColors.GrayText;
            this.chkkhcvy.Location = new System.Drawing.Point(8, 6);
            this.chkkhcvy.Name = "chkkhcvy";
            this.chkkhcvy.Size = new System.Drawing.Size(48, 24);
            this.chkkhcvy.TabIndex = 197;
            this.chkkhcvy.Text = "阳性";
            this.chkkhcvy.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkhbsagx);
            this.panel1.Controls.Add(this.chkhbsagy);
            this.panel1.Location = new System.Drawing.Point(80, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(112, 32);
            this.panel1.TabIndex = 197;
            // 
            // chkhbsagx
            // 
            this.chkhbsagx.BackColor = System.Drawing.SystemColors.Control;
            this.chkhbsagx.ForeColor = System.Drawing.SystemColors.GrayText;
            this.chkhbsagx.Location = new System.Drawing.Point(57, 6);
            this.chkhbsagx.Name = "chkhbsagx";
            this.chkhbsagx.Size = new System.Drawing.Size(48, 24);
            this.chkhbsagx.TabIndex = 198;
            this.chkhbsagx.Text = "阴性";
            this.chkhbsagx.UseVisualStyleBackColor = false;
            // 
            // chkhbsagy
            // 
            this.chkhbsagy.BackColor = System.Drawing.SystemColors.Control;
            this.chkhbsagy.ForeColor = System.Drawing.SystemColors.GrayText;
            this.chkhbsagy.Location = new System.Drawing.Point(8, 6);
            this.chkhbsagy.Name = "chkhbsagy";
            this.chkhbsagy.Size = new System.Drawing.Size(48, 24);
            this.chkhbsagy.TabIndex = 197;
            this.chkhbsagy.Text = "阳性";
            this.chkhbsagy.UseVisualStyleBackColor = false;
            // 
            // txtjsss4
            // 
            this.txtjsss4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjsss4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjsss4.Location = new System.Drawing.Point(536, 137);
            this.txtjsss4.Name = "txtjsss4";
            this.txtjsss4.Size = new System.Drawing.Size(192, 23);
            this.txtjsss4.TabIndex = 21;
            this.txtjsss4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtjsss4.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtjsss3
            // 
            this.txtjsss3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjsss3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjsss3.Location = new System.Drawing.Point(384, 137);
            this.txtjsss3.Name = "txtjsss3";
            this.txtjsss3.Size = new System.Drawing.Size(152, 23);
            this.txtjsss3.TabIndex = 20;
            this.txtjsss3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtjsss3.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtjsss2
            // 
            this.txtjsss2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjsss2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjsss2.Location = new System.Drawing.Point(232, 137);
            this.txtjsss2.Name = "txtjsss2";
            this.txtjsss2.Size = new System.Drawing.Size(152, 23);
            this.txtjsss2.TabIndex = 19;
            this.txtjsss2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtjsss2.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtjsss1
            // 
            this.txtjsss1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjsss1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjsss1.Location = new System.Drawing.Point(80, 137);
            this.txtjsss1.Name = "txtjsss1";
            this.txtjsss1.Size = new System.Drawing.Size(152, 23);
            this.txtjsss1.TabIndex = 18;
            this.txtjsss1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtjsss1.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(16, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 195;
            this.label9.Text = "兼施手术";
            // 
            // txtysqyy4
            // 
            this.txtysqyy4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtysqyy4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtysqyy4.Location = new System.Drawing.Point(536, 225);
            this.txtysqyy4.Name = "txtysqyy4";
            this.txtysqyy4.Size = new System.Drawing.Size(192, 23);
            this.txtysqyy4.TabIndex = 35;
            this.txtysqyy4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtysqyy4.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtysqyy3
            // 
            this.txtysqyy3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtysqyy3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtysqyy3.Location = new System.Drawing.Point(384, 225);
            this.txtysqyy3.Name = "txtysqyy3";
            this.txtysqyy3.Size = new System.Drawing.Size(152, 23);
            this.txtysqyy3.TabIndex = 34;
            this.txtysqyy3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtysqyy3.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtysqyy2
            // 
            this.txtysqyy2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtysqyy2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtysqyy2.Location = new System.Drawing.Point(232, 225);
            this.txtysqyy2.Name = "txtysqyy2";
            this.txtysqyy2.Size = new System.Drawing.Size(152, 23);
            this.txtysqyy2.TabIndex = 33;
            this.txtysqyy2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtysqyy2.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtysqyy1
            // 
            this.txtysqyy1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtysqyy1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtysqyy1.Location = new System.Drawing.Point(80, 225);
            this.txtysqyy1.Name = "txtysqyy1";
            this.txtysqyy1.Size = new System.Drawing.Size(152, 23);
            this.txtysqyy1.TabIndex = 32;
            this.txtysqyy1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtysqyy1.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(5, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 190;
            this.label10.Text = "拟术前用药";
            // 
            // txttsqj4
            // 
            this.txttsqj4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttsqj4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txttsqj4.Location = new System.Drawing.Point(536, 197);
            this.txttsqj4.Name = "txttsqj4";
            this.txttsqj4.Size = new System.Drawing.Size(192, 23);
            this.txttsqj4.TabIndex = 31;
            this.txttsqj4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txttsqj4.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txttsqj3
            // 
            this.txttsqj3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttsqj3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txttsqj3.Location = new System.Drawing.Point(384, 197);
            this.txttsqj3.Name = "txttsqj3";
            this.txttsqj3.Size = new System.Drawing.Size(152, 23);
            this.txttsqj3.TabIndex = 30;
            this.txttsqj3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txttsqj3.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txttsqj2
            // 
            this.txttsqj2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttsqj2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txttsqj2.Location = new System.Drawing.Point(232, 197);
            this.txttsqj2.Name = "txttsqj2";
            this.txttsqj2.Size = new System.Drawing.Size(152, 23);
            this.txttsqj2.TabIndex = 29;
            this.txttsqj2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txttsqj2.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txttsqj1
            // 
            this.txttsqj1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttsqj1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txttsqj1.Location = new System.Drawing.Point(80, 197);
            this.txttsqj1.Name = "txttsqj1";
            this.txttsqj1.Size = new System.Drawing.Size(152, 23);
            this.txttsqj1.TabIndex = 28;
            this.txttsqj1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txttsqj1.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(16, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 185;
            this.label6.Text = "特殊器械";
            // 
            // txtbz
            // 
            this.txtbz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtbz.Location = new System.Drawing.Point(80, 256);
            this.txtbz.Multiline = true;
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(648, 24);
            this.txtbz.TabIndex = 36;
            this.txtbz.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GotoNext);
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(32, 262);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(36, 18);
            this.label31.TabIndex = 184;
            this.label31.Text = "备注";
            // 
            // dtpyssj
            // 
            this.dtpyssj.CustomFormat = "HH:mm:ss";
            this.dtpyssj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpyssj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpyssj.Location = new System.Drawing.Point(628, 166);
            this.dtpyssj.Name = "dtpyssj";
            this.dtpyssj.ShowUpDown = true;
            this.dtpyssj.Size = new System.Drawing.Size(60, 23);
            this.dtpyssj.TabIndex = 27;
            this.dtpyssj.Value = new System.DateTime(2007, 1, 8, 18, 33, 0, 0);
            this.dtpyssj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GotoNext);
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.Location = new System.Drawing.Point(467, 171);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(65, 18);
            this.label41.TabIndex = 182;
            this.label41.Text = "拟施日期";
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(549, 80);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(48, 18);
            this.label40.TabIndex = 171;
            this.label40.Text = "抗TP";
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(381, 80);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(48, 18);
            this.label39.TabIndex = 170;
            this.label39.Text = "抗HIV";
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(204, 80);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(56, 18);
            this.label38.TabIndex = 169;
            this.label38.Text = "抗HCV ";
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(26, 80);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(47, 18);
            this.label37.TabIndex = 168;
            this.label37.Text = "HBsAg ";
            // 
            // txtywgms
            // 
            this.txtywgms.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtywgms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtywgms.Location = new System.Drawing.Point(496, 16);
            this.txtywgms.Name = "txtywgms";
            this.txtywgms.Size = new System.Drawing.Size(232, 23);
            this.txtywgms.TabIndex = 3;
            this.txtywgms.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GotoNext);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(416, 20);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 14);
            this.label35.TabIndex = 167;
            this.label35.Text = "药物过敏史";
            // 
            // txtfz3
            // 
            this.txtfz3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfz3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfz3.Location = new System.Drawing.Point(480, 48);
            this.txtfz3.Name = "txtfz3";
            this.txtfz3.Size = new System.Drawing.Size(112, 23);
            this.txtfz3.TabIndex = 6;
            this.txtfz3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtfz3.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtfz2
            // 
            this.txtfz2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfz2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfz2.Location = new System.Drawing.Point(280, 48);
            this.txtfz2.Name = "txtfz2";
            this.txtfz2.Size = new System.Drawing.Size(200, 23);
            this.txtfz2.TabIndex = 5;
            this.txtfz2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtfz2.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtfz1
            // 
            this.txtfz1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfz1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfz1.Location = new System.Drawing.Point(80, 48);
            this.txtfz1.Name = "txtfz1";
            this.txtfz1.Size = new System.Drawing.Size(200, 23);
            this.txtfz1.TabIndex = 4;
            this.txtfz1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtfz1.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.ForeColor = System.Drawing.Color.Red;
            this.label33.Location = new System.Drawing.Point(22, 53);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 18);
            this.label33.TabIndex = 163;
            this.label33.Text = "辅诊";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(192, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 18);
            this.label13.TabIndex = 161;
            this.label13.Text = "助手";
            // 
            // txtssez
            // 
            this.txtssez.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtssez.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtssez.Location = new System.Drawing.Point(304, 166);
            this.txtssez.Name = "txtssez";
            this.txtssez.Size = new System.Drawing.Size(76, 23);
            this.txtssez.TabIndex = 24;
            this.txtssez.Text = "无";
            this.txtssez.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtssez.Enter += new System.EventHandler(this.txt_Enter);
            this.txtssez.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtsssz
            // 
            this.txtsssz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtsssz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtsssz.Location = new System.Drawing.Point(381, 166);
            this.txtsssz.Name = "txtsssz";
            this.txtsssz.Size = new System.Drawing.Size(76, 23);
            this.txtsssz.TabIndex = 25;
            this.txtsssz.Text = "无";
            this.txtsssz.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtsssz.Enter += new System.EventHandler(this.txt_Enter);
            this.txtsssz.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtssyz
            // 
            this.txtssyz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtssyz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtssyz.Location = new System.Drawing.Point(228, 166);
            this.txtssyz.Name = "txtssyz";
            this.txtssyz.Size = new System.Drawing.Size(76, 23);
            this.txtssyz.TabIndex = 23;
            this.txtssyz.Text = "无";
            this.txtssyz.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtssyz.Enter += new System.EventHandler(this.txt_Enter);
            this.txtssyz.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtzdys
            // 
            this.txtzdys.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzdys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtzdys.Location = new System.Drawing.Point(81, 166);
            this.txtzdys.Name = "txtzdys";
            this.txtzdys.Size = new System.Drawing.Size(96, 23);
            this.txtzdys.TabIndex = 22;
            this.txtzdys.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtzdys.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(16, 171);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 18);
            this.label15.TabIndex = 160;
            this.label15.Text = "主刀医生";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(582, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 18);
            this.label8.TabIndex = 155;
            this.label8.Text = "手术体位";
            // 
            // txtsstw
            // 
            this.txtsstw.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtsstw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtsstw.Location = new System.Drawing.Point(645, 109);
            this.txtsstw.Name = "txtsstw";
            this.txtsstw.Size = new System.Drawing.Size(83, 23);
            this.txtsstw.TabIndex = 17;
            this.txtsstw.Tag = "0";
            this.txtsstw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtsstw.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtysmz
            // 
            this.txtysmz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtysmz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtysmz.Location = new System.Drawing.Point(349, 109);
            this.txtysmz.Name = "txtysmz";
            this.txtysmz.Size = new System.Drawing.Size(85, 23);
            this.txtysmz.TabIndex = 16;
            this.txtysmz.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtysmz.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(284, 112);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 18);
            this.label22.TabIndex = 153;
            this.label22.Text = "拟施麻醉";
            // 
            // txtysss
            // 
            this.txtysss.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtysss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtysss.Location = new System.Drawing.Point(81, 107);
            this.txtysss.Name = "txtysss";
            this.txtysss.Size = new System.Drawing.Size(134, 23);
            this.txtysss.TabIndex = 15;
            this.txtysss.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtysss.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(18, 110);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 18);
            this.label18.TabIndex = 149;
            this.label18.Text = "拟施手术";
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(382, 19);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(24, 18);
            this.label27.TabIndex = 144;
            this.label27.Text = "Kg";
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(269, 19);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(24, 18);
            this.label26.TabIndex = 143;
            this.label26.Text = "cm";
            // 
            // txtsg
            // 
            this.txtsg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtsg.Location = new System.Drawing.Point(221, 16);
            this.txtsg.Name = "txtsg";
            this.txtsg.Size = new System.Drawing.Size(44, 23);
            this.txtsg.TabIndex = 1;
            this.txtsg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GotoNext);
            // 
            // txttz
            // 
            this.txttz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txttz.Location = new System.Drawing.Point(331, 16);
            this.txttz.Name = "txttz";
            this.txttz.Size = new System.Drawing.Size(50, 23);
            this.txttz.TabIndex = 2;
            this.txttz.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GotoNext);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(296, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 18);
            this.label17.TabIndex = 142;
            this.label17.Text = "体重";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(187, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 18);
            this.label16.TabIndex = 141;
            this.label16.Text = "身高";
            // 
            // txtzyh
            // 
            this.txtzyh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzyh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtzyh.Location = new System.Drawing.Point(80, 16);
            this.txtzyh.Name = "txtzyh";
            this.txtzyh.ReadOnly = true;
            this.txtzyh.Size = new System.Drawing.Size(100, 23);
            this.txtzyh.TabIndex = 0;
            this.txtzyh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtzyh_KeyDown);
            this.txtzyh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GotoNext);
            this.txtzyh.Enter += new System.EventHandler(this.txtzyh_Enter);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 138;
            this.label1.Text = "住院号";
            // 
            // dtpysrq
            // 
            this.dtpysrq.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dtpysrq.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpysrq.Location = new System.Drawing.Point(533, 167);
            this.dtpysrq.Name = "dtpysrq";
            this.dtpysrq.ShowUpDown = true;
            this.dtpysrq.Size = new System.Drawing.Size(93, 23);
            this.dtpysrq.TabIndex = 202;
            this.dtpysrq.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GotoNext);
            // 
            // checkjzss
            // 
            this.checkjzss.ForeColor = System.Drawing.Color.Red;
            this.checkjzss.Location = new System.Drawing.Point(88, 424);
            this.checkjzss.Name = "checkjzss";
            this.checkjzss.Size = new System.Drawing.Size(76, 20);
            this.checkjzss.TabIndex = 1;
            this.checkjzss.Text = "急诊手术";
            this.checkjzss.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GotoNext);
            // 
            // checkmztys
            // 
            this.checkmztys.Location = new System.Drawing.Point(272, 424);
            this.checkmztys.Name = "checkmztys";
            this.checkmztys.Size = new System.Drawing.Size(98, 20);
            this.checkmztys.TabIndex = 3;
            this.checkmztys.Text = "签麻醉同意书";
            this.checkmztys.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GotoNext);
            // 
            // checksstys
            // 
            this.checksstys.Location = new System.Drawing.Point(168, 424);
            this.checksstys.Name = "checksstys";
            this.checksstys.Size = new System.Drawing.Size(102, 18);
            this.checksstys.TabIndex = 2;
            this.checksstys.Text = "签手术同意书";
            this.checksstys.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GotoNext);
            // 
            // btSH
            // 
            this.btSH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSH.ForeColor = System.Drawing.Color.DarkBlue;
            this.btSH.Location = new System.Drawing.Point(496, 422);
            this.btSH.Name = "btSH";
            this.btSH.Size = new System.Drawing.Size(88, 28);
            this.btSH.TabIndex = 201;
            this.btSH.Text = "审核(&H)";
            this.btSH.Visible = false;
            this.btSH.Click += new System.EventHandler(this.btSH_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.DarkBlue;
            this.button1.Location = new System.Drawing.Point(592, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 28);
            this.button1.TabIndex = 41;
            this.button1.Text = "退出(&Q)";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bsave
            // 
            this.Bsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bsave.ForeColor = System.Drawing.Color.DarkBlue;
            this.Bsave.Location = new System.Drawing.Point(496, 421);
            this.Bsave.Name = "Bsave";
            this.Bsave.Size = new System.Drawing.Size(88, 28);
            this.Bsave.TabIndex = 40;
            this.Bsave.Text = "保存(&S)";
            this.Bsave.Click += new System.EventHandler(this.Bsave_Click);
            // 
            // chcekbl
            // 
            this.chcekbl.AutoSize = true;
            this.chcekbl.Location = new System.Drawing.Point(87, 452);
            this.chcekbl.Name = "chcekbl";
            this.chcekbl.Size = new System.Drawing.Size(72, 16);
            this.chcekbl.TabIndex = 203;
            this.chcekbl.Text = "补录医嘱";
            this.chcekbl.UseVisualStyleBackColor = true;
            this.chcekbl.CheckedChanged += new System.EventHandler(this.chcekbl_CheckedChanged);
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DtpbeginDate.Enabled = false;
            this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpbeginDate.Location = new System.Drawing.Point(176, 450);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.ShowUpDown = true;
            this.DtpbeginDate.Size = new System.Drawing.Size(164, 21);
            this.DtpbeginDate.TabIndex = 202;
            this.DtpbeginDate.Value = new System.DateTime(2004, 6, 25, 0, 0, 0, 0);
            // 
            // FrmSSApply
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(747, 493);
            this.Controls.Add(this.chcekbl);
            this.Controls.Add(this.DtpbeginDate);
            this.Controls.Add(this.btSH);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Bsave);
            this.Controls.Add(this.checkjzss);
            this.Controls.Add(this.checkmztys);
            this.Controls.Add(this.checksstys);
            this.Name = "FrmSSApply";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手术申请";
            this.Load += new System.EventHandler(this.FrmSSApply_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelnsrqfw.ResumeLayout(false);
            this.panelnsrqfw.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_sel)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region 初始化界面
        private void Fclear()
        {

            this.lblbrxm.Text = "";
            this.lblcwh.Text = "";
            this.lblnl.Text = "";
            this.lblsqdh.Text = "新单号";
            this.lblks.Text = "";
            this.lblbq.Text = "";
            this.lblsqzd.Text = "";
            this.lblsqzd.Tag = 0;
            this.txtzyh.Text = "";
            this.txtzyh.Tag = 0;
            this.txtsg.Text = "";
            this.txttz.Text = "";
            this.txtywgms.Text = "";

            this.txtfz1.Text = "";
            this.txtfz1.Tag = 0;
            this.txtfz2.Text = "";
            this.txtfz2.Tag = 0;
            this.txtfz3.Text = "";
            this.txtfz3.Tag = 0;


            this.chkhbsagy.Checked = false;
            this.chkhbsagx.Checked = false;
            this.chkkhcvy.Checked = false;
            this.chkkhcvx.Checked = false;
            this.chkkhzvy.Checked = false;
            this.chkkhzvx.Checked = false;
            this.chkktpy.Checked = false;
            this.chkktpy.Checked = false;
            this.txtysss.Text = "";
            this.txtysss.Tag = 0;
            this.txtysmz.Text = "";
            this.txtysmz.Tag = 0;
            this.txtsstw.Text = "";
            this.txtsstw.Tag = 0;

            this.txtjsss1.Text = "";
            this.txtjsss1.Tag = 0;
            this.txtjsss2.Text = "";
            this.txtjsss2.Tag = 0;
            this.txtjsss3.Text = "";
            this.txtjsss3.Tag = 0;
            this.txtjsss4.Text = "";
            this.txtjsss4.Tag = 0;

            this.txtzdys.Text = "";
            this.txtzdys.Tag = 0;
            this.txtssyz.Text = "";
            this.txtssyz.Tag = 0;
            this.txtssez.Text = "";
            this.txtssez.Tag = 0;
            this.txtsssz.Text = "";
            this.txtsssz.Tag = 0;
            //			this.dtpysrq.Value=Convert.ToDateTime(PubFunction.sys_date());
            this.dtpyssj.Value = this.dtpysrq.Value;
            //			this.dtpysrq.MaxDate=((int)this.dtpysrq.Value.DayOfWeek)==6? this.dtpysrq.Value.Date.AddDays(3).AddMinutes(-1):this.dtpysrq.Value.Date.AddDays(2).AddMinutes(-1);
            //			this.dtpysrq.MinDate=this.dtpysrq.Value.Date;
            this.txttsqj1.Text = "";
            this.txttsqj1.Tag = 0;
            this.txttsqj2.Text = "";
            this.txttsqj2.Tag = 0;
            this.txttsqj3.Text = "";
            this.txttsqj3.Tag = 0;
            this.txttsqj4.Text = "";
            this.txttsqj4.Tag = 0;
            this.txtysqyy1.Text = "";
            this.txtysqyy1.Tag = 0;
            this.txtysqyy2.Text = "";
            this.txtysqyy2.Tag = 0;
            this.txtysqyy3.Text = "";
            this.txtysqyy3.Tag = 0;
            this.txtysqyy4.Text = "";
            this.txtysqyy4.Tag = 0;
            this.txtbz.Text = "";
            if (lg != 3)
            {
                this.btSH.Visible = false;
                this.Bsave.Visible = true;
            }
            else
            {
                this.btSH.Visible = true;
                this.Bsave.Visible = false;
            }
            //add by zouchihua 2013-8-28
            if (_ck)
            {
                this.btSH.Visible = false;
                this.Bsave.Visible = false;
            }
        }
        #endregion

        #region 回车跳至下一个文本
        private void GotoNext(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                //			 SendKeys.Send("{tab}"); //跳格
                this.SelectNextControl((Control)sender, true, false, true, true);
        }

        #endregion

        #region 保存按扭
        private void Bsave_Click(object sender, System.EventArgs e)
        {
            decimal price = 0;
            string ssname="";
            try
            {
                string strcfg = (new SystemCfg(6014)).Config;
                string strcfg1 = (new SystemCfg(6015)).Config;
                string strcfg2 = (new SystemCfg(6016)).Config;
                string strcfg3 = (new SystemCfg(6017)).Config;
                string cfg6096 = (new SystemCfg(6096)).Config;
                string GetDates = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToShortTimeString();

                DateTime datecfg = Convert.ToDateTime(strcfg);
                DateTime datecfg1 = Convert.ToDateTime(strcfg1);
                DateTime datecfg2 = Convert.ToDateTime(strcfg2);
                DateTime datecfg3 = Convert.ToDateTime(strcfg3);
                DateTime Serverdate = Convert.ToDateTime(GetDates);

              
                string cfg6086 = (new SystemCfg(6086)).Config;

                //			dtpysrqif(!(DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToLongTimeString() == strcfg || DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToLongTimeString() == strcfg1) && checkjzss.Checked==false)
                if (!((DateTime.Compare(datecfg, Serverdate) <= 0 && DateTime.Compare(Serverdate, datecfg1) <= 0) || (DateTime.Compare(datecfg2, Serverdate) <= 0 && DateTime.Compare(Serverdate, datecfg3) <= 0)) && checkjzss.Checked == false)
                {
                    MessageBox.Show("对不起,择期手术必须在每天的上班时间内发送申请！\n如果需要手术申请则选择急诊手术", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

               //yaokx 2013-03-17 择期手术只能提前一天，参数控制
                if(cfg6086 !="" && cfg6092.Config=="0")
                {
                    DateTime dqtime = Convert.ToDateTime(Serverdate.AddDays(Convert.ToInt32(cfg6086)).ToString("yyyy-MM-dd 23:59:59.000"));
                    DateTime date = Convert.ToDateTime(this.dtpysrq.Value.ToString("yyyy-MM-dd 00:00:00.000"));
                    if (date > dqtime)
                    {
                        MessageBox.Show("对不起,只能提前" + cfg6086 + "天开择期手术", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                //Modify By Tany 2010-01-12 手术申请必须在指定时间内完成
                string cfgStr = (new SystemCfg(6010)).Config;
                int sh_hour = 11;
                if (cfgStr != "")
                {
                    sh_hour = Convert.ToInt16(cfgStr);
                    
                }
                if (Serverdate.Hour >= sh_hour && checkjzss.Checked == false)
                {
                    MessageBox.Show("对不起,择期手术必须在每天的" + sh_hour + "点以前发送申请！\n如果需要手术申请则选择急诊手术", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
              //yaokx 手术打折问题  2014-06-07
//                if (cfg6096 != "")
//                {
//                    string sql = @"select * from SS_APPRECORD where INPATIENT_ID='" + this.txtzyh.Tag + "' and BDELETE=0";
//                    DataTable dtcount = FrmMdiMain.Database.GetDataTable(sql);
//                    if (dtcount != null)
//                    {
//                        if (dtcount.Rows.Count >= 2)
//                        {
//                             string tag = txtysss.Tag.ToString();
//                            int ii=0;
//                            string where = "";
//                            if (Int32.TryParse(tag, out ii))
//                            {
//                                if (tag.IndexOf(' ') >= 0)
//                                {
//                                    tag = tag.Remove(tag.IndexOf(' '));
//                                }
//                                where = " t1.ORDER_id=" + tag + "";
//                            }
//                            else
//                            {
//                                where = " t1.ORDER_name='" + tag + "'";
//                            }
//                                string sql1 = @"select t2.RETAIL_PRICE from JC_HOI_HDI t inner join
//                                    JC_HOITEMDICTION t1 on t.HOITEM_ID=t1.ORDER_ID and t1.DELETE_BIT=0
//                                    inner join JC_HSITEMDICTION t2 on t.HDITEM_ID=t2.ITEM_ID  and t2.DELETE_BIT=0
//                                    where t1.DELETE_BIT=0 and t2.DELETE_BIT=0 and t1.ORDER_TYPE=6
//                                    and " + where + "";

//                                DataRow drprice = FrmMdiMain.Database.GetDataRow(sql1);
//                                if (drprice != null)
//                                {
//                                    FrmSect frmSect = new FrmSect();
//                                    frmSect.ShowDialog();
//                                    price = decimal.Parse(drprice["RETAIL_PRICE"].ToString()) * frmSect.selectvaluebl;
//                                }
                              
//                        }
//                    }
//                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace.ToString());
                return;
            }

            if (this.lg == 0 || this.lg == 4) return;
            if (new Guid(this.txtzyh.Tag.ToString()) == Guid.Empty)
            {
                MessageBox.Show("对不起,请先确定病人!", "提示");
                return;
            }

            if (this.txtysss.Text.ToString().Trim() == "")
            {
                MessageBox.Show("手术名称必须填写!", "提示");
                this.txtysss.Focus();
                return;
            }
            //add by zouchihua 手术申请：凝血常规接口是否必须要录入
            if (new SystemCfg(6078).Config.Trim() == "1"&&this.comboBox1.Text.Trim()=="")
            {
                MessageBox.Show("请填写凝血常规结果!", "提示");
                this.comboBox1.Focus();
                return;
            }

            int zdys = 0;
            try
            {
                zdys = Convert.ToInt32(this.txtzdys.Tag.ToString().Trim());
            }
            catch
            {
                zdys = 0;
            }
            if (zdys == 0)
            {
                MessageBox.Show("主刀医生必须填写!", "提示");
                this.txtzdys.Focus();
                return;
            }
            if (this.txtfz1.Text.Trim() == "")
            {
                MessageBox.Show("缺少诊断！", "提示");
                this.txtfz1.Focus();
                return;
            }
            if (cmb_dept.Text.Trim()== "")
            {
                MessageBox.Show("请选择一个手术室！", "提示");
                this.cmb_dept.Focus();
                return;
            }

            if (cfg6071.Config.Trim() == "1" && checkjzss.Checked==false)
            {
                if (chkhbsagy.Checked == false && chkhbsagx.Checked == false)
                {
                    MessageBox.Show("HBsAg没有选择值");
                    //chkhbsagx.Focus();
                    return;
                }
                if (chkkhcvy.Checked == false && chkkhcvx.Checked == false)
                {
                    MessageBox.Show("抗HCV没有选择值");
                    //chkkhcvx.Focus();
                    return;
                }
                if (chkkhzvy.Checked == false && chkkhzvx.Checked == false)
                {
                    MessageBox.Show("抗HIV没有选择值");
                   // chkkhzvx.Focus();
                    return;
                }
                if (chkktpy.Checked == false && chkktpx.Checked == false)
                {
                    MessageBox.Show("抗TP没有选择值");
                    //chkktpx.Focus();
                    return;
                }
            }
            int ssyz = 0;
            try
            {
                 ssyz = Convert.ToInt32(this.txtssyz.Tag.ToString());
            }
            catch
            {
                ssyz = 0;
            }
            if (ssyz == 0)
            {
                if (MessageBox.Show("手术室要求：有助手的必须要写助手！\n你确定没有助手吗？", "提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    this.txtssyz.Focus();
                    return;
                }
            }

            try
            {
                string ssql;
                string hbsag = "";
                string khcv = "";
                string khzv = "";
                string ktp = "";
                int shbj = 0; //是否已审核 ：0未，1已
                if (isHs)
                {
                    shbj = 1;
                }
               
                if (chkhbsagy.Checked == true)
                {
                    hbsag = "阳性";
                }
                if (chkhbsagx.Checked == true)
                {
                    hbsag = "阴性";
                }

                if (this.chkkhcvy.Checked == true)
                {
                    khcv = "阳性";
                }
                if (this.chkkhcvx.Checked == true)
                {
                    khcv = "阴性";
                }

                if (chkkhzvy.Checked == true)
                {
                    khzv = "阳性";
                }
                if (chkkhzvx.Checked == true)
                {
                    khzv = "阴性";
                }

                if (chkktpy.Checked == true)
                {
                    ktp = "阳性";
                }
                if (chkktpx.Checked == true)
                {
                    ktp = "阴性";
                }
                string str="";
                if (this.rbnsrqfw_s.Checked)
                    str = "上午";
                else if (this.rbnsrqfw_x.Checked)
                    str = "下午";
                string date = this.dtpysrq.Value.ToLongDateString() + this.dtpyssj.Value.ToShortTimeString();
                string context = "拟在" + date + this.txtysmz.Text + "下行" + this.txtysss.Text;
                if (cfg6092.Config == "1")
                {
                    context = "拟在" + date + "("+str+")" + this.txtysmz.Text + "下行" + this.txtysss.Text;
                }
                string nxcgjg = "-1";
                if (this.comboBox1.Text.Trim() == "正常")
                {
                    nxcgjg = "1";
                }
                if (this.comboBox1.Text.Trim() == "不正常")
                {
                    nxcgjg = "0";
                }
                FrmMdiMain.Database.BeginTransaction();

                //				if(this.checkjzss.Checked==true) shbj=1;
                if (this.lblsqdh.Text.ToString().Trim() == "新单号")
                {
                    if (this.txtsg.Text.Trim() == "") this.txtsg.Text = "0";
                    if (this.txttz.Text.Trim() == "") this.txttz.Text = "0";

                   
                    string sno;
                    sno = PubFunction.SeekAppNo();
                    Guid order_id = PubStaticFun.NewGuid();//产生临时医嘱id
                    ssql = "insert into ss_apprecord(id,jgbm,sno,inpatient_no,inpatient_id,tz,sg,deptid,hbsag,khcw,khzv,ktp,ssfz,ssfz1,ssfz2,ysssrq,ysss,jsss,jsss1,jsss2,jsss3,ysmz,zdys,ssyz,ssez,sssz," +
                        "sstw,ywgms,ssdept,ssbz,sstys,mztys,jzss,sqdjrq,sqdjczy,tsqj,tsqj1,tsqj2,tsqj3,ysqyy,ysqyy1,ysqyy2,ysqyy3,shbj,ssyz_name,ssez_name,sssz_name,cgz1_name,cgz2_name,cgz3_name,cgz4_name,shys,mzys,MZYS1,APBJ,BDELETE,order_id,jsmz,tsss_flag,nxcg,YSSSRQFW) " +
                        "values('" + TrasenClasses.GeneralClasses.PubStaticFun.NewGuid() + "'," + FrmMdiMain.Jgbm + ",'" + sno.Trim() + "','" + this.txtzyh.Text.Trim() + "','" + txtzyh.Tag + "'," + Convert.ToInt32(Convert.ToDecimal(Convertor.IsNull(txttz.Text.Trim(), "0"))) + "," +
                        " " + Convert.ToInt32(Convert.ToDecimal(Convertor.IsNull(txtsg.Text.Trim(), "0"))) + "," + this.DeptID + ",'" + hbsag.Trim() + "','" + khcv.Trim() + "','" + khzv.Trim() + "'," +
                        " '" + ktp.Trim() + "','" + this.txtfz1.Text.Trim() + "','" + this.txtfz2.Text.Trim() + "','" + this.txtfz3.Text.Trim() + "'," +
                        " '" + this.dtpysrq.Value.ToShortDateString() + " " + this.dtpyssj.Text + "','" + this.txtysss.Text.Trim() + "'," +
                        " '" + this.txtjsss1.Text.Trim() + "','" + this.txtjsss2.Text.Trim() + "','" + this.txtjsss3.Text.Trim() + "'," +
                        " '" + this.txtjsss4.Text.Trim() + "','" + Convertor.IsNull(this.txtysmz.Tag, "0") + "'," + Convert.ToInt32(Convertor.IsNull(this.txtzdys.Tag,"0")) + "," +
                        " " + Convert.ToInt32(Convertor.IsNull(this.txtssyz.Tag,"0")) + "," + Convert.ToInt32( Convertor.IsNull(this.txtssez.Tag,"0")) + "," + Convert.ToInt32( Convertor.IsNull(this.txtsssz.Tag,"0")) + "," +
                        " '" + Convertor.IsNull(this.txtsstw.Tag,"0") + "','" + this.txtywgms.Text.Trim() + "'," + this.cmb_dept.SelectedValue + ",'" + this.txtbz.Text.Trim() + "'," +
                        " " + Convert.ToInt32(this.checksstys.Checked) + "," + Convert.ToInt32(this.checkmztys.Checked) + "," + Convert.ToInt32(this.checkjzss.Checked) + "," +
                        " '" + PubFunction.sys_date() + "'," + PubFunction.AuserEmployeeID + ",'" + this.txttsqj1.Text.ToString().Trim() + "','" + this.txttsqj2.Text.ToString().Trim() + "'," +
                        " '" + this.txttsqj3.Text.ToString().Trim() + "','" + this.txttsqj4.Text.ToString().Trim() + "','" + this.txtysqyy1.Text.ToString().Trim() + "'," +
                        " '" + this.txtysqyy2.Text.ToString().Trim() + "','" + this.txtysqyy3.Text.ToString().Trim() + "','" + this.txtysqyy4.Text.ToString().Trim() + "'," + shbj.ToString() + "," +
                        " '" + this.txtssyz.Text.ToString().Trim() + "','" + this.txtssez.Text.ToString().Trim() + "','" + this.txtsssz.Text.ToString().Trim() + "'," +                                                       //产生的医嘱id
                        " '" + this.txtcgz1.Text.ToString().Trim() + "','" + this.txtcgz2.Text.ToString().Trim() + "','" + this.txtcgz3.Text.ToString().Trim() + "','" + this.txtcgz4.Text.ToString().Trim() + " ',0,0,0,0,0,'" + order_id + "'," + Convertor.IsNull(txtjsmz.Tag, "0") + "," + Convertor.IsNull(this.labssdj.Tag, "0") + "," + nxcgjg + ",'" + str + "')";
                    FrmMdiMain.Database.DoCommand(ssql);

                    //Add By Tany 2007-10-30 重新查询最大组号
                    string grpSql = "select max(group_id)+1 from zy_orderrecord where inpatient_id='" + BinID + "' and baby_id=0 ";
                    _Order_Num = Convert.ToInt64(Convertor.IsNull(FrmMdiMain.Database.GetDataResult(grpSql), "0"));
                    DateTime order_date = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                    string status_flag = "0";
                    //add by zouchihua  手术申请补录
                    if (chcekbl.Checked)
                    {
                        order_date = DtpbeginDate.Value;
                        status_flag = "9";//补录
                    }
                    //插入一条手术申请记录到临时医嘱中去
                    string _ssql = "INSERT INTO ZY_ORDERRECORD(order_id,Group_ID,Inpatient_ID,Dept_ID,Ward_ID,MNGTYPE,Order_Doc,HOItem_ID,xmly,Item_Code,Order_context," +
                                    "book_date,Order_bDate,Operator," +
                                    "baby_id,dept_br,ps_flag,dwlx,ntype,num,EXEC_DEPT,jgbm,memo,STATUS_FLAG,PRICE)" +
                                    "VALUES('" + order_id + "'," + _Order_Num + ",'" + this.BinID + "'," + this.DeptID + ",'" + this.WardID + "',1," + this.YS_ID + ",-1,2,'','" + context.ToString().Trim() + "',GetDate(),'"+order_date+"'," +
                                    "" + this.YS_ID + ",0," + this.DeptID + ",-1,1,7,0," + this.DeptID + "," + FrmMdiMain.Jgbm + ",'手术申请'," + status_flag + "," + price + ")";
                    FrmMdiMain.Database.DoCommand(_ssql);

                    ssql = "insert into ss_log(id,sno,inpatient_no,inpatient_name,sbz,djrq,czy)values('" + PubStaticFun.NewGuid() + "','" + sno.ToString().Trim() + "','" + this.txtzyh.Text.ToString().Trim() + "','" + lblbrxm.Text.ToString().Trim() + "','手术申请登记','" + PubFunction.sys_date() + "'," + PubFunction.AuserEmployeeID + ")";
                    FrmMdiMain.Database.DoCommand(ssql);
                    //Add by zouchihua 2012-10-07 如果是临床路径 
                    if (Iscp==1)
                    {
                        ssql = String.Format(@"insert into path_itemexe(path_itemexe_id,PATHWAY_ID,PATHWAY_EXE_ID,EXE_STEP_ID,PATH_STEP_ID,PATH_STEP_ITEM_ID,delete_bit,note,status_flag,book_date,oprate_id,order_id)  "
                        + " values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',getdate(),{9},'{10}')",
                        new object[] { Guid.NewGuid(), pathway_id, PATHWAY_EXE_ID, EXE_STEP_ID, PATH_STEP_ID, PATH_STEP_ITEM_ID, 0, "", 0, this.YS_ID,order_id });
                        FrmMdiMain.Database.DoCommand(ssql);
                        
                    }
                    FrmMdiMain.Database.CommitTransaction();

                    if (checkjzss.Checked == false)
                    {
                        MessageBox.Show("保存成功！\n请在每天的上班时间内审核手术。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.lblsqdh.Text = sno.Trim();
                    if (checkjzss.Checked == true)
                    {
                        long[] dept = myQuery.GetSSDept();
                        if (dept == null) return;
                        //myQuery.sendMessage(BinID, YS_ID, DeptID, dept, "急诊手术申请", lblbq.Text.Trim() + "病人" + lblbrxm.Text + ":" + "拟施" + txtysss.Text.Trim(), 3, 2);
                        Department msgDept = new Department(Convert.ToInt64(cmb_dept.SelectedValue), FrmMdiMain.Database);
                        string msg_wardid = msgDept.WardId;
                        long msg_deptid = 0;
                        long msg_empid = 0;
                        string msg_sender = FrmMdiMain.CurrentDept.DeptName + "：" + FrmMdiMain.CurrentUser.Name;
                        string msg_msg = lblks.Text + " " + lblbrxm.Text + " 申请急诊手术 " + txtysss.Text + " ，请处理！";
                        TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.手术麻醉, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
                    }
                }
                else
                {
                    if (FrmMessageBox.Show("该手术申请已经保存！你确定要更新吗？", new Font("宋体", 10.5F), Color.Red, "修改申请提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                    ssql = "select * from ss_apprecord where sno='" + this.lblsqdh.Text.Trim() + "' and deptid=" + PubFunction.AuserDeptID + "";
                    DataTable tb = FrmMdiMain.Database.GetDataTable(ssql);
                    if (tb.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(tb.Rows[0]["shbj"].ToString()) == 1)
                        {
                            FrmMessageBox.Show("这个手术已审核，不能修改。", new Font("宋体", 10.5F), Color.Red, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (Convert.ToInt32(tb.Rows[0]["apbj"].ToString()) == 1)
                        {
                            FrmMessageBox.Show("这个手术已安排，不能修改。", new Font("宋体", 10.5F), Color.Red, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    ssql = "update ss_apprecord set " +
                        "tz = " + Convert.ToInt32(Convert.ToDecimal(Convertor.IsNull(txttz.Text.Trim(), "0"))) + "," +
                        "sg = " + Convert.ToInt32(Convert.ToDecimal(Convertor.IsNull(txtsg.Text.Trim(), "0"))) + ",deptid = " + this.DeptID + ",hbsag = '" + hbsag.Trim() + "',khcw = '" + khcv.Trim() + "',khzv = '" + khzv.Trim() + "'," +
                        "ktp = '" + ktp.Trim() + "',ssfz = '" + this.txtfz1.Text.Trim() + "',ssfz1 = '" + this.txtfz2.Text.Trim() + "',ssfz2 = '" + this.txtfz3.Text.Trim() + "'," +
                        "ysssrq = '" + this.dtpysrq.Value.ToShortDateString() + " " + this.dtpyssj.Value.ToLongTimeString() + "',ysss = '" + this.txtysss.Text.Trim() + "'," +
                        "jsss = '" + this.txtjsss1.Text.Trim() + "',jsss1 = '" + this.txtjsss2.Text.Trim() + "',jsss2 = '" + this.txtjsss3.Text.Trim() + "'," +
                        "jsss3 = '" + this.txtjsss4.Text.Trim() + "',ysmz = '" + this.txtysmz.Tag.ToString().Trim() + "',zdys = " + Convert.ToInt32(this.txtzdys.Tag.ToString().Trim()) + "," +
                        "ssyz = " + Convert.ToInt32(this.txtssyz.Tag.ToString().Trim()) + ",ssez = " + Convert.ToInt32(this.txtssez.Tag.ToString().Trim()) + ",sssz = " + Convert.ToInt32(this.txtsssz.Tag.ToString().Trim()) + "," +
                        "sstw = '" + this.txtsstw.Tag.ToString().Trim() + "',ywgms = '" + this.txtywgms.Text.Trim() + "',ssdept = " + this.cmb_dept.SelectedValue + ",ssbz = '" + this.txtbz.Text.Trim() + "'," +
                        "sstys = " + Convert.ToInt32(this.checksstys.Checked) + ",mztys = " + Convert.ToInt32(this.checkmztys.Checked) + ",jzss = " + Convert.ToInt32(this.checkjzss.Checked) + "," +
                        "tsqj = '" + this.txttsqj1.Text.ToString().Trim() + "',tsqj1 = '" + this.txttsqj2.Text.ToString().Trim() + "'," +
                        "tsqj2 = '" + this.txttsqj3.Text.ToString().Trim() + "',tsqj3 = '" + this.txttsqj4.Text.ToString().Trim() + "',ysqyy = '" + this.txtysqyy1.Text.ToString().Trim() + "'," +
                        "ysqyy1 = '" + this.txtysqyy2.Text.ToString().Trim() + "',ysqyy2 = '" + this.txtysqyy3.Text.ToString().Trim() + "',ysqyy3 = '" + this.txtysqyy4.Text.ToString().Trim() + "'," +
                        "shbj = " + shbj.ToString() + ",ssyz_name = '" + this.txtssyz.Text.ToString().Trim() + "',ssez_name = '" + this.txtssez.Text.ToString().Trim() + "',sssz_name = '" + this.txtsssz.Text.ToString().Trim() + "'," +
                        "cgz1_name = '" + this.txtcgz1.Text.ToString().Trim() + "',cgz2_name = '" + this.txtcgz2.Text.ToString().Trim() + "',cgz3_name = '" + this.txtcgz3.Text.ToString().Trim() + "',cgz4_name = '" + this.txtcgz4.Text.ToString().Trim() + "',tsss_flag=" + Convertor.IsNull(this.labssdj.Tag, "0") + ",nxcg=" + nxcgjg + ",YSSSRQFW='" + str +"'"+
                        "where sno='" + this.lblsqdh.Text.Trim() + "' and deptid=" + this.DeptID + "";
                    FrmMdiMain.Database.DoCommand(ssql);

                    //Add By Tany 2007-10-30 重新查询最大组号
                    string grpSql = "select max(group_id)+1 from zy_orderrecord where inpatient_id='" + BinID + "' and baby_id=0 ";
                    _Order_Num = Convert.ToInt64(Convertor.IsNull(FrmMdiMain.Database.GetDataResult(grpSql), "0"));

                    //更新临时医嘱中一条已经申请的手术记录 Modify by zouchihua 2013-10-18 以前这里有一个很大漏洞。ntype=6会更改手术室记账的的医嘱，现在该为ntype=7
                    string _ssql = "UPDATE ZY_ORDERRECORD SET Group_ID = " + _Order_Num + ",Inpatient_ID = '" + this.BinID + "',Dept_ID = " + this.DeptID + ",Ward_ID = '" + this.WardID + "',MNGTYPE = 1,Order_Doc = " + this.YS_ID + ",HOItem_ID = -1," +
                        "Item_Code = '',Order_context = '" + context.ToString().Trim() + "',book_date = GetDate(),Order_bDate = GetDate(),Operator = " + this.YS_ID + "," +
                        "baby_id = 0,dept_br = " + this.DeptID + ",ps_flag = -1,dwlx = 1,ntype = 7,num = 0,exec_dept = " + this.DeptID + " ,PRICE="+price+" WHERE inpatient_id = '" + this.BinID + "' and baby_id=0 AND ntype = 7 and delete_bit=0 " +
                        "and order_id=(select top 1 order_id from ZY_ORDERRECORD where inpatient_id = '" + this.BinID + "' and baby_id=0 AND ntype = 7 and delete_bit=0 and memo='手术申请' order by order_bdate desc)";//最后一条手术医嘱
                    FrmMdiMain.Database.DoCommand(_ssql);

                    ssql = "insert into ss_log(id,sno,inpatient_no,inpatient_name,sbz,djrq,czy)values('" + PubStaticFun.NewGuid() + "','" + this.lblsqdh.Text.ToString().Trim() + "','" + this.txtzyh.Text.ToString().Trim() + "','" + lblbrxm.Text.ToString().Trim() + "','手术申请修改','" + PubFunction.sys_date() + "'," + PubFunction.AuserEmployeeID + ")";
                    FrmMdiMain.Database.DoCommand(ssql);

                    FrmMdiMain.Database.CommitTransaction();

                    if (checkjzss.Checked == false)
                    {
                        MessageBox.Show("更新成功！\n请在每天的上班时间内审核手术。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("更新成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.Close();
            }
            catch (System.Exception err)
            {
                FrmMdiMain.Database.RollbackTransaction();
                MessageBox.Show(err.Message + err.Source);
            }
        }

        #endregion

        #region Load
        private void FrmSSApply_Load(object sender, System.EventArgs e)
        {
            if (_ck)
            {
                this.btSH.Visible = false;
                this.Bsave.Visible = false;
            }

            if (cfg6092.Config == "1")
            {
                this.panelnsrqfw.Visible = true;
            }
            string cfgStr = (new SystemCfg(6004, FrmMdiMain.Database)).Config;
            int cfg = 24;
            DtpbeginDate.MaxDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            DtpbeginDate.MinDate = DtpbeginDate.MaxDate.AddHours(-cfg);
            //Add by zouchihua 2012-04-22 判断补录日期不能小于上次转科日期
            string mysql = "select * from ZY_INPATIENT where  INPATIENT_ID='" + this.BinID + "' ";
            DataTable TransTb = FrmMdiMain.Database.GetDataTable(mysql);
            if (TransTb != null && TransTb.Rows.Count > 0)
            {
                DtpbeginDate.MinDate = Convert.ToDateTime(TransTb.Rows[0]["in_date"].ToString());
            }
            DtpbeginDate.Value = DtpbeginDate.MaxDate;
            //Add by zouchihua 2012-04-22 判断补录日期不能小于上次转科日期
            mysql = "select * from ZY_TRANSFER_DEPT where  FINISH_BIT=1 and INPATIENT_ID='" + this.BinID + "' and  cancel_bit=0   order by TRANSFER_DATE desc";
            TransTb.Clear();
            TransTb = FrmMdiMain.Database.GetDataTable(mysql);
            if (TransTb != null && TransTb.Rows.Count > 0)
            {
                DtpbeginDate.MinDate = Convert.ToDateTime(TransTb.Rows[0]["TRANSFER_DATE"].ToString());
            }
            DtpbeginDate.Value = DtpbeginDate.MaxDate;

            PubFunction.AuserDeptID = Convert.ToInt32(this.DeptID);
            PubFunction.AuserEmployeeID = Convert.ToInt32(this.YS_ID);
            this.Fclear();

            this.cmb_dept.Items.Clear();
            this.cmb_dept.DisplayMember = "NAME";
            this.cmb_dept.ValueMember = "DEPTID";
            this.cmb_dept.DataSource = PubFunction.SSDept(0);

            SystemCfg cfg6043 = new SystemCfg(6043);
            if (cfg6043.Config.Trim() == "0")
                chcekbl.Visible = false;

            if (this.BinID != Guid.Empty) InBin();

            if (Iscp == 1)
            {
                this.txtysss.Text = ysss;
                this.txtysss.Tag = ysssid;
            }
            //Modify By tany 2011-04-30 填充数据放在病人数据之后
            FillApp();

        }

        #endregion

        #region 进入相应的代码选择窗口
        private void TextKeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyCode) >= 65 & Convert.ToInt32(e.KeyCode) <= 90)
            {
                Control control = (Control)sender;
                int TypeID = 0;
                switch (control.TabIndex)
                {
                    case 4://诊断类代码
                    case 5:
                    case 6:
                        TypeID = Convert.ToInt32(PubFunction.CodyType.Diagnose);
                        break;
                    case 15://手术代码
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                        TypeID = Convert.ToInt32(PubFunction.CodyType.Operate);
                        break;
                    case 12://手术等级
                        TypeID = Convert.ToInt32(PubFunction.CodyType.OperateRate);
                        break;
                    case 16:  //麻醉名称
                        TypeID = Convert.ToInt32(PubFunction.CodyType.Anesthesia);
                        break;
                    case 17://体位
                        TypeID = Convert.ToInt32(PubFunction.CodyType.OperateBody);
                        break;
                    case 22://主刀医生助手
                    case 23:
                    case 24:
                    case 25:
                        TypeID = Convert.ToInt32(PubFunction.CodyType.OperateDoctor);
                        break;
                    case 28://特殊器械
                    case 29:
                    case 30:
                    case 31:
                        TypeID = Convert.ToInt32(PubFunction.CodyType.Appliance);
                        break;
                    case 32://拟术前用药
                    case 33:
                    case 34:
                    case 35:
                        TypeID = Convert.ToInt32(PubFunction.CodyType.UserDrug);
                        break;
                    default:
                        return;
                }
                //				Fbasesearch f=new Fbasesearch();
                //				f.Search=Convert.ToString(e.KeyCode);
                //				f.control=control;
                //				f.TypeID=TypeID;
                //				try
                //				{
                //					f.ShowDialog();
                //				}
                //				catch(System.Exception err)
                //				{
                //					MessageBox.Show(err.Message);
                //				}
                DataRow dr = GetDate(((char)e.KeyValue).ToString(), TypeID);
                control.Text = dr["名称"].ToString().Trim();
                control.Tag = dr["code"];
                this.SelectNextControl((Control)sender, true, false, true, true);
            }
        }

        private DataRow GetDate(string dm, int typeID)
        {
            string[] GrdMappingName ={ "code", "名称", "拼音码", "五笔码", "数字码" };
            int[] GrdWidth ={ 0, 90, 50, 50, 50 };
            string[] sfield ={ "wbm", "pym", "code", "name", "" };
            string sSql = "select code,name 名称,pym 拼音码,wbm 五笔码 ,code 数字码 from vi_ss_vCALIBRATECODE where typeid=" + typeID.ToString() + " ";
            Fshowcard fks = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.智能, dm, sSql);
            fks.StartPosition = FormStartPosition.CenterScreen;
            fks.ShowDialog();
            return fks.dataRow;
        }

        private void txt_Enter(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            _curActiveTextBox = control;
            int TypeID = 0;
            string _pyname = "";
            string sSql = "";
            if (control.Name == "txtjsmz")
                control.TabIndex = 16;
            switch (control.TabIndex)
            {
                case 4://诊断类代码
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Diagnose);
                    _pyname = txtfz1.Text.ToString().Trim();
                    break;
                case 5:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Diagnose);
                    _pyname = txtfz2.Text.ToString().Trim();
                    break;
                case 6:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Diagnose);
                    _pyname = txtfz3.Text.ToString().Trim();
                    break;
                case 15://手术代码
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Operate);
                    _pyname = txtysss.Text.ToString().Trim();
                    break;
                case 18:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Operate);
                    _pyname = txtjsss1.Text.ToString().Trim();
                    break;
                case 19:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Operate);
                    _pyname = txtjsss2.Text.ToString().Trim();
                    break;
                case 20:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Operate);
                    _pyname = txtjsss3.Text.ToString().Trim();
                    break;
                case 21:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Operate);
                    _pyname = txtjsss4.Text.ToString().Trim();
                    break;
                case 12://手术等级
                    TypeID = Convert.ToInt32(PubFunction.CodyType.OperateRate);
                    break;
                case 16:  //麻醉名称
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Anesthesia);
                    _pyname = control.Text.ToString().Trim();
                    break;
                case 17://体位
                    TypeID = Convert.ToInt32(PubFunction.CodyType.OperateBody);
                    _pyname = txtsstw.Text.ToString().Trim();
                    break;
                case 22://主刀医生助手
                    TypeID = Convert.ToInt32(PubFunction.CodyType.OperateDoctor);
                    _pyname = txtzdys.Text.ToString().Trim();
                    break;
                case 23:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.OperateDoctor);
                    _pyname = txtssyz.Text.ToString().Trim();
                    break;
                case 24:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.OperateDoctor);
                    _pyname = txtssez.Text.ToString().Trim();
                    break;
                case 25:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.OperateDoctor);
                    _pyname = txtsssz.Text.ToString().Trim();
                    break;
                case 37:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.OperateDoctor);
                    _pyname = txtcgz1.Text.ToString().Trim();
                    break;
                case 38:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.OperateDoctor);
                    _pyname = txtcgz2.Text.ToString().Trim();
                    break;
                case 39:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.OperateDoctor);
                    _pyname = txtcgz3.Text.ToString().Trim();
                    break;
                case 40:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.OperateDoctor);
                    _pyname = txtcgz4.Text.ToString().Trim();
                    break;
                case 28://特殊器械
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Appliance);
                    _pyname = txttsqj1.Text.ToString().Trim();
                    break;
                case 29:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Appliance);
                    _pyname = txttsqj2.Text.ToString().Trim();
                    break;
                case 30:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Appliance);
                    _pyname = txttsqj3.Text.ToString().Trim();
                    break;
                case 31:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.Appliance);
                    _pyname = txttsqj4.Text.ToString().Trim();
                    break;
                case 32://拟术前用药
                    TypeID = Convert.ToInt32(PubFunction.CodyType.UserDrug);
                    _pyname = txtysqyy1.Text.ToString().Trim();
                    break;
                case 33:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.UserDrug);
                    _pyname = txtysqyy2.Text.ToString().Trim();
                    break;
                case 34:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.UserDrug);
                    _pyname = txtysqyy3.Text.ToString().Trim();
                    break;
                case 35:
                    TypeID = Convert.ToInt32(PubFunction.CodyType.UserDrug);
                    _pyname = txtysqyy4.Text.ToString().Trim();
                    break;
                default:
                    return;
            }
            if ((control as TextBox).Name == "txtjsmz")
                control.TabIndex = 17;
            if (_pyname == "")
            {
                sSql = "select top 50 0 ROWNO, name NAME,pym PY_CODE,wbm WB_CODE,code D_CODE from vi_ss_vCALIBRATECODE where typeid=" + TypeID.ToString() + " order by len(pym) ";
            }
            else
                sSql = "select top 20 0 ROWNO, name NAME,pym PY_CODE,wbm WB_CODE,code D_CODE from vi_ss_vCALIBRATECODE where typeid=" + TypeID.ToString() + " and (pym like '" + _pyname + "%' or  wbm like '"+_pyname+"%' ) order by len(pym) ";//Modify by zouchihua 增加了对五笔码的检索 2012-2-24
            DataTable myTb = FrmMdiMain.Database.GetDataTable(sSql);
            myTb.TableName = "seltb";
            //			SelectView = new DataView(myTb.Copy());
            ds.Tables.Clear();
            ds.Tables.Add(myTb);
        }

        private void txt_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                TextBox tb = (TextBox)sender;
                if (e.KeyValue == 13 && this.dGrid_sel.Focus() == false)//.CurrentRowIndex<=0 ) 
                {
                    this.SelectNextControl((Control)sender, true, false, true, true);
                    return;
                }
                if (this.dGrid_sel.VisibleRowCount > 0)
                {
                    if (e.KeyCode == Keys.Down)
                    {
                        this.dGrid_sel.CurrentRowIndex += 1;
                        this.dGrid_sel.Select(this.dGrid_sel.CurrentRowIndex);
                        return;
                    }
                    if (e.KeyCode == Keys.Up)
                    {
                        if (this.dGrid_sel.CurrentRowIndex == 0) return;
                        this.dGrid_sel.CurrentRowIndex -= 1;
                        //				if(this.dGrid_sel.CurrentRowIndex)
                        return;
                    }
                }
                Cursor = PubStaticFun.WaitCursor();
                txt_Enter(sender, e);
                txt_KeyDow(sender, e);
                if (ssflag == 1)
                {
                    txtysss.Focus();
                    Cursor = Cursors.Default;
                    e.Handled = true;
                    return;
                }
                if (e.KeyValue == 13 && this.dGrid_sel.Focus() == false)//.CurrentRowIndex<=0 ) 
                {

                    this.SelectNextControl((Control)sender, true, false, true, true);
                }

                Cursor = Cursors.Default;
            }
            catch 
            {
                 if(e.KeyValue == 13)
                this.SelectNextControl((Control)sender, true, false, true, true);
            }
        }
        int ssflag = 0;
        private void txt_KeyDow(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            bool respondKey = true;
            ssflag = 0;
            DataRow dr = WorkStaticFun.GetCardData(tb, e.KeyValue, 1, dGrid_sel, 0, ds, "seltb", FilterType.智能, SearchType.前导相似, ref respondKey, "", "");
            if (dr != null && respondKey)
            {
               
                //增加手术等级设置
                if (tb.Name == "txtysss")
                {
                    string sql = " select b.NAME,a.bz,b.id,isnull(tsss,0) tsss from JC_HOITEMDICTIONForss a  join SS_OPERATERATE b on a.operaterateid=b.ID where a.order_id=" + dr["D_CODE"] + "";
                    DataTable temp = InstanceForm._database.GetDataTable(sql);
                    if (temp.Rows.Count > 0)
                    {
                        //说明有手术等级
                        //if (cfg6071.Config.Trim() == "1")
                        //{
                        //    Doctor doctor = new Doctor(long.Parse(InstanceForm._currentUser.EmployeeId.ToString()), InstanceForm._database);
                        //    if (doctor.OperateRate_Type == 0 || doctor.OperateRate_Type < long.Parse(temp.Rows[0]["id"].ToString()))
                        //    {
                        //        tb.Text = "";
                        //        MessageBox.Show("你没有申请【" + temp.Rows[0]["name"].ToString() + "】的权限，请联系管理员");
                        //        return;
                        //    }

                        //}
                        this.labssdj.Text = temp.Rows[0]["name"].ToString();
                        this.labssdj.Tag = temp.Rows[0]["tsss"].ToString();//特殊手术标志
                        if (temp.Rows[0]["bz"].ToString().Trim()!="")
                             MessageBox.Show("备注提示：\r\n" + temp.Rows[0]["bz"].ToString());

                    }
                    
                }
                //判断主刀医生
                if (tb.Name == "txtzdys")
                {
                    if (cfg6071.Config.Trim() == "1")
                    {
                        if (txtysss.Text.Trim() == "")
                        {
                            MessageBox.Show("请先填写拟施手术！！");
                            tb.Text = "";
                            txtysss.Focus();
                            ssflag = 1;
                            e.Handled = true;
                            return;
                        }
                        string sql = " select b.NAME,a.bz,b.id from JC_HOITEMDICTIONForss a  join SS_OPERATERATE b on a.operaterateid=b.ID where a.order_id=" + txtysss.Tag.ToString() + "";
                        DataTable temp = InstanceForm._database.GetDataTable(sql);
                        if (temp.Rows.Count > 0)
                        {
                            //说明有手术等级
                            Doctor doctor = new Doctor(long.Parse(dr["D_CODE"].ToString()), InstanceForm._database);
                            if (doctor.OperateRate_Type == 0 || doctor.OperateRate_Type < long.Parse(temp.Rows[0]["id"].ToString()))
                            {
                                tb.Text = "";
                                MessageBox.Show("你没有申请【" + temp.Rows[0]["name"].ToString() + "】的权限，请联系管理员");
                                return;
                            }

                        }
                    }
                }
                 
                tb.Text = dr["NAME"].ToString().Trim();
                tb.Tag = dr["D_CODE"];
               
            }
        }

        private void dGrid_CurrentCellChanged(object sender, System.EventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            for (int i = 0; i < ((DataTable)grid.DataSource).Rows.Count; i++)
            {
                grid.UnSelect(i);
            }
            grid.Select(grid.CurrentCell.RowNumber);
        }
        private void dGrid_sel_DoubleClick(object sender, System.EventArgs e)
        {
            if (_curActiveTextBox != null)
            {
                _curActiveTextBox.Focus();
                txt_KeyDow(_curActiveTextBox, new KeyEventArgs(Keys.Enter));
            }
        }
        private void dGrid_sel_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dGrid_sel_DoubleClick(null, null);
            }
        }
        #endregion

        #region 住院号回车事件
        private void txtzyh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            InBin();
        }
        #endregion

        #region 初始病人信息
        private void InBin()
        {
            Inpatient Inpt = new Inpatient(this.BinID);
            Patient pt = new Patient(Inpt.PatientID);
            txtzyh.Text = Inpt.InpatientNo.Trim();
            string szyh;
            szyh = "";
            if (txtzyh.Text.Length < 8)
            {
                for (int i = 0; i < 8 - txtzyh.Text.Length; i++)
                {
                    szyh = szyh + "0";
                }
                txtzyh.Text = szyh + txtzyh.Text;
            }
            //			DataTable Tbpatient=new DataTable();
            //			Tbpatient=PubFunction.SeekPatient(txtzyh.Text.ToString().Trim());
            //			if (Tbpatient.Rows.Count==0) 
            //			{
            //				MessageBox.Show("没有找到病人");
            //				return;
            //			}
            if (Inpt.Flag == 2 || Inpt.Flag >= 4)
            {
                MessageBox.Show("注意，该病人已经是出院病人，不允许再申请手术！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Inpt.DischargeType == DischargeMode.Insure_DischargeMode)
                this.lblbrxm.ForeColor = Color.Red;
            else
                this.lblbrxm.ForeColor = Color.Blue;
            this.lblbrxm.Text = pt.Name.Trim();
            //			lblcwh.Text=Inpt.Bed_ID<=0 ? "" : Inpt.Bed_ID.ToString();
            lblcwh.Text = myQuery.GetBedNO(Inpt.Bed_ID);
            //			this.lblks.Text=PubFunction.SeekDeptName(Convert.ToInt32(Inpt.KSBH));
            this.lblks.Text = PubFunction.SeekDeptName(Convert.ToInt32(this.DeptID));
            //			this.lblks.Tag=Inpt.KSBH;
            this.lblks.Tag = this.DeptID;
            //			this.lblbq.Text=this.lblks.Text;
            this.lblbq.Text = this.WardID;
            this.lblbq.Tag = this.lblbq.Tag;
            this.lblxb.Text = (pt.Sex.ToString() == "1") ? "男" : "女";
            this.lblnl.Text = Convert.ToString(System.DateTime.Now.Year - pt.Birthday.Year);
            //Modify By tany 2011-04-30
            this.lblsqzd.Text = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select ryzd from vi_zy_vinpatient_all where baby_id=0 and inpatient_id='" + Inpt.InpatientID + "'"), "");
            this.txtzyh.Tag = this.BinID.ToString();
            if (this.txtfz1.Text.Trim() == "") this.txtfz1.Text = this.lblsqzd.Text.Trim();
        }
        #endregion

        #region 填充数据
        public void FillApp()
        {
            try
            {
                Operate s = new Operate();
                string ssql = "SELECT distinct sno,inpatient_no  FROM SS_APPRECORD WHERE (bdelete = 0) AND (inpatient_id = '" + this.BinID.ToString() + "') AND (apbj = 0) AND SNO !=''";
                DataTable myTb = FrmMdiMain.Database.GetDataTable(ssql);
                if (myTb.Rows.Count == 0)
                {
                    //Modify By Tany 2011-04-30
                    //增加对EMR信息的调用
                    try
                    {
                        if (this.txtfz1.Text.Trim() == "")
                        {
                            object[] objs = EmrVSHISInterface.HisInterface.GetMrDiagnoseOrContent(BinID.ToString());
                            //MessageBox.Show(Convertor.IsNull(objs[0], ""));
                            this.txtfz1.Text = Convertor.IsNull(objs[0], "");
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    } 
                    return;
                }
                this.chcekbl.Enabled = false;
                this.sNo = myTb.Rows[0]["sno"].ToString();
                DataTable Tb = new DataTable();
                Tb = s.SeekAppRecord(this.sNo.Trim(), myTb.Rows[0]["inpatient_no"].ToString().Trim());
                if (Tb.Rows.Count > 0)
                {
                    //					DataTable Tinpatient=new DataTable();
                    //					Tinpatient=PubFunction.SeekPatient(Convert.ToInt64(Tb.Rows[0]["inpatient_id"]));
                    //					if (Tinpatient.Rows.Count==0)
                    //					{
                    //						MessageBox.Show("没有找到病人");
                    //					}
                    this.lblsqdh.Text = Tb.Rows[0]["sno"].ToString().Trim();
                    //					this.lblbrxm.Text=Tinpatient.Rows[0]["name"].ToString().Trim();
                    //                    this.lblcwh.Text=PubFunction.SeekBedNo(Convert.ToInt32(Tinpatient.Rows[0]["BED_ID"].ToString()));
                    //					this.lblxb.Text=PubFunction.SeekSexName(Convert.ToInt32(Tinpatient.Rows[0]["sex"].ToString()));
                    //
                    //					this.lblks.Text=PubFunction.SeekDeptName(Convert.ToInt32(Tinpatient.Rows[0]["dept_id"].ToString().Trim()));
                    //					this.lblbq.Text=PubFunction.SeekDeptName(Convert.ToInt32(Tinpatient.Rows[0]["dept_id"].ToString().Trim()));
                    //					this.lblsqdh.Text =PubFunction.SeekCalibrateName("",Convert.ToInt32(PubFunction.CodyType.Diagnose));

                    this.txtzyh.Text = Tb.Rows[0]["inpatient_no"].ToString().Trim();
                    this.txtsg.Text = Tb.Rows[0]["sg"].ToString().Trim();
                    this.txttz.Text = Tb.Rows[0]["tz"].ToString().Trim();
                    this.txtywgms.Text = Tb.Rows[0]["ywgms"].ToString().Trim();
                    this.txtfz1.Tag = Tb.Rows[0]["ssfz"].ToString().Trim();
                    this.txtfz1.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ssfz"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Diagnose));
                    this.txtfz2.Tag = Tb.Rows[0]["ssfz"].ToString().Trim();
                    this.txtfz2.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ssfz1"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Diagnose));
                    this.txtfz3.Tag = Tb.Rows[0]["ssfz"].ToString().Trim();
                    this.txtfz3.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ssfz2"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Diagnose));
                    if (Tb.Rows[0]["YSSSRQFW"].ToString().Trim() != "")
                    {
                        if (Tb.Rows[0]["YSSSRQFW"].ToString().Trim() == "上午")
                        {
                            this.rbnsrqfw_s.Checked = true;
                        }
                        else
                        {
                            this.rbnsrqfw_x.Checked = true;
                        }
                    }
                    if (Tb.Rows[0]["hbsag"].ToString().Trim() == "阳性")
                    {
                        this.chkhbsagy.Checked = true;
                    }
                    else
                    {
                        this.chkhbsagx.Checked = true;
                    }

                    if (Tb.Rows[0]["KHCW"].ToString().Trim() == "阳性")
                    {
                        this.chkkhcvy.Checked = true;
                    }
                    else
                    {
                        this.chkkhcvx.Checked = true;
                    }

                    if (Tb.Rows[0]["KHZV"].ToString().Trim() == "阳性")
                    {
                        this.chkkhzvy.Checked = true;
                    }
                    else
                    {
                        this.chkkhzvx.Checked = true;
                    }

                    if (Tb.Rows[0]["KTP"].ToString().Trim() == "阳性")
                    {
                        this.chkktpy.Checked = true;
                    }
                    else
                    {
                        this.chkktpx.Checked = true;
                    }

                    this.txtysss.Tag = Tb.Rows[0]["ysss"].ToString().Trim();
                    this.txtysss.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ysss"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Operate));
                    this.txtysmz.Tag = Tb.Rows[0]["ysmz"].ToString().Trim();
                    this.txtysmz.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ysmz"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Anesthesia));
                    this.txtsstw.Tag = Tb.Rows[0]["sstw"].ToString().Trim();
                    this.txtsstw.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["sstw"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.OperateBody));
                    this.txtjsss1.Tag = Tb.Rows[0]["jsss"].ToString().Trim();
                    this.txtjsss1.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["jsss"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Operate));
                    this.txtjsss2.Tag = Tb.Rows[0]["jsss1"].ToString().Trim();
                    this.txtjsss2.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["jsss1"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Operate));
                    this.txtjsss3.Tag = Tb.Rows[0]["jsss2"].ToString().Trim();
                    this.txtjsss3.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["jsss2"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Operate));
                    this.txtjsss4.Tag = Tb.Rows[0]["jsss3"].ToString().Trim();
                    this.txtjsss4.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["jsss3"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Operate));
                    this.txtzdys.Tag = Tb.Rows[0]["zdys"].ToString().Trim();
                    this.txtzdys.Text = PubFunction.SeekEmployeeName(Convert.ToInt32(Tb.Rows[0]["zdys"].ToString().Trim()));
                    this.txtssyz.Tag = Tb.Rows[0]["ssyz"].ToString().Trim();
                    this.txtssyz.Text = Tb.Rows[0]["ssyz_name"].ToString().Trim();//PubFunction.SeekEmployeeName(Convert.ToInt32(Tb.Rows[0]["ssyz"].ToString().Trim()));
                    this.txtssez.Tag = Tb.Rows[0]["ssez"].ToString().Trim();
                    this.txtssez.Text = Tb.Rows[0]["ssez_name"].ToString().Trim();//PubFunction.SeekEmployeeName(Convert.ToInt32(Tb.Rows[0]["ssez"].ToString().Trim()));
                    this.txtsssz.Tag = Tb.Rows[0]["sssz"].ToString().Trim();
                    this.txtsssz.Text = Tb.Rows[0]["sssz_name"].ToString().Trim();//PubFunction.SeekEmployeeName(Convert.ToInt32(Tb.Rows[0]["sssz"].ToString().Trim()));
                    this.txttsqj1.Text = Tb.Rows[0]["tsqj"].ToString().Trim();
                    this.txttsqj2.Text = Tb.Rows[0]["tsqj1"].ToString().Trim();
                    this.txttsqj3.Text = Tb.Rows[0]["tsqj2"].ToString().Trim();
                    this.txttsqj4.Text = Tb.Rows[0]["tsqj3"].ToString().Trim();
                    this.txtysqyy1.Text = Tb.Rows[0]["ysqyy"].ToString().Trim();
                    this.txtysqyy2.Text = Tb.Rows[0]["ysqyy1"].ToString().Trim();
                    this.txtysqyy3.Text = Tb.Rows[0]["ysqyy2"].ToString().Trim();
                    this.txtysqyy4.Text = Tb.Rows[0]["ysqyy3"].ToString().Trim();
                    this.txtbz.Text = Tb.Rows[0]["ssbz"].ToString().Trim();
                    this.txtcgz1.Text = Tb.Rows[0]["cgz1_name"].ToString().Trim();
                    this.txtcgz2.Text = Tb.Rows[0]["cgz2_name"].ToString().Trim();
                    this.txtcgz3.Text = Tb.Rows[0]["cgz3_name"].ToString().Trim();
                    this.txtcgz4.Text = Tb.Rows[0]["cgz4_name"].ToString().Trim();
                    this.checksstys.Checked = Convert.ToBoolean(Convert.ToInt32(Tb.Rows[0]["sstys"].ToString().Trim()));
                    this.checkmztys.Checked = Convert.ToBoolean(Convert.ToInt32(Tb.Rows[0]["mztys"].ToString().Trim()));
                    this.checkjzss.Checked = Convert.ToBoolean(Convert.ToInt32(Tb.Rows[0]["jzss"].ToString().Trim()));

                    //					this.dtpysrq.Value=Convert.ToDateTime(Convertor.IsNull(Tb.Rows[0]["YSSSRQ"],"00:00:00"));
                    //					this.dtpyssj.Value=Convert.ToDateTime(Convertor.IsNull(Tb.Rows[0]["YSSSRQ"],"00:00:00"));

                    this.dtpysrq.Value = Convert.ToDateTime(Tb.Rows[0]["YSSSRQ"].ToString());
                    this.dtpyssj.Value = Convert.ToDateTime(Tb.Rows[0]["YSSSRQ"].ToString());
                    for (int i = this.cmb_dept.Items.Count - 1; i >= 0; i--)
                    {
                        this.cmb_dept.SelectedIndex = i;
                        string str = this.cmb_dept.SelectedValue.ToString();
                        if (str == Tb.Rows[0]["ssdept"].ToString())
                        {
                            break;
                        }
                    }
                    //add by zouchihua 2013-8-27
                    this.labssdj.Tag = Tb.Rows[0]["tsss_flag"].ToString().Trim();
                    if (Tb.Rows[0]["nxcg"].ToString().Trim() == "1")
                        this.comboBox1.SelectedIndex = 1;
                    if (Tb.Rows[0]["nxcg"].ToString().Trim() == "0")
                        this.comboBox1.SelectedIndex = 2;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message + err.StackTrace.ToString());
            }
        }
        #endregion

        #region 丢失焦点事件
        private void TextLostFocus(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }
            //			if (control.Tag.ToString().Trim()=="") return;
            //			switch(control.TabIndex)
            //			{
            //				case 4://诊断类代码
            //				case 5:
            //				case 6:
            ////					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.Diagnose));
            //					break;
            //				case 15://手术代码
            //				case 18:
            //				case 19:
            //				case 20:
            //				case 21:
            ////					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.Operate));
            //					break;
            //				case 12://手术等级
            //					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.OperateRate));
            //					break;		
            //				case 16:  //麻醉名称
            //					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.Anesthesia ));
            //					break;						
            //				case 17://体位
            //					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.OperateBody ));
            //					break;	
            //				case 22://主刀医生助手
            //				case 23:
            //				case 24:
            //				case 25:
            //					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.OperateDoctor ));
            //					break;
            //				case 28://特殊器械
            //				case 29:
            //				case 30:
            //				case 31:
            //					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.Appliance));
            //					break;
            //				case 32://拟术前用药
            //				case 33:
            //				case 34:
            //				case 35:
            //					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.UserDrug));
            //					break;
            //				default:
            //					return;
            //			}
        }
        #endregion

        private void CheckChanged(object sender, System.EventArgs e)
        {
            System.Windows.Forms.CheckBox control = (System.Windows.Forms.CheckBox)sender;
            if (control.Checked == true)
            {
                control.ForeColor = Color.Blue; //SystemBrushes.InactiveBorder;
            }
            else
            {
                control.ForeColor = Color.Gray;//SystemBrushes.HotTrack;
            }
        }
        private void txtzyh_Enter(object sender, System.EventArgs e)
        {
            SendKeys.Send("{tab}");
        }

        #region 关闭窗口
        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 审核申请
        private void btSH_Click(object sender, System.EventArgs e)
        {
            if (this.lg != 3) return;

            try
            {
                //根据邵阳市人民医院的需求，按照他们上班时间为正常手术申请时间
                string strcfg = (new SystemCfg(6014)).Config;
                string strcfg1 = (new SystemCfg(6015)).Config;
                string strcfg2 = (new SystemCfg(6016)).Config;
                string strcfg3 = (new SystemCfg(6017)).Config;
                string GetDates = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToShortTimeString();

                DateTime datecfg = Convert.ToDateTime(strcfg);
                DateTime datecfg1 = Convert.ToDateTime(strcfg1);
                DateTime datecfg2 = Convert.ToDateTime(strcfg2);
                DateTime datecfg3 = Convert.ToDateTime(strcfg3);
                DateTime Serverdate = Convert.ToDateTime(GetDates);

                if (!((DateTime.Compare(datecfg, Serverdate) <= 0 && DateTime.Compare(Serverdate, datecfg1) <= 0) || (DateTime.Compare(datecfg2, Serverdate) <= 0 && DateTime.Compare(Serverdate, datecfg3) <= 0)) && checkjzss.Checked == false)
                {
                    MessageBox.Show("对不起,审核手术必须在每天的上班时间内审核！\n如果是急诊手术审核则选择急诊手术", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Modify By Tany 2010-01-12 手术审核必须在指定时间内完成
                string cfgStr = (new SystemCfg(6012)).Config;
                int sh_hour = 11;
                if (cfgStr != "")
                {
                    sh_hour = Convert.ToInt16(cfgStr);
                }
                if (Serverdate.Hour >= sh_hour) //&& checkjzss.Checked == false
                {
                    MessageBox.Show("对不起,手术必须在每天的" + sh_hour + "点以前完成审核！\n如果需要手术申请则选择急诊手术", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //add by zouchihua 2013-8-27 如果是特殊手术
                string sSql="";
                if(this.labssdj.Tag.ToString()!="1")
                   sSql = "update ss_apprecord set shbj=1,shrq=GetDate() ,shys=" + this.YS_ID.ToString() + " where sno='" + this.lblsqdh.Text.Trim() + "' and deptid=" + this.DeptID + "";
                else
                   sSql = "update ss_apprecord set shbj=2,shrq=GetDate() ,shys=" + this.YS_ID.ToString() + " where sno='" + this.lblsqdh.Text.Trim() + "' and deptid=" + this.DeptID + "";
                int i = FrmMdiMain.Database.DoCommand(sSql);
                if (i != -1)
                {
                    MessageBox.Show("该申请审核成功！", "审核成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sSql = "insert into ss_log(id,sno,inpatient_no,inpatient_name,sbz,djrq,czy)values('" + PubStaticFun.NewGuid() + "','" + this.lblsqdh.Text.ToString().Trim() + "','" + this.txtzyh.Text.ToString() + "','','手术审核',GetDate()," + PubFunction.AuserEmployeeID + ")";
                    FrmMdiMain.Database.DoCommand(sSql);

                    Department msgDept = new Department(Convert.ToInt64(cmb_dept.SelectedValue), FrmMdiMain.Database);
                    string msg_wardid = msgDept.WardId;
                    long msg_deptid = 0;
                    long msg_empid = 0;
                    string msg_sender = FrmMdiMain.CurrentDept.DeptName + "：" + FrmMdiMain.CurrentUser.Name;
                    string msg_msg = lblks.Text + " " + lblbrxm.Text + " 申请 " + txtysss.Text + " ，请处理！";
                    TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.手术麻醉, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("该申请审核失败！", "审核失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        #endregion

        private void chcekbl_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcekbl.Checked)
            {
                this.DtpbeginDate.Enabled = true;
            }
            else
                this.DtpbeginDate.Enabled = false;
        }

        private void txtysmz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtjsmz.Focus();
            }
        }
    }
}
