using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using Ts_ss_class;
using Ts_zyys_public;

namespace Ts_zyys_ssgl
{
    /// <summary>
    /// 手术查询 的摘要说明。
    /// </summary>
    public class FrmSSQuery : System.Windows.Forms.Form
    {
        public long deptID = 0;
        public long lg = 0;//权限
        public long YS_ID = 0;
        public System.Data.OleDb.OleDbConnection cCon = new System.Data.OleDb.OleDbConnection();
        private DbQuery myQuery = new DbQuery();
        private long Ward_DeptID = 0;
        public static User Current_User;
        public static Department Current_Dept;			///系统当前登录的部门

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtprq1;
        private System.Windows.Forms.DateTimePicker dtprq2;
        private System.Windows.Forms.RadioButton optyap;
        private System.Windows.Forms.RadioButton optwap;
        private System.Windows.Forms.RadioButton optqxap;
        private System.Windows.Forms.Button bview;
        private System.Windows.Forms.RadioButton optywc;
        private System.Windows.Forms.RadioButton optysh;
        private System.Windows.Forms.RadioButton optJZ;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
        private System.ComponentModel.IContainer components;

        public FrmSSQuery(long currentUser, long currentDept, string formText, object[] _value)
        {
            InitializeComponent();

            Current_User = new User(Convert.ToInt32(currentUser), FrmMdiMain.Database);

            YS_ID = Current_User.EmployeeId;
            //			InstanceForm._database.Close();

            deptID = Convert.ToInt32(currentDept); ;
            lg = Convert.ToInt64(Convertor.IsNull(_value[5], "0"));
        }
        //手术安排查询
        public FrmSSQuery(long currentUser, long currentDept, string formText)
        {
            InitializeComponent();


            Current_Dept = new Department(Convert.ToInt32(currentDept), FrmMdiMain.Database);
            Ward_DeptID = Current_Dept.DeptId;
            //			InstanceForm._database.Close();

            this.Text = formText;
            label1.Text = "安排时间";
            optwap.Enabled = false;
            optysh.Enabled = false;
            optJZ.Enabled = false;
            optqxap.Enabled = false;
            optywc.Enabled = false;
            optyap.Checked = true;
            lg = 1;
        }

        public FrmSSQuery()
        {
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSSQuery));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optywc = new System.Windows.Forms.RadioButton();
            this.optqxap = new System.Windows.Forms.RadioButton();
            this.optyap = new System.Windows.Forms.RadioButton();
            this.optJZ = new System.Windows.Forms.RadioButton();
            this.optysh = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bview = new System.Windows.Forms.Button();
            this.optwap = new System.Windows.Forms.RadioButton();
            this.dtprq2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtprq1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
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
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optywc);
            this.groupBox1.Controls.Add(this.optqxap);
            this.groupBox1.Controls.Add(this.optyap);
            this.groupBox1.Controls.Add(this.optJZ);
            this.groupBox1.Controls.Add(this.optysh);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.bview);
            this.groupBox1.Controls.Add(this.optwap);
            this.groupBox1.Controls.Add(this.dtprq2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtprq1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 69);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // optywc
            // 
            this.optywc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.optywc.Location = new System.Drawing.Point(668, 28);
            this.optywc.Name = "optywc";
            this.optywc.Size = new System.Drawing.Size(66, 24);
            this.optywc.TabIndex = 10;
            this.optywc.Text = "已完成";
            this.optywc.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optqxap
            // 
            this.optqxap.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.optqxap.Location = new System.Drawing.Point(602, 28);
            this.optqxap.Name = "optqxap";
            this.optqxap.Size = new System.Drawing.Size(66, 24);
            this.optqxap.TabIndex = 6;
            this.optqxap.Text = "已取消";
            this.optqxap.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optyap
            // 
            this.optyap.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.optyap.Location = new System.Drawing.Point(536, 28);
            this.optyap.Name = "optyap";
            this.optyap.Size = new System.Drawing.Size(66, 24);
            this.optyap.TabIndex = 4;
            this.optyap.Text = "已安排";
            this.optyap.CheckedChanged += new System.EventHandler(this.opt_CheckedChanged);
            // 
            // optJZ
            // 
            this.optJZ.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.optJZ.Location = new System.Drawing.Point(456, 28);
            this.optJZ.Name = "optJZ";
            this.optJZ.Size = new System.Drawing.Size(80, 24);
            this.optJZ.TabIndex = 12;
            this.optJZ.Text = "急诊手术";
            this.optJZ.CheckedChanged += new System.EventHandler(this.optwap_CheckedChanged);
            // 
            // optysh
            // 
            this.optysh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.optysh.Location = new System.Drawing.Point(390, 28);
            this.optysh.Name = "optysh";
            this.optysh.Size = new System.Drawing.Size(66, 24);
            this.optysh.TabIndex = 11;
            this.optysh.Text = "已审核";
            this.optysh.CheckedChanged += new System.EventHandler(this.optysh_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.Navy;
            this.button3.Location = new System.Drawing.Point(905, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 28);
            this.button3.TabIndex = 9;
            this.button3.Text = "退出";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Navy;
            this.button2.Location = new System.Drawing.Point(828, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "取消申请";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bview
            // 
            this.bview.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bview.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bview.Location = new System.Drawing.Point(743, 24);
            this.bview.Name = "bview";
            this.bview.Size = new System.Drawing.Size(82, 28);
            this.bview.TabIndex = 7;
            this.bview.Text = "刷新(&F)";
            this.bview.UseVisualStyleBackColor = false;
            this.bview.Click += new System.EventHandler(this.bview_Click);
            // 
            // optwap
            // 
            this.optwap.Checked = true;
            this.optwap.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.optwap.Location = new System.Drawing.Point(324, 28);
            this.optwap.Name = "optwap";
            this.optwap.Size = new System.Drawing.Size(66, 24);
            this.optwap.TabIndex = 5;
            this.optwap.TabStop = true;
            this.optwap.Text = "未审核";
            this.optwap.CheckedChanged += new System.EventHandler(this.optwap_CheckedChanged);
            // 
            // dtprq2
            // 
            this.dtprq2.Location = new System.Drawing.Point(200, 27);
            this.dtprq2.Name = "dtprq2";
            this.dtprq2.Size = new System.Drawing.Size(118, 23);
            this.dtprq2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(183, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "到";
            // 
            // dtprq1
            // 
            this.dtprq1.Location = new System.Drawing.Point(64, 27);
            this.dtprq1.Name = "dtprq1";
            this.dtprq1.Size = new System.Drawing.Size(120, 23);
            this.dtprq1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "申请日期";
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 69);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.RowHeaderWidth = 25;
            this.myDataGrid1.Size = new System.Drawing.Size(984, 392);
            this.myDataGrid1.TabIndex = 4;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.DoubleClick += new System.EventHandler(this.myDataGrid1_DoubleClick);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.LightYellow;
            this.dataGridTableStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "住院号";
            this.dataGridTextBoxColumn17.MappingName = "住院号";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.Width = 55;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "床号";
            this.dataGridTextBoxColumn18.MappingName = "床号";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.Width = 40;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "姓名";
            this.dataGridTextBoxColumn1.MappingName = "姓名";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 55;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "性别";
            this.dataGridTextBoxColumn2.MappingName = "性别";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 35;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "术前诊断";
            this.dataGridTextBoxColumn3.MappingName = "术前诊断";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 150;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "拟施手术";
            this.dataGridTextBoxColumn4.MappingName = "拟施手术";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 170;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "主刀";
            this.dataGridTextBoxColumn5.MappingName = "主刀";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 55;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "拟施麻醉";
            this.dataGridTextBoxColumn6.MappingName = "拟施麻醉";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 90;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "麻醉师";
            this.dataGridTextBoxColumn7.MappingName = "麻醉师";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 55;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "拟施时间";
            this.dataGridTextBoxColumn8.MappingName = "拟施时间";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 80;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "申请医生";
            this.dataGridTextBoxColumn11.MappingName = "申请医生";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 55;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "申请时间";
            this.dataGridTextBoxColumn12.MappingName = "申请时间";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.Width = 80;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "手术间";
            this.dataGridTextBoxColumn16.MappingName = "手术间";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.Width = 45;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "安排时间";
            this.dataGridTextBoxColumn13.MappingName = "安排时间";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 105;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "完成时间";
            this.dataGridTextBoxColumn14.MappingName = "完成时间";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.Width = 80;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "审核人";
            this.dataGridTextBoxColumn15.MappingName = "审核人";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 60;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "手术同意书";
            this.dataGridTextBoxColumn9.MappingName = "手术同意书";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 70;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "麻醉同意书";
            this.dataGridTextBoxColumn10.MappingName = "麻醉同意书";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 70;
            // 
            // FrmSSQuery
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.myDataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSSQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手术查询";
            this.Load += new System.EventHandler(this.FrmSSQuery_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void bview_Click(object sender, System.EventArgs e)
        {
            //			string ssql;
            DataTable myTb = new DataTable();
            if (this.optwap.Checked == true) //未审核
            {
                myTb = myQuery.SSapp(deptID, dtprq1.Value.Date, dtprq2.Value.Date, 1);
            }
            if (this.optysh.Checked == true) //已审核
            {
                myTb = myQuery.SSapp(deptID, dtprq1.Value.Date, dtprq2.Value.Date, 5);
            }
            if (this.optJZ.Checked == true) //急诊手术
            {
                myTb = myQuery.SSapp(deptID, dtprq1.Value.Date, dtprq2.Value.Date, 6);
            }
            if (this.optyap.Checked == true) //已安排
            {
                //				ssql="select * from ss_apprecord where apbj=1 and bdelete=0  and date(sqdjrq)>='"+dtprq1.Value.ToShortDateString()+"' and date(sqdjrq)<='"+dtprq2.Value.ToShortDateString()+"' and deptid="+PubFunction.AuserDeptID+" and sno in(select sno from ss_arrrecord where wcbj=0) ";
                //				AddData(ssql);
                if (this.label1.Text == "安排时间")
                {
                    myTb = myQuery.SSapp(Ward_DeptID, dtprq1.Value.Date, dtprq2.Value.Date, 7);
                }
                else
                {
                    myTb = myQuery.SSapp(deptID, dtprq1.Value.Date, dtprq2.Value.Date, 2);
                }
            }
            if (this.optqxap.Checked == true)//已取消
            {
                //				ssql="select * from ss_apprecord where   date(sqdjrq)>='"+dtprq1.Value.ToShortDateString()+"' and date(sqdjrq)<='"+dtprq2.Value.ToShortDateString()+"' and deptid="+PubFunction.AuserDeptID+" and sno in(select sno from ss_arrrecord where  bdelete=1)";
                //				AddData(ssql);
                myTb = myQuery.SSapp(deptID, dtprq1.Value.Date, dtprq2.Value.Date, 3);
            }
            if (this.optywc.Checked == true) //已完成
            {
                //				ssql="select * from ss_apprecord where  bdelete=0  and date(sqdjrq)>='"+dtprq1.Value.ToShortDateString()+"' and date(sqdjrq)<='"+dtprq2.Value.ToShortDateString()+"' and deptid="+PubFunction.AuserDeptID+" and sno in(select sno from ss_arrrecord where wcbj=1)";
                //				AddData(ssql);
                myTb = myQuery.SSapp(deptID, dtprq1.Value.Date, dtprq2.Value.Date, 4);
            }

            this.myDataGrid1.DataSource = myTb;
            if (myTb.Rows.Count == 0)
            {
                button2.Enabled = false;
                return;
            }
            if (myTb.Rows.Count > 0) DelDataGridTextBox(myDataGrid1);

        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (this.lg == 0 || this.lg == 4) return;
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb.Rows.Count == 0)
            {
                MessageBox.Show("请选择要取消的手术申请", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string str = myTb.Rows[this.myDataGrid1.CurrentRowIndex]["sno"].ToString().Trim();
            string _inpatient_no = myTb.Rows[this.myDataGrid1.CurrentRowIndex]["inpatient_no"].ToString().Trim();

            if (this.button2.Text == "取消申请")
            {
               
                if (!(myTb.Rows[this.myDataGrid1.CurrentRowIndex]["sqdjczy"].ToString() == this.YS_ID.ToString() || this.lg == 3))
                {
                    MessageBox.Show("不是你申请的手术！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("您确认要取消当前选定的手术申请吗?", "取消手术申请", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Operate ss = new Operate();

                    if (ss.CancelApp(str, _inpatient_no) == true)
                    {
                        MessageBox.Show("取消成功", "取消手术申请", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    bview_Click(sender, e);
                }
            }
            else
            {
                //add by zouchihua 2013-8-27 特殊手术审核
                if (myTb.Rows[this.myDataGrid1.CurrentRowIndex]["tsss_shsj"].ToString() != "")
                {
                    MessageBox.Show("特殊手术已经被上级审核，需要取消特殊手术审核后才能取消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("您确认要取消审核当前选定的手术申请吗?", "取消审核手术申请", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CancelSH(str) == true)
                    {
                        MessageBox.Show("取消审核成功！", "取消审核", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    bview_Click(sender, e);
                }
            }
        }

        private bool CancelSH(string sno)
        {
            string sSql = "update ss_apprecord set shbj=0 where sno='" + sno + "' and deptid=" + this.deptID + "";
            int i = InstanceForm._database.DoCommand(sSql);
            if (i != -1) return true;
            else
            {
                MessageBox.Show("取消审核失败！", "取消审核失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void optwap_CheckedChanged(object sender, System.EventArgs e)
        {
            if (optwap.Checked == true || optJZ.Checked == true)
            {
                this.button2.Enabled = true;
                this.button2.Text = "取消申请";
                this.myDataGrid1.DataSource = null;
            }
            else this.button2.Enabled = false;

        }
        private void optysh_CheckedChanged(object sender, System.EventArgs e)
        {
            if (optysh.Checked == true && lg == 3) //主任才能取消审核
            {
                if (optysh.Checked == true)
                {
                    this.button2.Enabled = true;
                    this.button2.Text = "取消审核";
                }
                else this.button2.Enabled = false;
            }
            else this.button2.Enabled = false;
            this.myDataGrid1.DataSource = null;
        }
        private void opt_CheckedChanged(object sender, System.EventArgs e)
        {
            RadioButton RB = (RadioButton)sender;
            this.myDataGrid1.DataSource = null;
        }

        private void FrmSSQuery_Load(object sender, System.EventArgs e)
        {
            //			this.Text=PubFunction.sys_date();
            //			dtprq1.Value=Convert.ToDateTime(PubFunction.sys_date());			
            DateTime dt = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
            dtprq1.Value = dt;
            dtprq2.Value = dtprq1.Value;
            DataTable myTb = null;
            if (this.label1.Text == "安排时间")
            {
                myTb = myQuery.SSapp(Ward_DeptID, dtprq1.Value.Date, dtprq2.Value.Date, 7);
            }
            else
            {
                myTb = myQuery.SSapp(deptID, dtprq1.Value.Date, dtprq2.Value.Date, 1);
            }
            this.myDataGrid1.DataSource = myTb;
            if (myTb.Rows.Count > 0) DelDataGridTextBox(myDataGrid1);

            //			this.Text=PubFunction.sys_date();
        }

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            if (this.myDataGrid1.VisibleRowCount > 0) this.myDataGrid1.Select(this.myDataGrid1.CurrentRowIndex);
            //			myDataGrid1_DoubleClick(sender,e);

        }

        private void myDataGrid1_DoubleClick(object sender, System.EventArgs e)
        {
            if (!(lg == 3 || lg == 0)) return;//不是主任，退出
            if (this.optwap.Checked == false) return;//不是未审核的就退出 
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb.Rows.Count == 0) return;

            FrmSSApply ss = new FrmSSApply();
            ss.BinID = new Guid(myTb.Rows[this.myDataGrid1.CurrentRowIndex]["inpatient_id"].ToString());
            ss.sInpatient_no = myTb.Rows[this.myDataGrid1.CurrentRowIndex]["inpatient_no"].ToString();
            ss.DeptID = this.deptID;
            ss.YS_ID = this.YS_ID;
            ss.btSH.Visible = true;
            ss.Bsave.Enabled = false;
            ss.lg = this.lg;
            ss.ShowDialog();

            bview_Click(sender, e);
        }
        #region 清除DataGrid中的TextBox
        private void DelDataGridTextBox(DataGridEx dg)
        {
            System.Windows.Forms.DataGridTextBoxColumn dgtb = null;
            for (int i = 0; i < dg.TableStyles[0].GridColumnStyles.Count; i++)
            {
                dgtb = (DataGridTextBoxColumn)dg.TableStyles[0].GridColumnStyles[i];
                dgtb.TextBox.Parent.Controls.Remove(dgtb.TextBox);
            }
        }
        #endregion
    }
}
