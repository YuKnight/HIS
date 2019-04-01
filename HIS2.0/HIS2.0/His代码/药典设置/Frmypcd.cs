using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
//using YpClass;
using System.Transactions;
using TrasenClasses.DatabaseAccess;
using System.Collections.Generic;

using ts_SCM_HIS;
using System.Text;


namespace ts_yp_ypcd
{
    /// <summary>
    /// Frmypcd 药品字典定义
    /// </summary>
    public class Frmypcd : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txttxm;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.CheckBox chkwyyp;
        private System.Windows.Forms.CheckBox chkjsyp;
        private System.Windows.Forms.CheckBox chkpsyp;
        private System.Windows.Forms.CheckBox chkmzyp;
        private System.Windows.Forms.CheckBox chkdjyp;
        private System.Windows.Forms.CheckBox chkgzyp;
        private System.Windows.Forms.TextBox txtzglsj;
        private System.Windows.Forms.TextBox txtmrkl;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtmrjj;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtpzwh;
        private System.Windows.Forms.TextBox txtzfbl;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtsyff;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtylfl;
        private System.Windows.Forms.TextBox txtbz;
        private System.Windows.Forms.TextBox txtzzbz;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butnext;
        private System.Windows.Forms.Button butup;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butdel;
        private System.Windows.Forms.Button butnewcj;
        private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.Button butnewgg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkstop;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtlsj;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtpfj;
        private System.Windows.Forms.TextBox txtsccj;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtbzdw;
        private System.Windows.Forms.TextBox txtbzsl;
        private System.Windows.Forms.TextBox txthldw;
        private System.Windows.Forms.TextBox txthlxs;
        private System.Windows.Forms.TextBox txtypgg;
        private System.Windows.Forms.TextBox txtypspm;
        private System.Windows.Forms.TextBox txtypjx;
        private System.Windows.Forms.TextBox txtypdw;
        private System.Windows.Forms.TextBox txtypspmbz;
        private System.Windows.Forms.TextBox txtwbm;
        private System.Windows.Forms.TextBox txtpym;
        private System.Windows.Forms.TextBox txtyppm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbypzlx;
        private System.Windows.Forms.ComboBox cmbyplx;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbcfjb;
        private System.Windows.Forms.CheckBox chkcfyp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private myDataGrid.myDataGrid myDataGrid1;
        private System.Windows.Forms.CheckBox chkspm;
        private System.Windows.Forms.TextBox txtbmszm;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtbmwbm;
        private System.Windows.Forms.TextBox txtbmywm;
        private System.Windows.Forms.TextBox txtypbm;
        private System.Windows.Forms.TextBox txtbmpym;
        private System.Windows.Forms.Button but_bm_new;
        private System.Windows.Forms.Button but_bm_del;
        private System.Windows.Forms.Button but_bm_save;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.ComboBox cmblyfs;
        private System.Windows.Forms.ComboBox cmbtlfl;
        private System.Windows.Forms.Label label27;
        private int _Cjid = 0;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cmbyblx;
        private System.Windows.Forms.TextBox txthwjxbm;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtypywm;
        private System.Windows.Forms.Label label31;
        private TextBox txthh;
        private Label label32;
        private CheckBox chkrsyp;
        private string YpConfig_lsj;
        private TextBox txtzt;
        private Label label33;
        private CheckBox chkzbzt;
        private GroupBox groupBox5;
        private TextBox txtDdd;
        private Label label38;
        private ComboBox cmbKssdj;
        private Label label34;
        private CheckBox chkgjjbyw;
        private TextBox txtcglsh;
        private Label label41;
        private CheckBox chkgwyp;
        private ComboBox cmbjsypfl;
        private Label lbljsypfl;
        private Panel panel_3;
        private Panel panel_1;
        private Panel panel_2;
        private TextBox txtghdw;
        private Label label45;
        private TextBox txtfkbl;
        private Label label46;
        private Label label47;
        private TextBox txtDDDjldw;
        private Label label49;
        private TextBox txtDDDjl;
        private Label label48;
        private CheckBox chkbhtdw;
        private CheckBox chkdpzyp;

        private bool bmrzbzt = false;//默认中标状态
        private bool bsswr_lsj = true;
        private ComboBox cmbJbyw;
        private ComboBox cmbGwypjb;
        private CheckBox chwbyp; //零售价按批发价 比例计算时四舍五入

        private bool isWbks = false;
        private CheckBox chkFzYy;
        private CheckBox chkFsx;
        private CheckBox chkhlyw;//Add By Tany 2015-11-24

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// 构造函数，添加药品类型、子类型、用法、领药方式等
        /// </summary>
        public Frmypcd()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            if (InstanceForm._menuTag.Function_Name == "Fun_ts_yp_ypcd" && InstanceForm.BCurrentUser.IsAdministrator == false)
                Yp.AddCmbYplx(false, InstanceForm.BCurrentDept.DeptId, cmbyplx, InstanceForm.BDatabase);
            else
                Yp.AddCmbYplx(false, 0, cmbyplx, InstanceForm.BDatabase);

            Yp.AddcmbYblx(cmbyblx, InstanceForm.BDatabase);

            Yp.AddcmbLyfs(cmblyfs, InstanceForm.BDatabase);
            Yp.Addcmbtlfl(cmbtlfl, InstanceForm.BDatabase);
            Yp.AddcmbKsskj(cmbKssdj, InstanceForm.BDatabase);
            cmbyplx.Focus();

            //Add By Tany 2015-05-25
            Yp.AddcmbJbyw(cmbJbyw, InstanceForm.BDatabase);

            YpConfig_lsj = new SystemCfg(8011).Config;

            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            this.txtfkbl.Text = "100.00";

            SystemCfg cfg8055 = new SystemCfg(8055);
            if (cfg8055.Config == "1")
            {
                bmrzbzt = true;
                chkzbzt.Checked = bmrzbzt;
            }
            else
            {
                bmrzbzt = false;
            }

            SystemCfg cfg8060 = new SystemCfg(8060);
            if (cfg8060.Config == "1")
            {
                bsswr_lsj = false;
            }

        }

        /// <summary>
        /// 构造函数,添加药品类型、子类型、用法、领药方式等
        /// </summary>
        /// <param name="cjid">药品CJID</param>
        public Frmypcd(int cjid)
        {
            InitializeComponent();

            if (InstanceForm._menuTag.Function_Name == "Fun_ts_yp_ypcd" && InstanceForm.BCurrentUser.IsAdministrator == false)
                Yp.AddCmbYplx(false, InstanceForm.BCurrentDept.DeptId, cmbyplx, InstanceForm.BDatabase);
            else
                Yp.AddCmbYplx(false, 0, cmbyplx, InstanceForm.BDatabase);

            Yp.AddcmbYblx(cmbyblx, InstanceForm.BDatabase);

            Yp.AddcmbLyfs(cmblyfs, InstanceForm.BDatabase);
            Yp.Addcmbtlfl(cmbtlfl, InstanceForm.BDatabase);
            Yp.AddcmbKsskj(cmbKssdj, InstanceForm.BDatabase);

            //Add By Tany 2015-05-25
            Yp.AddcmbJbyw(cmbJbyw, InstanceForm.BDatabase);

            cmbyplx.Focus();
            YpConfig_lsj = new SystemCfg(8011).Config;
            _Cjid = cjid;

            //FillYp(cjid);
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel_1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chwbyp = new System.Windows.Forms.CheckBox();
            this.chkbhtdw = new System.Windows.Forms.CheckBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtfkbl = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtypywm = new System.Windows.Forms.TextBox();
            this.cmblyfs = new System.Windows.Forms.ComboBox();
            this.chkstop = new System.Windows.Forms.CheckBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtlsj = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtpfj = new System.Windows.Forms.TextBox();
            this.txtsccj = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbzdw = new System.Windows.Forms.TextBox();
            this.txtbzsl = new System.Windows.Forms.TextBox();
            this.txthldw = new System.Windows.Forms.TextBox();
            this.txthlxs = new System.Windows.Forms.TextBox();
            this.txtypgg = new System.Windows.Forms.TextBox();
            this.txtypspm = new System.Windows.Forms.TextBox();
            this.txtypjx = new System.Windows.Forms.TextBox();
            this.txtypdw = new System.Windows.Forms.TextBox();
            this.txtypspmbz = new System.Windows.Forms.TextBox();
            this.txtwbm = new System.Windows.Forms.TextBox();
            this.txtpym = new System.Windows.Forms.TextBox();
            this.txtyppm = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbypzlx = new System.Windows.Forms.ComboBox();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.cmbtlfl = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.panel_2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkhlyw = new System.Windows.Forms.CheckBox();
            this.chkFsx = new System.Windows.Forms.CheckBox();
            this.chkFzYy = new System.Windows.Forms.CheckBox();
            this.cmbGwypjb = new System.Windows.Forms.ComboBox();
            this.cmbJbyw = new System.Windows.Forms.ComboBox();
            this.chkdpzyp = new System.Windows.Forms.CheckBox();
            this.txtghdw = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.cmbjsypfl = new System.Windows.Forms.ComboBox();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.lbljsypfl = new System.Windows.Forms.Label();
            this.chkgjjbyw = new System.Windows.Forms.CheckBox();
            this.chkzbzt = new System.Windows.Forms.CheckBox();
            this.txtzt = new System.Windows.Forms.TextBox();
            this.chkrsyp = new System.Windows.Forms.CheckBox();
            this.txthh = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txthwjxbm = new System.Windows.Forms.TextBox();
            this.cmbyblx = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cmbcfjb = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chkwyyp = new System.Windows.Forms.CheckBox();
            this.chkpsyp = new System.Windows.Forms.CheckBox();
            this.chkcfyp = new System.Windows.Forms.CheckBox();
            this.chkdjyp = new System.Windows.Forms.CheckBox();
            this.txtzglsj = new System.Windows.Forms.TextBox();
            this.txtmrkl = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtmrjj = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtpzwh = new System.Windows.Forms.TextBox();
            this.txtzfbl = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.txtsyff = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtylfl = new System.Windows.Forms.TextBox();
            this.txtzzbz = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.chkmzyp = new System.Windows.Forms.CheckBox();
            this.chkgzyp = new System.Windows.Forms.CheckBox();
            this.chkjsyp = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.chkgwyp = new System.Windows.Forms.CheckBox();
            this.panel_3 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtDDDjldw = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.txtDDDjl = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txtDdd = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.cmbKssdj = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtcglsh = new System.Windows.Forms.TextBox();
            this.txttxm = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butnext = new System.Windows.Forms.Button();
            this.butup = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butnewcj = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.butnewgg = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.but_bm_save = new System.Windows.Forms.Button();
            this.but_bm_del = new System.Windows.Forms.Button();
            this.but_bm_new = new System.Windows.Forms.Button();
            this.chkspm = new System.Windows.Forms.CheckBox();
            this.txtbmszm = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txtbmwbm = new System.Windows.Forms.TextBox();
            this.txtbmywm = new System.Windows.Forms.TextBox();
            this.txtypbm = new System.Windows.Forms.TextBox();
            this.txtbmpym = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel_1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel_2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel_3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(697, 603);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel_1);
            this.tabPage1.Controls.Add(this.panel_2);
            this.tabPage1.Controls.Add(this.panel_3);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(689, 577);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "药品信息";
            // 
            // panel_1
            // 
            this.panel_1.Controls.Add(this.groupBox1);
            this.panel_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_1.Location = new System.Drawing.Point(0, 0);
            this.panel_1.Name = "panel_1";
            this.panel_1.Size = new System.Drawing.Size(555, 241);
            this.panel_1.TabIndex = 152;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.chwbyp);
            this.groupBox1.Controls.Add(this.chkbhtdw);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.txtfkbl);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.txtypywm);
            this.groupBox1.Controls.Add(this.cmblyfs);
            this.groupBox1.Controls.Add(this.chkstop);
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.txtlsj);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txtpfj);
            this.groupBox1.Controls.Add(this.txtsccj);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtbzdw);
            this.groupBox1.Controls.Add(this.txtbzsl);
            this.groupBox1.Controls.Add(this.txthldw);
            this.groupBox1.Controls.Add(this.txthlxs);
            this.groupBox1.Controls.Add(this.txtypgg);
            this.groupBox1.Controls.Add(this.txtypspm);
            this.groupBox1.Controls.Add(this.txtypjx);
            this.groupBox1.Controls.Add(this.txtypdw);
            this.groupBox1.Controls.Add(this.txtypspmbz);
            this.groupBox1.Controls.Add(this.txtwbm);
            this.groupBox1.Controls.Add(this.txtpym);
            this.groupBox1.Controls.Add(this.txtyppm);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbypzlx);
            this.groupBox1.Controls.Add(this.cmbyplx);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.cmbtlfl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 241);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // chwbyp
            // 
            this.chwbyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chwbyp.ForeColor = System.Drawing.Color.Black;
            this.chwbyp.Location = new System.Drawing.Point(176, 111);
            this.chwbyp.Name = "chwbyp";
            this.chwbyp.Size = new System.Drawing.Size(80, 24);
            this.chwbyp.TabIndex = 181;
            this.chwbyp.Text = "外部药品";
            // 
            // chkbhtdw
            // 
            this.chkbhtdw.AutoSize = true;
            this.chkbhtdw.ForeColor = System.Drawing.Color.Black;
            this.chkbhtdw.Location = new System.Drawing.Point(422, 218);
            this.chkbhtdw.Name = "chkbhtdw";
            this.chkbhtdw.Size = new System.Drawing.Size(72, 16);
            this.chkbhtdw.TabIndex = 179;
            this.chkbhtdw.Text = "合同单位";
            this.chkbhtdw.UseVisualStyleBackColor = true;
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(402, 217);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(16, 15);
            this.label47.TabIndex = 177;
            this.label47.Text = "%";
            // 
            // txtfkbl
            // 
            this.txtfkbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfkbl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfkbl.ForeColor = System.Drawing.Color.Blue;
            this.txtfkbl.Location = new System.Drawing.Point(328, 214);
            this.txtfkbl.Name = "txtfkbl";
            this.txtfkbl.Size = new System.Drawing.Size(72, 21);
            this.txtfkbl.TabIndex = 22;
            this.txtfkbl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label46.Location = new System.Drawing.Point(266, 215);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(60, 19);
            this.label46.TabIndex = 176;
            this.label46.Text = "付款比例";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtypywm
            // 
            this.txtypywm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtypywm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtypywm.ForeColor = System.Drawing.Color.Blue;
            this.txtypywm.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtypywm.Location = new System.Drawing.Point(384, 40);
            this.txtypywm.Name = "txtypywm";
            this.txtypywm.Size = new System.Drawing.Size(144, 21);
            this.txtypywm.TabIndex = 4;
            this.txtypywm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // cmblyfs
            // 
            this.cmblyfs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmblyfs.ForeColor = System.Drawing.Color.Blue;
            this.cmblyfs.Location = new System.Drawing.Point(274, 163);
            this.cmblyfs.Name = "cmblyfs";
            this.cmblyfs.Size = new System.Drawing.Size(105, 20);
            this.cmblyfs.TabIndex = 16;
            this.cmblyfs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // chkstop
            // 
            this.chkstop.ForeColor = System.Drawing.Color.Red;
            this.chkstop.Location = new System.Drawing.Point(344, 88);
            this.chkstop.Name = "chkstop";
            this.chkstop.Size = new System.Drawing.Size(112, 24);
            this.chkstop.TabIndex = 170;
            this.chkstop.Text = "停用状态";
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(221, 169);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(61, 19);
            this.label42.TabIndex = 169;
            this.label42.Text = "领药方式";
            // 
            // txtlsj
            // 
            this.txtlsj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtlsj.ForeColor = System.Drawing.Color.Blue;
            this.txtlsj.Location = new System.Drawing.Point(464, 188);
            this.txtlsj.Name = "txtlsj";
            this.txtlsj.Size = new System.Drawing.Size(64, 21);
            this.txtlsj.TabIndex = 20;
            this.txtlsj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(420, 192);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 19);
            this.label21.TabIndex = 167;
            this.label21.Text = "零售价";
            // 
            // txtpfj
            // 
            this.txtpfj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpfj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpfj.ForeColor = System.Drawing.Color.Blue;
            this.txtpfj.Location = new System.Drawing.Point(328, 188);
            this.txtpfj.Name = "txtpfj";
            this.txtpfj.Size = new System.Drawing.Size(72, 21);
            this.txtpfj.TabIndex = 19;
            this.txtpfj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtpfj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtsccj
            // 
            this.txtsccj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsccj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtsccj.ForeColor = System.Drawing.Color.Blue;
            this.txtsccj.Location = new System.Drawing.Point(72, 188);
            this.txtsccj.Name = "txtsccj";
            this.txtsccj.Size = new System.Drawing.Size(208, 21);
            this.txtsccj.TabIndex = 18;
            this.txtsccj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtsccj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(32, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 18);
            this.label8.TabIndex = 158;
            this.label8.Text = "剂量";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtbzdw
            // 
            this.txtbzdw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbzdw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbzdw.ForeColor = System.Drawing.Color.Blue;
            this.txtbzdw.Location = new System.Drawing.Point(464, 137);
            this.txtbzdw.Name = "txtbzdw";
            this.txtbzdw.Size = new System.Drawing.Size(64, 21);
            this.txtbzdw.TabIndex = 14;
            this.txtbzdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtbzdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtbzsl
            // 
            this.txtbzsl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbzsl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbzsl.ForeColor = System.Drawing.Color.Blue;
            this.txtbzsl.Location = new System.Drawing.Point(331, 137);
            this.txtbzsl.Name = "txtbzsl";
            this.txtbzsl.Size = new System.Drawing.Size(72, 21);
            this.txtbzsl.TabIndex = 13;
            this.txtbzsl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtbzsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txthldw
            // 
            this.txthldw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txthldw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txthldw.ForeColor = System.Drawing.Color.Blue;
            this.txthldw.Location = new System.Drawing.Point(200, 137);
            this.txthldw.Name = "txthldw";
            this.txthldw.Size = new System.Drawing.Size(72, 21);
            this.txthldw.TabIndex = 12;
            this.txthldw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txthldw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txthlxs
            // 
            this.txthlxs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txthlxs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txthlxs.ForeColor = System.Drawing.Color.Blue;
            this.txthlxs.Location = new System.Drawing.Point(72, 137);
            this.txthlxs.Name = "txthlxs";
            this.txthlxs.Size = new System.Drawing.Size(72, 21);
            this.txthlxs.TabIndex = 11;
            this.txthlxs.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txthlxs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtypgg
            // 
            this.txtypgg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtypgg.ForeColor = System.Drawing.Color.Blue;
            this.txtypgg.Location = new System.Drawing.Point(72, 163);
            this.txtypgg.Name = "txtypgg";
            this.txtypgg.Size = new System.Drawing.Size(146, 21);
            this.txtypgg.TabIndex = 15;
            this.txtypgg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtypspm
            // 
            this.txtypspm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtypspm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtypspm.ForeColor = System.Drawing.Color.Blue;
            this.txtypspm.Location = new System.Drawing.Point(72, 64);
            this.txtypspm.Name = "txtypspm";
            this.txtypspm.Size = new System.Drawing.Size(256, 21);
            this.txtypspm.TabIndex = 5;
            this.txtypspm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtypjx
            // 
            this.txtypjx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtypjx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtypjx.ForeColor = System.Drawing.Color.Blue;
            this.txtypjx.Location = new System.Drawing.Point(432, 14);
            this.txtypjx.Name = "txtypjx";
            this.txtypjx.Size = new System.Drawing.Size(96, 21);
            this.txtypjx.TabIndex = 2;
            this.txtypjx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtypjx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtypdw
            // 
            this.txtypdw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtypdw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtypdw.ForeColor = System.Drawing.Color.Blue;
            this.txtypdw.Location = new System.Drawing.Point(72, 113);
            this.txtypdw.Name = "txtypdw";
            this.txtypdw.Size = new System.Drawing.Size(72, 21);
            this.txtypdw.TabIndex = 10;
            this.txtypdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtypdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtypspmbz
            // 
            this.txtypspmbz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtypspmbz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtypspmbz.ForeColor = System.Drawing.Color.Blue;
            this.txtypspmbz.Location = new System.Drawing.Point(384, 64);
            this.txtypspmbz.Name = "txtypspmbz";
            this.txtypspmbz.Size = new System.Drawing.Size(144, 21);
            this.txtypspmbz.TabIndex = 6;
            this.txtypspmbz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtwbm
            // 
            this.txtwbm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtwbm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtwbm.ForeColor = System.Drawing.Color.Blue;
            this.txtwbm.Location = new System.Drawing.Point(224, 88);
            this.txtwbm.Name = "txtwbm";
            this.txtwbm.Size = new System.Drawing.Size(96, 21);
            this.txtwbm.TabIndex = 8;
            this.txtwbm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtpym
            // 
            this.txtpym.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpym.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpym.ForeColor = System.Drawing.Color.Blue;
            this.txtpym.Location = new System.Drawing.Point(72, 88);
            this.txtpym.Name = "txtpym";
            this.txtpym.Size = new System.Drawing.Size(92, 21);
            this.txtpym.TabIndex = 7;
            this.txtpym.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtyppm
            // 
            this.txtyppm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtyppm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtyppm.ForeColor = System.Drawing.Color.Blue;
            this.txtyppm.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtyppm.Location = new System.Drawing.Point(72, 40);
            this.txtyppm.Name = "txtyppm";
            this.txtyppm.Size = new System.Drawing.Size(256, 21);
            this.txtyppm.TabIndex = 3;
            this.txtyppm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(408, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 19);
            this.label11.TabIndex = 161;
            this.label11.Text = "包装单位";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(280, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 19);
            this.label10.TabIndex = 160;
            this.label10.Text = "包装数量";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(144, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 19);
            this.label9.TabIndex = 159;
            this.label9.Text = "剂量单位";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(328, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 153;
            this.label3.Text = "名称备注";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(400, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 19);
            this.label7.TabIndex = 150;
            this.label7.Text = "剂型";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(32, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 19);
            this.label6.TabIndex = 149;
            this.label6.Text = "单位";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label15.Location = new System.Drawing.Point(8, 165);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 14);
            this.label15.TabIndex = 151;
            this.label15.Text = "药品规格";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(176, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 148;
            this.label5.Text = "五笔码";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(8, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 147;
            this.label4.Text = "拼音码";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbypzlx
            // 
            this.cmbypzlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbypzlx.ForeColor = System.Drawing.Color.Blue;
            this.cmbypzlx.Location = new System.Drawing.Point(272, 15);
            this.cmbypzlx.Name = "cmbypzlx";
            this.cmbypzlx.Size = new System.Drawing.Size(112, 20);
            this.cmbypzlx.TabIndex = 1;
            this.cmbypzlx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.cmbypzlx.DropDown += new System.EventHandler(this.cmbyplx_Leave);
            // 
            // cmbyplx
            // 
            this.cmbyplx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyplx.ForeColor = System.Drawing.Color.Blue;
            this.cmbyplx.Location = new System.Drawing.Point(72, 15);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(112, 20);
            this.cmbyplx.TabIndex = 0;
            this.cmbyplx.Leave += new System.EventHandler(this.cmbyplx_Leave);
            this.cmbyplx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(200, 18);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(70, 19);
            this.label39.TabIndex = 135;
            this.label39.Text = "药品子类型";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label16.Location = new System.Drawing.Point(16, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 19);
            this.label16.TabIndex = 134;
            this.label16.Text = "药品类型";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(8, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 145;
            this.label1.Text = "药品名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label40.Location = new System.Drawing.Point(11, 191);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(61, 19);
            this.label40.TabIndex = 163;
            this.label40.Text = "生产厂家";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbtlfl
            // 
            this.cmbtlfl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtlfl.ForeColor = System.Drawing.Color.Blue;
            this.cmbtlfl.Location = new System.Drawing.Point(435, 162);
            this.cmbtlfl.Name = "cmbtlfl";
            this.cmbtlfl.Size = new System.Drawing.Size(93, 20);
            this.cmbtlfl.TabIndex = 17;
            this.cmbtlfl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(7, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 146;
            this.label2.Text = "药品商品名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(284, 192);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 19);
            this.label20.TabIndex = 166;
            this.label20.Text = "批发价";
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label31.Location = new System.Drawing.Point(328, 43);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(49, 15);
            this.label31.TabIndex = 174;
            this.label31.Text = "英文名";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(379, 167);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(61, 19);
            this.label27.TabIndex = 172;
            this.label27.Text = "统领分类";
            // 
            // panel_2
            // 
            this.panel_2.Controls.Add(this.groupBox2);
            this.panel_2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_2.Location = new System.Drawing.Point(0, 241);
            this.panel_2.Name = "panel_2";
            this.panel_2.Size = new System.Drawing.Size(555, 275);
            this.panel_2.TabIndex = 151;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.chkhlyw);
            this.groupBox2.Controls.Add(this.chkFsx);
            this.groupBox2.Controls.Add(this.chkFzYy);
            this.groupBox2.Controls.Add(this.cmbGwypjb);
            this.groupBox2.Controls.Add(this.cmbJbyw);
            this.groupBox2.Controls.Add(this.chkdpzyp);
            this.groupBox2.Controls.Add(this.txtghdw);
            this.groupBox2.Controls.Add(this.label45);
            this.groupBox2.Controls.Add(this.cmbjsypfl);
            this.groupBox2.Controls.Add(this.txtbz);
            this.groupBox2.Controls.Add(this.lbljsypfl);
            this.groupBox2.Controls.Add(this.chkgjjbyw);
            this.groupBox2.Controls.Add(this.chkzbzt);
            this.groupBox2.Controls.Add(this.txtzt);
            this.groupBox2.Controls.Add(this.chkrsyp);
            this.groupBox2.Controls.Add(this.txthh);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.txthwjxbm);
            this.groupBox2.Controls.Add(this.cmbyblx);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.cmbcfjb);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.chkwyyp);
            this.groupBox2.Controls.Add(this.chkpsyp);
            this.groupBox2.Controls.Add(this.chkcfyp);
            this.groupBox2.Controls.Add(this.chkdjyp);
            this.groupBox2.Controls.Add(this.txtzglsj);
            this.groupBox2.Controls.Add(this.txtmrkl);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.txtmrjj);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.txtpzwh);
            this.groupBox2.Controls.Add(this.txtzfbl);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.txtsyff);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtylfl);
            this.groupBox2.Controls.Add(this.txtzzbz);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.chkmzyp);
            this.groupBox2.Controls.Add(this.chkgzyp);
            this.groupBox2.Controls.Add(this.chkjsyp);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.chkgwyp);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(555, 275);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "详细信息";
            // 
            // chkhlyw
            // 
            this.chkhlyw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkhlyw.ForeColor = System.Drawing.Color.Black;
            this.chkhlyw.Location = new System.Drawing.Point(404, 245);
            this.chkhlyw.Name = "chkhlyw";
            this.chkhlyw.Size = new System.Drawing.Size(89, 24);
            this.chkhlyw.TabIndex = 192;
            this.chkhlyw.Text = "化疗药物";
            // 
            // chkFsx
            // 
            this.chkFsx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkFsx.ForeColor = System.Drawing.Color.Black;
            this.chkFsx.Location = new System.Drawing.Point(320, 245);
            this.chkFsx.Name = "chkFsx";
            this.chkFsx.Size = new System.Drawing.Size(89, 24);
            this.chkFsx.TabIndex = 191;
            this.chkFsx.Text = "放射性药品";
            // 
            // chkFzYy
            // 
            this.chkFzYy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkFzYy.ForeColor = System.Drawing.Color.Black;
            this.chkFzYy.Location = new System.Drawing.Point(320, 219);
            this.chkFzYy.Name = "chkFzYy";
            this.chkFzYy.Size = new System.Drawing.Size(72, 24);
            this.chkFzYy.TabIndex = 190;
            this.chkFzYy.Text = "辅助用药";
            // 
            // cmbGwypjb
            // 
            this.cmbGwypjb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGwypjb.Enabled = false;
            this.cmbGwypjb.FormattingEnabled = true;
            this.cmbGwypjb.Location = new System.Drawing.Point(482, 170);
            this.cmbGwypjb.Name = "cmbGwypjb";
            this.cmbGwypjb.Size = new System.Drawing.Size(51, 20);
            this.cmbGwypjb.TabIndex = 189;
            // 
            // cmbJbyw
            // 
            this.cmbJbyw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJbyw.Enabled = false;
            this.cmbJbyw.Location = new System.Drawing.Point(396, 195);
            this.cmbJbyw.Name = "cmbJbyw";
            this.cmbJbyw.Size = new System.Drawing.Size(137, 20);
            this.cmbJbyw.TabIndex = 188;
            // 
            // chkdpzyp
            // 
            this.chkdpzyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkdpzyp.ForeColor = System.Drawing.Color.Black;
            this.chkdpzyp.Location = new System.Drawing.Point(320, 167);
            this.chkdpzyp.Name = "chkdpzyp";
            this.chkdpzyp.Size = new System.Drawing.Size(85, 24);
            this.chkdpzyp.TabIndex = 187;
            this.chkdpzyp.Text = "单品种药品";
            // 
            // txtghdw
            // 
            this.txtghdw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtghdw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtghdw.ForeColor = System.Drawing.Color.Blue;
            this.txtghdw.Location = new System.Drawing.Point(309, 41);
            this.txtghdw.Name = "txtghdw";
            this.txtghdw.Size = new System.Drawing.Size(126, 21);
            this.txtghdw.TabIndex = 36;
            this.txtghdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.ForeColor = System.Drawing.Color.Black;
            this.label45.Location = new System.Drawing.Point(244, 46);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(69, 13);
            this.label45.TabIndex = 185;
            this.label45.Text = "默认供货商";
            // 
            // cmbjsypfl
            // 
            this.cmbjsypfl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbjsypfl.Enabled = false;
            this.cmbjsypfl.Items.AddRange(new object[] {
            "",
            "一类",
            "二类"});
            this.cmbjsypfl.Location = new System.Drawing.Point(482, 223);
            this.cmbjsypfl.Name = "cmbjsypfl";
            this.cmbjsypfl.Size = new System.Drawing.Size(51, 20);
            this.cmbjsypfl.TabIndex = 182;
            // 
            // txtbz
            // 
            this.txtbz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbz.ForeColor = System.Drawing.Color.Blue;
            this.txtbz.Location = new System.Drawing.Point(72, 145);
            this.txtbz.Multiline = true;
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(240, 124);
            this.txtbz.TabIndex = 44;
            this.txtbz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lbljsypfl
            // 
            this.lbljsypfl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbljsypfl.ForeColor = System.Drawing.Color.Black;
            this.lbljsypfl.Location = new System.Drawing.Point(394, 226);
            this.lbljsypfl.Name = "lbljsypfl";
            this.lbljsypfl.Size = new System.Drawing.Size(83, 20);
            this.lbljsypfl.TabIndex = 183;
            this.lbljsypfl.Text = "精神药物分类";
            // 
            // chkgjjbyw
            // 
            this.chkgjjbyw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkgjjbyw.ForeColor = System.Drawing.Color.Black;
            this.chkgjjbyw.Location = new System.Drawing.Point(320, 193);
            this.chkgjjbyw.Name = "chkgjjbyw";
            this.chkgjjbyw.Size = new System.Drawing.Size(80, 24);
            this.chkgjjbyw.TabIndex = 180;
            this.chkgjjbyw.Text = "基本药物";
            this.chkgjjbyw.CheckedChanged += new System.EventHandler(this.chkgjjbyw_CheckedChanged);
            // 
            // chkzbzt
            // 
            this.chkzbzt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkzbzt.ForeColor = System.Drawing.Color.Black;
            this.chkzbzt.Location = new System.Drawing.Point(465, 141);
            this.chkzbzt.Name = "chkzbzt";
            this.chkzbzt.Size = new System.Drawing.Size(80, 24);
            this.chkzbzt.TabIndex = 179;
            this.chkzbzt.Text = "中标状态";
            // 
            // txtzt
            // 
            this.txtzt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtzt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzt.ForeColor = System.Drawing.Color.Blue;
            this.txtzt.Location = new System.Drawing.Point(173, 93);
            this.txtzt.Name = "txtzt";
            this.txtzt.Size = new System.Drawing.Size(139, 21);
            this.txtzt.TabIndex = 42;
            // 
            // chkrsyp
            // 
            this.chkrsyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkrsyp.ForeColor = System.Drawing.Color.Black;
            this.chkrsyp.Location = new System.Drawing.Point(392, 142);
            this.chkrsyp.Name = "chkrsyp";
            this.chkrsyp.Size = new System.Drawing.Size(80, 24);
            this.chkrsyp.TabIndex = 176;
            this.chkrsyp.Text = "妊娠药品";
            // 
            // txthh
            // 
            this.txthh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txthh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txthh.ForeColor = System.Drawing.Color.Blue;
            this.txthh.Location = new System.Drawing.Point(71, 93);
            this.txthh.Name = "txthh";
            this.txthh.Size = new System.Drawing.Size(72, 21);
            this.txthh.TabIndex = 41;
            this.txthh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(8, 97);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(64, 19);
            this.label32.TabIndex = 175;
            this.label32.Text = "货号";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txthwjxbm
            // 
            this.txthwjxbm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txthwjxbm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txthwjxbm.ForeColor = System.Drawing.Color.Blue;
            this.txthwjxbm.Location = new System.Drawing.Point(336, 67);
            this.txthwjxbm.Name = "txthwjxbm";
            this.txthwjxbm.Size = new System.Drawing.Size(24, 21);
            this.txthwjxbm.TabIndex = 39;
            this.txthwjxbm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // cmbyblx
            // 
            this.cmbyblx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyblx.Location = new System.Drawing.Point(328, 17);
            this.cmbyblx.Name = "cmbyblx";
            this.cmbyblx.Size = new System.Drawing.Size(104, 20);
            this.cmbyblx.TabIndex = 32;
            this.cmbyblx.SelectedIndexChanged += new System.EventHandler(this.cmbyblx_SelectedIndexChanged);
            this.cmbyblx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(520, 19);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(16, 15);
            this.label30.TabIndex = 172;
            this.label30.Text = "%";
            // 
            // cmbcfjb
            // 
            this.cmbcfjb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcfjb.ForeColor = System.Drawing.Color.Blue;
            this.cmbcfjb.Items.AddRange(new object[] {
            "1-正主任医师",
            "2-副主任医师",
            "3-主治医师",
            "4-经治医师"});
            this.cmbcfjb.Location = new System.Drawing.Point(432, 68);
            this.cmbcfjb.Name = "cmbcfjb";
            this.cmbcfjb.Size = new System.Drawing.Size(96, 20);
            this.cmbcfjb.TabIndex = 40;
            this.cmbcfjb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(376, 71);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 19);
            this.label18.TabIndex = 171;
            this.label18.Text = "处方级别";
            // 
            // chkwyyp
            // 
            this.chkwyyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkwyyp.ForeColor = System.Drawing.Color.Black;
            this.chkwyyp.Location = new System.Drawing.Point(464, 118);
            this.chkwyyp.Name = "chkwyyp";
            this.chkwyyp.Size = new System.Drawing.Size(84, 24);
            this.chkwyyp.TabIndex = 56;
            this.chkwyyp.Text = "外用药品";
            // 
            // chkpsyp
            // 
            this.chkpsyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkpsyp.ForeColor = System.Drawing.Color.Black;
            this.chkpsyp.Location = new System.Drawing.Point(464, 94);
            this.chkpsyp.Name = "chkpsyp";
            this.chkpsyp.Size = new System.Drawing.Size(80, 24);
            this.chkpsyp.TabIndex = 53;
            this.chkpsyp.Text = "皮试药品";
            // 
            // chkcfyp
            // 
            this.chkcfyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkcfyp.ForeColor = System.Drawing.Color.Black;
            this.chkcfyp.Location = new System.Drawing.Point(320, 142);
            this.chkcfyp.Name = "chkcfyp";
            this.chkcfyp.Size = new System.Drawing.Size(80, 24);
            this.chkcfyp.TabIndex = 57;
            this.chkcfyp.Text = "处方药品";
            // 
            // chkdjyp
            // 
            this.chkdjyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkdjyp.ForeColor = System.Drawing.Color.Black;
            this.chkdjyp.Location = new System.Drawing.Point(392, 94);
            this.chkdjyp.Name = "chkdjyp";
            this.chkdjyp.Size = new System.Drawing.Size(80, 24);
            this.chkdjyp.TabIndex = 52;
            this.chkdjyp.Text = "毒剧药品";
            // 
            // txtzglsj
            // 
            this.txtzglsj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtzglsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzglsj.ForeColor = System.Drawing.Color.Blue;
            this.txtzglsj.Location = new System.Drawing.Point(72, 41);
            this.txtzglsj.Name = "txtzglsj";
            this.txtzglsj.Size = new System.Drawing.Size(56, 21);
            this.txtzglsj.TabIndex = 34;
            this.txtzglsj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtmrkl
            // 
            this.txtmrkl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmrkl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmrkl.ForeColor = System.Drawing.Color.Blue;
            this.txtmrkl.Location = new System.Drawing.Point(488, 41);
            this.txtmrkl.Name = "txtmrkl";
            this.txtmrkl.Size = new System.Drawing.Size(40, 21);
            this.txtmrkl.TabIndex = 37;
            this.txtmrkl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(435, 47);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(69, 13);
            this.label25.TabIndex = 122;
            this.label25.Text = "默认扣率";
            // 
            // txtmrjj
            // 
            this.txtmrjj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmrjj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmrjj.ForeColor = System.Drawing.Color.Blue;
            this.txtmrjj.Location = new System.Drawing.Point(182, 41);
            this.txtmrjj.Name = "txtmrjj";
            this.txtmrjj.Size = new System.Drawing.Size(61, 21);
            this.txtmrjj.TabIndex = 35;
            this.txtmrjj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(131, 47);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(69, 13);
            this.label24.TabIndex = 121;
            this.label24.Text = "默认进价";
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(0, 44);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 18);
            this.label23.TabIndex = 120;
            this.label23.Text = "上限价格";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(272, 20);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(64, 17);
            this.label28.TabIndex = 115;
            this.label28.Text = "医保类型";
            // 
            // txtpzwh
            // 
            this.txtpzwh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpzwh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpzwh.ForeColor = System.Drawing.Color.Blue;
            this.txtpzwh.Location = new System.Drawing.Point(197, 15);
            this.txtpzwh.Name = "txtpzwh";
            this.txtpzwh.Size = new System.Drawing.Size(72, 21);
            this.txtpzwh.TabIndex = 31;
            this.txtpzwh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtzfbl
            // 
            this.txtzfbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtzfbl.Enabled = false;
            this.txtzfbl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzfbl.ForeColor = System.Drawing.Color.Blue;
            this.txtzfbl.Location = new System.Drawing.Point(488, 18);
            this.txtzfbl.Name = "txtzfbl";
            this.txtzfbl.Size = new System.Drawing.Size(32, 21);
            this.txtzfbl.TabIndex = 33;
            this.txtzfbl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(145, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 16);
            this.label19.TabIndex = 114;
            this.label19.Text = "批准文号";
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.ForeColor = System.Drawing.Color.Black;
            this.label43.Location = new System.Drawing.Point(16, 19);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(56, 19);
            this.label43.TabIndex = 110;
            this.label43.Text = "使用方法";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtsyff
            // 
            this.txtsyff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsyff.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtsyff.ForeColor = System.Drawing.Color.Blue;
            this.txtsyff.Location = new System.Drawing.Point(72, 15);
            this.txtsyff.Name = "txtsyff";
            this.txtsyff.Size = new System.Drawing.Size(72, 21);
            this.txtsyff.TabIndex = 30;
            this.txtsyff.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtsyff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(32, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 19);
            this.label13.TabIndex = 108;
            this.label13.Text = "备注";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtylfl
            // 
            this.txtylfl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtylfl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtylfl.ForeColor = System.Drawing.Color.Blue;
            this.txtylfl.Location = new System.Drawing.Point(72, 67);
            this.txtylfl.Name = "txtylfl";
            this.txtylfl.Size = new System.Drawing.Size(194, 21);
            this.txtylfl.TabIndex = 38;
            this.txtylfl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtylfl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtzzbz
            // 
            this.txtzzbz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtzzbz.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzzbz.ForeColor = System.Drawing.Color.Blue;
            this.txtzzbz.Location = new System.Drawing.Point(72, 119);
            this.txtzzbz.Name = "txtzzbz";
            this.txtzzbz.Size = new System.Drawing.Size(240, 21);
            this.txtzzbz.TabIndex = 43;
            this.txtzzbz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(8, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 19);
            this.label12.TabIndex = 107;
            this.label12.Text = "主治病症";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(8, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 19);
            this.label14.TabIndex = 109;
            this.label14.Text = "药理分类";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(432, 22);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(64, 16);
            this.label29.TabIndex = 116;
            this.label29.Text = "自付比例";
            // 
            // chkmzyp
            // 
            this.chkmzyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkmzyp.ForeColor = System.Drawing.Color.Black;
            this.chkmzyp.Location = new System.Drawing.Point(320, 94);
            this.chkmzyp.Name = "chkmzyp";
            this.chkmzyp.Size = new System.Drawing.Size(80, 24);
            this.chkmzyp.TabIndex = 51;
            this.chkmzyp.Text = "麻醉药品";
            // 
            // chkgzyp
            // 
            this.chkgzyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkgzyp.ForeColor = System.Drawing.Color.Black;
            this.chkgzyp.Location = new System.Drawing.Point(392, 118);
            this.chkgzyp.Name = "chkgzyp";
            this.chkgzyp.Size = new System.Drawing.Size(84, 24);
            this.chkgzyp.TabIndex = 55;
            this.chkgzyp.Text = "贵重药品";
            // 
            // chkjsyp
            // 
            this.chkjsyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkjsyp.ForeColor = System.Drawing.Color.Black;
            this.chkjsyp.Location = new System.Drawing.Point(320, 118);
            this.chkjsyp.Name = "chkjsyp";
            this.chkjsyp.Size = new System.Drawing.Size(80, 24);
            this.chkjsyp.TabIndex = 54;
            this.chkjsyp.Text = "精神药品";
            this.chkjsyp.CheckedChanged += new System.EventHandler(this.chkjsyp_CheckedChanged);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(272, 72);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 13);
            this.label17.TabIndex = 173;
            this.label17.Text = "货位剂型码";
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(137, 94);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(37, 19);
            this.label33.TabIndex = 178;
            this.label33.Text = "嘱托";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkgwyp
            // 
            this.chkgwyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkgwyp.ForeColor = System.Drawing.Color.Black;
            this.chkgwyp.Location = new System.Drawing.Point(404, 167);
            this.chkgwyp.Name = "chkgwyp";
            this.chkgwyp.Size = new System.Drawing.Size(72, 24);
            this.chkgwyp.TabIndex = 181;
            this.chkgwyp.Text = "高危药品";
            this.chkgwyp.CheckedChanged += new System.EventHandler(this.chkgwyp_CheckedChanged);
            // 
            // panel_3
            // 
            this.panel_3.Controls.Add(this.groupBox5);
            this.panel_3.Controls.Add(this.txtcglsh);
            this.panel_3.Controls.Add(this.txttxm);
            this.panel_3.Controls.Add(this.label41);
            this.panel_3.Controls.Add(this.label44);
            this.panel_3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_3.Location = new System.Drawing.Point(0, 516);
            this.panel_3.Name = "panel_3";
            this.panel_3.Size = new System.Drawing.Size(555, 61);
            this.panel_3.TabIndex = 150;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtDDDjldw);
            this.groupBox5.Controls.Add(this.label49);
            this.groupBox5.Controls.Add(this.txtDDDjl);
            this.groupBox5.Controls.Add(this.label48);
            this.groupBox5.Controls.Add(this.txtDdd);
            this.groupBox5.Controls.Add(this.label38);
            this.groupBox5.Controls.Add(this.cmbKssdj);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(345, 61);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "抗生素";
            // 
            // txtDDDjldw
            // 
            this.txtDDDjldw.Location = new System.Drawing.Point(236, 39);
            this.txtDDDjldw.Name = "txtDDDjldw";
            this.txtDDDjldw.Size = new System.Drawing.Size(99, 21);
            this.txtDDDjldw.TabIndex = 201;
            this.txtDDDjldw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.Location = new System.Drawing.Point(166, 43);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(71, 12);
            this.label49.TabIndex = 203;
            this.label49.Text = "DDD剂量单位";
            // 
            // txtDDDjl
            // 
            this.txtDDDjl.Location = new System.Drawing.Point(73, 39);
            this.txtDDDjl.Name = "txtDDDjl";
            this.txtDDDjl.Size = new System.Drawing.Size(89, 21);
            this.txtDDDjl.TabIndex = 200;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.ForeColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(24, 42);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(47, 12);
            this.label48.TabIndex = 202;
            this.label48.Text = "DDD剂量";
            // 
            // txtDdd
            // 
            this.txtDdd.Location = new System.Drawing.Point(236, 14);
            this.txtDdd.Name = "txtDdd";
            this.txtDdd.Size = new System.Drawing.Size(100, 21);
            this.txtDdd.TabIndex = 3;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(199, 17);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(35, 12);
            this.label38.TabIndex = 2;
            this.label38.Text = "DDD值";
            // 
            // cmbKssdj
            // 
            this.cmbKssdj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKssdj.FormattingEnabled = true;
            this.cmbKssdj.Location = new System.Drawing.Point(72, 14);
            this.cmbKssdj.Name = "cmbKssdj";
            this.cmbKssdj.Size = new System.Drawing.Size(121, 20);
            this.cmbKssdj.TabIndex = 1;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(6, 17);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(65, 12);
            this.label34.TabIndex = 0;
            this.label34.Text = "抗生素等级";
            // 
            // txtcglsh
            // 
            this.txtcglsh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcglsh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtcglsh.ForeColor = System.Drawing.Color.Blue;
            this.txtcglsh.Location = new System.Drawing.Point(419, 29);
            this.txtcglsh.Name = "txtcglsh";
            this.txtcglsh.Size = new System.Drawing.Size(110, 21);
            this.txtcglsh.TabIndex = 148;
            // 
            // txttxm
            // 
            this.txttxm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttxm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttxm.ForeColor = System.Drawing.Color.Blue;
            this.txttxm.Location = new System.Drawing.Point(419, 4);
            this.txttxm.Name = "txttxm";
            this.txttxm.Size = new System.Drawing.Size(110, 21);
            this.txttxm.TabIndex = 58;
            this.txttxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label41.Location = new System.Drawing.Point(331, 31);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(87, 16);
            this.label41.TabIndex = 149;
            this.label41.Text = "采购流水号";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(377, 10);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(48, 16);
            this.label44.TabIndex = 131;
            this.label44.Text = "条形码";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.butnext);
            this.panel1.Controls.Add(this.butup);
            this.panel1.Controls.Add(this.butquit);
            this.panel1.Controls.Add(this.butdel);
            this.panel1.Controls.Add(this.butnewcj);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.butnewgg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(555, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 577);
            this.panel1.TabIndex = 6;
            // 
            // butnext
            // 
            this.butnext.BackColor = System.Drawing.SystemColors.Info;
            this.butnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butnext.Location = new System.Drawing.Point(20, 318);
            this.butnext.Name = "butnext";
            this.butnext.Size = new System.Drawing.Size(96, 32);
            this.butnext.TabIndex = 76;
            this.butnext.Text = "下一个(&N)";
            this.butnext.UseVisualStyleBackColor = false;
            this.butnext.Click += new System.EventHandler(this.butnext_Click);
            // 
            // butup
            // 
            this.butup.BackColor = System.Drawing.SystemColors.Info;
            this.butup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butup.Location = new System.Drawing.Point(20, 286);
            this.butup.Name = "butup";
            this.butup.Size = new System.Drawing.Size(96, 32);
            this.butup.TabIndex = 75;
            this.butup.Text = "上一个(U)";
            this.butup.UseVisualStyleBackColor = false;
            this.butup.Click += new System.EventHandler(this.butup_Click);
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.Info;
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butquit.Location = new System.Drawing.Point(20, 184);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(96, 32);
            this.butquit.TabIndex = 74;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butdel
            // 
            this.butdel.BackColor = System.Drawing.SystemColors.Info;
            this.butdel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butdel.Location = new System.Drawing.Point(20, 144);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(96, 32);
            this.butdel.TabIndex = 73;
            this.butdel.Text = "删除(&D)";
            this.butdel.UseVisualStyleBackColor = false;
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butnewcj
            // 
            this.butnewcj.BackColor = System.Drawing.SystemColors.Info;
            this.butnewcj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butnewcj.Location = new System.Drawing.Point(20, 64);
            this.butnewcj.Name = "butnewcj";
            this.butnewcj.Size = new System.Drawing.Size(96, 32);
            this.butnewcj.TabIndex = 72;
            this.butnewcj.Text = "新增厂家(&B)";
            this.butnewcj.UseVisualStyleBackColor = false;
            this.butnewcj.Click += new System.EventHandler(this.butnewcj_Click);
            // 
            // butsave
            // 
            this.butsave.BackColor = System.Drawing.SystemColors.Info;
            this.butsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butsave.Location = new System.Drawing.Point(20, 104);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(96, 32);
            this.butsave.TabIndex = 70;
            this.butsave.Text = "保存(&S)";
            this.butsave.UseVisualStyleBackColor = false;
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // butnewgg
            // 
            this.butnewgg.BackColor = System.Drawing.SystemColors.Info;
            this.butnewgg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butnewgg.Location = new System.Drawing.Point(20, 24);
            this.butnewgg.Name = "butnewgg";
            this.butnewgg.Size = new System.Drawing.Size(96, 32);
            this.butnewgg.TabIndex = 71;
            this.butnewgg.Text = "新增药品(&A)";
            this.butnewgg.UseVisualStyleBackColor = false;
            this.butnewgg.Click += new System.EventHandler(this.butnewgg_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(689, 577);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "别名信息";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.myDataGrid1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(689, 320);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "别名信息";
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(683, 300);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.but_bm_save);
            this.groupBox4.Controls.Add(this.but_bm_del);
            this.groupBox4.Controls.Add(this.but_bm_new);
            this.groupBox4.Controls.Add(this.chkspm);
            this.groupBox4.Controls.Add(this.txtbmszm);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.label37);
            this.groupBox4.Controls.Add(this.txtbmwbm);
            this.groupBox4.Controls.Add(this.txtbmywm);
            this.groupBox4.Controls.Add(this.txtypbm);
            this.groupBox4.Controls.Add(this.txtbmpym);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 320);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(689, 257);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // but_bm_save
            // 
            this.but_bm_save.BackColor = System.Drawing.SystemColors.Info;
            this.but_bm_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_bm_save.Location = new System.Drawing.Point(496, 80);
            this.but_bm_save.Name = "but_bm_save";
            this.but_bm_save.Size = new System.Drawing.Size(96, 32);
            this.but_bm_save.TabIndex = 108;
            this.but_bm_save.Text = "保存";
            this.but_bm_save.UseVisualStyleBackColor = false;
            this.but_bm_save.Click += new System.EventHandler(this.but_bm_save_Click);
            // 
            // but_bm_del
            // 
            this.but_bm_del.BackColor = System.Drawing.SystemColors.Info;
            this.but_bm_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_bm_del.Location = new System.Drawing.Point(496, 128);
            this.but_bm_del.Name = "but_bm_del";
            this.but_bm_del.Size = new System.Drawing.Size(96, 32);
            this.but_bm_del.TabIndex = 107;
            this.but_bm_del.Text = "删除";
            this.but_bm_del.UseVisualStyleBackColor = false;
            this.but_bm_del.Click += new System.EventHandler(this.but_bm_del_Click);
            // 
            // but_bm_new
            // 
            this.but_bm_new.BackColor = System.Drawing.SystemColors.Info;
            this.but_bm_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_bm_new.Location = new System.Drawing.Point(496, 32);
            this.but_bm_new.Name = "but_bm_new";
            this.but_bm_new.Size = new System.Drawing.Size(96, 32);
            this.but_bm_new.TabIndex = 106;
            this.but_bm_new.Text = "新增";
            this.but_bm_new.UseVisualStyleBackColor = false;
            this.but_bm_new.Click += new System.EventHandler(this.but_bm_new_Click);
            // 
            // chkspm
            // 
            this.chkspm.Enabled = false;
            this.chkspm.Location = new System.Drawing.Point(384, 24);
            this.chkspm.Name = "chkspm";
            this.chkspm.Size = new System.Drawing.Size(64, 24);
            this.chkspm.TabIndex = 100;
            this.chkspm.Text = "商品名";
            // 
            // txtbmszm
            // 
            this.txtbmszm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbmszm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtbmszm.Location = new System.Drawing.Point(80, 152);
            this.txtbmszm.Name = "txtbmszm";
            this.txtbmszm.Size = new System.Drawing.Size(296, 21);
            this.txtbmszm.TabIndex = 105;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(32, 156);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 18);
            this.label22.TabIndex = 99;
            this.label22.Text = "数字码";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(24, 64);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(56, 19);
            this.label36.TabIndex = 96;
            this.label36.Text = " 拼音码";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(24, 32);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(56, 19);
            this.label37.TabIndex = 95;
            this.label37.Text = "药品别名";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbmwbm
            // 
            this.txtbmwbm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbmwbm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtbmwbm.Location = new System.Drawing.Point(80, 88);
            this.txtbmwbm.Name = "txtbmwbm";
            this.txtbmwbm.Size = new System.Drawing.Size(296, 21);
            this.txtbmwbm.TabIndex = 103;
            this.txtbmwbm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtbmywm
            // 
            this.txtbmywm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbmywm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtbmywm.Location = new System.Drawing.Point(80, 120);
            this.txtbmywm.Name = "txtbmywm";
            this.txtbmywm.Size = new System.Drawing.Size(296, 21);
            this.txtbmywm.TabIndex = 104;
            this.txtbmywm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtypbm
            // 
            this.txtypbm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtypbm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtypbm.Location = new System.Drawing.Point(80, 26);
            this.txtypbm.Name = "txtypbm";
            this.txtypbm.Size = new System.Drawing.Size(296, 21);
            this.txtypbm.TabIndex = 101;
            this.txtypbm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // txtbmpym
            // 
            this.txtbmpym.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbmpym.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtbmpym.Location = new System.Drawing.Point(80, 56);
            this.txtbmpym.Name = "txtbmpym";
            this.txtbmpym.Size = new System.Drawing.Size(296, 21);
            this.txtbmpym.TabIndex = 102;
            this.txtbmpym.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(32, 125);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 19);
            this.label26.TabIndex = 98;
            this.label26.Text = "英文名";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(32, 96);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(56, 19);
            this.label35.TabIndex = 97;
            this.label35.Text = "五笔码";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frmypcd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(697, 603);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Frmypcd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药品词典设置";
            this.Load += new System.EventHandler(this.Frmypcd_Load);
            this.Activated += new System.EventHandler(this.Frmypcd_Activated);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel_1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel_3.ResumeLayout(false);
            this.panel_3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 窗体LOAD事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frmypcd_Load(object sender, System.EventArgs e)
        {
            DataTable gwjbTable = new DataTable();
            DataColumn idColumn = new DataColumn();
            idColumn.DataType = typeof(int);
            idColumn.ColumnName = "id";
            DataColumn nameColumn = new DataColumn();
            nameColumn.DataType = typeof(string);
            nameColumn.ColumnName = "name";
            gwjbTable.Columns.AddRange(new DataColumn[] { idColumn, nameColumn });
            gwjbTable.Rows.Add(new object[] { 1, "A" });
            gwjbTable.Rows.Add(new object[] { 2, "B" });
            gwjbTable.Rows.Add(new object[] { 3, "C" });
            cmbGwypjb.DataSource = gwjbTable;
            cmbGwypjb.DisplayMember = "name";
            cmbGwypjb.ValueMember = "id";
            cmbGwypjb.SelectedIndex = -1;

            if (_Cjid > 0)
                this.FillYp(_Cjid);
            else
                this.cmbyplx.Focus();

            this.cmbcfjb.SelectedIndex = 3;

            if (InstanceForm._menuTag.Function_Name == "Fun_ts_yp_ypcd_all")
            {
                butsave.Enabled = false;
                butdel.Enabled = false;
                butnewcj.Enabled = false;
                butnewgg.Enabled = false;
                but_bm_del.Enabled = false;
                but_bm_new.Enabled = false;
                but_bm_save.Enabled = false;
            }

            this.tabControl1.SelectedTab = tabPage1;

            //Modify By Tany 2015-11-24
            isWbks = YpClass.WBKS.IsWbks(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
            if (isWbks)
            {
                //如果是外部科室，则必须维护成外部药品
                chwbyp.Checked = true;
            }
            //都不能维护是不是外部药品
            chwbyp.Enabled = TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator;
        }

        /// <summary>
        /// 药品类型框焦点离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbyplx_Leave(object sender, System.EventArgs e)
        {
            if (InstanceForm._menuTag.Function_Name == "Fun_ts_yp_ypcd" && InstanceForm.BCurrentUser.IsAdministrator == false)
                Yp.AddCmbYpzlx(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(cmbyplx.SelectedValue), cmbypzlx, InstanceForm.BDatabase);
            else
                Yp.AddCmbYpzlx(0, Convert.ToInt32(cmbyplx.SelectedValue), cmbypzlx, InstanceForm.BDatabase);

        }



        /// <summary>
        /// 回车时下一个控件获得焦点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                if (e.KeyChar == 13)
                {
                    if ((control.Name == "txtyplx" || control.Name == "txtypzlx" || control.Name == "txtypdw" || control.Name == "txtypjx" || control.Name == "txthldw" || control.Name == "txtbzdw" || control.Name == "txtylfl" || control.Name == "txtsccj" || control.Name == "txtyblx" || control.Name == "txtzbzt"))
                    {
                        if (Convertor.IsNull(control.Tag, "0") != "0")
                        {
                            this.SelectNextControl(control, true, false, true, true);
                        }
                    }
                    else
                    {
                        if (control.Name == "txtfkbl")
                            butsave.Focus();
                        else
                            this.SelectNextControl(control, true, false, true, true);
                        if (control.Name == "txtyppm")
                        {
                            if (txtypspm.Text.Trim() == "")
                            {
                                txtypspm.Text = txtyppm.Text;
                                txtpym.Text = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtypspm.Text, 0);
                                txtwbm.Text = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtypspm.Text, 1);
                            }
                        }
                        if (control.Name == "txtypspm")
                        {
                            txtpym.Text = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtypspm.Text, 0);
                            txtwbm.Text = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtypspm.Text, 1);
                        }
                        if (control.Name == "txtypbm")
                        {
                            txtbmpym.Text = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtypbm.Text, 0);
                            txtbmwbm.Text = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtypbm.Text, 1);
                        }
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("abc" + err.Message);
            }
        }



        /// <summary>
        /// ShowCard输入框事件,如剂型、单位、厂家、用法、药理分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            try
            {
                Control control = (Control)sender;

                if (control.Text.Trim() == "")
                {
                    control.Text = "";
                    control.Tag = "0";
                }

                if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convertor.IsNull(control.Tag, "0") == "0" || Convertor.IsNull(control.Tag, "0") == "")))
                {
                }
                else
                {
                    return;
                }

                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 2);
                string ssql = "";
                switch (control.TabIndex)
                {
                    case 2://剂型
                        if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                        Yp.frmShowCard(sender, ShowCardType.剂型, Convert.ToInt32(cmbyplx.SelectedValue), point, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                        break;
                    case 11:
                    case 13:
                        if (nkey != 13)
                        {
                            ssql = Convert.ToDouble(Convertor.IsNull(this.txthlxs.Text, "0")).ToString() + this.txthldw.Text.Trim() + "*" + Convertor.IsNull(this.txtbzsl.Text.Trim(), "0") + this.txtbzdw.Text.Trim();
                            this.txtypgg.Text = ssql;
                        }
                        break;
                    case 10://单位 
                        if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                        Yp.frmShowCard(sender, ShowCardType.单位, Convert.ToInt32(cmbyplx.SelectedValue), point, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                        break;
                    case 12:
                    case 14:
                        if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                        Yp.frmShowCard(sender, ShowCardType.单位, Convert.ToInt32(cmbyplx.SelectedValue), point, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                        ssql = Convert.ToDouble(Convertor.IsNull(this.txthlxs.Text, "0")).ToString() + this.txthldw.Text.Trim() + "*" + Convertor.IsNull(this.txtbzsl.Text.Trim(), "0") + this.txtbzdw.Text.Trim();
                        this.txtypgg.Text = ssql;
                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                        break;
                    case 18://生产厂家
                        if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                        Yp.frmShowCard(sender, ShowCardType.厂家, Convert.ToInt32(cmbyplx.SelectedValue), point, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                        break;
                    case 19:
                        if (Convertor.IsNumeric(Convertor.IsNull(YpConfig_lsj, "0")) == true)
                        {
                           // decimal kl = Convert.ToDecimal(YpConfig_lsj);

                            // decimal kl = Convert.ToDecimal(YpConfig_lsj);//原来

                            decimal kl = 1;
                            if (Convert.ToInt32(cmbyplx.SelectedValue) > 2)  //根据2016-12-31号药品实行零加成进行批量调价更改
                            {
                                kl = Convert.ToDecimal(YpConfig_lsj);
                            }

                            int cjid = Convert.ToInt32(Convertor.IsNull(this.groupBox2.Tag, "0"));
                            if (kl > 0 && cjid == 0)
                                //txtlsj.Text =Convert.ToString(Math.Round((Convert.ToDecimal(Convertor.IsNull(txtpfj.Text, "0")) *100)/kl, 2));
                                if (bsswr_lsj)
                                {
                                    txtlsj.Text = Convert.ToString(Math.Round(Convert.ToDecimal(Convertor.IsNull(txtpfj.Text, "0")) * kl, 2));
                                }
                                else
                                {
                                    //txtlsj.Text = Convert.ToDecimal(Convert.ToDecimal(Convertor.IsNull(txtpfj.Text, "0")) * kl).ToString("0.00");
                                    txtlsj.Text = Convert.ToString(RoundingNotIn(Convert.ToDecimal(Convertor.IsNull(txtpfj.Text, "0")) * kl, 2));
                                }
                        }
                        break;
                    case 30://使用方法
                        if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                        Yp.frmShowCard(sender, ShowCardType.用法, Convert.ToInt32(cmbyplx.SelectedValue), point, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                        break;
                    case 38://药理分类
                        if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                        Yp.frmShowCard(sender, ShowCardType.药理分类, Convert.ToInt32(cmbyplx.SelectedValue), point, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0")
                            this.SelectNextControl((Control)sender, true, false, true, true);
                        break;
                    case 36:
                        if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                        Yp.frmShowCard(sender, ShowCardType.供货单位, 0, point, 0, InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                        break;
                    case 201://ddd剂量单位
                        if (nkey == 13 && (control.Tag.ToString() != "" && control.Tag.ToString() != "0")) return;
                        Yp.frmShowCard(sender, ShowCardType.单位, 0, new Point(point.X, point.Y + groupBox1.Size.Height + groupBox2.Size.Height - 300), 0, InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                        break;
                }

                //				switch(control.TabIndex)
                //				{
                //					case 11:
                //					case 12:
                //					case 13:
                //					case 14:
                //						if (nkey!=13)
                //						{
                //							string ssql=Convert.ToDouble(Convertor.IsNull(this.txthlxs.Text,"0")).ToString()+this.txthldw.Text.Trim()+"*"+Convertor.IsNull(this.txtbzsl.Text.Trim(),"0")+this.txtbzdw.Text.Trim();
                //							this.txtypgg.Text=ssql;
                //						}
                //						break;
                //				}

            }
            catch (System.Exception err)
            {
                MessageBox.Show("err:" + err.Message);
            }
        }


        public void FillYp(int cjid)
        {

            Ypcj cj = new Ypcj(cjid, InstanceForm.BDatabase);
            Ypgg gg = new Ypgg(cj.GGID, InstanceForm.BDatabase);

            FillYpbm(0);
            FillYpbmTable(cj.GGID);


            this.groupBox1.Tag = gg.GGID.ToString();

            this.cmbyplx.SelectedValue = gg.YPLX;
            //if (gg.YPLX!=0)
            //    cmbyplx.Enabled=false;

            //if (InstanceForm._menuTag.Function_Name == "Fun_ts_yp_ypcd" && InstanceForm.BCurrentUser.IsAdministrator == false)
            //    //Yp.AddCmbYpzlx(InstanceForm.BCurrentDept.DeptId, gg.YPLX, cmbypzlx, InstanceForm.BDatabase);
            //else
                Yp.AddCmbYpzlx(0, gg.YPLX, cmbypzlx, InstanceForm.BDatabase);

            this.cmbypzlx.SelectedValue = gg.YPZLX;
            this.txtyppm.Text = gg.YPPM;
            this.txtypywm.Text = gg.YPYWM.Trim();
            this.txtypspm.Text = gg.YPSPM;
            this.txtypspmbz.Text = gg.YPSPMBZ;
            this.txtpym.Text = gg.PYM;
            this.txtwbm.Text = gg.WBM;

            DataTable tbdw = Yp.SelectYpdw(InstanceForm.BDatabase);
            this.txtypdw.Text = Yp.SeekYpdw(gg.YPDW, InstanceForm.BDatabase);//tbdw.Select(" id="+gg.YPDW+"")[0]["DWMC"].ToString();
            this.txtypdw.Tag = gg.YPDW;

            //this.txtylfl.Text = Yp.SeekYlfl(gg.YLFL, InstanceForm.BDatabase);
            this.txtylfl.Tag = gg.YLFL;

            this.txthwjxbm.Text = gg.HWJXBM.Trim();

            this.txtypjx.Text = Yp.SeekYpjx(gg.YPJX, InstanceForm.BDatabase);
            this.txtypjx.Tag = gg.YPJX;

            this.txthlxs.Text = Convert.ToString((float)gg.HLXS);

            this.txthldw.Text = Yp.SeekYpdw(gg.HLDW, InstanceForm.BDatabase);//tbdw.Select(" id="+gg.HLDW+"")[0]["DWMC"].ToString();
            this.txthldw.Tag = gg.HLDW;

            this.txtbzsl.Text = gg.BZSL.ToString();

            this.txtbzdw.Text = Yp.SeekYpdw(gg.BZDW, InstanceForm.BDatabase);//tbdw.Select(" id="+gg.BZDW+"")[0]["DWMC"].ToString();
            this.txtbzdw.Tag = gg.BZDW;

            this.txtypgg.Text = gg.YPGG;

            this.txtsyff.Text = Yp.SeekYpyf(gg.SYFF, InstanceForm.BDatabase);
            this.txtsyff.Tag = gg.SYFF;

            if (gg.CFJB == 0)
                this.cmbcfjb.SelectedIndex = 3;
            else
                this.cmbcfjb.SelectedIndex = gg.CFJB - 1;
            this.chkdjyp.Checked = gg.DJYP;
            this.chkmzyp.Checked = gg.MZYP;
            this.chkpsyp.Checked = gg.PSYP;
            this.chkjsyp.Checked = gg.JSYP;
            this.chkgzyp.Checked = gg.GZYP;
            this.chkcfyp.Checked = gg.CFYP;
            this.chkwyyp.Checked = gg.WYYP;
            this.chkrsyp.Checked = gg.RSYP;

            this.chkFzYy.Checked = gg.FZYY == 1;

            //Add by zhujh 2017-02-18
            this.chkFsx.Checked = gg.FSX == 1;
            //Add by chenl 2017-03-23
            this.chkhlyw.Checked = gg.HLYW == 1;

            this.chkzbzt.Checked = Convert.ToBoolean(cj.ZBZT);
            this.chkdpzyp.Checked = gg.DPZYP;


            if (gg.JSYPFL >= 0) this.cmbjsypfl.SelectedIndex = gg.JSYPFL;

            this.cmblyfs.SelectedValue = gg.LYFS;

            this.cmbtlfl.SelectedValue = gg.TLFL.Trim();

            this.groupBox2.Tag = cj.CJID;

            this.groupBox1.Text = "基本信息   " + cj.SHH.Trim();

            if ((new SystemCfg(8005)).Config != "1")
            {
                this.txthh.Text = cj.SHH;
                this.txthh.Enabled = false;
            }
            else
            {
                this.txthh.Text = cj.ZBQH.Trim();
                this.txthh.Enabled = true;
            }

            this.txttxm.Text = cj.TXM;

            this.txtsccj.Text = Yp.SeekSccj(cj.SCCJ, InstanceForm.BDatabase);
            this.txtsccj.Tag = cj.SCCJ.ToString();

            this.txtpfj.Text = cj.PFJ.ToString();
            this.txtlsj.Text = cj.LSJ.ToString();
            this.txtfkbl.Text = Convert.ToString((float)(cj.FKBL * 100));//付款比例
            this.txtpzwh.Text = cj.PZWH;

            this.cmbyblx.SelectedValue = Convertor.IsNull(cj.YBLX, "0");
            this.txtzfbl.Text = Convert.ToString((float)(cj.ZFBL * 100));

            this.txtmrkl.Text = Convert.ToString((float)cj.MRKL);
            this.txtmrjj.Text = Convert.ToString((float)cj.MRJJ);
            this.chkstop.Checked = cj.CJBDELETE;

            //Add By Tany 2015-11-24
            this.chwbyp.Checked = cj.BWBYP;

            txtzt.Text = gg.ZT;

            txtbz.Text = gg.GGBZ;

            cmbKssdj.SelectedValue = gg.KSSDJ;
            txtDdd.Text = gg.DDD.ToString();
            chkgjjbyw.Checked = gg.GJJBYW;
            chkgwyp.Checked = gg.GWYP;

            //Add By Tany 2015-05-25
            if (gg.GJJBYW)
            {
                cmbJbyw.SelectedValue = gg.JBYWLX;
            }

            txtcglsh.Text = Convertor.IsNull(cj.CGLSH, "");
            txtghdw.Tag = cj.MRGHDW.ToString();
            txtghdw.Text = Yp.SeekGhdw(Convert.ToInt32(cj.MRGHDW), InstanceForm.BDatabase);

            chkbhtdw.Checked = cj.BHTDW; //是否合同单位

            this.txtDDDjl.Text = gg.DDDJL.ToString("0.0000");
            this.txtDDDjldw.Text = Yp.SeekYpdw(gg.DDDJLDW, InstanceForm.BDatabase);
            this.txtDDDjldw.Tag = gg.DDDJLDW;
            if (chkgwyp.Checked)
                this.cmbGwypjb.SelectedValue = gg.GWYPJB;
        }

        private void FillYpbm(long id)
        {
            //Ypbm bm = new Ypbm(id, InstanceForm.BDatabase);
            this.txtypbm.Text = bm.YPBM.Trim();
            this.txtypbm.Tag = bm.ID.ToString();
            this.chkspm.Checked = bm.SPMBZ;
            this.txtbmpym.Text = bm.PYM.Trim();
            this.txtbmwbm.Text = bm.WBM.Trim();
            this.txtbmywm.Text = bm.YWM.Trim();
            this.txtbmszm.Text = bm.SZM.Trim();
        }

        private void FillYpbmTable(int ggid)
        {
            this.CsMydataGrid1();
            string ssql = "select ypbm 品名,pym 拼音码,wbm 五笔码,ywm 英文码,szm 数字码,cast(spmbz as smallint) 商品名,id from yp_ypbm where ggid=" + ggid + " order by spmbz desc";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            tb.TableName = "ypbm";
            this.myDataGrid1.DataSource = tb;
            this.myDataGrid1.TableStyles[0].MappingName = "ypbm";

            if (tb.Rows.Count > 0)
            {
                FillYpbm(Convert.ToInt64(tb.Rows[0]["id"]));
            }
        }


        private void CsMydataGrid1()
        {
            string[] HeaderText ={ "品名", "拼音码", "五笔码", "英文码", "数字码", "商品名", "ID" };
            string[] MappingName ={ "品名", "拼音码", "五笔码", "英文码", "数字码", "商品名", "ID" };
            int[] ColWidth =	 { 150, 70, 70, 70, 70, 70, 0 };
            bool[] BoolCol =		 { false, false, false, false, false, true, false };

            this.myDataGrid1.ReadOnly = true;

            FunBase.csMydataGrid(this.myDataGrid1, HeaderText, MappingName, BoolCol, ColWidth, false);
        }


        /// <summary>
        /// 保存药品事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void butsave_Click(object sender, System.EventArgs e)
        {
            #region .....
            int cjid = Convert.ToInt32(Convertor.IsNull(this.groupBox2.Tag, "0"));
            int ggid = Convert.ToInt32(Convertor.IsNull(this.groupBox1.Tag, "0"));



            if (Convertor.IsNumeric(txtDDDjl.Text.Trim()) == false && txtDDDjl.Text.Trim() != "")//ddd剂量
            {
                MessageBox.Show("DDD剂量必须输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convertor.IsNumeric(txtDdd.Text.Trim()) == false && txtDdd.Text.Trim() != "")
            {
                MessageBox.Show("DDD值必须输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chkjsyp.Checked == true && cmbjsypfl.SelectedIndex == 0)
            {
                MessageBox.Show("请选择精神药品类别", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbjsypfl.Focus();
                return;
            }

            if (Convertor.IsNumeric(txthlxs.Text.Trim()) == false || Convertor.IsNumeric(txtbzsl.Text.Trim()) == false || Convertor.IsNumeric(txtpfj.Text.Trim()) == false
                || Convertor.IsNumeric(txtlsj.Text.Trim()) == false)
            {
                MessageBox.Show("剂量、包装数量、批发价、零售价必须输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convertor.IsNull(this.groupBox1.Tag, "0") != "0" && Convertor.IsNull(this.groupBox2.Tag, "0") == "0")
            {
                if (Ypcj.SelectGG_SCCJ(ggid, Convert.ToInt32(Convertor.IsNull(this.txtsccj.Tag, "0")), InstanceForm.BDatabase) == true)
                {
                    MessageBox.Show("当前这个规格已经添加了这个生产厂家", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Convertor.IsNumeric(this.txtfkbl.Text.Trim()) == false)
            {
                MessageBox.Show("付款比例必须输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chkgwyp.Checked && cmbGwypjb.SelectedIndex == -1)
            {
                MessageBox.Show("请选择高危药品级别", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbGwypjb.Focus();
                return;
            }


            //Ypcj cjd = new Ypcj(cjid, InstanceForm.BDatabase);
            //DataTable tb;
            //string ssql = "select * from Yk_KCMX where cjid=" + cjid + "";
            //tb = InstanceForm.BDatabase.GetDataTable(ssql);
            //if (tb.Rows.Count == 0)
            //{
            //   ssql = "select * from YF_KCMX where cjid=" + cjid + " ";
            //   tb = InstanceForm.BDatabase.GetDataTable(ssql);
            //}

            //if (tb.Rows.Count > 0)
            //{
            //    if (cjd.LSJ != Convert.ToDecimal(Convertor.IsNull(this.txtlsj.Text, "0")))// || cjd.PFJ != Convert.ToDecimal(Convertor.IsNull(this.txtpfj.Text, "0")))
            //    {
            //        MessageBox.Show("对不起，该药品已经使用不能直接更改价格。请通过调价来变更价格信息", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}

            string ssql = "";
            #region 修改价格
            try
            {
                if (cjd.LSJ != Convert.ToDecimal(Convertor.IsNull(this.txtlsj.Text, "0")) && cjid > 0)
                {
                    ssql = "select * from jc_jgbm where ipaddr is not null and len(ipaddr)>=2 ";//and jgbm<>" + InstanceForm._menuTag.Jgbm + "  ";
                    DataTable tbjg = InstanceForm.BDatabase.GetDataTable(ssql);
                    for (int i = 0; i <= tbjg.Rows.Count - 1; i++)
                    {
                        RelationalDatabase MB_DB;
                        if (Convert.ToInt32(tbjg.Rows[i]["jgbm"]) == InstanceForm._menuTag.Jgbm)
                            MB_DB = InstanceForm.BDatabase;
                        else
                            MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(tbjg.Rows[i]["jgbm"]));

                        ssql = "select * from yk_kcmx where CJID=" + Convertor.IsNull(this.groupBox2.Tag, "0") + "";
                        DataRow row = MB_DB.GetDataRow(ssql);
                        if (row != null)
                        {
                            MessageBox.Show("该药品在 [" + tbjg.Rows[i]["jgmc"].ToString().Trim() + "]  已有使用记录,不能直接修改价格,请使用调价功能", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ssql = "select * from yf_kcmx where CJID=" + Convertor.IsNull(this.groupBox2.Tag, "0") + "";
                        row = MB_DB.GetDataRow(ssql);
                        if (row != null)
                        {
                            MessageBox.Show("该药品在 [" + tbjg.Rows[i]["jgmc"].ToString().Trim() + "]  已有使用记录,不能直接修改价格,请使用调价功能", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        //MB_DB.Close();
                        //MB_DB.Dispose();
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }
            #endregion

            if (ggid == 0)
            {
                ssql = "select * from yp_ypggd where ypspm='" + txtypspm.Text.Trim() + "' and yppm='" + txtyppm.Text.Trim() + "' and ypgg='" + txtypgg.Text.Trim() + "'";
                DataTable tbgg = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbgg.Rows.Count > 0)
                {
                    MessageBox.Show("这个品名或商品名已经有了，不能重复添加", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            try
            {
                int _ggid; int _errcode; string _errtext; int _cjid;
                string str_old = "";
                string str_log = "";
                InstanceForm.BDatabase.BeginTransaction();

                //停用匹配关系
                ParameterEx[] parameters = new ParameterEx[2];
                parameters[0].Text = "@xmid";
                parameters[0].Value = ggid;
                parameters[1].Text = "@xmly";
                parameters[1].Value = 1;
                InstanceForm.BDatabase.DoCommand("sp_yb_qxybppgx", parameters, 30);

                string bz = "";
                #region 写日志
                if (cjid > 0)
                {
                    Ypgg gg_log = new Ypgg(ggid, InstanceForm.BDatabase);
                    Ypcj cj_log = new Ypcj(cjid, InstanceForm.BDatabase);
                    str_old = gg_log.YPPM.Trim() == txtyppm.Text.Trim() ? "" : ("原品名:" + gg_log.YPPM + " 现品名:" + txtyppm.Text.Trim());
                    str_old = str_old + (gg_log.YPSPM.Trim() == txtypspm.Text.Trim() ? "" : ("原商品名:" + gg_log.YPSPM + " 现商品名:" + txtypspm.Text.Trim() + "\n"));
                    str_old = str_old + (gg_log.YPGG.Trim() == txtypgg.Text.Trim() ? "" : ("原规格:" + gg_log.YPGG + " 现规格:" + txtypgg.Text.Trim() + "\n"));
                    str_old = str_old + (gg_log.YPLX.ToString() == cmbyplx.SelectedValue.ToString() ? "" : ("原类型:" + Yp.SeekYplx(gg_log.YPLX, InstanceForm.BDatabase) + " 现类型:" + cmbyplx.Text.Trim() + "\n"));
                    str_old = str_old + (cj_log.S_YPJX.Trim() == txtypjx.Text.Trim() ? "" : ("原剂型:" + cj_log.S_YPJX + " 现剂型:" + txtypjx.Text.Trim() + "\n"));
                    str_old = str_old + (cj_log.S_YPDW.Trim() == txtypdw.Text.Trim() ? "" : ("原单位:" + cj_log.S_YPDW + " 现单位:" + txtypdw.Text.Trim() + "\n"));
                    str_old = str_old + (cj_log.S_SCCJ.Trim() == txtsccj.Text.Trim() ? "" : ("原厂家:" + cj_log.S_SCCJ + " 现厂家:" + txtsccj.Text.Trim() + "\n"));
                    str_old = str_old + (gg_log.PYM.Trim() == txtpym.Text.Trim() ? "" : ("原拼音码:" + gg_log.PYM + " 现拼音码:" + txtpym.Text.Trim() + "\n"));
                    // str_old = str_old == "" ? "" : ("修改药品:" + gg_log.YPPM.Trim() + "(" + InstanceForm.BCurrentUser.Name + ")\n" + str_old);


                    str_log = str_log + (gg_log.LYFS.ToString() == cmblyfs.SelectedValue.ToString() ? "" : ("领药方式修改为:" + cmblyfs.Text.Trim() + "\n"));
                    str_log = str_log + (gg_log.TLFL.Trim() == cmbtlfl.SelectedValue.ToString() ? "" : ("原统领分类:" + Yp.SeekTlfl(gg_log.TLFL, InstanceForm.BDatabase) + " 现统领分类:" + cmbtlfl.Text.Trim() + "\n"));
                    str_log = str_log + (gg_log.CFJB.ToString() == Convert.ToInt32(Convertor.IsNull(cmbcfjb.Text.Substring(0, 1), "0")).ToString() ? "" : ("原处方级别:" + gg_log.CFJB.ToString() + " 现处方级别修改为:" + cmbcfjb.Text.Trim() + "\n"));
                    str_log = str_log + (gg_log.MZYP.ToString() == chkmzyp.Checked.ToString() ? "" : ("原麻醉状态:" + gg_log.MZYP.ToString() + " 现麻醉状态:" + chkmzyp.Checked.ToString() + "\n"));
                    str_log = str_log + (gg_log.DJYP.ToString() == chkdjyp.Checked.ToString() ? "" : ("原毒剧状态:" + gg_log.DJYP.ToString() + " 现毒剧状态:" + chkdjyp.Checked.ToString() + "\n"));
                    str_log = str_log + (gg_log.PSYP.ToString() == chkpsyp.Checked.ToString() ? "" : ("原皮试状态:" + gg_log.PSYP.ToString() + " 现皮试状态:" + chkpsyp.Checked.ToString() + "\n"));
                    str_log = str_log + (gg_log.JSYP.ToString() == chkjsyp.Checked.ToString() ? "" : ("原精神状态:" + gg_log.JSYP.ToString() + " 现精神状态:" + chkjsyp.Checked.ToString() + "\n"));
                    str_log = str_log + (gg_log.GZYP.ToString() == chkgzyp.Checked.ToString() ? "" : ("原贵重状态:" + gg_log.GZYP.ToString() + " 现贵重状态:" + chkgzyp.Checked.ToString() + "\n"));
                    str_log = str_log + (gg_log.WYYP.ToString() == chkwyyp.Checked.ToString() ? "" : ("原外用状态:" + gg_log.WYYP.ToString() + " 现外用状态:" + chkwyyp.Checked.ToString() + "\n"));
                    str_log = str_log + (gg_log.CFYP.ToString() == chkcfyp.Checked.ToString() ? "" : ("原处方状态:" + gg_log.CFYP.ToString() + " 现处方状态:" + chkcfyp.Checked.ToString() + "\n"));
                    str_log = str_log + (gg_log.RSYP.ToString() == chkrsyp.Checked.ToString() ? "" : ("原妊娠状态:" + gg_log.RSYP.ToString() + " 现妊娠状态:" + chkrsyp.Checked.ToString() + "\n"));

                    str_log = str_log + ((gg_log.FZYY.ToString() == (chkFzYy.Checked ? 1 : 0).ToString()) ? "" : ("原辅助用药:" + gg_log.FZYY.ToString() + " 现辅助用药:" + (chkFzYy.Checked ? 1 : 0).ToString() + "\n"));
                    str_log = str_log + ((gg_log.FSX.ToString() == (chkFsx.Checked ? 1 : 0).ToString()) ? "" : ("原放射性:" + gg_log.FSX.ToString() + " 现放射性:" + (chkFsx.Checked ? 1 : 0).ToString() + "\n"));
                    str_log = str_log + ((gg_log.HLYW.ToString() == (chkhlyw.Checked ? 1 : 0).ToString()) ? "" : ("原化疗药物:" + gg_log.HLYW.ToString() + " 现化疗药物:" + (chkhlyw.Checked ? 1 : 0).ToString() + "\n"));
                    str_log = str_log + (gg_log.KSSDJ.ToString() == Convertor.IsNull(cmbKssdj.SelectedValue, "0") ? "" : ("原抗生素等级:" + gg_log.KSSDJ.ToString() + " 现抗生素等级:" + Convertor.IsNull(cmbKssdj.SelectedValue, "0") + "\n"));
                    str_log = str_log + (gg_log.DDD.ToString() == Convertor.IsNull(txtDdd.Text, "0") ? "" : ("原DDD:" + gg_log.DDD.ToString() + " 现DDD:" + txtDdd.Text + "\n"));

                    bz = "修改药品:" + gg_log.YPPM.Trim() + "(" + InstanceForm.BCurrentUser.Name + ") CJID=" + cj_log.CJID.ToString() + "";
                }
                else
                {
                    str_old = "新增药品:" + txtyppm.Text.Trim() + "(" + InstanceForm.BCurrentUser.Name + ")\n";
                    str_old = str_old + "规格:" + txtypgg.Text.Trim() + "\n";
                    str_old = str_old + "厂家:" + txtsccj.Text.Trim() + "\n";
                    str_old = str_old + "单价:" + txtlsj.Text.Trim() + "\n";
                }

                string strr = str_old + str_log;
                if (strr != "")
                {
                    strr = bz + strr;
                    SystemLog systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "修改药品字典", strr, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, 8);
                    systemLog.Save();
                    systemLog = null;
                }
                #endregion

                Ypgg ypgg = new Ypgg();
                ypgg.GGID = ggid;
                ypgg.YPLX = Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0"));
                ypgg.YPZLX = Convert.ToInt32(Convertor.IsNull(cmbypzlx.SelectedValue, "0"));
                ypgg.GJBM = "";
                ypgg.YPPM = txtyppm.Text.Trim();
                ypgg.YPSPM = txtypspm.Text.Trim();
                ypgg.YPSPMBZ = txtypspmbz.Text.Trim();
                ypgg.YPDW = Convert.ToInt32(Convertor.IsNull(txtypdw.Tag, "0"));
                ypgg.YLFL = Convert.ToInt32(Convertor.IsNull(txtylfl.Tag, "0"));
                ypgg.YPJX = Convert.ToInt32(Convertor.IsNull(txtypjx.Tag, "0"));
                ypgg.HLXS = Convert.ToDecimal(Convertor.IsNull(txthlxs.Text, "0"));
                ypgg.HLDW = Convert.ToInt32(Convertor.IsNull(txthldw.Tag, "0"));
                ypgg.BZSL = Convert.ToInt32(Convertor.IsNull(txtbzsl.Text, "0"));
                ypgg.BZDW = Convert.ToInt32(Convertor.IsNull(txtbzdw.Tag, "0"));
                ypgg.SYXL = 0;
                ypgg.YPGG = txtypgg.Text.Trim();
                ypgg.GGBZ = txtbz.Text.Trim();
                ypgg.GGBDELETE = 0;
                ypgg.SYFF = Convert.ToInt32(Convertor.IsNull(txtsyff.Tag, "0"));
                ypgg.GGDJSJ = "";
                ypgg.CFJB = Convert.ToInt32(Convertor.IsNull(cmbcfjb.Text.Substring(0, 1), "0"));
                ypgg.DJYP = this.chkdjyp.Checked;
                ypgg.MZYP = this.chkmzyp.Checked;
                ypgg.PSYP = this.chkpsyp.Checked;
                ypgg.JSYP = this.chkjsyp.Checked;
                ypgg.GZYP = this.chkgzyp.Checked;
                ypgg.CFYP = this.chkcfyp.Checked;
                ypgg.WYYP = this.chkwyyp.Checked;
                ypgg.RSYP = this.chkrsyp.Checked;
                ypgg.LYFS = Convert.ToInt32(Convertor.IsNull(cmblyfs.SelectedValue, "0"));
                ypgg.WBM = txtwbm.Text.Trim();
                ypgg.PYM = txtpym.Text.Trim();
                ypgg.TLFL = Convertor.IsNull(cmbtlfl.SelectedValue, "0") == "0" ? "" : cmbtlfl.SelectedValue.ToString().Trim();
                ypgg.HWJXBM = txthwjxbm.Text.Trim().ToUpper();
                ypgg.YPYWM = txtypywm.Text.Trim();
                ypgg.XGR = InstanceForm.BCurrentUser.EmployeeId;
                ypgg.ZT = txtzt.Text.Trim();
                ypgg.GWYP = this.chkgwyp.Checked;

                ypgg.JSYPFL = cmbjsypfl.SelectedIndex;

                ypgg.KSSDJ = Convert.ToInt32(Convertor.IsNull(cmbKssdj.SelectedValue, "0"));
                ypgg.DDD = Convert.ToDecimal(Convertor.IsNull(txtDdd.Text, "0"));
                ypgg.GJJBYW = chkgjjbyw.Checked;
                ypgg.DPZYP = this.chkdpzyp.Checked;
                ypgg.DDDJL = Convert.ToDecimal(Convertor.IsNull(txtDDDjl.Text, "0"));//ddd剂量
                ypgg.DDDJLDW = Convert.ToInt32(Convertor.IsNull(txtDDDjldw.Tag, "0"));//ddd剂量单位

                //Add By Tany 2015-05-25
                ypgg.JBYWLX = chkgjjbyw.Checked ? (Convert.ToInt32(Convertor.IsNull(cmbJbyw.SelectedValue, "0"))) : 0;
                ypgg.GWYPJB = cmbGwypjb.SelectedIndex != -1 && cmbGwypjb.Enabled ? int.Parse(cmbGwypjb.SelectedValue.ToString()) : 0;

                //Add By jchl 2016-10-11
                ypgg.FZYY = chkFzYy.Checked ? 1 : 0;

                //Add by Zhujh 2017-02-18
                ypgg.FSX = chkFsx.Checked ? 1 : 0;

                //Add by chenl 2017-03-23
                ypgg.HLYW = chkhlyw.Checked ? 1 : 0;

                ypgg.SaveGG(out _ggid, out _errcode, out _errtext, InstanceForm.BDatabase);
                if (_ggid == 0 || _errcode != 0) throw new Exception(_errtext);


                Ypcj ypcj = new Ypcj();
                ypcj.CJID = cjid;
                ypcj.GGID = _ggid;
                ypcj.SHH = txthh.Text.Trim();
                ypcj.N_YPLX = Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue, "0"));
                ypcj.N_YPZLX = Convert.ToInt32(Convertor.IsNull(cmbypzlx.SelectedValue, "0"));
                ypcj.S_YPJX = txtypjx.Text.Trim();
                ypcj.S_YPPM = txtyppm.Text.Trim();
                ypcj.S_YPSPM = txtypspm.Text.Trim();
                ypcj.S_YPSPMBZ = txtypspmbz.Text.Trim();
                ypcj.S_YPGG = txtypgg.Text.Trim();
                ypcj.S_SCCJ = txtsccj.Text.Trim();
                ypcj.S_YPDW = txtypdw.Text.Trim();
                ypcj.TXM = txttxm.Text.Trim();
                ypcj.SCCJ = Convert.ToInt32(Convertor.IsNull(txtsccj.Tag, "0"));
                ypcj.ZBJ = 0;
                ypcj.PFJ = Convert.ToDecimal(Convertor.IsNull(txtpfj.Text, "0"));
                ypcj.ZGLSJ = Convert.ToDecimal(Convertor.IsNull(txtzglsj.Text, "0"));
                ypcj.LSJ = Convert.ToDecimal(Convertor.IsNull(txtlsj.Text, "0"));
                ypcj.PZWH = txtpzwh.Text.Trim();
                ypcj.YXQ = 0;
                ypcj.YBLX = Convertor.IsNull(cmbyblx.SelectedValue, "");
                ypcj.ZFBL = Convert.ToDecimal(Convertor.IsNull(txtzfbl.Text, "0"));
                ypcj.MRKL = Convert.ToDecimal(Convertor.IsNull(txtmrkl.Text, "0"));
                ypcj.MRJJ = Convert.ToDecimal(Convertor.IsNull(txtmrjj.Text, "0"));
                ypcj.CJBDELETE = this.chkstop.Checked;
                ypcj.ZBZT = chkzbzt.Checked == true ? 1 : 0;
                ypcj.ZBDW = "";
                ypcj.ZBQH = txthh.Text.Trim(); //改成货号计数器
                ypcj.CJBZ = "";
                ypcj.YLFL = Convert.ToInt64(Convertor.IsNull(txtylfl.Tag, "0"));
                ypcj.S_YPYWM = txtypywm.Text.Trim();
                ypcj.CGLSH = txtcglsh.Text.Trim();
                ypcj.MRGHDW = Convert.ToInt32(Convertor.IsNull(txtghdw.Tag, "0"));
                ypcj.FKBL = Convert.ToDecimal(Convertor.IsNull(txtfkbl.Text, "100")) / 100; //付款比例
                ypcj.BHTDW = chkbhtdw.Checked; //是否合同单位

                ypcj.SaveCJ(out _cjid, out _errcode, out _errtext, InstanceForm.BDatabase);
                if (_cjid == 0 || _errcode != 0) throw new Exception(_errtext);

                //*******************添加推送药品字典到SCM系统  2016-09-03 By HuangYD  ************************
                bool Suc_flag = false;
                if (cjid > 0)
                {
                    //cjid >0 则为修改药品字典 
                    try
                    {
                        Suc_flag = PushDRugInfoToSCM(cjid.ToString(), "U");
                        if (Suc_flag)
                        {
                            MessageBox.Show("在SCM中修改药品字典成功！");
                        }
                        else
                        {
                            MessageBox.Show("在SCM中修改药品字典失败！");
                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show("发生错误：" + err.Message);
                    }
                }
                else
                {
                    //说明增加字典
                    try
                    {
                        Suc_flag = PushDRugInfoToSCM(_cjid.ToString(), "C");
                        if (Suc_flag)
                        {
                            MessageBox.Show("在SCM中增加药品字典成功！");
                        }
                        else
                        {
                            MessageBox.Show("在SCM中增加药品字典失败！");
                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show("发生错误：" + err.Message);
                    }
                }


                //**********************************************************************************************


                //Modify By Tany 2015-11-24 如果不勾选，要把外部药品的勾去掉
                //if (chwbyp.Checked)
                //{
                //add pengyang 2015-10-27  增加便民药房判断
                ssql = string.Format(" update YP_YPCJD set Iswbyp = {1} where cjid = {0}", _cjid, (chwbyp.Checked ? 1 : 0));
                int ret = InstanceForm.BDatabase.DoCommand(ssql);
                //}
                //如果是外部科室，保存时直接写入 Modify By Tany 2015-11-24
                if (isWbks)
                {
                    ssql = string.Format("insert into yp_wbksyp(cjid,deptid) values({0},{1})", _cjid, InstanceForm.BCurrentDept.DeptId);
                    InstanceForm.BDatabase.DoCommand(ssql);
                }
                //如果没勾选外部药品，删除该药品所有的对应关系
                if (!chwbyp.Checked)
                {
                    ssql = string.Format("delete from yp_wbksyp where cjid = {0} ", _cjid);
                    InstanceForm.BDatabase.DoCommand(ssql);
                }

                if (txtyppm.Text.Trim() != txtypspm.Text.Trim())
                {
                    ssql = "select * from yp_ypbm where pym='" + TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtyppm.Text, 0).Trim() + "' and ggid=" + _ggid + "";
                    DataTable tbbm = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tbbm.Rows.Count == 0)
                    {
                        long newbmid = 0;
                        Ypbm bm = new Ypbm();
                        bm.ID = 0;
                        bm.GGID = _ggid;
                        bm.YPBM = txtyppm.Text.Trim();
                        bm.PYM = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtyppm.Text, 0);
                        bm.WBM = TrasenClasses.GeneralClasses.PubStaticFun.GetPYWBM(txtyppm.Text, 1);
                        bm.Save(InstanceForm.BDatabase, out newbmid);
                    }
                }

                //更新药品货号
                ypcj.Update_shh(_ggid, out _errcode, out _errtext, InstanceForm.BDatabase);
                if (_errcode != 0) throw new Exception(_errtext);


                //三院数据处理
                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                ts.Save_log(ts_HospData_Share.czlx.yp_药品字典修改, InstanceForm.BCurrentUser.Name + "对药品【" + ypgg.YPPM + " " + ypgg.YPGG + "  " + ypcj.S_SCCJ + " 】 进行修改", "yp_ypcjd", "cjid", _cjid.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                InstanceForm.BDatabase.CommitTransaction();


                this.groupBox2.Tag = _cjid.ToString();
                this.groupBox1.Tag = _ggid.ToString();

                Ypcj cj = new Ypcj(_cjid, InstanceForm.BDatabase);
                this.groupBox1.Text = "基本信息   " + cj.SHH.Trim();

                if (cjid == 0)
                    butnewgg_Click(sender, e);

                //三院数据处理
                string errtext = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.yp_药品字典修改, InstanceForm.BDatabase);
                if (ty.Bzx == 1)
                    ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);



                if (errtext != "")
                    MessageBox.Show(_errtext + errtext, "保存", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show(_errtext, "保存", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //消息发送
                TrasenFrame.Classes.WorkStaticFun.SendMessage(false, TrasenFrame.Classes.SystemModule.药品系统, "", 0, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, str_old);

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        /// <summary>
        /// 把药品字典信息添加到SCM
        /// </summary>
        /// <param name="strCjid"></param>
        private bool PushDRugInfoToSCM(string strCjid, string ActFlag)
        {
            DataTable tabInfo = null;
            bool err_flag = true;
            bool Suc_flag = false;
            List<SCMHisDrugItem> scmDrugInfo = new List<SCMHisDrugItem>();
            tabInfo = ScmHisSer.GetDrugInfoByCjid(strCjid, InstanceForm.BDatabase);
            if (tabInfo.Rows.Count > 0)
            {
                SCMHisDrugItem drugInfo = new SCMHisDrugItem();
                drugInfo.NAME = tabInfo.Rows[0]["NAME"].ToString();
                drugInfo.CODE = tabInfo.Rows[0]["CODE"].ToString();
                drugInfo.SPEC = tabInfo.Rows[0]["SPEC"].ToString();
                drugInfo.FACTORY = tabInfo.Rows[0]["FACTORY"].ToString();
                drugInfo.MRJJ = Convert.ToDecimal(tabInfo.Rows[0]["MRJJ"].ToString());
                scmDrugInfo.Add(drugInfo);
            }
            try
            {
                //public static void HisPushDrugItemToSCM(List<SCMHisDrugItem> DrugItem, string ActFlag)                
                ScmHisSer.HisPushDrugItemToSCM(scmDrugInfo, ActFlag, out Suc_flag, out err_flag);
                return Suc_flag;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }


        /// <summary>
        /// 删除一个药品事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butdel_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("您确定要删除第当前药品吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    string ssql = "select * from jc_jgbm where ipaddr is not null and len(ipaddr)>6 and jgbm<>" + InstanceForm._menuTag.Jgbm + "  ";
                    DataTable tbjg = InstanceForm.BDatabase.GetDataTable(ssql);
                    for (int i = 0; i <= tbjg.Rows.Count - 1; i++)
                    {
                        RelationalDatabase MB_DB = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(Convert.ToInt32(tbjg.Rows[i]["jgbm"]));

                        ssql = "select * from yk_kcmx where CJID=" + Convertor.IsNull(this.groupBox2.Tag, "0") + "";
                        DataRow row = MB_DB.GetDataRow(ssql);
                        if (row != null) throw new Exception("该药品在 [" + tbjg.Rows[i]["jgmc"].ToString().Trim() + "]  已有使用记录,不能删除");

                        ssql = "select * from yf_kcmx where CJID=" + Convertor.IsNull(this.groupBox2.Tag, "0") + "";
                        row = MB_DB.GetDataRow(ssql);
                        if (row != null) throw new Exception("该药品在 [" + tbjg.Rows[i]["jgmc"].ToString().Trim() + "]  已有使用记录,不能删除");

                        MB_DB.Close();
                        MB_DB.Dispose();
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    InstanceForm.BDatabase.BeginTransaction();

                    //***************在SCM中删除药品字典数据  2016-09-03 HuangYD **********************************
                    string strCjid = this.groupBox2.Tag.ToString();
                    bool Suc_flag = false;
                    try
                    {
                        Suc_flag = PushDRugInfoToSCM(strCjid, "D");
                        if (Suc_flag)
                        {
                            MessageBox.Show("在SCM中删除药品字典成功！");
                        }
                        else
                        {
                            MessageBox.Show("在SCM中删除药品字典失败！");
                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show("发生错误：" + err.Message);
                    }
                    //****************************************************************************************** 

                    //Ypcj.DeleteCJ(Convert.ToInt32(Convertor.IsNull(this.groupBox1.Tag, "0")), Convert.ToInt32(Convertor.IsNull(this.groupBox2.Tag, "0")), InstanceForm.BDatabase);

                    //三院数据处理
                    Guid log_djid = Guid.Empty;
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    ts.Save_log(ts_HospData_Share.czlx.yp_药品字典修改, InstanceForm.BCurrentUser.Name + "删除药品 【" + txtyppm.Text + " " + txtypgg.Text + "  " + txtsccj.Text + " 】 ", "yp_ypcjd", "cjid", Convertor.IsNull(this.groupBox2.Tag, "0"), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                    InstanceForm.BDatabase.CommitTransaction();

                    //三院数据处理
                    string errtext = "";
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.yp_药品字典修改, InstanceForm.BDatabase);
                    if (ty.Bzx == 1)
                        ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);

                    MessageBox.Show("  删除成功  " + errtext, "删除", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    butnewgg_Click(sender, e);




                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }


        /// <summary>
        /// 新增药品按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butnewgg_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < this.groupBox1.Controls.Count - 1; i++)
            {
                if (this.groupBox1.Controls[i].GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    this.groupBox1.Controls[i].Text = "";
                    this.groupBox1.Controls[i].Tag = "0";
                }
                this.groupBox1.Controls[i].Enabled = true;
            }

            for (int i = 0; i < this.groupBox2.Controls.Count - 1; i++)
            {
                if (this.groupBox2.Controls[i].GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    this.groupBox2.Controls[i].Text = "";
                    this.groupBox2.Controls[i].Tag = "0";
                }
                this.groupBox2.Controls[i].Enabled = true;
            }


            this.groupBox1.Text = "基本信息";
            this.groupBox1.Tag = "0";
            this.groupBox2.Tag = "0";
            this.cmbyplx.Focus();
            this.cmbcfjb.SelectedIndex = 3;

            chkcfyp.Checked = false;
            chkdjyp.Checked = false;
            chkgzyp.Checked = false;
            chkjsyp.Checked = false;
            chkmzyp.Checked = false;
            chkpsyp.Checked = false;
            chkrsyp.Checked = false;
            chkwyyp.Checked = false;
            chkstop.Checked = false;
            chkzbzt.Checked = true;
            chkgwyp.Checked = false;

            chkFzYy.Checked = false;

            cmbjsypfl.SelectedIndex = 0;

            chkdpzyp.Checked = false;
            txtDDDjl.Text = "0.0000";
            txtDDDjldw.Text = "";
            txtDDDjldw.Tag = 0;
        }


        /// <summary>
        /// 新增厂家按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butnewcj_Click(object sender, System.EventArgs e)
        {
            this.chkbhtdw.Enabled = false;//合同单位
            this.cmbyplx.Enabled = false;
            this.cmbypzlx.Enabled = false;
            this.txtypjx.Enabled = false;
            this.txtyppm.Enabled = false;
            this.txtypspm.Enabled = false;
            this.txtypspmbz.Enabled = false;
            this.txtpym.Enabled = false;
            this.txtwbm.Enabled = false;
            this.chkstop.Enabled = false;
            this.txtypdw.Enabled = false;
            this.txthlxs.Enabled = false;
            this.txthldw.Enabled = false;
            this.txtbzsl.Enabled = false;
            this.txtbzdw.Enabled = false;
            this.txtypgg.Enabled = false;
            this.cmblyfs.Enabled = false;
            this.txtsyff.Enabled = false;
            this.txtylfl.Enabled = false;
            this.cmbcfjb.Enabled = false;
            this.txtzzbz.Enabled = false;
            this.txtbz.Enabled = false;
            if ((new SystemCfg(8005)).Config != "1")
                this.txthh.Enabled = false;

            this.chkstop.Checked = false;

            this.chkmzyp.Enabled = false;
            this.chkdjyp.Enabled = false;
            this.chkpsyp.Enabled = false;
            this.chkjsyp.Enabled = false;
            this.chkgzyp.Enabled = false;
            this.chkwyyp.Enabled = false;
            this.chkcfyp.Enabled = false;

            this.chkFzYy.Enabled = false;


            this.chkzbzt.Enabled = false;
            this.chkgwyp.Enabled = false;
            this.chkdpzyp.Enabled = false;
            this.chkrsyp.Enabled = false;
            this.chkgjjbyw.Enabled = false;

            //                this.chkzbzt.Enabled = false;

            this.txthwjxbm.Enabled = false;

            this.txtsccj.Text = "";
            this.txtsccj.Tag = "0";

            this.txtfkbl.Text = "100";//付款比例
            this.txtpzwh.Text = "";
            this.txtzfbl.Text = "";
            this.txtzglsj.Text = "";

            //this.txtpfj.Text = "";//批发价
            //this.txtlsj.Text = "";//零售价
            //this.txtmrjj.Text="";//默认进价  药品字典新增厂家批发价、零售价、默认进价都默认为上一个厂家的内容，不要清空

            this.txtmrkl.Text = "";
            this.txttxm.Text = "";
            this.txtcglsh.Text = "";
            this.txtghdw.Text = "";
            txtghdw.Tag = "0";

            //----------------
            this.groupBox1.Text = "基本信息";
            this.groupBox2.Tag = "0";
            this.txtsccj.Focus();
        }


        /// <summary>
        /// 退出按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butquit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


         /// <summary>
        /// 上一个药品事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butup_Click(object sender, System.EventArgs e)
        {
            string ssql = "";
            if (InstanceForm._menuTag.Function_Name == "Fun_ts_yp_ypcd" && InstanceForm.BCurrentUser.IsAdministrator == false)
                ssql = "select top 1 * from yp_ypcjd where cjid<" + Convert.ToInt32(Convertor.IsNull(this.groupBox2.Tag, "0")) + " and n_ypzlx in(select ypzlx from yp_gllx where deptid=" + InstanceForm.BCurrentDept.DeptId + ") order by cjid desc";
            else
                ssql = "select top 1 * from yp_ypcjd where cjid<" + Convert.ToInt32(Convertor.IsNull(this.groupBox2.Tag, "0")) + " order by cjid desc";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 1)
                FillYp(Convert.ToInt32(tb.Rows[0]["cjid"]));
            txtyppm.Focus();
        }

        /// <summary>
        /// 下一个药品事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butnext_Click(object sender, System.EventArgs e)
        {
            string ssql = "";
            if (InstanceForm._menuTag.Function_Name == "Fun_ts_yp_ypcd" && InstanceForm.BCurrentUser.IsAdministrator == false)
                ssql = "select top 1 * from yp_ypcjd where cjid>" + Convert.ToInt32(Convertor.IsNull(this.groupBox2.Tag, "0")) + " and n_ypzlx in(select ypzlx from yp_gllx where deptid=" + InstanceForm.BCurrentDept.DeptId + ") order by cjid";
            else
                ssql = "select top 1 * from yp_ypcjd where cjid>" + Convert.ToInt32(Convertor.IsNull(this.groupBox2.Tag, "0")) + " order by cjid";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 1)
                FillYp(Convert.ToInt32(tb.Rows[0]["cjid"]));
            txtyppm.Focus();
        }


        /// <summary>
        /// 新增别名按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_bm_new_Click(object sender, System.EventArgs e)
        {
            FillYpbm(0);
        }

        /// <summary>
        /// 保存别名按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_bm_save_Click(object sender, System.EventArgs e)
        {
            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                long bmid = 0;
                ////Ypbm bm = new Ypbm();
                bm.ID = Convert.ToInt64(Convertor.IsNull(this.txtypbm.Tag, "0"));
                bm.GGID = Convert.ToInt32(Convertor.IsNull(this.groupBox1.Tag, "0"));
                bm.YPBM = txtypbm.Text.Trim();
                bm.PYM = txtbmpym.Text.Trim();
                bm.WBM = txtbmwbm.Text.Trim();
                bm.YWM = txtbmywm.Text.Trim();
                bm.SZM = txtbmszm.Text.Trim();
                bm.SPMBZ = this.chkspm.Checked;
                bm.Save(InstanceForm.BDatabase, out bmid);

                //三院数据处理_____保存日志
                string bz = "";
                if (bm.ID == 0)
                    bz = "增加药品别名:" + bm.YPBM;
                else
                    bz = "修改药品别名为:" + bm.YPBM;
                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                ts.Save_log(ts_HospData_Share.czlx.yp_药品基础数据单表修改, bz, "yp_ypbm", "id", bmid.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                InstanceForm.BDatabase.CommitTransaction();

                //三院数据处理___执行同步操作 
                string errtext = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.yp_药品基础数据单表修改, InstanceForm.BDatabase);
                if (ty.Bzx == 1) //只有当立即执行标志为1时才执行
                    ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);

                MessageBox.Show("保存成功" + errtext, "保存", MessageBoxButtons.OK, MessageBoxIcon.Information);

                but_bm_new_Click(sender, e);
                FillYpbmTable(Convert.ToInt32(Convertor.IsNull(this.groupBox1.Tag, "0")));

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 删除别名按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_bm_del_Click(object sender, System.EventArgs e)
        {
            try
            {
                Ypbm bm = new Ypbm(Convert.ToInt64(Convertor.IsNull(this.txtypbm.Tag, "0")), InstanceForm.BDatabase);
                bm.Delete(InstanceForm.BDatabase);
                FillYpbmTable(Convert.ToInt32(Convertor.IsNull(this.groupBox1.Tag, "0")));

                //三院数据处理
                string bz = "";
                bz = "删除别名:" + bm.YPBM;
                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                ts.Save_log(ts_HospData_Share.czlx.yp_药品基础数据单表修改, bz, "yp_ypbm", "id", bm.ID.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                //三院数据处理
                string errtext = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.yp_药品基础数据单表修改, InstanceForm.BDatabase);
                if (ty.Bzx == 1)
                    ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);




            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 在别名网格中改变单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (nrow > tb.Rows.Count) return;
                FillYpbm(Convert.ToInt64(tb.Rows[nrow]["id"]));
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frmypcd_Activated(object sender, System.EventArgs e)
        {
            //Ypcj cj = new Ypcj(_Cjid, InstanceForm.BDatabase);
            Ypgg gg = new Ypgg(cj.GGID, InstanceForm.BDatabase);
            if (gg.CFJB == 0)
                this.cmbcfjb.SelectedIndex = 3;
            else
                this.cmbcfjb.SelectedIndex = gg.CFJB - 1;
        }

        //医保类型选择事件
        private void cmbyblx_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (Convertor.IsNull(cmbyblx.SelectedValue, "0") != "0")
            {
                string ssql = "select zfbl from yp_yblx where bh='" + cmbyblx.SelectedValue.ToString().Trim() + "'";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count > 0)
                    txtzfbl.Text = tb.Rows[0]["zfbl"].ToString();
            }
        }

        private void chkjsyp_CheckedChanged(object sender, EventArgs e)
        {
            cmbjsypfl.Enabled = chkjsyp.Checked;
            if (chkjsyp.Checked == false) cmbjsypfl.SelectedIndex = 0;
        }

        /// <summary>
        /// Modify by dyw 2014.6.27 只舍不入
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private decimal RoundingNotIn(decimal obj, int len)
        {
            string str = "0." + "".PadLeft(len, '0') + "5";
            decimal dec = Convert.ToDecimal(str);
            return Math.Round(obj - dec, len, MidpointRounding.AwayFromZero);
        }

        //Add By Tany 2015-05-25
        private void chkgjjbyw_CheckedChanged(object sender, EventArgs e)
        {
            cmbJbyw.Enabled = chkgjjbyw.Checked;
        }

        private void chkgwyp_CheckedChanged(object sender, EventArgs e)
        {
            cmbGwypjb.Enabled = chkgwyp.Checked;
            if (cmbGwypjb.Enabled == false)
                cmbGwypjb.SelectedIndex = -1;
        }


    }
}
