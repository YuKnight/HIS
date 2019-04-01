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

namespace ts_zyhs_kssr
{
	/// <summary>
	/// 病区科室收入 的摘要说明。
	/// </summary>
	public class FrmBqsr : System.Windows.Forms.Form
	{
		//自定义变量
		private BaseFunc myFunc;
		private DataTable dataTb=new DataTable();
		private DataTable wardTb=new DataTable();
		private DataTable patTb=new DataTable();
		
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.ComboBox cmbDept;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DataGridEx dgWard;
		private DataGridEx dgPat;
		private DataGridEx dgList;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DateTimePicker dtpBegin;
		private System.Windows.Forms.DateTimePicker dtpEnd;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
        private Button button1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmBqsr(string _formText)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this.Text=_formText;
			
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
            this.dgWard = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dgPat = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dgList = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgWard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgWard
            // 
            this.dgWard.BackgroundColor = System.Drawing.Color.White;
            this.dgWard.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgWard.CaptionFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgWard.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgWard.CaptionText = "病区收入";
            this.dgWard.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dgWard.DataMember = "";
            this.dgWard.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgWard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgWard.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgWard.Location = new System.Drawing.Point(0, 0);
            this.dgWard.Name = "dgWard";
            this.dgWard.ReadOnly = true;
            this.dgWard.Size = new System.Drawing.Size(937, 216);
            this.dgWard.TabIndex = 0;
            this.dgWard.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgWard.CurrentCellChanged += new System.EventHandler(this.dgWard_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.dgWard;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dgPat
            // 
            this.dgPat.BackgroundColor = System.Drawing.Color.White;
            this.dgPat.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgPat.CaptionFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgPat.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgPat.CaptionText = "病人费用";
            this.dgPat.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dgPat.DataMember = "";
            this.dgPat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgPat.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPat.Location = new System.Drawing.Point(0, 216);
            this.dgPat.Name = "dgPat";
            this.dgPat.ReadOnly = true;
            this.dgPat.Size = new System.Drawing.Size(937, 149);
            this.dgPat.TabIndex = 2;
            this.dgPat.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dgPat.CurrentCellChanged += new System.EventHandler(this.dgPat_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.dgPat;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dgList
            // 
            this.dgList.BackgroundColor = System.Drawing.Color.White;
            this.dgList.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgList.CaptionFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgList.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgList.CaptionText = "费用明细";
            this.dgList.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dgList.DataMember = "";
            this.dgList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgList.Location = new System.Drawing.Point(0, 365);
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.Size = new System.Drawing.Size(937, 184);
            this.dgList.TabIndex = 4;
            this.dgList.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.dgList.CurrentCellChanged += new System.EventHandler(this.dgList_CurrentCellChanged);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.AllowSorting = false;
            this.dataGridTableStyle3.DataGrid = this.dgList;
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.dgPat);
            this.panel1.Controls.Add(this.dgWard);
            this.panel1.Controls.Add(this.dgList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(937, 549);
            this.panel1.TabIndex = 6;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 216);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(937, 3);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 362);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(937, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBegin.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(70, 30);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(138, 21);
            this.dtpBegin.TabIndex = 7;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnd.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(270, 30);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(137, 21);
            this.dtpEnd.TabIndex = 8;
            // 
            // cmbDept
            // 
            this.cmbDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDept.Location = new System.Drawing.Point(452, 30);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(136, 22);
            this.cmbDept.TabIndex = 9;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(594, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 32);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.ContextMenu = this.contextMenu1;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Location = new System.Drawing.Point(682, 23);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 32);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "打印病区收入";
            this.menuItem1.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "打印病人费用";
            this.menuItem2.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(854, 23);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 32);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "退出(&E)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "开始日期";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(206, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "结束日期";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(413, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "科室";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpBegin);
            this.panel2.Controls.Add(this.dtpEnd);
            this.panel2.Controls.Add(this.cmbDept);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(937, 72);
            this.panel2.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ContextMenu = this.contextMenu1;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(768, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 16;
            this.button1.Text = "导出(&D)";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmBqsr
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(937, 621);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmBqsr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "病区科室收入";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmWarddeptSR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgWard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private void frmWarddeptSR_Load(object sender, System.EventArgs e)
        {
            dtpBegin.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            dtpEnd.Value = dtpBegin.Value;

            dtpBegin.Value =Convert.ToDateTime( dtpBegin.Value.ToShortDateString() + " 00:00:00");
            dtpEnd.Value = Convert.ToDateTime(dtpEnd.Value.ToShortDateString() + " 23:59:59");
            LoadDept();

            //string[] GrdMappingName1 ={ "病区", "科室", "合计" };
            //int[] GrdWidth1 ={ 20, 20, 30 };
            //int[] Alignment1 ={ 1, 1, 1 };
            //int[] ReadOnly1 ={ 0, 0, 0 };
            //myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.dgWard);

            string[] GrdMappingName3 ={ "项目代码", "项目名称", "单价", "数量", "金额", "记帐日期", "记帐人", "执行科室", "项目类别" };
            int[] GrdWidth3 ={ 10, 30, 10, 10, 10, 20, 10, 15, 15 };
            int[] Alignment3 ={ 1, 0, 2, 2, 2, 1, 1, 1, 1 };
            int[] ReadOnly3 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName3, GrdWidth3, Alignment3, ReadOnly3, this.dgList);
        }

		private void LoadDept()
		{
			string sSql="";
			DataTable myTb=new DataTable();

			sSql="select b.dept_id,b.name from jc_wardrdept a inner join jc_dept_property b on a.dept_id=b.dept_id "+
                "where a.dept_id not in (select dept_id from jc_ward) and a.ward_id='" + InstanceForm.BCurrentDept.WardId + "'";
			myTb=InstanceForm.BDatabase.GetDataTable(sSql);
            if (InstanceForm.BCurrentDept.WardId==""||myTb.Rows.Count==0)
            {
                sSql = "select b.dept_id,b.name from jc_wardrdept a inner join jc_dept_property b on a.dept_id=b.dept_id " +
                 "where a.dept_id not in (select dept_id from jc_ward) ";
                myTb = InstanceForm.BDatabase.GetDataTable(sSql);
            }
			cmbDept.DataSource=myTb;
			cmbDept.DisplayMember="NAME";
			cmbDept.ValueMember="DEPT_ID";
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			dgWard.DataSource=null;
			dgPat.DataSource=null;
			dgList.DataSource=null;

			dgWard.CaptionText="病区收入";
			dgPat.CaptionText="病人费用";
			dgList.CaptionText="费用明细";

			if(cmbDept.Text.Trim()=="")
			{
				MessageBox.Show("请选择一个科室！");
				return;
			}
			
			Cursor.Current=PubStaticFun.WaitCursor();

            string sSql = "exec sp_zyhs_selkssr '" + dtpBegin.Value + "','" + dtpEnd.Value + "'," + cmbDept.SelectedValue;
			dataTb=InstanceForm.BDatabase.GetDataTable(sSql);

			wardTb=dataTb.Clone();
			DataRow[] drM = dataTb.Select("病区='合  计'");
			foreach(DataRow dr in drM)
			{
				wardTb.Rows.Add(dr.ItemArray);
			}

			dgWard.DataSource=wardTb;

			Cursor.Current=Cursors.Default;
		}

        private void dgWard_CurrentCellChanged(object sender, System.EventArgs e)
        {
            dgPat.DataSource = null;
            dgList.DataSource = null;

            dgPat.CaptionText = "病人费用";
            dgList.CaptionText = "费用明细";

            patTb = dataTb.Copy();
            dgPat.DataSource = patTb;
        }

		private void dgPat_CurrentCellChanged(object sender, System.EventArgs e)
		{
			dgList.DataSource=null;

			dgList.CaptionText="费用明细";

			int nrow=dgPat.CurrentCell.RowNumber;
			dgPat.Select(nrow);

            Guid sInpatientId = Guid.Empty;
            if (dgPat[nrow, 2].ToString().Trim() != "")
            {
                sInpatientId = new Guid(dgPat[nrow, 2].ToString().Trim());
            }

			if(sInpatientId!=Guid.Empty)
			{
				Cursor.Current=PubStaticFun.WaitCursor();

				dgList.CaptionText+=" [病区："+dgPat[nrow,1].ToString()+" 住院号："+dgPat[nrow,4].ToString()+" 姓名："+dgPat[nrow,5].ToString()+"]";

                string sSql = "select a.subcode as 项目代码, " +
                    " a.item_name 项目名称, " +
					" a.retail_price 单价,a.num*a.dosage 数量,a.acvalue 金额,a.charge_date 记帐日期,dbo.fun_getempname(a.charge_user) 记帐人, "+
					" dbo.fun_getdeptname(a.execdept_id) 执行科室,c.item_name 项目类别 "+
                    " from (select * from (select * from zy_fee_speci union all select * from zy_fee_speci_h) a where inpatient_id='" + sInpatientId + "' and charge_bit=1 and delete_bit=0" +
                    " and charge_date >= '" + dtpBegin.Value +"' and charge_date < '" + dtpEnd.Value + "'   and dept_id=" + cmbDept.SelectedValue + ") a" +
					" inner join jc_stat_item c"+
                    " on a.statitem_code=c.code" +
					" order by c.code,charge_date";
				DataTable myTb=InstanceForm.BDatabase.GetDataTable(sSql);

				dgList.DataSource=myTb;
			}

			Cursor.Current=Cursors.Default;
		}

		private void dgList_CurrentCellChanged(object sender, System.EventArgs e)
		{
			int nrow=dgPat.CurrentCell.RowNumber;
			dgPat.Select(nrow);
		}

		private void cmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			dgWard.DataSource=null;
			dgPat.DataSource=null;
			dgList.DataSource=null;

			dgWard.CaptionText="病区收入";
			dgPat.CaptionText="病人费用";
			dgList.CaptionText="费用明细";
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Point pp = new Point(btnPrint.Location.X,btnPrint.Location.Y+btnPrint.Height);

			contextMenu1.Show(this,pp);
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			if(wardTb==null || wardTb.Rows.Count==0)
			{
				menuItem1.Enabled=false;
			}
			else
			{
				menuItem1.Enabled=true;
			}
			if(patTb==null || patTb.Rows.Count==0)
			{
				menuItem2.Enabled=false;
			}
			else
			{
				menuItem2.Enabled=true;
			}
		}

		private void menuItem_Click(object sender, System.EventArgs e)
		{
			MenuItem mnu = (MenuItem)sender;
			DataTable prtTb = new DataTable();

			if(mnu.Text=="打印病区收入")
			{
				prtTb=((DataTable)dgWard.DataSource).Copy();
			}
			else
			{
				prtTb=((DataTable)dgPat.DataSource).Copy();
			}

			DataSet ds = new DataSet();
			prtTb.TableName="tabBqkssr";
			ds.Tables.Add(prtTb);

			FrmReportView frmRptView=null;
			ParameterEx[] _parameters=new ParameterEx[3];

			_parameters[0].Text="科室名称";
			_parameters[0].Value=cmbDept.Text;
			_parameters[1].Text="开始日期";
			_parameters[1].Value=dtpBegin.Value.ToShortDateString();
			_parameters[2].Text="结束日期";
			_parameters[2].Value=dtpEnd.Value.ToShortDateString();

			frmRptView=new FrmReportView(ds,Constant.ApplicationDirectory+"\\report\\ZYHS_病区科室收入.rpt",_parameters);
			frmRptView.Show();
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
        /// <summary>   
        /// 将DataTable数据导出到Excel表   
        /// </summary>   
        /// <param name="tmpDataTable">要导出的DataTable</param>   
        /// <param name="strFileName">Excel的保存路径及名称</param>   
        public void DataTabletoExcel(System.Data.DataTable tmpDataTable, string strFileName)
        {
            if (tmpDataTable == null)
            {
                return;
            }
            long rowNum = tmpDataTable.Rows.Count;//行数   
            int columnNum = tmpDataTable.Columns.Count;//列数   
            Excel.Application m_xlApp = new Excel.Application();
            m_xlApp.DisplayAlerts = true;//不显示更改提示   
            m_xlApp.Visible = true;//false;//

            Excel.Workbooks workbooks = m_xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1   
            //worksheet.SetBackgroundPicture("d:\\26.jpg");
            try
            {
                //查询条件
                string rq = "日期:" + this.dtpBegin.Value.ToString() + " 到 " + this.dtpEnd.Value.ToString();
                string ks = "";

                string swhere = rq + ks;
                int SumColCount = tmpDataTable.Columns.Count;

                //for (int j = 0; j < tmpDataTable.Columns.Count; j++)
                //{
                //    if (this.dataGridView1.Columns[j].Visible)
                //    {
                //        SumColCount = SumColCount + 1;
                //        m_xlApp.Cells[5, SumColCount] = "" + tmpDataTable.Columns[j].Caption;
                //    }
                //}

                //报表名称
                string ss = InstanceForm.BCurrentDept.DeptName+" "+ "科室收入";
                m_xlApp.Cells[1, 1] = ss;
                m_xlApp.get_Range(m_xlApp.Cells[1, 1], m_xlApp.Cells[1, SumColCount]).Font.Bold = true;
                m_xlApp.get_Range(m_xlApp.Cells[1, 1], m_xlApp.Cells[1, SumColCount]).Font.Size = 16;
                //报表名称跨行居中
                m_xlApp.get_Range(m_xlApp.Cells[1, 1], m_xlApp.Cells[1, SumColCount]).Select();
                m_xlApp.get_Range(m_xlApp.Cells[1, 1], m_xlApp.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //报表条件
                m_xlApp.Cells[3, 1] = swhere.Trim();
                m_xlApp.get_Range(m_xlApp.Cells[3, 1], m_xlApp.Cells[3, SumColCount]).Font.Size = 10;
                m_xlApp.get_Range(m_xlApp.Cells[3, 1], m_xlApp.Cells[3, SumColCount]).Select();
                m_xlApp.get_Range(m_xlApp.Cells[3, 1], m_xlApp.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;




                if (rowNum > 65536)//单张Excel表格最大行数   
                {
                    long pageRows = 65535;//定义每页显示的行数,行数必须小于65536   
                    int scount = (int)(rowNum / pageRows);//导出数据生成的表单数   
                    if (scount * pageRows < rowNum)//当总行数不被pageRows整除时，经过四舍五入可能页数不准   
                    {
                        scount = scount + 1;
                    }
                    for (int sc = 1; sc <= scount; sc++)
                    {
                        if (sc > 1)
                        {
                            object missing = System.Reflection.Missing.Value;
                            worksheet = (Excel.Worksheet)workbook.Worksheets.Add(
                                        missing, missing, missing, missing);//添加一个sheet   
                        }
                        else
                        {
                            worksheet = (Excel.Worksheet)workbook.Worksheets[sc];//取得sheet1   
                        }
                        string[,] datas = new string[pageRows + 1, columnNum];

                        for (int i = 0; i < columnNum; i++) //写入字段   
                        {
                            datas[0, i] = tmpDataTable.Columns[i].Caption;//表头信息   
                        }
                        Excel.Range range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, columnNum]);
                        range.Interior.ColorIndex = 15;//15代表灰色   
                        range.Font.Bold = true;
                        range.Font.Size = 9;

                        int init = int.Parse(((sc - 1) * pageRows).ToString());
                        int r = 0;
                        int index = 0;
                        int result;
                        if (pageRows * sc >= rowNum)
                        {
                            result = (int)rowNum;
                        }
                        else
                        {
                            result = int.Parse((pageRows * sc).ToString());
                        }

                        for (r = init; r < result; r++)
                        {
                            index = index + 1;
                            for (int i = 0; i < columnNum; i++)
                            {
                                object obj = tmpDataTable.Rows[r][tmpDataTable.Columns[i].ToString()];
                                datas[index, i] = obj == null ? "" : "" + obj.ToString().Trim();//在obj.ToString()前加单引号是为了防止自动转化格式   
                            }
                            System.Windows.Forms.Application.DoEvents();
                            //添加进度条   
                        }

                        Excel.Range fchR = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[index + 5, columnNum]);
                        fchR.Value2 = datas;
                        worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。   
                        m_xlApp.WindowState = Excel.XlWindowState.xlMaximized;//Sheet表最大化   
                        range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[index + 5, columnNum]);
                        //range.Interior.ColorIndex = 15;//15代表灰色   
                        range.Font.Size = 9;
                        range.RowHeight = 14.25;
                        range.Borders.LineStyle = 1;
                        range.HorizontalAlignment = 1;
                    }
                }
                else
                {
                    string[,] datas = new string[rowNum + 1, columnNum];
                    for (int i = 0; i < columnNum; i++) //写入字段   
                    {
                        datas[0, i] = tmpDataTable.Columns[i].Caption;
                    }
                    Excel.Range range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, columnNum]);
                    range.Interior.ColorIndex = 15;//15代表灰色   
                    range.Font.Bold = true;
                    range.Font.Size = 9;

                    int r = 0;
                    for (r = 0; r < rowNum; r++)
                    {
                        for (int i = 0; i < columnNum; i++)
                        {
                            object obj = tmpDataTable.Rows[r][tmpDataTable.Columns[i].ToString()];
                            datas[r + 1, i] = obj == null ? "" : "" + obj.ToString().Trim();//在obj.ToString()前加单引号是为了防止自动转化格式   
                        }
                        System.Windows.Forms.Application.DoEvents();
                        //添加进度条   
                    }
                    Excel.Range fchR = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[rowNum + 5, columnNum]);
                    fchR.Value2 = datas;

                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。   
                    m_xlApp.WindowState = Excel.XlWindowState.xlMaximized;

                    range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[rowNum + 5, columnNum]);
                    //range.Interior.ColorIndex = 15;//15代表灰色   
                    range.Font.Size = 9;
                    range.RowHeight = 14.25;
                    range.Borders.LineStyle = 1;
                    range.HorizontalAlignment = 1;
                }
                //workbook.Saved = true;
                // workbook.SaveCopyAs(strFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出异常：" + ex.Message, "导出异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (workbook != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    workbook = null;

                }
                if (m_xlApp != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp);
                    m_xlApp = null;
                    //xlApp.Quit(); 

                }
                GC.Collect();

                //EndReport();
            }
        }
        public Excel.Application m_xlApp = null;
        // <summary>   
        /// 退出报表时关闭Excel和清理垃圾Excel进程   
        /// </summary>   
        private void EndReport()
        {
            object missing = System.Reflection.Missing.Value;
            try
            {
                m_xlApp.Workbooks.Close();
                m_xlApp.Workbooks.Application.Quit();
                m_xlApp.Application.Quit();
                m_xlApp.Quit();
            }
            catch { }
            finally
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp.Workbooks);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp.Application);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp);
                    m_xlApp = null;
                }
                catch { }
                try
                {
                    //清理垃圾进程   
                    this.killProcessThread();
                }
                catch { }
                GC.Collect();
            }
        }
        /// <summary>   
        /// 杀掉不死进程   
        /// </summary>   
        private void killProcessThread()
        {
            ArrayList myProcess = new ArrayList();
            for (int i = 0; i < myProcess.Count; i++)
            {
                try
                {
                    System.Diagnostics.Process.GetProcessById(int.Parse((string)myProcess[i])).Kill();
                }
                catch { }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.dgPat.DataSource) == null || ((DataTable)this.dgPat.DataSource).Rows.Count==0)
            {
                dgWard_CurrentCellChanged(null,null);
            }
            DataTabletoExcel((DataTable)this.dgPat.DataSource, "d:\\dd.asv");
            return;
        }
	}
}
