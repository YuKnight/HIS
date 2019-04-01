using System;
using System.Data.OleDb;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using UtilityLibrary.General;
using UtilityLibrary.WinControls;
using TrasenFrame.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using Ts_ss_class;

namespace Ts_ss_shbl
{
    /// <summary>
    /// FApp 的摘要说明。
    /// </summary>
    public class FrmShbl : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components;
        public string CaptionText;
        public string sNo;
        public string age;
        public string sInpatient_no;
        private bool isSSKS = false; //Add By Tany 2015-04-08 是否手术科室
        private bool isMZKS = false; //Add By Tany 2015-04-08 是否麻醉科室
        protected System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.ImageList imageList2;
        protected System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button Bsave;
        protected System.Windows.Forms.CheckBox checkjzss;
        protected System.Windows.Forms.CheckBox checkmztys;
        protected System.Windows.Forms.CheckBox checksstys;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Label label20;
        protected System.Windows.Forms.Label label22;
        protected System.Windows.Forms.Label lblks;
        protected System.Windows.Forms.Label lblbq;
        protected System.Windows.Forms.Label label50;
        protected System.Windows.Forms.Label label45;
        protected System.Windows.Forms.Label label44;
        protected System.Windows.Forms.Label label30;
        protected System.Windows.Forms.Label txtysmz;
        protected System.Windows.Forms.Label txtysss;
        protected System.Windows.Forms.Label label21;
        protected System.Windows.Forms.Label label23;
        protected System.Windows.Forms.Label label40;
        protected System.Windows.Forms.Label label39;
        protected System.Windows.Forms.Label label38;
        protected System.Windows.Forms.Label label37;
        protected System.Windows.Forms.Label txtywgms;
        protected System.Windows.Forms.Label txttz;
        protected System.Windows.Forms.Label txtsg;
        protected System.Windows.Forms.Label label35;
        protected System.Windows.Forms.Label label27;
        protected System.Windows.Forms.Label label26;
        protected System.Windows.Forms.Label label17;
        protected System.Windows.Forms.Label label16;
        protected System.Windows.Forms.Label txtzyh;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label lblsqzd;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label lblnl;
        protected System.Windows.Forms.Label label36;
        protected System.Windows.Forms.Label lblxb;
        protected System.Windows.Forms.Label label34;
        protected System.Windows.Forms.Label lblsqdh;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.Label lblcwh;
        protected System.Windows.Forms.Label lblbrxm;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.TextBox txtqjb;
        protected System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        protected System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox 病人信息;
        protected System.Windows.Forms.Label label14;
        protected System.Windows.Forms.Label label24;
        protected System.Windows.Forms.Label label25;
        protected System.Windows.Forms.Label label29;
        protected System.Windows.Forms.Label label31;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.Label lblyxrq;
        protected System.Windows.Forms.TextBox txtfmys;
        protected System.Windows.Forms.TextBox txtzmys;
        protected System.Windows.Forms.TextBox txtyxss;
        protected System.Windows.Forms.TextBox txtyxmz;
        protected System.Windows.Forms.TextBox txtshzd;
        protected System.Windows.Forms.TextBox txtfz1;
        protected System.Windows.Forms.TextBox txtfz2;
        protected System.Windows.Forms.TextBox txtfz3;
        protected System.Windows.Forms.TextBox txtjsss1;
        protected System.Windows.Forms.TextBox txtjsss2;
        protected System.Windows.Forms.TextBox txtjsss3;
        protected System.Windows.Forms.TextBox txtjsss4;
        protected System.Windows.Forms.TextBox txtzdys;
        protected System.Windows.Forms.TextBox txtssyz;
        protected System.Windows.Forms.TextBox txtssez;
        protected System.Windows.Forms.TextBox txtsssz;
        protected System.Windows.Forms.TextBox txtxshs1;
        protected System.Windows.Forms.TextBox txtxshs2;
        protected System.Windows.Forms.TextBox txtxshs3;
        protected System.Windows.Forms.TextBox txtxhhs1;
        protected System.Windows.Forms.TextBox txtxhhs2;
        protected System.Windows.Forms.TextBox txtxhhs3;
        protected System.Windows.Forms.DateTimePicker dtpkssj;
        protected System.Windows.Forms.DateTimePicker dtpksrq;
        protected System.Windows.Forms.DateTimePicker dtpjssj;
        protected System.Windows.Forms.DateTimePicker dtpjsrq;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton chkktpx;
        private System.Windows.Forms.RadioButton chkktpy;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton chkkhzvx;
        private System.Windows.Forms.RadioButton chkkhzvy;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton chkkhcvx;
        private System.Windows.Forms.RadioButton chkkhcvy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton chkhbsagx;
        private System.Windows.Forms.RadioButton chkhbsagy;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox txtyxmz2;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.Label txtssfj;
        protected System.Windows.Forms.Label label15;
        protected System.Windows.Forms.TextBox txtssdj;
        protected Label label18;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        protected Label label19;
        private Panel panel5;
        private ComboBox cmbnnisfj;
        protected Label lbfj;
        private ComboBox cmbMzfxpg;
        protected Label label32;
        private ComboBox cmbNjmc;
        protected Label label28;
        protected TextBox txtXsl;
        protected Label label41;
        private ComboBox cmbcg;
        protected Label label33;
        private GroupBox groupBox1;
        protected Label label42;
        protected Label label46;
        private TextBox txtNzwmc;
        protected Label label43;
        private TextBox txtNzwghs;
        protected Label label47;
        private TextBox txtNzwcj;
        private Label label48;
        private Label label51;
        private Label label49;
        private CheckBox cbqt;
        private Label label52;//单据号
        public int ExecType;
        protected TextBox txtfmys3;
        protected TextBox txtfmys2;//操作类型
        private bool Iscx = false;
        private ComboBox combNzwyw;
        private ComboBox combWqssyy;
        private Label label53;
        protected Label label54;
        protected Label txtjsmz;
        public Button btZjwc;//查询
        private bool Isysz = false;//是否为医生站
        public FrmShbl(long currentUserId, long currentDeptId, string formText, object[] _value)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            this.sNo = Convertor.IsNull(_value[0].ToString().Trim(), "0");
            this.sInpatient_no = Convertor.IsNull(_value[1], "0");
            this.age = Convertor.IsNull(_value[2].ToString().Trim(), "");
            this.ExecType = 0;
            try
            {
                if (_value[3].ToString() == "1")
                    Iscx = true;
                if (_value[4].ToString() == "1")
                    Isysz = true;
            }
            catch (Exception ex)
            {

            }
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        public FrmShbl(long currentUserId, long currentDeptId, string formText)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            this.sNo = "";
            this.ExecType = 0;
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShbl));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.Bsave = new System.Windows.Forms.Button();
            this.checkjzss = new System.Windows.Forms.CheckBox();
            this.checkmztys = new System.Windows.Forms.CheckBox();
            this.checksstys = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.病人信息 = new System.Windows.Forms.GroupBox();
            this.label52 = new System.Windows.Forms.Label();
            this.cbqt = new System.Windows.Forms.CheckBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
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
            this.label26 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtzyh = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblsqzd = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblnl = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblxb = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lblsqdh = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblcwh = new System.Windows.Forms.Label();
            this.lblbrxm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblks = new System.Windows.Forms.Label();
            this.lblbq = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txtywgms = new System.Windows.Forms.Label();
            this.txttz = new System.Windows.Forms.Label();
            this.txtsg = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtjsmz = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.txtfmys3 = new System.Windows.Forms.TextBox();
            this.txtfmys2 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.combWqssyy = new System.Windows.Forms.ComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combNzwyw = new System.Windows.Forms.ComboBox();
            this.txtNzwghs = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtNzwcj = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtNzwmc = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txtXsl = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.cmbcg = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cmbnnisfj = new System.Windows.Forms.ComboBox();
            this.lbfj = new System.Windows.Forms.Label();
            this.cmbMzfxpg = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.cmbNjmc = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtssdj = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtssfj = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtyxmz2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpjssj = new System.Windows.Forms.DateTimePicker();
            this.dtpjsrq = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpkssj = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpksrq = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtxhhs3 = new System.Windows.Forms.TextBox();
            this.txtxhhs2 = new System.Windows.Forms.TextBox();
            this.txtxhhs1 = new System.Windows.Forms.TextBox();
            this.txtxshs3 = new System.Windows.Forms.TextBox();
            this.txtxshs2 = new System.Windows.Forms.TextBox();
            this.txtxshs1 = new System.Windows.Forms.TextBox();
            this.txtsssz = new System.Windows.Forms.TextBox();
            this.txtssez = new System.Windows.Forms.TextBox();
            this.txtssyz = new System.Windows.Forms.TextBox();
            this.txtzdys = new System.Windows.Forms.TextBox();
            this.txtjsss4 = new System.Windows.Forms.TextBox();
            this.txtjsss3 = new System.Windows.Forms.TextBox();
            this.txtjsss2 = new System.Windows.Forms.TextBox();
            this.txtjsss1 = new System.Windows.Forms.TextBox();
            this.txtfz3 = new System.Windows.Forms.TextBox();
            this.txtfz2 = new System.Windows.Forms.TextBox();
            this.txtfz1 = new System.Windows.Forms.TextBox();
            this.txtshzd = new System.Windows.Forms.TextBox();
            this.txtyxmz = new System.Windows.Forms.TextBox();
            this.txtyxss = new System.Windows.Forms.TextBox();
            this.txtfmys = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtzmys = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblyxrq = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtysmz = new System.Windows.Forms.Label();
            this.txtysss = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtqjb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btZjwc = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            this.病人信息.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(647, 565);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 29;
            this.button1.Text = "退出(&Q)";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bsave
            // 
            this.Bsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bsave.ForeColor = System.Drawing.Color.Blue;
            this.Bsave.Location = new System.Drawing.Point(552, 565);
            this.Bsave.Name = "Bsave";
            this.Bsave.Size = new System.Drawing.Size(88, 32);
            this.Bsave.TabIndex = 28;
            this.Bsave.Text = "保存(&S)";
            this.Bsave.Click += new System.EventHandler(this.Bsave_Click);
            // 
            // checkjzss
            // 
            this.checkjzss.ForeColor = System.Drawing.Color.Red;
            this.checkjzss.Location = new System.Drawing.Point(136, 575);
            this.checkjzss.Name = "checkjzss";
            this.checkjzss.Size = new System.Drawing.Size(76, 20);
            this.checkjzss.TabIndex = 164;
            this.checkjzss.Text = "急诊手术";
            // 
            // checkmztys
            // 
            this.checkmztys.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkmztys.Location = new System.Drawing.Point(320, 575);
            this.checkmztys.Name = "checkmztys";
            this.checkmztys.Size = new System.Drawing.Size(98, 20);
            this.checkmztys.TabIndex = 166;
            this.checkmztys.Text = "签麻醉同意书";
            // 
            // checksstys
            // 
            this.checksstys.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.checksstys.Location = new System.Drawing.Point(216, 575);
            this.checksstys.Name = "checksstys";
            this.checksstys.Size = new System.Drawing.Size(102, 18);
            this.checksstys.TabIndex = 165;
            this.checksstys.Text = "签手术同意书";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tabPage1.Controls.Add(this.病人信息);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(729, 534);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本信息";
            // 
            // 病人信息
            // 
            this.病人信息.BackColor = System.Drawing.Color.WhiteSmoke;
            this.病人信息.Controls.Add(this.label52);
            this.病人信息.Controls.Add(this.cbqt);
            this.病人信息.Controls.Add(this.label51);
            this.病人信息.Controls.Add(this.label49);
            this.病人信息.Controls.Add(this.label48);
            this.病人信息.Controls.Add(this.panel4);
            this.病人信息.Controls.Add(this.panel3);
            this.病人信息.Controls.Add(this.panel2);
            this.病人信息.Controls.Add(this.panel1);
            this.病人信息.Controls.Add(this.label26);
            this.病人信息.Controls.Add(this.label17);
            this.病人信息.Controls.Add(this.label16);
            this.病人信息.Controls.Add(this.txtzyh);
            this.病人信息.Controls.Add(this.label1);
            this.病人信息.Controls.Add(this.lblsqzd);
            this.病人信息.Controls.Add(this.label4);
            this.病人信息.Controls.Add(this.label7);
            this.病人信息.Controls.Add(this.lblnl);
            this.病人信息.Controls.Add(this.label36);
            this.病人信息.Controls.Add(this.lblxb);
            this.病人信息.Controls.Add(this.label34);
            this.病人信息.Controls.Add(this.lblsqdh);
            this.病人信息.Controls.Add(this.label5);
            this.病人信息.Controls.Add(this.label11);
            this.病人信息.Controls.Add(this.lblcwh);
            this.病人信息.Controls.Add(this.lblbrxm);
            this.病人信息.Controls.Add(this.label3);
            this.病人信息.Controls.Add(this.label2);
            this.病人信息.Controls.Add(this.lblks);
            this.病人信息.Controls.Add(this.lblbq);
            this.病人信息.Controls.Add(this.label40);
            this.病人信息.Controls.Add(this.label39);
            this.病人信息.Controls.Add(this.label38);
            this.病人信息.Controls.Add(this.label37);
            this.病人信息.Controls.Add(this.txtywgms);
            this.病人信息.Controls.Add(this.txttz);
            this.病人信息.Controls.Add(this.txtsg);
            this.病人信息.Controls.Add(this.label35);
            this.病人信息.Controls.Add(this.label27);
            this.病人信息.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.病人信息.Location = new System.Drawing.Point(6, 8);
            this.病人信息.Name = "病人信息";
            this.病人信息.Size = new System.Drawing.Size(704, 142);
            this.病人信息.TabIndex = 166;
            this.病人信息.TabStop = false;
            this.病人信息.Text = "病人信息";
            // 
            // label52
            // 
            this.label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label52.Location = new System.Drawing.Point(659, 99);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(1, 35);
            this.label52.TabIndex = 260;
            // 
            // cbqt
            // 
            this.cbqt.ForeColor = System.Drawing.Color.Blue;
            this.cbqt.Location = new System.Drawing.Point(663, 101);
            this.cbqt.Name = "cbqt";
            this.cbqt.Size = new System.Drawing.Size(41, 35);
            this.cbqt.TabIndex = 259;
            this.cbqt.Text = "其它";
            this.cbqt.UseVisualStyleBackColor = true;
            this.cbqt.CheckedChanged += new System.EventHandler(this.cbqt_CheckedChanged);
            // 
            // label51
            // 
            this.label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label51.Location = new System.Drawing.Point(521, 98);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(1, 35);
            this.label51.TabIndex = 258;
            // 
            // label49
            // 
            this.label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label49.Location = new System.Drawing.Point(348, 101);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(1, 35);
            this.label49.TabIndex = 257;
            // 
            // label48
            // 
            this.label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label48.Location = new System.Drawing.Point(179, 100);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(1, 35);
            this.label48.TabIndex = 256;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkktpx);
            this.panel4.Controls.Add(this.chkktpy);
            this.panel4.Location = new System.Drawing.Point(555, 101);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(112, 32);
            this.panel4.TabIndex = 255;
            // 
            // chkktpx
            // 
            this.chkktpx.Location = new System.Drawing.Point(55, 6);
            this.chkktpx.Name = "chkktpx";
            this.chkktpx.Size = new System.Drawing.Size(48, 24);
            this.chkktpx.TabIndex = 198;
            this.chkktpx.Text = "阴性";
            this.chkktpx.CheckedChanged += new System.EventHandler(this.chkhbsagy_CheckedChanged);
            // 
            // chkktpy
            // 
            this.chkktpy.Location = new System.Drawing.Point(7, 6);
            this.chkktpy.Name = "chkktpy";
            this.chkktpy.Size = new System.Drawing.Size(48, 24);
            this.chkktpy.TabIndex = 197;
            this.chkktpy.Text = "阳性";
            this.chkktpy.CheckedChanged += new System.EventHandler(this.chkhbsagy_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkkhzvx);
            this.panel3.Controls.Add(this.chkkhzvy);
            this.panel3.Location = new System.Drawing.Point(394, 101);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(112, 32);
            this.panel3.TabIndex = 254;
            // 
            // chkkhzvx
            // 
            this.chkkhzvx.Location = new System.Drawing.Point(54, 6);
            this.chkkhzvx.Name = "chkkhzvx";
            this.chkkhzvx.Size = new System.Drawing.Size(48, 24);
            this.chkkhzvx.TabIndex = 198;
            this.chkkhzvx.Text = "阴性";
            this.chkkhzvx.CheckedChanged += new System.EventHandler(this.chkhbsagy_CheckedChanged);
            // 
            // chkkhzvy
            // 
            this.chkkhzvy.Location = new System.Drawing.Point(5, 6);
            this.chkkhzvy.Name = "chkkhzvy";
            this.chkkhzvy.Size = new System.Drawing.Size(48, 24);
            this.chkkhzvy.TabIndex = 197;
            this.chkkhzvy.Text = "阳性";
            this.chkkhzvy.CheckedChanged += new System.EventHandler(this.chkhbsagy_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkkhcvx);
            this.panel2.Controls.Add(this.chkkhcvy);
            this.panel2.Location = new System.Drawing.Point(222, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(112, 32);
            this.panel2.TabIndex = 253;
            // 
            // chkkhcvx
            // 
            this.chkkhcvx.Location = new System.Drawing.Point(57, 6);
            this.chkkhcvx.Name = "chkkhcvx";
            this.chkkhcvx.Size = new System.Drawing.Size(48, 24);
            this.chkkhcvx.TabIndex = 198;
            this.chkkhcvx.Text = "阴性";
            this.chkkhcvx.CheckedChanged += new System.EventHandler(this.chkhbsagy_CheckedChanged);
            // 
            // chkkhcvy
            // 
            this.chkkhcvy.Location = new System.Drawing.Point(8, 6);
            this.chkkhcvy.Name = "chkkhcvy";
            this.chkkhcvy.Size = new System.Drawing.Size(48, 24);
            this.chkkhcvy.TabIndex = 197;
            this.chkkhcvy.Text = "阳性";
            this.chkkhcvy.CheckedChanged += new System.EventHandler(this.chkhbsagy_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkhbsagx);
            this.panel1.Controls.Add(this.chkhbsagy);
            this.panel1.Location = new System.Drawing.Point(54, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(112, 32);
            this.panel1.TabIndex = 252;
            // 
            // chkhbsagx
            // 
            this.chkhbsagx.Location = new System.Drawing.Point(59, 5);
            this.chkhbsagx.Name = "chkhbsagx";
            this.chkhbsagx.Size = new System.Drawing.Size(48, 24);
            this.chkhbsagx.TabIndex = 198;
            this.chkhbsagx.Text = "阴性";
            this.chkhbsagx.CheckedChanged += new System.EventHandler(this.chkhbsagy_CheckedChanged);
            // 
            // chkhbsagy
            // 
            this.chkhbsagy.Location = new System.Drawing.Point(8, 6);
            this.chkhbsagy.Name = "chkhbsagy";
            this.chkhbsagy.Size = new System.Drawing.Size(48, 24);
            this.chkhbsagy.TabIndex = 197;
            this.chkhbsagy.Text = "阳性";
            this.chkhbsagy.CheckedChanged += new System.EventHandler(this.chkhbsagy_CheckedChanged);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(113, 76);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(24, 18);
            this.label26.TabIndex = 173;
            this.label26.Text = "cm";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(144, 78);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 18);
            this.label17.TabIndex = 172;
            this.label17.Text = "体重";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(15, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 18);
            this.label16.TabIndex = 171;
            this.label16.Text = "身 高";
            // 
            // txtzyh
            // 
            this.txtzyh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtzyh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzyh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtzyh.Location = new System.Drawing.Point(477, 19);
            this.txtzyh.Name = "txtzyh";
            this.txtzyh.Size = new System.Drawing.Size(88, 21);
            this.txtzyh.TabIndex = 146;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(426, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 145;
            this.label1.Text = "住院号";
            // 
            // lblsqzd
            // 
            this.lblsqzd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblsqzd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblsqzd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblsqzd.Location = new System.Drawing.Point(424, 49);
            this.lblsqzd.Name = "lblsqzd";
            this.lblsqzd.Size = new System.Drawing.Size(272, 21);
            this.lblsqzd.TabIndex = 143;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(361, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 142;
            this.label4.Text = "术前诊断";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(200, 53);
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
            this.lblnl.Location = new System.Drawing.Point(380, 18);
            this.lblnl.Name = "lblnl";
            this.lblnl.Size = new System.Drawing.Size(41, 21);
            this.lblnl.TabIndex = 140;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(343, 22);
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
            this.lblxb.Location = new System.Drawing.Point(297, 18);
            this.lblxb.Name = "lblxb";
            this.lblxb.Size = new System.Drawing.Size(41, 21);
            this.lblxb.TabIndex = 138;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(261, 23);
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
            this.lblsqdh.Location = new System.Drawing.Point(616, 18);
            this.lblsqdh.Name = "lblsqdh";
            this.lblsqdh.Size = new System.Drawing.Size(70, 21);
            this.lblsqdh.TabIndex = 134;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(568, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 133;
            this.label5.Text = "单据号";
            this.label5.Visible = false;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(16, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 18);
            this.label11.TabIndex = 129;
            this.label11.Text = "科 室";
            // 
            // lblcwh
            // 
            this.lblcwh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcwh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcwh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblcwh.Location = new System.Drawing.Point(215, 19);
            this.lblcwh.Name = "lblcwh";
            this.lblcwh.Size = new System.Drawing.Size(41, 21);
            this.lblcwh.TabIndex = 127;
            // 
            // lblbrxm
            // 
            this.lblbrxm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblbrxm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbrxm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblbrxm.Location = new System.Drawing.Point(72, 18);
            this.lblbrxm.Name = "lblbrxm";
            this.lblbrxm.Size = new System.Drawing.Size(100, 21);
            this.lblbrxm.TabIndex = 126;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 125;
            this.label3.Text = "病人姓名";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(183, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 124;
            this.label2.Text = "床号";
            // 
            // lblks
            // 
            this.lblks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblks.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblks.Location = new System.Drawing.Point(72, 45);
            this.lblks.Name = "lblks";
            this.lblks.Size = new System.Drawing.Size(120, 21);
            this.lblks.TabIndex = 229;
            // 
            // lblbq
            // 
            this.lblbq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblbq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblbq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblbq.Location = new System.Drawing.Point(239, 47);
            this.lblbq.Name = "lblbq";
            this.lblbq.Size = new System.Drawing.Size(120, 21);
            this.lblbq.TabIndex = 228;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(523, 108);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(48, 18);
            this.label40.TabIndex = 194;
            this.label40.Text = "抗TP";
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(352, 108);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(48, 18);
            this.label39.TabIndex = 193;
            this.label39.Text = "抗HIV";
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(181, 109);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(56, 18);
            this.label38.TabIndex = 192;
            this.label38.Text = "抗HCV ";
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(3, 106);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(47, 18);
            this.label37.TabIndex = 191;
            this.label37.Text = "HBsAg ";
            // 
            // txtywgms
            // 
            this.txtywgms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtywgms.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtywgms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtywgms.Location = new System.Drawing.Point(344, 77);
            this.txtywgms.Name = "txtywgms";
            this.txtywgms.Size = new System.Drawing.Size(352, 21);
            this.txtywgms.TabIndex = 178;
            // 
            // txttz
            // 
            this.txttz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txttz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txttz.Location = new System.Drawing.Point(184, 77);
            this.txttz.Name = "txttz";
            this.txttz.Size = new System.Drawing.Size(41, 21);
            this.txttz.TabIndex = 177;
            // 
            // txtsg
            // 
            this.txtsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtsg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtsg.Location = new System.Drawing.Point(72, 77);
            this.txtsg.Name = "txtsg";
            this.txtsg.Size = new System.Drawing.Size(41, 21);
            this.txtsg.TabIndex = 176;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(265, 82);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(80, 18);
            this.label35.TabIndex = 175;
            this.label35.Text = "药物过敏史";
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(228, 77);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(24, 18);
            this.label27.TabIndex = 174;
            this.label27.Text = "Kg";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Snow;
            this.groupBox2.Controls.Add(this.txtjsmz);
            this.groupBox2.Controls.Add(this.label54);
            this.groupBox2.Controls.Add(this.txtfmys3);
            this.groupBox2.Controls.Add(this.txtfmys2);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.txtssdj);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtssfj);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtyxmz2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dtpjssj);
            this.groupBox2.Controls.Add(this.dtpjsrq);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dtpkssj);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.dtpksrq);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtxhhs3);
            this.groupBox2.Controls.Add(this.txtxhhs2);
            this.groupBox2.Controls.Add(this.txtxhhs1);
            this.groupBox2.Controls.Add(this.txtxshs3);
            this.groupBox2.Controls.Add(this.txtxshs2);
            this.groupBox2.Controls.Add(this.txtxshs1);
            this.groupBox2.Controls.Add(this.txtsssz);
            this.groupBox2.Controls.Add(this.txtssez);
            this.groupBox2.Controls.Add(this.txtssyz);
            this.groupBox2.Controls.Add(this.txtzdys);
            this.groupBox2.Controls.Add(this.txtjsss4);
            this.groupBox2.Controls.Add(this.txtjsss3);
            this.groupBox2.Controls.Add(this.txtjsss2);
            this.groupBox2.Controls.Add(this.txtjsss1);
            this.groupBox2.Controls.Add(this.txtfz3);
            this.groupBox2.Controls.Add(this.txtfz2);
            this.groupBox2.Controls.Add(this.txtfz1);
            this.groupBox2.Controls.Add(this.txtshzd);
            this.groupBox2.Controls.Add(this.txtyxmz);
            this.groupBox2.Controls.Add(this.txtyxss);
            this.groupBox2.Controls.Add(this.txtfmys);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.txtzmys);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.lblyxrq);
            this.groupBox2.Controls.Add(this.label50);
            this.groupBox2.Controls.Add(this.label45);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.txtysmz);
            this.groupBox2.Controls.Add(this.txtysss);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Location = new System.Drawing.Point(5, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(707, 379);
            this.groupBox2.TabIndex = 999;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "手术情况";
            // 
            // txtjsmz
            // 
            this.txtjsmz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtjsmz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjsmz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjsmz.Location = new System.Drawing.Point(560, 77);
            this.txtjsmz.Name = "txtjsmz";
            this.txtjsmz.Size = new System.Drawing.Size(135, 21);
            this.txtjsmz.TabIndex = 298;
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label54.Location = new System.Drawing.Point(495, 80);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(64, 18);
            this.label54.TabIndex = 297;
            this.label54.Text = "兼施麻醉";
            // 
            // txtfmys3
            // 
            this.txtfmys3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfmys3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfmys3.Location = new System.Drawing.Point(313, 184);
            this.txtfmys3.Name = "txtfmys3";
            this.txtfmys3.Size = new System.Drawing.Size(56, 23);
            this.txtfmys3.TabIndex = 296;
            this.txtfmys3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            // 
            // txtfmys2
            // 
            this.txtfmys2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfmys2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfmys2.Location = new System.Drawing.Point(256, 184);
            this.txtfmys2.Name = "txtfmys2";
            this.txtfmys2.Size = new System.Drawing.Size(53, 23);
            this.txtfmys2.TabIndex = 295;
            this.txtfmys2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.combWqssyy);
            this.panel5.Controls.Add(this.label53);
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.label42);
            this.panel5.Controls.Add(this.txtXsl);
            this.panel5.Controls.Add(this.label41);
            this.panel5.Controls.Add(this.cmbcg);
            this.panel5.Controls.Add(this.label33);
            this.panel5.Controls.Add(this.cmbnnisfj);
            this.panel5.Controls.Add(this.lbfj);
            this.panel5.Controls.Add(this.cmbMzfxpg);
            this.panel5.Controls.Add(this.label32);
            this.panel5.Controls.Add(this.cmbNjmc);
            this.panel5.Controls.Add(this.label28);
            this.panel5.Location = new System.Drawing.Point(3, 301);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(702, 72);
            this.panel5.TabIndex = 294;
            // 
            // combWqssyy
            // 
            this.combWqssyy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combWqssyy.FormattingEnabled = true;
            this.combWqssyy.Items.AddRange(new object[] {
            "",
            "有",
            "无"});
            this.combWqssyy.Location = new System.Drawing.Point(139, 41);
            this.combWqssyy.Name = "combWqssyy";
            this.combWqssyy.Size = new System.Drawing.Size(72, 20);
            this.combWqssyy.TabIndex = 293;
            this.combWqssyy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(137, 27);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(77, 12);
            this.label53.TabIndex = 295;
            this.label53.Text = "围期手术用药";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combNzwyw);
            this.groupBox1.Controls.Add(this.txtNzwghs);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.txtNzwcj);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.txtNzwmc);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(220, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 45);
            this.groupBox1.TabIndex = 294;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "内置物";
            // 
            // combNzwyw
            // 
            this.combNzwyw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combNzwyw.FormattingEnabled = true;
            this.combNzwyw.Items.AddRange(new object[] {
            "",
            "有",
            "无"});
            this.combNzwyw.Location = new System.Drawing.Point(14, 15);
            this.combNzwyw.Name = "combNzwyw";
            this.combNzwyw.Size = new System.Drawing.Size(72, 20);
            this.combNzwyw.TabIndex = 294;
            this.combNzwyw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtNzwghs
            // 
            this.txtNzwghs.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtNzwghs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtNzwghs.Location = new System.Drawing.Point(385, 14);
            this.txtNzwghs.Name = "txtNzwghs";
            this.txtNzwghs.Size = new System.Drawing.Size(84, 23);
            this.txtNzwghs.TabIndex = 297;
            this.txtNzwghs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNzwghs_KeyPress);
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label47.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label47.Location = new System.Drawing.Point(335, 17);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(52, 18);
            this.label47.TabIndex = 296;
            this.label47.Text = "供货商";
            // 
            // txtNzwcj
            // 
            this.txtNzwcj.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtNzwcj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtNzwcj.Location = new System.Drawing.Point(266, 14);
            this.txtNzwcj.Name = "txtNzwcj";
            this.txtNzwcj.Size = new System.Drawing.Size(64, 23);
            this.txtNzwcj.TabIndex = 296;
            this.txtNzwcj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label46.Location = new System.Drawing.Point(230, 19);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(36, 18);
            this.label46.TabIndex = 294;
            this.label46.Text = "厂家";
            // 
            // txtNzwmc
            // 
            this.txtNzwmc.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtNzwmc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtNzwmc.Location = new System.Drawing.Point(134, 14);
            this.txtNzwmc.Name = "txtNzwmc";
            this.txtNzwmc.Size = new System.Drawing.Size(90, 23);
            this.txtNzwmc.TabIndex = 295;
            this.txtNzwmc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label43.Location = new System.Drawing.Point(91, 17);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(36, 18);
            this.label43.TabIndex = 292;
            this.label43.Text = "名称";
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label42.Location = new System.Drawing.Point(110, 36);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(22, 18);
            this.label42.TabIndex = 293;
            this.label42.Text = "ML";
            // 
            // txtXsl
            // 
            this.txtXsl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXsl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtXsl.Location = new System.Drawing.Point(55, 33);
            this.txtXsl.Name = "txtXsl";
            this.txtXsl.Size = new System.Drawing.Size(53, 23);
            this.txtXsl.TabIndex = 292;
            this.txtXsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label41.Location = new System.Drawing.Point(3, 37);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(53, 18);
            this.label41.TabIndex = 291;
            this.label41.Text = "输血量";
            // 
            // cmbcg
            // 
            this.cmbcg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcg.FormattingEnabled = true;
            this.cmbcg.Location = new System.Drawing.Point(606, 3);
            this.cmbcg.Name = "cmbcg";
            this.cmbcg.Size = new System.Drawing.Size(87, 20);
            this.cmbcg.TabIndex = 290;
            this.cmbcg.Tag = "4";
            this.cmbcg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label33.Location = new System.Drawing.Point(544, 4);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 18);
            this.label33.TabIndex = 289;
            this.label33.Text = "管道";
            // 
            // cmbnnisfj
            // 
            this.cmbnnisfj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbnnisfj.FormattingEnabled = true;
            this.cmbnnisfj.Location = new System.Drawing.Point(449, 3);
            this.cmbnnisfj.Name = "cmbnnisfj";
            this.cmbnnisfj.Size = new System.Drawing.Size(85, 20);
            this.cmbnnisfj.TabIndex = 288;
            this.cmbnnisfj.Tag = "3";
            this.cmbnnisfj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lbfj
            // 
            this.lbfj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbfj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbfj.Location = new System.Drawing.Point(379, 4);
            this.lbfj.Name = "lbfj";
            this.lbfj.Size = new System.Drawing.Size(64, 18);
            this.lbfj.TabIndex = 287;
            this.lbfj.Text = "NNIS分级";
            // 
            // cmbMzfxpg
            // 
            this.cmbMzfxpg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMzfxpg.FormattingEnabled = true;
            this.cmbMzfxpg.Location = new System.Drawing.Point(278, 3);
            this.cmbMzfxpg.Name = "cmbMzfxpg";
            this.cmbMzfxpg.Size = new System.Drawing.Size(79, 20);
            this.cmbMzfxpg.TabIndex = 286;
            this.cmbMzfxpg.Tag = "2";
            this.cmbMzfxpg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label32.Location = new System.Drawing.Point(208, 4);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(58, 18);
            this.label32.TabIndex = 285;
            this.label32.Text = "ASA分级";
            // 
            // cmbNjmc
            // 
            this.cmbNjmc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNjmc.FormattingEnabled = true;
            this.cmbNjmc.Location = new System.Drawing.Point(75, 3);
            this.cmbNjmc.Name = "cmbNjmc";
            this.cmbNjmc.Size = new System.Drawing.Size(118, 20);
            this.cmbNjmc.TabIndex = 284;
            this.cmbNjmc.Tag = "1";
            this.cmbNjmc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label28.Location = new System.Drawing.Point(8, 4);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(64, 18);
            this.label28.TabIndex = 283;
            this.label28.Text = "内镜名称";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Ⅰ/甲 无菌切口，切口愈合良好",
            "Ⅰ/乙 无菌切口，切口愈合欠佳",
            "Ⅰ/丙 无菌切口，切口化脓    ",
            "Ⅱ/甲 沾染切口，切口愈合良好",
            "Ⅱ/乙 沾染切口，切口愈合欠佳",
            "Ⅱ/丙 沾染切口，切口化脓    ",
            "Ⅲ/甲 感染切口，切口愈合良好",
            "Ⅲ/乙 感染切口，切口愈合欠佳",
            "Ⅲ/丙 感染切口，切口化脓 "});
            this.comboBox2.Location = new System.Drawing.Point(386, 278);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(315, 20);
            this.comboBox2.TabIndex = 29;
            this.comboBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "无菌",
            "清洁",
            "污染"});
            this.comboBox1.Location = new System.Drawing.Point(78, 279);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 20);
            this.comboBox1.TabIndex = 28;
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtssdj
            // 
            this.txtssdj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtssdj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtssdj.Location = new System.Drawing.Point(440, 186);
            this.txtssdj.Name = "txtssdj";
            this.txtssdj.Size = new System.Drawing.Size(112, 23);
            this.txtssdj.TabIndex = 17;
            this.txtssdj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtssdj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtssdj.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(375, 190);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 18);
            this.label15.TabIndex = 292;
            this.label15.Text = "手术等级";
            // 
            // txtssfj
            // 
            this.txtssfj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtssfj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtssfj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtssfj.Location = new System.Drawing.Point(619, 186);
            this.txtssfj.Name = "txtssfj";
            this.txtssfj.Size = new System.Drawing.Size(75, 21);
            this.txtssfj.TabIndex = 290;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(560, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 18);
            this.label13.TabIndex = 289;
            this.label13.Text = "手术房间";
            // 
            // txtyxmz2
            // 
            this.txtyxmz2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtyxmz2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtyxmz2.Location = new System.Drawing.Point(561, 48);
            this.txtyxmz2.Name = "txtyxmz2";
            this.txtyxmz2.Size = new System.Drawing.Size(135, 23);
            this.txtyxmz2.TabIndex = 2;
            this.txtyxmz2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtyxmz2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(495, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 18);
            this.label10.TabIndex = 287;
            this.label10.Text = "已行麻醉2";
            // 
            // dtpjssj
            // 
            this.dtpjssj.CustomFormat = "";
            this.dtpjssj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpjssj.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpjssj.Location = new System.Drawing.Point(456, 248);
            this.dtpjssj.Name = "dtpjssj";
            this.dtpjssj.ShowUpDown = true;
            this.dtpjssj.Size = new System.Drawing.Size(80, 23);
            this.dtpjssj.TabIndex = 27;
            this.dtpjssj.Value = new System.DateTime(2004, 7, 3, 12, 40, 37, 62);
            this.dtpjssj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.dtpjssj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            // 
            // dtpjsrq
            // 
            this.dtpjsrq.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpjsrq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpjsrq.Location = new System.Drawing.Point(335, 248);
            this.dtpjsrq.Name = "dtpjsrq";
            this.dtpjsrq.ShowUpDown = true;
            this.dtpjsrq.Size = new System.Drawing.Size(120, 23);
            this.dtpjsrq.TabIndex = 26;
            this.dtpjsrq.Value = new System.DateTime(2004, 7, 3, 12, 40, 37, 78);
            this.dtpjsrq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.dtpjsrq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(274, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 285;
            this.label9.Text = "手术结束";
            // 
            // dtpkssj
            // 
            this.dtpkssj.CustomFormat = "";
            this.dtpkssj.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpkssj.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpkssj.Location = new System.Drawing.Point(192, 248);
            this.dtpkssj.Name = "dtpkssj";
            this.dtpkssj.ShowUpDown = true;
            this.dtpkssj.Size = new System.Drawing.Size(80, 23);
            this.dtpkssj.TabIndex = 25;
            this.dtpkssj.Value = new System.DateTime(2004, 7, 3, 12, 40, 37, 62);
            this.dtpkssj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.dtpkssj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(277, 281);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 18);
            this.label19.TabIndex = 282;
            this.label19.Text = "切口愈合等级";
            // 
            // dtpksrq
            // 
            this.dtpksrq.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtpksrq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpksrq.Location = new System.Drawing.Point(76, 248);
            this.dtpksrq.Name = "dtpksrq";
            this.dtpksrq.ShowUpDown = true;
            this.dtpksrq.Size = new System.Drawing.Size(120, 23);
            this.dtpksrq.TabIndex = 24;
            this.dtpksrq.Value = new System.DateTime(2004, 7, 3, 12, 40, 37, 78);
            this.dtpksrq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.dtpksrq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label18.Location = new System.Drawing.Point(8, 280);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 18);
            this.label18.TabIndex = 282;
            this.label18.Text = "切口类型";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(8, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 18);
            this.label8.TabIndex = 282;
            this.label8.Text = "手术开始";
            // 
            // txtxhhs3
            // 
            this.txtxhhs3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxhhs3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtxhhs3.Location = new System.Drawing.Point(606, 216);
            this.txtxhhs3.Name = "txtxhhs3";
            this.txtxhhs3.Size = new System.Drawing.Size(88, 23);
            this.txtxhhs3.TabIndex = 23;
            this.txtxhhs3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtxhhs3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtxhhs3.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtxhhs2
            // 
            this.txtxhhs2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxhhs2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtxhhs2.Location = new System.Drawing.Point(513, 216);
            this.txtxhhs2.Name = "txtxhhs2";
            this.txtxhhs2.Size = new System.Drawing.Size(88, 23);
            this.txtxhhs2.TabIndex = 22;
            this.txtxhhs2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtxhhs2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtxhhs2.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtxhhs1
            // 
            this.txtxhhs1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxhhs1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtxhhs1.Location = new System.Drawing.Point(421, 216);
            this.txtxhhs1.Name = "txtxhhs1";
            this.txtxhhs1.Size = new System.Drawing.Size(88, 23);
            this.txtxhhs1.TabIndex = 21;
            this.txtxhhs1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtxhhs1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtxhhs1.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtxshs3
            // 
            this.txtxshs3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxshs3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtxshs3.Location = new System.Drawing.Point(254, 216);
            this.txtxshs3.Name = "txtxshs3";
            this.txtxshs3.Size = new System.Drawing.Size(88, 23);
            this.txtxshs3.TabIndex = 20;
            this.txtxshs3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtxshs3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtxshs3.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtxshs2
            // 
            this.txtxshs2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxshs2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtxshs2.Location = new System.Drawing.Point(163, 216);
            this.txtxshs2.Name = "txtxshs2";
            this.txtxshs2.Size = new System.Drawing.Size(88, 23);
            this.txtxshs2.TabIndex = 19;
            this.txtxshs2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtxshs2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtxshs2.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtxshs1
            // 
            this.txtxshs1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtxshs1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtxshs1.Location = new System.Drawing.Point(76, 216);
            this.txtxshs1.Name = "txtxshs1";
            this.txtxshs1.Size = new System.Drawing.Size(88, 23);
            this.txtxshs1.TabIndex = 18;
            this.txtxshs1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtxshs1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtxshs1.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtsssz
            // 
            this.txtsssz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtsssz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtsssz.Location = new System.Drawing.Point(467, 160);
            this.txtsssz.Name = "txtsssz";
            this.txtsssz.Size = new System.Drawing.Size(113, 23);
            this.txtsssz.TabIndex = 14;
            this.txtsssz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtsssz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtsssz.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtssez
            // 
            this.txtssez.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtssez.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtssez.Location = new System.Drawing.Point(350, 160);
            this.txtssez.Name = "txtssez";
            this.txtssez.Size = new System.Drawing.Size(113, 23);
            this.txtssez.TabIndex = 13;
            this.txtssez.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtssez.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtssez.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtssyz
            // 
            this.txtssyz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtssyz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtssyz.Location = new System.Drawing.Point(234, 160);
            this.txtssyz.Name = "txtssyz";
            this.txtssyz.Size = new System.Drawing.Size(113, 23);
            this.txtssyz.TabIndex = 12;
            this.txtssyz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtssyz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtssyz.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtzdys
            // 
            this.txtzdys.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzdys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtzdys.Location = new System.Drawing.Point(76, 160);
            this.txtzdys.Name = "txtzdys";
            this.txtzdys.Size = new System.Drawing.Size(113, 23);
            this.txtzdys.TabIndex = 11;
            this.txtzdys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtzdys.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtzdys.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtjsss4
            // 
            this.txtjsss4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjsss4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjsss4.Location = new System.Drawing.Point(538, 128);
            this.txtjsss4.Name = "txtjsss4";
            this.txtjsss4.Size = new System.Drawing.Size(158, 23);
            this.txtjsss4.TabIndex = 10;
            this.txtjsss4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtjsss4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtjsss4.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtjsss3
            // 
            this.txtjsss3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjsss3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjsss3.Location = new System.Drawing.Point(384, 128);
            this.txtjsss3.Name = "txtjsss3";
            this.txtjsss3.Size = new System.Drawing.Size(152, 23);
            this.txtjsss3.TabIndex = 9;
            this.txtjsss3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtjsss3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtjsss3.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtjsss2
            // 
            this.txtjsss2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjsss2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjsss2.Location = new System.Drawing.Point(229, 128);
            this.txtjsss2.Name = "txtjsss2";
            this.txtjsss2.Size = new System.Drawing.Size(152, 23);
            this.txtjsss2.TabIndex = 8;
            this.txtjsss2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtjsss2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtjsss2.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtjsss1
            // 
            this.txtjsss1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjsss1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtjsss1.Location = new System.Drawing.Point(76, 128);
            this.txtjsss1.Name = "txtjsss1";
            this.txtjsss1.Size = new System.Drawing.Size(152, 23);
            this.txtjsss1.TabIndex = 7;
            this.txtjsss1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtjsss1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtjsss1.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtfz3
            // 
            this.txtfz3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfz3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfz3.Location = new System.Drawing.Point(491, 104);
            this.txtfz3.Name = "txtfz3";
            this.txtfz3.Size = new System.Drawing.Size(204, 23);
            this.txtfz3.TabIndex = 6;
            this.txtfz3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtfz3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtfz3.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtfz2
            // 
            this.txtfz2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfz2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfz2.Location = new System.Drawing.Point(282, 104);
            this.txtfz2.Name = "txtfz2";
            this.txtfz2.Size = new System.Drawing.Size(207, 23);
            this.txtfz2.TabIndex = 5;
            this.txtfz2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtfz2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtfz2.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtfz1
            // 
            this.txtfz1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfz1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfz1.Location = new System.Drawing.Point(76, 104);
            this.txtfz1.Name = "txtfz1";
            this.txtfz1.Size = new System.Drawing.Size(206, 23);
            this.txtfz1.TabIndex = 4;
            this.txtfz1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtfz1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtfz1.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtshzd
            // 
            this.txtshzd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtshzd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtshzd.Location = new System.Drawing.Point(76, 77);
            this.txtshzd.Name = "txtshzd";
            this.txtshzd.Size = new System.Drawing.Size(413, 23);
            this.txtshzd.TabIndex = 3;
            this.txtshzd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtshzd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtshzd.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtyxmz
            // 
            this.txtyxmz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtyxmz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtyxmz.Location = new System.Drawing.Point(316, 48);
            this.txtyxmz.Name = "txtyxmz";
            this.txtyxmz.Size = new System.Drawing.Size(173, 23);
            this.txtyxmz.TabIndex = 1;
            this.txtyxmz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtyxmz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtyxmz.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtyxss
            // 
            this.txtyxss.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtyxss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtyxss.Location = new System.Drawing.Point(76, 50);
            this.txtyxss.Name = "txtyxss";
            this.txtyxss.Size = new System.Drawing.Size(173, 23);
            this.txtyxss.TabIndex = 0;
            this.txtyxss.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtyxss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtyxss.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // txtfmys
            // 
            this.txtfmys.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfmys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfmys.Location = new System.Drawing.Point(202, 184);
            this.txtfmys.Name = "txtfmys";
            this.txtfmys.Size = new System.Drawing.Size(51, 23);
            this.txtfmys.TabIndex = 16;
            this.txtfmys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtfmys.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtfmys.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label29.Location = new System.Drawing.Point(143, 191);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(64, 18);
            this.label29.TabIndex = 261;
            this.label29.Text = "辅麻医生";
            // 
            // txtzmys
            // 
            this.txtzmys.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzmys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtzmys.Location = new System.Drawing.Point(76, 184);
            this.txtzmys.Name = "txtzmys";
            this.txtzmys.Size = new System.Drawing.Size(62, 23);
            this.txtzmys.TabIndex = 15;
            this.txtzmys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextKeyDown);
            this.txtzmys.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.txtzmys.LostFocus += new System.EventHandler(this.TextLostFocus);
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label31.Location = new System.Drawing.Point(7, 186);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 18);
            this.label31.TabIndex = 260;
            this.label31.Text = "主麻医生";
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label24.Location = new System.Drawing.Point(251, 51);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 18);
            this.label24.TabIndex = 255;
            this.label24.Text = "已行麻醉";
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label25.Location = new System.Drawing.Point(16, 53);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 18);
            this.label25.TabIndex = 254;
            this.label25.Text = "已行手术";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(16, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 18);
            this.label14.TabIndex = 252;
            this.label14.Text = "术后诊断";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(20, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 18);
            this.label12.TabIndex = 248;
            this.label12.Text = "辅 诊";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Location = new System.Drawing.Point(357, 216);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 18);
            this.label20.TabIndex = 237;
            this.label20.Text = "巡回护士";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label22.Location = new System.Drawing.Point(8, 218);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 18);
            this.label22.TabIndex = 236;
            this.label22.Text = "洗手护士";
            // 
            // lblyxrq
            // 
            this.lblyxrq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblyxrq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblyxrq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblyxrq.Location = new System.Drawing.Point(560, 22);
            this.lblyxrq.Name = "lblyxrq";
            this.lblyxrq.Size = new System.Drawing.Size(136, 21);
            this.lblyxrq.TabIndex = 215;
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label50.Location = new System.Drawing.Point(496, 24);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(74, 18);
            this.label50.TabIndex = 214;
            this.label50.Text = "手术日期";
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label45.Location = new System.Drawing.Point(191, 160);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(41, 18);
            this.label45.TabIndex = 209;
            this.label45.Text = "助 手";
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label44.Location = new System.Drawing.Point(9, 160);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(64, 18);
            this.label44.TabIndex = 208;
            this.label44.Text = "主刀医生";
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label30.Location = new System.Drawing.Point(12, 128);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(64, 18);
            this.label30.TabIndex = 203;
            this.label30.Text = "兼施手术";
            // 
            // txtysmz
            // 
            this.txtysmz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtysmz.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtysmz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtysmz.Location = new System.Drawing.Point(317, 22);
            this.txtysmz.Name = "txtysmz";
            this.txtysmz.Size = new System.Drawing.Size(168, 21);
            this.txtysmz.TabIndex = 200;
            // 
            // txtysss
            // 
            this.txtysss.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtysss.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtysss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtysss.Location = new System.Drawing.Point(76, 24);
            this.txtysss.Name = "txtysss";
            this.txtysss.Size = new System.Drawing.Size(168, 21);
            this.txtysss.TabIndex = 199;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label21.Location = new System.Drawing.Point(251, 26);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 18);
            this.label21.TabIndex = 198;
            this.label21.Text = "拟施麻醉";
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label23.Location = new System.Drawing.Point(16, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 18);
            this.label23.TabIndex = 197;
            this.label23.Text = "拟施手术";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(720, 471);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "器械信息";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGrid2);
            this.groupBox4.Controls.Add(this.dataGrid1);
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(8, 72);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(696, 344);
            this.groupBox4.TabIndex = 201;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "器械包明细";
            // 
            // dataGrid2
            // 
            this.dataGrid2.CaptionText = "加数";
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(352, 16);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(336, 320);
            this.dataGrid2.TabIndex = 1;
            // 
            // dataGrid1
            // 
            this.dataGrid1.CaptionText = "包明细";
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(336, 320);
            this.dataGrid1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtqjb);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(696, 56);
            this.groupBox3.TabIndex = 200;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "器械包";
            // 
            // txtqjb
            // 
            this.txtqjb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtqjb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtqjb.Location = new System.Drawing.Point(103, 20);
            this.txtqjb.Name = "txtqjb";
            this.txtqjb.Size = new System.Drawing.Size(157, 23);
            this.txtqjb.TabIndex = 198;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(26, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 199;
            this.label6.Text = "器械包名称";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 17);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(737, 559);
            this.tabControl1.TabIndex = 169;
            // 
            // btZjwc
            // 
            this.btZjwc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btZjwc.ForeColor = System.Drawing.Color.Blue;
            this.btZjwc.Location = new System.Drawing.Point(447, 565);
            this.btZjwc.Name = "btZjwc";
            this.btZjwc.Size = new System.Drawing.Size(98, 32);
            this.btZjwc.TabIndex = 170;
            this.btZjwc.Text = "完成(&F)";
            this.btZjwc.Click += new System.EventHandler(this.btZjwc_Click);
            // 
            // FrmShbl
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(742, 604);
            this.Controls.Add(this.btZjwc);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Bsave);
            this.Controls.Add(this.checkjzss);
            this.Controls.Add(this.checkmztys);
            this.Controls.Add(this.checksstys);
            this.Name = "FrmShbl";
            this.Text = "术后补录";
            this.Load += new System.EventHandler(this.FApp_Load);
            this.tabPage1.ResumeLayout(false);
            this.病人信息.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

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

            this.txtssfj.Text = "";
            this.txtssfj.Tag = "0";
            this.chkhbsagy.Checked = false;
            this.chkhbsagx.Checked = false;
            this.chkkhcvy.Checked = false;
            this.chkkhcvx.Checked = false;
            this.chkkhzvy.Checked = false;
            this.chkkhzvx.Checked = false;
            this.chkktpy.Checked = false;
            this.chkktpy.Checked = false;
            this.lblyxrq.Text = "";
            this.txtysss.Text = "";
            this.txtysss.Tag = 0;
            this.txtysmz.Text = "";
            this.txtysmz.Tag = 0;
            this.txtyxss.Text = "";
            this.txtyxss.Tag = 0;
            this.txtyxmz.Text = "";
            this.txtyxmz.Tag = 0;
            this.txtshzd.Text = "";
            this.txtshzd.Tag = 0;

            this.txtjsmz.Text = "";
            this.txtjsmz.Tag = "";

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
            this.txtzmys.Text = "";
            this.txtzmys.Tag = 0;
            this.txtfmys.Text = "";
            this.txtfmys.Tag = 0;

            this.txtfmys2.Text = "";
            this.txtfmys2.Tag = 0;
            this.txtfmys3.Text = "";
            this.txtfmys3.Tag = 0;


            this.txtxshs1.Text = "";
            this.txtxshs1.Tag = 0;
            this.txtxshs2.Text = "";
            this.txtxshs2.Tag = 0;
            this.txtxshs3.Text = "";
            this.txtxshs3.Tag = 0;
            this.txtxhhs1.Text = "";
            this.txtxhhs1.Tag = 0;
            this.txtxhhs2.Text = "";
            this.txtxhhs2.Tag = 0;
            this.txtxhhs3.Text = "";
            this.txtxhhs3.Tag = 0;
            this.txtqjb.Text = "";
            this.txtqjb.Tag = 0;

        }
        #endregion

        #region 回车跳至下一个文本
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                this.SelectNextControl((Control)sender, true, false, true, true);
        }

        #endregion

        #region 保存按扭
        private void Bsave_Click(object sender, System.EventArgs e)
        {
            //add by zouchihua 增加ini控制
            string xshs = ApiFunction.GetIniString("Shbl", "xshs", Constant.ApplicationDirectory + "\\Shbl_Set.ini");
            string xhhs = ApiFunction.GetIniString("Shbl", "xhhs", Constant.ApplicationDirectory + "\\Shbl_Set.ini");
            string qklx = ApiFunction.GetIniString("Shbl", "qklx", Constant.ApplicationDirectory + "\\Shbl_Set.ini");
            string qkyhdj = ApiFunction.GetIniString("Shbl", "qkyhdj", Constant.ApplicationDirectory + "\\Shbl_Set.ini");
            string x = ApiFunction.GetIniString("Shbl", "X", Constant.ApplicationDirectory + "\\Shbl_Set.ini");
            string y = ApiFunction.GetIniString("Shbl", "Y", Constant.ApplicationDirectory + "\\Shbl_Set.ini");
            string mzys = ApiFunction.GetIniString("Shbl", "mzys", Constant.ApplicationDirectory + "\\Shbl_Set.ini");
            string sdata = PubFunction.sys_date();
            if (this.txtyxss.Text.ToString().Trim() == "" || this.txtyxss.Tag.ToString().Trim() == "0")
            {
                MessageBox.Show("已行手术必填.");
                this.txtyxss.Focus();
                return;
            }

            if (this.txtyxmz.Tag.ToString().Trim() == "" || this.txtyxmz.Tag.ToString().Trim() == "0")
            {
                MessageBox.Show("已行麻醉必填.");
                this.txtyxmz.Focus();
                return;
            }

            if (this.txtshzd.Text.ToString().Trim() == "")//|| this.txtshzd.Tag.ToString().Trim()=="0")
            {
                MessageBox.Show("术后诊断必填.");
                this.txtshzd.Focus();
                return;
            }

            if (this.txtzdys.Tag.ToString().Trim() == "" || this.txtzdys.Tag.ToString().Trim() == "0")
            {
                MessageBox.Show("主刀医生必填.");
                this.txtzdys.Focus();
                return;
            }

            if (mzys.Trim() == "1" && (this.txtzmys.Tag.ToString().Trim() == "" || this.txtzmys.Tag.ToString().Trim() == "0"))
            {
                MessageBox.Show("主麻医生必填.");
                this.txtzmys.Focus();
                return;
            }

            if ((this.txtssdj.Tag.ToString().Trim() == "" || this.txtssdj.Tag.ToString().Trim() == "0"))
            {
                MessageBox.Show("手术等级必填.");
                this.txtssdj.Focus();
                return;
            }
            //add by zouchihua 2011-12-23 增加巡回护士
            if (xhhs.Trim() == "1" &&
                ((this.txtxhhs1.Tag.ToString().Trim() == "" && this.txtxhhs2.Tag.ToString().Trim() == "" && this.txtxhhs3.Tag.ToString().Trim() == "")
                || (this.txtxhhs1.Tag.ToString().Trim() == "0" && this.txtxhhs2.Tag.ToString().Trim() == "0" && this.txtxhhs3.Tag.ToString().Trim() == "0"))
                )
            {
                MessageBox.Show("巡回护士必填.");
                this.txtxhhs1.Focus();
                return;
            }
            //add by zouchihua 2011-12-23 增加洗手护士
            if (xshs.Trim() == "1" &&
                ((this.txtxshs1.Tag.ToString().Trim() == "" && this.txtxshs2.Tag.ToString().Trim() == "" && this.txtxshs3.Tag.ToString().Trim() == "")
                || (this.txtxshs1.Tag.ToString().Trim() == "0" && this.txtxshs2.Tag.ToString().Trim() == "0" && this.txtxshs3.Tag.ToString().Trim() == "0"))
                )
            {
                MessageBox.Show("洗手护士必填.");
                this.txtxshs1.Focus();
                return;
            }
            if (qklx.Trim() == "1" && comboBox1.Text.ToString().Trim() == "")
            {
                MessageBox.Show("切口类型必填.");
                this.comboBox1.Focus();
                return;
            }

            if (qkyhdj.Trim() == "1" && comboBox2.Text.ToString().Trim() == "")
            {
                MessageBox.Show("切口愈合等级必填.");
                this.comboBox2.Focus();
                return;
            }
            DateTime serdatime = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            DateTime jssj = DateTime.Parse(this.dtpjsrq.Value.ToShortDateString() + " " + this.dtpjssj.Value.ToLongTimeString());
            DateTime kssj = DateTime.Parse(this.dtpksrq.Value.ToShortDateString() + " " + this.dtpkssj.Value.ToLongTimeString());
            if (jssj < kssj)
            {
                MessageBox.Show("开始时间不能大于结束时间.");
                this.dtpjsrq.Focus();
                return;
            }
            //add by zouchihua 2012-11-13 X  手术开始时间不能早于手术结束时间X小时,0默认不做控制 Y   不能早于系统当前时间Y小时，0默认不做控制
            if (Convert.ToInt32(y) > 0)
            {
                if (serdatime.AddHours(-Convert.ToInt32(y)) > kssj)
                {
                    MessageBox.Show("手术开始时间不能早于系统当前时间[" + y.ToString() + "]小时,请联系管理员！");
                    return;
                }
            }
            if (Convert.ToInt32(x) > 0)
            {
                if (kssj.AddHours(Convert.ToInt32(x)) < jssj)
                {
                    MessageBox.Show("手术开始时间不能早于手术结束时间[" + x.ToString() + "]小时,请联系管理员！");
                    return;
                }
            }
            //add by zouchihua 2011-12-23 新增内容

            string cfg9004 = new SystemCfg(9004).Config.Trim();
            if (cfg9004 == "1")
            {
                SystemCfg cfg2 = new SystemCfg(2);
                if (this.cmbNjmc.Text.Trim() == "")
                {
                    MessageBox.Show("内镜名称必填.");
                    this.cmbNjmc.Focus();
                    return;
                }
                if (this.cmbMzfxpg.Text.Trim() == "")
                {
                    MessageBox.Show(label32.Text.Trim() + "必填.");
                    this.cmbMzfxpg.Focus();
                    return;
                }
                if (this.cmbnnisfj.Text.Trim() == "" && cfg2.Config.Trim() != "怀化市第三人民医院")
                {
                    MessageBox.Show("NNIS分级必填.");
                    this.cmbnnisfj.Focus();
                    return;
                }


                if (this.txtXsl.Text.Trim() == "" && cfg2.Config.Trim() != "怀化市第三人民医院")
                {
                    MessageBox.Show("输血量必填.");
                    this.txtXsl.Focus();
                    return;
                }
                //add by zouchihua 2013-5-21
                if (this.combNzwyw.Text.Trim() == "")
                {
                    MessageBox.Show("内置物有无请选择.");
                    this.combNzwyw.Focus();
                    return;
                }
                if (this.combWqssyy.Text.Trim() == "")
                {
                    MessageBox.Show("围期手术期用药有无请选择");
                    this.combWqssyy.Focus();
                    return;
                }
                if (cfg2.Config.Trim() != "怀化市第三人民医院")
                {
                    if (combNzwyw.Text.Trim() == "有")
                    {
                        if (this.txtNzwmc.Text.Trim() == "")
                        {
                            MessageBox.Show("内置物名称必填.");
                            this.txtNzwmc.Focus();
                            return;
                        }
                        if (this.txtNzwcj.Text.Trim() == "")
                        {
                            MessageBox.Show("内置物厂家必填.");
                            this.txtNzwcj.Focus();
                            return;
                        }
                        if (this.txtNzwghs.Text.Trim() == "")
                        {
                            MessageBox.Show("内置物供货商必填.");
                            this.txtNzwghs.Focus();
                            return;
                        }
                    }
                }
                try
                {
                    double value = Double.Parse(txtXsl.Text.Trim() == "" ? "0" : txtXsl.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("输血量必须为数字类型！");
                    this.txtXsl.Focus();
                    this.txtXsl.SelectAll();
                    return;
                }
            }
            string cfg9005 = new SystemCfg(9005).Config.Trim();
            if (cfg9005 == "1" && this.cbqt.Checked == false)
            {
                if (chkhbsagy.Checked == false && chkhbsagx.Checked == false)
                {
                    MessageBox.Show("HBsAg请选择.");
                    this.chkhbsagy.Focus();
                    return;
                }
                if (chkkhcvy.Checked == false && chkkhcvx.Checked == false)
                {
                    MessageBox.Show("抗HCV 请选择.");
                    this.chkkhcvy.Focus();
                    return;
                }
                if (chkkhzvy.Checked == false && chkkhzvx.Checked == false)
                {
                    MessageBox.Show("抗HIV请选择.");
                    this.chkkhzvy.Focus();
                    return;
                }
                if (chkktpy.Checked == false && chkktpx.Checked == false)
                {
                    MessageBox.Show("抗TP请选择.");
                    this.chkktpy.Focus();
                    return;
                }

            }
            //
            if (MessageBox.Show(this, "补录保存后您将再无法更改手术的相关信息，您确认吗?", "术后补录", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //				RelationalDatabase db=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
                //				try
                //				{
                //					db.Initialize("");
                //					db.Open();
                //				}
                //				catch(System.Exception err)
                //				{
                //					MessageBox.Show("连接远程数据库失败!"+err.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //					this.Close();
                //					return;
                //				}

                try
                {
                    FrmMdiMain.Database.BeginTransaction();
                    string ssql;
                    //Modify by zouchihua 2011-12-23
                    if (cfg9005 == "1")
                    {
                        if (!cbqt.Checked)//没有选中
                        {
                            //更新申请表
                            ssql = "update ss_apprecord set " +
                                " shzd = '" + this.txtshzd.Text.ToString().Trim() + "',ssfz = '" + this.txtfz1.Text.ToString().Trim() + "',ssfz1 = '" + this.txtfz2.Text.ToString().Trim() + "',ssfz2 = '" + this.txtfz3.Text.ToString().Trim() + "', " +
                                " jsss = '" + this.txtjsss1.Text.ToString().Trim() + "',jsss1 = '" + this.txtjsss2.Text.ToString().Trim() + "',jsss2 = '" + this.txtjsss3.Text.ToString().Trim() + "'," +
                                " jsss3 = '" + this.txtjsss4.Text.ToString().Trim() + "',zdys = " + Convert.ToInt32(this.txtzdys.Tag.ToString()) + "," +
                                " ssyz = " + Convert.ToInt32(this.txtssyz.Tag.ToString()) + ",ssez = " + Convert.ToInt32(this.txtssez.Tag.ToString()) + ",sssz = " + Convert.ToInt32(this.txtsssz.Tag.ToString()) + "," +
                                " ssdj = '" + txtssdj.Tag.ToString().Trim() + "',mzys = " + Convert.ToInt32(this.txtzmys.Tag) + ",mzys1 = " + Convert.ToInt32(this.txtfmys.Tag) + ",mzys2=" + Convert.ToInt32(this.txtfmys2.Tag == null ? "0" : this.txtfmys2.Tag.ToString()) + ",mzys3=" + Convert.ToInt32(this.txtfmys3.Tag == null ? "0" : this.txtfmys3.Tag.ToString())
                                + ", Hbsag='" + (this.chkhbsagy.Checked == true ? "阳性" : "阴性") + "', khcw='" + (chkkhcvy.Checked == true ? "阳性" : "阴性") + "',khzv='" + (chkkhzvy.Checked == true ? "阳性" : "阴性") + "',ktp='" + (chkktpy.Checked == true ? "阳性" : "阴性") + "'"
                                + " where sno='" + this.lblsqdh.Text.Trim() + "' ";
                        }
                        else //其它选中的时候！输血四项清空
                        {
                            //更新申请表
                            ssql = "update ss_apprecord set " +
                                " shzd = '" + this.txtshzd.Text.ToString().Trim() + "',ssfz = '" + this.txtfz1.Text.ToString().Trim() + "',ssfz1 = '" + this.txtfz2.Text.ToString().Trim() + "',ssfz2 = '" + this.txtfz3.Text.ToString().Trim() + "', " +
                                " jsss = '" + this.txtjsss1.Text.ToString().Trim() + "',jsss1 = '" + this.txtjsss2.Text.ToString().Trim() + "',jsss2 = '" + this.txtjsss3.Text.ToString().Trim() + "'," +
                                " jsss3 = '" + this.txtjsss4.Text.ToString().Trim() + "',zdys = " + Convert.ToInt32(this.txtzdys.Tag.ToString()) + "," +
                                " ssyz = " + Convert.ToInt32(this.txtssyz.Tag.ToString()) + ",ssez = " + Convert.ToInt32(this.txtssez.Tag.ToString()) + ",sssz = " + Convert.ToInt32(this.txtsssz.Tag.ToString()) + "," +
                                " ssdj = '" + txtssdj.Tag.ToString().Trim() + "',mzys = " + Convert.ToInt32(this.txtzmys.Tag) + ",mzys1 = " + Convert.ToInt32(this.txtfmys.Tag) + ",mzys2=" + Convert.ToInt32(this.txtfmys2.Tag == null ? "0" : this.txtfmys2.Tag.ToString()) + ",mzys3=" + Convert.ToInt32(this.txtfmys3.Tag == null ? "0" : this.txtfmys3.Tag.ToString())
                                + ", Hbsag='', khcw='',khzv='',ktp=''"
                                + " where sno='" + this.lblsqdh.Text.Trim() + "' ";
                        }
                    }
                    else
                    {
                        ssql = "update ss_apprecord set " +
                       " shzd = '" + this.txtshzd.Text.ToString().Trim() + "',ssfz = '" + this.txtfz1.Text.ToString().Trim() + "',ssfz1 = '" + this.txtfz2.Text.ToString().Trim() + "',ssfz2 = '" + this.txtfz3.Text.ToString().Trim() + "', " +
                       " jsss = '" + this.txtjsss1.Text.ToString().Trim() + "',jsss1 = '" + this.txtjsss2.Text.ToString().Trim() + "',jsss2 = '" + this.txtjsss3.Text.ToString().Trim() + "'," +
                       " jsss3 = '" + this.txtjsss4.Text.ToString().Trim() + "',zdys = " + Convert.ToInt32(this.txtzdys.Tag.ToString()) + "," +
                       " ssyz = " + Convert.ToInt32(this.txtssyz.Tag.ToString()) + ",ssez = " + Convert.ToInt32(this.txtssez.Tag.ToString()) + ",sssz = " + Convert.ToInt32(this.txtsssz.Tag.ToString()) + "," +
                       " ssdj = '" + txtssdj.Tag.ToString().Trim() + "',mzys = " + Convert.ToInt32(this.txtzmys.Tag) + ",mzys1 = " + Convert.ToInt32(this.txtfmys.Tag) + ",mzys2=" + Convert.ToInt32(this.txtfmys2.Tag == null ? "0" : this.txtfmys2.Tag.ToString()) + ",mzys3=" + Convert.ToInt32(this.txtfmys3.Tag == null ? "0" : this.txtfmys3.Tag.ToString())
                       + " where sno='" + this.lblsqdh.Text.Trim() + "' ";
                        FrmMdiMain.Database.DoCommand(ssql);
                    }
                    //更新房间占用标志
                    ssql = "update ss_roomtc set flag=0 where id='" + this.txtssfj.Tag.ToString() + "'";
                    FrmMdiMain.Database.DoCommand(ssql);
                    //更新安排表
                    ssql = "update ss_arrrecord set " +
                        " wssqyy='" + this.combWqssyy.Text + "',nzwyw='" + this.combNzwyw.Text + "' ," +//add by zouchihua 2013-5-21
                        " yxss = '" + txtyxss.Text.ToString().Trim() + "',yxmz = '" + this.txtyxmz.Text.ToString().Trim() + "',yxmz2 = '" + this.txtyxmz2.Text.ToString().Trim() + "',xshs = " + Convert.ToInt32(this.txtxshs1.Tag.ToString()) + "," +
                        " xshs1 = " + Convert.ToInt32(this.txtxshs2.Tag.ToString()) + ",xshs2 = " + Convert.ToInt32(this.txtxshs3.Tag.ToString()) + "," +
                        " xhhs = " + Convert.ToInt32(this.txtxhhs1.Tag.ToString()) + ",xhhs1 = " + Convert.ToInt32(this.txtxhhs2.Tag.ToString()) + "," +
                        " xhhs2 = " + Convert.ToInt32(this.txtxhhs3.Tag.ToString()) + ",wcbj = 1,ssbeginrq = '" + this.dtpksrq.Value.ToShortDateString() + " " + this.dtpkssj.Value.ToLongTimeString() + "'," +
                        " ssendrq = '" + this.dtpjsrq.Value.ToShortDateString() + " " + this.dtpjssj.Value.ToLongTimeString() + "',wcsj = '" + sdata.Trim() + "',wcdjczy = " + PubFunction.AuserEmployeeID + ",xshs_name = '" + this.txtxshs1.Text.Trim() + "',xhhs_name = '" + this.txtxhhs1.Text.Trim() +
                        "',qklx='" + comboBox1.Text + "',qklxid=" + Convert.ToInt32(Convertor.IsNull(comboBox1.SelectedValue, "0")) + ",qkyhdj='" + comboBox2.Text + "',qkyhdjid=" + Convert.ToInt32(Convertor.IsNull(comboBox2.SelectedValue, "0")) + "  " +
                        " ,njmc='" + this.cmbNjmc.Text.Trim() + "' ,mzfxpg='" + this.cmbMzfxpg.Text.Trim() + "', nnisfj='" + this.cmbnnisfj.Text.Trim() + "',cglx='" + this.cmbcg.Text.Trim() + "',sxl=" + ((this.txtXsl.Text == "" || this.txtXsl.Text == "0") ? "null" : this.txtXsl.Text) + ",nzwmc='" + this.txtNzwmc.Text + "',nzwcj='" + this.txtNzwcj.Text.Trim() + "',nzwghgs='" + this.txtNzwghs.Text.Trim() + "' " +
                        " where sno='" + this.sNo.Trim() + "'";
                    FrmMdiMain.Database.DoCommand(ssql);
                    //插入日志
                    ssql = "insert into ss_log(id,sno,inpatient_name,sbz,djrq,czy)values('" + TrasenClasses.GeneralClasses.PubStaticFun.NewGuid() + "','" + this.sNo.ToString().Trim() + "','','术后补录','" + sdata.Trim() + "'," + PubFunction.AuserEmployeeID + ")";
                    FrmMdiMain.Database.DoCommand(ssql);
                    FrmMdiMain.Database.CommitTransaction();
                    MessageBox.Show("手术补录完成");
                    PubFunction.shbl = true;
                    this.Close();
                }
                catch (System.Exception err)
                {
                    FrmMdiMain.Database.RollbackTransaction();
                    //					db.Close();
                    //					db.Dispose();
                    MessageBox.Show(err.Message + err.Source);

                }
            }
        }

        #endregion

        private void AddcomData(ComboBox cb, Label lab)
        {

            string sql = "select typename,name,id from ss_ShblJcsj where type='" + cb.Tag.ToString() + "'";
            DataTable temptb = FrmMdiMain.Database.GetDataTable(sql);
            if (temptb.Rows.Count > 0)
            {
                lab.Text = temptb.Rows[0]["typename"].ToString();
                cb.DataSource = null;
                cb.Items.Clear();

                cb.ValueMember = "id";
                cb.DisplayMember = "name";
                cb.DataSource = temptb;

            }
        }
        #region Load
        private void FApp_Load(object sender, System.EventArgs e)
        {

            #region //add by caicheng 2013-09-16 动态加载ASA等级等下拉框的数据
            AddcomData(cmbNjmc, label28);
            AddcomData(cmbMzfxpg, label32);
            AddcomData(cmbnnisfj, lbfj);
            AddcomData(cmbcg, label33);
            cmbNjmc.SelectedIndex = -1;
            cmbMzfxpg.SelectedIndex = -1;
            cmbnnisfj.SelectedIndex = -1;
            cmbcg.SelectedIndex = -1;
            #endregion


            this.combWqssyy.SelectedIndex = 0;
            this.combNzwyw.SelectedIndex = 0;
            //add by zouchihua 2012-11-13 结束日期不能大于当期日期
            dtpjsrq.MaxDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).AddHours(1);
            // dtpjssj.MaxDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);


            SystemCfg cfg9004 = new SystemCfg(9004);
            if (cfg9004.Config.Trim() == "0")
            {
                Iscx = true;
                this.panel5.Visible = false;
            }
            this.Fclear();
            this.checkjzss.Enabled = false;
            this.checkmztys.Enabled = false;
            this.checksstys.Enabled = false;
            Ts_ss_class.PubFunction.AddQkyhdj(comboBox2);
            Ts_ss_class.PubFunction.AddQkdj(comboBox1);
            comboBox2.SelectedIndex = -1;
            this.FillApp();

            //Add By Tany 2015-04-08
            GetSSMZDept();
            Bsave.Visible = isSSKS; //手术科室才可见保存按钮
            if (isSSKS)
            {
                btZjwc.Text = "手术完成(&F)";
            }
            if (isMZKS)
            {
                btZjwc.Text = "麻醉完成(&F)";
            }
        }

        #endregion

        #region 进入相应的代码选择窗口
        private void TextKeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyCode) >= 65 & Convert.ToInt32(e.KeyCode) <= 90)
            {
                Control control = (Control)sender;
                Fbasesearch f = new Fbasesearch();
                f.Search = Convert.ToString(e.KeyCode);
                f.control = control;

                switch (control.TabIndex)
                {
                    case 0://手术代码
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        f.TypeID = Convert.ToInt32(PubFunction.CodyType.Operate);
                        break;
                    case 1:  //麻醉名称
                    case 2:
                        f.TypeID = Convert.ToInt32(PubFunction.CodyType.Anesthesia);
                        break;
                    case 3://诊断
                    case 4:
                    case 5:
                    case 6:
                        f.TypeID = Convert.ToInt32(PubFunction.CodyType.Diagnose);
                        break;
                    case 11://主刀医生助手
                    case 12:
                    case 13:
                    case 14:
                        f.TypeID = Convert.ToInt32(PubFunction.CodyType.OperateDoctor);
                        break;
                    case 15://麻醉医生
                    case 16:
                    case 295:
                    case 296:
                        f.TypeID = Convert.ToInt32(PubFunction.CodyType.AnesthesiaDoctor);
                        break;
                    case 17:
                        f.TypeID = Convert.ToInt32(PubFunction.CodyType.OperateRate);
                        break;
                    case 18://护士
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                        f.TypeID = Convert.ToInt32(PubFunction.CodyType.Nurse);
                        break;
                    default:
                        return;
                }
                try
                {
                    f.ShowDialog();

                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                this.SelectNextControl((Control)sender, true, false, true, true);
                //				if (Convert.ToInt32(txtssfj.Tag)>0)
                //				{
                //					DataTable tb=new DataTable();
                //					tb=PubFunction.AddRoomTc(Convert.ToInt32(txtssfj.Tag));
                //					cmbtc.Items.Clear();
                //					cmbtc.DisplayMember="tc";
                //					cmbtc.ValueMember="tcID";
                //					cmbtc.DataSource=tb;
                //					
                //				}
            }
        }

        #endregion

        #region 填充数据
        public void FillApp()
        {
            try
            {
                Operate s = new Operate();
                DataTable Tb = new DataTable();
                Tb = s.SeekAppRecord(this.sNo.ToString().Trim(), this.sInpatient_no);
                if (Tb.Rows.Count > 0)
                {
                    DataTable Tinpatient = new DataTable();
                    Tinpatient = PubFunction.SeekPatient(new Guid(Tb.Rows[0]["inpatient_id"].ToString()));
                    if (Tinpatient.Rows.Count == 0)
                    {
                        MessageBox.Show("没有找到病人");
                    }
                    this.lblsqdh.Text = Tb.Rows[0]["sno"].ToString().Trim();
                    this.lblbrxm.Text = Tinpatient.Rows[0]["name"].ToString().Trim();
                    this.lblcwh.Text = PubFunction.SeekBedNo(new Guid(Tinpatient.Rows[0]["BED_ID"].ToString()));
                    this.lblxb.Text = PubFunction.SeekSexName(Convert.ToInt32(Tinpatient.Rows[0]["sexcode"].ToString()));
                    this.lblnl.Text = age.ToString().Trim();

                    this.lblks.Text = PubFunction.SeekDeptName(Convert.ToInt32(Tinpatient.Rows[0]["dept_id"].ToString().Trim()));
                    this.lblbq.Text = PubFunction.SeekDeptName(Convert.ToInt32(Tinpatient.Rows[0]["dept_id"].ToString().Trim()));

                    this.lblsqzd.Text = "";
                    DataTable tb = new DataTable();
                    string ssql = "select * from ZY_DIAGNOSIS where inpatient_id='" + new Guid(Tinpatient.Rows[0]["inpatient_id"].ToString()) + "' and type=0 and serial_id=1";
                    tb = PubFunction.ExecsqlTable(ssql);
                    if (tb.Rows.Count > 0)
                    {
                        this.lblsqzd.Text = tb.Rows[0]["name"].ToString();
                        this.lblsqzd.Tag = tb.Rows[0]["icd"].ToString();
                    }

                    this.txtzyh.Text = Tb.Rows[0]["inpatient_no"].ToString().Trim();
                    this.txtzyh.Tag = Tinpatient.Rows[0]["inpatient_id"].ToString().Trim();
                    this.txtsg.Text = Tb.Rows[0]["sg"].ToString().Trim();
                    this.txttz.Text = Tb.Rows[0]["tz"].ToString().Trim();
                    this.txtywgms.Text = Tb.Rows[0]["ywgms"].ToString().Trim();
                    this.txtfz1.Tag = Tb.Rows[0]["ssfz"].ToString().Trim();
                    this.txtfz1.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ssfz"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Diagnose));
                    this.txtfz2.Tag = Tb.Rows[0]["ssfz1"].ToString().Trim();
                    this.txtfz2.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ssfz1"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Diagnose));
                    this.txtfz3.Tag = Tb.Rows[0]["ssfz2"].ToString().Trim();
                    this.txtfz3.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ssfz2"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Diagnose));
                    this.txtshzd.Tag = Tb.Rows[0]["SHZD"].ToString().Trim();
                    this.txtshzd.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["SHZD"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Diagnose));

                    if (this.txtshzd.Text.Trim() == "")
                    {
                        this.txtshzd.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ssfz"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Diagnose));
                    }
                    int flag = 0;//记录是否有输血项目
                    if (Tb.Rows[0]["hbsag"].ToString().Trim() == "阳性")
                    {
                        this.chkhbsagy.Checked = true;
                        chkhbsagy.ForeColor = Color.Blue;
                        flag = 1;
                    }
                    if (Tb.Rows[0]["hbsag"].ToString().Trim() == "阴性")
                    {
                        this.chkhbsagx.Checked = true;
                        chkhbsagx.ForeColor = Color.Blue;
                        flag = 1;
                    }
                    //ADD BY Zouchihua 2011-12-23
                    string cfg9005 = new SystemCfg(9005).Config.Trim();
                    if (cfg9005 == "0")
                    {
                        chkhbsagy.Enabled = false;
                        chkhbsagx.Enabled = false;
                    }
                    else
                    {
                        chkhbsagy.Enabled = true;
                        chkhbsagx.Enabled = true;
                    }


                    if (Tb.Rows[0]["KHCW"].ToString().Trim() == "阳性")
                    {
                        this.chkkhcvy.Checked = true;
                        chkkhcvy.ForeColor = Color.Blue;
                        flag = 1;
                    }
                    if (Tb.Rows[0]["KHCW"].ToString().Trim() == "阴性")
                    {
                        this.chkkhcvx.Checked = true;
                        chkkhcvx.ForeColor = Color.Blue;
                        flag = 1;
                    }

                    if (cfg9005 == "0")
                    {
                        chkkhcvy.Enabled = false;
                        chkkhcvx.Enabled = false;
                    }
                    else
                    {
                        chkkhcvy.Enabled = true;
                        chkkhcvx.Enabled = true;
                    }


                    if (Tb.Rows[0]["KHZV"].ToString().Trim() == "阳性")
                    {
                        this.chkkhzvy.Checked = true;
                        chkkhzvy.ForeColor = Color.Blue;
                        flag = 1;
                    }
                    if (Tb.Rows[0]["KHZV"].ToString().Trim() == "阴性")
                    {
                        this.chkkhzvx.Checked = true;
                        chkkhzvx.ForeColor = Color.Blue;
                        flag = 1;
                    }
                    if (cfg9005 == "0")
                    {
                        chkkhzvx.Enabled = false;
                        chkkhzvy.Enabled = false;
                    }
                    else
                    {
                        chkkhzvx.Enabled = true;
                        chkkhzvy.Enabled = true;
                    }


                    if (Tb.Rows[0]["KTP"].ToString().Trim() == "阳性")
                    {
                        this.chkktpy.Checked = true;
                        chkktpy.ForeColor = Color.Blue;
                        flag = 1;
                    }
                    if (Tb.Rows[0]["KTP"].ToString().Trim() == "阴性")
                    {
                        this.chkktpx.Checked = true;
                        chkktpx.ForeColor = Color.Blue;
                        flag = 1;
                    }
                    if (cfg9005 == "0")
                    {
                        chkktpy.Enabled = false;
                        chkktpx.Enabled = false;
                    }
                    else
                    {
                        chkktpy.Enabled = true;
                        chkktpx.Enabled = true;
                    }
                    if (cfg9005 == "0")
                    {
                        this.cbqt.Enabled = false;
                        cbqt.Enabled = false;
                    }
                    else
                    {
                        cbqt.Enabled = true;
                        cbqt.Enabled = true;
                    }
                    if (flag == 0)
                        cbqt.Checked = true;

                    //this.txtsstw.Tag=Tb.Rows[0]["sstw"].ToString().Trim();
                    //this.txtsstw.Text =PubFunction.SeekCalibrateName(Tb.Rows[0]["sstw"].ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.OperateBody ));
                    this.txtjsss1.Tag = Tb.Rows[0]["jsss"].ToString().Trim();
                    this.txtjsss1.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["jsss"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Operate));
                    this.txtjsss2.Tag = Tb.Rows[0]["jsss1"].ToString().Trim();
                    this.txtjsss2.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["jsss1"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Operate));
                    this.txtjsss3.Tag = Tb.Rows[0]["jsss2"].ToString().Trim();
                    this.txtjsss3.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["jsss2"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Operate));
                    this.txtjsss4.Tag = Tb.Rows[0]["jsss3"].ToString().Trim();
                    this.txtjsss4.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["jsss3"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Operate));
                    //不加载 modify by zouchihua 2012-02-09
                    if (Iscx)
                    {
                        this.txtzdys.Tag = Tb.Rows[0]["zdys"].ToString().Trim();
                        this.txtzdys.Text = PubFunction.SeekEmployeeName(Convert.ToInt32(Tb.Rows[0]["zdys"].ToString().Trim()));
                        this.txtssyz.Tag = Tb.Rows[0]["ssyz"].ToString().Trim();
                        this.txtssyz.Text = PubFunction.SeekEmployeeName(Convert.ToInt32(Tb.Rows[0]["ssyz"].ToString().Trim()));
                        this.txtssez.Tag = Tb.Rows[0]["ssez"].ToString().Trim();
                        this.txtssez.Text = PubFunction.SeekEmployeeName(Convert.ToInt32(Tb.Rows[0]["ssez"].ToString().Trim()));
                        this.txtsssz.Tag = Tb.Rows[0]["sssz"].ToString().Trim();
                        this.txtsssz.Text = PubFunction.SeekEmployeeName(Convert.ToInt32(Tb.Rows[0]["sssz"].ToString().Trim()));


                        // this.lblysrq.Text = Tb.Rows[0]["ysssrq"].ToString().Trim();
                        //this.txtbz.Text = Tb.Rows[0]["ssbz"].ToString().Trim();
                    }
                    //**********************************
                    //add by zouchihua 2013-5-21
                    this.txtjsmz.Tag = Tb.Rows[0]["jsmz"].ToString().Trim();
                    this.txtjsmz.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["jsmz"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Anesthesia));
                    this.checksstys.Checked = Convert.ToBoolean(Convert.ToInt32(Tb.Rows[0]["sstys"].ToString().Trim()));
                    this.checkmztys.Checked = Convert.ToBoolean(Convert.ToInt32(Tb.Rows[0]["mztys"].ToString().Trim()));
                    this.checkjzss.Checked = Convert.ToBoolean(Convert.ToInt32(Tb.Rows[0]["jzss"].ToString().Trim()));

                    this.txtssdj.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ssdj"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.OperateRate));
                    this.txtssdj.Tag = Tb.Rows[0]["ssdj"].ToString().Trim();
                    //不加载 modify by zouchihua 2012-02-09
                    if (Iscx)
                    {
                        this.txtzmys.Tag = Tb.Rows[0]["mzys"].ToString().Trim();
                        this.txtzmys.Text = PubFunction.SeekEmployeeName(Convert.ToInt32(Tb.Rows[0]["mzys"].ToString().Trim()));
                        this.txtfmys.Tag = Tb.Rows[0]["mzys1"].ToString().Trim();
                        this.txtfmys.Text = PubFunction.SeekEmployeeName(Convert.ToInt32(Tb.Rows[0]["mzys1"].ToString().Trim()));

                        //辅麻医生
                        this.txtfmys2.Tag = Tb.Rows[0]["mzys2"].ToString().Trim() == "" ? "0" : Tb.Rows[0]["mzys2"].ToString().Trim();
                        this.txtfmys2.Text = PubFunction.SeekEmployeeName(Convert.ToInt32((Tb.Rows[0]["mzys2"].ToString().Trim() == "" ? "0" : Tb.Rows[0]["mzys2"].ToString().Trim())));

                        this.txtfmys3.Tag = Tb.Rows[0]["mzys3"].ToString().Trim() == "" ? "0" : Tb.Rows[0]["mzys3"].ToString().Trim();
                        this.txtfmys3.Text = PubFunction.SeekEmployeeName(Convert.ToInt32((Tb.Rows[0]["mzys3"].ToString().Trim() == "" ? "0" : Tb.Rows[0]["mzys3"].ToString().Trim())));


                    }
                }

                Tb = s.SeekArrRecord(this.sNo.ToString().Trim());
                if (Tb.Rows.Count > 0)
                {
                    this.checkjzss.Checked = false;
                    this.checkmztys.Checked = false;
                    this.checksstys.Checked = false;

                    this.txtysss.Tag = Tb.Rows[0]["ysss"].ToString().Trim();
                    this.txtysss.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ysss"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Operate));
                    this.txtysmz.Tag = Tb.Rows[0]["ysmz"].ToString().Trim();
                    this.txtysmz.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ysmz"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Anesthesia));

                    //不加载 modify by zouchihua 2012-02-09
                    if (Iscx)
                    {
                        this.txtyxss.Tag = Tb.Rows[0]["yxss"].ToString().Trim();
                        this.txtyxss.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["yxss"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Operate));
                    }
                    this.txtyxmz.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["yxmz"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Anesthesia));
                    this.txtyxmz.Tag = Tb.Rows[0]["yxmz"].ToString().Trim();
                    //add by zouchihua 2013-5-9  拟施手术是否自动提出从医生申请的手术 0=否 1=是
                    if (this.txtyxss.Text.Trim() == "")
                    {
                        string ysss = "0";
                        try
                        {
                            ysss = ApiFunction.GetIniString("Shbl", "ysss", Constant.ApplicationDirectory + "\\Shbl_Set.ini");
                        }
                        catch
                        {

                        }
                        if (ysss.Trim() == "1")
                        {
                            this.txtyxss.Tag = Tb.Rows[0]["yxss"].ToString().Trim();
                            this.txtyxss.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ysss"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Operate));
                        }
                    }

                    if (this.txtyxmz.Text.Trim() == "")
                    {
                        this.txtyxmz.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["yxmz"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Anesthesia));
                    }

                    this.txtyxmz2.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["yxmz2"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Anesthesia));
                    this.txtyxmz2.Tag = Tb.Rows[0]["yxmz2"].ToString().Trim();
                    //********************************
                    this.lblyxrq.Text = Tb.Rows[0]["yxssrq"].ToString().Trim();
                    string xsStr = PubFunction.SeekCalibrateName(Tb.Rows[0]["xshs"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Nurse));
                    string xhStr = PubFunction.SeekCalibrateName(Tb.Rows[0]["xhhs"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Nurse));
                    //不加载 modify by zouchihua 2012-02-09
                    if (Iscx == true)
                    {
                        this.txtxshs1.Text = xsStr.Trim() == "" ? Tb.Rows[0]["xshs_name"].ToString().Trim() : xsStr;
                        this.txtxshs1.Tag = Tb.Rows[0]["xshs"].ToString().Trim();
                        this.txtxshs2.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["xshs1"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Nurse));
                        this.txtxshs2.Tag = Tb.Rows[0]["xshs1"].ToString().Trim();
                        this.txtxshs3.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["xshs2"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Nurse));
                        this.txtxshs3.Tag = Tb.Rows[0]["xshs2"].ToString().Trim();
                        this.txtxhhs1.Text = xhStr.Trim() == "" ? Tb.Rows[0]["xhhs_name"].ToString().Trim() : xhStr;
                        this.txtxhhs1.Tag = Tb.Rows[0]["xhhs"].ToString().Trim();
                        this.txtxhhs2.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["xhhs1"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Nurse));
                        this.txtxhhs2.Tag = Tb.Rows[0]["xhhs1"].ToString().Trim();
                        this.txtxhhs3.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["xhhs2"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Nurse));
                        this.txtxhhs3.Tag = Tb.Rows[0]["xhhs2"].ToString().Trim();
                        //add by zouchihua 2013-5-21
                        this.combWqssyy.Text = Tb.Rows[0]["wssqyy"].ToString().Trim();
                        this.combNzwyw.Text = Tb.Rows[0]["nzwyw"].ToString().Trim();
                    }
                    //**************************
                    this.txtqjb.Tag = Tb.Rows[0]["ssqjb"].ToString().Trim();
                    this.txtqjb.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["ssqjb"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.AppBundle));
                    this.txtssfj.Text = PubFunction.SeekCalibrateName(Tb.Rows[0]["sstc"].ToString().Trim(), Convert.ToInt32(PubFunction.CodyType.Room));
                    this.txtssfj.Tag = Tb.Rows[0]["sstc"].ToString();

                    string sys_date = PubFunction.sys_date();
                    this.dtpksrq.Value = Tb.Rows[0]["ssbeginrq"] == System.DBNull.Value ? Convert.ToDateTime(sys_date) : Convert.ToDateTime(Tb.Rows[0]["ssbeginrq"]);
                    this.dtpkssj.Value = Tb.Rows[0]["ssbeginrq"] == System.DBNull.Value ? Convert.ToDateTime(sys_date) : Convert.ToDateTime(Tb.Rows[0]["ssbeginrq"]);
                    this.dtpjsrq.Value = Tb.Rows[0]["ssendrq"] == System.DBNull.Value ? Convert.ToDateTime(sys_date) : Convert.ToDateTime(Tb.Rows[0]["ssendrq"]);
                    this.dtpjssj.Value = Tb.Rows[0]["ssendrq"] == System.DBNull.Value ? Convert.ToDateTime(sys_date) : Convert.ToDateTime(Tb.Rows[0]["ssendrq"]);
                    comboBox2.SelectedValue = Tb.Rows[0]["qkyhdjid"];
                    comboBox1.SelectedValue = Tb.Rows[0]["qklxid"];
                    #region// add by zouchihua 2011-12-23
                    this.cmbNjmc.Text = Tb.Rows[0]["njmc"].ToString().Trim();
                    this.cmbnnisfj.Text = Tb.Rows[0]["nnisfj"].ToString().Trim();
                    this.cmbMzfxpg.Text = Tb.Rows[0]["mzfxpg"].ToString().Trim();
                    this.cmbcg.Text = Tb.Rows[0]["cglx"].ToString().Trim();
                    this.txtXsl.Text = Tb.Rows[0]["sxl"].ToString().Trim();
                    this.txtNzwmc.Text = Tb.Rows[0]["nzwmc"].ToString().Trim();
                    this.txtNzwcj.Text = Tb.Rows[0]["nzwcj"].ToString().Trim();
                    this.txtNzwghs.Text = Tb.Rows[0]["nzwghgs"].ToString().Trim();// nzwmc,nzwghgs,nzwcj
                    #endregion
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message + err.Source);
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
            if (control.Tag.ToString().Trim() == "") return;
            //			switch(control.TabIndex)
            //			{
            //				//case 0://手术代码
            //////				case 7:
            //////				case 8:
            //////				case 9:
            //////				case 10:
            //////					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.Operate));
            //////					break;	
            //				case 1:  //麻醉名称
            //				case 2:
            //					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.Anesthesia));		
            //					break;						
            //////				case 3://诊断
            //////				case 4:
            //////				case 5:
            //////				case 6:
            //////					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.Diagnose));
            //////					break;	
            //				case 11://主刀医生助手
            //				case 12:
            //				case 13:
            //				case 14:
            //					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.OperateDoctor));
            //					break;
            //				case 15://麻醉医生
            //				case 16:
            //					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.AnesthesiaDoctor));
            //					break;
            //				case 17:
            //					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.OperateRate));
            //					break;
            //				case 18://护士
            //				case 19:
            //				case 20:
            //				case 21:
            //				case 22:
            //				case 23:
            //					control.Text=PubFunction.SeekCalibrateName(control.Tag.ToString().Trim(),Convert.ToInt32(PubFunction.CodyType.Nurse));
            //					break;
            //				default:
            //					return;
            //			}
        }
        #endregion

        #region 退出
        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();

        }
        #endregion



        private void chkhbsagy_CheckedChanged(object sender, EventArgs e)
        {
            chkhbsagy.ForeColor = chkhbsagx.Parent.ForeColor;
            this.chkhbsagx.ForeColor = chkhbsagx.Parent.ForeColor;
            chkkhcvx.ForeColor = chkhbsagx.Parent.ForeColor;
            chkkhcvy.ForeColor = chkhbsagx.Parent.ForeColor;
            chkkhzvx.ForeColor = chkhbsagx.Parent.ForeColor;
            chkkhzvy.ForeColor = chkhbsagx.Parent.ForeColor;
            chkktpx.ForeColor = chkhbsagx.Parent.ForeColor;
            chkktpy.ForeColor = chkhbsagx.Parent.ForeColor;
            System.Windows.Forms.RadioButton cb = sender as RadioButton;
            if (cb.Checked)
            {
                this.cbqt.Checked = false;
                //cb.BackColor = Color.Blue;
            }
        }

        private void cbqt_CheckedChanged(object sender, EventArgs e)
        {
            //add by zouchihua 2011-01-04 选中，其余四项都不选
            if (this.cbqt.Checked)
            {
                chkhbsagy.Checked = false;
                this.chkhbsagx.Checked = false;
                chkkhcvx.Checked = false;
                chkkhcvy.Checked = false;
                chkkhzvx.Checked = false;
                chkkhzvy.Checked = false;
                chkktpx.Checked = false;
                chkktpy.Checked = false;
            }
        }

        private void txtNzwghs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.Bsave.Focus();
            }
        }

        //Add By Tany 2015-01-30 直接完成手术
        private void btZjwc_Click(object sender, EventArgs e)
        {
            string ssmz = isSSKS ? "手术" : "麻醉";

            if (MessageBox.Show(this, "点击完成后程序将不会更新" + ssmz + "相关信息，仅将该" + ssmz + "标记为完成状态！！！\r\n\r\n您确认吗?", "" + ssmz + "完成", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    //Modify By Tany 2015-04-08 手术和麻醉完成的内容不一样
                    FrmMdiMain.Database.BeginTransaction();
                    string ssql;
                    if (isSSKS)
                    {
                        //更新房间占用标志
                        if (IsGuid(this.txtssfj.Tag.ToString()))
                        {
                            ssql = "update ss_roomtc set flag=0 where id='" + this.txtssfj.Tag.ToString() + "'";
                            FrmMdiMain.Database.DoCommand(ssql);
                        }
                        //增加更新安排标志 Modify By Tany 2015-04-20
                        ssql = "update ss_apprecord set apbj=1 where sno='" + this.sNo.Trim() + "'";
                        FrmMdiMain.Database.DoCommand(ssql);
                        //更新安排表
                        ssql = "update ss_arrrecord set " +
                            " wcbj = 1,wcsj = getdate()" +
                            " where sno='" + this.sNo.Trim() + "'";
                        FrmMdiMain.Database.DoCommand(ssql);
                        //插入日志
                        ssql = "insert into ss_log(id,sno,inpatient_name,sbz,djrq,czy)values('" + TrasenClasses.GeneralClasses.PubStaticFun.NewGuid() + "','" + this.sNo.ToString().Trim() + "','','手术完成',getdate()," + PubFunction.AuserEmployeeID + ")";
                        FrmMdiMain.Database.DoCommand(ssql);
                    }
                    else if (isMZKS)
                    {
                        //更新安排表
                        ssql = "update ss_arrrecord set " +
                            " mzwcbj = 1,mzwcsj = getdate()," +
                            " mzwcczy=" + FrmMdiMain.CurrentUser.EmployeeId +
                            " where sno='" + this.sNo.Trim() + "'";
                        FrmMdiMain.Database.DoCommand(ssql);
                    }
                    FrmMdiMain.Database.CommitTransaction();
                    MessageBox.Show(isSSKS ? "手术完成！" : "麻醉完成！");
                    PubFunction.shbl = true;
                    this.Close();
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

        //Add By Tany 2015-04-08
        private void GetSSMZDept()
        {
            string ssql = "SELECT * FROM SS_DEPT WHERE DEPTID=" + FrmMdiMain.CurrentDept.DeptId + "";
            DataTable tb = FrmMdiMain.Database.GetDataTable(ssql);
            try
            {
                if (tb == null || tb.Rows.Count == 0)
                {
                    MessageBox.Show("该科室非手术麻醉科室！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (Convert.ToInt32(tb.Rows[0]["type"]) == 0)
                    {
                        isSSKS = true;
                    }
                    if (Convert.ToInt32(tb.Rows[0]["type"]) == 1)
                    {
                        isMZKS = true;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
