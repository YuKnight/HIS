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

namespace ts_zyhs_brzk
{
    /// <summary>
    /// Form2 的摘要说明。
    /// </summary>
    public class frmBRZK : System.Windows.Forms.Form
    {
        private BaseFunc myFunc;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter1;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button bt转科;
        private System.Windows.Forms.Button btnWzx;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabZK;
        private System.Windows.Forms.TabPage tabQXZK;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn刷新;
        private System.Windows.Forms.Button btn取消转科;
        private System.Windows.Forms.Button btn退出;
        private DataGridEx GrdQxzk;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        SystemCfg cfg7205 = new SystemCfg(7205);//yaokx2014-06-27
        public frmBRZK(string _formText)
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnWzx = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.bt转科 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.GrdQxzk = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabZK = new System.Windows.Forms.TabPage();
            this.tabQXZK = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn刷新 = new System.Windows.Forms.Button();
            this.btn取消转科 = new System.Windows.Forms.Button();
            this.btn退出 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdQxzk)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabZK.SuspendLayout();
            this.tabQXZK.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 465);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(694, 405);
            this.panel4.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 405);
            this.panel2.TabIndex = 0;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "申请转科清单";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(694, 405);
            this.myDataGrid1.TabIndex = 59;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Tag = "";
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 405);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(694, 4);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnWzx);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Controls.Add(this.bt转科);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 409);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(694, 56);
            this.panel3.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.Location = new System.Drawing.Point(270, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 24);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.ImageIndex = 0;
            this.btnCancel.Location = new System.Drawing.Point(518, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消转科(&Q)";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnWzx
            // 
            this.btnWzx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWzx.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnWzx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWzx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWzx.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnWzx.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnWzx.ImageIndex = 0;
            this.btnWzx.Location = new System.Drawing.Point(342, 16);
            this.btnWzx.Name = "btnWzx";
            this.btnWzx.Size = new System.Drawing.Size(96, 24);
            this.btnWzx.TabIndex = 6;
            this.btnWzx.Text = "未处理项目(&W)";
            this.btnWzx.UseVisualStyleBackColor = false;
            this.btnWzx.Click += new System.EventHandler(this.btnWzx_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancel.ImageIndex = 0;
            this.btCancel.Location = new System.Drawing.Point(614, 16);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 24);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // bt转科
            // 
            this.bt转科.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt转科.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bt转科.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt转科.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt转科.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt转科.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt转科.ImageIndex = 0;
            this.bt转科.Location = new System.Drawing.Point(446, 16);
            this.bt转科.Name = "bt转科";
            this.bt转科.Size = new System.Drawing.Size(64, 24);
            this.bt转科.TabIndex = 4;
            this.bt转科.Text = "转科(&Z)";
            this.bt转科.UseVisualStyleBackColor = false;
            this.bt转科.Click += new System.EventHandler(this.bt转科_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageIndex = 0;
            this.button3.Location = new System.Drawing.Point(262, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(424, 40);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // GrdQxzk
            // 
            this.GrdQxzk.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GrdQxzk.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.GrdQxzk.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrdQxzk.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.GrdQxzk.CaptionText = "取消转科清单";
            this.GrdQxzk.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.GrdQxzk.DataMember = "";
            this.GrdQxzk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdQxzk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GrdQxzk.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.GrdQxzk.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GrdQxzk.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GrdQxzk.Location = new System.Drawing.Point(0, 0);
            this.GrdQxzk.Name = "GrdQxzk";
            this.GrdQxzk.ReadOnly = true;
            this.GrdQxzk.Size = new System.Drawing.Size(694, 409);
            this.GrdQxzk.TabIndex = 60;
            this.GrdQxzk.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.GrdQxzk.Tag = "";
            this.GrdQxzk.CurrentCellChanged += new System.EventHandler(this.GrdQxzk_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.GrdQxzk;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabZK);
            this.tabControl1.Controls.Add(this.tabQXZK);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 491);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabZK
            // 
            this.tabZK.Controls.Add(this.panel1);
            this.tabZK.Location = new System.Drawing.Point(4, 22);
            this.tabZK.Name = "tabZK";
            this.tabZK.Size = new System.Drawing.Size(694, 465);
            this.tabZK.TabIndex = 0;
            this.tabZK.Text = "转科";
            // 
            // tabQXZK
            // 
            this.tabQXZK.Controls.Add(this.panel5);
            this.tabQXZK.Location = new System.Drawing.Point(4, 22);
            this.tabQXZK.Name = "tabQXZK";
            this.tabQXZK.Size = new System.Drawing.Size(694, 465);
            this.tabQXZK.TabIndex = 1;
            this.tabQXZK.Text = "取消转科";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.splitter2);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(694, 465);
            this.panel5.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 405);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(694, 4);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.GrdQxzk);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(694, 409);
            this.panel7.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn刷新);
            this.panel6.Controls.Add(this.btn取消转科);
            this.panel6.Controls.Add(this.btn退出);
            this.panel6.Controls.Add(this.button5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 409);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(694, 56);
            this.panel6.TabIndex = 0;
            // 
            // btn刷新
            // 
            this.btn刷新.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn刷新.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn刷新.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn刷新.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn刷新.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn刷新.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn刷新.ImageIndex = 0;
            this.btn刷新.Location = new System.Drawing.Point(452, 16);
            this.btn刷新.Name = "btn刷新";
            this.btn刷新.Size = new System.Drawing.Size(64, 24);
            this.btn刷新.TabIndex = 12;
            this.btn刷新.Text = "刷新(&R)";
            this.btn刷新.UseVisualStyleBackColor = false;
            this.btn刷新.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btn取消转科
            // 
            this.btn取消转科.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn取消转科.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn取消转科.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn取消转科.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn取消转科.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn取消转科.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn取消转科.ImageIndex = 0;
            this.btn取消转科.Location = new System.Drawing.Point(522, 16);
            this.btn取消转科.Name = "btn取消转科";
            this.btn取消转科.Size = new System.Drawing.Size(88, 24);
            this.btn取消转科.TabIndex = 11;
            this.btn取消转科.Text = "取消转科(&Q)";
            this.btn取消转科.UseVisualStyleBackColor = false;
            this.btn取消转科.Click += new System.EventHandler(this.btn取消转科_Click);
            // 
            // btn退出
            // 
            this.btn退出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn退出.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn退出.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn退出.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn退出.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btn退出.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn退出.ImageIndex = 0;
            this.btn退出.Location = new System.Drawing.Point(616, 16);
            this.btn退出.Name = "btn退出";
            this.btn退出.Size = new System.Drawing.Size(64, 24);
            this.btn退出.TabIndex = 10;
            this.btn退出.Text = "退出(&E)";
            this.btn退出.UseVisualStyleBackColor = false;
            this.btn退出.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button5.Enabled = false;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.ImageIndex = 0;
            this.button5.Location = new System.Drawing.Point(444, 8);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(244, 40);
            this.button5.TabIndex = 9;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // frmBRZK
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(702, 491);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmBRZK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "转科";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBRZK_Load);
            this.Activated += new System.EventHandler(this.frmBRZK_Activated);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdQxzk)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabZK.ResumeLayout(false);
            this.tabQXZK.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmZK_Load(object sender, System.EventArgs e)
        {
            string sSql = "";
            DataTable myTb = new DataTable();

            Cursor.Current = PubStaticFun.WaitCursor();

            if (tabControl1.SelectedTab == tabZK)
            {
                sSql = "select dbo.fun_getdate(Transfer_date) 转科日期,convert(char,Transfer_date,108) 转科时间,a.bed_no 床号,a.inpatient_no  住院号,a.name 姓名,a.SEX_NAME 性别,dbo.FUN_ZY_SEEKDEPTNAME(d.s_Dept_id) 源科室,dbo.FUN_ZY_SEEKDEPTNAME(d.d_Dept_id) 目标科室,dbo.FUN_ZY_SEEKEMPLOYEENAME(d.operator) 医生,dbo.fun_getdate(book_date) 登记日期,a.inpatient_id,a.baby_id,b.isMYTS,d.d_Dept_id,d.s_Dept_id,d.order_id,d.id ,b.bed_id,d.chk_bit,d.chk_man,d.chk_Time,d.ref_memo,a.DISCHARGETYPE " +
                    "  from ZY_TRANSFER_dept d left join ZY_BEDDICTION b on d.inpatient_id=b.inpatient_id,vi_zy_vinpatient_bed a " + //and d.baby_id=b.baby_id Modify by tany 2011-03-07 婴儿和母亲同一张床
                    "	where a.inpatient_id=d.inpatient_id and a.baby_id=d.baby_id " +
                    "         and d.s_Dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') and d.finish_bit=0 and d.cancel_bit=0 "
                    + "and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=d_Dept_id)= " + FrmMdiMain.Jgbm;
                myFunc.ShowGrid(0, sSql, this.myDataGrid1);

                string[] GrdMappingName1 ={ "转科日期", "转科时间", "床号", "住院号", "姓名", "性别", "源科室", "目标科室", "医生", "登记日期", "inpatient_id", "baby_id", "isMYTS", "d_Dept_id", "s_Dept_id", "order_id", "id", "bed_id" ,
                                        "审核标志", "审核人", "审核时间", "拒绝原因","yblx" };
                int[] GrdWidth1 ={ 10, 8, 4, 9, 12, 4, 12, 12, 8, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 0 };
                int[] Alignment1 ={ 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 0 };
                int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 6, 6, 0 };
                myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);

                myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb.Rows.Count != 0)
                {
                    this.bt转科.Enabled = true;
                    this.myDataGrid1.Enabled = true;
                    myFunc.SelectBin(false, this.myDataGrid1, 10, 11, 0, 0);
                }
                else
                {
                    this.bt转科.Enabled = false;
                    this.myDataGrid1.Enabled = false;
                }
            }
            else
            {
                sSql = "select dbo.fun_getdate(Transfer_date) 转科日期,convert(char,Transfer_date,108) 转科时间,b.inpatient_no  住院号,b.name 姓名,b.SEX_NAME 性别,dbo.FUN_ZY_SEEKDEPTNAME(a.s_Dept_id) 源科室,dbo.FUN_ZY_SEEKDEPTNAME(a.d_Dept_id) 目标科室,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.operator) 医生,dbo.fun_getdate(book_date) 登记日期,b.inpatient_id,b.baby_id,a.d_Dept_id,a.s_Dept_id,a.order_id,a.id,b.bed_id " +
                    "  from zy_transfer_Dept a inner join vi_zy_vinpatient_info b on a.inpatient_id=b.inpatient_id and a.baby_id=b.baby_id " +
                    "  where a.finish_bit=1 and a.cancel_bit=0 and b.flag=1  " +
                    "        and a.s_Dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') "
                    + " and (select JGBM from JC_DEPT_PROPERTY where DEPT_ID=d_Dept_id)= " + FrmMdiMain.Jgbm;
                myFunc.ShowGrid(0, sSql, this.GrdQxzk);

                string[] GrdMappingName1 ={ "转科日期", "转科时间", "住院号", "姓名", "性别", "源科室", "目标科室", "医生", "登记日期", "inpatient_id", "baby_id", "d_Dept_id", "s_Dept_id", "order_id", "id", "bed_id" };
                int[] GrdWidth1 ={ 10, 8, 9, 12, 4, 12, 12, 8, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] Alignment1 ={ 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.GrdQxzk);

                myTb = (DataTable)this.GrdQxzk.DataSource;
                if (myTb.Rows.Count != 0)
                {
                    this.btn取消转科.Enabled = true;
                    this.GrdQxzk.Enabled = true;
                    myFunc.SelectBin(false, this.GrdQxzk, 9, 10, 0, 0);
                }
                else
                {
                    this.btn取消转科.Enabled = false;
                    this.GrdQxzk.Enabled = false;
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid1);
        }

        private void bt转科_Click(object sender, System.EventArgs e)
        {

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null || myTb.Rows.Count == 0) return;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            string sBinID = myTb.Rows[nrow]["inpatient_id"].ToString().Trim();
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();
            long nSDeptID = Convert.ToInt64(myTb.Rows[nrow]["s_Dept_id"]);
            long nDDeptID = Convert.ToInt64(myTb.Rows[nrow]["d_Dept_id"]);
            string sOrderId = myTb.Rows[nrow]["order_id"].ToString().Trim();
            //add by zouchihua 2013-8-22 转科的时候。同时把以前科室bed_id更新进去
            string Sid = myTb.Rows[nrow]["id"].ToString().Trim(); //转科id
            string Sbed_id = myTb.Rows[nrow]["bed_id"].ToString().Trim(); //转科id

            int isMYTS = 0;
            if (myTb.Rows[nrow]["isMYTS"].ToString().Trim() != "")
            {
                isMYTS = Convert.ToInt32(myTb.Rows[nrow]["isMYTS"]);
            }

            //判断是否是婴儿先转科
            if (isMYTS != 0 && Convert.ToInt32(sBabyID) == 0 && cfg7205.Config == "0")
            {
                MessageBox.Show(this, "对不起，请先将婴儿转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isMYTS != 0 && Convert.ToInt32(sBabyID) == 0 && cfg7205.Config == "1")
            {
                MessageBox.Show(this, "对不起，请先将" + myTb.Rows[nrow]["姓名"].ToString() + "附转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sMsg = "";
            string sSql = "";
            DataTable tempTb = new DataTable();
            bool isBTYZ = false;//是否不停医嘱

            try
            {
                //转科是否判断有未记账的费用 0=不是，1=是, 应该是7102 Modify By Tany 2015-04-02 下面的判断都出错了，一起修正
                //string cfg7012 = new SystemCfg(7012).Config;
                string cfg7102 = new SystemCfg(7102).Config;

                sSql = "select 1 from zy_zkgx where s_Dept=" + nSDeptID + " and d_Dept=" + nDDeptID;
                DataTable deptTB = InstanceForm.BDatabase.GetDataTable(sSql);
                //判断是否可以不停医嘱转科
                if (deptTB == null || deptTB.Rows.Count == 0)
                {
                    //判断是否有未停止的医嘱、判断是否有未记帐的费用
                    sSql = " select sum(id1) as id1,sum(id2) as id2 from ( " +
                        " select count(a.order_id) id1,0 id2 " +
                        "  from zy_orderrecord a " +
                        "  where a.status_flag<5 and a.delete_bit=0 " +
                        "  and a.dept_id not in (select deptid from ss_dept) " + //Modify By Tany 2015-04-13 不验证手术麻醉科的医嘱是否完成
                        "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID + " ";

                    if (cfg7102 != "0")
                    {
                        sSql += " union all" +
                                            " select 0 id1,count(b.id) id2 " +
                                            "  from zy_fee_speci b " +
                                            "  where b.charge_bit=0 and b.delete_bit=0 " +
                                            "  and b.dept_id not in (select deptid from ss_dept) " + //Modify By Tany 2015-04-08 不验证手术麻醉科的费用是否完成
                                            "  and b.inpatient_id='" + sBinID + "' and b.baby_id=" + sBabyID + " "; //Modify By Tany 2004-12-22 转科可以不判断费用
                    }
                    sSql += " ) tmp";
                    tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (Convert.ToInt32(tempTb.Rows[0]["id1"]) > 0)
                    {
                        sMsg = "有未停止的医嘱";
                    }
                    if (Convert.ToInt32(tempTb.Rows[0]["id2"]) > 0)
                    {
                        sMsg += sMsg == "" ? "有" : "和";
                        sMsg = "未记帐的费用";
                    }
                    if (sMsg != "")
                    {
                        MessageBox.Show(this, "对不起，该病人" + sMsg + "，不允许转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnWzx_Click(null, null);
                        return;
                    }
                }
                else
                {
                    isBTYZ = true;

                    sSql = "select count(a.order_id) id1" +
                        "  from zy_orderrecord a " +
                        "  where a.status_flag<2 and a.delete_bit=0 " +
                        "  and a.dept_id not in (select deptid from ss_dept) " + //Modify By Tany 2015-04-13 不验证手术麻醉科的医嘱是否完成
                        "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID;
                    tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (Convert.ToInt32(tempTb.Rows[0]["id1"]) > 0)
                    {
                        MessageBox.Show(this, "对不起，该病人有未转抄的医嘱，不允许转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //临时医嘱必须发送后才能转科
                    sSql = "select count(a.order_id) id1" +
                        "  from zy_orderrecord a " +
                        "  where a.status_flag<5 and a.delete_bit=0 and mngtype in (1,5)" +
                        "  and a.dept_id not in (select deptid from ss_dept) " + //Modify By Tany 2015-04-13 不验证手术麻醉科的医嘱是否完成
                        "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID;
                    tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (Convert.ToInt32(tempTb.Rows[0]["id1"]) > 0)
                    {
                        MessageBox.Show(this, "对不起，该病人有未执行的临时医嘱，不允许转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //有转科关系，转科时也需要验证费用是否确认 Modify By Tany 2015-03-13
                    //医院又不要验证了 Modify By Tany 2015-04-09
                    //if (cfg7102 != "0")
                    //{
                    //    sSql = " select 0 id1,count(b.id) id2 " +
                    //            "  from zy_fee_speci b " +
                    //            "  where b.charge_bit=0 and b.delete_bit=0 " +
                    //            "  and b.dept_id not in (select deptid from ss_dept) " + //Modify By Tany 2015-04-08 不验证手术麻醉科的费用是否完成
                    //            "  and b.inpatient_id='" + sBinID + "' and b.baby_id=" + sBabyID + " ";

                    //    tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    //    if (Convert.ToInt32(tempTb.Rows[0]["id1"]) > 0)
                    //    {
                    //        sMsg = "有未停止的医嘱";
                    //    }
                    //    if (Convert.ToInt32(tempTb.Rows[0]["id2"]) > 0)
                    //    {
                    //        sMsg += sMsg == "" ? "有" : "和";
                    //        sMsg = "未记帐的费用";
                    //    }
                    //    if (sMsg != "")
                    //    {
                    //        MessageBox.Show(this, "对不起，该病人" + sMsg + "，不允许转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        btnWzx_Click(null, null);
                    //        return;
                    //    }
                    //}
                }

                //add by zouchihua 2012-12-11 又未审核的手术申请
                sSql = "select  * from SS_APPRECORD where  BDELETE=0 and JZSS=0 and SHBJ=0 and inpatient_id='" + sBinID + "'";
                DataTable tmtb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (tmtb != null && tmtb.Rows.Count > 0)
                {
                    MessageBox.Show("对不起，该病人还有未审核的择期手术，请通知医生进行审核后才可以进行转科操作！");
                    return;
                }

                sSql = "Select 1 from zy_BedDiction where inpatient_id='" + sBinID + "' and isbf=1";
                tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                if (tempTb.Rows.Count > 0)
                {
                    MessageBox.Show(this, "对不起，该病人有包床，请取消包床后再转科！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Modify By Tany 2015-04-01 增加参数控制
                SystemCfg cfg7604 = new SystemCfg(7604);
                //Modify by jchl（医保审核流程）
                if (!myTb.Rows[nrow]["DISCHARGETYPE"].ToString().Trim().Equals("0") && cfg7604.Config == "1")
                {
                    string id = myTb.Rows[nrow]["id"].ToString();
                    //非自费病人
                    sSql = "Select count(1) from ZY_TRANSFER_dept where id='" + id + "' and finish_bit=0 and cancel_bit=0 and ( chk_bit=1 or exists (select 1 from ZY_ZKGX where S_DEPT=s_Dept_id and D_DEPT=d_Dept_id))";
                    int iCnt = int.Parse(InstanceForm.BDatabase.GetDataResult(sSql).ToString());
                    if (iCnt <= 0)
                    {
                        MessageBox.Show(this, "对不起，该病人未审核通过，请联系医保办审核！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //转科
                if (MessageBox.Show(this, "确认“" + myTb.Rows[nrow]["姓名"].ToString().Trim() + "”转到“" + myTb.Rows[nrow]["目标科室"].ToString().Trim() + "”吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                #region 如果转科可以不停医嘱
                if (isBTYZ)
                {
                    //看看是不是还存在本科室的药品
                    sSql = "select a.group_id,a.hoitem_id cjid,a.order_context " +
                        "  from zy_orderrecord a " +
                        "  where a.status_flag<5 and a.delete_bit=0 and ntype in (1,2,3) and exec_Dept=" + InstanceForm.BCurrentDept.WardDeptId +
                        "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID;
                    tempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    //如果有，则把执行科室更改成对方科室
                    if (tempTb.Rows.Count > 0)
                    {
                        //得到对方科室信息
                        Department _newDept = new Department(nDDeptID, InstanceForm.BDatabase);

                        string tmpMsg = "";

                        #region 判断药品的有效性
                        for (int i = 0; i < tempTb.Rows.Count; i++)
                        {
                            sSql = "Select 1 from YF_KCMX a where a.bdelete=0 and a.cjid=" + tempTb.Rows[i]["cjid"].ToString().Trim() + " and a.deptid=" + _newDept.WardDeptId;
                            DataTable medTb = InstanceForm.BDatabase.GetDataTable(sSql);

                            if (medTb == null || medTb.Rows.Count == 0)
                            {
                                tmpMsg += " ⊙ " + tempTb.Rows[i]["order_context"].ToString().Trim() + "\n";
                            }
                        }

                        if (tmpMsg.Trim() != "")
                        {
                            MessageBox.Show("下列药品因为对方科室小药柜中没有该种药品，将不能更改执行科室！\n请确认对方科室小药柜有该种药品或请医生停止该组医嘱！\n不能更改执行科室为对方科室的药品包括：\n\n" + tmpMsg,
                                "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        #endregion

                        //判断通过的话，则把这些医嘱的执行科室全部改变
                        sSql = "update zy_orderrecord a " +
                            "  set exec_Dept=" + _newDept.WardDeptId +
                            "  where a.status_flag<5 and a.delete_bit=0 and ntype in (1,2,3) and exec_Dept=" + InstanceForm.BCurrentDept.WardDeptId +
                            "       and a.inpatient_id='" + sBinID + "' and a.baby_id=" + sBabyID;
                        InstanceForm.BDatabase.DoCommand(sSql);

                        //屏蔽该条转科医嘱
                        sSql = "update zy_orderrecord set delete_bit=1 where order_id='" + sOrderId + "'";
                        InstanceForm.BDatabase.DoCommand(sSql);
                    }
                }
                #endregion

                string _outmsg = "";
                if (myFunc.isMYTSBaby(isMYTS, Convert.ToInt32(sBabyID)))
                {
                    //减少母亲的母婴同室数量
                    _outmsg = myFunc.TransfeDept("", 2, new Guid(sBinID), Convert.ToInt64(sBabyID), nSDeptID, nDDeptID, InstanceForm.BCurrentUser.EmployeeId, Convert.ToDateTime(myTb.Rows[nrow]["登记日期"]), new Guid(myTb.Rows[nrow]["id"].ToString()));
                }
                else
                {
                    _outmsg = myFunc.TransfeDept("", 1, new Guid(sBinID), Convert.ToInt64(sBabyID), nSDeptID, nDDeptID, InstanceForm.BCurrentUser.EmployeeId, Convert.ToDateTime(myTb.Rows[nrow]["登记日期"]), new Guid(myTb.Rows[nrow]["id"].ToString()));
                }

                if (_outmsg.Trim() != "")
                {
                    MessageBox.Show(_outmsg);
                }
                //更改床位 2013-8-22 
                string updatesql = "update ZY_TRANSFER_DEPT set Sbed_id='" + Sbed_id + "'  where id='" + Sid + "'";
                InstanceForm.BDatabase.DoCommand(updatesql);

                Department msgDept = new Department(nDDeptID, FrmMdiMain.Database);
                string msg_wardid = msgDept.WardId;
                long msg_deptid = 0;
                long msg_empid = 0;
                string msg_sender = FrmMdiMain.CurrentDept.WardName + "：" + FrmMdiMain.CurrentUser.Name;
                string msg_msg = "有转科病人！\r\n住院号：" + myTb.Rows[nrow]["住院号"].ToString().Trim() + "\r\n姓名：" + myTb.Rows[nrow]["姓名"].ToString().Trim();
                TrasenFrame.Classes.WorkStaticFun.SendMessage(true, SystemModule.住院护士站, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);

                //写日志 Add By Tany 2005-01-12
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "转科", _outmsg + "将“" + myTb.Rows[nrow]["姓名"].ToString().Trim() + " " + sBinID + " " + sBabyID + "”转到“" + myTb.Rows[nrow]["目标科室"].ToString().Trim() + "”", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                frmZK_Load(sender, e);
            }
        }

        private void btnWzx_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null || myTb.Rows.Count == 0) return;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            string sBinID = myTb.Rows[nrow]["inpatient_id"].ToString().Trim();
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();

            object[] _communicates = new object[2];
            _communicates[0] = sBinID;
            _communicates[1] = sBabyID;
            WorkStaticFun.InstanceFormEx("ts_zyhs_wclxmcx", "Fun_ts_zyhs_wclxmcx", "未处理项目查询", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase, ref _communicates);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;

            if (myTb == null || myTb.Rows.Count == 0) return;

            string sSql = "";
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            Guid sBinID = new Guid(myTb.Rows[nrow]["inpatient_id"].ToString().Trim());
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();
            string sBedNo = myTb.Rows[nrow]["床号"].ToString().Trim();
            string sName = myTb.Rows[nrow]["姓名"].ToString().Trim();
            string sSDept = myTb.Rows[nrow]["源科室"].ToString().Trim();
            string sDDept = myTb.Rows[nrow]["目标科室"].ToString().Trim();
            long nSDeptID = Convert.ToInt64(myTb.Rows[nrow]["s_Dept_id"]);
            long nDDeptID = Convert.ToInt64(myTb.Rows[nrow]["d_Dept_id"]);
            Guid sId = new Guid(myTb.Rows[nrow]["id"].ToString().Trim());
            Guid sOrderId = new Guid(myTb.Rows[nrow]["order_id"].ToString().Trim());
            bool IsExistOrder = false;

            if (sOrderId == Guid.Empty)
            {
                if (MessageBox.Show("没有找到该条转科信息的转科医嘱，取消该转科信息将不能同时取消转科医嘱，是否继续？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }
            else
            {
                IsExistOrder = true;
            }
            string sMsg = IsExistOrder ? "\n同时将取消转科医嘱！" : "";
            if (MessageBox.Show("是否确定取消 " + sBedNo + " 床病人 " + sName + " 从 " + sSDept + " 到 " + sDDept + " 的转科信息？" + sMsg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                bool isHSZ = f1.isHSZ;
                if (f1.isLogin == false) return;
            }

            try
            {
                string[] sqls = new string[2];
                //sqls[0] = "update ZY_TRANSFER_Dept set cancel_bit=1,cancel_date=getdate(),cancel_operator=" + InstanceForm.BCurrentUser.EmployeeId +
                //    " where id='" + sId + "'";

                //Modify by tany 2011-03-07 取消所有该病人包括婴儿的转科记录
                sqls[0] = "update ZY_TRANSFER_Dept set cancel_bit=1,cancel_date=getdate(),cancel_operator=" + InstanceForm.BCurrentUser.EmployeeId +
                    " where finish_bit=0 and inpatient_id='" + sBinID + "' and s_dept_id=" + nSDeptID;

                if (IsExistOrder)
                {
                    sqls[1] = "update zy_orderrecord set delete_bit=1 where order_id='" + sOrderId + "'";
                }
                InstanceForm.BDatabase.DoCommand(null, null, null, sqls);
            }
            catch (Exception err)
            {
                //写错误日志 Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "程序错误", "取消转科错误：" + err.Message + "  Source：" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("错误：" + err.Message + "\n" + "Source：" + err.Source + "\n\n数据已经回滚，请检查后重新执行！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmZK_Load(sender, e);
                return;
            }

            MessageBox.Show("取消转科操作成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //写日志 Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "取消转科", "取消 " + sBedNo + " 床病人 " + sName + " 从 " + sSDept + " 到 " + sDDept + " 的转科信息", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            frmZK_Load(sender, e);
        }

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            frmZK_Load(null, null);
        }

        private void frmBRZK_Activated(object sender, System.EventArgs e)
        {
            frmZK_Load(null, null);
        }

        private void GrdQxzk_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myFunc.SelRow(this.GrdQxzk);
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            frmZK_Load(null, null);
        }

        private void btn取消转科_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = (DataTable)this.GrdQxzk.DataSource;
            if (myTb == null || myTb.Rows.Count == 0) return;
            int nrow = this.GrdQxzk.CurrentCell.RowNumber;
            Guid sBinID = new Guid(myTb.Rows[nrow]["inpatient_id"].ToString().Trim());
            string sBabyID = myTb.Rows[nrow]["baby_id"].ToString().Trim();
            string sName = myTb.Rows[nrow]["姓名"].ToString().Trim();
            string sSDept = myTb.Rows[nrow]["源科室"].ToString().Trim();
            string sDDept = myTb.Rows[nrow]["目标科室"].ToString().Trim();
            long nSDeptID = Convert.ToInt64(myTb.Rows[nrow]["s_Dept_id"]);
            long nDDeptID = Convert.ToInt64(myTb.Rows[nrow]["d_Dept_id"]);
            Guid sOrderId = new Guid(myTb.Rows[nrow]["order_id"].ToString().Trim());
            Guid sId = new Guid(myTb.Rows[nrow]["id"].ToString().Trim());
            string sSql = "";
            bool IsExistOrder = false;

            if (sOrderId == Guid.Empty)
            {
                if (MessageBox.Show("没有找到该条转科信息的转科医嘱，取消该转科信息将不能同时取消转科医嘱，是否继续？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }
            else
            {
                IsExistOrder = true;
            }
            string sMsg = IsExistOrder ? "\n同时将取消转科医嘱！" : "";
            if (MessageBox.Show("是否确定取消病人 " + sName + " 从 " + sSDept + " 到 " + sDDept + " 的转科信息？" + sMsg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            //Modify By Tany 2010-06-08 是否使用密码确认 0=使用 1=不使用
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                bool isHSZ = f1.isHSZ;
                if (f1.isLogin == false) return;
            }

            //再次判断病人状态
            sSql = "select flag from vi_zy_vinpatient_info where (flag=1 or dept_id=" + nSDeptID + ") and inpatient_id='" + sBinID + "' and baby_id=0";//Modify By tany 2011-03-07 只判断大人的状态" + sBabyID;
            DataTable patTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (patTb == null || patTb.Rows.Count == 0)
            {
                MessageBox.Show("对不起，没有找到病人信息或病人已经分配床位，不能进行操作！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmZK_Load(sender, e);
                return;
            }

            string[] sqls = new string[5];
            sqls[0] = "update zy_inpatient set dept_id=" + nSDeptID + " where dept_id=" + nDDeptID + " and inpatient_id='" + sBinID + "'";

            //sqls[1] = "update ZY_TRANSFER_Dept set cancel_bit=1,cancel_date=getdate(),cancel_operator=" + InstanceForm.BCurrentUser.EmployeeId +
            //    " where id='" + sId + "'";

            //Modify by tany 2011-03-07 取消所有该病人包括婴儿的转科记录
            sqls[1] = "update ZY_TRANSFER_Dept set cancel_bit=1,cancel_date=getdate(),cancel_operator=" + InstanceForm.BCurrentUser.EmployeeId +
                " where inpatient_id='" + sBinID + "' and s_dept_id=" + nSDeptID;

            if (IsExistOrder)
            {
                sqls[2] = "update zy_orderrecord set delete_bit=1 where order_id='" + sOrderId + "'";
            }

            //Modify By tany 2011-03-07 取消婴儿的转科记录
            sqls[3] = "update a set a.dept_id=" + nSDeptID + ",a.flag=b.flag,a.bed_id=b.bed_id from zy_inpatient_baby a inner join zy_inpatient b on a.inpatient_id=b.inpatient_id where a.dept_id=" + nDDeptID + " and a.inpatient_id='" + sBinID + "'";
            sqls[4] = "update zy_beddiction set ismyts=isnull((select count(1) from zy_inpatient_baby where inpatient_id='" + sBinID + "'),0) where inpatient_id='" + sBinID + "'";

            InstanceForm.BDatabase.DoCommand(null, null, null, sqls);

            //写日志 Add By Tany 2005-01-12
            SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "取消转科", "将“" + myTb.Rows[nrow]["姓名"].ToString().Trim() + " " + sBinID + " " + sBabyID + "”取消转科", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "主机名：" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            frmZK_Load(sender, e);
        }

        private void frmBRZK_Load(object sender, System.EventArgs e)
        {

        }

    }
}

