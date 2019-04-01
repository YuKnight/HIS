using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_jc_yzxmwh
{
	/// <summary>
	/// FrmEdit 的摘要说明。
    /// 
	/// </summary>
	public class FrmEdit : System.Windows.Forms.Form
	{
		public DataView dataviewYZXM;
		public int currentRowIndex;
		/// <summary>
		/// 当前项目
		/// </summary>
		private OrderItem currentItem;
		/// <summary>
		/// 当前操作类型
		/// </summary>
		private OP_TYPE opType;

		private DataSet _dataset;
				
		Control activeControl ;

		private System.Windows.Forms.TextBox txtPym;
		private System.Windows.Forms.TextBox txtXmmc;
		private System.Windows.Forms.TextBox txtWbm;
		private System.Windows.Forms.TextBox txtJjdw;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.CheckBox chkClose;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtFinddept;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnDefault;
		private System.Windows.Forms.ListView lvwExecDept;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtChargeItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtNum;
		private System.Windows.Forms.ComboBox cboYzfl;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtUsage;
		private System.Windows.Forms.Button btnProvious;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panJC;
		private System.Windows.Forms.Panel panHY;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cboJclx;
		private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboHYLX;
		private System.Windows.Forms.RadioButton rdNone;
		private System.Windows.Forms.RadioButton rdJC;
		private System.Windows.Forms.RadioButton rdHY;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtBZ;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGrid dtgrdOrders;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Button btnAddNew;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSelect;
        private System.ComponentModel.IContainer components;
        private TextBox txtHYYB;
        private DataGridTextBoxColumn dataGridTextBoxColumn1;
        private CheckBox che_fjsmbt;
        private Label lbl_sfxm_delete;
        public Label lbl_sfxm_price;
        private TextBox txtszm;
        private Label label14;

        int _idcode;
		/// <summary>
		/// 项目编号
		/// </summary>
		/// <param name="xmbh"></param>
		public FrmEdit(int orderId)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

            LoadBaseData();
			
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			if ( orderId != 0 )
			{
				currentItem = new OrderItem(orderId);



				ShowItemDetail();
				opType = OP_TYPE.更新项目;
				ShowMatchOrders();
				lblInfo.Text = "<修改项目>";
			}
			else
			{
				currentItem = null;
				opType = OP_TYPE.新增项目;
				lblInfo.Text = "<新增项目>";
			}
            
		}

		public FrmEdit(int ChargeItemId,int TcFlag)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            lbl_sfxm_delete.Text = "";
			LoadBaseData();
			
			currentItem = null;
			opType = OP_TYPE.新增项目;
			
			string sql = "";
			if (TcFlag==0)
                sql = "select item_name,py_code,wb_code,item_unit,retail_price from jc_hsitem where item_id=" + ChargeItemId;
			else
                sql = "select item_name,py_code,wb_code,item_unit,price as retail_price from jc_tc_t where item_id=" + ChargeItemId;
			DataRow dr = InstanceForm.BDatabase.GetDataRow( sql );

			this.txtXmmc.Text = dr["item_name"].ToString().Trim();
			this.txtPym.Text = dr["py_code"].ToString().Trim();
			this.txtWbm.Text = dr["wb_code"].ToString().Trim();
			this.txtJjdw.Text = dr["item_unit"].ToString().Trim();
			this.txtNum.Text = "1";
			this.txtChargeItem.Text = txtXmmc.Text;
  
			ChargeItem item = new ChargeItem();
			item.ItemId = ChargeItemId;
			item.ItemName = txtXmmc.Text;
			item.TcFlag = TcFlag ;

            lbl_sfxm_price.Text =  "单价：" + dr["retail_price"].ToString().Trim();

			this.txtChargeItem.Tag = item;
			
			lvwExecDept.Items.Clear();
			if (TcFlag==0)
				sql="select exec_dept_id from jc_hsitem_dept where tcid=-1 and hsitem_id=" + ChargeItemId;
			else
				sql="select exec_dept_id from jc_hsitem_dept where tcid=" +ChargeItemId + " and hsitem_id=" + ChargeItemId;
			DataTable tableDept = InstanceForm.BDatabase.GetDataTable(sql);

			for ( int i=0;i<tableDept.Rows.Count;i++)
			{
				int deptId = Convert.ToInt32(tableDept.Rows[i]["exec_dept_id"]);
				Department dept = new Department( Convert.ToInt32(deptId),InstanceForm.BDatabase);
				ListViewItem lstItem = new ListViewItem();
				lstItem.Text = dept.DeptName;
				lstItem.ImageIndex = 0;
				if ( lvwExecDept.Items.Count == 0 )
				{
					dept.Default = 1;
					lstItem.ForeColor = Color.Blue;
				}
				lstItem.Tag = dept;
				this.lvwExecDept.Items.Add( lstItem );
			}
			
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
		/// 操作类型
		/// </summary>
		public OP_TYPE OperatorType
		{
			get
			{
				return opType;
			}
			set
			{
				opType = value;
			}
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		private void LoadBaseData()
		{
            lbl_sfxm_price.Text = "";
			_dataset = new DataSet();
			_dataset.Tables.Clear();
			string sql = "select 0 as rowno,id,name as itemname,py_code,wb_code,cast(d_code as varchar(10)) as d_code from jc_usagediction order by id";
			DataTable table = InstanceForm.BDatabase.GetDataTable(sql);
			table.TableName = "USAGE";
			_dataset.Tables.Add(table);
			
			sql = "select 0 as rowno,item_id as id,item_name as itemname,retail_price as price,py_code,wb_code,item_code as d_code,0 as tc_flag from jc_hsitem where delete_bit=0 ";
			sql += " union all ";
			sql += " select 0 as rowno,item_id as id,'*'+ item_name as itemname,price,py_code,wb_code,code as d_code,1 as tc_flag from jc_tc_t where delete_bit=0 ";

			DataTable tableXm = InstanceForm.BDatabase.GetDataTable(sql);


			tableXm.TableName = "SFXM";
			_dataset.Tables.Add(tableXm);

			sql = "select 0 as rowno,dept_id as id,name as itemname,py_code,wb_code,d_code from jc_dept_property where deleted=0 and layer=3 order by dept_id";
			DataTable tableDept = InstanceForm.BDatabase.GetDataTable(sql);
			tableDept.TableName = "DEPT";
			_dataset.Tables.Add(tableDept);

			sql = "select CODE,NAME from jc_ordertype";
			this.cboYzfl.DisplayMember ="NAME";
			this.cboYzfl.ValueMember = "CODE";
			this.cboYzfl.DataSource = InstanceForm.BDatabase.GetDataTable(sql);

			//检查类型
			sql="Select 0 As ROWNO,ID As ID,NAME As NAME,'' As PY_CODE,'' As WB_CODE,'' AS D_CODE From JC_JCCLASSDICTION where class_type=0";
			DataTable tbJC = InstanceForm.BDatabase.GetDataTable( sql );
			this.cboJclx.DisplayMember = "NAME";
			this.cboJclx.ValueMember = "ID";
			this.cboJclx.DataSource = tbJC;
			//化验类型
			sql="Select 0 As ROWNO,ID As ID,NAME As NAME,'' As PY_CODE,'' As WB_CODE,'' AS D_CODE From JC_JCCLASSDICTION where class_type=1";
			DataTable tbHY = InstanceForm.BDatabase.GetDataTable( sql );
			this.cboHYLX.DisplayMember = "NAME";
			this.cboHYLX.ValueMember = "ID";
			this.cboHYLX.DataSource = tbHY;
            //样本
        }
		/// <summary>
		/// 显示项目明细
		/// </summary>
		private void ShowItemDetail()
		{
			try
			{
				this.txtXmmc.Text = currentItem.Order_Name;
				this.txtPym.Text = currentItem.Py_Code;
				this.txtWbm.Text = currentItem.Wb_Code;
                this.txtszm.Text = currentItem.D_Code;
				this.txtJjdw.Text = currentItem.Order_Unit;
				this.txtNum.Text = currentItem.ItemExecNum.ToString();
				this.txtChargeItem.Text = currentItem.ChargeItemName;
				ChargeItem item = new ChargeItem();
				item.ItemId = currentItem.ChargeItemId;
				item.ItemName = currentItem.ChargeItemName;
				item.TcFlag = currentItem.MatchType;
				this.txtChargeItem.Tag = item;
				this.cboYzfl.SelectedValue = currentItem.OrderTypeID;
				this.txtUsage.Text = currentItem.Usage;
				this.txtBZ.Text = currentItem.BZ;
                this.che_fjsmbt.Checked = currentItem.FJSMBT == 1 ? true : false;
                if (currentItem.sfxm_delete_bit == 1) this.lbl_sfxm_delete.Text = "（该收费项目实际已停用）";
                else if (currentItem.sfxm_delete_bit == 2) this.lbl_sfxm_delete.Text = "（该收费项目实际未启用）";
                else this.lbl_sfxm_delete.Text = "";

				lvwExecDept.Items.Clear();
				for ( int i=0;i<currentItem.ExecDeptList.Count;i++)
				{
					TrasenFrame.Classes.Department dept = (TrasenFrame.Classes.Department)currentItem.ExecDeptList[i] ;
					ListViewItem lstItem = new ListViewItem();
					lstItem.Text = dept.DeptName;
					lstItem.Tag = dept;
					lstItem.ImageIndex = 0;
					if ( dept.DeptId == currentItem.DefaultExecDept )
						lstItem.ForeColor = Color.Blue;
					this.lvwExecDept.Items.Add( lstItem );
				}
				//检查化验
				if ( currentItem.IsJCorHY == 0 )
					rdNone.Checked = true;
				else if ( currentItem.IsJCorHY == 1 ) //检查
				{
					rdJC.Checked = true;
					this.cboJclx.SelectedValue = currentItem.JCLX;
				}
				else
				{
					rdHY.Checked = true;
                    _idcode = currentItem.Sample;
                    if(_idcode != 0)
					txtHYYB.Text = InstanceForm.BDatabase.GetDataResult("Select samp_name NAME from LS_AS_SAMPLE where samp_code = " + _idcode.ToString(),60).ToString();
					this.cboHYLX.SelectedValue = currentItem.HYLX;
				}

			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}
		/// <summary>
		/// 显示当前项目配的医嘱
		/// </summary>
		private void ShowMatchOrders()
		{
			if ( this.txtChargeItem.Tag != null )
			{
				try
				{
					ChargeItem item = (ChargeItem)this.txtChargeItem.Tag ;
                   // string sql = @"select ORDER_NAME,ORDER_UNIT,ORDER_TYPE ,dbo.fun_getxmjg(ORDER_NAME)as  PRICE_P 
                    string sql = " select ORDER_NAME,dbo.fun_getxmjg(" + item.ItemId + "," + item.TcFlag + ")as jgxx,ORDER_UNIT,ORDER_TYPE ";
                           sql+= " from jc_hoitemdiction where delete_bit =0 and order_id in (select hoitem_id from jc_hoi_hdi where hditem_id=" + item.ItemId + " and tc_flag=" + item.TcFlag + ")";

					DataTable tbOrders = InstanceForm.BDatabase.GetDataTable(sql);
					this.dtgrdOrders.DataSource = tbOrders;
					
					if ( item.ItemId !=0 )
						this.dtgrdOrders.CaptionText = "[" + item.ItemName.Trim() + "] 已匹配的医嘱";
				}
				catch
				{
					MessageBox.Show("查看已匹配的医嘱发生错误");
				}
			}
		}
		/// <summary>
		/// 判断科室是否选择
		/// </summary>
		/// <param name="srcDept"></param>
		/// <returns></returns>
		private bool DepartmentHasSelected(Department srcDept)
		{
			bool bRet = false;
			foreach(ListViewItem item in lvwExecDept.Items)
			{
				if ( srcDept.DeptId == ((Department)item.Tag).DeptId )
				{
					bRet = true;
					break;
				}
			}
			return bRet ;
		}
		/// <summary>
		/// 清除内容
		/// </summary>
		private void ClearContent()
		{
		}

		private void RadioButtonCheckChange(object sender,System.EventArgs e )
		{
			RadioButton rd = (RadioButton)sender;
			if ( rd.Checked )
			{
				if ( rd == rdNone  )
				{
					this.panHY.Enabled = false;
					this.panJC.Enabled = false;
				}
				else if ( rd == rdJC )
				{
					this.panHY.Enabled = false;
					this.panJC.Enabled = true;
				}
				else
				{
					this.panHY.Enabled = true;
					this.panJC.Enabled = false;
				}
			}
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEdit));
            this.txtPym = new System.Windows.Forms.TextBox();
            this.txtXmmc = new System.Windows.Forms.TextBox();
            this.txtWbm = new System.Windows.Forms.TextBox();
            this.txtJjdw = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnProvious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lvwExecDept = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFinddept = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.cboYzfl = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChargeItem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rdNone = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.rdJC = new System.Windows.Forms.RadioButton();
            this.rdHY = new System.Windows.Forms.RadioButton();
            this.panJC = new System.Windows.Forms.Panel();
            this.cboJclx = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panHY = new System.Windows.Forms.Panel();
            this.che_fjsmbt = new System.Windows.Forms.CheckBox();
            this.txtHYYB = new System.Windows.Forms.TextBox();
            this.cboHYLX = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBZ = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtgrdOrders = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_sfxm_delete = new System.Windows.Forms.Label();
            this.lbl_sfxm_price = new System.Windows.Forms.Label();
            this.txtszm = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panJC.SuspendLayout();
            this.panHY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdOrders)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPym
            // 
            this.txtPym.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtPym.Location = new System.Drawing.Point(258, 94);
            this.txtPym.MaxLength = 30;
            this.txtPym.Name = "txtPym";
            this.txtPym.Size = new System.Drawing.Size(108, 23);
            this.txtPym.TabIndex = 3;
            // 
            // txtXmmc
            // 
            this.txtXmmc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXmmc.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtXmmc.Location = new System.Drawing.Point(84, 62);
            this.txtXmmc.MaxLength = 30;
            this.txtXmmc.Name = "txtXmmc";
            this.txtXmmc.Size = new System.Drawing.Size(485, 23);
            this.txtXmmc.TabIndex = 0;
            this.txtXmmc.TextChanged += new System.EventHandler(this.txtXmmc_TextChanged);
            this.txtXmmc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXmmc_KeyPress);
            // 
            // txtWbm
            // 
            this.txtWbm.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtWbm.Location = new System.Drawing.Point(84, 94);
            this.txtWbm.MaxLength = 30;
            this.txtWbm.Name = "txtWbm";
            this.txtWbm.Size = new System.Drawing.Size(122, 23);
            this.txtWbm.TabIndex = 2;
            // 
            // txtJjdw
            // 
            this.txtJjdw.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtJjdw.Location = new System.Drawing.Point(575, 96);
            this.txtJjdw.MaxLength = 30;
            this.txtJjdw.Name = "txtJjdw";
            this.txtJjdw.Size = new System.Drawing.Size(88, 23);
            this.txtJjdw.TabIndex = 5;
            this.txtJjdw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJjdw_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(210, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 21;
            this.label4.Text = "拼音码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(20, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "五笔码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(20, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "医嘱名称";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label8.Location = new System.Drawing.Point(537, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 25;
            this.label8.Text = "单位";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSave.Location = new System.Drawing.Point(883, 153);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCancel.Location = new System.Drawing.Point(883, 456);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消(&X)";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkClose
            // 
            this.chkClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkClose.Location = new System.Drawing.Point(16, 486);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(110, 18);
            this.chkClose.TabIndex = 44;
            this.chkClose.Text = "保存完关闭窗口";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 34);
            this.panel1.TabIndex = 45;
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblInfo.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(252, 30);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "<>";
            // 
            // btnProvious
            // 
            this.btnProvious.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnProvious.Location = new System.Drawing.Point(883, 54);
            this.btnProvious.Name = "btnProvious";
            this.btnProvious.Size = new System.Drawing.Size(75, 23);
            this.btnProvious.TabIndex = 4;
            this.btnProvious.Text = "上一记录";
            this.btnProvious.UseVisualStyleBackColor = false;
            this.btnProvious.Click += new System.EventHandler(this.btnProvious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnNext.Location = new System.Drawing.Point(883, 86);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一记录";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lvwExecDept);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(669, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 160);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "执行科室";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(4, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 12);
            this.label13.TabIndex = 3;
            this.label13.Text = "在此输入科室检索码";
            // 
            // lvwExecDept
            // 
            this.lvwExecDept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwExecDept.LargeImageList = this.imageList1;
            this.lvwExecDept.Location = new System.Drawing.Point(3, 17);
            this.lvwExecDept.Name = "lvwExecDept";
            this.lvwExecDept.Size = new System.Drawing.Size(198, 97);
            this.lvwExecDept.SmallImageList = this.imageList1;
            this.lvwExecDept.TabIndex = 2;
            this.lvwExecDept.UseCompatibleStateImageBehavior = false;
            this.lvwExecDept.View = System.Windows.Forms.View.List;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFinddept);
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.btnDefault);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 22);
            this.panel2.TabIndex = 1;
            // 
            // txtFinddept
            // 
            this.txtFinddept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFinddept.Location = new System.Drawing.Point(0, 0);
            this.txtFinddept.MaxLength = 30;
            this.txtFinddept.Name = "txtFinddept";
            this.txtFinddept.Size = new System.Drawing.Size(100, 21);
            this.txtFinddept.TabIndex = 0;
            this.txtFinddept.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFinddept_KeyPress);
            this.txtFinddept.Enter += new System.EventHandler(this.txtFinddept_Enter);
            // 
            // btnDel
            // 
            this.btnDel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDel.Location = new System.Drawing.Point(100, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(48, 22);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "移除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDefault.Location = new System.Drawing.Point(148, 0);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(50, 22);
            this.btnDefault.TabIndex = 1;
            this.btnDefault.Text = "设默认";
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // cboYzfl
            // 
            this.cboYzfl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYzfl.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboYzfl.Location = new System.Drawing.Point(84, 132);
            this.cboYzfl.MaxDropDownItems = 30;
            this.cboYzfl.Name = "cboYzfl";
            this.cboYzfl.Size = new System.Drawing.Size(282, 22);
            this.cboYzfl.TabIndex = 5;
            this.cboYzfl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboYzfl_KeyPress);
            this.cboYzfl.SelectedValueChanged += new System.EventHandler(this.cboYzfl_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(20, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 48;
            this.label2.Text = "医嘱分类";
            // 
            // txtChargeItem
            // 
            this.txtChargeItem.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtChargeItem.Location = new System.Drawing.Point(4, 4);
            this.txtChargeItem.Name = "txtChargeItem";
            this.txtChargeItem.Size = new System.Drawing.Size(432, 23);
            this.txtChargeItem.TabIndex = 7;
            this.txtChargeItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChargeItem_KeyPress);
            this.txtChargeItem.Enter += new System.EventHandler(this.txtChargeItem_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(16, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 49;
            this.label1.Text = "对应的收费项目";
            // 
            // txtNum
            // 
            this.txtNum.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtNum.Location = new System.Drawing.Point(631, 166);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(32, 23);
            this.txtNum.TabIndex = 8;
            this.txtNum.Text = "1";
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label6.Location = new System.Drawing.Point(599, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 53;
            this.label6.Text = "次数";
            // 
            // txtUsage
            // 
            this.txtUsage.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtUsage.Location = new System.Drawing.Point(2, 2);
            this.txtUsage.MaxLength = 30;
            this.txtUsage.Name = "txtUsage";
            this.txtUsage.Size = new System.Drawing.Size(240, 23);
            this.txtUsage.TabIndex = 6;
            this.txtUsage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsage_KeyPress);
            this.txtUsage.Enter += new System.EventHandler(this.txtUsage_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label7.Location = new System.Drawing.Point(369, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 54;
            this.label7.Text = "用法";
            // 
            // rdNone
            // 
            this.rdNone.Checked = true;
            this.rdNone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdNone.Location = new System.Drawing.Point(110, 216);
            this.rdNone.Name = "rdNone";
            this.rdNone.Size = new System.Drawing.Size(48, 24);
            this.rdNone.TabIndex = 9;
            this.rdNone.TabStop = true;
            this.rdNone.Text = "无";
            this.rdNone.CheckedChanged += new System.EventHandler(this.RadioButtonCheckChange);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label9.Location = new System.Drawing.Point(18, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 14);
            this.label9.TabIndex = 57;
            this.label9.Text = "该项目属于:";
            // 
            // rdJC
            // 
            this.rdJC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdJC.Location = new System.Drawing.Point(189, 216);
            this.rdJC.Name = "rdJC";
            this.rdJC.Size = new System.Drawing.Size(65, 24);
            this.rdJC.TabIndex = 10;
            this.rdJC.Text = "检查";
            this.rdJC.CheckedChanged += new System.EventHandler(this.RadioButtonCheckChange);
            // 
            // rdHY
            // 
            this.rdHY.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdHY.Location = new System.Drawing.Point(282, 216);
            this.rdHY.Name = "rdHY";
            this.rdHY.Size = new System.Drawing.Size(68, 24);
            this.rdHY.TabIndex = 11;
            this.rdHY.Text = "化验";
            this.rdHY.CheckedChanged += new System.EventHandler(this.RadioButtonCheckChange);
            // 
            // panJC
            // 
            this.panJC.Controls.Add(this.cboJclx);
            this.panJC.Controls.Add(this.label10);
            this.panJC.Enabled = false;
            this.panJC.Location = new System.Drawing.Point(12, 242);
            this.panJC.Name = "panJC";
            this.panJC.Size = new System.Drawing.Size(348, 66);
            this.panJC.TabIndex = 60;
            // 
            // cboJclx
            // 
            this.cboJclx.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cboJclx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJclx.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboJclx.Location = new System.Drawing.Point(78, 12);
            this.cboJclx.MaxDropDownItems = 30;
            this.cboJclx.Name = "cboJclx";
            this.cboJclx.Size = new System.Drawing.Size(260, 22);
            this.cboJclx.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label10.Location = new System.Drawing.Point(6, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 50;
            this.label10.Text = "检查类型：";
            // 
            // panHY
            // 
            this.panHY.Controls.Add(this.che_fjsmbt);
            this.panHY.Controls.Add(this.txtHYYB);
            this.panHY.Controls.Add(this.cboHYLX);
            this.panHY.Controls.Add(this.label12);
            this.panHY.Controls.Add(this.label11);
            this.panHY.Enabled = false;
            this.panHY.Location = new System.Drawing.Point(374, 242);
            this.panHY.Name = "panHY";
            this.panHY.Size = new System.Drawing.Size(348, 74);
            this.panHY.TabIndex = 61;
            // 
            // che_fjsmbt
            // 
            this.che_fjsmbt.AutoSize = true;
            this.che_fjsmbt.Location = new System.Drawing.Point(79, 55);
            this.che_fjsmbt.Name = "che_fjsmbt";
            this.che_fjsmbt.Size = new System.Drawing.Size(216, 16);
            this.che_fjsmbt.TabIndex = 56;
            this.che_fjsmbt.Text = "开本医嘱(化验)时必须填写附加说明";
            this.che_fjsmbt.UseVisualStyleBackColor = true;
            // 
            // txtHYYB
            // 
            this.txtHYYB.Location = new System.Drawing.Point(79, 5);
            this.txtHYYB.Name = "txtHYYB";
            this.txtHYYB.Size = new System.Drawing.Size(260, 21);
            this.txtHYYB.TabIndex = 55;
            this.txtHYYB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHYYB_KeyPress);
            // 
            // cboHYLX
            // 
            this.cboHYLX.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cboHYLX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHYLX.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cboHYLX.Location = new System.Drawing.Point(79, 30);
            this.cboHYLX.Name = "cboHYLX";
            this.cboHYLX.Size = new System.Drawing.Size(260, 22);
            this.cboHYLX.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label12.Location = new System.Drawing.Point(10, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 54;
            this.label12.Text = "化验类型：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label11.Location = new System.Drawing.Point(10, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 52;
            this.label11.Text = "化验样本：";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(9, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(864, 3);
            this.groupBox3.TabIndex = 62;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // txtBZ
            // 
            this.txtBZ.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtBZ.Location = new System.Drawing.Point(575, 62);
            this.txtBZ.Name = "txtBZ";
            this.txtBZ.Size = new System.Drawing.Size(88, 23);
            this.txtBZ.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(13, 210);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(946, 3);
            this.groupBox4.TabIndex = 63;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // dtgrdOrders
            // 
            this.dtgrdOrders.AllowSorting = false;
            this.dtgrdOrders.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgrdOrders.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dtgrdOrders.CaptionForeColor = System.Drawing.SystemColors.Desktop;
            this.dtgrdOrders.DataMember = "";
            this.dtgrdOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgrdOrders.Location = new System.Drawing.Point(10, 326);
            this.dtgrdOrders.Name = "dtgrdOrders";
            this.dtgrdOrders.ReadOnly = true;
            this.dtgrdOrders.Size = new System.Drawing.Size(860, 156);
            this.dtgrdOrders.TabIndex = 64;
            this.dtgrdOrders.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.dtgrdOrders;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "医嘱名称";
            this.dataGridTextBoxColumn1.MappingName = "ORDER_NAME";
            this.dataGridTextBoxColumn1.Width = 200;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "医嘱项目及价格信息";
            this.dataGridTextBoxColumn7.MappingName = "jgxx";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 350;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "单位";
            this.dataGridTextBoxColumn8.MappingName = "ORDER_UNIT";
            this.dataGridTextBoxColumn8.Width = 75;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "类型";
            this.dataGridTextBoxColumn9.MappingName = "ORDER_TYPE";
            this.dataGridTextBoxColumn9.Width = 75;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAddNew.Location = new System.Drawing.Point(883, 184);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 65;
            this.btnAddNew.Text = "新增(&A)";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSelect);
            this.panel3.Controls.Add(this.txtChargeItem);
            this.panel3.Location = new System.Drawing.Point(116, 162);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(477, 32);
            this.panel3.TabIndex = 66;
            // 
            // btnSelect
            // 
            this.btnSelect.ImageIndex = 1;
            this.btnSelect.ImageList = this.imageList1;
            this.btnSelect.Location = new System.Drawing.Point(442, 5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(32, 22);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtUsage);
            this.panel4.Location = new System.Drawing.Point(417, 130);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(245, 26);
            this.panel4.TabIndex = 67;
            // 
            // lbl_sfxm_delete
            // 
            this.lbl_sfxm_delete.AutoSize = true;
            this.lbl_sfxm_delete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_sfxm_delete.ForeColor = System.Drawing.Color.Red;
            this.lbl_sfxm_delete.Location = new System.Drawing.Point(11, 197);
            this.lbl_sfxm_delete.Name = "lbl_sfxm_delete";
            this.lbl_sfxm_delete.Size = new System.Drawing.Size(187, 14);
            this.lbl_sfxm_delete.TabIndex = 68;
            this.lbl_sfxm_delete.Text = "（该收费项目实际已停用）";
            // 
            // lbl_sfxm_price
            // 
            this.lbl_sfxm_price.AutoSize = true;
            this.lbl_sfxm_price.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_sfxm_price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_sfxm_price.Location = new System.Drawing.Point(228, 197);
            this.lbl_sfxm_price.Name = "lbl_sfxm_price";
            this.lbl_sfxm_price.Size = new System.Drawing.Size(35, 14);
            this.lbl_sfxm_price.TabIndex = 69;
            this.lbl_sfxm_price.Text = "单价";
            // 
            // txtszm
            // 
            this.txtszm.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtszm.Location = new System.Drawing.Point(417, 95);
            this.txtszm.MaxLength = 30;
            this.txtszm.Name = "txtszm";
            this.txtszm.Size = new System.Drawing.Size(114, 23);
            this.txtszm.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label14.Location = new System.Drawing.Point(369, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 14);
            this.label14.TabIndex = 71;
            this.label14.Text = "数字码";
            // 
            // FrmEdit
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(965, 506);
            this.Controls.Add(this.txtszm);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.dtgrdOrders);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtBZ);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPym);
            this.Controls.Add(this.txtXmmc);
            this.Controls.Add(this.txtWbm);
            this.Controls.Add(this.txtJjdw);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panHY);
            this.Controls.Add(this.panJC);
            this.Controls.Add(this.rdHY);
            this.Controls.Add(this.rdJC);
            this.Controls.Add(this.rdNone);
            this.Controls.Add(this.cboYzfl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkClose);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnProvious);
            this.Controls.Add(this.lbl_sfxm_delete);
            this.Controls.Add(this.lbl_sfxm_price);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医嘱项目编辑";
            this.Load += new System.EventHandler(this.FrmEdit_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panJC.ResumeLayout(false);
            this.panJC.PerformLayout();
            this.panHY.ResumeLayout(false);
            this.panHY.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdOrders)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void FrmEdit_Load(object sender, System.EventArgs e)
		{
			//LoadBaseData();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			#region 判断
			if (txtXmmc.Text.Trim()=="")
			{
				MessageBox.Show("医嘱名称不能为空");
				return;
			}
			if ( txtJjdw.Text.Trim() == "" && Convert.ToInt32(this.cboYzfl.SelectedValue) != 7 )
			{
				MessageBox.Show("单位不能为空");
				return;
			}
			if ( ! Convertor.IsNumeric(txtNum.Text) )
			{
				MessageBox.Show("数量格式不正确");
				return;
			}
			if ( Convert.ToInt32(this.cboYzfl.SelectedValue)!=7)
			{

                if (txtChargeItem.Tag == null || ((ChargeItem)this.txtChargeItem.Tag).ItemId == 0 || txtChargeItem.Text == "")
				{
					MessageBox.Show("非说明性医嘱请指定对应的收费项目");
					return;
				}
			}
			if ( !rdNone.Checked  )
			{
				if ( this.lvwExecDept.Items.Count == 0 )
				{
					MessageBox.Show("指定了检查或化验的项目必须输入一个执行科室并指定为默认科室");
					return;
				}
				else
				{
					bool setDefault = false;
					foreach(ListViewItem item in this.lvwExecDept.Items)
					{
						if ( ((Department)item.Tag).Default == 1 )
						{
							setDefault = true;
							break;
						}
					}
					if ( ! setDefault )
					{
						MessageBox.Show("指定了检查或化验的项目必须指定一个默认科室");
						return;
					}
				}
			}
			if ( opType == OP_TYPE.新增项目)
			{
				DataRow dr = InstanceForm.BDatabase.GetDataRow("select * from jc_hoitemdiction where order_name='" + this.txtXmmc.Text + "' and order_unit='" + this.txtJjdw.Text + "' and DEFAULT_USAGE='" + this.txtUsage.Text + "' and bz='" + this.txtBZ.Text + "' and order_type=" + Convert.ToInt32(this.cboYzfl.SelectedValue) );
				if ( dr != null )
				{
					if ( Convert.ToInt32(dr["DELETE_BIT"]) == 0 )
					{
						if ( MessageBox.Show("已经有相同名称，类型，单位，用法，备注的医嘱项目存在，是否继续保存？","",MessageBoxButtons.YesNo,MessageBoxIcon.Question )==DialogResult.No )
						{
							return;
						}
					}
					else
					{
						MessageBox.Show("已经有相同名称，类型，单位，用法，备注的医嘱项目存在,已经停用，如要使用，请将之恢复");
						return;
					}
					
				}
			}

			#endregion
			try
			{
				if ( currentItem == null )
					currentItem = new OrderItem();

				currentItem.Order_Name = this.txtXmmc.Text;
				currentItem.Py_Code = this.txtPym.Text;
				currentItem.Wb_Code = this.txtWbm.Text;
                currentItem.D_Code = this.txtszm.Text.Trim();
				currentItem.OrderTypeID = Convert.ToInt32(this.cboYzfl.SelectedValue);
				currentItem.Usage = this.txtUsage.Text;
				currentItem.Order_Unit = this.txtJjdw.Text;
				currentItem.BZ = this.txtBZ.Text.Trim();
				currentItem.ItemExecNum =  Convertor.IsNumeric( this.txtNum.Text ) ? Convert.ToInt32(this.txtNum.Text) : 1;
				if ( this.txtChargeItem.Text.Trim() !="" && txtChargeItem.Tag != null && txtChargeItem.Enabled ==true )
				{
					currentItem.ChargeItemId = ((ChargeItem)txtChargeItem.Tag).ItemId;
					currentItem.MatchType = ((ChargeItem)txtChargeItem.Tag).TcFlag;
				}
				else
				{
					currentItem.ChargeItemId = 0;
				}

				if (currentItem.ExecDeptList!=null )
					currentItem.ExecDeptList.Clear();
				else
					currentItem.ExecDeptList = new ArrayList();

				currentItem.DefaultExecDept = 0;
				foreach(ListViewItem item in this.lvwExecDept.Items)
				{				
					Department dept = (Department)item.Tag;
					currentItem.ExecDeptList.Add(dept);
					if ( item.ForeColor == Color.Blue )
						currentItem.DefaultExecDept = dept.DeptId;
				}
				currentItem.IsJCorHY=0;
                currentItem.FJSMBT = 0; //2012-11-21 增加 附加说明必填
				if ( rdHY.Checked ) //化验
				{
					currentItem.IsJCorHY = 2;
                    currentItem.Sample = _idcode;
					currentItem.HYLX = Convert.ToInt32( cboHYLX.SelectedValue );
                    currentItem.FJSMBT = che_fjsmbt.Checked ? byte.Parse("1") : byte.Parse("0");//2012-11-21 增加 附加说明必填
				}
				if ( rdJC.Checked ) //检查
				{
					currentItem.IsJCorHY = 1;
					currentItem.JCLX = Convert.ToInt32(cboJclx.SelectedValue);
 
				}
				if ( currentItem.Save(this.opType) )
				{
					MessageBox.Show("保存成功");
				}
				
				if ( this.chkClose.Checked )
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					if ( opType == OP_TYPE.新增项目)
					{
                        cantxt();
					}
					else
					{
						//将当前状态改为新增,
						opType = OP_TYPE.新增项目;
                        cantxt();
					}
					if ( this.txtChargeItem.Tag != null )
					{
						ShowMatchOrders();
					}
				}
			}
			catch(Exception err)
			{
				if ( currentItem.Order_Id == 0 )
				{
					currentItem =null;
				}
				MessageBox.Show(err.Message);
			}
		}

        private void cantxt()
        {
            currentItem = null;
            txtXmmc.Text = "";
            this.txtPym.Text = "";
            this.txtWbm.Text = "";
            this.txtszm.Text = "";
            this.txtBZ.Text = "";
            this.txtJjdw.Text = "";
            this.cboYzfl.Text = "";
            this.txtUsage.Text = "";
            this.txtNum.Text = "";
            rdNone.Checked = true;
            lvwExecDept.Clear();
            //dtgrdOrders.DataSource = null;
            txtXmmc.Focus();
            lblInfo.Text = "<新增项目>";
        }

		private void txtXmmc_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( (int)e.KeyChar == 13 )
			{
				this.txtPym.Text = PubStaticFun.GetPYWBM(this.txtXmmc.Text,0);
				this.txtWbm.Text = PubStaticFun.GetPYWBM(this.txtXmmc.Text,1);
				this.txtJjdw.Focus();
			}
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			if ( lvwExecDept.SelectedItems.Count != 0 )
			{
				lvwExecDept.Items.Remove(lvwExecDept.SelectedItems[0]);
			}
		}

		private void btnDefault_Click(object sender, System.EventArgs e)
		{
			if ( lvwExecDept.SelectedItems.Count == 1 )
			{
				foreach(ListViewItem item in lvwExecDept.Items)
				{
					item.ForeColor = Color.Black;
					((Department)item.Tag).Default = 0;
				}

				lvwExecDept.SelectedItems[0].ForeColor = Color.Blue;
				((Department)lvwExecDept.SelectedItems[0].Tag).Default = 1;
			}
		}

		private void txtFinddept_Enter(object sender, System.EventArgs e)
		{
			activeControl = txtFinddept;
			InputLanguage.CurrentInputLanguage = PubStaticFun.GetInputLanguage("中文(中国)");
		}

		private struct ChargeItem
		{
			public string ItemName;
			public int ItemId;
			public int TcFlag;

		}

		private void txtUsage_Enter(object sender, System.EventArgs e)
		{
			InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
		}

		private void txtChargeItem_Enter(object sender, System.EventArgs e)
		{
            txtChargeItem.ImeMode = ImeMode.Close;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnProvious_Click(object sender, System.EventArgs e)
		{
			if ( this.dataviewYZXM != null )
			{
				currentRowIndex --;
				if ( currentRowIndex == -1 )
				{
					currentRowIndex = 0;
					return;
				}
				int itemId = Convert.ToInt32(this.dataviewYZXM[currentRowIndex]["order_id"]);
				currentItem = new OrderItem(itemId);
				ShowItemDetail();
				this.ShowMatchOrders();
				opType = OP_TYPE.更新项目;
				lblInfo.Text = "<修改项目>";
			}
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if ( this.dataviewYZXM != null )
			{
				currentRowIndex ++;
				if ( currentRowIndex == dataviewYZXM.Count )
				{
					currentRowIndex --;
					return;
				}
				int itemId = Convert.ToInt32(this.dataviewYZXM[currentRowIndex]["order_id"]);
				currentItem = new OrderItem(itemId);
				ShowItemDetail();
				this.ShowMatchOrders();
				opType = OP_TYPE.更新项目;
				lblInfo.Text = "<修改项目>";
			}
		}

		private void cboYzfl_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if ( cboYzfl.SelectedValue == null ) return;
			string sTypeCode = cboYzfl.SelectedValue.ToString();
			if ( sTypeCode.Trim() == "7")
			{
				txtChargeItem.Enabled = false;
				txtChargeItem.Tag = null;
				txtChargeItem.Text = "";
			}
			else
			{
				txtChargeItem.Enabled = true;
				//显示当前医嘱对应的收费项目
				if ( this.opType == OP_TYPE.更新项目)
				{
					ChargeItem item = new ChargeItem();
					item.ItemId = this.currentItem.ChargeItemId;
					item.ItemName = this.currentItem.ChargeItemName;
					item.TcFlag = this.currentItem.MatchType;
					this.txtChargeItem.Text = item.ItemName;
					this.txtChargeItem.Tag = item;
				}
			}
		}

		private void txtXmmc_TextChanged(object sender, System.EventArgs e)
		{
			if ( this.txtXmmc.Text == "" )
			{
				this.txtPym.Text = PubStaticFun.GetPYWBM(this.txtXmmc.Text,0);
				this.txtWbm.Text = PubStaticFun.GetPYWBM(this.txtXmmc.Text,1);
			}
		}

		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			opType = OP_TYPE.新增项目;
			currentItem = null;
			txtXmmc.Text = "";
			this.txtPym.Text = "";
			this.txtWbm.Text = "";
			txtXmmc.Focus();
			lblInfo.Text = "<新增项目>";
		}

		private void txtChargeItem_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( (int)e.KeyChar == 13 )
			{
				txtFinddept.Focus();
			}
			if ( (e.KeyChar>='a' && e.KeyChar <='z') || (e.KeyChar>='A' && e.KeyChar <='Z') || (int)e.KeyChar >=48 && (int)e.KeyChar<=57 )
			{
                string[] headText = new string[] { "国家编码" , "名称" , "拼音码" , "单位" , "单价" , "套餐" , "内码" };
                string[] mappName = new string[] { "std_code" , "item_name" , "py_code" , "item_unit" , "retail_price" , "tc_flag" , "item_id" };
                int[] colWidth = new int[] { 75 , 300 , 75 , 50 , 65 , 50 , 50 };
                string[] searchFields = new string[] { "std_code" , "py_code" };
				
				string sql = "select item_id ,std_code,item_name ,retail_price,py_code,0 as tc_flag from jc_hsitem where retail_price<>0 and delete_bit=0 ";
				sql += " union all ";
				sql += " select item_id ,'','*'+ item_name ,price as retail_price,py_code,1 as tc_flag from jc_tc_t where delete_bit=0 ";

				DataTable tableXm = InstanceForm.BDatabase.GetDataTable(sql);

                TrasenFrame.Forms.FrmSelectCard selectCard = new TrasenFrame.Forms.FrmSelectCard( searchFields , headText , mappName , colWidth );
				selectCard.sourceDataTable = tableXm;
				selectCard.ReciveString = e.KeyChar.ToString();
                selectCard.Width = 800;// 550;
                selectCard.Height = 300;// 200;
				selectCard.srcControl = txtChargeItem;
				selectCard.WorkForm = this;
				selectCard.ShowDialog();
				e.Handled = true;
				if ( selectCard.DialogResult == DialogResult.OK)
				{
					ChargeItem item = new ChargeItem();
					item.ItemId = Convert.ToInt32(selectCard.SelectDataRow["item_id"]);
					item.ItemName = selectCard.SelectDataRow["item_name"].ToString().Trim();
					item.TcFlag = Convert.ToInt32( selectCard.SelectDataRow["tc_flag"] );

   
                    lbl_sfxm_price.Text = "单价：" + selectCard.SelectDataRow["retail_price"].ToString();
					this.txtChargeItem.Text = item.ItemName;
					this.txtChargeItem.Tag = item;
                    this.lbl_sfxm_delete.Text = "";
					//查找该项目的执行科室并在列表中显示
					sql = "select exec_dept_id from jc_hsitem_dept where hsitem_id=" + item.ItemId + " and tcid = -1";
					if ( item.TcFlag == 1 )
						sql = "select exec_dept_id from jc_hsitem_dept where hsitem_id=" + item.ItemId + " and tcid=" + item.ItemId;
					DataTable tableDept = InstanceForm.BDatabase.GetDataTable( sql );
					for ( int i = 0 ; i< tableDept.Rows.Count ; i ++ )
					{
						int deptId = Convert.ToInt32(tableDept.Rows[i]["exec_dept_id"]);
						try
						{
							Department dept = new Department(deptId,InstanceForm.BDatabase);
							if (dept != null && !DepartmentHasSelected(dept))
							{
								ListViewItem itemDept = new ListViewItem();
								itemDept.Text = dept.DeptName;
								itemDept.Tag = dept;
								itemDept.ImageIndex = 0;
								this.lvwExecDept.Items.Add(itemDept);
							}
						}
						catch(Exception err)
						{
							MessageBox.Show(err.Message);
						}
					}
					if ( this.txtXmmc.Text == "" )
					{
						this.txtXmmc.Text = item.ItemName;
						this.txtWbm.Text = PubStaticFun.GetPYWBM(item.ItemName,1);
						this.txtPym.Text = PubStaticFun.GetPYWBM(item.ItemName,0);
						this.txtXmmc.Focus();
					}
					this.ShowMatchOrders();
				}
			}
		}

		private void txtUsage_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( (int)e.KeyChar == 13 )
			{
				txtFinddept.Focus();
			}
			if ( (e.KeyChar>='a' && e.KeyChar <='z') || (e.KeyChar>='A' && e.KeyChar <='Z') || (int)e.KeyChar >=48 && (int)e.KeyChar<=57 )
			{
				string[] headText = new string[]{"id","名称","拼音码"};
				string[] mappName = new string[]{"id","name","py_code"};
				int[] colWidth = new int[]{0,120,75};
				string[] searchFields = new string[]{"py_code"};
				string sql = "select id,name ,py_code from jc_usagediction order by id";
				DataTable table = InstanceForm.BDatabase.GetDataTable(sql);

                TrasenFrame.Forms.FrmSelectCard selectCard = new TrasenFrame.Forms.FrmSelectCard( searchFields , headText , mappName , colWidth );
				selectCard.sourceDataTable = table;
				selectCard.ReciveString = e.KeyChar.ToString();
				selectCard.Width = 300;
				selectCard.Height = 350;
				selectCard.srcControl = txtUsage;
				selectCard.WorkForm = this;
				selectCard.ShowDialog();
				e.Handled = true;
				if ( selectCard.DialogResult == DialogResult.OK)
				{
					this.txtUsage.Text = selectCard.SelectDataRow["name"].ToString().Trim();
				}
			}
		}

		private void txtFinddept_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( (int)e.KeyChar == 13 )
			{
				btnSave.Focus();
			}
			if ( (e.KeyChar>='a' && e.KeyChar <='z') || (e.KeyChar>='A' && e.KeyChar <='Z') || (int)e.KeyChar >=48 && (int)e.KeyChar<=57 )
			{
				string[] headText = new string[]{"id","名称","拼音码"};
				string[] mappName = new string[]{"dept_id","name","py_code"};
				int[] colWidth = new int[]{0,120,75};
				string[] searchFields = new string[]{"py_code"};
				string sql = "select dept_id ,name ,py_code from jc_dept_property where deleted=0 and layer=3 order by dept_id";
				DataTable tableDept = InstanceForm.BDatabase.GetDataTable(sql);

                TrasenFrame.Forms.FrmSelectCard selectCard = new TrasenFrame.Forms.FrmSelectCard( searchFields , headText , mappName , colWidth );
				selectCard.sourceDataTable = tableDept;
				selectCard.ReciveString = e.KeyChar.ToString();
				selectCard.Width = 260;
				selectCard.Height = 300;
				selectCard.srcControl = txtFinddept;
				selectCard.WorkForm = this;
				selectCard.ShowDialog();
				e.Handled = true;
				if ( selectCard.DialogResult == DialogResult.OK)
				{
					int deptId = Convert.ToInt32(selectCard.SelectDataRow["dept_id"]);
					Department dept = new Department(deptId,InstanceForm.BDatabase);
					if (dept != null && !DepartmentHasSelected(dept))
					{
						ListViewItem item = new ListViewItem();
						if ( lvwExecDept.Items.Count == 0 )
						{
							item.ForeColor = Color.Blue;
							dept.Default = 1;
						}
						item.Text = dept.DeptName;
						item.Tag = dept;
						item.ImageIndex = 0;
					

						this.lvwExecDept.Items.Add(item);
						this.txtFinddept.Text = "";
					}

				}
			}
		}

		private void txtJjdw_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( (int)e.KeyChar == 13 )
			{
				cboYzfl.Focus();
			}
		}

		private void cboYzfl_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( (int)e.KeyChar == 13 )
			{
				txtUsage.Focus();
			}
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{

            string[] headText = new string[] { "国家编码" , "名称" , "拼音码" , "单位" , "单价" , "套餐" , "内码" ,"备注"};
            string[] mappName = new string[] { "std_code", "item_name", "py_code", "item_unit", "retail_price", "tc_flag", "item_id", "item_describe" };
			int[] colWidth = new int[]{75,200,75,50,65,50,50,50};
			string[] searchFields = new string[]{"std_code","py_code"};
            string sql = "select item_describe,item_id ,std_code,item_name ,retail_price,py_code,0 as tc_flag from jc_hsitem where  delete_bit=0 ";
			sql += " union all ";
			sql += " select '',item_id ,'','*'+ item_name ,price as retail_price,py_code,1 as tc_flag from jc_tc_t where delete_bit=0 ";
			DataTable tableXm = InstanceForm.BDatabase.GetDataTable(sql);
            TrasenFrame.Forms.FrmSelectCard selectCard = new TrasenFrame.Forms.FrmSelectCard( searchFields , headText , mappName , colWidth );
			selectCard.sourceDataTable = tableXm;
			selectCard.ReciveString = "";
			selectCard.Width = 550;
			selectCard.Height = 200;
			selectCard.srcControl = txtChargeItem;
			selectCard.WorkForm = this;
			selectCard.ShowDialog();
			
			if ( selectCard.DialogResult == DialogResult.OK)
			{
				ChargeItem item = new ChargeItem();
				item.ItemId = Convert.ToInt32(selectCard.SelectDataRow["item_id"]);
				item.ItemName = selectCard.SelectDataRow["item_name"].ToString().Trim();
				item.TcFlag = Convert.ToInt32( selectCard.SelectDataRow["tc_flag"] );
                txtBZ.Text = selectCard.SelectDataRow["item_describe"].ToString().Trim();
				this.txtChargeItem.Text = item.ItemName;
				this.txtChargeItem.Tag = item;
				//查找该项目的执行科室并在列表中显示
				sql = "select exec_dept_id from jc_hsitem_dept where hsitem_id=" + item.ItemId + " and tcid = -1";
				if ( item.TcFlag == 1 )
					sql = "select exec_dept_id from jc_hsitem_dept where hsitem_id=" + item.ItemId + " and tcid=" + item.ItemId;
				DataTable tableDept = InstanceForm.BDatabase.GetDataTable( sql );
				for ( int i = 0 ; i< tableDept.Rows.Count ; i ++ )
				{
					int deptId = Convert.ToInt32(tableDept.Rows[i]["exec_dept_id"]);
					try
					{
						Department dept = new Department(deptId,InstanceForm.BDatabase);
						if (dept != null && !DepartmentHasSelected(dept))
						{
							ListViewItem itemDept = new ListViewItem();
							itemDept.Text = dept.DeptName;
							itemDept.Tag = dept;
							itemDept.ImageIndex = 0;
							this.lvwExecDept.Items.Add(itemDept);
						}
					}
					catch(Exception err)
					{
						MessageBox.Show(err.Message);
					}
				}
				if ( this.txtXmmc.Text == "" )
				{
					this.txtXmmc.Text = item.ItemName;
					this.txtWbm.Text = PubStaticFun.GetPYWBM(item.ItemName,1);
					this.txtPym.Text = PubStaticFun.GetPYWBM(item.ItemName,0);
					this.txtXmmc.Focus();
				}
				this.ShowMatchOrders();
			}
		}

        private void txtHYYB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8 )//|| e.KeyChar == Keys.Back
            {
                txtHYYB.Tag = -1;
                txtHYYB.Text = "";
                _idcode = 0;
            }
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                string[] headText = new string[] { "idcode" , "名称", "拼音码" };
                string[] mappName = new string[] { "idcode" , "name", "py_code" };
                int[] colWidth = new int[] { 0, 120, 75 };
                string[] searchFields = new string[] { "py_code" };
                string sql = "Select samp_code as idcode,samp_name NAME,PY_code As PY_CODE from LS_AS_SAMPLE order by samp_name";
                DataTable tableDept = InstanceForm.BDatabase.GetDataTable(sql);

                TrasenFrame.Forms.FrmSelectCard selectCard = new TrasenFrame.Forms.FrmSelectCard(searchFields, headText, mappName, colWidth);
                selectCard.sourceDataTable = tableDept;
                selectCard.ReciveString = e.KeyChar.ToString();
                selectCard.Width = 260;
                selectCard.Height = 300;
                selectCard.srcControl = txtFinddept;
                selectCard.WorkForm = this;
                selectCard.ShowDialog();
                e.Handled = true;
                if (selectCard.DialogResult == DialogResult.OK)
                {
                    txtHYYB.Text = selectCard.SelectDataRow["name"].ToString();
                    _idcode = Convert.ToInt32(selectCard.SelectDataRow["idcode"].ToString());
                }
            }
        }

	}
}
