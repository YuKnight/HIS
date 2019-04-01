using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_hspb
{
    /// <summary>
    /// Form2 的摘要说明。
    /// </summary>
    public class frmHSPB : System.Windows.Forms.Form
    {
        //自定义变量
        private BaseFunc myFunc;
        private bool isAll = false;

        private System.DateTime Data1, Data7; //星期一 星期日
        private string ColName1 = "", ColName2 = "", ColName3 = "", ColName4 = "", ColName5 = "", ColName6 = "", ColName7 = "";
        private int row_count = 0;
        private string CurrentChar = "";
        private DataTable bcTb = new DataTable();

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker DtpbeginDate;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button bt保存;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button bt查询;
        private System.Windows.Forms.Button bt修改;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt新增;
        private System.Windows.Forms.Button bt打印;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbI3;
        private System.Windows.Forms.RadioButton rbI2;
        private System.Windows.Forms.RadioButton rbI1;
        private System.Windows.Forms.Panel panel4;
        private DataGridEx GrdSel;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.GroupBox groupBox2;
        private RichTextBoxEx rtbCon;
        private ComboBox cmbWard;
        private System.ComponentModel.IContainer components;

        public frmHSPB(string _formText)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;

            myFunc = new BaseFunc();
        }

        public frmHSPB(string _formText, bool _isAll)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.Text = _formText;

            myFunc = new BaseFunc();

            isAll = _isAll;
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.GrdSel = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbWard = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbI3 = new System.Windows.Forms.RadioButton();
            this.rbI2 = new System.Windows.Forms.RadioButton();
            this.rbI1 = new System.Windows.Forms.RadioButton();
            this.bt新增 = new System.Windows.Forms.Button();
            this.bt修改 = new System.Windows.Forms.Button();
            this.bt查询 = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.bt打印 = new System.Windows.Forms.Button();
            this.bt保存 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbCon = new TrasenClasses.GeneralControls.RichTextBoxEx(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdSel)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 413);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myDataGrid1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(984, 357);
            this.panel3.TabIndex = 2;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "护士排班";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(984, 357);
            this.myDataGrid1.TabIndex = 25;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.GrdSel);
            this.panel4.Location = new System.Drawing.Point(936, 56);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(64, 184);
            this.panel4.TabIndex = 4;
            this.panel4.Visible = false;
            // 
            // GrdSel
            // 
            this.GrdSel.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GrdSel.CaptionVisible = false;
            this.GrdSel.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.GrdSel.DataMember = "";
            this.GrdSel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdSel.Enabled = false;
            this.GrdSel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdSel.Location = new System.Drawing.Point(0, 0);
            this.GrdSel.Name = "GrdSel";
            this.GrdSel.ReadOnly = true;
            this.GrdSel.RowHeadersVisible = false;
            this.GrdSel.Size = new System.Drawing.Size(64, 184);
            this.GrdSel.TabIndex = 18;
            this.GrdSel.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.GrdSel.CurrentCellChanged += new System.EventHandler(this.GrdSel_CurrentCellChanged);
            this.GrdSel.myKeyDown += new TrasenClasses.GeneralControls.myDelegate(this.GrdSel_myKeyDown);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.GrdSel;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbWard);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.bt新增);
            this.panel2.Controls.Add(this.bt修改);
            this.panel2.Controls.Add(this.bt查询);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Controls.Add(this.bt打印);
            this.panel2.Controls.Add(this.bt保存);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 56);
            this.panel2.TabIndex = 0;
            // 
            // cmbWard
            // 
            this.cmbWard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWard.FormattingEnabled = true;
            this.cmbWard.Location = new System.Drawing.Point(187, 18);
            this.cmbWard.Name = "cmbWard";
            this.cmbWard.Size = new System.Drawing.Size(133, 20);
            this.cmbWard.TabIndex = 61;
            this.cmbWard.SelectedIndexChanged += new System.EventHandler(this.cmbWard_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbI3);
            this.groupBox1.Controls.Add(this.rbI2);
            this.groupBox1.Controls.Add(this.rbI1);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 48);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // rbI3
            // 
            this.rbI3.Checked = true;
            this.rbI3.Location = new System.Drawing.Point(16, 12);
            this.rbI3.Name = "rbI3";
            this.rbI3.Size = new System.Drawing.Size(56, 32);
            this.rbI3.TabIndex = 59;
            this.rbI3.TabStop = true;
            this.rbI3.Text = "数字(&F&1&2)";
            this.rbI3.CheckedChanged += new System.EventHandler(this.rbI1_Click);
            // 
            // rbI2
            // 
            this.rbI2.Location = new System.Drawing.Point(144, 12);
            this.rbI2.Name = "rbI2";
            this.rbI2.Size = new System.Drawing.Size(56, 32);
            this.rbI2.TabIndex = 58;
            this.rbI2.Text = "五笔(&F&1&1)";
            this.rbI2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rbI2.Click += new System.EventHandler(this.rbI1_Click);
            // 
            // rbI1
            // 
            this.rbI1.Location = new System.Drawing.Point(80, 12);
            this.rbI1.Name = "rbI1";
            this.rbI1.Size = new System.Drawing.Size(56, 32);
            this.rbI1.TabIndex = 57;
            this.rbI1.Text = "拼音(&F&1&0)";
            this.rbI1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rbI1.Click += new System.EventHandler(this.rbI1_Click);
            // 
            // bt新增
            // 
            this.bt新增.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt新增.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt新增.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt新增.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt新增.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt新增.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt新增.ImageIndex = 0;
            this.bt新增.Location = new System.Drawing.Point(674, 16);
            this.bt新增.Name = "bt新增";
            this.bt新增.Size = new System.Drawing.Size(88, 24);
            this.bt新增.TabIndex = 59;
            this.bt新增.Text = "新增护士(&I)";
            this.bt新增.UseVisualStyleBackColor = false;
            this.bt新增.Click += new System.EventHandler(this.bt新增_Click);
            // 
            // bt修改
            // 
            this.bt修改.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt修改.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt修改.Enabled = false;
            this.bt修改.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt修改.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt修改.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt修改.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt修改.ImageIndex = 0;
            this.bt修改.Location = new System.Drawing.Point(604, 16);
            this.bt修改.Name = "bt修改";
            this.bt修改.Size = new System.Drawing.Size(64, 24);
            this.bt修改.TabIndex = 58;
            this.bt修改.Text = "修改(&X)";
            this.bt修改.UseVisualStyleBackColor = false;
            this.bt修改.Click += new System.EventHandler(this.bt修改_Click);
            // 
            // bt查询
            // 
            this.bt查询.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt查询.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt查询.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt查询.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt查询.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt查询.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt查询.ImageIndex = 0;
            this.bt查询.Location = new System.Drawing.Point(534, 16);
            this.bt查询.Name = "bt查询";
            this.bt查询.Size = new System.Drawing.Size(64, 24);
            this.bt查询.TabIndex = 57;
            this.bt查询.Text = "查询(&C)";
            this.bt查询.UseVisualStyleBackColor = false;
            this.bt查询.Click += new System.EventHandler(this.bt查询_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(908, 16);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 24);
            this.btCancel.TabIndex = 55;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // bt打印
            // 
            this.bt打印.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt打印.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt打印.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt打印.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt打印.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt打印.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt打印.ImageIndex = 0;
            this.bt打印.Location = new System.Drawing.Point(838, 16);
            this.bt打印.Name = "bt打印";
            this.bt打印.Size = new System.Drawing.Size(64, 24);
            this.bt打印.TabIndex = 54;
            this.bt打印.Text = "打印(&P)";
            this.bt打印.UseVisualStyleBackColor = false;
            this.bt打印.Click += new System.EventHandler(this.bt打印_Click);
            // 
            // bt保存
            // 
            this.bt保存.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt保存.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt保存.Enabled = false;
            this.bt保存.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt保存.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt保存.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt保存.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt保存.ImageIndex = 0;
            this.bt保存.Location = new System.Drawing.Point(768, 16);
            this.bt保存.Name = "bt保存";
            this.bt保存.Size = new System.Drawing.Size(64, 24);
            this.bt保存.TabIndex = 53;
            this.bt保存.Text = "保存(&S)";
            this.bt保存.UseVisualStyleBackColor = false;
            this.bt保存.Click += new System.EventHandler(this.bt保存_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(527, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(452, 40);
            this.button3.TabIndex = 56;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.DtpbeginDate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(326, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 48);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd";
            this.DtpbeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpbeginDate.Location = new System.Drawing.Point(83, 16);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.Size = new System.Drawing.Size(104, 23);
            this.DtpbeginDate.TabIndex = 0;
            this.DtpbeginDate.Value = new System.DateTime(2003, 9, 20, 19, 22, 0, 0);
            this.DtpbeginDate.ValueChanged += new System.EventHandler(this.DtpbeginDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "请选择日期：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.groupBox2);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 413);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(984, 160);
            this.panelBottom.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbCon);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(984, 160);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "公告";
            // 
            // rtbCon
            // 
            this.rtbCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbCon.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbCon.LinkStyle = false;
            this.rtbCon.Location = new System.Drawing.Point(3, 17);
            this.rtbCon.Name = "rtbCon";
            this.rtbCon.Size = new System.Drawing.Size(978, 140);
            this.rtbCon.TabIndex = 0;
            this.rtbCon.Text = "";
            // 
            // frmHSPB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(984, 573);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBottom);
            this.Name = "frmHSPB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "护士排班";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHSPB_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdSel)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmHSPB_Load(object sender, System.EventArgs e)
        {
            //当前日期是服务器当前系统日期
            this.DtpbeginDate.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            //最大值是今天+7天
            this.DtpbeginDate.MaxDate = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(14).ToShortDateString() + " 23:59:59");
            //最小日期是2002年8月1日
            //this.DtpbeginDate.MinDate=Convert.ToDateTime("2002-8-1 00:00:00");  
            this.DtpbeginDate.Focus();

            string sSql = "select ltrim(rtrim(name)) as name from jc_arrange where kind=1 order by code";
            bcTb = InstanceForm.BDatabase.GetDataTable(sSql);

            string sql = "";
            //读取病区列表
            if (isAll)
            {
                sql = " select * from jc_ward where jgbm=" + FrmMdiMain.Jgbm + " order by ward_id ";
            }
            else
            {
                sql = " select * from jc_ward where jgbm=" + FrmMdiMain.Jgbm + " and ward_id='" + InstanceForm.BCurrentDept.WardId + "' order by ward_id ";
            }
            DataTable tb = FrmMdiMain.Database.GetDataTable(sql);

            cmbWard.ValueMember = "ward_id";
            cmbWard.DisplayMember = "ward_name";
            cmbWard.DataSource = tb;

            cmbWard.SelectedIndex = 0;

            this.ShowSelCard();
        }


        //根据输入的日期找出该星期的第一天和第七天
        private void GetData1()
        {
            System.DateTime Data0 = Convert.ToDateTime(this.DtpbeginDate.Value.ToShortDateString() + " 00:00:00");
            int daynum = 0;
            switch (Data0.DayOfWeek.ToString())
            {
                case "Monday":
                    daynum = 1;
                    break;
                case "Tuesday":
                    daynum = 2;
                    break;
                case "Wednesday":
                    daynum = 3;
                    break;
                case "Thursday":
                    daynum = 4;
                    break;
                case "Friday":
                    daynum = 5;
                    break;
                case "Saturday":
                    daynum = 6;
                    break;
                case "Sunday":
                    daynum = 7;
                    break;
            }
            System.TimeSpan diff = new System.TimeSpan(daynum - 1, 0, 0, 0);
            this.Data1 = Data0.Subtract(diff);
            this.Data7 = Data1.AddDays(6);
            this.DtpbeginDate.Value = this.Data1;
            this.ColName1 = "(" + this.Data1.Month.ToString() + "." + this.Data1.Day.ToString() + ")";
            this.ColName2 = "(" + this.Data1.AddDays(1).Month.ToString() + "." + this.Data1.AddDays(1).Day.ToString() + ")";
            this.ColName3 = "(" + this.Data1.AddDays(2).Month.ToString() + "." + this.Data1.AddDays(2).Day.ToString() + ")";
            this.ColName4 = "(" + this.Data1.AddDays(3).Month.ToString() + "." + this.Data1.AddDays(3).Day.ToString() + ")";
            this.ColName5 = "(" + this.Data1.AddDays(4).Month.ToString() + "." + this.Data1.AddDays(4).Day.ToString() + ")";
            this.ColName6 = "(" + this.Data1.AddDays(5).Month.ToString() + "." + this.Data1.AddDays(5).Day.ToString() + ")";
            this.ColName7 = "(" + this.Data1.AddDays(6).Month.ToString() + "." + this.Data1.AddDays(6).Day.ToString() + ")";
        }

        private void Show_Date(bool isRead)
        {
            string sSql = "select	dbo.FUN_ZY_SEEKEMPLOYEENAME(employee_id) 姓名," +
                "				case group_id when 0 then '甲组' when 1 then '乙组' " +
                "				when 2 then '总务' when 3 then '护士长' when 4 then '产房' " +
                "               when 5 then '甲组组长' when 6 then '乙组组长'end 组号," +
                "               NAME1,NAME2,NAME3,NAME4,NAME5,NAME6,NAME7,ID" +
                "  from zy_arrange a" +
                " where kind=1 and ward_id='" + cmbWard.SelectedValue + "'" +
                "       and arrange_date='" + this.Data1.ToString() + "'" +
                " order by group_id,employee_id";
            myFunc.ShowGrid(0, sSql, this.myDataGrid1);
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            this.row_count = myTb.Rows.Count;

            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName ={ "姓名", "组号", "NAME1", "NAME2", "NAME3", "NAME4", "NAME5", "NAME6", "NAME7", "ID" };
            int[] GrdWidth ={ 10, 10, 12, 12, 12, 12, 12, 12, 12, 0 };
            int[] Alignment ={ 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };

            //			if (isRead)
            //			{
            //只读
            int[] ReadOnly0 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName, GrdWidth, Alignment, ReadOnly0, this.myDataGrid1);
            this.myDataGrid1.ReadOnly = true;
            //			}
            //			else
            //			{
            //				//可写
            //				int[] ReadOnly1    ={1, 1, 1, 1, 1, 1, 1, 1, 1,0};
            //				myFunc.InitGrid(GrdMappingName,GrdWidth,Alignment,ReadOnly1,this.myDataGrid1);
            //				this.myDataGrid1.ReadOnly=false;
            //			}

            this.myDataGrid1.TableStyles[0].GridColumnStyles[2].HeaderText = "星期一" + this.ColName1;
            this.myDataGrid1.TableStyles[0].GridColumnStyles[3].HeaderText = "星期二" + this.ColName2;
            this.myDataGrid1.TableStyles[0].GridColumnStyles[4].HeaderText = "星期三" + this.ColName3;
            this.myDataGrid1.TableStyles[0].GridColumnStyles[5].HeaderText = "星期四" + this.ColName4;
            this.myDataGrid1.TableStyles[0].GridColumnStyles[6].HeaderText = "星期五" + this.ColName5;
            this.myDataGrid1.TableStyles[0].GridColumnStyles[7].HeaderText = "星期六" + this.ColName6;
            this.myDataGrid1.TableStyles[0].GridColumnStyles[8].HeaderText = "星期日" + this.ColName7;

            //读公告 Add By Tany 2005-06-23
            sSql = "select contents from zy_arrange_con" +
                " where ward_id='" + cmbWard.SelectedValue + "'" +
                "       and con_date='" + this.Data1.Date + "'";
            rtbCon.Text = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql), "");
        }


        private void DtpbeginDate_ValueChanged(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;
            myTb.Rows.Clear();
        }


        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if (this.bt保存.Enabled == false)
            {
                //查询状态选择一行
                myFunc.SelRow(this.myDataGrid1);
            }
            else
            {
                //Add By Tany 2005-06-23
                int nrow = this.myDataGrid1.CurrentCell.RowNumber;
                int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
                DataGridTextBoxColumn dgtb = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                dgtb.TextBox.Controls.Clear();//清除编辑框中的控件

                string ColumnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();
                if (ColumnName == "组号") this.addGroupCmb();
                else if (ColumnName.Length > 4 && ColumnName.Substring(0, 4) == "NAME") this.addBCCmb();
            }
        }

        private bool myDataGrid1_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (this.row_count == 0) return true;

            long keyInt = Convert.ToInt32(keyData);
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            string ColumnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();


            //新增加的行屏蔽输入字母和数字
            if (nrow >= this.row_count
                && ((keyInt >= 65 && keyInt <= 111) || (keyInt >= 48 && keyInt <= 90)))
                return true;

            //列只读,输入字母和数字送tab键,屏蔽输入
            if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].ReadOnly == true
                && ((keyInt >= 65 && keyInt <= 111) || (keyInt >= 48 && keyInt <= 90)))
            {
                SendKeys.Send("{tab}");
                return true;
            }

            #region 组号的输入 已经屏蔽,改用下拉框形式 Modify By Tany 2005-06-23
            /*
			if(ColumnName=="组号")			 
			{
				//可输入字符和退格健
				if ( (keyInt>=65 && keyInt<=111 ) || (keyInt>=48 && keyInt<=90) || keyInt==8 ) 
				{
					if(keyInt==49 || keyInt==50)   //只允许输入 1、2
					{
						myTb.Rows[nrow][ColumnName]=keyInt==49?"甲组":"乙组";
						this.myDataGrid1.DataSource=myTb;
						SendKeys.Send("{tab}");											
					}
					//屏蔽输入
					return true;					
				}
				this.GrdSel.Enabled=false;
			}
			*/
            #endregion

            #region 排班输入
            if (ColumnName.Length > 4 && ColumnName.Substring(0, 4) == "NAME")
            {
                if ((keyInt >= 65 && keyInt <= 111) || (keyInt >= 48 && keyInt <= 90))
                {
                    if (keyInt > 90) keyInt -= 48;
                    DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                    this.CurrentChar = txtCol.TextBox.Text.Trim();
                    if (this.CurrentChar != "")
                    {
                        this.CurrentChar = (txtCol.TextBox.SelectionLength == txtCol.TextBox.TextLength ? "" : this.CurrentChar);
                    }
                    this.CurrentChar += Convert.ToChar(keyInt);
                    this.ShowSelCard();
                    //不屏蔽输入
                    return false;
                }

                #region 当this.GrdSel.Enabled
                if (this.GrdSel.Enabled)
                {
                    #region 退格键
                    if (keyInt == 8)
                    {
                        //得到输入的数据
                        DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                        string SelData = txtCol.TextBox.Text.Trim();
                        if (SelData != "")
                        {
                            if (txtCol.TextBox.SelectionLength == txtCol.TextBox.TextLength)
                            {
                                this.CurrentChar = "";
                            }
                            else
                            {
                                this.CurrentChar = SelData.Substring(0, SelData.Length - 1);
                            }
                            //显示查到的数据
                            this.CurrentChar = SelData;
                            this.ShowSelCard();
                        }
                        else this.GrdSel.Enabled = false;
                        //不屏蔽输入
                        return false;
                    }
                    #endregion

                    #region 上下键
                    if (keyInt == 40 || keyInt == 38)
                    {
                        if (this.GrdSel.VisibleRowCount > 0)
                        {
                            this.GrdSel.Select(this.GrdSel.CurrentCell.RowNumber);
                        }
                        this.GrdSel.Focus();
                        //屏蔽输入
                        return true;
                    }
                    #endregion

                    #region 回车键
                    if (keyInt == 13)
                    {
                        GetCardData(this.GrdSel.CurrentCell.RowNumber);
                        SendKeys.Send("{tab}");
                        //屏蔽输入
                        return true;
                    }
                    #endregion

                }
                #endregion
            }
            else this.GrdSel.Enabled = false;
            #endregion

            #region F10,F11,F12键切换输入方法
            if ((keyInt == 121 && this.rbI1.Checked == false) || (keyInt == 122 && this.rbI2.Checked == false) || (keyInt == 123 && this.rbI3.Checked == false))
            {
                this.CurrentChar = "";
                if (keyInt == 121) this.rbI1.Checked = true;
                if (keyInt == 122) this.rbI2.Checked = true;
                if (keyInt == 123) this.rbI3.Checked = true;

                this.myDataGrid1.Focus();
                DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[this.myDataGrid1.CurrentCell.ColumnNumber];
                if (txtCol.TextBox.Text != "" && this.GrdSel.Enabled)
                {
                    SendKeys.Send("{tab}");
                    SendKeys.Send("{left}");  //选中已经输入的数据
                }
                return true;
            }
            #endregion

            #region  回车键
            if (keyInt == 13)
            {
                SendKeys.Send("{tab}");
                if (ColumnName == "NAME7")
                {
                    if (nrow <= this.row_count - 1)
                    {
                        SendKeys.Send("{tab}");
                    }
                    else
                    {
                        SendKeys.Send("{up}");
                    }
                }
                return true;
            }
            #endregion

            #region TAB键
            if (keyInt == 9)
            {
                if (ColumnName == "NAME7")
                {
                    SendKeys.Send("{tab}");
                    SendKeys.Send("{tab}");
                    return false;
                }
                else
                {
                    return false;
                }
            }
            #endregion

            return false;
        }


        private void rbI1_Click(object sender, System.EventArgs e)
        {
            bool isEnabled = this.GrdSel.Enabled;
            this.CurrentChar = "";
            this.ShowSelCard();
            this.GrdSel.Enabled = isEnabled;
        }

        private void ShowSelCard()
        {
            this.GrdSel.Enabled = true;

            string[] GrdMappingName ={ "", "", "", "", "" };
            int[] GrdWidth ={ 6, 8, 6, 6, 0 };
            int[] Alignment ={ 0, 0, 0, 0, 0 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0 };
            string sSql = "";

            if (this.rbI1.Checked)
            {
                sSql = "select py_code 拼音码, rtrim(name) as 名称, wb_code 五笔码,code 数字码,id " +
                    "   from jc_arrange where kind=1 order by py_code";
                string[] GrdMappingName_tmp ={ "拼音码", "名称", "五笔码", "数字码", "id" };
                GrdMappingName_tmp.CopyTo(GrdMappingName, 0);
            }
            else if (this.rbI2.Checked)
            {
                sSql = "select  wb_code 五笔码, rtrim(name) as 名称, py_code 拼音码,code 数字码,id " +
                    "   from jc_arrange where kind=1 order by wb_code";
                string[] GrdMappingName_tmp ={ "五笔码", "名称", "拼音码", "数字码", "id" };
                GrdMappingName_tmp.CopyTo(GrdMappingName, 0);
            }
            else
            {
                sSql = "select  code 数字码, rtrim(name) as 名称, py_code 拼音码,wb_code 五笔码,id " +
                    "   from jc_arrange where kind=1 order by code";
                string[] GrdMappingName_tmp ={ "数字码", "名称", "拼音码", "五笔码", "id" };
                GrdMappingName_tmp.CopyTo(GrdMappingName, 0);
            }

            this.GrdSel.TableStyles[0].GridColumnStyles.Clear();
            myFunc.ShowGrid(0, sSql, this.GrdSel);
            this.myFunc.InitGrid(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.GrdSel);

            //选择最接近的记录			
            DataTable myTempTb = (DataTable)this.GrdSel.DataSource;
            int j = CurrentChar.Length;
            while (j > 0)
            {
                string sCode = this.CurrentChar.Substring(0, j);
                for (int i = 0; i <= myTempTb.Rows.Count - 1; i++)
                {
                    if (Convert.ToString(this.GrdSel[i, 0]).Trim().Length < j) continue;
                    if (Convert.ToString(this.GrdSel[i, 0]).Trim().Substring(0, j).ToLower() == sCode.ToLower())
                    {
                        this.GrdSel.CurrentRowIndex = i;
                        j = 1;
                        break;
                    }
                }
                j--;
            }
        }

        private bool GrdSel_myKeyDown(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            //变量定义
            long keyInt = Convert.ToInt32(keyData);
            int nrow, ncol;
            string ColumnName = "";

            //变量付初始值
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            ColumnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();

            if (keyInt == 27)   //ESC
            {
                this.GrdSel.Enabled = false;
                this.myDataGrid1.Focus();
            }

            if (ColumnName.Length > 4 && ColumnName.Substring(0, 4) == "NAME")
            {
                if (keyInt == 13)
                {
                    GetCardData(this.GrdSel.CurrentCell.RowNumber);
                    this.myDataGrid1.Select();
                    SendKeys.Send("{Tab}");
                }
                //为英文字母
                if ((keyInt >= 65 && keyInt <= 90) || (keyInt >= 48 && keyInt <= 57) || (keyInt >= 96 && keyInt <= 105))
                {
                    //需要重复的代码
                    this.myDataGrid1.Select();
                    DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                    txtCol.TextBox.SelectionStart = txtCol.TextBox.TextLength;
                    if (keyInt >= 65 && keyInt <= 90) SendKeys.Send(keyData.ToString().ToLower());
                    else if ((keyInt >= 48 && keyInt <= 57))
                        SendKeys.Send(Convert.ToString(keyInt - 48));
                    else
                        SendKeys.Send(Convert.ToString(keyInt - 96));
                }
            }

            if (keyInt == 40 || keyInt == 38) return false;
            return true;
        }

        private void GrdSel_CurrentCellChanged(object sender, System.EventArgs e)
        {
            this.GrdSel.Select(this.GrdSel.CurrentCell.RowNumber);
        }

        private void GetCardData(long keyInt)
        {
            //首先得到当前网格的信息
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            DataTable mySelTbTemp = (DataTable)this.GrdSel.DataSource;
            int nSelRow = (int)keyInt;
            string ColumnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();

            //选择超出范围
            if (nSelRow <= mySelTbTemp.Rows.Count - 1)
            {
                myTb.Rows[nrow][ColumnName] = mySelTbTemp.Rows[nSelRow]["名称"].ToString().Trim();
                DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                txtCol.TextBox.Text = mySelTbTemp.Rows[nSelRow]["名称"].ToString().Trim();
                this.myDataGrid1.DataSource = myTb;
            }
            else
            {
                myTb.Rows[nrow][ColumnName] = "";
                DataGridTextBoxColumn txtCol = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol];
                txtCol.TextBox.Text = "";
                this.myDataGrid1.DataSource = myTb;
            }
            this.GrdSel.Enabled = false;
            this.myDataGrid1.Focus();

        }


        private void bt查询_Click(object sender, System.EventArgs e)
        {
            this.GetData1();
            this.Show_Date(true);
            this.myDataGrid1.CaptionText = "护士排班 - 查询";

            this.bt新增.Enabled = true;
            if (this.row_count > 0)
            {
                this.bt修改.Enabled = true;
                this.bt保存.Enabled = false;
            }
            else
            {
                if (isAll)
                {
                    return;
                }
                if (MessageBox.Show(this, "对不起，没有排班记录，现在增加吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    //没有记录退出
                    this.bt修改.Enabled = false;
                    this.bt保存.Enabled = false;
                    this.bt新增.Enabled = true;
                }
                else
                {
                    //没有记录，增加
                    string sSql = "insert into zy_arrange(KIND,WARD_ID,ARRANGE_DATE,GROUP_ID,EMPLOYEE_ID," +
                        "                               NAME1,NAME2,NAME3,NAME4,NAME5,NAME6,NAME7,BOOK_USER,BOOK_DATE,JGBM)" +
                        "select distinct 1,'" + InstanceForm.BCurrentDept.WardId + "','" + this.Data1 + "',0,c.employee_id,'','','','','','',''," + InstanceForm.BCurrentUser.EmployeeId + ",getdate()," + FrmMdiMain.Jgbm + "" +
                        "  from jc_role_nurse a,(select employee_id emp_id,dept_id d_id from jc_emp_dept_role) b,jc_employee_property c" +
                        " where a.employee_id=b.emp_id and a.employee_id=c.employee_id and b.d_id in ( select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')";
                    InstanceForm.BDatabase.DoCommand(sSql);

                    sSql = "insert into zy_arrange_con(ward_id,con_date,book_user,jgbm) values " +
                        " ('" + InstanceForm.BCurrentDept.WardId + "','" + Data1.Date + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";
                    InstanceForm.BDatabase.DoCommand(sSql);

                    this.bt修改_Click(sender, e);
                }
            }
        }


        private void bt修改_Click(object sender, System.EventArgs e)
        {
            if (isAll)
            {
                return;
            }
            this.myDataGrid1.CaptionText = "护士排班 - 修改";
            this.bt保存.Enabled = true;
            this.bt新增.Enabled = false;

            this.GetData1();
            this.Show_Date(false);

            this.myDataGrid1.Focus();
            //			SendKeys.Send("{tab}");		//光标到"组号"
        }


        private void bt新增_Click(object sender, System.EventArgs e)
        {
            if (isAll)
            {
                return;
            }
            if (this.DtpbeginDate.Value.Date >= this.Data1 && this.DtpbeginDate.Value.Date <= this.Data7)
            {
                string sSql = "select * from jc_role_nurse a,(select employee_id emp_id,dept_id d_id from jc_emp_dept_role where jc_emp_dept_role.[default]=1) b,jc_employee_property c" +
                    " where a.employee_id=b.emp_id and a.employee_id=c.employee_id and b.d_id in ( select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                    "       and a.employee_id not in ( " +
                    "                  Select employee_id from zy_arrange " +
                    "                   where arrange_date= '" + this.Data1.ToString() + " '" +
                    "                         and ward_id='" + InstanceForm.BCurrentDept.WardId + "' and kind=1 )";
                DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                if (tempTab.Rows.Count > 0)
                {
                    sSql = "insert into zy_arrange(KIND,WARD_ID,ARRANGE_DATE,GROUP_ID,EMPLOYEE_ID," +
                        "                       NAME1,NAME2,NAME3,NAME4,NAME5,NAME6,NAME7,BOOK_USER,BOOK_DATE)" +
                        "select distinct 1,'" + InstanceForm.BCurrentDept.WardId + "','" + this.Data1 + "',0,employee_id,'','','','','','',''," + InstanceForm.BCurrentUser.EmployeeId + ",getdate()" +
                        "  from jc_role_nurse a,(select employee_id emp_id,dept_id d_id from jc_emp_dept_role ) b,jc_employee_property c" +//where jc_emp_dept_role.default=1) b"+
                        " where a.employee_id=b.emp_id and a.employee_id=c.employee_id and b.d_id in ( select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')" +
                        "       and employee_id not in ( " +
                        "                  Select employee_id from zy_arrange " +
                        "                   where arrange_date= '" + this.Data1.ToString() + " '" +
                        "                         and ward_id='" + InstanceForm.BCurrentDept.WardId + "' and kind=1 )";
                    InstanceForm.BDatabase.DoCommand(sSql);
                    this.bt修改_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(this, "对不起，没有新增加的护士！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }


        private void bt保存_Click(object sender, System.EventArgs e)
        {
            if (isAll)
            {
                return;
            }
            if (this.row_count == 0) return;
            string sSql = "";
            int j = 0;

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= this.row_count - 1; i++)
            {
                j = GetGroup(myTb.Rows[i]["组号"].ToString().Trim());
                sSql = "update zy_arrange set " +
                    "      group_id=" + j.ToString() + "," +
                    "      name1='" + myTb.Rows[i]["NAME1"].ToString() + "'," +
                    "      name2='" + myTb.Rows[i]["NAME2"].ToString() + "'," +
                    "      name3='" + myTb.Rows[i]["NAME3"].ToString() + "'," +
                    "      name4='" + myTb.Rows[i]["NAME4"].ToString() + "'," +
                    "      name5='" + myTb.Rows[i]["NAME5"].ToString() + "'," +
                    "      name6='" + myTb.Rows[i]["NAME6"].ToString() + "'," +
                    "      name7='" + myTb.Rows[i]["NAME7"].ToString() + "'," +
                    "      BOOK_USER=" + InstanceForm.BCurrentUser.EmployeeId + "," +
                    "      BOOK_DATE=getdate()" +
                    " where id=" + myTb.Rows[i]["ID"].ToString();
                InstanceForm.BDatabase.DoCommand(sSql);
            }

            sSql = "select contents from zy_arrange_con" +
                " where ward_id='" + InstanceForm.BCurrentDept.WardId + "'" +
                "       and con_date='" + Data1.Date + "'";
            DataTable conTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (conTb.Rows.Count > 0)
            {
                sSql = "update zy_arrange_con set contents='" + rtbCon.Text.Trim() + "'" +
                    " where ward_id='" + InstanceForm.BCurrentDept.WardId + "'" +
                    "       and con_date='" + Data1.Date + "'";
            }
            else
            {
                sSql = "insert into zy_arrange_con(ward_id,con_date,contents,book_user) values " +
                    " ('" + InstanceForm.BCurrentDept.WardId + "','" + Data1.Date + "','" + rtbCon.Text.Trim() + "'," + InstanceForm.BCurrentUser.EmployeeId + ")";
            }
            InstanceForm.BDatabase.DoCommand(sSql);

            this.bt查询_Click(sender, e);
        }


        private void bt打印_Click(object sender, System.EventArgs e)
        {
            DataTable myTb1 = (DataTable)this.myDataGrid1.DataSource;
            DataTable myTb = new DataTable();
            myTb = myTb1.Copy();
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            myTb.TableName = "tabpbb";
            DataSet rs = new DataSet();
            rs.Tables.Add(myTb);

            FrmReportView frmRptView = null;
            ParameterEx[] _parameters = new ParameterEx[12];
            string sSql = "select contents from zy_arrange_con" +
                " where ward_id='" + cmbWard.SelectedValue + "'" +
                "       and con_date='" + this.Data1.Date + "'";

            _parameters[0].Text = "表头";
            _parameters[0].Value = (new SystemCfg(0002)).Config + " - 护士排班表";
            _parameters[1].Text = "病区";
            _parameters[1].Value = "病区：" + cmbWard.Text;
            _parameters[2].Text = "日期";
            _parameters[2].Value = "日期： 从" + this.Data1.Year.ToString() + "-" + this.Data1.Month.ToString() + "-" + this.Data1.Day.ToString() + " 至 " + this.Data7.Year.ToString() + "-" + this.Data7.Month.ToString() + "-" + this.Data7.Day.ToString();
            _parameters[3].Text = "D1";
            _parameters[3].Value = this.ColName1;
            _parameters[4].Text = "D2";
            _parameters[4].Value = this.ColName2;
            _parameters[5].Text = "D3";
            _parameters[5].Value = this.ColName3;
            _parameters[6].Text = "D4";
            _parameters[6].Value = this.ColName4;
            _parameters[7].Text = "D5";
            _parameters[7].Value = this.ColName5;
            _parameters[8].Text = "D6";
            _parameters[8].Value = this.ColName6;
            _parameters[9].Text = "D7";
            _parameters[9].Value = this.ColName7;
            _parameters[10].Text = "打印者";
            _parameters[10].Value = "打印者：" + InstanceForm.BCurrentUser.Name;
            _parameters[11].Text = "contents";
            _parameters[11].Value = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql), "");

            frmRptView = new FrmReportView(rs, Constant.ApplicationDirectory + "\\report\\ZYHS_护士排班.rpt", _parameters);
            frmRptView.Show();
        }

        #region 增加组号下拉选择框
        private void addGroupCmb()
        {
            ComboBox cmb = new ComboBox();

            cmb.Items.Clear();

            cmb.Items.Add("甲组");
            cmb.Items.Add("乙组");
            cmb.Items.Add("甲组组长");
            cmb.Items.Add("乙组组长");
            cmb.Items.Add("总务");
            cmb.Items.Add("护士长");
            cmb.Items.Add("产房");

            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.Dock = DockStyle.Fill;
            cmb.Cursor = Cursors.Hand;
            cmb.DropDownWidth = 90;
            cmb.BackColor = Color.LightCyan;
            cmb.SelectionChangeCommitted += new EventHandler(cmbGroup_SelectionChangeCommitted);
            DataGridTextBoxColumn dgtb = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles["组号"];
            dgtb.TextBox.Controls.Clear();//必须先清空
            dgtb.TextBox.Controls.Add(cmb);
        }

        private void cmbGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int nrow = this.GrdSel.CurrentCell.RowNumber;
            int ncol = this.GrdSel.CurrentCell.ColumnNumber;
            this.myDataGrid1[this.myDataGrid1.CurrentCell] = ((ComboBox)sender).Text.ToString().Trim();
        }
        #endregion

        #region 增加班次下拉选择框
        private void addBCCmb()
        {
            ComboBox cmb = new ComboBox();

            cmb.Items.Clear();

            cmb.DisplayMember = "NAME";
            cmb.DataSource = bcTb;

            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.Dock = DockStyle.Fill;
            cmb.Cursor = Cursors.Hand;
            cmb.DropDownWidth = 90;
            cmb.BackColor = Color.LightCyan;
            cmb.SelectionChangeCommitted += new EventHandler(cmbBC_SelectionChangeCommitted);
            DataGridTextBoxColumn dgtb = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles[myDataGrid1.CurrentCell.ColumnNumber];
            dgtb.TextBox.Controls.Clear();//必须先清空
            dgtb.TextBox.Controls.Add(cmb);
        }

        private void cmbBC_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.myDataGrid1[this.myDataGrid1.CurrentCell] = ((ComboBox)sender).Text.ToString().Trim();
        }
        #endregion

        /// <summary>
        /// 得到组号
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        private int GetGroup(string GroupName)
        {
            int a = 0;

            switch (GroupName)
            {
                case "甲组":
                    a = 0;
                    break;
                case "乙组":
                    a = 1;
                    break;
                case "总务":
                    a = 2;
                    break;
                case "护士长":
                    a = 3;
                    break;
                case "产房":
                    a = 4;
                    break;
                case "甲组组长":
                    a = 5;
                    break;
                case "乙组组长":
                    a = 6;
                    break;
            }

            return a;
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void cmbWard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWard.SelectedValue == null)
                return;

            bt查询_Click(null, null);
        }
    }
}
