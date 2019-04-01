using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Diagnostics;
using System.Threading;
using System.Data.OleDb;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using ts_yj_tjbb;


namespace ts_yj_jyqddy
{
    public class Frmzyqddy : System.Windows.Forms.Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbDept;
        private long PrintID = 0;
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmzyqddy));
            this.lblCaption = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btLookup = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbhylx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.txtzyh_jhlx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rdo1_ydy = new System.Windows.Forms.RadioButton();
            this.rdo1_wdy = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rdo2_ydy = new System.Windows.Forms.RadioButton();
            this.rdo2_wdy = new System.Windows.Forms.RadioButton();
            this.txtzyh_bq = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtp3 = new System.Windows.Forms.DateTimePicker();
            this.dtp4 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.打印内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.打印时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.打印人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.butdycx = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpdyrq1 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.Window;
            this.lblCaption.Location = new System.Drawing.Point(0, -2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(913, 34);
            this.lblCaption.TabIndex = 16;
            this.lblCaption.Text = "   检验清单打印";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 556);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 36);
            this.panel1.TabIndex = 17;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(693, -1);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 34);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btExit.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btExit.ForeColor = System.Drawing.Color.White;
            this.btExit.Image = ((System.Drawing.Image)(resources.GetObject("btExit.Image")));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExit.Location = new System.Drawing.Point(814, 0);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(96, 34);
            this.btExit.TabIndex = 17;
            this.btExit.Text = "关闭  \"";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btLookup
            // 
            this.btLookup.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btLookup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLookup.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.btLookup.ForeColor = System.Drawing.Color.White;
            this.btLookup.Image = ((System.Drawing.Image)(resources.GetObject("btLookup.Image")));
            this.btLookup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLookup.Location = new System.Drawing.Point(785, 8);
            this.btLookup.Name = "btLookup";
            this.btLookup.Size = new System.Drawing.Size(96, 34);
            this.btLookup.TabIndex = 18;
            this.btLookup.Text = "查询";
            this.btLookup.UseVisualStyleBackColor = false;
            this.btLookup.Click += new System.EventHandler(this.btLookup_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(679, 476);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(457, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 32;
            this.label5.Text = "申请病区";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(469, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 31;
            this.label3.Text = "检验类型";
            // 
            // cmbhylx
            // 
            this.cmbhylx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbhylx.FormattingEnabled = true;
            this.cmbhylx.Items.AddRange(new object[] {
            "",
            "生化室",
            "细菌室",
            "免疫室",
            "细胞室",
            "PCR实验室",
            "体液室",
            "免疫发光室",
            "血液室",
            "血库室",
            "乙肝室"});
            this.cmbhylx.Location = new System.Drawing.Point(534, 14);
            this.cmbhylx.Name = "cmbhylx";
            this.cmbhylx.Size = new System.Drawing.Size(103, 22);
            this.cmbhylx.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(96, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "开始时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(282, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 25;
            this.label2.Text = "结束时间";
            // 
            // dtp1
            // 
            this.dtp1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp1.Location = new System.Drawing.Point(161, 14);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(119, 23);
            this.dtp1.TabIndex = 26;
            // 
            // dtp2
            // 
            this.dtp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp2.Location = new System.Drawing.Point(347, 14);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(120, 23);
            this.dtp2.TabIndex = 27;
            // 
            // txtzyh_jhlx
            // 
            this.txtzyh_jhlx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzyh_jhlx.Location = new System.Drawing.Point(690, 14);
            this.txtzyh_jhlx.Name = "txtzyh_jhlx";
            this.txtzyh_jhlx.Size = new System.Drawing.Size(93, 23);
            this.txtzyh_jhlx.TabIndex = 1;
            this.txtzyh_jhlx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtzyh_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(639, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "住院号";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(912, 80);
            this.tabControl1.TabIndex = 37;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.rdo1_ydy);
            this.tabPage1.Controls.Add(this.rdo1_wdy);
            this.tabPage1.Controls.Add(this.btLookup);
            this.tabPage1.Controls.Add(this.txtzyh_jhlx);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dtp1);
            this.tabPage1.Controls.Add(this.cmbhylx);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dtp2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(904, 52);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "按检验类型打印";
            // 
            // rdo1_ydy
            // 
            this.rdo1_ydy.AutoSize = true;
            this.rdo1_ydy.Checked = true;
            this.rdo1_ydy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo1_ydy.Location = new System.Drawing.Point(8, 30);
            this.rdo1_ydy.Name = "rdo1_ydy";
            this.rdo1_ydy.Size = new System.Drawing.Size(67, 18);
            this.rdo1_ydy.TabIndex = 37;
            this.rdo1_ydy.TabStop = true;
            this.rdo1_ydy.Text = "已打印";
            this.rdo1_ydy.UseVisualStyleBackColor = true;
            this.rdo1_ydy.CheckedChanged += new System.EventHandler(this.rdo1_wdy_CheckedChanged);
            // 
            // rdo1_wdy
            // 
            this.rdo1_wdy.AutoSize = true;
            this.rdo1_wdy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo1_wdy.Location = new System.Drawing.Point(8, 6);
            this.rdo1_wdy.Name = "rdo1_wdy";
            this.rdo1_wdy.Size = new System.Drawing.Size(67, 18);
            this.rdo1_wdy.TabIndex = 36;
            this.rdo1_wdy.Text = "未打印";
            this.rdo1_wdy.UseVisualStyleBackColor = true;
            this.rdo1_wdy.CheckedChanged += new System.EventHandler(this.rdo1_wdy_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.cmbDept);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.rdo2_ydy);
            this.tabPage2.Controls.Add(this.rdo2_wdy);
            this.tabPage2.Controls.Add(this.txtzyh_bq);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dtp3);
            this.tabPage2.Controls.Add(this.dtp4);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(904, 52);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "按申请病区打印";
            // 
            // cmbDept
            // 
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(522, 17);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(123, 22);
            this.cmbDept.TabIndex = 41;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(793, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 34);
            this.button1.TabIndex = 40;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rdo2_ydy
            // 
            this.rdo2_ydy.AutoSize = true;
            this.rdo2_ydy.Checked = true;
            this.rdo2_ydy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo2_ydy.Location = new System.Drawing.Point(8, 31);
            this.rdo2_ydy.Name = "rdo2_ydy";
            this.rdo2_ydy.Size = new System.Drawing.Size(67, 18);
            this.rdo2_ydy.TabIndex = 39;
            this.rdo2_ydy.TabStop = true;
            this.rdo2_ydy.Text = "已打印";
            this.rdo2_ydy.UseVisualStyleBackColor = true;
            this.rdo2_ydy.CheckedChanged += new System.EventHandler(this.rdo2_wdy_CheckedChanged);
            // 
            // rdo2_wdy
            // 
            this.rdo2_wdy.AutoSize = true;
            this.rdo2_wdy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo2_wdy.Location = new System.Drawing.Point(8, 10);
            this.rdo2_wdy.Name = "rdo2_wdy";
            this.rdo2_wdy.Size = new System.Drawing.Size(67, 18);
            this.rdo2_wdy.TabIndex = 38;
            this.rdo2_wdy.Text = "未打印";
            this.rdo2_wdy.UseVisualStyleBackColor = true;
            this.rdo2_wdy.CheckedChanged += new System.EventHandler(this.rdo2_wdy_CheckedChanged);
            // 
            // txtzyh_bq
            // 
            this.txtzyh_bq.AcceptsTab = true;
            this.txtzyh_bq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzyh_bq.Location = new System.Drawing.Point(698, 17);
            this.txtzyh_bq.Name = "txtzyh_bq";
            this.txtzyh_bq.Size = new System.Drawing.Size(93, 23);
            this.txtzyh_bq.TabIndex = 35;
            this.txtzyh_bq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtzyh_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(647, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 34;
            this.label8.Text = "住院号";
            // 
            // dtp3
            // 
            this.dtp3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp3.Location = new System.Drawing.Point(148, 17);
            this.dtp3.Name = "dtp3";
            this.dtp3.Size = new System.Drawing.Size(123, 23);
            this.dtp3.TabIndex = 30;
            // 
            // dtp4
            // 
            this.dtp4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp4.Location = new System.Drawing.Point(338, 17);
            this.dtp4.Name = "dtp4";
            this.dtp4.Size = new System.Drawing.Size(117, 23);
            this.dtp4.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(273, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 29;
            this.label6.Text = "结束时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(83, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 28;
            this.label7.Text = "开始时间";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(912, 80);
            this.panel3.TabIndex = 38;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(912, 476);
            this.panel2.TabIndex = 40;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(233, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(679, 476);
            this.panel5.TabIndex = 21;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(230, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 476);
            this.splitter1.TabIndex = 20;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(230, 476);
            this.panel4.TabIndex = 19;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dataGridView2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 55);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(230, 421);
            this.panel7.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView2.ColumnHeadersHeight = 30;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.打印内容,
            this.打印时间,
            this.打印人,
            this.printid});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(230, 421);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
            // 
            // 打印内容
            // 
            this.打印内容.DataPropertyName = "打印内容";
            this.打印内容.HeaderText = "打印内容";
            this.打印内容.Name = "打印内容";
            this.打印内容.ReadOnly = true;
            // 
            // 打印时间
            // 
            this.打印时间.DataPropertyName = "打印时间";
            this.打印时间.HeaderText = "打印时间";
            this.打印时间.Name = "打印时间";
            this.打印时间.ReadOnly = true;
            // 
            // 打印人
            // 
            this.打印人.DataPropertyName = "打印人";
            this.打印人.HeaderText = "打印人";
            this.打印人.Name = "打印人";
            this.打印人.ReadOnly = true;
            // 
            // printid
            // 
            this.printid.DataPropertyName = "printid";
            this.printid.HeaderText = "printid";
            this.printid.Name = "printid";
            this.printid.ReadOnly = true;
            this.printid.Visible = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.butdycx);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.dtpdyrq1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(230, 55);
            this.panel6.TabIndex = 1;
            // 
            // butdycx
            // 
            this.butdycx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butdycx.Location = new System.Drawing.Point(151, 25);
            this.butdycx.Name = "butdycx";
            this.butdycx.Size = new System.Drawing.Size(68, 24);
            this.butdycx.TabIndex = 29;
            this.butdycx.Text = "查询";
            this.butdycx.UseVisualStyleBackColor = true;
            this.butdycx.Click += new System.EventHandler(this.butdycx_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(12, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 28;
            this.label9.Text = "打印时间";
            // 
            // dtpdyrq1
            // 
            this.dtpdyrq1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpdyrq1.Location = new System.Drawing.Point(29, 25);
            this.dtpdyrq1.Name = "dtpdyrq1";
            this.dtpdyrq1.Size = new System.Drawing.Size(119, 23);
            this.dtpdyrq1.TabIndex = 27;
            // 
            // Frmzyqddy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(912, 592);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblCaption);
            this.Name = "Frmzyqddy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检验清单打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Jyqddy_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btLookup;
        private System.Windows.Forms.Button btExit;
        private Label label1;
        private Label label2;
        private DateTimePicker dtp1;
        private DateTimePicker dtp2;
        private TextBox txtzyh_jhlx;
        private Label label4;
        private Label label3;
        private ComboBox cmbhylx;
        private Label label5;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel3;
        private TextBox txtzyh_bq;
        private Label label8;
        private DateTimePicker dtp3;
        private DateTimePicker dtp4;
        private Label label6;
        private Label label7;
        private RadioButton rdo1_ydy;
        private RadioButton rdo1_wdy;
        private RadioButton rdo2_ydy;
        private RadioButton rdo2_wdy;
        private Panel panel2;
        private Button button1;
        private Panel panel5;
        private Splitter splitter1;
        private Panel panel4;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn 打印内容;
        private DataGridViewTextBoxColumn 打印时间;
        private DataGridViewTextBoxColumn 打印人;
        private DataGridViewTextBoxColumn printid;
        private Panel panel7;
        private Panel panel6;
        private Button butdycx;
        private Label label9;
        private DateTimePicker dtpdyrq1;
        private DataGridView dataGridView1;


        public Frmzyqddy(MenuTag menuTag, string chineseName, Form mdiParent)
        {
           
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
        }

        private void ShowData(long printID)//显示数据
        {
            string BDate = "";
            string EDate = "";
            string jylx = "";
            string Inpatient_no = "";
            string ward_id = "";
            int execdeptid = InstanceForm.BCurrentDept.DeptId;
            int dybz = 0;
            int lx = this.tabControl1.SelectedTab == this.tabPage1 ? 0 : 1;
            if (lx == 0)
            {
                 BDate = this.dtp1.Value.ToShortDateString()+" 00:00:00";
                 EDate = this.dtp2.Value.ToShortDateString() + " 23:59:59";
                 jylx = cmbhylx.Text.Trim();
                 Inpatient_no = txtzyh_jhlx.Text.Trim();
                 dybz = rdo1_ydy.Checked == true ? 1 : 0;
            }
            if (lx == 1)
            {
                BDate = this.dtp3.Value.ToShortDateString() + " 00:00:00";
                EDate = this.dtp4.Value.ToShortDateString() + " 23:59:59";
                ward_id = Convertor.IsNull(cmbDept.SelectedValue, "") == "0" ? "" : Convertor.IsNull(cmbDept.SelectedValue, "");
                Inpatient_no = txtzyh_bq.Text.Trim();
                dybz = rdo2_ydy.Checked == true ? 1 : 0;
            }

            ParameterEx[] _parameters = new ParameterEx[9];
            _parameters[0].Text = "lx";
            _parameters[0].Value = lx;
            _parameters[1].Text = "inpatient_no";
            _parameters[1].Value = Inpatient_no;
            _parameters[2].Text = "jylx";
            _parameters[2].Value = jylx;
            _parameters[3].Text = "bdate";
            _parameters[3].Value = BDate;
            _parameters[4].Text = "edate";
            _parameters[4].Value = EDate;
            _parameters[5].Text = "ward_id";
            _parameters[5].Value = ward_id;
            _parameters[6].Text = "execdept_id";
            _parameters[6].Value = execdeptid;
            _parameters[7].Text = "printid";
            _parameters[7].Value = printID;
            _parameters[8].Text = "dybz";
            _parameters[8].Value = dybz ;
            //exec SP_YJ_jyqdprint1 1,'','','2008-9-25 00:00:00','2008-9-25 23:59:59','',87,0,0
            DataTable dV = new DataTable();
            try
            {
                dV = FrmMdiMain.Database.GetDataTable("SP_YJ_ZYSQ_JYDDY", _parameters);
            }
            catch (Exception err)
            {
                MessageBox.Show("执行 查询 时出错！\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.dataGridView1.DataSource = dV;
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Width = 75;
            this.dataGridView1.Columns[2].Width = 70;
            this.dataGridView1.Columns[3].Width = 110;
            this.dataGridView1.Columns[4].Width = 60;
            this.dataGridView1.Columns[5].Width = 180;
            this.dataGridView1.Columns[6].Width = 60;
            this.dataGridView1.Columns[7].Width = 110;
            this.dataGridView1.Columns[8].Width = 100;
            this.dataGridView1.Columns[9].Width = 100; 
        }        

        private void btLookup_Click(object sender, EventArgs e)
        {            
           ShowData(0);  
        }

        private void btnPrint_Click(object sender, EventArgs e)//打印
        {
            //String BDate = this.dtp1.Value.Date.ToString();
            //String EDate = this.dtp2.Value.ToShortDateString() + " 23:59:59";
            //DataTable dV = (DataTable)this.dataGridView1.DataSource;
            //string cfgStr = (new SystemCfg(6002)).Config;    //获得医院名称
            //string sql = "";
            //string cd = "";
            //string id = "";
            //if (dV == null)
            //{
            //    MessageBox.Show("没有需要打印的内容！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //FrmReportView rv = null;
            //ParameterEx[] _parameters = new ParameterEx[4];

            //_parameters[0].Text = "hospitalname";
            //_parameters[0].Value = cfgStr + "检验清单";
            //_parameters[1].Text = "BDate";
            //_parameters[1].Value = BDate;
            //_parameters[2].Text = "EDate";
            //_parameters[2].Value = EDate;

            ////if (checkBox3.Checked == false)
            ////{
            //_parameters[3].Text = "cd";
            //_parameters[3].Value = "";
            //for (int i = 0; i <= this.dataGridView1.Rows.Count - 1; i++)
            //{
            //    string name = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
            //    id += name + ",";
            //}
            //if (true)
            //{
            //    id = Convert.ToString(id.Remove(id.Length - 1));
            //}

            //int dybz = 0;
            //if (this.tabControl1.SelectedTab == this.tabPage1) dybz = rdo1_ydy.Checked == true ? 1 : 0;
            //if (this.tabControl1.SelectedTab == this.tabPage2) dybz = rdo2_ydy.Checked == true ? 1 : 0;
            //if (dybz == 0)
            //{
            //    try
            //    {
            //        InstanceForm.BDatabase.BeginTransaction();
            //        string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
            //        int lx = this.tabControl1.SelectedTab == this.tabPage1 ? 0 : 1;
            //        string dylr = this.tabControl1.SelectedTab == this.tabPage1 ? cmbhylx.Text.Trim() : cmbDept.Text.Trim();
            //        sql = "insert into yj_dyjl(dylx,dylr,djsj,djy)values(" + lx + ",'" + dylr + "','" + _sDate + "'," + InstanceForm.BCurrentUser.EmployeeId + ")";
            //        InstanceForm.BDatabase.DoCommand(sql);
            //        sql = "select @@IDENTITY";
            //        long _printid = Convert.ToInt64(InstanceForm.BDatabase.GetDataResult(sql));

            //        if (lx == 0)
            //            sql = "update yj_zysq set dyid=" + _printid + " where id in (" + id + ")";
            //        else
            //            sql = "update yj_zysq set dyid1=" + _printid + " where id in (" + id + ")";
            //        int iii = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql, 30);
            //        InstanceForm.BDatabase.CommitTransaction();


            //    }
            //    catch (System.Exception err)
            //    {
            //        InstanceForm.BDatabase.RollbackTransaction();
            //        MessageBox.Show(err.Message, "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}
            ////}
            //if ((this.tabControl1.SelectedTab == this.tabPage1 && rdo1_ydy.Checked == true) || (this.tabControl1.SelectedTab == this.tabPage2 && rdo2_ydy.Checked == true))
            //{
            //    _parameters[3].Text = "cd";
            //    _parameters[3].Value = "重打";
            //}

            //try
            //{
            //    rv = new FrmReportView(dV, Constant.ApplicationDirectory + "\\report\\YJ_检验清单.rpt", _parameters, false);
            //}
            //catch
            //{
            //    MessageBox.Show("条件输入错误，无法打印", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

            //if (rv.LoadReportSuccess)
            //{
            //    rv.ShowDialog();
            //}
            //else
            //{
            //    rv.Dispose();
            //}

            //DataTable tb = (DataTable)this.dataGridView1.DataSource;
            //if (tb == null) return;
            //tb.Rows.Clear();


            try
            {

                DataTable tbmx = (DataTable)dataGridView1.DataSource;

                if (tbmx.Rows.Count == 0) return;
                #region  打印状态
                string id = "";
                string sql = "";
                for (int i = 0; i <= this.dataGridView1.Rows.Count - 1; i++)
                {
                    string name = "'"+this.dataGridView1.Rows[i].Cells[0].Value.ToString()+"'";
                    id += name + ",";
                }
                if (true)
                {
                    id = Convert.ToString(id.Remove(id.Length - 1));
                }

                int dybz = 0;
                if (this.tabControl1.SelectedTab == this.tabPage1) dybz = rdo1_ydy.Checked == true ? 1 : 0;
                if (this.tabControl1.SelectedTab == this.tabPage2) dybz = rdo2_ydy.Checked == true ? 1 : 0;
                if (dybz == 0)
                {
                    try
                    {
                        InstanceForm.BDatabase.BeginTransaction();
                        string _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                        int lx = this.tabControl1.SelectedTab == this.tabPage1 ? 0 : 1;
                        string dylr = this.tabControl1.SelectedTab == this.tabPage1 ? cmbhylx.Text.Trim() : cmbDept.Text.Trim();
                        sql = "insert into yj_dyjl(dylx,dylr,djsj,djy)values(" + lx + ",'" + dylr + "','" + _sDate + "'," + InstanceForm.BCurrentUser.EmployeeId + ")";
                        InstanceForm.BDatabase.DoCommand(sql);
                        sql = "select @@IDENTITY";
                        long _printid = Convert.ToInt64(InstanceForm.BDatabase.GetDataResult(sql));

                        if (lx == 0)
                            sql = "update yj_zysq set dyid=" + _printid + " where yjsqid in (" + id + ")";
                        else
                            sql = "update yj_zysq set dyid1=" + _printid + " where yjsqid in (" + id + ")";
                        int iii = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql, 30);
                        InstanceForm.BDatabase.CommitTransaction();
						 
                    }
                    catch (System.Exception err)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();
                        MessageBox.Show(err.Message, "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                #endregion


                DataSet1 Dset = new DataSet1();
                int x = 0;
                DataRow myrow = Dset.项目.NewRow();
                for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                {
                    if (dataGridView1.Columns[i].Visible == true)
                    {
                        x = x + 1;
                        string nm = "T" + x.ToString();
                        myrow[nm] = tbmx.Columns[x].ColumnName.Trim();
                    }
                }
                Dset.项目.Rows.Add(myrow);

                
                for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
                {
                    DataRow myrow1 = Dset.项目内容.NewRow();
                    x = 0;
                    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
                    {
                       
                        if (dataGridView1.Columns[i].Visible == true)
                        {
                             x = x + 1;
                            string nm = "JE" + x.ToString();
                            myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[x].ColumnName].ToString();
                        }
                    }
                    Dset.项目内容.Rows.Add(myrow1);
                }


                ParameterEx[] _parameters = new ParameterEx[4];

                _parameters[0].Text = "医院名称";
                _parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;
                _parameters[1].Text = "rq1";
                _parameters[1].Value = this.dtp1.Value.Date.ToString();
                _parameters[2].Text = "rq2";
                _parameters[2].Value = this.dtp2.Value.Date.ToString();
                _parameters[3].Text = "cd";
                _parameters[3].Value = "";
                if ((this.tabControl1.SelectedTab == this.tabPage1 && rdo1_ydy.Checked == true) || (this.tabControl1.SelectedTab == this.tabPage2 && rdo2_ydy.Checked == true))
                {
                    _parameters[3].Value = "重打";
                }

                TrasenFrame.Forms.FrmReportView f;

                f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\YJ_检验清单.rpt", _parameters);

                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();


                DataTable tb = (DataTable)this.dataGridView1.DataSource;
                if (tb == null) return;
                tb.Rows.Clear();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ReadOnly = true;            
        }


        private void Jyqddy_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.rdo1_wdy.Checked = true;
            this.rdo2_wdy.Checked = true;
            LoadDept();
            LoadJCCLASSDICTION();
        }


        private void txtzyh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                ShowData(0);
            }
        }

        private void LoadDept()
        {
            string sSql = "";
            DataTable myTb = new DataTable();

            sSql = "select '0' ward_id,'全部' ward_name union all select ward_id,ward_name from jc_ward order by ward_id";
            myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            cmbDept.DataSource = myTb;
            cmbDept.DisplayMember = "WARD_NAME";
            cmbDept.ValueMember = "WARD_ID";
            cmbDept.SelectedIndex = 0;
        }
        private void LoadJCCLASSDICTION()
        {
            string sSql = "";
            DataTable myTb = new DataTable();

            sSql = "select '0' id,' ' name union all select id,name from JC_JCCLASSDICTION where class_type=1";
            myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            cmbhylx.DataSource = myTb;
            cmbhylx.DisplayMember = "name";
            cmbhylx.ValueMember = "id";
            cmbhylx.SelectedIndex = 0;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.dataGridView2.DataSource;
            if (tb != null)
                tb.Rows.Clear();

            DataTable tb1 = (DataTable)this.dataGridView1.DataSource;
            if (tb1!= null) 
                tb1.Rows.Clear();

            if (this.tabControl1.SelectedTab == this.tabPage1)
            {
                if (rdo1_wdy.Checked == true)
                    panel4.Visible = false;
                else
                    panel4.Visible = true;
            }
            if (this.tabControl1.SelectedTab == this.tabPage2)
            {
                if (rdo2_wdy.Checked == true)
                    panel4.Visible = false;
                else
                    panel4.Visible = true;
            }
        }

        private void rdo1_wdy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo1_wdy.Checked==true)
                panel4.Visible = false;
            else
                panel4.Visible = true;
  
            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (tb == null) return;
            tb.Rows.Clear();
        }

        private void rdo2_wdy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo2_wdy.Checked == true)
                panel4.Visible = false;
            else
                panel4.Visible = true;

            DataTable tb = (DataTable)this.dataGridView1.DataSource;
            if (tb == null) return;
            tb.Rows.Clear();
        }

        private void butdycx_Click(object sender, EventArgs e)
        {
            int lx = this.tabControl1.SelectedTab == this.tabPage1 ? 0 : 1;
            string bdate = dtpdyrq1.Value.ToShortDateString() + " 00:00:00";
            string edate = dtpdyrq1.Value.ToShortDateString() + " 23:59:59";
            string ssql = "select dylr 打印内容,djsj 打印时间,dbo.fun_getempname(djy) 打印人,id dyid from yj_dyjl where dylx="+lx+" and djsj>='"+bdate+"' and djsj<='"+edate+"'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            this.dataGridView2.DataSource = tb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData(0);
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell == null) return;
            DataTable tb = (DataTable)this.dataGridView2.DataSource;
            if (tb == null) return;
            int nrow = dataGridView2.CurrentCell.RowIndex;
            long _printid = Convert.ToInt64(tb.Rows[nrow]["dyid"]);
            ShowData(_printid);
        }
        
    }
   
}

