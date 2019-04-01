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
	public enum NurseType
	{
		普通护士 = 0,
		组长护士 = 1,
		护士长 = 2
	}
	/// <summary>
	/// FrmEmployee 的摘要说明。
	/// </summary>
	public class FrmEmployee : System.Windows.Forms.Form
	{
        
        /// <summary>
        /// 修改前的前的 人员基本属性 用于保存日志 jianqg 2013-4-10 增加
        /// </summary>
        private string cznr_old = "";
		/// <summary>
		/// 当前编辑状态
		/// </summary>
		private CurrentStatus _currentStatus;
		/// <summary>
		/// 当前编辑的人员
		/// </summary>
		private Employee currentEmployee;
		/// <summary>
		/// 数据集
		/// </summary>
		private DataSet _dataset ;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtPym;
		private System.Windows.Forms.TextBox txtWbm;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cboZwjb;
		private System.Windows.Forms.ComboBox cboZcjb;
		private System.Windows.Forms.ComboBox cboRylx;
		private System.Windows.Forms.CheckBox chkCf;
		private System.Windows.Forms.CheckBox chkMz;
		private System.Windows.Forms.CheckBox chkDm;
		private System.Windows.Forms.ComboBox cboYsjb;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnDefault;
		private System.Windows.Forms.ListView lvwDept;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btnSetUser;
		private System.Windows.Forms.Button btnStatus;
		private System.Windows.Forms.GroupBox grpNurse;
		private System.Windows.Forms.RadioButton rdPths;
		private System.Windows.Forms.RadioButton rdZzhs;
		private System.Windows.Forms.RadioButton rdHsz;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button btnAddDept;
        private TextBox txtDocCode;
        private Label label8;
        private ComboBox cboSex;
        private Label label9;
        private CheckBox chkTf;
        private string biaozhi = "s";
        private Label label10;
        private TextBox txtgh;
        private Label label11;
        private Button btnClear;
        private PictureBox picSIGN;
        private Button btnOPEN;
        private Button btnView;
		private System.ComponentModel.IContainer components;
        private CheckBox chkZy;
        private Label label12;
        private ComboBox cmbSSJB;
        private Label label13;
        private Panel panel_tf;
        private CheckBox chkXd;
        private CheckBox chkhlywcfq;
        private MenuTag _menuTag;

        //public FrmEmployee()
        //{
        //    //
        //    // Windows 窗体设计器支持所必需的
        //    //
        //    InitializeComponent();

        //    //
        //    // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
        //    //
        //    this.DialogResult = DialogResult.Cancel;
        //    _currentStatus=CurrentStatus.新建状态;
        //    InitEmployeeTypeComboBox();
        //    InitDoctorTypeComboBox();
			
        //    LoadDept();
        //    btnSetUser.Visible = false;
        //    btnStatus.Visible = false;
        //}

        public FrmEmployee(MenuTag ss)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.DialogResult = DialogResult.Cancel;
            _currentStatus = CurrentStatus.新建状态;

            InitEmployeeTypeComboBox();
            InitDoctorTypeComboBox();
            this._menuTag = ss;
            LoadDept();
            if (_menuTag.Function_Name == "Fun_ts_jc_yykssz_ryk")
            {
                btnSetUser.Visible = false;
                btnStatus.Visible = false;
            }
           
            
        }


        public FrmEmployee(string ss)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.DialogResult = DialogResult.Cancel;
            _currentStatus = CurrentStatus.新建状态;
            InitEmployeeTypeComboBox();
            InitDoctorTypeComboBox();
            this.biaozhi = ss;
            LoadDept();
            btnSetUser.Visible = false;
            btnStatus.Visible = false;
         
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
                    txtPym.Enabled = false;
                    //cboRylx.Enabled = false;
                    cboSex.Enabled = false;
                    txtgh.Enabled = false;
                    panel_tf.Enabled = false;
                    btnDefault.Enabled = false;
                    btnOPEN.Enabled = false;
                    btnDel.Enabled = false; btnClear.Enabled = false; btnView.Enabled = false;
                    btnStatus.Enabled =false ;
                    btnSetUser.Enabled =false ;
                    break;
                case "Fun_ts_jc_yykssz_rs_ksry"://人事
                    chkCf.Enabled = false; chkMz.Enabled = false; chkDm.Enabled = false; chkZy.Enabled = false; chkXd.Enabled = false;
                    cmbSSJB.Enabled = false;
                    panel_tf.Enabled = false;
                    btnSetUser.Enabled =false ;
                    chkhlywcfq.Enabled = false;//add  by  chenli 2017-03-24
                    
                    break;
            }

        }

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="EmployeeId">人员编号</param>
        //public FrmEmployee(int EmployeeId)
        //{
        //    InitializeComponent();

        //    InitEmployeeTypeComboBox();
        //    InitDoctorTypeComboBox();
			
        //    LoadDept();

        //    _currentStatus=CurrentStatus.修改状态;
        //    currentEmployee = new Employee(EmployeeId,InstanceForm.BDatabase);
        //    this.txtName.Text = currentEmployee.Name;
        //    this.txtPym.Text = currentEmployee.Pym;
        //    this.txtWbm.Text = currentEmployee.Wbm;			
        //    cboRylx.Text = currentEmployee.Rylx.ToString();
        //    object objSex = InstanceForm.BDatabase.GetDataResult( "select sex from jc_employee_property where employee_id = " + currentEmployee.EmployeeId );
        //    cboSex.SelectedIndex = Convert.IsDBNull( objSex ) ? 0 : Convert.ToInt32( objSex );

        //    object objSfFlg = InstanceForm.BDatabase.GetDataResult( "select tf_flag from jc_employee_property where employee_id = " + currentEmployee.EmployeeId );
        //    txtgh.Text = InstanceForm.BDatabase.GetDataResult("select d_code from jc_employee_property where employee_id = " + currentEmployee.EmployeeId).ToString();
        //    if ( Convert.IsDBNull( objSfFlg ) )
        //    {
        //        chkTf.Checked = false;
        //    }
        //    else
        //    {
        //        chkTf.Checked = false;
        //        if ( Convert.ToInt32( objSfFlg ) == 1 )
        //        {
        //            chkTf.Checked = true;
        //        }
        //    }
            
        //    if ( currentEmployee.Rylx == EmployeeType.医生 )
        //    {
        //        Doctor doctor = new Doctor(currentEmployee.EmployeeId,InstanceForm.BDatabase);
        //        this.chkCf.Checked = doctor.CF_Right;
        //        this.chkMz.Checked = doctor.MZ_Right;
        //        this.chkDm.Checked = doctor.DM_Right;
        //        this.cboYsjb.SelectedValue = doctor.TypeID;
        //        object obj = InstanceForm.BDatabase.GetDataResult( "select ys_code from jc_role_doctor where employee_id=" + EmployeeId );
        //        this.txtDocCode.Text = obj == null ? "" : obj.ToString( ).Trim( );

        //    }
        //    else if ( currentEmployee.Rylx == EmployeeType.护士 )
        //    {
        //        string sql = "select type from jc_role_nurse where employee_id=" + currentEmployee.EmployeeId;
        //        DataRow dr = InstanceForm.BDatabase.GetDataRow(sql);
        //        if ( dr != null)
        //        {
        //            int type = Convert.ToInt32( Convert.IsDBNull(dr[0]) ? 0 : Convert.ToInt32(dr[0]));
        //            if ( type == 0 )
        //                this.rdPths.Checked = true;
        //            else if ( type == 1 )
        //                this.rdZzhs.Checked = true;
        //            else
        //                this.rdHsz.Checked = true;
        //        }
        //    }
			

        //    DataTable tableDept = currentEmployee.GetEmpRoleDept();
        //    if (tableDept != null )
        //    {
        //        for ( int i =0;i<tableDept.Rows.Count;i++)
        //        {
        //            Department dept = new Department( Convert.ToInt32(tableDept.Rows[i]["dept_Id"]),InstanceForm.BDatabase) ;
        //            if ( Convert.ToInt32( Convertor.IsNull(tableDept.Rows[i]["default_bit"],"0"))== 1)
        //            {
        //                dept.Default = 1;
        //            }
        //            ListViewItem item = new ListViewItem();
        //            item.Text = dept.DeptName;
        //            if ( dept.Default == 1 )
        //                item.ForeColor = Color.Blue;
        //            item.ImageIndex = 0;
        //            item.Tag = dept;
        //            this.lvwDept.Items.Add(item);
        //        }
        //    }

        //    picSIGN.Image = currentEmployee.GetSIGN();
        //}

        public FrmEmployee(MenuTag ss,int EmployeeId)
        {
            InitializeComponent();

            InitEmployeeTypeComboBox();
            InitDoctorTypeComboBox();
            this._menuTag = ss;
            if (_menuTag.Function_Name == "Fun_ts_jc_yykssz_ryk")
            {
                btnStatus.Visible = false;
                btnSetUser.Visible = false;
            }
            LoadDept();
        
            _currentStatus = CurrentStatus.修改状态;
            currentEmployee = new Employee(EmployeeId, InstanceForm.BDatabase);
            this.txtName.Text = currentEmployee.Name;
            this.txtPym.Text = currentEmployee.Pym;
            this.txtWbm.Text = currentEmployee.Wbm;
            cboRylx.Text = currentEmployee.Rylx.ToString();
            object objSex = InstanceForm.BDatabase.GetDataResult("select sex from jc_employee_property where employee_id = " + currentEmployee.EmployeeId);
            cboSex.SelectedIndex = Convert.IsDBNull(objSex) ? 0 : Convert.ToInt32(objSex);

            object objSfFlg = InstanceForm.BDatabase.GetDataResult("select tf_flag from jc_employee_property where employee_id = " + currentEmployee.EmployeeId);
            txtgh.Text = InstanceForm.BDatabase.GetDataResult("select d_code from jc_employee_property where employee_id = " + currentEmployee.EmployeeId).ToString();
            if (Convert.IsDBNull(objSfFlg))
            {
                chkTf.Checked = false;
            }
            else
            {
                chkTf.Checked = false;
                if (Convert.ToInt32(objSfFlg) == 1)
                {
                    chkTf.Checked = true;
                }
            }

            if (currentEmployee.Rylx == EmployeeType.医生)
            {
                Doctor doctor = new Doctor(currentEmployee.EmployeeId, InstanceForm.BDatabase);
                this.chkCf.Checked = doctor.CF_Right;
                this.chkMz.Checked = doctor.MZ_Right;
                this.chkDm.Checked = doctor.DM_Right;
                this.chkZy.Checked = doctor.ZY_Right;
              //  this.chkXd.Checked = doctor.XDCF_Right;
                this.chkhlywcfq.Checked = doctor.HlywcfRight;
                TrasenFrame.Classes.Doctor doc = new TrasenFrame.Classes.Doctor();
                

                this.cboYsjb.SelectedValue = doctor.TypeID;
                this.cmbSSJB.SelectedValue =(int) doctor.OperateRate_Type;//手术级别
                object obj = InstanceForm.BDatabase.GetDataResult("select ys_code from jc_role_doctor where employee_id=" + EmployeeId);
                this.txtDocCode.Text = obj == null ? "" : obj.ToString().Trim();
            }
            else if (currentEmployee.Rylx == EmployeeType.护士)
            {
                string sql = "select type from jc_role_nurse where employee_id=" + currentEmployee.EmployeeId;
                DataRow dr = InstanceForm.BDatabase.GetDataRow(sql);
                if (dr != null)
                {
                    int type = Convert.ToInt32(Convert.IsDBNull(dr[0]) ? 0 : Convert.ToInt32(dr[0]));
                    if (type == 0)
                        this.rdPths.Checked = true;
                    else if (type == 1)
                        this.rdZzhs.Checked = true;
                    else
                        this.rdHsz.Checked = true;
                }
            }


            DataTable tableDept = currentEmployee.GetEmpRoleDept();
            if (tableDept != null)
            {
                for (int i = 0; i < tableDept.Rows.Count; i++)
                {
                    Department dept = new Department(Convert.ToInt32(tableDept.Rows[i]["dept_Id"]), InstanceForm.BDatabase);
                    if (Convert.ToInt32(Convertor.IsNull(tableDept.Rows[i]["default_bit"], "0")) == 1)
                    {
                        dept.Default = 1;
                    }
                    ListViewItem item = new ListViewItem();
                    item.Text = dept.DeptName;
                    if (dept.Default == 1)
                        item.ForeColor = Color.Blue;
                    item.ImageIndex = 0;
                    item.Tag = dept;
                    this.lvwDept.Items.Add(item);
                }
            }
            picSIGN.Image = currentEmployee.GetSIGN();
            cznr_old = GetEmpInfo();//2014-4-10   增加
            Init_function_Name();
        }
		/// <summary>
		/// 加载科室表
		/// </summary>
		private void LoadDept()
		{
			_dataset = new DataSet();
			_dataset.Tables.Clear();

			IDbCommand cmd = InstanceForm.BDatabase.GetCommand();
			cmd.CommandText = "select 0 as rowno,dept_id as id,name,py_code,wb_code,d_code from jc_dept_property where layer=3 and deleted=0 ";
			cmd.CommandType = CommandType.Text;;

			DataTable tablePDept = InstanceForm.BDatabase.GetDataTable(cmd );
			tablePDept.TableName = "Dept";
			_dataset.Tables.Add(tablePDept);
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
		/// 初始化人员类型选择框
		/// </summary>
		private void InitEmployeeTypeComboBox()
		{
			//EmployeeType
            //cboRylx.Items.Add(EmployeeType.其他);
            //cboRylx.Items.Add(EmployeeType.医技人员);
            //cboRylx.Items.Add(EmployeeType.医生);
            //cboRylx.Items.Add(EmployeeType.护士);
            //cboRylx.Items.Add(EmployeeType.收费员);
            //cboRylx.Items.Add(EmployeeType.药库操作员);
            //cboRylx.Items.Add(EmployeeType.药房操作员);

            foreach ( object obj in Enum.GetValues( typeof( EmployeeType ) ) )
                cboRylx.Items.Add( obj.ToString() );

            cboRylx.Text = EmployeeType.其他.ToString();
		}
		/// <summary>
		/// 初始化医生级别类型选择框
		/// </summary>
		private void InitDoctorTypeComboBox()
		{
            //DataTable tableYsjb = InstanceForm.BDatabase.GetDataTable("select type_id as JBBH,type_name as JBMC from jc_doctor_type");
            //?WXZ
            DataTable tableYsjb = InstanceForm.BDatabase.GetDataTable("select 1 code ,'主任医师' name union select 2 code,'副主任医师' name union select 3 code,'主治医师' name union select 4 code, '医师' name  union select 5 code, '助理医师' name  ");
			this.cboYsjb.DisplayMember = "NAME";
			this.cboYsjb.ValueMember = "CODE";
			this.cboYsjb.DataSource = tableYsjb;

            //2013-8-13 增加手术级别
            DataTable tablessjb = InstanceForm.BDatabase.GetDataTable(" select ID CODE,NAME FROM SS_OPERATERATE  union select 0,''   ");
            this.cmbSSJB.DisplayMember = "NAME";
            this.cmbSSJB.ValueMember = "CODE";
            this.cmbSSJB.DataSource = tablessjb;


		}
		/// <summary>
		/// 保存人员信息
		/// </summary>
		private bool AddNewEmployeeInfo(out Employee newEmpoloyee)
		{

            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;

			try
			{
                EmployeeType rylx = EmployeeType.其他;
                foreach ( object obj in Enum.GetValues( typeof( EmployeeType ) ) )
                {
                    if ( ( (EmployeeType)obj ).ToString() == cboRylx.Text )
                    {
                        rylx = (EmployeeType)obj;
                        break;
                    }
                }

				newEmpoloyee = null;
				InstanceForm.BDatabase.BeginTransaction();

				ParameterEx[] paras = new ParameterEx[7];
				#region ...
				paras[0].Text = "@rybh";
				paras[0].ParaDirection=ParameterDirection.Output;
				paras[0].ParaSize=10;

				paras[1].Text = "@ryxm";
				paras[1].Value = this.txtName.Text;

				paras[2].Text = "@pym";
				paras[2].Value = this.txtPym.Text;

				paras[3].Text = "@wbm";
				paras[3].Value = this.txtWbm.Text;

				paras[4].Text = "@zwjb";
				paras[4].Value = Convert.IsDBNull(cboZwjb.SelectedValue) ? -1 : Convert.ToInt32(cboZwjb.SelectedValue);

				paras[5].Text = "@zcjb";
				paras[5].Value =  Convert.IsDBNull(cboZcjb.SelectedValue) ? -1 : Convert.ToInt32(cboZcjb.SelectedValue);
                
				paras[6].Text = "@rylx";
				paras[6].Value = (int)rylx;

               
				#endregion

				InstanceForm.BDatabase.DoCommand("up_AddEmployeeInfo",paras,30);

				if ( paras[0].Value == null )
					throw new Exception("插入人员未返回编号");

				int newId = Convert.ToInt32(paras[0].Value);

                InstanceForm.BDatabase.DoCommand( "update jc_employee_property set sex =" + cboSex.SelectedIndex + " where employee_id=" + newId );
                //D_CODE  第一部分入库
                if (txtgh.Text.Trim() != "")
                {
                    InstanceForm.BDatabase.DoCommand("update jc_employee_property set d_code =" + txtgh.Text.Trim() + " where employee_id=" + newId);
                }
                InstanceForm.BDatabase.DoCommand( "update jc_employee_property set tf_flag =" + (chkTf.Checked ? "1" : "0") + " where employee_id=" + newId );
                
				//根据不同的类型插入不同的表
				//EmployeeType rylx = (EmployeeType)cboRylx.SelectedItem;
				switch(rylx)
				{
					case EmployeeType.医生:
						#region 插入医生信息
						paras = new ParameterEx[9];
						paras[0].Text = "@rybh";
						paras[0].Value = newId;
						paras[1].Text = "@cfq";
						paras[1].Value = chkCf.Checked ? 1 : 0;
						paras[2].Text = "@mzq";
						paras[2].Value = chkMz.Checked ? 1 : 0;
						paras[3].Text = "@dmq";
						paras[3].Value = chkDm.Checked ? 1 : 0;
                        paras[4].Text = "@hlywcfq";
                        paras[4].Value =chkhlywcfq.Checked ? 1 : 0;//化疗药物处方权  2012-03-24
						paras[5].Text = "@ysjb";
                        //2013-1-16 jianqg 修改   原来使用的是 (int)rylx;
                        paras[5].Value = Convert.ToInt32(this.cboYsjb.SelectedValue); //(int)rylx;//(int)((EmployeeType)cboRylx.SelectedItem);
                        paras[6].Text = "@ysdm";
                        paras[6].Value = txtDocCode.Text;
                        paras[7].Text = "@zyq";  //中药处方权 2012-5-25 增加
                        paras[7].Value = chkZy.Checked ? 1 : 0;
                        paras[8].Text = "@ssjb";  //手术级别 2013-8-13 增加
                        paras[8].Value = Convert.ToInt16(this.cmbSSJB.SelectedValue);
                        //paras[9].Text = "@xdcfq";  //手术级别 2013-8-13 增加
                        //paras[9].Value = chkXd.Checked ? 1 : 0;
						InstanceForm.BDatabase.DoCommand("up_AddDoctorInfo",paras,30);
						#endregion
						break;
					case EmployeeType.护士:
						string sqlAddNurse = "";
						int type = 0;
						if( rdZzhs.Checked )
							type = 1;
						if ( rdHsz.Checked )
							type = 2;
						sqlAddNurse = "delete from jc_role_nurse where employee_id=" + newId;
						InstanceForm.BDatabase.DoCommand( sqlAddNurse );
						sqlAddNurse = "insert into jc_role_nurse (dept_id,employee_id,type) values(0,"+newId+","+type+")";
						InstanceForm.BDatabase.DoCommand( sqlAddNurse );
						break;
				}

				SaveEmployeeDept( newId );

                //三院数据处理
                string bz = "添加人员:【" + txtName.Text + "】";
                ts.Save_log(ts_HospData_Share.czlx.jc_人员修改, bz, "jc_employee_property", "employee_id", newId.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);


				InstanceForm.BDatabase.CommitTransaction();

				newEmpoloyee = new Employee(newId,InstanceForm.BDatabase);
				
			}
			catch(Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show(err.Message);
				newEmpoloyee = null;
				return false;
			}


            //三院数据处理
            try
            {
                string errtext = "";
                ts_HospData_Share.ts_update_log tss = new ts_HospData_Share.ts_update_log();
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_人员修改, InstanceForm.BDatabase);
                if (ty.Bzx == 1 && log_djid!=Guid.Empty)
                {
                    tss.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                }
                if (errtext != "") throw new Exception(errtext);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;

		}
		/// <summary>
		/// 更新人员信息
		/// </summary>
		private bool UpdateEmployeeInfo()
		{
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;
			string sql = "";
			try
			{
                EmployeeType rylx = EmployeeType.其他;
                foreach ( object obj in Enum.GetValues( typeof( EmployeeType ) ) )
                {
                    if ( ( (EmployeeType)obj ).ToString() == cboRylx.Text )
                    {
                        rylx = (EmployeeType)obj;
                        break;
                    }
                }

				InstanceForm.BDatabase.BeginTransaction();

				ParameterEx[] paras = new ParameterEx[8];
				#region ...
				paras[0].Text = "@rybh";
				paras[0].Value = currentEmployee.EmployeeId;

				paras[1].Text = "@ryxm";
				paras[1].Value = this.txtName.Text;

				paras[2].Text = "@pym";
				paras[2].Value = this.txtPym.Text;

				paras[3].Text = "@wbm";
				paras[3].Value = this.txtWbm.Text;

				paras[4].Text = "@zwjb";
				paras[4].Value = Convert.IsDBNull(cboZwjb.SelectedValue) ? -1 : Convert.ToInt32(cboZwjb.SelectedValue);

				paras[5].Text = "@zcjb";
				paras[5].Value =  Convert.IsDBNull(cboZcjb.SelectedValue) ? -1 : Convert.ToInt32(cboZcjb.SelectedValue);

				paras[6].Text = "@rylx";
                paras[6].Value = (int)rylx;//((EmployeeType)cboRylx.SelectedItem);

				paras[7].Text = "@OpType";
				paras[7].Value = 0 ;

                
				#endregion

				InstanceForm.BDatabase.DoCommand("up_UpdateEmployeeInfo",paras,30);
                int tfFlag = chkTf.Checked ? 1 : 0;

                InstanceForm.BDatabase.DoCommand( "Update jc_employee_property set sex = " + cboSex.SelectedIndex + ",tf_flag="+tfFlag+" where employee_id=" + currentEmployee.EmployeeId );

				sql = "delete from jc_role_doctor where employee_id=" + currentEmployee.EmployeeId;
				InstanceForm.BDatabase.DoCommand( sql );
				sql = "delete from jc_role_nurse where employee_id=" + currentEmployee.EmployeeId;
				InstanceForm.BDatabase.DoCommand( sql );
                if (txtgh.Text.Trim() != null && txtgh.Text.Trim() != "")
                {
                    InstanceForm.BDatabase.DoCommand("update jc_employee_property set d_code =" + txtgh.Text.Trim() + " where employee_id=" + currentEmployee.EmployeeId);
                }
               
				//根据不同的类型插入不同的表
				//EmployeeType rylx = (EmployeeType)cboRylx.SelectedItem;
				switch(rylx)
				{
					case EmployeeType.医生:
						#region 插入医生信息
						paras = new ParameterEx[9];
						paras[0].Text = "@rybh";
						paras[0].Value = currentEmployee.EmployeeId;
						paras[1].Text = "@cfq";
						paras[1].Value = chkCf.Checked ? 1 : 0;
						paras[2].Text = "@mzq";
						paras[2].Value = chkMz.Checked ? 1 : 0;
						paras[3].Text = "@dmq";
						paras[3].Value = chkDm.Checked ? 1 : 0;
						paras[4].Text = "@ysjb";
						paras[4].Value = Convert.ToInt32(this.cboYsjb.SelectedValue);
                        paras[5].Text = "@hlywcfq";
                        paras[5].Value = chkhlywcfq.Checked ? 1 : 0;//化疗药物处方权  2012-03-24
                        paras[6].Text = "@ysdm";
                        paras[6].Value = txtDocCode.Text;
                        paras[7].Text = "@zyq";  //中药处方权 2012-5-25 增加
                        paras[7].Value = chkZy.Checked ? 1 : 0;
                        paras[8].Text = "@ssjb";  //手术级别 2013-8-13 增加
                        paras[8].Value = Convert.ToInt16(this.cmbSSJB.SelectedValue);

                        //paras[9].Text = "@xdcfq";  //手术级别 2013-8-13 增加
                        //paras[9].Value = chkXd.Checked ? 1 : 0;

						InstanceForm.BDatabase.DoCommand("up_AddDoctorInfo",paras,30);
						#endregion
						break;
					case EmployeeType.护士:
                        int hs_type = 0;//护士类型
						if( rdZzhs.Checked )
						{
                            hs_type = 1;
						}
						if ( rdHsz.Checked )
						{
                            hs_type = 2;
						}
                        sql = "insert into jc_role_nurse (dept_id,employee_id,type) values(0," + currentEmployee.EmployeeId + "," + hs_type + ")";
						InstanceForm.BDatabase.DoCommand( sql );
						break;
				}
				SaveEmployeeDept( currentEmployee.EmployeeId );
                //2013-4-10  增加日志处理 jianqg
                
                ts_jc_log.His_Log.SaveLog( "修改人员:【ID:" + currentEmployee.EmployeeId.ToString() +":"+ txtName.Text + "】的信息", cznr_old + " 修改后：" +  GetEmpInfo(), InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);

                //三院数据处理
                string bz = "修改人员:【" + txtName.Text + "】的信息";
                ts.Save_log(ts_HospData_Share.czlx.jc_人员修改, bz, "jc_employee_property", "employee_id", currentEmployee.EmployeeId.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);


				InstanceForm.BDatabase.CommitTransaction();

			}
			catch(Exception err)
			{
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show(err.Message);
				return false;
			}
            

            //三院数据处理
            try
            {
                string errtext = "";
                ts_HospData_Share.ts_update_log tss = new ts_HospData_Share.ts_update_log();
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_人员修改, InstanceForm.BDatabase);
                if (ty.Bzx == 1 && log_djid != Guid.Empty)
                {
                    tss.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                }
                if (errtext != "") throw new Exception(errtext);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("发生错误" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cznr_old =GetEmpInfo();//jianqg  2013-4-10 增加
            return true;

		}
        /// <summary>
        /// jianqg 2013-4-10 增加 用于记录日志
        /// </summary>
        /// <returns></returns>
        private string GetEmpInfo()
        {
            int hs_type = 0;//护士类型
            if (rdZzhs.Checked)
            {
                hs_type = 1;
            }
            if (rdHsz.Checked)
            {
                hs_type = 2;
            }
            string cznr = "人员类型：" + cboRylx.Text + ",处方{0},麻醉{1},毒麻{2},中医处方{3},医生级别{4},能退费 {5},护士类型{6},默认科室{7}，所在科室{8}，所在科室{9},协定处方权{10},化疗药物处方权{11}";
            string strDept_def = "";//首选科室
            string strDept_all = "";//所在科室
            foreach (ListViewItem item in this.lvwDept.Items)
            {
                if (strDept_all != "") strDept_all += ",";
                strDept_all += ((Department)item.Tag).DeptId.ToString();

                if (item.ForeColor == Color.Blue) strDept_def = ((Department)item.Tag).DeptId.ToString();
            }
            cznr = string.Format(cznr, new object[] { chkCf.Checked, chkMz.Checked, chkDm.Checked, chkZy.Checked, Convertor.IsNull(this.cboYsjb.SelectedValue, ""), chkTf.Checked, hs_type, strDept_def, strDept_all, Convertor.IsNull(this.cmbSSJB.SelectedValue, ""),chkXd.Checked, chkhlywcfq.Checked});
            return cznr;
        }
		/// <summary>
		/// 保存人员科室
		/// </summary>
		/// <param name="rybh"></param>
		/// <returns></returns>
		private bool SaveEmployeeDept(int rybh)
		{
			try
			{
                SystemCfg cfg26 = new SystemCfg(26);  //是否并库
                //2013-5-16 jianqg  处理 his中默认科室的问题
				InstanceForm.BDatabase.DoCommand("Delete From jc_emp_dept_role where employee_id = " + rybh);
                if (cfg26.Config == "1") InstanceForm.BDatabase.DoCommand("Delete From dict_user_dept_role where user_id  = '" + rybh + "'");
				foreach(ListViewItem item in this.lvwDept.Items )
				{
                    if (item.ForeColor == Color.Blue)
                    {
                        InstanceForm.BDatabase.DoCommand("insert into jc_emp_dept_role (employee_id,dept_id,xtbh,[default]) values (" + rybh + "," + ((Department)item.Tag).DeptId + ",0,1)");
                        if (cfg26.Config == "1") InstanceForm.BDatabase.DoCommand("insert into dict_user_dept_role(user_id,dept_id,default_dept_flag,synchro_flag) values ('" + rybh + "'," + ((Department)item.Tag).DeptId + ",1,1)");
                    }
                    else
                    {
                        InstanceForm.BDatabase.DoCommand("insert into jc_emp_dept_role (employee_id,dept_id,xtbh,[default]) values (" + rybh + "," + ((Department)item.Tag).DeptId + ",0,0)");
                        if (cfg26.Config == "1") InstanceForm.BDatabase.DoCommand("insert into dict_user_dept_role(user_id,dept_id,default_dept_flag,synchro_flag) values ('" + rybh + "'," + ((Department)item.Tag).DeptId + ",0,1)");
                    }
				}
				return true;
			}
			catch(Exception err)
			{
				throw err;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmployee));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPym = new System.Windows.Forms.TextBox();
            this.txtWbm = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboZwjb = new System.Windows.Forms.ComboBox();
            this.cboZcjb = new System.Windows.Forms.ComboBox();
            this.cboRylx = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkXd = new System.Windows.Forms.CheckBox();
            this.cmbSSJB = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkZy = new System.Windows.Forms.CheckBox();
            this.txtDocCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboYsjb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkDm = new System.Windows.Forms.CheckBox();
            this.chkMz = new System.Windows.Forms.CheckBox();
            this.chkCf = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddDept = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lvwDept = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSetUser = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.grpNurse = new System.Windows.Forms.GroupBox();
            this.rdHsz = new System.Windows.Forms.RadioButton();
            this.rdZzhs = new System.Windows.Forms.RadioButton();
            this.rdPths = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel_tf = new System.Windows.Forms.Panel();
            this.chkTf = new System.Windows.Forms.CheckBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnOPEN = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.picSIGN = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtgh = new System.Windows.Forms.TextBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chkhlywcfq = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpNurse.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel_tf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSIGN)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "拼音码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(674, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "五笔码";
            this.label3.Visible = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(86, 14);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(188, 26);
            this.txtName.TabIndex = 0;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // txtPym
            // 
            this.txtPym.Location = new System.Drawing.Point(86, 44);
            this.txtPym.MaxLength = 30;
            this.txtPym.Name = "txtPym";
            this.txtPym.Size = new System.Drawing.Size(188, 26);
            this.txtPym.TabIndex = 1;
            // 
            // txtWbm
            // 
            this.txtWbm.Location = new System.Drawing.Point(746, 100);
            this.txtWbm.Name = "txtWbm";
            this.txtWbm.Size = new System.Drawing.Size(166, 26);
            this.txtWbm.TabIndex = 8;
            this.txtWbm.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Location = new System.Drawing.Point(220, 501);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "保存";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(298, 501);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "人员类型";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(672, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "职务级别";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "职称级别";
            this.label6.Visible = false;
            // 
            // cboZwjb
            // 
            this.cboZwjb.Location = new System.Drawing.Point(744, 24);
            this.cboZwjb.Name = "cboZwjb";
            this.cboZwjb.Size = new System.Drawing.Size(166, 24);
            this.cboZwjb.TabIndex = 18;
            this.cboZwjb.Visible = false;
            // 
            // cboZcjb
            // 
            this.cboZcjb.Location = new System.Drawing.Point(744, 66);
            this.cboZcjb.Name = "cboZcjb";
            this.cboZcjb.Size = new System.Drawing.Size(166, 24);
            this.cboZcjb.TabIndex = 19;
            this.cboZcjb.Visible = false;
            // 
            // cboRylx
            // 
            this.cboRylx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRylx.Location = new System.Drawing.Point(86, 74);
            this.cboRylx.Name = "cboRylx";
            this.cboRylx.Size = new System.Drawing.Size(188, 24);
            this.cboRylx.TabIndex = 2;
            this.cboRylx.SelectedIndexChanged += new System.EventHandler(this.cboRylx_SelectedIndexChanged);
            this.cboRylx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboRylx_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkhlywcfq);
            this.groupBox1.Controls.Add(this.chkXd);
            this.groupBox1.Controls.Add(this.cmbSSJB);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.chkZy);
            this.groupBox1.Controls.Add(this.txtDocCode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboYsjb);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chkDm);
            this.groupBox1.Controls.Add(this.chkMz);
            this.groupBox1.Controls.Add(this.chkCf);
            this.groupBox1.Location = new System.Drawing.Point(12, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 128);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "医生属性";
            // 
            // chkXd
            // 
            this.chkXd.AutoSize = true;
            this.chkXd.Location = new System.Drawing.Point(332, 18);
            this.chkXd.Name = "chkXd";
            this.chkXd.Size = new System.Drawing.Size(107, 20);
            this.chkXd.TabIndex = 9;
            this.chkXd.Text = "协定处方权";
            // 
            // cmbSSJB
            // 
            this.cmbSSJB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSSJB.Location = new System.Drawing.Point(294, 72);
            this.cmbSSJB.Name = "cmbSSJB";
            this.cmbSSJB.Size = new System.Drawing.Size(163, 24);
            this.cmbSSJB.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(222, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "手术级别";
            // 
            // chkZy
            // 
            this.chkZy.AutoSize = true;
            this.chkZy.Location = new System.Drawing.Point(229, 18);
            this.chkZy.Name = "chkZy";
            this.chkZy.Size = new System.Drawing.Size(107, 20);
            this.chkZy.TabIndex = 6;
            this.chkZy.Text = "中医处方权";
            // 
            // txtDocCode
            // 
            this.txtDocCode.Location = new System.Drawing.Point(71, 97);
            this.txtDocCode.MaxLength = 30;
            this.txtDocCode.Name = "txtDocCode";
            this.txtDocCode.Size = new System.Drawing.Size(98, 26);
            this.txtDocCode.TabIndex = 5;
            this.txtDocCode.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "代码";
            this.label8.Visible = false;
            // 
            // cboYsjb
            // 
            this.cboYsjb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYsjb.Location = new System.Drawing.Point(71, 72);
            this.cboYsjb.Name = "cboYsjb";
            this.cboYsjb.Size = new System.Drawing.Size(147, 24);
            this.cboYsjb.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "医生级别";
            // 
            // chkDm
            // 
            this.chkDm.AutoSize = true;
            this.chkDm.Location = new System.Drawing.Point(154, 18);
            this.chkDm.Name = "chkDm";
            this.chkDm.Size = new System.Drawing.Size(75, 20);
            this.chkDm.TabIndex = 2;
            this.chkDm.Text = "毒麻权";
            // 
            // chkMz
            // 
            this.chkMz.AutoSize = true;
            this.chkMz.Location = new System.Drawing.Point(80, 18);
            this.chkMz.Name = "chkMz";
            this.chkMz.Size = new System.Drawing.Size(75, 20);
            this.chkMz.TabIndex = 1;
            this.chkMz.Text = "麻醉权";
            // 
            // chkCf
            // 
            this.chkCf.AutoSize = true;
            this.chkCf.Location = new System.Drawing.Point(6, 18);
            this.chkCf.Name = "chkCf";
            this.chkCf.Size = new System.Drawing.Size(75, 20);
            this.chkCf.TabIndex = 0;
            this.chkCf.Text = "处方权";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddDept);
            this.groupBox2.Controls.Add(this.btnDefault);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.lvwDept);
            this.groupBox2.Location = new System.Drawing.Point(12, 340);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(463, 115);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "所在科室";
            // 
            // btnAddDept
            // 
            this.btnAddDept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddDept.Location = new System.Drawing.Point(160, 89);
            this.btnAddDept.Name = "btnAddDept";
            this.btnAddDept.Size = new System.Drawing.Size(75, 26);
            this.btnAddDept.TabIndex = 0;
            this.btnAddDept.Text = "添加";
            this.btnAddDept.Click += new System.EventHandler(this.btnAddDept_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDefault.Location = new System.Drawing.Point(320, 89);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 26);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "首选";
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnDel
            // 
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDel.Location = new System.Drawing.Point(240, 89);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 26);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lvwDept
            // 
            this.lvwDept.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvwDept.Location = new System.Drawing.Point(3, 22);
            this.lvwDept.Name = "lvwDept";
            this.lvwDept.Size = new System.Drawing.Size(457, 64);
            this.lvwDept.SmallImageList = this.imageList1;
            this.lvwDept.TabIndex = 0;
            this.lvwDept.UseCompatibleStateImageBehavior = false;
            this.lvwDept.View = System.Windows.Forms.View.List;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // btnSetUser
            // 
            this.btnSetUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetUser.Location = new System.Drawing.Point(134, 501);
            this.btnSetUser.Name = "btnSetUser";
            this.btnSetUser.Size = new System.Drawing.Size(82, 26);
            this.btnSetUser.TabIndex = 24;
            this.btnSetUser.Text = "设置用户";
            this.btnSetUser.Click += new System.EventHandler(this.btnSetUser_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStatus.Location = new System.Drawing.Point(56, 501);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 26);
            this.btnStatus.TabIndex = 25;
            this.btnStatus.Text = "停用";
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // grpNurse
            // 
            this.grpNurse.Controls.Add(this.rdHsz);
            this.grpNurse.Controls.Add(this.rdZzhs);
            this.grpNurse.Controls.Add(this.rdPths);
            this.grpNurse.Location = new System.Drawing.Point(12, 128);
            this.grpNurse.Name = "grpNurse";
            this.grpNurse.Size = new System.Drawing.Size(463, 48);
            this.grpNurse.TabIndex = 3;
            this.grpNurse.TabStop = false;
            this.grpNurse.Text = "护士属性";
            // 
            // rdHsz
            // 
            this.rdHsz.Location = new System.Drawing.Point(226, 17);
            this.rdHsz.Name = "rdHsz";
            this.rdHsz.Size = new System.Drawing.Size(100, 22);
            this.rdHsz.TabIndex = 2;
            this.rdHsz.Text = "护士长";
            // 
            // rdZzhs
            // 
            this.rdZzhs.Location = new System.Drawing.Point(118, 17);
            this.rdZzhs.Name = "rdZzhs";
            this.rdZzhs.Size = new System.Drawing.Size(100, 22);
            this.rdZzhs.TabIndex = 1;
            this.rdZzhs.Text = "组长护士";
            // 
            // rdPths
            // 
            this.rdPths.Location = new System.Drawing.Point(12, 17);
            this.rdPths.Name = "rdPths";
            this.rdPths.Size = new System.Drawing.Size(100, 22);
            this.rdPths.TabIndex = 0;
            this.rdPths.Text = "普通护士";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(488, 493);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel_tf);
            this.tabPage1.Controls.Add(this.btnView);
            this.tabPage1.Controls.Add(this.btnOPEN);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.btnClear);
            this.tabPage1.Controls.Add(this.picSIGN);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtgh);
            this.tabPage1.Controls.Add(this.cboSex);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtPym);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.grpNurse);
            this.tabPage1.Controls.Add(this.cboRylx);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(480, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "人员属性";
            // 
            // panel_tf
            // 
            this.panel_tf.Controls.Add(this.chkTf);
            this.panel_tf.Location = new System.Drawing.Point(18, 304);
            this.panel_tf.Name = "panel_tf";
            this.panel_tf.Size = new System.Drawing.Size(457, 30);
            this.panel_tf.TabIndex = 26;
            // 
            // chkTf
            // 
            this.chkTf.Location = new System.Drawing.Point(3, 8);
            this.chkTf.Name = "chkTf";
            this.chkTf.Size = new System.Drawing.Size(337, 24);
            this.chkTf.TabIndex = 18;
            this.chkTf.Text = "能进行退费操作";
            // 
            // btnView
            // 
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Font = new System.Drawing.Font("宋体", 9F);
            this.btnView.Location = new System.Drawing.Point(386, 8);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(29, 23);
            this.btnView.TabIndex = 25;
            this.btnView.Text = "大";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnOPEN
            // 
            this.btnOPEN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOPEN.Font = new System.Drawing.Font("宋体", 9F);
            this.btnOPEN.Location = new System.Drawing.Point(326, 8);
            this.btnOPEN.Name = "btnOPEN";
            this.btnOPEN.Size = new System.Drawing.Size(29, 23);
            this.btnOPEN.TabIndex = 24;
            this.btnOPEN.Text = "选";
            this.btnOPEN.UseVisualStyleBackColor = true;
            this.btnOPEN.Click += new System.EventHandler(this.btnOPEN_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(297, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "签名";
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("宋体", 9F);
            this.btnClear.Location = new System.Drawing.Point(356, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(29, 23);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "清";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // picSIGN
            // 
            this.picSIGN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSIGN.Location = new System.Drawing.Point(295, 32);
            this.picSIGN.Name = "picSIGN";
            this.picSIGN.Size = new System.Drawing.Size(174, 67);
            this.picSIGN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSIGN.TabIndex = 21;
            this.picSIGN.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(234, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "工号";
            // 
            // txtgh
            // 
            this.txtgh.Location = new System.Drawing.Point(297, 100);
            this.txtgh.Name = "txtgh";
            this.txtgh.Size = new System.Drawing.Size(175, 26);
            this.txtgh.TabIndex = 19;
            this.txtgh.Leave += new System.EventHandler(this.txtgh_leave);
            // 
            // cboSex
            // 
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "未指定",
            "男",
            "女"});
            this.cboSex.Location = new System.Drawing.Point(86, 101);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(114, 24);
            this.cboSex.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "性别";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(3, 499);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 32);
            this.label12.TabIndex = 28;
            this.label12.DoubleClick += new System.EventHandler(this.label12_DoubleClick);
            // 
            // chkhlywcfq
            // 
            this.chkhlywcfq.AutoSize = true;
            this.chkhlywcfq.Location = new System.Drawing.Point(6, 46);
            this.chkhlywcfq.Name = "chkhlywcfq";
            this.chkhlywcfq.Size = new System.Drawing.Size(139, 20);
            this.chkhlywcfq.TabIndex = 10;
            this.chkhlywcfq.Text = "化疗药物处方权";
            // 
            // FrmEmployee
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(491, 532);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.btnSetUser);
            this.Controls.Add(this.cboZcjb);
            this.Controls.Add(this.cboZwjb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWbm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEmployee";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加人员";
            this.Load += new System.EventHandler(this.FrmEmployee_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.grpNurse.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel_tf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSIGN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e)
		{

            if (InstanceForm._menuTag.Function_Name == "Fun_ts_jc_yykssz_yw_ry")
            {   
                //医务 医生 = 1,护士 = 2,其他 = 7,医技人员 = 6,
                if (!(cboRylx.SelectedValue != null && (cboRylx.SelectedValue.ToString() == "1" || cboRylx.SelectedValue.ToString() == "2" || cboRylx.SelectedValue.ToString() == "7")))
                {
                    MessageBox.Show("该人员类型只可设置位医生 = 1,护士 = 2,其他 = 7,医技人员 = 6,请重新输入", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //txtName.Text = txtName.Text.Trim().Replace(" ", "");

			if ( txtName.Text.Trim() == "" )
			{
				MessageBox.Show("姓名不能为空","",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
            if (txtgh.Text.Trim() != "" && this._currentStatus == CurrentStatus.新建状态)
            {
               int a =  Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select count(*) from jc_employee_property where d_code = '" + txtgh.Text.Trim() + "'",60));
               if (a > 0)
               {
                   MessageBox.Show("该工号存在,请重新输入", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   return;
               }
            }
            if(txtgh.Text.Trim() == "")
            {
                if(MessageBox.Show("工号为空,是否保存？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                return;
            }
            
			else
			{
                 txtgh.Text= txtgh.Text.Trim();
                  //jianqg 2014-6-30 增加判断 必须为数字
                 if (TrasenClasses.GeneralClasses.Convertor.IsInteger(txtgh.Text) == false)
                 {
                     MessageBox.Show("工号输入错误，必须为数字（整数）！！！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;

                 }
				if ( this._currentStatus == CurrentStatus.新建状态 )
				{
                    if ( InstanceForm.BDatabase.GetDataRow("select * from jc_employee_property where name = '" + txtName.Text + "'") != null)
					{
						if ( MessageBox.Show("已经存在一个姓名为" + txtName.Text + "的人员,是否继续操作?\n\n如果需要查看请在列表中查询\n\n如果不在列表中,可能已经被置无效,请在无效数据中查询","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
						{
							return;
						}
					}
				}
			}
			if ( lvwDept.Items.Count > 0 && lvwDept.Items.Count != 1)
			{
				bool setDefault = false;
				foreach(ListViewItem item in this.lvwDept.Items)
				{
					if ( ((Department)item.Tag).Default == 1 )
					{
						setDefault = true;
						break;
					}
				}
				if ( !setDefault )
				{
					MessageBox.Show("请指定一个首选科室！","",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
			}
			else if ( lvwDept.Items.Count == 1 )
			{
				lvwDept.Items[0].ForeColor = Color.Blue;
			}
			else
			{
				MessageBox.Show("没有分配科室！","",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
            //医生代码重复判断
            /*
            if ( ( (EmployeeType)cboRylx.SelectedItem ) == EmployeeType.医生 )
            {
                if ( txtDocCode.Text.Trim( ) == "" )
                {
                    if ( MessageBox.Show( "医生代码未填写，是否继续保存？" , "警告" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                    {
                        return;
                    }
                }
                string sql = "";
                if ( this._currentStatus == CurrentStatus.新建状态 )
                {
                    sql = "select employee_id,ys_code from jc_role_doctor where ys_code='" + txtDocCode.Text + "'";
                }
                else
                {
                    sql = "select employee_id,ys_code from jc_role_doctor where ys_code='" + txtDocCode.Text + "' and employee_id<>" + currentEmployee.EmployeeId;
                }
                if ( InstanceForm.BDatabase.GetDataRow( sql ) != null )
                {
                    MessageBox.Show( "输入的医生代码已经在使用中","错误",MessageBoxButtons.OK,MessageBoxIcon.Error );
                    return;
                }
            }
             * */
            try
            {
                if (this._currentStatus == CurrentStatus.新建状态)
                {
                    Employee newEmployee;
                    if (AddNewEmployeeInfo(out newEmployee) == false)
                    {
                        return;
                    }
                    if ((_menuTag.Function_Name == "Fun_ts_jc_yykssz_xxk" || _menuTag.Function_Name == "Fun_ts_jc_yykssz_ryk_qx") && MessageBox.Show("保存成功是否为该人员分配用户名？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        TrasenFrame.Forms.FrmAddUser fAddUser = new TrasenFrame.Forms.FrmAddUser(newEmployee.EmployeeId);
                        fAddUser.ShowDialog();
                    }

                    if (picSIGN.Image != null)
                        newEmployee.SaveSIGN(picSIGN.Tag.ToString());
                }
                else
                {
                    if (UpdateEmployeeInfo() == false)
                        return;
                    if (picSIGN.Image == null && (picSIGN.Tag == null || picSIGN.Tag.ToString() == ""))
                        currentEmployee.SaveSIGN("");
                    else if (picSIGN.Image != null && picSIGN.Tag != null && picSIGN.Tag.ToString() != "")
                        currentEmployee.SaveSIGN(picSIGN.Tag.ToString());
                }

                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception err)
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show(err.Message);
            }
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}



		private void txtName_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{

			if ( e.KeyCode == Keys.Enter )
			{
				this.txtPym.Text = PubStaticFun.GetPYWBM(this.txtName.Text,0);
				this.txtWbm.Text= PubStaticFun.GetPYWBM(this.txtName.Text,1);
				cboRylx.Focus();
			}

		}
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
	
		private void FrmEmployee_Load(object sender, System.EventArgs e)
		{
			
		}

		private void cboRylx_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            EmployeeType rylx = EmployeeType.其他;
            foreach ( object obj in Enum.GetValues( typeof( EmployeeType ) ) )
            {
                if ( ( (EmployeeType)obj ).ToString() == cboRylx.Text )
                {
                    rylx = (EmployeeType)obj;
                    break;
                }
            }

			if ( rylx == EmployeeType.医生 )
			{
				this.groupBox1.Enabled = true;
				this.grpNurse.Enabled = false;
                chkTf.Enabled = false;
                chkTf.Checked = false;
			}
			else if ( rylx == EmployeeType.护士 )
			{
				this.groupBox1.Enabled = false;
				this.grpNurse.Enabled = true;
                chkTf.Enabled = false;
                chkTf.Checked = false;
			}
            else if ( rylx == EmployeeType.收费员 )
            {
                this.groupBox1.Enabled = false;
                this.grpNurse.Enabled = false;
                chkTf.Enabled = true;
            }
            else
            {
                this.groupBox1.Enabled = false;
                this.grpNurse.Enabled = false;
                chkTf.Enabled = false;
                chkTf.Checked = false;
            }
            Init_function_Name();
		}
	
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			if ( lvwDept.SelectedItems.Count > 0 )
			{
				lvwDept.Items.Remove(lvwDept.SelectedItems[0]);
			}
		}

		private void btnDefault_Click(object sender, System.EventArgs e)
		{
			if (lvwDept.SelectedItems.Count == 0 ) return ;
			foreach( ListViewItem item in this.lvwDept.Items )
			{
				item.ForeColor = Color.Black;
				((Department)item.Tag).Default = 0;
			}
			lvwDept.SelectedItems[0].ForeColor = Color.Blue;
			((Department)lvwDept.SelectedItems[0].Tag).Default = 1;
		}

		private void btnSetUser_Click(object sender, System.EventArgs e)
		{
            if (this.currentEmployee == null) return;
            TrasenFrame.Forms.FrmAddUser fUser = null;
			fUser = new TrasenFrame.Forms.FrmAddUser(this.currentEmployee.EmployeeId);
			fUser.ShowDialog();
		}

		private void btnStatus_Click(object sender, System.EventArgs e)
		{
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;

			if ( this.currentEmployee != null )
			{
				if ( MessageBox.Show("确定要将当前人员置无效吗?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question ) == DialogResult.Yes )
				{
					InstanceForm.BDatabase.BeginTransaction();
					try
					{
						string sql = "update jc_employee_property set delete_bit=1 where employee_id=" + this.currentEmployee.EmployeeId;
						InstanceForm.BDatabase.DoCommand( sql );
						sql = "select * from pub_user where employee_id=" + this.currentEmployee.EmployeeId;
						DataRow dr = InstanceForm.BDatabase.GetDataRow( sql );
						if ( dr != null )
						{
							sql = "delete from pub_user where employee_id=" + this.currentEmployee.EmployeeId;
							InstanceForm.BDatabase.DoCommand( sql );
							sql = "delete from pub_group_user where user_id=" + dr["id"].ToString();
							InstanceForm.BDatabase.DoCommand( sql );
						}

                        //三院数据处理
                        string bz = "停用人员:【" + txtName.Text + "】";
                        ts.Save_log(ts_HospData_Share.czlx.jc_人员修改, bz, "jc_employee_property", "employee_id", this.currentEmployee.EmployeeId.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);


						InstanceForm.BDatabase.CommitTransaction();
						this.DialogResult = DialogResult.OK;
						this.Close();
					}
					catch(Exception err)
					{
						InstanceForm.BDatabase.RollbackTransaction();
						MessageBox.Show(err.Message);
					}


                    //三院数据处理
                    try
                    {
                        string errtext = "";
                        ts_HospData_Share.ts_update_log tss = new ts_HospData_Share.ts_update_log();
                        ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_人员修改, InstanceForm.BDatabase);
                        if (ty.Bzx == 1 && log_djid != Guid.Empty)
                        {
                            tss.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                        }
                        if (errtext != "") throw new Exception(errtext);
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show("发生错误" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

				}
			}
		}

		private void btnAddDept_Click(object sender, System.EventArgs e)
		{
			string [] searchFields = new string[]{"py_code" } ;
			string[] headText = new string[]{"dept_id","科室名","拼音码"};
			string[] mappName = new string[]{"dept_id","name","py_code"};
			int[] colWidth =new int[]{0,200,75};

            string sql = "select dept_id ,name,py_code from jc_dept_property where layer=3 and deleted=0"; //and jgbm =" + InstanceForm._menuTag.Jgbm.ToString();
			DataTable tableDept = InstanceForm.BDatabase.GetDataTable( sql );
			
			TrasenFrame.Forms.FrmSelectCard fSelect = new TrasenFrame.Forms.FrmSelectCard(searchFields,headText,mappName,colWidth);
			fSelect.sourceDataTable = tableDept;
			fSelect.StartPosition = FormStartPosition.CenterScreen;
			fSelect.ShowDialog();
			if ( fSelect.DialogResult == DialogResult.OK )
			{
				Department dept = new Department( Convert.ToInt32(fSelect.SelectDataRow["dept_id"]),InstanceForm.BDatabase);
				foreach(ListViewItem _item in this.lvwDept.Items )
				{
					if ( ((Department)_item.Tag).DeptId == dept.DeptId )
					{
						return;
					}
				}
				ListViewItem item = new ListViewItem();
				item.Text = dept.DeptName;
				item.ImageIndex = 0;
				if ( lvwDept.Items.Count == 0 )
				{
					item.ForeColor = Color.Blue;
					dept.Default = 1;
				}
				item.Tag = dept;
				this.lvwDept.Items.Add ( item );
				btnAddDept.Focus();
			}
		}

		private void cboRylx_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( (int)e.KeyChar == 13 )
			{
				btnAddDept.Focus();
			}
		}

        private void txtgh_leave(object sender, EventArgs e)
        {
            if (txtgh.Text == null || txtgh.Text.Trim() == "") return;
            int s = InstanceForm.BDatabase.DoCommand("select * from JC_EMPLOYEE_PROPERTY where d_code = '"+txtgh.Text.Trim()+"'",60);
            if (s > 0)
            {
                MessageBox.Show("该工号被占用！", "工号提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtDocCode.Text = txtgh.Text;
        }

        private void btnOPEN_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.bmp|*.bmp|*.jpg|*.jpg|*.*|*.*";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picSIGN.Image = new Bitmap(dlg.FileName);
                    picSIGN.Tag = dlg.FileName;
                }
                catch
                {
                    MessageBox.Show("无效的图片格式","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            picSIGN.Image = null;
            picSIGN.Tag = "";
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (picSIGN.Image != null)
            {
                Form fView = new Form();
                PictureBox pic = new PictureBox();
                pic.Image = picSIGN.Image;
                pic.Dock = DockStyle.Fill;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                fView.Controls.Add(pic);
                fView.Size = new Size(150, 150);
                fView.ShowDialog(this);
            }
        }

        private void label12_DoubleClick(object sender, EventArgs e)
        {
            if (_currentStatus != CurrentStatus.修改状态) return;

            if (InstanceForm.BCurrentUser.IsAdministrator)
            {
                string yymc = new SystemCfg(2, InstanceForm.BDatabase).Config.ToString();
                if (yymc.Contains("浏阳市中医医院") == false) return; //浏阳中医院 2013-7-12 要求 开放此功能：wianxz,jianqg
                Cursor = Cursors.AppStarting;
                string scode = currentEmployee.EmployeeId.ToString();
                if (scode != "" && scode != null)
                {
                    string sPwd = InstanceForm.BDatabase.GetDataResult("select password from pub_user where Employee_Id=" + scode).ToString().Trim();
                    if (sPwd != "")
                    {
                        sPwd = TrasenClasses.GeneralClasses.Crypto.Instance().Decrypto(sPwd);
                    }
                    Clipboard.SetDataObject(sPwd);
                }
                MessageBox.Show("ok");
                Cursor = Cursors.Default;
            }
        }


	}
}
