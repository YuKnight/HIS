using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using YpClass;
using System.IO;
namespace ts_zyhs_jyddy
{
	/// <summary>
	/// 化验单打印 的摘要说明。
	/// </summary>
	public class frmjydqf : System.Windows.Forms.Form
	{

        //自定义变量
		private BaseFunc myFunc;
		private int nType=0;
        private TheReportDateSet rds = new TheReportDateSet();
        private System.Windows.Forms.Panel panel4;
        private GroupBox groupBox3;
        private RadioButton rdowdy;
        private RadioButton rdoydy;
        private Button btCancel;
        private Button btnfyqr;
        private Button btnRefresh;
        private Button button3;
        private Panel panel1;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private TextBox txtcwh;
        private Label label4;
        private Label label3;
        private TextBox txtzyh;
        private Panel panel2;
        private myDataGrid.myDataGrid myDataGrid1;
        private DataGridTableStyle dataGridTableStyle1;
        private DataGridTextBoxColumn 序号;
        private DataGridBoolColumn 选择;
        private DataGridTextBoxColumn 住院号;
        private DataGridTextBoxColumn 床号;
        private DataGridTextBoxColumn 姓名;
        private DataGridTextBoxColumn 性别;
        private DataGridTextBoxColumn 年龄;
        private DataGridTextBoxColumn 项目内容;
        private DataGridTextBoxColumn 诊断及病史;
        private DataGridTextBoxColumn 附加说明;
        private DataGridTextBoxColumn 标本类型;
        private DataGridTextBoxColumn 金额;
        private DataGridTextBoxColumn 执行科室;
        private DataGridTextBoxColumn 项目分类;
        private DataGridTextBoxColumn 申请日期;
        private DataGridTextBoxColumn 打印;
        private DataGridTextBoxColumn 申请医生;
        private DataGridTextBoxColumn 确认日期;
        private DataGridTextBoxColumn 确认人;
        private DataGridTextBoxColumn 条形码;
        private DataGridTextBoxColumn order_id;
        private DataGridTextBoxColumn lx;
        private DataGridTextBoxColumn 状态;
        private DataGridTextBoxColumn inpatient_id;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private DataGridTextBoxColumn 分组;
        private Label label5;
        private TextBox txtname;
        private RadioButton rdorq1;
        private RadioButton rdorq2;
        private Label label1;
        private TextBox txttxm;
        private RadioButton rdoall;
        private DataGridTextBoxColumn 病区;
        private PrintPreviewDialog printPreviewDialog1;
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")] 
        private static extern bool BitBlt(

            IntPtr hdcDest, //目的上下文设备的句柄 

            int nXDest, //目的图形的左上角的x坐标 

            int nYDest, //目的图形的左上角的y坐标 

            int nWidth, //目的图形的矩形宽度 

            int nHeight, //目的图形的矩形高度 

            IntPtr hdcSrc, //源上下文设备的句柄 

            int nXSrc, //源图形的左上角的x坐标 

            int nYSrc, //源图形的左上角的x坐标 

            System.Int32 dwRop //光栅操作代码 

            );
        public System.Drawing.Brush brush;
        public System.Drawing.Font font;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmjydqf(string _formText,int _type)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.Text=_formText;
			nType=_type;
			
			myFunc=new BaseFunc();
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmjydqf));
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.序号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.选择 = new System.Windows.Forms.DataGridBoolColumn();
            this.打印 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.病区 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.住院号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.床号 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.姓名 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.性别 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.年龄 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.条形码 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.项目内容 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.金额 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.执行科室 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.项目分类 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.标本类型 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.附加说明 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.申请日期 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.申请医生 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.确认日期 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.确认人 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.诊断及病史 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.order_id = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lx = new System.Windows.Forms.DataGridTextBoxColumn();
            this.inpatient_id = new System.Windows.Forms.DataGridTextBoxColumn();
            this.分组 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txttxm = new System.Windows.Forms.TextBox();
            this.rdorq1 = new System.Windows.Forms.RadioButton();
            this.rdorq2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtcwh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtzyh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoall = new System.Windows.Forms.RadioButton();
            this.rdowdy = new System.Windows.Forms.RadioButton();
            this.rdoydy = new System.Windows.Forms.RadioButton();
            this.btCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnfyqr = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(909, 557);
            this.panel4.TabIndex = 74;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(909, 451);
            this.panel2.TabIndex = 78;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(909, 451);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.序号,
            this.选择,
            this.打印,
            this.状态,
            this.病区,
            this.住院号,
            this.床号,
            this.姓名,
            this.性别,
            this.年龄,
            this.条形码,
            this.项目内容,
            this.金额,
            this.执行科室,
            this.项目分类,
            this.标本类型,
            this.附加说明,
            this.申请日期,
            this.申请医生,
            this.确认日期,
            this.确认人,
            this.诊断及病史,
            this.order_id,
            this.lx,
            this.inpatient_id,
            this.分组});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // 序号
            // 
            this.序号.Format = "";
            this.序号.FormatInfo = null;
            this.序号.HeaderText = "序号";
            this.序号.Width = 40;
            // 
            // 选择
            // 
            this.选择.FalseValue = ((short)(0));
            this.选择.HeaderText = "选择";
            this.选择.NullValue = ((short)(0));
            this.选择.TrueValue = ((short)(1));
            this.选择.Width = 30;
            // 
            // 打印
            // 
            this.打印.Format = "";
            this.打印.FormatInfo = null;
            this.打印.HeaderText = "打印";
            this.打印.Width = 35;
            // 
            // 状态
            // 
            this.状态.Format = "";
            this.状态.FormatInfo = null;
            this.状态.HeaderText = "状态";
            this.状态.Width = 50;
            // 
            // 病区
            // 
            this.病区.Format = "";
            this.病区.FormatInfo = null;
            this.病区.HeaderText = "病区";
            this.病区.Width = 75;
            // 
            // 住院号
            // 
            this.住院号.Format = "";
            this.住院号.FormatInfo = null;
            this.住院号.HeaderText = "住院号";
            this.住院号.Width = 65;
            // 
            // 床号
            // 
            this.床号.Format = "";
            this.床号.FormatInfo = null;
            this.床号.HeaderText = "床号";
            this.床号.Width = 40;
            // 
            // 姓名
            // 
            this.姓名.Format = "";
            this.姓名.FormatInfo = null;
            this.姓名.HeaderText = "姓名";
            this.姓名.Width = 50;
            // 
            // 性别
            // 
            this.性别.Format = "";
            this.性别.FormatInfo = null;
            this.性别.HeaderText = "性别";
            this.性别.Width = 0;
            // 
            // 年龄
            // 
            this.年龄.Format = "";
            this.年龄.FormatInfo = null;
            this.年龄.HeaderText = "年龄";
            this.年龄.Width = 0;
            // 
            // 条形码
            // 
            this.条形码.Format = "";
            this.条形码.FormatInfo = null;
            this.条形码.HeaderText = "条形码";
            this.条形码.Width = 85;
            // 
            // 项目内容
            // 
            this.项目内容.Format = "";
            this.项目内容.FormatInfo = null;
            this.项目内容.HeaderText = "项目内容";
            this.项目内容.Width = 150;
            // 
            // 金额
            // 
            this.金额.Format = "";
            this.金额.FormatInfo = null;
            this.金额.HeaderText = "金额";
            this.金额.Width = 55;
            // 
            // 执行科室
            // 
            this.执行科室.Format = "";
            this.执行科室.FormatInfo = null;
            this.执行科室.HeaderText = "执行科室";
            this.执行科室.Width = 0;
            // 
            // 项目分类
            // 
            this.项目分类.Format = "";
            this.项目分类.FormatInfo = null;
            this.项目分类.HeaderText = "项目分类";
            this.项目分类.Width = 0;
            // 
            // 标本类型
            // 
            this.标本类型.Format = "";
            this.标本类型.FormatInfo = null;
            this.标本类型.HeaderText = "标本类型";
            this.标本类型.Width = 60;
            // 
            // 附加说明
            // 
            this.附加说明.Format = "";
            this.附加说明.FormatInfo = null;
            this.附加说明.HeaderText = "附加说明";
            this.附加说明.Width = 75;
            // 
            // 申请日期
            // 
            this.申请日期.Format = "";
            this.申请日期.FormatInfo = null;
            this.申请日期.HeaderText = "申请日期";
            this.申请日期.Width = 75;
            // 
            // 申请医生
            // 
            this.申请医生.Format = "";
            this.申请医生.FormatInfo = null;
            this.申请医生.HeaderText = "申请医生";
            this.申请医生.Width = 50;
            // 
            // 确认日期
            // 
            this.确认日期.Format = "";
            this.确认日期.FormatInfo = null;
            this.确认日期.HeaderText = "确认日期";
            this.确认日期.Width = 75;
            // 
            // 确认人
            // 
            this.确认人.Format = "";
            this.确认人.FormatInfo = null;
            this.确认人.HeaderText = "确认人";
            this.确认人.Width = 50;
            // 
            // 诊断及病史
            // 
            this.诊断及病史.Format = "";
            this.诊断及病史.FormatInfo = null;
            this.诊断及病史.HeaderText = "诊断及病史";
            this.诊断及病史.Width = 120;
            // 
            // order_id
            // 
            this.order_id.Format = "";
            this.order_id.FormatInfo = null;
            this.order_id.HeaderText = "order_id";
            this.order_id.Width = 75;
            // 
            // lx
            // 
            this.lx.Format = "";
            this.lx.FormatInfo = null;
            this.lx.HeaderText = "lx";
            this.lx.Width = 75;
            // 
            // inpatient_id
            // 
            this.inpatient_id.Format = "";
            this.inpatient_id.FormatInfo = null;
            this.inpatient_id.HeaderText = "inpatient_id";
            this.inpatient_id.Width = 75;
            // 
            // 分组
            // 
            this.分组.Format = "";
            this.分组.FormatInfo = null;
            this.分组.HeaderText = "分组";
            this.分组.Width = 40;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txttxm);
            this.panel1.Controls.Add(this.rdorq1);
            this.panel1.Controls.Add(this.rdorq2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtname);
            this.panel1.Controls.Add(this.txtcwh);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtzyh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnfyqr);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 106);
            this.panel1.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 91;
            this.label1.Text = "条形码";
            // 
            // txttxm
            // 
            this.txttxm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttxm.Location = new System.Drawing.Point(55, 76);
            this.txttxm.Name = "txttxm";
            this.txttxm.Size = new System.Drawing.Size(336, 23);
            this.txttxm.TabIndex = 90;
            this.txttxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttxm_KeyPress);
            // 
            // rdorq1
            // 
            this.rdorq1.AutoSize = true;
            this.rdorq1.Location = new System.Drawing.Point(12, 15);
            this.rdorq1.Name = "rdorq1";
            this.rdorq1.Size = new System.Drawing.Size(71, 16);
            this.rdorq1.TabIndex = 89;
            this.rdorq1.Text = "确认日期";
            this.rdorq1.UseVisualStyleBackColor = true;
            this.rdorq1.CheckedChanged += new System.EventHandler(this.rdorq1_CheckedChanged);
            // 
            // rdorq2
            // 
            this.rdorq2.AutoSize = true;
            this.rdorq2.Checked = true;
            this.rdorq2.Location = new System.Drawing.Point(92, 15);
            this.rdorq2.Name = "rdorq2";
            this.rdorq2.Size = new System.Drawing.Size(71, 16);
            this.rdorq2.TabIndex = 88;
            this.rdorq2.TabStop = true;
            this.rdorq2.Text = "申请日期";
            this.rdorq2.UseVisualStyleBackColor = true;
            this.rdorq2.CheckedChanged += new System.EventHandler(this.rdorq1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 87;
            this.label5.Text = "姓名";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(191, 46);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(97, 21);
            this.txtname.TabIndex = 86;
            this.txtname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtname_KeyPress);
            // 
            // txtcwh
            // 
            this.txtcwh.Location = new System.Drawing.Point(326, 46);
            this.txtcwh.Name = "txtcwh";
            this.txtcwh.Size = new System.Drawing.Size(65, 21);
            this.txtcwh.TabIndex = 84;
            this.txtcwh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcwh_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 83;
            this.label4.Text = "床号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 82;
            this.label3.Text = "住院号";
            // 
            // txtzyh
            // 
            this.txtzyh.Location = new System.Drawing.Point(55, 46);
            this.txtzyh.Name = "txtzyh";
            this.txtzyh.Size = new System.Drawing.Size(97, 21);
            this.txtzyh.TabIndex = 81;
            this.txtzyh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtzyh_KeyPress);
            this.txtzyh.TextChanged += new System.EventHandler(this.txtzyh_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 80;
            this.label2.Text = "到";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(293, 13);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(98, 21);
            this.dateTimePicker2.TabIndex = 78;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(172, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(98, 21);
            this.dateTimePicker1.TabIndex = 77;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rdoall);
            this.groupBox3.Controls.Add(this.rdowdy);
            this.groupBox3.Controls.Add(this.rdoydy);
            this.groupBox3.Location = new System.Drawing.Point(411, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 49);
            this.groupBox3.TabIndex = 76;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择类型";
            // 
            // rdoall
            // 
            this.rdoall.Location = new System.Drawing.Point(9, 18);
            this.rdoall.Name = "rdoall";
            this.rdoall.Size = new System.Drawing.Size(59, 16);
            this.rdoall.TabIndex = 3;
            this.rdoall.Text = "全部";
            this.rdoall.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdoall.Visible = false;
            this.rdoall.CheckedChanged += new System.EventHandler(this.rdorq1_CheckedChanged);
            // 
            // rdowdy
            // 
            this.rdowdy.Checked = true;
            this.rdowdy.Location = new System.Drawing.Point(68, 18);
            this.rdowdy.Name = "rdowdy";
            this.rdowdy.Size = new System.Drawing.Size(88, 16);
            this.rdowdy.TabIndex = 2;
            this.rdowdy.TabStop = true;
            this.rdowdy.Text = "选择未确费";
            this.rdowdy.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdowdy.CheckedChanged += new System.EventHandler(this.rdorq1_CheckedChanged);
            // 
            // rdoydy
            // 
            this.rdoydy.Location = new System.Drawing.Point(162, 18);
            this.rdoydy.Name = "rdoydy";
            this.rdoydy.Size = new System.Drawing.Size(88, 16);
            this.rdoydy.TabIndex = 1;
            this.rdoydy.Text = "选择已确费";
            this.rdoydy.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdoydy.CheckedChanged += new System.EventHandler(this.rdorq1_CheckedChanged);
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
            this.btCancel.Location = new System.Drawing.Point(829, 31);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(64, 32);
            this.btCancel.TabIndex = 72;
            this.btCancel.Text = "退出(&E)";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.Location = new System.Drawing.Point(687, 31);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 32);
            this.btnRefresh.TabIndex = 74;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnfyqr
            // 
            this.btnfyqr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnfyqr.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnfyqr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfyqr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfyqr.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnfyqr.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnfyqr.ImageIndex = 0;
            this.btnfyqr.Location = new System.Drawing.Point(757, 31);
            this.btnfyqr.Name = "btnfyqr";
            this.btnfyqr.Size = new System.Drawing.Size(64, 32);
            this.btnfyqr.TabIndex = 71;
            this.btnfyqr.Text = "确费(&P)";
            this.btnfyqr.UseVisualStyleBackColor = false;
            this.btnfyqr.Click += new System.EventHandler(this.btnfyqr_Click);
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
            this.button3.Location = new System.Drawing.Point(679, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(224, 49);
            this.button3.TabIndex = 73;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmjydqf
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(909, 557);
            this.Controls.Add(this.panel4);
            this.Name = "frmjydqf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "检验单费用确认";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmjyd_Load);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private void frmjyd_Load(object sender, EventArgs e)
        {
            //初始化
            FunBase.CsDataGrid(this.myDataGrid1, this.myDataGrid1.TableStyles[0], "Tb");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[12];
                parameters[0].Value = 0;
                parameters[1].Value = InstanceForm.BCurrentDept.WardId.Trim();
                parameters[2].Value = rdorq1.Checked==true?"": this.dateTimePicker1.Value.ToShortDateString() + " 00:00:01";
                parameters[3].Value = rdorq1.Checked == true ? "" : this.dateTimePicker2.Value.ToShortDateString() + " 23:59:59";
                int bprint = 8;
                if (rdowdy.Checked == true) bprint = 3;
                if (rdoydy.Checked == true) bprint = 4;
                parameters[4].Value = bprint;
                parameters[5].Value = txtzyh.Text.Trim();
                parameters[6].Value = txtcwh.Text.Trim();
                parameters[7].Value = txtname.Text.Trim();
                parameters[8].Value = txttxm.Text.Trim();
                parameters[9].Value = rdorq1.Checked == false ? "" : this.dateTimePicker1.Value.ToShortDateString() + " 00:00:01";
                parameters[10].Value = rdorq1.Checked == false ? "" : this.dateTimePicker2.Value.ToShortDateString() + " 23:59:59";
                parameters[11].Value = InstanceForm.BCurrentDept.DeptId;

                parameters[0].Text = "@lx";
                parameters[1].Text = "@wardid";
                parameters[2].Text = "@sqrq1";
                parameters[3].Text = "@sqrq2";
                parameters[4].Text = "@dybz";
                parameters[5].Text = "@zyh";
                parameters[6].Text = "@cwh";
                parameters[7].Text = "@name";
                parameters[8].Text = "@txm";
                parameters[9].Text = "@qrrq1";
                parameters[10].Text = "@qrrq2";
                parameters[11].Text = "@zxks";
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_zyhs_getjchy", parameters, 30);
                FunBase.AddRowtNo(tb);
                tb.TableName = "Tb";
                //if (rdorq2.Checked == true)
                //{
                //    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                //        tb.Rows[i]["选择"] = (short)1;
                //}
                this.myDataGrid1.DataSource = tb;
                FunBase.myGridSelect(this.myDataGrid1, this.myDataGrid1.TableStyles[0].GridColumnStyles);
                //if (rdowdy.Checked == true && tb.Rows.Count != 0)
                //{
                //    if (MessageBox.Show("您要确认该费用吗？", "询问窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                //    {
                //        this.btnfyqr_Click(sender, e);
                //        txttxm.Focus();
                //        txttxm.SelectAll();
                //    }
                //}

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }



        private void myDataGrid1_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            if (tb.Rows.Count == 0) return;
            if (tb.Rows[nrow]["状态"].ToString().Trim() == "作废") return;
            if (rdorq1.Checked==true) return;
            //DataRow[] selrow = tb.Select("条形码='"+tb.Rows[nrow]["条形码"].ToString().Trim()+"'");
            string txm = tb.Rows[nrow]["条形码"].ToString().Trim();
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (tb.Rows[i]["条形码"].ToString().Trim() == txm )
                {
                    if (Convert.ToBoolean(tb.Rows[i]["选择"]) == false)
                       tb.Rows[i]["选择"] = (short)1;
                    else
                       tb.Rows[i]["选择"] = (short)0;
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void txtzyh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                txtzyh.Text=FunBase.returnZyh(txtzyh.Text.Trim());
                this.btnRefresh_Click(sender, e);
            }
        }

        private void txtcwh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                this.btnRefresh_Click(sender, e);
            }
        }

        private void txtzyh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                this.btnRefresh_Click(sender, e);
            }
        }

        //费用确认
        private void btnfyqr_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] selrow = tb.Select(" 选择=true");

            string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                for (int i = 0; i <= selrow.Length - 1; i++)
                {
                    string ssql = "update YJ_ZYSQ set BJSBZ=1,jssj='" + sDate + "',jsr=" + InstanceForm.BCurrentUser.EmployeeId + " where yzid='" + new Guid(selrow[i]["order_id"].ToString()) + "' and bjsbz=0 and bscbz=0";
                    int n = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(ssql, 30);
                    if (n == 0)
                        throw new Exception("没有更新到申请数据，请刷新数据");

                    ssql = "update zy_fee_speci set charge_bit=1,charge_date='" + sDate + "',charge_user=" + InstanceForm.BCurrentUser.EmployeeId + " where order_id=" + Convert.ToInt64(selrow[i]["order_id"]) + " and charge_bit=0 and delete_bit=0";
                    n = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(ssql, 30);
                    if (n == 0)
                        throw new Exception("没有更新到费用数据，请刷新数据");

                    ssql = "update zy_prescription set charge_bit=1  where order_id=" + Convert.ToInt64(selrow[i]["order_id"]) + " and charge_bit=0 ";
                    n = TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(ssql, 30);
                    if (n == 0)
                        throw new Exception("没有更新到处方数据，请刷新数据");
                }
                for (int i = 0; i <= selrow.Length - 1; i++)
                    tb.Rows.Remove(selrow[i]);

                InstanceForm.BDatabase.CommitTransaction();
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void rdorq1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
        }

        private void txttxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                string txm = txttxm.Text.Trim();
                if (Convertor.IsNumeric(txm) == true)
                {
                    decimal tm = Convert.ToDecimal(txm);
                    txttxm.Text = tm.ToString("000000000");
                    btnRefresh_Click(sender, e);
                    txttxm.Focus();
                    txttxm.SelectAll();
                }
            }
        }


    }
}
