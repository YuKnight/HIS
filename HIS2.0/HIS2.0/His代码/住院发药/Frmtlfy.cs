using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using Ts_zyys_public;
using TrasenFrame.Forms;
using YpClass;
using System.Collections.Generic;
using System.IO;

namespace ts_yf_zyfy
{
    /// <summary>
    /// Frmyprk 的摘要说明。
    /// </summary>
    public class Frmtlfy : System.Windows.Forms.Form
    {
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        public long _Sqdh;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter1;
        private Crownwood.Magic.Controls.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TreeListView treeListView1;
        private System.Windows.Forms.ColumnHeader 消息时间;
        private System.Windows.Forms.ColumnHeader 发送人;
        private System.Windows.Forms.ColumnHeader 消息备注;
        private System.Windows.Forms.ColumnHeader apply_id;
        private System.Windows.Forms.ColumnHeader nurseid;
        private System.Windows.Forms.ColumnHeader dept_ly;
        private System.Windows.Forms.ColumnHeader groupid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeListView treeListView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Crownwood.Magic.Controls.TabControl tabControl2;
        private System.Windows.Forms.ComboBox cmbpyr;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtcw;
        private System.Windows.Forms.TextBox txtypmc;
        private System.Windows.Forms.TextBox txtxm;
        private System.Windows.Forms.TextBox txtzyh;
        private System.Windows.Forms.Button butmxcx;
        private System.Windows.Forms.Button butqc;
        private System.Windows.Forms.Button butref;
        private System.Windows.Forms.DateTimePicker dtptlrq2;
        private System.Windows.Forms.DateTimePicker dtptlrq1;
        private System.Windows.Forms.Button butref1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbbs2;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private System.Windows.Forms.TreeListView treeListView3;
        private System.Windows.Forms.ColumnHeader 发药日期;
        private System.Windows.Forms.ColumnHeader 发药人;
        private System.Windows.Forms.ColumnHeader 配药人;
        private System.Windows.Forms.ColumnHeader 单据号;
        private System.Windows.Forms.ColumnHeader 金额;
        private System.Windows.Forms.ColumnHeader 领药护士;
        private System.Windows.Forms.ColumnHeader 备注;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.ComboBox cmbbs3;
        private System.Windows.Forms.CheckBox chkmx;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butprintmx;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butfy;
        private System.Windows.Forms.ComboBox cmbbs1;
        private System.Windows.Forms.TextBox txtbz;
        private TrasenClasses.GeneralControls.ButtonDataGridEx myDataGridMx;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.CheckBox chkprintview;
        private System.Windows.Forms.Button butselect;
        private System.Windows.Forms.Button butunselect;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private Panel panel9;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader8;
        private CheckBox chkkcfs;
        private CheckBox chkkccc;
        private Panel panel_dd;
        private StatusBarPanel statusBarPanel3;
        private StatusBarPanel statusBarPanel2;
        private StatusBarPanel statusBarPanel1;
        private StatusBar statusBar1;
        private Panel panel_left;
        private Splitter splitter2;
        private System.Windows.Forms.GroupBox panel_top;
        private Panel panel_chk;
        private YpConfig ss;
        bool bpcgl = false;
        private Panel panel7;
        private Panel panel13;
        private Button button1;
        private Button button3;
        private StatusBarPanel statusBarPanel4;
        private RadioButton rdAll;
        private RadioButton rdCJ;
        private RadioButton rdTL;
        private Panel panel6;
        private ComboBox comboBox1;
        private Label label3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private Button btncb;

        //private CachedYF_住院处方清单中药 cachedYF_住院处方清单中药1;
        private CheckBox chkAllFee;
        private CheckBox chkCharged;
        private CheckBox chkUncharge;
        private Button btCharge; //是否进行批次管理

        private CachedYF_住院处方清单中药 cachedYF_住院处方清单中药1;
        private DateTimePicker dateTimePicker1;
        private CheckBox checkBox4; //是否进行批次管理

        string pcglfs = "0";//批次管理方式 0先进先出 1近效期先出

        private bool isPivasYF = false;
        private CheckBox chkPivasCHK;
        private RadioButton rbDy;
        private RadioButton rbXydy;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;//是否PIVAS药房 Add By Tany 2015-04-20
        private DataTable PivasDept = new DataTable();//记录pivas与科室的对应关系

        public Frmtlfy(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            _Sqdh = 0;
            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            ss = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

        }

        private void OrderTypeSelectionChanged(object sender, EventArgs e)
        {
            butref1_Click(sender, e);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmtlfy));
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer2 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer3 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.treeListView1 = new System.Windows.Forms.TreeListView();
            this.消息时间 = new System.Windows.Forms.ColumnHeader();
            this.发送人 = new System.Windows.Forms.ColumnHeader();
            this.消息备注 = new System.Windows.Forms.ColumnHeader();
            this.apply_id = new System.Windows.Forms.ColumnHeader();
            this.nurseid = new System.Windows.Forms.ColumnHeader();
            this.dept_ly = new System.Windows.Forms.ColumnHeader();
            this.groupid = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.chkmx = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdTL = new System.Windows.Forms.RadioButton();
            this.rdAll = new System.Windows.Forms.RadioButton();
            this.rdCJ = new System.Windows.Forms.RadioButton();
            this.cmbbs1 = new System.Windows.Forms.ComboBox();
            this.butref1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.treeListView2 = new System.Windows.Forms.TreeListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.panel11 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cmbbs2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeListView3 = new System.Windows.Forms.TreeListView();
            this.发药日期 = new System.Windows.Forms.ColumnHeader();
            this.发药人 = new System.Windows.Forms.ColumnHeader();
            this.单据号 = new System.Windows.Forms.ColumnHeader();
            this.备注 = new System.Windows.Forms.ColumnHeader();
            this.配药人 = new System.Windows.Forms.ColumnHeader();
            this.领药护士 = new System.Windows.Forms.ColumnHeader();
            this.金额 = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbbs3 = new System.Windows.Forms.ComboBox();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.butref = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtptlrq2 = new System.Windows.Forms.DateTimePicker();
            this.dtptlrq1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtbz = new System.Windows.Forms.TextBox();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.butfy = new System.Windows.Forms.Button();
            this.chkkccc = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkkcfs = new System.Windows.Forms.CheckBox();
            this.cmbpyr = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkprintview = new System.Windows.Forms.CheckBox();
            this.butprintmx = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.myDataGridMx = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btncb = new System.Windows.Forms.Button();
            this.butunselect = new System.Windows.Forms.Button();
            this.butselect = new System.Windows.Forms.Button();
            this.butqc = new System.Windows.Forms.Button();
            this.butmxcx = new System.Windows.Forms.Button();
            this.txtzyh = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtxm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtcw = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtypmc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel_dd = new System.Windows.Forms.Panel();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.panel_chk = new System.Windows.Forms.Panel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel_top = new System.Windows.Forms.GroupBox();
            this.rbDy = new System.Windows.Forms.RadioButton();
            this.rbXydy = new System.Windows.Forms.RadioButton();
            this.chkPivasCHK = new System.Windows.Forms.CheckBox();
            this.chkAllFee = new System.Windows.Forms.CheckBox();
            this.chkCharged = new System.Windows.Forms.CheckBox();
            this.chkUncharge = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btCharge = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.cachedYF_住院处方清单中药1 = new ts_yf_zyfy.CachedYF_住院处方清单中药();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridMx)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel_dd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.panel_left.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 485);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabControl1.BoldSelectedPage = true;
            this.tabControl1.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl1.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl1.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabPage1;
            this.tabControl1.Size = new System.Drawing.Size(273, 458);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
            this.tabControl1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl1.TextInactiveColor = System.Drawing.Color.Black;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(273, 433);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Tag = "0";
            this.tabPage1.Title = "领药消息";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.treeListView1);
            this.panel5.Controls.Add(this.chkmx);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 66);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(273, 367);
            this.panel5.TabIndex = 1;
            // 
            // treeListView1
            // 
            this.treeListView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.消息时间,
            this.发送人,
            this.消息备注,
            this.apply_id,
            this.nurseid,
            this.dept_ly,
            this.groupid,
            this.columnHeader8});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView1.Comparer = treeListViewItemCollectionComparer1;
            this.treeListView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView1.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeListView1.GridLines = true;
            this.treeListView1.Location = new System.Drawing.Point(0, 0);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeListView1.Size = new System.Drawing.Size(273, 367);
            this.treeListView1.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView1.TabIndex = 3;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.DoubleClick += new System.EventHandler(this.treeListView1_DoubleClick);
            this.treeListView1.Click += new System.EventHandler(this.treeListView1_Click);
            // 
            // 消息时间
            // 
            this.消息时间.Text = "消息时间";
            this.消息时间.Width = 194;
            // 
            // 发送人
            // 
            this.发送人.Text = "发送人";
            this.发送人.Width = 67;
            // 
            // 消息备注
            // 
            this.消息备注.Text = "消息备注";
            this.消息备注.Width = 95;
            // 
            // apply_id
            // 
            this.apply_id.Text = "apply_id";
            this.apply_id.Width = 0;
            // 
            // nurseid
            // 
            this.nurseid.Text = "nurseid";
            this.nurseid.Width = 0;
            // 
            // dept_ly
            // 
            this.dept_ly.Text = "dept_ly";
            this.dept_ly.Width = 0;
            // 
            // groupid
            // 
            this.groupid.Text = "groupid";
            this.groupid.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "lyflcode";
            this.columnHeader8.Width = 0;
            // 
            // chkmx
            // 
            this.chkmx.AutoSize = true;
            this.chkmx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkmx.ForeColor = System.Drawing.Color.Black;
            this.chkmx.Location = new System.Drawing.Point(199, 0);
            this.chkmx.Name = "chkmx";
            this.chkmx.Size = new System.Drawing.Size(48, 16);
            this.chkmx.TabIndex = 12;
            this.chkmx.Text = "明细";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.cmbbs1);
            this.panel4.Controls.Add(this.butref1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(273, 66);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rdTL);
            this.panel6.Controls.Add(this.rdAll);
            this.panel6.Controls.Add(this.rdCJ);
            this.panel6.Location = new System.Drawing.Point(9, 39);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(189, 24);
            this.panel6.TabIndex = 12;
            // 
            // rdTL
            // 
            this.rdTL.AutoSize = true;
            this.rdTL.Checked = true;
            this.rdTL.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTL.Location = new System.Drawing.Point(3, 3);
            this.rdTL.Name = "rdTL";
            this.rdTL.Size = new System.Drawing.Size(56, 20);
            this.rdTL.TabIndex = 9;
            this.rdTL.TabStop = true;
            this.rdTL.Text = "统领";
            this.rdTL.UseVisualStyleBackColor = true;
            // 
            // rdAll
            // 
            this.rdAll.AutoSize = true;
            this.rdAll.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAll.Location = new System.Drawing.Point(127, 2);
            this.rdAll.Name = "rdAll";
            this.rdAll.Size = new System.Drawing.Size(56, 20);
            this.rdAll.TabIndex = 11;
            this.rdAll.Text = "全部";
            this.rdAll.UseVisualStyleBackColor = true;
            // 
            // rdCJ
            // 
            this.rdCJ.AutoSize = true;
            this.rdCJ.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCJ.Location = new System.Drawing.Point(65, 2);
            this.rdCJ.Name = "rdCJ";
            this.rdCJ.Size = new System.Drawing.Size(56, 20);
            this.rdCJ.TabIndex = 10;
            this.rdCJ.Text = "冲减";
            this.rdCJ.UseVisualStyleBackColor = true;
            // 
            // cmbbs1
            // 
            this.cmbbs1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbbs1.Location = new System.Drawing.Point(50, 14);
            this.cmbbs1.Name = "cmbbs1";
            this.cmbbs1.Size = new System.Drawing.Size(217, 21);
            this.cmbbs1.TabIndex = 3;
            this.cmbbs1.SelectedIndexChanged += new System.EventHandler(this.cmbbs1_SelectedIndexChanged);
            // 
            // butref1
            // 
            this.butref1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butref1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butref1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butref1.ForeColor = System.Drawing.Color.Navy;
            this.butref1.Location = new System.Drawing.Point(199, 39);
            this.butref1.Name = "butref1";
            this.butref1.Size = new System.Drawing.Size(68, 24);
            this.butref1.TabIndex = 2;
            this.butref1.Text = "刷新";
            this.butref1.Click += new System.EventHandler(this.butref1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "病区";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel10);
            this.tabPage2.Controls.Add(this.panel11);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(273, 433);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Tag = "1";
            this.tabPage2.Title = "退药消息";
            this.tabPage2.Visible = false;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.treeListView2);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 88);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(273, 345);
            this.panel10.TabIndex = 3;
            // 
            // treeListView2
            // 
            this.treeListView2.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.treeListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9});
            treeListViewItemCollectionComparer2.Column = 0;
            treeListViewItemCollectionComparer2.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView2.Comparer = treeListViewItemCollectionComparer2;
            this.treeListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView2.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeListView2.GridLines = true;
            this.treeListView2.Location = new System.Drawing.Point(0, 0);
            this.treeListView2.Name = "treeListView2";
            this.treeListView2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeListView2.Size = new System.Drawing.Size(273, 345);
            this.treeListView2.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView2.TabIndex = 4;
            this.treeListView2.UseCompatibleStateImageBehavior = false;
            this.treeListView2.DoubleClick += new System.EventHandler(this.treeListView1_DoubleClick);
            this.treeListView2.Click += new System.EventHandler(this.treeListView1_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "消息时间";
            this.columnHeader1.Width = 168;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "发送人";
            this.columnHeader2.Width = 67;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "消息备注";
            this.columnHeader3.Width = 85;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "apply_id";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "nurseid";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "dept_ly";
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "groupid";
            this.columnHeader7.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "lyflcode";
            this.columnHeader9.Width = 0;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.Control;
            this.panel11.Controls.Add(this.button1);
            this.panel11.Controls.Add(this.button3);
            this.panel11.Controls.Add(this.cmbbs2);
            this.panel11.Controls.Add(this.label11);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(273, 88);
            this.panel11.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(224, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "查找";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.ForeColor = System.Drawing.Color.Navy;
            this.button3.Location = new System.Drawing.Point(224, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 24);
            this.button3.TabIndex = 5;
            this.button3.Text = "刷新";
            // 
            // cmbbs2
            // 
            this.cmbbs2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbs2.Location = new System.Drawing.Point(50, 14);
            this.cmbbs2.Name = "cmbbs2";
            this.cmbbs2.Size = new System.Drawing.Size(165, 21);
            this.cmbbs2.TabIndex = 0;
            this.cmbbs2.SelectedIndexChanged += new System.EventHandler(this.cmbbs2_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(9, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 1;
            this.label11.Text = "病区";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(273, 433);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Tag = "2";
            this.tabPage3.Title = "历史统领单据";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeListView3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 141);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 292);
            this.panel3.TabIndex = 1;
            // 
            // treeListView3
            // 
            this.treeListView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.发药日期,
            this.发药人,
            this.单据号,
            this.备注,
            this.配药人,
            this.领药护士,
            this.金额});
            treeListViewItemCollectionComparer3.Column = 0;
            treeListViewItemCollectionComparer3.SortOrder = System.Windows.Forms.SortOrder.None;
            this.treeListView3.Comparer = treeListViewItemCollectionComparer3;
            this.treeListView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView3.ExpandMethod = System.Windows.Forms.TreeListViewExpandMethod.IconDbleClick;
            this.treeListView3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListView3.GridLines = true;
            this.treeListView3.Location = new System.Drawing.Point(0, 0);
            this.treeListView3.Name = "treeListView3";
            this.treeListView3.Size = new System.Drawing.Size(273, 292);
            this.treeListView3.Sorting = System.Windows.Forms.SortOrder.None;
            this.treeListView3.TabIndex = 1;
            this.treeListView3.UseCompatibleStateImageBehavior = false;
            this.treeListView3.Click += new System.EventHandler(this.treeListView3_Click);
            // 
            // 发药日期
            // 
            this.发药日期.Text = "发药日期";
            this.发药日期.Width = 188;
            // 
            // 发药人
            // 
            this.发药人.Text = "发药人";
            // 
            // 单据号
            // 
            this.单据号.Text = "单据号";
            this.单据号.Width = 55;
            // 
            // 备注
            // 
            this.备注.Text = "备注";
            this.备注.Width = 100;
            // 
            // 配药人
            // 
            this.配药人.Text = "配药人";
            // 
            // 领药护士
            // 
            this.领药护士.Text = "领药护士";
            // 
            // 金额
            // 
            this.金额.Text = "金额";
            this.金额.Width = 65;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmbbs3);
            this.panel2.Controls.Add(this.cmbtype);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.butref);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtptlrq2);
            this.panel2.Controls.Add(this.dtptlrq1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 141);
            this.panel2.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "全部",
            "长期医嘱",
            "临时医嘱"});
            this.comboBox1.Location = new System.Drawing.Point(72, 113);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(122, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "医嘱类型";
            // 
            // cmbbs3
            // 
            this.cmbbs3.Location = new System.Drawing.Point(72, 59);
            this.cmbbs3.Name = "cmbbs3";
            this.cmbbs3.Size = new System.Drawing.Size(122, 21);
            this.cmbbs3.TabIndex = 11;
            this.cmbbs3.SelectedIndexChanged += new System.EventHandler(this.cmbbs3_SelectedIndexChanged);
            // 
            // cmbtype
            // 
            this.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtype.Items.AddRange(new object[] {
            "全部",
            "统领",
            "退药"});
            this.cmbtype.Location = new System.Drawing.Point(72, 86);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(122, 21);
            this.cmbtype.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(6, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 10;
            this.label12.Text = "统领类型";
            // 
            // butref
            // 
            this.butref.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butref.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butref.ForeColor = System.Drawing.Color.Navy;
            this.butref.Location = new System.Drawing.Point(200, 85);
            this.butref.Name = "butref";
            this.butref.Size = new System.Drawing.Size(67, 49);
            this.butref.TabIndex = 8;
            this.butref.Text = "刷新(&F)";
            this.butref.Click += new System.EventHandler(this.butref_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "病区";
            // 
            // dtptlrq2
            // 
            this.dtptlrq2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtptlrq2.Location = new System.Drawing.Point(72, 32);
            this.dtptlrq2.Name = "dtptlrq2";
            this.dtptlrq2.Size = new System.Drawing.Size(195, 21);
            this.dtptlrq2.TabIndex = 5;
            // 
            // dtptlrq1
            // 
            this.dtptlrq1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtptlrq1.Location = new System.Drawing.Point(72, 5);
            this.dtptlrq1.Name = "dtptlrq1";
            this.dtptlrq1.Size = new System.Drawing.Size(195, 21);
            this.dtptlrq1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "日期";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(273, 458);
            this.panel1.TabIndex = 4;
            // 
            // txtbz
            // 
            this.txtbz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbz.Location = new System.Drawing.Point(188, 5);
            this.txtbz.Name = "txtbz";
            this.txtbz.Size = new System.Drawing.Size(151, 21);
            this.txtbz.TabIndex = 8;
            // 
            // butquit
            // 
            this.butquit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butquit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point(737, 3);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(66, 28);
            this.butquit.TabIndex = 7;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butprint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butprint.ForeColor = System.Drawing.Color.Navy;
            this.butprint.Location = new System.Drawing.Point(479, 3);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(66, 28);
            this.butprint.TabIndex = 5;
            this.butprint.Text = "打印(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butfy
            // 
            this.butfy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butfy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butfy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butfy.ForeColor = System.Drawing.Color.Navy;
            this.butfy.Location = new System.Drawing.Point(412, 3);
            this.butfy.Name = "butfy";
            this.butfy.Size = new System.Drawing.Size(66, 28);
            this.butfy.TabIndex = 4;
            this.butfy.Text = "发药(&O)";
            this.butfy.Click += new System.EventHandler(this.butfy_Click);
            // 
            // chkkccc
            // 
            this.chkkccc.AutoSize = true;
            this.chkkccc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkkccc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkkccc.Location = new System.Drawing.Point(278, 17);
            this.chkkccc.Name = "chkkccc";
            this.chkkccc.Size = new System.Drawing.Size(234, 16);
            this.chkkccc.TabIndex = 9;
            this.chkkccc.Text = "当领药数大于库存时,超出部分明细不选";
            this.chkkccc.UseVisualStyleBackColor = true;
            this.chkkccc.CheckedChanged += new System.EventHandler(this.chkkccc_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(147, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "备注";
            // 
            // chkkcfs
            // 
            this.chkkcfs.AutoSize = true;
            this.chkkcfs.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkkcfs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkkcfs.Location = new System.Drawing.Point(9, 17);
            this.chkkcfs.Name = "chkkcfs";
            this.chkkcfs.Size = new System.Drawing.Size(258, 16);
            this.chkkcfs.TabIndex = 8;
            this.chkkcfs.Text = "当退药不能被领药抵扣时,超出部分明细不选";
            this.chkkcfs.UseVisualStyleBackColor = true;
            this.chkkcfs.CheckedChanged += new System.EventHandler(this.chkkcfs_CheckedChanged);
            // 
            // cmbpyr
            // 
            this.cmbpyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpyr.Location = new System.Drawing.Point(61, 5);
            this.cmbpyr.Name = "cmbpyr";
            this.cmbpyr.Size = new System.Drawing.Size(80, 20);
            this.cmbpyr.TabIndex = 1;
            this.cmbpyr.SelectedIndexChanged += new System.EventHandler(this.cmbpyr_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "配药人";
            // 
            // chkprintview
            // 
            this.chkprintview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkprintview.AutoSize = true;
            this.chkprintview.Checked = true;
            this.chkprintview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkprintview.Location = new System.Drawing.Point(650, 8);
            this.chkprintview.Name = "chkprintview";
            this.chkprintview.Size = new System.Drawing.Size(84, 16);
            this.chkprintview.TabIndex = 18;
            this.chkprintview.Text = "打印时预览";
            // 
            // butprintmx
            // 
            this.butprintmx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butprintmx.ContextMenuStrip = this.contextMenuStrip1;
            this.butprintmx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butprintmx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butprintmx.ForeColor = System.Drawing.Color.Navy;
            this.butprintmx.Location = new System.Drawing.Point(546, 3);
            this.butprintmx.Name = "butprintmx";
            this.butprintmx.Size = new System.Drawing.Size(98, 28);
            this.butprintmx.TabIndex = 6;
            this.butprintmx.Text = "打印明细(&M)";
            this.butprintmx.Visible = false;
            this.butprintmx.Click += new System.EventHandler(this.butprintmx_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "冲减明细";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabControl2.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl2.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl2.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.SelectedTab = this.tabPage4;
            this.tabControl2.Size = new System.Drawing.Size(805, 335);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage4});
            this.tabControl2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabControl2.TextInactiveColor = System.Drawing.Color.Black;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage4.Controls.Add(this.panel9);
            this.tabPage4.Controls.Add(this.panel8);
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(805, 310);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Title = "消息明细";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.myDataGridMx);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 40);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(805, 270);
            this.panel9.TabIndex = 2;
            // 
            // myDataGridMx
            // 
            this.myDataGridMx.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.myDataGridMx.CaptionVisible = false;
            this.myDataGridMx.DataMember = "";
            this.myDataGridMx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridMx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGridMx.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGridMx.Location = new System.Drawing.Point(0, 0);
            this.myDataGridMx.Name = "myDataGridMx";
            this.myDataGridMx.ReadOnly = true;
            this.myDataGridMx.SelectionForeColor = System.Drawing.Color.Aquamarine;
            this.myDataGridMx.Size = new System.Drawing.Size(805, 270);
            this.myDataGridMx.TabIndex = 0;
            this.myDataGridMx.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGridMx.DoubleClick += new System.EventHandler(this.myDataGridMx_DoubleClick_1);
            this.myDataGridMx.Click += new System.EventHandler(this.myDataGridMx_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGridMx;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 10;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.btncb);
            this.panel8.Controls.Add(this.butunselect);
            this.panel8.Controls.Add(this.butselect);
            this.panel8.Controls.Add(this.butqc);
            this.panel8.Controls.Add(this.butmxcx);
            this.panel8.Controls.Add(this.txtzyh);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.txtxm);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.txtcw);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.txtypmc);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(805, 40);
            this.panel8.TabIndex = 1;
            // 
            // btncb
            // 
            this.btncb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncb.ForeColor = System.Drawing.Color.Navy;
            this.btncb.Location = new System.Drawing.Point(699, 6);
            this.btncb.Name = "btncb";
            this.btncb.Size = new System.Drawing.Size(45, 27);
            this.btncb.TabIndex = 12;
            this.btncb.Text = "重包";
            this.btncb.Click += new System.EventHandler(this.btncb_Click);
            // 
            // butunselect
            // 
            this.butunselect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.butunselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butunselect.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butunselect.ForeColor = System.Drawing.Color.Yellow;
            this.butunselect.Location = new System.Drawing.Point(40, 7);
            this.butunselect.Name = "butunselect";
            this.butunselect.Size = new System.Drawing.Size(40, 27);
            this.butunselect.TabIndex = 11;
            this.butunselect.Text = "反选";
            this.butunselect.UseVisualStyleBackColor = false;
            this.butunselect.Click += new System.EventHandler(this.butunselect_Click);
            // 
            // butselect
            // 
            this.butselect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.butselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butselect.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butselect.ForeColor = System.Drawing.Color.Yellow;
            this.butselect.Location = new System.Drawing.Point(0, 7);
            this.butselect.Name = "butselect";
            this.butselect.Size = new System.Drawing.Size(40, 27);
            this.butselect.TabIndex = 10;
            this.butselect.Text = "全选";
            this.butselect.UseVisualStyleBackColor = false;
            this.butselect.Click += new System.EventHandler(this.butselect_Click);
            // 
            // butqc
            // 
            this.butqc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butqc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butqc.ForeColor = System.Drawing.Color.Navy;
            this.butqc.Location = new System.Drawing.Point(653, 6);
            this.butqc.Name = "butqc";
            this.butqc.Size = new System.Drawing.Size(45, 27);
            this.butqc.TabIndex = 9;
            this.butqc.Text = "清除";
            this.butqc.Click += new System.EventHandler(this.butqc_Click);
            // 
            // butmxcx
            // 
            this.butmxcx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butmxcx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butmxcx.ForeColor = System.Drawing.Color.Navy;
            this.butmxcx.Location = new System.Drawing.Point(606, 6);
            this.butmxcx.Name = "butmxcx";
            this.butmxcx.Size = new System.Drawing.Size(45, 27);
            this.butmxcx.TabIndex = 4;
            this.butmxcx.Text = "查询";
            this.butmxcx.Click += new System.EventHandler(this.butmxcx_Click);
            // 
            // txtzyh
            // 
            this.txtzyh.Location = new System.Drawing.Point(491, 8);
            this.txtzyh.Name = "txtzyh";
            this.txtzyh.Size = new System.Drawing.Size(113, 23);
            this.txtzyh.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(443, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "住院号";
            // 
            // txtxm
            // 
            this.txtxm.Location = new System.Drawing.Point(379, 8);
            this.txtxm.Name = "txtxm";
            this.txtxm.Size = new System.Drawing.Size(64, 23);
            this.txtxm.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(347, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "姓名";
            // 
            // txtcw
            // 
            this.txtcw.Location = new System.Drawing.Point(307, 8);
            this.txtcw.Name = "txtcw";
            this.txtcw.Size = new System.Drawing.Size(40, 23);
            this.txtcw.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(275, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "床号";
            // 
            // txtypmc
            // 
            this.txtypmc.Location = new System.Drawing.Point(147, 8);
            this.txtypmc.Name = "txtypmc";
            this.txtypmc.Size = new System.Drawing.Size(128, 23);
            this.txtypmc.TabIndex = 0;
            this.txtypmc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(83, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "药品名称";
            // 
            // panel_dd
            // 
            this.panel_dd.Controls.Add(this.statusBar1);
            this.panel_dd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_dd.Location = new System.Drawing.Point(3, 458);
            this.panel_dd.Name = "panel_dd";
            this.panel_dd.Size = new System.Drawing.Size(1082, 27);
            this.panel_dd.TabIndex = 0;
            // 
            // statusBar1
            // 
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBar1.Location = new System.Drawing.Point(0, 0);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1082, 27);
            this.statusBar1.TabIndex = 0;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 200;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 200;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 200;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Width = 465;
            // 
            // panel_chk
            // 
            this.panel_chk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_chk.Location = new System.Drawing.Point(3, 62);
            this.panel_chk.Name = "panel_chk";
            this.panel_chk.Size = new System.Drawing.Size(799, 24);
            this.panel_chk.TabIndex = 1;
            // 
            // panel_left
            // 
            this.panel_left.Controls.Add(this.panel1);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(3, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(273, 458);
            this.panel_left.TabIndex = 8;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(276, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(4, 458);
            this.splitter2.TabIndex = 9;
            this.splitter2.TabStop = false;
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.rbDy);
            this.panel_top.Controls.Add(this.rbXydy);
            this.panel_top.Controls.Add(this.chkPivasCHK);
            this.panel_top.Controls.Add(this.chkAllFee);
            this.panel_top.Controls.Add(this.chkCharged);
            this.panel_top.Controls.Add(this.chkUncharge);
            this.panel_top.Controls.Add(this.checkBox4);
            this.panel_top.Controls.Add(this.dateTimePicker1);
            this.panel_top.Controls.Add(this.checkBox3);
            this.panel_top.Controls.Add(this.checkBox2);
            this.panel_top.Controls.Add(this.checkBox1);
            this.panel_top.Controls.Add(this.chkkcfs);
            this.panel_top.Controls.Add(this.chkkccc);
            this.panel_top.Controls.Add(this.panel_chk);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(280, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(805, 89);
            this.panel_top.TabIndex = 10;
            this.panel_top.TabStop = false;
            this.panel_top.Text = "过滤选项";
            // 
            // rbDy
            // 
            this.rbDy.AutoSize = true;
            this.rbDy.Location = new System.Drawing.Point(313, 38);
            this.rbDy.Name = "rbDy";
            this.rbDy.Size = new System.Drawing.Size(29, 16);
            this.rbDy.TabIndex = 19;
            this.rbDy.Text = "=";
            this.rbDy.UseVisualStyleBackColor = true;
            // 
            // rbXydy
            // 
            this.rbXydy.AutoSize = true;
            this.rbXydy.Checked = true;
            this.rbXydy.Location = new System.Drawing.Point(275, 38);
            this.rbXydy.Name = "rbXydy";
            this.rbXydy.Size = new System.Drawing.Size(35, 16);
            this.rbXydy.TabIndex = 18;
            this.rbXydy.TabStop = true;
            this.rbXydy.Text = "<=";
            this.rbXydy.UseVisualStyleBackColor = true;
            // 
            // chkPivasCHK
            // 
            this.chkPivasCHK.AutoSize = true;
            this.chkPivasCHK.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPivasCHK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkPivasCHK.Location = new System.Drawing.Point(518, 15);
            this.chkPivasCHK.Name = "chkPivasCHK";
            this.chkPivasCHK.Size = new System.Drawing.Size(174, 16);
            this.chkPivasCHK.TabIndex = 17;
            this.chkPivasCHK.Text = "发药时不验证PIVAS审核状态";
            this.chkPivasCHK.UseVisualStyleBackColor = true;
            // 
            // chkAllFee
            // 
            this.chkAllFee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAllFee.AutoSize = true;
            this.chkAllFee.Location = new System.Drawing.Point(595, 38);
            this.chkAllFee.Name = "chkAllFee";
            this.chkAllFee.Size = new System.Drawing.Size(72, 16);
            this.chkAllFee.TabIndex = 15;
            this.chkAllFee.Text = "全部费用";
            this.chkAllFee.UseVisualStyleBackColor = true;
            this.chkAllFee.CheckedChanged += new System.EventHandler(this.chkAllFee_CheckedChanged);
            // 
            // chkCharged
            // 
            this.chkCharged.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCharged.AutoSize = true;
            this.chkCharged.Location = new System.Drawing.Point(733, 38);
            this.chkCharged.Name = "chkCharged";
            this.chkCharged.Size = new System.Drawing.Size(60, 16);
            this.chkCharged.TabIndex = 14;
            this.chkCharged.Text = "已记账";
            this.chkCharged.UseVisualStyleBackColor = true;
            this.chkCharged.CheckedChanged += new System.EventHandler(this.chkCharged_CheckedChanged);
            // 
            // chkUncharge
            // 
            this.chkUncharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUncharge.AutoSize = true;
            this.chkUncharge.Location = new System.Drawing.Point(670, 38);
            this.chkUncharge.Name = "chkUncharge";
            this.chkUncharge.Size = new System.Drawing.Size(60, 16);
            this.chkUncharge.TabIndex = 13;
            this.chkUncharge.Text = "未记账";
            this.chkUncharge.UseVisualStyleBackColor = true;
            this.chkUncharge.CheckedChanged += new System.EventHandler(this.chkUncharge_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(197, 38);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(78, 16);
            this.checkBox4.TabIndex = 16;
            this.checkBox4.Text = "处方日期:";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(344, 36);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(101, 21);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(9, 38);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 16);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "全部医嘱";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.VisibleChanged += new System.EventHandler(this.checkBox3_VisibleChanged);
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(133, 38);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "临嘱";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(83, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "长嘱";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btCharge);
            this.panel7.Controls.Add(this.txtbz);
            this.panel7.Controls.Add(this.butfy);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.butquit);
            this.panel7.Controls.Add(this.butprintmx);
            this.panel7.Controls.Add(this.cmbpyr);
            this.panel7.Controls.Add(this.butprint);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.chkprintview);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(280, 424);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(805, 34);
            this.panel7.TabIndex = 12;
            // 
            // btCharge
            // 
            this.btCharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCharge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCharge.ForeColor = System.Drawing.Color.Navy;
            this.btCharge.Location = new System.Drawing.Point(345, 3);
            this.btCharge.Name = "btCharge";
            this.btCharge.Size = new System.Drawing.Size(66, 28);
            this.btCharge.TabIndex = 19;
            this.btCharge.Text = "记账(&C)";
            this.btCharge.Click += new System.EventHandler(this.btCharge_Click);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.tabControl2);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(280, 89);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(805, 335);
            this.panel13.TabIndex = 13;
            // 
            // Frmtlfy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1085, 485);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel_dd);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Frmtlfy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "药品统领";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmtlfy_Load);
            this.tabPage1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridMx)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel_dd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.panel_left.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        Point cbxfirstPoint;
        Point dtpfirstPoint;
        private void Frmtlfy_Load(object sender, System.EventArgs e)
        {
            try
            {
                //初始化领药明细
                CshMxGrid(this.myDataGridMx);
                if (ss.网络内容显示商品名 == true)
                    this.myDataGridMx.TableStyles[0].GridColumnStyles["商品名"].Width = 120;
                else
                    this.myDataGridMx.TableStyles[0].GridColumnStyles["商品名"].Width = 0;
                //添加病区列表
                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_bq")
                {
                    Yp.AddcmbWardDept(cmbbs1, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                    Yp.AddcmbWardDept(cmbbs2, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                    Yp.AddcmbWardDept(cmbbs3, 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                }
                else
                {
                    Yp.AddcmbWardDept(cmbbs1, 1, 0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                    Yp.AddcmbWardDept(cmbbs2, 1, 0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                    Yp.AddcmbWardDept(cmbbs3, 1, 0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                }

                //Add By Tany 2015-05-04 如果是仅记账，发药按钮不可见
                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_jz"
                    || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz")
                {
                    butfy.Visible = false;
                }

                this.cmbbs1.SelectedIndex = 0;
                this.cmbbs2.SelectedIndex = 0;
                this.cmbbs3.SelectedIndex = 0;
                this.cmbtype.SelectedIndex = 0;


                //添加配药人
                Yp.AddcmbPyr(InstanceForm.BCurrentDept.DeptId, cmbpyr, InstanceForm.BDatabase);
                cmbpyr.SelectedValue = Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId);


                this.dtptlrq1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                this.dtptlrq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

                string fs = ApiFunction.GetIniString("住院统领发药统领选项", "退药抵扣不足时超出部分的明细自动不选", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (fs == "是")
                    chkkcfs.Checked = true;
                string cc = ApiFunction.GetIniString("住院统领发药统领选项", "领药数大于库存数时超出部分的明细自动不选", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (cc == "是")
                    chkkccc.Checked = true;

                bpcgl = Yp.BPcgl(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);//进行批次管理
                SystemCfg cfg8051 = new SystemCfg(8051);
                if (cfg8051.Config == "1")
                {
                    pcglfs = "1";
                }
                tabControl1.SelectedTab = this.tabPage1;
                btncb.Enabled = false;
                checkBox4.Checked = false;
                dateTimePicker1.Value = DateTime.Now;
                cbxfirstPoint = checkBox4.Location;
                dtpfirstPoint = dateTimePicker1.Location;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }

            cmbbs1.KeyPress += delegate(object s, KeyPressEventArgs kpe)
            {
                if (kpe.KeyChar == '\r')
                {
                    if (cmbbs1.Text == "")
                    {
                        cmbbs1.SelectedIndex = 0;
                        return;
                    }
                    string ssql = @" select a.name,a.dept_id,a.py_code as pym,a.wb_code as wbm,b.ward_id from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id 
                            where a.dept_id in(select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
                    ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm;

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "Ward_Id", "Name", "pym", "wbm" },
                                                                                       new string[] { "代码", "名称", "拼音码", "五笔码", "编号" },
                                                                                       new string[] { "Ward_Id", "Name", "PYM", "WBM", "Dept_id" }, new int[] { 80, 150, 80, 80, 80 });

                    frmSelectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbbs1;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbbs1.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbbs1.Text = "";
                        cmbbs1.SelectedValue = Convert.ToInt32(frmSelectCard.SelectDataRow["dept_id"]);
                    }
                }
            };

            cmbbs3.KeyPress += delegate(object s, KeyPressEventArgs kpe)
            {
                if (kpe.KeyChar == '\r')
                {
                    if (cmbbs3.Text == "")
                    {
                        cmbbs3.SelectedIndex = 0;
                        return;
                    }
                    string ssql = @" select a.name,a.dept_id,a.py_code as pym,a.wb_code as wbm,b.ward_id from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id 
                            where a.dept_id in(select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
                    ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm;

                    TrasenFrame.Forms.FrmSelectCard frmSelectCard = new FrmSelectCard(new string[] { "Ward_Id", "Name", "pym", "wbm" },
                                                                                       new string[] { "代码", "名称", "拼音码", "五笔码", "编号" },
                                                                                       new string[] { "Ward_Id", "Name", "PYM", "WBM", "Dept_id" }, new int[] { 80, 150, 80, 80, 80 });

                    frmSelectCard.sourceDataTable = InstanceForm.BDatabase.GetDataTable(ssql);
                    frmSelectCard.srcControl = cmbbs3;
                    frmSelectCard.WorkForm = this;
                    frmSelectCard.ReciveString = cmbbs3.Text;
                    if (frmSelectCard.ShowDialog() == DialogResult.OK)
                    {
                        cmbbs3.Text = "";
                        cmbbs3.SelectedValue = Convert.ToInt32(frmSelectCard.SelectDataRow["dept_id"]);
                    }
                }
            };

            rdTL.CheckedChanged += new EventHandler(butref1_Click);
            rdCJ.CheckedChanged += new EventHandler(butref1_Click);
            rdAll.CheckedChanged += new EventHandler(butref1_Click);

            //Modify By Tany 2015-04-20
            CheckIsPivasYF();

            //Modify By jchl 2016-08-23
            if (isPivasYF)
            {
                //Pivas 屏蔽记账按钮   【不屏蔽有bug：转打包后转住院药房的药扔可记账】
                btCharge.Visible = false;
            }
        }

        //Add By Tany 2015-04-20 检查是否pivas药房
        private void CheckIsPivasYF()
        {
            string sql = "";
            try
            {
                sql = "select * from JC_DEPT_DRUGSTORE where is_PvsRel=1 and DELETE_BIT=0 and DRUGSTORE_ID=" + InstanceForm.BCurrentDept.DeptId;
                PivasDept = InstanceForm.BDatabase.GetDataTable(sql); //Modify By Tany 2015-04-21 将科室缓存进datatable
                if (PivasDept != null && PivasDept.Rows.Count > 0)
                {
                    isPivasYF = true;
                }
                else
                {
                    isPivasYF = false;
                }
            }
            catch (Exception ex)
            {
                isPivasYF = false;
                MessageBox.Show("获取PIVAS科室信息时出错，请检查！\r\n\r\n" + sql);
            }
        }


        //初始化领药明细
        private void CshMxGrid(TrasenClasses.GeneralControls.ButtonDataGridEx xcjwDataGrid)
        {
            #region 添加统领明细的列

            xcjwDataGrid.TableStyles[0].GridColumnStyles.Clear();

            #region
            List<ColumnDefine> columns = new List<ColumnDefine>();
            columns.Add(PubClass.NewColumnDefine("序号", "序号", 45, true, 0));
            columns.Add(PubClass.NewColumnDefine("选择", "选择", 35, false, 1));
            columns.Add(PubClass.NewColumnDefine("床号", "床号", 35, true, 0));
            columns.Add(PubClass.NewColumnDefine("姓名", "姓名", 55, true, 0));
            columns.Add(PubClass.NewColumnDefine("住院号", "住院号", 80, true, 0));
            columns.Add(PubClass.NewColumnDefine("性别", "性别", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("年龄", "年龄", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("医嘱类型", "医嘱类型", 45, true, 0));
            columns.Add(PubClass.NewColumnDefine("品名", "品名", 120, true, 0));
            columns.Add(PubClass.NewColumnDefine("商品名", "商品名", 120, true, 0));
            columns.Add(PubClass.NewColumnDefine("规格", "规格", 90, true, 0));
            columns.Add(PubClass.NewColumnDefine("厂家", "厂家", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("单价", "单价", 55, true, 0));
            //columns.Add(PubClass.NewColumnDefine("库存数", "库存数", 55, true, 0));
            columns.Add(PubClass.NewColumnDefine("数量", "数量", 50, true, 0));
            columns.Add(PubClass.NewColumnDefine("单位", "单位", 40, true, 0));
            columns.Add(PubClass.NewColumnDefine("缺药", "缺药", 0, true, 2));
            columns.Add(PubClass.NewColumnDefine("转发", "转发", 0, true, 2));
            columns.Add(PubClass.NewColumnDefine("库存数", "库存数", 55, true, 0));
            columns.Add(PubClass.NewColumnDefine("金额", "金额", 50, true, 0));
            columns.Add(PubClass.NewColumnDefine("货号", "货号", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("类型", "类型", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("剂型", "剂型", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("cjid", "cjid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dept_id", "dept_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("apply_id", "apply_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("apply_date", "apply_date", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("charge_bit", "charge_bit", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dept_ly", "dept_ly", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("zy_id", "zy_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("unitrate", "unitrate", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("ypsl", "ypsl", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("zxdw", "zxdw", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("批发价", "批发价", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("批发金额", "批发金额", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("用量", "用量", 55, true, 0));
            columns.Add(PubClass.NewColumnDefine("用法", "用法", 55, true, 0));
            columns.Add(PubClass.NewColumnDefine("频次", "频次", 50, true, 0));
            columns.Add(PubClass.NewColumnDefine("ryrq", "ryrq", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("货位号", "货位号", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("lyflcode", "lyflcode", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("lsj", "lsj", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("处方日期", "处方日期", 80, true, 0));
            columns.Add(PubClass.NewColumnDefine("kcid", "kcid", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("英文名", "英文名", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("cz_id", "cz_id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("剂数", "剂数", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("剂量", "剂量", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("收费日期", "收费日期", 80, true, 0));//Modify By Tany 2015-03-17 放出收费日期
            columns.Add(PubClass.NewColumnDefine("收费员id", "收费员id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("管床医生id", "管床医生id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("医嘱序号", "医嘱序号", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("处方id", "处方id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("医嘱内容", "医嘱内容", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("执行科室id", "执行科室id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("病人科室id", "病人科室id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("开单科室id", "开单科室id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("开单医生id", "开单医生id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("jlzxdw", "jlzxdw", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("ypdw", "ypdw", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("住院id", "住院id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("婴儿id", "婴儿id", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("嘱托", "嘱托", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("组标志", "组标志", 0, true, 0));
            columns.Add(PubClass.NewColumnDefine("剂量单位", "剂量单位", 0, true, 0));
            //update code pengy 2015-1-2
            columns.Add(PubClass.NewColumnDefine("包药方式", "包药方式", 80, true, 0));
            columns.Add(PubClass.NewColumnDefine("groupid", "groupid", 0, true, 0));
            #endregion

            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbmx";
            this.butprintmx.Visible = true;
            int index = 0;
            foreach (ColumnDefine cd in columns)
            {
                #region 文本列
                if (cd.ColBoolButton == 0)
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(index);
                    colText.HeaderText = cd.HeaderText;
                    colText.MappingName = cd.MappingName;
                    colText.Width = cd.ColWidth;
                    colText.NullText = "";
                    colText.ReadOnly = cd.ColReadOnly;
                    colText.TextBox.Visible = false;
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGridMx_colText_CheckCellEnabled);

                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    DataColumn datacol;
                    if (cd.MappingName.Trim() == "ypsl" || cd.MappingName == "金额" || cd.MappingName == "批发金额")
                        datacol = new DataColumn(cd.MappingName, Type.GetType("System.Decimal"));
                    else
                        datacol = new DataColumn(cd.MappingName);

                    dtTmp.Columns.Add(datacol);
                }
                #endregion

                #region 布尔列
                if (cd.ColBoolButton == 1)
                {
                    DataGridEnableBoolColumn colText = new DataGridEnableBoolColumn(index);
                    colText.HeaderText = cd.HeaderText;
                    colText.MappingName = cd.MappingName;
                    colText.Width = cd.ColWidth;
                    colText.NullText = "0";
                    colText.AllowNull = false;
                    colText.NullValue = ((short)(0));
                    colText.FalseValue = ((short)(0));
                    colText.TrueValue = ((short)(1));
                    colText.ReadOnly = cd.ColReadOnly;
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableBoolColumn.EnableCellEventHandler(myDataGridMx_colText_CheckCellEnabled);
                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    dtTmp.Columns.Add(cd.MappingName, Type.GetType("System.Int16"));
                }
                #endregion

                #region 按钮列
                if (cd.ColBoolButton == 2)
                {
                    DataGridButtonColumn btnCol = new DataGridButtonColumn(index);
                    btnCol.Dispose();
                    btnCol.HeaderText = cd.HeaderText;
                    btnCol.MappingName = cd.MappingName;
                    btnCol.Width = cd.ColWidth;
                    btnCol.CellButtonClicked += new DataGridCellButtonClickEventHandler(btnCol_CellButtonClicked);
                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);
                    xcjwDataGrid.MouseDown += new MouseEventHandler(btnCol.HandleMouseDown);
                    xcjwDataGrid.MouseUp += new MouseEventHandler(btnCol.HandleMouseUp);

                    DataColumn datacol;
                    datacol = new DataColumn(cd.MappingName);
                    dtTmp.Columns.Add(datacol);
                }
                #endregion

                index++;
            }

            xcjwDataGrid.DataSource = dtTmp;
            xcjwDataGrid.TableStyles[0].MappingName = "tbmx";

            #endregion



        }

        //添加消息树
        private void AddMssageTree(int dept_ly, System.Windows.Forms.TreeListView treeListView, Crownwood.Magic.Controls.TabPage Tabpage)
        {
            treeListView.Items.Clear();
            DataTable mytb = (DataTable)this.myDataGridMx.DataSource;
            mytb.Rows.Clear();
            //获取病区列表
            string ssql = @" select name,a.dept_id,a.d_code from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id 
                            where a.dept_id in(select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
            ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm;
            if (dept_ly > 0)
                ssql = ssql + " and  a.dept_id=" + dept_ly + "";
            ssql = ssql + " order by isnull(ward_id,'999999999')";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);

            SystemCfg cfg = new SystemCfg(8004); //住院统领发药消息树是否自动展开  0 不展开，1展开
            //获取领药消息
            DataTable tab = ZY_FY.SelectMassage(dept_ly, InstanceForm.BCurrentDept.DeptId, 0, "", Convert.ToInt32(Tabpage.Tag), _menuTag.Function_Name, InstanceForm.BDatabase);

            if (rdTL.Checked || rdCJ.Checked)
            {
                int msgType = 0;
                if (rdTL.Checked == false && rdCJ.Checked == true)
                    msgType = 1;
                DataRow[] datalist = tab.Select(string.Format(" msg_type = {0}", msgType));
                DataTable newTable = tab.Clone();
                foreach (DataRow dr in datalist)
                {
                    newTable.Rows.Add(dr.ItemArray);
                }
                tab = newTable;
            }

            #region 添加有消息的病区及消息
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                DataRow[] rows = tab.Select(string.Format("dept_ly={0}", tb.Rows[i]["dept_id"]));

                treeListView.SmallImageList = imageList1;
                //添加病区
                TreeListViewItem itemA = new TreeListViewItem("【" + rows.Length + "条】" + tb.Rows[i]["name"].ToString(), 0);
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.SubItems.Add("");
                itemA.Tag = tb.Rows[i]["dept_id"].ToString();

                itemA.ForeColor = Color.Black;
                itemA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        TreeListViewItem itemB = new TreeListViewItem(row["apply_date"].ToString(), 1);
                        itemB.SubItems.Add(row["发送人"].ToString().Trim());
                        itemB.SubItems.Add(row["memo"].ToString());
                        itemB.SubItems.Add(row["apply_id"].ToString());
                        itemB.SubItems.Add(row["apply_nurse"].ToString());
                        itemB.SubItems.Add(row["dept_ly"].ToString());
                        itemB.SubItems.Add(row["group_id"].ToString());
                        itemB.SubItems.Add(row["lyflcode"].ToString());
                        itemB.Tag = row["apply_id"].ToString();
                        itemB.BackColor = Color.White;
                        if (Convert.ToInt32(row["msg_type"]) == 1)
                        {
                            for (int d = 0; d <= itemB.SubItems.Count - 1; d++)
                                itemB.SubItems[d].ForeColor = Color.Red;
                        }
                        itemB.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                        itemA.Items.Add(itemB);

                    }
                    treeListView.Items.Add(itemA);
                    if (cfg.Config == "1")
                        treeListView.Items[i].Expand();
                }
            }
            #endregion

            if (Tabpage.Name == "tabPage1")
                Tabpage.Title = "领药消息" + "(" + tab.Rows.Count + ")";
            if (Tabpage.Name == "tabPage2")
                Tabpage.Title = "退药消息" + "(" + tab.Rows.Count + ")";
        }

        //添加统领单树
        private void AddTldTree(int dept_ly, System.Windows.Forms.TreeListView treeListView, Crownwood.Magic.Controls.TabPage Tabpage, string sType)
        {
            treeListView.Items.Clear();
            DataTable mytb = (DataTable)this.myDataGridMx.DataSource;

            mytb.Rows.Clear();

            long tldCount = 0;
            decimal tldJe = 0;

            int lylx = 0;
            if (_menuTag.Function_Name == "Fun_ts_yf_zyfy_tld_by"
                || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                lylx = 1;
            SystemCfg cfg = new SystemCfg(8004);


            string ssql = @" select name,a.dept_id from jc_dept_property a left join jc_ward b on a.dept_id=b.dept_id
                            where a.dept_id in(
                            select dept_id from dbo.JC_DEPT_TYPE_RELATION where type_code='009')   ";
            ssql = ssql + " and  a.jgbm=" + InstanceForm._menuTag.Jgbm + " ";
            if (dept_ly > 0)
                ssql = ssql + " and  a.dept_id=" + dept_ly + "";
            ssql = ssql + " order by isnull(ward_id,'999999999')";

            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            DataTable tab = ZY_FY.SelectTld(dept_ly, InstanceForm.BCurrentDept.DeptId, this.dtptlrq1.Value.ToShortDateString(), this.dtptlrq2.Value.ToShortDateString(), "", sType, lylx, InstanceForm.BDatabase);

            treeListView.SmallImageList = imageList1;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DataRow[] rows = tab.Select(string.Format("dept_ly={0}", tb.Rows[i]["dept_id"]));
                if (rows.Length > 0)
                {
                    //添加病区
                    TreeListViewItem itemA = new TreeListViewItem(tb.Rows[i]["name"].ToString(), 0);
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.SubItems.Add("");
                    itemA.Tag = tb.Rows[i]["dept_id"].ToString();
                    itemA.ForeColor = Color.Black;
                    itemA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                    //添加子节点
                    foreach (DataRow row in rows)
                    {
                        TreeListViewItem itemB = new TreeListViewItem(row["fyrq"].ToString(), 1);
                        itemB.SubItems.Add(row["发药人"].ToString().Trim());
                        itemB.SubItems.Add(row["djh"].ToString());
                        string bz = "";
                        if (_menuTag.Function_Name == "Fun_ts_yf_zyfy_tld_by"
                            || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                            bz = "已打印 " + row["mxdycs"].ToString() + " 次";
                        else
                            bz = "已打印 " + row["hzdycs"].ToString() + " 次";
                        itemB.SubItems.Add(bz);

                        itemB.SubItems.Add(row["配药人"].ToString().Trim());
                        itemB.SubItems.Add(row["护士"].ToString().Trim());
                        itemB.SubItems.Add(row["sumlsje"].ToString());
                        itemB.Tag = row["groupid"].ToString();
                        tldCount = tldCount + 1;
                        tldJe = tldJe + Convert.ToDecimal(row["sumlsje"]);
                        itemB.BackColor = Color.White;
                        itemB.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

                        itemA.Items.Add(itemB);
                    }
                    treeListView.Items.Add(itemA);
                    if (cfg.Config == "1")
                        itemA.Expand();
                }

            }

            this.statusBar1.Panels[0].Text = "统领单张数: " + tldCount.ToString() + " 张";
            this.statusBar1.Panels[1].Text = "统领单金额: " + tldJe.ToString("0.00") + " ";
            this.statusBar1.Panels[2].Text = "";


        }

        //递归移除tabpage
        private void RemoveTabpage(Crownwood.Magic.Controls.TabControl tabcontrol)
        {
            for (int i = 0; i <= tabcontrol.TabPages.Count - 1; i++)
            {
                if (tabcontrol.TabPages[i] != this.tabPage4)
                {
                    tabcontrol.TabPages.Remove(tabcontrol.TabPages[i]);
                    RemoveTabpage(tabcontrol);
                }
            }
        }

        //添加统领方式页面
        private void AddtlflPage(DataTable tb)
        {

            RemoveTabpage(this.tabControl2);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                Crownwood.Magic.Controls.TabPage tabPage1 = new Crownwood.Magic.Controls.TabPage();
                tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                tabPage1.Location = new System.Drawing.Point(0, 25);
                tabPage1.Name = tb.Rows[i]["类型"].ToString().Trim() == "" ? "其他" : tb.Rows[i]["类型"].ToString().Trim();
                tabPage1.Title = tb.Rows[i]["类型"].ToString();
                tabPage1.Size = new System.Drawing.Size(639, 452);
                tabPage1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
																								   tabPage1});

                TrasenClasses.GeneralControls.DataGridEx myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
                System.Windows.Forms.DataGridTableStyle dataGridTableStyle1 = new DataGridTableStyle();
                myDataGrid1.TableStyles.Add(dataGridTableStyle1);
                ;
                List<ColumnDefine> columns = new List<ColumnDefine>();
                columns.Add(PubClass.NewColumnDefine("序号", "序号", 30, true, 0));
                columns.Add(PubClass.NewColumnDefine("品名", "品名", 250, true, 0));
                columns.Add(PubClass.NewColumnDefine("商品名", "商品名", 250, true, 0));
                columns.Add(PubClass.NewColumnDefine("规格", "规格", 150, true, 0));
                columns.Add(PubClass.NewColumnDefine("厂家", "厂家", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("单价", "单价", 50, true, 0));
                columns.Add(PubClass.NewColumnDefine("库存数", "库存数", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("领药数", "领药数", 55, true, 0));
                columns.Add(PubClass.NewColumnDefine("缺药数", "缺药数", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("单位", "单位", 40, false, 0));
                columns.Add(PubClass.NewColumnDefine("金额", "金额", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("货号", "货号", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("cjid", "cjid", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
                columns.Add(PubClass.NewColumnDefine("货位号", "货位号", 0, true, 0));

                DataTable dtTmp = new DataTable();
                dtTmp.TableName = "tb";
                int index = 0;
                foreach (ColumnDefine cd in columns)
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(index);
                    colText.HeaderText = cd.HeaderText;
                    colText.MappingName = cd.MappingName;
                    colText.Width = cd.ColWidth;
                    colText.NullText = "";
                    colText.ReadOnly = cd.ColReadOnly;
                    //colText.CheckCellEnabled+=new XcjwHIS.PublicControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(colText_CheckCellEnabled);
                    colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(colText_CheckCellEnabled);
                    myDataGrid1.TableStyles[0].GridColumnStyles.Add(colText);
                    DataColumn datacol = new DataColumn(cd.MappingName);
                    dtTmp.Columns.Add(datacol);
                    index++;
                }

                myDataGrid1.DataSource = dtTmp;
                myDataGrid1.TableStyles[0].MappingName = "tb";
                myDataGrid1.CaptionVisible = false;
                myDataGrid1.BackgroundColor = System.Drawing.Color.White;
                myDataGrid1.SelectionBackColor = System.Drawing.Color.White;
                myDataGrid1.ReadOnly = true;
                myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                tabPage1.Controls.Add(myDataGrid1);
                myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                if (ss.网络内容显示商品名 == true)
                    myDataGrid1.TableStyles[0].GridColumnStyles["商品名"].Width = 120;
                else
                    myDataGrid1.TableStyles[0].GridColumnStyles["商品名"].Width = 0;
            }
        }

        //点击消息时
        private void treeListView1_Click(object sender, System.EventArgs e)
        {

            System.Windows.Forms.TreeListView TreeListView = (System.Windows.Forms.TreeListView)sender;
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                TreeListViewItem item = (TreeListViewItem)TreeListView.SelectedItems[0];

                //查询或移除明细
                this.SelectOrRemoveItem(TreeListView, item);

                //计算统领单
                computeTld();

                PubStaticFun.ModifyDataGridStyle(this.myDataGridMx, 0);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                this.AddMssageTree(Convert.ToInt32(Convertor.IsNull(this.cmbbs1.SelectedValue, "0")), TreeListView, this.tabPage1);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        //添加明细或移除明细的方法
        private void SelectOrRemoveItem(System.Windows.Forms.TreeListView TreeListView, TreeListViewItem item)
        {
            #region 改变选择对象的颜色
            if (item.ImageIndex == 0)
                return;
            if (item.BackColor != Color.GreenYellow)
            {
                #region 判断选择了哪个科室
                bool Byes = false;
                for (int i = 0; i <= TreeListView.Items.Count - 1; i++)
                {
                    //如果当前节点是科室并且已选中
                    if (TreeListView.Items[i].ImageIndex == 0 && TreeListView.Items[i].BackColor == Color.GreenYellow)
                    {
                        //如果正要选择的节点的父节点与已选择的科室不同
                        if (item.Parent.Tag.ToString().Trim() != TreeListView.Items[i].Tag.ToString().Trim())
                        {
                            if (MessageBox.Show(this, "因为不能跨科室选择消息,当前操作将取消原有的选择,您确认继续吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                            Byes = true;
                        }
                    }
                }

                //如果确认跨科室
                if (Byes == true)
                {
                    DataTable tbb = (DataTable)this.myDataGridMx.DataSource;
                    tbb.Rows.Clear();
                    for (int i = 0; i <= TreeListView.Items.Count - 1; i++)
                        this.ChangeTreeItemColorToWhite(TreeListView.Items[i]);
                }
                #endregion

                item.BackColor = Color.GreenYellow;
                item.SubItems[0].BackColor = Color.GreenYellow;
                item.SubItems[1].BackColor = Color.GreenYellow;
                item.SubItems[2].BackColor = Color.GreenYellow;
                item.SubItems[3].BackColor = Color.GreenYellow;
                item.Selected = false;
            }
            else
            {
                item.BackColor = Color.White;
                item.SubItems[0].BackColor = Color.White;
                item.SubItems[1].BackColor = Color.White;
                item.SubItems[2].BackColor = Color.White;
                item.SubItems[3].BackColor = Color.White;
                item.Selected = false;
            }
            #endregion

            #region 改变父对象的颜色
            bool bflag = false;
            for (int i = 0; i <= item.Parent.Items.Count - 1; i++)
            {
                if (item.Parent.Items[i].BackColor == Color.GreenYellow)
                {
                    bflag = true;
                }
            }

            if (bflag == true)
            {
                item.Parent.SubItems[0].BackColor = Color.GreenYellow;
                item.Parent.SubItems[1].BackColor = Color.GreenYellow;
                item.Parent.SubItems[2].BackColor = Color.GreenYellow;
                item.Parent.SubItems[3].BackColor = Color.GreenYellow;
                item.Parent.Selected = false;
            }
            else
            {
                item.Parent.SubItems[0].BackColor = Color.White;
                item.Parent.SubItems[1].BackColor = Color.White;
                item.Parent.SubItems[2].BackColor = Color.White;
                item.Parent.SubItems[3].BackColor = Color.White;
                item.Parent.Selected = false;
            }
            #endregion

            #region 查询或去除明细
            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
            if (new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString())) != Guid.Empty)
                tb.Rows.Clear();
            DataTable tbmx = new DataTable();
            //查询或去除明细
            if (item.BackColor != Color.White)
            {
                DataTable tab = tb.Copy();/////////////////////////////
                tbmx = ZY_FY.SelectMassageMx(item.SubItems[7].Text, item.Tag.ToString(), item.SubItems[0].Text, item.Parent.Tag.ToString(), 0, InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                if (tbmx.Rows.Count == 0)
                {
                    ZY_FY.UpdateMsg_Delete(new Guid(item.Tag.ToString()), InstanceForm.BDatabase);
                }

                tab.TableName = "tbmx";
                FunBase.AddRowtNo(tab);
                FunBase.AddRowtNo(tbmx);
                /*
                 * update code by pengy  7-7 14:55 
                 * 按处方日期 病人排序消息明细
                 */
                DataTable datalist = GetDatatableForGrid(tbmx, false);
                this.myDataGridMx.DataSource = ReOrderDataTable(datalist);
            }
            else
            {
                DataTable tbmxCopy = tb.Clone();
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (new Guid(tb.Rows[i]["apply_id"].ToString().Trim()) != new Guid(item.Tag.ToString().Trim()))
                        tbmxCopy.ImportRow(tb.Rows[i]);
                }
                tb.Rows.Clear();
                FunBase.AddRowtNo(tbmxCopy);
                /*
                 * update code by pengy  7-7 14:55 
                 * 按处方日期 病人排序消息明细
                 */
                DataTable datalist = tbmxCopy;
                this.myDataGridMx.DataSource = ReOrderDataTable(datalist);
            }

            //汇总当前的分类
            DataTable tbMx = (DataTable)myDataGridMx.DataSource;
            string[] GroupbyField1 ={ "类型" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };
            TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
            xcset1.TsDataTable = tbMx;
            DataTable tbfl = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "选择=true");///////////////////
            DataTable tbfl2 = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");
            panel_chk.Controls.Clear();
            for (int i = 0; i <= tbfl2.Rows.Count - 1; i++)
            {

                CheckBox checkBox1;
                checkBox1 = new System.Windows.Forms.CheckBox();
                panel_chk.Controls.Add(checkBox1);
                checkBox1.AutoSize = true;
                checkBox1.Dock = System.Windows.Forms.DockStyle.Left;
                checkBox1.Location = new System.Drawing.Point(0, 0);
                checkBox1.Name = "checkBox" + i.ToString();
                checkBox1.Size = new System.Drawing.Size(77, 40);
                checkBox1.TabIndex = 4;
                checkBox1.Text = tbfl2.Rows[i]["类型"].ToString();
                checkBox1.UseVisualStyleBackColor = true;
                checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
            }
            //			DataTable tt=(DataTable)this.myDataGridMx.DataSource;
            //			decimal sumje=0;
            //			for(int i=0;i<=tt.Rows.Count-1;i++)
            //				sumje=sumje+Convert.ToDecimal(tt.Rows[i]["金额"]);
            //			this.Text=sumje.ToString();
            #endregion
        }

        //双击科室节点时
        private void treeListView1_DoubleClick(object sender, System.EventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            System.Windows.Forms.TreeListView TreeListView = (System.Windows.Forms.TreeListView)sender;
            try
            {

                //如果不是一级节点就退出
                if (TreeListView.SelectedItems.Count == 0)
                    return;
                int Ncount = 0;
                TreeListViewItem item = (TreeListViewItem)TreeListView.SelectedItems[0];
                if (item.ImageIndex != 0)
                    return;
                DataTable tbmx = (DataTable)this.myDataGridMx.DataSource;
                Ncount = tbmx.Rows.Count;

                //myDataGridMx.TableStyles[0].GridColumnStyles["缺药"].Width = 55;
                //清除网格内容
                tbmx.Rows.Clear();
                //将所有节点变成白色
                for (int i = 0; i <= TreeListView.Items.Count - 1; i++)
                    this.ChangeTreeItemColorToWhite(TreeListView.Items[i]);

                for (int i = 0; i <= item.Items.Count - 1; i++)
                {
                    //如果以前网格中没有明细就添加明细，如果以前有明细就把节点置为没有选中
                    if (Ncount == 0)
                        this.SelectOrRemoveItem(TreeListView, item.Items[i]);
                }

                item.Selected = false;
                checkBox3.Checked = true;
                chkAllFee.Checked = true;//Modify By Tany 2015-03-17

                //Modify By Tany 2015-03-23 增加处方日期过滤
                //Modify by jchl 2015-03-27 处方日期过滤需在顶端，过滤掉处方日期的对应的冲减正记录
                if (checkBox4.Checked)
                    moveCfrq();

                //统领时,当有退药时如果没有正数抵消,则默认不选择
                if (chkkcfs.Checked == true)
                    moveTyxx();
                if (chkkccc.Checked == true)
                    moveKccc();

                //计算统领单
                computeTld();
                PubStaticFun.ModifyDataGridStyle(this.myDataGridMx, 0);


            }
            catch (System.Exception err)
            {

                MessageBox.Show(err.Message);
                this.AddMssageTree(Convert.ToInt32(Convertor.IsNull(this.cmbbs1.SelectedValue, "0")), TreeListView, this.tabPage1);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        //统领时,当有退药时如果没有正数抵消,则默认不选择
        private void moveTyxx()
        {
            //重新计算统领单
            DataTable tb = (DataTable)myDataGridMx.DataSource;
            string[] GroupbyField3 ={ "类型", "货号", "品名", "商品名", "规格", "厂家", "库存数", "cjid", "批发价", "lsj", "dwbl", "zxdw", "货位号" };
            string[] ComputeField3 ={ "ypsl", "金额", "批发金额" };
            string[] CField3 ={ "sum", "sum", "sum" };
            TrasenFrame.Classes.TsSet xcset4 = new TrasenFrame.Classes.TsSet();
            xcset4.TsDataTable = tb;

            DataTable tbhz;
            try
            {
                DataRow[] selrow = tb.Select("选择=true");
                DataTable tbsel = tb.Clone();
                for (int i = 0; i <= selrow.Length - 1; i++)
                    tbsel.ImportRow(selrow[i]);
                tbhz = FunBase.GroupbyDataTable(tbsel, GroupbyField3, ComputeField3, CField3, null);

                //退药抵扣
                for (int i = 0; i <= tbhz.Rows.Count - 1; i++)
                {
                    if (Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) >= 0)
                        continue;
                    decimal ypsl = Convert.ToDecimal(tbhz.Rows[i]["ypsl"]);
                    int cjid = Convert.ToInt32(tbhz.Rows[i]["cjid"]);
                    decimal kc_ypsl = 0;
                    DataRow[] selrow_mx = tb.Select("ypsl<0 and cjid=" + cjid + "", "ypsl");
                    for (int x = 0; x <= selrow_mx.Length - 1; x++)
                    {
                        if (kc_ypsl > ypsl)
                        {
                            selrow_mx[x]["选择"] = (int)0;
                            kc_ypsl = kc_ypsl + Convert.ToDecimal(selrow_mx[x]["ypsl"]);
                        }
                    }
                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
        }

        //统领时,当有领药超出库存时
        private void moveKccc()
        {
            //重新计算统领单
            DataTable tb = (DataTable)myDataGridMx.DataSource;
            string[] GroupbyField3 ={ "类型", "货号", "品名", "商品名", "规格", "厂家", "库存数", "cjid", "批发价", "lsj", "dwbl", "zxdw", "货位号" };
            string[] ComputeField3 ={ "ypsl", "金额", "批发金额" };
            string[] CField3 ={ "sum", "sum", "sum" };
            TrasenFrame.Classes.TsSet xcset4 = new TrasenFrame.Classes.TsSet();
            xcset4.TsDataTable = tb;

            DataTable tbhz;
            try
            {
                DataRow[] selrow = tb.Select("选择=true");
                DataTable tbsel = tb.Clone();
                for (int i = 0; i <= selrow.Length - 1; i++)
                    tbsel.ImportRow(selrow[i]);
                tbhz = FunBase.GroupbyDataTable(tbsel, GroupbyField3, ComputeField3, CField3, null);

                //退药抵扣
                //tb.Reset();
                for (int i = 0; i <= tbhz.Rows.Count - 1; i++)
                {
                    if (Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) < Convert.ToDecimal(tbhz.Rows[i]["库存数"]))
                        continue;
                    decimal ypsl = Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) - Convert.ToDecimal(tbhz.Rows[i]["库存数"]);
                    int cjid = Convert.ToInt32(tbhz.Rows[i]["cjid"]);
                    decimal kc_ypsl = 0;
                    DataRow[] selrow_mx = tb.Select("ypsl>0 and cjid=" + cjid + "", "ypsl");
                    for (int x = 0; x <= selrow_mx.Length - 1; x++)
                    {
                        if (kc_ypsl < ypsl)
                        {
                            selrow_mx[x]["选择"] = (int)0;
                            kc_ypsl = kc_ypsl + Convert.ToDecimal(selrow_mx[x]["ypsl"]);
                        }
                    }
                }
                //tb.AcceptChanges();
                myDataGridMx.Refresh();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
        }

        //统领时，将超出处方日期的不勾选 Add By Tany 2015-03-23
        private void moveCfrq()
        {
            if (!checkBox4.Checked)
            {
                return;
            }

            DataTable tb = (DataTable)myDataGridMx.DataSource;
            try
            {
                DateTime currentTime = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 23, 59, 59);
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    //Modify By Tany 2015-05-21 增加小于等于和等于的判断
                    if ((rbXydy.Checked && currentTime >= Convert.ToDateTime(tb.Rows[i]["处方日期"].ToString()))
                        || (rbDy.Checked && currentTime.ToShortDateString() == Convert.ToDateTime(tb.Rows[i]["处方日期"].ToString()).ToShortDateString()))
                    {
                        continue;
                    }
                    else
                    {
                        tb.Rows[i]["选择"] = (int)0;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
        }

        //点击统领单时
        private void treeListView3_Click(object sender, System.EventArgs e)
        {
            try
            {

                decimal sumlsje = 0;
                this.statusBar1.Panels[2].Text = "";
                this.Cursor = PubStaticFun.WaitCursor();

                TreeListViewItem item = treeListView3.SelectedItems[0];
                if (item.ImageIndex == 0)
                    return;

                //查询统领汇总单
                DataTable tb = ZY_FY.SelectTldHz(item.Tag.ToString(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

                this.myDataGridMx.Tag = item.Tag.ToString();

                //汇总当前的统领分类
                string[] GroupbyField1 ={ "类型" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                DataTable tbfl = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "");

                //添加分类页面
                this.AddtlflPage(tbfl);


                //添加每个统类分类的药品
                for (int i = 1; i <= this.tabControl2.TabPages.Count - 1; i++)
                {
                    for (int j = 0; j <= this.tabControl2.TabPages[i].Controls.Count - 1; j++)
                    {
                        //如果是网格
                        if (this.tabControl2.TabPages[i].Controls[j].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                        {
                            TrasenClasses.GeneralControls.DataGridEx mydatagrid = (TrasenClasses.GeneralControls.DataGridEx)this.tabControl2.TabPages[i].Controls[j];
                            DataTable mytb = (DataTable)mydatagrid.DataSource;

                            DataRow[] rows = tb.Select("类型='" + this.tabControl2.TabPages[i].Title.Trim() + "'", "hwh,yppm");
                            for (int x = 0; x <= rows.Length - 1; x++)
                            {
                                DataRow row = mytb.NewRow();
                                row["序号"] = mytb.Rows.Count + 1;
                                row["品名"] = rows[x]["yppm"];
                                row["商品名"] = rows[x]["ypspm"];
                                row["规格"] = rows[x]["ypgg"];
                                row["厂家"] = rows[x]["sccj"];
                                row["单价"] = rows[x]["lsj"];
                                row["库存数"] = rows[x]["kcl"];
                                row["领药数"] = rows[x]["ypsl"];
                                row["缺药数"] = rows[x]["qysl"];
                                row["单位"] = rows[x]["ypdw"];
                                row["金额"] = rows[x]["lsje"];
                                row["货号"] = rows[x]["shh"];
                                row["cjid"] = rows[x]["cjid"];
                                row["dwbl"] = rows[x]["ydwbl"];
                                row["货位号"] = rows[x]["hwh"];
                                sumlsje = sumlsje + Convert.ToDecimal(rows[x]["lsje"]);
                                mytb.Rows.Add(row);
                            }
                        }
                    }
                }

                this.statusBar1.Panels[2].Text = "当前单据金额:" + sumlsje.ToString("0.00");

                //查询明细单
                if (this.chkmx.Checked == true)
                {
                    myDataGridMx.TableStyles[0].GridColumnStyles["缺药"].Width = 0;

                    string sql = string.Format("select bylx from yf_tld where groupid = '{0}'", item.Tag.ToString());
                    DataTable tmpTable = InstanceForm.BDatabase.GetDataTable(sql);

                    DataTable tbmx = ZY_FY.SelectTldMx(item.Tag.ToString(), InstanceForm.BDatabase);
                    tbmx.TableName = "tbmx";



                    //this.myDataGridMx.DataSource=tbmx;
                    FunBase.AddRowtNo(tbmx);
                    DataTable datalist = GetDatatableForGrid(tbmx, true);
                    //DataView dv = datalist.DefaultView;
                    //dv.Sort = "处方日期 DESC,姓名 DESC";

                    string bylx = tmpTable != null && tmpTable.Rows.Count > 0 ? tmpTable.Rows[0]["bylx"].ToString() : "";
                    if (bylx == "1")
                        bylx = "自动";
                    else if (bylx == "2")
                        bylx = "手工";
                    else
                        bylx = "未知";
                    DataTable dt = ReOrderDataTable(datalist);
                    DataColumn bylxColumn = new DataColumn();
                    bylxColumn.Caption = "包药方式";
                    bylxColumn.ColumnName = "包药方式";
                    bylxColumn.DataType = typeof(string);

                    DataColumn groupidColumn = new DataColumn();
                    groupidColumn.Caption = "groupid";
                    groupidColumn.ColumnName = "groupid";
                    groupidColumn.DataType = typeof(string);
                    dt.Columns.AddRange(new DataColumn[] { bylxColumn, groupidColumn });

                    foreach (DataRow tmpRow in dt.Rows)
                    {
                        tmpRow["包药方式"] = bylx;
                        tmpRow["groupid"] = item.Tag.ToString();
                    }
                    this.myDataGridMx.DataSource = dt;
                    PubStaticFun.ModifyDataGridStyle(this.myDataGridMx, 0);
                }

                #region 改变选择对象的颜色
                if (item.ImageIndex == 0)
                    return;

                for (int i = 0; i <= this.treeListView3.Items.Count - 1; i++)
                    this.ChangeTreeItemColorToWhite(this.treeListView3.Items[i]);

                if (item.BackColor != Color.GreenYellow)
                {
                    item.BackColor = Color.GreenYellow;
                    item.SubItems[0].BackColor = Color.GreenYellow;
                    item.SubItems[1].BackColor = Color.GreenYellow;
                    item.SubItems[2].BackColor = Color.GreenYellow;
                    item.SubItems[3].BackColor = Color.GreenYellow;
                    item.Selected = false;
                }

                #endregion

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                //还原鼠标指针 Modify By Tany 2015-05-25
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// jianqg 20133-5-7增加
        /// </summary>
        /// <param name="tbSource"></param>
        /// <param name="ClearOldData"></param>
        private DataTable GetDatatableForGrid(DataTable tbSource, bool ClearOldData)
        {
            //"处方日期 DESC,姓名 DESC";
            try
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                DataTable tab = tbSource.Clone();
                if (ClearOldData == false)
                    tab = tb.Copy();
                for (int i = 0; i <= tbSource.Rows.Count - 1; i++)
                {
                    tab.ImportRow(tbSource.Rows[i]);
                }
                return tab;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 对网格的数据重排序
        /// </summary>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        private DataTable ReOrderDataTable(DataTable dtSource)
        {
            DataTable dtOrder = dtSource.Clone();

            DataRow[] rows = dtSource.Select("", "姓名 ASC,处方日期 ASC");

            for (int i = 0; i < rows.Length; i++)
            {
                dtOrder.Rows.Add(rows[i].ItemArray);
                dtOrder.Rows[dtOrder.Rows.Count - 1]["序号"] = i + 1;
            }

            return dtOrder;
        }

        //生成统领单
        private void computeTld()
        {
            this.myDataGridMx.Tag = null;
            this.statusBar1.Panels[2].Text = "";
            decimal sumlsje = 0;

            DataTable tb = (DataTable)this.myDataGridMx.DataSource;

            //汇总当前的分类
            string[] GroupbyField1 ={ "类型" };
            string[] ComputeField1 ={ };
            string[] CField1 ={ };
            TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
            xcset1.TsDataTable = tb;
            DataTable tbfl = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "选择=true");///////////////////


            //添加分类页面
            AddtlflPage(tbfl);//
            string[] GroupbyField ={ "货号", "品名", "商品名", "规格", "厂家", "库存数", "cjid", "批发价", "lsj", "dwbl", "zxdw", "货位号" };/////,"ifby"
            string[] ComputeField ={ "ypsl", "金额" };
            string[] CField ={ "sum", "sum" };

            TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
            xcset.TsDataTable = tb;
            for (int i = 1; i <= this.tabControl2.TabPages.Count - 1; i++)
            {
                for (int j = 0; j <= this.tabControl2.TabPages[i].Controls.Count - 1; j++)
                {
                    //如果是网格
                    if (this.tabControl2.TabPages[i].Controls[j].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                    {
                        //汇总每个统领分类
                        //DataTable tab=xcset.GroupTable(GroupbyField,ComputeField,CField," 类型='"+this.tabControl2.TabPages[i].Title.Trim()+"' and 选择=true");

                        DataTable tab;
                        DataRow[] selrow = tb.Select(" 类型='" + this.tabControl2.TabPages[i].Title.Trim() + "' and 选择=true");
                        DataTable tbsel = tb.Clone();
                        for (int w = 0; w <= selrow.Length - 1; w++)
                            tbsel.ImportRow(selrow[w]);
                        tab = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);

                        TrasenClasses.GeneralControls.DataGridEx mydatagrid = (TrasenClasses.GeneralControls.DataGridEx)this.tabControl2.TabPages[i].Controls[j];
                        DataTable mytb = (DataTable)mydatagrid.DataSource;
                        mytb.Rows.Clear();
                        DataRow[] rows = tab.Select("", "货位号,品名 asc");

                        //添加数据
                        #region 添加数据
                        for (int x = 0; x <= rows.Length - 1; x++)
                        {
                            DataRow row = mytb.NewRow();
                            row["序号"] = x + 1;
                            row["品名"] = rows[x]["品名"];
                            row["商品名"] = rows[x]["商品名"];
                            row["规格"] = rows[x]["规格"];
                            row["厂家"] = rows[x]["厂家"];
                            row["单价"] = rows[x]["lsj"];

                            decimal ypsl = Convert.ToDecimal(Convertor.IsNull(rows[x]["ypsl"], "0"));
                            decimal kcl = Convert.ToDecimal(Convertor.IsNull(rows[x]["库存数"], "0"));
                            float _ypsl = (float)ypsl;
                            float _kcl = (float)kcl;
                            row["库存数"] = kcl.ToString();// rows[x]["库存数"];
                            row["领药数"] = ypsl.ToString();// rows[x]["ypsl"];
                            row["缺药数"] = (kcl - ypsl) < 0 ? System.Math.Abs(kcl - ypsl) : 0;
                            row["单位"] = Yp.SeekYpdw(Convert.ToInt32(rows[x]["zxdw"]), InstanceForm.BDatabase);
                            row["金额"] = rows[x]["金额"];
                            row["货号"] = rows[x]["货号"];
                            row["cjid"] = rows[x]["cjid"];
                            row["dwbl"] = rows[x]["dwbl"];
                            row["货位号"] = rows[x]["货位号"];
                            //sumlsje=sumlsje+Convert.ToDecimal(Convertor.IsNull(rows[x]["金额"],"0"));
                            sumlsje = sumlsje + (Convert.IsDBNull(rows[x]["金额"]) ? 0 : Convert.ToDecimal(rows[x]["金额"]));
                            mytb.Rows.Add(row);
                        }

                        #endregion
                    }
                }
            }

            this.statusBar1.Panels[2].Text = "当前单据金额:" + sumlsje.ToString("0.00");

            PubStaticFun.ModifyDataGridStyle(this.myDataGridMx, 0);

        }

        void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox chk = (CheckBox)sender;
            DataTable tb = (DataTable)this.myDataGridMx.DataSource;

            DataRow[] rows = tb.Select("类型='" + chk.Text + "'");
            for (int i = 0; i <= rows.Length - 1; i++)
                rows[i]["选择"] = chk.Checked == true ? (short)1 : (short)0;
            computeTld();
        }

        //双击消息明细时
        private void myDataGridMx_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (this.tabControl1.SelectedTab == this.tabPage3)
                    return;
                TrasenClasses.GeneralControls.ButtonDataGridEx myGridDate = (TrasenClasses.GeneralControls.ButtonDataGridEx)sender;
                int nrow = myGridDate.CurrentCell.RowNumber;
                DataTable tb = (DataTable)myGridDate.DataSource;
                if (myGridDate.TableStyles[0].GridColumnStyles[myGridDate.CurrentCell.ColumnNumber].HeaderText != "选择")
                    return;
                if (nrow > tb.Rows.Count - 1)
                    return;
                tb.Rows[nrow]["选择"] = Convert.ToBoolean(tb.Rows[nrow]["选择"]) == true ? false : true;
                if (myGridDate.Name == "myDataGridMx")
                    this.computeTld();
                PubStaticFun.ModifyDataGridStyle(myGridDate, 0);

                //if (myGridDate.Name == "myhy")
                //{
                //    if (tb.Rows.Count == 0) return;
                //    int cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);
                //    decimal zsl = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(ypsl)", "选择=true and cjid=" + cjid + ""), "0"));
                //    f.statusStrip1.Items[0].Text = "须替换用量:" + zsl.ToString() + Yp.SeekYpdw(Convert.ToInt32(tb.Rows[0]["zxdw"]));

                //}
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //明细列的按钮事件
        private void btnCol_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
        {
            if (this.tabControl2.SelectedTab == this.tabPage3)
                return;

            try
            {

                DataGridButtonColumn butCol = (DataGridButtonColumn)sender;
                TrasenClasses.GeneralControls.ButtonDataGridEx myGridDate = (TrasenClasses.GeneralControls.ButtonDataGridEx)butCol.DataGridTableStyle.DataGrid;
                ;
                int nrow = myGridDate.CurrentCell.RowNumber;
                DataTable tb = (DataTable)myGridDate.DataSource;
                if (nrow > tb.Rows.Count - 1)
                    return;

                Guid zy_id = new Guid(tb.Rows[nrow]["zy_id"].ToString());
                int cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);

                if (butCol.HeaderText == "缺药")
                {
                    if (Convert.ToDecimal(tb.Rows[nrow]["数量"]) < 0)
                    {
                        MessageBox.Show("退药信息不能打缺");
                        return;
                    }

                    if (MessageBox.Show(this, "您确定要将此条药品记录列为缺药吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    ZY_FY.UpdateFeeChargeTlfs(1, "缺药cjid=" + cjid.ToString(), zy_id, InstanceForm.BDatabase);

                    DataTable tbkc = Yp.Selectkc(InstanceForm.BCurrentDept.DeptId, cjid, Yp.Seek_kcmx_table(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase), InstanceForm.BDatabase);
                    decimal kcl = 0;
                    int bdelete = 0;
                    int zxdw = 0;
                    if (tbkc.Rows.Count > 0)
                    {
                        kcl = Convert.ToDecimal(tbkc.Rows[0]["kcl"]);
                        zxdw = Convert.ToInt32(tbkc.Rows[0]["zxdw"]);
                        bdelete = Convert.ToInt32(tbkc.Rows[0]["bdelete"]);
                    }

                    SystemCfg cfg8036 = new SystemCfg(8036);
                    if (bdelete == 0 && cfg8036.Config == "1")
                    {
                        if (MessageBox.Show(this, "该药当前库存是" + kcl.ToString() + Yp.SeekYpdw(zxdw, InstanceForm.BDatabase) + ",您要禁用该药品库存吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                InstanceForm.BDatabase.BeginTransaction();
                                string ssql = "update yf_kcmx set bdelete=1 where cjid=" + cjid + " and deptid=" + InstanceForm.BCurrentDept.DeptId + "";
                                InstanceForm.BDatabase.DoCommand(ssql);
                                ssql = "update yf_kcph set bdelete=1 where cjid=" + cjid + " and deptid=" + InstanceForm.BCurrentDept.DeptId + "";
                                InstanceForm.BDatabase.DoCommand(ssql);
                                InstanceForm.BDatabase.CommitTransaction();

                                string bz = " 当时该批号库存为 " + kcl.ToString() + Yp.SeekYpdw(zxdw, InstanceForm.BDatabase);
                                Yp.InsertLog("禁用药品", InstanceForm.BCurrentDept.DeptId, cjid, InstanceForm.BCurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(), bz, InstanceForm.BDatabase);
                            }
                            catch (System.Exception err)
                            {
                                InstanceForm.BDatabase.RollbackTransaction();
                                MessageBox.Show("", "报错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    tb.Rows.Remove(tb.Rows[nrow]);
                    myGridDate.DataSource = tb;
                    this.computeTld();
                }
                if (butCol.HeaderText == "转发")
                {
                    Frmks f = new Frmks();
                    f.cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);
                    f.deptid = InstanceForm.BCurrentDept.DeptId;
                    f.ShowDialog();

                    if (f.mdks > 0)
                    {
                        ZY_FY.UpdateFeeChargeExecDeptID(f.mdks, "转发", zy_id, InstanceForm.BDatabase);
                        tb.Rows.Remove(tb.Rows[nrow]);
                        myGridDate.DataSource = tb;
                        this.computeTld();
                    }
                }

                if (butCol.HeaderText == "换药")
                {

                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }

        }

        //消息或统领单明细查询
        private void butmxcx_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                DataTable tab = tb.Clone();
                DataRow[] rows;
                string swhere = "";
                //品名
                if (Convert.ToInt32(txtypmc.Tag) > 0 && txtypmc.Text.Trim() != "")
                    swhere = " cjid='" + txtypmc.Tag.ToString().Trim() + "'";
                //床位
                if (txtcw.Text.Trim() != "")
                    swhere = swhere == "" ? swhere = "床号='" + txtcw.Text.Trim() + "'" : swhere = swhere + " and 床号='" + txtcw.Text.Trim() + "'";
                //姓名
                if (txtxm.Text.Trim() != "")
                    swhere = swhere == "" ? swhere = "姓名='" + txtxm.Text.Trim() + "'" : swhere = swhere + " and 姓名='" + txtxm.Text.Trim() + "'";
                //住院号
                if (txtzyh.Text.Trim() != "")
                    swhere = swhere == "" ? swhere = "住院号='" + txtzyh.Text.Trim() + "'" : swhere = swhere + " and 住院号='" + txtzyh.Text.Trim() + "'";


                rows = tb.Select(swhere);
                if (checkBox4.Checked)
                {
                    for (int x = 0; x < rows.Length; x++)
                    {
                        DateTime currentTime = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 23, 59, 59);
                        if (currentTime >= Convert.ToDateTime(rows[x]["处方日期"].ToString()))
                            tab.ImportRow(rows[x]);
                    }
                }
                else
                {
                    for (int i = 0; i <= rows.Length - 1; i++)
                        tab.ImportRow(rows[i]);
                }
                TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
                System.Windows.Forms.DataGridTableStyle dataGridTableStyle1 = new DataGridTableStyle();
                dataGridTableStyle1.AllowSorting = false;
                myDataGrid1.TableStyles.Add(dataGridTableStyle1);
                myDataGrid1.CaptionVisible = false;
                myDataGrid1.ReadOnly = true;
                myDataGrid1.BackgroundColor = System.Drawing.Color.White;
                myDataGrid1.SelectionBackColor = System.Drawing.Color.White;
                myDataGrid1.AllowSorting = false;
                myDataGrid1.Click += new EventHandler(myDataGridMx_DoubleClick);

                //初始化网格
                CshMxGrid(myDataGrid1);

                //显示查询结果
                myDataGrid1.DataSource = tab;

                Frmmxcx f = new Frmmxcx();
                f.panel2.Controls.Add(myDataGrid1);
                myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
                PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);
                myDataGrid1.TableStyles[0].GridColumnStyles["缺药"].Width = 0;

                if (this.tabControl1.SelectedTab == this.tabPage3)
                {
                    f.butok.Visible = false;
                    f.butall.Visible = false;
                    f.butuall.Visible = false;
                }
                f.ShowDialog();

                //更新明细的选择结果
                if (f.Bselect == true)
                {
                    DataTable tbmx = (DataTable)myDataGrid1.DataSource;
                    TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                    xcset.TsDataTable = tb;//Modify By Tany 2015-03-20 这里要用结果集的全集，否则会导致部分药没发但是又没重新生成统领单

                    for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                    {
                        ItemEx[] item = new ItemEx[1];
                        item[0].Text = "选择";
                        item[0].Value = (short)(Convert.ToInt16(tbmx.Rows[i]["选择"]));
                        xcset.UpdateField(item, "zy_id='" + tbmx.Rows[i]["zy_id"].ToString().Trim() + "'");
                    }
                    ////////////////
                    FunBase.AddRowtNo(xcset.TsDataTable);

                    DataTable datalist = xcset.TsDataTable;

                    this.myDataGridMx.DataSource = ReOrderDataTable(datalist);
                    this.computeTld();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //关闭窗口
        private void butquit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        //发药按钮事件
        private void butfy_Click(object sender, System.EventArgs e)
        {
            bpcgl = Yp.BPcgl(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);//进行批次管理

            if (!bpcgl)
            {
                #region 不进行批次管理
                if (new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString())) != Guid.Empty)
                {
                    MessageBox.Show("当前药品已发药不能再次发药");
                    return;
                }

                if (Convertor.IsNull(cmbpyr.SelectedValue, "") == "")
                {
                    MessageBox.Show("请选择配药人", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #region 权限确认
                try
                {
                    if ((new SystemCfg(8008)).Config == "1")
                    {
                        string dlgvalue = DlgPW.Show();
                        string pwStr = dlgvalue; //YS.Password;
                        bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                        if (!bOk)
                        {
                            FrmMessageBox.Show("你没有通过权限确认，不能发药！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Cursor = Cursors.Default;
                            return;
                        }
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                SystemCfg cfg8203 = new SystemCfg(8203);
                string alertDept = cfg8203.Config.Trim();
                if (!string.IsNullOrEmpty(alertDept))
                {
                    if (alertDept.Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
                    {
                        if (MessageBox.Show("是否需要发药？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                            return;
                    }
                }

                this.Cursor = PubStaticFun.WaitCursor();

                DataTable tb = (DataTable)this.myDataGridMx.DataSource;

                //验证PIVAS审核标志 Modify By Tany 2015-04-20
                //Modify By Tany 2015-05-04 增加选择框确认是否验证这个状态
                if (!chkPivasCHK.Checked)
                {
                    CheckPvsSH(tb);
                }

                //汇总当前要发药消息的条数
                string[] GroupbyField1 ={ "dept_ly", "apply_id", "apply_date", "lyflcode" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb;
                DataTable tb_msg = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "选择=true");
                if (tb_msg.Rows.Count == 0)
                {
                    MessageBox.Show("没有要发药的消息");
                    this.Cursor = Cursors.Arrow;
                    return;
                }

                //汇总当前不选择发药的消息条数
                TrasenFrame.Classes.TsSet xcset2 = new TrasenFrame.Classes.TsSet();
                xcset2.TsDataTable = tb;
                DataTable tb_Umsg = xcset2.GroupTable(GroupbyField1, ComputeField1, CField1, "选择=false");

                //汇总当前金额
                string[] GroupbyField2 ={ };
                string[] ComputeField2 ={ "金额", "批发金额" };
                string[] CField2 ={ "sum", "sum" };
                TrasenFrame.Classes.TsSet xcset3 = new TrasenFrame.Classes.TsSet();
                xcset3.TsDataTable = tb;
                DataTable tbje = xcset3.GroupTable(GroupbyField2, ComputeField2, CField2, "选择=true");

                //重新计算统领单
                string[] GroupbyField3 ={ "类型", "货号", "品名", "商品名", "规格", "厂家", "库存数", "cjid", "批发价", "lsj", "dwbl", "zxdw", "货位号" };
                string[] ComputeField3 ={ "ypsl", "金额", "批发金额", "ypcjs" };
                string[] CField3 ={ "sum", "sum", "sum", "sum" };
                TrasenFrame.Classes.TsSet xcset4 = new TrasenFrame.Classes.TsSet();
                xcset4.TsDataTable = tb;
                //DataTable tbhz=xcset4.GroupTable(GroupbyField3,ComputeField3,CField3,"选择=true");


                #region Modify by dyw 2014/7/1增加冲减数
                if (!tb.Columns.Contains("ypcjs"))
                {
                    tb.Columns.Add(new DataColumn("ypcjs", Type.GetType("System.Decimal")));
                }
                foreach (DataRow row in tb.Select("选择=true"))
                {
                    if (Convert.ToDecimal(row["ypsl"]) < 0)
                    {
                        row["ypcjs"] = row["ypsl"];
                    }
                    else
                    {
                        row["ypcjs"] = 0;
                    }
                }
                #endregion

                DataTable tbhz;
                try
                {
                    DataRow[] selrow = tb.Select("选择=true");
                    DataTable tbsel = tb.Clone();
                    for (int i = 0; i <= selrow.Length - 1; i++)
                        tbsel.ImportRow(selrow[i]);
                    tbhz = FunBase.GroupbyDataTable(tbsel, GroupbyField3, ComputeField3, CField3, null);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message);
                    return;
                }

                if (tbhz.Rows.Count == 0)
                {
                    MessageBox.Show("没有要发药的药品记录");
                    this.Cursor = Cursors.Arrow;
                    return;
                }

                //返回变量
                int _err_code = -1;
                string _err_text = "";

                //时间
                string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                //领药科室
                string _dept_ly = tb_msg.Rows[0]["dept_ly"].ToString().Trim();
                //配药人
                int _py_user = Convert.ToInt32(cmbpyr.SelectedValue);
                //备注
                string _bz = this.txtbz.Text.Trim();
                //批发价、批发金额
                decimal _sumpfje = Convert.ToDecimal(tbje.Rows[0]["批发金额"]);
                decimal _sumlsje = Convert.ToDecimal(tbje.Rows[0]["金额"]);
                //统领分类
                string _stype = this.tabControl1.SelectedTab == this.tabPage1 ? "统领" : "退药";
                //string _stype=_sumlsje>0?"统领":"退药";
                //消息类型
                int _msg_type = this.tabControl1.SelectedTab == this.tabPage1 ? 0 : 1;
                //强制控制库存
                YpConfig s = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

                //领药方式
                int lylx = 0;
                if (_menuTag.Function_Name == "Fun_ts_yf_zyfy_tld_by"
                    || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                    lylx = 1;
                //总金额。。用于和上面计算的_sumlsje比较。。以防计算不正确
                decimal _zje = 0;
                long djh = Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                InstanceForm.BDatabase.BeginTransaction();

                try
                {

                    #region 添加统领单头表
                    _err_text = "添加统领单头表";
                    Guid _groupid = Guid.Empty;


                    //需要加上进货金额ncq
                    ZY_FY.SaveTld(djh, InstanceForm.BCurrentDept.DeptId, _sDate, InstanceForm.BCurrentUser.EmployeeId, Convert.ToInt32(_dept_ly), 0, _py_user, _bz, _sumpfje, _sumlsje, _stype, _menuTag.FunctionTag, out _groupid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, lylx, InstanceForm.BDatabase, 0);
                    if (_groupid == Guid.Empty || _err_code != 0)
                        throw new Exception(_err_text);
                    #endregion

                    this.myDataGridMx.Tag = _groupid.ToString();
                    this.butfy.Tag = _sDate.Trim();

                    #region 添加统领单明细表
                    _err_text = "添加统领单明细表";
                    for (int i = 0; i <= tbhz.Rows.Count - 1; i++)
                    {
                        Guid _fyid = Guid.Empty;
                        decimal _qysl = Convert.ToDecimal(tbhz.Rows[i]["库存数"]) - Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) < 0 ? Convert.ToDecimal(tbhz.Rows[i]["库存数"]) - Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) : 0;
                        _zje = _zje + Convert.ToDecimal(tbhz.Rows[i]["金额"]);
                        decimal _ypcjs = Convert.ToDecimal(tbhz.Rows[i]["ypcjs"]);
                        #region 插入统领单明细
                        ZY_FY.SaveTldMx(_groupid,
                                        Convert.ToInt32(tbhz.Rows[i]["cjid"]),
                                        tbhz.Rows[i]["货号"].ToString(),
                                        tbhz.Rows[i]["品名"].ToString(),
                                        tbhz.Rows[i]["商品名"].ToString(),
                                        tbhz.Rows[i]["规格"].ToString(),
                                        Yp.SeekYpdw(Convert.ToInt32(tbhz.Rows[i]["zxdw"]), InstanceForm.BDatabase),
                                        tbhz.Rows[i]["厂家"].ToString(),
                                        Convert.ToDecimal(tbhz.Rows[i]["库存数"]),
                                        Convert.ToDecimal(tbhz.Rows[i]["ypsl"]),
                                        _qysl,
                                        Convert.ToDecimal(tbhz.Rows[i]["批发价"]),
                                        Convert.ToDecimal(tbhz.Rows[i]["lsj"]),
                                        Convert.ToDecimal(tbhz.Rows[i]["批发金额"]),
                                        Convert.ToDecimal(tbhz.Rows[i]["金额"]),//零售金额
                                        Convert.ToString(tbhz.Rows[i]["类型"]),
                                        Convert.ToInt32(tbhz.Rows[i]["dwbl"]),
                                        s.强制控制库存,
                                        InstanceForm.BCurrentDept.DeptId,
                                        "",
                                        tbhz.Rows[i]["货位号"].ToString(),
                                        out _fyid,
                                        out _err_code,
                                        out _err_text,
                                        InstanceForm.BDatabase,
                                        0, //进价
                                        0, //进货金额
                                        "",//效期
                                        "",//批次号
                                        Guid.Empty,
                                        false, _ypcjs
                                        );
                        if (_fyid == Guid.Empty || _err_code != 0)
                            throw new Exception(_err_text);
                        #endregion
                    }
                    #endregion

                    #region 验证金额
                    _err_text = "计算金额";
                    _zje = Math.Round(_zje, 0);
                    _sumlsje = Math.Round(_sumlsje, 0);
                    if (Math.Abs(_zje - (_sumlsje)) > 1)
                    {
                        throw new Exception("计算出的总金额" + _zje.ToString() + " 不等于明细总金额" + _sumlsje.ToString() + " ，请和管理员联系");
                    }
                    #endregion

                    //没有记费的记录
                    DataRow[] rows = tb.Select("选择=true and charge_bit='0'");
                    //已记费的记录
                    DataRow[] rows2 = tb.Select("选择=true  and charge_bit='1'");

                    #region 屏蔽代码，暂时不用
                    //////////////////////////////非嫁接的方式直接更新费用表
                    ////////////////////////////if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy")
                    ////////////////////////////{
                    ////////////////////////////    for (int i = 0; i <= rows.Length - 1; i++)
                    ////////////////////////////    {
                    ////////////////////////////        long _Zyid = Convert.ToInt64(rows[i]["zy_id"]);
                    ////////////////////////////        ZY_FY.UpdateFeeChargeFy(false, _groupid, _sDate, InstanceForm.BCurrentUser.EmployeeId, _py_user, 0, _sDate, InstanceForm.BCurrentUser.EmployeeId, _Zyid);
                    ////////////////////////////    }

                    ////////////////////////////    for (int i = 0; i <= rows2.Length - 1; i++)
                    ////////////////////////////    {
                    ////////////////////////////        long _Zyid = Convert.ToInt64(rows2[i]["zy_id"]);
                    ////////////////////////////        ZY_FY.UpdateFeeChargeFy(false, _groupid, _sDate, InstanceForm.BCurrentUser.EmployeeId, _py_user, 1, _sDate, InstanceForm.BCurrentUser.EmployeeId, _Zyid);
                    ////////////////////////////    }
                    ////////////////////////////}

                    //嫁接的方式则插入临时表后再更新费用表
                    //////////////////////////////if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy")
                    //////////////////////////////{
                    #endregion

                    string ssql = "";
                    decimal _execId = 0;

                    #region 更新没有记费的记录
                    _err_text = "更新没有记费的记录";
                    //更新没有记费的记录
                    //时间撮
                    ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                    _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));

                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ", '" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'" + _groupid + "',1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }
                    if (rows.Length > 0)
                    {
                        int iii = ZY_FY.UpdateFeeChargeFy(false, _groupid, _sDate, InstanceForm.BCurrentUser.EmployeeId, _py_user, 0, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                        if (rows.Length != iii)
                        {
                            if (isPivasYF)
                            {
                                butref1_Click(null,null);
                                throw new System.Exception("错误，在做费用更新时，所更新的记录数与发药记录数不相符,操作回滚!\r\r  可能病区进行了转打包操作！  \r\r　您可以刷新数据后重试!");

                            }
                            else
                            {
                                throw new System.Exception("错误，在做费用更新时，所更新的记录数与发药记录数不相符,操作回滚!　您可以刷新数据后重试!");
                            }
                        }
                    }
                    #endregion

                    #region 更新已记费的记录
                    _err_text = "更新已记费的记录";
                    //更新已记费的记录
                    //时间撮
                    ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                    _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));

                    for (int i = 0; i <= rows2.Length - 1; i++)
                    {
                        ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows2[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ",'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'" + _groupid + "',1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }

                    if (rows2.Length > 0)
                    {
                        int iii = ZY_FY.UpdateFeeChargeFy(false, _groupid, _sDate, InstanceForm.BCurrentUser.EmployeeId, _py_user, 1, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                        if (rows2.Length != iii)
                        {
                            if (isPivasYF)
                            {
                                butref1_Click(null, null);
                                throw new System.Exception("错误，在做费用更新时，所更新的记录数与发药记录数不相符,操作回滚!\r\r  可能病区进行了转打包操作！  \r\r　您可以刷新数据后重试!");
                            }
                            else
                            {
                                throw new System.Exception("错误，在做费用更新时，所更新的记录数与发药记录数不相符,操作回滚!　您可以刷新数据后重试!");
                            }
                        }
                    }
                    #endregion

                    #region 嫁接不更新发药消息
                    _err_text = "嫁接不更新发药消息";
                    //嫁接不更新发药消息
                    if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_ly")
                    {
                        _err_text = "更新zy_apply_drug";
                        //更新zy_apply_drug
                        for (int i = 0; i <= tb_msg.Rows.Count - 1; i++)
                            ZY_FY.UpdateMsg(new Guid(tb_msg.Rows[i]["apply_id"].ToString()), _groupid, InstanceForm.BDatabase);

                        _err_text = "将没有发药的生成新的消息";
                        //将没有发药的生成新的消息
                        for (int i = 0; i <= tb_Umsg.Rows.Count - 1; i++)
                        {
                            //判断是否部分发药
                            bool byes = false;
                            for (int j = 0; j <= tb_msg.Rows.Count - 1; j++)
                            {
                                if (new Guid(tb_Umsg.Rows[i]["apply_id"].ToString().Trim()) == new Guid(tb_msg.Rows[j]["apply_id"].ToString().Trim()))
                                    byes = true;
                            }

                            Guid _apply_id = Guid.Empty;
                            if (byes == true)
                            {
                                //产生消息表
                                ZY_FY.SaveApplyDrug(tb_Umsg.Rows[i]["apply_date"].ToString().Trim(), InstanceForm.BCurrentUser.EmployeeId, Convert.ToInt32(_dept_ly), InstanceForm.BCurrentDept.DeptId, _msg_type, tb_Umsg.Rows[i]["lyflcode"].ToString().Trim(), out _apply_id, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                                if (_apply_id == Guid.Empty)
                                    throw new Exception("错误,生成消息时,消息ID为零");
                                DataRow[] RowUmsg = tb.Select("选择=false and apply_id='" + tb_Umsg.Rows[i]["apply_id"].ToString().Trim() + "'");

                                //更新此消息的明细
                                for (int x = 0; x <= RowUmsg.Length - 1; x++)
                                    ZY_FY.UpdateFeeChargeApplyID(_apply_id, new Guid(RowUmsg[x]["zy_id"].ToString()), InstanceForm.BDatabase);
                            }
                        }
                    }
                    #endregion

                    #region  使用分包机 ---摆药 LQQ 2013-4-27
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by"
                        || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                    {
                        DataTable dt_byjCS = InstanceForm.BDatabase.GetDataTable("select ZT from yk_config where BH=153 and deptid='" + InstanceForm.BCurrentDept.DeptId + "'");
                        if (dt_byjCS != null)
                        {
                            if (dt_byjCS.Rows.Count > 0)
                            {
                                if (Convert.ToString(dt_byjCS.Rows[0][0]) == "1")
                                {
                                    ParameterEx[] parameters = new ParameterEx[2];
                                    parameters[0].Value = "00000000-0000-0000-0000-000000000000";
                                    parameters[1].Value = _groupid;

                                    parameters[0].Text = "@fyid";
                                    parameters[1].Text = "@V_groupid";

                                    DataSet dset = new DataSet();
                                    InstanceForm.BDatabase.AdapterFillDataSet("sp_yf_zyfy_byj", parameters, dset, "kss", 240);
                                }
                            }
                        }
                    }

                    #endregion

                    //提交事务
                    InstanceForm.BDatabase.CommitTransaction();

                    //if (MessageBox.Show("发药成功,您要打印吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    //{
                    //    if (_menuTag.Function_Name != "Fun_ts_yf_zyfy_tld_by")
                    //        this.butprint_Click(sender, e);
                    //    else
                    //        this.butprintmx_Click(sender, e);
                    //}
                    MessageBox.Show("发药成功", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //嫁接不更移除发药消息
                    if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_ly")
                    {
                        //移除消息
                        System.Windows.Forms.TreeListView TreeListView;
                        if (this.tabControl1.SelectedTab == this.tabPage1)
                            TreeListView = this.treeListView1;
                        else
                            TreeListView = this.treeListView2;

                        for (int i = 0; i <= tb_msg.Rows.Count - 1; i++)
                            RemoveItem(TreeListView, _dept_ly, tb_msg.Rows[i]);
                        for (int i = 0; i <= tb_Umsg.Rows.Count - 1; i++)
                            RemoveItem(TreeListView, _dept_ly, tb_Umsg.Rows[i]);
                        tb.Rows.Clear();
                    }
                    else
                    {
                        tb.Rows.Clear();
                    }


                }
                catch (System.Exception err)
                {
                    this.myDataGridMx.Tag = null;
                    this.butfy.Tag = "";
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
                #endregion
            }
            else
            {
                #region 进行批次管理
                if (new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString())) != Guid.Empty)
                {
                    MessageBox.Show("当前药品已发药不能再次发药");
                    return;
                }

                if (Convertor.IsNull(cmbpyr.SelectedValue, "") == "")
                {
                    MessageBox.Show("请选择配药人", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #region 权限确认
                try
                {
                    if ((new SystemCfg(8008)).Config == "1")
                    {
                        string dlgvalue = DlgPW.Show();
                        string pwStr = dlgvalue; //YS.Password;
                        bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                        if (!bOk)
                        {
                            FrmMessageBox.Show("你没有通过权限确认，不能发药！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Cursor = Cursors.Default;
                            return;
                        }
                    }
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion


                SystemCfg cfg8203 = new SystemCfg(8203);
                string alertDept = cfg8203.Config.Trim();
                if (!string.IsNullOrEmpty(alertDept))
                {
                    if (alertDept.Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
                    {
                        if (MessageBox.Show("是否需要发药？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                            return;
                    }
                }


                this.Cursor = PubStaticFun.WaitCursor();

                DataTable tb = (DataTable)this.myDataGridMx.DataSource;

                //验证PIVAS审核标志 Modify By Tany 2015-04-20
                //Modify By Tany 2015-05-04 增加选择框确认是否验证这个状态
                if (!chkPivasCHK.Checked)
                {
                    CheckPvsSH(tb);
                }

                #region 汇总当前要发药消息的条数
                string[] GroupbyField1 ={ "dept_ly", "apply_id", "apply_date", "lyflcode" };
                string[] ComputeField1 ={ };
                string[] CField1 ={ };
                TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                xcset1.TsDataTable = tb.Copy();
                DataTable tb_msg = xcset1.GroupTable(GroupbyField1, ComputeField1, CField1, "选择=true");
                if (tb_msg.Rows.Count == 0)
                {
                    MessageBox.Show("没有要发药的消息");
                    this.Cursor = Cursors.Arrow;
                    return;
                }
                #endregion

                #region 汇总当前不选择发药的消息条数
                TrasenFrame.Classes.TsSet xcset2 = new TrasenFrame.Classes.TsSet();
                xcset2.TsDataTable = tb.Copy();
                DataTable tb_Umsg = xcset2.GroupTable(GroupbyField1, ComputeField1, CField1, "选择=false");
                #endregion

                #region 汇总当前金额 批发金额 零售金额
                string[] GroupbyField2 ={ };
                string[] ComputeField2 ={ "金额", "批发金额" };
                string[] CField2 ={ "sum", "sum" };
                TrasenFrame.Classes.TsSet xcset3 = new TrasenFrame.Classes.TsSet();
                xcset3.TsDataTable = tb.Copy();
                DataTable tbje = xcset3.GroupTable(GroupbyField2, ComputeField2, CField2, "选择=true");
                #endregion

                #region 添加列
                if (!tb.Columns.Contains("YPPCH2"))
                {
                    tb.Columns.Add(new DataColumn("YPPCH2", Type.GetType("System.String")));
                }
                if (!tb.Columns.Contains("YPPH2"))
                {
                    tb.Columns.Add(new DataColumn("YPPH2", Type.GetType("System.String")));
                }
                if (!tb.Columns.Contains("YPXQ2"))
                {
                    tb.Columns.Add(new DataColumn("YPXQ2", Type.GetType("System.String")));
                }
                if (!tb.Columns.Contains("KCID2"))
                {
                    tb.Columns.Add(new DataColumn("KCID2", Type.GetType("System.String")));
                }
                if (!tb.Columns.Contains("JHJ2"))
                {
                    tb.Columns.Add(new DataColumn("JHJ2", Type.GetType("System.Decimal")));
                }
                if (!tb.Columns.Contains("JHJE2"))
                {
                    tb.Columns.Add(new DataColumn("JHJE2", Type.GetType("System.Decimal")));
                }
                if (!tb.Columns.Contains("KDSl"))
                {
                    tb.Columns.Add(new DataColumn("KDSl", Type.GetType("System.Decimal")));//可抵数量
                }

                if (!tb.Columns.Contains("BDELETE2"))
                {
                    tb.Columns.Add(new DataColumn("BDELETE2", Type.GetType("System.Boolean")));//删除标志
                }
                if (!tb.Columns.Contains("ypcjs"))
                {
                    tb.Columns.Add(new DataColumn("ypcjs", Type.GetType("System.Decimal")));

                }
                #endregion

                DataTable tbpcmx = tb.Clone();//已分配正数
                DataTable tbpcmx_zs_wfp = tb.Clone();//未分配的正数费用
                DataTable tbpcmx_fs = tb.Clone();//已分配负数

                DataTable tbkcph = InstanceForm.BDatabase.GetDataTable(@"select ID kcid,yppch,CJID,YPPH,YPXQ,JHJ,KCL,0 
                as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where  deptid=" + InstanceForm.BCurrentDept.DeptId + " and kcl>0 and bdelete = 0");

                try
                {
                    #region 批次计算
                    DataTable tb_temp = tb.Copy();
                    //第一步，处理出库数量大于0的药品
                    DataRow[] rows_mx = tb_temp.Select("选择=true and ypsl>0 ", "ypsl desc");
                    for (int i = 0; i < rows_mx.Length; i++) //费用明细行
                    {
                        #region
                        DataRow row = rows_mx[i];
                        DataRow[] rows_kcph;
                        if (pcglfs == "0")
                            rows_kcph = tbkcph.Select(" kcl>0 and bdelete = 0 and cjid=" + row["cjid"].ToString() + "", "djsj asc,yppch asc");
                        else
                            rows_kcph = tbkcph.Select(" kcl>0 and bdelete = 0 and cjid=" + row["cjid"].ToString() + "", "ypxq asc");

                        //单位比例比较
                        if (rows_kcph.Length > 0)
                        {
                            int dwbl_kc = Convert.ToInt32(rows_kcph[0]["dwbl"]);
                            int dwbl_mx = Convert.ToInt32(row["dwbl"]);
                            if (dwbl_kc != dwbl_mx)
                            {
                                throw new Exception("单位比例发生变化,请刷新数据后重试！");
                            }
                        }

                        decimal sysl = Convert.ToDecimal(row["ypsl"]);//剩余数量
                        for (int j = 0; j < rows_kcph.Length; j++)//批号库存行
                        {
                            DataRow row1 = rows_kcph[j];
                            decimal cksl = 0;//本次出库量
                            decimal kcl = Convert.ToDecimal(row1["kcl"]);//批次库存量
                            if (kcl == 0)
                                continue;
                            if (sysl == 0)
                                break;
                            if (kcl > sysl)//库存量大于剩余数量
                            {
                                cksl = sysl;
                                sysl = 0;
                            }
                            else//库存量小于剩余数量
                            {
                                cksl = kcl;
                                sysl = sysl - kcl;
                            }
                            //回填批次相关信息
                            DataRow newrow = tb_temp.NewRow();
                            newrow = row;
                            newrow["yppch2"] = row1["yppch"];
                            newrow["ypph2"] = row1["ypph"];
                            newrow["ypxq2"] = row1["ypxq"];
                            newrow["kcid2"] = row1["kcid"];
                            decimal jhj = Math.Round(Convert.ToDecimal(row1["jhj"]) / Convert.ToInt32(row1["dwbl"]), 4);
                            newrow["jhj2"] = jhj;
                            newrow["jhje2"] = Math.Round(jhj * cksl, 3);
                            newrow["ypsl"] = cksl;
                            decimal pfj = Convert.ToDecimal(row["批发价"]);
                            newrow["批发价"] = pfj;
                            newrow["批发金额"] = Convert.ToDecimal(pfj * cksl);
                            newrow["KCID2"] = row1["kcid"];
                            newrow["KDSL"] = 0;//可抵数量

                            newrow["bdelete2"] = row1["bdelete"];//禁用标志

                            tbpcmx.ImportRow(newrow);
                            row1["kcl"] = kcl - cksl;//将批次库存减掉
                            if (sysl == 0)//如果剩余数量等于0 跳出当前批次库存循环
                            {
                                break;
                            }
                        }
                        #endregion

                        //如果剩余数量仍然>0 
                        #region 未分配的正数
                        if (sysl > 0)
                        {
                            row["ypsl"] = sysl;
                            if (Convert.ToDecimal(row["ypsl"]) > 0)
                            {
                                DataRow row_zs = tb_temp.NewRow();
                                row_zs = row;
                                tbpcmx_zs_wfp.ImportRow(row);
                            }
                        }
                        #endregion
                    }

                    //第二步,处理出库数量小于零的药品(先去已经分配批号的正数匹配，匹配不到发第一个批次)
                    rows_mx = tb_temp.Select("选择=true and ypsl<=0", "ypsl desc");
                    for (int i = 0; i < rows_mx.Length; i++)
                    {
                        DataRow row = rows_mx[i];
                        int dwbl_mx = Convert.ToInt32(row["dwbl"]);
                        bool bFind = false;//是否找到正的已分配的

                        #region 批次分解
                        decimal ypsl = Convert.ToDecimal(row["ypsl"]);
                        string kcid = Convertor.IsNull(row["kcid"], new Guid().ToString());
                        string cz_id = Convertor.IsNull(row["cz_id"], new Guid().ToString());
                        DataRow[] rows_kcph = new DataRow[] { };

                        //在分解了的批次中找原记录
                        DataRow[] rows_yjl = tbpcmx.Select("zy_id='" + cz_id + "'", "");
                        if (rows_yjl.Length > 0)
                        {
                            //rows_kcph = tbkcph.Select("kcid='" + row["KCID2"].ToString() + "'", "");
                            rows_kcph = rows_yjl;//2015-05-07 ncq //补充说明 By Tany 2015-05-07 这里用原记录是有道理的，但是下面的变量要跟着改
                            bFind = true;
                        }
                        #region 找不到，退到有库存的记录上，如果整个没有库存，就找一个最近的记录
                        if (rows_kcph.Length == 0)
                        {
                            if (pcglfs == "0")
                                rows_kcph = tbkcph.Select("cjid=" + row["cjid"].ToString() + "", "djsj asc");
                            else
                                rows_kcph = tbkcph.Select("cjid=" + row["cjid"].ToString() + "", "ypxq asc");
                            if (rows_kcph.Length == 0)
                            {
                                if (pcglfs == "0")
                                {
                                    rows_kcph = InstanceForm.BDatabase.GetDataTable(@"select top 1 ID kcid, yppch,
                                            CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row["cjid"].ToString() + " order by djsj desc,yppch desc ").Select();
                                }
                                else
                                {
                                    rows_kcph = InstanceForm.BDatabase.GetDataTable(@"select top 1 ID kcid, yppch,
                                            CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row["cjid"].ToString() + " order by ypxq desc ").Select();
                                }
                            }
                        }
                        #endregion
                        if (rows_kcph.Length <= 0)
                        {
                            throw new Exception("找不到库存记录！");
                        }
                        if (bFind)
                        {
                            //能找到已分配正数记录
                            DataRow row1 = rows_kcph[0];
                            DataRow newrow = tb_temp.NewRow();
                            newrow = row;
                            int dwbl_zs = Convert.ToInt32(row1["dwbl"]);
                            if (dwbl_zs != dwbl_mx)
                            {
                                throw new Exception("单位比例发生错误！请刷新数据后重试");
                            }
                            #region
                            //newrow["yppch2"] = row1["yppch2"];
                            //newrow["ypph2"] = row1["ypph2"];
                            //newrow["ypxq2"] = row1["ypxq2"];
                            //newrow["kcid2"] = row1["kcid2"];
                            //decimal jhj = Convert.ToDecimal(Convert.ToDecimal(row1["jhj2"]) * dwbl_zs / dwbl_mx);
                            //newrow["jhj2"] = jhj;
                            //newrow["jhje2"] = Math.Round(jhj * ypsl, 3);
                            //newrow["ypsl"] = ypsl;
                            //decimal pfj = Convert.ToDecimal(row["批发价"]);
                            //newrow["批发价"] = pfj;
                            //newrow["批发金额"] = Math.Round(pfj * ypsl, 2);
                            //newrow["KDSL"] = ypsl * (-1);//可抵数量
                            //newrow["bdelete2"] = row1["bdelete2"];//禁用标志
                            #endregion
                            /*
                             * 2014-12-11 更新代码
                             */
                            newrow["yppch2"] = row1["yppch2"]; //Modify By Tany 2015-05-07 因为数据源变成原记录，所以这里要用2字尾的
                            newrow["ypph2"] = row1["ypph2"];//Modify By Tany 2015-05-07 因为数据源变成原记录，所以这里要用2字尾的
                            newrow["ypxq2"] = row1["ypxq2"];//Modify By Tany 2015-05-07 因为数据源变成原记录，所以这里要用2字尾的
                            newrow["kcid2"] = row1["kcid2"];//Modify By Tany 2015-05-07 因为数据源变成原记录，所以这里要用2字尾的
                            //decimal jhj = Convert.ToDecimal(Convert.ToDecimal(row1["jhj"]) * dwbl_zs / dwbl_mx);
                            decimal jhj = Convert.ToDecimal(Convert.ToDecimal(row1["jhj2"]) * dwbl_zs / dwbl_mx);//2015-05-07 ncq
                            newrow["jhj2"] = jhj;
                            newrow["jhje2"] = Math.Round(jhj * ypsl, 3);
                            newrow["ypsl"] = ypsl;
                            decimal pfj = Convert.ToDecimal(row["批发价"]);
                            newrow["批发价"] = pfj;
                            newrow["批发金额"] = Math.Round(pfj * ypsl, 2);
                            newrow["KDSL"] = ypsl * (-1);//可抵数量
                            newrow["bdelete2"] = row1["bdelete2"];//禁用标志 //Modify By Tany 2015-05-07 因为数据源变成原记录，所以这里要用2字尾的
                            tbpcmx_fs.ImportRow(newrow);
                        }
                        else
                        {
                            //未找到已分配正数记录
                            int dwbl_kc = Convert.ToInt32(rows_kcph[0]["dwbl"]);
                            if (dwbl_mx != dwbl_kc)
                            {
                                throw new Exception("单位比例发生变化！请刷新数据后重试");
                            }
                            DataRow row1 = rows_kcph[0];
                            DataRow newrow = tb_temp.NewRow();
                            newrow = row;
                            newrow["yppch2"] = row1["yppch"];
                            newrow["ypph2"] = row1["ypph"];
                            newrow["ypxq2"] = row1["ypxq"];
                            newrow["kcid2"] = row1["kcid"];
                            //库存批号表中存的是未拆零的进价
                            decimal jhj = Convert.ToDecimal(Convert.ToDecimal(row1["jhj"]) / dwbl_mx);
                            newrow["jhj2"] = jhj;
                            newrow["jhje2"] = Math.Round(jhj * ypsl, 3);
                            newrow["ypsl"] = ypsl;
                            decimal pfj = Convert.ToDecimal(row["批发价"]);
                            newrow["批发价"] = pfj;
                            newrow["批发金额"] = Math.Round(pfj * ypsl, 2);
                            newrow["KDSL"] = ypsl * (-1);//可抵数量
                            newrow["bdelete2"] = row1["bdelete"];//禁用标志
                            tbpcmx_fs.ImportRow(newrow);
                            //将批次库存减掉
                            row1["kcl"] = Convert.ToDecimal(row1["kcl"]) - ypsl;
                        }

                        #endregion
                    }

                    //第三部,处理未分配的大于零的药品(去已分配的负数进行抵销)
                    foreach (DataRow row_zs in tbpcmx_zs_wfp.Rows)
                    {
                        #region 批次分解
                        decimal sysl = Convert.ToDecimal(row_zs["ypsl"]);
                        DataRow[] rows_fs = tbpcmx_fs.Select(" kdsl>0 and cjid=" + row_zs["cjid"].ToString());
                        int dwbl_zs = Convert.ToInt32(row_zs["dwbl"]); //正数dwbl
                        for (int i = 0; i < rows_fs.Length; i++)
                        {
                            int dwbl_fs = Convert.ToInt32(rows_fs[i]["dwbl"]);
                            if (dwbl_zs != dwbl_fs)
                            {
                                throw new Exception("单位比例发生变化！请刷新数据后重试");
                            }
                            decimal cks = 0;
                            DataRow row_fs = rows_fs[i];
                            decimal kdsl = Convert.ToDecimal(row_fs["kdsl"]);
                            if (kdsl == 0)
                                continue;

                            if (kdsl >= sysl)
                            {
                                kdsl = kdsl - sysl;
                                cks = sysl;
                                sysl = 0;
                            }
                            else
                            {
                                cks = kdsl;
                                kdsl = 0;
                                sysl -= cks;
                            }
                            row_fs["kdsl"] = kdsl;

                            DataRow newrow = tb_temp.NewRow();
                            newrow = row_zs;
                            newrow["yppch2"] = row_fs["yppch2"];//批次号
                            newrow["ypph2"] = row_fs["ypph2"];//批号
                            newrow["ypxq2"] = row_fs["ypxq2"];//效期
                            newrow["kcid2"] = row_fs["kcid2"];//kcid
                            newrow["jhj2"] = row_fs["jhj2"];
                            newrow["jhje2"] = Convert.ToDecimal(Convert.ToDecimal(row_fs["jhj2"]) * cks);
                            newrow["ypsl"] = cks;

                            newrow["bdelete2"] = row_fs["bdelete2"];//禁用标志

                            tbpcmx.ImportRow(newrow);
                            row_zs["ypsl"] = sysl;

                            if (sysl == 0)
                            {
                                break;
                            }
                            if (kdsl == 0)
                            {
                                continue;
                            }
                        }
                        #endregion
                    }
                    foreach (DataRow row in tbpcmx_fs.Rows)
                    {
                        tbpcmx.ImportRow(row);
                    }


                    //第四部，处理第三部未能抵消的大于0的药品
                    DataRow[] rows_zs_wfp = tbpcmx_zs_wfp.Select("ypsl>0");
                    if (rows_zs_wfp.Length > 0)
                    {
                        throw new Exception(string.Format("{0} {1} 可用库存量不足！", rows_zs_wfp[0]["品名"], rows_zs_wfp[0]["规格"]));
                    }

                    #region 不用代码
                    //for (int i = 0; i < rows_zs_wfp.Length; i++)
                    //{
                    //    DataRow newrow = tb_temp.NewRow();
                    //    newrow = rows_zs_wfp[i];

                    //    DataRow[] rows_kcph = new DataRow[] { };

                    //    //先分配原有库存的记录上，如果整个没有库存，就找一个最近的记录
                    //    if (rows_kcph.Length == 0)
                    //    {
                    //        if (pcglfs == "1")
                    //            rows_kcph = tbkcph.Select("cjid=" + newrow["cjid"].ToString() + "", "djsj asc");
                    //        else
                    //            rows_kcph = tbkcph.Select("cjid=" + newrow["cjid"].ToString() + "", "ypxq asc");
                    //        if (rows_kcph.Length == 0)
                    //            rows_kcph = InstanceForm.BDatabase.GetDataTable("select top 1 ID kcid, yppch, CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + newrow["cjid"].ToString() + " order by djsj desc ").Select();
                    //    }

                    //    //回填批次信息
                    //    DataRow row1 = rows_kcph[0];
                    //    newrow["yppch2"] = row1["yppch"];
                    //    newrow["ypph2"] = row1["ypph"];
                    //    newrow["ypxq2"] = row1["ypxq"];
                    //    newrow["kcid2"] = row1["kcid"];
                    //    decimal jhj = Convert.ToDecimal(row1["jhj"]);
                    //    decimal ypsl = Convert.ToDecimal(newrow["ypsl"]);
                    //    decimal pfj = Convert.ToDecimal(newrow["批发价"]);
                    //    newrow["批发金额"] = Convert.ToDecimal(pfj*ypsl);
                    //    newrow["KDSL"] = 0;
                    //    tbpcmx.ImportRow(newrow);
                    //}
                    #endregion

                    #endregion
                }
                catch (Exception eeee)
                {
                    MessageBox.Show(eeee.ToString());
                    this.Cursor = Cursors.Arrow;
                    return;
                }


                string str = "";
                //foreach (DataRow rowtest in tbpcmx.Rows)
                //{
                //    str += rowtest["品名"].ToString() + " " + rowtest["yppch2"].ToString() + " " + rowtest["ypsl"].ToString() + rowtest["jhj2"].ToString() + "\n";
                //}

                //MessageBox.Show(str);
                //return;
                #region 赋值冲减数
                foreach (DataRow row in tbpcmx.Rows)
                {
                    if (Convert.ToDecimal(row["ypsl"]) < 0)
                    {
                        row["ypcjs"] = row["ypsl"];
                    }
                    else
                    {
                        row["ypcjs"] = 0;
                    }
                }
                #endregion

                #region 重新计算统领单 汇总分配批次的明细
                //重新计算统领单 
                string[] GroupbyField3 ={ "类型", "货号", "品名", "商品名", "规格", 
                                    "厂家", "库存数", "cjid", "批发价", "lsj", 
                                "dwbl", "zxdw", "货位号",
                                "kcid2","jhj2","yppch2","ypph2","ypxq2","ypdw","bdelete2" }; //加了kcid2 jhj2  yppch2 ypph2 ypxq2 ypdw
                string[] ComputeField3 ={ "ypsl", "金额", "批发金额", "jhje2", "ypcjs" };
                string[] CField3 ={ "sum", "sum", "sum", "sum", "sum" };
                TrasenFrame.Classes.TsSet xcset4 = new TrasenFrame.Classes.TsSet();
                xcset4.TsDataTable = tbpcmx.Copy();
                DataTable tbhz;
                try
                {
                    DataRow[] selrow = tbpcmx.Select();
                    DataTable tbsel1 = tb.Clone();
                    for (int i = 0; i <= selrow.Length - 1; i++)
                        tbsel1.ImportRow(selrow[i]);
                    tbhz = FunBase.GroupbyDataTable(tbsel1, GroupbyField3, ComputeField3, CField3, null);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message);
                    return;
                }
                if (tbhz.Rows.Count == 0)
                {
                    MessageBox.Show("没有要发药的药品记录");
                    this.Cursor = Cursors.Arrow;
                    return;
                }
                //string strHz = "批次汇总:\n";
                //foreach (DataRow row_hz in tbhz.Rows)
                //{
                //    strHz += (row_hz["品名"].ToString() + " " + row_hz["yppch2"].ToString() + " " + row_hz["ypsl"].ToString()+" "+ row_hz["jhj2"].ToString() + "\n");
                //}
                //str += strHz;
                //MessageBox.Show(str);
                //return;
                #endregion

                #region 处理库存禁用
                DataRow[] rows_jy = tbhz.Select(" bdelete2 = '1' and ypsl> 0 ");
                if (rows_jy.Length > 0)
                {
                    DataRow row_jy = rows_jy[0];
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show(row_jy["品名"].ToString() + " " + row_jy["规格"].ToString() + " 可用库存量不够！");
                    return;
                }
                #endregion

                //计算进货金额
                string[] GroupbyField_jhje ={ };
                string[] ComputeField_jhje ={ "jhje2" };
                string[] CField_jhje ={ "sum" };
                TrasenFrame.Classes.TsSet xcset_jhje = new TrasenFrame.Classes.TsSet();
                xcset_jhje.TsDataTable = tbpcmx.Copy();
                DataTable tbjhje = xcset_jhje.GroupTable(GroupbyField_jhje, ComputeField_jhje, CField_jhje, "");
                decimal _sumjhje = 0;
                if (tbjhje.Rows.Count <= 0)
                {
                    MessageBox.Show("分配批次库存失败");
                    this.Cursor = Cursors.Arrow;
                    return;
                }
                _sumjhje = Convert.ToDecimal(Convertor.IsNull(tbjhje.Rows[0]["jhje2"], "0"));

                int _err_code = -1; //返回变量
                string _err_text = "";
                string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(); //时间
                string _dept_ly = tb_msg.Rows[0]["dept_ly"].ToString().Trim(); //领药科室
                int _py_user = Convert.ToInt32(cmbpyr.SelectedValue); //配药人
                string _bz = this.txtbz.Text.Trim();//备注
                decimal _sumpfje = Convert.ToDecimal(tbje.Rows[0]["批发金额"]); //批发金额
                decimal _sumlsje = Convert.ToDecimal(tbje.Rows[0]["金额"]);     //零售金额
                string _stype = this.tabControl1.SelectedTab == this.tabPage1 ? "统领" : "退药";//统领分类
                int _msg_type = this.tabControl1.SelectedTab == this.tabPage1 ? 0 : 1; //消息类型
                int lylx = 0; //领药方式
                if (_menuTag.Function_Name == "Fun_ts_yf_zyfy_tld_by"
                    || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                    lylx = 1;
                decimal _zje = 0; //总金额。。用于和上面计算的_sumlsje比较。。以防计算不正确

                #region 回填住院费用表kcid 考虑放到事务外
                int err_code_tt = 0;
                string err_text_tt = "更新费用表批次信息失败！";
                foreach (DataRow row_pcmx in tbpcmx.Rows)
                {
                    ZY_FY.UpdateFeeKcid(new Guid(row_pcmx["zy_id"].ToString()),
                                        new Guid(row_pcmx["kcid2"].ToString()),
                                        out err_code_tt,
                                        out err_text_tt,
                                        InstanceForm.BDatabase);
                    if (err_code_tt != 0)
                    {
                        throw new Exception(err_text_tt);
                    }
                }

                #endregion
                long djh = Yp.SeekNewDjh(_menuTag.FunctionTag.Trim(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
                InstanceForm.BDatabase.BeginTransaction();
                try
                {


                    #region 添加统领单头表
                    _err_text = "添加统领单头表";
                    Guid _groupid = Guid.Empty;


                    //需要加上进货金额ncq 
                    ZY_FY.SaveTld(djh, InstanceForm.BCurrentDept.DeptId, _sDate, InstanceForm.BCurrentUser.EmployeeId, Convert.ToInt32(_dept_ly), 0, _py_user, _bz, _sumpfje, _sumlsje, _stype, _menuTag.FunctionTag, out _groupid, out _err_code, out _err_text, InstanceForm._menuTag.Jgbm, lylx, InstanceForm.BDatabase, _sumjhje);
                    if (_groupid == Guid.Empty || _err_code != 0)
                        throw new Exception(_err_text);
                    #endregion

                    this.myDataGridMx.Tag = _groupid.ToString();
                    this.butfy.Tag = _sDate.Trim();

                    #region 添加统领单明细表
                    _err_text = "添加统领单明细表";
                    InstanceForm.DebugView(tbhz);

                    for (int i = 0; i <= tbhz.Rows.Count - 1; i++)
                    {
                        Guid _fyid = Guid.Empty;
                        decimal _qysl = Convert.ToDecimal(tbhz.Rows[i]["库存数"]) - Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) < 0 ? Convert.ToDecimal(tbhz.Rows[i]["库存数"]) - Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) : 0;
                        decimal _ypcjs = Convert.ToDecimal(tbhz.Rows[i]["ypcjs"]);
                        decimal lsje = Convert.ToDecimal(Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) * Convert.ToDecimal(tbhz.Rows[i]["lsj"]));
                        decimal pfje = Convert.ToDecimal(Convert.ToDecimal(tbhz.Rows[i]["ypsl"]) * Convert.ToDecimal(tbhz.Rows[i]["批发价"]));
                        _zje = _zje + lsje;
                        //string ssss = tbhz.Rows[i]["kcid2"].ToString();
                        #region 插入统领单明细
                        ZY_FY.SaveTldMx(_groupid,
                                        Convert.ToInt32(tbhz.Rows[i]["cjid"]),
                                        tbhz.Rows[i]["货号"].ToString(),
                                        tbhz.Rows[i]["品名"].ToString(),
                                        tbhz.Rows[i]["商品名"].ToString(),
                                        tbhz.Rows[i]["规格"].ToString(),
                                        Yp.SeekYpdw(Convert.ToInt32(tbhz.Rows[i]["zxdw"]), InstanceForm.BDatabase),
                                        tbhz.Rows[i]["厂家"].ToString(),
                                        Convert.ToDecimal(tbhz.Rows[i]["库存数"]),
                                        Convert.ToDecimal(tbhz.Rows[i]["ypsl"]),
                                        _qysl,
                                        Convert.ToDecimal(tbhz.Rows[i]["批发价"]),
                                        Convert.ToDecimal(tbhz.Rows[i]["lsj"]),
                                        pfje,
                                        lsje,
                                        Convert.ToString(tbhz.Rows[i]["类型"]),
                                        Convert.ToInt32(tbhz.Rows[i]["dwbl"]),
                                        true,
                                        InstanceForm.BCurrentDept.DeptId,
                                        tbhz.Rows[i]["ypph2"].ToString(),//批号
                                        tbhz.Rows[i]["货位号"].ToString(),
                                        out _fyid,
                                        out _err_code,
                                        out _err_text, InstanceForm.BDatabase,
                                        Convert.ToDecimal(Convertor.IsNull(tbhz.Rows[i]["jhj2"], "0")),//进货价
                                        Convert.ToDecimal(tbhz.Rows[i]["jhje2"]),//进货金额
                                        tbhz.Rows[i]["ypxq2"].ToString(),
                                        Convertor.IsNull(tbhz.Rows[i]["yppch2"].ToString(), ""),
                                        new Guid(tbhz.Rows[i]["kcid2"].ToString()),
                                        true, _ypcjs);
                        if (_fyid == Guid.Empty || _err_code != 0)
                            throw new Exception(_err_text);
                        #endregion
                    }

                    #endregion

                    DateTime tnow = Convert.ToDateTime(InstanceForm.BDatabase.GetDataResult(InstanceForm.BDatabase.GetServerTimeString()).ToString());
                    string err_text_t = "";
                    int err_code_t = -1;
                    InstanceForm.DebugView(tbpcmx);
                    #region 添加统领单明细批号表yf_tldmx_fee 剂量跟剂量单位问题
                    int pxxh_fee = 0;
                    foreach (DataRow row_fee in tbpcmx.Rows)
                    {
                        if (Convert.ToDecimal(row_fee["ypsl"]) == 0)
                            throw new Exception(string.Format("{0}药品发药数量为0,操作已终止,请联系管理员!", row_fee["品名"].ToString()));
                        pxxh_fee += 1;
                        ZY_FY.SaveTldMxFee(Guid.Empty, _groupid,
                            Convert.ToInt32(row_fee["cjid"]),
                            row_fee["货号"].ToString(),
                            row_fee["品名"].ToString(),
                            row_fee["英文名"].ToString(),
                            row_fee["商品名"].ToString(),
                            row_fee["规格"].ToString(),
                            row_fee["厂家"].ToString(),
                            row_fee["ypdw"].ToString(),
                            Convert.ToInt32(row_fee["dwbl"]),
                            Convert.ToDecimal(row_fee["ypsl"]),
                            Convert.ToInt32(row_fee["剂数"]),
                            new Guid(row_fee["kcid2"].ToString()),
                            Convertor.IsNull(row_fee["yppch2"], ""),
                            Convertor.IsNull(row_fee["ypph2"], ""),
                            row_fee["ypxq2"].ToString(),
                            Convert.ToDecimal(row_fee["jhj2"]),
                            Convert.ToDecimal(row_fee["批发价"]),
                            Convert.ToDecimal(row_fee["lsj"]),
                            Convert.ToDecimal(row_fee["jhje2"]),
                            Convert.ToDecimal(row_fee["批发金额"]),
                            Convert.ToDecimal(row_fee["金额"]),
                            new Guid(row_fee["zy_id"].ToString()),
                            new Guid(Convertor.IsNull(row_fee["cz_id"], Guid.Empty.ToString())),
                            new Guid(row_fee["住院id"].ToString()),
                            row_fee["姓名"].ToString(), row_fee["住院号"].ToString(), Convert.ToInt32(row_fee["婴儿id"]),
                            Convertor.IsNull(row_fee["医嘱内容"], ""),
                            Convert.ToDateTime(row_fee["处方日期"].ToString()),
                            Convert.ToInt32(Convertor.IsNull(row_fee["病人科室id"], "0")),
                            Convert.ToInt32(Convertor.IsNull(row_fee["开单科室id"], "0")),
                            Convert.ToInt32(Convertor.IsNull(row_fee["开单医生id"], "0")),
                            Convert.ToInt32(Convertor.IsNull(row_fee["管床医生id"], "0")),
                            Convert.ToInt32(Convertor.IsNull(row_fee["执行科室id"], "0")),
                            Convert.ToDateTime(row_fee["收费日期"] == DBNull.Value ? DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss") : row_fee["收费日期"].ToString()),
                            Convert.ToInt32(Convertor.IsNull(row_fee["收费员id"], "0")),
                            Convertor.IsNull(row_fee["用法"].ToString(), ""),
                            Convertor.IsNull(row_fee["嘱托"].ToString(), ""),
                            Convertor.IsNull(row_fee["频次"].ToString(), ""),
                            Convertor.IsNull(row_fee["剂量"].ToString(), "0"),
                            row_fee["剂量单位"].ToString(),
                            0, pxxh_fee, InstanceForm.BCurrentUser.EmployeeId, tnow, InstanceForm.BCurrentUser.EmployeeId, tnow, InstanceForm._menuTag.Jgbm,
                            out err_code_t, out err_text_t, InstanceForm.BDatabase);
                        if (err_code_t != 0)
                        {
                            throw new Exception(err_text_t);
                        }


                    }
                    #endregion

                    #region 验证金额
                    _err_text = "计算金额";
                    _zje = Math.Round(_zje, 0);
                    _sumlsje = Math.Round(_sumlsje, 0);
                    if (Math.Abs(_zje - (_sumlsje)) > 1)
                    {
                        //MessageBox.Show("计算出的总金额" + _zje.ToString() + " 不等于明细总金额" + _sumlsje.ToString() + " ，请和管理员联系");
                    }
                    #endregion

                    //没有记费的记录
                    DataRow[] rows = tb.Select("选择=true and charge_bit='0'");
                    //已记费的记录
                    DataRow[] rows2 = tb.Select("选择=true  and charge_bit='1'");

                    string ssql = "";
                    decimal _execId = 0;

                    #region 更新没有记费的记录
                    _err_text = "更新没有记费的记录";
                    //更新没有记费的记录 //时间撮
                    ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                    _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));

                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ", '" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'" + _groupid + "',1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }
                    if (rows.Length > 0)
                    {
                        int iii = ZY_FY.UpdateFeeChargeFy(false, _groupid, _sDate, InstanceForm.BCurrentUser.EmployeeId, _py_user, 0, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                        if (rows.Length != iii)
                        {
                            if (isPivasYF)
                            {
                                butref1_Click(null, null);
                                throw new System.Exception("错误，在做费用更新时，所更新的记录数与发药记录数不相符,操作回滚!\r\r  可能病区进行了转打包操作！  \r\r　您可以刷新数据后重试!");
                            }
                            else
                            {
                                throw new System.Exception("错误，在做费用更新时，所更新的记录数与发药记录数不相符,操作回滚!　您可以刷新数据后重试!");
                            }
                        }
                    }
                    #endregion

                    #region 更新已记费的记录
                    _err_text = "更新已记费的记录";
                    //更新已记费的记录 //时间撮
                    ssql = "select  convert(decimal(21,6),convert(varchar,getdate(),112)+convert(varchar,datepart(hh,getdate()))+convert(varchar,datepart(mi,getdate()))+convert(varchar,datepart(ss,getdate()))+'.'+convert(varchar,datepart(ms,getdate()))) ";
                    _execId = Convert.ToDecimal(InstanceForm.BDatabase.GetDataResult(ssql));

                    for (int i = 0; i <= rows2.Length - 1; i++)
                    {
                        ssql = "insert into yf_zyfymx(zy_id,jgbm,fyrq,fyr,groupid,charge_bit,charge_date,charge_user,execid,deptid)values('" + new Guid(rows2[i]["zy_id"].ToString()) + "'," + InstanceForm._menuTag.Jgbm + ",'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ",'" + _groupid + "',1,'" + _sDate.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + _execId + "," + InstanceForm.BCurrentDept.DeptId + ")";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }

                    if (rows2.Length > 0)
                    {
                        int iii = ZY_FY.UpdateFeeChargeFy(false, _groupid, _sDate, InstanceForm.BCurrentUser.EmployeeId, _py_user, 1, _sDate, InstanceForm.BCurrentUser.EmployeeId, _execId, InstanceForm.BDatabase);
                        if (rows2.Length != iii)
                        {
                            if (isPivasYF)
                            {
                                butref1_Click(null, null);
                                throw new System.Exception("错误，在做费用更新时，所更新的记录数与发药记录数不相符,操作回滚!\r\r  可能病区进行了转打包操作！  \r\r　您可以刷新数据后重试!");
                            }
                            else
                            {
                                throw new System.Exception("错误，在做费用更新时，所更新的记录数与发药记录数不相符,操作回滚!　您可以刷新数据后重试!");
                            }
                        }
                    }
                    #endregion

                    #region 嫁接不更新发药消息
                    _err_text = "嫁接不更新发药消息";
                    if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_ly")
                    {
                        _err_text = "更新zy_apply_drug";
                        //更新zy_apply_drug
                        for (int i = 0; i <= tb_msg.Rows.Count - 1; i++)
                            ZY_FY.UpdateMsg(new Guid(tb_msg.Rows[i]["apply_id"].ToString()), _groupid, InstanceForm.BDatabase);

                        _err_text = "将没有发药的生成新的消息";
                        //将没有发药的生成新的消息
                        for (int i = 0; i <= tb_Umsg.Rows.Count - 1; i++)
                        {
                            //判断是否部分发药
                            bool byes = false;
                            for (int j = 0; j <= tb_msg.Rows.Count - 1; j++)
                            {
                                if (new Guid(tb_Umsg.Rows[i]["apply_id"].ToString().Trim()) == new Guid(tb_msg.Rows[j]["apply_id"].ToString().Trim()))
                                    byes = true;
                            }

                            Guid _apply_id = Guid.Empty;
                            if (byes == true)
                            {
                                //产生消息表
                                ZY_FY.SaveApplyDrug(tb_Umsg.Rows[i]["apply_date"].ToString().Trim(), InstanceForm.BCurrentUser.EmployeeId, Convert.ToInt32(_dept_ly), InstanceForm.BCurrentDept.DeptId, _msg_type, tb_Umsg.Rows[i]["lyflcode"].ToString().Trim(), out _apply_id, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                                if (_apply_id == Guid.Empty)
                                    throw new Exception("错误,生成消息时,消息ID为零");
                                DataRow[] RowUmsg = tb.Select("选择=false and apply_id='" + tb_Umsg.Rows[i]["apply_id"].ToString().Trim() + "'");

                                //更新此消息的明细
                                for (int x = 0; x <= RowUmsg.Length - 1; x++)
                                    ZY_FY.UpdateFeeChargeApplyID(_apply_id, new Guid(RowUmsg[x]["zy_id"].ToString()), InstanceForm.BDatabase);
                            }
                        }
                    }
                    #endregion

                    #region  使用分包机 ---摆药 LQQ 2013-4-27
                    if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by"
                        || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                    {
                        DataTable dt_byjCS = InstanceForm.BDatabase.GetDataTable("select ZT from yk_config where BH=153 and deptid='" + InstanceForm.BCurrentDept.DeptId + "'");
                        if (dt_byjCS != null)
                        {
                            if (dt_byjCS.Rows.Count > 0)
                            {
                                if (Convert.ToString(dt_byjCS.Rows[0][0]) == "1")
                                {
                                    ParameterEx[] parameters = new ParameterEx[2];
                                    parameters[0].Value = "00000000-0000-0000-0000-000000000000";
                                    parameters[1].Value = _groupid;

                                    string gid = _groupid.ToString();

                                    parameters[0].Text = "@fyid";
                                    parameters[1].Text = "@V_groupid";

                                    DataSet dset = new DataSet();
                                    InstanceForm.BDatabase.AdapterFillDataSet("sp_yf_zyfy_byj", parameters, dset, "kss", 240);
                                }
                            }
                        }
                    }

                    #endregion
                    InstanceForm.BDatabase.CommitTransaction();

                    //Modify by jchl 2015-06-27 提交事务后,不能在抛出异常进入回滚代码
                    try
                    {
                        #region 选择包药方式
                        int execResult = 0;
                        DialogResult retDialog = DialogResult.None;
                        string[] retInfo = null;
                        bool isDisPlay = false;
                        string exceptionInfo = string.Empty;
                        if (_chineseName.Contains("口服摆药单") && InstanceForm.BCurrentDept.DeptId == 359)
                        {
                            FrmSeleByType bylxFrm = null;
                            try
                            {
                                isDisPlay = true;
                                bylxFrm = new FrmSeleByType(_groupid.ToString());
                                bylxFrm.UpdateFylx += new FrmSeleByType.SelectBylx(bylxFrm_UpdateFylx);
                                bylxFrm.StartPosition = FormStartPosition.CenterScreen;
                                bylxFrm.Activate();
                                retDialog = bylxFrm.ShowDialog();
                                retInfo = bylxFrm.ExecResultInfo;
                            }
                            catch (Exception err)
                            {
                                exceptionInfo = err.Message;
                                isDisPlay = false;
                            }
                        }

                        if (InstanceForm.BCurrentDept.DeptId == 359)
                        {
                            object[] param = new object[] 
                        {         
                            InstanceForm.BCurrentDept.DeptId,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            _chineseName, 
                            retInfo !=null && retInfo.Length >1 ? retInfo[0]:"" , 
                            retInfo !=null && retInfo.Length >1 ? retInfo[1]:"",
                            retDialog.ToString(),
                            string.IsNullOrEmpty( exceptionInfo)? "空": exceptionInfo,
                            _dept_ly
                        };
                            //{住院药房} {18：00} 在{口服摆药单}选择包药方式,执行{sql}返回影响行数{1},选择窗口返回类型{}
                            string logInfo = string.Format("{0}药房在{1}时{2}选择包药方式,为{7}科室发药,执行{3}返回影响行数{4},选择窗口返回类型{5},异常信息为{6}", param);
                            ThrowTechError(logInfo);
                        }
                        #endregion

                        #region 提交事务并打印
                        if (_menuTag.Function_Name != "Fun_ts_yf_zyfy_tld_by"
                            || _menuTag.Function_Name.Trim() == "Fun_ts_yf_zyfy_tld_by_jz") //Modofy By Tany 2015-05-05
                        {
                            if (MessageBox.Show("发药成功,您要打印吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                this.butprint_Click(sender, e);

                                #region Modify by dyw 2014/6/30屏蔽
                                //if (_menuTag.Function_Name != "Fun_ts_yf_zyfy_tld_by")
                                //    this.butprint_Click(sender, e);
                                //else
                                //    this.butprintmx_Click(sender, e);
                                #endregion
                            }
                        }
                        MessageBox.Show("发药成功", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #endregion

                        #region 嫁接不更移除发药消息
                        if (_menuTag.Function_Name.Trim() != "Fun_ts_yf_zyfy_ly")
                        {
                            //移除消息
                            System.Windows.Forms.TreeListView TreeListView;
                            if (this.tabControl1.SelectedTab == this.tabPage1)
                                TreeListView = this.treeListView1;
                            else
                                TreeListView = this.treeListView2;

                            for (int i = 0; i <= tb_msg.Rows.Count - 1; i++)
                                RemoveItem(TreeListView, _dept_ly, tb_msg.Rows[i]);
                            for (int i = 0; i <= tb_Umsg.Rows.Count - 1; i++)
                                RemoveItem(TreeListView, _dept_ly, tb_Umsg.Rows[i]);
                            tb.Rows.Clear();
                        }
                        else
                        {
                            tb = (DataTable)this.myDataGridMx.DataSource;
                            tb.Rows.Clear();
                        }
                        #endregion
                    }
                    catch { }
                }
                catch (System.Exception err)
                {
                    this.myDataGridMx.Tag = null;
                    this.butfy.Tag = "";
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message + "\t" + err.StackTrace + "\t" + err.Source);
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
                #endregion
            }
        }

        /// <summary>
        /// 检查PIVAS的审核状态
        /// </summary>
        /// <param name="tb"></param>
        private void CheckPvsSH(DataTable tb)
        {
            string sql = "";
            string msg = "";
            if (isPivasYF && tb != null && tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(tb.Rows[i]["选择"]))
                    {
                        //如果费用的科室在pivas对应关系表里面，才验证 Modify By Tany 2015-04-21
                        if (PivasDept.Select("dept_id=" + tb.Rows[i]["病人科室id"].ToString()).Length > 0)
                        {
                            sql = "select is_pvschk from zy_orderrecord a inner join zy_fee_speci b on a.order_id=b.order_id where b.id='" + tb.Rows[i]["zy_id"].ToString() + "'";
                            int isPvschk = Convert.ToInt16(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sql), "0"));
                            if (isPvschk != 1)
                            {
                                tb.Rows[i]["选择"] = false;
                                msg += "第【" + tb.Rows[i]["序号"].ToString().Trim() + "】行，" + tb.Rows[i]["品名"].ToString().Trim() + " " + tb.Rows[i]["规格"].ToString().Trim() + "\r\n";
                            }
                        }
                    }
                }
            }
            if (msg != "")
            {
                MessageBox.Show("以下药品未经过PIVAS审核或审核未通过，暂时不能发药，已经取消对其勾选！\r\n\r\n" + msg);
            }
        }

        private string[] bylxFrm_UpdateFylx(object[] sender)
        {
            if (sender == null || sender.Length == 0)
                return null;

            int bylx = Convert.ToInt32(sender[0]);
            string tldid = sender[1].ToString();
            string outXml = string.Empty;
            if (bylx == 1)
            {
                string postString = string.Empty;
                ParameterEx[] parameters_tsbyj = new ParameterEx[1];
                parameters_tsbyj[0].Value = tldid;
                parameters_tsbyj[0].Text = "@group_id";
                DataTable tbbyjmx = InstanceForm.BDatabase.GetDataTable("SP_WHZXYY_BYJ_TS", parameters_tsbyj, 60);
                tbbyjmx.TableName = "root";
                if (tbbyjmx != null && tbbyjmx.Rows.Count > 0)
                {
                    DateTime currTime = DateTime.Now;
                    Dictionary<string, DateTime> dict = new Dictionary<string, DateTime>();
                    int i = 0;
                    foreach (DataRow tmpRow in tbbyjmx.Rows)
                    {
                        if (!dict.ContainsKey(tmpRow["wardCd"].ToString().Trim()))
                        {
                            if (i > 0)
                            {
                                currTime = currTime.AddSeconds(1);
                            }
                            dict.Add(tmpRow["wardCd"].ToString().Trim(), currTime);
                            i++;
                        }
                    }
                    for (int x = 0; x < tbbyjmx.Rows.Count; x++)
                    {
                        tbbyjmx.Rows[x].BeginEdit();
                        tbbyjmx.Rows[x]["makerecTime"] = dict[tbbyjmx.Rows[x]["wardCd"].ToString().Trim()];
                        tbbyjmx.Rows[x].EndEdit();
                    }
                    postString = DataTableToXmlEx(tbbyjmx, "tsDoctorAdvice");
                }
                else
                {
                    //MessageBox.Show("未查询到包药数据!");
                    return null;
                }
                postString = "<" + tbbyjmx.TableName + ">" + postString + "</" + tbbyjmx.TableName + ">";
                TsByj.getTsDoctorAdvice ts = new TsByj.getTsDoctorAdvice();
                outXml = ts.CallgetTsDoctorAdvice(postString);
            }
            if (outXml == "1" || bylx == 2) //如果发送包药数据成功 或手工包药方式  记录本次操作
            {
                if (bylx > 0 && !string.IsNullOrEmpty(tldid))
                {
                    string sql = string.Format("update yf_tld set bylx = {0} where groupid = '{1}'", bylx, tldid);
                    int execResult = InstanceForm.BDatabase.DoCommand(sql);
                    return new string[] { sql, execResult.ToString() };
                }
            }
            return null;
        }

        private static string DataTableToXmlEx(DataTable dt, string rowname)
        {
            if (dt != null)
            {
                if (rowname == "")
                {
                    rowname = "ROW";
                }
                string returnValue = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    returnValue += "<" + rowname + ">";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string colName = dt.Columns[j].ColumnName.ToString().Trim();
                        returnValue += "<" + colName + ">" + Convertor.IsNull(dt.Rows[i][j], "") + "</" + colName + ">";
                    }
                    returnValue += "</" + rowname + ">";
                }

                return returnValue;
            }
            else
            {
                return "";
            }
        }

        private void ThrowTechError(string logInfo)
        {
            try
            {
                string ErrPath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, "包药机日志");
                if (!Directory.Exists(ErrPath))
                {
                    Directory.CreateDirectory(ErrPath);
                }
                StreamWriter txtWriter = new StreamWriter(string.Format(@"{0}\{1}-ByjLog.txt", ErrPath, DateTime.Now.ToString("yyyy-MM-dd")), true);
                txtWriter.WriteLine("---------------------------------------------------------");
                txtWriter.WriteLine(logInfo);
                txtWriter.WriteLine("---------------------------------------------------------");
                txtWriter.WriteLine();
                txtWriter.Close();
            }
            catch
            {
                MessageBox.Show("本地日志记录失败!", "提示");
            }
        }

        //移除消息
        private void RemoveItem(System.Windows.Forms.TreeListView TreeListView, string dept_ly, DataRow row)
        {
            for (int i = 0; i <= TreeListView.Items.Count - 1; i++)
            {
                if (TreeListView.Items[i].Tag.ToString().Trim() == dept_ly.Trim())
                {
                    for (int j = 0; j <= TreeListView.Items[i].Items.Count - 1; j++)
                    {
                        if (row["apply_id"].ToString().Trim() == TreeListView.Items[i].Items[j].Tag.ToString().Trim())
                        {
                            TreeListView.Items[i].Items[j].Remove();
                        }
                    }
                }
            }

            for (int i = 0; i <= TreeListView.Items.Count - 1; i++)
            {
                if (TreeListView.Items[i].Items.Count == 0)
                    TreeListView.Items[i].BackColor = Color.White;
                TreeListView.Items[i].SubItems[0].BackColor = Color.White;
                TreeListView.Items[i].SubItems[1].BackColor = Color.White;
                TreeListView.Items[i].SubItems[2].BackColor = Color.White;
                TreeListView.Items[i].SubItems[3].BackColor = Color.White;
            }
        }

        #region 不般控制
        //清除页面
        private void ClearData()
        {

            DataTable tbmx = (DataTable)this.myDataGridMx.DataSource;
            tbmx.Rows.Clear();

            for (int i = 1; i <= this.tabControl2.TabPages.Count - 1; i++)
            {
                for (int j = 0; j <= this.tabControl2.TabPages[i].Controls.Count - 1; j++)
                {
                    //如果是网格
                    if (this.tabControl2.TabPages[i].Controls[j].GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEx")
                    {
                        TrasenClasses.GeneralControls.DataGridEx mydatagrid = (TrasenClasses.GeneralControls.DataGridEx)this.tabControl2.TabPages[i].Controls[j];
                        DataTable mytb = (DataTable)mydatagrid.DataSource;
                        mytb.Rows.Clear();
                    }
                }
            }
        }

        //输入项目
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 8 || nkey == 32 || nkey == 46 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
            {
            }
            else
            {
                return;
            }

            try
            {
                string[] GrdMappingName;
                int[] GrdWidth;
                string[] sfield;
                string ssql = "";
                DataRow row;

                Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
                switch (control.TabIndex)
                {
                    case 0:
                        if (control.Text.Trim() == "")
                            return;
                        GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "库存量", "单位", "禁用", "DWBL", "批发价", "零售价", "货号", "拼音码", "五笔码" };
                        GrdWidth = new int[] { 0, 0, 50, 200, 100, 100, 65, 40, 40, 0, 60, 60, 70, 60, 60 };
                        sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                        ssql = "select distinct a.ggid,cjid,0  rowno,yppm,ypgg,s_sccj sccj,cast(kcl as float) kcl,dbo.fun_yp_ypdw(ypdw) ypdw,(case when bdelete_kc=1 then '√' else '' end) jy,1 dwbl,pfj,lsj,shh,pym,wbm from vi_yf_kcmx a,yp_ypbm b " +
                                "where a.ggid=b.ggid and deptid=" + InstanceForm.BCurrentDept.DeptId + "  and a.ypzlx in(select ypzlx from yp_gllx where deptid=" + InstanceForm.BCurrentDept.DeptId + ")  ";

                        TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                        f2.Location = point;
                        f2.Width = 700;
                        f2.Height = 300;
                        f2.ShowDialog(this);
                        row = f2.dataRow;
                        if (row != null)
                        {
                            control.Text = row["yppm"].ToString();
                            control.Tag = row["cjid"].ToString();
                            this.SelectNextControl((Control)sender, true, false, true, true);

                            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                            DataRow[] rowX = tb.Select("cjid=" + row["cjid"].ToString() + "");
                            if (rowX.Length > 0)
                            {
                                int nrow = Convert.ToInt32(rowX[0]["序号"]);
                                this.myDataGridMx.CurrentCell = new DataGridCell(nrow - 1, 1);

                            }
                        }
                        break;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message);
            }
        }

        //刷新消息
        private void butref1_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                if (this.tabControl1.SelectedTab == this.tabPage1)
                    AddMssageTree(Convert.ToInt32(Convertor.IsNull(cmbbs1.SelectedValue, "0")), this.treeListView1, this.tabPage1);
                if (this.tabControl1.SelectedTab == this.tabPage2)
                    AddMssageTree(Convert.ToInt32(Convertor.IsNull(cmbbs2.SelectedValue, "0")), this.treeListView2, this.tabPage2);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        //刷新统领消息
        private void butref_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                AddTldTree(Convert.ToInt32(Convertor.IsNull(cmbbs3.SelectedValue, "0")), this.treeListView3, this.tabPage3, this.cmbtype.Text.Trim());
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        //选择是是统领？退药？统领单?
        private void tabControl1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.tabControl1.SelectedTab == this.tabPage1)
                {
                    //CshMxGrid(this.myDataGridMx);
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[1].Width = 35;
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[2].Width = 30;
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[3].Width = 55;//0
                    DataTable tbb = (DataTable)this.myDataGridMx.DataSource;
                    tbb.Rows.Clear();
                    for (int i = 0; i <= this.treeListView1.Items.Count - 1; i++)
                        this.ChangeTreeItemColorToWhite(treeListView1.Items[i]);
                    //重新统计汇总单
                    computeTld();
                    butfy.Enabled = true;
                    btCharge.Enabled = true;//Modify By Tany 2015-03-17
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    chkAllFee.Visible = true;//Modify By Tany 2015-03-17
                    chkUncharge.Visible = true;//Modify By Tany 2015-03-17
                    chkCharged.Visible = true;//Modify By Tany 2015-03-17
                    btncb.Enabled = false;

                    //checkBox4.Location = checkBox3.Location;
                    //dateTimePicker1.Location = checkBox1.Location;

                    checkBox4.Location = cbxfirstPoint;
                    dateTimePicker1.Location = dtpfirstPoint;
                }

                if (this.tabControl1.SelectedTab == this.tabPage2)
                {
                    //CshMxGrid(this.myDataGridMx);
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[1].Width = 35;
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[2].Width = 35;//0
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[3].Width = 55;//0
                    DataTable tbb = (DataTable)this.myDataGridMx.DataSource;
                    tbb.Rows.Clear();
                    for (int i = 0; i <= this.treeListView2.Items.Count - 1; i++)
                        this.ChangeTreeItemColorToWhite(treeListView2.Items[i]);
                    //重新统计汇总单
                    computeTld();
                    butfy.Enabled = true;
                    btCharge.Enabled = true;//Modify By Tany 2015-03-17
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    chkAllFee.Visible = true;//Modify By Tany 2015-03-17
                    chkUncharge.Visible = true;//Modify By Tany 2015-03-17
                    chkCharged.Visible = true;//Modify By Tany 2015-03-17
                    btncb.Enabled = false;

                    //checkBox4.Location = checkBox3.Location;
                    //dateTimePicker1.Location = checkBox1.Location;

                    checkBox4.Location = cbxfirstPoint;
                    dateTimePicker1.Location = dtpfirstPoint;
                }

                if (this.tabControl1.SelectedTab == this.tabPage3)
                {
                    //CshMxGrid(this.myDataGridMx);
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[1].Width = 0;
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[2].Width = 35;//0
                    this.myDataGridMx.TableStyles[0].GridColumnStyles[3].Width = 55;//0
                    DataTable tbb = (DataTable)this.myDataGridMx.DataSource;
                    tbb.Rows.Clear();

                    //Modify by dyw 2014/6/29
                    chkmx.Checked = true;
                    butref_Click(butref, new EventArgs());

                    //重新统计汇总单
                    computeTld();

                    butfy.Enabled = false;
                    btCharge.Enabled = false;//Modify By Tany 2015-03-17
                    checkBox1.Visible = false;
                    checkBox2.Visible = false;
                    checkBox3.Visible = false;
                    chkAllFee.Visible = false;//Modify By Tany 2015-03-17
                    chkUncharge.Visible = false;//Modify By Tany 2015-03-17
                    chkCharged.Visible = false;//Modify By Tany 2015-03-17
                    if (InstanceForm.BCurrentDept.DeptId == 359)
                        btncb.Enabled = true;

                    checkBox4.Location = checkBox3.Location;
                    dateTimePicker1.Location = new Point(checkBox1.Location.X + 20, checkBox1.Location.Y);
                }
                panel_top.Refresh();
                dateTimePicker1.Refresh();
                this.statusBar1.Panels[0].Text = "";
                this.statusBar1.Panels[1].Text = "";
                this.statusBar1.Panels[2].Text = "";
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        //清除
        private void butqc_Click(object sender, System.EventArgs e)
        {
            this.txtypmc.Text = "";
            this.txtxm.Text = "";
            this.txtzyh.Text = "";
            this.txtcw.Text = "";
        }


        //选择统领病室
        private void cmbbs1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            AddMssageTree(Convert.ToInt32(Convertor.IsNull(this.cmbbs1.SelectedValue, "0")), this.treeListView1, this.tabPage1);
        }

        //选择退药病室
        private void cmbbs2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            AddMssageTree(Convert.ToInt32(Convertor.IsNull(this.cmbbs2.SelectedValue, "0")), this.treeListView2, this.tabPage2);
        }


        private void cmbbs3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            AddTldTree(Convert.ToInt32(Convertor.IsNull(this.cmbbs3.SelectedValue, "0")), this.treeListView3, this.tabPage3, this.cmbtype.Text.Trim());
        }

        //将消息的变景变成白色
        private void ChangeTreeItemColorToWhite(System.Windows.Forms.TreeListViewItem item)
        {
            item.BackColor = Color.White;
            item.SubItems[0].BackColor = Color.White;
            item.SubItems[1].BackColor = Color.White;
            item.SubItems[2].BackColor = Color.White;
            item.SubItems[3].BackColor = Color.White;
            item.Selected = false;

            for (int i = 0; i <= item.Items.Count - 1; i++)
            {
                item.Items[i].BackColor = Color.White;
                item.Items[i].SubItems[0].BackColor = Color.White;
                item.Items[i].SubItems[1].BackColor = Color.White;
                item.Items[i].SubItems[2].BackColor = Color.White;
                item.Items[i].SubItems[3].BackColor = Color.White;
                item.Items[i].Selected = false;
                ChangeTreeItemColorToWhite(item.Items[i]);
            }
        }

        //列颜色改变事件
        private void colText_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;
            DataGridEnableTextBoxColumn column = (DataGridEnableTextBoxColumn)sender;
            DataTable tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
            if (e.Row > tb.Rows.Count - 1)
                return;
            if (Convert.ToDecimal(Convertor.IsNull(tb.Rows[e.Row]["领药数"], "0")) > Convert.ToDecimal(Convertor.IsNull(tb.Rows[e.Row]["库存数"], "0")))
                e.ForeColor = Color.Red;
            else
                e.ForeColor = Color.Black;


        }

        //列颜色改变事件
        private void myDataGridMx_colText_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            try
            {
                e.BackColor = Color.White;
                DataTable tb;
                if (sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn")
                {
                    DataGridEnableBoolColumn column = (DataGridEnableBoolColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                else
                {
                    DataGridEnableTextBoxColumn column = (DataGridEnableTextBoxColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }



                if (e.Row > tb.Rows.Count - 1)
                    return;
                if (Convert.ToBoolean(tb.Rows[e.Row]["选择"]) == false)
                    e.ForeColor = Color.Gray;
                else
                {
                    decimal sl_kc = 0;
                    if (Convert.ToString(tb.Rows[e.Row]["库存数"]) != "")
                        sl_kc = Convert.ToDecimal(tb.Rows[e.Row]["库存数"]);
                    if (Convert.ToDecimal(tb.Rows[e.Row]["数量"]) > sl_kc)
                        e.ForeColor = Color.Red;
                    else
                        e.ForeColor = Color.Blue;
                }

                if (e.Row == this.myDataGridMx.CurrentCell.RowNumber)
                    e.BackColor = Color.Yellow;
                else
                {
                    e.BackColor = Color.White;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            //			
        }



        #endregion

        #region 打印按钮
        private void butprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                Guid _groupid = new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString()));
                //_groupid = new Guid(Convertor.IsNull("691aa94e-90ff-403a-aaa4-a0d60006ebc0", Guid.Empty.ToString()));
                if (_groupid == Guid.Empty)
                {
                    MessageBox.Show("必须发药后才能打印单据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //更新打印次数
                //string ssql = "update yf_tld set hzdycs=hzdycs+1 where groupid='" + _groupid + "'";
                //int n = InstanceForm.BDatabase.DoCommand(ssql);
                //if (n == 0)
                //{

                //    ssql = "update yf_tld_h set hzdycs=hzdycs+1 where groupid='" + _groupid + "'";
                //    n = InstanceForm.BDatabase.DoCommand(ssql);
                //}


                DataTable tb = ZY_FY.SelectTldHz(_groupid.ToString(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

                #region Modify by dyw 2014/7/1启用批次后合并批次打印
                bpcgl = Yp.BPcgl(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);//进行批次管理
                if (bpcgl)
                {

                    string[] GroupbyField3 ={ "cjid", "ypgg", "ypdw", "dept_ly", "fyr", 
                        "pyr", "bprint", "fyrq", "类型", "djh","ypspm","sccj","lsj","shh",
                        "hwh","ypjx" ,"stype","hzdycs","ypzddw","DWBL","yppm"}; //加了kcid2 jhj2  yppch2 ypph2 ypxq2 ypdw
                    string[] ComputeField3 ={ "ypsl", "lsje", "ypcjs" };
                    string[] CField3 ={ "sum", "sum", "sum" };

                    //Modify by jchl
                    //TrasenFrame.Classes.TsSet xcset1 = new TrasenFrame.Classes.TsSet();
                    //xcset1.TsDataTable = tb.Copy();
                    //DataTable tbTemp = xcset1.GroupTable(GroupbyField3, ComputeField3, CField3, "");

                    DataTable tbTemp = GroupByDataTable(tb, GroupbyField3, ComputeField3, CField3);
                    tb.Clear();
                    tb = tbTemp.Copy();

                }
                #endregion

                // InstanceForm.BDatabase.GetDataTable(@" select ypjx,a.groupid,djh,deptid,fyrq,fyr,dept_ly,nurseid,pyr,bz,sumpfje,sumlsje,
                //yppm ,ypspm ,ypgg ,sccj ,lsj ,kcl ,ypsl ,qysl ,ypdw ,lsje ,shh ,cjid,ydwbl,tlfl 类型,
                //stype,b.id,isnull(bprint,1) bprint,hwh,hzdycs  from yf_tld_h a inner join yf_tldmx_h b 
                //on a.groupid=b.groupid left join yp_tlfl c on b.tlfl=c.name where  
                //a.groupid='" + _groupid + "' order by hwh,yppm");//ZY_FY.SelectTldHz(_groupid.ToString(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);// new DataTable();

                if (this.tabControl1.SelectedTab == this.tabPage3 || tb.Rows.Count == 0)
                {
                    #region 权限确认
                    try
                    {
                        if ((new SystemCfg(8008)).Config == "1")
                        {
                            string dlgvalue = DlgPW.Show();
                            string pwStr = dlgvalue; //YS.Password;
                            bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                            if (!bOk)
                            {
                                FrmMessageBox.Show("你没有通过权限确认，不能发药！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Cursor = Cursors.Default;
                                return;
                            }
                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion
                }
                this.Cursor = PubStaticFun.WaitCursor();

                PrintInfo(tb, _groupid);


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion

        #region 打印方法
        private void PrintInfo(DataTable tb, Guid _groupid)
        {
            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();

            if (tb.Rows.Count == 0)
                return;
            string lydw = Yp.SeekDeptName(Convert.ToInt32(tb.Rows[0]["dept_ly"]), InstanceForm.BDatabase);
            string fyr = Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["fyr"]), InstanceForm.BDatabase);
            string pyr = Yp.SeekEmpName(Convert.ToInt32(tb.Rows[0]["pyr"]), InstanceForm.BDatabase);
            DataRow myrow;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (Convertor.IsNull(tb.Rows[i]["bprint"], "0") == "1")
                {
                    myrow = Dset.发药明细单.NewRow();
                    myrow["yppm"] = Convert.ToString(tb.Rows[i]["yppm"]);
                    myrow["ypspm"] = Convert.ToString(tb.Rows[i]["ypspm"]);
                    myrow["ypgg"] = Convert.ToString(tb.Rows[i]["ypgg"]);
                    myrow["sccj"] = Convert.ToString(tb.Rows[i]["sccj"]);
                    myrow["lsj"] = Convert.ToDecimal(tb.Rows[i]["lsj"]);
                    myrow["ypsl"] = Convert.ToDecimal(tb.Rows[i]["ypsl"]);
                    myrow["ypdw"] = Convert.ToString(tb.Rows[i]["ypdw"]);
                    myrow["lsje"] = Convert.ToDecimal(tb.Rows[i]["lsje"]);
                    myrow["shh"] = Convert.ToString(tb.Rows[i]["shh"]);
                    myrow["hwh"] = Convert.ToString(tb.Rows[i]["hwh"]);
                    myrow["tlfl"] = Convert.ToString(tb.Rows[i]["类型"]) + " ( No." + tb.Rows[0]["djh"].ToString() + " )";
                    myrow["fyrq"] = Convert.ToString(tb.Rows[i]["fyrq"]);
                    myrow["fyr"] = fyr;
                    myrow["pyr"] = pyr;
                    myrow["lydw"] = lydw;
                    myrow["bz"] = Convert.ToDecimal(tb.Rows[i]["ypsl"]) >= 0 ? "" : "退药";
                    myrow["groupid"] = "( No." + tb.Rows[0]["djh"].ToString() + " )";
                    myrow["ypjx"] = Convert.ToString(tb.Rows[i]["ypjx"]);
                    myrow["bz1"] = Convert.ToDecimal(tb.Rows[i]["ypcjs"]);
                    myrow["bz2"] = Convertor.IsNull(tb.Rows[i]["ypzddw"], "");
                    myrow["bz3"] = tb.Rows[i]["DWBL"];
                    Dset.发药明细单.Rows.Add(myrow);
                }

            }


            ParameterEx[] parameters = new ParameterEx[3];
            parameters[0].Text = "title";
            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "" + InstanceForm.BCurrentDept.DeptName + tb.Rows[0]["stype"].ToString().Trim() + "" + "单";
            parameters[1].Text = "lydwHeadText";
            parameters[1].Value = tb.Rows[0]["stype"].ToString().Trim() == "统领" ? "领药病室:" : "退药病室:";
            parameters[2].Text = "dycs";
            int dycs = 0;
            if (tb.Rows[0]["hzdycs"].ToString() == "0")
                dycs = 1;
            else
                dycs = Convert.ToInt32(tb.Rows[0]["hzdycs"].ToString()) + 1;

            parameters[2].Value = dycs.ToString();

            string[] str ={ "" };
            str[0] = "update yf_tld set hzdycs=hzdycs+1 where groupid='" + _groupid + "'";
            bool bview = this.chkprintview.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.发药明细单, Constant.ApplicationDirectory + "\\Report\\YF_药品统领单.rpt", parameters, bview, str);
            f._sqlStr = str;
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();
        }
        #endregion

        private void butselect_Click(object sender, System.EventArgs e)
        {

            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
                tb.Rows[i]["选择"] = (short)1;
            this.computeTld();
        }

        private void butunselect_Click(object sender, System.EventArgs e)
        {

            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                int selected = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["选择"], "0"));
                tb.Rows[i]["选择"] = selected == 1 ? (short)0 : (short)1;
            }
            this.computeTld();
        }

        private void myDataGridMx_DoubleClick_1(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab == this.tabPage3)
                return;

            if ((new SystemCfg(8012)).Config != "1")
                return;

            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
            if (tb.Rows.Count == 0)
                return;
            int nrow = this.myDataGridMx.CurrentCell.RowNumber;
            int cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);
            Ypcj cj = new Ypcj(cjid, InstanceForm.BDatabase);

            DataTable tab = tb.Clone();
            DataRow[] rows;
            string swhere = " cjid=" + cjid + " and 数量>0 ";
            rows = tb.Select(swhere);
            for (int i = 0; i <= rows.Length - 1; i++)
                tab.ImportRow(rows[i]);

            TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            System.Windows.Forms.DataGridTableStyle dataGridTableStyle1 = new DataGridTableStyle();
            myDataGrid1.TableStyles.Add(dataGridTableStyle1);
            myDataGrid1.CaptionVisible = false;
            myDataGrid1.ReadOnly = true;
            myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            myDataGrid1.SelectionBackColor = System.Drawing.Color.White;
            myDataGrid1.Click += new EventHandler(myDataGridMx_DoubleClick);
            myDataGrid1.Name = "myhy";
            //初始化网格
            CshMxGrid(myDataGrid1);

            //显示查询结果
            myDataGrid1.DataSource = tab;

            Frmhy f = new Frmhy(cj.GGID, cj.CJID, InstanceForm.BCurrentDept.DeptId);
            f.panel2.Controls.Add(myDataGrid1);
            myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);
            myDataGrid1.TableStyles[0].GridColumnStyles["缺药"].Width = 0;
            myDataGrid1.TableStyles[0].GridColumnStyles["厂家"].Width = 80;
            myDataGrid1.TableStyles[0].GridColumnStyles["货号"].Width = 80;

            decimal zsl = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(ypsl)", "选择=true and cjid=" + cj.CJID + " and 数量>0 "), "0"));
            f.statusStrip1.Items[0].Text = "药品总用量:" + zsl.ToString() + Yp.SeekYpdw(Convert.ToInt32(tb.Rows[0]["zxdw"]), InstanceForm.BDatabase);

            f.ShowDialog();

            if (f.Bok == false)
                return;

            DataTable tbmx = (DataTable)this.myDataGridMx.DataSource;
            DataTable tbcj = (DataTable)f.dataGridView1.DataSource;
            if (tbcj.Rows.Count == 0)
            {
                MessageBox.Show("没有可供选择的厂家", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Ypcj newcj = new Ypcj(Convert.ToInt32(tbcj.Rows[f.dataGridView1.CurrentCell.RowIndex]["cjid"]), InstanceForm.BDatabase);
            decimal kcl = Convert.ToDecimal(tbcj.Rows[f.dataGridView1.CurrentCell.RowIndex]["库存量"]);

            try
            {

                //修改后台的数据
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(tab.Rows[i]["选择"]) == true)
                    {
                        DataRow[] rows1 = tbmx.Select("zy_id='" + tab.Rows[i]["zy_id"] + "'");
                        DataRow row = rows1[0];

                        decimal dj = Math.Round(newcj.LSJ / Convert.ToInt32(row["unitrate"]), 4);
                        decimal sl = Convert.ToDecimal(row["数量"]);
                        decimal je = Math.Round(dj * sl, 2);
                        Guid zy_id = new Guid(row["zy_id"].ToString());

                        try
                        {
                            InstanceForm.BDatabase.BeginTransaction();

                            string kcl_y = tab.Rows[i]["库存数"].ToString();
                            string kcdw = tab.Rows[i]["单位"].ToString();

                            ParameterEx[] parameters = new ParameterEx[9];
                            parameters[0].Text = "@zy_id";
                            parameters[0].Value = zy_id;
                            parameters[1].Text = "@new_cjid";
                            parameters[1].Value = newcj.CJID;
                            parameters[2].Text = "@new_price";
                            parameters[2].Value = dj;
                            parameters[3].Text = "@new_je";
                            parameters[3].Value = je;
                            parameters[4].Text = "@err_code";
                            parameters[4].ParaDirection = ParameterDirection.Output;
                            parameters[4].DataType = System.Data.DbType.Int32;
                            parameters[4].ParaSize = 100;
                            parameters[5].Text = "@err_text";
                            parameters[5].ParaDirection = ParameterDirection.Output;
                            parameters[5].ParaSize = 100;
                            parameters[6].Text = "@sccj";
                            parameters[6].Value = newcj.S_SCCJ;
                            parameters[7].Text = "@djy";
                            parameters[7].Value = InstanceForm.BCurrentUser.Name;
                            parameters[8].Text = "@kcl";
                            parameters[8].Value = kcl_y + kcdw + " 新药库存:" + kcl.ToString("0.0") + kcdw;
                            InstanceForm.BDatabase.DoCommand("sp_yf_hy", parameters, 120);
                            int err_code = Convert.ToInt32(parameters[4].Value);
                            string err_text = Convert.ToString(parameters[5].Value);
                            if (err_code != 0)
                                throw new Exception(@err_text);
                            InstanceForm.BDatabase.CommitTransaction();
                            //修改网格中的数据显示
                            row["cjid"] = newcj.CJID;
                            row["单价"] = dj.ToString();
                            row["金额"] = je.ToString();
                            row["库存数"] = kcl.ToString();
                            row["货号"] = newcj.SHH;
                            row["厂家"] = newcj.S_SCCJ;
                        }
                        catch (System.Exception err)
                        {
                            InstanceForm.BDatabase.RollbackTransaction();
                            MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }


                //重新计算
                computeTld();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataTable tbb = (DataTable)myDataGridMx.DataSource;
                tb.Rows.Clear();
            }

        }

        #region 打印明细按钮
        private void butprintmx_Click(object sender, EventArgs e)
        {
            try
            {
                Guid _groupid = new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString()));
                //_groupid = new Guid(Convertor.IsNull("47BD001F-AB4A-4AB5-AF27-A0D700D59CE7", Guid.Empty.ToString()));
                if (_groupid == Guid.Empty)
                {
                    MessageBox.Show("必须发药后才能打印单据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                //打印次数
                //string  ssql = "update yf_tld set mxdycs=mxdycs+1 where groupid='" + _groupid + "'";
                //int n = InstanceForm.BDatabase.DoCommand(ssql);
                //if (n == 0)
                //{

                //    ssql = "update yf_tld_h set mxdycs=mxdycs+1 where groupid='" + _groupid + "'";
                //    n = InstanceForm.BDatabase.DoCommand(ssql);
                //}

                string ssql = "select * from vi_yf_tld where groupid='" + _groupid.ToString() + "'";
                DataTable tbtld = InstanceForm.BDatabase.GetDataTable(ssql);


                DataTable tb = ZY_FY.SelectTldMx(_groupid.ToString(), InstanceForm.BDatabase);

                DataView dv = tb.DefaultView;
                dv.RowFilter = "数量>0";
                tb = dv.ToTable();

                this.Cursor = PubStaticFun.WaitCursor();

                if (this.tabControl1.SelectedTab == this.tabPage3 || tb.Rows.Count == 0)
                {
                    #region 权限确认
                    try
                    {
                        if ((new SystemCfg(8008)).Config == "1")
                        {
                            string dlgvalue = DlgPW.Show();
                            string pwStr = dlgvalue; //YS.Password;
                            bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                            if (!bOk)
                            {
                                FrmMessageBox.Show("你没有通过权限确认，不能发药！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Cursor = Cursors.Default;
                                return;
                            }
                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion
                }
                Print_FYMXInfo(tb, _groupid, tbtld);

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion

        #region 打印明细方法
        private void Print_FYMXInfo(DataTable tb, Guid _groupid, DataTable tbtld)
        {
            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();

            if (tb.Rows.Count == 0)
                return;
            string lydw = Yp.SeekDeptName(Convert.ToInt32(tbtld.Rows[0]["dept_ly"]), InstanceForm.BDatabase);
            string fyr = Yp.SeekEmpName(Convert.ToInt32(tbtld.Rows[0]["fyr"]), InstanceForm.BDatabase);
            string pyr = Yp.SeekEmpName(Convert.ToInt32(tbtld.Rows[0]["pyr"]), InstanceForm.BDatabase);
            string fyrq = tbtld.Rows[0]["fyrq"].ToString();
            string djh = Convertor.IsNull(tbtld.Rows[0]["djh"], "");
            DataRow myrow;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                myrow = Dset.住院药品摆药明细.NewRow();
                myrow["yppm"] = Convert.ToString(tb.Rows[i]["品名"]);
                myrow["ypspm"] = Convert.ToString(tb.Rows[i]["商品名"]);
                myrow["ypgg"] = Convert.ToString(tb.Rows[i]["规格"]);
                myrow["sccj"] = Convert.ToString(tb.Rows[i]["厂家"]);
                myrow["lsj"] = Convert.ToDecimal(tb.Rows[i]["单价"]);////////////////lsj 单价
                myrow["ypsl"] = Convert.ToDecimal(tb.Rows[i]["数量"]);
                myrow["ypdw"] = Convert.ToString(tb.Rows[i]["单位"]);
                myrow["lsje"] = Convert.ToDecimal(tb.Rows[i]["金额"]);
                myrow["shh"] = Convert.ToString(tb.Rows[i]["货号"]);
                //myrow["tlfl"] = Convert.ToString(tb.Rows[i]["类型"]) + " ( No." + tb.Rows[0]["djh"].ToString() + " )";
                myrow["fyrq"] = fyrq;
                myrow["fyr"] = fyr;
                myrow["pyr"] = pyr;
                myrow["lydw"] = lydw;
                myrow["mcyl"] = Convert.ToString(tb.Rows[i]["mcyl"]);
                myrow["mcdw"] = Convert.ToString(tb.Rows[i]["mcdw"]);
                myrow["yf"] = Convert.ToString(tb.Rows[i]["用法"]);
                myrow["pc"] = Convert.ToString(tb.Rows[i]["频次"]);
                //myrow["ryrq"] = Convert.ToString(tb.Rows[i]["ryrq"]);
                myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["dept_id"], "0")), InstanceForm.BDatabase);
                myrow["rowno"] = i;
                myrow["lydw"] = lydw;
                myrow["bed_no"] = Convert.ToString(tb.Rows[i]["床号"]);
                myrow["inpatient_no"] = Convert.ToString(tb.Rows[i]["住院号"]);
                myrow["name"] = Convert.ToString(tb.Rows[i]["姓名"]);
                myrow["cfrq"] = Convert.ToString(tb.Rows[i]["presc_date"]);
                myrow["MNGTYPE"] = Convert.ToString(tb.Rows[i]["MNGTYPE"]);////////////改printBZ
                myrow["gysj"] = Convert.ToString(tb.Rows[i]["gysj"]);
                myrow["ypjx"] = Convert.ToString(tb.Rows[i]["剂型"]);
                Dset.住院药品摆药明细.Rows.Add(myrow);


            }



            ParameterEx[] parameters = new ParameterEx[4];
            parameters[0].Text = "titletext";
            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "" + InstanceForm.BCurrentDept.DeptName + "摆药单";
            parameters[1].Text = "yfmc";
            parameters[1].Value = InstanceForm.BCurrentDept.DeptName;
            parameters[2].Text = "djh";
            parameters[2].Value = djh;
            parameters[3].Text = "dycs";

            int dycs = 0;
            if (tbtld.Rows[0]["mxdycs"].ToString() == "0")
                dycs = 1;
            else
                dycs = Convert.ToInt32(tbtld.Rows[0]["mxdycs"].ToString()) + 1;

            parameters[3].Value = dycs.ToString();

            string[] str ={ "" };
            str[0] = "update yf_tld set mxdycs=mxdycs+1 where groupid='" + _groupid + "'";
            bool bview = this.chkprintview.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.住院药品摆药明细, Constant.ApplicationDirectory + "\\Report\\YF_住院摆药单.rpt", parameters, bview, str);
            f._sqlStr = str;
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();
        }

        #endregion

        private void chkkccc_CheckedChanged(object sender, EventArgs e)
        {
            #region Modify by dyw 2014/6/28 屏蔽写入INI
            //string dy = "否";
            //if ( chkkccc.Checked == true )
            //    dy = "是";
            //ApiFunction.WriteIniString( "住院统领发药统领选项" , "领药数大于库存数时超出部分的明细自动不选" , dy , Constant.ApplicationDirectory + "\\ClientWindow.ini" );
            #endregion

        }

        private void chkkcfs_CheckedChanged(object sender, EventArgs e)
        {
            #region Modify by dyw 2014/6/28 屏蔽写入INI
            //string dy = "否";
            //if ( chkkcfs.Checked == true )
            //    dy = "是";
            //ApiFunction.WriteIniString( "住院统领发药统领选项" , "退药抵扣不足时超出部分的明细自动不选" , dy , Constant.ApplicationDirectory + "\\ClientWindow.ini" );
            #endregion
        }

        private int uid_pyr = 0;
        private void cmbpyr_SelectedIndexChanged(object sender, EventArgs e)
        {
            int uid_sel = Convert.ToInt32(cmbpyr.SelectedValue);//选择用户
            int uid_cur = InstanceForm.BCurrentUser.EmployeeId;//当前用户
            SystemCfg cfg8059 = new SystemCfg(8059);
            if (cfg8059.Config == "1")
            {
                if (uid_sel != uid_cur && uid_pyr != 0)
                {
                    //身份的再次确认
                    string dlgvalue = Ts_zyys_public.DlgPW.Show();
                    string pwStr = dlgvalue; //YS.Password;

                    bool bOk = new User(uid_sel, InstanceForm.BDatabase).CheckPassword(pwStr);
                    if (!bOk)
                    {
                        TrasenFrame.Forms.FrmMessageBox.Show("你没有通过权限确认，不能进行此操作！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbpyr.SelectedValue = uid_pyr;
                        return;
                    }
                }

            }
            uid_pyr = Convert.ToInt32(cmbpyr.SelectedValue);
        }

        bool cqAllSelParam = true;
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource != null)
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in tb.Rows)
                    {
                        object objYzlx = tmpRow["医嘱类型"];
                        decimal objKcl = tmpRow["库存数"] == null || tmpRow["库存数"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(tmpRow["库存数"].ToString().Trim());
                        if (objYzlx != null && objYzlx.ToString().Trim() == "长期医嘱" && objKcl > 0)
                            tmpRow["选择"] = checkBox1.Checked;
                        else
                            tmpRow["选择"] = false;
                    }
                    cqAllSelParam = !cqAllSelParam;
                }

            }
            checkBox3.CheckedChanged -= checkBox3_CheckedChanged;
            checkBox2.CheckedChanged -= checkBox2_CheckedChanged;
            checkBox3.Checked = false;
            checkBox2.Checked = false;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
        }

        bool lsAllSelParam = true;
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource != null)
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in tb.Rows)
                    {
                        object objYzlx = tmpRow["医嘱类型"];
                        decimal objKcl = tmpRow["库存数"] == null || tmpRow["库存数"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(tmpRow["库存数"].ToString().Trim());
                        if (objYzlx != null && objYzlx.ToString().Trim() == "临时医嘱" && objKcl > 0)
                            tmpRow["选择"] = checkBox2.Checked; // lsAllSelParam;
                        else
                            tmpRow["选择"] = false;
                    }
                    lsAllSelParam = !lsAllSelParam;
                }

            }
            checkBox3.CheckedChanged -= checkBox3_CheckedChanged;
            checkBox1.CheckedChanged -= checkBox1_CheckedChanged_1;
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource != null)
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in tb.Rows)
                    {
                        //object objYzlx = tmpRow["医嘱类型"];
                        decimal objKcl = tmpRow["库存数"] == null || tmpRow["库存数"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(tmpRow["库存数"].ToString().Trim());
                        if (objKcl > 0)
                            tmpRow["选择"] = checkBox3.Checked;// lsAllSelParam;
                        else
                            tmpRow["选择"] = false;
                    }
                    lsAllSelParam = !lsAllSelParam;
                }
                if (checkBox3.Focused)
                {
                    //统领时,当有退药时如果没有正数抵消,则默认不选择
                    if (chkkcfs.Checked == true)
                        moveTyxx();
                    if (chkkccc.Checked == true)
                        moveKccc();
                    //Modify By Tany 2015-03-23 增加处方日期过滤
                    if (checkBox4.Checked)
                        moveCfrq();

                    //计算统领单
                    computeTld();
                }
            }
            checkBox2.CheckedChanged -= checkBox2_CheckedChanged;
            checkBox1.CheckedChanged -= checkBox1_CheckedChanged_1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
        }

        private void btncb_Click(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource is DataTable)
            {
                List<string> groupIdList = new List<string>();
                DataTable datalist = myDataGridMx.DataSource as DataTable;
                string groupRange = string.Empty;
                foreach (DataRow tmpRow in datalist.Rows)
                {
                    if (tmpRow["groupid"].ToString().Trim() != string.Empty && !groupIdList.Contains(tmpRow["groupid"].ToString()))
                    {
                        groupIdList.Add(tmpRow["groupid"].ToString());
                        groupRange += string.Format("'{0}',", tmpRow["groupid"].ToString());
                    }
                }
                Dictionary<string, string> dict = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(groupRange))
                {
                    groupRange = groupRange.Remove(groupRange.Length - 1, 1);
                    string sql = string.Format("select bylx,GROUPID from YF_TLD where GROUPID in ({0})", groupRange);
                    DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        bool isShowMsg = false;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string bylx = dt.Rows[i]["bylx"].ToString().Trim();
                            if (!string.IsNullOrEmpty(bylx))
                            {
                                if (!isShowMsg)
                                {
                                    isShowMsg = true;
                                    //不为空代表已经做过包药动作,则给出提示
                                    DialogResult dr = MessageBox.Show("已做过包药操作,请确认是否重新包药？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dr != DialogResult.Yes)
                                        return;
                                }
                            }
                            dict.Add(dt.Rows[i]["GROUPID"].ToString(), dt.Rows[i]["bylx"].ToString());
                        }

                    }
                }
                else
                    return;

                bool param = false;
                foreach (KeyValuePair<string, string> s in dict)
                {
                    string outXml = string.Empty;
                    if (s.Value == "2" || string.IsNullOrEmpty(s.Value))
                    {

                        string postString = string.Empty;
                        ParameterEx[] parameters_tsbyj = new ParameterEx[1];
                        parameters_tsbyj[0].Value = s.Key;
                        parameters_tsbyj[0].Text = "@group_id";
                        DataTable tbbyjmx = InstanceForm.BDatabase.GetDataTable("SP_WHZXYY_BYJ_TS", parameters_tsbyj, 60);
                        tbbyjmx.TableName = "root";
                        if (tbbyjmx != null && tbbyjmx.Rows.Count > 0)
                        {
                            DateTime currTime = DateTime.Now;
                            Dictionary<string, DateTime> dictInfo = new Dictionary<string, DateTime>();
                            int i = 0;
                            foreach (DataRow tmpRow in tbbyjmx.Rows)
                            {
                                if (!dictInfo.ContainsKey(tmpRow["wardCd"].ToString().Trim()))
                                {
                                    if (i > 0)
                                    {
                                        currTime = currTime.AddSeconds(1);
                                    }
                                    dictInfo.Add(tmpRow["wardCd"].ToString().Trim(), currTime);
                                    i++;
                                }
                            }
                            for (int x = 0; x < tbbyjmx.Rows.Count; x++)
                            {
                                tbbyjmx.Rows[x].BeginEdit();
                                tbbyjmx.Rows[x]["makerecTime"] = dictInfo[tbbyjmx.Rows[x]["wardCd"].ToString().Trim()];
                                tbbyjmx.Rows[x].EndEdit();
                            }
                            postString = DataTableToXmlEx(tbbyjmx, "tsDoctorAdvice");
                        }
                        else
                        {
                            //MessageBox.Show("未查询到包药数据!");
                            continue;
                        }
                        postString = "<" + tbbyjmx.TableName + ">" + postString + "</" + tbbyjmx.TableName + ">";

                        TsByj.getTsDoctorAdvice ts = new TsByj.getTsDoctorAdvice();
                        outXml = ts.CallgetTsDoctorAdvice(postString);
                        if (outXml == "1" || s.Value == "2") //如果发送包药数据成功 或手工包药方式  记录本次操作
                        {
                            if (!string.IsNullOrEmpty(s.Key))
                            {
                                string sql = string.Format("update yf_tld set bylx = {0} where groupid = '{1}'", string.IsNullOrEmpty(s.Value) ? "1" : s.Value, s.Key);
                                int execResult = InstanceForm.BDatabase.DoCommand(sql);
                                param = true;
                            }
                        }
                        else if (outXml == "0")
                        {
                            MessageBox.Show("调用包药机接口失败!");
                            return;
                        }
                    }
                }
                if (param)
                    MessageBox.Show("操作成功！");
            }
        }

        //Modify By Tany 2015-03-17 勾选记账未记账的费用
        /***********************Begin Modify By Tany****************************************************/
        private void chkUncharge_CheckedChanged(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource != null)
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in tb.Rows)
                    {
                        object objChargeBit = tmpRow["charge_bit"];
                        decimal objKcl = tmpRow["库存数"] == null || tmpRow["库存数"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(tmpRow["库存数"].ToString().Trim());
                        if (objChargeBit != null && objChargeBit.ToString().Trim() != "1" && objKcl > 0)
                            tmpRow["选择"] = chkUncharge.Checked;
                        else
                            tmpRow["选择"] = false;
                    }
                }

            }
            chkAllFee.CheckedChanged -= chkAllFee_CheckedChanged;
            chkCharged.CheckedChanged -= chkCharged_CheckedChanged;
            chkAllFee.Checked = false;
            chkCharged.Checked = false;
            chkAllFee.CheckedChanged += chkAllFee_CheckedChanged;
            chkCharged.CheckedChanged += chkCharged_CheckedChanged;
        }

        private void checkBox3_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void chkCharged_CheckedChanged(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource != null)
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in tb.Rows)
                    {
                        object objChargeBit = tmpRow["charge_bit"];
                        decimal objKcl = tmpRow["库存数"] == null || tmpRow["库存数"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(tmpRow["库存数"].ToString().Trim());
                        if (objChargeBit != null && objChargeBit.ToString().Trim() == "1" && objKcl > 0)
                            tmpRow["选择"] = chkCharged.Checked;
                        else
                            tmpRow["选择"] = false;
                    }
                }
            }
            chkAllFee.CheckedChanged -= chkAllFee_CheckedChanged;
            chkUncharge.CheckedChanged -= chkUncharge_CheckedChanged;
            chkUncharge.Checked = false;
            chkAllFee.Checked = false;
            chkAllFee.CheckedChanged += chkAllFee_CheckedChanged;
            chkUncharge.CheckedChanged += chkUncharge_CheckedChanged;
        }

        private void chkAllFee_CheckedChanged(object sender, EventArgs e)
        {
            if (myDataGridMx.DataSource != null)
            {
                DataTable tb = (DataTable)this.myDataGridMx.DataSource;
                if (tb != null && tb.Rows.Count > 0)
                {
                    foreach (DataRow tmpRow in tb.Rows)
                    {
                        decimal objKcl = tmpRow["库存数"] == null || tmpRow["库存数"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(tmpRow["库存数"].ToString().Trim());
                        if (objKcl > 0)
                            tmpRow["选择"] = chkAllFee.Checked;// lsAllSelParam;
                        else
                            tmpRow["选择"] = false;
                    }
                }
                if (chkAllFee.Focused)
                {
                    //统领时,当有退药时如果没有正数抵消,则默认不选择
                    if (chkkcfs.Checked == true)
                        moveTyxx();
                    if (chkkccc.Checked == true)
                        moveKccc();
                    //Modify By Tany 2015-03-23 增加处方日期过滤
                    if (checkBox4.Checked)
                        moveCfrq();

                    //计算统领单
                    computeTld();
                }
            }
            chkCharged.CheckedChanged -= chkCharged_CheckedChanged;
            chkUncharge.CheckedChanged -= chkUncharge_CheckedChanged;
            chkUncharge.Checked = false;
            chkCharged.Checked = false;
            chkCharged.CheckedChanged += chkCharged_CheckedChanged;
            chkUncharge.CheckedChanged += chkUncharge_CheckedChanged;
        }

        private void btCharge_Click(object sender, EventArgs e)
        {
            #region 权限确认
            try
            {
                if ((new SystemCfg(8008)).Config == "1")
                {
                    string dlgvalue = DlgPW.Show();
                    string pwStr = dlgvalue; //YS.Password;
                    bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                    if (!bOk)
                    {
                        FrmMessageBox.Show("你没有通过权限确认，不能发药！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                        return;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            this.Cursor = PubStaticFun.WaitCursor();

            DataTable tb = (DataTable)this.myDataGridMx.DataSource;
            DataTable tbsel = tb.Clone();
            try
            {
                DataRow[] selrow = tb.Select("选择=true");
                for (int i = 0; i <= selrow.Length - 1; i++)
                    tbsel.ImportRow(selrow[i]);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }

            if (tbsel.Rows.Count == 0)
            {
                MessageBox.Show("没有要记账的药品记录！");
                this.Cursor = Cursors.Arrow;
                return;
            }

            try
            {
                //没有记费的记录
                DataRow[] rows = tb.Select("选择=true and charge_bit='0'");
                if (rows.Length == 0)
                {
                    MessageBox.Show("没有要记账的药品记录！");
                    this.Cursor = Cursors.Arrow;
                    return;
                }

                string[] ssql = new string[rows.Length];

                #region 更新没有记费的记录
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    ssql[i] = "update zy_fee_speci set charge_bit=1,charge_date=getdate(),charge_user=" + InstanceForm.BCurrentUser.EmployeeId + " where id='" + new Guid(rows[i]["zy_id"].ToString()) + "' and charge_bit=0 and delete_bit=0";
                    //Modify By Tany 2015-04-20
                    //如果是pivas药房，要验证这个费用对应的医嘱是否已经被审核
                    if (isPivasYF)
                    {
                        ssql[i] = "update a set a.charge_bit=1,a.charge_date=getdate(),a.charge_user=" + InstanceForm.BCurrentUser.EmployeeId + " from zy_fee_speci a inner join zy_orderrecord b on a.order_id=b.order_id where a.id='" + new Guid(rows[i]["zy_id"].ToString()) + "' and a.charge_bit=0 and a.delete_bit=0 and b.is_pvschk=1";
                    }
                }
                InstanceForm.BDatabase.DoCommand(null, null, null, ssql);
                #endregion

                MessageBox.Show("记账成功", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tb.Rows.Clear();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        /***********************End Modify By Tany****************************************************/

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Guid _groupid = new Guid(Convertor.IsNull(this.myDataGridMx.Tag, Guid.Empty.ToString()));
                //_groupid = new Guid(Convertor.IsNull("47BD001F-AB4A-4AB5-AF27-A0D700D59CE7", Guid.Empty.ToString()));
                if (_groupid == Guid.Empty)
                {
                    MessageBox.Show("必须发药后才能打印单据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                //打印次数
                //string  ssql = "update yf_tld set mxdycs=mxdycs+1 where groupid='" + _groupid + "'";
                //int n = InstanceForm.BDatabase.DoCommand(ssql);
                //if (n == 0)
                //{

                //    ssql = "update yf_tld_h set mxdycs=mxdycs+1 where groupid='" + _groupid + "'";
                //    n = InstanceForm.BDatabase.DoCommand(ssql);
                //}

                string ssql = "select * from vi_yf_tld where groupid='" + _groupid.ToString() + "'";
                DataTable tbtld = InstanceForm.BDatabase.GetDataTable(ssql);


                DataTable tb = ZY_FY.SelectTldMx(_groupid.ToString(), true, InstanceForm.BDatabase);
                this.Cursor = PubStaticFun.WaitCursor();

                if (this.tabControl1.SelectedTab == this.tabPage3 || tb.Rows.Count == 0)
                {
                    #region 权限确认
                    try
                    {
                        if ((new SystemCfg(8008)).Config == "1")
                        {
                            string dlgvalue = DlgPW.Show();
                            string pwStr = dlgvalue; //YS.Password;
                            bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
                            if (!bOk)
                            {
                                FrmMessageBox.Show("你没有通过权限确认，不能发药！", new Font("宋体", 12f), Color.Red, "Sorry！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Cursor = Cursors.Default;
                                return;
                            }
                        }
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion
                }
                Print_FYMXInfo(tb, _groupid, tbtld);

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        public static DataTable GroupByDataTable(DataTable tbtb, string[] GroupByField, string[] ComputeField, string[] Cfield, string filter)
        {
            DataTable tb = tbtb.Clone();
            if (filter != "")
            {
                tb = tb.Clone();
                DataRow[] rows = tbtb.Select(filter);
                for (int i = 0; i < rows.Length; i++)
                {
                    tb.ImportRow(rows[i]);
                }
            }
            else
            {
                tb = tbtb;
            }
            return GroupByDataTable(tb, GroupByField, ComputeField, Cfield);
        }

        public static DataTable GroupByDataTable(DataTable tbtb, string[] GroupByField, string[] ComputeField, string[] Cfield)
        {
            DataTable tbCompute = new DataTable();
            if (tbtb.Rows.Count <= 0)
                return tbCompute;
            List<string> lstCol = new List<string>();
            List<string> lstHj = new List<string>();

            #region 数据验证

            //分组字段不能出现重复数据
            List<string> lstGroupByFiled = new List<string>();
            for (int i = 0; i < GroupByField.Length; i++)
            {
                if (!lstGroupByFiled.Contains(GroupByField[i]))
                {
                    lstGroupByFiled.Add(GroupByField[i]);
                }
                else
                {
                    throw new Exception(string.Format("分组发生错误:GroupByField出现重复字段:{0}", GroupByField[i]));
                }
            }

            for (int i = 0; i < tbtb.Columns.Count; i++)
            {
                lstCol.Add(tbtb.Columns[i].ColumnName.ToLower().Trim());
            }

            for (int i = 0; i < GroupByField.Length; i++)
            {
                if (!lstCol.Contains(GroupByField[i].ToLower().Trim()))
                {
                    throw new Exception(string.Format("分组发生错误:找不到GroupByField:{0}", GroupByField[i].Trim().ToLower()));
                }
            }

            for (int i = 0; i < ComputeField.Length; i++)
            {
                if (!lstCol.Contains(ComputeField[i].ToLower().Trim()))
                {
                    throw new Exception(string.Format("分组发生错误:找不到ComputeField:{0}", ComputeField[i].Trim().ToLower()));
                }
            }
            lstHj.Add("sum");
            lstHj.Add("max");
            lstHj.Add("min");
            lstHj.Add("count");
            for (int i = 0; i < Cfield.Length; i++)
            {
                if (!lstHj.Contains(Cfield[i].Trim().ToLower().Trim()))
                {
                    throw new Exception(string.Format("分组发生错误:不支持Cfield:{0}", Cfield[i]));
                }
            }

            if (ComputeField.Length != Cfield.Length)
            {
                throw new Exception("分组发生错误:ComputeField与Cfield数组长度不一致");
            }
            #endregion

            #region 添加列
            for (int i = 0; i <= GroupByField.Length - 1; i++)
                tbCompute.Columns.Add(GroupByField[i]);
            for (int i = 0; i <= ComputeField.Length - 1; i++)
                tbCompute.Columns.Add(ComputeField[i]);
            if (tbtb.Rows.Count <= 0) return tbCompute;
            #endregion

            #region 计算
            DataTable tb = tbtb.Copy();
            string strFilter = " 1=1 ";
            try
            {

                for (int i = 0; 0 < tb.Rows.Count; i++)
                {
                    DataRow insertRow = tbCompute.NewRow();
                    strFilter = " 1=1 ";
                    for (int j = 0; j < GroupByField.Length; j++)
                    {

                        if (tb.Rows[0][GroupByField[j]] is DBNull)
                        {
                            strFilter += string.Format(" and {0} is null ", GroupByField[j].ToString()
                            );
                        }
                        else
                        {
                            strFilter += string.Format(" and {0}='{1}'", GroupByField[j].ToString(),
                              tb.Rows[0][GroupByField[j]].ToString());
                        }

                        //分组列赋值
                        insertRow[GroupByField[j]] = tb.Rows[0][GroupByField[j]];
                    }

                    tb.DefaultView.RowFilter = strFilter;
                    DataTable tbTemp = tb.DefaultView.ToTable();

                    //求汇总
                    for (int mm = 0; mm < ComputeField.Length; mm++)
                    {
                        string strCompute = string.Format("{0}({1})", Cfield[mm], ComputeField[mm].Trim());
                        insertRow[ComputeField[mm]] = tbTemp.Compute(strCompute, "").ToString();
                    }

                    tbCompute.Rows.Add(insertRow);
                    DataRow[] rows = tb.Select(strFilter);
                    if (rows.Length <= 0)
                    {
                        throw new Exception("分组发生错误,未成成功移除行:" + strFilter);
                    }
                    for (int w = 0; w < rows.Length; w++)
                    {
                        tb.Rows.Remove(rows[w]);
                    }

                }
            }
            catch (Exception err)
            {
                throw new Exception("分组发生错误" + strFilter + " " + err.Message);
            }
            #endregion

            return tbCompute;
        }
    }
}
