using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
//using YpClass;
using grproLib;

namespace ts_yp_ypcd
{
    /// <summary>
    ///Frmtitle 药品字典列表
    /// </summary>
    public class Frmtitle : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TreeView treeView1;
        private myDataGrid.myDataGrid myDataGrid1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtdm;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Button butnew;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbsort;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkxgsj;
        private System.Windows.Forms.DateTimePicker dtpxgsj;
        private System.Windows.Forms.CheckBox chkhb;
        private System.Windows.Forms.Button buthb;
        private System.Windows.Forms.Button butdel;
        private System.Windows.Forms.Button butunhb;
        private Button butexcel;
        private Button button1;
        private Button butWbks;
        private System.ComponentModel.IContainer components;
        bool isWbks = false;

        /// <summary>
        /// 窗口构造函数
        /// </summary>
        public Frmtitle()
        {
            //
            // Windows 窗体设计器支持所必需的
            //

            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            if (InstanceForm._menuTag.Function_Name == "Fun_ts_yp_ypcd_all")
            {
                butdel.Enabled = false;
                butnew.Enabled = false;
                buthb.Enabled = false;
                butunhb.Enabled = false;
                chkhb.Visible = false;
                butWbks.Enabled = false;
            }
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmtitle));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkhb = new System.Windows.Forms.CheckBox();
            this.dtpxgsj = new System.Windows.Forms.DateTimePicker();
            this.chkxgsj = new System.Windows.Forms.CheckBox();
            this.cmbsort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.butWbks = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.butexcel = new System.Windows.Forms.Button();
            this.butunhb = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.buthb = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butnew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtdm = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkhb);
            this.panel1.Controls.Add(this.dtpxgsj);
            this.panel1.Controls.Add(this.chkxgsj);
            this.panel1.Controls.Add(this.cmbsort);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 32);
            this.panel1.TabIndex = 0;
            // 
            // chkhb
            // 
            this.chkhb.BackColor = System.Drawing.SystemColors.Info;
            this.chkhb.Location = new System.Drawing.Point(88, 5);
            this.chkhb.Name = "chkhb";
            this.chkhb.Size = new System.Drawing.Size(112, 24);
            this.chkhb.TabIndex = 5;
            this.chkhb.Text = "显示合并列";
            this.chkhb.UseVisualStyleBackColor = false;
            this.chkhb.CheckedChanged += new System.EventHandler(this.chkhb_CheckedChanged);
            // 
            // dtpxgsj
            // 
            this.dtpxgsj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpxgsj.Enabled = false;
            this.dtpxgsj.Location = new System.Drawing.Point(811, 5);
            this.dtpxgsj.Name = "dtpxgsj";
            this.dtpxgsj.Size = new System.Drawing.Size(94, 21);
            this.dtpxgsj.TabIndex = 4;
            this.dtpxgsj.ValueChanged += new System.EventHandler(this.dtpxgsj_ValueChanged);
            // 
            // chkxgsj
            // 
            this.chkxgsj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkxgsj.BackColor = System.Drawing.SystemColors.Info;
            this.chkxgsj.Location = new System.Drawing.Point(740, 4);
            this.chkxgsj.Name = "chkxgsj";
            this.chkxgsj.Size = new System.Drawing.Size(80, 24);
            this.chkxgsj.TabIndex = 3;
            this.chkxgsj.Text = "修改时间";
            this.chkxgsj.UseVisualStyleBackColor = false;
            this.chkxgsj.CheckedChanged += new System.EventHandler(this.chkxgsj_CheckedChanged);
            // 
            // cmbsort
            // 
            this.cmbsort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbsort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsort.Items.AddRange(new object[] {
            "品名",
            "商品名",
            "货号",
            "登记时间"});
            this.cmbsort.Location = new System.Drawing.Point(643, 5);
            this.cmbsort.Name = "cmbsort";
            this.cmbsort.Size = new System.Drawing.Size(88, 20);
            this.cmbsort.TabIndex = 2;
            this.cmbsort.SelectedIndexChanged += new System.EventHandler(this.cmbsort_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(611, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "排序";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(948, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "药品词典一览";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.butWbks);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.butexcel);
            this.panel3.Controls.Add(this.butunhb);
            this.panel3.Controls.Add(this.butdel);
            this.panel3.Controls.Add(this.buthb);
            this.panel3.Controls.Add(this.butquit);
            this.panel3.Controls.Add(this.butnew);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 618);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(948, 32);
            this.panel3.TabIndex = 2;
            // 
            // butWbks
            // 
            this.butWbks.Location = new System.Drawing.Point(588, 4);
            this.butWbks.Name = "butWbks";
            this.butWbks.Size = new System.Drawing.Size(104, 24);
            this.butWbks.TabIndex = 7;
            this.butWbks.Text = "外部科室(&W)";
            this.butWbks.Click += new System.EventHandler(this.butWbks_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "导出(&E)";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butexcel
            // 
            this.butexcel.Location = new System.Drawing.Point(108, 5);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(104, 24);
            this.butexcel.TabIndex = 5;
            this.butexcel.Text = "导出(&E)";
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // butunhb
            // 
            this.butunhb.Location = new System.Drawing.Point(461, 4);
            this.butunhb.Name = "butunhb";
            this.butunhb.Size = new System.Drawing.Size(115, 24);
            this.butunhb.TabIndex = 4;
            this.butunhb.Text = "取消合并(&H)";
            this.butunhb.Click += new System.EventHandler(this.butunhb_Click);
            // 
            // butdel
            // 
            this.butdel.Location = new System.Drawing.Point(698, 4);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(104, 24);
            this.butdel.TabIndex = 3;
            this.butdel.Text = "停用(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // buthb
            // 
            this.buthb.Location = new System.Drawing.Point(346, 4);
            this.buthb.Name = "buthb";
            this.buthb.Size = new System.Drawing.Size(104, 24);
            this.buthb.TabIndex = 2;
            this.buthb.Text = "合并(&H)";
            this.buthb.Click += new System.EventHandler(this.buthb_Click);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(813, 4);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(98, 24);
            this.butquit.TabIndex = 1;
            this.butquit.Text = "退出(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butnew
            // 
            this.butnew.Location = new System.Drawing.Point(230, 4);
            this.butnew.Name = "butnew";
            this.butnew.Size = new System.Drawing.Size(104, 24);
            this.butnew.TabIndex = 0;
            this.butnew.Text = "新增(&A)";
            this.butnew.Click += new System.EventHandler(this.butnew_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 586);
            this.panel2.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 40);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(240, 546);
            this.panel6.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.treeView1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 40);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(240, 506);
            this.panel11.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(240, 506);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.tabControl1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 16);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(240, 24);
            this.panel10.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 24);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(232, 0);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "属性";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 0);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "药品类型";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(232, 0);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "剂型";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(232, 0);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "药理分类";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(240, 16);
            this.panel9.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "属性查询";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(240, 40);
            this.panel5.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtdm);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 16);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(240, 24);
            this.panel8.TabIndex = 1;
            // 
            // txtdm
            // 
            this.txtdm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtdm.Location = new System.Drawing.Point(0, 0);
            this.txtdm.Name = "txtdm";
            this.txtdm.Size = new System.Drawing.Size(240, 21);
            this.txtdm.TabIndex = 0;
            this.txtdm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdm_KeyPress);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(240, 16);
            this.panel7.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "编码查询";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(240, 32);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 586);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.myDataGrid1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(242, 32);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(706, 586);
            this.panel4.TabIndex = 5;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.GridLineColor = System.Drawing.Color.Gray;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(706, 586);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.myDataGrid1_Paint);
            this.myDataGrid1.DoubleClick += new System.EventHandler(this.myDataGrid1_DoubleClick);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // Frmtitle
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(948, 650);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Frmtitle";
            this.Text = "药品词典设置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmtitle_Load);
            this.Activated += new System.EventHandler(this.Frmtitle_Activated);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 窗体LOAD事件 初始化网格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frmtitle_Load(object sender, System.EventArgs e)
        {
            isWbks = YpClass.WBKS.IsWbks(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

            string[] HeaderText ={ "序号", "合并", "货号", "品名", "商品名", "备注", "规格", "单位", "厂家", "批发价", "零售价", "领药方式", "统领分类", "医保", "登记时间", "停用", "GGID", "CJID", "英文名", "中标", "付款比例" };
            string[] MappingName ={ "序号", "合并", "货号", "品名", "商品名", "备注", "规格", "单位", "厂家", "批发价", "零售价", "领药方式", "统领分类", "医保", "登记时间", "停用", "GGID", "CJID", "英文名", "中标", "付款比例" };
            int[] ColWidth =	 { 30, 0, 90, 110, 110, 50, 100, 40, 100, 65, 65, 100, 80, 0, 100, 50, 0, 60, 100, 40, 60 };
            bool[] BoolCol =		 { false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true, false };

            //this.myDataGrid1.ReadOnly=true;

            //FunBase.csMydataGrid(this.myDataGrid1,HeaderText,MappingName,BoolCol,ColWidth,false);


            DataTable tabTmp = new DataTable();

            for (int i = 0; i < HeaderText.Length; i++)
            {
                if (BoolCol[i] == false)
                {
                    DataGridEnableTextBoxColumn grdtxtCol = new DataGridEnableTextBoxColumn(i);
                    grdtxtCol.HeaderText = HeaderText[i];
                    grdtxtCol.MappingName = MappingName[i];

                    grdtxtCol.Width = ColWidth[i];
                    grdtxtCol.NullText = "";
                    grdtxtCol.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(col_CheckCellEnabled);

                    this.myDataGrid1.TableStyles[0].GridColumnStyles.Add(grdtxtCol);
                }
                else
                {
                    System.Windows.Forms.DataGridBoolColumn aColumnBoolColumn;
                    aColumnBoolColumn = new DataGridBoolColumn();
                    aColumnBoolColumn.HeaderText = HeaderText[i];
                    aColumnBoolColumn.MappingName = MappingName[i];
                    aColumnBoolColumn.Width = ColWidth[i];
                    aColumnBoolColumn.AllowNull = false;
                    aColumnBoolColumn.NullValue = ((short)(0));
                    aColumnBoolColumn.FalseValue = ((short)(0));
                    aColumnBoolColumn.TrueValue = ((short)(1));
                    myDataGrid1.TableStyles[0].GridColumnStyles.Add(aColumnBoolColumn);
                }

                tabTmp.Columns.Add(HeaderText[i]);
            }
            this.myDataGrid1.DataSource = tabTmp.DefaultView;
            PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);
            cmbsort.SelectedIndex = 0;
            //SelectGG("","");
            this.AddTreeYpsx();
            this.dtpxgsj.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);


        }

        void col_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            if (tb.Rows.Count > 0)
            {
                int iselect = Convert.ToInt32(tb.Rows[e.Row]["停用"]);
                if (iselect == 1)
                    e.ForeColor = Color.Red;

                else
                    e.ForeColor = Color.Black;
            }
        }


        /// <summary>
        /// 列表查询方法
        /// </summary>
        /// <param name="swhere">条件字符串</param>
        /// <param name="ypbm">别名查询字符串</param>
        private void SelectGG(string swhere, string ypbm)
        {
            try
            {
                string ssql = "select 0 as 序号,cast(0 as smallint) 合并,shh 货号,yppm 品名,ypspm 商品名,ypspmbz 备注,ypgg 规格,s_ypdw 单位,s_sccj 厂家," +
                    "pfj 批发价,lsj 零售价,(select mc from yp_lyfs where id=lyfs) 领药方式,c.name 统领分类,'' 医保,b.djsj 登记时间,cast(b.bdelete as smallint) 停用," +
                    " a.ggid,cjid,ypywm 英文名,cast(zbzt as smallint) 中标,cast(b.fkbl*100 as decimal(15,2)) 付款比例 from yp_ypggd a inner join yp_ypcjd b on a.ggid=b.ggid " +
                    " left join yp_tlfl c on a.tlfl=c.code where a.ggid>0 ";


                if (InstanceForm._menuTag.Function_Name == "Fun_ts_yp_ypcd" && InstanceForm.BCurrentUser.IsAdministrator == false)
                    ssql = ssql + " and ypzlx in(select ypzlx from yp_gllx where deptid=" + InstanceForm.BCurrentDept.DeptId +
                        " or deptid in(select deptid from yp_yjks_gx where p_deptid=" + InstanceForm.BCurrentDept.DeptId + ") ) ";
                if (swhere.Trim() == "" && ypbm.Trim() == "") ssql = ssql + " and b.bdelete=0 ";
                if (swhere.Trim() != "") ssql = ssql + " " + swhere;
                if (ypbm.Trim() != "")
                    ssql = ssql + " and  a.ggid in (select ggid from yp_ypbm where  upper(pym) like '%" + ypbm.Trim().ToUpper() + "%'" +
                        " or upper(wbm) like '%" + ypbm.Trim().ToUpper() + "%'" +
                        " or  ypbm like '%" + ypbm.Trim() + "%') ";

                if (this.chkxgsj.Checked == true)
                    ssql = ssql + " and xgsj>='" + this.dtpxgsj.Value.ToShortDateString() + " 00:00:01' and xgsj<='" + this.dtpxgsj.Value.ToShortDateString() + " 23:59:59'";

                //如果外部科室则只能看到自己的药，不是外部科室不能看到外部药品 Modify By Tany 2015-11-26
                //管理员不受限制
                if (!TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator)
                {
                    if (isWbks)
                    {
                        ssql += string.Format(" and isnull(b.iswbyp,0)=1 and b.cjid in ( select cjid from yp_wbksyp where deptid = {0})", InstanceForm.BCurrentDept.DeptId);
                    }
                    else
                    {
                        ssql += string.Format(" and isnull(b.iswbyp,0)=0 ");
                    }
                }
                if (cmbsort.SelectedIndex == 0)
                    ssql = ssql + " order by yppm";
                if (cmbsort.SelectedIndex == 1)
                    ssql = ssql + " order by ypspm";
                if (cmbsort.SelectedIndex == 2)
                    ssql = ssql + " order by shh";
                if (cmbsort.SelectedIndex == 3)
                    ssql = ssql + " order by b.djsj";

                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                FunBase.AddRowtNo(tb);
                tb.TableName = "ypgg";
                this.myDataGrid1.DataSource = tb;
                this.myDataGrid1.TableStyles[0].MappingName = "ypgg";
                PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);
                //FunBase.myGridSelect(this.myDataGrid1,this.myDataGrid1.TableStyles[0].GridColumnStyles);
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #region 添加嘱性查询树
        /// <summary>
        /// 添加药品类型树
        /// </summary>
        private void AddTreeYplx()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList1;

            DataTable tb = Yp.SelectYPLX(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                TreeNode node = treeView1.Nodes.Add(tb.Rows[i]["mc"].ToString());
                node.Tag = " and yplx=" + Convert.ToInt32(tb.Rows[i]["id"]) + "";
                node.ImageIndex = 0;
                DataTable tbc = Yp.SelectYpzlx(InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(tb.Rows[i]["id"]), InstanceForm.BDatabase);
                for (int j = 0; j <= tbc.Rows.Count - 1; j++)
                {
                    TreeNode Cnode = node.Nodes.Add(tbc.Rows[j]["mc"].ToString());
                    Cnode.Tag = " and yplx=" + Convert.ToInt32(tb.Rows[i]["id"]) + " and ypzlx=" + Convert.ToInt32(tbc.Rows[j]["id"]);
                    Cnode.ImageIndex = 1;
                }
                node.Expand();
            }

            TreeNode node1 = treeView1.Nodes.Add("没有分类的药品");
            node1.ImageIndex = 1;
            node1.Tag = " and (yplx=0 or ypzlx=0) ";
        }


        /// <summary>
        /// 添加药品剂型树
        /// </summary>
        private void AddTreeYpjx()
        {
            this.treeView1.Nodes.Clear();
            //			DataTable tb=Yp.SelectYPLX(InstanceForm.BCurrentDept.DeptId);
            //			for(int i=0 ;i<=tb.Rows.Count-1;i++)
            //			{
            TreeNode node = treeView1.Nodes.Add("剂型");
            node.Tag = "";
            //				node.Tag=" and yplx="+Convert.ToInt32(tb.Rows[i]["id"])+"";
            //				node.ImageIndex=0;
            //				DataTable tbc=Yp.SelectYpjx(Convert.ToInt32(tb.Rows[i]["id"]));
            DataTable tbc = Yp.SelectYpjx(0, InstanceForm.BDatabase);
            for (int j = 0; j <= tbc.Rows.Count - 1; j++)
            {
                TreeNode Cnode = node.Nodes.Add(tbc.Rows[j]["mc"].ToString());
                Cnode.Tag = "  and ypjx=" + Convert.ToInt32(tbc.Rows[j]["id"]);
                //Cnode.Tag=" and yplx="+Convert.ToInt32(tb.Rows[i]["id"])+" and ypjx="+Convert.ToInt32(tbc.Rows[j]["id"]);
                Cnode.ImageIndex = 1;
            }
            node.Expand();

            TreeNode node1 = treeView1.Nodes.Add("没有分类的药品");
            node1.ImageIndex = 1;
            node1.Tag = " and (ypjx=0 or ypjx not in(select id from yp_ypjx) ) ";
            //			}
        }


        /// <summary>
        /// 添加属性标志树
        /// </summary>
        private void AddTreeYpsx()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList1;
            TreeNode node = treeView1.Nodes.Add("属性状态");
            node.Tag = "";
            TreeNode Cnode2 = node.Nodes.Add("毒剧药品");
            Cnode2.Tag = " and djyp=1 ";
            Cnode2.ImageIndex = 1;
            TreeNode Cnode3 = node.Nodes.Add("麻醉药品");
            Cnode3.Tag = " and mzyp=1 ";
            Cnode3.ImageIndex = 1;
            TreeNode Cnode4 = node.Nodes.Add("皮试药品");
            Cnode4.Tag = " and psyp=1 ";
            Cnode4.ImageIndex = 1;
            TreeNode Cnode5 = node.Nodes.Add("精神药品");
            Cnode5.Tag = " and jsyp=1 ";
            Cnode5.ImageIndex = 1;
            TreeNode Cnode6 = node.Nodes.Add("贵重药品");
            Cnode6.Tag = " and gzyp=1 ";
            Cnode6.ImageIndex = 1;

            TreeNode Cnode20 = node.Nodes.Add("外用药品");
            Cnode20.Tag = " and wyyp=1 ";
            Cnode20.ImageIndex = 1;

            TreeNode Cnode7 = node.Nodes.Add("处方药品");
            Cnode7.Tag = " and cfyp=1 ";
            Cnode7.ImageIndex = 1;

            TreeNode Cnode21 = node.Nodes.Add("妊娠药品");
            Cnode21.Tag = " and rsyp=1 ";
            Cnode21.ImageIndex = 1;

            TreeNode Cnode22 = node.Nodes.Add("中标药品");
            Cnode22.Tag = " and zbzt=1 ";
            Cnode22.ImageIndex = 1;

            TreeNode Cnode32 = node.Nodes.Add("基本药物");
            Cnode32.Tag = " and GJJBYW=1 ";
            Cnode32.ImageIndex = 1;

            TreeNode Cnode33 = node.Nodes.Add("高危药品");
            Cnode33.Tag = " and GWYP=1 ";
            Cnode33.ImageIndex = 1;

            TreeNode Cnode13 = node.Nodes.Add("停用的药品");
            Cnode13.Tag = " and b.BDELETE=1 ";
            Cnode13.ImageIndex = 1;

            TreeNode Cnode14 = node.Nodes.Add("★按包装取整");
            Cnode14.Tag = " and lyfs=1 ";
            Cnode14.ImageIndex = 1;
            TreeNode Cnode15 = node.Nodes.Add("★按含量累计");
            Cnode15.Tag = " and lyfs=2 ";
            Cnode15.ImageIndex = 1;

            TreeNode Cnode16 = node.Nodes.Add("●正主任医师用药");
            Cnode16.Tag = " and cfjb=1 ";
            Cnode16.ImageIndex = 1;
            TreeNode Cnode17 = node.Nodes.Add("●副正主任医师用药");
            Cnode17.Tag = " and cfjb=2 ";
            Cnode17.ImageIndex = 1;
            TreeNode Cnode18 = node.Nodes.Add("●主治医师用药");
            Cnode18.Tag = " and cfjb=3 ";
            Cnode18.ImageIndex = 1;
            TreeNode Cnode19 = node.Nodes.Add("●经治医师用药");
            Cnode19.Tag = " and cfjb=4 ";
            Cnode19.ImageIndex = 1;

            //统领分类
            string ssql = "select * from yp_tlfl ";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                TreeNode Cnode30 = node.Nodes.Add("※" + Convertor.IsNull(tb.Rows[i]["name"], ""));
                Cnode30.Tag = " and a.tlfl='" + Convertor.IsNull(tb.Rows[i]["code"], "") + "' ";

                Cnode30.ImageIndex = 1;
            }

            //modefy by lwl 2011-10-19
            //抗生素等级
            string ksssql = "select * from YP_KSSDJ";
            DataTable dt = InstanceForm.BDatabase.GetDataTable(ksssql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode Cnode31 = node.Nodes.Add("★" + Convertor.IsNull(dt.Rows[i]["KSSDJMC"], ""));
                Cnode31.Tag = " and a.KSSDJID='" + Convertor.IsNull(dt.Rows[i]["KSSDJID"], "") + "' ";

                Cnode31.ImageIndex = 1;
            }




            node.Expand();


        }

        /// <summary>
        /// 添加药理分类树
        /// </summary>
        /// <param name="tb">药理分类表</param>
        /// <param name="treeNode">当前节点</param>
        /// <param name="fid">父ID</param>
        private void AddTreeYlfl(DataTable tb, TreeNode treeNode, long fid)
        {
            treeNode.Nodes.Clear();
            DataRow[] rows = tb.Select(" fid=" + fid + "");
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                TreeNode Cnode = treeNode.Nodes.Add(rows[i]["flmc"].ToString());
                Cnode.Tag = " and ylfl=" + Convert.ToInt64(rows[i]["id"]) + " ";
                Cnode.Tag = " and ylfl in(select id from dbo.fun_tlfl_child(" + Convertor.IsNull(rows[i]["id"], "") + ")) ";
                if (rows[i]["yjdbz"].ToString() == "1") Cnode.ImageIndex = 1; else Cnode.ImageIndex = 0;
                AddTreeYlfl(tb, Cnode, Convert.ToInt64(rows[i]["id"]));
            }
        }



        /// <summary>
        /// 药品属性选项卡改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex.ToString())
            {
                case "0":
                    this.AddTreeYpsx();
                    break;
                case "1":
                    this.AddTreeYplx();
                    break;
                case "2":
                    this.AddTreeYpjx();
                    break;
                case "3":
                    this.treeView1.Nodes.Clear();
                    this.treeView1.ImageList = this.imageList1;
                    TreeNode node = treeView1.Nodes.Add("药理分类目录");
                    node.Tag = " and ylfl<>-1 ";
                    node.ImageIndex = 0;

                    TreeNode nodenull = treeView1.Nodes.Add("☆ 没有分类的药品");
                    nodenull.Tag = " and ylfl=0 ";
                    nodenull.ImageIndex = 1;

                    DataTable tb = Yp.SelectYlfl(InstanceForm.BDatabase);
                    this.AddTreeYlfl(tb, node, 0);
                    node.Expand();
                    break;
                default:
                    break;
            }
        }

        #endregion

        /// <summary>
        /// 药品属性树节点选择事件，用于查询和当前属性匹配的药品列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            try
            {
                //if (this.treeView1.SelectedNode.ImageIndex==1)
                //{
                this.Cursor = PubStaticFun.WaitCursor();
                this.SelectGG(this.treeView1.SelectedNode.Tag.ToString(), "");
                //}
                //else
                //{
                //    DataTable tb=(DataTable)this.myDataGrid1.DataSource;
                //    tb.Rows.Clear();
                //}
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


        /// <summary>
        /// 新增按钮事件，新增一个药品时使用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butnew_Click(object sender, System.EventArgs e)
        {
            Frmypcd frmypcd = new Frmypcd();
            frmypcd.ShowDialog();
        }

        /// <summary>
        /// 网格双击事件，弹出药品明细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (this.myDataGrid1.TableStyles[0].GridColumnStyles[this.myDataGrid1.CurrentCell.ColumnNumber].HeaderText.Trim() == "合并")
                {
                    return;
                }
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                if (nrow < 0) return;
                if (tb.Rows.Count <= 0) return;
                if (nrow > tb.Rows.Count) return;
                Frmypcd cd = new Frmypcd(Convert.ToInt32(tb.Rows[nrow]["cjid"]));
                //cd.FillYp(Convert.ToInt32(tb.Rows[nrow]["cjid"]));
                cd.Show();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 网格单元格改变事件,用于选中一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            this.myDataGrid1.Select(this.myDataGrid1.CurrentCell.RowNumber);
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (nrow > tb.Rows.Count - 1) return;
            if (Convert.ToInt16(tb.Rows[nrow]["停用"]) == 0)
                this.butdel.Text = "停用(&D)";
            else
                this.butdel.Text = "启用(&D)";

            this.myDataGrid1.Select(this.myDataGrid1.CurrentCell.RowNumber);
        }

        private void butquit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void cmbsort_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                SelectGG("", txtdm.Text.Trim());
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

        private void chkxgsj_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.dtpxgsj.Enabled = chkxgsj.Checked == true ? true : false;
                this.Cursor = PubStaticFun.WaitCursor();
                this.SelectGG("", this.txtdm.Text.Trim());
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

        private void dtpxgsj_ValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                this.SelectGG("", this.txtdm.Text.Trim());
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

        private void Frmtitle_Activated(object sender, System.EventArgs e)
        {
            this.txtdm.Focus();
        }

        private void chkhb_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                System.Windows.Forms.DataGridBoolColumn col = (System.Windows.Forms.DataGridBoolColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles["合并"];
                col.Width = this.chkhb.Checked == true ? 30 : 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void myDataGrid1_Click(object sender, System.EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            //this.myDataGrid1.CurrentCell=new DataGridCell(this.myDataGrid1.CurrentCell.RowNumber,this.myDataGrid1.CurrentCell.ColumnNumber);
            if (tb.Rows.Count <= 0) return;
            this.myDataGrid1.Select(this.myDataGrid1.CurrentCell.RowNumber);
            string colname = this.myDataGrid1.TableStyles[0].GridColumnStyles[this.myDataGrid1.CurrentCell.ColumnNumber].HeaderText.Trim();
            if (colname.Trim() == "合并")
            {
                if (Convert.ToBoolean(tb.Rows[this.myDataGrid1.CurrentCell.RowNumber][colname.Trim()]) == true)
                    tb.Rows[this.myDataGrid1.CurrentCell.RowNumber][colname.Trim()] = (short)0;
                else
                    tb.Rows[this.myDataGrid1.CurrentCell.RowNumber][colname.Trim()] = (short)1;
            }

        }

        private void buthb_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                DataTable tab = tb.Clone();
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(tb.Rows[i]["合并"]) == true)
                    {
                        tab.ImportRow(tb.Rows[i]);
                    }
                }

                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    tab.Rows[i]["合并"] = (short)0;

                    DataRow[] rows = tab.Select("ggid=" + tab.Rows[i]["ggid"].ToString().Trim() + " and cjid<>" + tab.Rows[i]["cjid"].ToString().Trim() + "");
                    if (rows.Length != 0)
                    {
                        MessageBox.Show("第 " + tab.Rows[i]["序号"].ToString() + " 行与第 " + rows[0]["序号"].ToString() + " 行本来就是同一规格,请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                Frmhb f = new Frmhb();
                tab.TableName = "Tb";
                f.myDataGrid1.DataSource = tab;
                f.myDataGrid1.TableStyles[0].MappingName = "Tb";
                FunBase.myGridSelect(f.myDataGrid1, f.myDataGrid1.TableStyles[0].GridColumnStyles);
                f.panel4.Height = 0;
                f.txtdm.Visible = false;
                f.label2.Visible = false;
                f.butok_hb.Visible = false;
                f.butok.Visible = true;
                f.ShowDialog();

                if (f.UpdateRows != null)
                {
                    for (int i = 0; i <= f.UpdateRows.Length - 1; i++)
                    {
                        DataRow[] row = tb.Select("cjid=" + f.UpdateRows[i]["cjid"] + "");
                        tb.Rows.Remove(row[0]);
                    }
                }


            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void butdel_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                string ssql = "";
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                int cjid = Convert.ToInt32(tb.Rows[nrow]["cjid"]);
                if (nrow > tb.Rows.Count - 1) return;

                InstanceForm.BDatabase.BeginTransaction();

                string str_old = "";
                if (this.butdel.Text.Trim() == "停用(&D)")
                {
                    if (MessageBox.Show("是否停用此药品,一停用则全院的库存，库存批号中的药品都会停用？", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    // if (MessageBox.Show("是否停用此药品？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        //1.更新药品厂家信息为停用
                        ssql = "update yp_ypcjd set bdelete=1 where cjid=" + cjid + " ;"; // 原来的SQL

                        //2.根据厂家id(cjid)查询药房库存明细信息并保存到YK_KCMX_MID临时表
                        ssql += " INSERT INTO YF_KCMX_MID ( ID,JGBM,GGID,CJID,KCL,ZXDW,DWBL,DJSJ,BDELETE,DEPTID,SCJJ,SCKL,GHDW,CFWZ)";
                        ssql += " SELECT ID,JGBM,GGID,CJID,KCL,ZXDW,DWBL,DJSJ,BDELETE,DEPTID,SCJJ,SCKL,GHDW,CFWZ from YF_KCMX WHERE cjid=" + cjid + " and BDELETE=1 and KCL>0  ;";

                        //3.根据厂家id(cjid)查询药房库存批号信息并保存到YK_KCPH_MID临时表
                        ssql += " INSERT INTO dbo.YF_KCPH_MID (ID,JGBM,GGID,CJID,KWID,YPPH,YPXQ,JHJ,KCL,ZXDW,DWBL,DJSJ,BDELETE,DEPTID,YKBDELETE,YPPCH,RKDJMXID,RKDH,MAXSL,YJHJ,XGSJ)";
                        ssql += " SELECT ID,JGBM,GGID,CJID,KWID,YPPH,YPXQ,JHJ,KCL,ZXDW,DWBL,DJSJ,BDELETE,DEPTID,YKBDELETE,YPPCH,RKDJMXID,RKDH,MAXSL,YJHJ,XGSJ FROM dbo.YF_KCPH WHERE cjid=" + cjid + " and BDELETE=1 and KCL>0  ;";

                        //4.以下是新添加的按医院信息科要求：库存控制全院的药品禁用与启用情况 add by HuangYD 2016-10-12
                        ssql += "update YK_KCMX set bdelete=1 where cjid=" + cjid + " and BDELETE=0 and KCL>0  ;";
                        ssql += "update YK_KCPH set bdelete=1 where cjid=" + cjid + " and BDELETE=0 and KCL>0  ;";
                        ssql += "update YF_KCMX set bdelete=1 where cjid=" + cjid + " and BDELETE=0 and KCL>0  ;";
                        ssql += "update YF_KCPH set bdelete=1 where cjid=" + cjid + " and BDELETE=0 and KCL>0  ;";

                        InstanceForm.BDatabase.DoCommand(ssql);
                        MessageBox.Show("停用成功");
                        tb.Rows[nrow]["停用"] = (short)1;
                        this.butdel.Text = "启用(&D)";

                        str_old = "停用当前药品 cjid:" + cjid + "";
                        SystemLog systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "停用药品", str_old, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, 8);
                        systemLog.Save();
                        systemLog = null;
                    }
                }
                else
                {
                    if (MessageBox.Show("是否启用此药品,一启用则全院的库存，库存批号中的药品都会启用？", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    // if (MessageBox.Show("是否启用此药品？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        // ssql = "update yp_ypcjd set bdelete=0 where cjid=" + cjid + ""; // 原来的SQL

                        //1.更新药品厂家信息为启用
                        ssql = "update YP_YPCJD set bdelete=0 where cjid=" + cjid + " ;";

                        //2.查询药房人员停用库存明细记录信息
                        string strSql = "SELECT ID,CJID FROM YF_KCMX_MID WHERE CJID=" + cjid;
                        DataTable dt = InstanceForm.BDatabase.GetDataTable(strSql, 30);
                        //保存不需要更新药房记录的Ids
                        string strIdsMX = "";
                        foreach (DataRow item in dt.Rows)
                        {
                            strIdsMX += "'" + item["ID"].ToString() + "',";
                        }
                        if (!string.IsNullOrEmpty(strIdsMX))
                        {
                            strIdsMX = strIdsMX.TrimEnd(',');
                        }

                        //3.查询药房人员停用库存批号记录信息
                        strSql = "SELECT ID,CJID FROM  YF_KCPH_MID WHERE CJID=" + cjid;
                        DataTable dtPH = InstanceForm.BDatabase.GetDataTable(strSql, 30);
                        //保存不需要更新药房批号的Ids
                        string strIdsPH = "";
                        foreach (DataRow item in dtPH.Rows)
                        {
                            strIdsPH += "'" + item["ID"].ToString() + "',";
                        }
                        if (!string.IsNullOrEmpty(strIdsPH))
                        {
                            strIdsPH = strIdsPH.TrimEnd(',');
                        }

                        //4.以下是新添加的按医院信息科要求：库存控制全院的药品禁用与启用情况 add by HuangYD 2016-10-12
                        ssql += "update YK_KCMX set bdelete=0 where cjid=" + cjid + " and BDELETE=1 and KCL>0  ;";
                        ssql += "update YK_KCPH set bdelete=0 where cjid=" + cjid + " and BDELETE=1 and KCL>0  ;";

                        if (string.IsNullOrEmpty(strIdsMX))
                        {
                            ssql += "update YF_KCMX set bdelete=0 where cjid=" + cjid + " and BDELETE=1 and KCL>0  ;";
                        }
                        else
                        {
                            ssql += "update YF_KCMX set bdelete=0 where cjid=" + cjid + " and BDELETE=1 and KCL>0 and ID NOT IN (" + strIdsMX + ")  ;";
                        }

                        if (string.IsNullOrEmpty(strIdsPH))
                        {
                            ssql += "update YF_KCPH set bdelete=0 where cjid=" + cjid + " and BDELETE=1 and KCL>0  ;";
                        }
                        else
                        {
                            ssql += "update YF_KCPH set bdelete=0 where cjid=" + cjid + " and BDELETE=1 and KCL>0 and  ID NOT IN (" + strIdsPH + ")  ;";
                        }

                        //5.删除药房库存明细临时表数据
                        ssql += "DELETE FROM YF_KCMX_MID WHERE CJID=" + cjid + "  ;";

                        //6.删除药房库存批号临时数据
                        ssql += "DELETE FROM YF_KCPH_MID WHERE CJID=" + cjid + "  ;";

                        InstanceForm.BDatabase.DoCommand(ssql);
                        MessageBox.Show("启用成功");
                        tb.Rows[nrow]["停用"] = (short)0;
                        this.butdel.Text = "停用(&D)";

                        str_old = "启用当前药品 cjid:" + cjid + "";
                        SystemLog systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "启用药品", str_old, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "主机名：" + System.Environment.MachineName, 8);
                        systemLog.Save();
                        systemLog = null;
                    }
                }


                //三院数据处理
                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                ts.Save_log(ts_HospData_Share.czlx.yp_药品字典修改, InstanceForm.BCurrentUser.Name + "" + str_old + " ", "yp_ypcjd", "cjid", cjid.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                InstanceForm.BDatabase.CommitTransaction();

                //三院数据处理
                string errtext = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.yp_药品字典修改, InstanceForm.BDatabase);
                if (ty.Bzx == 1)
                    ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);


            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void txtdm_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyChar);
            try
            {
                if (nkey == 13)
                {
                    this.Cursor = PubStaticFun.WaitCursor();
                    this.SelectGG("", txtdm.Text.Trim());
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

        private void butunhb_Click(object sender, System.EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                DataTable tab = tb.Clone();
                tab.ImportRow(tb.Rows[this.myDataGrid1.CurrentCell.RowNumber]);

                Frmhb f = new Frmhb();
                tab.TableName = "Tb";
                f.myDataGrid1.DataSource = tab;
                f.myDataGrid1.TableStyles[0].MappingName = "Tb";
                f.butok_hb.Visible = true;
                f.butok.Visible = false;
                f.myDataGrid1.TableStyles[0].GridColumnStyles["合并"].Width = 0;
                FunBase.myGridSelect(f.myDataGrid1, f.myDataGrid1.TableStyles[0].GridColumnStyles);
                f.ShowDialog();

                this.txtdm_KeyPress(txtdm, new System.Windows.Forms.KeyPressEventArgs((char)13));
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;

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
                xlApp.ActiveCell.FormulaR1C1 = "药品词典";
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
                    Application.DoEvents();
                }

                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

                //设置报表表格为最适应宽度
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void myDataGrid1_Paint(object sender, PaintEventArgs e)
        {
            DataTable tb = new DataTable();

        }

        private GridppReport Report = new GridppReport(); //2016-09-06

        private void button1_Click(object sender, EventArgs e)
        {
            //载入报表模板数据

            Report.LoadFromFile(@"D:\TS-HIS\Report\cs.grf");
            Report.DetailGrid.Recordset.ConnectionString = "";
            Report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ReportFetchRecord); //2016-09-06

            //将全部记录一次填入
            //Report.DetailGrid.Recordset.Append();            
            //Report.DetailGrid.Recordset.Post();

            Report.PrintPreview(true);  //2016-09-06
        }

        private void ReportFetchRecord()
        {

            DataTable tb = (DataTable)myDataGrid1.DataSource;
            FillRecordToReport(Report, tb);   //2016-09-06
        }

        private struct MatchFieldPairType
        {
            public IGRField grField;
            public int MatchColumnIndex;
        }

        // 将 DataTable 的数据转储到 Grid++Report 的数据集中
        public static void FillRecordToReport(IGridppReport Report, DataTable dt)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];

            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dt.Columns.Count; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.Name, dt.Columns[i].ColumnName, true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }


            // 将 DataTable 中的每一条记录转储到 Grid++Report 的数据集中去
            foreach (DataRow dr in dt.Rows)
            {
                Report.DetailGrid.Recordset.Append();

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr[MatchFieldPairs[i].MatchColumnIndex];
                }

                Report.DetailGrid.Recordset.Post();
            }
        }

        private void butWbks_Click(object sender, EventArgs e)
        {
            if (this.myDataGrid1.DataSource == null)
                return;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (nrow < 0) return;
            if (tb.Rows.Count <= 0)
                return;
            if (nrow > tb.Rows.Count)
                return;
            Frmwbks frm = new Frmwbks(cztype.edit, Convert.ToInt32(tb.Rows[nrow]["cjid"]));
            frm.ShowDialog();
        }

    }
}
