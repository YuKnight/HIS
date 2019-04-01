using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenFrame.Forms;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;
using ts_zyhs_classes;
using TszyHIS;
namespace Ts_ss_brcx
{
    /// <summary>
    /// frmBrcx 的摘要说明。
    /// </summary>
    public class frmBrcx : System.Windows.Forms.Form
    {
        //自定义变量
        private Guid _inpatientId;
        private string _stag;
        private string _wardId;
        private long _deptId;
        private long _currentUserId;
        private long _currentDeptId;
        private long _ward_deptId;
        private DataView myDV = new DataView();

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnl_1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_br;
        private System.Windows.Forms.Panel pnl_2;
        private System.Windows.Forms.Panel pnl_3;
        private System.Windows.Forms.TextBox txtPatID;
        public Button btnXxcx;
        private System.Windows.Forms.Button btnYzlr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private DataGridEx dGrid_Pat;
        private System.Windows.Forms.DateTimePicker dTimeP_CX;
        private TrasenClasses.GeneralControls.LabelEx xcjwLabel1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.IContainer components;
        private Button btnserch;
        private Panel panel3;
        private Panel panel2;
        private RadioButton rdbYwc;
        private RadioButton rdbYap;
        private RadioButton rdbYjz;

        //yaokx 2014-05-24 转科病人来自不同科室的手术申请，录入医嘱要选择手术
        private string strValue;
        public string StrValue
        {
            set
            {
                strValue = value;
            }
        }
        /// <summary>
        /// 0 手术麻醉，1 特殊治疗
        /// </summary>
        private int type = 0;
        public frmBrcx(long currentUser, long currentDept, string formText, object[] _value)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _currentUserId = currentUser;
            _currentDeptId = currentDept;
            _ward_deptId = new Department(currentDept, FrmMdiMain.Database).WardDeptId;

            InitGrd();

            myDV = new DataView(GetPatList(this.dTimeP_CX.Value, _currentDeptId));
            this.dGrid_Pat.DataSource = myDV;
            DelTextBoxFromDataGrid(dGrid_Pat);
            type = Int32.Parse(_value[0].ToString());

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        public frmBrcx(long currentUser, long currentDept, string formText)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            _currentUserId = currentUser;
            _currentDeptId = currentDept;
            _ward_deptId = new Department(currentDept, FrmMdiMain.Database).WardDeptId;

            InitGrd();
            myDV = new DataView(GetPatList(this.dTimeP_CX.Value, _currentDeptId));
            this.dGrid_Pat.DataSource = myDV;
            DelTextBoxFromDataGrid(dGrid_Pat);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrcx));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnl_1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dGrid_Pat = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbYwc = new System.Windows.Forms.RadioButton();
            this.rdbYap = new System.Windows.Forms.RadioButton();
            this.rdbYjz = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dTimeP_CX = new System.Windows.Forms.DateTimePicker();
            this.bt_br = new System.Windows.Forms.Button();
            this.pnl_2 = new System.Windows.Forms.Panel();
            this.pnl_3 = new System.Windows.Forms.Panel();
            this.btnserch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatID = new System.Windows.Forms.TextBox();
            this.btnXxcx = new System.Windows.Forms.Button();
            this.btnYzlr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.xcjwLabel1 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.pnl_1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_Pat)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_2.SuspendLayout();
            this.pnl_3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(232, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 483);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // pnl_1
            // 
            this.pnl_1.Controls.Add(this.panel3);
            this.pnl_1.Controls.Add(this.panel2);
            this.pnl_1.Controls.Add(this.panel1);
            this.pnl_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_1.Location = new System.Drawing.Point(0, 0);
            this.pnl_1.Name = "pnl_1";
            this.pnl_1.Size = new System.Drawing.Size(232, 483);
            this.pnl_1.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dGrid_Pat);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 425);
            this.panel3.TabIndex = 14;
            // 
            // dGrid_Pat
            // 
            this.dGrid_Pat.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGrid_Pat.CaptionBackColor = System.Drawing.Color.DimGray;
            this.dGrid_Pat.CaptionText = "病人列表";
            this.dGrid_Pat.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dGrid_Pat.DataMember = "";
            this.dGrid_Pat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGrid_Pat.HeaderFont = new System.Drawing.Font("微软雅黑", 9F);
            this.dGrid_Pat.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGrid_Pat.Location = new System.Drawing.Point(0, 0);
            this.dGrid_Pat.Name = "dGrid_Pat";
            this.dGrid_Pat.ReadOnly = true;
            this.dGrid_Pat.RowHeaderWidth = 20;
            this.dGrid_Pat.Size = new System.Drawing.Size(232, 425);
            this.dGrid_Pat.TabIndex = 12;
            this.dGrid_Pat.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dGrid_Pat.CurrentCellChanged += new System.EventHandler(this.dGrid_Pat_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dGrid_Pat;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdbYwc);
            this.panel2.Controls.Add(this.rdbYap);
            this.panel2.Controls.Add(this.rdbYjz);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 34);
            this.panel2.TabIndex = 13;
            // 
            // rdbYwc
            // 
            this.rdbYwc.AutoSize = true;
            this.rdbYwc.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rdbYwc.Location = new System.Drawing.Point(135, 7);
            this.rdbYwc.Name = "rdbYwc";
            this.rdbYwc.Size = new System.Drawing.Size(62, 21);
            this.rdbYwc.TabIndex = 2;
            this.rdbYwc.Text = "已完成";
            this.rdbYwc.UseVisualStyleBackColor = true;
            this.rdbYwc.CheckedChanged += new System.EventHandler(this.rdbYwc_CheckedChanged);
            // 
            // rdbYap
            // 
            this.rdbYap.AutoSize = true;
            this.rdbYap.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rdbYap.Location = new System.Drawing.Point(69, 6);
            this.rdbYap.Name = "rdbYap";
            this.rdbYap.Size = new System.Drawing.Size(62, 21);
            this.rdbYap.TabIndex = 1;
            this.rdbYap.Text = "已安排";
            this.rdbYap.UseVisualStyleBackColor = true;
            this.rdbYap.CheckedChanged += new System.EventHandler(this.rdbYap_CheckedChanged);
            // 
            // rdbYjz
            // 
            this.rdbYjz.AutoSize = true;
            this.rdbYjz.Checked = true;
            this.rdbYjz.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.rdbYjz.Location = new System.Drawing.Point(3, 6);
            this.rdbYjz.Name = "rdbYjz";
            this.rdbYjz.Size = new System.Drawing.Size(62, 21);
            this.rdbYjz.TabIndex = 0;
            this.rdbYjz.TabStop = true;
            this.rdbYjz.Text = "已记账";
            this.rdbYjz.UseVisualStyleBackColor = true;
            this.rdbYjz.CheckedChanged += new System.EventHandler(this.rdbYjz_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dTimeP_CX);
            this.panel1.Controls.Add(this.bt_br);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 24);
            this.panel1.TabIndex = 0;
            // 
            // dTimeP_CX
            // 
            this.dTimeP_CX.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dTimeP_CX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dTimeP_CX.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dTimeP_CX.Location = new System.Drawing.Point(0, 0);
            this.dTimeP_CX.Name = "dTimeP_CX";
            this.dTimeP_CX.Size = new System.Drawing.Size(208, 23);
            this.dTimeP_CX.TabIndex = 4;
            // 
            // bt_br
            // 
            this.bt_br.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_br.Dock = System.Windows.Forms.DockStyle.Right;
            this.bt_br.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_br.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_br.ForeColor = System.Drawing.Color.LightCoral;
            this.bt_br.Image = ((System.Drawing.Image)(resources.GetObject("bt_br.Image")));
            this.bt_br.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.bt_br.Location = new System.Drawing.Point(208, 0);
            this.bt_br.Name = "bt_br";
            this.bt_br.Size = new System.Drawing.Size(24, 24);
            this.bt_br.TabIndex = 3;
            this.bt_br.Click += new System.EventHandler(this.bt_br_Click);
            // 
            // pnl_2
            // 
            this.pnl_2.BackColor = System.Drawing.Color.Gainsboro;
            this.pnl_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_2.Controls.Add(this.pnl_3);
            this.pnl_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_2.Location = new System.Drawing.Point(236, 0);
            this.pnl_2.Name = "pnl_2";
            this.pnl_2.Size = new System.Drawing.Size(356, 483);
            this.pnl_2.TabIndex = 9;
            this.pnl_2.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_2_Paint);
            this.pnl_2.SizeChanged += new System.EventHandler(this.pnl_2_SizeChanged);
            // 
            // pnl_3
            // 
            this.pnl_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnl_3.Controls.Add(this.btnserch);
            this.pnl_3.Controls.Add(this.label2);
            this.pnl_3.Controls.Add(this.txtPatID);
            this.pnl_3.Controls.Add(this.btnXxcx);
            this.pnl_3.Controls.Add(this.btnYzlr);
            this.pnl_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_3.Location = new System.Drawing.Point(0, 0);
            this.pnl_3.Name = "pnl_3";
            this.pnl_3.Size = new System.Drawing.Size(352, 479);
            this.pnl_3.TabIndex = 5;
            // 
            // btnserch
            // 
            this.btnserch.BackColor = System.Drawing.Color.White;
            this.btnserch.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnserch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnserch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnserch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnserch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnserch.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnserch.Image = global::Ts_ss_brcx.Properties.Resources._23;
            this.btnserch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnserch.Location = new System.Drawing.Point(243, 24);
            this.btnserch.Name = "btnserch";
            this.btnserch.Size = new System.Drawing.Size(97, 28);
            this.btnserch.TabIndex = 6;
            this.btnserch.Text = "病人查询";
            this.btnserch.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnserch.UseVisualStyleBackColor = false;
            this.btnserch.Visible = false;
            this.btnserch.Click += new System.EventHandler(this.btnserch_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(14, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "请输入住院号:";
            // 
            // txtPatID
            // 
            this.txtPatID.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPatID.Location = new System.Drawing.Point(110, 24);
            this.txtPatID.Name = "txtPatID";
            this.txtPatID.Size = new System.Drawing.Size(127, 29);
            this.txtPatID.TabIndex = 1;
            // 
            // btnXxcx
            // 
            this.btnXxcx.BackColor = System.Drawing.SystemColors.Control;
            this.btnXxcx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXxcx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXxcx.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnXxcx.ForeColor = System.Drawing.Color.Indigo;
            this.btnXxcx.Location = new System.Drawing.Point(110, 145);
            this.btnXxcx.Name = "btnXxcx";
            this.btnXxcx.Size = new System.Drawing.Size(230, 40);
            this.btnXxcx.TabIndex = 4;
            this.btnXxcx.Text = "信息查询";
            this.btnXxcx.UseVisualStyleBackColor = false;
            this.btnXxcx.Click += new System.EventHandler(this.btnXxcx_Click);
            // 
            // btnYzlr
            // 
            this.btnYzlr.BackColor = System.Drawing.SystemColors.Control;
            this.btnYzlr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYzlr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYzlr.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnYzlr.ForeColor = System.Drawing.Color.Indigo;
            this.btnYzlr.Location = new System.Drawing.Point(110, 77);
            this.btnYzlr.Name = "btnYzlr";
            this.btnYzlr.Size = new System.Drawing.Size(230, 40);
            this.btnYzlr.TabIndex = 2;
            this.btnYzlr.Text = "医嘱账单录入";
            this.btnYzlr.UseVisualStyleBackColor = false;
            this.btnYzlr.Click += new System.EventHandler(this.btnYzlr_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "住 院 号 ：";
            // 
            // xcjwLabel1
            // 
            this.xcjwLabel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.xcjwLabel1.BackColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.xcjwLabel1.BackColor2 = System.Drawing.Color.AliceBlue;
            this.xcjwLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.xcjwLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xcjwLabel1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xcjwLabel1.ForeColor = System.Drawing.SystemColors.Window;
            this.xcjwLabel1.Location = new System.Drawing.Point(0, 0);
            this.xcjwLabel1.Name = "xcjwLabel1";
            this.xcjwLabel1.Size = new System.Drawing.Size(100, 23);
            this.xcjwLabel1.TabIndex = 0;
            // 
            // frmBrcx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.ClientSize = new System.Drawing.Size(592, 483);
            this.Controls.Add(this.pnl_2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnl_1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmBrcx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手术病人查询";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.frmBrcx_Load);
            this.pnl_1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_Pat)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnl_2.ResumeLayout(false);
            this.pnl_3.ResumeLayout(false);
            this.pnl_3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region 方法
        #region 初始化DataGrid
        private void InitGrd()
        {
            int i = 0;
            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (i = 0; i < 4; i++)
            {
                aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                aColumnTextColumn.Format = "";
                aColumnTextColumn.FormatInfo = null;
                aColumnTextColumn.NullText = "";
                aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                dGrid_Pat.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
            }
            dGrid_Pat.TableStyles[0].GridColumnStyles[0].MappingName = "住院号";
            dGrid_Pat.TableStyles[0].GridColumnStyles[0].HeaderText = "住院号";
            dGrid_Pat.TableStyles[0].GridColumnStyles[0].ReadOnly = true;
            dGrid_Pat.TableStyles[0].GridColumnStyles[0].Width = 60;

            dGrid_Pat.TableStyles[0].GridColumnStyles[1].MappingName = "姓名";
            dGrid_Pat.TableStyles[0].GridColumnStyles[1].HeaderText = "姓名";
            dGrid_Pat.TableStyles[0].GridColumnStyles[1].ReadOnly = true;
            dGrid_Pat.TableStyles[0].GridColumnStyles[1].Width = 55;

            dGrid_Pat.TableStyles[0].GridColumnStyles[2].MappingName = "科室";
            dGrid_Pat.TableStyles[0].GridColumnStyles[2].HeaderText = "科室";
            dGrid_Pat.TableStyles[0].GridColumnStyles[2].ReadOnly = true;
            dGrid_Pat.TableStyles[0].GridColumnStyles[2].Width = 75;

            dGrid_Pat.TableStyles[0].GridColumnStyles[3].MappingName = "flag";
            dGrid_Pat.TableStyles[0].GridColumnStyles[3].HeaderText = "flag";
            dGrid_Pat.TableStyles[0].GridColumnStyles[3].ReadOnly = true;
            dGrid_Pat.TableStyles[0].GridColumnStyles[3].Width = 0;
        }
        public void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            e.BackColor = Color.White;
            e.ForeColor = Color.Black;
            myDV = (DataView)dGrid_Pat.DataSource;
            if (Convert.ToInt32(myDV[e.Row]["flag"]) > 4)
            {
                e.BackColor = Color.Honeydew;
                e.ForeColor = SystemColors.GrayText;
            }
            if (Convert.ToInt32(myDV[e.Row]["sel"]) == 1)
            {
                e.BackColor = Color.Navy;
                e.ForeColor = Color.White;
            }
        }
        #endregion

        #region 去除 DataGrid中的TextBox
        private void DelTextBoxFromDataGrid(DataGridEx myDataGrid)
        {
            for (int n = 0; n < myDataGrid.TableStyles[0].GridColumnStyles.Count; n++)
            {
                DataGridTextBoxColumn dgtb = (DataGridTextBoxColumn)myDataGrid.TableStyles[0].GridColumnStyles[n];
                dgtb.TextBox.Parent.Controls.Remove(dgtb.TextBox);
            }
        }
        #endregion

        #region 获取窗体
        private void GetForm(string dllName, string functionName, string chineseName, long userID, long deptID, object[] communicateValue, bool showType)
        {
            //			long menuId=WorkStaticFun.GetMenuId(dllName,functionName,FrmMdiMain.Database);
            User _userid = new User(userID, FrmMdiMain.Database);
            Department _deptid = new Department(deptID, FrmMdiMain.Database);

            //获得DLL中窗体

            Form _dllform = (Form)WorkStaticFun.InstanceForm(dllName, functionName, chineseName, _userid, _deptid, null, FrmMdiMain.Database, ref communicateValue);
            _dllform.StartPosition = FormStartPosition.CenterScreen;
            if (showType) _dllform.ShowDialog();
            else _dllform.Show();
        }
        #endregion

        #region 取病人信息
        /// <summary>
        /// 取病人信息（在院手术病人）
        /// </summary>
        /// <param name="sNo">住院号</param>
        private bool GetPatientInfo(string sNo)//２００５-１１-３停用
        {
            string ssql = "select a.inpatient_id," +
                " char(b.inpatient_id)+char(int(b.baby_id))+ char(int(b.ismy))+char(int(b.dept_id))+char(int(b.ward_id)) as stag," +
                " b.ward_id,b.dept_id " +
                " from ss_apprecord as a inner join vi_zy_vinpatient_bed as b " +
                " on a.inpatient_id=b.inpatient_id and b.inpatient_no='" + sNo + "'";
            DataTable tb = FrmMdiMain.Database.GetDataTable(ssql);
            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("没有该住院号的病人，请重新输入住院号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            try
            {
                _inpatientId = new Guid(tb.Rows[0]["inpatient_id"].ToString());
                _stag = tb.Rows[0]["stag"].ToString();
                _deptId = Convert.ToInt64(tb.Rows[0]["dept_id"]);
                _wardId = Convert.ToString(tb.Rows[0]["ward_id"]);
                return true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }
        /// <summary>
        /// 取病人信息（在院病人）
        /// </summary>
        /// <param name="sNo">住院号</param>
        private bool GetPatient(string sNo)
        {
            string ssql = "select b.inpatient_id," +
                " cast(b.inpatient_id as char(40))+cast(cast(b.baby_id as int) as char(10))+ cast(cast(b.ismy as int) as char(10))+cast(cast(b.dept_id as int) as char(10))+cast(b.ward_id  as char(10)) as stag," +//+cast(cast(b.ward_id as int) as char(10)) as stag,"+
                " b.ward_id,b.dept_id " +
                " from vi_zy_vinpatient_bed as b " +
                " where b.baby_id=0 and b.inpatient_no='" + sNo + "'";
            DataTable tb = FrmMdiMain.Database.GetDataTable(ssql);
            if (tb.Rows.Count == 0)
            {
                string msg = "未找到该住院号病人的在床信息，请重新输入住院号!\r\n\r\n";
                msg += "1、请联系病人所在病区，看病人是否已经定义出院\r\n";
                msg += "2、请联系病人所在病区，看病人是否已经分配床位";
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            try
            {
                _inpatientId = new Guid(tb.Rows[0]["inpatient_id"].ToString());
                _stag = tb.Rows[0]["stag"].ToString();
                _deptId = Convert.ToInt64(tb.Rows[0]["dept_id"]);
                //_wardId=Convert.ToInt64(tb.Rows[0]["ward_id"]);
                _wardId = Convert.ToString(tb.Rows[0]["ward_id"]);
                return true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }
        #endregion

        #region 获取已记帐病人
        private DataTable GetPatList(DateTime dtime, long deptid)
        {
            DateTime dtimes = Convert.ToDateTime(dtime.Date);
            string _datimes = dtimes.ToString().Trim();
            string sSql = "select 0 sel, bb.inpatient_no 住院号,bb.name 姓名,dbo.FUN_JC_DEPTNAME(cast(bb.dept_id as int)) 科室 ,bb.flag " +
                        "from (select distinct inpatient_id from zy_orderrecord where dept_id=" + deptid + " and delete_bit=0 and book_date between '" + dtime.ToShortDateString() + " 00:00:00" + "' and DATEADD(day,1,'" + _datimes + "')) aa " +
                        "      inner join " +
                        "      vi_zy_vinpatient bb on aa.inpatient_id=bb.inpatient_id  ";
            DataTable tb = FrmMdiMain.Database.GetDataTable(sSql);
            return tb;
        }
        #endregion

        private DataTable GetYapList(DateTime dtime, long deptid)
        {
            DateTime dtimes = Convert.ToDateTime(dtime.Date);
            string _datimes = dtimes.ToString().Trim();
            string sSql = string.Format(@"SELECT 0 AS sel,
                                                                        b.INPATIENT_NO AS 住院号, 
                                                                        b.NAME AS 姓名 ,
                                                                        b.CUR_DEPT_NAME AS 科室,
                                                                        b.FLAG
                                                                        FROM dbo.SS_ARRRECORD a INNER JOIN
                                                                        dbo.VI_ZY_VINPATIENT_ALL b  ON a.INPATIENT_ID = b.INPATIENT_ID
                                                                        WHERE WCBJ=0 and BDELETE=0 AND a.APDJRQ BETWEEN '{0}' AND DATEADD(day,1, '{1}')  ", dtime.ToShortDateString() + " 00:00:00", dtime);
            DataTable tb = FrmMdiMain.Database.GetDataTable(sSql);
            return tb;
        }
        private DataTable GetYwcList(DateTime dtime, long deptid)
        {
            DateTime dtimes = Convert.ToDateTime(dtime.Date);
            string _datimes = dtimes.ToString().Trim();
            string sSql = string.Format(@"SELECT 0 AS sel,
                                                                        b.INPATIENT_NO AS 住院号, 
                                                                        b.NAME AS 姓名 ,
                                                                        b.CUR_DEPT_NAME AS 科室,
                                                                        b.FLAG
                                                                        FROM dbo.SS_ARRRECORD a INNER JOIN
                                                                        dbo.VI_ZY_VINPATIENT_ALL b  ON a.INPATIENT_ID = b.INPATIENT_ID
                                                                        WHERE WCBJ=1 and BDELETE=0 AND a.APDJRQ BETWEEN '{0}' AND DATEADD(day,1, '{1}')  ", dtime.ToShortDateString() + " 00:00:00", dtime);
            DataTable tb = FrmMdiMain.Database.GetDataTable(sSql);
            return tb;
        }
        /// <summary>
        /// 医嘱管理(医嘱录入)
        /// </summary>
        /// <param name="userid">开嘱医生userId</param>
        /// <param name="deptid">开嘱医生的科室ID</param>
        /// <param name="dept_br">病人所在科室ID</param>
        private void ShowFrmYZGL(long userid, long deptid, string ssNo)
        {
            if (this.txtPatID.Text == "")
            {
                MessageBox.Show("请输入住院号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ssNo == "0")
            {
                MessageBox.Show("请选择一位病人!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (GetPatient(ssNo) == false)
            {
                return;
            }
            ///by add yaokx 2014-05-23 如果A科室病人申请一台手术，若做完手术，手术室医生没有记账之前，该病人由A科室转入B科室，此时手术室医生再进行记账，则此次病人在手术室发生的费用记账在B科室
            if (new SystemCfg(9010).Config == "1")
            {
                DataTable tbdept = FrmMdiMain.Database.GetDataTable(" select DEPTID from ss_apprecord where INPATIENT_ID='" + _inpatientId + "' and bdelete=0 and (jzss=1 or shbj=1) group by DEPTID");
                if (tbdept != null && tbdept.Rows.Count > 1)
                {
                    FrmShow frm = new FrmShow();
                    frm.Owner = this;
                    frm.INPATIENT_ID = _inpatientId;
                    frm.ShowDialog();
                    _deptId = Convert.ToInt32(strValue);
                    DataTable tbward = FrmMdiMain.Database.GetDataTable("select * from JC_WARDRDEPT where DEPT_ID=" + strValue + "");
                    if (tbward != null && tbward.Rows.Count > 0)
                    {
                        _wardId = tbward.Rows[0]["WARD_ID"].ToString();
                    }
                    string[] strs = _stag.Split(' ');
                    string s = strs[0] + "    " + strs[4] + "         " + strs[13] + "         " + _deptId + "       " + _wardId + "       ";
                    _stag = s;
                }
            }

            object[] communicateValue = new object[10];
            communicateValue[0] = _inpatientId;
            communicateValue[1] = _wardId;//
            communicateValue[2] = _deptId;//病人科室
            communicateValue[3] = _stag;
            communicateValue[4] = false;
            communicateValue[5] = 1;
            communicateValue[6] = _ward_deptId;

            User _userid = new User(userid, FrmMdiMain.Database);
            Department _deptid = new Department(deptid, FrmMdiMain.Database);
            string ssql = "select distinct c.INPATIENT_ID AS BINID,C.INPATIENT_NO AS 住院号,c.NAME AS 姓名" +
                " from vi_zy_vinpatient_bed c" +
                " where c.inpatient_no='" + ssNo + "' and c.baby_id = 0 and flag<>10";
            int _iskdksly = 0;
            //Modify by zouchihua 2012-3-18 增加了特殊治疗的病人
            if (type == 0)
            {
                //Modify By Tany 2011-03-03
                //9003是否允许对未开手术申请的病人录入医嘱 0=是 1=不是
                if (new SystemCfg(9003).Config == "1")
                {
                    ssql += " and c.inpatient_id in (select inpatient_id from ss_apprecord where (jzss=1 or shbj=1) and bdelete=0)";
                }
                communicateValue[7] = ssql;

                //Modify By Tany 2015-06-25 如果是查找病人，需要找到对应的手术申请，然后赋值给医嘱管理界面
                string ssId = "";
                int ssType = 0;
                string sql = "select SNO,YSSSRQ 拟施时间,YSSS 手术,b.NAME 麻醉,dbo.fun_getdeptname(deptid) 申请科室,dbo.fun_getempname(sqdjczy) 申请医生,a.id from SS_APPRECORD a left join SS_ANESTHESIACODE b on a.YSMZ=b.ID where BDELETE=0 and INPATIENT_ID='" + _inpatientId + "'";
                DataTable ssmzTb = FrmMdiMain.Database.GetDataTable(sql);
                if (ssmzTb == null || ssmzTb.Rows.Count == 0)
                {
                    ssId = "";
                    ssType = 0;
                }
                else
                {
                    Ts_zygl_ybgl.FrmDataGridView frmDv = new Ts_zygl_ybgl.FrmDataGridView();
                    frmDv.dgv.DataSource = ssmzTb;
                    frmDv.dgv.MultiSelect = false;
                    frmDv.ShowDialog();
                    if (frmDv.DialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (frmDv.dgv.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("未选择数据！");
                            return;
                        }
                        else
                        {
                            ssId = Convertor.IsNull(ssmzTb.Rows[frmDv.dgv.SelectedRows[0].Index]["id"], "");
                            ssType = 2;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                communicateValue[8] = ssId;
                communicateValue[9] = ssType;
            }
            else
            {
                SystemCfg cfg6038 = new SystemCfg(6038);
                string[] ss = cfg6038.Config.Split(',');
                if (!((ss.Length == 1 && ss[0].Trim() == "") || Convert.ToString("," + cfg6038.Config + ",").Contains("," + _currentDeptId + ",")))
                {
                    MessageBox.Show("本科室无权进行医嘱帐单录入", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable tb = FrmMdiMain.Database.GetDataTable("select * from JC_DEPT_TSZL where DEPTID=" + _currentDeptId + " ");
                if (tb != null && tb.Rows.Count > 0)
                {
                    _iskdksly = Int32.Parse(tb.Rows[0]["ISKDKSLY"].ToString());
                }
                communicateValue[7] = _iskdksly;
                communicateValue[8] = 1;
            }
            DataTable tb1 = FrmMdiMain.Database.GetDataTable(ssql);
            if (tb1.Rows.Count == 0)
            {
                string msg = "未找到该住院号病人的在床信息，请重新输入住院号!\r\n\r\n";
                msg += "1、请联系病人所在病区，看病人是否已经定义出院\r\n";
                msg += "2、请联系病人所在病区，看病人是否已经分配床位";
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (type == 0)
                GetForm("Ts_zyys_yzgl", "Fun_Ts_zyys_mzyz", "医嘱管理", userid, deptid, communicateValue, false);
            else
                GetForm("Ts_zyys_yzgl", "Fun_Ts_zyys_yzgl", "医嘱管理", userid, deptid, communicateValue, false);
        }

        /// <summary>
        /// 医嘱查询_麻醉,信息查询
        /// </summary>
        /// <param name="userid">开嘱医生userId</param>
        /// <param name="deptid">开嘱医生的科室ID</param>
        /// <param name="dept_br">病人所在科室ID</param>
        private void ShowFrmYZCX_MZ(long userid, long deptid, string ssNo)
        {
            if (this.txtPatID.Text == "")
            {
                MessageBox.Show("请输入住院号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object[] communicateValue = new object[3];
            User _userid = new User(userid, FrmMdiMain.Database);
            Department _deptid = new Department(deptid, FrmMdiMain.Database);
            //add by zouchihua 2012-5-24 医生工作站 手术麻醉进入是否对婴儿记账 0=否，1=是
            SystemCfg cfg6034 = new SystemCfg(6034);
            string ssql = "";
            if (cfg6034.Config.Trim() == "0")
                ssql = "select  INPATIENT_NO AS 住院号,NAME AS 姓名,INPATIENT_ID,0 as Baby_ID,DEPT_ID,0 as isMY " +
                          "from vi_zy_vinpatient " +
                          "where inpatient_no='" + ssNo + "' and flag<>10";
            else
                ssql = "select  INPATIENT_NO AS 住院号,NAME AS 姓名,INPATIENT_ID,Baby_ID,DEPT_ID,0 as isMY " +
                        "from VI_ZY_VINPATIENT_BED " +
                        "where inpatient_no='" + ssNo + "' and flag<>10";

            if (type == 0)
            {
                //Modify By Tany 2011-03-03
                //9003是否允许对未开手术申请的病人录入医嘱 0=是 1=不是
                if (new SystemCfg(9003).Config == "1")
                {
                    ssql += " and inpatient_id in (select inpatient_id from ss_apprecord where (jzss=1 or shbj=1) and bdelete=0)";
                }
            }
            else//特殊治疗
            {
                ssql = "select  INPATIENT_NO AS 住院号,NAME AS 姓名,INPATIENT_ID,0 as Baby_ID,DEPT_ID,0 as isMY " +
                        "from vi_zy_vinpatient_bed " +
                        "where inpatient_no='" + ssNo + "' and flag<>10";
            }
            DataTable tb = FrmMdiMain.Database.GetDataTable(ssql);
            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("不能查询该住院号的病人，请重新输入住院号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ClassStatic.Current_BinID = new Guid(tb.Rows[0]["INPATIENT_ID"].ToString());
            ClassStatic.Current_DeptID = Convert.ToInt64(tb.Rows[0]["DEPT_ID"]);
            ClassStatic.Current_BabyID = 0;
            communicateValue[0] = ssql;
            communicateValue[1] = 1;
            //Modify by zouchihua 2012-3-19
            if (type == 0)
            {
                //Modify By Tany 2015-05-11 手术和麻醉要根据科室来
                DataTable ssmzTb = FrmMdiMain.Database.GetDataTable("select * from ss_dept where deptid=" + FrmMdiMain.CurrentDept.DeptId);
                if (ssmzTb != null && ssmzTb.Rows.Count > 0)
                {
                    int ssmzType = Convert.ToInt32(ssmzTb.Rows[0]["type"]);
                    communicateValue[1] = ssmzType; //0=手术 1=麻醉
                }
                WorkStaticFun.InstanceFormEx("ts_zyhs_yzgl", "Fun_ts_zyhs_yzgl_ssmz", "医嘱管理", _userid, _deptid, InstanceForm._functions, InstanceForm._menuId, this.MdiParent, FrmMdiMain.Database, ref communicateValue);
            }
            if (type == 1)
            {
                communicateValue[2] = tb.Rows[0]["INPATIENT_ID"].ToString();
                WorkStaticFun.InstanceFormEx("ts_zyhs_yzgl", "Fun_ts_zyhs_yzgl_inpatient", "医嘱管理", _userid, _deptid, InstanceForm._functions, InstanceForm._menuId, this.MdiParent, FrmMdiMain.Database, ref communicateValue);
            }
        }

        #endregion

        /// <summary>
        /// 信息查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXxcx_Click(object sender, System.EventArgs e)
        {
            ShowFrmYZCX_MZ(_currentUserId, _currentDeptId, txtPatID.Text);
        }

        /// <summary>
        /// 医嘱账单录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYzlr_Click(object sender, System.EventArgs e)
        {
            ShowFrmYZGL(_currentUserId, _currentDeptId, txtPatID.Text);
        }

        private void pnl_2_SizeChanged(object sender, System.EventArgs e)
        {
            pnl_3.Left = (pnl_2.Width - pnl_3.Width) / 2;
            pnl_3.Top = (pnl_2.Height - pnl_3.Height) / 2;
        }

        private void bt_br_Click(object sender, System.EventArgs e)
        {
            if (rdbYjz.Checked) myDV = new DataView(GetPatList(this.dTimeP_CX.Value, _currentDeptId));
            else if (rdbYap.Checked) myDV = new DataView(GetYapList(this.dTimeP_CX.Value, _currentDeptId));
            else myDV = new DataView(GetYwcList(this.dTimeP_CX.Value, _currentDeptId));
            this.dGrid_Pat.DataSource = null;
            this.dGrid_Pat.DataSource = myDV;
            DelTextBoxFromDataGrid(dGrid_Pat);
        }

        private void dGrid_Pat_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myDV = (DataView)dGrid_Pat.DataSource;
            int nrow = dGrid_Pat.CurrentCell.RowNumber;
            dGrid_Pat.Select(nrow);
            for (int i = 0; i < myDV.Table.Rows.Count; i++)
            {
                myDV[i]["sel"] = 0;
            }
            myDV[nrow]["sel"] = 1;
            if (myDV.Table.Rows.Count > nrow && myDV.Table.Rows.Count != 0)
            {
                txtPatID.Text = myDV[nrow]["住院号"].ToString();
                pnl_2.Refresh();
            }
            else
            {
                txtPatID.Text = "";
            }
            dGrid_Pat.Refresh();
        }

        private void pnl_2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Random rd = new Random();
            System.Drawing.Brush brush = new SolidBrush(Color.Silver);
            System.Drawing.Pen pen = new Pen(brush);
            for (int x = 0; x <= rd.Next(6, 10); x++)
            {
                pen = new Pen(Color.Silver, rd.Next(0, 6));
                e.Graphics.DrawEllipse(pen, rd.Next(0, pnl_2.Width), rd.Next(0, pnl_2.Height), rd.Next(0, 100), rd.Next(0, 100));
                e.Graphics.FillEllipse(brush, rd.Next(0, pnl_2.Width), rd.Next(0, pnl_2.Height), rd.Next(0, 100), rd.Next(0, 100));
            }
            brush.Dispose();
            pen.Dispose();
        }

        private void frmBrcx_Load(object sender, EventArgs e)
        {
            if (type == 1)
                this.btnserch.Visible = true;
        }

        private void btnserch_Click(object sender, EventArgs e)
        {
            string iptid = Inpatient.GetInpatientNO();
            if (iptid == "" || iptid == Guid.Empty.ToString())
            {
                return;
            }
            else
            {
                this.txtPatID.Text = iptid.Trim();
            }
        }

        private void rdbYwc_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbYjz_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbYap_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
