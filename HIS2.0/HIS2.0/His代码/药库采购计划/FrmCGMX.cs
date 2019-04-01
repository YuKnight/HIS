using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
using ts_SCM_HIS;
using System.Text;
using System.Collections.Generic;
//using Excel=Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Excel;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;

//add com "Microsoft Excel 11.0 Object Library"  



namespace ts_yk_cgjh
{
    /// <summary>
    /// Frmyprk 的摘要说明。
    /// </summary>
    public class FrmCGMX : System.Windows.Forms.Form
    {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.StatusBarPanel statusBarPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbz;
        private System.Windows.Forms.Label lbldjh;
        private System.Windows.Forms.Label lbldjhd;
        private System.Windows.Forms.TextBox txtypdm;
        private System.Windows.Forms.TextBox txtypsl;
        private System.Windows.Forms.ComboBox cmbdw;
        private System.Windows.Forms.Label lblhh;
        private System.Windows.Forms.Label lblypmc;
        private System.Windows.Forms.Label lblcj;
        private System.Windows.Forms.Label lblgg;
        private System.Windows.Forms.Label lblkc;
        private System.Windows.Forms.Label lbllsj;
        private System.Windows.Forms.Label lblpfj;
        private System.Windows.Forms.Button butmodif;
        private System.Windows.Forms.Button butdel;
        private System.Windows.Forms.Button butadd;
        private myDataGrid.myDataGrid myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
        private System.Windows.Forms.Label lbldjrq;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
        private System.Windows.Forms.DateTimePicker dtprq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtckjj;
        private System.Windows.Forms.TextBox txtghdw;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private myDataGrid.myDataGrid myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn33;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn34;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn35;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn37;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn38;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn39;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn40;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblzbj;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label lblzbqh;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label lblzbdw;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label lblzbzt;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label lblscjj;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn41;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbfxff;
        private System.Windows.Forms.Button butref;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button butsh;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn42;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn43;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblmrjj;
        private System.Windows.Forms.CheckBox checkBox2;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.Label lblpm;
        private YpConfig ss;
        private System.Windows.Forms.DataGridTextBoxColumn 商品名;
        private DataGridTextBoxColumn dataGridTextBoxColumn44;
        private System.Windows.Forms.Label label5;
        private ComboBox cmbpx;
        private System.Windows.Forms.Label label7;
        private DataGridTextBoxColumn dataGridTextBoxColumn45;
        private ComboBox cmbck;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ComboBox cmbyplx;
        private ComboBox cmbckkc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button butexcel;
        private DataGridTextBoxColumn dataGridTextBoxColumn46;
        private DataGridTextBoxColumn dataGridTextBoxColumn47;
        private DataGridTextBoxColumn dataGridTextBoxColumn48;
        private DataGridTextBoxColumn dataGridTextBoxColumn49;
        private DataGridTextBoxColumn dataGridTextBoxColumn50;

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private DataGridTextBoxColumn dataGridTextBoxColumn51;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExportSCM;
        private ComboBox comSFDZ;
        private System.Windows.Forms.Label label13;

        private bool btjhj = false;//是否调进货价


        public FrmCGMX(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";



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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comSFDZ = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbckkc = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbpx = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.butref = new System.Windows.Forms.Button();
            this.cmbfxff = new System.Windows.Forms.ComboBox();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbldjh = new System.Windows.Forms.Label();
            this.lbldjhd = new System.Windows.Forms.Label();
            this.dtprq = new System.Windows.Forms.DateTimePicker();
            this.lbldjrq = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExportSCM = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblpm = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblmrjj = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblzbj = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.lblzbqh = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.lblzbdw = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.lblzbzt = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtghdw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtckjj = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butmodif = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butadd = new System.Windows.Forms.Button();
            this.lblscjj = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.lblkc = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtypsl = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lbllsj = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblpfj = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbdw = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblhh = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblypmc = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblcj = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblgg = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtypdm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.商品名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn46 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn49 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn44 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn47 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn43 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn45 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn48 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn50 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn51 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid2 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.butsh = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butexcel = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comSFDZ);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbckkc);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbyplx);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbpx);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.butref);
            this.groupBox1.Controls.Add(this.cmbfxff);
            this.groupBox1.Controls.Add(this.txtbz);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbldjh);
            this.groupBox1.Controls.Add(this.lbldjhd);
            this.groupBox1.Controls.Add(this.dtprq);
            this.groupBox1.Controls.Add(this.lbldjrq);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1014, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comSFDZ
            // 
            this.comSFDZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSFDZ.Location = new System.Drawing.Point(423, 41);
            this.comSFDZ.Name = "comSFDZ";
            this.comSFDZ.Size = new System.Drawing.Size(132, 20);
            this.comSFDZ.TabIndex = 57;
            this.comSFDZ.SelectedIndexChanged += new System.EventHandler(this.comSFDZ_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(364, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 56;
            this.label13.Text = "配送地址";
            // 
            // cmbckkc
            // 
            this.cmbckkc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbckkc.ForeColor = System.Drawing.Color.Navy;
            this.cmbckkc.Items.AddRange(new object[] {
            "药品类型、供货单位",
            "药品类型、统领分类、剂型",
            "药品类型、药理分类、剂型"});
            this.cmbckkc.Location = new System.Drawing.Point(223, 37);
            this.cmbckkc.Name = "cmbckkc";
            this.cmbckkc.Size = new System.Drawing.Size(132, 20);
            this.cmbckkc.TabIndex = 54;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(172, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 16);
            this.label11.TabIndex = 55;
            this.label11.Text = "参考库存";
            // 
            // cmbyplx
            // 
            this.cmbyplx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyplx.Location = new System.Drawing.Point(616, 37);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(81, 20);
            this.cmbyplx.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(561, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 52;
            this.label9.Text = "药品类型";
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbck.Location = new System.Drawing.Point(61, 13);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(108, 20);
            this.cmbck.TabIndex = 0;
            this.cmbck.SelectedIndexChanged += new System.EventHandler(this.cmbck_SelectedIndexChanged);
            this.cmbck.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(7, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 51;
            this.label8.Text = "仓库名称";
            // 
            // cmbpx
            // 
            this.cmbpx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpx.ForeColor = System.Drawing.Color.Navy;
            this.cmbpx.Items.AddRange(new object[] {
            "药品类型、供货单位",
            "药品类型、统领分类、剂型",
            "药品类型、药理分类、剂型",
            "药品类型、药品名称",
            "药品名称",
            "供货单位"});
            this.cmbpx.Location = new System.Drawing.Point(474, 13);
            this.cmbpx.Name = "cmbpx";
            this.cmbpx.Size = new System.Drawing.Size(225, 20);
            this.cmbpx.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(421, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 49;
            this.label7.Text = "排序方法";
            // 
            // butref
            // 
            this.butref.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butref.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butref.Location = new System.Drawing.Point(942, 11);
            this.butref.Name = "butref";
            this.butref.Size = new System.Drawing.Size(68, 45);
            this.butref.TabIndex = 47;
            this.butref.Text = "查询(&F)";
            this.butref.Click += new System.EventHandler(this.butref_Click);
            // 
            // cmbfxff
            // 
            this.cmbfxff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfxff.ForeColor = System.Drawing.Color.Navy;
            this.cmbfxff.Items.AddRange(new object[] {
            "低于下限以上限为计划数",
            "以上限和库存差值为计划数"});
            this.cmbfxff.Location = new System.Drawing.Point(223, 13);
            this.cmbfxff.Name = "cmbfxff";
            this.cmbfxff.Size = new System.Drawing.Size(192, 20);
            this.cmbfxff.TabIndex = 1;
            // 
            // txtbz
            // 
            this.txtbz.ForeColor = System.Drawing.Color.Navy;
            this.txtbz.Location = new System.Drawing.Point(750, 35);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(175, 21);
            this.txtbz.TabIndex = 2;
            this.txtbz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(710, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "备注";
            // 
            // lbldjh
            // 
            this.lbldjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldjh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldjh.Location = new System.Drawing.Point(750, 11);
            this.lbldjh.Name = "lbldjh";
            this.lbldjh.Size = new System.Drawing.Size(175, 20);
            this.lbldjh.TabIndex = 15;
            // 
            // lbldjhd
            // 
            this.lbldjhd.Location = new System.Drawing.Point(701, 16);
            this.lbldjhd.Name = "lbldjhd";
            this.lbldjhd.Size = new System.Drawing.Size(47, 16);
            this.lbldjhd.TabIndex = 14;
            this.lbldjhd.Text = "单据号";
            // 
            // dtprq
            // 
            this.dtprq.Location = new System.Drawing.Point(61, 36);
            this.dtprq.Name = "dtprq";
            this.dtprq.Size = new System.Drawing.Size(108, 21);
            this.dtprq.TabIndex = 1;
            this.dtprq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lbldjrq
            // 
            this.lbldjrq.Location = new System.Drawing.Point(9, 42);
            this.lbldjrq.Name = "lbldjrq";
            this.lbldjrq.Size = new System.Drawing.Size(56, 16);
            this.lbldjrq.TabIndex = 4;
            this.lbldjrq.Text = "采购日期";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(172, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "分析方法";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExportSCM);
            this.groupBox2.Controls.Add(this.btnImport);
            this.groupBox2.Controls.Add(this.lblpm);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.txtghdw);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtckjj);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.butmodif);
            this.groupBox2.Controls.Add(this.butdel);
            this.groupBox2.Controls.Add(this.butadd);
            this.groupBox2.Controls.Add(this.lblscjj);
            this.groupBox2.Controls.Add(this.label46);
            this.groupBox2.Controls.Add(this.lblkc);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.txtypsl);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.lbllsj);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.lblpfj);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.cmbdw);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.lblhh);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblypmc);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lblcj);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblgg);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtypdm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1014, 136);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnExportSCM
            // 
            this.btnExportSCM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExportSCM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnExportSCM.Location = new System.Drawing.Point(881, 69);
            this.btnExportSCM.Name = "btnExportSCM";
            this.btnExportSCM.Size = new System.Drawing.Size(121, 24);
            this.btnExportSCM.TabIndex = 102;
            this.btnExportSCM.Text = "导 出 SCM数据";
            this.btnExportSCM.Click += new System.EventHandler(this.btnExportSCM_Click);
            // 
            // btnImport
            // 
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnImport.Location = new System.Drawing.Point(777, 68);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(98, 24);
            this.btnImport.TabIndex = 101;
            this.btnImport.Text = "导 入SCM数据";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblpm
            // 
            this.lblpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpm.ForeColor = System.Drawing.Color.Navy;
            this.lblpm.Location = new System.Drawing.Point(211, 15);
            this.lblpm.Name = "lblpm";
            this.lblpm.Size = new System.Drawing.Size(125, 20);
            this.lblpm.TabIndex = 100;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.lblmrjj);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lblzbj);
            this.groupBox4.Controls.Add(this.label44);
            this.groupBox4.Controls.Add(this.lblzbqh);
            this.groupBox4.Controls.Add(this.label42);
            this.groupBox4.Controls.Add(this.lblzbdw);
            this.groupBox4.Controls.Add(this.label40);
            this.groupBox4.Controls.Add(this.lblzbzt);
            this.groupBox4.Controls.Add(this.label38);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox4.Location = new System.Drawing.Point(3, 93);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1008, 40);
            this.groupBox4.TabIndex = 60;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "招标信息";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(588, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 78;
            this.label5.Text = "默认进价";
            // 
            // lblmrjj
            // 
            this.lblmrjj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblmrjj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblmrjj.ForeColor = System.Drawing.Color.Navy;
            this.lblmrjj.Location = new System.Drawing.Point(505, 14);
            this.lblmrjj.Name = "lblmrjj";
            this.lblmrjj.Size = new System.Drawing.Size(71, 20);
            this.lblmrjj.TabIndex = 77;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(454, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 76;
            this.label6.Text = "默认进价";
            // 
            // lblzbj
            // 
            this.lblzbj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzbj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzbj.ForeColor = System.Drawing.Color.Navy;
            this.lblzbj.Location = new System.Drawing.Point(396, 14);
            this.lblzbj.Name = "lblzbj";
            this.lblzbj.Size = new System.Drawing.Size(55, 20);
            this.lblzbj.TabIndex = 75;
            // 
            // label44
            // 
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(356, 18);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(48, 16);
            this.label44.TabIndex = 74;
            this.label44.Text = "招标价";
            // 
            // lblzbqh
            // 
            this.lblzbqh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzbqh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzbqh.ForeColor = System.Drawing.Color.Navy;
            this.lblzbqh.Location = new System.Drawing.Point(277, 14);
            this.lblzbqh.Name = "lblzbqh";
            this.lblzbqh.Size = new System.Drawing.Size(75, 20);
            this.lblzbqh.TabIndex = 73;
            // 
            // label42
            // 
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(227, 18);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(56, 16);
            this.label42.TabIndex = 72;
            this.label42.Text = "招标期号";
            // 
            // lblzbdw
            // 
            this.lblzbdw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzbdw.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzbdw.ForeColor = System.Drawing.Color.Navy;
            this.lblzbdw.Location = new System.Drawing.Point(132, 14);
            this.lblzbdw.Name = "lblzbdw";
            this.lblzbdw.Size = new System.Drawing.Size(92, 20);
            this.lblzbdw.TabIndex = 71;
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(82, 18);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(56, 16);
            this.label40.TabIndex = 70;
            this.label40.Text = "招标单位";
            // 
            // lblzbzt
            // 
            this.lblzbzt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzbzt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzbzt.ForeColor = System.Drawing.Color.Red;
            this.lblzbzt.Location = new System.Drawing.Point(40, 14);
            this.lblzbzt.Name = "lblzbzt";
            this.lblzbzt.Size = new System.Drawing.Size(40, 20);
            this.lblzbzt.TabIndex = 69;
            // 
            // label38
            // 
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(13, 18);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(34, 16);
            this.label38.TabIndex = 68;
            this.label38.Text = "状态";
            // 
            // txtghdw
            // 
            this.txtghdw.ForeColor = System.Drawing.Color.Navy;
            this.txtghdw.Location = new System.Drawing.Point(339, 64);
            this.txtghdw.Name = "txtghdw";
            this.txtghdw.Size = new System.Drawing.Size(152, 21);
            this.txtghdw.TabIndex = 7;
            this.txtghdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtghdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(283, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 59;
            this.label3.Text = "进货单位";
            // 
            // txtckjj
            // 
            this.txtckjj.ForeColor = System.Drawing.Color.Navy;
            this.txtckjj.Location = new System.Drawing.Point(211, 64);
            this.txtckjj.Name = "txtckjj";
            this.txtckjj.Size = new System.Drawing.Size(64, 21);
            this.txtckjj.TabIndex = 6;
            this.txtckjj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtypsl_KeyUp);
            this.txtckjj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(155, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 57;
            this.label1.Text = "参考进价";
            // 
            // butmodif
            // 
            this.butmodif.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butmodif.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butmodif.Location = new System.Drawing.Point(707, 68);
            this.butmodif.Name = "butmodif";
            this.butmodif.Size = new System.Drawing.Size(64, 24);
            this.butmodif.TabIndex = 10;
            this.butmodif.Text = "修改(&M)";
            this.butmodif.Click += new System.EventHandler(this.butmodif_Click);
            // 
            // butdel
            // 
            this.butdel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butdel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butdel.Location = new System.Drawing.Point(635, 68);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(64, 24);
            this.butdel.TabIndex = 99;
            this.butdel.Text = "删除(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butadd
            // 
            this.butadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butadd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butadd.Location = new System.Drawing.Point(563, 68);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(64, 24);
            this.butadd.TabIndex = 8;
            this.butadd.Text = "添加(&A)";
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            // 
            // lblscjj
            // 
            this.lblscjj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblscjj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblscjj.ForeColor = System.Drawing.Color.Navy;
            this.lblscjj.Location = new System.Drawing.Point(568, 40);
            this.lblscjj.Name = "lblscjj";
            this.lblscjj.Size = new System.Drawing.Size(87, 20);
            this.lblscjj.TabIndex = 54;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(512, 40);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(56, 16);
            this.label46.TabIndex = 53;
            this.label46.Text = "上次进价";
            // 
            // lblkc
            // 
            this.lblkc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblkc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblkc.ForeColor = System.Drawing.Color.Navy;
            this.lblkc.Location = new System.Drawing.Point(709, 40);
            this.lblkc.Name = "lblkc";
            this.lblkc.Size = new System.Drawing.Size(88, 20);
            this.lblkc.TabIndex = 51;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(661, 40);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(48, 16);
            this.label36.TabIndex = 50;
            this.label36.Text = "库存量";
            // 
            // txtypsl
            // 
            this.txtypsl.ForeColor = System.Drawing.Color.Navy;
            this.txtypsl.Location = new System.Drawing.Point(64, 39);
            this.txtypsl.Name = "txtypsl";
            this.txtypsl.Size = new System.Drawing.Size(80, 21);
            this.txtypsl.TabIndex = 4;
            this.txtypsl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtypsl_KeyUp);
            this.txtypsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(21, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 16);
            this.label26.TabIndex = 32;
            this.label26.Text = "计划数";
            // 
            // lbllsj
            // 
            this.lbllsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsj.ForeColor = System.Drawing.Color.Navy;
            this.lbllsj.Location = new System.Drawing.Point(373, 40);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(104, 20);
            this.lbllsj.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(328, 41);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 16);
            this.label23.TabIndex = 28;
            this.label23.Text = "零售价";
            // 
            // lblpfj
            // 
            this.lblpfj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpfj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfj.ForeColor = System.Drawing.Color.Navy;
            this.lblpfj.Location = new System.Drawing.Point(211, 40);
            this.lblpfj.Name = "lblpfj";
            this.lblpfj.Size = new System.Drawing.Size(104, 20);
            this.lblpfj.TabIndex = 27;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(168, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 16);
            this.label20.TabIndex = 26;
            this.label20.Text = "批发价";
            // 
            // cmbdw
            // 
            this.cmbdw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdw.ForeColor = System.Drawing.Color.Navy;
            this.cmbdw.Location = new System.Drawing.Point(64, 64);
            this.cmbdw.Name = "cmbdw";
            this.cmbdw.Size = new System.Drawing.Size(80, 20);
            this.cmbdw.TabIndex = 55;
            this.cmbdw.SelectedIndexChanged += new System.EventHandler(this.cmbdw_SelectedIndexChanged);
            this.cmbdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(32, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 16);
            this.label19.TabIndex = 24;
            this.label19.Text = "单位";
            // 
            // lblhh
            // 
            this.lblhh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblhh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblhh.ForeColor = System.Drawing.Color.Navy;
            this.lblhh.Location = new System.Drawing.Point(709, 15);
            this.lblhh.Name = "lblhh";
            this.lblhh.Size = new System.Drawing.Size(88, 20);
            this.lblhh.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(677, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 16);
            this.label18.TabIndex = 22;
            this.label18.Text = "货号";
            // 
            // lblypmc
            // 
            this.lblypmc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblypmc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblypmc.ForeColor = System.Drawing.Color.Navy;
            this.lblypmc.Location = new System.Drawing.Point(336, 15);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(104, 20);
            this.lblypmc.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(143, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 16);
            this.label16.TabIndex = 20;
            this.label16.Text = "品名/商品名";
            // 
            // lblcj
            // 
            this.lblcj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcj.ForeColor = System.Drawing.Color.Navy;
            this.lblcj.Location = new System.Drawing.Point(590, 15);
            this.lblcj.Name = "lblcj";
            this.lblcj.Size = new System.Drawing.Size(87, 20);
            this.lblcj.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(560, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 16);
            this.label14.TabIndex = 18;
            this.label14.Text = "厂家";
            // 
            // lblgg
            // 
            this.lblgg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblgg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgg.ForeColor = System.Drawing.Color.Navy;
            this.lblgg.Location = new System.Drawing.Point(475, 15);
            this.lblgg.Name = "lblgg";
            this.lblgg.Size = new System.Drawing.Size(84, 20);
            this.lblgg.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(443, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 16);
            this.label12.TabIndex = 16;
            this.label12.Text = "规格";
            // 
            // txtypdm
            // 
            this.txtypdm.ForeColor = System.Drawing.Color.Navy;
            this.txtypdm.Location = new System.Drawing.Point(64, 15);
            this.txtypdm.Name = "txtypdm";
            this.txtypdm.Size = new System.Drawing.Size(80, 21);
            this.txtypdm.TabIndex = 3;
            this.txtypdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtypdm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "药品代码";
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.ForeColor = System.Drawing.Color.Navy;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(1008, 203);
            this.myDataGrid1.TabIndex = 60;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.myKeyDown += new myDataGrid.myDelegate(this.myDataGrid1_myKeyDown);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.商品名,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn46,
            this.dataGridTextBoxColumn49,
            this.dataGridTextBoxColumn44,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn47,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn43,
            this.dataGridTextBoxColumn41,
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn42,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn45,
            this.dataGridTextBoxColumn48,
            this.dataGridTextBoxColumn50,
            this.dataGridTextBoxColumn51});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "品名";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 130;
            // 
            // 商品名
            // 
            this.商品名.Format = "";
            this.商品名.FormatInfo = null;
            this.商品名.HeaderText = "商品名";
            this.商品名.Width = 130;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "规格";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 80;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "厂家";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 80;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "批发价";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 60;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "零售价";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 60;
            // 
            // dataGridTextBoxColumn46
            // 
            this.dataGridTextBoxColumn46.Format = "";
            this.dataGridTextBoxColumn46.FormatInfo = null;
            this.dataGridTextBoxColumn46.HeaderText = "全院库存";
            this.dataGridTextBoxColumn46.NullText = "";
            this.dataGridTextBoxColumn46.ReadOnly = true;
            this.dataGridTextBoxColumn46.Width = 70;
            // 
            // dataGridTextBoxColumn49
            // 
            this.dataGridTextBoxColumn49.Format = "";
            this.dataGridTextBoxColumn49.FormatInfo = null;
            this.dataGridTextBoxColumn49.HeaderText = "本院库存";
            this.dataGridTextBoxColumn49.NullText = "";
            this.dataGridTextBoxColumn49.Width = 70;
            // 
            // dataGridTextBoxColumn44
            // 
            this.dataGridTextBoxColumn44.Format = "";
            this.dataGridTextBoxColumn44.FormatInfo = null;
            this.dataGridTextBoxColumn44.HeaderText = "库存数";
            this.dataGridTextBoxColumn44.NullText = "";
            this.dataGridTextBoxColumn44.ReadOnly = true;
            this.dataGridTextBoxColumn44.Width = 60;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "需求数";
            this.dataGridTextBoxColumn10.ReadOnly = true;
            this.dataGridTextBoxColumn10.Width = 55;
            // 
            // dataGridTextBoxColumn47
            // 
            this.dataGridTextBoxColumn47.Format = "";
            this.dataGridTextBoxColumn47.FormatInfo = null;
            this.dataGridTextBoxColumn47.HeaderText = "上月用量";
            this.dataGridTextBoxColumn47.NullText = "";
            this.dataGridTextBoxColumn47.ReadOnly = true;
            this.dataGridTextBoxColumn47.Width = 60;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "计划数";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 55;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "单位";
            this.dataGridTextBoxColumn12.ReadOnly = true;
            this.dataGridTextBoxColumn12.Width = 30;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "参考进价";
            this.dataGridTextBoxColumn13.Width = 60;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "进货单位";
            this.dataGridTextBoxColumn14.NullText = "70";
            this.dataGridTextBoxColumn14.ReadOnly = true;
            this.dataGridTextBoxColumn14.Width = 110;
            // 
            // dataGridTextBoxColumn43
            // 
            this.dataGridTextBoxColumn43.Format = "";
            this.dataGridTextBoxColumn43.FormatInfo = null;
            this.dataGridTextBoxColumn43.HeaderText = "默认进价";
            this.dataGridTextBoxColumn43.NullText = "";
            this.dataGridTextBoxColumn43.ReadOnly = true;
            this.dataGridTextBoxColumn43.Width = 70;
            // 
            // dataGridTextBoxColumn41
            // 
            this.dataGridTextBoxColumn41.Format = "";
            this.dataGridTextBoxColumn41.FormatInfo = null;
            this.dataGridTextBoxColumn41.HeaderText = "进货单位id";
            this.dataGridTextBoxColumn41.ReadOnly = true;
            this.dataGridTextBoxColumn41.Width = 0;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "货号";
            this.dataGridTextBoxColumn22.ReadOnly = true;
            this.dataGridTextBoxColumn22.Width = 60;
            // 
            // dataGridTextBoxColumn42
            // 
            this.dataGridTextBoxColumn42.Format = "";
            this.dataGridTextBoxColumn42.FormatInfo = null;
            this.dataGridTextBoxColumn42.HeaderText = "ydwbl";
            this.dataGridTextBoxColumn42.ReadOnly = true;
            this.dataGridTextBoxColumn42.Width = 0;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "CJID";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.ReadOnly = true;
            this.dataGridTextBoxColumn15.Width = 70;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "id";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.ReadOnly = true;
            this.dataGridTextBoxColumn16.Width = 0;
            // 
            // dataGridTextBoxColumn45
            // 
            this.dataGridTextBoxColumn45.Format = "";
            this.dataGridTextBoxColumn45.FormatInfo = null;
            this.dataGridTextBoxColumn45.HeaderText = "药理分类";
            this.dataGridTextBoxColumn45.NullText = "";
            this.dataGridTextBoxColumn45.ReadOnly = true;
            this.dataGridTextBoxColumn45.Width = 75;
            // 
            // dataGridTextBoxColumn48
            // 
            this.dataGridTextBoxColumn48.Format = "";
            this.dataGridTextBoxColumn48.FormatInfo = null;
            this.dataGridTextBoxColumn48.HeaderText = "基本药物";
            this.dataGridTextBoxColumn48.NullText = "";
            this.dataGridTextBoxColumn48.ReadOnly = true;
            this.dataGridTextBoxColumn48.Width = 60;
            // 
            // dataGridTextBoxColumn50
            // 
            this.dataGridTextBoxColumn50.Format = "";
            this.dataGridTextBoxColumn50.FormatInfo = null;
            this.dataGridTextBoxColumn50.HeaderText = "货位名称";
            this.dataGridTextBoxColumn50.NullText = "";
            this.dataGridTextBoxColumn50.Width = 75;
            // 
            // dataGridTextBoxColumn51
            // 
            this.dataGridTextBoxColumn51.Format = "";
            this.dataGridTextBoxColumn51.FormatInfo = null;
            this.dataGridTextBoxColumn51.HeaderText = "拼音码";
            this.dataGridTextBoxColumn51.NullText = "";
            this.dataGridTextBoxColumn51.Width = 75;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 583);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1014, 24);
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 150;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 150;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Width = 400;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 203);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1014, 5);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 471);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 112);
            this.panel2.TabIndex = 6;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.Size = new System.Drawing.Size(1014, 112);
            this.myDataGrid2.TabIndex = 0;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn24,
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn30,
            this.dataGridTextBoxColumn31,
            this.dataGridTextBoxColumn32,
            this.dataGridTextBoxColumn33,
            this.dataGridTextBoxColumn34,
            this.dataGridTextBoxColumn35,
            this.dataGridTextBoxColumn36,
            this.dataGridTextBoxColumn37,
            this.dataGridTextBoxColumn38,
            this.dataGridTextBoxColumn39,
            this.dataGridTextBoxColumn40});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "序号";
            this.dataGridTextBoxColumn5.Width = 30;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "品名";
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "规格";
            this.dataGridTextBoxColumn7.Width = 70;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "厂家";
            this.dataGridTextBoxColumn17.Width = 70;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "库位";
            this.dataGridTextBoxColumn18.Width = 0;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "批号";
            this.dataGridTextBoxColumn19.Width = 60;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "效期";
            this.dataGridTextBoxColumn20.Width = 75;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "扣率";
            this.dataGridTextBoxColumn21.Width = 50;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "进价";
            this.dataGridTextBoxColumn23.Width = 60;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "批发价";
            this.dataGridTextBoxColumn24.Width = 60;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "零售价";
            this.dataGridTextBoxColumn25.Width = 60;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "数量";
            this.dataGridTextBoxColumn26.Width = 60;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "单位";
            this.dataGridTextBoxColumn27.Width = 30;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "进货金额";
            this.dataGridTextBoxColumn28.Width = 70;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "批发金额";
            this.dataGridTextBoxColumn29.Width = 70;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Format = "";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.HeaderText = "零售金额";
            this.dataGridTextBoxColumn30.Width = 70;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.HeaderText = "进零差额";
            this.dataGridTextBoxColumn31.Width = 70;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Format = "";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.HeaderText = "供货单位";
            this.dataGridTextBoxColumn32.Width = 75;
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Format = "";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.HeaderText = "业务员";
            this.dataGridTextBoxColumn33.Width = 50;
            // 
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Format = "";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.HeaderText = "送货单号";
            this.dataGridTextBoxColumn34.Width = 60;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.HeaderText = "发票号";
            this.dataGridTextBoxColumn35.Width = 60;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "发票日期";
            this.dataGridTextBoxColumn36.Width = 65;
            // 
            // dataGridTextBoxColumn37
            // 
            this.dataGridTextBoxColumn37.Format = "";
            this.dataGridTextBoxColumn37.FormatInfo = null;
            this.dataGridTextBoxColumn37.HeaderText = "单据号";
            this.dataGridTextBoxColumn37.Width = 60;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Format = "";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.HeaderText = "单据日期";
            this.dataGridTextBoxColumn38.Width = 65;
            // 
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.HeaderText = "登记时间";
            this.dataGridTextBoxColumn39.Width = 75;
            // 
            // dataGridTextBoxColumn40
            // 
            this.dataGridTextBoxColumn40.Format = "";
            this.dataGridTextBoxColumn40.FormatInfo = null;
            this.dataGridTextBoxColumn40.HeaderText = "登记员";
            this.dataGridTextBoxColumn40.Width = 60;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(8, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 21);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "隐藏历史入库批次";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // butsh
            // 
            this.butsh.Location = new System.Drawing.Point(411, 0);
            this.butsh.Name = "butsh";
            this.butsh.Size = new System.Drawing.Size(80, 24);
            this.butsh.TabIndex = 18;
            this.butsh.Text = "审核(&S)";
            this.butsh.Click += new System.EventHandler(this.butsh_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(734, 0);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 17;
            this.butclose.Text = "关闭(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butprint
            // 
            this.butprint.Enabled = false;
            this.butprint.Location = new System.Drawing.Point(569, 0);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(83, 24);
            this.butprint.TabIndex = 16;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(491, 0);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(77, 24);
            this.butsave.TabIndex = 15;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 463);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1014, 8);
            this.splitter2.TabIndex = 10;
            this.splitter2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butexcel);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.butsh);
            this.panel1.Controls.Add(this.butclose);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 32);
            this.panel1.TabIndex = 11;
            // 
            // butexcel
            // 
            this.butexcel.Enabled = false;
            this.butexcel.Location = new System.Drawing.Point(655, 0);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(75, 24);
            this.butexcel.TabIndex = 22;
            this.butexcel.Text = "导出(&E)";
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(132, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(304, 24);
            this.checkBox2.TabIndex = 21;
            this.checkBox2.Text = "以当前进价和进货单位更新上次进价和进货单位";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.myDataGrid1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 208);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1014, 223);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // FrmCGMX
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1014, 607);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCGMX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "药品采购计划";
            this.Load += new System.EventHandler(this.Frmypck_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        private void Frmypck_Load(object sender, System.EventArgs e)
        {
            this.dtprq.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            //初始化
            FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");

            //初始化
            FunBase.CsDataGrid(this.myDataGrid2, this.myDataGrid2.TableStyles[0], "Tb1");

            Yp.AddcmbCk(false, InstanceForm.BCurrentDept.DeptId, cmbck, InstanceForm.BDatabase);
            Yp.AddcmbYjks(cmbckkc, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
            cmbckkc.SelectedValue = InstanceForm.BCurrentDept.DeptId;

            this.cmbfxff.SelectedIndex = 0;


            this.checkBox1.Checked = true;

            if (Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) == Guid.Empty.ToString())
                butsh.Enabled = false;
            butexcel.Enabled = true;


            SystemCfg cfg8056 = new SystemCfg(8056);//调进货价
            if (cfg8056.Config == "1")
            {
                btjhj = true;
            }

            //绑定送货地址
            DbComboSHDZ();
            txtbz.ReadOnly = true;
        }

        private void DbComboSHDZ()
        {

            string ssql = "select TypeValue,memo from jc_config_SHDZ order by ID ";
            System.Data.DataTable tb = null;

            try
            {
               tb = InstanceForm.BDatabase.GetDataTable(ssql);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

            comSFDZ.DataSource = tb;
            comSFDZ.ValueMember = "TypeValue";
            comSFDZ.DisplayMember = "memo";

        }

        #region 界面控制事件
        // 回车跳至下一个文本
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                this.SelectNextControl(control, true, false, true, true);
            }
        }


        private void csgroupbox1()
        {
            for (int i = 0; i <= this.groupBox1.Controls.Count - 1; i++)
            {
                if (this.groupBox1.Controls[i].GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    this.groupBox1.Controls[i].Text = "";
                    this.groupBox1.Controls[i].Tag = "0";
                }
            }
            this.lbldjh.Text = "";
            this.groupBox1.Tag = null;
            this.dtprq.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
        }


        private void csgroupbox2()
        {
            for (int i = 0; i <= this.groupBox2.Controls.Count - 1; i++)
            {
                if (this.groupBox2.Controls[i].GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    this.groupBox2.Controls[i].Text = "";
                    this.groupBox2.Controls[i].Tag = "0";
                }
            }
            this.lblypmc.Text = "";
            this.lblypmc.Tag = "0";
            this.lblpm.Text = "";
            this.lblgg.Text = "";
            this.lblcj.Text = "";
            this.lblhh.Text = "";
            this.lblpfj.Text = "";
            this.lbllsj.Text = "";
            this.lblpfj.Tag = "";
            this.lbllsj.Tag = "";
            this.lblkc.Text = "";
            this.lblscjj.Text = "";
            this.txtckjj.Text = "";
            this.txtghdw.Text = "";
            this.txtghdw.Tag = "0";
            this.cmbdw.DataSource = null;
            this.txtypdm.Focus();
        }


        //输入框控制事件
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            { control.Text = ""; control.Tag = "0"; }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
            { }
            else { return; }

            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            DataRow row;

            try
            {
                System.Drawing.Point point = new System.Drawing.Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 7:
                        if (control.Text.Trim() == "") return;
                        GrdMappingName = new string[] { "id", "行号", "供货商", "拼音码", "五笔码" };
                        GrdWidth = new int[] { 0, 50, 200, 100, 100 };
                        sfield = new string[] { "wbm", "pym", "", "", "" };
                        ssql = "select ID,0 rowno,ghdwmc,pym,wbm from yp_ghdw WHERE ID<>0 ";
                        TrasenFrame.Forms.Fshowcard f1 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                        f1.Location = point;
                        f1.ShowDialog(this);
                        row = f1.dataRow;
                        if (row != null)
                        {
                            control.Text = row["ghdwmc"].ToString();
                            control.Tag = row["id"].ToString();
                            this.SelectNextControl((Control)sender, true, false, true, true);
                        }
                        break;
                    case 3:
                        if (control.Text.Trim() == "") return;
                        GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                        GrdWidth = new int[] { 0, 0, 50, 150, 100, 100, 40, 0, 60, 60, 70 };
                        sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                        //ssql="select a.ggid,cjid,0 rowno,ypspm,ypgg,dbo.fun_yp_sccj(sccj) sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_yp_ypcd a,yp_ypbm b "+
                        //" where a.ggid=b.ggid and a.bdelete=0 and a.ypzlx in(select ypzlx from yp_gllx where deptid="+Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"))+")  ";
                        ssql = "select distinct a.ggid,cjid,0 rowno,s_ypspm,s_ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from yp_ypcjd a,yp_ypbm b " +
                            " where a.ggid=b.ggid and a.bdelete=0 and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + ")  ";
                        TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, Constant.CustomFilterType, control.Text.Trim(), ssql);
                        f2.Location = point;
                        f2.Width = 700;
                        f2.Height = 300;
                        f2.ShowDialog(this);
                        row = f2.dataRow;
                        if (row != null)
                        {
                            this.csyp(Convert.ToInt32(row["ggid"]), Convert.ToInt32(row["cjid"]));
                            FindRecord(Convert.ToInt32(row["cjid"]), 0);
                            this.SelectNextControl((Control)sender, true, false, true, true);

                        }
                        break;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        private void FindRecord(int cjid, int nrow)
        {
            int beginrow = nrow;
            System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
            for (int i = beginrow; i <= tb.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(tb.Rows[i]["cjid"]) == cjid)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    for (int j = 0; j <= tb.Rows.Count - 1; j++)
                    {
                        this.myDataGrid1.UnSelect(j);
                    }

                    this.myDataGrid1.Select(i);
                    //					beginrow=i+1;
                    //					if (beginrow!=tb.Rows.Count) 
                    //					{
                    //						this.butnext.Visible=true;
                    //						this.butnext.Tag=beginrow.ToString(); 
                    //					}
                    //					else
                    //					{
                    //						this.butnext.Visible=false;
                    //						this.butnext.Tag="0";
                    //					}
                    //					return;
                    //
                }
                //				
                //				if (beginrow>=tb.Rows.Count-1)
                //				{
                //					this.butnext.Visible=false;
                //				}

            }
        }


        //数量输入事件
        private void txtypsl_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Convertor.IsNumeric(txtypsl.Text) == false) txtypsl.Text = "";
            if (Convertor.IsNumeric(txtckjj.Text) == false) txtckjj.Text = "";
            //if(txtypsl.Text.Trim()!="-" && txtypsl.Text.Trim()!=".") txtypsl.Text="";
            //if(txtckjj.Text.Trim()!="-" && txtckjj.Text.Trim()!=".") txtckjj.Text="";
        }


        //网格单元改变事件
        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            try
            {
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
                if (nrow >= tb.Rows.Count)
                {
                    DataRow nullrow = tb.NewRow();
                    this.Getrow(nullrow);
                }
                else
                {
                    DataRow row = tb.Rows[nrow];
                    Getrow(row);
                    this.Select_Rkmx(Convert.ToInt32(Convertor.IsNull(row["cjid"], "0")));
                    this.butadd.Enabled = false;
                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }


        //单位改变事件
        private void cmbdw_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (cmbdw.SelectedIndex <= -1) return;
                if (cmbdw.SelectedValue.GetType().ToString() != "System.Int32") return;
                int dwbl = Convert.ToInt32(cmbdw.SelectedValue);
                this.lblkc.Text = Yp.SeekKcZh(dwbl, Convert.ToInt32(this.lblypmc.Tag), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");

                decimal ypsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                decimal pfj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Tag, "0")) / dwbl;
                pfj = Convert.ToDecimal(pfj.ToString("0.0000"));
                this.lblpfj.Text = pfj.ToString("0.0000");
                decimal lsj = Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag, "0")) / dwbl;
                lsj = Convert.ToDecimal(lsj.ToString("0.0000"));
                this.lbllsj.Text = lsj.ToString("0.0000");
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }



        #endregion

        #region 填充数据的过程
        //初始药品
        private void csyp(int ggid, int cjid)
        {
            try
            {
                this.csgroupbox2();
                //Ydgg ydgg=new  Ydgg(ggid);
                Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
                this.lblypmc.Tag = ydcj.CJID.ToString();
                this.lblypmc.Text = ydcj.S_YPSPM;
                this.lblpm.Text = ydcj.S_YPPM;
                this.lblgg.Text = ydcj.S_YPGG;
                this.lblcj.Text = ydcj.S_SCCJ;
                this.lblhh.Text = ydcj.SHH;
                this.lblpfj.Text = ydcj.PFJ.ToString();
                this.lbllsj.Text = ydcj.LSJ.ToString();
                this.lblpfj.Tag = ydcj.PFJ.ToString();
                this.lbllsj.Tag = ydcj.LSJ.ToString();
                //this.lblzbzt.Text=BaseFun.Seekzbzt(ydcj.ZBZT);
                this.lblzbdw.Text = ydcj.ZBDW;
                this.lblzbqh.Text = ydcj.ZBQH;
                this.lblzbj.Text = ydcj.ZBJ.ToString("0.00");
                this.lblmrjj.Text = ydcj.MRJJ.ToString("0.00");

               // this.lblscjj.Text = Yp.SeekScjhj(ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString();
                this.lblscjj.Text = ydcj.PFJ.ToString();//药库要求：调价后药品参考进价为零售价 2016-11-23 Add BY HYD

                if (new SystemCfg(8039).Config == "1")
                {
                    this.txtghdw.Tag = Yp.SeekScghdw(ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString();
                    txtghdw.Text = Yp.SeekGhdw(Convert.ToInt32(txtghdw.Tag), InstanceForm.BDatabase);
                }
                else
                {
                    string ssql = "select mrghdw from yp_ypcjd where cjid=" + cjid + "";
                    System.Data.DataTable tbcj = InstanceForm.BDatabase.GetDataTable(ssql);
                    if (tbcj.Rows.Count > 0)
                    {
                        this.txtghdw.Tag = tbcj.Rows[0]["mrghdw"].ToString();
                        txtghdw.Text = Yp.SeekGhdw(Convert.ToInt32(tbcj.Rows[0]["mrghdw"].ToString()), InstanceForm.BDatabase);
                    }
                }
                this.txtckjj.Text = lblscjj.Text;

                cmbdw.DataSource = null;
                Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
                this.cmbdw.SelectedIndex = 0;
                this.lblkc.Text = Yp.SeekKcZh(Convert.ToInt32(this.cmbdw.SelectedValue), ydcj.CJID, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase).ToString("0.000");

                Select_Rkmx(ydcj.CJID);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        //填充行
        private void Fillrow(System.Data.DataRow row)
        {
            if (Convert.ToInt32(this.lblypmc.Tag) == 0)
            {
                MessageBox.Show("没有可添加的药品");
                txtypdm.Focus();
                return;
            }

            //			if (Convertor.IsNull(this.txtypsl.Text,"0")=="0")
            //			{
            //				MessageBox.Show("请输入计划数量");
            //				txtypsl.Focus();
            //				return;
            //			}

            System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
            row["序号"] = tb.Rows.Count + 1;
            row["商品名"] = this.lblypmc.Text.Trim();
            row["品名"] = this.lblpm.Text.Trim();
            row["规格"] = this.lblgg.Text.Trim();
            row["厂家"] = this.lblcj.Text.Trim();
            row["批发价"] = this.lblpfj.Text.Trim();
            row["零售价"] = this.lbllsj.Text.Trim();
            row["计划数"] = this.txtypsl.Text.Trim();
            row["单位"] = this.cmbdw.Text.Trim();
            row["参考进价"] = Convertor.IsNull(this.txtckjj.Text.Trim(), "0");
            row["进货单位"] = this.txtghdw.Text.Trim();
            row["默认进价"] = this.lblmrjj.Text.Trim();
            row["进货单位id"] = Convertor.IsNull(this.txtghdw.Tag, "0");
            row["ydwbl"] = Convertor.IsNull(cmbdw.SelectedValue, "0");
            row["货号"] = this.lblhh.Text.Trim();
            row["CJID"] = Convertor.IsNull(this.lblypmc.Tag.ToString(), "0");

            System.Data.DataTable tb2 = (System.Data.DataTable)this.myDataGrid2.DataSource;
            tb2.Rows.Clear();
        }

        //求和金额
        private void Sumje()
        {
            //			decimal sumpfje=0;
            //			decimal sumlsje=0;
            //			decimal sumplce=0;
            //			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
            //			for( int i=0;i<=tb.Rows.Count-1;i++)
            //			{
            //				sumpfje=sumpfje+Convert.ToDecimal(tb.Rows[i]["批发金额"]);
            //				sumlsje=sumlsje+Convert.ToDecimal(tb.Rows[i]["零售金额"]);
            //			}
            //			sumplce=sumlsje-sumpfje;
            //			this.statusBar1.Panels[0].Text ="批发金额: "+sumpfje.ToString("0.00");
            //			this.statusBar1.Panels[1].Text ="零售金额: "+sumlsje.ToString("0.00");
        }

        //获取一行
        private void Getrow(DataRow row)
        {
            int cjid = Convert.ToInt32(Convertor.IsNull(row["cjid"], "0"));
            Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
            this.lblpm.Text = row["品名"].ToString();
            this.lblypmc.Text = row["商品名"].ToString();
            this.lblypmc.Tag = row["CJID"].ToString();
            this.lblgg.Text = row["规格"].ToString();
            this.lblcj.Text = row["厂家"].ToString();
            this.lblpfj.Text = row["批发价"].ToString();
            this.lblpfj.Tag = ydcj.PFJ.ToString();
            this.lbllsj.Text = row["零售价"].ToString();
            this.lbllsj.Tag = ydcj.LSJ.ToString();
            this.txtckjj.Text = row["参考进价"].ToString();
            this.txtghdw.Text = row["进货单位"].ToString();
            this.lblmrjj.Text = row["默认进价"].ToString();
            this.txtghdw.Tag = row["进货单位id"].ToString();
            this.txtypsl.Text = row["计划数"].ToString();
            Yp.AddCmbDW(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
            this.cmbdw.Text = row["单位"].ToString();
            this.lblhh.Text = row["货号"].ToString();
            //this.lblzbzt.Text=BaseFun.Seekzbzt(ydcj.ZBZT);
            this.lblzbdw.Text = ydcj.ZBDW;
            this.lblzbqh.Text = ydcj.ZBQH;
            this.lblzbj.Text = ydcj.ZBJ.ToString("0.00");
            this.Select_Rkmx(ydcj.CJID);

        }

        //重新排序行号
        private void SortRowNO()
        {
            System.Data.DataTable tb1 = (System.Data.DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= tb1.Rows.Count - 1; i++)
            {
                tb1.Rows[i]["序号"] = i + 1;
            }
        }

        //填充单据
        public void FillDj(Guid id, bool shbz)
        {
            try
            {
                string ssql = "select * from yf_CG where id='" + id + "'";
                System.Data.DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                this.groupBox1.Tag = tb.Rows[0]["id"].ToString();

                this.cmbpx.SelectedIndex = Convert.ToInt32(tb.Rows[0]["pxfs"]);

                this.txtbz.Text = tb.Rows[0]["bz"].ToString();
                this.dtprq.Value = Convert.ToDateTime(tb.Rows[0]["JHCGRQ"]);
                long djh = Convert.ToInt64(tb.Rows[0]["djh"]);
                this.lbldjh.Text = djh.ToString("00000000");

                cmbck.SelectedValue = tb.Rows[0]["deptid"].ToString();
                cmbck.Enabled = false;

                Department dept = new Department(Convert.ToInt32(tb.Rows[0]["deptid"].ToString()), InstanceForm.BDatabase);


                ssql = "select 0 序号,s_yppm 品名,s_ypspm 商品名,s_ypgg 规格,s_sccj 厂家," +
                    " pfj 批发价,lsj 零售价,zkc 全院库存,fykc 本院库存,cast(round(kcl/dwbl,2) as float) 库存数,cast(XQS as float) 需求数,cast(syyl as float) 上月用量,cast(jhs  as float) 计划数,a.ypdw 单位," +
                    " cast(ckjj as float) 参考进价,dbo.fun_yp_ghdw(wldw) 进货单位,cast(mrjj as float) 默认进价,wldw 进货单位id,b.shh 货号," +
                    " a.ydwbl,a.cjid,a.id,dbo.fun_yp_ylfl(ylfl) 药理分类,(case when gjjbyw=1 then '√' else '' end) 基本药物,hwmc 货位名称,'' as 拼音码 from yf_cgmx a inner join vi_yp_ypcd b on a.cjid=b.cjid " +
                    " left join " + Yp.Seek_kcmx_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) + " c  " +
                    " on b.cjid=c.cjid and c.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) +
                    " left join (select cjid,cast(round(sum(kcl/dwbl),2) as float) zkc,cast(round(sum(case when " + dept.Jgbm + "= b.jgbm then kcl/dwbl else 0 end),2) as float) fykc from vi_yp_kcmx a,jc_dept_property b where a.deptid=b.dept_id group by cjid) d on a.cjid=d.cjid " +
                    " left join YP_HWSZ e on b.ggid=e.ggid and e.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) +
                    "  where  djid='" + id + "' ";

                string order = "";
                //if (cmbpx.SelectedIndex == 0 || cmbpx.SelectedIndex == -1)
                //    order = order + " order by b.yplx,wldw";
                //if (cmbpx.SelectedIndex == 1)
                //    order = order + " order by b.yplx,b.tlfl,ypjx";
                //if (cmbpx.SelectedIndex == 2)
                //    order = order + " order by b.yplx,ylfl,ypjx";



                if (Convert.ToInt32(tb.Rows[0]["pxfs"]) == 0 || Convert.ToInt32(tb.Rows[0]["pxfs"]) == -1)
                    order = order + " order by b.yplx,WLDW,B.GGID,B.CJID";
                if (Convert.ToInt32(tb.Rows[0]["pxfs"]) == 1)
                    order = order + " order by b.yplx,B.tlfl,ypjx,B.GGID,B.CJID";
                if (Convert.ToInt32(tb.Rows[0]["pxfs"]) == 2)
                    order = order + " order by b.yplx,ylfl,ypjx,B.GGID,B.CJID";
                if (Convert.ToInt32(tb.Rows[0]["pxfs"]) == 3)
                    order = order + " order by b.yplx,b.yppm,B.GGID,B.CJID";
                if (Convert.ToInt32(tb.Rows[0]["pxfs"]) == 4)
                    order = order + " order by b.yppm,B.GGID,B.CJID ";


                ssql = ssql + order;


                System.Data.DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                FunBase.AddRowtNo(tbmx);
                tbmx.TableName = "tbmx";
                this.myDataGrid1.DataSource = tbmx;
                this.myDataGrid1.TableStyles[0].MappingName = "tbmx";

                //if (Convert.ToInt32(tb.Rows[0]["shbz"])==0) return;

                this.butsave.Enabled = false;
                this.butadd.Enabled = false;
                this.butdel.Enabled = false;
                this.butmodif.Enabled = false;
                this.butref.Enabled = false;
                this.butprint.Enabled = false;
                if (Convert.ToInt32(tb.Rows[0]["shbz"]) == 1)
                {
                    this.butprint.Enabled = true;
                    this.butsh.Enabled = false;
                }
                else
                {
                    this.butadd.Enabled = true;
                    this.butdel.Enabled = true;
                    this.butmodif.Enabled = true;
                    this.butprint.Enabled = false;
                    this.butsh.Enabled = true;
                    this.butsave.Enabled = true;
                }

                this.Sumje();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        //查找最近入库的历史记录
        private void Select_Rkmx(int cjid)
        {
            System.Data.DataTable tb;
            tb = YF_CG_CGMX.Select_rkmx(cjid, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
            tb.TableName = "Tb1";
            this.myDataGrid2.DataSource = tb;
        }


        #endregion

        #region 按钮事件
        //添加一行
        private void butadd_Click(object sender, System.EventArgs e)
        {
            try
            {

                System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
                DataRow row = tb.NewRow();
                this.Fillrow(row);
                if (YpClass.FunBase.IsExistsInGrid(new object[] { row["cjid"] }, tb, new string[] { "cjid" }))
                {
                    MessageBox.Show("添加的药品已经存在，不能重复添加", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (row["品名"].ToString().Trim() != "")
                {
                    tb.Rows.Add(row);
                    this.Sumje();
                    this.myDataGrid1.Select(tb.Rows.Count - 1);
                    this.myDataGrid1.CurrentCell = new DataGridCell(tb.Rows.Count - 1, 3);
                    this.csgroupbox2();
                    this.butadd.Enabled = true;
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //新单据
        private void butnew_Click(object sender, System.EventArgs e)
        {
            this.csgroupbox1();
            this.csgroupbox2();
            System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
            this.statusBar1.Panels[0].Text = "";
            this.statusBar1.Panels[1].Text = "";
            this.statusBar1.Panels[2].Text = "";
            this.butadd.Enabled = true;
            this.butdel.Enabled = true;
            this.butmodif.Enabled = true;
            this.butsave.Enabled = true;
            this.dtprq.Focus();
        }

        //保存事件
        private void butsave_Click(object sender, System.EventArgs e)
        {
            long djh = 0;
            int err_code = 0;
            string err_text = "";
            Guid djid = Guid.Empty;
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

            System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
            if (tb.Rows.Count == 0) { MessageBox.Show("没有可保存的记录"); return; }

            DataRow[] row = tb.Select("品名<>''");
            if (row.Length == 0) { MessageBox.Show("没有可保存的记录"); return; }

            this.butsave.Enabled = false;

            if (new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())) == Guid.Empty)
               // txtbz.Text = " [" + cmbfxff.Text.Trim() + "] 以" + cmbckkc.Text.Trim() + "为参考库存 " + txtbz.Text.Trim();
            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                //产生单据号
                djh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) : Convert.ToInt64(this.lbldjh.Text);

                //保存单据表头
                YF_CG_CGMX.SaveDJ(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())),
                    dtprq.Value.ToShortDateString(),
                    sDate.Trim(),
                    InstanceForm.BCurrentUser.EmployeeId,
                    txtbz.Text.Trim(),
                    Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), +
                    djh,
                    out djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, Convert.ToInt32(cmbpx.SelectedIndex), InstanceForm.BDatabase);

                if (err_code != 0) { throw new System.Exception(err_text); }

                //保存单据明细

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["cjid"], "0")) > 0)
                    {
                        YF_CG_CGMX.SaveDJMX(new Guid(Convertor.IsNull(tb.Rows[i]["id"], Guid.Empty.ToString())),
                            djid,
                            Convert.ToInt32(tb.Rows[i]["cjid"]),
                            Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["需求数"], "0")),
                             Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["上月用量"], "0")),
                            Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["计划数"], "0")),
                            Convert.ToString(tb.Rows[i]["单位"]),
                            Convert.ToInt32(tb.Rows[i]["ydwbl"]),
                            Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["参考进价"], "0")),
                            0,
                            Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["进货单位ID"], "0")),
                            djh,
                            Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                            out err_code, out err_text, InstanceForm.BDatabase);
                        if (err_code != 0) { throw new System.Exception(err_text); }
                    }

                }



                //提交事务
                InstanceForm.BDatabase.CommitTransaction();
                this.lbldjh.Text = djh.ToString("00000000");
                //this.butadd.Enabled=false;
                //this.butdel.Enabled=false;
                //this.butmodif.Enabled=false;
                //this.butsave.Enabled=false;
                //butsh.Enabled = true;

                FillDj(djid, false);
                MessageBox.Show(err_text);

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.butsave.Enabled = true;
                MessageBox.Show(err.Message + err.Source);

            }
        }

        // 删除行
        private void butdel_Click(object sender, System.EventArgs e)
        {
            try
            {
                System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (nrow >= tb.Rows.Count) return;
                if (MessageBox.Show("您确定要删除第" + Convert.ToString((nrow + 1)) + "行吗 ？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataRow datarow = tb.Rows[nrow];
                    string ssql = "delete from yf_CGMX where id='" + Convertor.IsNull(datarow["id"], Guid.Empty.ToString()) + "'";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    tb.Rows.Remove(datarow);
                    System.Data.DataTable tb2 = (System.Data.DataTable)this.myDataGrid2.DataSource;
                    tb2.Rows.Clear();
                    this.Sumje();
                    this.csgroupbox2();
                }

                this.butadd.Enabled = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        //退出
        private void butclose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        //修改按钮事件
        private void butmodif_Click(object sender, System.EventArgs e)
        {
            try
            {
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
                if (nrow > tb.Rows.Count - 1) return;
                DataRow row = tb.Rows[nrow];
                this.Fillrow(row);
                if (row["货号"].ToString().Trim() != "")
                {
                    this.Sumje();
                    DataRow nullrow = tb.NewRow();
                    this.Getrow(nullrow);
                    this.butadd.Enabled = true;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        //审核事件
        private void butsh_Click(object sender, System.EventArgs e)
        {
           // SCMPurchasePlan ScmPlan = new SCMPurchasePlan();//提供SCM服务调用
            
            IList<SCMPurchasePlan> ScmPlan = new List<SCMPurchasePlan>();

            System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            long djh = Convert.ToInt64(Convertor.IsNull(this.lbldjh.Text, "0"));
            Guid djid = Guid.Empty;
            int err_code = 0;
            string err_text = "";


            bool bYes = false;
            int mdks = 0;
            if (
                YpConfig.是否药库(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) == false
                    && MessageBox.Show(this, "您须要将这个采购计划作为领药申请单吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bYes = true;

                Frmks f = new Frmks(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")));
                f.ShowDialog();
                mdks = f.mdks;
                if (mdks == 0) return;
            }

            try
            {

                InstanceForm.BDatabase.BeginTransaction();

                if (bYes == true && mdks > 0)
                {
                    //发送领药申请单
                    long sqdh = Yp.SeekNewDjh(_menuTag.FunctionTag, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                    YF_RKSQ_RKSQMX.SaveDJ(Guid.Empty, "", mdks, 0, InstanceForm.BCurrentUser.EmployeeId, sDate, sqdh, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), "由采购计划生成(采购单号 " + djh.ToString() + ")", 0, out djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                    if (err_code != 0) { throw new System.Exception(err_text); }


                    //下面是采购明细
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        decimal pfje = Convert.ToDecimal(tb.Rows[i]["批发价"]) * Convert.ToDecimal(tb.Rows[i]["计划数"]);
                        decimal lsje = Convert.ToDecimal(tb.Rows[i]["零售价"]) * Convert.ToDecimal(tb.Rows[i]["计划数"]);
                        YF_RKSQ_RKSQMX.SaveDJMX(Guid.Empty,
                            djid,
                            sqdh, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                            Convert.ToInt32(tb.Rows[i]["cjid"]),
                            Convert.ToString(tb.Rows[i]["单位"]),
                            Convert.ToInt32(tb.Rows[i]["ydwbl"]),
                            Convert.ToDecimal(tb.Rows[i]["计划数"]),
                            Convert.ToDecimal(tb.Rows[i]["批发价"]),
                            Convert.ToDecimal(tb.Rows[i]["零售价"]),
                            Convert.ToDecimal(pfje.ToString("0.00")),
                            Convert.ToDecimal(lsje.ToString("0.00")),
                            out err_code, out err_text, InstanceForm.BDatabase);
                        if (err_code != 0) { throw new System.Exception(err_text); }
                    }

                    
                    //产生目标服务器的申领单
                    System.Data.DataTable tbyjks = Yp.SelectYjks(mdks, InstanceForm.BDatabase);
                    if (tbyjks.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(tbyjks.Rows[0]["QYBZ"]) == 1)
                        {
                            if (Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]) != InstanceForm._menuTag.Jgbm)
                            {
                                string _err_text = "";
                                Guid log_djid = Guid.Empty;
                                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                                bool shbz = ts_HospData_Share.yp_lysq.GetShzt(djid, Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]), out _err_text);
                                if (shbz == true) throw new Exception(_err_text);
                                string bz = InstanceForm.BCurrentDept.DeptName.Trim() + " 由采购计划生成的申领单,单据号:" + sqdh.ToString();
                                ts.Save_log(ts_HospData_Share.czlx.yp_药房申请领药单, bz, "YF_RKSQ", "ID", djid.ToString(), InstanceForm._menuTag.Jgbm, Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]), 0, "", out log_djid, InstanceForm.BDatabase);
                            }
                        }
                    }
                }





                //更新表头的审核标志
                YF_CG_CGMX.Shdj(djh,
                    Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")),
                    InstanceForm.BCurrentUser.EmployeeId,
                    sDate, InstanceForm.BDatabase);

                //更新上次进价
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (this.checkBox2.Checked == true && Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["参考进价"], "0")) > 0)
                        YF_CG_CGMX.UpdateScjjScjjdw(Convert.ToInt32(tb.Rows[i]["cjid"]),
                                                    Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["参考进价"], "0")),
                                                    Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["进货单位ID"], "0")),
                                                    Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                }

                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("审核成功");

                //**********此处添加SCM相关服务代码*********************************
                bool Suc_flag = false;
                try
                {
                     Suc_flag = GetPurChanseInfoToScm(InstanceForm.BCurrentDept.DeptId.ToString(), djh.ToString(), djid.ToString());
                      if (!Suc_flag)
                      {
                          MessageBox.Show("传递信息到SCM系统出错，请联系SCM！");
                          return;
                      }
                      else
                      {
                          MessageBox.Show("传递信息到SCM系统成功！");
                      }

                }
                catch(System.Exception err)
                {
                    MessageBox.Show("发生错误："+err.Message);
                }            
               

                //******************************************************************
                this.butsh.Enabled = false;
                this.butsave.Enabled = false;
                this.butprint.Enabled = true;
                this.butadd.Enabled = false;
                this.butdel.Enabled = false;
                this.butmodif.Enabled = false;
                this.butref.Enabled = false;
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        #endregion

        private bool GetPurChanseInfoToScm(string strDeptid,string strDjh,string strZBid)
        {
            System.Data.DataTable tabInfo = null;
            long djh = Convert.ToInt32(strDjh);
            List<SCMPurchasePlan> scmPurchInfo = new List<SCMPurchasePlan>();
            tabInfo = ScmHisSer.GetCgmxByDeptAndId(strDeptid, strDjh, strZBid, InstanceForm.BDatabase);
            string strMemo = txtbz.Text.Trim();
            if (tabInfo.Rows.Count > 0)
            {
                for (int i = 0; i <= tabInfo.Rows.Count - 1; i++)
                {
                    SCMPurchasePlan pinfomx = new SCMPurchasePlan();
                    /*EBELN
                      EBELP
                      LIFNR
                     * 
                      NAME
                      MATNR
                      TXZ01
                     * 
                      WERKS
                      WERKST
                      LGORT
                     * 
                      MENGE
                      MEINS
                      MSEHT
                     * 
                      NETPR
                      EINDT
                      BEDAT
                      COMMENTS
                      FREEUSE
                     * */
                    //djh.ToString("00000000");strDjh

                   // pinfomx.EBELN = tabInfo.Rows[i]["EBELN"].ToString("00000000"); //采购单号 ---采用单据号,方便查看

                    pinfomx.EBELN = djh.ToString("00000000"); //采购单号 ---采用单据号,方便查看
                    pinfomx.EBELP = tabInfo.Rows[i]["EBELP"].ToString(); //项目编号 
                    pinfomx.LIFNR = tabInfo.Rows[i]["LIFNR"].ToString(); //供应商帐号

                    pinfomx.NAME = tabInfo.Rows[i]["NAME"].ToString();   //库存地点
                    pinfomx.MATNR = tabInfo.Rows[i]["MATNR"].ToString(); //药品编号
                    pinfomx.TXZ01 = tabInfo.Rows[i]["TXZ01"].ToString(); //药品名称

                    pinfomx.WERKS = tabInfo.Rows[i]["WERKS"].ToString(); //院区ID
                    pinfomx.WERKST = tabInfo.Rows[i]["WERKST"].ToString();//院区描述
                    pinfomx.LGORT = tabInfo.Rows[i]["LGORT"].ToString();  //库存（送货）地点

                    pinfomx.MENGE = Convert.ToDecimal(tabInfo.Rows[i]["MENGE"].ToString()); //送货数量 ?
                    pinfomx.MEINS = tabInfo.Rows[i]["MEINS"].ToString();  //计量单位ID
                    pinfomx.MSEHT = tabInfo.Rows[i]["MSEHT"].ToString();  //计量单位描述

                    pinfomx.NETPR = Convert.ToDecimal(tabInfo.Rows[i]["NETPR"].ToString()); //单价（进货价）
                    pinfomx.EINDT = Convert.ToDateTime( tabInfo.Rows[i]["EINDT"]).ToString("yyyy-MM-dd hh:mm:ss");  //交货日期
                    pinfomx.BEDAT = Convert.ToDateTime( tabInfo.Rows[i]["BEDAT"]).ToString("yyyy-MM-dd hh:mm:ss");  //采购订单日期
                   // pinfomx
                    pinfomx.COMMENTS = strMemo;//备注字段
                    pinfomx.FREEUSE = "";//预约字段传空                   

                    // 新增加 add by HYD 2016-11-08
                    pinfomx.PRODUCTFACTORY = tabInfo.Rows[i]["PRODUCTFACTORY"].ToString();//生产厂商
                    pinfomx.SPEC = tabInfo.Rows[i]["SPEC"].ToString();  //库存（送货）地点

                    scmPurchInfo.Add(pinfomx);
                }
            }

            try
            {                
                bool err_flag = true;
                bool Suc_flag = false;
                ScmHisSer.HisPushChasePlanToSCM(scmPurchInfo, "C", out Suc_flag, out err_flag);

                return Suc_flag;
                //if (!Suc_flag)
                //{
                //    MessageBox.Show("传递信息到SCM系统出错，请联系SCM！");
                //    return;
                //}
                //else
                //{
                //    MessageBox.Show("传递信息到SCM系统成功！");
                //}

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        private void butref_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.csgroupbox1();
                this.csgroupbox2();
                this.butsave.Enabled = true;

                System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
                if (tb.Rows.Count > 0)
                {
                    if (MessageBox.Show("点击查询将清除网格中的内容，您确定清除吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                }

                Frmsel frm = new Frmsel();
                frm.ShowDialog();
                if (frm.bok == false) return;
                //txtbz.Text = frm.ssql_bz;

                cmbck.Enabled = false;
                tb.Rows.Clear();

                string ssql = "";

                string order = "";

                if (Convertor.IsNull(cmbyplx.SelectedValue, "0") != "0")
                    order = " and  b.yplx=" + Convertor.IsNull(cmbyplx.SelectedValue, "0") + "  ";

                if (cmbpx.SelectedIndex == 0 || cmbpx.SelectedIndex == -1)
                    order = order + " order by b.yplx,A.ghdw,A.GGID,A.CJID";
                if (cmbpx.SelectedIndex == 1)
                    order = order + " order by b.yplx,d.tlfl,ypjx,A.GGID,A.CJID";
                if (cmbpx.SelectedIndex == 2)
                    order = order + " order by b.yplx,ylfl,ypjx,A.GGID,A.CJID";
                if (cmbpx.SelectedIndex == 3)
                    order = order + " order by b.yplx,b.yppm,A.GGID,A.CJID";
                if (cmbpx.SelectedIndex == 4)
                    order = order + " order by b.yppm,A.GGID,A.CJID ";
                if (cmbpx.SelectedIndex == 5)//新增 供货单位 排序方式  lidan 2013-07-01
                    order = order + " order by a.ghdw ";
                //if (cmbfxff.SelectedIndex == 0)
                //    ssql = "select 0 序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,s_sccj 厂家," +
                //        " pfj 批发价,lsj 零售价,zkc 全院库存,cast(round(a.kcl/a.dwbl,2) as float) 库存数,cast(kcsx  as float) 需求数,cast(kcsx  as float) 计划数,dbo.fun_yp_ypdw(b.ypdw) 单位," +
                //        " cast(a.scjj as float) 参考进价,dbo.fun_yp_ghdw(a.ghdw) 进货单位,cast(mrjj as float) 默认进价,a.ghdw 进货单位id,b.shh 货号," +
                //        " 1 ydwbl,a.cjid,dbo.FUN_GETEMPTYGUID() id,dbo.fun_yp_ylfl(ylfl) 药理分类 from " +
                //        Yp.Seek_kcmx_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) +
                //        " a inner join vi_yp_ypcd b on a.cjid=b.cjid inner join yp_kcsxx c " +
                //        " on b.cjid=c.cjid and c.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) +
                //        "  left join yp_ypjx d on b.ypjx=d.id inner join (select cjid,cast(round(sum(kcl/dwbl),2) as float) zkc from vi_yp_kcmx group by cjid) " +
                //        "  e on a.cjid=e.cjid  where " +
                //        " a.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and (kcxx*(a.dwbl/ydwbl)-a.kcl)>=0 and kcxx<>0 and kcsx<>0 and cjbdelete=0 and a.bdelete=0 " + order;
                //// 以上限报库存差值
                //else
                //     ssql = "select 0 序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,s_sccj 厂家," +
                //        " pfj 批发价,lsj 零售价,zkc 全院库存,cast(round(a.kcl/a.dwbl,3) as float) 库存数,"+
                //        " cast(round((kcsx/ydwbl-round(a.kcl/a.dwbl,3)),3) as float) 需求数,"+
                //        "(case when STATITEM_CODE='03' then cast(round((kcsx/ydwbl-round(a.kcl/a.dwbl,3)),3) AS float) else dbo.getint( (kcsx/ydwbl-round(a.kcl/a.dwbl,3)),1) end) 计划数,dbo.fun_yp_ypdw(b.ypdw) 单位," +
                //        " cast(a.scjj as float) 参考进价,dbo.fun_yp_ghdw(a.ghdw) 进货单位,cast(mrjj as float) 默认进价,a.ghdw 进货单位id,b.shh 货号," +
                //        " 1 ydwbl,a.cjid,dbo.FUN_GETEMPTYGUID() id,dbo.fun_yp_ylfl(ylfl) 药理分类 from " +
                //        Yp.Seek_kcmx_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase) +
                //        " a inner join vi_yp_ypcd b on a.cjid=b.cjid inner join yp_kcsxx c " +
                //        " on b.cjid=c.cjid and c.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) +
                //        " left join yp_ypjx d on b.ypjx=d.id inner join (select cjid,cast(round(sum(kcl/dwbl),2) as float) zkc from vi_yp_kcmx group by cjid ) " +
                //        " e on a.cjid=e.cjid  where  " +
                //        " a.deptid=" + Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")) + " and (kcsx*(a.dwbl/ydwbl)-a.kcl)>0 and kcsx<>0  and cjbdelete=0 and a.bdelete=0 " + order;



                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@ORDER";
                parameters[0].Value = order;
                parameters[1].Text = "@DEPTID";
                parameters[1].Value = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));
                parameters[2].Text = "@KCTABLE";
                parameters[2].Value = Yp.Seek_kcmx_table(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                parameters[3].Text = "@JSLX";
                parameters[3].Value = cmbfxff.SelectedIndex;
                parameters[4].Text = "@WHERE";
                parameters[4].Value = frm.ssql;
                System.Data.DataTable tbmx = InstanceForm.BDatabase.GetDataTable("SP_YP_SELECT_CGJH", parameters, 30);
                tbmx.TableName = "tbmx";
                FunBase.AddRowtNo(tbmx);
                this.myDataGrid1.DataSource = tbmx;
                this.myDataGrid1.TableStyles[0].MappingName = "tbmx";
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }


        }

        private void butprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
                ts_Yk_ReportView.Dataset1 Dset = new ts_Yk_ReportView.Dataset1();
                DataRow myrow;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    myrow = Dset.药品采购计划.NewRow();
                    myrow["xh"] = Convert.ToInt32(tb.Rows[i]["序号"]);
                    if (ss.打印单据时单据显示商品名 == true)
                        myrow["ypmc"] = Convert.ToString(tb.Rows[i]["商品名"]);
                    else
                        myrow["ypmc"] = Convert.ToString(tb.Rows[i]["品名"]);

                    myrow["ypgg"] = Convert.ToString(tb.Rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(tb.Rows[i]["厂家"]);
                    myrow["ypdw"] = Convert.ToString(tb.Rows[i]["单位"]);
                    myrow["pfj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"], "0"));
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"], "0"));
                    myrow["xqs"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["库存数"], "0"));
                    myrow["jhs"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["计划数"], "0"));
                    myrow["ckjj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["参考进价"], "0"));
                    myrow["ckkl"] = 0;
                    myrow["ghdw"] = Convertor.IsNull(tb.Rows[i]["进货单位"], "");
                    myrow["shh"] = Convert.ToString(tb.Rows[i]["货号"]);
                    myrow["syyl"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["上月用量"], "0"));
                    myrow["jbyw"] = Convert.ToString(tb.Rows[i]["基本药物"]);
                    myrow["hwh"] = Convert.ToString(tb.Rows[i]["货位名称"]);
                    myrow["bz"] = "";
                    myrow["bz1"] = "";
                    Dset.药品采购计划.Rows.Add(myrow);

                }

                string djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from yf_cg where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();

                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Text = "DJH";
                parameters[0].Value = this.lbldjh.Text;
                parameters[1].Text = "DJY";
                parameters[1].Value = djy + "                                 打印员:" + InstanceForm.BCurrentUser.Name;
                parameters[2].Text = "FXFF";
                parameters[2].Value = cmbfxff.Text.Trim();
                parameters[3].Text = "RQ";
                parameters[3].Value = dtprq.Value.ToShortDateString();
                parameters[4].Text = "TITLETEXT";
                parameters[4].Value = TrasenFrame.Classes.Constant.HospitalName + _menuTag.MenuName;
                parameters[5].Text = "BZ";
                parameters[5].Value = txtbz.Text.Trim();
                parameters[6].Text = "ckmc";
                parameters[6].Value = cmbck.Text;

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.药品采购计划, Constant.ApplicationDirectory + "\\Report\\YK_药品采购计划.rpt", parameters);
                if (f.LoadReportSuccess) f.Show(); else f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.checkBox1.Checked == true)
                this.panel2.Visible = false;
            else
                this.panel2.Visible = true;
        }

        private void cmbck_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbck.SelectedValue == null) return;
                if (cmbck.SelectedValue.ToString() == "System.Data.DataRowView") return;
                ss = new YpConfig(Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), InstanceForm.BDatabase);
                System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
                if (tb != null) tb.Rows.Clear();
                if (ss.网络内容显示商品名 == true)
                    this.商品名.Width = 130;
                else
                    this.商品名.Width = 0;

                Yp.AddCmbYplx(true, Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0")), cmbyplx, InstanceForm.BDatabase);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;

                //pym赋值
                tb = DoSetTablePym(tb);

                // 创建Excel对象                    --LeeWenjie    2006-11-29
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel无法启动");
                    return;
                }
                // 创建Excel工作薄
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // 列索引，行索引，总列数，总行数
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = 0;
                int RowCount = tb.Rows.Count;
                for (int i = 0; i <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[i].Width > 0)
                        colCount = colCount + 1;
                }

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = _chineseName + "一览表";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;


                // 设置条件
                Excel.Range range1 = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                range1.MergeCells = true;
                range1.Value2 = "仓库名称:" + cmbck.Text + "  参考库存:" + cmbckkc.Text.Trim() + "  分析方法:" + cmbfxff.Text + "  采购日期:" + dtprq.Value.ToShortDateString() + "   操作员:" + InstanceForm.BCurrentUser.Name;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;



                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; i++)
                {
                    if (myDataGrid1.TableStyles[0].GridColumnStyles[i].Width > 0)
                        objData[0, colIndex++] = myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
                }


                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= myDataGrid1.TableStyles[0].GridColumnStyles.Count - 1; j++)
                    {
                        if (myDataGrid1.TableStyles[0].GridColumnStyles[j].Width > 0)
                        {
                            if (myDataGrid1.TableStyles[0].GridColumnStyles[j].HeaderText == "品名" || myDataGrid1.TableStyles[0].GridColumnStyles[j].HeaderText == "商品名" || myDataGrid1.TableStyles[0].GridColumnStyles[j].HeaderText == "规格")
                                objData[i + 1, colIndex++] = "'" + tb.Rows[i][j].ToString().Trim();
                            else
                                objData[i + 1, colIndex++] = "" + tb.Rows[i][j].ToString().Trim();
                        }
                    }

                    System.Windows.Forms.Application.DoEvents();
                }

                int x = 3;
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[x, 1], xlApp.Cells[RowCount + x, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[x, 1], xlApp.Cells[RowCount + x, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[x, 1], xlApp.Cells[RowCount + x, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[x, 1], xlApp.Cells[RowCount + x, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[x, 1], xlApp.Cells[RowCount + x, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool myDataGrid1_myKeyDown(ref Message msg, Keys keyData)
        {
            try
            {
                System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
                int nkey = Convert.ToInt32(keyData);
                string columnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].HeaderText.Trim();
                if (nrow > tb.Rows.Count - 1) return true;
                if (columnName.Trim() == "进货单位" && nkey != 37 && nkey != 40 && nkey != 38 && nkey != 39 && butsave.Enabled == true)
                {
                    string coltext = keyData.ToString();
                    string[] GrdMappingName;
                    int[] GrdWidth;
                    string[] sfield;
                    string ssql = "";
                    DataRow row;

                    //Point point=new Point(this.Location.X+control.Location.X,this.Location.Y+control.Location.Y+control.Height*3 );
                    System.Drawing.Point point = new System.Drawing.Point(this.myDataGrid1.GetCellBounds(nrow, ncol).Left, this.myDataGrid1.GetCellBounds(nrow, ncol).Top + this.myDataGrid1.Top + this.myDataGrid1.GetCellBounds(nrow, ncol).Height);
                    GrdMappingName = new string[] { "id", "行号", "供货商", "拼音码", "五笔码" };
                    GrdWidth = new int[] { 0, 50, 200, 100, 100 };
                    sfield = new string[] { "wbm", "pym", "", "", "" };
                    ssql = "select ID,0 rowno,ghdwmc,pym,wbm from yp_ghdw WHERE ID<>0 ";
                    TrasenFrame.Forms.Fshowcard f1 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, coltext.Trim(), ssql);

                    f1.Location = point;
                    f1.ShowDialog(this);
                    row = f1.dataRow;
                    if (row != null)
                    {
                        tb.Rows[nrow]["进货单位"] = row["ghdwmc"].ToString().Trim();
                        tb.Rows[nrow]["进货单位id"] = row["id"].ToString();
                        if (nrow + 1 <= tb.Rows.Count)
                            this.myDataGrid1.CurrentCell = new DataGridCell(nrow + 1, ncol);
                        return false;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return false;
        }

        private System.Data.DataTable DoSetTablePym(System.Data.DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                row["拼音码"] = PubStaticFun.GetPYWBM(row["品名"].ToString().Trim(), 0);
            }
            return dt;
        }

        /// <summary>
        /// 点击导入按钮进行导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            //打开一个文件选择框
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Excel文件";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//为了获取特定的系统文件夹，可以使用System.Environment类的静态方法GetFolderPath()。该方法接受一个Environment.SpecialFolder枚举，其中可以定义要返回路径的哪个系统目录
            
            ofd.Filter = "Excel文件(*.xls)|*.xls|EXCEL(*.xlsx)|*.xlsx";
            ofd.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true;  //验证路径有效性
            ofd.CheckPathExists = true; //验证文件有效性


            string strName = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strName = ofd.FileName;
            }

            if (strName == "")
            {
                MessageBox.Show("没有选择Excel文件！无法进行数据导入");
                return;
            }
            //调用导入数据方法
            EcxelToDataGridView(strName);
        }

        #region excel 方法
        public bool getExcel(DataGridView dgv, System.Windows.Forms.Label lbl)
        {
            return true;
           /* bool fflag = true;

            OpenFileDialog open = new OpenFileDialog();
            open.Title = "请选择要导入的Excel文件";
            open.Filter = "Excel文件(*.xls)|*.xls";

            if (open.ShowDialog() == DialogResult.OK)
            {
                string fileName = open.FileName;
                //根据路径打开一个Excel文件并将数据填充到DataSet中  
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + fileName + ";Extended Properties ='Excel 8.0;HDR=NO;IMEX=1'";//导入时包含Excel中的第一行数据，并且将数字和字符混合的单元格视为文本进行导入  
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "select  * from   [sheet1$]";
                OleDbDataAdapter comm = new OleDbDataAdapter(strExcel, strConn);
                DataSet ds = new DataSet();
                try
                {
                    comm.Fill(ds, "table1");
                }
                catch
                {
                    MessageBox.Show("错误信息：009", "错误");
                }
                comm.Fill(ds, "table1");

                //根据DataGridView的列构造一个新的DataTable  
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                foreach (DataGridViewColumn dgvc in dgv.Columns)
                {
                    if (dgvc.Visible)
                    {

                        DataColumn dc = new DataColumn();
                        dc.ColumnName = dgvc.DataPropertyName;
                        dt.Columns.Add(dc);
                        DataColumn dc2 = new DataColumn();
                        dc2.ColumnName = dgvc.DataPropertyName;
                        dt2.Columns.Add(dc2);

                        if (dgvc.CellType == typeof(DataGridViewCheckBoxCell))
                        {
                            dc2.DataType = Type.GetType("System.Boolean");
                        }
                    }
                }

                //根据Excel的行逐一对上面构造的DataTable的列进行赋值  
                foreach (DataRow excelRow in ds.Tables[0].Rows)
                {
                    int i = 0;
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        dr[dc] = excelRow[i];
                        i++;
                    }
                    dt.Rows.Add(dr);
                }

                //判断Excel的格式是否正确  
                int n = 0;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    bool flag = false;
                    for (int k = n; k < dgv.ColumnCount; k++)
                    {
                        if (dgv.Columns[k].Visible)  //隐藏的列  
                        {
                            if (dgv.Columns[k].HeaderText.Trim().ToString() == dt.Rows[0][j].ToString())
                            {
                                if (dgv.Columns[k].CellType == typeof(DataGridViewCheckBoxCell))
                                {
                                    //list.Add(j);  
                                    //num++;  
                                }
                                flag = true;
                                n = k + 1;
                                break;
                            }
                        }
                    }
                    if (flag == false)
                    {
                        MessageBox.Show("导入的Excel的格式错误", "提示");
                        fflag = false;
                        return fflag;
                    }
                }

                //删除多余的行  
                int rowCount = (dt.Rows.Count) / 2;

                for (int i = 0; i <= rowCount; i++)
                {
                    dt.Rows.RemoveAt(0);
                }

                //处理Boolean类型的数据  
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt2.NewRow();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        try
                        {
                            dr[j] = dt.Rows[i][j];
                        }
                        catch
                        {
                            dr[j] = false;
                        }
                    }
                    dt2.Rows.Add(dr);
                }

                //导入到dataGridView  
                dgv.DataSource = dt2;

                lbl.Text = dgv.RowCount.ToString();
            }
            else
            {
                fflag = false;
            }
            return fflag;*/
        }
        #endregion

        /// <summary>
        /// 构造一个表结构特定的格式的表结构与数据
        /// </summary>
        /// <param name="TabTemp"></param>
        /// <returns></returns>
        private System.Data.DataTable GetTB(System.Data.DataTable TabTemp)
        {

            //定义表结构
           System.Data.DataTable dt = new System.Data.DataTable();
           
           //string strExcel = @"select [CJID],[品名],[规格],[厂家],[批发价],[零售价],[全院库存],[本院库存],[库存数],[需求数],
                      //  [上月用量],[计划数],[单位],[参考进价],[进货单位],[默认进价],[货号],[货位名称],[进货单位ID]   from   [sheet1$]";

           dt.Columns.Add("序号");           
           dt.Columns.Add("品名");
           dt.Columns.Add("规格");
           dt.Columns.Add("厂家");
           dt.Columns.Add("批发价");
           dt.Columns.Add("零售价");
           dt.Columns.Add("全院库存");
           dt.Columns.Add("本院库存");
           dt.Columns.Add("库存数");
           dt.Columns.Add("需求数");
           dt.Columns.Add("上月用量");
           dt.Columns.Add("计划数");
           dt.Columns.Add("单位");
           dt.Columns.Add("参考进价");
           dt.Columns.Add("进货单位");
           dt.Columns.Add("默认进价");
           dt.Columns.Add("货号");
           dt.Columns.Add("货位名称");
           dt.Columns.Add("进货单位ID");
           dt.Columns.Add("CJID");
           dt.Columns.Add("商品名");
           dt.Columns.Add("YDWBL");
           dt.Columns.Add("药理分类");
           dt.Columns.Add("基本药物");
           dt.Columns.Add("ID");

           dt.TableName = "TabPuchPlan";
          
           DataRow tr;
           for (int ii = 0; ii < TabTemp.Rows.Count;ii++ )
           {         
               tr = dt.NewRow();
               tr["序号"] = TabTemp.Rows[ii]["序号"].ToString();
               tr["品名"] = TabTemp.Rows[ii]["品名"].ToString();
               tr["规格"] = TabTemp.Rows[ii]["规格"].ToString();
               tr["厂家"] = TabTemp.Rows[ii]["厂家"].ToString();
               tr["批发价"] = TabTemp.Rows[ii]["批发价"].ToString();
               tr["零售价"] = TabTemp.Rows[ii]["零售价"].ToString();
               tr["全院库存"] = TabTemp.Rows[ii]["全院库存"].ToString();
               tr["本院库存"] = TabTemp.Rows[ii]["本院库存"].ToString();
               tr["库存数"] = TabTemp.Rows[ii]["库存数"].ToString();
               tr["需求数"] = TabTemp.Rows[ii]["需求数"].ToString();
               tr["上月用量"] = TabTemp.Rows[ii]["上月用量"].ToString();
               tr["计划数"] = TabTemp.Rows[ii]["计划数"].ToString();
               tr["单位"] = TabTemp.Rows[ii]["单位"].ToString();
               tr["参考进价"] = TabTemp.Rows[ii]["参考进价"].ToString();
               tr["进货单位"] = TabTemp.Rows[ii]["进货单位"].ToString();
               tr["默认进价"] = TabTemp.Rows[ii]["默认进价"].ToString();
               tr["货号"] = TabTemp.Rows[ii]["货号"].ToString();
               tr["货位名称"] = TabTemp.Rows[ii]["货位名称"].ToString();
               tr["进货单位ID"] = TabTemp.Rows[ii]["进货单位ID"].ToString();
               tr["CJID"] = TabTemp.Rows[ii]["CJID"].ToString();
               tr["商品名"] = TabTemp.Rows[ii]["商品名"].ToString();
               tr["YDWBL"] = TabTemp.Rows[ii]["YDWBL"].ToString();
               tr["药理分类"] = TabTemp.Rows[ii]["药理分类"].ToString();
               tr["基本药物"] = TabTemp.Rows[ii]["基本药物"].ToString();
               tr["ID"] = TabTemp.Rows[ii]["ID"].ToString();               

               dt.Rows.Add(tr);
           }

           // myrow["ypgg"] = Convert.ToString(tb.Rows[i]["规格"]);

            //填充数据            

            
            return dt;

        }        

        /// <summary>
        /// 根据导入的EXCEL数据进行绑定数据到DataGridView
        /// </summary>
        /// <param name="filePath"></param>
        public void EcxelToDataGridView(string filePath)
        {
           // string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0; Persist Security Info=False;Data Source=" + filePath + ";" + "Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";
            //根据路径打开一个Excel文件并将数据填充到DataSet中
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + filePath + ";Extended Properties ='Excel 12.0;HDR=YES;IMEX=1'";//HDR=YES 有两个值:YES/NO,表示第一行是否字段名,默认是YES,第一行是字段名
           // string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + filePath + ";Extended Properties ='Excel 8.0;HDR=YES;IMEX=1'";//HDR=YES 有两个值:YES/NO,表示第一行是否字段名,默认是YES,第一行是字段名
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;

            try
            {
                strExcel = @"SELECT [序号],[品名],[规格],[厂家],[批发价],[零售价],[全院库存],[本院库存],[库存数],[需求数],
                        [上月用量],[计划数],[单位],[参考进价],[进货单位],[默认进价],[货号],[货位名称],[进货单位ID],
                        [CJID],[商品名],[YDWBL],[药理分类],[基本药物],[ID] FROM   [sheet1$]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ds = new DataSet();
                myCommand.Fill(ds, "table1");

                System.Data.DataTable tbmx = ds.Tables[0];
                tbmx.TableName = "tbmx";
                this.myDataGrid1.DataSource = tbmx;
                this.myDataGrid1.TableStyles[0].MappingName = "tbmx";
                //this.myDataGrid1.DataSource = ds.Tables[0];  

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            
                       
        }

        /// <summary>
        /// 点击导出按钮把数据导出EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportSCM_Click(object sender, EventArgs e)
        {           
            System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
            DataGridViewToExcelY(GetTB(tb));
            
        }       


        /// <summary>
        /// 把数据表的数据按一定格式导出到EXCEL中
        /// </summary>
        /// <param name="dgv"></param>
        public static void DataGridViewToExcelY(System.Data.DataTable dgv)
        {

            #region   验证可操作性

            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀   
            dlg.DefaultExt = "xls ";
            //文件后缀列表   
            //dlg.Filter = "EXCEL文件(*.XLS)|*.xls ";
            dlg.Filter = "Excel文件(*.xls)|*.xls|EXCEL(*.xlsx)|*.xlsx";
            //默然路径是系统当前路径   
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径   
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (fileNameString.Trim() == " ")
            { return; }
            //定义表格内数据的行数和列数   
            int rowscount = dgv.Rows.Count;
            int colscount = dgv.Columns.Count;
            //行数必须大于0   
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数必须大于0   
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //行数不可以大于65536   
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数不可以大于255   
            if (colscount > 255)
            {
                MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它   
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            #endregion

           /* Excel.Application objExcel = null;
            Excel.Workbook objWorkbook = null;
            Excel.Worksheet objsheet = null;  */ 

            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet objsheet = null;
            try
            {
                //申明对象   
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objsheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.ActiveSheet;
                //设置EXCEL不可见   
                objExcel.Visible = false;

                //向Excel中写入表格的表头   
                int displayColumnsCount = 1;

                //for (int i = 0; i <= dgv.ColumnCount - 1; i++)
                //{
                //    if (dgv.Columns[i].Visible == true)
                //    {
                //        objExcel.Cells[1, displayColumnsCount] = dgv.Columns[i].HeaderText.Trim();
                //        displayColumnsCount++;
                //    }
                //}

                //定义特定的列名
                string str_XH = "序号";                
                string str_YPMC = "品名";
                string str_YPGG = "规格";
                string str_YPCJ = "厂家";
                string str_PFJ = "批发价";
                string str_LSJ = "零售价";
                string str_CYKC = "全院库存";
                string str_BYKC = "本院库存";
                string str_KCS = "库存数";
                string str_XQS = "需求数";
                string str_SYYL = "上月用量";
                string str_JHS = "计划数";
                string str_DW = "单位";
                string str_CKJJ = "参考进价";
                string str_JHDW = "进货单位";
                string str_MRJJ = "默认进价";
                string str_HH = "货号";
                string str_HWMC = "货位名称";
                string str_JHDWID = "进货单位ID";
                string str_CJID = "CJID";
                string str_YPSPM = "商品名";
                string str_YDWBL = "YDWBL";
                string str_YLFL = "药理分类";
                string str_JBYW = "基本药物";
                string str_ID = "ID";
                //商品名，厂家ID，进货单位ID，药理分类，基本药物，拼音码

                string[] strArrTitle = new string[] { str_XH, str_YPMC, str_YPGG, str_YPCJ, str_PFJ, str_LSJ, 
                                                      str_CYKC, str_BYKC, str_KCS, str_XQS, str_SYYL, str_JHS, str_DW, str_CKJJ, 
                                                      str_JHDW, str_MRJJ, str_HH, str_HWMC, str_JHDWID,str_CJID,
                                                      str_YPSPM,str_YDWBL,str_YLFL,str_JBYW,str_ID     };
                for (int i = 0; i < strArrTitle.Length; i++)
                {
                   // strLine = strLine + strArrTitle[i] + Convert.ToChar(9);
                    objExcel.Cells[1, displayColumnsCount] = strArrTitle[i];
                    //objExcel.Cells[1, displayColumnsCount] = strArrTitle[i];
                    displayColumnsCount++;  
                }

                //设置进度条   
                //tempProgressBar.Refresh();   
                //tempProgressBar.Visible   =   true;   
                //tempProgressBar.Minimum=1;   
                //tempProgressBar.Maximum=dgv.RowCount;   
                //tempProgressBar.Step=1;   
                //向Excel中逐行逐列写入表格中的数据   
                for (int row = 0; row <= dgv.Rows.Count - 1; row++)
                {
                    //tempProgressBar.PerformStep();   

                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        // if (dgv.Columns[col].Visible == true) Rows[i][j].ToString();
                       // {
                            try
                            {
                               // objExcel.Cells[row + 2, displayColumnsCount] = dgv.Rows[row].Cells[col].Value.ToString().Trim();
                                objExcel.Cells[row + 2, displayColumnsCount] = dgv.Rows[row][col].ToString();
                                displayColumnsCount++;
                            }
                            catch (Exception)
                            {

                            }

                       // }
                    }
                }
                //隐藏进度条   
                //tempProgressBar.Visible   =   false;   
                //保存文件   
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用   
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();

                objsheet = null;
                objWorkbook = null;
                objExcel = null;
            }
            MessageBox.Show(fileNameString + "/n/n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// DataGridView的数据导出到EXCEL
        /// </summary>
        /// <param name="dgv"></param>
        public static void DataGridViewToExcelOLD(DataGridView dgv)
        {

            #region   验证可操作性

            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀   
            dlg.DefaultExt = "xls ";
            //文件后缀列表   
            dlg.Filter = "EXCEL文件(*.XLS)|*.xls ";
            //默然路径是系统当前路径   
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径   
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (fileNameString.Trim() == " ")
            { return; }
            //定义表格内数据的行数和列数   
            int rowscount = dgv.Rows.Count;
            int colscount = dgv.Columns.Count;
            //行数必须大于0   
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数必须大于0   
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //行数不可以大于65536   
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数不可以大于255   
            if (colscount > 255)
            {
                MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它   
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            #endregion

            /* Excel.Application objExcel = null;
            Excel.Workbook objWorkbook = null;
            Excel.Worksheet objsheet = null;  */

            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet objsheet = null;
            try
            {
                //申明对象   
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objsheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.ActiveSheet;
                //设置EXCEL不可见   
                objExcel.Visible = false;

                //向Excel中写入表格的表头   
                int displayColumnsCount = 1;
                for (int i = 0; i <= dgv.ColumnCount - 1; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                    {
                        objExcel.Cells[1, displayColumnsCount] = dgv.Columns[i].HeaderText.Trim();
                        displayColumnsCount++;
                    }
                }

                //设置进度条   
                //tempProgressBar.Refresh();   
                //tempProgressBar.Visible   =   true;   
                //tempProgressBar.Minimum=1;   
                //tempProgressBar.Maximum=dgv.RowCount;   
                //tempProgressBar.Step=1;   
                //向Excel中逐行逐列写入表格中的数据   
                for (int row = 0; row <= dgv.RowCount - 1; row++)
                {
                    //tempProgressBar.PerformStep();   

                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (dgv.Columns[col].Visible == true)
                        {
                            try
                            {
                                objExcel.Cells[row + 2, displayColumnsCount] = dgv.Rows[row].Cells[col].Value.ToString().Trim();
                                displayColumnsCount++;
                            }
                            catch (Exception)
                            {

                            }

                        }
                    }
                }
                //隐藏进度条   
                //tempProgressBar.Visible   =   false;   
                //保存文件   
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用   
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();

                objsheet = null;
                objWorkbook = null;
                objExcel = null;
            }
            MessageBox.Show(fileNameString + "/n/n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="m_DataView"></param>
        public void DataToExcel(System.Data.DataTable m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "Excel文件(*.xls)|*.xls|EXCEL(*.xlsx)|*.xlsx";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                //string FileName = kk.FileName + ".xls";
                string FileName = kk.FileName;
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);

                //定义特定的列名
                string str_cjID = "药品CJID";
                string str_YPMC = "药品名称";
                string str_YPGG = "药品规格";
                string str_YPCJ = "药品厂家";
                string str_YPSL = "库存数量";



                string[] strArrTitle = new string[] { str_cjID, str_YPMC, str_YPGG, str_YPCJ, str_YPSL };
                for (int i = 0; i < strArrTitle.Length; i++)
                {
                    strLine = strLine + strArrTitle[i] + Convert.ToChar(9);
                }

                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < m_DataView.Rows.Count; i++)
                {

                    for (int j = 0; j < m_DataView.Columns.Count; j++)
                    {

                        if (m_DataView.Rows[i][j].ToString() == "")
                        {
                            //strLine = strLine + " " + Convert.ToChar(9);
                            strLine = strLine + " " + Convert.ToChar(9);
                        }
                        else
                        {
                            string rowstr = "";
                            rowstr = m_DataView.Rows[i][j].ToString();
                            if (rowstr.IndexOf("\r\n") > 0)
                                rowstr = rowstr.Replace("\r\n", " ");
                            if (rowstr.IndexOf("\t") > 0)
                                rowstr = rowstr.Replace("\t", " ");
                            // strLine = strLine + rowstr + Convert.ToChar(9);
                            strLine = strLine + rowstr + Convert.ToChar(9);
                        }

                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show(this, "保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comSFDZ_SelectedIndexChanged(object sender, EventArgs e)
        {
          // string strSeldz= comSFDZ.SelectedValue.ToString();
           string strSeldz = comSFDZ.Text;
           txtbz.Text = strSeldz.Trim();
        }

    }
}
