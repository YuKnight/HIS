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
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;
using Aspose.Cells;
using System.Text.RegularExpressions;

namespace ts_yf_ypck
{
    /// <summary>
    /// Frmyprk 的摘要说明。
    /// </summary>
    public class Frmypck : System.Windows.Forms.Form
    {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
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
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.StatusBarPanel statusBarPanel4;
        private System.Windows.Forms.Label lblrkfs;
        private System.Windows.Forms.Label lblrkrq;
        public long _Sqdh;//申请单据号
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
        private System.Windows.Forms.TextBox txtbz;
        private System.Windows.Forms.Label lbldjh;
        private System.Windows.Forms.Label lbldjhdd;
        private System.Windows.Forms.TextBox txtghdw;
        private System.Windows.Forms.ComboBox cmbrckfs;
        private System.Windows.Forms.TextBox txtph;
        private System.Windows.Forms.TextBox txtkw;
        private System.Windows.Forms.TextBox txtypsl;
        private System.Windows.Forms.Label lbllsj;
        private System.Windows.Forms.Label lblpfj;
        private System.Windows.Forms.ComboBox cmbdw;
        private System.Windows.Forms.Label lblhh;
        private System.Windows.Forms.Label lblypmc;
        private System.Windows.Forms.Label lblcj;
        private System.Windows.Forms.Label lblgg;
        private System.Windows.Forms.TextBox txtypdm;
        private System.Windows.Forms.Label lbllsje;
        private System.Windows.Forms.Label lblpfje;
        private System.Windows.Forms.Button butmodif;
        private System.Windows.Forms.Button butdel;
        private System.Windows.Forms.Button butadd;
        private System.Windows.Forms.Label lblkc;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butsave;
        private System.Windows.Forms.Button butnew;
        private myDataGrid.myDataGrid myDataGrid1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
        private System.Windows.Forms.Button butsh;
        private System.Windows.Forms.DateTimePicker dtprq;
        private System.Windows.Forms.Button butph;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
        private System.Windows.Forms.DataGridTextBoxColumn 批号;
        private System.Windows.Forms.DataGridTextBoxColumn 效期;
        private System.Windows.Forms.DataGridTextBoxColumn 库位;
        private System.Windows.Forms.DataGridTextBoxColumn 申请量;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblghdw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblxq;
        private System.Windows.Forms.Button button1;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.Label lblpm;
        private System.Windows.Forms.DataGridTextBoxColumn 商品名;
        private YpConfig s;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.Label lbljhje;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbljhj;
        private System.Windows.Forms.Label label8;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private DataGridTextBoxColumn col_批次号;
        private DataGridTextBoxColumn col_kcid;
        private System.Windows.Forms.TextBox txtpch;
        private System.Windows.Forms.Label label9;

        bool bpcgl = false;
        private System.Windows.Forms.CheckBox chkhzdy; //是否进行批次管理
        bool bfpkcph = false; //自动分配批号库存
        private bool btjhj = false;
        private Panel pbljyr;
        private DataGridTextBoxColumn dataGridTextBoxColumn19;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.GroupBox groupBox4;
        private DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label6;
        private DateTimePicker dtp1;
        private System.Windows.Forms.Label label3;
        private DateTimePicker dateTimePicker1;
        private DataGridTextBoxColumn 现有库存;//是否调进货价

        public int jyr = 0; //借药人

        public Frmypck(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            _Sqdh = 0;
            s = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
            if (s.网络内容显示商品名 == true)
                this.商品名.Width = 150;
            else
                this.商品名.Width = 0;
            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";

            bpcgl = Yp.BPcgl(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);//进行批次管理
            bfpkcph = Yppc.BfpKcph(_menuTag.FunctionTag, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);//自动分配批号库存
            if (bpcgl)
            {
                col_批次号.Width = 75;
            }
            else
            {
                col_批次号.Width = 0;
            }

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
            this.pbljyr = new System.Windows.Forms.Panel();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldjh = new System.Windows.Forms.Label();
            this.lbldjhdd = new System.Windows.Forms.Label();
            this.dtprq = new System.Windows.Forms.DateTimePicker();
            this.lblrkrq = new System.Windows.Forms.Label();
            this.txtghdw = new System.Windows.Forms.TextBox();
            this.lblghdw = new System.Windows.Forms.Label();
            this.cmbrckfs = new System.Windows.Forms.ComboBox();
            this.lblrkfs = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Import = new System.Windows.Forms.Button();
            this.txtpch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbljhje = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbljhj = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblxq = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbllsje = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblpfje = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.butph = new System.Windows.Forms.Button();
            this.txtph = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtkw = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.butmodif = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butadd = new System.Windows.Forms.Button();
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
            this.lblcj = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblgg = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtypdm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblpm = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.商品名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_批次号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.col_kcid = new System.Windows.Forms.DataGridTextBoxColumn();
            this.批号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.效期 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.库位 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.申请量 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkhzdy = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.butclose = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.butnew = new System.Windows.Forms.Button();
            this.butsh = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.现有库存 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbljyr);
            this.groupBox1.Controls.Add(this.txtbz);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbldjh);
            this.groupBox1.Controls.Add(this.lbldjhdd);
            this.groupBox1.Controls.Add(this.dtprq);
            this.groupBox1.Controls.Add(this.lblrkrq);
            this.groupBox1.Controls.Add(this.txtghdw);
            this.groupBox1.Controls.Add(this.lblghdw);
            this.groupBox1.Controls.Add(this.cmbrckfs);
            this.groupBox1.Controls.Add(this.lblrkfs);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1180, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // pbljyr
            // 
            this.pbljyr.Location = new System.Drawing.Point(13, 11);
            this.pbljyr.Name = "pbljyr";
            this.pbljyr.Size = new System.Drawing.Size(421, 24);
            this.pbljyr.TabIndex = 17;
            this.pbljyr.Visible = false;
            // 
            // txtbz
            // 
            this.txtbz.ForeColor = System.Drawing.Color.Navy;
            this.txtbz.Location = new System.Drawing.Point(64, 37);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(712, 21);
            this.txtbz.TabIndex = 3;
            this.txtbz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(33, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "备注";
            // 
            // lbldjh
            // 
            this.lbldjh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldjh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldjh.ForeColor = System.Drawing.Color.Navy;
            this.lbldjh.Location = new System.Drawing.Point(679, 12);
            this.lbldjh.Name = "lbldjh";
            this.lbldjh.Size = new System.Drawing.Size(97, 20);
            this.lbldjh.TabIndex = 15;
            // 
            // lbldjhdd
            // 
            this.lbldjhdd.Location = new System.Drawing.Point(632, 16);
            this.lbldjhdd.Name = "lbldjhdd";
            this.lbldjhdd.Size = new System.Drawing.Size(64, 16);
            this.lbldjhdd.TabIndex = 14;
            this.lbldjhdd.Text = "单据号";
            // 
            // dtprq
            // 
            this.dtprq.Location = new System.Drawing.Point(496, 11);
            this.dtprq.Name = "dtprq";
            this.dtprq.Size = new System.Drawing.Size(120, 21);
            this.dtprq.TabIndex = 2;
            this.dtprq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblrkrq
            // 
            this.lblrkrq.Location = new System.Drawing.Point(440, 16);
            this.lblrkrq.Name = "lblrkrq";
            this.lblrkrq.Size = new System.Drawing.Size(64, 16);
            this.lblrkrq.TabIndex = 4;
            this.lblrkrq.Text = "单据日期";
            // 
            // txtghdw
            // 
            this.txtghdw.ForeColor = System.Drawing.Color.Navy;
            this.txtghdw.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtghdw.Location = new System.Drawing.Point(64, 11);
            this.txtghdw.Name = "txtghdw";
            this.txtghdw.Size = new System.Drawing.Size(368, 21);
            this.txtghdw.TabIndex = 1;
            this.txtghdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtghdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblghdw
            // 
            this.lblghdw.Location = new System.Drawing.Point(11, 16);
            this.lblghdw.Name = "lblghdw";
            this.lblghdw.Size = new System.Drawing.Size(71, 16);
            this.lblghdw.TabIndex = 2;
            this.lblghdw.Text = "往来单位";
            // 
            // cmbrckfs
            // 
            this.cmbrckfs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbrckfs.ForeColor = System.Drawing.Color.Navy;
            this.cmbrckfs.Location = new System.Drawing.Point(65, 12);
            this.cmbrckfs.Name = "cmbrckfs";
            this.cmbrckfs.Size = new System.Drawing.Size(111, 20);
            this.cmbrckfs.TabIndex = 0;
            this.cmbrckfs.Visible = false;
            this.cmbrckfs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // lblrkfs
            // 
            this.lblrkfs.Location = new System.Drawing.Point(8, 16);
            this.lblrkfs.Name = "lblrkfs";
            this.lblrkfs.Size = new System.Drawing.Size(64, 16);
            this.lblrkfs.TabIndex = 0;
            this.lblrkfs.Text = "单据方式";
            this.lblrkfs.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.txtpch);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lbljhje);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lbljhj);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblxq);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lbllsje);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblpfje);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.butph);
            this.groupBox2.Controls.Add(this.txtph);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtkw);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.butmodif);
            this.groupBox2.Controls.Add(this.butdel);
            this.groupBox2.Controls.Add(this.butadd);
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
            this.groupBox2.Controls.Add(this.lblcj);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblgg);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtypdm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblpm);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1180, 120);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dateTimePicker1);
            this.groupBox4.Controls.Add(this.dateTimePicker2);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btn_Import);
            this.groupBox4.Location = new System.Drawing.Point(900, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 100);
            this.groupBox4.TabIndex = 88;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "一键调拨";
            this.groupBox4.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(38, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 21);
            this.dateTimePicker1.TabIndex = 92;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(38, 52);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(151, 21);
            this.dateTimePicker2.TabIndex = 91;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 90;
            this.label6.Text = "  至";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 88;
            this.label3.Text = "日期";
            // 
            // btn_Import
            // 
            this.btn_Import.Location = new System.Drawing.Point(195, 26);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(67, 38);
            this.btn_Import.TabIndex = 87;
            this.btn_Import.Text = "查找";
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // txtpch
            // 
            this.txtpch.ForeColor = System.Drawing.Color.Navy;
            this.txtpch.Location = new System.Drawing.Point(65, 90);
            this.txtpch.Name = "txtpch";
            this.txtpch.ReadOnly = true;
            this.txtpch.Size = new System.Drawing.Size(111, 21);
            this.txtpch.TabIndex = 85;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(33, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 86;
            this.label9.Text = "批次";
            // 
            // lbljhje
            // 
            this.lbljhje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbljhje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbljhje.ForeColor = System.Drawing.Color.Navy;
            this.lbljhje.Location = new System.Drawing.Point(678, 64);
            this.lbljhje.Name = "lbljhje";
            this.lbljhje.Size = new System.Drawing.Size(98, 20);
            this.lbljhje.TabIndex = 84;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(624, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 83;
            this.label11.Text = "进货金额";
            // 
            // lbljhj
            // 
            this.lbljhj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbljhj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbljhj.ForeColor = System.Drawing.Color.Navy;
            this.lbljhj.Location = new System.Drawing.Point(544, 64);
            this.lbljhj.Name = "lbljhj";
            this.lbljhj.Size = new System.Drawing.Size(72, 20);
            this.lbljhj.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(504, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 81;
            this.label8.Text = "进价";
            // 
            // lblxq
            // 
            this.lblxq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxq.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxq.ForeColor = System.Drawing.Color.Navy;
            this.lblxq.Location = new System.Drawing.Point(565, 89);
            this.lblxq.Name = "lblxq";
            this.lblxq.Size = new System.Drawing.Size(112, 20);
            this.lblxq.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(533, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 72;
            this.label2.Text = "效期";
            // 
            // lbllsje
            // 
            this.lbllsje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsje.ForeColor = System.Drawing.Color.Navy;
            this.lbllsje.Location = new System.Drawing.Point(392, 65);
            this.lbllsje.Name = "lbllsje";
            this.lbllsje.Size = new System.Drawing.Size(104, 20);
            this.lbllsje.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(336, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 70;
            this.label4.Text = "零售金额";
            // 
            // lblpfje
            // 
            this.lblpfje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpfje.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpfje.ForeColor = System.Drawing.Color.Navy;
            this.lblpfje.Location = new System.Drawing.Point(232, 65);
            this.lblpfje.Name = "lblpfje";
            this.lblpfje.Size = new System.Drawing.Size(104, 20);
            this.lblpfje.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(176, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 68;
            this.label7.Text = "批发金额";
            // 
            // butph
            // 
            this.butph.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butph.Location = new System.Drawing.Point(311, 88);
            this.butph.Name = "butph";
            this.butph.Size = new System.Drawing.Size(25, 20);
            this.butph.TabIndex = 67;
            this.butph.Text = "F1";
            this.butph.Click += new System.EventHandler(this.butph_Click);
            // 
            // txtph
            // 
            this.txtph.ForeColor = System.Drawing.Color.Navy;
            this.txtph.Location = new System.Drawing.Point(230, 88);
            this.txtph.Name = "txtph";
            this.txtph.ReadOnly = true;
            this.txtph.Size = new System.Drawing.Size(80, 21);
            this.txtph.TabIndex = 7;
            this.txtph.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(198, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 65;
            this.label5.Text = "批号";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(486, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 20);
            this.button2.TabIndex = 64;
            this.button2.Text = "...";
            // 
            // txtkw
            // 
            this.txtkw.ForeColor = System.Drawing.Color.Navy;
            this.txtkw.Location = new System.Drawing.Point(398, 90);
            this.txtkw.Name = "txtkw";
            this.txtkw.ReadOnly = true;
            this.txtkw.Size = new System.Drawing.Size(90, 21);
            this.txtkw.TabIndex = 8;
            this.txtkw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(366, 94);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 16);
            this.label31.TabIndex = 62;
            this.label31.Text = "库位";
            // 
            // butmodif
            // 
            this.butmodif.Location = new System.Drawing.Point(830, 90);
            this.butmodif.Name = "butmodif";
            this.butmodif.Size = new System.Drawing.Size(64, 24);
            this.butmodif.TabIndex = 57;
            this.butmodif.Text = "修改(&M)";
            this.butmodif.Click += new System.EventHandler(this.butmodif_Click);
            // 
            // butdel
            // 
            this.butdel.Location = new System.Drawing.Point(760, 90);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(64, 24);
            this.butdel.TabIndex = 56;
            this.butdel.Text = "删除(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butadd
            // 
            this.butadd.Location = new System.Drawing.Point(688, 90);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(64, 24);
            this.butadd.TabIndex = 9;
            this.butadd.Text = "添加(&A)";
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            // 
            // lblkc
            // 
            this.lblkc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblkc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblkc.ForeColor = System.Drawing.Color.Navy;
            this.lblkc.Location = new System.Drawing.Point(544, 40);
            this.lblkc.Name = "lblkc";
            this.lblkc.Size = new System.Drawing.Size(72, 20);
            this.lblkc.TabIndex = 51;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(504, 40);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(48, 16);
            this.label36.TabIndex = 50;
            this.label36.Text = "库存量";
            // 
            // txtypsl
            // 
            this.txtypsl.ForeColor = System.Drawing.Color.Navy;
            this.txtypsl.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtypsl.Location = new System.Drawing.Point(64, 40);
            this.txtypsl.Name = "txtypsl";
            this.txtypsl.Size = new System.Drawing.Size(96, 21);
            this.txtypsl.TabIndex = 5;
            this.txtypsl.Leave += new System.EventHandler(this.txtypsl_Leave);
            this.txtypsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(33, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 16);
            this.label26.TabIndex = 32;
            this.label26.Text = "数量";
            // 
            // lbllsj
            // 
            this.lbllsj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbllsj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbllsj.ForeColor = System.Drawing.Color.Navy;
            this.lbllsj.Location = new System.Drawing.Point(392, 40);
            this.lbllsj.Name = "lbllsj";
            this.lbllsj.Size = new System.Drawing.Size(104, 20);
            this.lbllsj.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(336, 42);
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
            this.lblpfj.Location = new System.Drawing.Point(232, 40);
            this.lblpfj.Name = "lblpfj";
            this.lblpfj.Size = new System.Drawing.Size(104, 20);
            this.lblpfj.TabIndex = 27;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(189, 40);
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
            this.cmbdw.Size = new System.Drawing.Size(96, 20);
            this.cmbdw.TabIndex = 8;
            this.cmbdw.SelectedIndexChanged += new System.EventHandler(this.cmbdw_SelectedIndexChanged);
            this.cmbdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GotoNext);
            this.cmbdw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
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
            this.lblhh.Location = new System.Drawing.Point(678, 40);
            this.lblhh.Name = "lblhh";
            this.lblhh.Size = new System.Drawing.Size(98, 20);
            this.lblhh.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(647, 42);
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
            this.lblypmc.Location = new System.Drawing.Point(392, 16);
            this.lblypmc.Name = "lblypmc";
            this.lblypmc.Size = new System.Drawing.Size(136, 20);
            this.lblypmc.TabIndex = 21;
            // 
            // lblcj
            // 
            this.lblcj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblcj.ForeColor = System.Drawing.Color.Navy;
            this.lblcj.Location = new System.Drawing.Point(688, 15);
            this.lblcj.Name = "lblcj";
            this.lblcj.Size = new System.Drawing.Size(87, 20);
            this.lblcj.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(656, 16);
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
            this.lblgg.Location = new System.Drawing.Point(560, 15);
            this.lblgg.Name = "lblgg";
            this.lblgg.Size = new System.Drawing.Size(84, 20);
            this.lblgg.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(528, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 16);
            this.label12.TabIndex = 16;
            this.label12.Text = "规格";
            // 
            // txtypdm
            // 
            this.txtypdm.ForeColor = System.Drawing.Color.Navy;
            this.txtypdm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtypdm.Location = new System.Drawing.Point(64, 15);
            this.txtypdm.Name = "txtypdm";
            this.txtypdm.Size = new System.Drawing.Size(96, 21);
            this.txtypdm.TabIndex = 4;
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
            // lblpm
            // 
            this.lblpm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblpm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpm.ForeColor = System.Drawing.Color.Navy;
            this.lblpm.Location = new System.Drawing.Point(232, 16);
            this.lblpm.Name = "lblpm";
            this.lblpm.Size = new System.Drawing.Size(160, 20);
            this.lblpm.TabIndex = 74;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(161, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 16);
            this.label16.TabIndex = 20;
            this.label16.Text = "品名/商品名";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1180, 229);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1174, 145);
            this.panel2.TabIndex = 63;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.Color.Navy;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(1174, 145);
            this.myDataGrid1.TabIndex = 60;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
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
            this.col_批次号,
            this.col_kcid,
            this.批号,
            this.效期,
            this.库位,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.申请量,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn19,
            this.现有库存});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "品名";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // 商品名
            // 
            this.商品名.Format = "";
            this.商品名.FormatInfo = null;
            this.商品名.HeaderText = "商品名";
            this.商品名.NullText = "";
            this.商品名.Width = 150;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "规格";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "厂家";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // col_批次号
            // 
            this.col_批次号.Format = "";
            this.col_批次号.FormatInfo = null;
            this.col_批次号.HeaderText = "批次号";
            this.col_批次号.Width = 135;
            // 
            // col_kcid
            // 
            this.col_kcid.Format = "";
            this.col_kcid.FormatInfo = null;
            this.col_kcid.HeaderText = "kcid";
            this.col_kcid.Width = 0;
            // 
            // 批号
            // 
            this.批号.Format = "";
            this.批号.FormatInfo = null;
            this.批号.HeaderText = "批号";
            this.批号.NullText = "";
            this.批号.Width = 70;
            // 
            // 效期
            // 
            this.效期.Format = "";
            this.效期.FormatInfo = null;
            this.效期.HeaderText = "效期";
            this.效期.NullText = "";
            this.效期.ReadOnly = true;
            this.效期.Width = 0;
            // 
            // 库位
            // 
            this.库位.Format = "";
            this.库位.FormatInfo = null;
            this.库位.HeaderText = "库位";
            this.库位.NullText = "";
            this.库位.Width = 70;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "批发价";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "零售价";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 60;
            // 
            // 申请量
            // 
            this.申请量.Format = "";
            this.申请量.FormatInfo = null;
            this.申请量.HeaderText = "申请量";
            this.申请量.NullText = "";
            this.申请量.ReadOnly = true;
            this.申请量.Width = 50;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "数量";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 50;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "单位";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 40;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "批发金额";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 70;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "零售金额";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.Width = 70;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "批零差额";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 70;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "进价";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 60;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "进货金额";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 70;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "货号";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.ReadOnly = true;
            this.dataGridTextBoxColumn16.Width = 75;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "CJID";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.Width = 0;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "DWBL";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "kwid";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.ReadOnly = true;
            this.dataGridTextBoxColumn17.Width = 0;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "ID";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.ReadOnly = true;
            this.dataGridTextBoxColumn18.Width = 0;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "库存量";
            this.dataGridTextBoxColumn19.Width = 75;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkhzdy);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.butclose);
            this.panel1.Controls.Add(this.butprint);
            this.panel1.Controls.Add(this.butsave);
            this.panel1.Controls.Add(this.butnew);
            this.panel1.Controls.Add(this.butsh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 64);
            this.panel1.TabIndex = 62;
            // 
            // chkhzdy
            // 
            this.chkhzdy.AutoSize = true;
            this.chkhzdy.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkhzdy.Location = new System.Drawing.Point(718, 13);
            this.chkhzdy.Name = "chkhzdy";
            this.chkhzdy.Size = new System.Drawing.Size(108, 16);
            this.chkhzdy.TabIndex = 75;
            this.chkhzdy.Text = "打印时汇总批次";
            this.chkhzdy.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 24);
            this.button1.TabIndex = 74;
            this.button1.Text = "模似出库";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(624, 8);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(88, 24);
            this.butclose.TabIndex = 59;
            this.butclose.Text = "关闭(&Q)";
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butprint
            // 
            this.butprint.Enabled = false;
            this.butprint.Location = new System.Drawing.Point(536, 8);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 24);
            this.butprint.TabIndex = 58;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(448, 8);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(88, 24);
            this.butsave.TabIndex = 57;
            this.butsave.Text = "保存(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(360, 8);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(88, 24);
            this.butnew.TabIndex = 56;
            this.butnew.Text = "新单号(&N)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // butsh
            // 
            this.butsh.Location = new System.Drawing.Point(272, 8);
            this.butsh.Name = "butsh";
            this.butsh.Size = new System.Drawing.Size(88, 24);
            this.butsh.TabIndex = 61;
            this.butsh.Text = "审核(&H)";
            this.butsh.Visible = false;
            this.butsh.Click += new System.EventHandler(this.butsh_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 389);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1180, 24);
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
            // 现有库存
            // 
            this.现有库存.Format = "";
            this.现有库存.FormatInfo = null;
            this.现有库存.HeaderText = "现有库存";
            this.现有库存.ReadOnly = true;
            this.现有库存.Width = 75;
            // 
            // Frmypck
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1180, 413);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Frmypck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "药品出库";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmypck_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frmypptrk_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion


        private void Frmypck_Load(object sender, System.EventArgs e)
        {
            try
            {
                //YFFun.AddRckfs(_menuTag.FunctionTag.Trim(),this.cmbrckfs);

                dateTimePicker1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 00:00:00");
                dateTimePicker2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

                this.dtprq.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                //初始化
                FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");

                FunctionControlEnable(_menuTag.Function_Name.Trim());

                //系统控制

                if (s.管理批号 == false)
                {
                    txtph.Enabled = false;
                    this.批号.Width = 0;
                    this.效期.Width = 0;
                    this.butph.Enabled = false;
                    if (bpcgl)
                    {
                        this.butph.Enabled = true;
                    }
                }
                if (s.库位管理 == false)
                {
                    txtkw.Enabled = false;
                    this.库位.Width = 0;
                }

                SystemCfg cfg8056 = new SystemCfg(8056);//调进货价
                if (cfg8056.Config == "1")
                {
                    btjhj = true;
                }

                if (_menuTag.FunctionTag == "030")//个人借药
                {
                    lblghdw.Text = "借药人";
                }

                //判断是否为门诊一楼白班药房（424）和门诊药房（后湖）207，是则显示一键调拨
                if (InstanceForm.BCurrentDept.DeptId == 424 || InstanceForm.BCurrentDept.DeptId == 207 || InstanceForm.BCurrentDept.DeptId == 142)
                {
                    groupBox4.Visible = true;
                    this.现有库存.Width = 75;
                }
                else
                {
                    groupBox4.Visible = false;
                    this.现有库存.Width = 0;
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

        }

        private void FunctionControlEnable(string functionName)
        {
            switch (functionName)
            {
                case "Fun_ts_yf_ypck_cfbl":
                    lblghdw.Visible = false;
                    txtghdw.Visible = false;
                    txtghdw.Tag = InstanceForm.BCurrentDept.DeptId;
                    txtghdw.Text = InstanceForm.BCurrentDept.DeptName;
                    this.statusBarPanel4.Text = "按 F4 修改处方副数";
                    this.button1.Tag = "1";
                    break;
                case "Fun_ts_yf_ypck_tk":
                    lblghdw.Text = "药库名称";
                    this.申请量.Width = 0;
                    break;
                case "Fun_ts_yf_ypck":
                    lblghdw.Text = "药房名称";
                    break;
                default:
                    break;
            }
        }

        #region 界面控制事件
        // 回车跳至下一个文本
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                if (_menuTag.Function_Name == "Fun_ts_yf_ypck_cfbl") //住院处方补录
                {
                    if (control.Name == "txtypsl")
                    {
                        cmbdw.Focus();
                        return;
                    }
                    if (control.Name == "cmbdw")
                    {
                        txtph.Focus();
                        return;
                    }
                }

                if (bfpkcph && bpcgl)
                {
                    if (control.Name == txtypsl.Name)
                    {
                        butadd.Focus();
                        return;
                    }
                }

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
                    this.groupBox1.Controls[i].Enabled = true;
                }
            }

            this.lbldjh.Text = "";
            this.groupBox1.Tag = null;
            this.dtprq.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            this.dtprq.Enabled = true;

            FunctionControlEnable(_menuTag.Function_Name.Trim());

        }


        private void csgroupbox2()
        {
            for (int i = 0; i <= this.groupBox2.Controls.Count - 1; i++)
            {
                if (this.groupBox2.Controls[i].GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    this.groupBox2.Controls[i].Text = "";
                    this.groupBox2.Controls[i].Tag = "0";
                    this.groupBox2.Controls[i].Enabled = true;
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
            this.lblpfje.Text = "";
            this.lbllsje.Text = "";
            this.lblkc.Text = "";
            this.lblxq.Text = "";
            this.lbljhj.Text = "";
            this.lbljhje.Text = "";
            this.lbljhj.Tag = "";
            this.cmbdw.DataSource = null;
            this.cmbdw.Enabled = true;
            this.txtypdm.Focus();
        }


        //输入框控制事件
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "") { control.Text = ""; control.Tag = "0"; }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == ""))) { } else { return; }

            try
            {

                System.Drawing.Point point = new System.Drawing.Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 1:
                        if (control.Text.Trim() == "") return;
                        Yp.frmShowCard_funName(sender, ShowCardType.单据往来科室, _menuTag.Function_Name, point, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true);
                        break;
                    case 4:

                        if (control.Text.Trim() == "") return;
                        if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_ypck_wyylyd" && _menuTag.Function_Name != "Fun_ts_yf_ypck_tk")
                            Yp.frmShowCard(sender, ShowCardType.库存药品, _menuTag.Function_Name.Trim(), 0, point, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                        else if (_menuTag.Function_Name == "Fun_ts_yf_ypck_tk")
                            Yp.frmShowCard(sender, ShowCardType.库存药品_不区分禁用, _menuTag.Function_Name.Trim(), 0, point, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                        else
                            Yp.frmShowCard(sender, ShowCardType.库存药品_外用药品, _menuTag.Function_Name.Trim(), 0, point, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                        if (Convertor.IsNull(control.Tag, "0") != "0") this.SelectNextControl((Control)sender, true, false, true, true); else return;

                        Ypcj cj = new Ypcj(Convert.ToInt32(control.Tag), InstanceForm.BDatabase);
                        FindRecord(cj.CJID, 0);
                        csgroupbox2();
                        if (butsave.Enabled == true) butadd.Enabled = true;

                        this.csyp(cj.GGID, cj.CJID);
                        this.SelectNextControl((Control)sender, true, false, true, true);


                        break;
                    case 7:
                        this.txtph.Text = "";
                        this.butph_Click(sender, e);
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
                    beginrow = i + 1;
                    DataRow row = tb.NewRow();
                    Getrow(row);
                    return;

                }

            }
        }
        //数量输入事件
        private void txtypsl_Leave(object sender, System.EventArgs e)
        {
            try
            {
                if (Convertor.IsNumeric(txtypsl.Text) == false) txtypsl.Text = "";
                if (txtypsl.Text.Trim() != "-" && txtypsl.Text.Trim() != ".")
                {
                    decimal sumpfje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text, "0"));
                    this.lblpfje.Text = sumpfje.ToString("0.00");
                    decimal sumlsje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text, "0"));
                    this.lbllsje.Text = sumlsje.ToString("0.00");
                    decimal sumjhje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text, "0"));
                    this.lbljhje.Text = sumjhje.ToString("0.00");

                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
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
                //if (cmbdw.SelectedValue.GetType().ToString()!="System.Int32") return;
                int dwbl = Convert.ToInt32(cmbdw.SelectedValue);
                this.lblkc.Text = Yp.SeekKcZh(dwbl, Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag, "0")), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase).ToString("0.000");

                decimal ypsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                decimal pfj = Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Tag, "0")) / dwbl;
                pfj = Convert.ToDecimal(pfj.ToString("0.0000"));
                this.lblpfj.Text = pfj.ToString("0.0000");
                decimal lsj = Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Tag, "0")) / dwbl;
                lsj = Convert.ToDecimal(lsj.ToString("0.0000"));
                this.lbllsj.Text = lsj.ToString("0.0000");
                decimal pfje = pfj * ypsl;
                this.lblpfje.Text = pfje.ToString("0.00");
                decimal lsje = lsj * ypsl;
                this.lbllsje.Text = lsje.ToString("0.00");

                decimal jhj = Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Tag, "0")) / dwbl;
                this.lbljhj.Text = jhj.ToString("0.0000");
                decimal jhje = Convert.ToDecimal(jhj * ypsl);
                this.lbljhje.Text = jhje.ToString("0.00");


            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        //窗体键盘事件
        private void Frmypptrk_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyCode) == 112)
            {
                this.butph_Click(sender, e);
            }

            if (Convert.ToInt32(e.KeyCode) == 115)
            {
                this.button1_Click(sender, e);
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
                this.lbljhj.Text = "";
                this.lbljhj.Tag = "";
                this.lbljhje.Text = "";

                if (btjhj)
                {
                    this.lbljhj.Text = ydcj.MRJJ.ToString();
                    this.lbljhj.Tag = ydcj.MRJJ;
                }

                Yp.AddCmbDW(InstanceForm.BCurrentDept.DeptId, ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
                this.cmbdw.SelectedIndex = 0;
                this.lblkc.Text = Yp.SeekKcZh(Convert.ToInt32(this.cmbdw.SelectedValue), ydcj.CJID, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase).ToString("0.000");


            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        //填充行
        private void Fillrow(System.Data.DataRow row, List<DataRow> lstRow)
        {
            YpConfig s = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

            #region  验证输入
            if (Convert.ToInt32(this.lblypmc.Tag) == 0)
            {
                MessageBox.Show("没有可添加的药品");
                return;
            }

            if (Convertor.IsNull(this.txtypsl.Text, "0") == "0")
            {
                MessageBox.Show("请输入药品数量");
                return;
            }

            if (!bfpkcph) //如果不自动分配批次 
            {
                if (txtph.Text.Trim() == "" && s.管理批号 == true)
                {
                    MessageBox.Show("请输入药品批号");
                    return;
                }
            }

            if (Convertor.IsNumeric(txtypsl.Text) == true)
            {
                if (new SystemCfg(8022).Config.Contains(_menuTag.FunctionTag.ToString()) == true && Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0")) < 0)
                {
                    MessageBox.Show("系统设定不能输入负数");
                    return;
                }
                //if (bpcgl)
                //{
                //    if (Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0")) < 0)
                //        MessageBox.Show("不能输入负数！进行批次管理");
                //}
            }
            #endregion

            #region 提示重复添加
            System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
            decimal ypsl = 0;
            int cjid = Convert.ToInt32(this.lblypmc.Tag.ToString());
            int xdwbl = 0;
            System.Data.DataTable tbkc = Yp.Selectkc(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(this.lblypmc.Tag), Yp.Seek_kcmx_table(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase), InstanceForm.BDatabase);
            if (tbkc.Rows.Count != 0)
                xdwbl = Convert.ToInt32(tbkc.Rows[0]["dwbl"]);
            else
                xdwbl = 0;

            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (cjid.ToString() == Convertor.IsNull(tb.Rows[i]["cjid"], "0") && Convertor.IsNull(this.txtph.Text.Trim(), "无批号") == tb.Rows[i]["批号"].ToString().Trim())
                    ypsl = ypsl + Convert.ToDecimal(tb.Rows[i]["数量"]) * xdwbl / Convert.ToInt32(tb.Rows[i]["dwbl"]);
            }
            if (Convertor.IsNull(row["数量"], "") != "")
                ypsl = ypsl - Convert.ToDecimal(Convertor.IsNull(row["数量"], "0")) * xdwbl / Convert.ToDecimal(Convertor.IsNull(row["dwbl"], "0"));
            ypsl = ypsl + Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0")) * xdwbl / Convert.ToInt32(this.cmbdw.SelectedValue);


            //if (YpClass.FunBase.IsExistsInGrid(new object[] { cjid, row["批次号"] }, tb, new string[] { "cjid", "批次号" }))
            //{
            //    throw new Exception( "添加的药品已经存在，不能重复添加"   );
            //}

            #endregion

            if (!bfpkcph || this.txtpch.Text != "") //不分配批次库存
            {
                #region 验证批次
                Guid t_kcid = Guid.Empty;
                if (Convertor.IsNull(txtph.Tag.ToString(), "0") != "0")
                {
                    t_kcid = new Guid(txtph.Tag.ToString());
                }
                if (bpcgl)
                {
                    if (t_kcid == Guid.Empty || t_kcid == null)
                    {
                        MessageBox.Show("请选择批次！");
                    }
                }
                #endregion

                #region 判断批次库存量
                if (Yp.BYfOutKc(_menuTag.FunctionTag.Trim(), Convert.ToInt32(this.lblypmc.Tag), Convertor.IsNull(this.txtph.Text.Trim(), "无批号"), ypsl, xdwbl, InstanceForm.BCurrentDept.DeptId, Convert.ToDecimal(lbljhj.Tag), InstanceForm.BDatabase
                  , t_kcid) == true)
                {
                    if (bpcgl) //进行批次库存管理
                    {
                        MessageBox.Show("批次库存不足！");
                        return;
                    }
                    if (s.强制控制库存 == true)
                    { MessageBox.Show("当前批次库存不够,请重新确认数量"); return; }
                    else
                    { if (MessageBox.Show(this, "当前批次库存不够，您确认继续吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return; }
                }
                #endregion

                #region 填充datarow
                row["序号"] = tb.Rows.Count + 1;
                row["商品名"] = this.lblypmc.Text.Trim();
                row["品名"] = this.lblpm.Text.Trim();
                row["规格"] = this.lblgg.Text.Trim();
                row["厂家"] = this.lblcj.Text.Trim();
                row["批次号"] = this.txtpch.Text; //批次号
                row["kcid"] = this.txtph.Tag.ToString();//批号
                row["批号"] = Convertor.IsNull(this.txtph.Text.Trim(), "无批号");
                row["库位"] = this.txtkw.Text.ToString();
                row["效期"] = this.lblxq.Text.Trim();
                row["批发价"] = this.lblpfj.Text.Trim();
                row["零售价"] = this.lbllsj.Text.Trim();
                row["数量"] = this.txtypsl.Text.Trim();
                row["单位"] = this.cmbdw.Text.Trim();
                decimal sumpfje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(), "0"));
                decimal sumlsje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text.Trim(), "0"));
                decimal sumplce = sumlsje - sumpfje;
                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_ypck_cfbl")
                {
                    row["批发金额"] = sumpfje.ToString("0.000");
                    row["零售金额"] = sumlsje.ToString("0.000");
                    row["批零差额"] = sumplce.ToString("0.000");
                }
                else
                {
                    row["批发金额"] = sumpfje.ToString("0.00");
                    row["零售金额"] = sumlsje.ToString("0.00");
                    row["批零差额"] = sumplce.ToString("0.00");
                }

                //进价、进货金额
                decimal sumjhje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text.Trim(), "0"));
                row["进价"] = Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text, "0"));
                row["进货金额"] = sumjhje.ToString("0.00");

                row["货号"] = this.lblhh.Text.Trim();
                row["CJID"] = this.lblypmc.Tag.ToString();
                row["DWBL"] = Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
                row["kwid"] = Convertor.IsNull(this.txtkw.Tag, "0");
                #endregion
            }
            else//自动分配批次库存
            {
                if (lstRow != null) //添加时
                {
                    #region
                    decimal t_sl = Convert.ToDecimal(Convertor.IsNull(txtypsl.Text, "0"));
                    int t_dwbl = Convert.ToInt32(Convertor.IsNull(cmbdw.SelectedValue.ToString(), "1"));
                    int t_deptid = Convert.ToInt32(Convertor.IsNull(InstanceForm.BCurrentDept.DeptId, "0"));
                    string t_zxdw = cmbdw.SelectedText;
                    //判断药房库存明细是否足够
                    if (!Yp.BYfOutKcmx(_menuTag.FunctionTag, cjid, t_sl, t_dwbl, Convert.ToInt64(t_deptid), InstanceForm.BDatabase))
                    {
                        System.Data.DataTable t_kcph = Yppc.FpKcph(cjid, t_sl, t_zxdw, t_dwbl, t_deptid, InstanceForm.BDatabase);
                        foreach (DataRow t_row in t_kcph.Rows)
                        {
                            DataRow m_row = ((System.Data.DataTable)myDataGrid1.DataSource).NewRow();
                            m_row["序号"] = tb.Rows.Count + 1;
                            m_row["商品名"] = this.lblypmc.Text.Trim();
                            m_row["品名"] = this.lblpm.Text.Trim();
                            m_row["规格"] = this.lblgg.Text.Trim();
                            m_row["厂家"] = this.lblcj.Text.Trim();
                            m_row["批号"] = t_row["ypph"].ToString();
                            m_row["kcid"] = t_row["kcid"];
                            m_row["批次号"] = t_row["yppch"];
                            m_row["效期"] = t_row["ypxq"];
                            m_row["库位"] = "";
                            m_row["批发价"] = this.lblpfj.Text.Trim();
                            m_row["零售价"] = this.lbllsj.Text.Trim();
                            //m_row["总库存"] = Convert.ToDecimal(Convertor.IsNull(this.lblkc.Text, "0"));
                            m_row["数量"] = Convert.ToDecimal(t_row["kcl"].ToString());
                            m_row["单位"] = this.cmbdw.Text.Trim();
                            decimal sumpfje = Convert.ToDecimal(Convert.ToDecimal(t_row["kcl"]).ToString()) * Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(), "0"));
                            decimal sumlsje = Convert.ToDecimal(Convert.ToDecimal(t_row["kcl"]).ToString()) * Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text.Trim(), "0"));
                            decimal sumplce = sumlsje - sumpfje;
                            m_row["批发金额"] = sumpfje.ToString("0.00");
                            m_row["零售金额"] = sumlsje.ToString("0.00");
                            m_row["批零差额"] = sumplce.ToString("0.00");

                            decimal sumjhje = Convert.ToDecimal(t_row["jhj"].ToString()) * Convert.ToDecimal(t_row["kcl"].ToString());
                            m_row["进价"] = Convert.ToDecimal(t_row["jhj"].ToString());
                            m_row["进货金额"] = sumjhje.ToString("0.00");

                            m_row["货号"] = this.lblhh.Text.Trim();
                            m_row["CJID"] = this.lblypmc.Tag.ToString();
                            m_row["DWBL"] = Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
                            m_row["kwid"] = Convertor.IsNull(this.txtkw.Tag, "0");
                            lstRow.Add(m_row);
                        }
                    }
                    else
                    {
                        MessageBox.Show("库存数量不足,请重新输入数量！");
                    }
                    #endregion
                }
                else //修改时
                {
                    #region 判断批次库存量
                    if (Yp.BYfOutKc(_menuTag.FunctionTag.Trim(), cjid, Convertor.IsNull(this.txtph.Text.Trim(), "无批号"), ypsl, xdwbl, Convert.ToInt32(Convertor.IsNull(InstanceForm.BCurrentDept.DeptId, "0")), Convert.ToDecimal(Convertor.IsNull(lbljhj.Tag, "0")),
                        InstanceForm.BDatabase, new Guid(Convertor.IsNull(txtph.Tag, Guid.Empty.ToString()))) == true)
                    {
                        if (s.强制控制库存 == true) { MessageBox.Show("当前批次库存不够,请重新确认数量"); return; }
                        else
                        { if (MessageBox.Show(this, "当前批次库存不够，您确认继续吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return; }
                        if (bpcgl) //进行批次库存管理
                        {
                            MessageBox.Show("批次库存不足！");
                            return;
                        }
                    }
                    #endregion

                    #region 填充datarow
                    row["序号"] = tb.Rows.Count + 1;
                    row["商品名"] = this.lblypmc.Text.Trim();
                    row["品名"] = this.lblpm.Text.Trim();
                    row["规格"] = this.lblgg.Text.Trim();
                    row["厂家"] = this.lblcj.Text.Trim();
                    row["批号"] = Convertor.IsNull(this.txtph.Text.Trim(), "无批号");

                    row["kcid"] = txtph.Tag;
                    row["批次号"] = txtpch.Text;

                    row["效期"] = this.lblxq.Text.Trim();
                    row["库位"] = this.txtkw.Text.ToString();
                    row["批发价"] = this.lblpfj.Text.Trim();
                    row["零售价"] = this.lbllsj.Text.Trim();
                    //row["总库存"] = Convert.ToDecimal(Convertor.IsNull(this.lblkc.Text, "0"));
                    //			row["申请量"]=0;
                    row["数量"] = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                    row["单位"] = this.cmbdw.Text.Trim();
                    decimal sumpfje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lblpfj.Text.Trim(), "0"));
                    decimal sumlsje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbllsj.Text.Trim(), "0"));
                    decimal sumplce = sumlsje - sumpfje;

                    row["批发金额"] = sumpfje.ToString("0.00");
                    row["零售金额"] = sumlsje.ToString("0.00");
                    row["批零差额"] = sumplce.ToString("0.00");

                    //进价、进货金额
                    decimal sumjhje = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0")) * Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text.Trim(), "0"));
                    row["进价"] = Convert.ToDecimal(Convertor.IsNull(this.lbljhj.Text, "0"));
                    row["进货金额"] = sumjhje.ToString("0.00");

                    row["货号"] = this.lblhh.Text.Trim();
                    row["CJID"] = this.lblypmc.Tag.ToString();
                    row["DWBL"] = Convert.ToInt32(this.cmbdw.SelectedValue).ToString();
                    row["kwid"] = Convertor.IsNull(this.txtkw.Tag, "0");
                    #endregion
                }
            }

            SortRowNO();
        }


        //求和金额
        private void Sumje()
        {
            try
            {
                decimal sumjhje = 0;
                decimal sumpfje = 0;
                decimal sumlsje = 0;
                decimal sumplce = 0;
                decimal sumjlce = 0;
                System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    sumjhje = sumjhje + Convert.ToDecimal(tb.Rows[i]["进货金额"]);
                    sumpfje = sumpfje + Convert.ToDecimal(tb.Rows[i]["批发金额"]);
                    sumlsje = sumlsje + Convert.ToDecimal(tb.Rows[i]["零售金额"]);
                }
                sumplce = sumlsje - sumpfje;
                sumjlce = sumlsje - sumjhje;
                //				this.statusBar1.Panels[0].Text ="批发金额: "+sumpfje.ToString("0.00");
                //				this.statusBar1.Panels[1].Text ="零售金额: "+sumlsje.ToString("0.00");
                //				this.statusBar1.Panels[2].Text ="批零差额: "+sumplce.ToString("0.00");

                this.statusBar1.Panels[0].Text = "进货金额: " + sumjhje.ToString("0.00");
                this.statusBar1.Panels[1].Text = "零售金额: " + sumlsje.ToString("0.00");
                this.statusBar1.Panels[2].Text = "进零差额: " + sumjlce.ToString("0.00");
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        //获取一行
        private void Getrow(DataRow row)
        {
            int cjid = Convert.ToInt32(Convertor.IsNull(row["cjid"], "0"));
            Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
            this.lblypmc.Text = row["商品名"].ToString();
            this.lblpm.Text = row["品名"].ToString();
            this.lblypmc.Tag = row["CJID"].ToString();
            this.lblgg.Text = row["规格"].ToString();
            this.lblcj.Text = row["厂家"].ToString();
            this.txtph.Text = row["批号"].ToString();

            this.txtph.Tag = row["kcid"];
            this.txtpch.Text = row["批次号"].ToString();

            this.lblxq.Text = row["效期"].ToString();
            this.txtkw.Text = row["库位"].ToString();
            this.txtkw.Tag = row["kwid"].ToString();
            this.lblpfj.Text = row["批发价"].ToString();
            this.lblpfj.Tag = ydcj.PFJ.ToString();
            this.lbllsj.Text = row["零售价"].ToString();
            this.lbllsj.Tag = ydcj.LSJ.ToString();
            this.lblkc.Text = Yp.SeekKcZh(1, ydcj.CJID, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase).ToString("0.000");
            this.txtypsl.Text = row["数量"].ToString();
            Yp.AddCmbDW(InstanceForm.BCurrentDept.DeptId, ydcj.GGID, cjid, this.cmbdw, InstanceForm.BDatabase);
            this.cmbdw.Text = row["单位"].ToString();
            this.lblpfje.Text = row["批发金额"].ToString();
            this.lbllsje.Text = row["零售金额"].ToString();
            this.lblhh.Text = row["货号"].ToString();

            this.lbljhj.Text = row["进价"].ToString();
            this.lbljhj.Tag = Convert.ToDecimal(Convertor.IsNull(row["进价"], "0")) * Convert.ToDecimal(Convertor.IsNull(row["dwbl"], "0"));
            this.lbljhje.Text = row["进货金额"].ToString();

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
                string ssql = "select id,deptid,WLDW,bz,sqdh,rq,djh,sdjh,shbz from yf_dj where id='" + id + "' union all select id,deptid,WLDW,bz,sqdh,rq,djh,sdjh,shbz from yf_dj_h where id='" + id + "'";
                System.Data.DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                this.groupBox1.Tag = tb.Rows[0]["id"].ToString();
                this.txtghdw.Tag = tb.Rows[0]["WLDW"].ToString();
                this.txtghdw.Text = Yp.SeekDeptName(Convert.ToInt32(tb.Rows[0]["wldw"]), InstanceForm.BDatabase);
                this.txtbz.Text = tb.Rows[0]["bz"].ToString();

                this.dtprq.Value = Convert.ToDateTime(tb.Rows[0]["rq"]);
                long djh = Convert.ToInt64(tb.Rows[0]["djh"]);
                this.lbldjh.Text = djh.ToString("00000000");

                int intDeptid = 0;
                //门诊一楼白班药房（424）,门诊一楼夜间药房(418)和门诊药房（后湖）207,门诊夜间药房（后湖）(669)
                if (InstanceForm.BCurrentDept.DeptId == 424)
                {
                    intDeptid = 418;
                }
                else if (InstanceForm.BCurrentDept.DeptId == 207)
                {
                    intDeptid = 669;
                }

                //modify by :jchl(添加kcid/yppch)
                if (groupBox4.Visible == false)
                {
                    ssql = string.Format(@"select 0   序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,dbo.fun_yp_sccj(b.sccj) 厂家,
                 a.ypph 批号,dbo.fun_yp_KWMC(b.ggid,A.DEPTID) 库位,a.ypxq 效期, a.pfj 批发价,a.lsj 零售价,
                 sqsl 申请量,ypsl 数量,a.ypdw 单位, pfje 批发金额,lsje 零售金额,(lsje-pfje) 批零差额,
                 a.jhj 进价,jhje 进货金额,b.shh 货号, a.cjid,ydwbl dwbl,a.kwid,a.id,a.kcid,a.yppch 批次号,c.KCL 库存量
                 from yf_djmx a,vi_yp_ypcd b, YF_KCPH c
                 where a.cjid=b.cjid and  a.KCID = c.ID and djid='{0}' and a.deptid={1} order by a.pxxh", id, InstanceForm.BCurrentDept.DeptId);
                }
                else
                {
                    //Modify by zhujh(添加调入药房库存量)
                    ssql = string.Format(@"select 0   序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,dbo.fun_yp_sccj(b.sccj) 厂家,
                     a.ypph 批号,dbo.fun_yp_KWMC(b.ggid,A.DEPTID) 库位,a.ypxq 效期, a.pfj 批发价,a.lsj 零售价,
                     sqsl 申请量,ypsl 数量,a.ypdw 单位, pfje 批发金额,lsje 零售金额,(lsje-pfje) 批零差额,
                     a.jhj 进价,jhje 进货金额,b.shh 货号, a.cjid,ydwbl dwbl,a.kwid,a.id,a.kcid,a.yppch 批次号,c.KCL 库存量,d.KCL 现有库存
                     from yf_djmx a 
                     JOIN vi_yp_ypcd b ON a.cjid=b.cjid
                     JOIN YF_KCPH c ON a.KCID = c.ID
                      LEFT JOIN  yf_kcmx d ON d.CJID =a.CJID AND d.DEPTID={2}     
                     where  djid='{0}' 
                     AND a.deptid={1} order by a.pxxh", id, InstanceForm.BCurrentDept.DeptId, intDeptid);
                }

                System.Data.DataTable tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tbmx.Rows.Count == 0)
                {
                    //ssql="select 0   序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,dbo.fun_yp_sccj(b.sccj) 厂家,a.ypph 批号,dbo.fun_yp_KWMC(b.ggid,A.DEPTID) 库位,ypxq 效期,"+
                    //    " a.pfj 批发价,a.lsj 零售价,sqsl 申请量,ypsl 数量,a.ypdw 单位,"+
                    //    " pfje 批发金额,lsje 零售金额,(lsje-pfje) 批零差额,jhj 进价,jhje 进货金额,b.shh 货号,"+
                    //    " a.cjid,ydwbl dwbl,kwid,a.id,a.kcid,a.yppch 批次号 from yf_djmx_h a,vi_yp_ypcd b  where a.cjid=b.cjid and  djid='" + id + "' and deptid=" + InstanceForm.BCurrentDept.DeptId + " ORDER BY A.pxxh";
                    //modify by :jchl(添加kcid/yppch)
                    if (groupBox4.Visible == false)
                    {
                        ssql = string.Format(@"select 0   序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,dbo.fun_yp_sccj(b.sccj) 厂家,
                         a.ypph 批号,dbo.fun_yp_KWMC(b.ggid,A.DEPTID) 库位,a.ypxq 效期, a.pfj 批发价,a.lsj 零售价,
                         sqsl 申请量,ypsl 数量,a.ypdw 单位, pfje 批发金额,lsje 零售金额,(lsje-pfje) 批零差额,
                         a.jhj 进价,jhje 进货金额,b.shh 货号, a.cjid,ydwbl dwbl,a.kwid,a.id,a.kcid,a.yppch 批次号,c.KCL 库存量
                         from yf_djmx_h a,vi_yp_ypcd b, YF_KCPH c
                         where a.cjid=b.cjid and  a.KCID = c.ID and djid='{0}' and a.deptid={1} order by a.pxxh", id, InstanceForm.BCurrentDept.DeptId);
                    }
                    else
                    {
                        //Modify by zhujh(添加调入药房库存量)
                        ssql = string.Format(@"select 0   序号,B.yppm 品名,b.ypspm 商品名,b.ypgg 规格,dbo.fun_yp_sccj(b.sccj) 厂家,
                         a.ypph 批号,dbo.fun_yp_KWMC(b.ggid,A.DEPTID) 库位,a.ypxq 效期, a.pfj 批发价,a.lsj 零售价,
                         sqsl 申请量,ypsl 数量,a.ypdw 单位, pfje 批发金额,lsje 零售金额,(lsje-pfje) 批零差额,
                         a.jhj 进价,jhje 进货金额,b.shh 货号, a.cjid,ydwbl dwbl,a.kwid,a.id,a.kcid,a.yppch 批次号,c.KCL 库存量,d.KCL 现有库存
                         from yf_djmx_h a 
                         JOIN vi_yp_ypcd b ON a.cjid=b.cjid
                         JOIN YF_KCPH c ON a.KCID = c.ID
                         LEFT JOIN  yf_kcmx d ON d.CJID =a.CJID AND d.DEPTID={2}     
                         where  djid='{0}' 
                         AND a.deptid={1} order by a.pxxh", id, InstanceForm.BCurrentDept.DeptId, intDeptid);
                    }
                    tbmx = InstanceForm.BDatabase.GetDataTable(ssql);
                }

                FunBase.AddRowtNo(tbmx);
                tbmx.TableName = "tbmx";
                this.myDataGrid1.DataSource = tbmx;
                this.myDataGrid1.TableStyles[0].MappingName = "tbmx";

                //this.butnew.Enabled=false;
                this.txtghdw.Enabled = false;

                if (Convert.ToInt32(tb.Rows[0]["shbz"]) == 1)
                {
                    this.cmbrckfs.Enabled = false;
                    this.dtprq.Enabled = false;
                    this.txtbz.Enabled = false;
                    this.txtypdm.Enabled = true;
                    this.txtypsl.Enabled = false;
                    this.cmbdw.Enabled = false;
                    this.txtph.Enabled = false;
                    this.butsave.Enabled = false;
                    this.butadd.Enabled = false;
                    this.butdel.Enabled = false;
                    this.butmodif.Enabled = false;
                    this.butprint.Enabled = true;
                }
                this.Sumje();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }


        public void FillDj_Rksq(Guid djid, int dept_sq)
        {
            try
            {
                System.Data.DataTable tbmx = YF_RKSQ_RKSQMX.YF_RKSQ_CK(djid, InstanceForm.BCurrentDept.DeptId, dept_sq, InstanceForm.BDatabase);
                FunBase.AddRowtNo(tbmx);
                tbmx.TableName = "tbmx";
                this.myDataGrid1.DataSource = tbmx;
                this.myDataGrid1.TableStyles[0].MappingName = "tbmx";
                if (tbmx.Rows.Count > 0)
                {
                    int deptid = dept_sq;
                    this.txtghdw.Text = Yp.SeekDeptName(deptid, InstanceForm.BDatabase);
                    this.txtghdw.Tag = deptid;
                    this.txtghdw.Enabled = false;
                }
                this.Sumje();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

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
                List<DataRow> lstRow = new List<DataRow>();
                this.Fillrow(row, lstRow);

                if (lstRow.Count <= 0)
                {
                    if (YpClass.FunBase.IsExistsInGrid(new object[] { row["cjid"], Convertor.IsNull(row["批次号"], "") }, tb, new string[] { "cjid", "批次号" }))
                    {
                        MessageBox.Show("同一批次号的药品已经存在，不能重复添加", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (row["货号"] != null && row["货号"].ToString().Trim() != "")
                    {
                        tb.Rows.Add(row);
                    }
                }
                else
                {
                    foreach (DataRow m_row in lstRow)
                    {
                        if (YpClass.FunBase.IsExistsInGrid(new object[] { m_row["cjid"], Convertor.IsNull(m_row["批次号"], "") }, tb, new string[] { "cjid", "批次号" }))
                        {
                            MessageBox.Show("同一批次号的药品已经存在，不能重复添加", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    foreach (DataRow m_row in lstRow)
                    {
                        if (row["货号"] != null && m_row["货号"].ToString().Trim() != "")
                        {
                            tb.Rows.Add(m_row);
                        }
                    }
                }


                this.Sumje();
                if (tb.Rows.Count > 0)
                {
                    this.myDataGrid1.Select(tb.Rows.Count - 1);
                    this.myDataGrid1.CurrentCell = new DataGridCell(tb.Rows.Count - 1, 3);
                }
                this.csgroupbox2();
                this.butadd.Enabled = true;

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
            this.txtghdw.Enabled = true;
            this.butadd.Enabled = true;
            this.butdel.Enabled = true;
            this.butmodif.Enabled = true;
            this.butsave.Enabled = true;
            this.butprint.Enabled = false;
            this.cmbrckfs.Focus();
            _Sqdh = 0;//将申请单号置零
        }


        //保存事件
        private void butsave_Click(object sender, System.EventArgs e)
        {
            if (Yp.是否药库(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) == true)
            {
                MessageBox.Show("请核实您当前登陆的科室是否正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long djh = 0;
            Guid djid = Guid.Empty;
            int err_code = 0;
            string err_text = "";
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            this.butsave.Enabled = false;
            System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
            if (tb.Rows.Count == 0) { MessageBox.Show("没有可保存的记录"); return; };
            Guid log_djid = Guid.Empty;
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                //产生单据号
                djh = this.lbldjh.Text.Trim() == "" ? Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) : Convert.ToInt64(this.lbldjh.Text);

                #region 合计金额
                decimal sumjhje = 0;
                decimal sumpfje = 0;
                decimal sumlsje = 0;
                //				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    sumjhje = sumjhje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"], "0"));
                    sumpfje = sumpfje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发金额"], "0"));
                    sumlsje = sumlsje + Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"], "0"));
                }
                #endregion

                #region 保存单据表头
                int wldw = Convert.ToInt32(Convertor.IsNull(this.txtghdw.Tag, "0"));
                if (_menuTag.FunctionTag.Trim() == "030")
                {
                    wldw = 9999;
                }
                YF_DJ_DJMX.SaveDJ(new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString())),
                    djh,
                    InstanceForm.BCurrentDept.DeptId,
                    _menuTag.FunctionTag.Trim(),
                    wldw,
                    0,
                    this.dtprq.Value.ToShortDateString(),
                    InstanceForm.BCurrentUser.EmployeeId,
                    Convert.ToDateTime(sDate).ToShortDateString(),
                    Convert.ToDateTime(sDate).ToLongTimeString(),
                    "",
                    "",
                    this.txtbz.Text.Trim(),
                    "", 0, _Sqdh, sumjhje, sumpfje, sumlsje, out djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);

                //如果没有成功，抛出异常
                if (err_code != 0) { throw new System.Exception(err_text); }
                #endregion

                #region 保存单据明细

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    YF_DJ_DJMX.SaveDJMX(new Guid(Convertor.IsNull(tb.Rows[i]["id"], Guid.Empty.ToString())),
                        djid,
                        Convert.ToInt32(tb.Rows[i]["cjid"]),
                        Convert.ToInt32(tb.Rows[i]["kwid"]),
                        Convert.ToString(tb.Rows[i]["货号"]),
                        Convert.ToString(tb.Rows[i]["品名"]),
                        Convert.ToString(tb.Rows[i]["商品名"]),
                        Convert.ToString(tb.Rows[i]["规格"]),
                        Convert.ToString(tb.Rows[i]["厂家"]),
                        Convert.ToString(tb.Rows[i]["批号"]),
                        Convert.ToString(tb.Rows[i]["效期"]),
                        0,//kl
                        Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["申请量"], "0")),
                        Convert.ToDecimal(tb.Rows[i]["数量"]),
                        Convert.ToString(tb.Rows[i]["单位"]),
                        Yp.SeekYpdw(Convert.ToString(tb.Rows[i]["单位"]), InstanceForm.BDatabase),
                        Convert.ToInt32(tb.Rows[i]["dwbl"]),
                        Convert.ToDecimal(tb.Rows[i]["进价"]),
                        Convert.ToDecimal(tb.Rows[i]["批发价"]),
                        Convert.ToDecimal(tb.Rows[i]["零售价"]),
                        Convert.ToDecimal(tb.Rows[i]["进货金额"]),
                        Convert.ToDecimal(tb.Rows[i]["批发金额"]),
                        Convert.ToDecimal(tb.Rows[i]["零售金额"]),
                        djh,
                        InstanceForm.BCurrentDept.DeptId,
                        _menuTag.FunctionTag.Trim(),
                        "",
                        "",
                        out err_code, out err_text, InstanceForm.BDatabase, i,
                        tb.Rows[i]["批次号"].ToString(),
                        new Guid(tb.Rows[i]["kcid"].ToString()));
                    if (err_code != 0) { throw new System.Exception(err_text); }
                }
                #endregion

                //更新表头的审核标志
                YF_DJ_DJMX.Shdj(djid, sDate, InstanceForm.BDatabase);

                SystemCfg sysConfig = new SystemCfg(8202);
                if (sysConfig != null && sysConfig.Config == "0")
                {
                    //更新库存
                    YF_DJ_DJMX.AddUpdateKcmx(djid,
                        out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                    if (err_code != 0)
                    {
                        int intIndexStart = err_text.IndexOf('[');
                        int intIndexEnd = err_text.IndexOf(']');
                        string strYpName = err_text.Substring(intIndexStart + 1, intIndexEnd - intIndexStart - 1);
                        DataRow[] dr = tb.Select("品名='" + strYpName + "'");
                        if (dr != null && dr.Length > 0)
                        {
                            err_text = "第" + dr[0]["序号"].ToString() + "行" + err_text;
                        }
                        throw new System.Exception(err_text);
                    }
                }

                //审核申领单据
                if (_Sqdh > 0)
                {
                    YF_RKSQ_RKSQMX.Shdj(_Sqdh, djh, Convert.ToInt32(Convertor.IsNull(this.txtghdw.Tag, "0")), InstanceForm.BCurrentUser.EmployeeId, sDate, InstanceForm.BDatabase, _menuTag.Jgbm);
                }

                #region 产生领药科室的入库待审单据
                System.Data.DataTable tbyjks = Yp.SelectYjks(Convert.ToInt32(this.txtghdw.Tag), InstanceForm.BDatabase);
                if (tbyjks.Rows.Count > 0)
                {
                    if (Convert.ToInt32(tbyjks.Rows[0]["QYBZ"]) == 1)
                    {
                        if (Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]) == InstanceForm._menuTag.Jgbm)
                        {
                            Guid _djid = Guid.Empty;
                            YF_RKSQ_RKSQMX.Add_Ck_RkDjmx(djid, _menuTag.FunctionTag.Trim(), Convert.ToInt32(this.txtghdw.Tag), InstanceForm.BCurrentDept.DeptId, djh, _Sqdh, out _djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                            if (err_code != 0)
                            { throw new System.Exception(err_text); }

                            if (sysConfig != null && sysConfig.Config == "1")
                            {
                                //更新库存
                                YF_DJ_DJMX.AddUpdateKcmx(djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                                if (err_code != 0) { throw new System.Exception(err_text); }

                                YF_DJ_DJMX.Shdj(_djid, sDate, InstanceForm.BDatabase);
                                YF_DJ_DJMX.AddUpdateKcmx(_djid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
                            }
                        }
                        else
                        {
                            //三院数据处理_____保存日志
                            string bz = InstanceForm.BCurrentDept.DeptName + " 办理 " + this.Text + "  往来科室:" + txtghdw.Text;
                            ts.Save_log(ts_HospData_Share.czlx.yp_药房出库单, bz, "yf_dj", "ID", djid.ToString(), InstanceForm._menuTag.Jgbm, Convert.ToInt32(tbyjks.Rows[0]["szjgbm"]), 0, "", out log_djid, InstanceForm.BDatabase);

                        }
                    }
                }
                #endregion

                if (_menuTag.FunctionTag.Trim() == "030")//如果是个人借药 插入借药数据
                {
                    int jyr = 1;//借药人
                    string djbz = "";//单据备注  
                    string ssql = string.Format(@"  insert into yf_jyjm
                                                (
	                                                ID,YWLX,CJID,SHH,YPPM,
	                                                YPSPM,YPGG,SCCJ,SL,JMSL,
	                                                HYSL,YPDW,NYPDW,YDWBL,BZ,
	                                                JYKS,JYR,DJH,DEPTID,DJSJ,
	                                                DJY,SHSJ,SHY,DJBZ,YMXID,
	                                                ZXDJID,ZXDJMXID,PXXH,JHJ,PFJ,
	                                                LSJ,YPPH,YPXQ,YPPCH,KCID,
                                                    BSHBZ 
                                                )
                                                select 
	                                                dbo.FUN_GETGUID(NEWID(),getdate()),'001',CJID,SHH,YPPM, 
	                                                YPSPM,YPGG,SCCJ,YPSL,0,									
	                                                0,YPDW,NYPDW,YDWBL,'借药',								
	                                                0,{2},a.DJH,a.DEPTID,GETDATE(),
	                                                b.DJY,GETDATE(),b.SHY,'{1}',null,
                                                    NEWID(),NEWID(),PXXH,JHJ,PFJ,
                                                    LSJ,YPPH,YPXQ,yppch,KCID,
                                                    1 
                                                from YF_DJMX a  inner join YF_DJ b on a.DJID=b.ID 
                                                 where a.djid='{0}'
                                            ", djid, djbz, jyr);
                    if (InstanceForm.BDatabase.DoCommand(ssql) <= 0)
                    {
                        throw new Exception("插入个人借药信息失败！");
                    }

                }

                //提交事务xSxS
                InstanceForm.BDatabase.CommitTransaction();

                this.groupBox1.Tag = djid;
                this.lbldjh.Text = djh.ToString("00000000");
                this.butadd.Enabled = false;
                this.butdel.Enabled = false;
                this.butmodif.Enabled = false;
                this.butprint.Enabled = true;
                txtghdw.Enabled = false;
                txtbz.Enabled = false;
                dtprq.Enabled = false;

                //已经审核 Modify by jchl
                FillDj(djid, true);

                string str = InstanceForm.BCurrentDept.DeptName + " 向 " + txtghdw.Text.Trim() + " 办理了出库单.单据号:" + djh.ToString();
                if (str.Trim() != "")
                    TrasenFrame.Classes.WorkStaticFun.SendMessage(false, TrasenFrame.Classes.SystemModule.药品系统, "", Convert.ToInt32(Convertor.IsNull(this.txtghdw.Tag, "0")), InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.Name, str);


            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.butsave.Enabled = true;
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            try
            {
                //三院数据处理___执行同步操作 
                string msg = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.yp_药房出库单, InstanceForm.BDatabase);
                if (ty.Bzx == 1 && log_djid != Guid.Empty)
                    ts.Pexec_log(log_djid, InstanceForm.BDatabase, out msg);

                MessageBox.Show(err_text + msg);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string ssql = "delete from YF_djmx where id='" + Convertor.IsNull(datarow["id"], Guid.Empty.ToString()) + "'";
                    InstanceForm.BDatabase.DoCommand(ssql);
                    tb.Rows.Remove(datarow);
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


        //批号按钮事件
        private void butph_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!bpcgl)//不进行批次管理
                {
                    #region
                    int cjid = Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag, "0"));
                    string[] GrdMappingName ={ "行号", "库存量", "单位", "进价", "批号", "效期", "库位", "kwid" };
                    int[] GrdWidth ={ 50, 80, 40, 60, 75, 100, 100, 0 };
                    string[] sfield ={ "", "", "", "", "" };
                    string ssql = "select 0   rowno,kcl,dbo.fun_yp_ypdw(zxdw),jhj,ypph,ypxq,dbo.fun_yp_kwmc(ggid,deptid) kwmc,kwid  from YF_kcph  where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + cjid + " and (bdelete=0 or (bdelete=1 and kcl<>0))";

                    //modify by jchl
                    SystemCfg cfg = new SystemCfg(8051);//批号排序及自动分配批号库存规则，0-先进先出 1-按效期先出 
                    ssql += cfg.Config.Trim().Equals("0") ? " order by DJSJ asc" : " order by ypxq asc";

                    TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, "".Trim(), ssql);
                    System.Drawing.Point point = new System.Drawing.Point(this.Location.X + this.txtph.Location.X, this.Location.Y + this.txtph.Location.Y + this.txtph.Height * 3);
                    f2.Location = point;
                    f2.ShowDialog(this);
                    DataRow row = f2.dataRow;
                    if (row != null)
                    {
                        this.txtph.Text = Convert.ToString(row["ypph"]);
                        this.lblxq.Text = row["ypxq"].ToString().Trim();
                        this.txtkw.Text = row["kwmc"].ToString();
                        this.txtkw.Tag = Convert.ToInt32(row["kwid"]);

                        //进价、进货金额
                        int dwbl = Convert.ToInt32(cmbdw.SelectedValue);
                        decimal ypsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                        decimal jhj = Convert.ToDecimal(Convertor.IsNull(row["jhj"], "0")) / dwbl;
                        jhj = Convert.ToDecimal(jhj.ToString("0.0000"));
                        this.lbljhj.Text = jhj.ToString("0.0000");

                        this.lbljhj.Tag = Convertor.IsNull(row["jhj"], "0").ToString();

                        decimal jhje = jhj * ypsl;
                        this.lbljhje.Text = jhje.ToString("0.00");

                        this.txtkw.Focus();
                        if (butadd.Enabled == true) butadd.Focus(); else butmodif.Focus();
                    }
                    #endregion
                }
                else//进行批次管理
                {
                    #region Modify by :jchl(自动分配则不处理，手动分配批号则弹框)"
                    int cjid = Convert.ToInt32(Convertor.IsNull(this.lblypmc.Tag, "0"));
                    string[] GrdMappingName ={ "行号", "库存量", "单位", "进价", "批次号", "kcid", "批号", "效期", "库位", "kwid" };
                    int[] GrdWidth ={ 50, 80, 40, 60, 95, 0, 75, 100, 100, 0 };
                    string[] sfield ={ "", "", "", "", "" };
                    string ssql = "select 0   rowno,kcl,dbo.fun_yp_ypdw(zxdw),jhj,yppch,id kcid,ypph,ypxq,dbo.fun_yp_kwmc(ggid,deptid) kwmc,kwid  from YF_kcph  where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + cjid + " and (bdelete=0 or (bdelete=1 and kcl<>0))";

                    //modify by jchl
                    SystemCfg cfg = new SystemCfg(8051);//批号排序及自动分配批号库存规则，0-先进先出 1-按效期先出 
                    ssql += cfg.Config.Trim().Equals("0") ? " order by DJSJ asc" : " order by ypxq asc";

                    TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, "".Trim(), ssql);
                    System.Drawing.Point point = new System.Drawing.Point(this.Location.X + this.txtph.Location.X, this.Location.Y + this.txtph.Location.Y + this.txtph.Height * 3);
                    f2.Location = point;
                    f2.ShowDialog(this);
                    DataRow row = f2.dataRow;
                    if (row != null)
                    {
                        //if (!bfpkcph) //配置为不自动填充批号库存时,才启用批次选择
                        //{
                        this.txtph.Tag = row["kcid"].ToString();
                        this.txtpch.Text = row["yppch"].ToString();
                        this.txtph.Text = Convert.ToString(row["ypph"]);
                        this.lblxq.Text = row["ypxq"].ToString().Trim();
                        this.txtkw.Text = row["kwmc"].ToString();
                        this.txtkw.Tag = Convert.ToInt32(row["kwid"]);
                        //进价、进货金额
                        int dwbl = Convert.ToInt32(cmbdw.SelectedValue);
                        decimal ypsl = Convert.ToDecimal(Convertor.IsNull(this.txtypsl.Text, "0"));
                        decimal jhj = Convert.ToDecimal(Convertor.IsNull(row["jhj"], "0")) / dwbl;
                        jhj = Convert.ToDecimal(jhj.ToString("0.0000"));
                        this.lbljhj.Text = jhj.ToString("0.0000");
                        this.lbljhj.Tag = Convertor.IsNull(row["jhj"], "0").ToString();
                        decimal jhje = jhj * ypsl;
                        this.lbljhje.Text = jhje.ToString("0.00");
                        this.txtkw.Focus();
                        if (butadd.Enabled == true) butadd.Focus(); else butmodif.Focus();
                        //}
                    }
                    #endregion
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }

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
                this.Fillrow(row, null);
                this.Sumje();
                DataRow nullrow = tb.NewRow();
                this.Getrow(nullrow);
                this.butadd.Enabled = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.ToString());
            }
        }


        //审核事件
        private void butsh_Click(object sender, System.EventArgs e)
        {
            string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            int err_code = 0;
            string err_text = "";
            Guid djid = new Guid(Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()));
            this.butsh.Enabled = false;

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                YF_DJ_DJMX.Shdj(djid,
                    sDate, InstanceForm.BDatabase);

                YF_DJ_DJMX.AddUpdateKcmx(
                    djid,
                    out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);

                if (err_code != 0) { throw new System.Exception(err_text); }

                InstanceForm.BDatabase.CommitTransaction();

                this.butprint.Enabled = true;
                MessageBox.Show("保存成功");

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                this.butsh.Enabled = true;
                MessageBox.Show(err.Message + err.Source);

            }
        }

        #endregion

        private void butprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
                ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                DataRow myrow;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    myrow = Dset.药品出库单.NewRow();
                    myrow["xh"] = Convert.ToInt32(tb.Rows[i]["序号"]);
                    if (s.打印单据时单据显示商品名 == true)
                        myrow["ypmc"] = Convert.ToString(tb.Rows[i]["商品名"]);
                    else
                        myrow["ypmc"] = Convert.ToString(tb.Rows[i]["品名"]);
                    myrow["ypgg"] = Convert.ToString(tb.Rows[i]["规格"]);
                    myrow["sccj"] = Convert.ToString(tb.Rows[i]["厂家"]);
                    myrow["ypsl"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["数量"], "0"));
                    myrow["ypdw"] = Convert.ToString(tb.Rows[i]["单位"]);
                    myrow["pfj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发价"], "0"));
                    myrow["pfje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批发金额"], "0"));
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售价"], "0"));
                    myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"], "0"));
                    myrow["plce"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["批零差额"], "0"));

                    myrow["jhj"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进价"], "0"));
                    myrow["jhje"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"], "0"));
                    decimal jlce = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["零售金额"], "0")) - Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["进货金额"], "0"));
                    myrow["jlce"] = jlce.ToString("0.00");

                    myrow["ypph"] = Convert.ToString(tb.Rows[i]["批号"]);
                    myrow["ypxq"] = Convert.ToString(tb.Rows[i]["效期"]);
                    myrow["shh"] = Convert.ToString(tb.Rows[i]["货号"]);
                    myrow["kwmc"] = Convert.ToString(tb.Rows[i]["库位"]);

                    //Modify by jchl
                    myrow["kcl"] = Convert.ToString(Convertor.IsNull(tb.Rows[i]["库存量"], "0"));

                    Dset.药品出库单.Rows.Add(myrow);

                }

                string djy = InstanceForm.BDatabase.GetDataTable("select dbo.fun_getempname(djy) from vi_yf_dj where id='" + Convertor.IsNull(this.groupBox1.Tag, Guid.Empty.ToString()) + "'").Rows[0][0].ToString();

                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Text = "DJH";
                parameters[0].Value = this.lbldjh.Text;
                parameters[1].Text = "DJY";
                parameters[1].Value = djy + "                                 打印员:" + InstanceForm.BCurrentUser.Name;
                parameters[2].Text = "GHDW";
                parameters[2].Value = "领药单位:" + txtghdw.Text.Trim();
                parameters[3].Text = "RQ";
                parameters[3].Value = dtprq.Value.ToShortDateString();
                parameters[4].Text = "TITLETEXT";
                parameters[4].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + _menuTag.MenuName;
                parameters[5].Text = "BZ";
                parameters[5].Value = txtbz.Text.Trim();
                parameters[6].Text = "ybps";
                parameters[6].Value = cmbrckfs.Text.Trim() == "是" ? "医保配送" : "";

                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.药品出库单, Constant.ApplicationDirectory + "\\Report\\YF_药品出库单据.rpt", parameters);
                if (f.LoadReportSuccess) f.Show(); else f.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            //////			string ssql="select 0   序号,s_ypspm 品名,s_ypgg 规格,s_sccj 厂家,'无批号' 批号,'1900-01-01' 效期,'' 库位,"+
            //////				" b.pfj 批发价,b.lsj 零售价,0 申请量,cast(round(sum((ypsl-(lsje/a.lsj))),0) as decimal(15,3)) 数量,0 单位,"+
            //////				" 0 批发金额,0 零售金额,0 批零差额,shh 货号,"+
            //////				" a.cjid, ydwbl  dwbl,0 kwid,0 id from yp_ypcjd a,yf_djmx b where abs(abs(lsje)-abs(b.lsj*ypsl))>=0.2 and deptid=1154 and ywlx='020' and a.cjid=b.cjid "+
            //////				" group by shh,a.cjid,s_ypspm,s_ypgg,s_sccj,b.pfj,b.lsj,ydwbl";
            //////			DataTable tbmx=InstanceForm.BDatabase.GetDataTable(ssql);
            //////
            ////////			select a.cjid,s_ypspm,a.pfj,a.lsj,sum(-(ypsl-(lsje/a.lsj))),sum(-(ypsl-(lsje/a.lsj))*a.lsj) from yf_djmx a,yp_ypcjd b
            ////////			where abs(abs(lsje)-abs(a.lsj*ypsl))>=0.4 and deptid=1154 and ywlx='020' and a.cjid=b.cjid
            ////////			group by a.cjid,b.s_ypspm,a.pfj,a.lsj order by cjid
            //////
            //////			tbmx.TableName="tbmx";
            //////			this.myDataGrid1.DataSource=tbmx;
            //////			this.myDataGrid1.TableStyles[0].MappingName ="tbmx";
            //////			this.Sumje();

            if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_ypck_cfbl")
            {
                return;
            }

            if (this.butsave.Enabled == false)
            {
                MessageBox.Show("不正确的操作,这个处方已被保存");
                return;
            }
            int cfts = 1;
            string ycfts = this.button1.Tag.ToString();

            TrasenFrame.Forms.DlgInputBox f = new TrasenFrame.Forms.DlgInputBox(ycfts, "请输入该副处方的副数", "处方副数 ");
            f.NumCtrl = true;
            f.ShowDialog();
            if (TrasenFrame.Forms.DlgInputBox.DlgResult == true) cfts = Convert.ToInt32(TrasenFrame.Forms.DlgInputBox.DlgValue); else return;

            System.Data.DataTable tb = (System.Data.DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                tb.Rows[i]["数量"] = (Convert.ToDecimal(tb.Rows[i]["数量"]) / Convert.ToInt32(ycfts)) * (cfts);
                decimal sumpfje = Convert.ToDecimal(Convert.ToDecimal(tb.Rows[i]["数量"])) * Convert.ToDecimal(Convert.ToDecimal(tb.Rows[i]["批发价"]));
                tb.Rows[i]["批发金额"] = sumpfje.ToString("0.000");
                decimal sumlsje = Convert.ToDecimal(Convert.ToDecimal(tb.Rows[i]["数量"])) * Convert.ToDecimal(Convert.ToDecimal(tb.Rows[i]["零售价"]));
                tb.Rows[i]["零售金额"] = sumlsje.ToString("0.000");
                decimal sumplce = sumlsje - sumpfje;
                tb.Rows[i]["批零差额"] = sumplce.ToString("0.000");
            }

            this.button1.Tag = cfts;
            this.Sumje();
        }


        private void btn_Import_Click(object sender, EventArgs e)
        {
            #region 注释代码
            /*
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开(Open)";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//为了获取特定的系统文件夹，可以使用System.Environment类的静态方法GetFolderPath()。该方法接受一个Environment.SpecialFolder枚举，其中可以定义要返回路径的哪个系统目录
            ofd.Filter = "excel2003 files (*.xls)|*.xls|excel2007 files (*.xlsx)|*.xlsx";
            ofd.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true;  //验证路径有效性
            ofd.CheckPathExists = true; //验证文件有效性
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = PubStaticFun.WaitCursor();
                    DataTable gridTable = myDataGrid1.DataSource as DataTable;
                    gridTable.BeginInit();
                    Workbook workbook = new Workbook();
                    workbook.Open(ofd.FileName);
                    Cells cells = workbook.Worksheets[0].Cells;
                    for (int i = 2; i < cells.MaxDataRow + 1; i++)
                    {
                        string YPPM = cells[i, 1].StringValue.Trim();
                        string YPGG = cells[i, 2].StringValue.Trim();
                        string S_SCCJ = cells[i, 3].StringValue.Trim();
                        decimal sl = Convert.ToDecimal(cells[i, 4].StringValue.Trim());
                        string ypdw = cells[i, 5].StringValue.Trim();
                        decimal pfje = Convert.ToDecimal(cells[i, 6].StringValue.Trim());
                        decimal lsje = Convert.ToDecimal(cells[i, 7].StringValue.Trim());
                        decimal plce = Convert.ToDecimal(cells[i, 8].StringValue.Trim());
                        int cjid = int.Parse(cells[i, 9].StringValue.Trim());

                        //1.根据cjid获取药品相关信息
                        Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);
                        //2.DataGridView新增一列数据                      
                        DataRow row = gridTable.NewRow();
                        row["序号"] = gridTable.Rows.Count + 1;
                        row["商品名"] = ydcj.S_YPSPM;
                        row["品名"] = YPPM;
                        row["规格"] = YPGG;
                        row["厂家"] = S_SCCJ;

                        row["批发价"] = ydcj.PFJ;
                        row["零售价"] = ydcj.LSJ;
                        row["批发金额"] = pfje;
                        row["零售金额"] = lsje;
                        row["批零差额"] = plce;
                        row["数量"] = sl.ToString();
                        row["单位"] = ypdw.ToString();
                        row["货号"] = ydcj.SHH;
                        row["CJID"] = cjid.ToString();
                        row["dwbl"] = "1";
                        //进价、进货金额
                        decimal sumjhje = Convert.ToDecimal(Convertor.IsNull(sl, "0")) * Convert.ToDecimal(Convertor.IsNull(ydcj.MRJJ.ToString(), "0"));
                        row["进价"] = ydcj.MRJJ.ToString();
                        row["进货金额"] = sumjhje.ToString("0.00");

                        //3.查询批次信息

                        string ssql = "select 0   rowno,kcl,dbo.fun_yp_ypdw(zxdw),jhj,yppch,id kcid,ypph,ypxq,dbo.fun_yp_kwmc(ggid,deptid) kwmc,kwid  from YF_kcph  where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + cjid + " and (bdelete=0 or (bdelete=1 and kcl<>0)) and kcl>0";
                        SystemCfg cfg = new SystemCfg(8051);//批号排序及自动分配批号库存规则，0-先进先出 1-按效期先出 
                        ssql += cfg.Config.Trim().Equals("0") ? " order by DJSJ asc" : " order by ypxq asc";

                        DataTable dt = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            row["批次号"] = dt.Rows[0]["yppch"];//批次号
                            row["kcid"] = dt.Rows[0]["kcid"];
                            row["批号"] = dt.Rows[0]["ypph"].ToString();
                            row["效期"] = dt.Rows[0]["ypxq"];
                            row["库位"] = dt.Rows[0]["kwmc"].ToString();
                            row["kwid"] = dt.Rows[0]["kwid"].ToString();
                            row["库存量"] = dt.Rows[0]["kcl"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("未获取到厂家id：" + cjid + "库存为0");
                        }

                        gridTable.Rows.Add(row);

                        SortRowNO();

                    }
                    gridTable.EndInit();
                    this.Sumje();
                    MessageBox.Show("导入成功");
                    //cells = workbook.Worksheets[0].Cells;
                    //System.Data.DataTable dataTable1 = cells.ExportDataTable(1, 0, cells.MaxDataRow, cells.MaxColumn, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

            */

            #endregion

            string strMessage = "";

            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                this.btn_Import.Enabled = false;

                ParameterEx[] parameters = new ParameterEx[9];
                parameters[0].Value = 1;
                parameters[1].Value = "017";
                parameters[2].Value = 0;
                parameters[3].Value = 0;
                parameters[4].Value = 0;
                parameters[5].Value = 0;
                parameters[6].Value = dateTimePicker1.Value.ToString();
                parameters[7].Value = dateTimePicker2.Value.ToString();
                int intDeptId = 0;

                //门诊一楼白班药房（424）,门诊一楼夜间药房(418)和门诊药房（后湖）207,门诊夜间药房（后湖）(669)
                if (InstanceForm.BCurrentDept.DeptId == 424)
                {
                    intDeptId = 418;
                }
                else if (InstanceForm.BCurrentDept.DeptId == 207)
                {
                    intDeptId = 669;
                }
                else if (InstanceForm.BCurrentDept.DeptId == 142)
                {
                    intDeptId = 399;
                }
                parameters[8].Value = intDeptId;

                parameters[0].Text = "@type";
                parameters[1].Text = "@ywlx";
                parameters[2].Text = "@yplx";
                parameters[3].Text = "@ypzlx";
                parameters[4].Text = "@ghdw";
                parameters[5].Text = "@cjid";
                parameters[6].Text = "@dtp1";
                parameters[7].Text = "@dtp2";
                parameters[8].Text = "@deptid";

                //1.获取门诊处方出库数据
                DataSet _dtset = new DataSet();
                InstanceForm.BDatabase.AdapterFillDataSet("SP_YF_YJDB", parameters, _dtset, "dtset", 30);

                FunBase.AddRowtNo(_dtset.Tables[0]);
                FunBase.AddRowtNo(_dtset.Tables[1]);
                _dtset.Tables[0].TableName = "Tb";
                _dtset.Tables[1].TableName = "Tbmx";

                DataTable tb = _dtset.Tables[0];

                DataView dataView = tb.DefaultView;
                dataView.Sort = "HWMC asc";
                tb = dataView.ToTable();

                if (tb != null && tb.Rows.Count > 0)
                {
                    DataTable gridTable = myDataGrid1.DataSource as DataTable;

                    //清空dataGridView数据
                    gridTable.Rows.Clear();


                    gridTable.BeginInit();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        //判断是否存在药品信息
                        string YPPM = tb.Rows[i]["品名"].ToString().Trim();
                        string YPGG = tb.Rows[i]["规格"].ToString().Trim();
                        string S_SCCJ = tb.Rows[i]["厂家"].ToString().Trim();
                        decimal sl = Convert.ToDecimal(tb.Rows[i]["数量"].ToString());
                        string ypdw = tb.Rows[i]["单位"].ToString();
                        decimal pfje = Convert.ToDecimal(tb.Rows[i]["批发金额"].ToString());
                        decimal lsje = Convert.ToDecimal(tb.Rows[i]["零售金额"].ToString());
                        decimal plce = Convert.ToDecimal(tb.Rows[i]["批零差额"].ToString());
                        int cjid = int.Parse(tb.Rows[i]["cjid"].ToString());
                        decimal ydwbl = Convert.ToDecimal(tb.Rows[i]["dwbl"].ToString());
                        decimal xykc = 0;

                        //申请数量
                        decimal sqsl = sl;

                        //1.根据cjid获取药品相关信息
                        Ypcj ydcj = new Ypcj(cjid, InstanceForm.BDatabase);

                        //批发单价
                        decimal pfUnitPrice = ydcj.PFJ;
                        //零售单价
                        decimal lsUnitPrice = ydcj.LSJ;

                        string ssql = "select 0   rowno,DWBL,kcl,dbo.fun_yp_ypdw(zxdw) as dw,jhj,yppch,id kcid,ypph,ypxq,dbo.fun_yp_kwmc(ggid,deptid) kwmc,kwid  from YF_kcph  where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + cjid + " and (bdelete=0 or (bdelete=1 and kcl<>0)) and kcl>0";
                        SystemCfg cfg = new SystemCfg(8051);//批号排序及自动分配批号库存规则，0-先进先出 1-按效期先出 
                        ssql += cfg.Config.Trim().Equals("0") ? " order by DJSJ asc" : " order by ypxq asc";

                        DataTable dt = InstanceForm.BDatabase.GetDataTable(ssql);

                        //查询药品的现有库存
                        string strSqlKc = "SELECT kcl,DWBL,CJID FROM yf_kcmx WHERE CJID=" + cjid + " AND DEPTID=" + intDeptId;
                        DataTable dtxykc = InstanceForm.BDatabase.GetDataTable(strSqlKc);
                        if (dtxykc != null && dtxykc.Rows.Count > 0)
                        {
                            xykc = Convert.ToDecimal(dtxykc.Rows[0]["kcl"]);
                        }
                        else
                        {
                            xykc = 0M;
                        }

                        if (dt == null || dt.Rows.Count <= 0)
                        {
                            strMessage = S_SCCJ + ",";

                            DataRow row = gridTable.NewRow();
                            row["序号"] = gridTable.Rows.Count + 1;
                            row["商品名"] = ydcj.S_YPSPM;
                            row["品名"] = YPPM;
                            row["规格"] = YPGG;
                            row["厂家"] = S_SCCJ;
                            row["单位"] = ypdw.ToString();
                            row["货号"] = ydcj.SHH;
                            row["CJID"] = cjid.ToString();
                            row["现有库存"] = xykc;


                            string strsql = "select 0   rowno,DWBL,kcl,dbo.fun_yp_ypdw(zxdw) as dw,jhj,yppch,id kcid,ypph,ypxq,dbo.fun_yp_kwmc(ggid,deptid) kwmc,kwid  from YF_kcph  where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + cjid;
                            SystemCfg cfg1 = new SystemCfg(8051);//批号排序及自动分配批号库存规则，0-先进先出 1-按效期先出 
                            strsql += cfg1.Config.Trim().Equals("0") ? " order by DJSJ asc" : " order by ypxq asc";
                            DataTable dt_KC = InstanceForm.BDatabase.GetDataTable(strsql);
                            if (dt_KC != null && dt_KC.Rows.Count > 0)
                            {
                                row["批次号"] = dt_KC.Rows[0]["yppch"];//批次号
                                row["kcid"] = dt_KC.Rows[0]["kcid"]; ;
                                row["批号"] = dt_KC.Rows[0]["ypph"].ToString();
                                row["效期"] = dt_KC.Rows[0]["ypxq"].ToString();
                                row["库位"] = dt_KC.Rows[0]["kwmc"].ToString();
                                row["kwid"] = dt_KC.Rows[0]["kwid"].ToString();
                                row["dwbl"] = dt_KC.Rows[0]["DWBL"];
                            }
                            else
                            {
                                row["批次号"] = "";//批次号
                                row["kcid"] = Guid.NewGuid();
                                row["批号"] = "";
                                row["效期"] = "";
                                row["库位"] = "";
                                row["kwid"] = "";
                                row["dwbl"] = 1;
                            }
                            row["批发价"] = pfUnitPrice;
                            row["零售价"] = lsUnitPrice;
                            row["进价"] = ydcj.MRJJ.ToString();
                            row["批发金额"] = 0;
                            row["零售金额"] = 0;
                            row["批零差额"] = 0;
                            row["进货金额"] = 0;
                            row["申请量"] = sqsl;

                            //int intSl = (int)sl;
                            //Regex reg = new Regex(@"^\d+\.[1-9]+$");
                            //if (reg.IsMatch(sl.ToString()))
                            //{
                            //    intSl = (int)sl + 1;
                            //}
                            row["数量"] = 0;
                            row["库存量"] = "0";

                            gridTable.Rows.Add(row);
                        }

                        foreach (DataRow item in dt.Rows)
                        {
                            DataRow row = gridTable.NewRow();
                            row["序号"] = gridTable.Rows.Count + 1;
                            row["商品名"] = ydcj.S_YPSPM;
                            row["品名"] = YPPM;
                            row["规格"] = YPGG;
                            row["厂家"] = S_SCCJ;
                            row["货号"] = ydcj.SHH;
                            row["CJID"] = cjid.ToString();
                            row["批次号"] = item["yppch"];//批次号
                            row["kcid"] = item["kcid"];
                            row["批号"] = item["ypph"].ToString();
                            row["效期"] = item["ypxq"].ToString();
                            row["库位"] = item["kwmc"].ToString();
                            row["kwid"] = item["kwid"].ToString();
                            row["批发价"] = Math.Round(pfUnitPrice / Convert.ToDecimal(item["DWBL"].ToString()), 4, MidpointRounding.AwayFromZero);
                            row["零售价"] = Math.Round(lsUnitPrice / Convert.ToDecimal(item["DWBL"].ToString()), 4, MidpointRounding.AwayFromZero);
                            row["进价"] = Math.Round(ydcj.MRJJ / Convert.ToDecimal(item["DWBL"].ToString()), 4, MidpointRounding.AwayFromZero);
                            //row["单位"] = ypdw.ToString();
                            row["单位"] = item["dw"].ToString();
                            row["dwbl"] = item["DWBL"];
                            row["现有库存"] = xykc;

                            if (YPPM == "艾司唑仑片（舒乐安定）")
                            {

                            }
                            //转换单位后的数量
                            sl = sl * Convert.ToDecimal(item["DWBL"].ToString());
                            Regex reg1 = new Regex(@"^\d+\.([1-9]|([0]+[1-9]+[0-9])+$)");
                            if (reg1.IsMatch(sl.ToString()))
                            {
                                sl = (decimal)(Convert.ToInt32((Math.Truncate(sl * 10) / 10)));
                            }

                            //转换单位后的申请数量
                            sqsl = sqsl * Convert.ToDecimal(item["DWBL"].ToString());
                            if (reg1.IsMatch(sqsl.ToString()))
                            {
                                sqsl = (decimal)(Convert.ToInt32((Math.Truncate(sqsl * 10) / 10)));
                            }

                            if (sl > Convert.ToDecimal(item["kcl"].ToString()))
                            {

                                sl = sl - Convert.ToDecimal(item["kcl"].ToString());
                                row["批发金额"] = Math.Round(Convert.ToDecimal(row["批发价"]) * Convert.ToDecimal(item["kcl"].ToString()), 4, MidpointRounding.AwayFromZero);
                                row["零售金额"] = Math.Round(Convert.ToDecimal(row["零售价"]) * Convert.ToDecimal(item["kcl"].ToString()), 4, MidpointRounding.AwayFromZero);
                                row["批零差额"] = Convert.ToDecimal(row["零售金额"]) - Convert.ToDecimal(row["批发金额"]);
                                row["进货金额"] = Math.Round(Convert.ToDecimal(row["进价"]) * Convert.ToDecimal(item["kcl"].ToString()), 4, MidpointRounding.AwayFromZero);
                                row["申请量"] = sqsl;
                                row["数量"] = item["kcl"].ToString();
                                row["库存量"] = item["kcl"].ToString();
                                //转换回原来单位数量
                                sl = sl / Convert.ToDecimal(item["DWBL"].ToString());
                                sqsl = sqsl / Convert.ToDecimal(item["DWBL"].ToString());
                                gridTable.Rows.Add(row);
                            }
                            else
                            {
                                int intSl = (int)sl;
                                Regex reg = new Regex(@"^\d+\.([1-9]|([0]+[1-9]+[0-9])+$)");
                                string strrr = sl.ToString();
                                if (reg.IsMatch(strrr))
                                {
                                    intSl = (int)sl + 1;
                                }
                                row["批发金额"] = Convert.ToDecimal(row["批发价"]) * intSl;
                                row["零售金额"] = Convert.ToDecimal(row["零售价"]) * intSl;
                                row["批零差额"] = Convert.ToDecimal(row["零售金额"]) - Convert.ToDecimal(row["批发金额"]);
                                row["进货金额"] = Convert.ToDecimal(row["进价"]) * intSl;
                                row["申请量"] = sqsl;


                                row["数量"] = intSl;
                                row["库存量"] = item["kcl"].ToString();
                                gridTable.Rows.Add(row);
                                break;
                            }
                        }

                        SortRowNO();

                    }
                    gridTable.EndInit();
                    this.Sumje();
                    //MessageBox.Show("一键调拨成功");
                }
                else
                {
                    MessageBox.Show("未查询到调拨数据");
                }

                this.btn_Import.Enabled = true;
            }
            catch (System.Exception err)
            {
                this.btn_Import.Enabled = true;
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        /// <summary>
        /// 由连字符分隔的32位数字
        /// </summary>
        /// <returns></returns>
        private static string GetGuid()
        {
            /*System.Guid guid = new Guid();
            guid = Guid.NewGuid();
            return guid.ToString();*/
            string strGuid = string.Empty;
            string ssql = "SELECT dbo.FUN_GETGUID(newid(),getdate()) AS GUIDNAME ";
            System.Data.DataTable tabkcph = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tabkcph.Rows.Count > 0)
            {
                strGuid = tabkcph.Rows[0]["GUIDNAME"].ToString();
            }
            return strGuid;
        }

        private static int getpatID(string strID, out string strMsg)
        {
            string strFlag = "这是返回参数值";

            int str = 1;
            strMsg = strFlag;
            return str;
        }


    }
}
