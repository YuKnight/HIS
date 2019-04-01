using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
namespace ts_jc_yykssz
{
	/// <summary>
	/// FrmDeptProperty 的摘要说明。
	/// </summary>
	public class FrmDeptProperty : System.Windows.Forms.Form
	{
		/// <summary>
		/// 数据集
		/// </summary>
		private DataSet _dataset ;
		/// <summary>
		/// 级别
		/// </summary>
		private int _level;
		/// <summary>
		/// 当前编辑模式
		/// </summary>
		private CurrentStatus _currentStatus;
		/// <summary>
		/// 当前科室编号
		/// </summary>
		private int _deptId;
        int _jgbm;
		public Department ReturnDepartment;

		public bool isDelete=false;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtPym;
		private System.Windows.Forms.ListView lvwType;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TextBox txtWardNO;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtfy;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox cboPDept;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rdWardDept;
		private System.Windows.Forms.RadioButton rdWard;
		private System.Windows.Forms.RadioButton rdNone;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboWard;
		private System.Windows.Forms.Label label8;
        private TextBox txtdCode;
        private Label label9;
        private TextBox txtBedNum;
        private Label label10;
        private CheckBox chkJz;
        private Label label4;
        private ComboBox cobjg;
        private TextBox txtSort;
        private Label label11;
      //  private string strWb;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmDeptProperty()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this._currentStatus = CurrentStatus.新建状态;
            
			
		}
		public FrmDeptProperty(int Level,int DeptId)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this._currentStatus = CurrentStatus.修改状态;
			this._deptId = DeptId;
			this._level = Level;
            
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
        /// <summary>
        /// jianqg 2014-6-30 增加，将人事，医务权限分离
        /// </summary>
        private void Init_function_Name()
        {
            string function_Name = InstanceForm._menuTag.Function_Name;
            switch (function_Name)
            {
                case "Fun_ts_jc_yykssz_yw_ry"://医务
                    txtName.Enabled = false;
                    cboPDept.Enabled = false;
                    txtPym.Enabled = false;
                    txtdCode.Enabled = false;
                    lvwType.Enabled = false;
                    chkJz.Enabled = false;
                    txtSort.Enabled = false;
                    groupBox3.Enabled = false;
                    btnDel.Enabled  = false;
                    btnSave.Enabled = false;

                    break;
                case "Fun_ts_jc_yykssz_rs_ksry"://人事
                    lvwType.Enabled = false;
                    chkJz.Enabled = false;
                    groupBox3.Enabled = false;
                    break;
            }

        }
        /// <summary>
        /// 加载机构编码
        /// </summary>
        /// <param name="a"></param>
        private void LoadJGBM(int a)
        {
            string sql = "select jgbm,jgmc from jc_jgbm ";
            DataTable dtJGBM = InstanceForm.BDatabase.GetDataTable(sql);
            cobjg.DataSource = dtJGBM;
            cobjg.DisplayMember = "jgmc";
            cobjg.ValueMember = "jgbm";
            if (a >= 0)
            {
                string sqls = InstanceForm.BDatabase.GetDataResult("select jgbm from jc_dept_property where dept_id = " + a).ToString() ;
                cobjg.SelectedValue = Convert.ToInt32(sqls);
            }
        }
		/// <summary>
		/// 加载科室角色类型
		/// </summary>
		private void LoadDeptType()
		{
			string sql = "select 0 as rowno,code as id,name,py_code,'' as wb_code,'' as d_code from jc_dept_type order by code ";
			DataTable tableDeptType = InstanceForm.BDatabase.GetDataTable( sql );
			for(int i=0;i<tableDeptType.Rows.Count;i++)
			{
				ListViewItem item = new ListViewItem();
				item.Text = tableDeptType.Rows[i]["name"].ToString().Trim();
				item.Tag = tableDeptType.Rows[i]["ID"].ToString().Trim();
				this.lvwType.Items.Add( item );
			}
		}
		private void LoadWard()
		{
			string sql = "select rtrim(WARD_ID) as WARD_ID,WARD_NAME from jc_ward";
			DataTable tbWard = InstanceForm.BDatabase.GetDataTable( sql );
			this.cboWard.DisplayMember = "WARD_NAME";
			this.cboWard.ValueMember = "WARD_ID";
			this.cboWard.DataSource = tbWard;
		}

		private void LoadParentDept()
		{
			string sql = "select 0 as DEPT_ID,'无' AS NAME union all select DEPT_ID,(convert(varchar(2),layer) + '-' + name) as NAME from jc_dept_property where deleted=0 and layer in (1,2) ";
			switch (_level )
			{
				case 1:
					sql = "select 0 as DEPT_ID,'无' AS NAME ";
					break;
				case 2:
					sql = "select DEPT_ID,(convert(varchar(2),layer) + '-' + name) as NAME from jc_dept_property where deleted=0 and layer = 1 ";
					break;
				case 3:
					sql = "select DEPT_ID,(convert(varchar(2),layer) + '-' + name) as NAME from jc_dept_property where deleted=0 and layer in (2) ";
					break;
			}

			DataTable table = InstanceForm.BDatabase.GetDataTable(sql);
			this.cboPDept.ValueMember = "DEPT_ID";
			this.cboPDept.DisplayMember = "NAME";
			this.cboPDept.DataSource = table;
			
		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvwType = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPym = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtWardNO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtfy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboPDept = new System.Windows.Forms.ComboBox();
            this.rdNone = new System.Windows.Forms.RadioButton();
            this.rdWardDept = new System.Windows.Forms.RadioButton();
            this.rdWard = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cobjg = new System.Windows.Forms.ComboBox();
            this.txtBedNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboWard = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtdCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkJz = new System.Windows.Forms.CheckBox();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(18, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "拼音码";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvwType);
            this.groupBox1.Location = new System.Drawing.Point(18, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 106);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "角色(非三级科室可不用设置角色)";
            // 
            // lvwType
            // 
            this.lvwType.CheckBoxes = true;
            this.lvwType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwType.Location = new System.Drawing.Point(3, 17);
            this.lvwType.Name = "lvwType";
            this.lvwType.Size = new System.Drawing.Size(360, 86);
            this.lvwType.TabIndex = 0;
            this.lvwType.UseCompatibleStateImageBehavior = false;
            this.lvwType.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "角色类型";
            this.columnHeader1.Width = 243;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 12F);
            this.txtName.Location = new System.Drawing.Point(96, 24);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(278, 26);
            this.txtName.TabIndex = 6;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // txtPym
            // 
            this.txtPym.Font = new System.Drawing.Font("宋体", 12F);
            this.txtPym.Location = new System.Drawing.Point(96, 90);
            this.txtPym.MaxLength = 30;
            this.txtPym.Name = "txtPym";
            this.txtPym.Size = new System.Drawing.Size(111, 26);
            this.txtPym.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(18, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "上级部门";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(240, 455);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 26);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(316, 455);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 26);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtWardNO
            // 
            this.txtWardNO.Enabled = false;
            this.txtWardNO.Font = new System.Drawing.Font("宋体", 12F);
            this.txtWardNO.Location = new System.Drawing.Point(106, 2);
            this.txtWardNO.MaxLength = 4;
            this.txtWardNO.Name = "txtWardNO";
            this.txtWardNO.Size = new System.Drawing.Size(126, 26);
            this.txtWardNO.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(28, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "病区编号";
            // 
            // txtfy
            // 
            this.txtfy.Enabled = false;
            this.txtfy.Font = new System.Drawing.Font("宋体", 12F);
            this.txtfy.Location = new System.Drawing.Point(232, 76);
            this.txtfy.MaxLength = 30;
            this.txtfy.Name = "txtfy";
            this.txtfy.Size = new System.Drawing.Size(128, 26);
            this.txtfy.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(152, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "费用限额";
            // 
            // btnDel
            // 
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDel.Location = new System.Drawing.Point(164, 455);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(70, 26);
            this.btnDel.TabIndex = 30;
            this.btnDel.Text = "置无效";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(8, 441);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 4);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtWardNO);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(126, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 30);
            this.panel1.TabIndex = 32;
            // 
            // cboPDept
            // 
            this.cboPDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPDept.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboPDept.Location = new System.Drawing.Point(96, 58);
            this.cboPDept.Name = "cboPDept";
            this.cboPDept.Size = new System.Drawing.Size(280, 24);
            this.cboPDept.TabIndex = 34;
            // 
            // rdNone
            // 
            this.rdNone.Checked = true;
            this.rdNone.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdNone.Location = new System.Drawing.Point(12, 22);
            this.rdNone.Name = "rdNone";
            this.rdNone.Size = new System.Drawing.Size(96, 22);
            this.rdNone.TabIndex = 35;
            this.rdNone.TabStop = true;
            this.rdNone.Text = "无";
            // 
            // rdWardDept
            // 
            this.rdWardDept.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdWardDept.Location = new System.Drawing.Point(12, 50);
            this.rdWardDept.Name = "rdWardDept";
            this.rdWardDept.Size = new System.Drawing.Size(126, 24);
            this.rdWardDept.TabIndex = 36;
            this.rdWardDept.Text = "病区下的科室";
            this.rdWardDept.CheckedChanged += new System.EventHandler(this.rdWardDept_CheckedChanged);
            // 
            // rdWard
            // 
            this.rdWard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdWard.Location = new System.Drawing.Point(12, 136);
            this.rdWard.Name = "rdWard";
            this.rdWard.Size = new System.Drawing.Size(98, 22);
            this.rdWard.TabIndex = 37;
            this.rdWard.Text = "病区";
            this.rdWard.CheckedChanged += new System.EventHandler(this.rdWard_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cobjg);
            this.groupBox3.Controls.Add(this.txtBedNum);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cboWard);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.rdNone);
            this.groupBox3.Controls.Add(this.rdWard);
            this.groupBox3.Controls.Add(this.rdWardDept);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.txtfy);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(18, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(368, 168);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其他";
            // 
            // cobjg
            // 
            this.cobjg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobjg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobjg.Location = new System.Drawing.Point(232, 18);
            this.cobjg.Name = "cobjg";
            this.cobjg.Size = new System.Drawing.Size(128, 24);
            this.cobjg.TabIndex = 42;
            this.cobjg.SelectedIndexChanged += new System.EventHandler(this.cobjg_selected);
            // 
            // txtBedNum
            // 
            this.txtBedNum.Enabled = false;
            this.txtBedNum.Font = new System.Drawing.Font("宋体", 12F);
            this.txtBedNum.Location = new System.Drawing.Point(232, 105);
            this.txtBedNum.MaxLength = 30;
            this.txtBedNum.Name = "txtBedNum";
            this.txtBedNum.Size = new System.Drawing.Size(128, 26);
            this.txtBedNum.TabIndex = 41;
            this.txtBedNum.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(152, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "所属机构";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F);
            this.label10.Location = new System.Drawing.Point(152, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 40;
            this.label10.Text = "床位数";
            // 
            // cboWard
            // 
            this.cboWard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWard.Enabled = false;
            this.cboWard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboWard.Location = new System.Drawing.Point(232, 48);
            this.cboWard.Name = "cboWard";
            this.cboWard.Size = new System.Drawing.Size(128, 24);
            this.cboWard.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(152, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "所属病区";
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(22, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(364, 14);
            this.label8.TabIndex = 40;
            this.label8.Text = "设置病区时请小心，一旦设置为病区保存后将不可改回";
            // 
            // txtdCode
            // 
            this.txtdCode.Font = new System.Drawing.Font("宋体", 12F);
            this.txtdCode.Location = new System.Drawing.Point(272, 89);
            this.txtdCode.MaxLength = 30;
            this.txtdCode.Name = "txtdCode";
            this.txtdCode.Size = new System.Drawing.Size(106, 26);
            this.txtdCode.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.Location = new System.Drawing.Point(202, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 41;
            this.label9.Text = " 数字码";
            // 
            // chkJz
            // 
            this.chkJz.AutoSize = true;
            this.chkJz.Checked = true;
            this.chkJz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkJz.Location = new System.Drawing.Point(18, 231);
            this.chkJz.Name = "chkJz";
            this.chkJz.Size = new System.Drawing.Size(96, 16);
            this.chkJz.TabIndex = 43;
            this.chkJz.Text = "是否直接记账";
            this.chkJz.UseVisualStyleBackColor = true;
            // 
            // txtSort
            // 
            this.txtSort.Enabled = false;
            this.txtSort.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSort.Location = new System.Drawing.Point(250, 229);
            this.txtSort.MaxLength = 30;
            this.txtSort.Name = "txtSort";
            this.txtSort.Size = new System.Drawing.Size(128, 26);
            this.txtSort.TabIndex = 45;
            this.txtSort.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F);
            this.label11.Location = new System.Drawing.Point(170, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 44;
            this.label11.Text = "科室排序";
            // 
            // FrmDeptProperty
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(409, 493);
            this.ControlBox = false;
            this.Controls.Add(this.txtSort);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkJz);
            this.Controls.Add(this.txtdCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cboPDept);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPym);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmDeptProperty";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "科室维护";
            this.Load += new System.EventHandler(this.FrmDeptProperty_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		
		private void FrmDeptProperty_Load(object sender, System.EventArgs e)
		{
            Init_function_Name();
			LoadParentDept();
			LoadDeptType();
			LoadWard();
            LoadJGBM(-1);
            if ( _currentStatus == CurrentStatus.修改状态 )
            {
                string sql = @"select a.dept_id,a.name,a.py_code,a.wb_code,a.d_code ,b.dept_id as p_id,b.name as p_name,a.isjz,a.sort_id 
									from jc_dept_property a	
									left join jc_dept_property b on a.p_dept_id = b.dept_id	where a.dept_id=" + this._deptId;

                DataRow dr = InstanceForm.BDatabase.GetDataRow( sql );
                LoadJGBM(this._deptId);
                this.txtName.Text = dr["name"].ToString( );
                this.txtPym.Text = dr["py_code"].ToString( );
                this.txtdCode.Text = dr["d_code"].ToString( ).Trim( );
                chkJz.Checked=Convert.ToBoolean(Convert.ToInt16(dr["isjz"]));
                if ( txtdCode.Text.Trim( ) == "" )
                {
                    //给默认的数字吗
                    object objMax = InstanceForm.BDatabase.GetDataResult( "select max(cast(d_code as int)) from jc_dept_property where isnumeric(d_code) = 1 " );
                    if ( Convert.IsDBNull( objMax ) )
                    {
                        txtdCode.Text = "1";
                    }
                    else
                    {
                        txtdCode.Text = Convert.ToString( Convert.ToInt32( objMax ) + 1 );
                    }
                }
                cboPDept.SelectedValue = Convert.IsDBNull( dr["p_id"] ) ? -1 : Convert.ToInt32( dr["p_id"] );

                txtSort.Enabled = true;
                txtSort.Text = Convert.IsDBNull(dr["SORT_ID"]) ? "1" : dr["SORT_ID"].ToString();
                //显示科室类型
                foreach ( ListViewItem _item in this.lvwType.Items )
                    _item.Checked = false;

                sql = @"select type_code as code from jc_dept_type_relation  where dept_id=" + this._deptId;
                DataTable tableType = InstanceForm.BDatabase.GetDataTable( sql );
                for ( int i = 0 ; i < tableType.Rows.Count ; i++ )
                {
                    foreach ( ListViewItem _item in this.lvwType.Items )
                    {
                        if ( tableType.Rows[i]["code"].ToString( ).Trim( ) == _item.Tag.ToString( ).Trim( ) )
                        {
                            _item.Checked = true;
                            break;
                        }
                    }
                }
                //显示病区
                sql = "select * from jc_ward where dept_id=" + this._deptId;
                dr = InstanceForm.BDatabase.GetDataRow( sql );
                if ( dr != null )
                {
                    this.rdWard.Checked = true;
                    this.txtWardNO.Text = dr["ward_id"].ToString( ).Trim( );
                }
                else
                {
                    //病区下的科室
                    sql = "select * from jc_wardrdept where dept_id not in (select dept_id from jc_ward) and dept_id=" + this._deptId;
                    dr = InstanceForm.BDatabase.GetDataRow( sql );
                    if ( dr != null )
                    {
                        this.cboWard.SelectedValue = dr["ward_id"].ToString( ).Trim( );
                        rdWardDept.Checked = true;
                        this.txtfy.Text = dr["minexecye"].ToString( );
                        this.txtfy.Enabled = true;
                    }
                    else
                    {
                        this.rdNone.Checked = true;
                    }
                }
                sql = "select cws from jc_dept_property where dept_id=" + this._deptId;
                object objBedNum = InstanceForm.BDatabase.GetDataResult( sql );
                if ( objBedNum == null )
                {
                    txtBedNum.Text = "0";
                }
                else
                {
                    if ( Convert.IsDBNull( objBedNum ) )
                    {
                        txtBedNum.Text = "0";
                    }
                    else
                    {
                        txtBedNum.Text = Convert.ToInt32( objBedNum ).ToString( );
                    }
                }
            }
            else
            {
                //给默认的数字吗
                object objMax = InstanceForm.BDatabase.GetDataResult( "select max(cast(d_code as int)) from jc_dept_property where isnumeric(d_code) = 1 " );
                if ( Convert.IsDBNull( objMax ) )
                {
                    txtdCode.Text = "1";
                }
                else
                {
                    txtdCode.Text = Convert.ToString( Convert.ToInt32( objMax ) + 1 );
                }
                //默认排序
                object objMaxSort=InstanceForm.BDatabase.GetDataResult( "select max(cast(SORT_ID as int))  from jc_dept_property " );
                if (Convert.IsDBNull(objMax)) txtSort.Text = "1";
                else txtSort.Text = Convert.ToString(Convert.ToInt32(objMaxSort) + 10);
                
            }

		}

		
		
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.DialogResult = DialogResult.Cancel ;
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;

			string sql = "";
			int p_id = Convert.ToInt32( this.cboPDept.SelectedValue );
			string name = this.txtName.Text;
            //增加拼音码的处理 2013-2-26
            if (this.txtPym.Text.Trim() == "" && txtName.Text.Trim() != "") this.txtPym.Text = PubStaticFun.GetPYWBM(this.txtName.Text, 0);
			string py_code = this.txtPym.Text ;
            string wb_code = txtName.Text !="" ? PubStaticFun.GetPYWBM(this.txtName.Text, 1) : "";
                   
            string d_code = this.txtdCode.Text;
			int deptId = this._deptId;
			string ward_no = this.txtWardNO.Text;
            int zjjz = chkJz.Checked ? 1 : 0;
			decimal limitValue =0;
			if ( Convertor.IsNumeric(this.txtfy.Text))
				limitValue = Convert.ToDecimal(this.txtfy.Text);

            int bedNum = 0;
            if ( Convertor.IsInteger( this.txtBedNum.Text ) )
                bedNum = Convert.ToInt32( txtBedNum.Text );
            int sort_id = 0;
            if (Convertor.IsInteger(txtSort.Text.Trim()))
            {
                txtSort.Text = txtSort.Text.Trim();
                sort_id = Convert.ToInt32(txtSort.Text);
            }
			//判断选择的上级科室layer
			if ( this._currentStatus == CurrentStatus.新建状态 )
			{
				if ( p_id <=0 )
				{
					this._level = 1;
				}
				else
				{
					object obj = InstanceForm.BDatabase.GetDataResult("select layer from jc_dept_property where dept_id=" + p_id);
					if ( Convert.ToInt32(obj) == 1 )
					{
						this._level = 2;
					}
					else if ( Convert.ToInt32(obj) == 2 )
					{
						this._level = 3;
					}
				}

			}
			#region
			if ( name.Trim() == "" )
			{
				MessageBox.Show("科室名称不能为空");
				return;
			}
			else
			{
				if ( this._currentStatus == CurrentStatus.新建状态 )
				{
					if ( InstanceForm.BDatabase.GetDataRow("select name from jc_dept_property where name='" + name.Trim() + "'") != null )
					{
						if ( MessageBox.Show("有相同的名称科室存在,是否继续","询问",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
							return;
					}
				}
			}
			
			if ( rdWard.Checked && this.txtWardNO.Text.Trim()=="")
			{
				MessageBox.Show("请输入病区编号");
				return;
			}
			//判断病区重复
			if ( this.rdWard.Checked)
			{
				if ( this._currentStatus == CurrentStatus.新建状态 )
				{
					sql = "select * from jc_ward where ward_id='" + this.txtWardNO.Text.Trim() + "'";
					if ( InstanceForm.BDatabase.GetDataRow( sql ) != null )
					{
						MessageBox.Show("病区编号已经存在!");
						return;
					}
				}
				else
				{
					sql = "select * from jc_ward where ward_id='" + this.txtWardNO.Text.Trim() + "' and dept_id <>" + deptId;
					if ( InstanceForm.BDatabase.GetDataRow( sql ) != null )
					{
						MessageBox.Show("修改的病区编号已经存在");
						return;
					}
				}
			}
			//判断取消病区,如果原来是病区，取消后删除关系，删除前判断该病区下是否有科室，有科室不能删除
			if ( _currentStatus == CurrentStatus.修改状态 )
			{
				DataRow drWard = InstanceForm.BDatabase.GetDataRow("select * from jc_wardrdept where ward_id in (select ward_id from jc_ward where dept_id=" + this._deptId + ")");
				if (drWard != null)
				{
					if ( !this.rdWard.Checked )
					{
						MessageBox.Show("该科室为病区并且有子科室,不能取消病区属性,请先取消所包含的科室");
						return;
					}
				}
			}
            //判断数字码
            if ( txtdCode.Text.Trim( ) != "" )
            {
                if ( _currentStatus == CurrentStatus.新建状态 )
                {
                    sql = "select name from jc_dept_property where d_code='" + txtdCode.Text + "'";
                }
                else
                {
                    sql = "select name from jc_dept_property where d_code='" + txtdCode.Text + "' and dept_id<>" + this._deptId;
                }
                DataRow drCode = InstanceForm.BDatabase.GetDataRow( sql );
                if ( drCode != null )
                {
                    MessageBox.Show( "数字码 [" + txtdCode.Text + "] 已经被科室 [" + drCode["name"].ToString( ).Trim() + "] 使用!" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                    return;
                }
            }
			#endregion
			try
			{
				InstanceForm.BDatabase.BeginTransaction();

				#region 写jc_dept_property
				if ( _currentStatus == CurrentStatus.新建状态 )
				{
                    sql = " insert into jc_dept_property ( p_dept_id,layer,name,py_code,wb_code,d_code ,isjz ,cws ,jgbm,sort_id) ";
					sql += " values (" + p_id + "," + this._level + ",'" + name + "','" + py_code + "','" + wb_code + "','" + d_code + "'," +zjjz+ ",0 , '"+InstanceForm._menuTag.Jgbm+"'," + sort_id.ToString() + ")";
					object obj;
					InstanceForm.BDatabase.InsertRecord(sql,out obj);
					if ( obj == null )
					{
						MessageBox.Show("未获取新科室编号");
						InstanceForm.BDatabase.RollbackTransaction();
						return;
					}
					else
					{
						deptId = Convert.ToInt32( obj );
					}
				}
				else
				{
					sql = "update jc_dept_property set p_dept_id=" + p_id + ",name='" + name + "',py_code='" + py_code + "',wb_code='" + wb_code + "',d_code='" + d_code + "',isjz=" + zjjz + ",sort_id=" + sort_id.ToString() + " where dept_id=" + this._deptId;
					InstanceForm.BDatabase.DoCommand( sql );
				}
				#endregion

				#region 保存科室角色
                int mz_flag = 0;
                int jz_flag = 0;
                int zy_flag = 0;
                int yj_flag = 0;
                int sm_flag = 0;
                int hz_flag = 0;
				sql = "delete from jc_dept_type_relation where dept_id=" + this._deptId;
				InstanceForm.BDatabase.DoCommand( sql );
				foreach( ListViewItem item in this.lvwType.Items )
				{
					if ( item.Checked )
					{
						sql = "insert into jc_dept_type_relation( dept_id,type_code ) values (" + deptId + ",'" + item.Tag.ToString().Trim() + "')";
						InstanceForm.BDatabase.DoCommand( sql );
						switch (item.Tag.ToString().Trim())
						{
							case "001": //挂号科室
                                mz_flag = 1;
								break;
							case "002": //门诊科室
                                mz_flag = 1;
								break;
							case "003": //急症科室
                                jz_flag = 1;
								break;
							case "004": //住院科室
                                zy_flag = 1;
								break;
							case "005": //医技科室
                                yj_flag = 1;
								break;
							case "006":
                                sm_flag = 1;
								break;
							case "007":
                                hz_flag = 1;
								break;
						}
					}
				}
                sql = "update jc_dept_property set mz_flag=" +mz_flag+",jz_flag="+jz_flag+",zy_flag="+zy_flag +",yj_flag="+yj_flag+",sm_flag="+sm_flag+",hz_flag="+hz_flag+" where dept_id=" + deptId;
                InstanceForm.BDatabase.DoCommand( sql );
				#endregion
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if(_jgbm == 0)
                    _jgbm = TrasenFrame.Forms.FrmMdiMain.Jgbm;
				if ( _currentStatus == CurrentStatus.新建状态 )
				{
					//如果是病区,写入病区表和自对应关系
					if ( this.rdWard.Checked )
					{
                        sql = "insert into jc_ward (jgbm,ward_id,dept_id,ward_name,py_code) values (" + _jgbm + ",'" + ward_no + "'," + deptId + ",'" + name + "','" + py_code + "')";
						InstanceForm.BDatabase.DoCommand( sql );
                        sql = "insert into jc_wardrdept(jgbm,ward_id,dept_id,minexecye) values (" + _jgbm + ",'" + ward_no + "'," + deptId + ",0)";
						InstanceForm.BDatabase.DoCommand( sql );
					}
					//如果是病区下的科室,写入对应关系
					if( this.rdWardDept.Checked )
					{
                        sql = "insert into jc_wardrdept(jgbm,ward_id,dept_id,minexecye) values (" + _jgbm + ",'" + ward_no + "'," + deptId + "," + limitValue + ")";
						InstanceForm.BDatabase.DoCommand( sql );

                        sql = "update jc_dept_property set cws=" + bedNum + " where dept_id=" + deptId;
                        InstanceForm.BDatabase.DoCommand( sql );
					}
				}
				else
				{
					if ( ! this.rdWard.Checked )
					{
						//修改时,不允许将病区变为普通
						if ( InstanceForm.BDatabase.GetDataRow("select * from  jc_ward where dept_id=" + deptId.ToString()) != null )
						{
							MessageBox.Show("不允许将设置的病区取消，如果要取消，请联系系统管理员处理！");
							InstanceForm.BDatabase.RollbackTransaction();
							return;
						}
						//如果选择的是病区下的科室选项
						if ( rdWardDept.Checked )
						{
							//删除现有关系
							sql = "delete from jc_wardrdept where dept_id=" + deptId;
							InstanceForm.BDatabase.DoCommand(sql);
							//重新写入对应关系
							sql = "insert into jc_wardrdept(jgbm,ward_id,dept_id,minexecye) values (" +_jgbm + ",'" + this.cboWard.SelectedValue.ToString().Trim() + "'," + deptId + "," + limitValue + ")";
							InstanceForm.BDatabase.DoCommand( sql );

                            sql = "update jc_dept_property set cws=" + bedNum + " where dept_id=" + deptId;
                            InstanceForm.BDatabase.DoCommand( sql );
						}
						if ( rdNone.Checked )
						{
							//删除病区的对应关系
							sql = "delete from jc_wardrdept where dept_id=" + deptId;
							InstanceForm.BDatabase.DoCommand( sql );
						}
					}
					else
					{
						if ( InstanceForm.BDatabase.GetDataRow("select * from jc_ward where dept_id =" + deptId.ToString() ) != null )
						{
							sql = "update jc_ward set ward_name = '" + name + "',py_code = '" + py_code + "' where dept_id=" + deptId;
							InstanceForm.BDatabase.DoCommand( sql );
						}
						else
						{
							sql = "insert into jc_ward (jgbm,ward_id,dept_id,ward_name,py_code) values ("+_jgbm + ",'"+ ward_no + "'," + deptId + ",'" + name + "','" + py_code + "')";
							InstanceForm.BDatabase.DoCommand( sql );
						}
						//加入自对应关系
						if ( InstanceForm.BDatabase.GetDataRow("select * from jc_wardrdept where dept_id="+deptId.ToString()) == null )
						{
                            sql = "insert into jc_wardrdept(jgbm,ward_id,dept_id,minexecye) values(" + _jgbm + ",'" + ward_no + "'," + deptId.ToString() + ",0)";
							InstanceForm.BDatabase.DoCommand(sql);
						}
					}
				}
                string sqlup = "update jc_dept_property set jgbm = "+_jgbm+" where dept_id = "+deptId;
                InstanceForm.BDatabase.DoCommand(sqlup);

                //三院数据处理
                string bz = "修改科室:【" + txtName.Text + "】";
                if (_currentStatus == CurrentStatus.新建状态)
                    bz = "添加科室:【" + txtName.Text + "】";
                ts.Save_log(ts_HospData_Share.czlx.jc_科室修改, bz, "jc_dept_property", "dept_id", deptId.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

				InstanceForm.BDatabase.CommitTransaction();
				ReturnDepartment = new Department(deptId,InstanceForm.BDatabase);
				

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch(Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show("保存失败"+err.Message);
			}



            //三院数据处理
            try
            {
                string errtext = "";
                ts_HospData_Share.ts_update_log tss = new ts_HospData_Share.ts_update_log();
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_科室修改, InstanceForm.BDatabase);
                if (ty.Bzx == 1)
                {
                    tss.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                }
                MessageBox.Show("保存成功" + errtext);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

		}

		private void txtName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( (int)e.KeyChar == 13 )
			{
				txtPym.Text = PubStaticFun.GetPYWBM(this.txtName.Text ,0);
                
				cboPDept.Focus();
			}
		}

		
		private void btnDel_Click(object sender, System.EventArgs e)
		{
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;

			if ( MessageBox.Show("确定要将该科室置无效吗？","",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes )
			{
                try
                {
                    InstanceForm.BDatabase.BeginTransaction();

                    string sql = "update jc_dept_property set deleted = 1 where dept_id=" + this._deptId;
                    InstanceForm.BDatabase.DoCommand(sql);

                    //三院数据处理
                    string bz = "停用科室:【" + txtName.Text + "】";
                    ts.Save_log(ts_HospData_Share.czlx.jc_基础数据单表修改, bz, "jc_dept_property", "dept_id", this._deptId.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                    InstanceForm.BDatabase.CommitTransaction();

                    isDelete = true;
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show("发生错误" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //三院数据处理
                try
                {
                    string errtext = "";
                    ts_HospData_Share.ts_update_log tss = new ts_HospData_Share.ts_update_log();
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_基础数据单表修改, InstanceForm.BDatabase);
                    if (ty.Bzx == 1)
                    {
                        tss.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                    }
                    MessageBox.Show("保存成功" + errtext);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("发生错误" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

			}
		}

		private void rdWardDept_CheckedChanged(object sender, System.EventArgs e)
		{
			this.txtfy.Enabled = rdWardDept.Checked;
			this.cboWard.Enabled = rdWardDept.Checked;
            this.txtBedNum.Enabled = rdWardDept.Checked;
		}

		private void rdWard_CheckedChanged(object sender, System.EventArgs e)
		{
			this.txtWardNO.Enabled = rdWard.Checked;
			this.label6.Enabled = rdWard.Checked;
		}

        private void cobjg_selected(object sender, EventArgs e)
        {
            try { Convert.ToInt32(cobjg.SelectedValue.ToString()); }
            catch {return ;}
            _jgbm = Convert.ToInt32(cobjg.SelectedValue.ToString());
        }
	}
}
