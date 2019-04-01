using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using YpClass;
using ts_mz_class;
using TrasenFrame.Forms;

namespace ts_yf_cx
{
	/// <summary>
	/// Frmcffy 的摘要说明。
	/// </summary>
	public class Frmzycfcx : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
        private Form _mdiParent;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel17;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.Button butexcelMx;
		private System.Windows.Forms.Button butcfcx;
		private System.Windows.Forms.RadioButton rdols;
        private System.Windows.Forms.RadioButton rdodq;
		private System.Windows.Forms.DateTimePicker dtprq2;
		private System.Windows.Forms.DateTimePicker dtprq1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtzyh;
		private YpConfig s;
        private string IPAddRess;
        public string _Fyckh;
        private TextBox _textBox;
        private Panel panel4;
        private Label lblfyrq;
        private CheckBox chkrsyp;
        private CheckBox chkwyyp;
        private CheckBox chkpsyp;
        private CheckBox chkcfyp;
        private CheckBox chkdjyp;
        private CheckBox chkmzyp;
        private CheckBox chkgzyp;
        private CheckBox chkjsyp;
        private ComboBox cmbyjks;
        private Label label16;
        private CheckBox chkkss;
        private Button buthelp;
        private ImageList imageList2;
        private ComboBox cmbbs1;
        private Label label1;
        private TextBox txtmb;
        private Label label6;
        private TextBox txtdm;
        private Label label4;
        private TextBox txtfyr;
        private Label label7;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button butexcelHz;
        private RadioButton rdoyfy;
        private RadioButton rdowfy;
        private ButtonDataGridEx myDataGrid1;
        private DataGridEx myDataGrid2;
        private bool  _ClickQuit=false;
        private DataGridTableStyle dataGridTableStyle1;
        private RadioButton rdoall;
        private DataGridTableStyle dataGridTableStyle2;

        public Frmzycfcx(MenuTag menuTag, string chineseName, Form mdiParent)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text =chineseName;

            Yp.AddcmbWardDept(cmbbs1, 1,0, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
            Yp.AddcmbYjks(true,cmbyjks,DeptType.药房,InstanceForm.BDatabase,InstanceForm._menuTag.Jgbm);

            cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId.ToString();
            if (cmbyjks.SelectedIndex == -1)
                cmbyjks.SelectedIndex = 0; ;

            CshMxGrid(this.myDataGrid1);
            CshHzGrid(this.myDataGrid2);

            this.dtprq1.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString()+" 00:00:00");
            this.dtprq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString()+" 23:59:59");


		}

        private void CshMxGrid(TrasenClasses.GeneralControls.ButtonDataGridEx xcjwDataGrid)
        {
            #region 添加明细的列
            string[] HeaderText ={ "序号", "领药科室","类型", "床号", "姓名", "住院号", "性别", "年龄", "剂型", "品名", "商品名", "规格", "厂家", "单价", "库存数", "数量", "剂数", "单位", "金额", "货号", "执行科室","处方日期", "记费日期", "记费员", "发药日期", "发药员","处方号","ypsl"};
            string[] MappingName ={ "序号", "领药科室", "类型", "床号", "姓名", "住院号", "性别", "年龄", "剂型", "品名", "商品名", "规格", "厂家", "单价", "库存数", "数量", "剂数", "单位", "金额", "货号", "执行科室", "处方日期", "记费日期", "记费员", "发药日期", "发药员", "处方号","ypsl" };
            int[] ColWidth ={ 30,80, 45, 35, 60, 75, 0, 0, 60, 100, 0, 80, 70, 55, 55, 50, 35, 35, 60, 50,80, 110, 110, 55, 110, 55, 110,0};
            bool[] ColReadOnly ={true,true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true,true,true};
            bool[] ColBool ={ false,false,false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,false,false};
            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbmx";

            for (int j = 0; j <= HeaderText.Length - 1; j++)
            {
                //DataGridEnableBoolColumn
                if (ColBool[j] == false)
                {
                    DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(j);
                    colText.HeaderText = HeaderText[j];
                    colText.MappingName = MappingName[j];
                    colText.Width = ColWidth[j];
                    colText.NullText = "";
                    colText.ReadOnly = ColReadOnly[j];
                    colText.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(colText_CheckCellEnabled);

                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    DataColumn datacol;
                    if (MappingName[j].Trim() == "ypsl" || MappingName[j] == "金额")
                        datacol = new DataColumn(MappingName[j], Type.GetType("System.Decimal"));
                    else
                        datacol = new DataColumn(MappingName[j]);

                    dtTmp.Columns.Add(datacol);
                }
                else
                {
                    DataGridButtonColumn btnCol = new DataGridButtonColumn(j);
                    btnCol.HeaderText = HeaderText[j];
                    btnCol.MappingName = MappingName[j];
                    btnCol.Width = ColWidth[j];


                    btnCol.CellButtonClicked += new DataGridCellButtonClickEventHandler(btnCol_CellButtonClicked);
                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);

                    this.myDataGrid1.MouseDown += new MouseEventHandler(btnCol.HandleMouseDown);
                    this.myDataGrid1.MouseUp += new MouseEventHandler(btnCol.HandleMouseUp);

                    DataColumn datacol;
                    datacol = new DataColumn(MappingName[j]);
                    dtTmp.Columns.Add(datacol);

                }

            }

            xcjwDataGrid.DataSource = dtTmp;
            xcjwDataGrid.TableStyles[0].MappingName = "tbmx";

            //if (ss.网络内容显示商品名 == true)
            //    xcjwDataGrid.TableStyles[0].GridColumnStyles["商品名"].Width = 100;
            //else
            //    xcjwDataGrid.TableStyles[0].GridColumnStyles["商品名"].Width = 0;

            #endregion

        }

        void btnCol_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
        {
            
        }

        void colText_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }


        private void CshHzGrid(TrasenClasses.GeneralControls.DataGridEx xcjwDataGrid)
        {
            #region 添加汇总的列
            string[] HeaderText ={ "序号", "领药科室","剂型", "品名", "商品名", "规格", "厂家", "单价", "领药数", "单位", "药库单位", "金额", "货号" };
            string[] MappingName ={ "序号", "领药科室","剂型", "品名", "商品名", "规格", "厂家", "单价", "领药数", "单位", "药库单位", "金额", "货号" };
            int[] ColWidth ={ 35,100, 70, 110, 110, 100, 80, 60, 65, 40, 70, 70, 60 };
            bool[] ColReadOnly ={ true, true, true, true, true, true, true, true, true, true, true, true, true };

            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbhz";

            for (int j = 0; j <= HeaderText.Length - 1; j++)
            {

                DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(j);
                colText.HeaderText = HeaderText[j];
                colText.MappingName = MappingName[j];
                colText.Width = ColWidth[j];
                colText.NullText = "";
                colText.ReadOnly = ColReadOnly[j];
                colText.CheckCellEnabled+=new DataGridEnableTextBoxColumn.EnableCellEventHandler(colText_CheckCellEnabled);
                xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                DataColumn datacol;
                if (MappingName[j].Trim() == "ypsl" || MappingName[j] == "金额")
                    datacol = new DataColumn(MappingName[j], Type.GetType("System.Decimal"));
                else
                    datacol = new DataColumn(MappingName[j]);

                dtTmp.Columns.Add(datacol);
            }

            xcjwDataGrid.DataSource = dtTmp;
            xcjwDataGrid.TableStyles[0].MappingName = "tbhz";
            #endregion

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmzycfcx));
            this.dtprq2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtprq1 = new System.Windows.Forms.DateTimePicker();
            this.rdols = new System.Windows.Forms.RadioButton();
            this.rdodq = new System.Windows.Forms.RadioButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtfyr = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtmb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdm = new System.Windows.Forms.TextBox();
            this.cmbbs1 = new System.Windows.Forms.ComboBox();
            this.buthelp = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.chkkss = new System.Windows.Forms.CheckBox();
            this.chkrsyp = new System.Windows.Forms.CheckBox();
            this.chkcfyp = new System.Windows.Forms.CheckBox();
            this.butcfcx = new System.Windows.Forms.Button();
            this.txtzyh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.lblfyrq = new System.Windows.Forms.Label();
            this.chkpsyp = new System.Windows.Forms.CheckBox();
            this.chkdjyp = new System.Windows.Forms.CheckBox();
            this.chkmzyp = new System.Windows.Forms.CheckBox();
            this.chkwyyp = new System.Windows.Forms.CheckBox();
            this.chkgzyp = new System.Windows.Forms.CheckBox();
            this.chkjsyp = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.butexcelHz = new System.Windows.Forms.Button();
            this.rdoyfy = new System.Windows.Forms.RadioButton();
            this.rdowfy = new System.Windows.Forms.RadioButton();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoall = new System.Windows.Forms.RadioButton();
            this.butexcelMx = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // dtprq2
            // 
            this.dtprq2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtprq2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtprq2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtprq2.Location = new System.Drawing.Point(455, 8);
            this.dtprq2.Name = "dtprq2";
            this.dtprq2.Size = new System.Drawing.Size(157, 23);
            this.dtprq2.TabIndex = 2;
            this.dtprq2.ValueChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(434, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "到";
            // 
            // dtprq1
            // 
            this.dtprq1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtprq1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtprq1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtprq1.Location = new System.Drawing.Point(276, 8);
            this.dtprq1.Name = "dtprq1";
            this.dtprq1.Size = new System.Drawing.Size(157, 23);
            this.dtprq1.TabIndex = 1;
            this.dtprq1.ValueChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // rdols
            // 
            this.rdols.ForeColor = System.Drawing.Color.Black;
            this.rdols.Location = new System.Drawing.Point(63, 8);
            this.rdols.Name = "rdols";
            this.rdols.Size = new System.Drawing.Size(58, 24);
            this.rdols.TabIndex = 11;
            this.rdols.Text = "历史";
            this.rdols.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // rdodq
            // 
            this.rdodq.Checked = true;
            this.rdodq.ForeColor = System.Drawing.Color.Black;
            this.rdodq.Location = new System.Drawing.Point(7, 8);
            this.rdodq.Name = "rdodq";
            this.rdodq.Size = new System.Drawing.Size(58, 24);
            this.rdodq.TabIndex = 10;
            this.rdodq.TabStop = true;
            this.rdodq.Text = "当前";
            this.rdodq.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(982, 3);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.txtfyr);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.txtmb);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.txtdm);
            this.panel8.Controls.Add(this.cmbbs1);
            this.panel8.Controls.Add(this.buthelp);
            this.panel8.Controls.Add(this.chkkss);
            this.panel8.Controls.Add(this.chkrsyp);
            this.panel8.Controls.Add(this.chkcfyp);
            this.panel8.Controls.Add(this.butcfcx);
            this.panel8.Controls.Add(this.txtzyh);
            this.panel8.Controls.Add(this.dtprq1);
            this.panel8.Controls.Add(this.dtprq2);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.butquit);
            this.panel8.Controls.Add(this.lblfyrq);
            this.panel8.Controls.Add(this.chkpsyp);
            this.panel8.Controls.Add(this.chkdjyp);
            this.panel8.Controls.Add(this.chkmzyp);
            this.panel8.Controls.Add(this.chkwyyp);
            this.panel8.Controls.Add(this.chkgzyp);
            this.panel8.Controls.Add(this.chkjsyp);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(980, 94);
            this.panel8.TabIndex = 1;
            // 
            // txtfyr
            // 
            this.txtfyr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfyr.ForeColor = System.Drawing.Color.Navy;
            this.txtfyr.Location = new System.Drawing.Point(276, 36);
            this.txtfyr.Name = "txtfyr";
            this.txtfyr.Size = new System.Drawing.Size(139, 23);
            this.txtfyr.TabIndex = 4;
            this.txtfyr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtfyr.TextChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(225, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 201;
            this.label7.Text = "发药人";
            // 
            // txtmb
            // 
            this.txtmb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmb.ForeColor = System.Drawing.Color.Navy;
            this.txtmb.Location = new System.Drawing.Point(68, 65);
            this.txtmb.Name = "txtmb";
            this.txtmb.Size = new System.Drawing.Size(135, 23);
            this.txtmb.TabIndex = 5;
            this.txtmb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtmb.TextChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(209, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 199;
            this.label6.Text = "药品代码";
            // 
            // txtdm
            // 
            this.txtdm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtdm.ForeColor = System.Drawing.Color.Navy;
            this.txtdm.Location = new System.Drawing.Point(276, 65);
            this.txtdm.Name = "txtdm";
            this.txtdm.Size = new System.Drawing.Size(203, 23);
            this.txtdm.TabIndex = 6;
            this.txtdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            this.txtdm.TextChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // cmbbs1
            // 
            this.cmbbs1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbs1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbbs1.ForeColor = System.Drawing.Color.Navy;
            this.cmbbs1.Location = new System.Drawing.Point(68, 39);
            this.cmbbs1.Name = "cmbbs1";
            this.cmbbs1.Size = new System.Drawing.Size(138, 22);
            this.cmbbs1.TabIndex = 3;
            this.cmbbs1.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // buthelp
            // 
            this.buthelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buthelp.ImageIndex = 0;
            this.buthelp.ImageList = this.imageList2;
            this.buthelp.Location = new System.Drawing.Point(183, 8);
            this.buthelp.Name = "buthelp";
            this.buthelp.Size = new System.Drawing.Size(23, 23);
            this.buthelp.TabIndex = 194;
            this.buthelp.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buthelp.UseVisualStyleBackColor = true;
            this.buthelp.Click += new System.EventHandler(this.buthelp_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "VIEWER1.ICO");
            // 
            // chkkss
            // 
            this.chkkss.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkkss.ForeColor = System.Drawing.Color.Black;
            this.chkkss.Location = new System.Drawing.Point(765, 60);
            this.chkkss.Name = "chkkss";
            this.chkkss.Size = new System.Drawing.Size(80, 24);
            this.chkkss.TabIndex = 189;
            this.chkkss.Text = "抗生素";
            this.chkkss.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // chkrsyp
            // 
            this.chkrsyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkrsyp.ForeColor = System.Drawing.Color.Black;
            this.chkrsyp.Location = new System.Drawing.Point(693, 60);
            this.chkrsyp.Name = "chkrsyp";
            this.chkrsyp.Size = new System.Drawing.Size(80, 24);
            this.chkrsyp.TabIndex = 184;
            this.chkrsyp.Text = "妊娠药品";
            this.chkrsyp.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // chkcfyp
            // 
            this.chkcfyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkcfyp.ForeColor = System.Drawing.Color.Black;
            this.chkcfyp.Location = new System.Drawing.Point(620, 60);
            this.chkcfyp.Name = "chkcfyp";
            this.chkcfyp.Size = new System.Drawing.Size(80, 24);
            this.chkcfyp.TabIndex = 183;
            this.chkcfyp.Text = "处方药品";
            this.chkcfyp.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // butcfcx
            // 
            this.butcfcx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butcfcx.ForeColor = System.Drawing.Color.Navy;
            this.butcfcx.Location = new System.Drawing.Point(849, 9);
            this.butcfcx.Name = "butcfcx";
            this.butcfcx.Size = new System.Drawing.Size(71, 24);
            this.butcfcx.TabIndex = 19;
            this.butcfcx.Text = "查询(&F)";
            this.butcfcx.Click += new System.EventHandler(this.butcfcx_Click);
            // 
            // txtzyh
            // 
            this.txtzyh.BackColor = System.Drawing.Color.White;
            this.txtzyh.Enabled = false;
            this.txtzyh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzyh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtzyh.Location = new System.Drawing.Point(68, 10);
            this.txtzyh.Name = "txtzyh";
            this.txtzyh.Size = new System.Drawing.Size(114, 23);
            this.txtzyh.TabIndex = 0;
            this.txtzyh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtzyh_KeyUp);
            this.txtzyh.TextChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "住院号";
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.Control;
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point(851, 57);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(71, 24);
            this.butquit.TabIndex = 15;
            this.butquit.Text = "退出(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // lblfyrq
            // 
            this.lblfyrq.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfyrq.ForeColor = System.Drawing.Color.Black;
            this.lblfyrq.Location = new System.Drawing.Point(210, 11);
            this.lblfyrq.Name = "lblfyrq";
            this.lblfyrq.Size = new System.Drawing.Size(71, 20);
            this.lblfyrq.TabIndex = 41;
            this.lblfyrq.Text = "发药日期";
            // 
            // chkpsyp
            // 
            this.chkpsyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkpsyp.ForeColor = System.Drawing.Color.Black;
            this.chkpsyp.Location = new System.Drawing.Point(765, 8);
            this.chkpsyp.Name = "chkpsyp";
            this.chkpsyp.Size = new System.Drawing.Size(80, 24);
            this.chkpsyp.TabIndex = 179;
            this.chkpsyp.Text = "皮试药品";
            this.chkpsyp.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // chkdjyp
            // 
            this.chkdjyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkdjyp.ForeColor = System.Drawing.Color.Black;
            this.chkdjyp.Location = new System.Drawing.Point(693, 8);
            this.chkdjyp.Name = "chkdjyp";
            this.chkdjyp.Size = new System.Drawing.Size(80, 24);
            this.chkdjyp.TabIndex = 178;
            this.chkdjyp.Text = "毒剧药品";
            this.chkdjyp.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // chkmzyp
            // 
            this.chkmzyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkmzyp.ForeColor = System.Drawing.Color.Black;
            this.chkmzyp.Location = new System.Drawing.Point(620, 8);
            this.chkmzyp.Name = "chkmzyp";
            this.chkmzyp.Size = new System.Drawing.Size(80, 24);
            this.chkmzyp.TabIndex = 177;
            this.chkmzyp.Text = "麻醉药品";
            this.chkmzyp.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // chkwyyp
            // 
            this.chkwyyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkwyyp.ForeColor = System.Drawing.Color.Black;
            this.chkwyyp.Location = new System.Drawing.Point(765, 34);
            this.chkwyyp.Name = "chkwyyp";
            this.chkwyyp.Size = new System.Drawing.Size(84, 24);
            this.chkwyyp.TabIndex = 182;
            this.chkwyyp.Text = "外用药品";
            this.chkwyyp.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // chkgzyp
            // 
            this.chkgzyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkgzyp.ForeColor = System.Drawing.Color.Black;
            this.chkgzyp.Location = new System.Drawing.Point(693, 34);
            this.chkgzyp.Name = "chkgzyp";
            this.chkgzyp.Size = new System.Drawing.Size(84, 24);
            this.chkgzyp.TabIndex = 181;
            this.chkgzyp.Text = "贵重药品";
            this.chkgzyp.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // chkjsyp
            // 
            this.chkjsyp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkjsyp.ForeColor = System.Drawing.Color.Black;
            this.chkjsyp.Location = new System.Drawing.Point(620, 34);
            this.chkjsyp.Name = "chkjsyp";
            this.chkjsyp.Size = new System.Drawing.Size(80, 24);
            this.chkjsyp.TabIndex = 180;
            this.chkjsyp.Text = "精神药品";
            this.chkjsyp.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 196;
            this.label1.Text = "领药科室";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 200;
            this.label4.Text = "模板名称";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.panel17);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(982, 50);
            this.panel6.TabIndex = 10;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Controls.Add(this.butexcelHz);
            this.panel17.Controls.Add(this.rdoyfy);
            this.panel17.Controls.Add(this.rdowfy);
            this.panel17.Controls.Add(this.cmbyjks);
            this.panel17.Controls.Add(this.label16);
            this.panel17.Controls.Add(this.panel4);
            this.panel17.Controls.Add(this.butexcelMx);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(982, 50);
            this.panel17.TabIndex = 14;
            // 
            // butexcelHz
            // 
            this.butexcelHz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butexcelHz.ForeColor = System.Drawing.Color.Navy;
            this.butexcelHz.Location = new System.Drawing.Point(688, 10);
            this.butexcelHz.Name = "butexcelHz";
            this.butexcelHz.Size = new System.Drawing.Size(101, 24);
            this.butexcelHz.TabIndex = 139;
            this.butexcelHz.Text = "导出汇总(&E)";
            this.butexcelHz.Click += new System.EventHandler(this.butexcelHz_Click);
            // 
            // rdoyfy
            // 
            this.rdoyfy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoyfy.ForeColor = System.Drawing.Color.Black;
            this.rdoyfy.Location = new System.Drawing.Point(257, 12);
            this.rdoyfy.Name = "rdoyfy";
            this.rdoyfy.Size = new System.Drawing.Size(88, 24);
            this.rdoyfy.TabIndex = 138;
            this.rdoyfy.Text = "已发药";
            this.rdoyfy.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // rdowfy
            // 
            this.rdowfy.Checked = true;
            this.rdowfy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdowfy.ForeColor = System.Drawing.Color.Black;
            this.rdowfy.Location = new System.Drawing.Point(183, 12);
            this.rdowfy.Name = "rdowfy";
            this.rdowfy.Size = new System.Drawing.Size(89, 24);
            this.rdowfy.TabIndex = 137;
            this.rdowfy.TabStop = true;
            this.rdowfy.Text = "未发药";
            this.rdowfy.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbyjks.ForeColor = System.Drawing.Color.Blue;
            this.cmbyjks.Location = new System.Drawing.Point(64, 13);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(112, 22);
            this.cmbyjks.TabIndex = 135;
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label16.Location = new System.Drawing.Point(8, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 19);
            this.label16.TabIndex = 136;
            this.label16.Text = "药房名称";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rdoall);
            this.panel4.Controls.Add(this.rdols);
            this.panel4.Controls.Add(this.rdodq);
            this.panel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(351, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(182, 44);
            this.panel4.TabIndex = 38;
            // 
            // rdoall
            // 
            this.rdoall.ForeColor = System.Drawing.Color.Black;
            this.rdoall.Location = new System.Drawing.Point(123, 8);
            this.rdoall.Name = "rdoall";
            this.rdoall.Size = new System.Drawing.Size(58, 24);
            this.rdoall.TabIndex = 12;
            this.rdoall.Text = "全部";
            this.rdoall.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // butexcelMx
            // 
            this.butexcelMx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butexcelMx.ForeColor = System.Drawing.Color.Navy;
            this.butexcelMx.Location = new System.Drawing.Point(581, 10);
            this.butexcelMx.Name = "butexcelMx";
            this.butexcelMx.Size = new System.Drawing.Size(101, 24);
            this.butexcelMx.TabIndex = 14;
            this.butexcelMx.Text = "导出明细(&M)";
            this.butexcelMx.Click += new System.EventHandler(this.butexcelMx_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 463);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(2, 492);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(980, 24);
            this.statusBar1.TabIndex = 15;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 180;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 180;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 500;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 439);
            this.panel2.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 439);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(980, 345);
            this.panel3.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(980, 345);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.myDataGrid1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(972, 320);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "明细情况";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.GridLineColor = System.Drawing.Color.Black;
            this.myDataGrid1.HeaderFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 3);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ParentRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(966, 314);
            this.myDataGrid1.TabIndex = 1;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.myDataGrid2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(972, 320);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "汇总情况";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(3, 3);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.Size = new System.Drawing.Size(966, 314);
            this.myDataGrid2.TabIndex = 2;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // Frmzycfcx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(982, 516);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.splitter2);
            this.Name = "Frmzycfcx";
            this.Text = "住院处方查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmcffy_Load);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		//加载窗口
		private void Frmcffy_Load(object sender, System.EventArgs e)
		{
		}


		//查询处方按钮事件
		private void butcfcx_Click(object sender, System.EventArgs e)
		{
			
            this.Cursor=PubStaticFun.WaitCursor();

            string where = "";
            if (chkmzyp.Checked == true) where = where == "" ? " mzyp=1 " : where + " or mzyp=1 ";
            if (chkdjyp.Checked == true) where = where == "" ? " djyp=1 " : where + " or djyp=1 ";
            if (chkpsyp.Checked == true) where = where == "" ? " psyp=1 " : where + " or psyp=1 ";
            if (chkjsyp.Checked == true) where = where == "" ? " jsyp=1 " : where + " or jsyp=1 ";
            if (chkgzyp.Checked == true) where = where == "" ? " gzyp=1 " : where + " or gzyp=1 ";
            if (chkwyyp.Checked == true) where = where == "" ? " wyyp=1 " : where + " or wyyp=1 ";
            if (chkcfyp.Checked == true) where = where == "" ? " cfyp=1 " : where + " or cfyp=1 ";
            if (chkrsyp.Checked == true) where = where == "" ? " rsyp=1 " : where + " or rsyp=1 ";
            if (chkkss.Checked == true) where = where == "" ? " kssdjid>0 " : where + " or kssdjid=1 ";

			try
			{

                ParameterEx[] parameters = new ParameterEx[12];
                parameters[0].Text = "@functionname";
                parameters[0].Value = _menuTag.Function_Name;

                parameters[1].Text = "@deptid";
                parameters[1].Value = Convert.ToInt32(cmbyjks.SelectedValue);

                parameters[2].Text = "@inpatient_id";
                parameters[2].Value = Convertor.IsNull(txtzyh.Tag,"");

                parameters[3].Text = "@lyks";
                parameters[3].Value =Convert.ToInt32(Convertor.IsNull(cmbbs1.SelectedValue,"0"));

                parameters[4].Text = "@mbid";
                parameters[4].Value = Convertor.IsNull(txtmb.Tag,"0");

                parameters[5].Text = "@cjid";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(txtdm.Tag, "0"));

                parameters[6].Text = "@qrrq1";
                parameters[6].Value = dtprq1.Value.ToString();

                parameters[7].Text = "@qrrq2";
                parameters[7].Value = dtprq2.Value.ToString();

                parameters[8].Text = "@qrczyh";
                parameters[8].Value = Convert.ToInt32(Convertor.IsNull(txtfyr.Tag, "0"));

                parameters[9].Text = "@fybz";
                parameters[9].Value = rdowfy.Checked==true?0:1;

                parameters[10].Text = "@where";
                parameters[10].Value = where;

                int bk = 0;
                if (rdols.Checked == true) bk = 1;
                if (rdoall.Checked == true) bk = 2;
                parameters[11].Text = "@bk";
                parameters[11].Value = bk;

                DataSet dset = new DataSet();
                TrasenFrame.Forms.FrmMdiMain.Database.AdapterFillDataSet("SP_YF_SELECT_CX_ZYCFCX", parameters, dset, "sfmx", 60);
                Fun.AddRowtNo(dset.Tables[0]);
                dset.Tables[0].TableName = "tbmx";
                myDataGrid1.DataSource = dset.Tables[0];

                dset.Tables[1].TableName = "tbhz";
                Fun.AddRowtNo(dset.Tables[1]);
                myDataGrid2.DataSource = dset.Tables[1];


                this.statusBarPanel1.Text ="金额合计:"+ dset.Tables[1].Compute("sum(金额)", "").ToString();
                this.statusBarPanel2.Text = "数量合计:" + dset.Tables[0].Compute("sum(ypsl)", "").ToString();

                //this.statusBarPanel2.Text = "";
                //this.statusBarPanel3.Text = "";
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message );
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}

		
		
		private void butquit_Click(object sender, System.EventArgs e)
		{
            _ClickQuit = true;
			this.Close();
		}


        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105) || nkey == 32 || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
            {

            }
            else
            {
                return;
            }

            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            DataRow row;

            Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
            switch (control.TabIndex)
            {
                case 6:
                    if (control.Text.Trim() == "") return;
                    GrdMappingName = new string[] { "ggid", "cjid", "行号", "品名", "规格", "厂家", "单位", "DWBL", "批发价", "零售价", "货号" };
                    GrdWidth = new int[] { 0, 0, 50, 200, 100, 100, 40, 0, 60, 60, 70 };
                    sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };
                    if (Convertor.IsNull(cmbyjks.SelectedValue, "0") != "0")
                        ssql = "select a.ggid,cjid,0  rowno,yppm,ypgg,dbo.fun_yp_sccj(sccj) sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_Yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and deptid=" + Convert.ToInt32(cmbyjks.SelectedValue) + " ";
                    else
                        ssql = "select a.ggid,cjid,0  rowno,yppm,ypgg,dbo.fun_yp_sccj(sccj) sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_yp_ypcd a,yp_ypbm b where a.ggid=b.ggid   ";
                    TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.智能, control.Text.Trim(), ssql);
                    f2.Location = point;
                    f2.Width = 700;
                    f2.Height = 300;
                    f2.ShowDialog(this);
                    row = f2.dataRow;
                    if (row != null)
                    {
                        this.txtdm.Text = row["yppm"].ToString();
                        this.txtdm.Tag = row["cjid"].ToString();
                    }
                    break;
                case 5:
                    if (control.Text.Trim() == "") return;
                    GrdMappingName = new string[] { "模板名称", "拼音码", "五笔码", "id" };
                    GrdWidth = new int[] { 150, 60, 60, 0 };
                    sfield = new string[] { "wbm", "pym", "", "", "" };
                    ssql = "select mbmc,pym,wbm,id from yp_yptjmb b where id>0   ";
                    TrasenFrame.Forms.Fshowcard f3 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.智能, control.Text.Trim(), ssql);
                    f3.Location = point;
                    f3.Width = 700;
                    f3.Height = 300;
                    f3.ShowDialog(this);
                    row = f3.dataRow;
                    if (row != null)
                    {
                        this.txtmb.Text = row["mbmc"].ToString();
                        this.txtmb.Tag = row["id"].ToString();
                    }
                    break;
                case 4:
                    if (control.Text.Trim() == "") return;
                    GrdMappingName = new string[] { "姓名", "拼音码", "五笔码", "id" };
                    GrdWidth = new int[] { 150, 60, 60, 0 };
                    sfield = new string[] { "wb_code", "py_code", "", "", "" };
                    ssql = "select name,py_code,wb_code,employee_id from jc_employee_property where employee_id>0   ";
                    TrasenFrame.Forms.Fshowcard f4 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.拼音, control.Text.Trim(), ssql);
                    f4.Location = point;
                    f4.Width = 700;
                    f4.Height = 300;
                    f4.ShowDialog(this);
                    row = f4.dataRow;
                    if (row != null)
                    {
                        this.txtfyr.Text = row["name"].ToString();
                        this.txtfyr.Tag = row["employee_id"].ToString();
                    }
                    break;

            }

        }

        private void buthelp_Click(object sender, EventArgs e)
        {
            TszyHIS.Inpatient inpatient = new TszyHIS.Inpatient(TszyHIS.Inpatient.GetInpatientID());
            if (inpatient.InpatientNo.ToString() != "")
            {
                txtzyh.Text = inpatient.InpatientNo;
                txtzyh.Tag = inpatient.InpatientID;

                //butcfcx_Click(sender, e);
            }
        }


        private void butexcelMx_Click(object sender, EventArgs e)
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
                int RowCount = tb.Rows.Count + 1;
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    colCount = colCount + 1;
                }


                //查询条件
                string title = "";
                title = rdowfy.Checked == true ? "药房未发药情况统计(明细)" : "药房已发药情况统计(明细)";
                string where1 = "";


                where1 = "药房:" + cmbyjks.Text.Trim();
                where1 = where1 + " 日期:" + dtprq1.Value.ToString() + " 到:" + dtprq1.Value.ToString() + "";
                where1 = where1 + "  领药科室:" + cmbbs1.Text.Trim();
                if (txtmb.Text.Trim() != "") where1 = where1 + " 统计模板:" + txtmb.Text.Trim();


                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 =title;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // 设置条件
                Excel.Range range1 = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                range1.MergeCells = true;

                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    objData[1, colIndex++] = tb.Columns[i].Caption;
                }
                objData[0, 0] = where1;
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

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

        private void cmbyjks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tbmx = (DataTable)myDataGrid1.DataSource;
                if (tbmx != null) tbmx.Clear();

                DataTable tb = (DataTable)myDataGrid2.DataSource;
                if (tb != null) tb.Clear();

                lblfyrq.Text = rdowfy.Checked == true ? "处方日期" : "发药日期";
            }
            catch (System.Exception err)
            {
            }
        }

        private void butexcelHz_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable tb = (DataTable)this.myDataGrid2.DataSource;

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
                int RowCount = tb.Rows.Count + 1;
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    colCount = colCount + 1;
                }


                //查询条件
                string title = "";
                title = rdowfy.Checked == true ? "药房未发药情况统计(汇总)" : "药房已发药情况统计(汇总)";
                string where1 = "";


                where1 = "药房:" + cmbyjks.Text.Trim();
                where1 = where1 + " 日期:" + dtprq1.Value.ToString() + " 到:" + dtprq1.Value.ToString() + "";
                where1 = where1 + "  领药科室:" + cmbbs1.Text.Trim();
                if (txtmb.Text.Trim() != "") where1 = where1 + " 统计模板:" + txtmb.Text.Trim();


                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = title;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // 设置条件
                Excel.Range range1 = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                range1.MergeCells = true;

                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // 获取列标题
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                    objData[1, colIndex++] = tb.Columns[i].Caption;
                }
                objData[0, 0] = where1;
                // 获取数据

                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

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

        private void txtzyh_KeyUp(object sender, KeyEventArgs e)
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "";
            }
        }

	}
};
